Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Xml

Public Class MenuItemHelper
    Private Const MenuItemCacheName As String = "MenuItem"
    Private Const RootPathMenuItem As String = "~/MenuXml.xml"
    Private Const FolderPathMenuItem As String = "~/MenuXml/MenuXml.xml"

    Public Shared ReadOnly Property MenuCacheName() As String
        Get
            Return MenuItemCacheName
        End Get
    End Property

    Public Shared Sub Permission(webpage As Page, pppRelativeCurrentExecutionFilePath As String)
        If webpage Is Nothing Then
            Return
        End If
        Dim table = CType(webpage.Cache(MenuItemCacheName), DataTable)
        If table Is Nothing Then
            Return
        End If

        Dim dv = New DataView(table, "URL = '" & pppRelativeCurrentExecutionFilePath & "'", "",
                              DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable(), "JOB_ID = '" & CType(webpage.Session.Item("JobId"), String) & "'", "",
                          DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            webpage.Session.Item("Add") = row(7).ToString
            webpage.Session.Item("Edit") = row(8).ToString
            webpage.Session.Item("Delete") = row(9).ToString
            webpage.Session.Item("Search") = row(10).ToString
            webpage.Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Public Shared Sub WriteMenuXml(webpage As Page, lblErrorMessage As Label)
        Dim conString, cmd As String
        Dim con As OleDbConnection
        Try

            conString = ConfigurationManager.AppSettings("DBConnectionString")
            cmd =
                ("SELECT DISTINCT MIM.MENU_ID, MIM.PARENT_ID, MIM.MODULE_ID, MIM.URL, MIM.TITLE, MIM.DESCRIPTION, JMI.JOB_ID, JMI.ADD_PERMIT, JMI.EDIT_PERMIT," _
                 & " JMI.DELETE_PERMIT, JMI.SEARCH_PERMIT FROM MENU_ITEM_MASTER MIM, JOB_MENU_ITEMS JMI " _
                 & " WHERE MIM.MENU_ID=JMI.MENU_ID ORDER BY MENU_ID")
            con = New OleDbConnection(conString)
            con.Open()
            Dim ada = New OleDbDataAdapter(cmd, con)
            Dim ds As New DataSet("Menu")
            ada.Fill(ds)
            con.Dispose()
            con.Close()
            Try
                ds.WriteXml(webpage.Server.MapPath(RootPathMenuItem))
                'File.Copy(webpage.Server.MapPath(RootPathMenuItem),
                '          webpage.Server.MapPath(FolderPathMenuItem), True)
                webpage.Cache(MenuItemCacheName) = ds.Tables(0)
            Catch ex1 As Exception
                lblErrorMessage.Text = ex1.Message
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ReadMenuXml(webpage As Page)
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(webpage.Server.MapPath(RootPathMenuItem), New XmlReaderSettings())
        Dim ds As New DataSet
        ds.ReadXml(xmlFile)
        webpage.Cache(MenuItemCacheName) = ds.Tables(0)
        xmlFile.Close()
    End Sub
End Class
