Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: TerminalOperator Class
    ''' @author	: Santosh Singh- 5/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class TerminalOperator

        Private lngOperatorId As Long ' Define Private Variable OperatorId DataType As Long 
        Private strOperatorName As String ' Define Private Variable OperatorName DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' OperatorId
        ''' </summary>
        ''' <value>lngOperatorId</value>
        ''' <returns> Return lngOperatorId</returns>
        ''' <remarks></remarks>
        Public Property OperatorId() As Long
            Get
                Return lngOperatorId
            End Get
            Set(ByVal value As Long)
                lngOperatorId = value
            End Set
        End Property


        ''' <summary>
        ''' OperatorName
        ''' </summary>
        ''' <value>strOperatorName</value>
        ''' <returns> Return strOperatorName</returns>
        ''' <remarks></remarks>
        Public Property OperatorName() As String
            Get
                Return strOperatorName
            End Get
            Set(ByVal value As String)
                strOperatorName = value
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
            lngOperatorId = 0
            strOperatorName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalOperator"></param>
        ''' <returns>Return pTerminalOperator Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_OPERATOR_ID", pTerminalOperator.OperatorId, ParameterDirection.Output)
                db.AddParameter("p_OPERATOR_NAME", pTerminalOperator.OperatorName)
                db.AddParameter("p_ErrorMsg", pTerminalOperator.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_OPERATOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOperator.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalOperator.OperatorId = db.Parameters.Item("p_OPERATOR_ID").value

                If pTerminalOperator.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalOperator"></param>
        ''' <returns>Return pTerminalOperator Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Try
                db.ClearParameters()
                db.AddParameter("p_OPERATOR_ID", pTerminalOperator.OperatorId, ParameterDirection.Output)
                db.AddParameter("p_OPERATOR_NAME", pTerminalOperator.OperatorName)
                db.AddParameter("p_ErrorMsg", pTerminalOperator.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_OPERATOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOperator.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalOperator.OperatorId = db.Parameters.Item("p_OPERATOR_ID").value

            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
            End Try
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalOperator"></param>
        ''' <returns>Return pTerminalOperator Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_OPERATOR_ID", pTerminalOperator.OperatorId)
                db.AddParameter("p_OPERATOR_NAME", pTerminalOperator.OperatorName)
                db.AddParameter("p_ErrorMsg", pTerminalOperator.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_OPERATOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOperator.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalOperator.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalOperator"></param>
        ''' <returns>Return pTerminalOperator Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Try
                db.ClearParameters()
                db.AddParameter("p_OPERATOR_ID", pTerminalOperator.OperatorId)
                db.AddParameter("p_OPERATOR_NAME", pTerminalOperator.OperatorName)
                db.AddParameter("p_ErrorMsg", pTerminalOperator.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_OPERATOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalOperator.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
            End Try
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("OPERATOR_ID").ToString <> "" Then
                            pTerminalOperator.OperatorId = dbr("OPERATOR_ID")
                        End If
                        If dbr("OPERATOR_NAME").ToString <> "" Then
                            pTerminalOperator.OperatorName = dbr("OPERATOR_NAME")
                        End If
                    End While
                End If
            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
            End Try
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalOperator As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalOperator
                        If dbr("OPERATOR_ID").ToString <> "" Then
                            temp.OperatorId = dbr("OPERATOR_ID")
                        End If
                        If dbr("OPERATOR_NAME").ToString <> "" Then
                            temp.OperatorName = dbr("OPERATOR_NAME")
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
        Public Shared Function ReturnTerminalOperator(ByVal pTerminalOperator As TerminalOperator) As TerminalOperator
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_OPERATOR", "' '")
                pTerminalOperator = ReturnObjectValues(dbr, pTerminalOperator)
                dbr.Close()
            Catch ex As Exception
                pTerminalOperator.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalOperator
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalOperatorList(ByVal pTerminalOperator As TerminalOperator) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalOperator As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_OPERATOR_BY_ALL", "")
                arrTerminalOperator = ReturnObjectValuesList(dbr, arrTerminalOperator)
                dbr.Close()
            Catch ex As Exception
                arrTerminalOperator = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalOperator
        End Function
    End Class
End Namespace
