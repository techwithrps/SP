Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ShiftDetailsMaster
    ''' @author	: Amit K. Singh- 3/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ShiftDetailsMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngShiftId As Long ' Define Private Variable ShiftId With DataType As Long 
        Private strShiftNo As String ' Define Private Variable ShiftNo With DataType As String 
        Private lngStartHrs As Long ' Define Private Variable StartHrs With DataType As Long 
        Private lngStartMin As Long ' Define Private Variable StartMin With DataType As Long 
        Private lngEndHrs As Long ' Define Private Variable EndHrs With DataType As Long 
        Private lngEndMin As Long ' Define Private Variable EndMin With DataType As Long 
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
        ''' Get or Set the Value of ShiftId
        ''' </summary>
        ''' <value>lngShiftId</value>
        ''' <returns> Return lngShiftId</returns>
        ''' <remarks> Get or Set the Value of ShiftId  </remarks>
        '''
        Public Property ShiftId() as Long
            Get
                Return lngShiftId
            End Get
            Set(ByVal value As Long)
                lngShiftId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ShiftNo
        ''' </summary>
        ''' <value>strShiftNo</value>
        ''' <returns> Return strShiftNo</returns>
        ''' <remarks> Get or Set the Value of ShiftNo  </remarks>
        '''
        Public Property ShiftNo() as String
            Get
                Return strShiftNo
            End Get
            Set(ByVal value As String)
                strShiftNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of StartHrs
        ''' </summary>
        ''' <value>lngStartHrs</value>
        ''' <returns> Return lngStartHrs</returns>
        ''' <remarks> Get or Set the Value of StartHrs  </remarks>
        '''
        Public Property StartHrs() as Long
            Get
                Return lngStartHrs
            End Get
            Set(ByVal value As Long)
                lngStartHrs = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of StartMin
        ''' </summary>
        ''' <value>lngStartMin</value>
        ''' <returns> Return lngStartMin</returns>
        ''' <remarks> Get or Set the Value of StartMin  </remarks>
        '''
        Public Property StartMin() as Long
            Get
                Return lngStartMin
            End Get
            Set(ByVal value As Long)
                lngStartMin = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EndHrs
        ''' </summary>
        ''' <value>lngEndHrs</value>
        ''' <returns> Return lngEndHrs</returns>
        ''' <remarks> Get or Set the Value of EndHrs  </remarks>
        '''
        Public Property EndHrs() as Long
            Get
                Return lngEndHrs
            End Get
            Set(ByVal value As Long)
                lngEndHrs = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EndMin
        ''' </summary>
        ''' <value>lngEndMin</value>
        ''' <returns> Return lngEndMin</returns>
        ''' <remarks> Get or Set the Value of EndMin  </remarks>
        '''
        Public Property EndMin() as Long
            Get
                Return lngEndMin
            End Get
            Set(ByVal value As Long)
                lngEndMin = value
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
            lngShiftId = 0 
            strShiftNo = ""
            lngStartHrs = 0 
            lngStartMin = 0 
            lngEndHrs = 0 
            lngEndMin = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pShiftDetailsMaster"></param>
        ''' <returns>Return pShiftDetailsMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pShiftDetailsMaster.TerminalId)
                db.AddParameter("p_SHIFT_ID", pShiftDetailsMaster.ShiftId, ParameterDirection.Output)
                db.AddParameter("p_SHIFT_NO", pShiftDetailsMaster.ShiftNo)
                db.AddParameter("p_START_HRS", pShiftDetailsMaster.StartHrs)
                db.AddParameter("p_START_MIN", pShiftDetailsMaster.StartMin)
                db.AddParameter("p_END_HRS", pShiftDetailsMaster.EndHrs)
                db.AddParameter("p_END_MIN", pShiftDetailsMaster.EndMin)
                db.AddParameter("p_CREATED_BY", pShiftDetailsMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pShiftDetailsMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pShiftDetailsMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SHIFT_DETAILS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pShiftDetailsMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pShiftDetailsMaster.ShiftId  = db.Parameters.Item("p_SHIFT_ID").value
                
                If pShiftDetailsMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pShiftDetailsMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pShiftDetailsMaster"></param>
        ''' <returns>Return pShiftDetailsMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pShiftDetailsMaster.TerminalId)
                db.AddParameter("p_SHIFT_ID", pShiftDetailsMaster.ShiftId, ParameterDirection.Output)
                db.AddParameter("p_SHIFT_NO", pShiftDetailsMaster.ShiftNo)
                db.AddParameter("p_START_HRS", pShiftDetailsMaster.StartHrs)
                db.AddParameter("p_START_MIN", pShiftDetailsMaster.StartMin)
                db.AddParameter("p_END_HRS", pShiftDetailsMaster.EndHrs)
                db.AddParameter("p_END_MIN", pShiftDetailsMaster.EndMin)
                db.AddParameter("p_CREATED_BY", pShiftDetailsMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pShiftDetailsMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pShiftDetailsMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SHIFT_DETAILS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pShiftDetailsMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pShiftDetailsMaster.ShiftId  = db.Parameters.Item("p_SHIFT_ID").value
                
            Catch ex As Exception
                pShiftDetailsMaster.ErrorMsg = ex.Message
            End Try
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pShiftDetailsMaster"></param>
        ''' <returns>Return pShiftDetailsMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pShiftDetailsMaster.TerminalId)
                db.AddParameter("p_SHIFT_ID", pShiftDetailsMaster.ShiftId)
                db.AddParameter("p_SHIFT_NO", pShiftDetailsMaster.ShiftNo)
                db.AddParameter("p_START_HRS", pShiftDetailsMaster.StartHrs)
                db.AddParameter("p_START_MIN", pShiftDetailsMaster.StartMin)
                db.AddParameter("p_END_HRS", pShiftDetailsMaster.EndHrs)
                db.AddParameter("p_END_MIN", pShiftDetailsMaster.EndMin)
                db.AddParameter("p_CREATED_BY", pShiftDetailsMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pShiftDetailsMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pShiftDetailsMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SHIFT_DETAILS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pShiftDetailsMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pShiftDetailsMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pShiftDetailsMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pShiftDetailsMaster"></param>
        ''' <returns>Return pShiftDetailsMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pShiftDetailsMaster.TerminalId)
                db.AddParameter("p_SHIFT_ID", pShiftDetailsMaster.ShiftId)
                db.AddParameter("p_SHIFT_NO", pShiftDetailsMaster.ShiftNo)
                db.AddParameter("p_START_HRS", pShiftDetailsMaster.StartHrs)
                db.AddParameter("p_START_MIN", pShiftDetailsMaster.StartMin)
                db.AddParameter("p_END_HRS", pShiftDetailsMaster.EndHrs)
                db.AddParameter("p_END_MIN", pShiftDetailsMaster.EndMin)
                db.AddParameter("p_CREATED_BY", pShiftDetailsMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pShiftDetailsMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pShiftDetailsMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SHIFT_DETAILS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pShiftDetailsMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pShiftDetailsMaster.ErrorMsg = ex.Message
                End Try
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PShiftDetailsMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIFT_ID").ToString <> "" Then
                                PShiftDetailsMaster.ShiftId = dbr("SHIFT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIFT_NO").ToString <> "" Then
                                PShiftDetailsMaster.ShiftNo = dbr("SHIFT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("START_HRS").ToString <> "" Then
                                PShiftDetailsMaster.StartHrs = dbr("START_HRS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("START_MIN").ToString <> "" Then
                                PShiftDetailsMaster.StartMin = dbr("START_MIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("END_HRS").ToString <> "" Then
                                PShiftDetailsMaster.EndHrs = dbr("END_HRS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("END_MIN").ToString <> "" Then
                                PShiftDetailsMaster.EndMin = dbr("END_MIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PShiftDetailsMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PShiftDetailsMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pShiftDetailsMaster.ErrorMsg = ex.Message
            End Try
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrShiftDetailsMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ShiftDetailsMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIFT_ID").ToString <> "" Then
                                temp.ShiftId = dbr("SHIFT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIFT_NO").ToString <> "" Then
                                temp.ShiftNo = dbr("SHIFT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("START_HRS").ToString <> "" Then
                                temp.StartHrs = dbr("START_HRS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("START_MIN").ToString <> "" Then
                                temp.StartMin = dbr("START_MIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("END_HRS").ToString <> "" Then
                                temp.EndHrs = dbr("END_HRS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("END_MIN").ToString <> "" Then
                                temp.EndMin = dbr("END_MIN")
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
        Public Shared Function ReturnShiftDetailsMaster(ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ShiftDetailsMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SHIFT_DETAILS_MASTER_BY_ID", pShiftDetailsMaster.TerminalId & "," & pShiftDetailsMaster.ShiftId)
                pShiftDetailsMaster = ReturnObjectValues(dbr, pShiftDetailsMaster)
                dbr.Close()
            Catch ex As Exception
                pShiftDetailsMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pShiftDetailsMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnShiftDetailsMasterList (ByVal pShiftDetailsMaster As ShiftDetailsMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrShiftDetailsMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SHIFT_DETAILS_MASTER_ALL", pShiftDetailsMaster.TerminalId)
                arrShiftDetailsMaster = ReturnObjectValuesList(dbr, arrShiftDetailsMaster)
                dbr.Close()
            Catch ex As Exception
                arrShiftDetailsMaster = Nothing
            End Try
            db.CloseDB()
            Return arrShiftDetailsMaster
        End Function
    End Class
End Namespace
