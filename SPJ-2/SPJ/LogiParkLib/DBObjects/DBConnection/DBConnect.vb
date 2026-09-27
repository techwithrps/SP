Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Data


Namespace DBConnection

    Public Class DBConnect

        Private strConnectionString As String
        Private oleDBConnection As System.Data.OleDb.OleDbConnection
        Private oleDBCommand As System.Data.OleDb.OleDbCommand
        Private oledbtrans As System.Data.OleDb.OleDbTransaction

        Public ReadOnly Property Parameters() As IDataParameterCollection
            Get
                Return oleDBCommand.Parameters
            End Get
        End Property


        Public Sub New()
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            oleDBConnection = New OleDbConnection
            oleDBConnection.ConnectionString = strConnectionString
            oleDBCommand = New OleDbCommand
            oleDBCommand.Connection = oleDBConnection
            oleDBCommand.CommandType = CommandType.Text
            oleDBCommand.CommandTimeout = 0
        End Sub
        Public Sub New(ByVal strConStr As String)
            If Not strConStr Is Nothing Then
                strConnectionString = strConStr
            Else
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            End If

            oleDBConnection = New OleDbConnection
            oleDBConnection.ConnectionString = strConnectionString

            oleDBCommand = New OleDbCommand
            oleDBCommand.Connection = oleDBConnection
            oleDBCommand.CommandType = CommandType.Text
            oleDBCommand.CommandTimeout = 0
        End Sub
        Public Function ReadDB(ByVal SQLstr As String) As System.Data.OleDb.OleDbDataReader
            If oleDBConnection.State = ConnectionState.Closed Then
                oleDBConnection.Open()
            End If
            oleDBCommand = oleDBConnection.CreateCommand()
            oleDBCommand.CommandText = SQLstr
            ' ''---------------------
            If Not (Me.oledbtrans Is Nothing) Then
                ' User has invoked a transaction. So add the Transaction to the command object
                Me.oleDBCommand.Transaction = Me.oledbtrans
            End If
            ' ''---------------------
            Return oleDBCommand.ExecuteReader()
        End Function
        Public Sub CloseDB()
            If Not oledbtrans Is Nothing Then
                oledbtrans.Rollback()
                oledbtrans = Nothing
            End If
            If Me.oleDBConnection.State = ConnectionState.Open Then
                Me.oleDBConnection.Close()
            End If
        End Sub

        Private Sub OpenDB()
            If oleDBCommand.Connection.State = ConnectionState.Closed Then
                oleDBCommand.Connection.Open()
            End If
        End Sub
        Public Sub BeginTransaction()
            If oleDBCommand.Connection.State = ConnectionState.Closed Then
                oleDBCommand.Connection.Open()
            End If
            Me.oledbtrans = oleDBCommand.Connection.BeginTransaction
        End Sub
        Public Sub CommitTransaction()
            Me.oledbtrans.Commit()
            Me.oledbtrans = Nothing
        End Sub
        Public Sub RollbackTransaction()
            Me.oledbtrans.Rollback()
            Me.oledbtrans = Nothing
        End Sub

        Public Sub AddParameter(ByVal paramname As String, ByVal paramvalue As Object, Optional ByVal paramDirection As Data.ParameterDirection = ParameterDirection.Input)
            Dim param As OleDbParameter = New OleDbParameter(paramname, OleDbType.VarChar)
            param.Value = paramvalue
            param.Direction = paramDirection
            param.Size = 5000

            oleDBCommand.Parameters.Add(param)
        End Sub

        Public Sub AddParameter(ByVal param As IDataParameter)
            oleDBCommand.Parameters.Add(param)
        End Sub

        Public Sub ClearParameters()
            oleDBCommand.Parameters.Clear()
        End Sub
        Public Function StoredProcedureReadDB(ByVal procName As String, ByVal procParam As String) As System.Data.OleDb.OleDbDataReader
            If oleDBConnection.State = ConnectionState.Closed Then
                oleDBConnection.Open()
            End If
            oleDBCommand = oleDBConnection.CreateCommand()
            oleDBCommand.CommandText = procName & "(" & procParam & ")"
            oleDBCommand.CommandType = CommandType.StoredProcedure
            ' ''---------------------
            If Not (Me.oledbtrans Is Nothing) Then
                ' User has invoked a transaction. So add the Transaction to the command object
                Me.oleDBCommand.Transaction = Me.oledbtrans
            End If
            ' ''---------------------
            Return oleDBCommand.ExecuteReader()
        End Function

        Public Function ExecuteScalar() As Object
            Dim obj As Object = Nothing
            Try
                Me.OpenDB()
                obj = oleDBCommand.ExecuteScalar()
            Catch ex As Exception
                Throw
            End Try
            Return obj
        End Function
        Public Function ExecuteScalar(ByVal commandtext As String, Optional ByVal cmdType As CommandType = CommandType.StoredProcedure) As Object
            Dim obj As Object = Nothing
            Try
                If Not (Me.oledbtrans Is Nothing) Then
                    ' User has invoked a transaction. So add the Transaction to the command object
                    oleDBCommand.Transaction = Me.oledbtrans
                End If
                oleDBCommand.CommandType = cmdType
                oleDBCommand.CommandText = commandtext
                obj = Me.ExecuteScalar()
            Catch ex As Exception
                ''If (handleErrors) Then
                ''    strLastError = ex.Message
                ''Else
                Throw
                ''End If
            End Try
            Return obj
        End Function
    End Class
End Namespace