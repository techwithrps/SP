<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TelexApproval.aspx.vb" Inherits="Reports_Fleet_TelexApproval"
    Title="eLLOGiFreight:: Telex Approval" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function handleTelexStatusChange(statusDropdown) {
            var row = statusDropdown.closest("tr");
            var approvalDropdown = row.querySelector("[id*='lstTelexApproval']");

            if (!approvalDropdown) return;

            var statusValue = statusDropdown.value;

            // Clear existing options
            approvalDropdown.innerHTML = "";

            if (statusValue === "1") {
                // Telex release → allow Yes + No
                approvalDropdown.options.add(new Option("Select", ""));
                approvalDropdown.options.add(new Option("Yes", "Y"));
                approvalDropdown.options.add(new Option("No", "N"));
            } else {
                // Other → only No
                approvalDropdown.options.add(new Option("Select", ""));
                approvalDropdown.options.add(new Option("No", "N"));
                approvalDropdown.value = "N";
            }
        }
    </script>
    <script type="text/javascript">

        // Check All / Uncheck All
        function checkAll(headerChk) {
            var grid = document.getElementById('<%= gvtripPendencyList.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] != headerChk) {
                    checkboxes[i].checked = headerChk.checked;
                }
            }
        }

        // Single selection (only one checkbox allowed)
        function singleCheck(currentChk) {
            var grid = document.getElementById('<%= gvtripPendencyList.ClientID %>');
            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            //for (var i = 0; i < checkboxes.length; i++) {
            //    if (checkboxes[i] != currentChk) {
            //        checkboxes[i].checked = false;
            //    }
            //}

            // also uncheck header checkbox
            var headerChk = grid.querySelector("input[id*='chkAll']");
            if (headerChk) {
                headerChk.checked = false;
            }
        }

    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Telex Approval"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 100%; overflow: auto;" id="tblReport" runat="server">
                                    <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                        runat="server" AlternatingRowStyle-CssClass="FormLabel" RowStyle-CssClass="FormLabel">
                                        <RowStyle Font-Size="8pt" BackColor="AntiqueWhite"></RowStyle>
                                        <Columns>

                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNewNew">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this)" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick="singleCheck(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Shipper Name" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipperName" runat="server" Text='<%#Eval("SHIPPER_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ShippingLine" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShippingLine" runat="server" Text='<%#Eval("LINE")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBLNo" runat="server" Text='<%#Eval("BL_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContainerNo" runat="server" Text='<%#Eval("CONT_NO")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFPOD" runat="server" Text='<%#Eval("FPOD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Type" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBLType" runat="server" Text='<%#Eval("BL_METHOD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Method" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBLMethod" runat="server" Text='<%#Eval("BL_METHOD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Status" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBLStatus" runat="server" Text='<%#Eval("BL_STATUS")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shipper Inv No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipperInvNo" runat="server" Text='<%#Eval("PARTY_INV_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Isuued Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="lstBLIsuuedDate" runat="server" CssClass="textbox" Text='<%#Eval("OBL_ISSUE_DATE")%>'
                                                        BackColor="LightGreen">
                                                    </asp:TextBox>
                                                    <%--                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="lstBLIsuuedDate" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telex Status" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="lstTelexStatus" runat="server" CssClass="ddlMedium" SelectedValue='<%# Eval("TELEX_STATUS") %>' BackColor="LightGreen" onchange="handleTelexStatusChange(this)">
                                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="Telex release" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="BL at our office" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="OBL send to customer" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telex Approval" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="lstTelexApproval" runat="server" CssClass="ddlMedium" SelectedValue='<%#Eval("TELEX_APPROVAL")%>' BackColor="LightGreen">
                                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telex Remarks" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="textTelexRemarks" runat="server" CssClass="ddlMedium" Text='<%#Eval("TELEX_REMARKS")%>' BackColor="LightGreen"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>


                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <%--                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" OnClientClick="return saveValidation();" />--%>
                                                <asp:Button ID="ImgBtnUpdate" runat="server" Text="UPDATE" CssClass="FormButton" />
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

