Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO
Partial Class Reports_Note_DrNoteUpdate
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            manageUserControls(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        TextGrno.Enabled = True
        btnSearchGr.Visible = True
        btnSearchGr.Enabled = True
        ButtonControlSetup(True)
        Functions.ControlFocus(TextGrno)
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
    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("MenuId") = row(0).ToString
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchGr.Click
        Dim pDrNote As New DrNote
        pDrNote.DrRefNo = TextGrno.Text.Trim
        DrNote.ReturnCreaditNotebyCrRefNo(pDrNote)
        HdnDrId.Value = pDrNote.DrId
        textjoNo.Enabled = True
        TextGrno.Enabled = False
        btnSave.Visible = True
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "")
        If textjoNo.Text = "" Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Please Enter Balance Amount")
            Functions.ControlFocus(textjoNo)
            Return
        End If
        Dim strConnectionString, CMD51 As String
        Dim con As OleDbConnection
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD51 = " UPDATE DR_NOTE SET BAL_AMT=" & textjoNo.Text.Trim & ",BAL_UP_DATE=SYSDATE, BAL_UP_BY='" & Session.Item("LoginUser") & "' WHERE DR_ID=" & HdnDrId.Value
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd55 As New OleDbCommand(CMD51, con)
            cmd55.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        'Try
        '    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        '    CMD101 = " Insert into MAINTENANCE (D_TRACK_ID, CONT_NO, MTY_CONT_ID, ICD_OUT, FACTORY_IN,FACTORY_OUT, ICD_IN, HANDOVER_DATE, PARTY_INV_NO, PARTY_INV_DATE,BL_NO, BOOKING_NO, CFS_ID, CFS, LINE_ID, " _
        '             & " LINE, POL_ID, POL, FPOD_ID, FPOD, BILL_TO_ID, BILL_TO, SHIPEMENT_STATUS, CONSIGNMENT_TYPE, ALL_PARTY_CONSIGNOR_ID, ALL_PARTY_CONSIGNOR, CREATED_BY, CREATED_ON, REMARK_ID) " _
        '             & " VALUES (D_TRACK_ID.NEXTVAL,'" & TextGrno.Text.Trim & "','" & hdnMtyContId.Value & "',NVL(TO_DATE('" & textOutDaTe.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
        '             & " NVL(TO_DATE('" & TextFInDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextFOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextIcdIn.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
        '             & " NVL(TO_DATE('" & TextHandOverDate.Text.Trim & "','DD/MM/YYYY'),''),'" & TextPInvNo.Text.Trim & "',NVL(TO_DATE('" & TextPDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextBlNO.Text.Trim & "','" & TextBookingNO.Text.Trim & "', " _
        '             & " " & lstcfs.SelectedValue & ",'" & lstcfs.SelectedItem.Text & "'," & lstline.SelectedValue & ",'" & lstline.SelectedItem.Text & "'," & lstPol.SelectedValue & ",'" & lstPol.SelectedItem.Text & "', " _
        '             & " " & LstFOD.SelectedValue & ",'" & LstFOD.SelectedItem.Text & "'," & LstBillTo.SelectedValue & ",'" & LstBillTo.SelectedItem.Text & "','" & lststatus.SelectedItem.Text & "', " _
        '             & " '" & lstConsignmentType.SelectedItem.Text & "'," & LstConsignor.SelectedValue & ",'" & LstConsignor.SelectedItem.Text & "','" & Session.Item("LoginUser") & "',sysdate, '" & LstRemark.SelectedValue & "') "
        '    ''Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
        '    con = New OleDbConnection(strConnectionString)
        '    con.Open()
        '    Dim cmd5 As New OleDbCommand(CMD101, con)
        '    cmd5.ExecuteNonQuery()
        '    con.Close()
        'Catch ex As Exception

        'End Try
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        'tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
