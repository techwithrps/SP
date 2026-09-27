<%@ Page Title="eLOGiFleet :: Vendor Master" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
 CodeFile="VendorMaster.aspx.vb" Inherits="Reports_Masters_VendorMaster" Theme="Forms" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Vendor Master Report" Width="400px" CssClass="FormLabelTitle">
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
                        <td align="left" valign="top" style="width: 244px">
                            <div style="width: 100%;">
                                <table cellspacing="0" id="tblReport" runat="server">
                                    <tr class="RepheaderNew">
                                        <td style="width: 20px">
                                            <asp:Label ID="lblSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                                Width="30px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblCustomerName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="Vendor Name" Width="200px"></asp:Label>
                                        </td>
 
                                        <td >
                                            <asp:Label ID="lblContactPerson" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Contact Person"
                                                Width="150px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblContact" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Conatct No"
                                                Width="120px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblEmail" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Email"
                                                Width="100px"></asp:Label>
                                        </td>

                                       
                                        <td align="center">
                                            <asp:Label ID="lblAddress" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Address"
                                                Width="250px"></asp:Label>
                                        </td>
                                       
                                        <td align="center">
                                            <asp:Label ID="lblCreatedBy" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Created By"
                                                Width="100px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblCreatedon" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Created On"
                                                Width="100px"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <div style="height: 360px; overflow: auto;">
                                                <asp:GridView ID="gvVendorMaster" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="30px"  />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="VENDOR_NAME" />
                  
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="CONTACT_PERSON" />
                                                        <asp:BoundField ItemStyle-Width="120px" DataField="CONTACT_NO" />
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="EMAIL_ID1" />
                                                         <asp:BoundField ItemStyle-Width="250px" DataField="ADDRESS" />
                                                       
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" />
                                                        <asp:BoundField ItemStyle-Width="90px" DataField="CREATED_ON" />
                                                        
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
            
        </tr>
<tr>
 <td>
                             <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" style="width: 139px" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
</tr>
    </table>
</asp:Content>

