<%@ Page Title="eLOGiFleet :: Bl Status Pending" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="UpdateBlStatus.aspx.vb" Inherits="Reports_Fleet_UpdateBlStatus"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
        var ScrollHeight = 400;
        //window.onload = function () {
        //    var grid = document.getElementById(GridId); 
        //    var gridWidth = grid.offsetWidth;
        //    var gridHeight = grid.offsetHeight;
        //    var headerCellWidths = new Array();
        //    for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
        //        headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        //    }
        //    grid.parentNode.appendChild(document.createElement("div"));
        //    var parentDiv = grid.parentNode;

        //    var table = document.createElement("table");
        //    for (i = 0; i < grid.attributes.length; i++) {
        //        if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
        //            table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
        //        }
        //    }
        //    table.style.cssText = grid.style.cssText;
        //    table.style.width = gridWidth + "px";
        //    table.appendChild(document.createElement("tbody"));
        //    table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        //    var cells = table.getElementsByTagName("TH");

        //    var gridRow = grid.getElementsByTagName("TR")[0];
        //    for (var i = 0; i < cells.length; i++) {
        //        var width;
        //        if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
        //            width = headerCellWidths[i];
        //        }
        //        else {
        //            width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
        //        }
        //        cells[i].style.width = parseInt(width - 2) + "px";
        //        gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 2) + "px";
        //    }
        //    parentDiv.removeChild(grid);

        //    var dummyHeader = document.createElement("div");
        //    dummyHeader.appendChild(table);
        //    parentDiv.appendChild(dummyHeader);
        //    var scrollableDiv = document.createElement("div");
        //    if (parseInt(gridHeight) > ScrollHeight) {
        //        gridWidth = parseInt(gridWidth) + 17;
        //    }
        //    scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        //    scrollableDiv.appendChild(grid);
        //    parentDiv.appendChild(scrollableDiv);
        //}

        function TabButton() {
            if (event.keyCode == 9) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }
        }

        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            var msg = "Sorry, this functionality is disabled.";
            if (parseInt(code) === 17) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) === 8) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) === 46) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
        }
    </script>

    <script type="text/javascript">
        function EnableDisableCtrol(ctrl) {

            if (ctrl.checked == true) {
                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpdate").style.display = 'inline';

                var ctrlId = ctrl.id;
                //INPUT  Booking NO 
                const TxtBookingNo = document.getElementById(ctrlId.replace("CheckBox1", "TxtBookingNo"));
                TxtBookingNo.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBookingNo")).style.display = 'none';

                //SECOND INPUT  BL NO
                const TxtBLNO = document.getElementById(ctrlId.replace("CheckBox1", "TxtBLNO"));
                TxtBLNO.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBLNO")).style.display = 'none';

                // INPUT  BL Type

                let lblBLStatusObj = document.getElementById(ctrlId.replace("CheckBox1", "lblBLStatus"));
                let lblBLStatusObj1 = lblBLStatusObj.textContent;


                const lstBLStatus1 = document.getElementById(ctrlId.replace("CheckBox1", "lstBLStatus"));

                for (var i = 0; i < lstBLStatus1.options.length; i++) {
                    if (lstBLStatus1.options[i].textContent == lblBLStatusObj1) {
                        lstBLStatus1.options[i].selected = true;
                    }
                }

                const lstBLStatus = document.getElementById(ctrlId.replace("CheckBox1", "lstBLStatus"));
                lstBLStatus.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBLStatus")).style.display = 'none';

                // INPUT  lstBlMethod

                let lblBlMethodObj = document.getElementById(ctrlId.replace("CheckBox1", "lblBlMethod"));
                let lblBlMethodObj1 = lblBlMethodObj.textContent;
                const lstBlMethod1 = document.getElementById(ctrlId.replace("CheckBox1", "lstBlMethod"));

                for (var i = 0; i < lstBlMethod1.options.length; i++) {
                    if (lstBlMethod1.options[i].textContent == lblBlMethodObj1) {
                        lstBlMethod1.options[i].selected = true;
                    }
                }

                const lstBlMethod = document.getElementById(ctrlId.replace("CheckBox1", "lstBlMethod"));
                lstBlMethod.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBlMethod")).style.display = 'none';

                // INPUT  lstOBLStatus
                let lblOBLStatusObj = document.getElementById(ctrlId.replace("CheckBox1", "lblOBLStatus"));
                let lblOBLStatusObj1 = lblOBLStatusObj.textContent;
                const lstOBLStatus1 = document.getElementById(ctrlId.replace("CheckBox1", "lstOBLStatus"));

                for (var i = 0; i < lstOBLStatus1.options.length; i++) {
                    if (lstOBLStatus1.options[i].textContent == lblOBLStatusObj1) {
                        lstOBLStatus1.options[i].selected = true;
                    }
                }

                const lstOBLStatus = document.getElementById(ctrlId.replace("CheckBox1", "lstOBLStatus"));
                lstOBLStatus.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblOBLStatus")).style.display = 'none';

                // INPUT  TxtOBLStatusDate
                const TxtOBLStatusDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtOBLStatusDate"));
                TxtOBLStatusDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblOBLStatusDate")).style.display = 'none';
                const TxtConsigneeName = document.getElementById(ctrlId.replace("CheckBox1", "TxtConsigneeName"));
                TxtConsigneeName.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblConsigneeName")).style.display = 'none';

                // INPUT  LstBillTo

                let lblBillToObj = document.getElementById(ctrlId.replace("CheckBox1", "lblBillTo"));
                let lblBillToObj1 = lblBillToObj.textContent;
                const LstBillTo1 = document.getElementById(ctrlId.replace("CheckBox1", "LstBillTo"));

                for (var i = 0; i < LstBillTo1.options.length; i++) {
                    if (LstBillTo1.options[i].textContent == lblBillToObj1) {
                        LstBillTo1.options[i].selected = true;
                    }
                }

                const LstBillTo = document.getElementById(ctrlId.replace("CheckBox1", "LstBillTo"));
                LstBillTo.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBillTo")).style.display = 'none';

                // INPUT  TxtOBLStatusDate
                const TxtBLRemark = document.getElementById(ctrlId.replace("CheckBox1", "TxtBLRemark"));
                TxtBLRemark.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBlRemark")).style.display = 'none';
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_BtnUpdate").style.display = 'none';

                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TxtBookingNo")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtBLNO")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstBLStatus")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstBlMethod")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstOBLStatus")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtOBLStatusDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtConsigneeName")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LstBillTo")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtBLRemark")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblBookingNo")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBLNO")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBLStatus")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBlMethod")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblOBLStatus")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblOBLStatusDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBillTo")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblBlRemark")).style.display = 'inline';

            }

        }

        function AllChecked(chkAll) {
            var checkBoxes = document.querySelectorAll('[id*="CheckBox1"]');

            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i] !== chkAll) {
                    checkBoxes[i].checked = chkAll.checked;
                    EnableDisableCtrol(checkBoxes[i])
                }
            }
        }


        function validateData() {
            var gridView = document.getElementById("<%= gvtripPendencyList.ClientID %>");
            var rows = gridView.getElementsByTagName("tr");

            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                var checkbox = row.querySelector("[type='checkbox']");
                var errorMessage = document.getElementById('ctl00_ContentPlaceHolder1_lblErrorMessage');
                var errorblank = errorMessage.innerText = ''

                if (checkbox !== null && checkbox.checked) {
                    var TxtBookingNo = row.querySelector("[id*='TxtBookingNo']");
                    var TxtBLNO = row.querySelector("[id*='TxtBLNO']");
                    var lstBLStatus = row.querySelector("[id*='lstBLStatus']");
                    var lstBlMethod = row.querySelector("[id*='lstBlMethod']");
                    var lstOBLStatus = row.querySelector("[id*='lstOBLStatus']");
                    var TxtOBLStatusDate = row.querySelector("[id*='TxtOBLStatusDate']");

                    if (TxtOBLStatusDate.value.trim() !== '') {
                        let GivenDate = TxtOBLStatusDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        //let [hours, minutes] = PartyInvoicedateParts[1].split(':');
                        let enteredDate = new Date(year, month - 1, day);
                        let currentDate = new Date();

                        if (enteredDate >= currentDate) {
                            errorMessage.innerText = 'Please ensure that the "BL Isuued Date" is less than or equal to the Current Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    // Set the visibility of controls
                    if (TxtBookingNo.value === "") {
                        errorMessage.innerText = 'please enter Booking No';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (TxtBLNO.value === "") {
                        errorMessage.innerText = "please enter BL NO";
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (lstBLStatus.value === "0") {
                        errorMessage.innerText = "Please Select BL Type";
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (lstBlMethod.value === "0") {
                        errorMessage.innerText = "Please Select BL Method";
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (lstOBLStatus === "0") {
                        errorMessage.innerText = "Please Select BL Status";
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (lstOBLStatus.value === '2') {
                        if (TxtOBLStatusDate.value === '') {
                            errorMessage.innerText = "Please Enter BL Issued Date";
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    else {
                        //alert('okk aalll')
                    }

                }
            }
        }
    </script>


    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Width="250px" Text="BL Status Update"
                    CssClass="FormLabelTitle"> </asp:Label>
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
            <td valign="top" colspan="2">
                <hr />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Customer " CssClass="label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="120px">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label ID="LblPFD" runat="server" Text="FPOD " CssClass="label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="LSTpod" runat="server" CssClass="ddlMedium" Width="100px">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label ID="LblOBLStatus" runat="server" Text="OBL Staus " CssClass="label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="LStRemark" runat="server" CssClass="ddlMedium" Width="100px">
                    <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                    <asp:ListItem Value="1" Text="APPROVED"></asp:ListItem>
                    <asp:ListItem Value="2" Text="CORRECTION"></asp:ListItem>
                    <asp:ListItem Value="3" Text="RECEIVED"></asp:ListItem>
                    <asp:ListItem Value="4" Text="WEB"></asp:ListItem>
                    <asp:ListItem Value="5" Text="MANUAL"></asp:ListItem>
                    <asp:ListItem Value="6" Text="PENDING BL INSTRUCTIONS"></asp:ListItem>
                    <asp:ListItem Value="7" Text="SAVE"></asp:ListItem>
                    <asp:ListItem Value="8" Text="SOB POST"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="FormButton" Style="display: none;" OnClientClick="validateData(this)" />
                <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
            </td>
        </tr>
    </table>
    <div style="height: 420px; width: 100%; overflow: auto;">
        <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
            runat="server">
            <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onClick="AllChecked(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" onClick="EnableDisableCtrol(this);" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Container.DataItemIndex + 1 %>
                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SHIPPER" HeaderText="Shipper" ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LINE" HeaderText="Shipping Line" ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="LINE_HANDOVER_DATE" HeaderText="Handover Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Booking NO" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                        <asp:TextBox ID="TxtBookingNo" runat="server" CssClass="textbox"
                            MaxLength="48" Text='<%# Eval("BOOKING_NO") %>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BL NO" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblBLNO" runat="server" Text='<%# Eval("BL_NO")%>'></asp:Label>
                        <asp:TextBox ID="TxtBLNO" runat="server" CssClass="textbox" MaxLength="48"
                            Text='<%# Eval("BL_NO") %>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BL Type" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblBLStatus" runat="server" Text='<%# Eval("BL_STATUS")%>'></asp:Label>
                        <asp:DropDownList ID="lstBLStatus" runat="server" CssClass="ddlMedium" Style="display: none;"
                            BackColor="LightGreen" ToolTip="1-APPROVED, 2-CORRECTION, 3-RECEIVED, 5-SEAWAY B/L, 7-ORIGINAL B/L-RFS, 6-DESTINATION B/L, 8-ORIGINAL B/L-SOB, 9-DRAFT BL">
                            <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                            <asp:ListItem Value="7" Text="ORIGINAL B/L-RFS"></asp:ListItem>
                            <asp:ListItem Value="8" Text="ORIGINAL B/L-SOB"></asp:ListItem>
                            <asp:ListItem Value="5" Text="SEAWAY B/L"></asp:ListItem>
                            <asp:ListItem Value="6" Text="DESTINATION B/L"></asp:ListItem>
                            <asp:ListItem Value="1" Text="APPROVED"></asp:ListItem>
                            <asp:ListItem Value="2" Text="CORRECTION"></asp:ListItem>
                            <asp:ListItem Value="3" Text="RECEIVED"></asp:ListItem>
                            <asp:ListItem Value="9" Text="DRAFT BL"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BL Method" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblBlMethod" runat="server" Text='<%# Eval("BL_METHOD")%>'></asp:Label>
                        <asp:DropDownList ID="lstBlMethod" runat="server" CssClass="ddlMedium" Style="display: none;"
                            BackColor="LightGreen">
                            <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                            <asp:ListItem Value="1" Text="RFS"></asp:ListItem>
                            <asp:ListItem Value="2" Text="SOB"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BL Status" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblOBLStatus" runat="server" Text='<%# Eval("OBL_STATUS")%>'></asp:Label>
                        <asp:DropDownList ID="lstOBLStatus" runat="server" CssClass="ddlMedium" Style="display: none;"
                            BackColor="LightGreen">
                            <asp:ListItem Value="1" Text="PENDING"></asp:ListItem>
                            <asp:ListItem Value="2" Text="ISSUED"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BL Isuued Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblOBLStatusDate" runat="server" Width="120px" Text='<%# Eval("OBL_ISSUE_DATE")%>'></asp:Label>
                        <asp:TextBox ID="TxtOBLStatusDate" runat="server" Width="120px" CssClass="textbox" AutoComplete="OFF" onKeyDown="TabButton();" onpaste="return false;"
                            Text='<%# Eval("OBL_ISSUE_DATE") %>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clROBLStatus" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtOBLStatusDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignee Name" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblConsigneeName" runat="server" Width="200px" Text='<%# Eval("CONSINGEE_NAME")%>'></asp:Label>
                        <asp:TextBox ID="TxtConsigneeName" AutoComplete="off" onblur="this.value=this.value.toUpperCase();"  Width="200px" runat="server" CssClass="textbox"
                            Text='<%# Eval("CONSINGEE_NAME") %>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Bill Party" HeaderStyle-CssClass="RepheaderNew">
                <itemstyle backcolor="LightGreen" />
                <itemtemplate>
                    <asp:Label ID="lblBillTo" runat="server" Text='<%# Eval("BILLING_PARTY_NAME")%>'></asp:Label>
                    <asp:DropDownList ID="LstBillTo" runat="server" CssClass="ddlMedium"
                        BackColor="LightGreen" Style="display: none;">
                        <asp:ListItem Value="1" Text="SPJ"></asp:ListItem>
                        <asp:ListItem Value="2" Text="PARTY"></asp:ListItem>
                    </asp:DropDownList>
                </itemtemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="RepheaderNew">
                    <itemstyle backcolor="LightGreen" />
                    <itemtemplate>
                        <asp:Label ID="lblBlRemark" runat="server" Text='<%# Eval("BL_REMARK")%>'></asp:Label>
                        <asp:TextBox ID="TxtBLRemark" runat="server" CssClass="textbox" MaxLength="100"
                            Text='<%# Eval("BL_REMARK") %>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle Font-Size="8pt"></AlternatingRowStyle>
        </asp:GridView>
    </div>
    <table>
        <tr>
            <td align="center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
