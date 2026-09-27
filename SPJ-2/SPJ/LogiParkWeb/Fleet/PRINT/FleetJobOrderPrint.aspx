<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FleetJobOrderPrint.aspx.vb"
    Inherits="Fleet_Print_FleetJobOrderPrint" Theme="Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td align="center">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCDtls" runat="server" Text="JSB CARGO MOVERS PRIVATE LIMITED" Font-Size="Large"
                                                Font-Bold="true"></asp:Label>
                                                <asp:HiddenField ID="hdnCompanyId" runat="server" Value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td align="center"
                                            <asp:Label ID="lblScreenTitle" CssClass="FormLabelTitle" runat="server" Text="Job Order"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblJoNo" CssClass="FormLabel" runat="server" Text="Job Order No"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label2" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textJoNO" CssClass="FormLabel" runat="server" Text="" Width="120px"></asp:Label>
                                        </td>
                                        <td width="200px" rowspan="6">
                                              </td>
                                        <td align="right">
                                            <asp:Label ID="lblJoDate" CssClass="FormLabel" runat="server" Text="Job Order Date"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label1" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textJoDate" CssClass="FormLabel" runat="server" Text="" Width="120px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblJoValidity" CssClass="FormLabel" runat="server" Text="Jo Validity."></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label4" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textJoValidity" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblJoType" CssClass="FormLabel" runat="server" Text="Jo Type"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label5" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textJoType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblVehicleNo" CssClass="FormLabel" runat="server" Text="Vehicle No"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textVehicleNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblVehicleType" CssClass="FormLabel" runat="server" Text="Vehicle Type"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label9" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textVehicleType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblJoFor" CssClass="FormLabel" runat="server" Text="Jo For"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label16" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textJoFor" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblWorkshop" CssClass="FormLabel" runat="server" Text="Workshop"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label12" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textWorkshop" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                  <%--  <tr>
                                    <td align="left">
                                            <asp:Label ID="lblremark" CssClass="FormLabel" runat="server" Text="Jo Remark"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label14" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textremark" CssClass="FormLabel" runat="server"  Width="200 px" Text=""></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="LblCloseRemark" CssClass="FormLabel" runat="server" Text="Close Remark"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label21" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textCremark" CssClass="FormLabel" runat="server"  Width="200 px" Text=""></asp:Label>
                                        </td>
                                        </tr>
				                  --%>  <%-- <tr> 
                                     <td align="left">
                                            <asp:Label ID="lblMech" CssClass="FormLabel" runat="server" Text="Mech"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label17" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="TextMech" CssClass="FormLabel"  runat="server"  Text=""></asp:Label>
                                        </td>
                                         <td align="left">
                                            <asp:Label ID="lblAmout" CssClass="FormLabel" runat="server" Text="Total Amt."></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Label10" CssClass="FormLabel" runat="server" Text=" : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="Textamt" CssClass="FormLabel" runat="server"  Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>--%>
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td align="center" class="style1">
                                            <asp:Repeater ID="rcContainers" runat="server">
                                                <HeaderTemplate>
                                                    <table id="cont1" cellspacing="1" border="0" cellpadding="0" width="70%">
                                                        <thead>
                                                            <tr style="font-weight: bold;">
                                                                <td align="left">
                                                                    <asp:Label ID="lblSbNo" CssClass="FormLabel" Width="150px" runat="server" Text="PART"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblGroupName" CssClass="FormLabel" Width="90px" runat="server" Text="Item Group Name"></asp:Label>
                                                                </td>
                                                                <td align="center" >
                                                                    <asp:Label ID="lblType" CssClass="FormLabel" Width="110" runat="server" Text="Qnty"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblRate" CssClass="FormLabel" Width="110" runat="server" Text="Rate"></asp:Label>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Label ID="lblAmt" CssClass="FormLabel" Width="110" runat="server" Text="Total Amt."></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </thead>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label Width="150px" CssClass="FormLabel" ID="textPartNo" runat="server" Text='<%# Eval("ItemName") %>'>
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label Width="90px" CssClass="FormLabel" ID="txtItemGroupName" runat="server" 
                                                           
                                                            >
                                                            </asp:Label>
                                                              <asp:HiddenField ID="hdnJoDtlsId" Value='<%# Eval("JoDtlsId") %>' runat="server" />
                                                            <asp:HiddenField  ID="hdnItemGroupId" runat="server" Value='<%# Eval("ItemGroupId") %>'/> 
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label Width="110px" CssClass="FormLabel" ID="textQnty" runat="server" Text='<%# Eval("CloseQnty") %>'>
                                                            </asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label Width="110px" CssClass="FormLabel" ID="Label8" runat="server" Text='<%# Eval("JoQnty") %>'>
                                                            </asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label Width="110px" CssClass="FormLabel" ID="Label11" runat="server" Text='<%# Eval("JoPrice") %>'>
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" CssClass="FormLabel" Width="100%" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px">
                                            <table width="100%">
                                                <tr>
						    
                                                    <td height="10px" width="20%">
                                                        <asp:Label ID="Label18" runat="server" Width="100%" Text="________________"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="Label19" CssClass="FormLabel" runat="server" Width="50%" Text="Controller"></asp:Label>
                                                    </td>
                                                    <td height="10px" width="20%">
                                                        <asp:Label ID="Label3" runat="server" Width="100%" Text="________________"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="Label6" CssClass="FormLabel" runat="server" Width="70%" Text="Maintainance"></asp:Label>
                                                    </td>
                                                    <td height="10px" width="20%">
                                                    </td>
                                                   <td height="10px" width="25%">
                                                        <asp:Label ID="Label13" runat="server" Width="100%" Text="________________"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblApprove" CssClass="FormLabel" runat="server" Width="70%" Text="Appoved By"></asp:Label>
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
    </div>
    </form>
</body>
</html>
