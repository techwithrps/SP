<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/HolidayMaster.aspx.vb" Inherits="Master_Admin_HolidayMaster"
    Title="LogiPark:: Holiday Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textHolidayName.clientId %>'),
                        document.getElementById('<%=lblHolidayName.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textHolidayFromDate.clientId %>'),
                            document.getElementById('<%=lblHolidayFromDate.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textHolidayToDate.clientId %>'),
                            document.getElementById('<%=lblHolidayToDate.clientId %>').innerHTML))
                                   result = true;
                                   
                    else
                       result=false;
               else
                   result=false;
          else
            result=false;
           
          return result;
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td style="height: 20px;">
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Holiday Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
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
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr style="height: 20px;">
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblHolidayName" runat="server" Text="Holiday Name " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textHolidayName" runat="server" CssClass="FormTextBoxLarg" ToolTip="Holiday Name"></asp:TextBox>
                                                <strong><span class="mandatory">*</span></strong>
                                                <asp:HiddenField ID="hdnHolidayId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblHolidayFromDate" runat="server" CssClass="FormLabel" Text="Holiday From Date "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textHolidayFromDate" runat="server" CssClass="FormTextBoxDate" ToolTip="Holiday From Date"></asp:TextBox>
                                                <strong><span class="mandatory">*</span></strong>
                                                <ajaxToolkit:CalendarExtender ID="clHolidayDate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textHolidayFromDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblHolidayToDate" runat="server" CssClass="FormLabel" Text="Holiday To Date "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textHolidayToDate" runat="server" CssClass="FormTextBoxDate" ToolTip="Holiday To Date"></asp:TextBox>
                                                <strong><span class="mandatory">*</span></strong>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textHolidayToDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblNoOfDays" runat="server" Text="No. Of Days " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textNoOfDays" Width="40px" runat="server" CssClass="RptFormTextBoxSmall"
                                                    ToolTip="No. Of Days" onkeypress="kp_integer()" MaxLength="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                               
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkIsChargable" runat="server" ToolTip="Is Chargable" Text="Is Chargable" CssClass="FormLabel"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" OnClientClick="return saveValidation();" />
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                               <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
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
