<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GRPrint1.aspx.vb" Inherits="Fleet_PRINT_GRPrint1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: GR Print</title>
    <style type="text/css">
        .FormLabel
        {
            font-family: Calibri;
            text-align: left;
            font-size: 18px;
        }
        
        
        .FormTextBoxHead
        {
            font-family: Calibri;
            text-align: left;
            font-size: 22px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div align="center" style="height: 1500px;">
        <table align="center" width="100%">
            <tr>
                <td height="105px" colspan="3" align="center">
                </td>
            </tr>
            <tr>
                <td height="25px" colspan="3" align="center">
                </td>
            </tr>
            <tr>
                <td height="35px" colspan="3" align="center">
                </td>
            </tr>
            <tr>
                <td height="25px" align="center">
                </td>
                <td height="25px" align="center">
                </td>
            </tr>
            <tr>
                <td height="25px" align="center">
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1100px; height: 208px;">
            <tr>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none;
                    border-left: none;">
                    <asp:Label ID="lblConsigner" Font-Bold="False" CssClass="FormLabel" runat="server"
                        Text="Consignor " Width="115px"></asp:Label>
                </td>
                <td width="450px" align="left" colspan="2" style="border-bottom: none; border-top: none;">
                    <asp:Label ID="textConsigner" Width="90%" CssClass="FormTextBoxHead" Font-Bold="false"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none;
                    border-left: none;">
                    <asp:Label ID="lblGrNo" runat="server" Text="GR No" CssClass="FormLabel "></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-top: none; border-bottom: none; border-right: none;">
                    <asp:Label ID="textGrNo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsignee" CssClass="FormLabel" runat="server" Text="Consignee "
                        Width="115px"></asp:Label>
                    &nbsp;
                </td>
                <td align="left" colspan="2" style="border-bottom: none;">
                    <asp:Label ID="textConsignee" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lbldate" runat="server" Text="Date" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textdate" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck" CssClass="FormLabel" runat="server" Text="Trailor/Truck No  "></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-bottom: none;">
                    <asp:Label ID="textTruck" Width="145px" CssClass="FormTextBoxHead" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Labelform" runat="server" Text="From" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextFrom" runat="server" Text="[ ] DELHI [ ] GDL [ ] PATLI [ ] LONI  <br/> [ ]  DADRI [ ] LDH [ ] FBD [ ] MBD [ ] PNP"
                        CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Text="BE No  " Width="115px"></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-bottom: none;">
                    <asp:Label ID="textBE" Width="65px" CssClass="FormLabel" runat="server"></asp:Label>
                    <asp:Label ID="Label16" CssClass="FormLabel" runat="server" Text="Date" Width="115px"></asp:Label>
                    <asp:Label ID="Label21" CssClass="FormLabel" runat="server"></asp:Label>
                    <asp:Label ID="Label22" CssClass="FormLabel" runat="server" Text="CST No." Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="LblTo" runat="server" Text="To" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" colspan="2" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextTo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblno" runat="server" CssClass="FormLabel" Text="No of  Pkgs"></asp:Label>
                </td>
                <td colspan="2" style="border-bottom: none;">
                    <asp:Label ID="LblDescription" runat="server" CssClass="FormLabel" Text="DESCRIPTION AS GOODS WEIGHT"></asp:Label>
                </td>
                <td style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblRate" runat="server" CssClass="FormLabel" Text="RATE"></asp:Label>
                </td>
                <td style="border-bottom: none;">
                    <asp:Label ID="LblFreight" runat="server" CssClass="FormLabel" Text="FREIGHTS </br> Paid   &nbsp;   To Pay "></asp:Label>
                </td>
                <td style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="LblRemarks" runat="server" CssClass="FormLabel" Text="REMARKS "></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1100px; border-top: none; height: 408px;">
            <tr>
                <td style="width: 140PX; border-bottom: none; border-top: none; border-right: none;
                    border-left: none;">
                    <asp:Label ID="TextPkg" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                </td>
                <td align="left" style="width: 430px; border-bottom: none; border-top: none; border-right: none;">
                    <div>
                        <asp:GridView ID="gvContDetail" AlternatingRowStyle-CssClass="FormListBoxLarg" RowStyle-CssClass="FormListBoxLarg"
                            AutoGenerateColumns="False" runat="server">
                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                            <Columns>
                                <asp:BoundField ItemStyle-Width="135px" DataField="CONT_NO" HeaderText="Cont No"
                                    HeaderStyle-CssClass="FormLabel"></asp:BoundField>
                                <asp:BoundField ItemStyle-Width="85px" DataField="CONT_SIZE" HeaderText="Cont Size"
                                    HeaderStyle-CssClass="FormLabel"></asp:BoundField>
                                <asp:BoundField ItemStyle-Width="90px" DataField="SEAL_NO" HeaderText="Seal No" HeaderStyle-CssClass="FormLabel">
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="70px" DataField="BE_NO" HeaderText="BE No" HeaderStyle-CssClass="FormLabel">
                                </asp:BoundField>
                            </Columns>
                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </td>
                <td rowspan="8" style="width: 70px; border-right: none; border-bottom: none; border-top: none;">
                    <asp:Image ID="Image1" runat="server" Width="30px" />
                    &nbsp;
                </td>
                <td rowspan="8" style="width: 70px; border-right: none; border-bottom: none; border-top: none;">
                    &nbsp;
                </td>
                <td rowspan="8" style="width: 70px; border-right: none; border-bottom: none; border-top: none;">
                    &nbsp;
                </td>
                <td rowspan="8" style="width: 70px; border-right: none; border-bottom: none; border-top: none;">
                    &nbsp;
                </td>
                <td rowspan="8" style="width: 232px; border-right: none; border-bottom: none; border-top: none;">
                    <asp:Image ID="Image2" runat="server" Width="30px" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-top: none; border-left: none; border-right: none;">
                </td>
                <td style="text-align: Left; width: 350px; border-bottom: none; border-top: none;
                    border-right: none;" colspan="2">
                </td>
            </tr>
            <tr>
                <td style="border-left: none; border-bottom: none; border-top: none; border-right: none;">
                    &nbsp;
                </td>
                <td colspan="2" style="border-bottom: none; height: 60px; border-right: none; border-top: none;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-top: none; border-left: none; border-right: none;">
                </td>
                <td style="text-align: left; border-bottom: none; border-top: none; border-right: none;">
                    <asp:Label ID="lblInvoiceNo" runat="server" CssClass="FormLabel" Text="Value Rs"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-left: none; border-top: none; border-right: none;">
                </td>
                <td style="text-align: left; border-bottom: none; border-top: none; border-right: none;">
                    <asp:Label ID="LblFactoryIn" runat="server" CssClass="FormLabel" Text="Loading"></asp:Label>
                    <asp:Label ID="textFactoryIn" runat="server" Width="130px" CssClass="FormLabel"></asp:Label>
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label9" runat="server" Text="Hrs. Dt" CssClass="FormLabel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-left: none; border-top: none; border-right: none;">
                </td>
                <td style="text-align: left; border-bottom: none; border-top: none; border-right: none;">
                    <asp:Label ID="lblFactoryOut" runat="server" CssClass="FormLabel" Text="Site Reporting"></asp:Label>
                    <asp:Label ID="textReporting" runat="server" Width="112px" CssClass="FormLabel"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Hrs. Dt" CssClass="FormLabel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-left: none; border-top: none; border-right: none;">
                </td>
                <td style="text-align: left; border-bottom: none; border-top: none; border-right: none;">
                    <asp:Label ID="lblOwnerRisk" runat="server" CssClass="FormLabel" Text="Site Release"></asp:Label>
                    <asp:Label ID="textRelease" runat="server" Width="130px" CssClass="FormLabel"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Hrs. Dt" CssClass="FormLabel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-left: none; border-top: none; border-right: none;">
                </td>
                <td style="text-align: left; border-bottom: none; border-top: none; border-right: none;">
                    <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="OWNER RISK" Font-Size="40px"
                        ForeColor="Red" CssClass="FormLabel"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                    <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="(SIG OF AUTH REP.)"
                        CssClass="FormLabel"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
