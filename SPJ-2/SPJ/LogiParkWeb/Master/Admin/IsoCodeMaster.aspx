<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="IsoCodeMaster.aspx.vb" Inherits="Master_Admin_IsoCodeMaster" Title="LogiPark:: ISO Code"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textISOCode.clientId %>'),
                   document.getElementById('<%=lblISOCode.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textISODescription.clientId %>'),
                        document.getElementById('<%=lblISODescription.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textContSize.clientId %>'),
                             document.getElementById('<%=lblContSize.clientId %>').innerHTML))
                         if (validateData(document.getElementById('<%=textContType.clientId %>'),
                                  document.getElementById('<%=lblContType.clientId %>').innerHTML))
                              if (validateData(document.getElementById('<%=textTareWeight.clientId %>'),
                                       document.getElementById('<%=lblTareWeight.clientId %>').innerHTML))
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
     function valTareWt()
          {
                 
             varTareWt = document.getElementById('<%= textTareWeight.clientid %>').getAttribute('value');
                   if (varTareWt == null || varTareWt == '')
                    {
                      varTareWt = 0;
                    }
                     if (varTareWt > 4500)
                    {
                      alert("Invalid Tare Weight.")
                      varTareWt=0;
                      varTareWt.focus; 
                      
                    }
            return true;
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="ISO Code" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblISOCode" runat="server" Text="ISO Code" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textISOCode" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_convert_upper()"
                                                    ToolTip="ISO Code" MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnISOId" runat="server" Value="" />
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblISODescription" runat="server" Text="ISO Description" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textISODescription" runat="server" CssClass="FormTextBoxLarg" MaxLength="100" ToolTip="ISO Description"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblContSize" runat="server" CssClass="FormLabel" Text="Cont Size"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContSize" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_integer()"
                                                    ToolTip="Cont Size" MaxLength="2" Width="30px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblContType" runat="server" CssClass="FormLabel" Text="Cont Type"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContType" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_convert_upper()"
                                                    ToolTip="Cont Type" MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTareWeight" runat="server" CssClass="FormLabel" Text="Tare Weight (kg)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTareWeight" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_numeric()"
                                                    ToolTip="Tare Weight" MaxLength="5" Width="40px"  onblur="valTareWt();"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblWidth" runat="server" CssClass="FormLabel" Text="Width (ft)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textWidth" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_numeric()"
                                                    ToolTip="Width" MaxLength="2" Width="30px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblLength" runat="server" CssClass="FormLabel" Text="Length (ft)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textLength" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_numeric()"
                                                    ToolTip="Length" MaxLength="2" Width="30px"></asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblHeight" runat="server" CssClass="FormLabel" Text="Height (ft)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textHeight" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_numeric()"
                                                    ToolTip="Height" MaxLength="2" Width="30px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblHazClass" runat="server" CssClass="FormLabel" Text="Haz Class"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textHazClass" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_numeric()"
                                                    ToolTip="Haz Class" MaxLength="5" Width="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkHighCubeStatus" runat="server" CssClass="FormLabel" Text=" High Cube Status"
                                                    ToolTip="High Cube Status"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkRefferStatus" runat="server" CssClass="FormLabel" Text=" Reffer Status"
                                                    ToolTip="Reffer Status"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkOpenTopStatus" runat="server" CssClass="FormLabel" Text=" Open Top Status"
                                                    ToolTip="Open Top Status"></asp:CheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkHazStatus" runat="server" ToolTip="Haz Status" Text=" Haz Status"
                                                    CssClass="FormLabel"></asp:CheckBox>
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
                            <td valign="top">
                                <div>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblSerachIsoCode" runat="server" Text="Search Details by ISO Code"
                                        CssClass="FormLabel"></asp:Label>
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="textSearchIsoCode" onkeypress="kp_convert_upper()" runat="server"
                                        CssClass="FormTextBoxMedium"></asp:TextBox>
                                    <asp:ImageButton ID="btnSearchIsoCode" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                    <div id="RepScroling" class="RepScroling" style="height: 90%; width: 320px; border-left-color: Black;">
                                        <asp:TreeView ID="tvISOcode" runat="server" Style="font-family: Verdana; font-size: 12px"
                                            Width="144px">
                                        </asp:TreeView>
                                    </div>
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
