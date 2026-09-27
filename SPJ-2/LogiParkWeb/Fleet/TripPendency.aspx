<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/TripPendency.aspx.vb" Inherits="Fleet_TripPendency" Title="eLOGiFreight :: Trip Pendency"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="Trip Pendency" CssClass="FormLabelTitle">
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="dvtabControl" runat="server" style="vertical-align: middle; width: 100%;">
                            <ajaxToolkit:TabContainer runat="server" ID="tabTripPendency" Width="100%" ActiveTabIndex="0"
                                AutoPostBack="true">
                                <ajaxToolkit:TabPanel runat="server" ID="tabPendnencyExp" TabIndex="0" HeaderText="Export">
                                    <ContentTemplate>
                                        <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                                            <tr class="RepheaderNew" align="center" width="200px" style="height:20px">
                                                <td>
                                                    <asp:Label ID="lblrSr" CssClass="labelHeader" runat="server" Text="Sr " Width="42px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" CssClass="labelHeader" runat="server" Text="Line" Width="180px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrContNo" CssClass="labelHeader" runat="server" Text="Cont No" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrSize" CssClass="labelHeader" runat="server" Text="Size" Width="50px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrType" CssClass="labelHeader" runat="server" Text="Type" Width="55px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrCustomer" CssClass="labelHeader" runat="server" Text="Customer"
                                                        Width="250px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrLocation" CssClass="labelHeader" runat="server" Text="Location"
                                                        Width="150px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrProgramDate" runat="server" CssClass="labelHeader" Text="Program Date"
                                                        Width="115px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEximRemarks" runat="server" CssClass="labelHeader" Text="Remarks"
                                                        Width="124px"></asp:Label>
                                                </td>
                                                <td style="width: 15px; background-color: White;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="11">
                                                    <div style="height: 398px; overflow: auto;">
                                                        <asp:GridView ID="gvtripPendencyList" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="38px" DataField=""></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="180px" DataField="LINE"></asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="CONT_NO" DataNavigateUrlFormatString="GrMapping.aspx?MTY_CONT_ID={0}"
                                                                    ItemStyle-Width="100px" DataNavigateUrlFields="MTY_CONT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="LOCATION_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="PROGRAM_DATE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="REMARKS"></asp:BoundField>
                                                            </Columns>
                                                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            
                                <ajaxToolkit:TabPanel runat="server" ID="TabImport" TabIndex="0" HeaderText="Import">
                                    <ContentTemplate>
                                        <table cellspacing="0" cellpadding="0" id="Table3" runat="server">
                                            <tr class="RepHeadFleet">
                                                <td>
                                                    <asp:Label ID="Label9" CssClass="labelHeader" runat="server" Text="Sr " Width="42px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" CssClass="labelHeader" runat="server" Text="Cont No" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" CssClass="labelHeader" runat="server" Text="Size" Width="50px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label20" CssClass="labelHeader" runat="server" Text="Type" Width="55px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label22" CssClass="labelHeader" runat="server" Text="Customer" Width="250px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label23" CssClass="labelHeader" runat="server" Text="Location" Width="150px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server" CssClass="labelHeader" Text="Program Date"
                                                        Width="115px"></asp:Label>
                                                </td>
                                             
                                                <td>
                                                    <asp:Label ID="Label27" runat="server" CssClass="labelHeader" Text="Remarks" Width="115px"></asp:Label>
                                                </td>
                                                <td style="width: 15px; background-color: White;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="9">
                                                    <div style="height: 398px; overflow: auto;">
                                                        <asp:GridView ID="gvImport" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="38px" DataField=""></asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="CONT_NO" DataNavigateUrlFormatString="GrMapping.aspx?MTY_CONT_ID={0}"
                                                                    ItemStyle-Width="100px" DataNavigateUrlFields="MTY_CONT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER_name"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="LOCATION_name"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="PROGRAM_DATE"></asp:BoundField>
                                                            
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="REMARKS"></asp:BoundField>
                                                            </Columns>
                                                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel runat="server" ID="tabLocation" TabIndex="1" HeaderText="Domestic">
                                    <ContentTemplate>
                                        <table cellspacing="0" cellpadding="0" id="Table1" runat="server">
                                            <tr class="RepHeadFleet">
                                                <td>
                                                    <asp:Label ID="Label1" CssClass="labelHeader" runat="server" Text="Sr " Width="42px"></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label12" CssClass="labelHeader" runat="server" Text="Line" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" CssClass="labelHeader" runat="server" Text="Cont No" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" CssClass="labelHeader" runat="server" Text="Size" Width="50px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" CssClass="labelHeader" runat="server" Text="Type" Width="55px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" CssClass="labelHeader" runat="server" Text="Customer" Width="250px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" CssClass="labelHeader" runat="server" Text="Location" Width="150px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" CssClass="labelHeader" Text="Program Date"
                                                        Width="115px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="labelHeader" Text="Remarks" Width="115px"></asp:Label>
                                                </td>
                                                <td style="width: 15px; background-color: White;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="9">
                                                    <div style="height: 405px; overflow: auto;">
                                                        <asp:GridView ID="gvDomestic" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="38px" DataField=""></asp:BoundField>
                                                                 <asp:BoundField ItemStyle-Width="50px" DataField="LINE"></asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="CONT_NO" DataNavigateUrlFormatString="GrMapping.aspx?MTY_CONT_ID={0}"
                                                                    ItemStyle-Width="100px" DataNavigateUrlFields="MTY_CONT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER_name"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="LOCATION_name"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="PROGRAM_DATE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="110px" DataField="REMARKS"></asp:BoundField>
                                                            </Columns>
                                                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tabTripPendency" EventName="ActiveTabChanged"
                            runat="Server" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
