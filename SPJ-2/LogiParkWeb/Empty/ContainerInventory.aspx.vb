Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.IO
Imports System.Data
Imports System.Globalization
Partial Class Empty_ContainerInventory
    Inherits System.Web.UI.Page
    Dim glLine As ArrayList
    Dim rows As Long = 5
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        'prepareCommodityData()
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            'MenuItemHelper.Permission(Me.Page, p)
            ' manageUserControls(True)
            ' ListControlDataBind()
            fillRepeator(New ArrayList)
            'manageUserControls(True)
            ' ButtonControlSetup(True)
            'lstOrigin.SelectedValue = Session.Item("LoginTerminal")
            'Functions.ControlFocus(fuFordaingNotUpload)
            'Functions.clearControls(Me.dvMain.Controls)
            ' Dim strBookingRefNo As String = Request.QueryString("BookingRefNo")
            '  If strBookingRefNo <> Nothing Then
            'textBookingRefNo.Text = strBookingRefNo.ToString
            ' btnSearchDisplay_Click(sender, e)
            'Else
            '  SEARCH()
            '   btnSearch.Visible = False
            'End If
            'lstFwNotePending.Enabled = True
        End If
    End Sub
    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - 1
            Next
        End If
        repBookingContDeatils.DataSource = arr
        ' Try
        repBookingContDeatils.DataBind()

    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If UPcontainers.HasFile Then
            Dim fn As String = System.IO.Path.GetFileName(UPcontainers.PostedFile.FileName)
            Dim SaveLocation As String = Convert.ToString(Server.MapPath("Format/")) + fn
            UPcontainers.PostedFile.SaveAs(SaveLocation)
            Dim filepath As String = Server.MapPath(Convert.ToString("Format/") & fn)
            Dim strFileType As String = System.IO.Path.GetExtension(filepath.ToLower())
            If strFileType.Trim() <> ".csv" Then
                lblErrorMessage.Text = "Only *.csv filetype are allowed."
                lblErrorMessage.ForeColor = System.Drawing.Color.Red
                Return
            End If
            Dim sSourceConstr As String = [String].Empty
            If strFileType.Trim() = ".csv" Then
                Dim tb As DataTable = CsvFileToDatatable(filepath, True)
                tb.Columns("LineName").ColumnName = "CustomerId"
               
                Dim newColumn As New Data.DataColumn("RefId", GetType(System.String))
                newColumn.DefaultValue = "0"
                tb.Columns.Add(newColumn)
                repBookingContDeatils.DataSource = tb
                repBookingContDeatils.DataBind()
                Dim completePath As String = Server.MapPath("Format/" + fn)
                If System.IO.File.Exists(completePath) Then
                    System.IO.File.Delete(completePath)
                End If
            End If

            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Uploaded Successfully.")

        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please select a file.")
        End If
    End Sub

    Public Function CsvFileToDatatable(ByVal path__1 As String, ByVal IsFirstRowHeader As Boolean) As DataTable
        'here Path is root of file and IsFirstRowHeader is header is there or not
        Dim header As String = "No"
        Dim sql As String = String.Empty
        Dim dataTable As DataTable = Nothing
        Dim pathOnly As String = String.Empty
        Dim fileName As String = String.Empty
        Try
            pathOnly = Path.GetDirectoryName(path__1)
            fileName = Path.GetFileName(path__1)
            sql = (Convert.ToString("SELECT * FROM [") & fileName) + "]"
            If IsFirstRowHeader Then
                header = "Yes"
            End If
            Using connection As New OleDbConnection((Convert.ToString((Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & pathOnly) + ";Extended Properties=""Text;HDR=") & header) + """")
                Using command As New OleDbCommand(sql, connection)
                    Using adapter As New OleDbDataAdapter(command)
                        dataTable = New DataTable()
                        dataTable.Locale = CultureInfo.CurrentCulture
                        adapter.Fill(dataTable)
                    End Using
                End Using
            End Using
        Finally
        End Try
        Return dataTable
    End Function
    Protected Sub prepareLine(ByVal sender As Object, ByVal e As System.EventArgs)

        prepareContData()
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

        Dim pCustomerMaster As New CustomerMaster
        glLine = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
    End Sub
    'Private Function prepareObjectFroUploadData() As ExtUploadData
    '    Dim pUploadData As New ExtUploadData
    '    pUploadData.UploadDataList = New ArrayList
    '    Try
    '        Dim fileobj As HttpPostedFile = UPcontainers.PostedFile
    '        Dim objStreamReader As System.IO.StreamReader
    '        Dim strLine As String = ""
    '        Dim index As Long = 1
    '        If fileobj IsNot Nothing Then
    '            objStreamReader = New System.IO.StreamReader(fileobj.InputStream)
    '            strLine = objStreamReader.ReadLine
    '            Do While Not strLine Is Nothing
    '                Dim p As New UploadData
    '                p.FileData = strLine
    '                p.RecordId = index
    '                pUploadData.UploadDataList.Add(p)
    '                index += 1
    '                strLine = objStreamReader.ReadLine
    '            Loop
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Return pUploadData
    'End Function
    Protected Sub repBookingContDeatils_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repBookingContDeatils.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("textContNo"), TextBox).Text.Trim <> Nothing AndAlso CType(e.Item.FindControl("textContNo"), TextBox).Text <> "" Then
                CType(e.Item.FindControl("textContNo"), TextBox).Text = CType(e.Item.FindControl("textContNo"), TextBox).Text.Trim
                Dim commodity As String = CType(e.Item.FindControl("lblCommodity"), Label).Text
                Try
                    CType(e.Item.FindControl("lstline"), DropDownList).Items.FindByText(commodity.ToUpper.Trim).Selected = True
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
End Class
