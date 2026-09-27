Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Data

Partial Class Commercial_InvoiceNew
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim lngImpContId As Integer = 0
    Dim dblAmount As Double
    Dim dblTaxAmount As Double
    Dim dblTotalAmount As Double
    Dim dblWeaverAmt As Double
    Dim dblServiceTax As Double
    Dim dblEducTax As Double
    Dim dblHEduTax As Double
    Dim dblTaxperc As Double
    Dim strTerminalId As String
    Dim strInvoiceNo As String
    Dim strDocType As String
    Dim strBookingNo As String
    Dim lngBookingId As Long
    Dim glService As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()

        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
            fillRepeator(New ArrayList)
            ListDataBind()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            btnGenerate.Visible = False
            btnSearchPendency.Visible = True
            lstParty.Enabled = True
            lstBookingType.Enabled = True
            lstInvoiceTo.Enabled = True
            lstCha.Enabled = True
            textInvoiceDate.Enabled = True
            strDocType = Request.QueryString("DocType")
            strTerminalId = Request.QueryString("TerminalId")
            strInvoiceNo = Request.QueryString("InvoiceNo")
            strBookingNo = Request.QueryString("BookingNo")
            lngBookingId = Request.QueryString("BookingId")
            If strInvoiceNo <> "" Then
                ' textBookingNo.Text = strBookingNo

                hdnMode.Value = "ADD"
                hdnTempInvoiceNo.Value = strInvoiceNo
                ' hdnBookingId.Value = lngBookingId

                ' AddBookingNo()
                btnGenerate.Visible = False
                btnAdd.Visible = False
                btnSearch.Visible = False
                btnExit.Visible = False
                btnPreview.Visible = True
                btnSave.Visible = True
                btnCancel.Visible = True
                textNote.Enabled = True

                btnProceedPayment.Visible = False

                For Each rc As RepeaterItem In rcInvoiceDetails.Items
                    CType(rc.FindControl("chkSelect"), CheckBox).Enabled = True
                Next

            End If
        End If
    End Sub
    Sub ListPartyBind()
        Dim pExtCustomerMaster As New ExtCustomerMaster
        lstParty.DataSource = ExtCustomerMaster.ReturnCustomerMasterListConsignee(pExtCustomerMaster)
        lstParty.DataTextField = "CustomerName"
        lstParty.DataValueField = "CustomerId"
        lstParty.DataBind()
        lstParty.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstParty.SelectedValue = 0
    End Sub
    Sub ListDataBind()
        Dim pExtCustomerMaster As New ExtCustomerMaster
        lstParty.DataSource = ExtCustomerMaster.ReturnCustomerMasterListByPendingInvoice(pExtCustomerMaster)
        lstParty.DataTextField = "CustomerName"
        lstParty.DataValueField = "CustomerId"
        lstParty.DataBind()
        lstParty.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstParty.SelectedValue = 0

        Dim pConsignor As New ExtCustomerMaster
        pConsignor.TerminalId = Session.Item("LoginTerminal")
        lstConsignor.DataSource = ExtCustomerMaster.ReturnCustomerMasterListConsigner(pConsignor)
        lstConsignor.DataTextField = "CustomerName"
        lstConsignor.DataValueField = "CustomerId"
        lstConsignor.DataBind()
        lstConsignor.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstConsignor.SelectedValue = 0

        Dim pLine As New ExtCustomerMaster
        pLine.TerminalId = Session.Item("LoginTerminal")
        lstLine.DataSource = ExtCustomerMaster.ReturnCustomerMasterListLine(pLine)
        lstLine.DataTextField = "CustomerName"
        lstLine.DataValueField = "CustomerId"
        lstLine.DataBind()
        lstLine.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstLine.SelectedValue = 0

        Dim pCHA As New ExtCustomerMaster
        pCHA.TerminalId = Session.Item("LoginTerminal")
        lstCha.DataSource = ExtCustomerMaster.ReturnCustomerMasterListCha(pCHA)
        lstCha.DataTextField = "CustomerName"
        lstCha.DataValueField = "CustomerId"
        lstCha.DataBind()
        lstCha.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstCha.SelectedValue = 0

        Dim pAccount As New ExtCustomerMaster
        pAccount.TerminalId = Session.Item("LoginTerminal")
        lstAcount.DataSource = ExtCustomerMaster.ReturnCustomerMasterListExportAgent(pAccount)
        lstAcount.DataTextField = "CustomerName"
        lstAcount.DataValueField = "CustomerId"
        lstAcount.DataBind()
        lstAcount.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstAcount.SelectedValue = 0
    End Sub

    Protected Sub prepareDataRepControlsList()
        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        glService = ServiceMaster.ReturnServiceMasterList(pService)
    End Sub

    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", 0))
            For Each ic As ServiceMaster In glService
                lst.Items.Add(New ListItem(ic.ServiceName, ic.ServiceId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then

                If hdnMode.Value = "ADD" And CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
                    Dim pTempImpInvoiceTax As New TempImpInvoiceTax
                    pTempImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pTempImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
                    For Each pTIT As TempImpInvoiceTax In TempImpInvoiceTax.ReturnTempImpInvoiceTaxListByItemKeyId(pTempImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textIGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textCGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textSGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                    Next
                End If
                If hdnMode.Value = "SEARCH" Then
                    Dim pImpInvoiceTax As New ImpInvoiceTax
                    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
                    For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByItemKeyId(pImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textIGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textCGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textSGSTAmount"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                    Next
                End If

            End If
            Try
                dblAmount += Double.Parse(CType(e.Item.FindControl("textAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(e.Item.FindControl("textTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTotalAmount += Double.Parse(CType(e.Item.FindControl("textTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try

            Try
                dblServiceTax += Double.Parse(CType(e.Item.FindControl("textServiceTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblEducTax += Double.Parse(CType(e.Item.FindControl("textEducTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblHEduTax += Double.Parse(CType(e.Item.FindControl("textHEduTax"), TextBox).Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub Permission(ByVal P As String)
        Dim PMI As New MenuItemMaster
        PMI.Url = P
        MenuItemMaster.ReturnMenuItemMasterByURL(PMI)
        Session.Item("Title") = PMI.Title
        Dim pJMI As New JobMenuItems
        pJMI.JobId = Session.Item("JobId")
        pJMI.MenuId = PMI.MenuId
        JobMenuItems.ReturnJobMenuItems(pJMI)

        Session.Item("Add") = pJMI.AddPermit
        Session.Item("Edit") = pJMI.EditPermit
        Session.Item("Search") = pJMI.SearchPermit
        Session.Item("Delete") = pJMI.DeletePermit
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New TempImpInvoiceItems
                arr.Add(p)
            Next
        End If
        rcInvoiceDetails.DataSource = arr
        rcInvoiceDetails.DataBind()

        textRepAmount.Text = Math.Round(dblAmount, 2)
        textRepTaxAmount.Text = Math.Round(dblTaxAmount, 2)
        textRepTotalAmount.Text = Math.Round(dblTotalAmount, 2)

        textRepIGSTAmount.Text = Math.Round(dblServiceTax, 2)
        textRepCGSTAmount.Text = Math.Round(dblEducTax, 2)
        textRepSGSTAmount.Text = Math.Round(dblHEduTax, 2)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnInvoiceNo.Value.Trim <> Nothing Then
            btnPrint.Visible = True
            btnCancelInvoice.Visible = True
        Else
            btnPrint.Visible = False
            btnCancelInvoice.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
            btnCancelInvoice.Visible = False
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnGenerate.Visible = False
        lstParty.Controls.Clear()
        chkJoNo.Controls.Clear()
        'ListDataBind()
        lstParty.Enabled = True
        lstBookingType.Enabled = True
        btnPreview.Visible = False
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "ADD"
        btnSearchPendency.Visible = True
        ' Functions.ControlFocus(textBookingNo)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        chkJoNo.Controls.Clear()
        lstParty.Controls.Clear()
        ListPartyBind()
        ButtonControlSetup(True)
        btnSearchInvoice.Visible = True
        textInvoiceRefNo.Enabled = True
        btnGenerate.Visible = False
        btnPreview.Visible = False
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "SEARCH"
        btnSearchPendency.Visible = False
        '  Functions.ControlFocus(textBookingNo)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        btnPreview.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        lstInvoiceTo.Enabled = Not pEnable
        lstServiceType.Enabled = pEnable
        lstPaymentMode.Enabled = pEnable
        textNote.Enabled = Not pEnable

        textPodate.Enabled = pEnable
        textpono.Enabled = pEnable
    End Sub

    Sub manageRepControl(ByVal pEnable As Boolean)
        textNote.Enabled = pEnable

        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            If CType(rep.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(rep.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                CType(rep.FindControl("chkSelect"), CheckBox).Checked = pEnable
            Else
                CType(rep.FindControl("textContNo"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textService"), DropDownList).Enabled = pEnable
                CType(rep.FindControl("textQuntity"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textRate"), TextBox).Enabled = pEnable
            End If
        Next
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        If lstInvoiceTo.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Invoice To")
            Functions.ControlFocus(lstInvoiceTo)
            Return
        End If

        Dim pExtTempInvoice As ExtTempImpInvoice = returnExtTempImpInvoice()
        ExtTempImpInvoice.GenerateInvoice(pExtTempInvoice)
        If pExtTempInvoice.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtTempInvoice.Errormsg)
            Functions.ControlFocus(btnGenerate)
            Return
        End If

        If pExtTempInvoice.InvoiceNo <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice not generated.")
            Functions.ControlFocus(btnGenerate)
            Return
        End If

        hdnTempInvoiceNo.Value = pExtTempInvoice.InvoiceNo
        hdnPaymentMode.Value = lstPaymentMode.SelectedValue
        Dim p As New TempImpInvoiceItems
        p.TerminalId = pExtTempInvoice.TerminalId
        p.InvoiceNo = pExtTempInvoice.InvoiceNo
        p.CargoType = "E"
        fillRepeator(TempImpInvoiceItems.ReturnTempImpInvoiceItemsListBuInvoiceNo(p))
        btnGenerate.Visible = False
        btnPreview.Visible = True
        ButtonControlSetup(False)
        manageUserControls(True)
        manageRepControl(True)
        Functions.ControlFocus(textNote)
        textInvoiceDate.Enabled = True
        chkSelect.Enabled = True
    End Sub

    Function returnExtTempImpInvoice() As ExtTempImpInvoice
        Dim pExtTempImpInvoice As New ExtTempImpInvoice
        Dim JOID As String = "0"
        Dim i As Int32 = 0
        For i = 0 To chkJoNo.Items.Count - 1
            If chkJoNo.Items(i).Selected = True Then
                JOID &= "," + chkJoNo.Items(i).Value
            End If
        Next
        pExtTempImpInvoice.CreatedBy = JOID
        hdnJoId.Value = JOID

        If lstInvoiceTo.SelectedValue = "C" Then
            pExtTempImpInvoice.BillTo = lstCha.SelectedValue
        ElseIf lstInvoiceTo.SelectedValue = "L" Then
            pExtTempImpInvoice.BillTo = lstLine.SelectedValue
        ElseIf lstInvoiceTo.SelectedValue = "E" Then
            pExtTempImpInvoice.BillTo = lstParty.SelectedValue
        ElseIf lstInvoiceTo.SelectedValue = "R" Then
            pExtTempImpInvoice.BillTo = lstConsignor.SelectedValue
        ElseIf lstInvoiceTo.SelectedValue = "A" Then
            pExtTempImpInvoice.BillTo = lstAcount.SelectedValue
        End If

        hdnInvoiceTo.Value = pExtTempImpInvoice.BillTo
        pExtTempImpInvoice.CustomerType = lstInvoiceTo.SelectedValue
        pExtTempImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pExtTempImpInvoice.ServiceType = lstServiceType.SelectedValue
        Return pExtTempImpInvoice
    End Function

    Sub LoadTreeViewData(ByVal pExtImpInvoice As ExtImpInvoice)
        tvInvoices.Nodes.Clear()
        Try
            For Each obj As ImpInvoice In ExtImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                ImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                Functions.treeViewNodeSetup(tvInvoices, "0", obj.InvoiceNo, obj.InvoiceRefNo)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        For Each rc As RepeaterItem In rcInvoiceDetails.Items
            If CType(rc.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(rc.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                Dim textTotalAmt As TextBox = CType(rc.FindControl("textTotalAmount"), TextBox)

                Try
                    textTotalAmt.Text = Double.Parse(textTotalAmt.Text)
                Catch ex As Exception
                    textTotalAmt.Text = 0
                End Try
            End If
        Next
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        If textInvoiceDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date")
            Functions.ControlFocus(textInvoiceDate)
            Return
        End If
        If chkInvoiceChecked.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select invoice check")
            Functions.ControlFocus(chkInvoiceChecked)
            Return
        End If
        Dim pExtImpInvoice As ExtImpInvoice = returnObjectsData()
        If pExtImpInvoice.ImpInvoiceItemsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select the Container")
            Functions.ControlFocus(btnSave)
            Return
        End If
        Dim pCreditCustomer As New ExtCustomerMaster
        pCreditCustomer.CustomerId = lstParty.SelectedValue
        pCreditCustomer.TerminalId = Session.Item("LoginTerminal")
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pCreditCustomer)
        If hdnInvStatus.Value <> Nothing Then
            ExtImpInvoice.UpdateInvoiceWithDetails(pExtImpInvoice)
            If pExtImpInvoice.Errormsg <> Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice.Errormsg)
                Return
            End If
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
        Else
            ExtImpInvoice.InsertInvoiceWithDetailsTemp(pExtImpInvoice)
            If pExtImpInvoice.Errormsg <> Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice.Errormsg)
                Return
            End If
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
            hdnInvoiceNo.Value = pExtImpInvoice.InvoiceNo
            textInvoiceRefNo.Text = pExtImpInvoice.InvoiceRefNo


            LoadTreeViewData(pExtImpInvoice)
            'voucher()

            tvInvoices.Enabled = True
        End If





        ButtonControlSetup(True)
        manageUserControls(True)
        btnPreview.Visible = False
        btnGenerate.Visible = False
        btnProceedPayment.Visible = True
    End Sub

    Function returnObjectsData() As ExtImpInvoice

        Dim pII As New ExtImpInvoice
        pII.ImpInvoiceList = New ArrayList

        For i = 0 To chkJoNo.Items.Count - 1
            If chkJoNo.Items(i).Selected = True Then
                Dim pExtImpInvoice As New ExtImpInvoice
                Try
                    pExtImpInvoice.InvoiceNo = hdnInvoiceNo.Value
                Catch ex As Exception
                End Try
                pExtImpInvoice.PrintStatus = hdnPrintStatus.Value
                '  pExtImpInvoice.CancleFlage = hdnCancelStatus.Value
                pExtImpInvoice.TerminalId = Session.Item("LoginTerminal")
                pExtImpInvoice.CreatedBy = Session.Item("LoginUser")

                Try
                    pExtImpInvoice.LineItemId = chkJoNo.Items(i).Value
                Catch ex As Exception
                End Try
                pExtImpInvoice.ServiceType = lstServiceType.SelectedValue
                pExtImpInvoice.InvoiceNote = textNote.Text
                pExtImpInvoice.InvoiceDate = textInvoiceDate.Text
                'pExtImpInvoice.DocType = "L"
                pExtImpInvoice.CustomerType = lstInvoiceTo.SelectedValue

                If lstInvoiceTo.SelectedValue = "C" Then
                    pExtImpInvoice.BillTo = lstCha.SelectedValue
                ElseIf lstInvoiceTo.SelectedValue = "L" Then
                    pExtImpInvoice.BillTo = lstLine.SelectedValue
                ElseIf lstInvoiceTo.SelectedValue = "E" Then
                    pExtImpInvoice.BillTo = lstParty.SelectedValue
                ElseIf lstInvoiceTo.SelectedValue = "R" Then
                    pExtImpInvoice.BillTo = lstConsignor.SelectedValue
                ElseIf lstInvoiceTo.SelectedValue = "A" Then
                    pExtImpInvoice.BillTo = lstAcount.SelectedValue
                End If

                pExtImpInvoice.ServiceType = lstServiceType.SelectedValue
                pExtImpInvoice.InvoiceNote = textNote.Text
                pExtImpInvoice.PaymentMode = lstPaymentMode.SelectedValue
                pExtImpInvoice.PoNo = textpono.Text
                pExtImpInvoice.PoDate = textPodate.Text
                pII.ImpInvoiceList.Add(pExtImpInvoice)
            End If
        Next
        pII.ImpInvoiceItemsList = New ArrayList
        pII.ImpInvoiceTaxItemsList = New ArrayList

        For Each rc As RepeaterItem In rcInvoiceDetails.Items
            If CType(rc.FindControl("chkSelect"), CheckBox).Checked = True AndAlso CType(rc.FindControl("chkSelect"), CheckBox).Enabled = True AndAlso _
            CType(rc.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(rc.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                Dim p As New ImpInvoiceItems
                p.TerminalId = Session.Item("LoginTerminal")
                p.LineItemId = CType(rc.FindControl("hdnLineItemId"), HiddenField).Value
                Try
                    p.LineItem = CType(rc.FindControl("hdnLineItem"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.ImpContId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.CommodityId = CType(rc.FindControl("hdnCommodityId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.ItemKeyId = CType(rc.FindControl("hdnItemKeyId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.InvoiceNo = hdnInvoiceNo.Value
                Catch ex As Exception
                End Try
                Try
                    p.CargoType = CType(rc.FindControl("textCargoType"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ContNo = CType(rc.FindControl("textContNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ContSize = CType(rc.FindControl("textSize"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ServiceId = CType(rc.FindControl("textService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.FromDate = CType(rc.FindControl("textFromdate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ToDate = CType(rc.FindControl("textTodate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.BillQnty = CType(rc.FindControl("textQuntity"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.BillRate = CType(rc.FindControl("textRate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.TaxPerc = CType(rc.FindControl("hdnTaxPerc"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.BillAmount = CType(rc.FindControl("textTotalAmount"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.WeiverReqAmt = CType(rc.FindControl("textWeiverReqAmt"), TextBox).Text
                Catch ex As Exception
                End Try
                If Double.TryParse(CType(rc.FindControl("hdnCont"), HiddenField).Value, 1) Then
                    Dim pTaxGroup As New TaxGroupHeads
                    pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                    pTaxGroup.TaxGroupId = CType(rc.FindControl("hdnTaxId"), HiddenField).Value
                    For Each ptxt As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                        Dim pImpInvoiceTax As New ImpInvoiceTax
                        If ptxt.TaxHeadId = "5" Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textServiceTax"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(rc.FindControl("textServiceTax"), TextBox).Text
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            pImpInvoiceTax.TaxPerc = ptxt.TaxPercentage
                        ElseIf ptxt.TaxHeadId = "6" Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textEducTax"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(rc.FindControl("textEducTax"), TextBox).Text
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            pImpInvoiceTax.TaxPerc = ptxt.TaxPercentage
                        ElseIf ptxt.TaxHeadId = "7" Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textHEduTax"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(rc.FindControl("textHEduTax"), TextBox).Text
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            pImpInvoiceTax.TaxPerc = ptxt.TaxPercentage
                        End If
                        pImpInvoiceTax.TaxOnAmt = ((p.BillRate * p.BillQnty))
                        pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                        pImpInvoiceTax.ImpContId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
                        pImpInvoiceTax.LineItemId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
                        pImpInvoiceTax.ServiceId = CType(rc.FindControl("textService"), DropDownList).SelectedValue
                        Try
                            pImpInvoiceTax.InvoiceNo = hdnInvoiceNo.Value
                        Catch ex As Exception

                        End Try
                        Try
                            pImpInvoiceTax.ItemKeyId = CType(rc.FindControl("hdnItemKeyId"), HiddenField).Value
                        Catch ex As Exception

                        End Try
                        pII.ImpInvoiceTaxItemsList.Add(pImpInvoiceTax)
                    Next
                End If

                pII.ImpInvoiceItemsList.Add(p)
            End If
        Next
        Return pII
    End Function

    Protected Sub lstInvoiceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInvoiceTo.SelectedIndexChanged
        Dim lngCustomer As Long = 0
        'If lstInvoiceTo.SelectedValue = "C" Then
        '    lngCustomer = lstCha.SelectedValue
        'ElseIf lstInvoiceTo.SelectedValue = "A" Then
        '    lngCustomer = lstAgent.SelectedValue
        'ElseIf lstInvoiceTo.SelectedValue = "L" Then
        '    lngCustomer = lstLine.SelectedValue
        'ElseIf lstInvoiceTo.SelectedValue = "B" Then
        '    lngCustomer = lstRailOperator.SelectedValue
        'End If

        lngCustomer = hdnCustomer.Value
        Dim p As New ExtCustomerMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.CustomerId = lngCustomer
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(p)

        If p.PaymentTerms = "C" Then
            lstPaymentMode.SelectedValue = "C"
            lstPaymentMode.Enabled = False
            textCreditLimit.Text = 0
        ElseIf p.PaymentTerms = "R" Then
            lstPaymentMode.SelectedValue = "R"
            lstPaymentMode.Enabled = True
            textCreditLimit.Text = p.CreditLimit
        End If
    End Sub

    Protected Sub tvInvoices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvInvoices.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        fillControlWithData(tvInvoices.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim p As New ExtImpInvoice
        p.InvoiceNo = PCodeValue.Value
        p.TerminalId = Session.Item("LoginTerminal")

        ExtImpInvoice.ReturnInvoiceWithItemDetails(p)

        hdnInvoiceNo.Value = p.InvoiceNo
        hdnPrintStatus.Value = p.PrintStatus
        lstInvoiceTo.SelectedValue = p.CustomerType
        If p.CustomerType = "C" Then
            lstCha.SelectedValue = p.BillTo
        ElseIf p.CustomerType = "R" Then
            lstConsignor.SelectedValue = p.BillTo
        Else
            lstParty.SelectedValue = p.BillTo
        End If
        textInvoiceDate.Text = p.InvoiceDate
        textNote.Text = p.InvoiceNote
        textpono.Text = p.PoNo
        textInvoiceRefNo.Text = p.InvoiceRefNo
        textPodate.Text = p.PoDate
        lstServiceType.SelectedValue = p.ServiceType
        lstPaymentMode.SelectedValue = p.PaymentMode
        fillRepeator(p.ImpInvoiceItemsList)
    End Sub

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If hdnJoId.Value <> "" AndAlso hdnTempInvoiceNo.Value > 0 Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/ExportInvoicePreview.aspx?BookingId=" & hdnJoId.Value & "&InvoiceNo=" & hdnTempInvoiceNo.Value & "&PaymentMode=" & "P" & "&InvoiceTo=" & hdnInvoiceTo.Value & "" & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If hdnInvoiceNo.Value <> "" AndAlso hdnInvoiceNo.Value <> Nothing Then
            If textInvoiceDate.Text < "20/10/2016" Then
                Response.Redirect("Preview/ExportInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
            Else
                Response.Redirect("Preview/ExportInvoicePrintPridel.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
            End If

        End If

    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If hdnInvoiceNo.Value <> "" AndAlso hdnInvoiceNo.Value <> Nothing Then
            Response.Redirect("Preview/ExportInvoicePrint1.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
        End If
    End Sub
    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As TextBox = sender
            Dim txtQnty As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length, txtRate.ClientID.IndexOf("_textRate") - "ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = rcInvoiceDetails.Items(index1 - 1)
            If txtRate.Text <> "" Then
                txtRateI = Double.Parse(txtRate.Text)
                CType(rep.FindControl("hdnCont"), HiddenField).Value = 1
                txtQnty = Double.Parse(CType(rep.FindControl("textQuntity"), TextBox).Text)
                CType(rep.FindControl("textAmount"), TextBox).Text = txtRateI * txtQnty
                Dim pServiceMaster As New ServiceMaster
                pServiceMaster.TerminalId = Session.Item("LoginTerminal")
                pServiceMaster.ServiceId = CType(rep.FindControl("textService"), DropDownList).SelectedValue
                ServiceMaster.ReturnServiceMasterByServiceId(pServiceMaster)
                '   CType(rep.FindControl("hdnTaxPerc"), HiddenField).Value = pExpContDtls.ContId

                CType(rep.FindControl("hdnTaxPerc"), HiddenField).Value = pServiceMaster.TaxOnPercentage
                CType(rep.FindControl("hdnTaxId"), HiddenField).Value = pServiceMaster.TaxGroupId
                txtTaxable = txtRateI * txtQnty / 100 * pServiceMaster.TaxOnPercentage
                Dim pTaxGroup As New TaxGroupHeads
                pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                pTaxGroup.TaxGroupId = pServiceMaster.TaxGroupId
                txtTaxamount = txtTaxable / 100
                For Each p As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                    If p.TaxHeadId = "5" Then
                        CType(rep.FindControl("textServiceTax"), TextBox).Text = txtTaxamount * p.TaxPercentage
                    ElseIf p.TaxHeadId = "6" Then
                        CType(rep.FindControl("textEducTax"), TextBox).Text = txtTaxamount * p.TaxPercentage
                    ElseIf p.TaxHeadId = "7" Then
                        CType(rep.FindControl("textHEduTax"), TextBox).Text = txtTaxamount * p.TaxPercentage
                    End If
                    dblTaxperc = dblTaxperc + p.TaxPercentage
                Next
                Try
                    CType(rep.FindControl("hdnTaxPerc"), HiddenField).Value = dblTaxperc

                Catch ex As Exception

                End Try
                Try
                    CType(rep.FindControl("textTaxAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textServiceTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)

                Catch ex As Exception

                End Try
                If CType(rep.FindControl("textTaxAmount"), TextBox).Text <> Nothing Then
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textTaxAmount"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text)
                Else
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text)

                End If

                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True

            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub checkContValid(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtCont As TextBox = sender

            Dim index1 As Integer = Integer.Parse(txtCont.ClientID.Substring("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length, txtCont.ClientID.IndexOf("_textContNo") - "ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = rcInvoiceDetails.Items(index1 - 1)
            If txtCont.Text <> "" Then
                Dim pFleetContJo As New FleetContJoDtls
                pFleetContJo.TerminalId = Session.Item("LoginTerminal")
                pFleetContJo.ContNo = txtCont.Text
                FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJo)
                CType(rep.FindControl("textSize"), TextBox).Text = pFleetContJo.ContSize
                CType(rep.FindControl("hdnImpContId"), HiddenField).Value = pFleetContJo.ContJoId
                CType(rep.FindControl("hdnCont"), HiddenField).Value = 1
                If pFleetContJo.ContJoId > 0 Then
                    CType(rep.FindControl("textService"), DropDownList).Enabled = True
                    CType(rep.FindControl("textRate"), TextBox).Enabled = True
                Else
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container No not found.")
                    Functions.ControlFocus(txtCont)
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearchPendency_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchPendency.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        btnSave.Visible = False
        If lstParty.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, LblParty.Text & " is Blank.")
            Functions.ControlFocus(lstParty)
            Exit Sub
        End If
        If lstBookingType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, LblBookingType.Text & " is Blank.")
            Functions.ControlFocus(lstParty)
            Exit Sub
        End If
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            Dim CONSIGNEE_ID As String = lstParty.SelectedValue
            Dim BookingType As String = lstBookingType.SelectedValue
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT DISTINCT FCJ.CONT_JO_ID, CONT_JO_NO FROM FLEET_CONT_JO FCJ, FLEET_GR_MAPPING GP   WHERE GP.CONT_JO_ID=FCJ.CONT_JO_ID AND GP.COMPANY_ID=" & Session.Item("CompanyId") & " AND GP.CLOSE_DATE IS NOT NULL AND  FCJ.JO_TYPE='" & lstBookingType.SelectedValue & "' AND  GP.MTY_CONT_ID NOT IN (SELECT DISTINCT IMP_CONT_ID FROM IMP_INVOICE_ITEMS III , IMP_INVOICE I  WHERE I.INVOICE_NO=III.INVOICE_NO AND  CANCLE_FLAGE IS NULL)   AND CONSIGNEE_ID=" & lstParty.SelectedValue
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet()
            ada.Fill(ds)
            chkJoNo.DataSource = ds.Tables(0)
            chkJoNo.DataTextField = "CONT_JO_NO"
            chkJoNo.DataValueField = "CONT_JO_ID"
            chkJoNo.DataBind()
            ds.Clear()
            con.Dispose()
            con.Close()
            lblJoNo.Visible = True
            btnGenerate.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearchInvoice_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnSearchInvoice.Click

        Dim p As New ExtImpInvoice
        p.InvoiceRefNo = textInvoiceRefNo.Text
        p.TerminalId = Session.Item("LoginTerminal")
        hdnInvStatus.Value = "update"
        ExtImpInvoice.ReturnImpInvoiceByInvoiceRefNo(p)
        Dim pExtImpInvoice As New ExtImpInvoice
        pExtImpInvoice.TerminalId = p.TerminalId
        pExtImpInvoice.LineItemId = p.LineItemId
        '  pExtImpInvoice.DocType = "E"
        LoadTreeViewData(pExtImpInvoice)
        If tvInvoices.Nodes.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Not Generated for Booking No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            Dim CONSIGNEE_ID As String = lstParty.SelectedValue
            Dim BookingType As String = lstBookingType.SelectedValue
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CONT_JO_ID, CONT_JO_NO FROM FLEET_CONT_JO  FCJ  WHERE CONT_JO_ID  IN (SELECT LINE_ITEM_ID FROM IMP_INVOICE WHERE INVOICE_NO= " & p.InvoiceNo & ")"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet()
            ada.Fill(ds)
            chkJoNo.DataSource = ds.Tables(0)
            chkJoNo.DataTextField = "CONT_JO_NO"
            chkJoNo.DataValueField = "CONT_JO_ID"
            chkJoNo.DataBind()
            For Each listItem As ListItem In chkJoNo.Items
                listItem.Selected = True
            Next
            ds.Clear()
            con.Dispose()
            con.Close()
            lblJoNo.Visible = True
        Catch ex As Exception

        End Try
        hdnInvoiceNo.Value = pExtImpInvoice.InvoiceNo
        If tvInvoices.Nodes.Count = 1 Then
            fillControlWithData(tvInvoices.Nodes(0))
            tvInvoices.Enabled = False
        Else
            tvInvoices.Enabled = True
        End If
        SaveViewState()
        btnSearchInvoice.Visible = False
        btnPrint.Visible = True
        btnEdit.Visible = True
    End Sub

    Protected Sub chkJoNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkJoNo.SelectedIndexChanged
        Try
            If chkJoNo.SelectedValue = True Then
                Dim JoNo As Integer = chkJoNo.SelectedValue
                Dim pFleetContJo As New FleetContJo
                pFleetContJo.TerminalId = Session.Item("LoginTerminal")
                pFleetContJo.ContJoId = JoNo
                FleetContJo.ReturnFleetContJo(pFleetContJo)
                Try
                    lstConsignor.SelectedValue = pFleetContJo.CustomerId
                Catch ex As Exception

                End Try
                lstLine.SelectedValue = 0
                lstCha.SelectedValue = pFleetContJo.CHA
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            If CType(rep.FindControl("textContNo"), TextBox).Text <> Nothing Then
                CType(rep.FindControl("textRate"), TextBox).Enabled = True
                CType(rep.FindControl("textAmount"), TextBox).Enabled = True
                CType(rep.FindControl("textServiceTax"), TextBox).Enabled = True
                CType(rep.FindControl("textEducTax"), TextBox).Enabled = True
                CType(rep.FindControl("textHEduTax"), TextBox).Enabled = True
                CType(rep.FindControl("textTaxAmount"), TextBox).Enabled = True
                CType(rep.FindControl("textTotalAmount"), TextBox).Enabled = True
                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
            End If
        Next
        textNote.Enabled = True
        textpono.Enabled = True
        textPodate.Enabled = True
        btnSave.Visible = True
        btnCancel.Visible = True
        btnEdit.Visible = False
        btnExit.Visible = False
    End Sub
End Class

