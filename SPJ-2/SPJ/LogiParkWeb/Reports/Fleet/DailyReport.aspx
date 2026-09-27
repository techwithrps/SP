<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DailyReport.aspx.vb" Inherits="Reports_Fleet_DailyReport" Title="eLOGiFleet :: Daily Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Daily Report" Width="400px" CssClass="FormLabelTitle">
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
    <table>
        <tr>
            <td>
                <table width="100%">

                    <tr>
                        <td style="text-align: left; width: 244px;">
                            <asp:Label ID="Label2" runat="server" Text="Export" Font-Bold="true" CssClass="FormLabel"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 244px">
                            <div style="width: 100%;">
                                <table cellspacing="0" id="tblReport" runat="server">
                                    <tr class="RepheaderNew">
                                        <td style="width: 20px">
                                            <asp:Label ID="lblSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                                Width="33px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblrDetails" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="Location" Width="100px"></asp:Label>
                                        </td>
 <td>
                                            <asp:Label ID="Label31" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No"
                                                Width="90px"></asp:Label>
                                        </td>
  <td>
                                            <asp:Label ID="Label30" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer"
                                                Width="160px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbl20" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vehicle No"
                                                Width="80px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblr40" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                                Width="40px"></asp:Label>
                                        </td>

                                       
                                        <td>
                                            <asp:Label ID="lbl40rf" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblrTues" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total"
                                                Width="40px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="11">
                                            <div style="height: 115px; overflow: auto;">
                                                <asp:GridView ID="gvExport" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="30px"  />
                                                        <asp:BoundField ItemStyle-Width="90px" DataField="TO_VIA_JRY" />
  <asp:BoundField ItemStyle-Width="90px" DataField="CONT_NO" />
  <asp:BoundField ItemStyle-Width="160px" DataField="CUSTOMER" />
                                
                                                      
                                                        <asp:BoundField ItemStyle-Width="80px" DataField="VEHICLE_NO" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="VEHICLE_SIZE" />
                                                      
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_IN" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_IN" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="TOTAL" />
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="text-align: left; width: 244px;">
                            <asp:Label ID="Label1" runat="server" Text="Import" Font-Bold="true" CssClass="FormLabel"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 244px">
                            <div style="width: 100%;">
                                <table cellspacing="0" id="tblImport" runat="server">
                                    <tr class="RepheaderNew">
                                        <td>
                                            <asp:Label ID="Label6" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                                Width="33px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Location"
                                                Width="90px"></asp:Label>
                                        </td>
<td>
                                            <asp:Label ID="Label51" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No"
                                                Width="90px"></asp:Label>
                                        </td>

                                         <td>
                                            <asp:Label ID="Label80" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer"
                                                Width="160px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vehicle No"
                                                Width="80px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                                Width="40px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total"
                                                Width="40px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="11">
                                            <div style="height: 125px; overflow: auto;">
                                                <asp:GridView ID="gvImport" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                      <asp:BoundField ItemStyle-Width="30px"  />
                                                        <asp:BoundField ItemStyle-Width="90px" DataField="TO_VIA_JRY" />
  <asp:BoundField ItemStyle-Width="90px" DataField="CONT_NO" />
                                                        <asp:BoundField ItemStyle-Width="160px" DataField="CUSTOMER" />
                                                      
                                                        <asp:BoundField ItemStyle-Width="80px" DataField="VEHICLE_NO" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="VEHICLE_SIZE" />

                                
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_IN" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_IN" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="TOTAL" />
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="text-align: left; width: 244px;">
                            <asp:Label ID="Label15" runat="server" Text="Domestic" Font-Bold="true" CssClass="FormLabel"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 244px">
                            <div style="width: 100%;">
                                <table cellspacing="0" id="tblDomestic" runat="server">
                                    <tr class="RepheaderNew">
                                        <td style="width: 20px">
                                            <asp:Label ID="Label16" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                                Width="33px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Location"
                                                Width="90px"></asp:Label>
                                        </td>
<td>
                                            <asp:Label ID="Label81" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No"
                                                Width="90px"></asp:Label>
                                        </td>
  <td>
                                            <asp:Label ID="Label70" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer"
                                                Width="160px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label18" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vehicle No"
                                                Width="80px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                                Width="40px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label21" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory Out"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label23" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD In"
                                                Width="110px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total"
                                                Width="40px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="11">
                                            <div style="height: 125px; overflow: auto;">
                                                <asp:GridView ID="gvDomestic" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                       <asp:BoundField ItemStyle-Width="30px" />
                                                        <asp:BoundField ItemStyle-Width="90px" DataField="TO_VIA_JRY" />
  <asp:BoundField ItemStyle-Width="90px" DataField="CONT_NO" />

                                                        <asp:BoundField ItemStyle-Width="160px" DataField="CUSTOMER" />
                                                      
                                                        <asp:BoundField ItemStyle-Width="80px" DataField="VEHICLE_NO" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="VEHICLE_SIZE" />
                                
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_IN" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_OUT" />
                                                        <asp:BoundField ItemStyle-Width="110px" DataField="ICD_IN" />
                                                        <asp:BoundField ItemStyle-Width="40px" DataField="TOTAL" />
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table id="tblsummary" runat="server" cellspacing="0">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="Label29" runat="server" Text="Summary" Font-Bold="true" CssClass="FormLabel"></asp:Label>
                        </td>
                    </tr>
                    <tr class="RepheaderNew">
                        <td style="width: 20px">
                            <asp:Label ID="Label25" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                Width="33px"></asp:Label>
                        </td>
 <td>
                            <asp:Label ID="Label26" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer"
                                Width="160px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label36" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Location"
                                Width="60px"></asp:Label>
                        </td>
 <td>
                            <asp:Label ID="Label46" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Type"
                                Width="40px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label28" CssClass="FormLabel" runat="server" Font-Bold="True" Text="20"
                                Width="40px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label57" CssClass="FormLabel" runat="server" Font-Bold="True" Text="40"
                                Width="40px"></asp:Label>
                        </td>
<td>
                            <asp:Label ID="Label27" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total"
                                Width="40px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <div style="height: 404px; overflow: auto;">
                                <asp:GridView ID="gvsummary" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="30px" />

                                        <asp:BoundField ItemStyle-Width="160px" DataField="LOCATION" />
                                        <asp:BoundField ItemStyle-Width="60px" DataField="TO_VIA_JRY" />
                                        <asp:BoundField ItemStyle-Width="40px" DataField="TRIP_Type" />
                                        <asp:BoundField ItemStyle-Width="40px" DataField="SIZE_20" />
                                        <asp:BoundField ItemStyle-Width="40px" DataField="SIZE_40" />

                                        <asp:BoundField ItemStyle-Width="40px" DataField="Total" />
                                    </Columns>
                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
 
<td colspan="4">
                            <asp:Label ID="texttotal1" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Total"></asp:Label>
                        </td>

                        <td style="text-align:left">
                            <asp:Label ID="textTotal20" runat="server" Width="40px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                        </td>
                        <td style="text-align:left">
                            <asp:Label ID="textTotal40" runat="server" Width="40px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                        </td>
  <td style="text-align:left">
                            <asp:Label ID="textTotalT" runat="server" Width="40px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
<tr>
 <td>
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
</tr>
    </table>
</asp:Content>
