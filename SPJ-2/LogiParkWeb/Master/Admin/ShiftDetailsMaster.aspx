<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/ShiftDetailsMaster.aspx.vb" Inherits="Master_Admin_ShiftDetailsMaster"
    Title="LogiPark:: Shift Details Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script type="text/javascript" language="javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textShiftNo.clientId %>'),
                    document.getElementById('<%=lblShiftNo.clientId %>').innerHTML))
              if (validateData(document.getElementById('<%=textStartHour.clientId %>'),
                        document.getElementById('<%=lblStartTime.clientId %>').innerHTML))
                  if (validateData(document.getElementById('<%=textStartMinuts.clientId %>'),
                           document.getElementById('<%=lblStartTime.clientId %>').innerHTML))
                      if (validateData(document.getElementById('<%=textEndHour.clientId %>'),
                               document.getElementById('<%=lblEndTime.clientId %>').innerHTML))
                          if (validateData(document.getElementById('<%=textEndMinuts.clientId %>'),
                                    document.getElementById('<%=lblEndTime.clientId %>').innerHTML))
                                        result = true;
                            else
                              result=false;
                      else
                        result=false;
                  else
                    result=false;
            else
              result=false;               
         else
           result=false;
           
          return result;
    }
    
    function selectTime(obj)
    {
            var returnValue = false;
            var msg = document.getElementById("<%=lblErrorMessage.ClientID %>");
            var StartTime = document.getElementById("<%=textStartHour.clientId %>").getAttribute("value");
            if (StartTime >= 0 && StartTime <= 23)
                {
                    returnValue=true;
                    msg.innerText="";
                }
              else
               {
                msg.innerText="Hour should be 0 to 23";
                msg.style.color="Red";
                obj.focus();
                returnValue=false;
                }
      returnValue; 
    }
    function selectMinuts(obj)
    {
   
        var returnValue = false;
            var msg = document.getElementById("<%=lblErrorMessage.ClientID %>");
        var EndTime = document.getElementById("<%=textStartMinuts.clientId %>").getAttribute("value");
            if (EndTime >= 0 && EndTime <= 59)
                {
                    returnValue=true;
                    msg.innerText="";
                }
              else
              {
                msg.innerText="Hour should be 0 to 59";
                msg.style.color="Red";
                obj.focus();
                returnValue=false;
                }         
    }
    function Hour(obj)
    {
            var returnValue = false;
            var msg = document.getElementById("<%=lblErrorMessage.ClientID %>");
            var StartTime = document.getElementById("<%=textEndHour.clientId %>").getAttribute("value");
            if (StartTime >= 0 && StartTime <= 23)
                {
                    returnValue=true;
                    msg.innerText="";
                }
              else
               {
                msg.innerText="Hour should be 0 to 23";
                msg.style.color="Red";
                obj.focus();
                returnValue=false;
                }
      returnValue; 
    }
    function Minuts(obj)
    {
   
        var returnValue = false;
            var msg = document.getElementById("<%=lblErrorMessage.ClientID %>");
        var EndTime = document.getElementById("<%=textEndMinuts.clientId %>").getAttribute("value");
            if (EndTime >= 0 && EndTime <= 59)
                {
                    returnValue=true;
                    msg.innerText="";
                }
              else
              {
                msg.innerText="Hour should be 0 to 59";
                msg.style.color="Red";
                obj.focus();
                returnValue=false;
                }         
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Shift Details Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
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
                                                <asp:Label ID="lblShiftNo" runat="server" Text="Shift No" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textShiftNo" runat="server" Width="90px" MaxLength="3" CssClass="FormTextBoxSmall"
                                                    ToolTip="Shift No" onkeypress="kp_convert_upper()"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnShiftId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblStartTime" runat="server" Text="Start Time (HH:MI)" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textStartHour" runat="server" CssClass="FormTextBoxSmall" Width="25px"
                                                    ToolTip="Hour" MaxLength="2" onkeypress="kp_integer()" onblur="return selectTime(this);">
                                                </asp:TextBox><asp:TextBox ID="textStartMinuts" runat="server" CssClass="FormTextBoxSmall"
                                                    Width="25px" ToolTip="Minutes" MaxLength="2" onkeypress="kp_integer()" onblur="return selectMinuts(this);">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblEndTime" runat="server" Text="End Time (HH:MI)" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEndHour" runat="server" CssClass="FormTextBoxSmall" Width="25px"
                                                    ToolTip="Hour" MaxLength="2" onkeypress="kp_integer()" onblur="return Hour(this);">
                                                </asp:TextBox><asp:TextBox ID="textEndMinuts" runat="server" CssClass="FormTextBoxSmall"
                                                    Width="25px" ToolTip="Minutes" MaxLength="2" onkeypress="kp_integer()" onblur="return Minuts(this);">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
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
