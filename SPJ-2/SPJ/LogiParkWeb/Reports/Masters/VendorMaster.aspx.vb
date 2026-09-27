Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Partial Class Reports_Masters_VendorMaster
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvVendorMaster.DataSource = Nothing
            gvVendorMaster.DataBind()



            tblReport.Visible = True
            tblReport.Visible = True

            Dim strpParms As String = ""
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VENDOR_MASTER_ALL", strpParms)
            gvVendorMaster.DataSource = dbr
            gvVendorMaster.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else

                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found For Export")
            End If
            dbr.Close()
            db.CloseDB()

        End If
    End Sub
    
    Protected Sub gvVendorMaster_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvVendorMaster.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try

            Dim strComa = ","
            Dim strFileName As String = "Customer Master.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            strb.Append(lblScreenTitle.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            strb.Append(Space(4) & vbCrLf)


            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = lblSrNo.Text & strComa & "Vendor Name" & strComa & "Contact Person" & strComa & "Contact No" & strComa & "Email" & strComa & "Address" & strComa & "Created By" & strComa & "Created On"

            strb.Append(strContHeader & vbCrLf)

            If gvVendorMaster.Rows.Count > 0 Then
                For Each r As GridViewRow In gvVendorMaster.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                        Else
                            strb.Append(" " & strComa)
                        End If
                    Next
                    strb.Append(vbCrLf)
                Next
            End If

            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception

        End Try

    End Sub
End Class
