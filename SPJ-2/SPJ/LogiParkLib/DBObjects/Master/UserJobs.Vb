Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UserJobs
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UserJobs 
    
        Private strUserId As String ' Define Private Variable UserId With DataType As String 
        Private lngJobId As Long ' Define Private Variable JobId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of UserId
        ''' </summary>
        ''' <value>strUserId</value>
        ''' <returns> Return strUserId</returns>
        ''' <remarks> Get or Set the Value of UserId  </remarks>
        '''
        Public Property UserId() as String
            Get
                Return strUserId
            End Get
            Set(ByVal value As String)
                strUserId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JobId
        ''' </summary>
        ''' <value>lngJobId</value>
        ''' <returns> Return lngJobId</returns>
        ''' <remarks> Get or Set the Value of JobId  </remarks>
        '''
        Public Property JobId() as Long
            Get
                Return lngJobId
            End Get
            Set(ByVal value As Long)
                lngJobId = value
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
            strUserId = ""
            lngJobId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUserJobs"></param>
        ''' <returns>Return pUserJobs Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUserJobs As UserJobs) As UserJobs
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJobs.UserId)
                db.AddParameter("p_JOB_ID", pUserJobs.JobId)
                db.AddParameter("p_ErrorMsg", pUserJobs.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_JOBS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJobs.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pUserJobs.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserJobs.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserJobs"></param>
        ''' <returns>Return pUserJobs Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUserJobs As UserJobs) As UserJobs
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJobs.UserId)
                db.AddParameter("p_JOB_ID", pUserJobs.JobId)
                db.AddParameter("p_ErrorMsg", pUserJobs.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_JOBS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJobs.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pUserJobs.ErrorMsg = ex.Message
            End Try
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Delete Member Function to Delete the all record By UserId
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserJobs"></param>
        ''' <returns>Return pUserJobs Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function DeleteTrn(ByVal db As DBConnect, ByVal pUserJobs As UserJobs) As UserJobs
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJobs.UserId)
                db.AddParameter("p_JOB_ID", pUserJobs.JobId)
                db.AddParameter("p_ErrorMsg", pUserJobs.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DELETE_USER_JOBS_BY_USER_ID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJobs.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pUserJobs.Errormsg = ex.Message
            End Try
            Return pUserJobs
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserJobs"></param>
        ''' <returns>Return pUserJobs Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUserJobs As UserJobs) As UserJobs
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJobs.UserId)
                db.AddParameter("p_JOB_ID", pUserJobs.JobId)
                db.AddParameter("p_ErrorMsg", pUserJobs.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_JOBS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJobs.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserJobs.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserJobs.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserJobs"></param>
        ''' <returns>Return pUserJobs Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUserJobs As UserJobs) As UserJobs
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJobs.UserId)
                db.AddParameter("p_JOB_ID", pUserJobs.JobId)
                db.AddParameter("p_ErrorMsg", pUserJobs.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_JOBS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJobs.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pUserJobs.ErrorMsg = ex.Message
                End Try
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUserJobs As UserJobs) As UserJobs
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                PUserJobs.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                PUserJobs.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pUserJobs.ErrorMsg = ex.Message
            End Try
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUserJobs As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UserJobs
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                temp.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                temp.JobId = dbr("JOB_ID")
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
        Public Shared Function ReturnUserJobsByUserId(ByVal pUserJobs As UserJobs) As UserJobs
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_JOBS_BY_ID", "'" & pUserJobs.UserId & "'")
                pUserJobs = ReturnObjectValues(dbr, pUserJobs)
                dbr.Close()
            Catch ex As Exception
                pUserJobs.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pUserJobs
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By UserId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUserJobsListByUserId(ByVal pUserJobs As UserJobs) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserJobs As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_JOBS_BY_ID_ALL", "'" & pUserJobs.UserId & "'")
                arrUserJobs = ReturnObjectValuesList(dbr, arrUserJobs)
                dbr.Close()
            Catch ex As Exception
                arrUserJobs = Nothing
            End Try
            db.CloseDB()
            Return arrUserJobs
        End Function
        Public Shared Function DeleteTrnByUserId(ByVal db As DBConnect, ByVal pUserJob As UserJobs) As UserJobs
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserJob.UserId)
                db.AddParameter("p_ErrorMsg", pUserJob.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_UB_UC_UJ_DELETE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserJob.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUserJob.Errormsg = ex.Message
            End Try
            Return pUserJob
        End Function
    End Class
End Namespace
