Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DispatchTracking
    ''' @author	: Amit K. Singh- 13/9/2022
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class DispatchTracking 
    
        Private lngDisptachTrackId As Long ' Define Private Variable DisptachTrackId With DataType As Long 
        Private strJobNo As String ' Define Private Variable JobNo With DataType As String 
        Private strSendingDate As String ' Define Private Variable SendingDate With DataType As String 
        Private strSendingDispatch As String ' Define Private Variable SendingDispatch With DataType As String 
        Private strFileRecDate As String ' Define Private Variable FileRecDate With DataType As String 
        Private strSoftCopyDate As String ' Define Private Variable SoftCopyDate With DataType As String 
        Private strHardCopyDate As String ' Define Private Variable HardCopyDate With DataType As String 
        Private strFilereceived As String ' Define Private Variable Filereceived With DataType As String
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of DisptachTrackId
        ''' </summary>
        ''' <value>lngDisptachTrackId</value>
        ''' <returns> Return lngDisptachTrackId</returns>
        ''' <remarks> Get or Set the Value of DisptachTrackId  </remarks>
        '''
        Public Property DisptachTrackId() as Long
            Get
                Return lngDisptachTrackId
            End Get
            Set(ByVal value As Long)
                lngDisptachTrackId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JobNo
        ''' </summary>
        ''' <value>strJobNo</value>
        ''' <returns> Return strJobNo</returns>
        ''' <remarks> Get or Set the Value of JobNo  </remarks>
        '''
        Public Property JobNo() as String
            Get
                Return strJobNo
            End Get
            Set(ByVal value As String)
                strJobNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SendingDate
        ''' </summary>
        ''' <value>strSendingDate</value>
        ''' <returns> Return strSendingDate</returns>
        ''' <remarks> Get or Set the Value of SendingDate  </remarks>
        '''
        Public Property SendingDate() as String
            Get
                Return strSendingDate
            End Get
            Set(ByVal value As String)
                strSendingDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SendingDispatch
        ''' </summary>
        ''' <value>strSendingDispatch</value>
        ''' <returns> Return strSendingDispatch</returns>
        ''' <remarks> Get or Set the Value of SendingDispatch  </remarks>
        '''
        Public Property SendingDispatch() as String
            Get
                Return strSendingDispatch
            End Get
            Set(ByVal value As String)
                strSendingDispatch = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FileRecDate
        ''' </summary>
        ''' <value>strFileRecDate</value>
        ''' <returns> Return strFileRecDate</returns>
        ''' <remarks> Get or Set the Value of FileRecDate  </remarks>
        '''
        Public Property FileRecDate() as String
            Get
                Return strFileRecDate
            End Get
            Set(ByVal value As String)
                strFileRecDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SoftCopyDate
        ''' </summary>
        ''' <value>strSoftCopyDate</value>
        ''' <returns> Return strSoftCopyDate</returns>
        ''' <remarks> Get or Set the Value of SoftCopyDate  </remarks>
        '''
        Public Property SoftCopyDate() as String
            Get
                Return strSoftCopyDate
            End Get
            Set(ByVal value As String)
                strSoftCopyDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of HardCopyDate
        ''' </summary>
        ''' <value>strHardCopyDate</value>
        ''' <returns> Return strHardCopyDate</returns>
        ''' <remarks> Get or Set the Value of HardCopyDate  </remarks>
        '''
        Public Property HardCopyDate() As String
            Get
                Return strHardCopyDate
            End Get
            Set(ByVal value As String)
                strHardCopyDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Filereceived
        ''' </summary>
        ''' <value>strFilereceived</value>
        ''' <returns> Return strFilereceived</returns>
        ''' <remarks> Get or Set the Value of Filereceived  </remarks>
        '''
        Public Property FileReceivedDispatch() As String
            Get
                Return strFilereceived
            End Get
            Set(ByVal value As String)
                strFilereceived = value
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
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() as String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
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
            lngDisptachTrackId = 0 
            strJobNo = ""
            strSendingDate = ""
            strSendingDispatch = ""
            strFileRecDate = ""
            strSoftCopyDate = ""
            strHardCopyDate = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strRemarks = ""
            strFilereceived = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pDispatchTracking"></param>
        ''' <returns>Return pDispatchTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_DISPTACH_TRACK_ID", pDispatchTracking.DisptachTrackId)
                db.AddParameter("p_JOB_NO", pDispatchTracking.JobNo)
                db.AddParameter("p_SENDING_DATE", pDispatchTracking.SendingDate)
                db.AddParameter("p_SENDING_DISPATCH", pDispatchTracking.SendingDispatch)
                db.AddParameter("p_FILE_REC_DATE", pDispatchTracking.FileRecDate)
                db.AddParameter("p_SOFT_COPY_DATE", pDispatchTracking.SoftCopyDate)
                db.AddParameter("p_HARD_COPY_DATE", pDispatchTracking.HardCopyDate)
                db.AddParameter("p_CREATED_BY", pDispatchTracking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDispatchTracking.CreatedOn)
                db.AddParameter("p_REMARKS", pDispatchTracking.Remarks)
                db.AddParameter("p_ErrorMsg", pDispatchTracking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DISPATCH_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDispatchTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pDispatchTracking.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDispatchTracking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDispatchTracking"></param>
        ''' <returns>Return pDispatchTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Try
                db.ClearParameters()
                db.AddParameter("p_DISPTACH_TRACK_ID", pDispatchTracking.DisptachTrackId)
                db.AddParameter("p_JOB_NO", pDispatchTracking.JobNo)
                db.AddParameter("p_SENDING_DATE", pDispatchTracking.SendingDate)
                db.AddParameter("p_SENDING_DISPATCH", pDispatchTracking.SendingDispatch)
                db.AddParameter("p_FILE_REC_DATE", pDispatchTracking.FileRecDate)
                db.AddParameter("p_SOFT_COPY_DATE", pDispatchTracking.SoftCopyDate)
                db.AddParameter("p_HARD_COPY_DATE", pDispatchTracking.HardCopyDate)
                db.AddParameter("p_CREATED_BY", pDispatchTracking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDispatchTracking.CreatedOn)
                db.AddParameter("p_REMARKS", pDispatchTracking.Remarks)
                db.AddParameter("p_ErrorMsg", pDispatchTracking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DISPATCH_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDispatchTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pDispatchTracking.ErrorMsg = ex.Message
            End Try
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pDispatchTracking"></param>
        ''' <returns>Return pDispatchTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_DISPTACH_TRACK_ID", pDispatchTracking.DisptachTrackId)
                db.AddParameter("p_JOB_NO", pDispatchTracking.JobNo)
                db.AddParameter("p_SENDING_DATE", pDispatchTracking.SendingDate)
                db.AddParameter("p_SENDING_DISPATCH", pDispatchTracking.SendingDispatch)
                db.AddParameter("p_FILE_REC_DATE", pDispatchTracking.FileRecDate)
                db.AddParameter("p_SOFT_COPY_DATE", pDispatchTracking.SoftCopyDate)
                db.AddParameter("p_HARD_COPY_DATE", pDispatchTracking.HardCopyDate)
                db.AddParameter("p_CREATED_BY", pDispatchTracking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDispatchTracking.CreatedOn)
                db.AddParameter("p_REMARKS", pDispatchTracking.Remarks)
                db.AddParameter("p_FILE_REC_DISPATCH", pDispatchTracking.FileReceivedDispatch)
                db.AddParameter("p_ErrorMsg", pDispatchTracking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DISPATCH_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDispatchTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pDispatchTracking.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDispatchTracking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDispatchTracking"></param>
        ''' <returns>Return pDispatchTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Try
                db.ClearParameters()
                db.AddParameter("p_DISPTACH_TRACK_ID", pDispatchTracking.DisptachTrackId)
                db.AddParameter("p_JOB_NO", pDispatchTracking.JobNo)
                db.AddParameter("p_SENDING_DATE", pDispatchTracking.SendingDate)
                db.AddParameter("p_SENDING_DISPATCH", pDispatchTracking.SendingDispatch)
                db.AddParameter("p_FILE_REC_DATE", pDispatchTracking.FileRecDate)
                db.AddParameter("p_SOFT_COPY_DATE", pDispatchTracking.SoftCopyDate)
                db.AddParameter("p_HARD_COPY_DATE", pDispatchTracking.HardCopyDate)
                db.AddParameter("p_CREATED_BY", pDispatchTracking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDispatchTracking.CreatedOn)
                db.AddParameter("p_REMARKS", pDispatchTracking.Remarks)
                db.AddParameter("p_ErrorMsg", pDispatchTracking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DISPATCH_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDispatchTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pDispatchTracking.ErrorMsg = ex.Message
                End Try
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("DISPTACH_TRACK_ID").ToString <> "" Then
                                PDispatchTracking.DisptachTrackId = dbr("DISPTACH_TRACK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_NO").ToString <> "" Then
                                PDispatchTracking.JobNo = dbr("JOB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SENDING_DATE").ToString <> "" Then
                                PDispatchTracking.SendingDate = dbr("SENDING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SENDING_DISPATCH").ToString <> "" Then
                                PDispatchTracking.SendingDispatch = dbr("SENDING_DISPATCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_REC_DATE").ToString <> "" Then
                                PDispatchTracking.FileRecDate = dbr("FILE_REC_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SOFT_COPY_DATE").ToString <> "" Then
                                PDispatchTracking.SoftCopyDate = dbr("SOFT_COPY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HARD_COPY_DATE").ToString <> "" Then
                                PDispatchTracking.HardCopyDate = dbr("HARD_COPY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PDispatchTracking.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PDispatchTracking.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PDispatchTracking.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_REC_DISPATCH").ToString <> "" Then
                                pDispatchTracking.FileReceivedDispatch = dbr("FILE_REC_DISPATCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pDispatchTracking.ErrorMsg = ex.Message
            End Try
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrDispatchTracking As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New DispatchTracking
                        Try
                            If dbr("DISPTACH_TRACK_ID").ToString <> "" Then
                                temp.DisptachTrackId = dbr("DISPTACH_TRACK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_NO").ToString <> "" Then
                                temp.JobNo = dbr("JOB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SENDING_DATE").ToString <> "" Then
                                temp.SendingDate = dbr("SENDING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SENDING_DISPATCH").ToString <> "" Then
                                temp.SendingDispatch = dbr("SENDING_DISPATCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_REC_DATE").ToString <> "" Then
                                temp.FileRecDate = dbr("FILE_REC_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SOFT_COPY_DATE").ToString <> "" Then
                                temp.SoftCopyDate = dbr("SOFT_COPY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HARD_COPY_DATE").ToString <> "" Then
                                temp.HardCopyDate = dbr("HARD_COPY_DATE")
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
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_REC_DISPATCH").ToString <> "" Then
                                temp.FileReceivedDispatch = dbr("FILE_REC_DISPATCH")
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
        Public Shared Function ReturnDispatchTracking(ByVal pDispatchTracking As DispatchTracking) As DispatchTracking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DISPATCH_TRACKING", "' '")
                pDispatchTracking = ReturnObjectValues(dbr, pDispatchTracking)
                dbr.Close()
            Catch ex As Exception
                pDispatchTracking.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pDispatchTracking
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnDispatchTrackingList (ByVal pDispatchTracking As DispatchTracking) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrDispatchTracking As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DISPATCH_TRACKING", "' '")
                arrDispatchTracking = ReturnObjectValuesList(dbr, arrDispatchTracking)
                dbr.Close()
            Catch ex As Exception
                arrDispatchTracking = Nothing
            End Try
            db.CloseDB()
            Return arrDispatchTracking
        End Function
    End Class
End Namespace
