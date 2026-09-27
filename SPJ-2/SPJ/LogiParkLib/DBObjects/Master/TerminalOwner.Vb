Imports LogiParkLib.DBConnection

Imports System.Web
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: TerminalOwner Class
    ''' @author	: Santosh Singh- 5/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class TerminalOwner

        Private lngOwnerId As Long ' Define Private Variable OwnerId DataType As Long 
        Private strOwnerName As String ' Define Private Variable OwnerName DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' OwnerId
        ''' </summary>
        ''' <value>lngOwnerId</value>
        ''' <returns> Return lngOwnerId</returns>
        ''' <remarks></remarks>
        Public Property OwnerId() As Long
            Get
                Return lngOwnerId
            End Get
            Set(ByVal value As Long)
                lngOwnerId = value
            End Set
        End Property


        ''' <summary>
        ''' OwnerName
        ''' </summary>
        ''' <value>strOwnerName</value>
        ''' <returns> Return strOwnerName</returns>
        ''' <remarks></remarks>
        Public Property OwnerName() As String
            Get
                Return strOwnerName
            End Get
            Set(ByVal value As String)
                strOwnerName = value
            End Set
        End Property


        ''' <summary>
        ''' Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks></remarks>
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            lngOwnerId = 0
            strOwnerName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalOwner"></param>
        ''' <returns>Return pTerminalOwner Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_OWNER_ID", pTerminalOwner.OwnerId, ParameterDirection.Output)
                db.AddParameter("p_OWNER_NAME", pTerminalOwner.OwnerName)
                db.AddParameter("p_ErrorMsg", pTerminalOwner.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_OWNER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOwner.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalOwner.OwnerId = db.Parameters.Item("p_OWNER_ID").value

                If pTerminalOwner.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalOwner"></param>
        ''' <returns>Return pTerminalOwner Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Try
                db.ClearParameters()
                db.AddParameter("p_OWNER_ID", pTerminalOwner.OwnerId, ParameterDirection.Output)
                db.AddParameter("p_OWNER_NAME", pTerminalOwner.OwnerName)
                db.AddParameter("p_ErrorMsg", pTerminalOwner.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_OWNER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOwner.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalOwner.OwnerId = db.Parameters.Item("p_OWNER_ID").value

            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
            End Try
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalOwner"></param>
        ''' <returns>Return pTerminalOwner Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_OWNER_ID", pTerminalOwner.OwnerId)
                db.AddParameter("p_OWNER_NAME", pTerminalOwner.OwnerName)
                db.AddParameter("p_ErrorMsg", pTerminalOwner.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_OWNER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOwner.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalOwner.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalOwner"></param>
        ''' <returns>Return pTerminalOwner Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Try
                db.ClearParameters()
                db.AddParameter("p_OWNER_ID", pTerminalOwner.OwnerId)
                db.AddParameter("p_OWNER_NAME", pTerminalOwner.OwnerName)
                db.AddParameter("p_ErrorMsg", pTerminalOwner.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_OWNER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOwner.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
            End Try
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("OWNER_ID").ToString <> "" Then
                            pTerminalOwner.OwnerId = dbr("OWNER_ID")
                        End If
                        If dbr("OWNER_NAME").ToString <> "" Then
                            pTerminalOwner.OwnerName = dbr("OWNER_NAME")
                        End If
                    End While
                End If
            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
            End Try
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalOwner As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalOwner
                        If dbr("OWNER_ID").ToString <> "" Then
                            temp.OwnerId = dbr("OWNER_ID")
                        End If
                        If dbr("OWNER_NAME").ToString <> "" Then
                            temp.OwnerName = dbr("OWNER_NAME")
                        End If
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalOwner(ByVal pTerminalOwner As TerminalOwner) As TerminalOwner
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_OWNER", "' '")
                pTerminalOwner = ReturnObjectValues(dbr, pTerminalOwner)
                dbr.Close()
            Catch ex As Exception
                pTerminalOwner.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalOwner
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalOwnerList(ByVal pTerminalOwner As TerminalOwner) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalOwner As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_OWNER_BY_ALL", "")
                arrTerminalOwner = ReturnObjectValuesList(dbr, arrTerminalOwner)
                dbr.Close()
            Catch ex As Exception
                arrTerminalOwner = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalOwner
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalOwnerSearchList(ByVal pTerminalOwner As TerminalOwner) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalOwner As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_OWNER_SEARCH_ALL", "'%" & pTerminalOwner.OwnerName & "%'")
                arrTerminalOwner = ReturnObjectValuesList(dbr, arrTerminalOwner)
                dbr.Close()
            Catch ex As Exception
                arrTerminalOwner = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalOwner
        End Function

    End Class
End Namespace
