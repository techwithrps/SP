<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExportInvoicePrintLineDetention.aspx.vb"
    Inherits="Commercial_Preview_ExportInvoicePrintLineDetention" Theme="Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .FormLabel {
            text-align: left;
        }
    </style>
    <style type="text/css">
        body {
            font-family: Calibri;
            font-size: xx-small;
            font-style: normal;
        }

        .FormTextBoxLeft {
        }

        .auto-style1 {
            width: 61px;
        }

        .auto-style2 {
            width: 106px;
        }

        .auto-style3 {
            width: 2px;
        }

        .auto-style6 {
            width: 315px;
        }

        .auto-style7 {
            width: 901px;
        }

        .auto-style8 {
            width: 875px;
        }
    </style>
    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var printButton = document.getElementById("printpagebutton");
            //Set the print button visibility to 'hidden' 
            printButton.style.visibility = 'hidden';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.visibility = 'visible';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wholepage">
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" height="10px" width="100%">
                            <tr>
                                <td align="center" width="10%" valign="top">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Image ID="imglogo" runat="server" Width="170px" Height="100px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" width="100%">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" align="center" style="text-decoration: none; font-family: Calibri; font-size: 20pt">
                                                <b>
                                                    <asp:Label ID="lblHeaderText" runat="server" Text="Tax Invoice"></asp:Label></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="text-decoration: none; font-family: Calibri; font-size: 15pt">
                                                <asp:Label ID="lblCDtls" runat="server" Text="SPJ CARGO PVT.LTD." Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lblCompanyName1" CssClass="FormLabel" Text="Complete Logistics Solution Provider"
                                                    runat="server"></asp:Label>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lblTerminaladdress0" CssClass="FormLabel" Text="D-9/3, Okhla Industrial Area Phase-1, New Delhi-110020"
                                                    runat="server"></asp:Label>
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="Center">
                                                <asp:Label ID="labGSTN" CssClass="FormTextBoxLeft" runat="server" Text="GSTIN:" Font-Size="Small"></asp:Label>
                                                <asp:Label ID="labService" CssClass="FormTextBoxLeft" runat="server" Text="07AAFPB3130K1Z5"
                                                    Font-Size="Small"></asp:Label>
                                            </td>
                                            <td align="Center">
                                                <asp:Label ID="Label26" CssClass="FormTextBoxLeft" runat="server" Text="PAN:" Font-Size="Small"></asp:Label>
                                                <asp:Label ID="lblPan" CssClass="FormTextBoxLeft" runat="server" Text="AAFPB3130K"
                                                    Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" Font-Size="11pt" Text="Delhi, India"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td align="center" colspan="2">&nbsp;&nbsp;
                                            <asp:Label ID="lblCIN1" CssClass="FormTextBoxLeft" runat="server" Text="CIN :" Font-Size="Small"></asp:Label>
                                                <asp:Label ID="Label2" CssClass="FormTextBoxLeft" runat="server" Text="U63013DL2003PTC121227"
                                                    Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lblcmContact0" runat="server" Text="Tel: +91 - 11-41062143-2147" Font-Size="11pt"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lblEmail" CssClass="FormTextBoxLeft" runat="server" Text="Email: accounts@spjcargo.com"
                                                    Font-Size="Small"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="Original For Receipent" Width="160"  Font-Size="10" Font-Bold="true" />
                                    <br />
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Duplicate For Supplier" Width="160" Font-Size="10" Font-Bold="true" />--%>
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="160" Font-Size="10pt"
                                        Font-Bold="True" Font-Overline="False">
                                        <asp:ListItem Value="1" Selected="True">Original For Receipent</asp:ListItem>
                                        <asp:ListItem Value="2">Duplicate For Supplier</asp:ListItem>
                                    </asp:CheckBoxList>
                                    <input id="printpagebutton" type="button" value="Print" onclick="printpage()" />
                                </td>
                                <td>
                                    <asp:PlaceHolder ID="plBarCode" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" height="100%" frame="Box">
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="Label28" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                        Text="To, "></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left" style="width: 190px">
                                    <asp:Label ID="lblCustomerName" Font-Bold="true" Font-Size="Medium" CssClass="FormLabel"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="Label1" runat="server" CssClass="FormTextBoxLeft" Text="Add" Font-Size="Small"></asp:Label>&nbsp;
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblcustomeradd" CssClass="FormTextBoxLeft"
                                        Font-Size="Small" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="sb" runat="server">
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="textStateCode" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                        Text="State Code"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textCustomerState" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="cha" runat="server">
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="textGSTIN" runat="server" Font-Size="Small" Text="GSTIN" CssClass="FormTextBoxLeft"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textCustomerGSTIN" CssClass="FormLabel" runat="server" Text="07HYSPT6767J98V"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblCustomerType" Width="120px" CssClass="FormLabel" Text="Customer Type"
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textCustomerType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblLine" Width="60px" CssClass="FormLabel" Text="Line" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textLine" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblBlNo" Width="60px" CssClass="FormLabel" Text="BL No" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textBlNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr id="TrNote" runat="server">
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblShippingBill" Width="90px" CssClass="FormLabel" Text="SB No." runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textSbNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblShippingDate" Width="90px" CssClass="FormLabel" Text="SB Date"
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextShippingBillDate" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server">
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblETDSOV" Width="120px" CssClass="FormLabel" Text="ETD/SOB DATE"
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textsobdate" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table width="100%" height="100%" frame="Box">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="lblConsignor" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                        Text="Invoice No."></asp:Label>
                                </td>
                                <td class="auto-style3">:
                                </td>
                                <td>
                                    <asp:Label ID="textInvoiceNo" Font-Bold="true" Width="160px" CssClass="FormLabel"
                                        runat="server"></asp:Label>
                                    <br />
                                    <asp:HiddenField ID="hdnAdvance" runat="server" />
                                    <asp:HiddenField ID="HdnLineItemId" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="lblIDate" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                        Text="Dated"></asp:Label>
                                </td>
                                <td class="auto-style3">:
                                </td>
                                <td>
                                    <asp:Label ID="textInvoiceDate" Font-Bold="true" Width="110px" CssClass="FormLabel"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblJob" Width="60px" CssClass="FormLabel" Text="Job No" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left" style="width: 250px">
                                    <asp:Label ID="TextJob" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblMode" Width="120px" CssClass="FormLabel" Text="Mode Of Shipment"
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextOfMode" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblPlaceOfSupply" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                        Text="Place of Supply"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textPlaceOfSupply" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                        Text="07-Delhi"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblContSize" Width="60px" CssClass="FormLabel" Text="Size" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textContSize" CssClass="FormLabel" runat="server" Text="Size"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblContType" Width="60px" CssClass="FormLabel" Text="Type" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textContType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblConsignee" Width="60px" CssClass="FormLabel" Text="Consignee" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textConsignee" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="lblPort" Width="60px" CssClass="FormLabel" Text="POL" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="textPort" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="LblPOD" Width="60px" CssClass="FormLabel" Text="POD" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextPod" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                <td align="left" class="auto-style2">
                                    <asp:Label ID="LblFPOD" Width="60px" CssClass="FormLabel" Text="FPOD" runat="server"></asp:Label>
                                </td>
                                <td align="left" class="auto-style3">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextFPOD" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td align="Right" style="width: 200px">
                                    <asp:Label ID="lblFromLocation" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                        Text="Empty Pickup"></asp:Label>
                                </td>
                                <td align="left">:
                                </td>
                                <td align="left" style="width: 200px">
                                    <asp:Label ID="textLocationFrom" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                                <%--<td align="right">
                                    <asp:Label ID="lblToLocation" Width="130px" CssClass="FormTextBoxLeft" Text="Factory Location"
                                        runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:
                                </td>
                                <td align="left" style="width: 200px">
                                    <asp:Label ID="textToLocation" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>--%>
                                <td align="right" style="width: 200px">
                                    <asp:Label ID="Label7" CssClass="FormTextBoxLeft" Text="Clerance Port" runat="server"
                                        Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:
                                </td>
                                <td align="left" style="width: 200px">
                                    <asp:Label ID="textHandover" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <%-- <tr>
                <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 5px;">
                </td>
            </tr>--%>
                <tr>
                    <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri; font-size: 11pt">
                        <strong>MOVEMENT DETAILS</strong>
                    </td>
                </tr>
                <%--   <tr>
                <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 2px;">
                </td>
            </tr>--%>
                <tr>
                    <td valign="top" align="center" colspan="2">
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <div>
                                        <asp:GridView ID="gvContainerDetail" Font-Size="10pt" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" Width="950px">
                                            <RowStyle Font-Size="10pt"></RowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.">
                                                    <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:BoundField ItemStyle-Width="38px" DataField="GR_NO" HeaderStyle-HorizontalAlign="center"
                                                ItemStyle-HorizontalAlign="center" HeaderText="GR No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VEHICLE_NO" HeaderStyle-HorizontalAlign="center"
                                                ItemStyle-HorizontalAlign="center" HeaderText="Vehicle No"></asp:BoundField>
                                                --%>
                                                <asp:BoundField ItemStyle-Width="400px" DataField="PO_NO" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Party Inv No."></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="100px" DataField="PO_DATE" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="DATE"></asp:BoundField>
                                              <%--  <asp:BoundField ItemStyle-Width="155px" DataField="GROSS_WT" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Gross Wt."></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="200px" DataField="CARTONS" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Packages"></asp:BoundField>
                                            --%>    <asp:BoundField ItemStyle-Width="75px" DataField="CONT_NO" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Container No"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="85px" DataField="ICD_OUT_DATE" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="ICD Out Date"></asp:BoundField>
                                                    <asp:BoundField ItemStyle-Width="85px" DataField="ICD_IN_DATE" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="ICD In Date"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="85px" DataField="HANDOVER_DATE" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Handover Date"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="47px" DataField="FREE_DAYS" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Free Days"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="47px" DataField="TOTAL_DAYS" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Total Days"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="47px" DataField="DET_DAYS" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Det. Days"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="47px" DataField="DET_AMT" HeaderStyle-HorizontalAlign="center"
                                                    ItemStyle-HorizontalAlign="center" HeaderText="Det Amt."></asp:BoundField>
                                            </Columns>
                                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%-- <tr>
                <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt; height: 12px">
                </td>
            </tr>--%>
                <tr>
                    <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri; font-size: 11pt; height: 12px">
                        <strong>SUMMARY OF CHARGES</strong>
                    </td>
                </tr>
                <%-- <tr>
                <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 2px;">
                </td>
            </tr>--%>
                <tr>
                    <td valign="top" align="center" colspan="2">
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <div>
                                        <asp:GridView ID="gvPaymentDetail" runat="server" AutoGenerateColumns="False" Font-Size="10pt" ShowFooter="True">
                                            <RowStyle Font-Size="10pt" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.">
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex + 1 %>
                                                        </asp:hiddenfield>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SERVICE" HeaderStyle-HorizontalAlign="Center" HeaderText="Services" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="left" ItemStyle-Width="320px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Names="Arial" HorizontalAlign="Left" Width="320px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SERVICE_CODE" HeaderStyle-HorizontalAlign="Center" HeaderText="HSN/SAC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QNTY" HeaderStyle-HorizontalAlign="Center" HeaderText="Qnty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EX_RATE" HeaderStyle-HorizontalAlign="Center" HeaderText="Ex. Rate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CURRENCY" HeaderStyle-HorizontalAlign="Center" HeaderText="Currency" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="55px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="55px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BILL_RATE" HeaderStyle-HorizontalAlign="Center" HeaderText="Rate" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <%-- Added 24/07/2024 by Adarsh --%>
                                                <asp:BoundField DataField="USD_AMOUNT" HeaderStyle-HorizontalAlign="Center" HeaderText="Taxable Value $" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AMOUNT" HeaderStyle-HorizontalAlign="Center" HeaderText="Taxable Value INR" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <%-- End --%>
                                                <asp:BoundField DataField="C_RATE" HeaderStyle-HorizontalAlign="Center" HeaderText="CGST Rate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="HECESS" HeaderStyle-HorizontalAlign="Center" HeaderText="CGST Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="H_RATE" HeaderStyle-HorizontalAlign="Center" HeaderText="SGST Rate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ECESS" HeaderStyle-HorizontalAlign="Center" HeaderText="SGST Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="S_RATE" HeaderStyle-HorizontalAlign="Center" HeaderText="IGST Rate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SERVICE_TAX" HeaderStyle-HorizontalAlign="Center" HeaderText="IGST Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TAX_AMOUNT" HeaderStyle-HorizontalAlign="Center" HeaderText="Tax Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TOTAL_AMOUNT" HeaderStyle-HorizontalAlign="Center" HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <tr>
                                            <td colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                        <table>
                                            <tr id="TrUsd" runat="server">
                                                <td>
                                                    <asp:Label ID="Label6" CssClass="FormTextBoxLeft" Font-Size="12px" runat="server"><b>Amount in USD :- </b></asp:Label>
                                                    <asp:Label ID="TxtUsd" CssClass="FormTextBoxLeft" runat="server" Font-Size="12px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblInWord" CssClass="FormTextBoxLeft" Font-Size="12px" runat="server"><b>Amount in Words :- </b></asp:Label>
                                                    <asp:Label ID="lblAmountsInWords" CssClass="FormTextBoxLeft" runat="server" Font-Size="12px" />
                                                </td>
                                            </tr>

                                        </table>
                                        <tr>
                                            <td colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="">
                        <table frame="box" style="width: 100%; height: 100%;">
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 12;">
                                     <asp:Label ID="lblNote" style = "text-decoration:underline" CssClass="FormLabel" Font-Bold="true" Font-Size="12" runat="server"
                                        Text="Invoice Note : "></asp:Label>
                                    <asp:Label ID="txtInvoiceNote" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 12;">
                                    <asp:Label ID="lblIrnNo" CssClass="FormTextBoxLeft" Font-Size="Medium" Text="IRN :- "
                                        Font-Bold="true" runat="server"></asp:Label>
                                    <asp:Label ID="textIrnNo" CssClass="FormTextBoxLeft" Font-Size="Medium"                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td style="width: 50%; height: 130px;">
                        <table frame="box" style="width: 100%; height: 100%;">
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 16;">
                                    <b>
                                        <asp:Label ID="lblTerms" Text="Terms & Conditions" runat="server" Font-Size="12" /></b>
                                </td>
                            </tr>
                                   <tr>
                                <td colspan="2" style="height: 10px; font-size: 10;">
                                    <b>
                                        <asp:Label ID="Label8" Font-Bold="false" Text=" 1. Payment due 5 days from Invoice date."
                                            runat="server" Font-Size="12" /></b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 10;">
                                    <b>
                                        <asp:Label ID="Label4" Font-Bold="false" Text=" 2. Delayed payments: 24% p.a. Interest."
                                            runat="server" Font-Size="12" /></b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 10;">
                                    <b>
                                        <asp:Label ID="Label5" Font-Bold="false" Text="3. Dispute Raise within 5 days."
                                            runat="server" Font-Size="12" /></b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 10px; font-size: 10;">
                                    <b>
                                        <asp:Label ID="Label3" Font-Bold="false" Text=" 4. All Disputes Subject to the Delhi Jurisdiction."
                                            runat="server" Font-Size="12" /></b>
                                </td>
                            </tr>
                            <%-- <tr>
                            <td>
                                <asp:Label ID="LblElectronicRefN" runat="server" Text="Electronic Reference Number :-"
                                    Font-Size="X-Small" CssClass="FormTextBoxLeft"></asp:Label>
                                <asp:Label ID="LblErefNo" runat="server" Font-Size="X-Small" CssClass="FormTextBoxLeft"></asp:Label>
                            </td>
                        </tr>--%>

                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" style="font-size: 10pt; width: 50%; height: 130px;">
                        <table frame="box" style="width: 100%; height: 100%; text-align: right;">
                            <tr>
                                <td align="left" valign="top" colspan="2" class="auto-style1">
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label25" runat="server" Text="Bank Details" Font-Size="Large" Font-Bold="true"></asp:Label>
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td align="left" class="style2">
                                                            <asp:Label ID="Label11" CssClass="FormTextBoxHead" runat="server" Font-Size="Medium"
                                                                Text="SPJ CARGO PVT. LTD."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LblAccountNo" runat="server" Font-Size="Medium" Text="A/C No. :"></asp:Label>
                                                            <asp:Label ID="lblAcNo1" runat="server" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="LblIFSC" runat="server" Font-Size="Medium" Text="IFSC Code:"></asp:Label>
                                                            <asp:Label ID="txtIFSC" runat="server" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSwift" runat="server" Font-Size="Medium" Text="SWIFT Code:"></asp:Label>
                                                            <asp:Label ID="txtSwift" runat="server" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="style2">
                                                            <asp:Label ID="Label13" runat="server" Font-Size="Medium" Text="Bank Name.:"></asp:Label>
                                                            <asp:Label ID="TxtBank" runat="server" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25px" align="left">
                                                            <asp:Label ID="Label14" runat="server" Font-Size="Medium" Text="Branch.:"></asp:Label>
                                                            <asp:Label ID="Txtbranch" runat="server" Font-Size="Medium"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="" style="font-size: 13pt;">
                                    <asp:Label ID="lblSignComapny" runat="server" Font-Size="16" Style="font-weight: 700"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <b>Authorized Signatory</b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana; font-size: 12px; text-align: left" colspan="3">
                        <p>
                            &nbsp;
                        </p>
                    </td>
                </tr>
        </div>
        <asp:Button ID="btnPDF" Text="ToPDF" runat="server" OnClick="btnPDF_Click" Visible="false" />
        <asp:Button ID="btnRTF" Text="ToRTF" runat="server" OnClick="btnRTF_Click" Visible="false" />
    </form>
</body>
</html>
