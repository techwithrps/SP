Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: HandoverReason
    ''' @author	: Amit K. Singh- 18/1/2024
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class HandoverReason 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngHandoverReason As Long ' Define Private Variable HandoverReason With DataType As Long 
        Private strHandoverReasonName As String ' Define Private Variable HandoverReasonName With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() as Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HandoverReason
        ''' </summary>
        ''' <value>lngHandoverReason</value>
        ''' <returns> Return lngHandoverReason</returns>
        ''' <remarks> Get or Set the Value of HandoverReason  </remarks>
        '''
        Public Property HandoverReason() as Long
            Get
                Return lngHandoverReason
            End Get
            Set(ByVal value As Long)
                lngHandoverReason = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HandoverReasonName
        ''' </summary>
        ''' <value>strHandoverReasonName</value>
        ''' <returns> Return strHandoverReasonName</returns>
        ''' <remarks> Get or Set the Value of HandoverReasonName  </remarks>
        '''
        Public Property HandoverReasonName() as String
            Get
                Return strHandoverReasonName
            End Get
            Set(ByVal value As String)
                strHandoverReasonName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() as String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() as String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() as String
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
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0 
            lngHandoverReason = 0 
            strHandoverReasonName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pHandoverReason"></param>
        ''' <returns>Return pHandoverReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pHandoverReason As HandoverReason) As HandoverReason
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHandoverReason.TerminalId)
                db.AddParameter("p_HANDOVER_REASON", pHandoverReason.HandoverReason, ParameterDirection.Output)
                db.AddParameter("p_HANDOVER_REASON_NAME", pHandoverReason.HandoverReasonName)
                db.AddParameter("p_CREATED_BY", pHandoverReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHandoverReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHandoverReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HANDOVER_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHandoverReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHandoverReason.HandoverReason  = db.Parameters.Item("p_HANDOVER_REASON").value
                
                If pHandoverReason.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHandoverReason.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHandoverReason"></param>
        ''' <returns>Return pHandoverReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pHandoverReason As HandoverReason) As HandoverReason
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHandoverReason.TerminalId)
                db.AddParameter("p_HANDOVER_REASON", pHandoverReason.HandoverReason, ParameterDirection.Output)
                db.AddParameter("p_HANDOVER_REASON_NAME", pHandoverReason.HandoverReasonName)
                db.AddParameter("p_CREATED_BY", pHandoverReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHandoverReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHandoverReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HANDOVER_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHandoverReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHandoverReason.HandoverReason  = db.Parameters.Item("p_HANDOVER_REASON").value
                
            Catch ex As Exception
                pHandoverReason.ErrorMsg = ex.Message
            End Try
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pHandoverReason"></param>
        ''' <returns>Return pHandoverReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pHandoverReason As HandoverReason) As HandoverReason
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHandoverReason.TerminalId)
                db.AddParameter("p_HANDOVER_REASON", pHandoverReason.HandoverReason)
                db.AddParameter("p_HANDOVER_REASON_NAME", pHandoverReason.HandoverReasonName)
                db.AddParameter("p_CREATED_BY", pHandoverReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHandoverReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHandoverReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HANDOVER_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHandoverReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pHandoverReason.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHandoverReason.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHandoverReason"></param>
        ''' <returns>Return pHandoverReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pHandoverReason As HandoverReason) As HandoverReason
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHandoverReason.TerminalId)
                db.AddParameter("p_HANDOVER_REASON", pHandoverReason.HandoverReason)
                db.AddParameter("p_HANDOVER_REASON_NAME", pHandoverReason.HandoverReasonName)
                db.AddParameter("p_CREATED_BY", pHandoverReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHandoverReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHandoverReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HANDOVER_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHandoverReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pHandoverReason.ErrorMsg = ex.Message
                End Try
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pHandoverReason As HandoverReason) As HandoverReason
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PHandoverReason.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_REASON").ToString <> "" Then
                                PHandoverReason.HandoverReason = dbr("HANDOVER_REASON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_REASON_NAME").ToString <> "" Then
                                PHandoverReason.HandoverReasonName = dbr("HANDOVER_REASON_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PHandoverReason.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PHandoverReason.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pHandoverReason.ErrorMsg = ex.Message
            End Try
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrHandoverReason As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New HandoverReason
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_REASON").ToString <> "" Then
                                temp.HandoverReason = dbr("HANDOVER_REASON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_REASON_NAME").ToString <> "" Then
                                temp.HandoverReasonName = dbr("HANDOVER_REASON_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                end If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnHandoverReason(ByVal pHandoverReason As HandoverReason) As HandoverReason
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HANDOVER_REASON_BY_ID", pHandoverReason.TerminalId & "," & pHandoverReason.HandoverReason)

                pHandoverReason = ReturnObjectValues(dbr, pHandoverReason)
                dbr.Close()
            Catch ex As Exception
                pHandoverReason.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pHandoverReason
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnHandoverReasonList (ByVal pHandoverReason As HandoverReason) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrHandoverReason As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HANDOVER_REASON", "' '")
                arrHandoverReason = ReturnObjectValuesList(dbr, arrHandoverReason)
                dbr.Close()
            Catch ex As Exception
                arrHandoverReason = Nothing
            End Try
            db.CloseDB()
            Return arrHandoverReason
        End Function
    End Class
End Namespace
