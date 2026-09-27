<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DateTimeTextBox.ascx.vb" Inherits="UserControl_DateTimeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link href="../App_Themes/Forms/Fleetcss.css" rel="stylesheet" />
<script type="text/javascript">
    function DataSelect(ctrl) {
        if (ctrl.value !== '' && ctrl.value.length < 11) {
            const now = new Date();
            ctrl.value = ctrl.value + " " + now.format("HH:mm");
        }
    }

    function TabButton() {
        if (event.keyCode === 9 || event.keyCode === 8 || event.keyCode === 186
            ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105))) {
            event.returnValue = true;
        }
        else {
            event.returnValue = false;s
        }
    }
</script>
<asp:TextBox ID="textDateTime" runat="server" MaxLength="16" Width="120" CssClass="Rpttextbox" onchange="DataSelect(this);" onKeyDown="TabButton();" onpaste="return false;"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="clExtender" runat="server" TargetControlID="textDateTime"
    BehaviorID="calendar" Format="dd/MM/yyyy" />
