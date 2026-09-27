Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Partial Class Reports_Masters_CustomerMaster
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvCustomerMaster.DataSource = Nothing
            gvCustomerMaster.DataBind()

            Dim strpParms As String = ""
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUSTOMER_MASTER_ALL", strpParms)
            gvCustomerMaster.DataSource = dbr
            gvCustomerMaster.DataBind()
           
            dbr.Close()
            db.CloseDB()

                   End If
    End Sub
    
    Protected Sub gvCustomerMaster_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCustomerMaster.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
           
        End If
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        
        Try
            Response.ClearContent()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "CustomerMaster.xls"))
            Response.ContentType = "application/ms-excel"
            Dim sw As New StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            gvCustomerMaster.AllowPaging = False
            gvCustomerMaster.HeaderRow.Style.Add("background-color", "#FFFFFF")
            gvCustomerMaster.RenderControl(htw)
            Response.Write(sw.ToString())
            Response.[End]()
        Catch ex As Exception
        End Try
    End Sub
End Class
