Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb

Partial Class Empty_MtyContainerJo
    Inherits System.Web.UI.Page
    'Dim rows As Integer = 20
    Dim count As Integer = 0
    Dim addrows As Integer = 2
    Dim glLine As ArrayList
    Dim glIsoCode As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareContData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            '  btnSave.Attributes.Add("onclick", " this.disabled = true; " & ClientScript.GetPostBackEventReference(btnSave, Nothing) & ";")
            manageUserControls(True)
            ListControlDataBind()
            ButtonControlSetup(True)
            btnAdd.Visible = True
            manageUserControls(False)
            fillRepeator(New ArrayList)
            '            LoadTreeViewData()
            'TVJo.Enabled = True
            ButtonControlSetup(False)
            textGrNo.Enabled = False
            textGrDate.Enabled = False
            btnNewRows.Visible = True
            lstToLocation.Enabled = False
            textCont.Text = 0
            tblCont.Visible = False
            btnNewRows.Visible = False
            btnSearch.Visible = True
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
    Function GetDateTime(strDate As String) As DateTime
        Dim strday, strtime, arrdate, Day, Month, Year, arrtime, Hour, Minute, FinalDate
        If String.IsNullOrEmpty(strDate) Then
            Return DateTime.Now
        End If
        Dim parry = strDate.Split(" ")
        If parry.Length = 2 Then
            strday = parry(0)
            strtime = parry(1)

            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            arrtime = strtime.Split(":")
            Hour = arrtime(0)
            Minute = arrtime(1)
        ElseIf parry.Length = 1 Then
            strday = parry(0)
            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            Hour = 0
            Minute = 0
        End If
        FinalDate = New DateTime(Year, Month, Day, Hour, Minute, 0)
        Return FinalDate
    End Function
    'Function GetDateTimeNew(strDate1 As String) As DateTime
    '    Dim arrdate1, Day1, Month1, Year1, FinalDate1

    '    If strDate1 <> Nothing And strDate1 <> "" Then
    '        Dim parry = strDate1.Trim()
    '        arrdate1 = parry.Split("/")
    '        Day1 = arrdate1(0)
    '        Month1 = arrdate1(1)
    '        Year1 = arrdate1(2)
    '    End If
    '    FinalDate1 = New DateTime(Year1, Month1, Day1, 0, 0, 0)
    '    Return FinalDate1
    'End Function


    Protected Sub prepareLine(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("--Select--", 0))
            For Each ic As CustomerMaster In glLine
                lst.Items.Add(New ListItem(ic.CustomerName, ic.CustomerId))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub prepareContData()
        Dim pIso As New IsoCode
        glIsoCode = IsoCode.ReturnIsoCodeListOfContType(pIso)
        Dim pCustomerMaster As New CustomerMaster
        glLine = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
        Dim P
    End Sub
    Private Sub fillRepeator(ByVal arr As ArrayList)
        'If arr.Count < rows Then
        '    For i As Integer = 0 To rows - arr.Count - 1
        '        Dim p As New MtyFleetContJoDtls
        '        p.LineId = 0
        '        arr.Add(p)
        '    Next
        'End If
        repBookingContDeatils.DataSource = arr
        repBookingContDeatils.DataBind()
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'S') ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('E','I') ORDER BY CUSTOMER_NAME"
            cmd3 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'L'  AND ELOGISOL_FLAG='Y' ORDER BY CUSTOMER_NAME"
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
            lstToLocation.DataSource = TerminalMaster.ReturnTerminalMasterListUserId(Session.Item("LoginUser"))
            lstToLocation.DataTextField = "TerminalName"
            lstToLocation.DataValueField = "TerminalId"
            lstToLocation.DataBind()
            lstToLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstToLocation.SelectedValue = Session.Item("LoginTerminal")

            lstLocation.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            lstLocation.DataTextField = "TerminalName"
            lstLocation.DataValueField = "TerminalId"
            lstLocation.DataBind()
            lstLocation.Items.Insert(0, (New ListItem("---Select---", 0)))

            Dim pVendor As New VendorMaster
            pVendor.TerminalId = Session.Item("LoginTerminal")
            lstSurveyor.DataSource = VendorMaster.ReturnVendorMasterSurveyor(pVendor)
            lstSurveyor.DataTextField = "VendorName"
            lstSurveyor.DataValueField = "VendorId"
            lstSurveyor.DataBind()
            lstSurveyor.Items.Insert(0, (New ListItem("---Select---", 0)))

            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try

        Dim pIso As New IsoCode
        lstType.DataSource = IsoCode.ReturnIsoCodeListOfContType(pIso)
        lstType.DataValueField = "ContType"
        lstType.DataTextField = "ContType"
        lstType.DataBind()
        lstType.Items.Insert(0, New ListItem("--Select--", ""))

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
    Protected Sub btnEditContDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditContDetail.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        tblCont.Visible = True
        Dim pRM As New ExtMtyFleetContJo
        pRM.ContJoDtlsList = New ArrayList
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            Dim pfId As New MtyFleetContJoDtls
            pfId.TerminalId = Session.Item("LoginTerminal")
            pfId.CompanyId = Session.Item("CompanyId")
            'pfId.DoNo = textDONo.Text
            'pfId.DoDate = textDODate.Text & " " & textDoDateHour.Text & ":" & textDoDateMinutes.Text
            'pfId.DoValidDate = textDoValidity.Text & " " & textDoValidityHour.Text & ":" & textDoValidityMinutes.Text
            Try
                pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
            Catch ex As Exception
            End Try
            'Try
            '    pfId.BookingNo = CType(rep.FindControl("textBookingNo"), TextBox).Text
            'Catch ex As Exception
            'End Try
            Try
                pfId.LineId = CType(rep.FindControl("lstLine"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text
            Catch ex As Exception
            End Try
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
                pfId.ContJoId = hdnJoId.Value
            Catch ex As Exception
            End Try
            Try
                pfId.VehicleNo = CType(rep.FindControl("textVehicleNo"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.GRNo = CType(rep.FindControl("textGRNo"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Extra3 = CType(rep.FindControl("textAllotMent"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.PickUpDate = CType(rep.FindControl("textPickupDate"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.GateInDate = CType(rep.FindControl("textGateInDate"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
            Catch ex As Exception
            End Try
            pRM.ContJoDtlsList.Add(pfId)
        Next

        'Dim i As Integer = 1
        'Try
        '    While i < Convert.ToDouble(textCont.Text)

        '        i += 1
        '    End While
        '    fillRepeator(pRM.ContJoDtlsList)
        'Catch ex As Exception
        'End Try

        If Not repBookingContDeatils.Items.Count.Equals(Convert.ToInt32(textCont.Text)) Then
            For index = repBookingContDeatils.Items.Count To Convert.ToDouble(textCont.Text) - 1
                Dim pRD As New MtyFleetContJoDtls
                pRD.LineId = 0
                pRM.ContJoDtlsList.Add(pRD)
                fillRepeator(pRM.ContJoDtlsList)
            Next
        Else
            fillRepeator(pRM.ContJoDtlsList)
        End If


        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
    Private Shared Function StingToDate(strDate As String) As DateTime
        Dim array = strDate.Split(CType("/", Char))
        If array.Length.Equals(1) Then
            array = strDate.Split(CType("-", Char))
        End If

        Dim cYear = CType(array.Last(), Integer)
        Dim cDt = CType(array.First(), Integer)
        Dim cMo = CType(array(1), Integer)
        Return New DateTime(cYear, cMo, cDt)
    End Function


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
        If lstSurveyor.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblsurveyor.Text)
            Functions.ControlFocus(lstSurveyor)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstLocation.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblLocation.Text)
            Functions.ControlFocus(lstLocation)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstToLocation.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblToLocation.Text)
            Functions.ControlFocus(lstToLocation)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstLine.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblLine.Text)
            Functions.ControlFocus(lstLine)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textBookingNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblStuffDate.Text)
            Functions.ControlFocus(textBookingNo)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textBookingDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblStuffDate.Text)
            Functions.ControlFocus(textBookingDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textValidity.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblStuffDate.Text)
            Functions.ControlFocus(textValidity)
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
        If lstPOD.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblPOD.Text)
            Functions.ControlFocus(lstPOD)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstPOL.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblPOL.Text)
            Functions.ControlFocus(lstPOL)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textVesselName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVesselName.Text)
            Functions.ControlFocus(textVesselName)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If textSicut.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblSicut.Text)
            Functions.ControlFocus(textSicut)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If TextPortCut.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblPortCut.Text)
            Functions.ControlFocus(TextPortCut)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If TextETD.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVesselName.Text)
            Functions.ControlFocus(TextETD)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If textGrNo.Text = "" Then
            Dim rr = GetDateTime(textBookingDate.Text.Trim())
            Dim newDt = rr.AddDays(-1)
            Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            If Not String.IsNullOrWhiteSpace(textBookingDate.Text) AndAlso (GetDateTime(textBookingDate.Text.Trim()) > currentDt OrElse
                 GetDateTime(textBookingDate.Text.Trim()) < currentDt.AddDays(-1)) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textBookingDate)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If textGrNo.Text = "" Then
            If GetDateTime(TextETD.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ETD Date can not be less than booking date")
                Functions.ControlFocus(TextETD)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If textGrNo.Text = "" Then
            If GetDateTime(textSicut.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "SICut Of Date can not be less than booking date")
                Functions.ControlFocus(textSicut)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If textGrNo.Text = "" Then
            If GetDateTime(TextPortCut.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "PortCut Of Date can not be less than booking date")
                Functions.ControlFocus(TextPortCut)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If GetDateTime(textBookingDate.Text.Trim()) > DateTime.Now Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Booking Date can not be more than current date")
            Functions.ControlFocus(textBookingDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If GetDateTime(textValidity.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Validity Date can not be less than booking date")
            Functions.ControlFocus(textValidity)
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
        If lstSize.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblContSize1.Text)
            Functions.ControlFocus(lstSize)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstType.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblContType1.Text)
            Functions.ControlFocus(lstType)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        '  End If
        If repBookingContDeatils.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textContNo, textCont1, textOutDate, textAllotmentDate, textGateInDate, textTareWeight, textWeight, textCargoWeight As TextBox
            Dim lstContSize, lstContType As DropDownList
            For Each rep1 In repBookingContDeatils.Items
                textContNo = rep1.FindControl("textContNo")
                textOutDate = rep1.FindControl("textPickupDate")
                textAllotmentDate = rep1.FindControl("textAllotMent")
                textGateInDate = rep1.FindControl("textGateInDate")
                textTareWeight = rep1.FindControl("textTareWeight")
                textWeight = rep1.FindControl("textWeight")
                textCargoWeight = rep1.FindControl("textCargoWeight")

                lstContSize = rep1.FindControl("lstSize")
                lstContType = rep1.FindControl("lstType")

                If textContNo.Text.Trim <> Nothing Then
                    If textContNo.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Number is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textContNo)
                        Return rtnBool
                        Exit Function
                    End If
                    If lstContSize.SelectedValue = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Container Size.")
                        rtnBool = False
                        Functions.ControlFocus(lstContSize)
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
                    If textTareWeight.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Tare Wt.")
                        Functions.ControlFocus(textTareWeight)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If textWeight.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Gross Wt.")
                        Functions.ControlFocus(textWeight)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If textAllotmentDate.Text <> "" AndAlso textAllotmentDate.Text <> Nothing Then
                        If GetDateTime(textAllotmentDate.Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Allotment Date can not be more than current date")
                            Functions.ControlFocus(textAllotmentDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(textAllotmentDate.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Allotment Date can not be less than booking date")
                            Functions.ControlFocus(textAllotmentDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    Else
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Allotment Date")
                        Functions.ControlFocus(textAllotmentDate)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If textOutDate.Text <> "" AndAlso textOutDate.Text <> Nothing Then
                        If GetDateTime(textOutDate.Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Out Date can not be more than current date")
                            Functions.ControlFocus(textOutDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(textOutDate.Text.Trim()) < GetDateTime(textAllotmentDate.Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Out Date can not be less than allotment date")
                            Functions.ControlFocus(textAllotmentDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(textAllotmentDate.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Out Date can not be less than booking date")
                            Functions.ControlFocus(textAllotmentDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If

                    If textGateInDate.Text <> "" AndAlso textGateInDate.Text <> Nothing Then
                        If GetDateTime(textGateInDate.Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Gate In Date can not be more than current date")
                            Functions.ControlFocus(textOutDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        If textOutDate.Text <> "" AndAlso textOutDate.Text <> Nothing Then
                            If GetDateTime(textGateInDate.Text.Trim()) < GetDateTime(textOutDate.Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Gate In Date can not be less than out date")
                                Functions.ControlFocus(textGateInDate)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Out Date can not be blank")
                            Functions.ControlFocus(textOutDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(textGateInDate.Text.Trim()) < GetDateTime(textAllotmentDate.Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Gate In Date can not be less than allotment date")
                            Functions.ControlFocus(textGateInDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(textGateInDate.Text.Trim()) < GetDateTime(textBookingDate.Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Gate In Date can not be less than booking date")
                            Functions.ControlFocus(textGateInDate)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If
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
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pMtyFleetContJo As ExtMtyFleetContJo = ReturnObject()
        ExtMtyFleetContJo.InsertUpdateMtyFleetContJo(pMtyFleetContJo)
        If pMtyFleetContJo.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pMtyFleetContJo.Errormsg)
            Functions.ControlFocus(lstDocType)
            Return
        End If
        textGrDate.Text = pMtyFleetContJo.CreatedOn
        textGrNo.Text = pMtyFleetContJo.ContJoNo
        hdnJoId.Value = pMtyFleetContJo.ContJoId
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

    Private Function ReturnObject() As ExtMtyFleetContJo
        Dim pGrMapping As New ExtMtyFleetContJo
        pGrMapping.TerminalId = Session.Item("LoginTerminal")
        pGrMapping.CompanyId = Session.Item("CompanyId")
        Try
            pGrMapping.ContJoId = hdnJoId.Value
        Catch ex As Exception

        End Try
        pGrMapping.FromLocationId = lstLocation.SelectedValue
        pGrMapping.CreatedBy = Session.Item("LoginUser")
        pGrMapping.CustomerId = lstCustomer.SelectedValue
        pGrMapping.ConsigneeId = lstConsignee.SelectedValue
        pGrMapping.TransporterId = lstTransportar.SelectedValue
        pGrMapping.SurveyorId = lstSurveyor.SelectedValue
        pGrMapping.ToLocationId = lstToLocation.SelectedValue
        pGrMapping.JoType = lstDocType.SelectedValue
        pGrMapping.ContJoNo = textGrNo.Text
        pGrMapping.ContSize = lstSize.SelectedValue
        pGrMapping.ContType = lstType.SelectedValue
        Try
            pGrMapping.EmptyPodId = lstPOD.SelectedValue
            pGrMapping.EmptyPolId = lstPOL.SelectedValue
            pGrMapping.VesselName = textVesselName.Text
            pGrMapping.Validity = textValidity.Text
            pGrMapping.SicutDate = textSicut.Text
            pGrMapping.PortCutOfdate = TextPortCut.Text
            pGrMapping.ETDDate = TextETD.Text   
            pGrMapping.LineId = 0
        Catch ex As Exception

        End Try

        'Try
        '    pGrMapping.NoOf20 = textCont20.Text
        'Catch ex As Exception
        'End Try
        'Try
        '    pGrMapping.NoOf40 = textCont40.Text
        'Catch ex As Exception
        'End Try
        pGrMapping.JoType = "M"
        pGrMapping.BookingNo = textBookingNo.Text
        pGrMapping.BookingDate = textBookingDate.Text
        Try
            pGrMapping.LineId = lstLine.SelectedValue
        Catch ex As Exception
        End Try

        Dim noOfCont20 = 0
        Dim noOfCont40 = 0

        pGrMapping.ContJoDtlsList = New ArrayList
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("textContNo"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textContNo"), TextBox).Text <> "" Then
                Dim pfId As New MtyFleetContJoDtls
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
                pfId.JoType = "M"
                Try
                    pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.ContSize = CType(rep.FindControl("lstSize"), DropDownList).SelectedValue
                    If pfId.ContSize = "20" Then
                        noOfCont20 += 1
                    ElseIf pfId.ContSize = "40" Then
                        noOfCont40 += 1
                    End If
                Catch ex As Exception
                End Try
                Try
                    pfId.Extra1 = lstLocation.SelectedValue
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
                    pfId.VehicleNo = CType(rep.FindControl("textVehicleNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.GRNo = CType(rep.FindControl("textGRNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.Extra3 = CType(rep.FindControl("textAllotMent"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.PickUpDate = CType(rep.FindControl("textPickupDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pfId.GateInDate = CType(rep.FindControl("textGateInDate"), TextBox).Text
                Catch ex As Exception
                End Try


                Try
                    pfId.BookingNo = textBookingNo.Text
                Catch ex As Exception
                End Try
                Try
                    pfId.BookingDate = textBookingDate.Text
                Catch ex As Exception
                End Try


                Try
                    pfId.LineId = lstLine.SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
                Catch ex As Exception
                End Try

                pGrMapping.ContJoDtlsList.Add(pfId)
            End If
        Next

        If noOfCont20.Equals(0) Or noOfCont40.Equals(0) Then
            If lstSize.SelectedValue = "20" Then
                pGrMapping.NoOf20 = CType(textCont.Text.Trim, Long)
                pGrMapping.NoOf40 = 0
            ElseIf lstSize.SelectedValue = "40" Then
                pGrMapping.NoOf20 = 0
                pGrMapping.NoOf40 = CType(textCont.Text.Trim, Long)

            End If
        Else
            pGrMapping.NoOf20 = noOfCont20
            pGrMapping.NoOf40 = noOfCont40
        End If

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
        Dim pRM As New ExtMtyFleetContJo
        pRM.ContJoDtlsList = New ArrayList

        For Each rep As RepeaterItem In repBookingContDeatils.Items

            Dim pfId As New MtyFleetContJoDtls
            pfId.TerminalId = Session.Item("LoginTerminal")

            Try
                pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
            Catch ex As Exception
            End Try

            Try
                pfId.ContJoId = hdnJoId.Value
            Catch ex As Exception
            End Try

            Try
                pfId.BookingNo = CType(rep.FindControl("textBookingNo"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.LineId = CType(rep.FindControl("lstLine"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try

            Try
                pfId.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text
            Catch ex As Exception
            End Try

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
                pfId.VehicleNo = CType(rep.FindControl("textVehicleNo"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.GRNo = CType(rep.FindControl("textGRNo"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                pfId.Extra3 = CType(rep.FindControl("textAllotMent"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.PickUpDate = CType(rep.FindControl("textPickupDate"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.GateInDate = CType(rep.FindControl("textGateInDate"), TextBox).Text
            Catch ex As Exception
            End Try

            Try
                pfId.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text
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
                Dim p As New FleetContJoDtls
                p.TerminalId = Session.Item("LoginTerminal")
                p.ContNo = txtContNo.Text
                FleetContJoDtls.ReturnFleetContJoDtls(p)
                If p.MtyContId <> Nothing Then
                    If p.GrId <> Nothing Then
                        Dim pgr As New FleetGrMapping
                        pgr.TerminalId = p.TerminalId
                        pgr.GrId = p.GrId
                        FleetGrMapping.ReturnFleetGrMapping(pgr)
                        If pgr.CloseDate = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & CType(rep.FindControl("textContNo"), TextBox).Text & "")
                            Functions.ControlFocus(txtContNo)
                            Exit Sub

                        End If
                    End If

                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & CType(rep.FindControl("textContNo"), TextBox).Text & "")
                    Functions.ControlFocus(txtContNo)
                    Exit Sub
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("hdnContId"), HiddenField).Value > 0 Then
                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = False
                'CType(rep.FindControl("textBookingNo"), TextBox).Enabled = False
                'CType(rep.FindControl("lstLine"), DropDownList).Enabled = False
                CType(rep.FindControl("textContNo"), TextBox).Enabled = False
                CType(rep.FindControl("lstSize"), DropDownList).Enabled = False
                CType(rep.FindControl("lstType"), DropDownList).Enabled = False
                CType(rep.FindControl("textVehicleNo"), TextBox).Enabled = False
                CType(rep.FindControl("textGRNo"), TextBox).Enabled = False
                CType(rep.FindControl("textAllotMent"), TextBox).Enabled = False
                CType(rep.FindControl("textPickupDate"), TextBox).Enabled = False
                CType(rep.FindControl("textGateInDate"), TextBox).Enabled = False
                CType(rep.FindControl("textRemarks"), TextBox).Enabled = False
                CType(rep.FindControl("textWeight"), TextBox).Enabled = False
                CType(rep.FindControl("textTareWeight"), TextBox).Enabled = False
                CType(rep.FindControl("textCargoWeight"), TextBox).Enabled = False
                'CType(rep.FindControl("lstPOD"), DropDownList).Enabled = False
                'CType(rep.FindControl("lstPOL"), DropDownList).Enabled = False
                'CType(rep.FindControl("textVesselName"), TextBox).Enabled = False
                'CType(rep.FindControl("textValidity"), TextBox).Enabled = False

            Else
                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
                'CType(rep.FindControl("textBookingNo"), TextBox).Enabled = True
                'CType(rep.FindControl("lstLine"), DropDownList).Enabled = True
                CType(rep.FindControl("textContNo"), TextBox).Enabled = True
                CType(rep.FindControl("lstSize"), DropDownList).Enabled = True
                CType(rep.FindControl("lstType"), DropDownList).Enabled = True
                CType(rep.FindControl("textWeight"), TextBox).Enabled = True
                CType(rep.FindControl("textTareWeight"), TextBox).Enabled = True
                CType(rep.FindControl("textCargoWeight"), TextBox).Enabled = True
                CType(rep.FindControl("textVehicleNo"), TextBox).Enabled = True
                CType(rep.FindControl("textGRNo"), TextBox).Enabled = True
                CType(rep.FindControl("textPickupDate"), TextBox).Enabled = True
                CType(rep.FindControl("textAllotMent"), TextBox).Enabled = True
                CType(rep.FindControl("textGateInDate"), TextBox).Enabled = True
                CType(rep.FindControl("textRemarks"), TextBox).Enabled = True
                'CType(rep.FindControl("lstPOD"), DropDownList).Enabled = True
                'CType(rep.FindControl("lstPOL"), DropDownList).Enabled = True
                'CType(rep.FindControl("textVesselName"), TextBox).Enabled = True
                'CType(rep.FindControl("textValidity"), TextBox).Enabled = True

            End If
        Next
        If hdnGrId.Value = "" Then
            lstToLocation.Enabled = True
            lstLocation.Enabled = False
            lstLine.Enabled = True
            lstConsignee.Enabled = True
            lstCustomer.Enabled = True
            lstSurveyor.Enabled = True
            lstPOD.Enabled = True
            lstPOL.Enabled = True
            textValidity.Enabled = True
            textVesselName.Enabled = True
            lstToLocation.Enabled = False
        End If

        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "superuser" Then
            textBookingDate.Enabled = True
            textSicut.Enabled = True
            TextPortCut.Enabled = True
            TextETD.Enabled = True
            textValidity.Enabled = True
            textVesselName.Enabled = True
            textBookingNo.Enabled = True
            lstPOD.Enabled = True
            lstPOL.Enabled = True
            lstToLocation.Enabled = True
            lstLocation.Enabled = True
            lstTransportar.Enabled = True
            lstSurveyor.Enabled = True
            lstLine.Enabled = True
        End If
        If Session.Item("LoginUser") = "Robin Singh" Then
            lstLocation.Enabled = True
            lstTransportar.Enabled = True
            lstSurveyor.Enabled = True
        End If
        If Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Akshay" Then
            textCont.Enabled = True
        End If

        btnSave.Visible = True
        btnCancel.Visible = True
        btnEdit.Visible = False
        btnExit.Visible = False
        btnDelete.Visible = True
    End Sub
    Protected Sub btnsearchJo_Click(sender As Object, e As EventArgs) Handles btnsearchJo.Click
        Dim pFleetContJo As New MtyFleetContJo
        pFleetContJo.FromLocationId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = textGrNo.Text
        MtyFleetContJo.ReturnMtyFleetContJoHandover(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId

        Try
            lstPOD.SelectedValue = pFleetContJo.EmptyPodId
            lstPOL.SelectedValue = pFleetContJo.EmptyPolId
            textVesselName.Text = pFleetContJo.VesselName
            textValidity.Text = pFleetContJo.Validity
            textSicut.Text = pFleetContJo.SicutDate
            TextPortCut.Text = pFleetContJo.PortCutOfdate
            TextETD.Text = pFleetContJo.ETDDate
        Catch ex As Exception

        End Try

        lstLocation.SelectedValue = pFleetContJo.FromLocationId
        lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        Try
            lstSurveyor.SelectedValue = pFleetContJo.SurveyorId
        Catch ex As Exception

        End Try
        Try
            lstDocType.SelectedValue = pFleetContJo.JoType
            lstSize.SelectedValue = pFleetContJo.ContSize
            lstType.SelectedValue = pFleetContJo.ContType
        Catch ex As Exception
        End Try

        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        'textCont40.Text = pFleetContJo.NoOf40
        textBookingNo.Text = pFleetContJo.BookingNo
        textBookingDate.Text = pFleetContJo.BookingDate
        Try
            lstLine.SelectedValue = pFleetContJo.LineId
        Catch ex As Exception
        End Try


        Dim pFCJ As New MtyFleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId

        fillRepeator(MtyFleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))


        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
    End Sub

    Protected Sub repBookingContDeatils_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles repBookingContDeatils.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            'Reference the Repeater Item.
            Dim item As RepeaterItem = e.Item

            'Reference the Controls.
            Dim repLstSize = TryCast(item.FindControl("lstSize"), DropDownList)
            Dim repLstType = TryCast(item.FindControl("lstType"), DropDownList)

            repLstSize.SelectedValue = lstSize.SelectedValue
            repLstType.SelectedValue = lstType.SelectedValue
            repLstSize.Enabled = False
            repLstType.Enabled = False

        End If
    End Sub
    Sub search(ByVal InvoiceNo As String)
        Dim pFleetContJo As New MtyFleetContJo
        pFleetContJo.FromLocationId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = InvoiceNo
        textGrNo.Text = InvoiceNo
        MtyFleetContJo.ReturnMtyFleetContJoHandover(pFleetContJo)
        If pFleetContJo.ContJoId <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order No.")
            Exit Sub
        End If
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId
        lstTransportar.SelectedValue = pFleetContJo.TransporterId

        Try
            lstPOD.SelectedValue = pFleetContJo.EmptyPodId
            lstPOL.SelectedValue = pFleetContJo.EmptyPolId
            textVesselName.Text = pFleetContJo.VesselName
            textValidity.Text = pFleetContJo.Validity
            textSicut.Text = pFleetContJo.SicutDate
            TextPortCut.Text = pFleetContJo.PortCutOfdate
            TextETD.Text = pFleetContJo.ETDDate
        Catch ex As Exception

        End Try
        lstLocation.SelectedValue = pFleetContJo.FromLocationId
        lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        lstSurveyor.SelectedValue = pFleetContJo.SurveyorId
        Try
            lstDocType.SelectedValue = pFleetContJo.JoType
            lstSize.SelectedValue = pFleetContJo.ContSize
            lstType.SelectedValue = pFleetContJo.ContType
        Catch ex As Exception
        End Try
        hdnJoId.Value = pFleetContJo.ContJoId
        textGrDate.Text = pFleetContJo.CreatedOn
        textCont.Text = pFleetContJo.NoOf20 + pFleetContJo.NoOf40
        'textCont40.Text = pFleetContJo.NoOf40
        textBookingNo.Text = pFleetContJo.BookingNo
        textBookingDate.Text = pFleetContJo.BookingDate
        Try
            lstLine.SelectedValue = pFleetContJo.LineId
        Catch ex As Exception
        End Try
        Dim pFCJ As New MtyFleetContJoDtls
        pFCJ.TerminalId = pFleetContJo.TerminalId
        pFCJ.ContJoId = pFleetContJo.ContJoId
        fillRepeator(MtyFleetContJoDtls.ReturnFleetContJoDtlsList(pFCJ))
        btnEditContDetail.Visible = True
        btnsearchJo.Visible = False
        manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True


    End Sub
End Class
