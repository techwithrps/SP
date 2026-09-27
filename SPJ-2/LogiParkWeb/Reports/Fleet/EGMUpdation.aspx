<%@ Page Title="eLOGiFleet :: EGM Updation" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EGMUpdation.aspx.vb" Inherits="Reports_Fleet_EGMUpdation" Theme="Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <%--  <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TextEgmDT]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>--%>
    <script type="text/javascript">
        function EnableDisableCtrol(ctrl) {

            if (ctrl.checked == true) {
                var ctrlId = ctrl.id;

                const TextRefId = document.getElementById(ctrlId.replace("CheckBox1", "TextRefId"));
                TextRefId.style.display = 'block';
                TextRefId.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblRefId")).style.display = 'none';

                //SECOND INPUT  TextEgmNo
                const TextEgmNo = document.getElementById(ctrlId.replace("CheckBox1", "TextEgmNo"));
                TextEgmNo.style.display = 'block';
                TextEgmNo.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblEgmNo")).style.display = 'none';



                const TextEgmDT = document.getElementById(ctrlId.replace("CheckBox1", "TextEgmDT"));
                TextEgmDT.style.display = 'block';
                TextEgmDT.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblEgmDT")).style.display = 'none';

                //third input  TxtHandover

                //const TxtHandover = document.getElementById(ctrlId.replace("CheckBox1", "TxtHandover"));
                //TxtHandover.style.display = 'block';
                //TxtHandover.disabled = false;
                //document.getElementById(ctrlId.replace("CheckBox1", "lblHandoverDate")).style.display = 'none';



                //fourth input  TextRemarks

                //const TextRemarks = document.getElementById(ctrlId.replace("CheckBox1", "TextRemarks"));
                //TextRemarks.style.display = 'block';
                //TextRemarks.disabled = false;
                //document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'none';


                //Five input  TextRemarks

                //let lblHoldremarkObj = document.getElementById(ctrlId.replace("CheckBox1", "lblHoldremark"));
                //let lblHoldremarkObj1 = lblHoldremarkObj.textContent;
                //const LstRemark1 = document.getElementById(ctrlId.replace("CheckBox1", "LstRemark"));

                //for (var i = 0; i < LstRemark1.options.length; i++) {
                //    if (LstRemark1.options[i].textContent == lblHoldremarkObj1) {
                //        LstRemark1.options[i].selected = true;
                //    }
                //}

                //document.getElementById(ctrlId.replace("CheckBox1", "lblHoldremark")).style.display = 'none';
                //const LstRemark = document.getElementById(ctrlId.replace("CheckBox1", "LstRemark"));
                //LstRemark.style.display = 'block';
            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TextRefId")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TextEgmNo")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TextEgmDT")).style.display = 'none';
                //document.getElementById(ctrlId.replace("CheckBox1", "TxtHandover")).style.display = 'none';
                //document.getElementById(ctrlId.replace("CheckBox1", "TextRemarks")).style.display = 'none';
                //document.getElementById(ctrlId.replace("CheckBox1", "LstRemark")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblRefId")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblEgmDT")).style.display = 'inline';
                //document.getElementById(ctrlId.replace("CheckBox1", "lblHandoverDate")).style.display = 'inline';
                //document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'inline';
                //document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'lblHoldremark';

            }

            document.getElementById("ctl00_ContentPlaceHolder1_Button3").style.display = 'inline';
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
                var errorblank = errorMessage.innerText = '';

                if (checkbox !== null && checkbox.checked) {
                    var TextRefId = row.querySelector("[id*='TextRefId']");
                    var TextEgmNo = row.querySelector("[id*='TextEgmNo']");
                    var TextEgmDT = row.querySelector("[id*='TextEgmDT']");
                    //var TxtHandover = row.querySelector("[id*='TxtHandover']");
                    //var LstRemark = row.querySelector("[id*='LstRemark']");
                    //var TextRemarks = row.querySelector("[id*='TextRemarks']");
                    var BookingNo = row.querySelector("[id*='lblBookingNo']");
                    var lblICDInDate = row.querySelector("[id*='lblICDInDate']");
                    var lblSBNo = row.querySelector("[id*='lblSBNo']");
                    var lblSBDate = row.querySelector("[id*='lblSBDate']");
                    var lblBookingDate = row.querySelector("[id*='lblBookingDate']");

                    var Sessionitem = '<%= Session("loginterminal") %>';
                    //console.log('Sessionitem value =', Sessionitem);

                    // Set the visibility of controls        

                    if (Sessionitem != 7 && Sessionitem != 5 && Sessionitem != 29 && Sessionitem != 53) {
                        let lblSBNo1 = lblSBNo.textContent
                        let lblSBDate1 = lblSBDate.textContent

                        if (lblSBNo1 === '' && lblSBDate1 === '') {
                            errorMessage.innerText = 'This Container EDI Not Updated';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    //if (TxtHandover.value != "") {
                    //    if (BookingNo.textContent === "") {
                    //        errorMessage.innerText = 'Documentation Page not updated';
                    //        errorMessage.style.color = "red";
                    //        event.preventDefault();
                    //        return;
                    //    }
                    //}

                    //if (TxtHandover.value.trim() !== "") {
                    if (TextRefId.value === "") {
                        errorMessage.innerText = 'Please Enter Ref Id.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }
                    //}
                    //if (TxtHandover.value.trim() !== "") {
                    if (TextEgmNo.value === "") {
                        errorMessage.innerText = 'Please fill EGM NO.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }
                    //}

                    //if (lblICDInDate.textContent.trim() !== "") {
                    //    let TxtHandover1 = TxtHandover.value.trim();
                    //    let lblICDInDate1 = lblICDInDate.textContent.trim();

                    //    let HandoverdateParts = TxtHandover1.split(' ');
                    //    let [day, month, year] = HandoverdateParts[0].split('/');
                    //    let [hours, minutes] = HandoverdateParts[1].split(':');
                    //    let parsedDateHandover = new Date(year, month - 1, day, hours, minutes);

                    //    let ICDdateParts = lblICDInDate1.split(' ');
                    //    let [ICDday, ICDmonth, ICDyear] = ICDdateParts[0].split('/');
                    //    let parsedDateIcd = new Date(ICDyear, ICDmonth - 1, ICDday);

                    //    if (parsedDateHandover < parsedDateIcd) {
                    //        errorMessage.innerText = 'Handover Date should not be less than ICD In Date.';
                    //        errorMessage.style.color = "red";
                    //        event.preventDefault();
                    //        return;
                    //    }
                    //}

                    //if (LstRemark.value.trim() !== "0") {
                    //    if (TextRemarks.value === "") {
                    //        errorMessage.innerText = 'Please fill Pending Reason or Remarks';
                    //        errorMessage.style.color = "red";
                    //        event.preventDefault();
                    //        return;
                    //    }
                    //}

                    //if (TxtHandover.value.trim() !== "") {
                    //    let TxtHandover1 = TxtHandover.value.trim();
                    //    let HandoverdateParts = TxtHandover1.split(' ');
                    //    let [day, month, year] = HandoverdateParts[0].split('/');
                    //    let [hours, minutes] = HandoverdateParts[1].split(':');
                    //    let parsedDateHandover = new Date(year, month - 1, day, hours, minutes);

                    //    let currentDate = new Date();

                    //    if (parsedDateHandover >= currentDate) {
                    //        errorMessage.innerText = 'Please ensure that the "Handover Date" is less than or equal to the Current Date.';
                    //        errorMessage.style.color = "red";
                    //        event.preventDefault();
                    //        return;
                    //    }
                    //}



                }
            }
        }


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtTRHandover]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>

     <script type="text/javascript">
         function isNumber(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                 return false;
             }
             return true;
         }
     </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="EGM Updation" CssClass="FormLabelTitle"
                    Width="300px"> </asp:Label>
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
            <td>
                <table>
                    <tr>
                        <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Style="display: none" OnClientClick="validateData(this)" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                            <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 400px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
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
                                        <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                                        <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="300px" HeaderText="Shipper"
                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Width="120" Text='<%# Eval("INV_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PARTY_INV_DATE" HeaderText="Invoice Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

                                        <asp:TemplateField HeaderText="S Bill" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSBNo" runat="server" Width="120" Text='<%# Eval("SB_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S Bill Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSBDate" runat="server" Width="120" Text='<%# Eval("SB_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ICD Place" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Port Code" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPortCode" runat="server" Text='<%# Eval("CUSTODIAN_CODE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="REF ID" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("REF_ID") %>'></asp:Label>
                                                <asp:TextBox ID="TextRefId" runat="server" Text='<%# Eval("REF_ID") %>' AutoComplete="off" CssClass="textbox"
                                                    disabled="false" ToolTip="Line Seal No" Style="display: none;" >
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EGM.NO" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblEgmNo" runat="server" Text='<%# Eval("EGM_NO") %>'></asp:Label>
                                                <asp:TextBox ID="TextEgmNo" runat="server" Text='<%# Eval("EGM_NO") %>' AutoComplete="off" CssClass="textbox"
                                                    ToolTip="EGM.NO" Style="display: none;" >
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EGM. DT" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblEgmDT" runat="server" Text='<%# Eval("EGM_DATE") %>'></asp:Label>
                                                <asp:TextBox ID="TextEgmDT" AutoComplete="OFF" runat="server" CssClass="textbox" Width="130px" 
                                                    BackColor="LightGreen" onKeyDown="TabButton();" onpaste="return false;" Style="display: none;"  Text='<%# Eval("EGM_DATE") %>' >
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clRailOutdate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="TextEgmDT" />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                    <AlternatingRowStyle></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

