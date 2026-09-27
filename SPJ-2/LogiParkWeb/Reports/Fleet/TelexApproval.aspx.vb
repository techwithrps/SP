Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_TelexApproval
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            BindData()
        End If
    End Sub
    Private Sub BindData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")

        Dim strpParms As String = ""
        strpParms &= "1, '','',"


        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_APPROVAL_REPORT", strpParms)
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


    Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim CheckBox1 As CheckBox = TryCast(row.Cells(0).FindControl("CheckBox1"), CheckBox)

                If CheckBox1.Checked Then
                    Dim MtyContId As HiddenField = TryCast(row.Cells(0).FindControl("hdnMtyContId"), HiddenField)
                    Dim lstTelexStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstTelexStatus"), DropDownList)
                    Dim lstTelexApproval As DropDownList = TryCast(row.Cells(0).FindControl("lstTelexApproval"), DropDownList)
                    Dim textTelexRemarks As TextBox = TryCast(row.Cells(0).FindControl("textTelexRemarks"), TextBox)


                    If textTelexRemarks.Text = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Telex Remarks")
                        Functions.ControlFocus(textTelexRemarks)
                        Return
                    End If

                    If lstTelexStatus.SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Telex Status")
                        Functions.ControlFocus(lstTelexStatus)
                        Return
                    End If

                    If lstTelexApproval.SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Telex Approval")
                        Functions.ControlFocus(lstTelexApproval)
                        Return
                    End If


                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim formattedDate As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

                        Dim cmd As New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET  TELEX_STATUS = " & lstTelexStatus.SelectedValue & ", TELEX_APPROVAL = '" & lstTelexApproval.SelectedValue & "', TELEX_UPDATED_BY = '" & Session("LoginUser") & "', TELEX_UPDATED_ON = TO_DATE('" & formattedDate & "', 'DD-MM-YYYY HH24:MI:SS') , TELEX_REMARKS = '" & textTelexRemarks.Text & "' WHERE MTY_CONT_ID = " & Convert.ToInt32(MtyContId.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
                        Return
                    End Try

                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub


    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    End Sub
End Class