Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Partial Class Fleet_FleetContainerJo
    Inherits System.Web.UI.Page
    ' Dim rows As Integer = 5
    Dim count As Integer = 0
    Dim addrows As Integer = 2
    Dim glLine As ArrayList
    Dim glIsoCode As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareContData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            manageUserControls(True)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            ListControlDataBind()
            ButtonControlSetup(True)
            btnAdd.Visible = True
            manageUserControls(False)
            fillRepeator(New ArrayList)
            'TVJo.Enabled = True
            ButtonControlSetup(False)
            textGrNo.Enabled = False
            textGrDate.Enabled = False
            btnNewRows.Visible = True
            textCont.Text = 1
            tblCont.Visible = False
            btnNewRows.Visible = False
            btnSearch.Visible = True
            lstLocation.Enabled = False
            TxtBookingNo.Enabled = False
            textStuffDate.Enabled = False
            textCont.Enabled = False
            'lstSize.Enabled = True
            'lstType.Enabled = True
            lstPOD.Enabled = False
            lstPOL.Enabled = False
            textVesselName.Enabled = False
            textValidity.Enabled = False
            Dim StrInvoiceRefNo As String = ""
            StrInvoiceRefNo = Request.QueryString("CONT_JO_NO")
            If StrInvoiceRefNo > 0 Then
                search(StrInvoiceRefNo)
            Else

            End If
        End If
    End Sub

    Protected Sub prepareContType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("--Select--", ""))
            For Each ic As IsoCode In glIsoCode
                lst.Items.Add(New ListItem(ic.ContType, ic.ContType))
            Next
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub prepareLine(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim lst As DropDownList = sender
    '        lst.Items.Clear()
    '        lst.Items.Add(New ListItem("--Select--", 0))
    '        For Each ic As CustomerMaster In glLine
    '            lst.Items.Add(New ListItem(ic.CustomerName, ic.CustomerId))
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Sub LoadTreeViewData()
        Dim pFleet As New FleetContJo
        pFleet.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As FleetContJo In FleetContJo.ReturnFleetContJoPendingList(pFleet)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ContJoId, obj.ContJoNo)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function
    Function GetDateTime(strDate As String) As DateTime
        Dim arrdate, Day, Month, Year, FinalDate

        If strDate <> Nothing And strDate <> "" Then
            Dim parry = strDate.Trim()
            If parry.Length > 10 Then
                parry = parry.Substring(0, 10)
            End If
            arrdate = parry.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
        End If
        FinalDate = New DateTime(Year, Month, Day, 0, 0, 0)
        Return FinalDate
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    'Private Sub selectFirstNode()
    '    If tvTreeview.Nodes.Count > 0 Then
    '        tvTreeview.Nodes(0).Selected = True
    '        prepareControls(tvTreeview.Nodes(0))
    '    End If
    'End Sub
    Sub prepareContData()
        Dim pIso As New IsoCode
        glIsoCode = IsoCode.ReturnIsoCodeListOfContType(pIso)
        Dim pCustomerMaster As New CustomerMaster
        glLine = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
    End Sub
    Private Sub fillRepeator(ByVal arr As ArrayList)
        'If arr.Count < rows Then
        '    For i As Integer = 0 To rows - arr.Count - 1
        '        Dim p As New FleetContJoDtls
        '        p.LineId = 0
        '        arr.Add(p)
        '    Next
        'End If
        repBookingContDeatils.DataSource = arr
        repBookingContDeatils.DataBind()
    End Sub
    'Private Sub fillRepeator(ByVal arr2 As ArrayList)
    '    If arr2.Count <= rows Then
    '        For i As Integer = 0 To rows - (arr2.Count + 1)
    '            Dim p As New MtyFleetContJoDtls
    '            arr2.Add(p)
    '        Next
    '    End If
    '    repBookingContDeatils.DataSource = arr2
    '    repBookingContDeatils.DataBind()
    'End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'S') ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('E') ORDER BY CUSTOMER_NAME"
            cmd3 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'L' AND ELOGISOL_FLAG='Y' ORDER BY CUSTOMER_NAME"
            cmd4 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'A' ORDER BY CUSTOMER_NAME"
            cmd5 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('C') ORDER BY CUSTOMER_NAME"
            cmd6 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID <> 19 ORDER BY PORT_NAME"
            cmd7 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID=19 ORDER BY PORT_NAME"

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            lstCustomer.DataSource = ds.Tables(0)
            lstCustomer.DataTextField = "CUSTOMER_NAME"
            lstCustomer.DataValueField = "CUSTOMER_ID"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            ada = New OleDbDataAdapter(cmd2, con)
            ada.Fill(ds)
            lstConsignee.DataSource = ds.Tables(0)
            lstConsignee.DataTextField = "CUSTOMER_NAME"
            lstConsignee.DataValueField = "CUSTOMER_ID"
            lstConsignee.DataBind()
            lstConsignee.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            ada = New OleDbDataAdapter(cmd3, con)
            ada.Fill(ds)
            lstLine.DataSource = ds.Tables(0)
            lstLine.DataTextField = "CUSTOMER_NAME"
            lstLine.DataValueField = "CUSTOMER_ID"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            ada = New OleDbDataAdapter(cmd6, con)
            ada.Fill(ds)
            lstPOD.DataSource = ds.Tables(0)
            lstPOD.DataTextField = "PORT_NAME"
            lstPOD.DataValueField = "PORT_ID"
            lstPOD.DataBind()
            lstPOD.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()


            ada = New OleDbDataAdapter(cmd7, con)
            ada.Fill(ds)
            lstPOL.DataSource = ds.Tables(0)
            lstPOL.DataTextField = "PORT_NAME"
            lstPOL.DataValueField = "PORT_ID"
            lstPOL.DataBind()
            lstPOL.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            Dim pExtVendorMaster As New ExtVendorMaster
            pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
            lstTransportar.DataSource = ExtVendorMaster.ReturnVendorMasterListAllExportTransporter(pExtVendorMaster)
            lstTransportar.DataTextField = "VendorName"
            lstTransportar.DataValueField = "VendorId"
            lstTransportar.DataBind()
            lstTransportar.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstTransportar.SelectedValue = 0

            Dim pExtTerminalMaster As New TerminalMaster
            lstLocation.DataSource = TerminalMaster.ReturnTerminalMasterListUserId(Session.Item("LoginUser"))
            lstLocation.DataTextField = "TerminalName"
            lstLocation.DataValueField = "TerminalId"
            lstLocation.DataBind()
            lstLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstLocation.SelectedValue = Session.Item("LoginTerminal")

            lstToLocation.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            lstToLocation.DataTextField = "TerminalName"
            lstToLocation.DataValueField = "TerminalId"
            lstToLocation.DataBind()
            lstToLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstToLocation.SelectedValue = 0

            Dim pExtLocationMaster As New TerminalLocationMaster
            pExtLocationMaster.TerminalId = Session.Item("LoginTerminal")
            lstFromLocation.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
            lstFromLocation.DataTextField = "LocationName"
            lstFromLocation.DataValueField = "LocationId"
            lstFromLocation.DataBind()
            lstFromLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstFromLocation.SelectedValue = 0

            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try
        'Dim pIso As New IsoCode
        'lstType.DataSource = IsoCode.ReturnIsoCodeListOfContType(pIso)
        'lstType.DataValueField = "ContType"
        'lstType.DataTextField = "ContType"
        'lstType.DataBind()
        'lstType.Items.Insert(0, New ListItem("--Select--", ""))
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
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        btnAdd.Visible = False
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEditContDetail.Visible = pVisible
        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If
        If Session.Item("Edit") <> "Y" Then

        End If

        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnsearchJo.Visible = True
        textGrNo.Enabled = True
    End Sub
    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
            textGrNo.Enabled = False
        End If
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Protected Sub btnEditContDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditContDetail.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        tblCont.Visible = True
        Dim pRM As New ExtFleetContJo
        pRM.ContJoDtlsList = New ArrayList
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            Dim pfId As New FleetContJoDtls
            pfId.TerminalId = Session.Item("LoginTerminal")
            pfId.CompanyId = Session.Item("CompanyId")
            Try
                pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
            Catch ex As Exception
            End Try
            Try
                pfId.ContJoId = hdnJoId.Value
            Catch ex As Exception
            End Try

            pfId.TripType = lstDocType.SelectedValue
            pfId.JoType = "C"


            pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text


            Try
                pfId.ContSize = CType(rep.FindControl("lstSize"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.ContType = CType(rep.FindControl("lstType"), DropDownList).SelectedValue
            Catch ex As Exception

            End Try
            Try
                pfId.Weight = CType(rep.FindControl("textWeight"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.TareWt = CType(rep.FindControl("textTareWeight"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.CargoWt = CType(rep.FindControl("textCargoWeight"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.BENo = CType(rep.FindControl("textBeNo"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.BookingNo = CType(rep.FindControl("txtBookingNo"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.AllotMentDate = CType(rep.FindControl("textAllotMent"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.StuffingPOD = CType(rep.FindControl("lstPOD"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.StuffingPOL = CType(rep.FindControl("lstPOL"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.VesselName = CType(rep.FindControl("textVesselName"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Validity = CType(rep.FindControl("textValidity"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.LineId = CType(rep.FindControl("lstLine"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            'Try
            '    pfId.InvoiceFlagTPT = CType(rep.FindControl("lstInvFlagTpt"), DropDownList).SelectedValue
            'Catch ex As Exception
            'End Try
            'Try
            '    pfId.InvoiceFlagFRT = CType(rep.FindControl("lstInvFlagFrt"), DropDownList).SelectedValue
            'Catch ex As Exception
            'End Try
            'Try
            '    pfId.InvoiceFlagCLR = CType(rep.FindControl("lstInvFlagCLR"), DropDownList).SelectedValue
            'Catch ex As Exception
            'End Try
            pRM.ContJoDtlsList.Add(pfId)
        Next

        'Dim i As Integer = 0
        'Try
        '    While i < (Convert.ToDouble(textCont20.Text) + Convert.ToDouble(textCont40.Text)) - rows
        '        Dim pRD As New FleetContJoDtls
        '        pRD.LineId = 0
        '        pRM.ContJoDtlsList.Add(pRD)
        '        i += 1
        '    End While
        '    fillRepeator(pRM.ContJoDtlsList)
        'Catch ex As Exception
        'End Try
        If Not repBookingContDeatils.Items.Count.Equals(Convert.ToInt32(textCont.Text)) Then
            For index = repBookingContDeatils.Items.Count To Convert.ToDouble(textCont.Text) - 1
                Dim pRD As New FleetContJoDtls
                pRD.LineId = 0
                pRM.ContJoDtlsList.Add(pRD)
                fillRepeator(pRM.ContJoDtlsList)
            Next
        Else
            fillRepeator(pRM.ContJoDtlsList)
        End If

        btnSave.Visible = True
        btnSave.Enabled = True
        textGrNo.Enabled = False
        lstPOD.Enabled = True
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim isContNo As Integer = 0

        If lstDocType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Jo Type")
            Functions.ControlFocus(lstDocType)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstOfMode.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Mode Of Shipment")
            Functions.ControlFocus(lstOfMode)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstCustomer.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblExporterShipper.Text)
            Functions.ControlFocus(lstCustomer)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstConsignee.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblConsignee.Text)
            Functions.ControlFocus(lstConsignee)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstTransportar.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblTransporter.Text)
            Functions.ControlFocus(lstTransportar)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If textCont.Text.Trim = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblCont.Text)
            Functions.ControlFocus(textCont)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstLine.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblCha.Text)
            Functions.ControlFocus(lstLine)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstToLocation.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblToLocation.Text)
            Functions.ControlFocus(lstToLocation)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If repBookingContDeatils.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textContNo, textCont1, textAllotMent, txtTareWeight, txtWeight, textBeNo As TextBox
            Dim lstContSize, lstContType As DropDownList
            For Each rep1 In repBookingContDeatils.Items
			    txtTareWeight = rep1.FindControl("textTareWeight")
				txtWeight = rep1.FindControl("textWeight")
                textContNo = rep1.FindControl("textContNo")
                lstContSize = rep1.FindControl("lstSize")
                lstContType = rep1.FindControl("lstType")
                textBeNo = rep1.FindControl("textBeNo")
                textAllotMent = rep1.FindControl("textAllotMent")

                If textContNo.Text.Trim <> Nothing Then
                    If txtTareWeight.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Tare Wt is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(txtTareWeight)
                        Return rtnBool
                        Exit Function
                    End If
                    If Session.Item("LoginTerminal") <> 7 Then
                        If Session.Item("LoginTerminal") <> 29 Then
                            If Session.Item("LoginTerminal") <> 5 Then
                                If Session.Item("LoginTerminal") <> 53 Then
                                    If txtWeight.Text.Trim = Nothing Then
                                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Gross Wt Weight is Blank.")
                                        rtnBool = False
                                        Functions.ControlFocus(txtWeight)
                                        Return rtnBool
                                        Exit Function
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If textContNo.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Number is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textContNo)
                        Return rtnBool
                        Exit Function
                    End If

                    If textBeNo.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Set Tempature is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textBeNo)
                        Return rtnBool
                        Exit Function
                    End If

                    If String.IsNullOrEmpty(textAllotMent.Text.Trim) Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Allotment Date is blank ")
                        rtnBool = False
                        Functions.ControlFocus(textAllotMent)
                        Return rtnBool
                        Exit Function
                    End If

                    If TxtBookingNo.Text = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblBookingNo.Text)
                        Functions.ControlFocus(TxtBookingNo)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If textStuffDate.Text = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & Label2.Text)
                        Functions.ControlFocus(textStuffDate)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If Not String.IsNullOrEmpty(textAllotMent.Text) Then
                        If GetDateTime(textAllotMent.Text.Trim()) >= DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                            Functions.ControlFocus(textAllotMent)
                            rtnBool = False
                            Functions.ControlFocus(textAllotMent)
                            Return rtnBool
                            Exit Function
                        End If
                    End If
                    'If Not String.IsNullOrEmpty(textSicut.Text) Then
                    '    If GetDateTime(textSicut.Text.Trim()) <= DateTime.Now Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                    '        Functions.ControlFocus(textSicut)
                    '        rtnBool = False
                    '        Functions.ControlFocus(textSicut)
                    '        Return rtnBool
                    '        Exit Function
                    '    End If
                    'End If
                    'If Not String.IsNullOrEmpty(TextPortCut.Text) Then
                    '    If GetDateTime(TextPortCut.Text.Trim()) <= DateTime.Now Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is grater than or equal to the Current Date.")
                    '        Functions.ControlFocus(TextPortCut)
                    '        rtnBool = False
                    '        Functions.ControlFocus(TextPortCut)
                    '        Return rtnBool
                    '        Exit Function
                    '    End If
                    'End If

                    If lstContSize.SelectedValue = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container belong to another Shipping Line")
                        rtnBool = False
                        Functions.ControlFocus(lstContSize)
                        Return rtnBool
                        Exit Function
                    End If
                    If lstContSize.SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container belong to another Shipping Line")
                        rtnBool = False
                        Functions.ControlFocus(lstContSize)
                        Return rtnBool
                        Exit Function
                    End If
                    'If lstContSize.SelectedValue = "20" AndAlso txtTareWeight.Text > 3000 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Check Tare Wt")
                    '    rtnBool = False
                    '    Functions.ControlFocus(txtTareWeight)
                    '    Return rtnBool
                    '    Exit Function
                    'End If
                    'If lstContSize.SelectedValue = "40" AndAlso txtTareWeight.Text > 5001 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Check Tare Wt")
                    '    rtnBool = False
                    '    Functions.ControlFocus(txtTareWeight)
                    '    Return rtnBool
                    '    Exit Function
                    'End If
                    'If Session.Item("LoginTerminal") <> 7 Then
                    '    If Session.Item("LoginTerminal") <> 29 Then
                    '                 If lstContSize.SelectedValue = "40" AndAlso txtWeight.Text < 28000 Then
                    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Check Cargo Weight")
                    '                    rtnBool = False
                    '                    Functions.ControlFocus(txtWeight)
                    '                    Return rtnBool
                    '                    Exit Function
                    '                 End If
                    '    End If
                    'End If
                    'If Session.Item("LoginTerminal") <> 7 Then
                    '    If Session.Item("LoginTerminal") <> 29 Then

                    '                If lstContSize.SelectedValue = "40" AndAlso txtWeight.Text > 36000 Then
                    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Check Cargo Weight")
                    '                    rtnBool = False
                    '                    Functions.ControlFocus(txtWeight)
                    '                    Return rtnBool
                    '                    Exit Function
                    '                    End If
                    '    End If
                    'End If
                    If lstContType.SelectedValue = Nothing Then
                                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Container Type.")
                                        rtnBool = False
                                        Functions.ControlFocus(lstContType)
                                        Return rtnBool
                                        Exit Function
                                    End If
                                    If lstContType.SelectedValue = "" Then
                                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Container Type.")
                                        rtnBool = False
                                        Functions.ControlFocus(lstContType)
                                        Return rtnBool
                                        Exit Function
                                    End If

                                    'End If

                                    Try
                                        If GetDateTime(textAllotMent.Text) < GetDateTime(textStuffDate.Text) Then
                                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                                                    "Booking Date can not be less than Allotment Date.")
                                            Functions.ControlFocus(textAllotMent)
                                            rtnBool = False
                                            Return rtnBool
                                            Exit Function
                                        End If

                                    Catch ex As Exception

                                    End Try

                                    'If GetDateTime(textAllotMent.Text.Trim()) < GetDateTime(textValidity.Text.Trim()) Then
                                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Validity Date can not be less than booking date")
                                    '    Functions.ControlFocus(textValidity)
                                    '    rtnBool = False
                                    '    Return rtnBool
                                    '    Exit Function
                                    'End If


                                End If

                                For Each rep2 In repBookingContDeatils.Items
                    textCont1 = rep2.FindControl("textContNo")
                    If textCont1.Text <> Nothing Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            isContNo += 1
                            If textContNo.Text = textCont1.Text Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Number is duplicate.")
                                rtnBool = False
                                Functions.ControlFocus(textContNo)
                                Return rtnBool
                                Exit Function
                            End If
                        End If

                    End If
                Next
            Next
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetContJo As ExtFleetContJo = ReturnObject()

        Dim pFleet As New FleetContJoDtls
        pFleet.TerminalId = pFleetContJo.TerminalId
        pFleet.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsContNo(pFleet)
        If Session.Item("LoginUser") <> "Puneet" AndAlso Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Akshay" Then
            If pFleet.MtyContId > 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container alreday alloted, So edit not allow.")
                Return
            End If
        End If
        ExtFleetContJo.InsertUpdateFleetContJo(pFleetContJo)
        If lstTransportar.SelectedValue <> 109 Then
            If lstFromLocation.SelectedValue = "0" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblFromLocation.Text)
                Functions.ControlFocus(lstFromLocation)
                Return
            End If
        End If
        If pFleetContJo.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetContJo.Errormsg)
            Functions.ControlFocus(lstDocType)
            Return
        End If
        textGrDate.Text = pFleetContJo.CreatedOn
        textGrNo.Text = pFleetContJo.ContJoNo
        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        hdnLineId.Value = pFleetContJo.LineId
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
        btnNewRows.Visible = False
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAdd.Visible = True
        'btnAddBookingNo.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Private Function ReturnObject() As ExtFleetContJo
        Dim pGrMapping As New ExtFleetContJo
        pGrMapping.TerminalId = Session.Item("LoginTerminal")
        pGrMapping.CompanyId = Session.Item("CompanyId")
        Try
            pGrMapping.ContJoId = hdnJoId.Value
        Catch ex As Exception

        End Try
        ' pGrMapping.GrNo = textGrNo.Text
        pGrMapping.MtyPickup = lstLocation.SelectedValue
        pGrMapping.CreatedBy = Session.Item("LoginUser")
        pGrMapping.CustomerId = lstCustomer.SelectedValue
        pGrMapping.ConsigneeId = lstConsignee.SelectedValue
        pGrMapping.TransporterId = lstTransportar.SelectedValue
        Try
            pGrMapping.ToLocationId = lstToLocation.SelectedValue
        Catch ex As Exception
        End Try
        pGrMapping.FromLocation = lstFromLocation.SelectedValue
        pGrMapping.TripType = lstDocType.SelectedValue
        Try
            pGrMapping.NoOf40 = 1
        Catch ex As Exception
        End Try
        'pGrMapping.ContSize = lstSize.SelectedValue
        'pGrMapping.ContType = lstType.Sele Q1```````````````````QctedValue
        Try

            pGrMapping.ModeType = lstOfMode.SelectedValue
        Catch ex As Exception
        End Try
        pGrMapping.ContJoNo = textGrNo.Text
        pGrMapping.BookingNo = TxtBookingNo.Text
        pGrMapping.LineId = 0

        pGrMapping.JoType = "C"

        Try
            pGrMapping.StuffDate = textStuffDate.Text
        Catch ex As Exception

        End Try
        pGrMapping.LineId = lstLine.SelectedValue

        pGrMapping.ContJoDtlsList = New ArrayList
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("textContNo"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textContNo"), TextBox).Text <> "" Then
                Dim pfId As New FleetContJoDtls
                pfId.TerminalId = Session.Item("LoginTerminal")
                pfId.CompanyId = Session.Item("CompanyId")
                Try
                    pfId.UpdatedBy = Session.Item("LoginUser")
                Catch ex As Exception
                End Try
                Try
                    pfId.VesselName = textVesselName.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.Validity = textValidity.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.SicutDate = textSicut.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.PortCutOfdate = TextPortCut.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.ETDDate = TextETD.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.BookingNo = TxtBookingNo.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.BEDate = textStuffDate.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.StuffingPOD = lstPOD.SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pfId.StuffingPOL = lstPOL.SelectedValue
                Catch ex As Exception
                End Try

                Try
                    pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pfId.ContJoId = hdnJoId.Value

                Catch ex As Exception

                End Try
                Try
                    pfId.LineId = hdnLineId.Value

                Catch ex As Exception

                End Try
                pfId.TripType = lstDocType.SelectedValue

                pfId.JoType = "C"
                Try
                    pfId.BENo = CType(rep.FindControl("textBeNo"), TextBox).Text
                Catch ex As Exception
                End Try


                pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text


                Try
                    pfId.ContSize = CType(rep.FindControl("lstSize"), DropDownList).SelectedValue
                Catch ex As Exception

                End Try
                Try
                    pfId.ContType = CType(rep.FindControl("lstType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try

                Try
                    pfId.Weight = CType(rep.FindControl("textWeight"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.TareWt = CType(rep.FindControl("textTareWeight"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.CargoWt = CType(rep.FindControl("textCargoWeight"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.AllotMentDate = CType(rep.FindControl("textAllotMent"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
                Catch ex As Exception
                End Try
                'Try
                '    pfId.InvoiceFlagTPT = CType(rep.FindControl("lstInvFlagTpt"), DropDownList).SelectedValue
                'Catch ex As Exception
                'End Try
                'Try
                '    pfId.InvoiceFlagFRT = CType(rep.FindControl("lstInvFlagFrt"), DropDownList).SelectedValue
                'Catch ex As Exception
                'End Try
                'Try
                '    pfId.InvoiceFlagCLR = CType(rep.FindControl("lstInvFlagCLR"), DropDownList).SelectedValue
                'Catch ex As Exception
                'End Try
                pGrMapping.ContJoDtlsList.Add(pfId)
            End If
        Next
        'If noOfCont20.Equals(0) AndAlso noOfCont40.Equals(0) Then
        '    If lstSize.SelectedValue = "20" Then
        '        pGrMapping.NoOf20 = CType(textCont.Text.Trim, Long)
        '        pGrMapping.NoOf40 = 0
        '    ElseIf lstSize.SelectedValue = "40" Then
        '        pGrMapping.NoOf20 = 0
        '        pGrMapping.NoOf40 = CType(textCont.Text.Trim, Long)

        '    End If
        'Else
        '    pGrMapping.NoOf20 = noOfCont20
        '    pGrMapping.NoOf40 = noOfCont40
        'End If
        Return pGrMapping
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(False)
        ButtonControlSetup(False)
        textGrNo.Enabled = False
        textGrDate.Enabled = False
        Functions.ControlFocus(lstCustomer)

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDelete.Click
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then
                hdnContId.Value = CType(rep.FindControl("hdnContId"), HiddenField).Value
                Dim strConnectionString, cmd, cmd1 As String
                Dim con As OleDbConnection
                Try
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd = " UPDATE FLEET_CONT_JO_DTLS SET CANCEL_STATUS='Y' WHERE  MTY_CONT_ID= " & hdnContId.Value
                    cmd1 = "UPDATE FLEET_GR_MAPPING SET CANCEL_STATUS='Y'  WHERE MTY_CONT_ID = " & hdnContId.Value

                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd3 As New OleDbCommand(cmd, con)
                    cmd3.ExecuteNonQuery()
                    Dim cmd4 As New OleDbCommand(cmd1, con)
                    cmd4.ExecuteNonQuery()
                Catch ex As Exception
                End Try
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Cancelled Successfully.")

            End If
        Next

        btnSave.Visible = False
        btnCancel.Visible = False
        btnEdit.Visible = False
        btnExit.Visible = True
        btnDelete.Visible = False
    End Sub
    Protected Sub btnNewRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewRows.Click
        Dim pRM As New ExtFleetContJo
        pRM.ContJoDtlsList = New ArrayList

        For Each rep As RepeaterItem In repBookingContDeatils.Items

            Dim pfId As New FleetContJoDtls
            pfId.TerminalId = Session.Item("LoginTerminal")
            Try
                pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
            Catch ex As Exception
            End Try
            Try
                pfId.ContJoId = hdnJoId.Value

            Catch ex As Exception

            End Try
            pfId.TripType = lstDocType.SelectedValue
            pfId.JoType = "C"


            pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text

            pfId.ContSize = CType(rep.FindControl("lstSize"), DropDownList).SelectedValue
            pfId.ContType = CType(rep.FindControl("lstType"), DropDownList).SelectedValue
            Try
                pfId.Weight = CType(rep.FindControl("textWeight"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.BookingNo = CType(rep.FindControl("txtBookingNo"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.AgentSeal = CType(rep.FindControl("textAgentSeal"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.LineId = CType(rep.FindControl("lstLine"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.AllotMentDate = CType(rep.FindControl("textAllotMent"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.InvoiceFlagTPT = CType(rep.FindControl("lstInvFlagTpt"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.InvoiceFlagFRT = CType(rep.FindControl("lstInvFlagFrt"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.InvoiceFlagCLR = CType(rep.FindControl("lstInvFlagCLR"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            pRM.ContJoDtlsList.Add(pfId)

        Next

        Dim i As Integer = 0
        Try
            While i < Convert.ToDouble(textCont.Text)
                Dim pRD As New FleetContJoDtls
                pRD.LineId = 0
                pRM.ContJoDtlsList.Add(pRD)

                i += 0
            End While

            fillRepeator(pRM.ContJoDtlsList)

        Catch ex As Exception

        End Try

    End Sub
    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtContNo As TextBox = sender
            Dim index1 As Integer = Integer.Parse(txtContNo.ClientID.Substring("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length, txtContNo.ClientID.IndexOf("_textContNo") - "ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length))
            Dim rep As RepeaterItem
            rep = repBookingContDeatils.Items(index1 - 1)
            If txtContNo.Text <> "" Then
                Dim p As New MtyFleetContJoDtls
                p.TerminalId = Session.Item("LoginTerminal")
                p.ContNo = txtContNo.Text
                p.LineId = 0
                MtyFleetContJoDtls.ReturnMtyContainersValidate(p)
                If p.LineId <> 0 Then
                    If p.LineId = lstLine.SelectedValue Then
                        If p.TerminalId <> Session.Item("LoginTerminal") Then
                            Dim pTerminalMaster As New TerminalMaster
                            pTerminalMaster.TerminalId = p.TerminalId
                            TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container belong to another terminal - " & pTerminalMaster.TerminalName)
                            Functions.ControlFocus(txtContNo)
                            Exit Sub
                        End If
                        Dim pCONFIRM As New MtyFleetContJoDtls
                        pCONFIRM.TerminalId = Session.Item("LoginTerminal")
                        pCONFIRM.ContNo = txtContNo.Text
                        pCONFIRM.LineId = lstLine.SelectedValue
                        MtyFleetContJoDtls.ReturnMtyContainersValidate(pCONFIRM)
                        p.ContJoId = pCONFIRM.ContJoId
                        Dim pMtyFleetContJo As New MtyFleetContJo
                        pMtyFleetContJo.TerminalId = Session.Item("LoginTerminal")
                        pMtyFleetContJo.ContJoId = p.ContJoId
                        MtyFleetContJo.ReturnMtyFleetContJoVessel(pMtyFleetContJo)
                        If p.ContNo <> Nothing AndAlso p.ContNo <> "" Then
                            CType(rep.FindControl("lstSize"), DropDownList).SelectedValue = p.ContSize
                            CType(rep.FindControl("lstType"), DropDownList).SelectedValue = p.ContType
                            CType(rep.FindControl("textTareWeight"), TextBox).Text = p.TareWt
                            CType(rep.FindControl("textWeight"), TextBox).Text = p.Weight
                            CType(rep.FindControl("textCargoWeight"), TextBox).Text = p.CargoWt
                            CType(TxtBookingNo.FindControl("TxtBookingNo"), TextBox).Text = p.BookingNo
                            CType(textStuffDate.FindControl("textStuffDate"), TextBox).Text = p.BookingDate
                            '  pMtyFleetContJo.EmptyPodId = lstPOD.SelectedValue
                            ' pMtyFleetContJo.EmptyPolId = lstPOL.SelectedValue
                            CType(lstPOD.FindControl("lstPOD"), DropDownList).SelectedValue = pMtyFleetContJo.EmptyPodId
                            CType(lstPOD.FindControl("lstPOL"), DropDownList).SelectedValue = pMtyFleetContJo.EmptyPolId
                            CType(textValidity.FindControl("textValidity"), TextBox).Text = pMtyFleetContJo.Validity
                            CType(textValidity.FindControl("textSicut"), TextBox).Text = pMtyFleetContJo.SicutDate
                            CType(textValidity.FindControl("TextPortCut"), TextBox).Text = pMtyFleetContJo.PortCutOfdate
                            CType(textValidity.FindControl("TextETD"), TextBox).Text = pMtyFleetContJo.ETDDate
                            CType(textVesselName.FindControl("textVesselName"), TextBox).Text = pMtyFleetContJo.VesselName
                        Else
                            CType(rep.FindControl("lstSize"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstType"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstPOD"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstPOL"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("textTareWeight"), TextBox).Text = ""
                            CType(rep.FindControl("textWeight"), TextBox).Text = ""
                            CType(rep.FindControl("textCargoWeight"), TextBox).Text = ""
                            CType(TxtBookingNo.FindControl("TxtBookingNo"), TextBox).Text = ""
                            CType(textStuffDate.FindControl("textStuffDate"), TextBox).Text = ""
                            CType(textVesselName.FindControl("textVesselName"), TextBox).Text = ""
                            CType(textValidity.FindControl("textValidity"), TextBox).Text = ""
                            CType(textSicut.FindControl("textSicut"), TextBox).Text = ""
                            CType(TextPortCut.FindControl("TextPortCut"), TextBox).Text = ""
                            CType(TextETD.FindControl("TextETD"), TextBox).Text = ""
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "We are having some problem, contact to administrator.")
                            Functions.ControlFocus(txtContNo)
                            Exit Sub
                        End If
                    Else
                        Dim pCustomerMaster As New CustomerMaster
                        pCustomerMaster.CustomerId = p.LineId
                        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                        CType(rep.FindControl("lstSize"), DropDownList).SelectedValue = ""
                        CType(rep.FindControl("lstType"), DropDownList).SelectedValue = ""
                        CType(rep.FindControl("textTareWeight"), TextBox).Text = ""
                        CType(rep.FindControl("textWeight"), TextBox).Text = ""
                        CType(rep.FindControl("textCargoWeight"), TextBox).Text = ""
                        CType(TxtBookingNo.FindControl("TxtBookingNo"), TextBox).Text = ""
                        CType(textStuffDate.FindControl("textStuffDate"), TextBox).Text = ""
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container belong to shipping line - " & pCustomerMaster.CustomerName)
                        Functions.ControlFocus(txtContNo)
                        Exit Sub
                    End If
                Else
                    CType(rep.FindControl("lstSize"), DropDownList).SelectedValue = ""
                    CType(rep.FindControl("lstType"), DropDownList).SelectedValue = ""
                    CType(rep.FindControl("textTareWeight"), TextBox).Text = ""
                    CType(rep.FindControl("textWeight"), TextBox).Text = ""
                    CType(rep.FindControl("textCargoWeight"), TextBox).Text = ""
                    CType(TxtBookingNo.FindControl("TxtBookingNo"), TextBox).Text = ""
                    CType(textStuffDate.FindControl("textStuffDate"), TextBox).Text = ""

                    Dim pvalid As New MtyFleetContJoDtls
                    pvalid.ContNo = txtContNo.Text
                    MtyFleetContJoDtls.ReturnMtyContainersValidateNew(pvalid)
                    If pvalid.TerminalId <> Session.Item("LoginTerminal") AndAlso pvalid.TerminalId <> 0 Then
                        Dim pTerminalMaster As New TerminalMaster
                        pTerminalMaster.TerminalId = pvalid.TerminalId
                        TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container belong to another terminal - " & pTerminalMaster.TerminalName)
                        Functions.ControlFocus(txtContNo)
                        Exit Sub
                    End If
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container not available in inventory - " & txtContNo.Text)
                    Functions.ControlFocus(txtContNo)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "Catch Exception Occured")
        End Try
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        'For Each rep As RepeaterItem In repBookingContDeatils.Items
        '    'If CType(rep.FindControl("textGrNo"), HiddenField).Value > 0 Then
        '    If CType(rep.FindControl("textGrNo"), TextBox).Text Then
        '        CType(rep.FindControl("chkSelect"), CheckBox).Enabled = False
        '        CType(rep.FindControl("textContNo"), TextBox).Enabled = False
        '        CType(rep.FindControl("lstSize"), DropDownList).Enabled = False
        '        ' CType(rep.FindControl("lstLine"), DropDownList).Enabled = False
        '        CType(rep.FindControl("lstType"), DropDownList).Enabled = False
        '        CType(rep.FindControl("textWeight"), TextBox).Enabled = False
        '        CType(rep.FindControl("textSealNo"), TextBox).Enabled = False
        '        CType(rep.FindControl("textDOValidity"), TextBox).Enabled = False
        '        CType(rep.FindControl("txtBookingNo"), TextBox).Enabled = False
        '        CType(rep.FindControl("textDOValidity"), TextBox).Enabled = False
        '        CType(rep.FindControl("textAgentSeal"), TextBox).Enabled = False
        '        CType(rep.FindControl("textRemarks"), TextBox).Enabled = False
        '        CType(rep.FindControl("lstInvFlagTpt"), DropDownList).Enabled = False
        '        CType(rep.FindControl("lstInvFlagFrt"), DropDownList).Enabled = False
        '        CType(rep.FindControl("lstInvFlagCLR"), DropDownList).Enabled = False
        '    Else
        '        CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
        '        CType(rep.FindControl("textContNo"), TextBox).Enabled = True
        '        CType(rep.FindControl("lstSize"), DropDownList).Enabled = True
        '        ' CType(rep.FindControl("lstLine"), DropDownList).Enabled = True
        '        CType(rep.FindControl("lstType"), DropDownList).Enabled = True
        '        CType(rep.FindControl("textWeight"), TextBox).Enabled = True
        '        CType(rep.FindControl("textTareWeight"), TextBox).Enabled = True
        '        CType(rep.FindControl("textCargoWeight"), TextBox).Enabled = True
        '        CType(rep.FindControl("textRemarks"), TextBox).Enabled = True
        '        CType(rep.FindControl("textSealNo"), TextBox).Enabled = True
        '        CType(rep.FindControl("textDOValidity"), TextBox).Enabled = True
        '        ' CType(rep.FindControl("textBookingNo"), TextBox).Enabled = True
        '        CType(rep.FindControl("textAgentSeal"), TextBox).Enabled = True
        '        CType(rep.FindControl("lstInvFlagTpt"), DropDownList).Enabled = True
        '        CType(rep.FindControl("lstInvFlagFrt"), DropDownList).Enabled = True
        '        CType(rep.FindControl("lstInvFlagCLR"), DropDownList).Enabled = True
        '    End If
        'Next
        lstFromLocation.Enabled = True
        lstTransportar.Enabled = True
        lstToLocation.Enabled = True
        lstLocation.Enabled = True
        lstLine.Enabled = True
        lstPOD.Enabled = False
        lstConsignee.Enabled = True
        lstCustomer.Enabled = True
        textCont.Enabled = False
        TxtBookingNo.Enabled = False
        textStuffDate.Enabled = False


        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Puneet" Then
            textSicut.Enabled = True
            TextPortCut.Enabled = True
            TextETD.Enabled = True
            textValidity.Enabled = True
            textVesselName.Enabled = True
            lstPOD.Enabled = True
            lstPOL.Enabled = True
            lstToLocation.Enabled = True
            lstLocation.Enabled = True
            TxtBookingNo.Enabled = True
            textStuffDate.Enabled = True
            lstTransportar.Enabled = True
        End If
        'End If

        'If Session.Item("LoginUser") = "ADMIN" Then
        '    lstFromLocation.Enabled = True
        '    lstToLocation.Enabled = True
        '    lstLocation.Enabled = True
        '    'lstLine.Enabled = True
        '    'lstConsignee.Enabled = True
        '    'lstCustomer.Enabled = True
        'End If

        btnSave.Visible = True
        btnCancel.Visible = True
        btnEdit.Visible = False
        btnExit.Visible = False
        btnDelete.Visible = True
    End Sub
    Protected Sub btnsearchJo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsearchJo.Click
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = textGrNo.Text
        FleetContJo.ReturnFleetContJoMode(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        Try
            lstFromLocation.SelectedValue = pFleetContJo.FromLocation
        Catch ex As Exception
        End Try

        lstLocation.SelectedValue = pFleetContJo.MtyPickup
        Try
            lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        Catch ex As Exception
        End Try

        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        Try
            lstDocType.SelectedValue = pFleetContJo.TripType
            'lstSize.SelectedValue = pFleetContJo.ContSize
            'lstType.SelectedValue = pFleetContJo.ContType
        Catch ex As Exception
        End Try
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        textStuffDate.Text = pFleetContJo.StuffDate
        lstLine.SelectedValue = pFleetContJo.LineId
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try
        TxtBookingNo.Text = pFleetContJo.BookingNo
        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)
        textVesselName.Text = pFCJ1.VesselName
        textValidity.Text = pFCJ1.Validity
        TxtBookingNo.Text = pFCJ1.BookingNo
        textStuffDate.Text = pFCJ1.BEDate
        Try
            textSicut.Text = pFCJ1.SicutDate
            TextPortCut.Text = pFCJ1.PortCutOfdate
            TextETD.Text = pFCJ1.ETDDate
        Catch ex As Exception

        End Try
        Try
            lstPOD.SelectedValue = pFCJ1.StuffingPOD
            lstPOL.SelectedValue = pFCJ1.StuffingPOL
        Catch ex As Exception

        End Try


        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
        TxtBookingNo.Enabled = False
        textStuffDate.Enabled = False
    End Sub
    Sub search(ByVal InvoiceNo As String)
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = InvoiceNo
        textGrNo.Text = InvoiceNo
        FleetContJo.ReturnFleetContJoMode(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        Try
            lstFromLocation.SelectedValue = pFleetContJo.FromLocation
        Catch ex As Exception
        End Try

        lstLocation.SelectedValue = pFleetContJo.MtyPickup
        lstToLocation.SelectedValue = pFleetContJo.ToLocationId

        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        Try
            lstDocType.SelectedValue = pFleetContJo.TripType
            'lstSize.SelectedValue = pFleetContJo.ContSize
            'lstType.SelectedValue = pFleetContJo.ContType
        Catch ex As Exception
        End Try
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        textStuffDate.Text = pFleetContJo.StuffDate
        lstLine.SelectedValue = pFleetContJo.LineId
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try
        TxtBookingNo.Text = pFleetContJo.BookingNo
        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)
        textVesselName.Text = pFCJ1.VesselName
        textVesselName.Text = pFCJ1.VesselName
        textValidity.Text = pFCJ1.Validity
        TxtBookingNo.Text = pFCJ1.BookingNo
        textStuffDate.Text = pFCJ1.BEDate
        Try
            textSicut.Text = pFCJ1.SicutDate
            TextPortCut.Text = pFCJ1.PortCutOfdate
            TextETD.Text = pFCJ1.ETDDate
        Catch ex As Exception
        End Try
        lstPOD.SelectedValue = pFCJ1.StuffingPOD
        lstPOL.SelectedValue = pFCJ1.StuffingPOL

        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
        TxtBookingNo.Enabled = False
        textStuffDate.Enabled = False
        btnSearch.Visible = False
        btnEdit.Visible = True
        ' tblCont.Visible = True


    End Sub

    'Protected Sub repBookingContDeatils_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles repBookingContDeatils.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
    '        'Reference the Repeater Item.
    '        Dim item As RepeaterItem = e.Item

    '        'Reference the Controls.
    '        Dim repLstSize = TryCast(item.FindControl("lstSize"), DropDownList)
    '        Dim repLstType = TryCast(item.FindControl("lstType"), DropDownList)

    '        repLstSize.SelectedValue = lstSize.SelectedValue
    '        repLstType.SelectedValue = lstType.SelectedValue
    '        repLstSize.Enabled = False
    '        repLstType.Enabled = False

    '    End If
    'End Sub
    Sub ChkOilDtls(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim textWeight As TextBox = sender
            Dim textTareWeight As Double = 0
            Dim textCargoWeight As Double = 0
            Dim index1 As Integer = Integer.Parse(textWeight.ClientID.Substring("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length, textWeight.ClientID.IndexOf("_textWeight") - "ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length))
            Dim rep As RepeaterItem
            rep = repBookingContDeatils.Items(index1 - 1)
            'If txtOil.Text <> "0" Then
            '    Dim lngVendor As Integer = 0
            '    Try
            '        lngVendor = Convert.ToInt32(CType(rep.FindControl("lstOilVendor"), DropDownList).SelectedValue)
            '    Catch ex As Exception
            '        lngVendor = 0
            '    End Try
            '    If lngVendor = 0 Then
            '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Oil Vendor Name.")
            '        Return
            '    End If

            textTareWeight = Double.Parse(CType(rep.FindControl("textTareWeight"), TextBox).Text)
            'If textTareWeight = 0 Then
            '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Kindly Fill Tare Wt. and Gross Wt.")
            '    Return
            'End If

            CType(rep.FindControl("textCargoWeight"), TextBox).Text = Double.Parse(textWeight.Text) - textTareWeight

            '  End If
        Catch ex As Exception
        End Try


    End Sub
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = pCodevalue.Text
        FleetContJo.ReturnFleetContJoMode(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        textGrNo.Text = pFleetContJo.ContJoNo
        Try
            lstFromLocation.SelectedValue = pFleetContJo.FromLocation
        Catch ex As Exception
        End Try

        lstLocation.SelectedValue = pFleetContJo.MtyPickup
        Try
            lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        Catch ex As Exception
        End Try

        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        textStuffDate.Text = pFleetContJo.StuffDate
        lstLine.SelectedValue = pFleetContJo.LineId
        lstDocType.SelectedValue = pFleetContJo.TripType
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try
        ''lstOfMode.SelectedValue = pFleetContJo.ModeType
        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)
        textVesselName.Text = pFCJ1.VesselName
        textVesselName.Text = pFCJ1.VesselName
        textValidity.Text = pFCJ1.Validity
        Try
            textSicut.Text = pFCJ1.SicutDate
            TextPortCut.Text = pFCJ1.PortCutOfdate
            TextETD.Text = pFCJ1.ETDDate
            TxtBookingNo.Text = pFCJ1.BookingNo
            textStuffDate.Text = pFCJ1.BEDate
        Catch ex As Exception

        End Try
        lstPOL.SelectedValue = pFCJ1.StuffingPOL
        lstPOD.SelectedValue = pFCJ1.StuffingPOD
        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
    End Sub
End Class
