<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">

    //this function takes a value (ltext) and transmits that to the left hand frame

    function tranRight(ltext) {
        parent.frames(1).document.forms("frmReceive").item("txtReceive").value =
ltext;

    }
		</script>

<html>
<head>
    <title>Frames</title>
</head>
        <frameset cols="20%,80%">
            <frame name="1" src="DivisionLogIn.aspx">
            <frame name="2" src="BlankPage.aspx">
        </frameset>
</html>
