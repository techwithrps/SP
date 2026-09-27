Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: HoldReason
    ''' @author	: Santosh Singh- 9/7/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class HoldReason 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngHoldReasonId As Long ' Define Private Variable HoldReasonId With DataType As Long 
        Private strReasonDeatils As String ' Define Private Variable ReasonDeatils With DataType As String 
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
        ''' Get or Set the Value of HoldReasonId
        ''' </summary>
        ''' <value>lngHoldReasonId</value>
        ''' <returns> Return lngHoldReasonId</returns>
        ''' <remarks> Get or Set the Value of HoldReasonId  </remarks>
        '''
        Public Property HoldReasonId() as Long
            Get
                Return lngHoldReasonId
            End Get
            Set(ByVal value As Long)
                lngHoldReasonId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReasonDeatils
        ''' </summary>
        ''' <value>strReasonDeatils</value>
        ''' <returns> Return strReasonDeatils</returns>
        ''' <remarks> Get or Set the Value of ReasonDeatils  </remarks>
        '''
        Public Property ReasonDeatils() as String
            Get
                Return strReasonDeatils
            End Get
            Set(ByVal value As String)
                strReasonDeatils = value
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
            lngHoldReasonId = 0 
            strReasonDeatils = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pHoldReason"></param>
        ''' <returns>Return pHoldReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pHoldReason As HoldReason) As HoldReason
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldReason.TerminalId)
                db.AddParameter("p_HOLD_REASON_ID", pHoldReason.HoldReasonId, ParameterDirection.Output)
                db.AddParameter("p_REASON_DEATILS", pHoldReason.ReasonDeatils)
                db.AddParameter("p_CREATED_BY", pHoldReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldReason.HoldReasonId  = db.Parameters.Item("p_HOLD_REASON_ID").value
                
                If pHoldReason.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldReason.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldReason"></param>
        ''' <returns>Return pHoldReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pHoldReason As HoldReason) As HoldReason
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldReason.TerminalId)
                db.AddParameter("p_HOLD_REASON_ID", pHoldReason.HoldReasonId, ParameterDirection.Output)
                db.AddParameter("p_REASON_DEATILS", pHoldReason.ReasonDeatils)
                db.AddParameter("p_CREATED_BY", pHoldReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldReason.HoldReasonId  = db.Parameters.Item("p_HOLD_REASON_ID").value
                
            Catch ex As Exception
                pHoldReason.ErrorMsg = ex.Message
            End Try
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pHoldReason"></param>
        ''' <returns>Return pHoldReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pHoldReason As HoldReason) As HoldReason
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldReason.TerminalId)
                db.AddParameter("p_HOLD_REASON_ID", pHoldReason.HoldReasonId)
                db.AddParameter("p_REASON_DEATILS", pHoldReason.ReasonDeatils)
                db.AddParameter("p_CREATED_BY", pHoldReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pHoldReason.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldReason.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldReason"></param>
        ''' <returns>Return pHoldReason Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pHoldReason As HoldReason) As HoldReason
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldReason.TerminalId)
                db.AddParameter("p_HOLD_REASON_ID", pHoldReason.HoldReasonId)
                db.AddParameter("p_REASON_DEATILS", pHoldReason.ReasonDeatils)
                db.AddParameter("p_CREATED_BY", pHoldReason.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldReason.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldReason.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_REASON", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldReason.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pHoldReason.ErrorMsg = ex.Message
                End Try
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pHoldReason As HoldReason) As HoldReason
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PHoldReason.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REASON_ID").ToString <> "" Then
                                PHoldReason.HoldReasonId = dbr("HOLD_REASON_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REASON_DEATILS").ToString <> "" Then
                                PHoldReason.ReasonDeatils = dbr("REASON_DEATILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PHoldReason.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PHoldReason.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pHoldReason.ErrorMsg = ex.Message
            End Try
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrHoldReason As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New HoldReason
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REASON_ID").ToString <> "" Then
                                temp.HoldReasonId = dbr("HOLD_REASON_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REASON_DEATILS").ToString <> "" Then
                                temp.ReasonDeatils = dbr("REASON_DEATILS")
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
        Public Shared Function ReturnHoldReason(ByVal pHoldReason As HoldReason) As HoldReason
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_REASON", "' '")
                pHoldReason = ReturnObjectValues(dbr, pHoldReason)
                dbr.Close()
            Catch ex As Exception
                pHoldReason.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pHoldReason
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnHoldReasonList (ByVal pHoldReason As HoldReason) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrHoldReason As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_REASON_ALL", pHoldReason.TerminalId)
                arrHoldReason = ReturnObjectValuesList(dbr, arrHoldReason)
                dbr.Close()
            Catch ex As Exception
                arrHoldReason = Nothing
            End Try
            db.CloseDB()
            Return arrHoldReason
        End Function
    End Class
End Namespace
