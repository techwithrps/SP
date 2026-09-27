Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection
Imports System.IO
Imports System.Xml
Partial Class Commercial_ClearencePur
    Inherits System.Web.UI.Page
    Dim rows As Integer = 25
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Public glServiceMaster As New ArrayList
    Public c As Char

    Dim TotalRate As Double = 0
    Dim TotalCgst As Double = 0
    Dim TotalSgst As Double = 0
    Dim totalIgst As Double = 0
    Dim totalTax As Double = 0
    Dim TotalAmount As Double = 0
    Dim totalTds As Double = 0
    Protected Sub ddchkContainer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        hdnServiceType.Value = 0
        For Each item As System.Web.UI.WebControls.ListItem In ddchkContainer.Items
            If item.Selected = True Then
                hdnServiceType.Value &= ","
                hdnServiceType.Value &= item.Value
            End If
        Next
        hdnServiceType.Value = hdnServiceType.Value
    End Sub
    Sub ListControlDataBind1()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT DISTINCT SERVICE_ID,UPPER(SERVICE_NAME) SERVICE_NAME FROM SERVICE_MASTER ORDER BY SERVICE_NAME "
            'cmd2 = "SELECT VM.VENDOR_ID,VENDOR_NAME FROM VENDOR_MASTER VM,VENDOR_TYPE_DETAILS VD WHERE VD.VENDOR_ID=VM.VENDOR_ID AND VD.VENDER_TYPE_CODE='P' "
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            ddchkContainer.DataSource = ds.Tables(0)
            ddchkContainer.DataTextField = "SERVICE_NAME"
            ddchkContainer.DataValueField = "SERVICE_ID"
            ddchkContainer.DataBind()
            ds.Clear()
            ddchkContainer.Enabled = True
            con.Close()
        Catch ex As Exception
        End Try

     
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        prepareDataRepControlsList()

        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = "Cost Booking"
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            fillRepeator(New ArrayList)
            ButtonControlSetup(False)
            manageUserControls(False)
            Dim StrInvoiceRefNo As String = ""
            StrInvoiceRefNo = Request.QueryString("CostId")
            'search(StrInvoiceRefNo)
            ListControlDataBindNew()
            LstBillingParty.Enabled = False
            lblShippingLine.Visible = False
            lstVendorList.Visible = False
            btnSearchInvoice.Visible = False
            'BindData()
            ddchkContainer.Enabled = True
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "")
        End If
    End Sub
    Private Sub BindData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Purchase Type")
            Functions.ControlFocus(lstPurchaseType)
            Return
        End If
        If LstBillingParty.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Company")
            Functions.ControlFocus(LstBillingParty)
            Return
        End If
        If lstVendorList.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Customer")
            Functions.ControlFocus(lstVendorList)
            Return
        End If

        If TextInvNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Purchase Invoice No")
            Functions.ControlFocus(TextInvNo)
            Return
        End If
        'strpParms &= 0
        'strpParms &= "," & 0 & ",'','','P',0,0"
        strpParms = "'" & TxtFromDate.Text.Trim & "','" & txtToDate.Text.Trim & "'," & lstLine.SelectedValue & "," & LstCFS.SelectedValue & "," & LstPol.SelectedValue
        strpParms &= "," & LstPod.SelectedValue
        strpParms &= "," & lstCHA.SelectedValue
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CLEARANCE_PURCHASE", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        'If dbr.HasRows Then
        '    tbCont.Visible = True
        'Else
        '    tblReport.Visible = False
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        'End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New CostBookingDtls
                arr.Add(p)
            Next
        End If
        rcInvoiceDetails.DataSource = arr
        rcInvoiceDetails.DataBind()
        textRepAmount.Text = Math.Round(TotalRate, 2)
        textRepCGSTAmount.Text = Math.Round(TotalCgst, 2)
        textRepSGSTAmount.Text = Math.Round(TotalSgst, 2)
        textRepIGSTAmount.Text = Math.Round(totalIgst, 2)
        textRepTaxAmount.Text = Math.Round(totalTax, 2)
        textRepTotalAmount.Text = Math.Round(TotalAmount, 2)
        textRepTotalTds.Text = Math.Round(totalTds, 2)
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Protected Sub prepareDataRepControlsList()
        Dim p As New ServiceMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glServiceMaster = ServiceMaster.ReturnServiceMasterList(p)
    End Sub

    Protected Sub prepareServiceMaster(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each th As ServiceMaster In glServiceMaster
                lst.Items.Add(New ListItem(th.ServiceName, th.ServiceId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        fillRepeator(New ArrayList)
        ButtonControlSetup(False)
        manageUserControls(False)
        btnPriview.Visible = False
        BtnGenerate.Visible = True
        'tvTreeView.Enabled = False
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        'tvTreeView.Enabled = False
        manageControls(False)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'If Not tvTreeView.SelectedNode Is Nothing Then
        '    prepareControls(tvTreeView.SelectedNode)
        'End If
        manageUserControls(True)
        'tvTreeView.Enabled = True
        ButtonControlSetup(True)
        btnSearch.Visible = True
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If LstBillingParty.SelectedValue <> Session.Item("CompanyId") Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Bill To is not maching with login company")
            rtnBool = False
            Functions.ControlFocus(LstBillingParty)
            Return rtnBool
            Exit Function
        End If
        If lstVendorList.SelectedValue = "0" And lstPurchaseType.SelectedValue <> "L" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblShippingLine.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstVendorList)
            Return rtnBool
            Exit Function
        End If
        If TextInvNo.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, LblLineInvoiceNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(TextInvNo)
            Return rtnBool
            Exit Function
        End If
        If textToDate0.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblInvoiceDate.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textToDate0)
            Return rtnBool
            Exit Function
        End If
        If lstPurchaseType.SelectedValue <> "M" Then
            If txtGSTIN.Text = "" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblGSTINNo.Text & "is Blank.")
                rtnBool = False
                Functions.ControlFocus(txtGSTIN)
                Return rtnBool
                Exit Function
            End If
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        If HdnStatus.Value <> "U" Then
            HdnStatus.Value = "U"
            If lstPurchaseType.SelectedValue = "0" Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Purchase Type")
                Return
            End If
            If lstVendorList.SelectedValue = 0 And lstPurchaseType.SelectedValue <> "L" Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Vendor")
                Return
            End If

            If lstState.SelectedValue = "0" And lstPurchaseType.SelectedValue = "L" Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select State")
                Return
            End If
            If TextInvNo.Text.Trim = "" Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Liner Invoice No")
                Return
            End If
            If textToDate0.Text.Trim = "" Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Liner Invoice Date")
                Return
            End If
            Dim pCostBooking As CostBooking = ReturnObject()
            If pCostBooking.ListCostBooking.Count <= 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " Please enter the cost for booking.")
                rcInvoiceDetails.Items(0).Focus()
                Exit Sub
            End If

            If pCostBooking.CostID > 0 Then
                CostBooking.UpdateCostBookingDtls(pCostBooking)
            Else
                CostBooking.InsertCostWithDetailsTemp(pCostBooking)
            End If
            Try
                hdnCostId.Value = pCostBooking.CostID
            Catch ex As Exception
                hdnCostId.Value = 0
            End Try
            If pCostBooking.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCostBooking.Errormsg)
                Return
            End If
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Already Updated")
        End If
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnSearch.Visible = True
        btnDelete.Visible = True
    End Sub

    Private Function ReturnObject() As CostBooking
        Dim p As New CostBooking
        p.ListCostBooking = New ArrayList
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            If CType(rep.FindControl("textService"), DropDownList).SelectedValue <> "0" Then
                Dim pdet As New CostBooking
                Try
                    pdet.CostID = hdnCostId.Value
                Catch ex As Exception
                    pdet.CostID = 0
                End Try
                pdet.PurchaseType = lstPurchaseType.SelectedValue
                pdet.LinerInvoiceNo = TextInvNo.Text.Trim
                pdet.LinerInvoiceDate = textToDate0.Text
                If lstPurchaseType.SelectedValue = "M" Then
                    pdet.BLNO = CType(rep.FindControl("HdnBlNo"), HiddenField).Value
                Else
                    pdet.BLNO = CType(rep.FindControl("HdnBlNo"), HiddenField).Value
                End If
                Try
                    pdet.KeyId = CType(rep.FindControl("HdnKeyId"), HiddenField).Value
                Catch ex As Exception
                    pdet.KeyId = 0
                End Try
                If lstPurchaseType.SelectedValue = "L" Then
                    pdet.BillingParty = lstVendorList.SelectedValue
                Else
                    pdet.BillingParty = lstVendorList.SelectedValue
                End If
                Try
                    pdet.CompanyId = LstBillingParty.SelectedValue
                Catch ex As Exception
                End Try
                pdet.DueDate = textDueDate.Text.Trim
                pdet.CreatedBy = Session.Item("LoginUser")
                p.ListCostBooking.Add(pdet)
            End If
        Next
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ServiceMasterCost
        p.TerminalId = Session.Item("LoginTerminal")
        p.ServiceId = pCodevalue.Value
        ServiceMasterCost.ReturnServiceMasterByServiceId(p)
        hdnTaxGroupID.Value = p.TaxGroupId
    End Sub
    Sub ListControlDataBindNew()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New CustomerMaster
            lstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
            lstLine.DataTextField = "CustomerName"
            lstLine.DataValueField = "CustomerId"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            lstLine.SelectedValue = 0

            Dim pPortMaster As New PortMaster
            pPortMaster.TerminalId = Session.Item("LoginTerminal")
            LstPol.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            LstPol.DataTextField = "PortCode"
            LstPol.DataValueField = "PortId"
            LstPol.DataBind()
            LstPol.Items.Insert(0, (New ListItem("ALL", 0)))
            LstPol.SelectedValue = 0
            Dim pPortMaster1 As New PortMaster
            LstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster1)
            LstPod.DataTextField = "PortCode"
            LstPod.DataValueField = "PortId"
            LstPod.DataBind()
            LstPod.Items.Add(New ListItem("----Select----", "0"))
            LstPod.SelectedValue = 0
            Dim pTerminalMaster1 As New TerminalMaster
            LstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster1)
            LstCFS.DataTextField = "TerminalCode"
            LstCFS.DataValueField = "TerminalId"
            LstCFS.DataBind()
            LstCFS.Items.Add(New ListItem("----Select----", "0"))
            LstCFS.SelectedValue = 0
        Catch ex As Exception
        End Try

        Try
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.CustomerType = "C"
            lstCHA.DataSource = CustomerMaster.ReturnCustomerMasterCostList(pCustomerMaster)
            lstCHA.DataTextField = "CUSTOMERNAME"
            lstCHA.DataValueField = "CUSTOMERID"
            lstCHA.DataBind()
            lstCHA.Enabled = True
            lstCHA.Items.Add(New ListItem("----Select----", "0"))
            lstCHA.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            If lstPurchaseType.SelectedValue = "L" Or lstPurchaseType.SelectedValue = "C" Then
                Dim pTerminalMaster As New CustomerMaster
                lstVendorList.DataSource = CustomerMaster.ReturnCustomerMasterTypeDtls(pTerminalMaster)
                lstVendorList.DataTextField = "CustomerName"
                lstVendorList.DataValueField = "CustomerId"
                lstVendorList.DataBind()
                lstVendorList.Items.Insert(0, (New ListItem("---All---", 0)))
                lstVendorList.SelectedValue = 0
            Else
                Dim pVendorMaster As New VendorMaster
                lstVendorList.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
                lstVendorList.DataTextField = "VendorName"
                lstVendorList.DataValueField = "VendorId"
                lstVendorList.DataBind()
                lstVendorList.Items.Insert(0, (New ListItem("---All---", 0)))
                lstVendorList.SelectedValue = 0
            End If
            Dim pCompanyMaster As New CompanyMaster
            LstBillingParty.DataSource = CompanyMaster.ReturnCompanyMasterList(pCompanyMaster)
            LstBillingParty.DataTextField = "CompanyName"
            LstBillingParty.DataValueField = "CompanyId"
            LstBillingParty.DataBind()
            LstBillingParty.Items.Insert(0, (New ListItem("DIRECT", 0)))
            LstBillingParty.SelectedValue = Session.Item("CompanyId")
            Dim pStateCodeMaster As New StateCodeMaster
            lstState.DataSource = StateCodeMaster.ReturnStateList(pStateCodeMaster)
            lstState.DataTextField = "StateName"
            lstState.DataValueField = "StateCode"
            lstState.DataBind()
            lstState.Items.Add(New ListItem("----Select----", "0"))
            lstState.SelectedValue = "0"
        Catch ex As Exception
        End Try
    End Sub
    Sub checkper(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtPerc As TextBox = sender
            Dim txtExRate As Double = 0
            Dim txtQnty As Double = 0
            Dim txtBaseAmount As Double = 0
            Dim txtRate As Double = 0
            Dim txtRateI As Double = 0
            Dim index1 As Integer = Integer.Parse(txtPerc.ClientID.Substring("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length, txtPerc.ClientID.IndexOf("_textPerc") - "ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = rcInvoiceDetails.Items(index1 - 1)
            If txtPerc.Text <> "" Then
                'CType(rep.FindControl("hdnServiceId"), HiddenField).Value = 1
                txtRateI = Double.Parse(CType(rep.FindControl("textQnty"), TextBox).Text)
                txtExRate = Double.Parse(CType(rep.FindControl("textExRate"), TextBox).Text)
                Try
                    txtRate = Double.Parse(CType(rep.FindControl("textRate"), TextBox).Text)
                Catch ex As Exception
                    txtRate = 0
                End Try

                CType(rep.FindControl("textRate"), TextBox).Text = txtRateI * txtRate
                txtBaseAmount = txtRateI * txtRate * txtExRate
                CType(rep.FindControl("textBaseAmount"), TextBox).Text = txtRateI * txtRate * txtExRate
                CType(rep.FindControl("TextBox5"), TextBox).Text = txtRateI * txtRate * txtExRate / 100 * 18
                CType(rep.FindControl("textBaseAmount"), TextBox).Enabled = False
                CType(rep.FindControl("TextBox6"), TextBox).Enabled = False
                CType(rep.FindControl("TextBox5"), TextBox).Enabled = False
                CType(rep.FindControl("TextBox6"), TextBox).Text = Double.Parse(CType(rep.FindControl("textBaseAmount"), TextBox).Text) + Double.Parse(CType(rep.FindControl("TextBox5"), TextBox).Text)

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        ListControlDataBind()
        lblShippingLine.Visible = True
        lstVendorList.Visible = True
        lstPurchaseType.Enabled = False
    End Sub

    'Protected Sub lstShippingLine_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstShippingLine.SelectedIndexChanged
    '    If lstPurchaseType.SelectedValue = "L" Then
    '        Dim pCustomerMaster As New CustomerMaster
    '        pCustomerMaster.CustomerId = lstShippingLine.SelectedValue
    '        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
    '        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
    '        Try
    '            lstState.SelectedValue = pCustomerMaster.StateCode
    '            txtGSTIN.Text = pCustomerMaster.GSTN
    '        Catch ex As Exception

    '        End Try
    '        lstState.Enabled = False
    '        txtGSTIN.Enabled = False
    '    End If
    'End Sub

    Protected Sub lstVendorList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstVendorList.SelectedIndexChanged
        If (lstPurchaseType.SelectedValue <> "L" And lstPurchaseType.SelectedValue <> "C") Then
            Dim pVendorMaster As New VendorMaster
            pVendorMaster.VendorId = lstVendorList.SelectedValue
            pVendorMaster.TerminalId = Session.Item("LoginTerminal")
            VendorMaster.ReturnVendorMaster(pVendorMaster)
            Try
                lstState.SelectedValue = pVendorMaster.State
                txtGSTIN.Text = pVendorMaster.GSTIN
            Catch ex As Exception

            End Try
            lstState.Enabled = False
            txtGSTIN.Enabled = False
        Else
            Dim P As New CustomerMaster
            P.CustomerId = lstVendorList.SelectedValue
            P.TerminalId = Session.Item("LoginTerminal")
            CustomerMaster.ReturnCustomerMaster(P)
            Try
                lstState.SelectedValue = P.StateCode
                txtGSTIN.Text = P.GSTN
            Catch ex As Exception

            End Try
            lstState.Enabled = False
            txtGSTIN.Enabled = False
        End If
        ListControlDataBind1()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnSearchInvoice.Visible = True
        TextInvNo.Enabled = True
        btnSearchInvoice.Visible = True
        btnSave.Visible = False
        btnAdd.Visible = True
        btnCancel.Visible = True
    End Sub

    Protected Sub btnSearchInvoice_Click(sender As Object, e As System.EventArgs) Handles btnSearchInvoice.Click
        Dim p As New CostBooking
        p.LinerInvoiceNo = TextInvNo.Text.Trim

        CostBooking.ReturnPurchaseByInvoice(p)
        If p.CostID = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Liner Invoice No")
            Functions.ControlFocus(TextInvNo)
            Return
        End If
        lstPurchaseType.SelectedValue = p.PurchaseType

        ListControlDataBind()
        LstBillingParty.SelectedValue = p.CompanyId
        lstVendorList.SelectedValue = p.BillingParty
        If lstPurchaseType.SelectedValue = "L" Then
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.CustomerId = lstVendorList.SelectedValue
            pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
            Try
                lstState.SelectedValue = pCustomerMaster.StateCode
                txtGSTIN.Text = pCustomerMaster.GSTN
            Catch ex As Exception
            End Try
            lstVendorList.Visible = True

        Else
            Dim pVendorMaster As New VendorMaster
            pVendorMaster.VendorId = lstVendorList.SelectedValue
            pVendorMaster.TerminalId = Session.Item("LoginTerminal")
            VendorMaster.ReturnVendorMaster(pVendorMaster)
            Try
                lstState.SelectedValue = pVendorMaster.State
                txtGSTIN.Text = pVendorMaster.GSTIN
            Catch ex As Exception
            End Try
            lstVendorList.Visible = True

        End If
        TextInvNo.Text = p.LinerInvoiceNo
        textToDate0.Text = p.LinerInvoiceDate
        textDueDate.Text = p.DueDate
        'Dim pCostDtls As New CostBookingDtls
        'pCostDtls.CostID = p.CostID
        hdnCostId.Value = p.CostID
        'pCostDtls.CostBookingList = CostBookingDtls.ReturnCostBookingDtlsByCostId(pCostDtls)
        'fillRepeator(pCostDtls.CostBookingList)

        Dim pTempCostBookingDtls As New TempCostBookingDtls
        pTempCostBookingDtls.CreatedBy = p.LinerInvoiceNo
        fillRepeator(TempCostBookingDtls.ReturnMaincostDtlsListByInvoiceNo(pTempCostBookingDtls))

        btnSearchInvoice.Visible = False
        btnSearch.Visible = True
        btnSave.Visible = False
        btnEdit.Visible = False
        btnAdd.Visible = True
        manageUserControls(True)
        btnDelete.Visible = True
        BtnGenerate.Visible = False
        btnPriview.Visible = False
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        Dim confirmValue As String = Request.Form("confirm_value")
        If confirmValue = "Yes" Then
            If hdnCostId.Value <> "0" Then
                Dim pCostBooking As New CostBooking
                pCostBooking.CostID = hdnCostId.Value
                CostBooking.DeletePurchaseEntryByCostId(pCostBooking)
                btnDelete.Visible = False
                btnSearch.Visible = True
                btnAdd.Visible = True
   lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Invoice have Successfully Deleted.")
          
            End If
        Else
            Return
        End If
    End Sub
    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                Dim pAllPartyAccount As New AllPartyAccount
                pAllPartyAccount.MtyContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
                CType(e.Item.FindControl("HdnBlNo"), HiddenField).Value = pAllPartyAccount.BlNo
                CType(e.Item.FindControl("txtBlNo"), TextBox).Text = pAllPartyAccount.BlNo
            End If
            Try
                TotalRate += Double.Parse(CType(e.Item.FindControl("textAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                TotalCgst += Double.Parse(CType(e.Item.FindControl("textCGSTAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                TotalSgst += Double.Parse(CType(e.Item.FindControl("textSGSTAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                totalIgst += Double.Parse(CType(e.Item.FindControl("textIGSTAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                totalTax += Double.Parse(CType(e.Item.FindControl("textTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                TotalAmount += Double.Parse(CType(e.Item.FindControl("textTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                totalTds += Double.Parse(CType(e.Item.FindControl("textTDSAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Protected Sub BtnGenerate_Click(sender As Object, e As System.EventArgs) Handles BtnGenerate.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If LstBillingParty.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Invoice To")
            Functions.ControlFocus(LstBillingParty)
            Return
        End If
        Dim pExtCostBooking As ExtCostBooking = returnExtTempImpInvoice()
        ExtCostBooking.GenerateCostInvoice(pExtCostBooking)
        If pExtCostBooking.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtCostBooking.Errormsg)
            Functions.ControlFocus(BtnGenerate)
            Return
        End If

        If pExtCostBooking.CostId <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Cost not generated.")
            Functions.ControlFocus(BtnGenerate)
            Return
        End If
        hdnCostId.Value = pExtCostBooking.CostId
        Dim p As New TempCostBookingDtls
        p.CostId = pExtCostBooking.CostId
        fillRepeator(TempCostBookingDtls.ReturnTempcostDtlsListBuInvoiceNo(p))
        BtnGenerate.Visible = False
        btnPriview.Visible = True
        ButtonControlSetup(False)
        manageUserControls(True)
        Functions.ControlFocus(txtRemak)
        TextInvNo.Enabled = True
        textToDate0.Enabled = True
        textDueDate.Enabled = True
        chkSelect.Enabled = True
    End Sub
    Function returnExtTempImpInvoice() As ExtCostBooking
        Dim pExtCostBooking As New ExtCostBooking
        Dim MtyContId As String = "0"
        Dim i As Int32 = 0
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim HdnMtyContId As HiddenField = TryCast(row.Cells(0).FindControl("HdnMtyContId"), HiddenField)
                    MtyContId &= "," + HdnMtyContId.Value
                End If
            End If
        Next
        pExtCostBooking.BlNo = MtyContId
        pExtCostBooking.BillingParty = lstVendorList.SelectedValue
        Try
            pExtCostBooking.ExRate = TextTotalCont.Text.Trim
        Catch ex As Exception
            pExtCostBooking.ExRate = 1
        End Try
        pExtCostBooking.CreatedBy = hdnServiceType.Value
        pExtCostBooking.CompanyId = Session.Item("CompanyId")
  Try
            If TextTdsPer.Text.Trim = Nothing Or TextTdsPer.Text.Trim = 0 Then
                TextTdsPer.Text = 0
            End If
        Catch ex As Exception
            TextTdsPer.Text = 0
        End Try
        Try
            If TextTdsPer.Text.Trim = Nothing Or TextTdsPer.Text.Trim = 0 Then
                If lstPurchaseType.SelectedValue = "L" Then
                    Dim pCustomerMaster As New CustomerMaster
                    pCustomerMaster.CustomerId = lstVendorList.SelectedValue
                    CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                    If pCustomerMaster.TDS = "Y" Then
                        pExtCostBooking.TdsPer = pCustomerMaster.Exemption
                    Else
                        pExtCostBooking.TdsPer = 0
                    End If
                End If
            Else
                pExtCostBooking.TdsPer = TextTdsPer.Text.Trim
            End If
        Catch ex As Exception
            pExtCostBooking.TdsPer = 0
        End Try
        Return pExtCostBooking
    End Function
    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", 0))
            For Each ic As ServiceMaster In glServiceMaster
                lst.Items.Add(New ListItem(ic.ServiceName, ic.ServiceId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BtnDisplay_Click(sender As Object, e As System.EventArgs) Handles BtnDisplay.Click
        BindData()
    End Sub

    Protected Sub TextInvNo_TextChanged(sender As Object, e As System.EventArgs) Handles TextInvNo.TextChanged
        Dim p As New CostBooking
        p.LinerInvoiceNo = TextInvNo.Text.Trim

        CostBooking.ReturnPurchaseByInvoice(p)
        If p.CostID = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Liner Invoice No")
            Functions.ControlFocus(TextInvNo)
            Return
        Else
            lstPurchaseType.SelectedValue = p.PurchaseType

            ListControlDataBind()
            LstBillingParty.SelectedValue = p.CompanyId
            lstVendorList.SelectedValue = p.BillingParty
            If lstPurchaseType.SelectedValue = "L" Then
                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.CustomerId = lstVendorList.SelectedValue
                pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                Try
                    lstState.SelectedValue = pCustomerMaster.StateCode
                    txtGSTIN.Text = pCustomerMaster.GSTN
                Catch ex As Exception
                End Try

            Else
                Dim pVendorMaster As New VendorMaster
                pVendorMaster.VendorId = lstVendorList.SelectedValue
                pVendorMaster.TerminalId = Session.Item("LoginTerminal")
                VendorMaster.ReturnVendorMaster(pVendorMaster)
                Try
                    lstState.SelectedValue = pVendorMaster.State
                    txtGSTIN.Text = pVendorMaster.GSTIN
                Catch ex As Exception
                End Try

            End If
            TextInvNo.Text = p.LinerInvoiceNo
            textToDate0.Text = p.LinerInvoiceDate
            textDueDate.Text = p.DueDate
            'Dim pCostDtls As New CostBookingDtls
            'pCostDtls.CostID = p.CostID
            'hdnCostId.Value = p.CostID
            'pCostDtls.CostBookingList = CostBookingDtls.ReturnCostBookingDtlsByCostId(pCostDtls)
            'fillRepeator(pCostDtls.CostBookingList)

            Dim pTempCostBookingDtls As New TempCostBookingDtls
            pTempCostBookingDtls.CreatedBy = p.LinerInvoiceNo
            fillRepeator(TempCostBookingDtls.ReturnMaincostDtlsListByInvoiceNo(pTempCostBookingDtls))

            btnSearchInvoice.Visible = False
            btnSearch.Visible = True
            btnSave.Visible = False
            btnEdit.Visible = False
            btnAdd.Visible = True
            manageUserControls(True)
            btnDelete.Visible = True
            BtnGenerate.Visible = False
            btnPriview.Visible = False
        End If
     
    End Sub
End Class
