Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.Net
Imports System.IO
Partial Class Fleet_VehicleStatus
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        Permission(p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListGridDataBind()
        End If
    End Sub

    Sub Permission(ByVal P As String)
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("~/MenuXml.xml"), New XmlReaderSettings())
        Dim ds2 As New DataSet
        ds2.ReadXml(xmlFile)
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        If dv.ToTable.Rows.Count > 0 Then
            For Each row As DataRow In dv.ToTable.Rows
                Session.Item("Add") = row(7).ToString
                Session.Item("Edit") = row(8).ToString
                Session.Item("Delete") = row(9).ToString
                Session.Item("Search") = row(10).ToString
                Session.Item("Title") = row(4).ToString
            Next
        Else
            Response.Redirect("~/Restriction.aspx")
        End If

    End Sub

    Sub ListGridDataBind()

        repVehicleStatus.DataSource = Nothing
        repVehicleStatus.DataBind()

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & Session.Item("CompanyId") & ""
        strpParms &= "," & lstFilter.SelectedValue & ""
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VEHICLE_RUNNING_POSITION", strpParms)
        repVehicleStatus.DataSource = dbr
        repVehicleStatus.DataBind()

        dbr.Close()
        db.CloseDB()
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
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True

        Dim dataCount As Integer = 0
        Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)

        For Each repItem As RepeaterItem In repVehicleStatus.Items

            If CType(repItem.FindControl("chkSelect"), CheckBox).Checked Then
                dataCount = dataCount + 1
                If CType(repItem.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Text = Nothing Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Vehicle Out Is Blank.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                If CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text = Nothing Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD Out Date is Blank.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                ElseIf CType(repItem.FindControl("textIcdOutRemarks"), TextBox).Text.Trim = Nothing Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD Out Remarks is Blank.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                If GetDateTime(CType(repItem.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Vehicle Out Date is less than or equal to current Date.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                If GetDateTime(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD Out Date is less than or equal to current Date.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                '-------------------

                If GetDateTime(CType(repItem.FindControl("textAllotmentDate"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text.Trim()) Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Allotment Date is less than or equal to the ICD Out Date.")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If

                If CType(repItem.FindControl("hdnTransporterId"), HiddenField).Value <> "109" Then ' Shipper Wise Validation Start

                    If CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> "" Then
                        If GetDateTime(CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text.Trim()) < GetDateTime(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory In Date is more than or equal to the ICD Out Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory In Date is less than or equal to current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If (CType(repItem.FindControl("hdnFactoryInDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnFactoryInDate"), HiddenField)).Value <> "" Then
                        Else
                            If GetDateTime(CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory In Date is more than or equal to yesterday.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                    End If

                    If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> "" Then
                        If CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory Out Date is more than or equal to the Factory In Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory out Date is less than or equal to current Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If (CType(repItem.FindControl("hdnFactoryOutDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnFactoryOutDate"), HiddenField)).Value <> "" Then
                            Else
                                If GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory Out Date is more than or equal to yesterday.")
                                    rtnBool = False
                                    Return rtnBool
                                    Exit Function
                                End If
                            End If
                        Else
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory In Date is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If

                    If CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                        If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer In Date is more than or equal to the Factory Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If GetDateTime(CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer In Date is less than or equal to current Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If (CType(repItem.FindControl("hdnBufferInDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnBufferInDate"), HiddenField)).Value <> "" Then
                            Else
                                If GetDateTime(CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer In Date is more than or equal to yesterday.")
                                    rtnBool = False
                                    Return rtnBool
                                    Exit Function
                                End If
                            End If
                        Else
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory Out Date is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If

                    If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue = "R" AndAlso CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Date is blank")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue = "M" AndAlso CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Date is blank")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue = "E" AndAlso CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "DOC type is  Export  So Please select another DOC Type")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text = Nothing AndAlso CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "DOC Type Is blank")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> "" Then
                        If CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer Out Date Is more than Or equal To the Buffer In Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If GetDateTime(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer out Date Is less than Or equal To current Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If (CType(repItem.FindControl("hdnBufferOutDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnBufferOutDate"), HiddenField)).Value <> "" Then
                            Else
                                If GetDateTime(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer Out Date Is more than Or equal To yesterday.")
                                    rtnBool = False
                                    Return rtnBool
                                    Exit Function
                                End If
                            End If
                        Else
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer In Date Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If

                    If CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                        If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that Empty gate In Date Is less than Or equal To the Current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Empty Gate In Date Is less than Or equal To current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If (CType(repItem.FindControl("hdnEmptyGateInDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnEmptyGateInDate"), HiddenField)).Value <> "" Then
                        Else
                            If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Empty Gate In Date Is more than Or equal To yesterday.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                    End If

                    If CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> "" Then

                        If CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To the Buffer Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            If CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer Out Date Is Blank.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If

                        If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To the Factory Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            'If CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> "" Then
                            If CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text = Nothing Or CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory In Date Is Blank.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            ElseIf CType(repItem.FindControl("textFactoryInRemarks"), TextBox).Text.Trim = Nothing Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory In Remarks is Blank.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If

                        If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To yesterday.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is less than Or equal To current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "T" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "M" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "N" Then
                            If Session.Item("LoginTerminal") <> 7 Then
                                If Session.Item("LoginTerminal") <> 29 Then
                                    If Session.Item("LoginTerminal") <> 5 Then
                                        If String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbNo"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvNo"), HiddenField).Value) Then
                                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
                                            rtnBool = False
                                            Return rtnBool
                                            Exit Function
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> "" Then

                        If CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To the Buffer Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            If CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer Out Date Is Blank.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If

                        ''Added By Amit on 16/04/2026
                        If CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferInRemarks"), TextBox).Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer In Remarks Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        ''Added By Amit on 16/04/2026
                        If CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textBufferOutRemarks"), TextBox).Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer Out Remarks Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To the Factory Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            'If CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> "" Then
                            If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text = Nothing Or CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory Out Date Is Blank.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                        ''Added By Amit on 16/04/2026
                        If CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textFactoryOutRemarks"), TextBox).Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory Out Remarks Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To yesterday.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is less than Or equal To current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        ''Added by Amit on 16/04/2026
                        If CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdInRemarks"), TextBox).Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Icd In Remarks Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If

                        If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "T" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "M" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "N" Then
                            If Session.Item("LoginTerminal") <> 7 Then
                                If Session.Item("LoginTerminal") <> 29 Then
                                    If Session.Item("LoginTerminal") <> 5 Then
                                        If String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbNo"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvNo"), HiddenField).Value) Then
                                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
                                            rtnBool = False
                                            Return rtnBool
                                            Exit Function
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                Else
                    If CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> "" Then
                        If CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "T" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "M" Or CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue <> "N" Then
                            If Session.Item("LoginTerminal") <> 7 Then
                                If Session.Item("LoginTerminal") <> 5 Then
                                    If Session.Item("LoginTerminal") <> 29 Then
                                        If String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbNo"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnSbDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvDate"), HiddenField).Value) Or String.IsNullOrEmpty(CType(repItem.FindControl("hdnInvNo"), HiddenField).Value) Then
                                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
                                            rtnBool = False
                                            Return rtnBool
                                            Exit Function
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> "" Then
                        If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that Empty gate In Date Is less than Or equal To the Current Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                        If (CType(repItem.FindControl("hdnEmptyGateInDate"), HiddenField)).Value <> Nothing AndAlso (CType(repItem.FindControl("hdnEmptyGateInDate"), HiddenField)).Value <> "" Then
                        Else
                            If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Empty Gate In Date Is more than Or equal To yesterday.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                        If GetDateTime(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text.Trim()) < GetDateTime(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text.Trim()) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that Empty gate In Date Is less than Or equal To the ICD Out Date.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If

                    ''Added by Amit on 16/04/2026
                    If CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textEmptyGateInRemarks"), TextBox).Text = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Remarks Remarks Is Blank.")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text <> "" Then
                        If CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text <> Nothing AndAlso CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text <> "" Then
                            If GetDateTime(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text.Trim()) > GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To the ICD Out Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) < currentDt.AddDays(-1) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is more than Or equal To yesterday.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If GetDateTime(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text.Trim()) > DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date Is less than Or equal To current Date.")
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                        Else
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD Out Date Is Blank.")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next

        If dataCount = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Min 1 Container")
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Sub SaveContDetails(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If ValidationCheck() = False Then
            Return
        End If
        Try
            Dim pFleetContJo As New FleetContJoDtls
            For Each repItem As RepeaterItem In repVehicleStatus.Items

                Dim chkSelect = CType(repItem.FindControl("chkSelect"), CheckBox)
                If chkSelect.Checked Then
                    Dim pFleetContJoDtls As New FleetContJoDtls



                    If String.IsNullOrEmpty(CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text) Then
                        pFleetContJoDtls.BufferDate = ""
                    Else
                        pFleetContJoDtls.BufferDate = CType(repItem.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text
                        pFleetContJoDtls.BufferInRemarks = CType(repItem.FindControl("textBufferInRemarks"), TextBox).Text.Trim
                        pFleetContJoDtls.BufferInBy = Session.Item("LoginUser")
                    End If

                    If String.IsNullOrEmpty(CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text) Then
                        pFleetContJoDtls.BufferOutDate = ""
                    Else
                        pFleetContJoDtls.BufferOutDate = CType(repItem.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text
                        pFleetContJoDtls.BufferOutRemarks = CType(repItem.FindControl("textBufferOutRemarks"), TextBox).Text.Trim
                        pFleetContJoDtls.BufferOutBy = Session.Item("LoginUser")
                    End If

                    If String.IsNullOrEmpty(CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text) Then
                        pFleetContJoDtls.EmptyGateInDate = ""
                    Else
                        pFleetContJoDtls.EmptyGateInDate = CType(repItem.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text
                        pFleetContJoDtls.EmptyGateInRemarks = CType(repItem.FindControl("textEmptyGateInRemarks"), TextBox).Text.Trim
                        pFleetContJoDtls.EmptyGateInBy = Session.Item("LoginUser")
                    End If
                    Try
                        If String.IsNullOrEmpty(CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text) Then
                            pFleetContJoDtls.FactoryInDate = ""
                        Else
                            pFleetContJoDtls.FactoryInDate = CType(repItem.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text
                            pFleetContJoDtls.FactoryInRemarks = CType(repItem.FindControl("textFactoryInRemarks"), TextBox).Text.Trim
                            pFleetContJoDtls.FactoryInBy = Session.Item("LoginUser")
                        End If
                    Catch ex As Exception
                        pFleetContJoDtls.FactoryInDate = ""
                    End Try

                    Try
                        If pFleetContJoDtls.FactoryInDate = "Shipper's Transportation" Then
                            pFleetContJoDtls.FactoryInDate = ""
                        End If
                    Catch ex As Exception
                        pFleetContJoDtls.FactoryInDate = ""
                    End Try

                    Try
                        If String.IsNullOrEmpty(CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text) Then
                            pFleetContJoDtls.FactoryOutDate = ""
                        Else
                            pFleetContJoDtls.FactoryOutDate = CType(repItem.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text
                            pFleetContJoDtls.FactoryOutRemarks = CType(repItem.FindControl("textFactoryOutRemarks"), TextBox).Text.Trim
                            pFleetContJoDtls.FactoryOutBy = Session.Item("LoginUser")
                        End If
                    Catch ex As Exception
                        pFleetContJoDtls.FactoryOutDate = ""
                    End Try

                    Try
                        If String.IsNullOrEmpty(CType(repItem.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Text) Then
                            pFleetContJoDtls.VehicleGateOutDate = ""
                        Else
                            pFleetContJoDtls.VehicleGateOutDate = CType(repItem.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Text
                        End If
                    Catch ex As Exception
                        pFleetContJoDtls.VehicleGateOutDate = ""
                    End Try

                    Try
                        If pFleetContJoDtls.FactoryOutDate = "Shipper's Transportation" Then
                            pFleetContJoDtls.FactoryOutDate = ""
                        End If
                    Catch ex As Exception
                        pFleetContJoDtls.FactoryOutDate = ""
                    End Try

                    If String.IsNullOrEmpty(CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text) Then
                        pFleetContJoDtls.IcdInDate = ""
                    Else
                        pFleetContJoDtls.IcdInDate = CType(repItem.FindControl("textIcdIn"), UserControl_DateTimeTextBox).Text
                        pFleetContJoDtls.IcdInRemarks = CType(repItem.FindControl("textIcdInRemarks"), TextBox).Text.Trim
                        pFleetContJoDtls.IcdInBy = Session.Item("LoginUser")
                    End If

                    If String.IsNullOrEmpty(CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text) Then
                        pFleetContJoDtls.IcdOutDate = ""
                    Else
                        pFleetContJoDtls.IcdOutDate = CType(repItem.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text
                        pFleetContJoDtls.IcdOutRemarks = CType(repItem.FindControl("textIcdOutRemarks"), TextBox).Text.Trim
                        pFleetContJoDtls.IcdOutBy = Session.Item("LoginUser")
                    End If

                    pFleetContJoDtls.ContNo = CType(repItem.FindControl("textContNo"), TextBox).Text
                    pFleetContJoDtls.ContJoId = CType(repItem.FindControl("hdnContJoId"), HiddenField).Value
                    pFleetContJoDtls.MtyContId = CType(repItem.FindControl("hdnMtyContId"), HiddenField).Value
                    pFleetContJoDtls.CompanyId = Session.Item("CompanyId")
                    Try
                        pFleetContJoDtls.TripType = CType(repItem.FindControl("lstDocType"), DropDownList).SelectedValue
                    Catch ex As Exception
                    End Try
                    pFleetContJo.ItemDtlsList.Add(pFleetContJoDtls)
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
                End If
            Next
            FleetContJoDtls.UpdateVehicleRunningPosition(pFleetContJo)
            If pFleetContJo.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetContJo.Errormsg)
                Return
            End If
            ListGridDataBind()
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub OnItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles repVehicleStatus.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim item As RepeaterItem = e.Item
            If CType(item.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textIcdOut"), UserControl_DateTimeTextBox).Enabled = False
            End If

            If CType(item.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textVehicleOut"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textFactoryIn"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textFactoryOut"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textBufferInDate"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textBufferOutDate"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Text <> Nothing Then
                CType(item.FindControl("textEmptyGateInDate"), UserControl_DateTimeTextBox).Enabled = False
            End If
            If CType(item.FindControl("hdnTransporterId"), HiddenField).Value = "109" Then

            End If
        End If
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        ListGridDataBind()
    End Sub
End Class