<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MaintenanceReport.aspx.vb" Inherits="Reports_Fleet_MaintenanceReport"
    Title="eLOGiPark:: Maintenance Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
   function DisplayValidation()
      {
       var result=false;    
       if (validateData(document.getElementById('<%=textFromDate.clientId %>'),
            document.getElementById('<%=lblFromDate.clientId %>').innerHTML))
          if (validateData(document.getElementById('<%=textToDate.clientId %>'),
            document.getElementById('<%=lblToDate.clientId %>').innerHTML))        
                result = true;
          else
            result=false;
      else
         result=false;       
           return result;
      }
    function checktodate(dodate)
  {
    var startDate = dodate.getAttribute('value');
    var currentTime = new Date()
    var month = currentTime.getMonth() + 1
    var day = currentTime.getDate()
    var year = currentTime.getFullYear()
        endDate = (day + "/" + month + "/" + year)
        startDate = Date.parse(startDate);
        endDate = Date.parse(endDate);

        if(startDate > endDate)
        {
            alert("Please ensure that the To Date is less than or equal to the Current Date.");
            dodate.value='';
            dodate.style.border='1px solid red';
            dodate.focus();
            return false;
        } 
        dodate.style.border='1px solid #B3CBFF';
    }
    function checkfromdate(dodate)
  {
    var startDate = dodate.getAttribute('value');
    var currentTime = new Date()
    var month = currentTime.getMonth() + 1
    var day = currentTime.getDate()
    var year = currentTime.getFullYear()
        endDate = (day + "/" + month + "/" + year)
        startDate = Date.parse(startDate);
        endDate = Date.parse(endDate);

        if(startDate > endDate)
        {
            alert("Please ensure that From Date is less than or equal to the Current Date.");
            dodate.value='';
            dodate.style.border='1px solid red';
            dodate.focus();
            return false;
        } 
        dodate.style.border='1px solid #B3CBFF';
    }
    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Maintenance Report" Width="400px" CssClass="FormLabelTitle">
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
                        <td> <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" style="width: 139px" />
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
                            <td>
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Maintenance Report"></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td colspan="12">
                                <div style="overflow: auto;">
                      <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        ShowFooter="False" runat="server">
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                              <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_NO" HeaderText="Jo No." />
                                                   <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_DATE" HeaderText="Jo Date" />
                                                              <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="VEHICLE_NO" HeaderText="Vehicle No" />
                                                   <asp:BoundField ItemStyle-Width="200px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="PARTY_NAME" HeaderText="Party Name" />
                                                   <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_NO" HeaderText="Invoice No" />
                                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BILL_AMOUNT" HeaderText="Bill Amount" />
                                                       <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_TYPE" HeaderText="Job Type" />

                                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_FOR" HeaderText="Job For" />

                                                          <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="WR_NAME" HeaderText="Warehouse Name" />

                                                
                                                          <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="DRIVER_NAME" HeaderText="Driver Name" />
                                                
                                                
                                                          <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="ADVANCE" HeaderText="Advance" />
                                                
                                                          <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="OIL_ADVANCE" HeaderText="Oil Advance" />
                                                
                                                          <asp:BoundField ItemStyle-Width="150px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="ITEM_NAME" HeaderText="Item Name" />
                                                
                                                          <asp:BoundField ItemStyle-Width="50px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_QNTY" HeaderText="Job Qnty" />
                                                
                                                          <asp:BoundField ItemStyle-Width="50px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="JO_PRICE" HeaderText="Job Price" />
                                                    
                                                          <asp:BoundField ItemStyle-Width="50px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CLOSE_QNTY" HeaderText="Close Qnty" />
                                                  <asp:BoundField ItemStyle-Width="150px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="NOTE" HeaderText="Remarks" />

                                                             <asp:BoundField ItemStyle-Width="70px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CREATED_BY" HeaderText="Created By" />
                                                
                                                             <asp:BoundField ItemStyle-Width="70px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CLOSE_BY" HeaderText="Close By" />
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView> </div></td></tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
