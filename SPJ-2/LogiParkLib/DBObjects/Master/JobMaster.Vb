Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: JobMaster
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class JobMaster 
    
        Private lngJobId As Long ' Define Private Variable JobId With DataType As Long 
        Private lngModuleId As Long ' Define Private Variable ModuleId With DataType As Long 
        Private strJobName As String ' Define Private Variable JobName With DataType As String 
        Private strDescription As String ' Define Private Variable Description With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
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
        ''' Get or Set the Value of ModuleId
        ''' </summary>
        ''' <value>lngModuleId</value>
        ''' <returns> Return lngModuleId</returns>
        ''' <remarks> Get or Set the Value of ModuleId  </remarks>
        '''
        Public Property ModuleId() as Long
            Get
                Return lngModuleId
            End Get
            Set(ByVal value As Long)
                lngModuleId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JobName
        ''' </summary>
        ''' <value>strJobName</value>
        ''' <returns> Return strJobName</returns>
        ''' <remarks> Get or Set the Value of JobName  </remarks>
        '''
        Public Property JobName() as String
            Get
                Return strJobName
            End Get
            Set(ByVal value As String)
                strJobName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Description
        ''' </summary>
        ''' <value>strDescription</value>
        ''' <returns> Return strDescription</returns>
        ''' <remarks> Get or Set the Value of Description  </remarks>
        '''
        Public Property Description() as String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
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
            lngJobId = 0 
            lngModuleId = 0 
            strJobName = ""
            strDescription = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pJobMaster"></param>
        ''' <returns>Return pJobMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pJobMaster As JobMaster) As JobMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMaster.JobId)
                db.AddParameter("p_MODULE_ID", pJobMaster.ModuleId)
                db.AddParameter("p_JOB_NAME", pJobMaster.JobName)
                db.AddParameter("p_DESCRIPTION", pJobMaster.Description)
                db.AddParameter("p_ErrorMsg", pJobMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJobMaster.JobId = db.Parameters.Item("p_JOB_ID").value

                If pJobMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobMaster"></param>
        ''' <returns>Return pJobMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pJobMaster As JobMaster) As JobMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMaster.JobId, ParameterDirection.InputOutput)
                db.AddParameter("p_MODULE_ID", pJobMaster.ModuleId)
                db.AddParameter("p_JOB_NAME", pJobMaster.JobName)
                db.AddParameter("p_DESCRIPTION", pJobMaster.Description)
                db.AddParameter("p_ErrorMsg", pJobMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJobMaster.JobId = db.Parameters.Item("p_JOB_ID").value
            Catch ex As Exception
                pJobMaster.ErrorMsg = ex.Message
            End Try
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pJobMaster"></param>
        ''' <returns>Return pJobMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pJobMaster As JobMaster) As JobMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMaster.JobId)
                db.AddParameter("p_MODULE_ID", pJobMaster.ModuleId)
                db.AddParameter("p_JOB_NAME", pJobMaster.JobName)
                db.AddParameter("p_DESCRIPTION", pJobMaster.Description)
                db.AddParameter("p_ErrorMsg", pJobMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pJobMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobMaster"></param>
        ''' <returns>Return pJobMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pJobMaster As JobMaster) As JobMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMaster.JobId)
                db.AddParameter("p_MODULE_ID", pJobMaster.ModuleId)
                db.AddParameter("p_JOB_NAME", pJobMaster.JobName)
                db.AddParameter("p_DESCRIPTION", pJobMaster.Description)
                db.AddParameter("p_ErrorMsg", pJobMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pJobMaster.ErrorMsg = ex.Message
                End Try
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pJobMaster As JobMaster) As JobMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                PJobMaster.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                PJobMaster.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_NAME").ToString <> "" Then
                                PJobMaster.JobName = dbr("JOB_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                PJobMaster.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pJobMaster.ErrorMsg = ex.Message
            End Try
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrJobMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New JobMaster
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                temp.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                temp.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_NAME").ToString <> "" Then
                                temp.JobName = dbr("JOB_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                temp.Description = dbr("DESCRIPTION")
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
        ''' Preparing Return Object By JobId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnJobMaster(ByVal pJobMaster As JobMaster) As JobMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MASTER_BY_ID", pJobMaster.JobId)
                pJobMaster = ReturnObjectValues(dbr, pJobMaster)
                dbr.Close()
            Catch ex As Exception
                pJobMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pJobMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnJobMasterList (ByVal pJobMaster As JobMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MASTER_ALL", " ")
                arrJobMaster = ReturnObjectValuesList(dbr, arrJobMaster)
                dbr.Close()
            Catch ex As Exception
                arrJobMaster = Nothing
            End Try
            db.CloseDB()
            Return arrJobMaster
        End Function
    End Class
End Namespace
