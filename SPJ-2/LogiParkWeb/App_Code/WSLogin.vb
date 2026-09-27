Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects
Imports Newtonsoft.Json
Imports System.Data
Imports System.Data.OleDb
Imports System

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSLogin
     Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function
    <WebMethod()> _
    Public Function Login(ByVal UserId As String, ByVal Password As String) As Integer
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT USER_ID, PASSWORD FROM USER_MASTER WHERE USER_ID='" & UserId & "' AND PASSWORD='" & Password & "'"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        ada = New OleDbDataAdapter(cmd1, con)
        Dim dt As New DataTable()
        ada.Fill(dt)
        If dt.Rows.Count > 0 Then
            Return JsonConvert.SerializeObject(1, Newtonsoft.Json.Formatting.Indented)
            'Return "1"
        Else
            Return JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented)
        End If
    End Function

    <WebMethod()> _
    Public Function Insert_Container_Inventory(ByVal CONT_NO As String, ByVal LOCATION As String, ByVal LINE_BOOKING_NO As String, ByVal CONT_SIZE As String, ByVal CONT_TYPE As String, ByVal LINE As String, ByVal PAY_LOAD As Double, ByVal TARE_WT As Double, ByVal CREATED_BY As String) As Integer
        Dim INV_ID As Integer
        Dim Errormsg As String
        Dim db As New DBConnect
        Try
            db.BeginTransaction()
            db.ClearParameters()
            db.AddParameter("p_INV_ID", INV_ID, ParameterDirection.Output)
            db.AddParameter("p_CONT_NO", CONT_NO)
            db.AddParameter("p_LOCATION", LOCATION)
            db.AddParameter("p_LINE_BOOKING_NO", LINE_BOOKING_NO)
            db.AddParameter("p_CONT_SIZE", CONT_SIZE)
            db.AddParameter("p_CONT_TYPE", CONT_TYPE)
            db.AddParameter("p_LINE", LINE)
            db.AddParameter("p_PAY_LOAD", PAY_LOAD)
            db.AddParameter("p_TARE_WT", TARE_WT)
            db.AddParameter("p_CREATED_BY", CREATED_BY)
            db.AddParameter("p_ErrorMsg", Errormsg, ParameterDirection.Output)
            db.ExecuteScalar("INSERT_PKG.SP_CONTAINER_INVENTORY", CommandType.StoredProcedure)
            If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
            End If
            INV_ID = db.Parameters.Item("p_INV_ID").value

            If Errormsg <> Nothing Then
                db.RollbackTransaction()
            Else
                db.CommitTransaction()

            End If
            Return JsonConvert.SerializeObject(INV_ID, Newtonsoft.Json.Formatting.Indented)
        Catch ex As Exception
            Errormsg = ex.Message
            db.RollbackTransaction()
            Return JsonConvert.SerializeObject(0, Newtonsoft.Json.Formatting.Indented)
        End Try
        db.CloseDB()

    End Function
End Class