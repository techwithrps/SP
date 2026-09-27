Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_DSRReportShipmentWise
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            ListControlDataBind()

            'Dim strCurrentDate As String
            'strCurrentDate = Format(Now, "MM/dd/yyyy")
            'textFromDate.Text = Format(Now, "dd/MM/yyyy")
            'textToDate.Text = Format(Now, "dd/MM/yyyy")
            'Dim strpParms As String = ""
            'strpParms &= Session.Item("LoginTerminal")
            'strpParms &= ",'" & textFromDate.Text & "'"
            'strpParms &= ",'" & textToDate.Text & "'"
            'strpParms &= ",'" & lstLine.SelectedValue & "'"
            'strpParms &= "," & lstCustomer.SelectedValue & ""
            'strpParms &= "'" & lstLine.SelectedValue & "'"
            'Dim dbr As OleDb.OleDbDataReader
            'Dim db As New DBConnect
            'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DSR_REPORT", strpParms)
            'gvGRDetails.DataSource = dbr
            'gvGRDetails.DataBind()
            'If dbr.HasRows Then
            '    tblReport.Visible = True
            'Else
            '    tblReport.Visible = False
            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            'End If
            'dbr.Close()
            'db.CloseDB()
        End If

    End Sub
    Protected Sub Check_UnCheckAll(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstCustomer.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAll.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub Check_UnCheckAllPort(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstPort.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllPort.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub Check_UnCheckAllTerMinal(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstTerminalName.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllNew.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub CheckBox_Checked_Unchecked(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As ListItem In lstTerminalName.Items
            If Not item.Selected Then
                isAllChecked = False
                Exit For
            End If
        Next

        chkAll.Checked = isAllChecked
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
    Sub ListControlDataBind()
        Dim pCustomerMaster As New CustomerMaster
        lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        ' lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
        lstCustomer.Items.Insert(0, (New ListItem("---Select", 0)))
        lstCustomer.SelectedValue = 0
        Dim pPortMaster As New PortMaster
        lstPort.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
        lstPort.DataTextField = "PortName"
        lstPort.DataValueField = "PortId"
        lstPort.DataBind()
        lstPort.Items.Insert(0, (New ListItem("---All---", 0)))
        lstPort.SelectedValue = 0
        Dim pLine As New CustomerMaster
        lstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pLine)
        lstLine.DataTextField = "CustomerName"
        lstLine.DataValueField = "CustomerId"
        lstLine.DataBind()
        lstLine.Items.Insert(0, (New ListItem("---All---", 0)))
        lstLine.SelectedValue = 0
        Dim pTerminalMaster As New TerminalMaster
        lstTerminalName.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstTerminalName.DataTextField = "TerminalName"
        lstTerminalName.DataValueField = "TerminalId"
        lstTerminalName.DataBind()
        lstTerminalName.Items.Insert(0, (New ListItem("---Select", 0)))
        lstTerminalName.SelectedValue = 0
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvGRDetails.DataSource = Nothing
        gvGRDetails.DataBind()
        '  ListControlDataBind()
        tblReport.Visible = False
        If textFromDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        ' strpParms &= "," & lstCustomer.SelectedValue & ""
        strpParms &= ",'" & lstLine.SelectedValue & "'"

        Dim str As [String] = ""
        For i As Integer = 0 To lstCustomer.Items.Count - 1

            If lstCustomer.Items(i).Selected Then

                If str = "" Then
                    str = "'" & lstCustomer.Items(i).Value
                Else

                    str += "," + lstCustomer.Items(i).Value

                End If
            End If
        Next
        strpParms &= "," + str & "'"

        Dim strPort As [String] = ""
        For i As Integer = 0 To lstPort.Items.Count - 1

            If lstPort.Items(i).Selected Then

                If strPort = "" Then
                    strPort = "'" & lstPort.Items(i).Value
                Else

                    strPort += "," + lstPort.Items(i).Value

                End If
            End If
        Next


        'End
        'strpParms &= "," + terminalId.TrimEnd(CType(",", Char))        'Commented 16/12/2022
        strpParms &= "," + strPort & "'"

        Dim strTerminal As [String] = ""
        For i As Integer = 0 To lstTerminalName.Items.Count - 1

            If lstTerminalName.Items(i).Selected Then

                If strTerminal = "" Then
                    strTerminal = "'" & lstTerminalName.Items(i).Value
                Else

                    strTerminal += "," + lstTerminalName.Items(i).Value

                End If
            End If
        Next

        'End
        'strpParms &= "," + terminalId.TrimEnd(CType(",", Char))        'Commented 16/12/2022
        strpParms &= "," + strTerminal & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DSR_REPORT_SHIP", strpParms)
        gvGRDetails.DataSource = dbr
        gvGRDetails.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvGRDetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvGRDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Functions.ExportToCSV(Me.Page, gvGRDetails)
    End Sub

End Class
