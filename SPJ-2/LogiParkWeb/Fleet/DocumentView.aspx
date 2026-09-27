<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DocumentView.aspx.vb" Inherits="Fleet_DocumentView" Title="eLOGiFleet:: Document View"
    Theme="Forms" %>

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
    <script type="text/javascript">
        $("[id*=btnSendMail]").live("click", function () {
            $("#dialogMail").find("input:text").val('');
            var dlg = $("#dialogMail").dialog({

                width: 570,
                title: "Add Mail Details",
                resizable: false,
                position: [480, 300],
                buttons: {
                    Save: function () {
                        $(document.getElementById('<%= btnsaveMail.ClientID %>')).click();
                    },
                    Cancel: function () {
                        $(document.getElementById('<%= btncancle.ClientID %>')).click();
                    }

                }
            });
            dlg.parent().appendTo(jQuery("form:first"));
            return false;
        });
    
    </script>
    <script language="javascript" type="text/javascript">

        function checktodate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that the To Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
        function checkfromdate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that From Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Document View" Width="300px" CssClass="FormLabelTitle">
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
                            <asp:Label ID="lblVehicleNo" runat="server" Text="Vehicle No" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textVehicleNo" runat="server" ToolTip="Vehicle No" Width="100px"
                                CssClass="textbox" MaxLength="15">
                            </asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                              <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" CssClass="FormButton" />
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
                       
                        <tr class="RepHeadFleet">
                          
                           
                            <td>
                                <asp:Label ID="lblVehicleType" CssClass="label" runat="server" Font-Bold="True"
                                    Text="Type" Width="40px"></asp:Label>
                            </td>
                         
                            <td colspan="3"  style="text-align: center">
                                <asp:Label ID="lblrInsuranceNo" CssClass="label" runat="server" Font-Bold="True" Text="Insurance No"
                                   ></asp:Label>
                            </td>
                            <td colspan="3"  style="text-align: center">
                                <asp:Label ID="lblrRcNo" CssClass="label" runat="server" Font-Bold="True" Text="Rc No"
                                    Width="110px"></asp:Label>
                            </td>
                            
                            <td colspan="3"  style="text-align: center">
                                <asp:Label ID="lblPermitFRom" CssClass="label" runat="server" Font-Bold="True"
                                    Text="Permit Validity" Width="110px"></asp:Label>
                            </td>
                            <td colspan="3"  style="text-align: center">
                                <asp:Label ID="lblFitnessValidity" CssClass="label" runat="server" Font-Bold="True" Text="Fitness Validity"
                                    Width="110px"></asp:Label>
                            </td>
                            <td colspan="3"  style="text-align: center">
                                <asp:Label ID="lblPollutionValidity" CssClass="label" runat="server" Font-Bold="True"
                                    Text="Pollution" Width="110px"></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                      
                            <td>
                                <asp:Label ID="textVehicleType" CssClass="label" runat="server" Font-Bold="True"
                                    Width="40px"></asp:Label>
                            </td>
                             <td>
                                <asp:CheckBox ID="chkInsurance" CssClass="label" runat="server" Font-Bold="True" Width="40px" />
                             </td>
                             <td>
                                <asp:Label ID="textinsuranceno" CssClass="label" runat="server" Font-Bold="True" Width="250px"></asp:Label>
                            </td>
                             <td>
                                <asp:LinkButton ID="linkInsurance"    Text="View" CssClass="label" runat="server" Font-Bold="True" Width="50px"></asp:LinkButton>
                            </td>
                             <td>
                                <asp:CheckBox ID="chkRc" CssClass="label" runat="server" Font-Bold="True" Width="40px" />
                             </td>
                             <td>
                                <asp:Label ID="textRc" CssClass="label" runat="server" Font-Bold="True" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:LinkButton ID="lnkRC"  Text="View" CssClass="label" runat="server" Font-Bold="True" Width="50px"></asp:LinkButton>
                            </td>
                             <td>
                                <asp:CheckBox ID="chkPermit" CssClass="label" runat="server" Font-Bold="True" Width="40px" />
                             </td>
                             <td>
                                <asp:Label ID="textPermit" CssClass="label" runat="server" Font-Bold="True" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:LinkButton ID="lnkPermit"  Text="View" CssClass="label" runat="server" Font-Bold="True" Width="50px"></asp:LinkButton>
                            </td>
                             <td>
                                <asp:CheckBox ID="chkFitness" CssClass="label" runat="server" Font-Bold="True" Width="40px" />
                             </td>
                             <td>
                                <asp:Label ID="textFitness" CssClass="label" runat="server" Font-Bold="True" Width="150px"></asp:Label>
                            </td>
                             <td>
                                <asp:LinkButton ID="lnkFitness"   Text="View" CssClass="label" runat="server" Font-Bold="True" Width="50px"></asp:LinkButton>
                            </td>
                           </tr>
                           </table>
                          </div>
                          </td>
                          </tr>


                          </table>
                            <div id="dialogMail" style="display: none;">
        <table border="0" cellpadding="0" style="border-style: none;">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblToMail" runat="server" Width="150px" CssClass="FormLabel"
                        Text="To Mail"> </asp:Label>&nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="textToMail" runat="server" Width="150px" ToolTip="To Mail"
                        MaxLength="50" Font-Size="8pt" CssClass="FormTextBoxSmall" onkeypress="kp_convert_upper();"> </asp:TextBox>
                    <span class="mandatory">*</span>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblCCMail" runat="server" Width="150px" CssClass="FormLabel"
                        Text="CC Mail"> </asp:Label>&nbsp;
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="textCCMail" CssClass="FormTextBoxSmall" runat="server" Font-Size="8pt"
                        Width="150px" ToolTip="CC Mail" onkeypress="kp_convert_upper();"> </asp:TextBox>
                    <span class="mandatory">*</span>
                </td>
                </tr>
                <tr>

                <td colspan="2" style="text-align: center" >
                <asp:FileUpload ID="fileUpload" runat="server" multiple="true" class="multi" />
    
                </td>
                    
            </tr>
        </table>
    </div>

    <asp:Button ID="btnsaveMail" runat="server" Text="Save" Style="display: none" />
    <asp:Button ID="btncancle" runat="server" Text="Cancel" Style="display: none" />
</asp:Content>
