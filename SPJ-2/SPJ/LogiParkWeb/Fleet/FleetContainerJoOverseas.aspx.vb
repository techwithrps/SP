Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Partial Class Fleet_FleetContainerJoOverseas
    Inherits System.Web.UI.Page
    ' Dim rows As Integer = 5
    Dim count As Integer = 0
    Dim addrows As Integer = 2
    Dim glLine As ArrayList
    Dim glIsoCode As ArrayList
    Dim arrCHAId As ArrayList       'Added 16/11/2022
    Dim arrCHAName As ArrayList     'Added 16/11/2022
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
            TextjobNO.Enabled = False
            ImporttextJobdate.Enabled = False
            btnNewRows.Visible = True
            tblCont.Visible = False
            btnNewRows.Visible = False
            btnSearch.Visible = True
            lstLocation.Enabled = True
            textBoeNo.Enabled = False
            textBoeDate.Enabled = False
            textCont.Enabled = False
            lstPOD.Enabled = False
            lstPOL.Enabled = False
            Dim StrInvoiceRefNo As String = ""
            StrInvoiceRefNo = Request.QueryString("CONT_JO_NO")
            If StrInvoiceRefNo > 0 Then
                search(StrInvoiceRefNo)
            Else

            End If
            lstOfMode.Enabled = True
            lstPOD.Enabled = True
            lstPOL.Enabled = True
            textBoeNo.Enabled = True
            textBoeDate.Enabled = True
            textCont.Enabled = True
            lstFPOD.Enabled = True
            LstCHA.Enabled = True
            textHod.Enabled = True
            textCommodity.Enabled = True
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

    Sub LoadTreeViewData()
        Dim pFleet As New FleetContJo
        pFleet.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As FleetContJo In FleetContJo.ReturnFleetContJoImpPendingList(pFleet)
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

        repBookingContDeatils.DataSource = arr
        repBookingContDeatils.DataBind()
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND CUSTOMER_TYPE='E' ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('E','I') ORDER BY CUSTOMER_NAME"
            cmd3 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'L' AND ELOGISOL_FLAG='Y' ORDER BY CUSTOMER_NAME"
            cmd4 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'A' ORDER BY CUSTOMER_NAME"
            cmd5 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('C') ORDER BY CUSTOMER_NAME"
            cmd6 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID <> 19 ORDER BY PORT_NAME"
            cmd7 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER ORDER BY PORT_NAME"
            cmd8 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND CUSTOMER_TYPE='C' ORDER BY CUSTOMER_NAME"
            cmd9 = "SELECT DISTINCT TERMINAL_ID,TERMINAL_NAME FROM TERMINAL_MASTER  ORDER BY TERMINAL_NAME"


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

            'Added 16/11/2022
            ada = New OleDbDataAdapter(cmd9, con)
            ada.Fill(ds)
            lstFPOD.DataSource = ds.Tables(0)
            lstFPOD.DataTextField = "TERMINAL_NAME"
            lstFPOD.DataValueField = "TERMINAL_ID"
            lstFPOD.DataBind()
            lstFPOD.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            'End

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

            ada = New OleDbDataAdapter(cmd8, con)
            ada.Fill(ds)
            LstCHA.DataSource = ds.Tables(0)
            LstCHA.DataTextField = "CUSTOMER_NAME"
            LstCHA.DataValueField = "CUSTOMER_ID"
            LstCHA.DataBind()
            LstCHA.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try

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
            Dim textContNo, textCont1, textAllotMent As TextBox
            Dim lstContSize, lstContType As DropDownList
            For Each rep1 In repBookingContDeatils.Items
                textContNo = rep1.FindControl("textContNo")
                lstContSize = rep1.FindControl("lstSize")
                lstContType = rep1.FindControl("lstType")
                textAllotMent = rep1.FindControl("textAllotMent")

                If textContNo.Text.Trim <> Nothing Then
                    If textContNo.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Number is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textContNo)
                        Return rtnBool
                        Exit Function
                    End If

                    'If String.IsNullOrEmpty(textAllotMent.Text.Trim) Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Allotment Date is blank ")
                    '    rtnBool = False
                    '    Functions.ControlFocus(textAllotMent)
                    '    Return rtnBool
                    '    Exit Function
                    'End If

                    'If textBoeNo.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblBoeNo.Text)
                    '    Functions.ControlFocus(textBoeNo)
                    '    rtnBool = False
                    '    Return rtnBool
                    '    Exit Function
                    'End If

                    'If textBoeDate.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblBoeDate.Text)
                    '    Functions.ControlFocus(textBoeDate)
                    '    rtnBool = False
                    '    Return rtnBool
                    '    Exit Function
                    'End If

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

                    'Try
                    '    If GetDateTime(textAllotMent.Text) < GetDateTime(textStuffDate.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                "Booking Date can not be less than Allotment Date.")
                    '        Functions.ControlFocus(textAllotMent)
                    '        rtnBool = False
                    '        Return rtnBool
                    '        Exit Function
                    '    End If

                    'Catch ex As Exception

                    'End Try


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
        If Session.Item("LoginUser") <> "Puneet" AndAlso Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Akshay" Then
            If pFleet.MtyContId > 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container alreday alloted, So edit not allow.")
                Return
            End If
        End If
        ExtFleetContJo.InsertUpdateFleetContJoImp(pFleetContJo)
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
        Try
            TextjobNO.Text = pFleetContJo.JONO
            ImporttextJobdate.Text = pFleetContJo.JODate
        Catch ex As Exception
        End Try
        hdnJoId.Value = pFleetContJo.ContJoId
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
        'Added 16/11/2022
        pGrMapping.ClrBy = LstCHA.SelectedItem.Value
        Try
            pGrMapping.PackageType = lslPackageType.SelectedItem.Text
            pGrMapping.Cartons = TextPacket.Text
        Catch ex As Exception

        End Try
        pGrMapping.Hod = textHod.Text
        pGrMapping.Fpod = lstFPOD.SelectedItem.Value
        pGrMapping.Commodity = textCommodity.Text

        pGrMapping.MBLNo = textMBL.Text
        pGrMapping.MBLDate = textMBLDate.Text
        pGrMapping.HBLNo = textHBL.Text
        pGrMapping.HBLDate = textHBLDate.Text
        pGrMapping.ShipperInvNo = textShipperInvNo.Text
        pGrMapping.ShipperInvDate = textShipperInvDate.Text


        pGrMapping.MtyPickup = lstLocation.SelectedValue
        pGrMapping.CreatedBy = Session.Item("LoginUser")
        pGrMapping.ConsigneeId = lstCustomer.SelectedValue
        pGrMapping.Consignee = textConsignee.Text
        pGrMapping.TransporterId = lstTransportar.SelectedValue
        Try
            pGrMapping.ToLocationId = lstToLocation.SelectedValue
        Catch ex As Exception
        End Try
        pGrMapping.FromLocation = lstFromLocation.SelectedValue
        pGrMapping.TripType = lstDocType.SelectedValue
        Try
            pGrMapping.NoOf40 = textCont.Text
        Catch ex As Exception
        End Try

        Try
            pGrMapping.ModeType = lstOfMode.SelectedValue
        Catch ex As Exception
        End Try
        pGrMapping.ContJoNo = textGrNo.Text
        pGrMapping.BOENo = textBoeNo.Text
        pGrMapping.BOEDate = textBoeDate.Text
        pGrMapping.LineId = 0

        pGrMapping.JoType = "C"

        Try
            pGrMapping.StuffDate = textBoeDate.Text
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
                    pfId.BENo = textBoeNo.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.BEDate = textBoeDate.Text
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

                pGrMapping.ContJoDtlsList.Add(pfId)
            End If
        Next

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
                            CType(textBoeNo.FindControl("textBoeNo"), TextBox).Text = p.BookingNo
                            CType(textBoeDate.FindControl("textStuffDate"), TextBox).Text = p.BookingDate
                            CType(lstPOD.FindControl("lstPOD"), DropDownList).SelectedValue = pMtyFleetContJo.EmptyPodId
                            CType(lstPOD.FindControl("lstPOL"), DropDownList).SelectedValue = pMtyFleetContJo.EmptyPolId

                        Else
                            CType(rep.FindControl("lstSize"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstType"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstPOD"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("lstPOL"), DropDownList).SelectedValue = ""
                            CType(rep.FindControl("textTareWeight"), TextBox).Text = ""
                            CType(rep.FindControl("textWeight"), TextBox).Text = ""
                            CType(rep.FindControl("textCargoWeight"), TextBox).Text = ""
                            CType(textBoeNo.FindControl("textBoeNo"), TextBox).Text = ""
                            CType(textBoeDate.FindControl("textStuffDate"), TextBox).Text = ""

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
                        CType(textBoeNo.FindControl("textBoeNo"), TextBox).Text = ""
                        CType(textBoeDate.FindControl("textStuffDate"), TextBox).Text = ""
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
                    CType(textBoeNo.FindControl("textBoeNo"), TextBox).Text = ""
                    CType(textBoeDate.FindControl("textStuffDate"), TextBox).Text = ""

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
        textCont.Enabled = True
        lstFromLocation.Enabled = True
        lstTransportar.Enabled = True
        lstToLocation.Enabled = True
        lstLocation.Enabled = True
        lstLine.Enabled = True
        lstPOL.Enabled = True
        lstPOD.Enabled = True
        textConsignee.Enabled = True
        lstCustomer.Enabled = True
        textBoeNo.Enabled = True
        textBoeDate.Enabled = True
        lstOfMode.Enabled = True
        textMBL.Enabled = True
        textMBLDate.Enabled = True
        textHBL.Enabled = True
        textHBLDate.Enabled = True
        textShipperInvNo.Enabled = True
        textShipperInvDate.Enabled = True
        lstLocation.Enabled = True
        lslPackageType.Enabled = True
        TextPacket.Enabled = True

        btnSave.Visible = True
        btnCancel.Visible = True
        btnEdit.Visible = False
        btnExit.Visible = False
        btnDelete.Visible = True
        lstFPOD.Enabled = True
        LstCHA.Enabled = True
        textHod.Enabled = True
        textCommodity.Enabled = True
        ImporttextJobdate.Enabled = False
        TextjobNO.Enabled = False
    End Sub
    Protected Sub btnsearchJo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsearchJo.Click
        ListControlDataBind()
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = textGrNo.Text
        FleetContJo.ReturnFleetContJoMode(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        textConsignee.Text = pFleetContJo.Consignee
        Try
            lstCustomer.SelectedValue = pFleetContJo.ConsigneeId
        Catch ex As Exception
        End Try

        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        Try
            lstFromLocation.SelectedValue = pFleetContJo.FromLocation
        Catch ex As Exception
        End Try

        LstCHA.SelectedValue = pFleetContJo.ClrBy
        textCommodity.Text = pFleetContJo.Commodity
        Try
            lslPackageType.SelectedItem.Text = pFleetContJo.PackageType
            TextPacket.Text = pFleetContJo.Cartons
        Catch ex As Exception

        End Try

        lstFPOD.SelectedValue = pFleetContJo.Fpod
        textHod.Text = pFleetContJo.Hod

        Try
            lstLocation.SelectedValue = pFleetContJo.MtyPickup
        Catch ex As Exception
        End Try


        Try
            lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        Catch ex As Exception
        End Try

        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        Try
            TextjobNO.Text = pFleetContJo.JONO
            ImporttextJobdate.Text = pFleetContJo.JODate
        Catch ex As Exception

        End Try
        Try
            lstDocType.SelectedValue = pFleetContJo.TripType
        Catch ex As Exception
        End Try
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        textBoeNo.Text = pFleetContJo.BOENo
        textBoeDate.Text = pFleetContJo.BOEDate
        lstLine.SelectedValue = pFleetContJo.LineId
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try

        textHBL.Text = pFleetContJo.HBLNo
        textHBLDate.Text = pFleetContJo.HBLDate
        textMBL.Text = pFleetContJo.MBLNo
        textMBLDate.Text = pFleetContJo.MBLDate
        textShipperInvNo.Text = pFleetContJo.ShipperInvNo
        textShipperInvDate.Text = pFleetContJo.ShipperInvDate

        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)

        'textBoeNo.Text = pFCJ1.BENo
        'textBoeDate.Text = pFCJ1.BEDate

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
        textBoeNo.Enabled = False
        textBoeDate.Enabled = False
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
        textConsignee.Text = pFleetContJo.Consignee
        lstCustomer.SelectedValue = pFleetContJo.ConsigneeId
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
            TextjobNO.Text = pFleetContJo.JONO
            ImporttextJobdate.Text = pFleetContJo.JODate
        Catch ex As Exception

        End Try

        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        textBoeDate.Text = pFleetContJo.StuffDate
        lstLine.SelectedValue = pFleetContJo.LineId
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try
        textBoeNo.Text = pFleetContJo.BOENo
        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)

        'textValidity.Text = pFCJ1.Validity
        textBoeNo.Text = pFCJ1.BENo
        textBoeDate.Text = pFCJ1.BEDate

        lstPOD.SelectedValue = pFCJ1.StuffingPOD
        lstPOL.SelectedValue = pFCJ1.StuffingPOL

        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
        textBoeNo.Enabled = False
        textBoeDate.Enabled = False
        btnSearch.Visible = False
        btnEdit.Visible = True
        ' tblCont.Visible = True


    End Sub

    Sub ChkOilDtls(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim textWeight As TextBox = sender
            Dim textTareWeight As Double = 0
            Dim textCargoWeight As Double = 0
            Dim index1 As Integer = Integer.Parse(textWeight.ClientID.Substring("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length, textWeight.ClientID.IndexOf("_textWeight") - "ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length))
            Dim rep As RepeaterItem
            rep = repBookingContDeatils.Items(index1 - 1)

            textTareWeight = Double.Parse(CType(rep.FindControl("textTareWeight"), TextBox).Text)


            CType(rep.FindControl("textCargoWeight"), TextBox).Text = Double.Parse(textWeight.Text) - textTareWeight

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
        textConsignee.Text = pFleetContJo.Consignee
        lstCustomer.SelectedValue = pFleetContJo.ConsigneeId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        textGrNo.Text = pFleetContJo.ContJoNo
        textBoeNo.Text = pFleetContJo.BOENo
        TextjobNO.Text = pFleetContJo.JONO
        ImporttextJobdate.Text = pFleetContJo.JODate
        textBoeDate.Text = pFleetContJo.BOEDate
        textMBL.Text = pFleetContJo.MBLNo
        textMBLDate.Text = pFleetContJo.MBLDate
        textHBL.Text = pFleetContJo.HBLNo
        textHBLDate.Text = pFleetContJo.HBLDate
        textShipperInvNo.Text = pFleetContJo.ShipperInvNo
        textShipperInvDate.Text = pFleetContJo.ShipperInvDate
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
        textBoeDate.Text = pFleetContJo.StuffDate
        Try
            lstLine.SelectedValue = pFleetContJo.LineId
        Catch ex As Exception

        End Try
        Try
            TextjobNO.Text = pFleetContJo.JONO
            ImporttextJobdate.Text = pFleetContJo.JODate
        Catch ex As Exception

        End Try

        lstDocType.SelectedValue = pFleetContJo.TripType
        Try
            lstOfMode.SelectedValue = pFleetContJo.ModeType
        Catch ex As Exception
        End Try
        Dim pFCJ As New FleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(FleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        Dim pFCJ1 As New FleetContJoDtls
        pFCJ1.TerminalId = pFleetContJo.TerminalId
        pFCJ1.ContJoId = pFleetContJo.ContJoId
        FleetContJoDtls.ReturnFleetContJoDtlsvessel(pFCJ1)

        Try

            textBoeNo.Text = pFCJ1.BENo
            textBoeDate.Text = pFCJ1.BEDate
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
