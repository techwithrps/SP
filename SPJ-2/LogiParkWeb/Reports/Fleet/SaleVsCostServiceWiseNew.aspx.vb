Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Fleet_SaleVsCostServiceWiseNew
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvInvoiceReport.DataSource = Nothing
            gvInvoiceReport.DataBind()
            tblReport.Visible = False
            ListControlDataBind()
            lblScreenTitle.Text = Session.Item("Title")
        End If
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pServiceMaster As New ServiceMaster
            lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pServiceMaster)
            lstService.DataTextField = "ServiceName"
            lstService.DataValueField = "ServiceId"
            lstService.DataBind()
            lstService.Items.Insert(0, (New ListItem("---All---", 0)))
            lstService.SelectedValue = 0
            Dim PcustomerMaster As New CustomerMaster
            'lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(PcustomerMaster)
            lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(PcustomerMaster)
            lstCustomer.DataTextField = "CustomerName"
            lstCustomer.DataValueField = "CustomerId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
            Dim pPol As New PortMaster
            'lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(PcustomerMaster)
            LstPol.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPol)
            LstPol.DataTextField = "PortName"
            LstPol.DataValueField = "PortId"
            LstPol.DataBind()
            LstPol.Items.Insert(0, (New ListItem("---All---", 0)))
            LstPol.SelectedValue = 0
            Dim pPod As New PortMaster
            'lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(PcustomerMaster)
            LstPod.DataSource = PortMaster.ReturnPortMasterList(pPod)
            LstPod.DataTextField = "PortName"
            LstPod.DataValueField = "PortId"
            LstPod.DataBind()
            LstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            LstPod.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub

    

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
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

        Dim strpParms As String = ""
        strpParms &= "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstCustomer.SelectedValue & ""
        strpParms &= "," & lstService.SelectedValue & "," & LstPol.SelectedValue & "," & LstPod.SelectedValue

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect


        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MARGIN_BY_SERVICE", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub

    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
        If Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MARGIN")) < 0 Then
            e.Row.BackColor = Drawing.Color.Red
        ElseIf Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MARGIN")) > 30000 Then
            e.Row.BackColor = Drawing.Color.Yellow
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "SalesVsPurchase.csv"
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

            strb.Append(lblReport.Text & " : ")
            strb.Append(lblReportDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = lblrSerialNo.Text & strComa & lblrPickup.Text & strComa & lblrPartyName.Text & strComa & LblRBlNo.Text & strComa & lblrService.Text & strComa &
            lblrLine.Text & strComa & lblr1Line.Text & strComa & lblrCFS.Text & strComa & lblrPol.Text & strComa & lblrFPOD.Text & strComa & LblSaleExRate.Text & strComa & LblRSaleRate.Text & strComa &
            lblrSale.Text & strComa & LblPExRate.Text & strComa & LblrPurchaseRate.Text & strComa & lblrPurchase.Text & strComa & lblrMargin.Text
            strb.Append(strContHeader & vbCrLf)
            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
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
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

End Class

