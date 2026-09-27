Imports System.Data
Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Partial Class Commercial_Default
    Inherits Page
    Dim rows As Integer = 0
    Dim pExtServiceMaster As New ExtServiceMaster
    Dim arrListService As New ArrayList
    Dim arrCheckList As String
    'Added 15/2/2023
    Dim pAmountTotal As Integer
    Dim pIGSTAmountTotal As Integer
    Dim pSGSTAmountTotal As Integer
    Dim pCGSTAmountTotal As Integer
    Dim pTaxAmountTotal As Integer
    Dim pTotalAmount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
            fillRepeator(New ArrayList)
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            BtnInvoiceTo.Visible = False

            '  ListControldatabind()
        End If
    End Sub

    Sub ListControldatabind()
        Try
            Dim pExtCustomerMaster As New ExtCustomerMaster
            pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            LstBiitoPartyNamne.DataSource = ExtCustomerMaster.ReturnCustomerMasterListImportLine(pExtCustomerMaster)
            LstBiitoPartyNamne.DataTextField = "CustomerName"
            LstBiitoPartyNamne.DataValueField = "CustomerId"
            LstBiitoPartyNamne.DataBind()
            LstBiitoPartyNamne.Items.Add(New ListItem("---Select---", 0))
            LstBiitoPartyNamne.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub
    Sub ListControldatabind1()
        Try
            Dim pBank As New BankMaster
            pBank.TerminalId = Session.Item("LoginTerminal")
            lstBank.DataSource = BankMaster.ReturnBankMasterList(pBank)
            lstBank.DataTextField = "BankName"
            lstBank.DataValueField = "BankId"
            lstBank.DataBind()
            lstBank.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstBank.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", "0"))
            For Each SM As ServiceMaster In pExtServiceMaster.ServiceList
                lst.Items.Add(New ListItem(SM.ServiceName, SM.ServiceId))
            Next
        Catch ex As Exception
        End Try
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
                Dim p As New ImpInvoiceItems
                arr.Add(p)
            Next
        End If
        rcInvoiceDetails.DataSource = arr
        rcInvoiceDetails.DataBind()
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnExit.Visible = pVisible
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnCalculate.Visible = Not pVisible
        If hdnInvoiceNo.Value.Trim <> Nothing Then
            btnPrint.Visible = True

        Else
            btnPrint.Visible = False

        End If
        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
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
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "ADD"
        textBookingNo.Enabled = False
        lstInvoiceTo.Enabled = True
        'textBookingNo.Enabled = True
        BtnInvoiceTo.Visible = True
        BtnInvoiceTo.Enabled = True
        'btnAddBooking.Visible = True
        'btnAddBooking.Enabled = True
        'lstDocType.Enabled = True
        Functions.ControlFocus(lstInvoiceTo)
        'Functions.ControlFocus(textBookingNo)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        'btnAddBooking.Visible = False
        BtnInvoiceTo.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        lstInvoiceTo.Enabled = True
        lstServiceType.Enabled = pEnable
        'lstPaymentMode.Enabled = pEnable
        lstBank.Enabled = pEnable
        textNote.Enabled = pEnable
        LstBiitoPartyNamne.Enabled = True
        'lSTtAX.Enabled = pEnable
    End Sub

    Sub manageRepControl(ByVal pEnable As Boolean)
        textNote.Enabled = pEnable
        chkSelect.Enabled = pEnable
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            'If CType(rep.FindControl("textContNo"), TextBox).Text <> Nothing Then
            CType(rep.FindControl("textQuntity"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textExrate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textRate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("lstService"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstCurrency"), DropDownList).Enabled = pEnable
            'End If
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
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            Dim lstService As DropDownList = CType(rep.FindControl("lstService"), DropDownList)
            Dim textQuntity As TextBox = CType(rep.FindControl("textQuntity"), TextBox)
            Dim textExRate As TextBox = CType(rep.FindControl("textExRate"), TextBox)
            Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
            Dim chkSelect As CheckBox = CType(rep.FindControl("chkSelectRow"), CheckBox)

            If lstService.SelectedValue > 0 Then
                If textQuntity.Text.ToString.Trim = String.Empty Then
                    textQuntity.Text = 0
                End If
                If textExRate.Text.ToString.Trim = String.Empty Then
                    textExRate.Text = 0
                End If
                If textRate.Text.ToString.Trim = String.Empty Then
                    textRate.Text = 0
                End If
                If textQuntity.Text = 0 Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Quantity.")
                    ScriptManager.RegisterStartupScript(Me, [GetType](), "ShowAlert",
                                                "alert('Please Enter Quantity.');", True)
                    rtnBool = False
                    Functions.ControlFocus(textQuntity)
                    'Exit Function
                End If
                If textExRate.Text = 0 Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Ex-Rate.")
                    ScriptManager.RegisterStartupScript(Me, [GetType](), "ShowAlert",
                                                "alert('Please Enter Ex-Rate.');", True)
                    rtnBool = False
                    Functions.ControlFocus(textExRate)
                    'Exit Function
                End If
                If textRate.Text = 0 Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Rate.")
                    ScriptManager.RegisterStartupScript(Me, [GetType](), "ShowAlert",
                                                "alert('Please Enter Rate.');", True)
                    rtnBool = False
                    Functions.ControlFocus(textRate)
                    'Exit Function
                End If
            End If
            If textRate.Text > 0 Then
                If lstService.SelectedValue > 0 And chkSelect.Checked = False Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select a check Box.")
                    ScriptManager.RegisterStartupScript(Me, [GetType](), "ShowAlert",
                                            "alert('Please Select a check Box.');", True)
                    rtnBool = False
                    Functions.ControlFocus(chkSelect)
                    Exit Function
                End If
            End If
        Next
        Return rtnBool

    End Function
    Function returnObjectsDataInvoice() As ExtImpInvoice

        Dim pII As New ExtImpInvoice
        pII.ImpInvoiceList = New ArrayList

        Dim pExtImpInvoice As New ExtImpInvoice
        Try
            pExtImpInvoice.InvoiceNo = hdnInvoiceNo.Value
        Catch ex As Exception
        End Try
        pExtImpInvoice.PrintStatus = hdnPrintStatus.Value
        '  pExtImpInvoice.CancleFlage = hdnCancelStatus.Value
        pExtImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pExtImpInvoice.CreatedBy = Session.Item("LoginUser")
        'new
        Try
            pExtImpInvoice.BookingNo = hdnBookingId.Value
        Catch ex As Exception
        End Try
        Try
            pExtImpInvoice.InvoiceDate = textInvoiceDate.Text
        Catch ex As Exception

        End Try
        Try

            pExtImpInvoice.BookingDate = txtBookingDate.Text
        Catch ex As Exception

        End Try
        'new

        'Try
        '    pExtImpInvoice.LineItemId = hdnBookingId.Value
        'Catch ex As Exception
        'End Try
        pExtImpInvoice.ServiceType = lstServiceType.SelectedValue
        If lstBank.SelectedValue = 0 Then
            pExtImpInvoice.VisitId = 1
        Else
            pExtImpInvoice.VisitId = lstBank.SelectedValue
        End If
        pExtImpInvoice.InvoiceNote = textNote.Text

        'pExtImpInvoice.DocType = "L"
        pExtImpInvoice.CustomerType = lstInvoiceTo.SelectedValue
        pExtImpInvoice.BillTo = LstBiitoPartyNamne.SelectedValue
        pExtImpInvoice.InvoiceNote = textNote.Text
        pExtImpInvoice.PaymentMode = "R"
        'pExtImpInvoice.PoNo = textpono.Text
        'pExtImpInvoice.PoDate = textPodate.Text
        pExtImpInvoice.CompanyId = Session.Item("CompanyId")
        pII.ImpInvoiceList.Add(pExtImpInvoice)

        pII.ImpInvoiceItemsList = New ArrayList
        pII.ImpInvoiceTaxItemsList = New ArrayList

        'Added 23/12/2022
        Dim arrNewCheckList = arrCheckList.TrimEnd(",")
        Dim CheckList = arrNewCheckList.Split(",")

        'For Each rc As RepeaterItem In rcInvoiceDetails.Items
        'Dim chk As CheckBox = TryCast(rc.FindControl("chkSelectRow"), CheckBox)
        'If CType(rc.FindControl("chkSelect"), CheckBox).Checked = True AndAlso
        'CType(rc.FindControl("chkSelect"), CheckBox).Enabled = True AndAlso
        'CType(rc.FindControl("lstService"), DropDownList).SelectedValue <> Nothing AndAlso
        '    CType(rc.FindControl("lstService"), DropDownList).SelectedValue > 0 Then
        'Added 23/12/2022
        'For Each Check In CheckList
        For Each rc As RepeaterItem In rcInvoiceDetails.Items
            Dim p As New ImpInvoiceItems
            For Each Check In CheckList
                'Dim p As New ImpInvoiceItems
                p.TerminalId = Session.Item("LoginTerminal")
                p.LineItemId = hdnBookingId.Value

                'Try
                '    p.LineItem = CType(rc.FindControl("hdnLineItem"), HiddenField).Value
                'Catch ex As Exception
                'End Try
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
                ''new
                'Try
                '    p.BookingNo = hdnBookingId
                'Catch ex As Exception

                'End Try

                Try
                    p.CargoType = CType(rc.FindControl("textCargoType"), TextBox).Text
                Catch ex As Exception
                End Try
                'Try
                '    p.ContNo = CType(rc.FindControl("textContNo"), TextBox).Text
                'Catch ex As Exception
                'End Try
                'Try
                '    p.ContSize = CType(rc.FindControl("textSize"), TextBox).Text
                'Catch ex As Exception
                'End Try
                Try
                    p.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
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
                    p.ExRate = CType(rc.FindControl("textExrate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.Currency = CType(rc.FindControl("lstCurrency"), TextBox).Text
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
                    'pTaxGroup.TaxGroupId = 1
                    For Each ptxt As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                        Dim pImpInvoiceTax As New ImpInvoiceTax
                        If ptxt.TaxHeadId.Equals(5) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textIGSTAmount"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textIGSTAmount"), TextBox).Text, Double)
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If

                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                        ElseIf ptxt.TaxHeadId.Equals(6) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textSGSTAmount"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textSGSTAmount"), TextBox).Text, Double)
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnSGSTTaxPerc"), HiddenField).Value, Double)
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                        ElseIf ptxt.TaxHeadId.Equals(7) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textCGSTAmount"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textCGSTAmount"), TextBox).Text, Double)
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnCGSTTaxPerc"), HiddenField).Value, Double)
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                        End If
                        ' pImpInvoiceTax.TaxOnAmt = ((p.BillRate * p.BillQnty))
                        pImpInvoiceTax.TaxOnAmt = p.BillRate

                        pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                        pImpInvoiceTax.ImpContId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
                        pImpInvoiceTax.LineItemId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
                        pImpInvoiceTax.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
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
            Next
            pII.ImpInvoiceItemsList.Add(p)


        Next
        '        Dim p As New ImpInvoiceItems
        '        p.TerminalId = Session.Item("LoginTerminal")
        '        p.LineItemId = hdnBookingId.Value

        '        'Try
        '        '    p.LineItem = CType(rc.FindControl("hdnLineItem"), HiddenField).Value
        '        'Catch ex As Exception
        '        'End Try
        '        Try
        '            p.ImpContId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.CommodityId = CType(rc.FindControl("hdnCommodityId"), HiddenField).Value
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.ItemKeyId = CType(rc.FindControl("hdnItemKeyId"), HiddenField).Value
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.InvoiceNo = hdnInvoiceNo.Value
        '        Catch ex As Exception
        '        End Try
        '        ''new
        '        'Try
        '        '    p.BookingNo = hdnBookingId
        '        'Catch ex As Exception

        '        'End Try

        '        Try
        '            p.CargoType = CType(rc.FindControl("textCargoType"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        'Try
        '        '    p.ContNo = CType(rc.FindControl("textContNo"), TextBox).Text
        '        'Catch ex As Exception
        '        'End Try
        '        'Try
        '        '    p.ContSize = CType(rc.FindControl("textSize"), TextBox).Text
        '        'Catch ex As Exception
        '        'End Try
        '        Try
        '            p.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.FromDate = CType(rc.FindControl("textFromdate"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.ToDate = CType(rc.FindControl("textTodate"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.BillQnty = CType(rc.FindControl("textQuntity"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.ExRate = CType(rc.FindControl("textExrate"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.Currency = CType(rc.FindControl("lstCurrency"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.BillRate = CType(rc.FindControl("textRate"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.TaxPerc = CType(rc.FindControl("hdnTaxPerc"), HiddenField).Value
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.BillAmount = CType(rc.FindControl("textTotalAmount"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        Try
        '            p.WeiverReqAmt = CType(rc.FindControl("textWeiverReqAmt"), TextBox).Text
        '        Catch ex As Exception
        '        End Try
        '        If Double.TryParse(CType(rc.FindControl("hdnCont"), HiddenField).Value, 1) Then
        '            Dim pTaxGroup As New TaxGroupHeads
        '            pTaxGroup.TerminalId = Session.Item("LoginTerminal")
        '            pTaxGroup.TaxGroupId = CType(rc.FindControl("hdnTaxId"), HiddenField).Value
        '            'pTaxGroup.TaxGroupId = 1
        '            For Each ptxt As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
        '                Dim pImpInvoiceTax As New ImpInvoiceTax
        '                If ptxt.TaxHeadId.Equals(5) Then
        '                    pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
        '                    If CType(rc.FindControl("textIGSTAmount"), TextBox).Text <> "" Then
        '                        pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textIGSTAmount"), TextBox).Text, Double)
        '                    Else
        '                        pImpInvoiceTax.TaxAmt = 0
        '                    End If

        '                    Try
        '                        pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
        '                    Catch ex As Exception
        '                        pImpInvoiceTax.TaxPerc = 0
        '                    End Try
        '                ElseIf ptxt.TaxHeadId.Equals(6) Then
        '                    pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
        '                    If CType(rc.FindControl("textSGSTAmount"), TextBox).Text <> "" Then
        '                        pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textSGSTAmount"), TextBox).Text, Double)
        '                    Else
        '                        pImpInvoiceTax.TaxAmt = 0
        '                    End If
        '                    Try
        '                        pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnSGSTTaxPerc"), HiddenField).Value, Double)
        '                    Catch ex As Exception
        '                        pImpInvoiceTax.TaxPerc = 0
        '                    End Try
        '                ElseIf ptxt.TaxHeadId.Equals(7) Then
        '                    pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
        '                    If CType(rc.FindControl("textCGSTAmount"), TextBox).Text <> "" Then
        '                        pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textCGSTAmount"), TextBox).Text, Double)
        '                    Else
        '                        pImpInvoiceTax.TaxAmt = 0
        '                    End If
        '                    Try
        '                        pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnCGSTTaxPerc"), HiddenField).Value, Double)
        '                    Catch ex As Exception
        '                        pImpInvoiceTax.TaxPerc = 0
        '                    End Try
        '                End If
        '                ' pImpInvoiceTax.TaxOnAmt = ((p.BillRate * p.BillQnty))
        '                pImpInvoiceTax.TaxOnAmt = p.BillRate

        '                pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
        '                pImpInvoiceTax.ImpContId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
        '                pImpInvoiceTax.LineItemId = CType(rc.FindControl("hdnImpContId"), HiddenField).Value
        '                pImpInvoiceTax.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
        '                Try
        '                    pImpInvoiceTax.InvoiceNo = hdnInvoiceNo.Value
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    pImpInvoiceTax.ItemKeyId = CType(rc.FindControl("hdnItemKeyId"), HiddenField).Value
        '                Catch ex As Exception

        '                End Try
        '                pII.ImpInvoiceTaxItemsList.Add(pImpInvoiceTax)
        '            Next
        '        End If

        '        pII.ImpInvoiceItemsList.Add(p)

        'Next
        Return pII
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        If chkInvoiceChecked.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Invoice Check Box")
            Functions.ControlFocus(chkInvoiceChecked)
            Return
        End If
        Dim pExtImpInvoice As ExtImpInvoice = returnObjectsData()
        'If pExtImpInvoice.ImpInvoiceItemsList.Count <= 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select the Container")
        '    Functions.ControlFocus(btnSave)
        '    Return
        'End If
        ExtImpInvoice.InsertInvoiceWithDtlsTemp(pExtImpInvoice)             'Commented 13/12/2022
        Dim p As New TempImpInvoiceItems
        p.TerminalId = pExtImpInvoice.TerminalId
        p.InvoiceNo = pExtImpInvoice.InvoiceNo
        p.CargoType = "E"
        fillRepeator(New ArrayList)
        fillRepeator(TempImpInvoiceItems.ReturnTempImpInvoiceItemsListBuInvoiceNo(p))

        Dim pExtImpInvoice1 As ExtImpInvoice = returnObjectsDataInvoice()
        'NEW
        ExtImpInvoice.InsertInvoiceWithDetailsWithRebate(pExtImpInvoice1)      'Commented 14/12/2022
        If pExtImpInvoice1.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice1.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
        hdnInvoiceNo.Value = pExtImpInvoice1.InvoiceNo
        textInvoiceRefNo.Text = pExtImpInvoice1.InvoiceRefNo
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        textBookingNo.Text = pExtImpInvoice1.BookingNo
        txtBookingDate.Text = pExtImpInvoice.BookingDate
        LoadTreeViewData(pExtImpInvoice)
        tvInvoices.Enabled = True
        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub

    Function returnObjectsData() As ExtImpInvoice
        Dim pExtImpInvoice As New ExtImpInvoice
        Try
            pExtImpInvoice.InvoiceNo = hdnInvoiceNo.Value
        Catch ex As Exception
        End Try
        'new'
        Try
            pExtImpInvoice.BookingNo = hdnBookingId.Value
        Catch ex As Exception

        End Try
        'NEW
        Try
            pExtImpInvoice.InvoiceDate = textInvoiceDate.Text
        Catch ex As Exception

        End Try
        Try
            pExtImpInvoice.BookingDate = txtBookingDate.Text
        Catch ex As Exception

        End Try

        'NEW
        pExtImpInvoice.PrintStatus = hdnPrintStatus.Value
        pExtImpInvoice.CancleFlage = hdnCancelStatus.Value
        pExtImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pExtImpInvoice.CreatedBy = Session.Item("LoginUser")
        pExtImpInvoice.DocType = "R"
        Try
            pExtImpInvoice.LineItemId = hdnBookingId.Value
            If lstInvoiceTo.SelectedValue = "C" Then
                pExtImpInvoice.BillTo = hdnChaId.Value
            ElseIf lstInvoiceTo.SelectedValue = "L" Then
                pExtImpInvoice.BillTo = hdnChaId.Value
            ElseIf lstInvoiceTo.SelectedValue = "I" Then
                pExtImpInvoice.BillTo = hdnChaId.Value
            ElseIf lstInvoiceTo.SelectedValue = "E" Then
                pExtImpInvoice.BillTo = hdnChaId.Value
            ElseIf lstInvoiceTo.SelectedValue = "T" Then
                pExtImpInvoice.BillTo = hdnChaId.Value
            ElseIf lstInvoiceTo.SelectedValue = "F" Then
            End If
        Catch ex As Exception
        End Try
        If lstBank.SelectedValue = 0 Then
            pExtImpInvoice.VisitId = 1
        Else
            pExtImpInvoice.VisitId = lstBank.SelectedValue
        End If
        pExtImpInvoice.CustomerType = lstInvoiceTo.SelectedValue
        pExtImpInvoice.ServiceType = lstServiceType.SelectedValue
        pExtImpInvoice.InvoiceNote = textNote.Text
        pExtImpInvoice.PaymentMode = "R"
        pExtImpInvoice.ImpInvoiceItemsList = New ArrayList
        pExtImpInvoice.ImpInvoiceTaxItemsList = New ArrayList
        For Each rc As RepeaterItem In rcInvoiceDetails.Items
            If CType(rc.FindControl("chkSelectRow"), CheckBox).Checked = True AndAlso
                CType(rc.FindControl("chkSelectRow"), CheckBox).Enabled = True AndAlso
                CType(rc.FindControl("lstService"), DropDownList).SelectedValue <> Nothing AndAlso
                CType(rc.FindControl("lstService"), DropDownList).SelectedValue > 0 Then
                arrCheckList &= "Checked" + ","
                Dim p As New ImpInvoiceItems
                p.TerminalId = pExtImpInvoice.TerminalId
                p.LineItemId = pExtImpInvoice.LineItemId
                Try
                    p.LineItem = hdnBookingId.Value
                Catch ex As Exception
                End Try
                Try
                    p.ImpContId = CType(rc.FindControl("hdnContId"), HiddenField).Value
                Catch ex As Exception
                End Try
                'Try
                '    p.ContNo = CType(rc.FindControl("textContNo"), TextBox).Text
                'Catch ex As Exception
                'End Try
                'Try
                '    p.ContSize = CType(rc.FindControl("textSize"), TextBox).Text
                'Catch ex As Exception
                'End Try
                Try
                    p.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.BillQnty = CType(rc.FindControl("textQuntity"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ExRate = CType(rc.FindControl("textExrate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.Currency = CType(rc.FindControl("lstCurrency"), DropDownList).SelectedValue
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
                Dim pTaxGroup As New TaxGroupHeads
                pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                pTaxGroup.TaxGroupId = hdnTaxId.Value
                For Each ptxt As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                    Dim pCustomer As New CustomerMaster
                    pCustomer.TerminalId = Session.Item("LoginTerminal")
                    pCustomer.CustomerId = LstBiitoPartyNamne.SelectedValue
                    CustomerMaster.ReturnCustomerMaster(pCustomer)
                    Dim pImpInvoiceTax As New ImpInvoiceTax
                    'If CType(rc.FindControl("textIGSTAmount"), TextBox).Text > 0 Then
                    If pCustomer.StateCode <> "07" Then
                        If ptxt.TaxHeadId.Equals(5) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textIGSTAmount"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textIGSTAmount"), TextBox).Text, Double)
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                        End If
                        If ptxt.TaxHeadId.Equals(6) Then
                            pImpInvoiceTax.TaxHeadId = 6
                            pImpInvoiceTax.TaxAmt = 0
                            pImpInvoiceTax.TaxPerc = 0
                        End If
                        If ptxt.TaxHeadId.Equals(7) Then
                            pImpInvoiceTax.TaxHeadId = 7
                            pImpInvoiceTax.TaxAmt = 0
                            pImpInvoiceTax.TaxPerc = 0
                        End If
                    Else
                        If ptxt.TaxHeadId.Equals(5) Then
                            pImpInvoiceTax.TaxHeadId = 5
                            pImpInvoiceTax.TaxAmt = 0
                            pImpInvoiceTax.TaxPerc = 0
                        End If
                        If ptxt.TaxHeadId.Equals(6) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textCGSTAmount"), TextBox).Text <> "" Then
                                Try
                                    pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textCGSTAmount"), TextBox).Text, Double)
                                Catch ex As Exception
                                    pImpInvoiceTax.TaxAmt = 0
                                End Try
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If

                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
                                If pImpInvoiceTax.TaxPerc.Equals(0) Then
                                    pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnSGSTTaxPerc"), HiddenField).Value, Double)
                                End If
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                            'Try
                            '    pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
                            'Catch ex As Exception
                            '    pImpInvoiceTax.TaxPerc = 0
                            'End Try
                        ElseIf ptxt.TaxHeadId.Equals(7) Then
                            pImpInvoiceTax.TaxHeadId = ptxt.TaxHeadId
                            If CType(rc.FindControl("textSGSTAmount"), TextBox).Text <> "" Then
                                pImpInvoiceTax.TaxAmt = CType(CType(rc.FindControl("textSGSTAmount"), TextBox).Text, Double)
                            Else
                                pImpInvoiceTax.TaxAmt = 0
                            End If
                            Try
                                pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnIGSTTaxPerc"), HiddenField).Value, Double)
                                If pImpInvoiceTax.TaxPerc.Equals(0) Then
                                    pImpInvoiceTax.TaxPerc = CType(CType(rc.FindControl("hdnCGSTTaxPerc"), HiddenField).Value, Double)
                                End If
                            Catch ex As Exception
                                pImpInvoiceTax.TaxPerc = 0
                            End Try
                        End If

                    End If

                    ' pImpInvoiceTax.TaxOnAmt = ((p.BillRate * p.BillQnty) / 100)
                    pImpInvoiceTax.TaxOnAmt = p.BillRate

                    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pImpInvoiceTax.LineItemId = hdnBookingId.Value
                    'pImpInvoiceTax.ImpContId = CType(rc.FindControl("hdnContId"), HiddenField).Value
                    pImpInvoiceTax.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
                    pExtImpInvoice.ImpInvoiceTaxItemsList.Add(pImpInvoiceTax)
                Next
                pExtImpInvoice.ImpInvoiceItemsList.Add(p)
            End If
        Next
        Return pExtImpInvoice
    End Function

    'Protected Sub lstInvoiceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInvoiceTo.SelectedIndexChanged
    '    Try
    '        Dim pExtCustomerMaster As New ExtCustomerMaster
    '        pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
    '        LstBiitoPartyNamne.DataSource = ExtCustomerMaster.ReturnCustomerMasterListImportLine(pExtCustomerMaster)
    '        LstBiitoPartyNamne.DataTextField = "CustomerName"
    '        LstBiitoPartyNamne.DataValueField = "CustomerId"
    '        LstBiitoPartyNamne.DataBind()
    '        LstBiitoPartyNamne.Items.Add(New ListItem("---Select---", 0))
    '        LstBiitoPartyNamne.SelectedValue = 0
    '    Catch ex As Exception

    '    End Try
    '    ListControldatabind()

    '    'Dim strConnectionString, cmd1 As String
    '    'Dim con As OleDbConnection
    '    'Dim ada As New OleDbDataAdapter
    '    'Try
    '    '    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '    '    cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE = '" & lstInvoiceTo.SelectedValue & "' ORDER BY CUSTOMER_NAME"
    '    '    con = New OleDbConnection(strConnectionString)
    '    '    con.Open()
    '    '    ada = New OleDbDataAdapter(cmd1, con)
    '    '    Dim ds As New DataSet("Customer")
    '    '    ada.Fill(ds)
    '    '    LstBiitoPartyNamne.DataSource = ds.Tables(0)
    '    '    LstBiitoPartyNamne.DataTextField = "CUSTOMER_NAME"
    '    '    LstBiitoPartyNamne.DataValueField = "CUSTOMER_ID"
    '    '    LstBiitoPartyNamne.DataBind()
    '    '    LstBiitoPartyNamne.Items.Insert(0, (New ListItem("---Select---", "0")))
    '    '    ds.Clear()
    '    '    con.Dispose()
    '    '    con.Close()
    '    'Catch ex As Exception

    '    'End Try
    '    'manageControl(True)
    '    'LstBiitoPartyNamne.Enabled = True
    'End Sub

    'Protected Sub btnAddBooking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBooking.Click
    '    manageUserControls(True)
    '    manageRepControl(True)
    '    AddBookingNo()
    '    ListControldatabind1()
    'End Sub

    'Protected Sub tvInvoices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvInvoices.SelectedNodeChanged
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    fillControlWithData(tvInvoices.SelectedNode)
    '    SaveViewState()
    '    manageUserControls(True)
    '    Functions.ControlFocus(btnAdd)
    'End Sub

    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim p As New ExtImpInvoice
        p.InvoiceNo = PCodeValue.Value
        p.TerminalId = Session.Item("LoginTerminal")
        ExtImpInvoice.ReturnInvoiceWithItemDetails(p)
        hdnInvoiceNo.Value = p.InvoiceNo
        hdnCancelStatus.Value = p.CancleFlage
        hdnBookingId.Value = p.LineItemId
        hdnPrintStatus.Value = p.PrintStatus
        hdnReceiptNo.Value = p.ReceiptNo
        textInvoiceRefNo.Text = p.InvoiceRefNo
        textInvoiceDate.Text = p.InvoiceDate
        'new
        hdnBookingId.Value = p.BookingNo
        '
        textBookingNo.Text = p.BookingNo
        txtBookingDate.Text = p.BookingDate
        textNote.Text = p.InvoiceNote
        'lstServiceType.SelectedValue = p.ServiceType
        lstInvoiceTo.SelectedValue = p.CustomerType
        ' lstPaymentMode.SelectedValue = p.PaymentMode
        fillRepeator(p.ImpInvoiceItemsList)
    End Sub
    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

            If LstBiitoPartyNamne.SelectedValue = "0" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Bill Party.")
                Functions.ControlFocus(LstBiitoPartyNamne)
                Return
            End If

            Dim txtRate As TextBox = sender
            Dim txtQnty As Double = 0
            Dim txtRateI As Double = 0
            Dim txtExRate As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim rep = CType(CType(sender, Control).NamingContainer, RepeaterItem)
            If txtRate.Text <> "" Then
                CType(rep.FindControl("hdnCont"), HiddenField).Value = 5
                txtRateI = Double.Parse(txtRate.Text)
                txtQnty = Double.Parse(CType(rep.FindControl("textQuntity"), TextBox).Text)
                txtExRate = Double.Parse(CType(rep.FindControl("textExrate"), TextBox).Text)
                CType(rep.FindControl("textAmount"), TextBox).Text = txtRateI * txtQnty * txtExRate
                Dim pServiceMaster As New ServiceMaster
                pServiceMaster.TerminalId = Session.Item("LoginTerminal")
                pServiceMaster.ServiceId = CType(rep.FindControl("lstService"), DropDownList).SelectedValue
                ServiceMaster.ReturnServiceMasterByServiceId(pServiceMaster)
                hdnTaxOnPercentage.Value = pServiceMaster.TaxOnPercentage

                txtTaxable = txtRateI * txtExRate * txtQnty / 100 * pServiceMaster.TaxOnPercentage
                Dim PBillTo As New CustomerMaster
                PBillTo.TerminalId = Session.Item("LoginTerminal")
                PBillTo.CustomerId = LstBiitoPartyNamne.SelectedValue
                CustomerMaster.ReturnCustomerMaster(PBillTo)
                Dim pTaxGroup As New TaxGroupHeads
                pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                pTaxGroup.TaxGroupId = pServiceMaster.TaxGroupId
                ' pTaxGroup.TaxGroupId = lSTtAX.SelectedValue
                hdnTaxId.Value = pServiceMaster.TaxGroupId
                txtTaxamount = txtTaxable / 100
                CType(rep.FindControl("textCGSTAmount"), TextBox).Text = "0"
                CType(rep.FindControl("textSGSTAmount"), TextBox).Text = "0"
                CType(rep.FindControl("textIGSTAmount"), TextBox).Text = "0"

                For Each p As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                    SetTaxByState(rep, PBillTo, p, txtTaxamount)
                Next

                Try
                    CType(rep.FindControl("textTaxAmount"), TextBox).Text = CType((Double.Parse(CType(rep.FindControl("textIGSTAmount"), TextBox).Text) +
                                                                                   Double.Parse(CType(rep.FindControl("textCGSTAmount"), TextBox).Text) +
                                                                                   Double.Parse(CType(rep.FindControl("textSGSTAmount"), TextBox).Text)), String)

                Catch ex As Exception

                End Try

                If CType(rep.FindControl("textTaxAmount"), TextBox).Text <> Nothing Then
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = CType((Double.Parse(CType(rep.FindControl("textTaxAmount"), TextBox).Text) +
                                                                                     Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text)), String)
                Else
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = CType(Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text), String)

                End If

                CType(rep.FindControl("chkSelectRow"), CheckBox).Enabled = True

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetTaxByState(rep As RepeaterItem, PBillTo As CustomerMaster, p As TaxGroupHeads, txtTaxamount As Double)

        If PBillTo.CountryId.Equals(0) Then
            CType(rep.FindControl("textCGSTAmount"), TextBox).Text = "0"
            CType(rep.FindControl("textSGSTAmount"), TextBox).Text = "0"
            CType(rep.FindControl("textIGSTAmount"), TextBox).Text = "0"
            CType(rep.FindControl("hdnIGSTTaxPerc"), HiddenField).Value = "0"
            CType(rep.FindControl("hdnCGSTTaxPerc"), HiddenField).Value = "0"
            CType(rep.FindControl("hdnSGSTTaxPerc"), HiddenField).Value = "0"
        Else
            If PBillTo.StateCode = "07" Then
                If p.TaxHeadId.Equals(6) Then

                ElseIf p.TaxHeadId.Equals(7) Then

                ElseIf p.TaxHeadId.Equals(5) Then
                    CType(rep.FindControl("textIGSTAmount"), TextBox).Text = "0"
                    CType(rep.FindControl("hdnIGSTTaxPerc"), HiddenField).Value = "0"

                    CType(rep.FindControl("textCGSTAmount"), TextBox).Text = CType((txtTaxamount * p.TaxPercentage / 2.0), String)
                    CType(rep.FindControl("hdnCGSTTaxPerc"), HiddenField).Value = CType(p.TaxPercentage / 2.0, String)

                    CType(rep.FindControl("textSGSTAmount"), TextBox).Text = CType((txtTaxamount * p.TaxPercentage / 2.0), String)
                    CType(rep.FindControl("hdnSGSTTaxPerc"), HiddenField).Value = CType(p.TaxPercentage / 2.0, String)
                End If
            Else
                If p.TaxHeadId.Equals(5) Then
                    CType(rep.FindControl("textIGSTAmount"), TextBox).Text = CType((txtTaxamount * p.TaxPercentage), String)
                    CType(rep.FindControl("hdnIGSTTaxPerc"), HiddenField).Value = CType(p.TaxPercentage, String)
                ElseIf p.TaxHeadId.Equals(6) Then
                    CType(rep.FindControl("textSGSTAmount"), TextBox).Text = "0"
                    CType(rep.FindControl("hdnSGSTTaxPerc"), HiddenField).Value = "0"
                ElseIf p.TaxHeadId.Equals(7) Then
                    CType(rep.FindControl("textCGSTAmount"), TextBox).Text = "0"
                    CType(rep.FindControl("hdnCGSTTaxPerc"), HiddenField).Value = "0"
                End If
            End If
        End If
    End Sub

    Sub checkQnty(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

            If LstBiitoPartyNamne.SelectedValue = "0" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Bill Party.")
                Functions.ControlFocus(LstBiitoPartyNamne)
                Return
            End If

            Dim txtRate As Double = 0
            Dim txtQnty As TextBox = sender
            Dim txtExRate As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim rep = CType(CType(sender, Control).NamingContainer, RepeaterItem)
            If txtQnty.Text <> "" Then
                CType(rep.FindControl("hdnCont"), HiddenField).Value = 1
                txtRateI = Double.Parse(CType(rep.FindControl("textRate"), TextBox).Text)
                'txtQnty = txtQnty.Text
                CType(rep.FindControl("textAmount"), TextBox).Text = txtRateI * txtQnty.Text * txtExRate
                Dim pServiceMaster As New ServiceMaster
                pServiceMaster.TerminalId = Session.Item("LoginTerminal")
                pServiceMaster.ServiceId = CType(rep.FindControl("lstService"), DropDownList).SelectedValue
                ServiceMaster.ReturnServiceMasterByServiceId(pServiceMaster)
                hdnTaxOnPercentage.Value = pServiceMaster.TaxOnPercentage

                txtTaxable = txtRateI * txtExRate * txtQnty.Text / 100 * pServiceMaster.TaxOnPercentage
                Dim pTaxGroup As New TaxGroupHeads
                pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                pTaxGroup.TaxGroupId = pServiceMaster.TaxGroupId
                txtTaxamount = txtTaxable / 100

                Dim PBillTo As New CustomerMaster
                PBillTo.TerminalId = Session.Item("LoginTerminal")
                PBillTo.CustomerId = LstBiitoPartyNamne.SelectedValue
                CustomerMaster.ReturnCustomerMaster(PBillTo)

                CType(rep.FindControl("textCGSTAmount"), TextBox).Text = "0"
                CType(rep.FindControl("textSGSTAmount"), TextBox).Text = "0"
                CType(rep.FindControl("textIGSTAmount"), TextBox).Text = "0"
                For Each p As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                    SetTaxByState(rep, PBillTo, p, txtTaxamount)
                Next
                Try
                    CType(rep.FindControl("textTaxAmount"), TextBox).Text = CType((Double.Parse(CType(rep.FindControl("textIGSTAmount"), TextBox).Text) +
                                                                                   Double.Parse(CType(rep.FindControl("textSGSTAmount"), TextBox).Text) +
                                                                                   Double.Parse(CType(rep.FindControl("textCGSTAmount"), TextBox).Text)), String)

                Catch ex As Exception

                End Try
                If CType(rep.FindControl("textTaxAmount"), TextBox).Text <> Nothing Then
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = CType((Double.Parse(CType(rep.FindControl("textTaxAmount"), TextBox).Text) +
                                                                                     Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text)), String)
                Else
                    CType(rep.FindControl("textTotalAmount"), TextBox).Text = CType(Double.Parse(CType(rep.FindControl("textAmount"), TextBox).Text), String)

                End If

                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
                hdnTaxId.Value = CType(pServiceMaster.TaxGroupId, String)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
        'CType(e.Item.FindControl("lstService"), DropDownList).Enabled = True
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            'If CType(e.Item.FindControl("textContNo"), TextBox).Text <> Nothing Then
            Dim ITEMID As Long = 0
            Try
                ITEMID = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
            Catch ex As Exception

            End Try
            Dim pService As New ServiceMaster
            pService.TerminalId = Session.Item("LoginTerminal")
            pService.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
            ServiceMaster.ReturnServiceMasterByServiceId(pService)
            hdnTaxId.Value = pService.TaxGroupId
            'hdnServiceId.Value = pService.ServiceId
            'hdnTaxId.Value = lSTtAX.SelectedValue
            CType(e.Item.FindControl("lstService"), DropDownList).SelectedValue = pService.ServiceId
            'End If
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If hdnInvoiceNo.Value <> "" AndAlso hdnInvoiceNo.Value <> Nothing Then
            Response.Redirect("Preview/ExportInvoicePrint1.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
        End If
    End Sub
    Protected Sub prepareDataRepControlsList()
        Dim p As New ExtServiceMaster
        p.TerminalId = Session.Item("LoginTerminal")
        pExtServiceMaster.ServiceList = ExtServiceMaster.ReturnServiceMasterList(p)
    End Sub

    Protected Sub BtnInvoiceTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInvoiceTo.Click
        'ListControldatabind()
        manageUserControls(True)
        manageRepControl(True)
        ListControldatabind1()
        AddBookingNo()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE = '" & lstInvoiceTo.SelectedValue & "' ORDER BY CUSTOMER_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            LstBiitoPartyNamne.DataSource = ds.Tables(0)
            LstBiitoPartyNamne.DataTextField = "CUSTOMER_NAME"
            LstBiitoPartyNamne.DataValueField = "CUSTOMER_ID"
            LstBiitoPartyNamne.DataBind()
            LstBiitoPartyNamne.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Dispose()
            con.Close()
        Catch ex As Exception

        End Try
        LstBiitoPartyNamne.Visible = True
        LstBiitoPartyNamne.Enabled = True
        btnSave.Visible = False
    End Sub
    Sub AddBookingNo()

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'If textBookingNo.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Booking No")
        '    Functions.ControlFocus(textBookingNo)
        '    Return
        'End If
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = lstInvoiceTo.Text
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        'If pFleetContJo.ContJoId = Nothing Then
        'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Booking No")
        'Functions.ControlFocus(lstInvoiceTo)
        'Return
        'End If
        hdnLineId.Value = pFleetContJo.LineId
        hdnBookingId.Value = pFleetContJo.ContJoId
        Dim pFleetContJo1 As New ImpInvoiceItems
        pFleetContJo1.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo1.LineItemId = pFleetContJo.ContJoId
        'pFleetContJo1.LineItemId = 1

        '  fillRepeator(ImpInvoiceItems.ReturnExpContainersListMiscInv(pFleetContJo1))
        Dim array As ArrayList = ImpInvoiceItems.ReturnExpContainersListMiscInv(pFleetContJo1)
        Dim arraylist10 As New ArrayList
        If array.Count > 0 Then
            For Each rc As ImpInvoiceItems In array
                For i As Integer = 0 To 9
                    arraylist10.Add(rc)
                Next
            Next
        Else
            arraylist10 = New ArrayList
        End If
        fillRepeator(arraylist10)
        ' fillRepeator(FleetContJoDtls.ReturnExpContainersListMiscInv(pImpContainers))
        manageRepControl(True)
        manageControl(True)
        BtnInvoiceTo.Visible = False
        'btnAddBooking.Visible = False
        'textBookingNo.Enabled = False

        ButtonControlSetup(False)
        'BtnInvoiceTo.Visible = True
        'BtnInvoiceTo.Enabled = True
        Functions.ControlFocus(LstBiitoPartyNamne)
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '  Response.Redirect("~/Commercial/CreditNote.aspx?CrNo=" & lnk.Text)
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.InvoiceNo = hdnInvoiceNo.Value
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
        If Session.Item("CompanyId") = 2 Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SSRInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value & "&Type=Print" & "&BillTo=" & 0 & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pImpInvoice.ServiceType = "I" Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/ImportInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value & "&Type=Print" & "&BillTo=" & 0 & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value & "&Type=Print" & "&BillTo=" & 0 & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        End If
    End Sub
    ''' <summary>
    ''' Added 13/12/2022 To Calculate Amounts
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            Dim lstServiceN As DropDownList = CType(rep.FindControl("lstService"), DropDownList)
            Dim chkSelectN As CheckBox = CType(rep.FindControl("chkSelectRow"), CheckBox)
            If lstServiceN.SelectedValue <> 0 AndAlso CType(rep.FindControl("chkSelectRow"), CheckBox).Checked = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select a check Box or Select Service")
                Functions.ControlFocus(chkSelectN)
                Return
            Else
                Dim lstService As DropDownList = CType(rep.FindControl("lstService"), DropDownList)
                Dim textQuntity As TextBox = CType(rep.FindControl("textQuntity"), TextBox)
                Dim textExRate As TextBox = CType(rep.FindControl("textExRate"), TextBox)
                Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
                Dim chkSelect As CheckBox = CType(rep.FindControl("chkSelectRow"), CheckBox)

                If chkSelect.Checked = True Then
                    For Each p In arrListService
                        If lstService.SelectedItem.Value = p Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lstService.SelectedItem.Text & " Service already selected!!")
                            Functions.ControlFocus(lstService)
                            Return
                        End If
                    Next
                    arrListService.Add(lstService.SelectedItem.Value)
                    checkContNo(textRate, e)
                    pAmountTotal += CType(rep.FindControl("textAmount"), TextBox).Text
                    pIGSTAmountTotal += CType(rep.FindControl("textIGSTAmount"), TextBox).Text
                    pSGSTAmountTotal += CType(rep.FindControl("textSGSTAmount"), TextBox).Text
                    pCGSTAmountTotal += CType(rep.FindControl("textCGSTAmount"), TextBox).Text
                    pTaxAmountTotal += CType(rep.FindControl("textTaxAmount"), TextBox).Text
                    pTotalAmount += CType(rep.FindControl("textTotalAmount"), TextBox).Text
                    CType(rep.FindControl("chkSelectRow"), CheckBox).Checked = True
                    'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "SelectAmount();", True)
                End If
            End If

        Next
        textAmountTotal.Text = pAmountTotal
        TxtIGST.Text = pIGSTAmountTotal
        textSGST.Text = pSGSTAmountTotal
        TextCGST.Text = pCGSTAmountTotal
        TextTaxTotalAmount.Text = pTaxAmountTotal
        textrepTotalAmount.Text = pTotalAmount
        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
End Class