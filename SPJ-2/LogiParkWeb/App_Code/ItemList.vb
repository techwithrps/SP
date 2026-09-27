Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data

<WebService()> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
Public Class ItemList
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetCompletionList(prefixText As String, count As Integer) As List(Of String)
        If count = 0 Then
            count = 10
        End If
        Dim dt As DataTable = GetRecords(prefixText)
        ' Dim items As New List(Of String)(count)
        Dim items As List(Of String) = New List(Of String)
        For i As Integer = 0 To dt.Rows.Count - 1
            'Dim strName As String = dt.Rows(i)(0).ToString()
            'items.Add(strName)
            Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows(i)("ITEM_NAME").ToString, dt.Rows(i)("ITEM_ID").ToString)
            items.Add(item)
        Next
        Return items
    End Function

    Public Function GetRecords(strName As String) As DataTable
        '  Dim strConn As String = "Provider=MSDAORA.1;User ID=spj;Password=MAPLE; Max Pool Size=100; Min Pool Size=5; Data Source=XE"
        Dim strConn As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConn)
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("Name", strName)
        cmd.CommandText = "SELECT ITEM_ID, ITEM_CODE, UPPER(ITEM_NAME) ITEM_NAME, ITEM_COST FROM ITEM_MASTER WHERE ITEM_NAME LIKE UPPER('%" & strName & "%') AND ITEM_COST_VALIDITY>=TO_DATE(SYSDATE, 'DD/MM/YYYY')"
        Dim objDs As New DataSet()
        Dim dAdapter As New OleDbDataAdapter()
        dAdapter.SelectCommand = cmd
        con.Open()
        dAdapter.Fill(objDs)
        con.Close()
        Return objDs.Tables(0)
    End Function

  
End Class