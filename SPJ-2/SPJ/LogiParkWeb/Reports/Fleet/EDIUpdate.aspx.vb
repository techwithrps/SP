Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports AjaxControlToolkit

Partial Class Reports_Fleet_EDIUpdate
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim strJob As String = ""
    Dim longJobNo As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Dim arrCustomerId As ArrayList
    Dim arrCustomerName As ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
    Dim arrPodId As ArrayList
    Dim arrPortName1 As ArrayList
    Dim arrPodId1 As ArrayList
    Dim arrPodName As ArrayList
    Dim arrPodName1 As ArrayList
    Dim arrCHAId As ArrayList
    Dim arrCHAName As ArrayList
    Protected Sub preparePort(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", ""))
            For i As Integer = 0 To arrPortId.Count - 1
                lst.Items.Add(New ListItem(arrPortName(i), arrPortId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub preparePortData()
        Try
            arrPortId = New ArrayList
            arrPortName = New ArrayList
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterList(pPortMaster)
                arrPortId.Add(obj.PortId)
                arrPortName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub preparePod(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrPodId1.Count - 1
                lst.Items.Add(New ListItem(arrPodName1(i), arrPodId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub preparePortDataPOD()
        Try
            arrPodId1 = New ArrayList
            arrPodName1 = New ArrayList
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterList(pPortMaster)
                arrPodId.Add(obj.PortId)
                arrPodName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareCHA(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lstCHA As DropDownList = sender
            lstCHA.Items.Clear()
            lstCHA.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrCHAId.Count - 1
                lstCHA.Items.Add(New ListItem(arrCHAName(i), arrCHAId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub prepareCHAData()
        Try
            arrCHAId = New ArrayList
            arrCHAName = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.CustomerType = "C"
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterCostList(pCustomerMaster)
                arrCHAId.Add(obj.CustomerId)
                arrCHAName.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareCustomer(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrCustomerId.Count - 1
                lst.Items.Add(New ListItem(arrCustomerName(i), arrCustomerId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub prepareCustomerData()
        Try
            arrCustomerId = New ArrayList
            arrCustomerName = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerName.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrTerminalId.Count - 1
                lst.Items.Add(New ListItem(arrTerminalName(i), arrTerminalId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
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

    Sub prepareTerminalData()
        Try
            arrTerminalId = New ArrayList
            arrTerminalName = New ArrayList
            Dim pTerminalMaster As New TerminalMaster
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                arrTerminalId.Add(obj.TerminalId)
                arrTerminalName.Add(obj.TerminalName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindData()
        preparePortData()
        prepareTerminalData()
        prepareCustomerData()
        preparePortDataPOD()
        prepareCHAData()



        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & LstLine.SelectedValue & ""
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EDI_REPORT_TEST", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If

        dbr.Close()
        db.CloseDB()
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            lstCFS.DataTextField = "TerminalName"
            lstCFS.DataValueField = "TerminalId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0

            Dim pPortMaster As New PortMaster
            lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            lstPod.DataTextField = "PortName"
            lstPod.DataValueField = "PortId"
            lstPod.DataBind()
            lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPod.SelectedValue = 0

            Dim pCustomerMaster As New CustomerMaster
            lstShipping.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            lstShipping.DataTextField = "CustomerName"
            lstShipping.DataValueField = "CustomerId"
            lstShipping.DataBind()
            lstShipping.Items.Insert(0, (New ListItem("---All---", 0)))
            lstShipping.SelectedValue = 0
            Dim pCustomerMaster1 As New CustomerMaster
            LstLine.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster1)
            LstLine.DataTextField = "CustomerName"
            LstLine.DataValueField = "CustomerId"
            LstLine.DataBind()
            LstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            LstLine.SelectedValue = 0


        Catch ex As Exception
        End Try
    End Sub
    Sub lstlinebind()
        Try
            arrCustomerId = New ArrayList
            arrCustomerId = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerId.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' preparePortData()
            ListControlDataBind()
            prepareTerminalData()
            preparePortData()
            prepareCustomerData()
            prepareCHAData()
            preparePortDataPOD()
            If Session.Item("LstLine") <> "" Then
                LstLine.SelectedValue = Session.Item("LstLine")
                Session.Add("LstLine", "")
            End If
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= "," & LstLine.SelectedValue & ""
            'strpParms &= 0
            'strpParms &= "," & 0
            'strpParms &= "," & 0 & ""
            ''strpParms &= ",'" & textFromDate.Text & "'"
            'strpParms &= ",'" & textToDate.Text & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EDI_REPORT_TEST", strpParms)
            gvtripPendencyList.DataSource = dbr
            gvtripPendencyList.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
            Me.Cache("SaveClicked") = "N"
        End If

    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        BindData()

    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    intCounter = intCounter + 1
        '    e.Row.Cells(0).Text = intCounter
        'End If
    End Sub
    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvtripPendencyList.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                End If
            Next
        End If
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim HdnContJOId As HiddenField = TryCast(row.Cells(0).FindControl("HdnContJOId"), HiddenField)
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim hdnCFSId As HiddenField = TryCast(row.Cells(0).FindControl("hdnCFSId"), HiddenField)
                    '  Dim Lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("Lstcfs"), DropDownList)
                    Dim TextConsignee As TextBox = TryCast(row.Cells(0).FindControl("TextConsignee"), TextBox)
                    Dim TextNotify As TextBox = TryCast(row.Cells(0).FindControl("TextNotify"), TextBox)
                    Dim TextConsignor As DropDownList = TryCast(row.Cells(0).FindControl("TextConsignor"), DropDownList)
                    Dim TxtGrossWeight As TextBox = TryCast(row.Cells(0).FindControl("TxtGrossWeight"), TextBox)
                    Dim TextWeight As TextBox = TryCast(row.Cells(0).FindControl("TextWeight"), TextBox)
                    Dim textRefId As TextBox = TryCast(row.Cells(0).FindControl("textRefId"), TextBox)
                    Dim TextHeathNo As TextBox = TryCast(row.Cells(0).FindControl("TextHeathNo"), TextBox)
                    Dim lslPackageType As DropDownList = TryCast(row.Cells(0).FindControl("lslPackageType"), DropDownList)
                    Dim TextPacket As TextBox = TryCast(row.Cells(0).FindControl("TextPacket"), TextBox)
                    Dim TextPartyInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoiceNO"), TextBox)
                    Dim TextPartyInvoicedate As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoicedate"), TextBox)
                    Dim TextSbNo As TextBox = TryCast(row.Cells(0).FindControl("TextSbNo"), TextBox)
                    Dim TextSbDate As TextBox = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox)
                    Dim LstConsignmentType As DropDownList = TryCast(row.Cells(0).FindControl("LstConsignmentType"), DropDownList)
                    Dim LstCommodityName As DropDownList = TryCast(row.Cells(0).FindControl("LstCommodityName"), DropDownList)
                    Dim TextFobValue As TextBox = TryCast(row.Cells(0).FindControl("TextFobValue"), TextBox)
                    Dim lstPod As DropDownList = TryCast(row.Cells(0).FindControl("lstPod"), DropDownList)
                    Dim LstCHA As DropDownList = TryCast(row.Cells(0).FindControl("lstCHA"), DropDownList)
                    Dim clTextPartyInvoicedate = TryCast(row.Cells(0).FindControl("clTextPartyInvoicedate"), CalendarExtender)
                    clTextPartyInvoicedate.EndDate = DateTime.Now.Date
                    Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
                    clRailOutdate1.EndDate = DateTime.Now.Date
                    Dim DAY As Long = 0
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),NVL(CFS_ID,0),PORT,POL,CFS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                    ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                    'Try
                    '    Lstpol.SelectedValue = ada.GetValue(0)
                    'Catch ex As Exception
                    'End Try
                    Try
                        lstPod.SelectedValue = ada.GetValue(1)
                    Catch ex As Exception
                    End Try
                    Try
                        lstCFS.SelectedValue = ada.GetValue(2)
                    Catch ex As Exception
                    End Try

                End If
            End If
        Next
        Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
                    row.Cells(i).FindControl("lblConsignor").Visible = Not isChecked
                    row.Cells(i).FindControl("lblConsignee").Visible = Not isChecked
                    row.Cells(i).FindControl("lblNotify").Visible = Not isChecked
                    row.Cells(i).FindControl("lblFobValue").Visible = Not isChecked
                    row.Cells(i).FindControl("lblGrossWt").Visible = Not isChecked
                    row.Cells(i).FindControl("lblWeight").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRefId").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPacket").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPackageType").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPartyInvocieNO").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPartyInvoiceDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSbNO").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSbDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblConsignmentType").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCHA").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblCFS").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPort").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCommodityName").Visible = Not isChecked
                    row.Cells(i).FindControl("lblHealthNo").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblCfs").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblConsignmentType").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
                    '  row.Cells(i).FindControl("lblTransitTime").Visible = Not isChecked
                    '  row.Cells(i).FindControl("lblPortArrival").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblCutOfDate").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblLINE_HANDOVER_DATE").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
                    'row.Cells(i).FindControl("txtTrainNo").Visible = Not isChecked
                    'row.Cells(i).FindControl("txtOutDate").Visible = Not isChecked

                    If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
                    End If
                    If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    End If
                    'If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                    '    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    'End If
                    If isChecked AndAlso Not isUpdateVisible Then
                        isUpdateVisible = True
                    End If
                    If Not isChecked Then
                        chkAll.Checked = False
                    End If
                Next
            End If
        Next
        Button3.Visible = isUpdateVisible
        Me.Cache("SaveClicked") = "N"
    End Sub
    <WebMethod()>
    Public Shared Function GetConsignee(ByVal prefix As String) As String()
        Dim customers As New List(Of String)()
        Using conn As New OleDbConnection()
            ' Dim con As OleDbConnection
            conn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            'conn.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            Using cmd As New OleDbCommand()
                cmd.CommandText = "SELECT DISTINCT CUSTOMER_NAME, CUSTOMER_ID FROM CUSTOMER_MASTER WHERE CUSTOMER_NAME LIKE UPPER('" + prefix + "%') AND CUSTOMER_TYPE='P'"
                'cmd.CommandText = "select customer_Name, customer_id from Customer_master where customer_Name like "
                'cmd.Parameters.AddWithValue("@SearchText", prefix)
                cmd.Connection = conn
                conn.Open()
                Using sdr As OleDbDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(String.Format("{0}-{1}", sdr("CUSTOMER_NAME"), sdr("CUSTOMER_ID")))
                    End While
                End Using
                conn.Close()
            End Using
        End Using
        Return customers.ToArray()
    End Function
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim saveClickedStatus = Me.Cache("SaveClicked").ToString()

        'If saveClickedStatus.Equals("Y") Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
        '                                                     "If you have reloaded the page  then you will have to relogin fresh EDI page.")
        '    Return
        'End If

        'If Not String.IsNullOrEmpty(hdnClickCount.Value) Or hdnClickCount.Value.Equals("0") Then
        '    Return
        'End If

        Dim mainObj As New EdiUpdateAllPartyAccout
        Dim temp As New List(Of EdiUpdateAllPartyAccout)
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim HdnContJOId As HiddenField = TryCast(row.Cells(0).FindControl("HdnContJOId"), HiddenField)
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim hdnCFSId As HiddenField = TryCast(row.Cells(0).FindControl("hdnCFSId"), HiddenField)
                    Dim TextConsignee As TextBox = TryCast(row.Cells(0).FindControl("TextConsignee"), TextBox)
                    Dim TextNotify As TextBox = TryCast(row.Cells(0).FindControl("TextNotify"), TextBox)
                    Dim TextConsignor As DropDownList = TryCast(row.Cells(0).FindControl("TextConsignor"), DropDownList)
                    Dim TxtGrossWeight As TextBox = TryCast(row.Cells(0).FindControl("TxtGrossWeight"), TextBox)
                    Dim TextWeight As TextBox = TryCast(row.Cells(0).FindControl("TextWeight"), TextBox)
                    Dim textRefId As TextBox = TryCast(row.Cells(0).FindControl("textRefId"), TextBox)
                    Dim TextHeathNo As TextBox = TryCast(row.Cells(0).FindControl("TextHeathNo"), TextBox)
                    Dim lslPackageType As DropDownList = TryCast(row.Cells(0).FindControl("lslPackageType"), DropDownList)
                    Dim TextPacket As TextBox = TryCast(row.Cells(0).FindControl("TextPacket"), TextBox)
                    Dim TextPartyInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoiceNO"), TextBox)
                    Dim TextPartyInvoicedate As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoicedate"), TextBox)
                    Dim TextSbNo As TextBox = TryCast(row.Cells(0).FindControl("TextSbNo"), TextBox)
                    Dim TextSbDate As TextBox = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox)
                    Dim LstConsignmentType As DropDownList = TryCast(row.Cells(0).FindControl("LstConsignmentType"), DropDownList)
                    Dim LstCommodityName As DropDownList = TryCast(row.Cells(0).FindControl("LstCommodityName"), DropDownList)
                    '   Dim lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("lstcfs"), DropDownList)
                    Dim TextFobValue As TextBox = TryCast(row.Cells(0).FindControl("TextFobValue"), TextBox)
                    Dim lblJobValue As Label = TryCast(row.Cells(0).FindControl("lblJobNo"), Label)

                    Dim LstCHA As DropDownList = TryCast(row.Cells(0).FindControl("LstCHA"), DropDownList)
                    Dim Lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("Lstcfs"), DropDownList)
                    Dim lstPod As DropDownList = TryCast(row.Cells(0).FindControl("lstPod"), DropDownList)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                    Dim lblJobNo As Label = TryCast(row.Cells(0).FindControl("lblJobNo"), Label)
                    Dim lblJobDate As Label = TryCast(row.Cells(0).FindControl("lblJobDate"), Label)

                    If hdnMTY_CONT_ID.Value = 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Select Container No.")
                        Return
                    End If
                    If Session.Item("LoginTerminal") <> 7 AndAlso Session.Item("LoginTerminal") <> 29 Then
                        If TextSbNo.Text = Nothing Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter SB No.")
                            Functions.ControlFocus(TextSbNo)
                            Return
                        End If
                        If TextConsignee.Text = Nothing Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter Consignee Name.")
                            Functions.ControlFocus(TextConsignee)
                            Return
                        End If
                        Try
                            Dim pFleetContjoDtls As New FleetContJoDtls
                            pFleetContjoDtls.TerminalId = Session.Item("LoginTerminal")
                            pFleetContjoDtls.MtyContId = hdnMTY_CONT_ID.Value
                            pFleetContjoDtls = FleetContJoDtls.ReturnFleetContJoDtls(pFleetContjoDtls)

                            Try
                                If pFleetContjoDtls.CargoWt < TxtGrossWeight.Text Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                                        "Please Check Commodity Cross Weight.")
                                    Functions.ControlFocus(TxtGrossWeight)
                                    Return
                                End If

                            Catch ex As Exception

                            End Try

                        Catch ex As Exception
                        End Try
                        If TextNotify.Text = Nothing Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter Notify Party Name.")
                            Functions.ControlFocus(TextNotify)
                            Return
                        End If
                        If TextSbDate.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter SB Date.")
                            Functions.ControlFocus(TextSbDate)
                            Return
                        End If
                        If TextPartyInvoicedate.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter Shipper Invoice  Date.")
                            Functions.ControlFocus(TextSbDate)
                            Return
                        End If
                        If TextSbDate.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Enter SB Date.")
                            Functions.ControlFocus(TextSbDate)
                            Return
                        End If
                        If TxtGrossWeight.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please fill Commodity Gross Wt.")
                            Functions.ControlFocus(TxtGrossWeight)
                            Return
                        End If
                        If TextWeight.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please fill Commodity Net Wt.")
                            Functions.ControlFocus(TextWeight)
                            TextWeight.Focus()
                            Return
                        End If
                        If TextFobValue.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please fill FOB Value.")
                            Functions.ControlFocus(TextWeight)
                            TextFobValue.Focus()
                            Return
                        End If
                        If textRefId.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please Fill REF ID Value.")
                            Functions.ControlFocus(textRefId)
                            textRefId.Focus()
                            Return
                        End If
                        'If TextHeathNo.Text = "" Then
                        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                        '                                     "Please fill Helth  Cert.No.")
                        '    Functions.ControlFocus(TextWeight)
                        '    TextHeathNo.Focus()
                        '    Return
                        'End If
                        Try
                            If GetDateTime(TextPartyInvoicedate.Text) > GetDateTime(TextSbDate.Text) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                                        "Shipping bill date will not less than Shipper Invoice date.")
                                Functions.ControlFocus(TextPartyInvoicedate)
                                Return
                            End If

                        Catch ex As Exception

                        End Try

                        If TextWeight.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                             "Please fill Commodity Net Wt.")
                            Functions.ControlFocus(TextWeight)
                            Return
                        End If

                        'If Lstcfs.SelectedValue = "0" Then
                        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                        '                                 "Please Select CFS.")
                        '    Functions.ControlFocus(Lstcfs)
                        '    Return
                        'End If
                        If LstCHA.SelectedValue = "0" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                         "Please Select CHA.")
                            Functions.ControlFocus(LstCHA)
                            Return
                        End If
                        If lstPod.SelectedValue = "0" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                         "Please Select POD.")
                            Functions.ControlFocus(lstPod)
                            Return
                        End If
                        If LstCommodityName.SelectedValue = "0" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                         "Please Select Commodity.")
                            Functions.ControlFocus(LstCommodityName)
                            Return
                        End If
                        If lslPackageType.SelectedValue = "0" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                         "Please Select Package Type.")
                            Functions.ControlFocus(lslPackageType)
                            Return
                        End If
                        If LstConsignmentType.SelectedValue = "0" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                         "Please Select Consignment Type")
                            Functions.ControlFocus(LstConsignmentType)
                            Return
                        End If
                    Else
                        LstConsignmentType.SelectedValue = "4"
                    End If


                    Dim p As New EdiUpdateAllPartyAccout
                    p.ConsignerName = TextConsignor.SelectedItem.Text
                    p.ConsigerId = TextConsignor.SelectedValue
                    p.ConsignmentType = LstConsignmentType.SelectedItem.Text
                    p.ConsignmentTypeId = LstConsignmentType.SelectedValue
                    p.CommodityName = LstCommodityName.SelectedItem.Text
                    p.CommodityId = LstCommodityName.SelectedValue
                    p.NotifyParty = TextNotify.Text.Trim
                    p.ShipperName = TextConsignee.Text.Trim
                    p.ConsigneeName = TextConsignee.Text.Trim
                    p.Port = lstPod.SelectedItem.Text
                    p.PodId = lstPod.SelectedValue
                    p.PartyInvoiceNo = TextPartyInvoiceNO.Text.Trim
                    Try
                        p.FobValue = TextFobValue.Text.Trim
                    Catch ex As Exception
                    End Try
                    p.HeathNo = TextHeathNo.Text.Trim
                    p.CARTONS = TextPacket.Text.Trim
                    p.PackageType = lslPackageType.SelectedItem.Text
                    p.NetWt = TextWeight.Text.Trim
                    p.GrossWeight = TxtGrossWeight.Text.Trim
                    p.PackageTypeId = lslPackageType.SelectedValue
                    p.CfsId = Convert.ToInt64(hdnCFSId.Value)
                    'p.Cfs = Lstcfs.SelectedItem.Text
                    p.JobNumber = strJob.Trim
                    p.JobDate = ""
                    p.RefId = textRefId.Text.Trim
                    p.CreatedBy = Session.Item("LoginUser")
                    p.PartyInvoicedate = TextPartyInvoicedate.Text
                    p.ChaId = LstCHA.SelectedValue
                    p.CHA = LstCHA.SelectedItem.Text
                    p.SbNo = TextSbNo.Text
                    p.SbDate = TextSbDate.Text
                    p.JobNumber = lblJobNo.Text
                    p.MtyContId = Convert.ToInt64(hdnMTY_CONT_ID.Value)
                    p.ContJoId = Convert.ToInt64(HdnContJOId.Value)

                    temp.Add(p)

                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                    hdnMTY_CONT_ID.Value = 0
                End If
            End If
        Next

        mainObj.AllPartyList = temp
        EdiUpdateAllPartyAccout.UpdateJOForTransaction(mainObj)

        ' hdnClickCount.Value = "1"
        Button4.Visible = True
        BindData()
        Me.Cache("SaveClicked") = "Y"
        'MsgBox(checkedRowCount & " :Records " & "Update Successfully", MsgBoxStyle.Information, "Update Records")
        Session.Add("LstLine", LstLine.SelectedValue)
        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully '); window.location ='EDIUpdate.aspx';"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)


        'Response.Redirect(Request.Url.AbsoluteUri)

    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
End Class
