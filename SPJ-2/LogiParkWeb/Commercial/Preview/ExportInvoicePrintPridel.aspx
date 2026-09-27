<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExportInvoicePrintPridel.aspx.vb"
    Inherits="Commercial_Preview_ExportInvoicePrintPridel" Theme="Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: Invoice Print</title>
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
        
        
        .style2
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div align="center">
       <table align="center" width="100%">
               <tr>
                <td align="center">
                <asp:Image ID="imglogo" runat="server" />
                </td>
                </tr>
            <tr>
                
                <td height="25px" align="center">
                <asp:Label ID="Label4" CssClass="FormText_BoxHead" Font-Size="Large" runat="server" Text="JSB CONSULTANTS"></asp:Label>
                </td>
                
            </tr>
           <tr>
 <td height="25px" align="center">
                <asp:Label ID="Label12" CssClass="FormText_BoxHead" Font-Size="Large" runat="server" Text="----"></asp:Label>
                </td>
           </tr>
            <tr>
                <td height="25px" align="center">
                    <asp:Label ID="lblTerminaladdress" CssClass="FormLabel" Text="Regd. Office : First Floor, 61, Durga Park, Delhi-110096 </br> Admin Occice : Room No-01, 363, Sector-1, Vaishali, Ghaziabad (U.P.) </br> Tel/Fax : +91-120-4263512,0120-463513" runat="server"></asp:Label>
                </td>
                <td height="25px" align="center"></td>
            </tr>
            <tr>
                
                <td height="25px" align="center">
                <asp:Label ID="Label1" CssClass="FormText_BoxHead" runat="server" Text="INVOICE"></asp:Label>
                </td>
                
            </tr>
             
             <tr>
            <td height="25px" align="left">
            <asp:Label ID="labService" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Service Tax No.: BXQPS6507JD001"></asp:Label>
            </td>
            <td height="25px" align="center"></td>
            </tr>
             
             <tr>
            <td height="25px" align="left">
            <asp:Label ID="Label10" CssClass="FormLabel" Font-Bold="true" runat="server" Text="TAN NO.: BXQPS6507J"></asp:Label>
            </td>
            <td height="25px" align="center"></td>
            <td align="right">
            <asp:Label ID="lblcon" CssClass="FormLabel" runat="server" Text="   "></asp:Label>
            </td>
            </tr>
            <tr>
                <td height="25px" align="left">
                    
                    <asp:Label ID="Label20" CssClass="FormLabel" Font-Bold="true" runat="server" Text="PAN NO: BXQPS6507J"></asp:Label>
                </td>
                <td height="25px" align="center"></td>
                <td align="right">
            <asp:Label ID="Label18" CssClass="FormLabel" runat="server" Text="  "></asp:Label>
            </td>
            </tr>
 
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td>
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                                <table style="width: 1000px" align="left">
                                    <tr>
                                        <td align="left"  class="text-align: justify;" colspan="2" >
                                            <asp:Label ID="lblcusName" Font-Bold="False" CssClass="FormLabel"  runat="server" Text="To, "
                                                Width="200px"></asp:Label>
                                        </td>   
                                        
                                        <td align="left" class="text-align: justify;" >
                                            <asp:Label ID="lblInvoiceDate" CssClass="FormLabel" runat="server" Text="Invoice No"
                                                Width="115px"></asp:Label>
                                                      <asp:HiddenField ID="hdnBookingId" runat="server" />
                                      
                                        </td>
                                        <td align="left" class="text-align: justify;">
                                            <asp:Label ID="Label2" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textInvoiceNo" Font-Bold="true" Width="160px" CssClass="FormLabel" runat="server"></asp:Label>
                                        </td>
                                    
                                    </tr>
                                    <tr>
                                        
                                        <td align="left" colspan="2" class="text-align: justify width: 400px;">
                                            <asp:Label ID="lblCustomerName" Width="90%" Font-Bold="true"  CssClass="FormTextBoxHead" runat="server"></asp:Label>
                                        </td>
                                  
                                         <td align="left"  class="text-align: justify width: 125px;">
                                            <asp:Label ID="lblExporterAdd" CssClass="FormLabel" runat="server" Text="Invoice Date"
                                                Width="115px"></asp:Label>
                                        </td>
                                        <td align="left" class="text-align: justify ;">
                                            <asp:Label ID="Label3" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                           
                                            <asp:Label ID="textInvoiceDate" Font-Bold="true" Width="110px" CssClass="FormLabel" runat="server"></asp:Label>
                                        </td>
                                        <%--<td "text-align: justify width: 24px;">
                                            <asp:Label ID="lblBookingDate" CssClass="FormLabel" Width="120px" runat="server" Text="Jo Date  "></asp:Label>
                                        </td>
                                        <td align="left" class="text-align: justify width: 350px;">
                                            <asp:Label ID="Label6" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textBookingDate" Width="90%" CssClass="FormLabel" runat="server"
                                                Height="90%"></asp:Label>
                                            
                                        </td>--%>
                                    </tr>
                                    <tr>
                                       <td align="left" colspan="3" class="text-align: justify width: 500px;">
                                            <asp:Label ID="lblcustomeradd" Width="600px"  CssClass="FormLabel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td></td>
                                    </tr>
                               
                                    <tr>
                                    <td align="left" class="text-align: justify;" colspan="2">
                                            <asp:Label ID="lblAc" Width="60px" CssClass="FormLabel" Text="A/C" runat="server"></asp:Label>
                                             <asp:Label ID="Label23" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textAccount" CssClass="FormLabel" runat="server"></asp:Label>
                                        </td>
                                     
                                        <td align="left" class="text-align: justify;">
                                            <asp:Label ID="lblFromLocation" CssClass="FormLabel" Width="70px" Text="Pick Up" runat="server"></asp:Label>
                                             <asp:Label ID="Label9" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textLocationFrom" CssClass="FormLabel" runat="server" Height="21px"></asp:Label>
                                        </td>
                                      
                                      <td align="left" class="text-align: justify width: 125px;">
                                            <asp:Label ID="lblToLocation" Width="100px" CssClass="FormLabel" Text="Location To" runat="server"></asp:Label>
                                             <asp:Label ID="Label19" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textToLocation" CssClass="FormLabel" runat="server" ></asp:Label>
                                        </td>
                                      
                                         <td align="left" class="text-align: justify width: 125px;">
                                           <asp:Label ID="Label7" Width="60px" CssClass="FormLabel" Text="Handover" runat="server"></asp:Label>
                                        </td>
                                        <td align="left" class="text-align: justify;">
                                            <asp:Label ID="Label8" CssClass="FormTextBoxHead" runat="server" Text=":"></asp:Label>
                                            <asp:Label ID="textHandover" CssClass="FormLabel" runat="server"></asp:Label>
                                        </td>
                                       </tr> 
                                   
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                        </tr>
                        <tr style="height: 150px;">
                            <td valign="top" align="left" colspan="2">
                                <table align="center">
                                    <tr align="center">
                                        <td valign="top" align="left">
                                            
                                            <div class="RepScroling" style="height: 60%; width: 1000px;">
                                                <asp:GridView ID="gvPaymentDetail" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                    <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="300px" DataField="SERVICE" HeaderText="Service"
                                                            HeaderStyle-CssClass="FormLabel"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="55px" DataField="BILL_QNTY" HeaderText="Qnty" HeaderStyle-CssClass="FormLabel"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="60px" DataField="BILL_RATE" HeaderText="Rate" HeaderStyle-CssClass="FormLabel"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="AMOUNT" HeaderText="Amount" HeaderStyle-CssClass="FormLabel"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="105px" DataField="SERVICE_TAX" HeaderText="Service Tax"
                                                            HeaderStyle-CssClass="FormLabel" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="85px" DataField="ECESS" HeaderText="E.Cess" HeaderStyle-CssClass="FormLabel"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="85px" DataField="HECESS" HeaderText="H.E.Cess" HeaderStyle-CssClass="FormLabel"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="105px" DataField="TAX_AMOUNT" HeaderText="Tax Amount"
                                                            HeaderStyle-CssClass="FormLabel" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="105px" DataField="TOTAL_AMOUNT" HeaderText="Total Amount"
                                                            HeaderStyle-CssClass="FormLabel" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                            <table cellspacing="0" cellpadding="0">
                                                <tr align="right">
                                                    <td width="300px" align="center">
                                                    </td>
                                                    <td width="55px" align="center">
                                                    </td>
                                                    <td style="text-align: center" width="60px">
                                                        <asp:Label ID="lblGrandTotal" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                            runat="server" Text="Total :">
                                                        </asp:Label>
                                                    </td>
                                                    <td width="100px" align="right">
                                                        <asp:Label class="FormTextBoxNumeric" ID="textAmountTotal" runat="server" ToolTip="Bill Amount Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="105px" align="right">
                                                        <asp:Label class="FormTextBoxNumeric" ID="textServiceTotal" runat="server" ToolTip="Service Tax Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="85px" align="right">
                                                        <asp:Label class="FormTextBoxNumeric" ID="textEcessTotal" runat="server" ToolTip="E.cess Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="85px" align="right">
                                                        <asp:Label class="FormTextBoxNumeric" ID="textHcessTotal" runat="server" ToolTip="H.cess Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="105px" align="right">
                                                        <asp:Label class="FormTextBoxNumeric" ID="textTaxAmount" runat="server" ToolTip="Tax Amount Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td align="right" width="105px">
                              &nbsp;&nbsp;
                                                        <asp:Label class="FormTextBoxNumeric" ID="textBillAmountTotal" runat="server" ToolTip="Bill Amount Total"
                                                            Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30px" colspan="9">
                                                        <br />
                                                        <asp:Label ID="lblInWords" CssClass="FormTextBoxLeft" Text="In Words :- " Font-Bold="true"
                                                            runat="server"></asp:Label>
                                                        <asp:Label ID="textInWords" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="50px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height: 50%;">
                                        <td valign="top" align="left" colspan="2">
                                            <table>
                                                <tr>
                                                    <td valign="top" align="left">
                                                        <div style="width: 1000px;">
                                                            <asp:GridView ID="gvContainerDetail" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                                RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" 
                                                                runat="server" Width="1000px">
                                                                <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                                <Columns>
                                                                    <asp:BoundField ItemStyle-Width="28px" HeaderText="Sr." HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                     <asp:BoundField ItemStyle-Width="38px"  DataField="GR_NO" HeaderText="Gr No." HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                       <asp:BoundField ItemStyle-Width="78px" DataField="GR_DATE" HeaderText="Date Of Loading" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                     <asp:BoundField ItemStyle-Width="128px" DataField="VEHICLE_NO" HeaderText="Vehicle No" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="95px" DataField="CONT_NO" HeaderText="Cont No" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="47px" DataField="CONT_SIZE" HeaderText="Size" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                 
                                                                 
                                                                    <asp:BoundField ItemStyle-Width="85px" DataField="REPORTED" HeaderText="Reported Date Time"
                                                                        HeaderStyle-CssClass="FormLabel"></asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="85px" DataField="ICD_IN" HeaderText="Released Date Time"
                                                                        HeaderStyle-CssClass="FormLabel"></asp:BoundField>
                                                                    <asp:BoundField ItemStyle-Width="47px" DataField="DET_DAYS" HeaderText="Det Days" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                     <asp:BoundField ItemStyle-Width="77px" DataField="Rate" HeaderText="Rate" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                     <asp:BoundField ItemStyle-Width="50px" DataField="TOLL" HeaderText="Toll Tax" HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                  <asp:BoundField ItemStyle-Width="50px" DataField="DET_AMT" HeaderText="Detention Amt." HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                   <asp:BoundField ItemStyle-Width="50px" DataField="MISC_AMT" HeaderText="Misc. Amt." HeaderStyle-CssClass="FormLabel">
                                                                    </asp:BoundField>
                                                                
                                                                </Columns>
                                                                <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    <table width="100%">
                                <tr>
                                <td align="left" width="100%">
                                <asp:Label ID="lblNote" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Invoice Note : "></asp:Label>
                                &nbsp;
                                <asp:Label ID="txtInvoiceNote" Width="650px" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                                
                                
                                </tr>
                                </table>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        <asp:Label ID="lblDeclaration" Font-Bold="true" CssClass="FormLabel" Text="Declaration:" runat="server"></asp:Label>
                                            
                                                                  </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family: Verdana; font-size: 13px; text-align: left" width="1040px">
                                           1. Consignor/Consignee will be responsible for paying service tax as per not FN.NO.30/2012 dated 20/06/2012.
                                            <br />
                                            2. Cheques/DD should be drawn in favour of <b>JSB CONSULTANTS</b>, payable
                                            at New Delhi.
                                            <br />
                                            3. Any discrepancies in the bill should be brought to the notice of the company
                                            within 2 week of bill date.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                   
                                        <td  style="font-weight: bold" width="1000px">
                                        <table>
                                        <tr>
                                        <td>
                                        <div>
                                        <table> 
                                         <tr>
                                        
                                        
            <td height="25px" align="left">
            <asp:Label ID="Label17" CssClass="FormTextBoxHead" runat="server" 
                    Text="Company Bank Detail  " ViewStateMode="Disabled" Font-Underline="True"></asp:Label>
            <br />
            <br />
            
            </td>
            
                                        </tr>
                                        
                                         <tr>
                                        
                                        
            <td align="left" class="style2">
            <asp:Label ID="Label11" CssClass="FormTextBoxHead" runat="server" Text="JSB CONSULTANTS"></asp:Label>
            </td>
            
                                        </tr>
                                        <tr>
                                        
                                        
            <td align="left" class="style2">
            <asp:Label ID="Label13" CssClass="FormTextBoxHead" runat="server" Text="Bank Name.:--------- "></asp:Label>
            </td>
            
                                        </tr>
                                         <tr>  
            <td height="25px" align="left">
            <asp:Label ID="Label14" CssClass="FormTextBoxHead" runat="server" Text="Branch.: ----------------"></asp:Label>
            </td>
            
                                        </tr>
                                         <tr>
                                        
                                        
            <td height="25px" align="left">
            <asp:Label ID="Label15" CssClass="FormTextBoxHead" runat="server" Text="A/c. no.: 00000000000000  "></asp:Label>
            </td>
            
                                        </tr>
                                         <tr>
                                        
                                        
            <td height="25px" align="left">
            <asp:Label ID="Label16" CssClass="FormTextBoxHead" runat="server" Text="RTGS/IFSC code-.:  00000000000 "></asp:Label>
            </td>
            
                                        </tr>
                                        </table>
                                        </div>
                                        </td>
                                        <td align="center" width="395px"></td>
                                        <td align="right">
                                        <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Label ID="Label5" Font-Bold="true" CssClass="FormLabel" runat="server" Text="For JSB CONSULTANTS"></asp:Label>
                                            
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Label ID="Label6" Font-Bold="true" CssClass="FormLabel" runat="server" Text="Authorized Signatory"></asp:Label>
                                            
                                        </td>
                                        </tr>
                                        <tr>
                                        <td colspan="3" align="center">
                                        <br />
                                       <br />
                                        <asp:Label ID="Label21" CssClass="FormLabel" runat="server" Text="This is software generated invoice, signature not required.  "></asp:Label>
                                        </td>
                                        </tr>
                                        </table>
                                            
                                        </td>
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblPrintedBy" CssClass="FormLabel" runat="server" Text="Printed by:"></asp:Label>
           <asp:Label ID="textPrintedBy" CssClass="FormLabel" runat="server" ></asp:Label>
    </div>
    <asp:Button ID="btnPDF" Text="ToPDF" runat="server" OnClick="btnPDF_Click" Visible="false" />
    <asp:Button ID="btnRTF" Text="ToRTF" runat="server" OnClick="btnRTF_Click" Visible="false" />
    </form>
</body>
</html>
