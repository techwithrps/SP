Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports LogiParkLib.DBConnection

Partial Class Commercial_Default1
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
    Dim dblsbt As Double
    Dim strTerminalId As String
    Dim strInvoiceNo As String
    Dim strDocType As String
    Dim strBookingNo As String
    Dim lngBookingId As Long
    Dim pExtServiceMaster As New ExtServiceMaster

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
            '  ListControldatabind()
        End If
    End Sub

    'Sub ListControldatabind()
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
    'End Sub

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
                Dim p As New FleetContJoDtls
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
        textBookingNo.Enabled = True
        btnAddBooking.Visible = True
        btnAddBooking.Enabled = True
        '   lstDocType.Enabled = True
        Functions.ControlFocus(textBookingNo)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        btnAddBooking.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        'lstInvoiceTo.Enabled = True
        '' lstServiceType.Enabled = pEnable
        '' lstPaymentMode.Enabled = pEnable
        'textNote.Enabled = pEnable
        'LstBiitoPartyNamne.Enabled = True
        'lSTtAX.Enabled = pEnable
    End Sub

    Sub manageRepControl(ByVal pEnable As Boolean)
        ' textNote.Enabled = pEnable
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            'If CType(rep.FindControl("textContNo"), TextBox).Text <> Nothing Then
            CType(rep.FindControl("textQuntity"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textExRate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textRate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("lstService"), DropDownList).Enabled = pEnable
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

        If chkInvoiceChecked.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Invoice Check Box")
            Functions.ControlFocus(chkInvoiceChecked)
            Return rtnBool
            Exit Function
        End If


        If rcInvoiceDetails.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textContNo As TextBox
            Dim textQuntity As TextBox
            Dim textExRate As TextBox
            Dim textRate As TextBox
            Dim lstService As DropDownList
            Dim lstServiceType As DropDownList
            Dim lstCurrency As DropDownList
            Dim chkTick As CheckBox
            For Each rep1 In rcInvoiceDetails.Items
                textContNo = rep1.FindControl("textContNo")
                textQuntity = rep1.FindControl("textQuntity")
                textExRate = rep1.FindControl("textExRate")
                textRate = rep1.FindControl("textRate")
                lstService = rep1.FindControl("lstService")
                lstServiceType = rep1.FindControl("lstServiceType")
                lstCurrency = rep1.FindControl("lstCurrency")
                chkTick = rep1.FindControl("chkSelect")
                If chkTick.Checked Then
                    If textContNo.Text = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter container no")
                        rtnBool = False
                        Functions.ControlFocus(textContNo)
                        Return rtnBool
                        Exit Function
                    End If
                    If lstService.SelectedValue = "0" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Service name")
                        rtnBool = False
                        Functions.ControlFocus(lstService)
                        Return rtnBool
                        Exit Function
                    End If

                    If lstServiceType.SelectedValue = "0" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Service Type")
                        rtnBool = False
                        Functions.ControlFocus(lstServiceType)
                        Return rtnBool
                        Exit Function
                    End If



                    If textQuntity.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Qnty")
                        rtnBool = False
                        Functions.ControlFocus(textQuntity)
                        Return rtnBool
                        Exit Function
                    End If

                    If textExRate.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Ex Rate.")
                        rtnBool = False
                        Functions.ControlFocus(textExRate)
                        Return rtnBool
                        Exit Function
                    End If

                    If lstCurrency.SelectedValue = "0" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Currency Type")
                        rtnBool = False
                        Functions.ControlFocus(lstCurrency)
                        Return rtnBool
                        Exit Function
                    End If

                    If textRate.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Rate.")
                        rtnBool = False
                        Functions.ControlFocus(textRate)
                        Return rtnBool
                        Exit Function
                    End If


                    Dim textContNo1 As TextBox
                    Dim lstService1 As DropDownList
                    Dim chkTick1 As CheckBox

                    For Each rep2 In rcInvoiceDetails.Items
                        textContNo1 = rep2.FindControl("textContNo")
                        lstService1 = rep2.FindControl("lstService")
                        chkTick1 = rep2.FindControl("chkSelect")
                        If chkTick1.Checked Then
                            If rep1.ItemIndex <> rep2.ItemIndex Then
                                If textContNo.Text = textContNo1.Text AndAlso lstService.SelectedValue = lstService1.SelectedValue Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Duplicate Service selected")
                                    rtnBool = False
                                    Functions.ControlFocus(lstService1)
                                    Return rtnBool
                                    Exit Function
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End If

        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pAddServices As AddServices = returnObjectsData()
        'Try
        '    pAddServices.ServiceId = hdnService.Value
        'Catch ex As Exception
        'End Try

        If pAddServices.AddServiceList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select the Container")
            Functions.ControlFocus(btnSave)
            Return
        End If

        Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
        Try
            db.BeginTransaction()
            For Each ii As AddServices In pAddServices.AddServiceList
                AddServices.Insert(ii)
                If ii.Errormsg <> "" Then
                    Throw New Exception(ii.Errormsg)
                End If
            Next
            db.CommitTransaction()
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, ex.Message)
            Try
                db.RollbackTransaction()
            Catch ex1 As Exception
            End Try
            Return
        End Try
        tvInvoices.Enabled = True
        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub

    Function returnObjectsData() As AddServices
        Dim pExtImp As New AddServices
        Dim parray As New ArrayList
        For Each rc As RepeaterItem In rcInvoiceDetails.Items
            If CType(rc.FindControl("chkSelect"), CheckBox).Checked = True AndAlso CType(rc.FindControl("chkSelect"), CheckBox).Enabled = True AndAlso CType(rc.FindControl("hdnContId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnContId"), HiddenField).Value <> 0 Then

                Dim pExtImpInvoice As New AddServices

                pExtImpInvoice.TerminalId = Session.Item("LoginTerminal")
                pExtImpInvoice.CreatedBy = Session.Item("LoginUser")
                pExtImpInvoice.CompanyId = Session.Item("CompanyId")
                Try
                Catch ex As Exception
                End Try

                Try
                    pExtImpInvoice.ContJoId = hdnBookingId.Value
                Catch ex As Exception
                End Try
                Try
                    pExtImpInvoice.MtyContId = CType(rc.FindControl("hdnContId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pExtImpInvoice.ServiceId = CType(rc.FindControl("lstService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pExtImpInvoice.ServiceType = CType(rc.FindControl("lstServiceType"), DropDownList).SelectedValue
                Catch ex As Exception

                End Try

                Try
                    pExtImpInvoice.Qnty = CType(rc.FindControl("textQuntity"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pExtImpInvoice.Rate = CType(rc.FindControl("textRate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtImpInvoice.ExRate = CType(rc.FindControl("textExRate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pExtImpInvoice.Currency = CType(rc.FindControl("lstCurrency"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                parray.Add(pExtImpInvoice)
            End If
        Next
        pExtImp.AddServiceList = parray
        Return pExtImp
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

    Protected Sub btnAddBooking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBooking.Click
        manageUserControls(True)
        manageRepControl(True)
        AddBookingNo()
    End Sub
    Sub AddBookingNo()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textBookingNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Booking No")
            Functions.ControlFocus(textBookingNo)
            Return
        End If
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = textBookingNo.Text
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        If pFleetContJo.ContJoId = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Booking No")
            Functions.ControlFocus(textBookingNo)
            Return
        End If
        '  hdnLineId.Value = pFleetContJo.LineId
        hdnBookingId.Value = pFleetContJo.ContJoId
        Dim pFleetContJo1 As New FleetContJoDtls
        pFleetContJo1.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo1.ContJoId = pFleetContJo.ContJoId
        Dim array As ArrayList = FleetContJoDtls.ReturnFleetContJoDtlsList(pFleetContJo1)
        Dim arraylist10 As New ArrayList
        If array.Count > 0 Then
            For Each rc As FleetContJoDtls In array
                For i As Integer = 0 To 9
                    arraylist10.Add(rc)
                Next
            Next
        Else
            arraylist10 = New ArrayList
        End If

        fillRepeator(arraylist10)
        manageRepControl(True)
        manageControl(True)
        btnAddBooking.Visible = False
        textBookingNo.Enabled = False

        ButtonControlSetup(False)
        ' BtnInvoiceTo.Visible = True
        ' BtnInvoiceTo.Enabled = True
        ' Functions.ControlFocus(lstInvoiceTo)
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
        ' hdnInvoiceNo.Value = p.InvoiceNo
        hdnCancelStatus.Value = p.CancleFlage
        hdnBookingId.Value = p.LineItemId
        'hdnPrintStatus.Value = p.PrintStatus
        hdnReceiptNo.Value = p.ReceiptNo
        ' textInvoiceRefNo.Text = p.InvoiceRefNo
        ' textInvoiceDate.Text = p.InvoiceDate
        'textNote.Text = p.InvoiceNote
        '  lstServiceType.SelectedValue = p.ServiceType
        'lstInvoiceTo.SelectedValue = p.CustomerType
        '  lstPaymentMode.SelectedValue = p.PaymentMode
        fillRepeator(p.ImpInvoiceItemsList)
    End Sub
    Protected Sub prepareDataRepControlsList()
        Dim p As New ExtServiceMaster
        p.TerminalId = Session.Item("LoginTerminal")
        pExtServiceMaster.ServiceList = ExtServiceMaster.ReturnServiceMasterListNew(p)
    End Sub

    'Protected Sub BtnInvoiceTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnInvoiceTo.Click
    '    'ListControldatabind()
    '    Dim strConnectionString, cmd1 As String
    '    Dim con As OleDbConnection
    '    Dim ada As New OleDbDataAdapter
    '    Try
    '        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '        cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE = '" & lstInvoiceTo.SelectedValue & "' ORDER BY CUSTOMER_NAME"
    '        con = New OleDbConnection(strConnectionString)
    '        con.Open()
    '        ada = New OleDbDataAdapter(cmd1, con)
    '        Dim ds As New DataSet("Customer")
    '        ada.Fill(ds)
    '        LstBiitoPartyNamne.DataSource = ds.Tables(0)
    '        LstBiitoPartyNamne.DataTextField = "CUSTOMER_NAME"
    '        LstBiitoPartyNamne.DataValueField = "CUSTOMER_ID"
    '        LstBiitoPartyNamne.DataBind()
    '        LstBiitoPartyNamne.Items.Insert(0, (New ListItem("---Select---", "0")))
    '        ds.Clear()
    '        con.Dispose()
    '        con.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
