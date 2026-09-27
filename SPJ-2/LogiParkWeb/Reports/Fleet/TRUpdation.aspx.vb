Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Partial Class Reports_Fleet_TRUpdation
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrCustomerId As ArrayList
    Dim arrCustomerName As ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
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
            For Each obj As PortMaster In PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
                arrPortId.Add(obj.PortId)
                arrPortName.Add(obj.PortName)
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
        Dim strday, strtime, arrdate, Day, Month, Year, arrtime, Hour, Minute, FinalDate

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
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        ' strpParms &= 
        strpParms &= "," & 0
        strpParms &= "," & 0 & ",'','','P'"



        'Dim strpParms As String = ""
        'strpParms &= Session.Item("LoginTerminal")
        '' strpParms &= LstLine.SelectedValue
        ''prepareTerminalData()
        'strpParms &= "," & lstPol.SelectedValue
        'strpParms &= "," & lstPod.SelectedValue & ",'','','P'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TR_UPDATION", strpParms)
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
    Sub lstlinebind()
        Try
            arrCustomerId = New ArrayList
            arrCustomerId = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerId.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            prepareTerminalData()
            preparePortData()
            'ListControlDataBind()
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            ' strpParms &= 
            strpParms &= "," & 0
            strpParms &= "," & 0 & ",'','','P'"
            'strpParms &= ",'" & textFromDate.Text & "'"
            'strpParms &= ",'" & textToDate.Text & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TR_UPDATION", strpParms)
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
            Button3.Visible = False
        End If

    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
        End If

    End Sub


    'Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim isUpdateVisible As Boolean = False
    '    Dim chk As CheckBox = TryCast(sender, CheckBox)
    '    If chk.ID = "chkAll" Then
    '        For Each row As GridViewRow In gvtripPendencyList.Rows
    '            If row.RowType = DataControlRowType.DataRow Then
    '                row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
    '            End If
    '        Next
    '    End If
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
    '                Dim TxtTRHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtTRHandover"), TextBox)
    '                Dim TextVGMWt As TextBox = TryCast(row.Cells(0).FindControl("TextVGMWt"), TextBox)

    '                Dim DAY As Long = 0
    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = "SELECT nvl(POL_ID,0),POL FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader
    '                ada.Read()
    '            End If
    '        End If
    '    Next
    '    Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
    '    chkAll.Checked = True
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                row.Cells(i).FindControl("lblTRDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblVGMWt").Visible = Not isChecked


    '                If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                End If
    '                'If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                '    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                'End If
    '                If isChecked AndAlso Not isUpdateVisible Then
    '                    isUpdateVisible = True
    '                End If
    '                If Not isChecked Then
    '                    chkAll.Checked = False
    '                End If
    '            Next
    '        End If
    '    Next
    '    Button3.Visible = isUpdateVisible
    'End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TextVGMWt As TextBox = TryCast(row.Cells(0).FindControl("TextVGMWt"), TextBox)
                    Dim TxtTRHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtTRHandover"), TextBox)
                    'If TxtRequiredETA.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                    '    Functions.ControlFocus(TxtRequiredETA)
                    '    Return
                    'End If
                    'If TxtTRHandover.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill TR Date.")
                    '    Functions.ControlFocus(TxtTRHandover)
                    '    Return
                    'End If
                    'If TextVGMWt.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill VGM Wt.")
                    '    Functions.ControlFocus(TextVGMWt)
                    '    Return
                    'End If

                    'If Not String.IsNullOrEmpty(TxtTRHandover.Text) Then
                    '    If GetDateTime(TxtTRHandover.Text.Trim()) >= DateTime.Now Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                    '        Functions.ControlFocus(TxtTRHandover)
                    '        Return
                    '    End If
                    'End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TR_UPDATION_ON=SYSDATE,TR_UPDATION_BY='" & Session.Item("LoginUser") & "', TR_HANDOVER_DATE=TO_DATE('" & TxtTRHandover.Text & "','DD/MM/YYYY HH24:MI'),VGM_WT='" & TextVGMWt.Text.Trim & "'  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        Dim p99 As String = ex.Message
                    End Try

                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        Button4.Visible = True
        Button3.Visible = False
        linkDownload.Visible = True
        btnUpload.Visible = True
        LoadFileLocation.Visible = True
        lblFileUpload.Visible = True
        BindData()
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    '=============for download format with data in csv file create by arjun negi On 19 june 2025 As per request akshay====================
    Private Sub linkDownload_Click(sender As Object, e As EventArgs) Handles linkDownload.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "TRUpdation.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()

            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            ' Header title
            strb.Append(lblScreenTitle.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            ' Column Headers
            Dim strContHeader As String = "Sr.No." & strComa & "Cont Number" & strComa & "Shipper" & strComa & "S/Line" & strComa & "CFS" & strComa & "Line Handover" & strComa & "TR Handover" & strComa & "VGM Wt."
            strb.Append(strContHeader & vbCrLf)

            If gvtripPendencyList.Rows.Count > 0 Then
                Dim srno As Integer = 1
                For Each r As GridViewRow In gvtripPendencyList.Rows
                    Dim strRow As New StringBuilder()

                    ' Sr No
                    strRow.Append(srno.ToString() & strComa)
                    srno += 1

                    ' for Container No
                    strRow.Append(GetControlText(r, "lblContNo") & strComa)

                    ' for Shipper
                    strRow.Append(GetControlText(r, "lblConsignorName") & strComa)

                    ' for S/Line
                    strRow.Append(GetControlText(r, "lblLine") & strComa)

                    ' for CFS (from Label)
                    strRow.Append(GetControlText(r, "lblCFS") & strComa)

                    ' for Custom Handover
                    'strRow.Append(GetControlText(r, "lblCustomerHandoverDate") & strComa)

                    ' Line Handover (Label in TemplateField)
                    strRow.Append(GetControlText(r, "lblLineHandover") & strComa)

                    ' TR Handover (either Label or TextBox)
                    strRow.Append(GetControlText(r, "lblTRDate") & strComa)

                    ' VGM Wt. (either Label or TextBox)
                    strRow.Append(GetControlText(r, "lblVGMWt") & strComa)

                    strb.Append(strRow.ToString() & vbCrLf)
                Next
            End If

            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()

        Catch ex As Exception
            ' Handle exception (optional logging)
        End Try


    End Sub
    Private Function GetControlText(row As GridViewRow, controlID As String) As String
        Dim ctrl As Control = row.FindControl(controlID)
        If ctrl IsNot Nothing Then
            If TypeOf ctrl Is Label Then
                Return CType(ctrl, Label).Text.Trim().Replace(",", " ")
            ElseIf TypeOf ctrl Is TextBox Then
                Return CType(ctrl, TextBox).Text.Trim().Replace(",", " ")
            ElseIf TypeOf ctrl Is HiddenField Then
                Return CType(ctrl, HiddenField).Value.Trim().Replace(",", " ")
            End If
        End If
        Return ""
    End Function

    '===========FOR UPLOADING DATA CSV FILE INTO REPETER =====================
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim FileStatus As Boolean
        FileStatus = VerifyFileType(Path.GetExtension(LoadFileLocation.FileName))
        If FileStatus = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "System only allow .csv extension type of file")
            Functions.ControlFocus(LoadFileLocation)
            Return
        End If
        If LoadFileLocation.HasFile <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select file.")
            Return
        Else
            If gvtripPendencyList.Rows.Count > 0 Then
                Dim index As Long
                Try
                    Dim folderPath As String = Server.MapPath("~/Content/TRUpdationFileData/")
                    If Not Directory.Exists(folderPath) Then
                        Directory.CreateDirectory(folderPath)
                    End If
                    'Dim filename As String = DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv"
                    Dim filename As String = "TRUpdation" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".csv"
                    LoadFileLocation.SaveAs(folderPath & filename)
                    Dim folder As String = Server.MapPath("~/Content/TRUpdationFileData/")
                    Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
                    Dim dtt As New DataTable
                    hdnfileName.Value = filename
                    hdnFolder.Value = folder
                    Using Adp As New OleDbDataAdapter("select * from " & filename, CnStr)
                        Adp.Fill(dtt)
                    End Using
                    If dtt.Rows.Count > 0 Then
                        For Each row As DataRow In dtt.Rows
                            Dim contNoFromCsv As String = row.ItemArray(1).ToString().Trim().ToUpper()
                            For Each item As GridViewRow In gvtripPendencyList.Rows
                                Dim lblContNo As Label = CType(item.FindControl("lblContNo"), Label)
                                If lblContNo IsNot Nothing AndAlso lblContNo.Text.Trim().ToUpper() = contNoFromCsv Then
                                    Dim txtTR As TextBox = CType(item.FindControl("TxtTRHandover"), TextBox)

                                    If txtTR IsNot Nothing Then
                                        Try
                                            Dim TRdate1 As Date = row.ItemArray(6).ToString()
                                            txtTR.Text = TRdate1.ToString("dd/MM/yyyy")
                                            txtTR.Style("display") = "inline"
                                        Catch ex As Exception
                                            txtTR.Text = ""
                                            txtTR.Style("display") = "none"
                                        End Try

                                    End If
                                    Dim txtVGM As TextBox = CType(item.FindControl("TextVGMWt"), TextBox)
                                    If txtVGM IsNot Nothing Then
                                        Try
                                            txtVGM.Text = row.ItemArray(7).ToString().Trim()
                                            txtVGM.Style("display") = "inline"
                                        Catch ex As Exception

                                        End Try
                                    End If
                                    Dim chkBox As CheckBox = CType(item.FindControl("CheckBox1"), CheckBox)
                                    If txtVGM.Text = "" AndAlso txtTR.Text = "" Then
                                        'If chkBox IsNot Nothing Then
                                        chkBox.Enabled = False
                                        'End If
                                    Else
                                        chkBox.Checked = True
                                    End If
                                End If

                            Next
                            index += 1
                        Next row
                    End If
                Catch ex As Exception
                    Dim P As String = ex.Message
                    'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ckeck row " & index.ToString() - 2 & " and enter value if done you can proceed")
                End Try
            Else
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Search Container First.")
            End If

        End If
        Button3.Visible = True
        linkDownload.Visible = False
        btnUpload.Visible = False
        LoadFileLocation.Visible = False
        lblFileUpload.Visible = False
    End Sub
    Public Shared Function VerifyFileType(ByVal extension As String) As Boolean
        Dim returnStr As Boolean = False
        If extension = ".csv" Or extension = ".CSV" Then
            returnStr = True
        End If
        Return returnStr
    End Function

End Class
