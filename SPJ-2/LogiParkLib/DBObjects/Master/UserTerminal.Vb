Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UserJobs
    ''' @author	: Amit K. Singh- 06/06/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UserTerminal

        Private strUserId As String ' Define Private Variable UserId DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 
        Private strTerminalName As String ' Define Private Variable UserId DataType As String 


        ''' <summary>
        ''' UserId
        ''' </summary>
        ''' <value>strUserId</value>
        ''' <returns> Return strUserId</returns>
        ''' <remarks></remarks>
        Public Property UserId() As String
            Get
                Return strUserId
            End Get
            Set(ByVal value As String)
                strUserId = value
            End Set
        End Property

        ''' <summary>
        ''' UserId
        ''' </summary>
        ''' <value>strUserId</value>
        ''' <returns> Return strUserId</returns>
        ''' <remarks></remarks>
        Public Property TerminalName() As String
            Get
                Return strTerminalName
            End Get
            Set(ByVal value As String)
                strTerminalName = value
            End Set
        End Property


        ''' <summary>
        ''' TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks></remarks>
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
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
            strUserId = ""
            strTerminalName = ""
            lngTerminalId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUserTerminal"></param>
        ''' <returns>Return pUserTerminal Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pUserTerminal As UserTerminal) As UserTerminal
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserTerminal.UserId)
                db.AddParameter("p_TERMINAL_ID", pUserTerminal.TerminalId)
                db.AddParameter("p_ErrorMsg", pUserTerminal.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_TERMINAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserTerminal.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pUserTerminal.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserTerminal"></param>
        ''' <returns>Return pUserTerminal Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUserTerminal As UserTerminal) As UserTerminal
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserTerminal.UserId)
                db.AddParameter("p_TERMINAL_ID", pUserTerminal.TerminalId)
                db.AddParameter("p_ErrorMsg", pUserTerminal.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_TERMINAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserTerminal.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
            End Try
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserTerminal"></param>
        ''' <returns>Return pUserTerminal Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pUserTerminal As UserTerminal) As UserTerminal
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserTerminal.UserId)
                db.AddParameter("p_TERMINAL_ID", pUserTerminal.TerminalId)
                db.AddParameter("p_ErrorMsg", pUserTerminal.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_TERMINAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserTerminal.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserTerminal.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserTerminal"></param>
        ''' <returns>Return pUserTerminal Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUserTerminal As UserTerminal) As UserTerminal
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserTerminal.UserId)
                db.AddParameter("p_TERMINAL_ID", pUserTerminal.TerminalId)
                db.AddParameter("p_ErrorMsg", pUserTerminal.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_TERMINAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserTerminal.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
            End Try
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUserTerminal As UserTerminal) As UserTerminal
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                pUserTerminal.UserId = dbr("USER_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pUserTerminal.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_NAME").ToString <> "" Then
                                pUserTerminal.TerminalName = dbr("TERMINAL_NAME")
                            End If
                        Catch ex As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
            End Try
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUserTerminal As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UserTerminal
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                temp.UserId = dbr("USER_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_NAME").ToString <> "" Then
                                temp.TerminalName = dbr("TERMINAL_NAME")
                            End If
                        Catch ex As Exception
                        End Try
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
        Public Shared Function ReturnUserTerminal(ByVal pUserTerminal As UserTerminal) As UserTerminal
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_TERMINAL", "' '")
                pUserTerminal = ReturnObjectValues(dbr, pUserTerminal)
                dbr.Close()
            Catch ex As Exception
                pUserTerminal.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pUserTerminal
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnUserTerminalList(ByVal pUserTerminal As UserTerminal) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserTerminal As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_TERM_ALL_BY_USER_ID", "'" & pUserTerminal.UserId & "'")
                arrUserTerminal = ReturnObjectValuesList(dbr, arrUserTerminal)
                dbr.Close()
            Catch ex As Exception
                arrUserTerminal = Nothing
            End Try
            db.CloseDB()
            Return arrUserTerminal
        End Function

        Public Shared Function ReturnUserTerminalListAssigned(ByVal pUserTerminal As UserTerminal) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserTerminal As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_TERM_ASSIGN_BY_USER_ID", "'" & pUserTerminal.UserId & "'")
                arrUserTerminal = ReturnObjectValuesList(dbr, arrUserTerminal)
                dbr.Close()
            Catch ex As Exception
                arrUserTerminal = Nothing
            End Try
            db.CloseDB()
            Return arrUserTerminal
        End Function
    End Class
End Namespace
