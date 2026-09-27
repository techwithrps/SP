<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
 CodeFile="RateTariffReport.aspx.vb" Inherits="Reports_Fleet_RateTariffReport" Title="eLOGiFleet::Rate Master Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Rate Master Report" CssClass="FormLabelTitle" Width="400px">
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
    <table width="100%" style="height:450px;">
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
                         <td style="text-align: right">
                            <asp:Label ID="lblTerminal" runat="server" Text="Customer Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerType" runat="server" AutoPostBack="true" ToolTip="Customer Type" CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                       
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer" CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                       
                        </td>
                        <td>
                        <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" style="width: 139px" />
                            <asp:Button ID="btnExcelAll" runat="server" Text="Download All" CssClass="FormButton" style="width: 120px" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                            <%--<asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return DisplayValidation();" ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="btnExcalAll" runat="server" ImageUrl="~/Images/btnExcelDownload.png" ToolTip="Download All Rate" />
                            <asp:ImageButton ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" >
               
                    <table id="tblReport" runat="server">
                        
                        
                        <tr class="RepHead">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                    Width="32px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRateId" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Rate Id" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblService" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Service" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblrCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer" Width="200px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblValidFrom" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Valid From" Width="100px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblValidTo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Valid To" Width="100px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblRemark" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Remark" Width="150px"></asp:Label>
                            </td>
                            
                             <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="left">
                                <div style="height: 150px; overflow: auto;">
                                    <asp:GridView ID="gvRateMaster" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server" OnRowCommand="gvRateMaster_RowCommand">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px"></asp:BoundField>
                                             <asp:TemplateField ItemStyle-Width="0px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnRateId" runat="server" Value='<%# Eval("RATE_ID") %>' />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE_ID" />
                                            <asp:ButtonField ItemStyle-Width="150px" DataTextField="SERVICE" />
                                             <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VALID_FROM" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VALID_TO" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REMARKS" />
                                           </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                    
                
            </td>
        </tr>
        <tr>
        <td style="height:20PX;">
        </td>
        </tr>
        <tr>
        <td align="left" valign="top" style="height:200px;" >
        <table cellspacing="1" id="tblRateDtls" runat="server">
                        
                        
                        <tr class="RepHead">
                            <td>
                                <asp:Label ID="Label1" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                    Width="32px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRateIdd" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Rate Id" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblSize" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Cont Size" Width="70px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Cont Type" Width="70px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblStatus" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Status" Width="50px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Doc Type" Width="70px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblFrom" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="From" Width="120px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblTo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To" Width="120px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblHandover" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover" Width="120px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblCommodity" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Commodity" Width="80px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblRangeFrom" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Range From" Width="120px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblRangeTo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Range To" Width="120px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblRate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Rate(INR)" Width="100px"></asp:Label>
                            </td>
                            
                             <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="13" align="left">
                                <div style="height: 200px; overflow: auto;">
                                    <asp:GridView ID="gvRateDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE_ID" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_TYPE" />
                                             <asp:BoundField ItemStyle-Width="50px" DataField="CONT_STATUS" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DOC_TYPE" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="FROM_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="TO_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="HANDOVER" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="COMMODITY" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FROM_RANG" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TO_RANG" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE" />
                                          
                                           </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        
                    </table>
        </td>
        </tr>
        <tr>
        <td>
        <asp:GridView ID="GridView1" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg" Visible="false"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="SR"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE_ID" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SERVICE" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="CUSTOMER" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_TYPE" />
                                             <asp:BoundField ItemStyle-Width="50px" DataField="CONT_STATUS" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DOC_TYPE" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="FROM_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="TO_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="120px" NullDisplayText="All" DataField="HANDOVER" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="COMMODITY" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FROM_RANG" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TO_RANG" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE" />
                                           </Columns>
                                    </asp:GridView>
        </td>
        </tr>
    </table>
</asp:Content>

