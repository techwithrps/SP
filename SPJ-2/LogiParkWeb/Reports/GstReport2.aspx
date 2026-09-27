<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GstReport2.aspx.vb" Inherits="Reports_GstReport" Title="eLOGiPark:: GST Return Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="200px" Text="GSTR-2 Return Report" CssClass="FormLabelTitle">
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
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td>
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lbltable1" CssClass="FormLabel" Text="Table-1(b2b)" Font-Bold="true"
                                    runat="server"></asp:Label>
                                <asp:Button ID="btnb2b" runat="server" Text="b2b" CssClass="FormButton" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div style="height: 230px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" HeaderStyle-CssClass="RepheaderNew" runat="server">
                                        <Columns>
                                            <asp:BoundField HeaderText="Vendor GSTIN" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="GSTN" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="left"></asp:BoundField>
                                                 <asp:BoundField HeaderText="Vendor Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="left"></asp:BoundField>
                                            <asp:BoundField HeaderText="Invoice Number" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_REF_NO" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="left"></asp:BoundField>
                                            <asp:BoundField HeaderText="Invoice Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="left"></asp:BoundField>
                                           
                                            <asp:BoundField HeaderText="Place Of Supply" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="STATE_CODE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                  <asp:BoundField HeaderText="No of Items" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="ITEM" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                              
                                 <asp:BoundField HeaderText="Rate" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TAX_PERC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ></asp:BoundField>
                                                 <asp:BoundField HeaderText="Invoice Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TAXABLE_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px"></asp:BoundField>
                                                   <asp:BoundField HeaderText="CGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CGST_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
                                                   <asp:BoundField HeaderText="SGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SGST_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
                                                      <asp:BoundField HeaderText="IGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="IGST_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px"></asp:BoundField>
                                                              <asp:BoundField HeaderText="Cess Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CESS" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px"></asp:BoundField>
                                                      <asp:BoundField HeaderText="Total Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BILL_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px"></asp:BoundField>

                                                       <asp:BoundField HeaderText="ITC Eligibility" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px"></asp:BoundField>

                                                       <asp:BoundField HeaderText="CGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CE" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px"></asp:BoundField>
                                                <asp:BoundField HeaderText="SGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SE" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px"></asp:BoundField>
                                                                <asp:BoundField HeaderText="IGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="IE" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>

                                            <asp:Label ID="lblTable3" CssClass="FormLabel" Text="Table-2 (hsn)" Font-Bold="true"
                                                runat="server"></asp:Label>
                                            <asp:Button ID="btnhsn" runat="server" Text="hsn" CssClass="FormButton" />

                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <div style="height: 150px; overflow: auto;">
                                                <asp:GridView ID="gvService" HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="HSN" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SERVICE_CODE" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Service Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SERVICE_NAME" ItemStyle-Width="330px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="UQC" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="UNIT" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="TEU" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TEUS" ItemStyle-Width="40px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Bill Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="BILL_AMOUNT" ItemStyle-Width="10px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Base Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="BASE_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="IGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="IGST" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="CGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="CGST" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="SGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SGST" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cess Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="CESS" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="right"></asp:BoundField>

                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">

                                            <asp:Label ID="lblTable2" CssClass="FormLabel" Text="Table-3(b2cs)" Font-Bold="true"
                                                runat="server"></asp:Label>

                                            <asp:Button ID="btnb2cs" runat="server" Text="b2cs" CssClass="FormButton" />

                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <div style="height: 100px; overflow: auto;">
                                                <asp:GridView ID="gvb2cs" HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="CUST_TYPE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Place Of Supply" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SUPPLY_STATE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Rate" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TAX_PERC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" ></asp:BoundField>
                                                        <asp:BoundField HeaderText="Taxable Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="BASE_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cess Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="E-Commerce GSTIN" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">

                                            <asp:Label ID="Label1" CssClass="FormLabel" Text="Table-4(b2cl)" Font-Bold="true"
                                                runat="server"></asp:Label>

                                            <asp:Button ID="btnb2cl" runat="server" Text="b2cl" CssClass="FormButton" />

                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <div style="height: 100px; overflow: auto;">
                                                <asp:GridView ID="gvb2cl" HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Invoice Number" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="INVOICE_REF_NO" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Invoice Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="INVOICE_DATE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Invoice Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="BILL_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Place Of Supply" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SUPPLY_STATE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Rate" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TAX_PERC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Taxable Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TAX_AMOUNT" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cess Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="70px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="E-Commerce GSTIN" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>

                                    </tr>

                                        <tr>
                            <td>
                                <asp:Label ID="Label3" CssClass="FormLabel" Text="Table-5(Debit Note)" Font-Bold="true"
                                    runat="server"></asp:Label>
                                <asp:Button ID="btnCreditExcel" runat="server" Text="Debit Note" CssClass="FormButton" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div style="height: 230px; overflow: auto;">
                                    <asp:GridView ID="gvCredit" HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                            <asp:BoundField HeaderText="Vendor GSTIN" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="GSTIN" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                            <asp:BoundField HeaderText="Vendor Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>

                                             <asp:BoundField HeaderText="Note/Refund Voucher Number" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_REF_NO" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                            <asp:BoundField HeaderText="Note/Refund Voucher Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_DATE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                           
                                            <asp:BoundField HeaderText="Invoice No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_REF_NO" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                            <asp:BoundField HeaderText="Invoice Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-HorizontalAlign="center" ItemStyle-Width="100px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Document Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="NOTE" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                           
                                            <asp:BoundField HeaderText="Reason for issuing Note" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="REASON" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                           <asp:BoundField HeaderText="No of Item" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="ITEM" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                               
                                           <asp:BoundField HeaderText="Taxable Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TAXABLE_AMT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>

                                                <asp:BoundField HeaderText="CGST Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CGST" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>

                                                 <asp:BoundField HeaderText="SGST Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SGST" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>


                                                <asp:BoundField HeaderText="IGST Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="IGST" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                 <asp:BoundField HeaderText="Cess Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CESS_AMT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                             
                                               <asp:BoundField HeaderText="Note/Refund Voucher Value" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CREDIT_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                          
                                                 <asp:BoundField HeaderText="Supply Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SUPPLY_TYPE" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="center"></asp:BoundField> 
                                          
                                          
                                                
                                                <asp:BoundField HeaderText="Pre GST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                            DataField="PRE_GST"     ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>


                                                <asp:BoundField HeaderText="CGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>

                                                

                                                <asp:BoundField HeaderText="SGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                  <asp:BoundField HeaderText="IGST Eligible" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="IE" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                  
                                        </Columns>
                                    </asp:GridView>
                                      <%--<asp:GridView ID="gvCredit" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <Columns>
                                                  <asp:BoundField  HeaderText="Sr." HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                               ItemStyle-HorizontalAlign="center" ItemStyle-Width="30px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Credit Note No." HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_REF_NO" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                            <asp:BoundField HeaderText="Credit Note Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_DATE" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                                 <asp:BoundField HeaderText="Customer Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                             <asp:BoundField HeaderText="Service Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SERVICE_NAME" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                            <asp:BoundField HeaderText="CN Basic Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                            <asp:BoundField HeaderText="CGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CGST_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField> 
                                                       <asp:BoundField HeaderText="SGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SGST_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField> 
                                                       <asp:BoundField HeaderText="IGST" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="IGST_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                                 <asp:BoundField HeaderText="Total Taxes" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TOTAL_TAX" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField> 
                                                            <asp:BoundField HeaderText="Credit Note Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CREDIT_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField> 
                                                   <asp:BoundField HeaderText="Agnt. Invoice No." HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_REF_NO" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField> 
                                                            <asp:BoundField HeaderText="Agnt. Invoice Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center"></asp:BoundField>  
                                                 <asp:BoundField HeaderText="Invoice Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_AMOUNT" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>  
                                          
                                        </Columns>
                                    </asp:GridView>--%>
                                </div>
                            </td>
                        </tr>
     
                                    <tr>
                                        <td valign="top">

                                            <asp:Label ID="Label2" CssClass="FormLabel" Text="Table-6(docs)" Font-Bold="true"
                                                runat="server"></asp:Label>
                                            <asp:Button ID="btndoc" runat="server" Text="doc" CssClass="FormButton" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <div style="height: 100px; overflow: auto;">
                                                <asp:GridView ID="gvSummary" HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nature of Document" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="DOC_NATURE" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                         <asp:BoundField HeaderText="Doc Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="DOC" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Sr. No. From" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SR_FROM" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="center"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Sr. No. To" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="SR_TO" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Total Number" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TOTAL_NUMBER" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cancelled" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TOTAL_CANCELLED" ItemStyle-HorizontalAlign="right" ItemStyle-Width="40px" ></asp:BoundField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>

                                    </tr>

                                </table>
                            </td>

                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
