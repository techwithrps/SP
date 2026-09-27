<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ContainerInventory.aspx.vb" Inherits="Empty_ContainerInventory" Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <table width="100%" style="vertical-align: top;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Container Booking"
                                    CssClass="FormLabelTitle"> </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Lblfile" Text="File" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="UPcontainers" runat="server" />
                                                <asp:Button ID="btnUpload" runat="server" Visible="True" CssClass="FormButton" Text="Upload" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px">
                                            </td>
                                        </tr>
                                        <table id="tblCont" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                            <tr>
                                                <td colspan="4" align="center">
                                                    <table cellspacing="0">
                                                        <tr class="RepHeadFleet">
                                                            <td align="center">
                                                                <asp:Label ID="lblBookingNo" CssClass="labelHeader" Width="120px" runat="server"
                                                                    Text="Line Booking No"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblLine" CssClass="labelHeader" Width="120px" runat="server" Text="Line Name"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblBcdContNo" CssClass="labelHeader" Width="100px" runat="server"
                                                                    Text="Cont No"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblSize" CssClass="labelHeader" Width="70px" runat="server" Text="Size"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblBcdContType" CssClass="labelHeader" Width="50px" runat="server"
                                                                    Text="Type"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblDoValidity" CssClass="labelHeader" Width="70px" runat="server"
                                                                    Text="Do Validity"></asp:Label>
                                                            </td>
                                                            <td align="center">
                                                                <asp:Label ID="lblTareWeight" CssClass="labelHeader" Width="60px" runat="server"
                                                                    Text="Tare Wt"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblDocType" runat="server" Text="Doc Type" CssClass="labelHeader"></asp:Label>
                                                            </td>
                                                            <td style="width: 15px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="14" valign="top" align="center">
                                                                <div style="overflow: auto; height: 240px;">
                                                                    <asp:Repeater ID="repBookingContDeatils" runat="server">
                                                                        <HeaderTemplate>
                                                                            <table id="cont" cellspacing="0">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" Width="120px" ID="textBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'
                                                                                        ToolTip="Booking No">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList class="ddlMedium" Width="120px" ID="lstline" runat="server" OnDataBinding="prepareLine"
                                                                                        ToolTip="Line">
                                                                                    </asp:DropDownList>
                                                                                    <asp:Label Text='<%# Eval("CustomerId") %>' ID="lblCommodity" Visible="false" runat="server" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" Width="100px" ID="textContNo" runat="server" Text='<%# Eval("ContNo") %>'
                                                                                        MaxLength="11" onkeypress="this.value=this.value.toUpperCase();" onblur="validateContainer(this);"
                                                                                        ToolTip="Cont No" AutoPostBack="true">      
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="ddlMedium" Width="71px" ID="TxtSize" runat="server" Text='<%#Eval("ContSize") %>'
                                                                                        ToolTip="Cont Size">
                                                                                        
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="ddlMedium" Width="50px" ID="lstType" runat="server" Text='<%#Eval("ContType") %>'
                                                                                        ToolTip="Cont Type">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" Width="70px" ID="textDOValidity" runat="server" Text='<%# Eval("DOValidity") %>'
                                                                                        MaxLength="15" ToolTip="DO Validity">
                                                                                    </asp:TextBox>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                                                        TargetControlID="textDOValidity">
                                                                                    </ajaxToolkit:CalendarExtender>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" Width="70px" ID="textTareWeight" runat="server" Text='<%# Eval("TareWt")%>'
                                                                                        MaxLength="10" ToolTip="Tare Weight">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" Width="70px" ID="TextDocType" runat="server" Text='<%# Eval("DocType")%>'
                                                                                        MaxLength="10" ToolTip="Tare Weight">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <%--                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                                        TargetControlID="TextBeDate">
                                                                                    </ajaxToolkit:CalendarExtender>--%>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            </table></FooterTemplate>
                                                                    </asp:Repeater>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center" width="100%">
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnDelete" runat="server" Visible="false" ImageUrl="~/Images/btnDelete.png" />
                                                <asp:ImageButton ID="btnNewRows" runat="server" Visible="false" ImageUrl="~/Images/btnAddRow.png" />
                                                <asp:ImageButton ID="btnEditContDetail" runat="server" ImageUrl="~/Images/btneditcontdetails.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
