Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects
Imports System.Xml
Imports System.Data.OleDb
Imports System.Data

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim ARR As New ArrayList

    ' Protected Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    'Response.Cache.SetCacheability(HttpCacheability.NoCache)
    'Response.Cache.SetExpires(DateTime.Now.AddDays(-1))
    'Response.Cache.SetNoStore()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Count = 0 Then
            If Not Request.RawUrl.ToUpper.EndsWith("/HOME.ASPX") Then
                Session.Add("UrlString", Request.Url.AbsoluteUri)
            End If
            Response.Redirect("~/ClientLogin.aspx")
        End If
        If Not Request.RawUrl.ToUpper.EndsWith("/HOME.ASPX") Then
            lstBranch.Enabled = False
            lstCompany.Enabled = False
        End If
        If Not Page.IsPostBack Then
            If Session.Item("LoginUser") <> Nothing Then
                FillMenuItemsByLoginUserId()
            End If
            lstBranch.ClearSelection()
            lstCompany.ClearSelection()
            ListControlDataBind()

            Dim strConnectionString, cmd As String
            Dim con As OleDbConnection
            Dim ada As New OleDbDataAdapter
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "Select Count(*) From Change_Request Where Close_Date Is Null"
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim ds As New DataSet
                ada = New OleDbDataAdapter(cmd, con)
                ada.Fill(ds)
                If (ds.Tables.Count > 0) Then
                    linkNotification.Text = "(" & ds.Tables(0).Rows(0)(0) & ")"
                Else
                    linkNotification.Text = "(" & 0 & ")"
                End If
            Catch ex As Exception
                linkNotification.Text = "(" & 0 & ")"
            End Try

            lstBranch.SelectedValue = Session.Item("LoginTerminal")
            lblLoginUser.Text = Session.Item("LoginUserName")
            lstCompany.SelectedValue = Session.Item("CompanyId")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
            lblLoginUser.ToolTip = pTerminalMaster.TerminalCode
        End If
        mnLogiPark.Focus()
    End Sub
    Sub ListControlDataBind()
        Try
            Dim pUserTerminal As New UserTerminal
            pUserTerminal.UserId = Session.Item("LoginUser")
            lstBranch.DataSource = UserTerminal.ReturnUserTerminalListAssigned(pUserTerminal)
            lstBranch.DataTextField = "UserId"
            lstBranch.DataValueField = "TerminalId"
            lstBranch.DataBind()
        Catch ex As Exception
        End Try

        Try
            Dim pUserCompany As New UserCompany
            pUserCompany.UserId = Session.Item("LoginUser")
            lstCompany.DataSource = UserCompany.ReturnUserCompanyListAssigned(pUserCompany)
            lstCompany.DataTextField = "CompanyName"
            lstCompany.DataValueField = "CompanyId"
            lstCompany.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub State_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Session.Add("LoginTerminal", lstBranch.SelectedValue)
        lstBranch.ToolTip = lstBranch.SelectedItem.Text
        Session.Add("CompanyId", lstCompany.SelectedValue)

    End Sub

    'Sub FillMenuItemsByLoginUserId()
    '    If mnLogiPark Is Nothing Then
    '        Return
    '    End If
    '    Dim table = CType(Cache(MenuItemHelper.MenuCacheName), DataTable)
    '    If Not (table Is Nothing) Then
    '        FilterTableByJobId(table)
    '    Else
    '        MenuItemHelper.ReadMenuXml(Me.Page)
    '        table = CType(Cache(MenuItemHelper.MenuCacheName), DataTable)
    '        FilterTableByJobId(table)
    '    End If

    'End Sub
    Sub FillMenuItemsByLoginUserId()
        Dim puser As New ExtUserMaster
        puser.UserId = Session.Item("LoginUser")
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserId(puser)
        If puser.UserStatus = "C" Then
            Return
        End If

        Dim menuItem As New MenuItem
        Dim submenu As New MenuItem
        Dim ds2 As New DataSet

        If Cache("Data") Is Nothing Then
            ds2.ReadXml(Server.MapPath("~/MenuXml.xml"))
            Cache("Data") = ds2
        Else
            ds2 = DirectCast(Cache("Data"), DataSet)

        End If

        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "JOB_ID = " & Session.Item("JobId") & "", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Dim xmlParentId As Double
            Try
                xmlParentId = Double.Parse(row(1).ToString)
            Catch ex As Exception
                xmlParentId = 0
            End Try

            If xmlParentId = 1 Then
                menuItem = New MenuItem(row(5).ToString, row(0).ToString, "", row(3).ToString)
                mnLogiPark.Items.Add(menuItem)
            Else
                submenu = New MenuItem(row(5).ToString, row(0).ToString, "", row(3).ToString)
                MenuChildParentSetup(submenu, xmlParentId, mnLogiPark, Nothing)
            End If
        Next
    End Sub

    Private Sub FilterTableByJobId(table As DataTable)

        Dim dv = New DataView(table, "JOB_ID = " & Session.Item("JobId") & "", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Dim xmlParentId As Double = 0
            Try
                xmlParentId = Double.Parse(row(1).ToString)
            Catch ex As Exception
                'ScriptManager.RegisterStartupScript(Me, [GetType](), "ShowAlert",
                '                                    "alert('" & row(1).ToString & "');", True)
            End Try
            If xmlParentId.Equals(1) Then
                Dim menuItem = New MenuItem(row(5).ToString, row(0).ToString, "", row(3).ToString)
                mnLogiPark.Items.Add(menuItem)
            Else
                Dim submenu = New MenuItem(row(5).ToString, row(0).ToString, "", row(3).ToString)
                MenuChildParentSetup(submenu, xmlParentId, mnLogiPark, Nothing)
            End If
        Next
    End Sub

    Private Shared Sub MenuChildParentSetup(ByVal child_id As MenuItem, ByVal parentid As Double, ByVal mnMenu As Menu, Optional ByVal parent As MenuItem = Nothing)
        Dim m1 As MenuItem
        Dim i As Integer = 0
        If parent Is Nothing Then
            For Each m1 In mnMenu.Items
                If m1.Value = parentid Then
                    mnMenu.Items(i).ChildItems.Add(child_id)
                    Exit For
                ElseIf m1.ChildItems.Count > 0 Then
                    MenuChildParentSetup(child_id, parentid, mnMenu, m1)
                End If
                i += 1
            Next
        Else
            For Each m1 In parent.ChildItems
                If m1.Value = parentid Then
                    parent.ChildItems(i).ChildItems.Add(child_id)
                    Exit For
                ElseIf m1.ChildItems.Count > 0 Then
                    MenuChildParentSetup(child_id, parentid, mnMenu, m1)
                End If
                i += 1
            Next
        End If
    End Sub

    Private Sub child_parent(ByVal child_id As MenuItem)
        Dim i As String
        For Each i In ARR
            If i = child_id.Value Then
                child_id.ChildItems.Add(New MenuItem(ARR.Item(i)))
            End If
        Next
    End Sub

    Protected Sub linkNotification_Click(sender As Object, e As EventArgs) Handles linkNotification.Click
        Response.Redirect("~/Master/Admin/ChangeRequest.aspx")
    End Sub

    Protected Sub ImgLogout_Click(sender As Object, e As ImageClickEventArgs) Handles ImgLogout.Click
        If Cache("Data") IsNot Nothing Then
            Cache.Remove("Data")
        End If

        If Cache(MenuItemHelper.MenuCacheName) IsNot Nothing Then
            Cache.Remove(MenuItemHelper.MenuCacheName)
        End If
        Dim pUserLogin As New UserLogin
        pUserLogin.UserId = Session.Item("LoginUser")
        pUserLogin.TrnId = Session.Item("TrnId")
        UserLogin.Update(pUserLogin)
        Session.Clear()
        Session.Abandon()
        FormsAuthentication.SignOut()
        Dim loggedOutPageUrl As String = "ClientLogin.aspx"
        Response.Write("<script language=""javascript"">")
        Response.Write("function ClearHistory()")
        Response.Write("{")
        Response.Write(" var backlen=history.length;")
        Response.Write(" history.go(-backlen);")
        Response.Write(" window.location.href='" & loggedOutPageUrl & "'; ")
        Response.Write("}")
        Response.Write("</script>")
        Response.Redirect("~/ClientLogin.aspx")
    End Sub

    Protected Sub ImageChangePass_Click(sender As Object, e As ImageClickEventArgs) Handles ImageChangePass.Click
        Response.Redirect("~/Master/Admin/ChangePassword.aspx")
    End Sub
End Class

