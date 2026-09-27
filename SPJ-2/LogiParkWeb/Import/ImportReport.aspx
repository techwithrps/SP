<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImportReport.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Import_ImportReport"
    Title="eLOGiFleet :: Import Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

</script>

    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
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
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Import Report" Width="400px"
                    CssClass="FormLabelTitle"> </asp:Label>
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
                        <td align="left">
                            <asp:Label ID="lblShipper" runat="server" Text="Shipper Name " CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstShipper" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPOD" runat="server" Text="POD " CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <%--<td align="left">
                                            <asp:Label ID="lblrTerminal" runat="server" CssClass="FormLabel" Text="Terminal Name"></asp:Label>
                                        </td>
                                        <td align="left" rowspan="2">
                                            <div style="height: 100px; overflow: auto; width: 100%">
                                                <asp:Repeater ID="rptTerminal" runat="server">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" rules="all" border="1" style="border: 1px solid #CCC;">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </td>
                                                            <td>
                                                               
                                                                <asp:Label ID="lstTerminalName2" CssClass="FormLabel" Text='<%# Eval("TERMINAL_NAME")%>' runat="server" />
                                                                <asp:HiddenField ID="hddTerminalCode" Value='<%# Eval("TERMINAL_ID")%>' runat="server" />
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                               
                                            </div>
                                          
                                        </td>--%>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="Terminal Name"></asp:Label>
                        </td>
                        <td>
                            <div style="height: 100px; overflow: auto; width: 100%; position: relative" class="FormLabel">
                                <span class="multi-check">
                                    <asp:CheckBox ID="chkAll" Text="Select All" runat="server" OnCheckedChanged="Check_UnCheckAll" AutoPostBack="true" /></span>
                                <asp:CheckBoxList ID="lstTerminalName" runat="server" ToolTip="TerminalName" Width="150px" Style="border: 1px solid #CCC;"></asp:CheckBoxList>
                            </div>
                        </td>


                        <td align="right">
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
                            <td colspan="51">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="JO_DATE" HeaderText="Month"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="JO_NO" HeaderText="JOB No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="JO_DATE" HeaderText="JOB Date "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="BILL_TO" HeaderText="Billing Party"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER" HeaderText="Shipper Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CONSIGNEE" HeaderText="Consignee Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SHIPPER_INV_NO" HeaderText="Inv No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SHIPPER_INV_DATE" HeaderText="Inv. Dt."></asp:BoundField>
                                             <asp:BoundField ItemStyle-Width="150px" DataField="FPOD" HeaderText="Clearance Port"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="POL" HeaderText="POL/Origin"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="COUNTRY_NAME" HeaderText="Country"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BOE_NO" HeaderText="BOE No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BOE_DATE" HeaderText="BOE Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="CARTONS" HeaderText="No of PCS."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="GROSS_WT" HeaderText="Gross Wt."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="COMMODITY_NAME" HeaderText="Commodity Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_NO" HeaderText="Conatiner No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CONT_SIZE" HeaderText="SIZE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CONT_TYPE" HeaderText="TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="210px" DataField="LINE_NAME" HeaderText="Line Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CBM" HeaderText="CBM"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MBL_NO" HeaderText="Bl/Awb No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="HBL_NO" HeaderText="Hbl/Hawb No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="MODE_TYPE" HeaderText="Mode Of Shipment"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="TRIP_TYPE" HeaderText="Doc Type"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CWC" HeaderText="CWC/Celebi/ICD Charges"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="DO_CHARGES" HeaderText="Do Charges"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TPT_CHARGES" HeaderText="TPT Charges"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="S_LINE_CHARGES" HeaderText="S/Line Payment"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CASH_EXP" HeaderText="Cash Exp"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="OTHER_EXP" HeaderText="Other Exp."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_REF_NO" HeaderText="SPJ Bill No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_DATE" HeaderText="SPJ Bill Dt."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BILL_AMOUNT" HeaderText="Amount"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="EXTRA_CHARGES" HeaderText="Extra Charged to Customere"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="REBATE_CHARGES" HeaderText="Rebate to Customer"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="IMP_REMARKS" HeaderText="Remarks"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="Label2" runat="server" Width="1500px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="" Width="60px" CssClass="FormLabel"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Width="10px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
