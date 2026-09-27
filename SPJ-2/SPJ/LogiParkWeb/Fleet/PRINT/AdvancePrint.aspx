<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdvancePrint.aspx.vb" Inherits="Fleet_PRINT_AdvancePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFleet :: Advance Print</title>
    <style type="text/css">
        .FormLabel
        {
            text-align: left;
        }
        .style1
        {
            text-align: left;
        }
        
        
        .FormTextBoxHead
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div align="center">
        <table align="center">
            <tr>
                <td height="25px" align="center">
                                    <asp:Image ID="imglogo" runat="server" />
             
                </td>
                <td height="25px" align="center">
                    &nbsp;</td>
                <td align="right" rowspan="5">
                    <div>
                        <table>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td height="25px" align="center">
                        <asp:Label ID="Label1"  Font-Bold="true"   CssClass="FormLabelTitle" runat="server" Text="JSB CONSULTANTS"></asp:Label>
             
                </td>
                <td height="25px" align="center">
                    <asp:Label ID="Label4" CssClass="FormText_BoxHead" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="25px" align="center" >
                           <asp:Label ID="Label12"   Font-Bold="true"  CssClass="FormLabelTitle" runat="server" Text="Regd. Office : First Floor, 61, Durga Park, Delhi-110096 </br> Admin Occice : Room No-01, 363, Sector-1, Vaishali, Ghaziabad (U.P.) </br> Tel/Fax : +91-120-4263512,0120-463513"></asp:Label>
              </td>
                <td height="25px" align="center">
                </td>
            </tr>
             <tr>
                <td height="25px" align="center" >
                           <asp:Label ID="lblPrint"   Visible="false" Font-Bold="true"  CssClass="labelHeader" runat="server"  Text="Duplicate Copy"></asp:Label>
              </td>
                <td height="25px" align="center">
                </td>
            </tr>
                           
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
        </table>        
            <table style="height: 208px;" align="center">
              <tr>
                    <td align="left" >
                        <asp:Label ID="lblPrintedBy" runat="server" Width="80px" Text="Printed By" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label9" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="textPrintedBy" runat="server"></asp:Label>
                    </td>
                    
                    <td align="left" >
                        <asp:Label ID="lblPrintDate" runat="server" Text="Print Date" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left" >
                        <asp:Label ID="Label15" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="textPrintedDate"  runat="server" CssClass="FormTextBoxHead"></asp:Label>
                    </td>
                </tr>
                <tr>
                   
                    <td align="left" >
                        <asp:Label ID="lblGrNo" runat="server" Width="50px" Text="GR No" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label5" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="textGrNo" runat="server"></asp:Label>
                    </td>
                    
                    <td align="left" >
                        <asp:Label ID="lbldate" runat="server" Text="GR Date" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label6" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="textdate"  runat="server" CssClass="FormTextBoxHead"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="left">
                        <asp:Label ID="lblTruck" CssClass="FormLabel" runat="server" Text="Truck No  " Width="85px"></asp:Label>
                    </td>
                    <td align="left"">
                        <asp:Label ID="Label2" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        &nbsp;<asp:Label ID="textTruck"  CssClass="FormLabel" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblDriverName" CssClass="FormLabel" runat="server" Text="Driver" Width="85px"></asp:Label>
                    </td>
                    <td align="left"">
                        <asp:Label ID="Label3" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        &nbsp;<asp:Label ID="textDriver"  CssClass="FormLabel" runat="server"></asp:Label>
                    </td>
                
                </tr>
              
                <tr>
                    <td align="left">
                        <asp:Label ID="Labelform" runat="server" Text="From" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblFrom" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="TextFrom" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="LblTo" runat="server" Text="To" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left" >
                        <asp:Label ID="Label10" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="TextTo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                    </td>
                </tr>
                <tr>
                  <td align="left">
                        <asp:Label ID="lblVendor" CssClass="FormLabel" runat="server" Text="Oil Vendor" Width="85px"></asp:Label>
                    </td>
                    <td align="left" >
                        <asp:Label ID="Label8" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        &nbsp;<asp:Label ID="textPetrolPump" Width="145px" CssClass="FormLabel" runat="server"></asp:Label>
                    </td>
                     <td align="left">
                        <asp:Label ID="lblOil" runat="server" Text="Oil" CssClass="FormLabel"></asp:Label>
                    </td>
                    <td align="left" >
                        <asp:Label ID="Label11" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                        <asp:Label ID="textOilAdvance" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                    </td>
                </tr>
                   
                       <tr>
     
      <td align="right"  colspan="4">
      <h4>JSB CONSULTANTS<br /> &nbsp;<br /> Authorised Signatory</h4></td>
      </tr>
           
             </table>
                 
           
                         
       </div>   
      
    </form>
</body>
</html>
