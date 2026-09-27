<%@ Page Title="eLOGiFleet :: Customer Master" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
 CodeFile="CustomerMaster.aspx.vb" Inherits="Reports_Masters_CustomerMaster" Theme="Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Customer Master Report" Width="400px" CssClass="FormLabelTitle">
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
                        <td align="left" valign="top" >
                            <div style="width: 100%;">
                                <table>
                                    
                                    <tr>
                                        <td>
                                            <div style="height: 360px; overflow: auto;">
                                                <asp:GridView ID="gvCustomerMaster" HeaderStyle-CssClass="RepheaderNew" HeaderStyle-Font-Names="Verdana" HeaderStyle-Font-Size="8pt" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="30px" HeaderText="Sr."  />
                                                        <asp:BoundField ItemStyle-Width="300px" HeaderText="Customer" DataField="CUSTOMER_NAME" />
                                                        <asp:BoundField ItemStyle-Width="300px" HeaderText="Address" DataField="ADDRESS" />
                                                        <asp:BoundField ItemStyle-Width="120px" HeaderText="Type" DataField="CUSTOMER_TYPE" />
                                                        <asp:BoundField ItemStyle-Width="150px" HeaderText="Contact Person" DataField="CONTACT_PERSON" />
                                                        <asp:BoundField ItemStyle-Width="100px" HeaderText="Contact No" DataField="CONTACT_NO" />
                                                        <asp:BoundField ItemStyle-Width="100px" HeaderText="Email" DataField="EMAIL_COMMERCIAL" />
                                                        <asp:BoundField ItemStyle-Width="100px" HeaderText="Status" DataField="STATUS" />
                                                        <asp:BoundField ItemStyle-Width="50px" HeaderText="Export" DataField="EXPORT" />
                                                        <asp:BoundField ItemStyle-Width="50px" HeaderText="Import" DataField="IMPORT" />
                                                        <asp:BoundField ItemStyle-Width="100px" HeaderText="Created By" DataField="CREATED_BY" />
                                                        <asp:BoundField ItemStyle-Width="100px" HeaderText="Created On" DataField="CREATED_ON" />
                                                        
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
 <td align="center">
                           <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" style="width: 139px" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
</tr>
    </table>
</asp:Content>

