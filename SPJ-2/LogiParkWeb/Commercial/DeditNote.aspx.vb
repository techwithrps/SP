Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data

Partial Class Commercial_DeditNote
    Inherits System.Web.UI.Page
    Dim rows As Integer = 1
    Dim lngImpContId As Integer = 0
    Dim dblAmount As Double
    Dim dblTaxAmount As Double
    Dim dblBillQnty As Double
    Dim dblBillRate As Double
    Dim dblExRate As Double
    Dim dblDebitAmt As Double
    Dim dblDebitTax As Double
    Dim dblBillAmt As Double
    Dim dblDrTotalAmount As Double
    Dim dblWeaverAmt As Double
    Dim dblServiceTax As Double
    Dim dblIGSTTax As Double
    Dim dblCGSTTax As Double
    Dim dblSGSTTax As Double
    Dim strTerminalId As String
    Dim strInvoiceNo As String
    Dim dblTaxperc As Double
    Dim strDocType As String
    Dim strBookingNo As String
    Dim lngBookingId As Long
    Dim glService As New ArrayList
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            BtnSearchCredit.Visible = False
            BtnSearchCredit.Enabled = True
            textCreditRefNo.Enabled = False
            ListControlDataBind()
            Dim StrCrNo As String = ""

            StrCrNo = Request.QueryString("CrNo")
            search(StrCrNo)
        End If
    End Sub
    Sub ListControlDataBind()
        'Dim pExtTaxGroup As New ExtTaxGroup
        'pExtTaxGroup.TerminalId = Session.Item("LoginTerminal")
        'lstTaxGroup.DataSource = ExtTaxGroup.ReturnTaxGroupList(pExtTaxGroup)
        'lstTaxGroup.DataTextField = "TaxGroupCode"
        'lstTaxGroup.DataValueField = "TaxGroupId"
        'lstTaxGroup.DataBind()
        'lstTaxGroup.Items.Add(New ListItem("---Select---", 0))
        'lstTaxGroup.SelectedValue = 0
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
    Private Sub fillRepeatorCredit(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New TempImpInvoiceItems
                p.ServiceId = 0
                arr.Add(p)
            Next
        End If
        Repeater1.DataSource = arr
        Repeater1.DataBind()
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New DrItemDetails
                p.ServiceID = 0
                arr.Add(p)
            Next
        End If
        Repeater1.DataSource = arr
        Repeater1.DataBind()
        lblBillAmt.Text = Math.Round(dblBillAmt, 2)
        lblDebitAmt.Text = Math.Round(dblDebitAmt, 2)
        lblIGST.Text = Math.Round(dblIGSTTax, 2)
        lblSGST.Text = Math.Round(dblSGSTTax, 2)
        lblCGST.Text = Math.Round(dblCGSTTax, 2)
        lblDrTaxAmt.Text = Math.Round(dblTaxAmount, 2)
        lblDrTotalAmt.Text = Math.Round(dblDrTotalAmount, 2)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnDrId.Value.Trim <> Nothing Then
            btnPrint.Visible = True
            'btnCancelInvoice.Visible = True
        Else
            btnPrint.Visible = False
            'btnCancelInvoice.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If
        'If Session.Item("Edit") <> "Y" Then

        'End If
        'If Session.Item("Search") <> "Y" Then
        '    btnSearch.Visible = False
        'End If
        'If Session.Item("Delete") <> "Y" Then
        '    btnCancelInvoice.Visible = False
        'End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddInvoice.Visible = True
        btnSearchInvoice.Visible = False
        textInvoiceRefNo.Enabled = True
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "ADD"
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddInvoice.Visible = False
        btnSearchInvoice.Visible = True
        ' textBookingNo.Enabled = True
        tvInvoices.Nodes.Clear()
        'textBlNo.Enabled = True
        textCreditRefNo.Enabled = True
        hdnMode.Value = "SEARCH"
        'Functions.ControlFocus(textBookingNo)
        BtnSearchCredit.Visible = True
        btnAddInvoice.Visible = False
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        btnAddInvoice.Visible = False
        btnSearchInvoice.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        'lstInvoiceTo.Enabled = pEnable
        '  lstPaymentMode.Enabled = pEnable
        textNote1.Enabled = pEnable
    End Sub

    Sub manageRepControl(ByVal pEnable As Boolean)
        For Each rep As RepeaterItem In Repeater1.Items
            CType(rep.FindControl("ChkCredit"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textService"), DropDownList).Enabled = False
            CType(rep.FindControl("textQuntity"), TextBox).Enabled = pEnable
            CType(rep.FindControl("txtBillRate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("txtExRate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("txtBillAmt"), TextBox).Enabled = False
            CType(rep.FindControl("textDrAmt"), TextBox).Enabled = False
            CType(rep.FindControl("textIGST"), TextBox).Enabled = False
            CType(rep.FindControl("textEducTax"), TextBox).Enabled = False
            CType(rep.FindControl("textHEduTax"), TextBox).Enabled = False
            CType(rep.FindControl("textDrTaxAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textDrTotalAmount"), TextBox).Enabled = False
        Next
    End Sub
    Sub LoadTreeViewData(ByVal pExtImpInvoice As ExtImpInvoice)
        tvInvoices.Nodes.Clear()
        Try
            For Each obj As ImpInvoice In ExtImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                Functions.treeViewNodeSetup(tvInvoices, "0", obj.InvoiceNo, obj.InvoiceRefNo)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        For Each rc As RepeaterItem In Repeater1.Items
            If CType(rc.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(rc.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                Dim textWeaver As TextBox = CType(rc.FindControl("textWeiverReqAmt"), TextBox)
                Dim textTotalAmt As TextBox = CType(rc.FindControl("textTotalAmount"), TextBox)
                Try
                    textWeaver.Text = Double.Parse(textWeaver.Text)
                Catch ex As Exception
                    'textWeaver.Text = 0
                End Try
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
        'If ValidationCheck() = False Then
        '    Return
        'End If

        If textInvoiceRefNo.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Purchase Invoice No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        If textCreditRefNo.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Debit Ref No")
            Functions.ControlFocus(textCreditRefNo)
            Return
        End If
        If textCreditDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Debit Date")
            Functions.ControlFocus(textCreditDate)
            Return
        End If
        Dim pExtImpInvoice As DrNote = returnObjectsData()
        If pExtImpInvoice.DRNoteList.Count = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Minimum One Service for Debit Note")
            'Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        If chkInvoiceChecked.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Invoice Check Box")
            Functions.ControlFocus(chkInvoiceChecked)
            Return
        End If
        If pExtImpInvoice.DrAmt = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Debit Amount Should Greater then Zero")
            '  Functions.ControlFocus(chkInvoiceChecked)
            Return
        End If
        DrNote.InsertDRDetails(pExtImpInvoice)

        If pExtImpInvoice.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
        hdnDrId.Value = pExtImpInvoice.DrId
        textCreditRefNo.Text = pExtImpInvoice.DrRefNo
        Dim pCR As New DrNote
        pCR.DrId = pExtImpInvoice.DrId
        DrNote.ReturnCreaditNotebyid(pCR)
        textCreditRefNo.Text = pCR.DrRefNo
        textCreditDate.Text = pCR.DrDate
        tvInvoices.Enabled = True
        ButtonControlSetup(True)
        manageUserControls(True)
        btnPrint.Visible = True
        btnPrint.Enabled = True
    End Sub

    Function returnObjectsData() As DrNote
        Dim dblDrAmt As Double = 0.0
        Dim dblDrtax As Double = 0.0
        Dim dblBillAmt As Double = 0.0
        Dim pCr As New DrNote

        pCr.DRNoteList = New ArrayList
        For Each rc As RepeaterItem In Repeater1.Items


            If CType(rc.FindControl("ChkCredit"), CheckBox).Checked = True Then
                Dim pCreaditNote As New DrItemDetails
                Try
                    pCreaditNote.DrId = hdnDrId.Value
                Catch ex As Exception
                End Try
                pCreaditNote.CostId = hdnCostId.Value '
                Try
                    pCreaditNote.ServiceID = CType(rc.FindControl("textService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.BillRate = CType(rc.FindControl("txtBillRate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.BillQnty = CType(rc.FindControl("textQuntity"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.ExRate = Double.Parse(CType(rc.FindControl("txtExRate"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.DrAmt = Double.Parse(CType(rc.FindControl("textDrAmt"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.DrTax = Double.Parse(CType(rc.FindControl("textDrTaxAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.BillAmt = Double.Parse(CType(rc.FindControl("txtBillAmt"), TextBox).Text)
                Catch ex As Exception
                End Try

                Try
                    pCreaditNote.IGST = Double.Parse(CType(rc.FindControl("textIGST"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.SGST = Double.Parse(CType(rc.FindControl("textEducTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.CGST = Double.Parse(CType(rc.FindControl("textHEduTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.IGSTRate = Double.Parse(CType(rc.FindControl("HdnIgstPer"), HiddenField).Value)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.SGSTRate = Double.Parse(CType(rc.FindControl("Hdnsgstper"), HiddenField).Value)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.CGSTRate = Double.Parse(CType(rc.FindControl("hdncgstper"), HiddenField).Value)
                Catch ex As Exception
                End Try

                dblDrAmt = dblDrAmt + Double.Parse(CType(rc.FindControl("textDrAmt"), TextBox).Text)
                dblDrtax = dblDrtax + Double.Parse(CType(rc.FindControl("textDrTaxAmount"), TextBox).Text)
                dblBillAmt = dblBillAmt + Double.Parse(CType(rc.FindControl("txtBillAmt"), TextBox).Text)
                pCr.DRNoteList.Add(pCreaditNote)
            End If

        Next
        pCr.DrRefNo = textCreditRefNo.Text.Trim
        pCr.DrDate = textCreditDate.Text
        pCr.CostId = hdnCostId.Value
        pCr.CompanyId = hdnCmnyId.Value
        pCr.InvoiceAmt = dblBillAmt
        pCr.DrBy = Session.Item("LoginUser")
        pCr.DrAmt = dblDrAmt
        pCr.DrTax = dblDrtax
        pCr.DrNotes = textNote1.Text
        Return pCr
    End Function

    'Protected Sub lstInvoiceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInvoiceTo.SelectedIndexChanged
    '    Dim lngCustomer As Long = 0
    '    'If lstInvoiceTo.SelectedValue = "C" Then
    '    '    lngCustomer = hdnCHa.Value
    '    'ElseIf lstInvoiceTo.SelectedValue = "F" Then
    '    '    lngCustomer = HdnForwarder.Value
    '    'ElseIf lstInvoiceTo.SelectedValue = "L" Then
    '    '    lngCustomer = hdnLine.Value
    '    'End If

    '    Dim p As New ExtCustomerMaster
    '    p.TerminalId = Session.Item("LoginTerminal")
    '    p.CustomerId = lngCustomer
    '    ExtCustomerMaster.ReturnCustomerMasterDetailsById(p)

    '    'If p.PaymentTerms = "C" Then
    '    '    lstPaymentMode.SelectedValue = "C"
    '    '    lstPaymentMode.Enabled = False
    '    'ElseIf p.PaymentTerms = "R" Then
    '    '    lstPaymentMode.SelectedValue = "R"
    '    '    lstPaymentMode.Enabled = True
    '    'End If
    'End Sub

    Protected Sub btnAddBooking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddInvoice.Click
        AddBookingNo()
    End Sub


    Sub AddBookingNo()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textInvoiceRefNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Purchase Invoice No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If

        Dim p As New CostBooking
        p.LinerInvoiceNo = textInvoiceRefNo.Text

        CostBooking.ReturnPurchaseByInvoice(p)
        If p.CostID = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Purchase Invoice No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If

        lstPurchaseType.SelectedValue = p.PurchaseType
        Try
            Dim strConnectionString As String
            Dim ada As New OleDbDataAdapter

            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            If p.PurchaseType = "L" Then
                lstCustomer.Items.Clear()
                Dim pTerminalMaster As New CustomerMaster
                lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
                lstCustomer.DataTextField = "CustomerName"
                lstCustomer.DataValueField = "CustomerId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0
            Else
                lstCustomer.Items.Clear()
                Dim pVendorMaster As New VendorMaster
                lstCustomer.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
                lstCustomer.DataTextField = "VendorName"
                lstCustomer.DataValueField = "VendorId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0

            End If
            lstCustomer.SelectedValue = p.BillingParty
        Catch
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        End Try

        hdnCostId.Value = p.CostID
        hdnCmnyId.Value = p.CompanyId

        textInvoiceDate.Text = p.LinerInvoiceDate

        Dim pCostDtls As New DrItemDetails
        pCostDtls.CostId = p.CostID
        hdnCostId.Value = p.CostID
        pCostDtls.DRNoteDetailsList = DrItemDetails.ReturnCostBookingDtlsByCostId(pCostDtls)
        fillRepeator(pCostDtls.DRNoteDetailsList)

        manageControl(True)
        btnAddInvoice.Visible = False
        btnSave.Visible = True
        ' textBookingNo.Enabled = False
        btnAdd.Visible = False
        btnSearch.Visible = False
        btnCancel.Visible = True
        manageRepControl(True)
        textCreditRefNo.Enabled = False
        textCreditDate.Enabled = True
        textCreditRefNo.Enabled = True

    End Sub

    'Protected Sub tvInvoices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvInvoices.SelectedNodeChanged
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    fillRepeator(tvInvoices.SelectedNode)
    '    SaveViewState()
    '    manageUserControls(True)
    '    Functions.ControlFocus(btnAdd)
    'End Sub

    'Sub fillControlWithData(ByVal PCodeValue As TreeNode)
    '    Dim p As New ExtImpInvoice
    '    p.InvoiceNo = PCodeValue.Value
    '    p.TerminalId = Session.Item("LoginTerminal")

    '    ExtImpInvoice.ReturnInvoiceWithItemDetails(p)

    '    hdnInvoiceNo.Value = p.InvoiceNo
    '    hdnCancelStatus.Value = p.CancleFlage
    '    hdnBookingId.Value = p.LineItemId
    '    hdnPrintStatus.Value = p.PrintStatus
    '    hdnReceiptNo.Value = p.ReceiptNo
    '    textInvoiceRefNo.Text = p.InvoiceRefNo
    '    textInvoiceDate.Text = p.InvoiceDate
    '    textNote1.Text = p.InvoiceNote
    '    'Try
    '    '    lstInvoiceTo.SelectedValue = p.CustomerType
    '    'Catch ex As Exception

    '    'End Try


    '    ' lstPaymentMode.SelectedValue = p.PaymentMode
    '    fillRepeator(p.ImpInvoiceItemsList)

    'End Sub
    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then

                'If hdnMode.Value = "ADD" And CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
                '    Dim pImpInvoiceTax As New ImpInvoiceTax
                '    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                '    pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                '    pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("textService"), DropDownList).SelectedValue
                '    pImpInvoiceTax.ImpContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                '    pImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                '    For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByItemKeyId(pImpInvoiceTax)
                '        'For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByInvoiceNo(pImpInvoiceTax)
                '        If pTIT.TaxHeadId = "5" Then
                '            CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
                '            CType(e.Item.FindControl("HdnIgstPer"), HiddenField).Value = pTIT.TaxPerc
                '        End If
                '        If pTIT.TaxHeadId = "6" Then
                '            CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
                '            CType(e.Item.FindControl("Hdnsgstper"), HiddenField).Value = pTIT.TaxPerc
                '        End If
                '        If pTIT.TaxHeadId = "7" Then
                '            CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
                '            CType(e.Item.FindControl("hdncgstper"), HiddenField).Value = pTIT.TaxPerc
                '        End If
                '    Next
                'End If

                Try
                    dblBillAmt += Double.Parse(CType(e.Item.FindControl("txtBillAmt"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblDebitAmt += Double.Parse(CType(e.Item.FindControl("textDrAmt"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblIGSTTax += Double.Parse(CType(e.Item.FindControl("textIGST"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblCGSTTax += Double.Parse(CType(e.Item.FindControl("textEducTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblSGSTTax += Double.Parse(CType(e.Item.FindControl("textHEduTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblTaxAmount += Double.Parse(CType(e.Item.FindControl("textDrTaxAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblDrTotalAmount += Double.Parse(CType(e.Item.FindControl("textDrTotalAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
            End If

        End If
    End Sub
    'Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
    '    If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
    '        If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then

    '            If hdnMode.Value = "ADD" And CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
    '                Dim pImpInvoiceTax As New ImpInvoiceTax
    '                pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
    '                pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
    '                pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
    '                pImpInvoiceTax.ImpContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
    '                For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByInvoiceNo(pImpInvoiceTax)
    '                    If pTIT.TaxHeadId = "5" Then
    '                        CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
    '                        'CType(e.Item.FindControl("HdnIgstPer"), HiddenField).Value = pTIT.TaxPerc
    '                    End If
    '                    If pTIT.TaxHeadId = "6" Then
    '                        CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
    '                        ' CType(e.Item.FindControl("Hdnsgstper"), HiddenField).Value = pTIT.TaxPerc
    '                    End If
    '                    If pTIT.TaxHeadId = "7" Then
    '                        CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
    '                        'CType(e.Item.FindControl("hdncgstper"), HiddenField).Value = pTIT.TaxPerc
    '                    End If
    '                Next
    '            End If
    '            If hdnMode.Value = "SEARCH" Then
    '                Dim pImpInvoiceTax As New ImpInvoiceTax
    '                pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
    '                pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
    '                pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
    '                For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByInvoiceNo(pImpInvoiceTax)
    '                    If pTIT.TaxHeadId = "5" Then
    '                        CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
    '                    End If
    '                    If pTIT.TaxHeadId = "6" Then
    '                        CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
    '                    End If
    '                    If pTIT.TaxHeadId = "7" Then
    '                        CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
    '                    End If
    '                Next
    '            End If

    '        End If
    '        Try
    '            dblAmount += Double.Parse(CType(e.Item.FindControl("textAmount"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblTaxAmount += Double.Parse(CType(e.Item.FindControl("textTaxAmount"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblTotalAmount += Double.Parse(CType(e.Item.FindControl("textTotalAmount"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblWeaverAmt += Double.Parse(CType(e.Item.FindControl("textWeiverReqAmt"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblServiceTax += Double.Parse(CType(e.Item.FindControl("textServiceTax"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblEducTax += Double.Parse(CType(e.Item.FindControl("textEducTax"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            dblHEduTax += Double.Parse(CType(e.Item.FindControl("textHEduTax"), TextBox).Text)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Try
    '        If hdnBookingId.Value <> "" AndAlso hdnInvoiceNo.Value > 0 Then
    '            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Print/InvoicePrint.aspx?BookingId=" & hdnBookingId.Value & "&InvoiceNo=" & hdnInvoiceNo.Value & "" & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Sub checkQnty(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim textQuntity As TextBox = sender
            Dim txtQtny1 As Double = 0
            Dim txtRate As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim txtExRate As Double = 0
            Dim txtDrAmt As Double = 0
            Dim txtigst As Double = 0
            Dim txtCgst As Double = 0
            Dim txtSgst As Double = 0
            Dim txtDrtaxAmt As Double = 0
            Dim txtDrTotalAmt As Double = 0
            '' Dim index1 As Integer = Integer.Parse(textQuntity.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length, textQuntity.ClientID.IndexOf("_textQuntity") - "ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length))

            Dim index1 As Integer = Integer.Parse(textQuntity.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl".Length, textQuntity.ClientID.IndexOf("_textQuntity") - "ctl00_ContentPlaceHolder1_Repeater1_ctl".Length))
            Dim rep As RepeaterItem
            rep = Repeater1.Items(index1 - 1)
            If textQuntity.Text <> "" Then
                txtQtny1 = Double.Parse(textQuntity.Text)
                txtRate = Double.Parse(CType(rep.FindControl("txtBillRate"), TextBox).Text)
                txtExRate = Double.Parse(CType(rep.FindControl("txtExRate"), TextBox).Text)
                If txtRate <> 0 And txtQtny1 <> 0 And txtExRate <> 0 Then
                    Try
                        txtDrAmt = txtQtny1 * txtExRate * txtRate
                        txtigst = Double.Parse(CType(rep.FindControl("HdnIgstPer"), HiddenField).Value)
                        txtCgst = Double.Parse(CType(rep.FindControl("HdnCgstPer"), HiddenField).Value)
                        txtSgst = Double.Parse(CType(rep.FindControl("HdnSgstPer"), HiddenField).Value)
                        If txtigst <> 0 Then
                            txtDrtaxAmt = txtDrAmt * txtigst / 100

                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(0, 2)
                        Else
                            txtDrtaxAmt = txtDrAmt * txtCgst * 2 / 100
                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                        End If
                        txtDrTotalAmt = txtDrtaxAmt + txtDrAmt
                        CType(rep.FindControl("textDrAmt"), TextBox).Text = Math.Round(txtDrAmt, 2)
                        CType(rep.FindControl("textDrTaxAmount"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                        CType(rep.FindControl("textDrTotalAmount"), TextBox).Text = Math.Round(txtDrTotalAmt, 2)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Catch ex As Exception
        End Try
        For Each rep As RepeaterItem In Repeater1.Items
            Try
                dblBillAmt += Double.Parse(CType(rep.FindControl("txtBillAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDebitAmt += Double.Parse(CType(rep.FindControl("textDrAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblIGSTTax += Double.Parse(CType(rep.FindControl("textIGST"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblCGSTTax += Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblSGSTTax += Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(rep.FindControl("textDrTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDrTotalAmount += Double.Parse(CType(rep.FindControl("textDrTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
        Next
        lblBillAmt.Text = Math.Round(dblBillAmt, 2)
        lblDebitAmt.Text = Math.Round(dblDebitAmt, 2)
        lblIGST.Text = Math.Round(dblIGSTTax, 2)
        lblSGST.Text = Math.Round(dblSGSTTax, 2)
        lblCGST.Text = Math.Round(dblCGSTTax, 2)
        lblDrTaxAmt.Text = Math.Round(dblTaxAmount, 2)
        lblDrTotalAmt.Text = Math.Round(dblDrTotalAmount, 2)
    End Sub

    Sub checkRate(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtBillRate As TextBox = sender
            Dim txtBillRate1 As Double = 0
            Dim txtQtny As Double = 0
            Dim txtRate As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim txtExRate As Double = 0
            Dim txtDrAmt As Double = 0
            Dim txtigst As Double = 0
            Dim txtCgst As Double = 0
            Dim txtSgst As Double = 0
            Dim txtDrtaxAmt As Double = 0
            Dim txtDrTotalAmt As Double = 0
            '' Dim index1 As Integer = Integer.Parse(textQuntity.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length, textQuntity.ClientID.IndexOf("_textQuntity") - "ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length))

            Dim index1 As Integer = Integer.Parse(txtBillRate.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl".Length, txtBillRate.ClientID.IndexOf("_txtBillRate") - "ctl00_ContentPlaceHolder1_Repeater1_ctl".Length))
            Dim rep As RepeaterItem
            rep = Repeater1.Items(index1 - 1)
            If txtBillRate.Text <> "" Then
                txtBillRate1 = Double.Parse(txtBillRate.Text)
                txtQtny = Double.Parse(CType(rep.FindControl("textQuntity"), TextBox).Text)
                txtExRate = Double.Parse(CType(rep.FindControl("txtExRate"), TextBox).Text)
                If txtQtny <> 0 And txtBillRate1 <> 0 And txtExRate <> 0 Then
                    Try
                        txtDrAmt = txtQtny * txtExRate * txtBillRate1
                        txtigst = Double.Parse(CType(rep.FindControl("HdnIgstPer"), HiddenField).Value)
                        txtCgst = Double.Parse(CType(rep.FindControl("HdnCgstPer"), HiddenField).Value)
                        txtSgst = Double.Parse(CType(rep.FindControl("HdnSgstPer"), HiddenField).Value)
                        If txtigst <> 0 Then
                            txtDrtaxAmt = txtDrAmt * txtigst / 100

                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(0, 2)
                        Else
                            txtDrtaxAmt = txtDrAmt * txtCgst * 2 / 100
                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                        End If
                        txtDrTotalAmt = txtDrtaxAmt + txtDrAmt
                        CType(rep.FindControl("textDrAmt"), TextBox).Text = Math.Round(txtDrAmt, 2)
                        CType(rep.FindControl("textDrTaxAmount"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                        CType(rep.FindControl("textDrTotalAmount"), TextBox).Text = Math.Round(txtDrTotalAmt, 2)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Catch ex As Exception
        End Try
        For Each rep As RepeaterItem In Repeater1.Items
            Try
                dblBillAmt += Double.Parse(CType(rep.FindControl("txtBillAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDebitAmt += Double.Parse(CType(rep.FindControl("textDrAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblIGSTTax += Double.Parse(CType(rep.FindControl("textIGST"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblCGSTTax += Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblSGSTTax += Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(rep.FindControl("textDrTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDrTotalAmount += Double.Parse(CType(rep.FindControl("textDrTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
        Next
        lblBillAmt.Text = Math.Round(dblBillAmt, 2)
        lblDebitAmt.Text = Math.Round(dblDebitAmt, 2)
        lblIGST.Text = Math.Round(dblIGSTTax, 2)
        lblSGST.Text = Math.Round(dblSGSTTax, 2)
        lblCGST.Text = Math.Round(dblCGSTTax, 2)
        lblDrTaxAmt.Text = Math.Round(dblTaxAmount, 2)
        lblDrTotalAmt.Text = Math.Round(dblDrTotalAmount, 2)
    End Sub

    Sub checkExRate(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtExRate As TextBox = sender
            Dim txtQtny As Double = 0
            Dim txtExRate1 As Double = 0
            Dim txtRate As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim txtDrAmt As Double = 0
            Dim txtigst As Double = 0
            Dim txtCgst As Double = 0
            Dim txtSgst As Double = 0
            Dim txtDrtaxAmt As Double = 0
            Dim txtDrTotalAmt As Double = 0
            '' Dim index1 As Integer = Integer.Parse(textQuntity.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length, textQuntity.ClientID.IndexOf("_textQuntity") - "ctl00_ContentPlaceHolder1_Repeater1_ctl01".Length))

            Dim index1 As Integer = Integer.Parse(txtExRate.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl".Length, txtExRate.ClientID.IndexOf("_txtExRate") - "ctl00_ContentPlaceHolder1_Repeater1_ctl".Length))
            Dim rep As RepeaterItem
            rep = Repeater1.Items(index1 - 1)
            If txtExRate.Text <> "" Then
                txtExRate1 = Double.Parse(txtExRate.Text)
                txtQtny = Double.Parse(CType(rep.FindControl("textQuntity"), TextBox).Text)
                txtRate = Double.Parse(CType(rep.FindControl("txtBillRate"), TextBox).Text)
                If txtRate <> 0 And txtQtny <> 0 And txtExRate1 <> 0 Then
                    Try
                        txtDrAmt = txtQtny * txtExRate1 * txtRate
                        txtigst = Double.Parse(CType(rep.FindControl("HdnIgstPer"), HiddenField).Value)
                        txtCgst = Double.Parse(CType(rep.FindControl("HdnCgstPer"), HiddenField).Value)
                        txtSgst = Double.Parse(CType(rep.FindControl("HdnSgstPer"), HiddenField).Value)
                        If txtigst <> 0 Then
                            txtDrtaxAmt = txtDrAmt * txtigst / 100

                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(0, 2)
                        Else
                            txtDrtaxAmt = txtDrAmt * txtCgst * 2 / 100
                            CType(rep.FindControl("textIGST"), TextBox).Text = Math.Round(0, 2)
                            CType(rep.FindControl("textEducTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                            CType(rep.FindControl("textHEduTax"), TextBox).Text = Math.Round(txtDrtaxAmt / 2, 2)
                        End If
                        txtDrTotalAmt = txtDrtaxAmt + txtDrAmt
                        CType(rep.FindControl("textDrAmt"), TextBox).Text = Math.Round(txtDrAmt, 2)
                        CType(rep.FindControl("textDrTaxAmount"), TextBox).Text = Math.Round(txtDrtaxAmt, 2)
                        CType(rep.FindControl("textDrTotalAmount"), TextBox).Text = Math.Round(txtDrTotalAmt, 2)
                    Catch ex As Exception

                    End Try
                End If

            End If
        Catch ex As Exception
        End Try
        For Each rep As RepeaterItem In Repeater1.Items
            Try
                dblBillAmt += Double.Parse(CType(rep.FindControl("txtBillAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDebitAmt += Double.Parse(CType(rep.FindControl("textDrAmt"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblIGSTTax += Double.Parse(CType(rep.FindControl("textIGST"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblCGSTTax += Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblSGSTTax += Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(rep.FindControl("textDrTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblDrTotalAmount += Double.Parse(CType(rep.FindControl("textDrTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
        Next
        lblBillAmt.Text = Math.Round(dblBillAmt, 2)
        lblDebitAmt.Text = Math.Round(dblDebitAmt, 2)
        lblIGST.Text = Math.Round(dblIGSTTax, 2)
        lblSGST.Text = Math.Round(dblSGSTTax, 2)
        lblCGST.Text = Math.Round(dblCGSTTax, 2)
        lblDrTaxAmt.Text = Math.Round(dblTaxAmount, 2)
        lblDrTotalAmt.Text = Math.Round(dblDrTotalAmount, 2)
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

    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    If hdnCreditNo.Value <> "" AndAlso hdnCreditNo.Value <> Nothing Then
    '        Response.Redirect("Preview/CrPrint.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
    '    End If
    'End Sub

    Protected Sub BtnSearchCredit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearchCredit.Click

        Dim pCrNote As New DrNote
        pCrNote.DrRefNo = textCreditRefNo.Text
        DrNote.ReturnCreaditNotebyCrRefNo(pCrNote)
        pCrNote.DrDate = textCreditDate.Text

        Dim pCostBooking As New CostBooking
        pCostBooking.CostID = pCrNote.CostId

        CostBooking.ReturnPurchaseDetailsByCostId(pCostBooking)
        Try
            If pCostBooking.PurchaseType = "L" Then
                lstCustomer.Items.Clear()
                Dim pTerminalMaster As New CustomerMaster
                lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
                lstCustomer.DataTextField = "CustomerName"
                lstCustomer.DataValueField = "CustomerId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0
            Else
                lstCustomer.Items.Clear()
                Dim pVendorMaster As New VendorMaster
                lstCustomer.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
                lstCustomer.DataTextField = "VendorName"
                lstCustomer.DataValueField = "VendorId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0

            End If
            lstCustomer.SelectedValue = pCostBooking.BillingParty
        Catch
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        End Try
        lstPurchaseType.SelectedValue = pCostBooking.PurchaseType
        textInvoiceDate.Text = pCostBooking.LinerInvoiceDate
        textNote1.Text = pCrNote.DrNotes
        hdnCostId.Value = pCostBooking.CostID
        hdnCmnyId.Value = pCostBooking.CompanyId

        hdnDrId.Value = pCrNote.DrId
        Dim pDRItemDtls As New DrItemDetails
        pDRItemDtls.DrId = pCrNote.DrId
        Dim arrLiast As New ArrayList
        arrLiast = DrItemDetails.ReturnCreaditItemListbyid(pDRItemDtls)
        fillRepeator(arrLiast)
        'If pCrNote.DrId <> 0 Then
        '    Response.Redirect("Preview/CrPrint.aspx?InvoiceNo=" & pCrNote.DrId)

        'End If
        textCreditRefNo.Text = pCrNote.DrRefNo
        textCreditDate.Text = pCrNote.DrDate
        textNote1.Text = pCrNote.DrNotes
        textInvoiceRefNo.Text = pCostBooking.LinerInvoiceNo
        btnPrint.Visible = True
        If Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "sarika" Or Session.Item("LoginUser") = "ANAMIKA" Then
            BtnDelete.Visible = True
        End If

        manageRepControl(False)
    End Sub

    Sub search(ByVal CrRefNo As String)
        Dim pCrNote As New DrNote
        pCrNote.DrRefNo = CrRefNo
        DrNote.ReturnCreaditNotebyCrRefNo(pCrNote)
        pCrNote.DrDate = textCreditDate.Text

        Dim pCostBooking As New CostBooking
        pCostBooking.CostID = pCrNote.CostId

        CostBooking.ReturnPurchaseDetailsByCostId(pCostBooking)
        Try
            If pCostBooking.PurchaseType = "L" Then
                lstCustomer.Items.Clear()
                Dim pTerminalMaster As New CustomerMaster
                lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
                lstCustomer.DataTextField = "CustomerName"
                lstCustomer.DataValueField = "CustomerId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0
            Else
                lstCustomer.Items.Clear()
                Dim pVendorMaster As New VendorMaster
                lstCustomer.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
                lstCustomer.DataTextField = "VendorName"
                lstCustomer.DataValueField = "VendorId"
                lstCustomer.DataBind()
                lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomer.SelectedValue = 0

            End If
            lstCustomer.SelectedValue = pCostBooking.BillingParty
        Catch
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        End Try

        lstPurchaseType.SelectedValue = pCostBooking.PurchaseType

        textCreditRefNo.Text = pCrNote.DrRefNo
        textCreditDate.Text = pCrNote.DrDate
        textNote1.Text = pCrNote.DrNotes
        textInvoiceRefNo.Text = pCostBooking.LinerInvoiceNo

        textInvoiceDate.Text = pCostBooking.LinerInvoiceDate
        textNote1.Text = pCrNote.DrNotes
        hdnCostId.Value = pCostBooking.CostID
        hdnCmnyId.Value = pCostBooking.CompanyId

        hdnDrId.Value = pCrNote.DrId
        Dim pDRItemDtls As New DrItemDetails
        pDRItemDtls.DrId = pCrNote.DrId
        Dim arrLiast As New ArrayList
        arrLiast = DrItemDetails.ReturnCreaditItemListbyid(pDRItemDtls)
        fillRepeator(arrLiast)
        'If pCrNote.DrId <> 0 Then
        '    Response.Redirect("Preview/CrPrint.aspx?InvoiceNo=" & pCrNote.DrId)

        'End If

        btnPrint.Visible = True
        manageRepControl(False)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim pCrNote As New DrNote
        pCrNote.DrRefNo = textCreditRefNo.Text
        DrNote.ReturnCreaditNotebyCrRefNo(pCrNote)

        If pCrNote.DrId <> 0 Then
            Response.Redirect("Preview/DrPrint.aspx?InvoiceNo=" & pCrNote.DrId)
        End If
    End Sub

    Protected Sub BtnDelete_Click(sender As Object, e As System.EventArgs) Handles BtnDelete.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then
            If hdnDrId.Value <> "0" Then
                Try
                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("DELETE FROM DR_NOTE WHERE DR_ID=" & hdnDrId.Value, con)
                    cmd.ExecuteNonQuery()
                    Dim cmd1 As OleDbCommand = New OleDbCommand("DELETE FROM DR_ITEM_DETAILS WHERE DR_ID=" & hdnDrId.Value, con)
                    cmd1.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
                BtnDelete.Visible = False
                btnSearch.Visible = True
                btnAdd.Visible = True
            End If
        Else
            Return
        End If
    End Sub
End Class
