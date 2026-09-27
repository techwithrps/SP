Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UploadFile
    ''' @author	: Amit K. Singh- 14/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UploadFile 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngFileId As Long ' Define Private Variable FileId With DataType As Long 
        Private strFileName As String ' Define Private Variable FileName With DataType As String 
        Private strFileType As String ' Define Private Variable FileType With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngTempMsgId As Long

        Private strIgmNo As String
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

        Public Property TempMsgId() As Long
            Get
                Return lngTempMsgId
            End Get
            Set(ByVal value As Long)
                lngTempMsgId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FileId
        ''' </summary>
        ''' <value>lngFileId</value>
        ''' <returns> Return lngFileId</returns>
        ''' <remarks> Get or Set the Value of FileId  </remarks>
        '''
        Public Property FileId() as Long
            Get
                Return lngFileId
            End Get
            Set(ByVal value As Long)
                lngFileId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FileName
        ''' </summary>
        ''' <value>strFileName</value>
        ''' <returns> Return strFileName</returns>
        ''' <remarks> Get or Set the Value of FileName  </remarks>
        '''
        Public Property FileName() as String
            Get
                Return strFileName
            End Get
            Set(ByVal value As String)
                strFileName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FileType
        ''' </summary>
        ''' <value>strFileType</value>
        ''' <returns> Return strFileType</returns>
        ''' <remarks> Get or Set the Value of FileType  </remarks>
        '''
        Public Property FileType() as String
            Get
                Return strFileType
            End Get
            Set(ByVal value As String)
                strFileType = value
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

        Public Property IGMNo() As String
            Get
                Return strIgmNo
            End Get
            Set(ByVal value As String)
                strIgmNo = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0 
            lngFileId = 0 
            strFileName = ""
            strFileType = ""
            strRemarks = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            strIgmNo = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUploadFile"></param>
        ''' <returns>Return pUploadFile Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUploadFile As UploadFile) As UploadFile
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFile.FileId, ParameterDirection.Output)
                db.AddParameter("p_FILE_NAME", pUploadFile.FileName)
                db.AddParameter("p_FILE_TYPE", pUploadFile.FileType)
                db.AddParameter("p_REMARKS", pUploadFile.Remarks)
                db.AddParameter("p_CREATED_BY", pUploadFile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUploadFile.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUploadFile.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPLOAD_IGM", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUploadFile.FileId = db.Parameters.Item("p_FILE_ID").value
                
                If pUploadFile.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUploadFile"></param>
        ''' <returns>Return pUploadFile Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUploadFile As UploadFile) As UploadFile
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFile.FileId, ParameterDirection.Output)
                db.AddParameter("p_FILE_NAME", pUploadFile.FileName)
                db.AddParameter("p_FILE_TYPE", pUploadFile.FileType)
                db.AddParameter("p_REMARKS", pUploadFile.Remarks)
                db.AddParameter("p_CREATED_BY", pUploadFile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUploadFile.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUploadFile.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_UPLOAD_IGM", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUploadFile.FileId = db.Parameters.Item("p_FILE_ID").value
                
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
            End Try
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUploadFile"></param>
        ''' <returns>Return pUploadFile Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUploadFile As UploadFile) As UploadFile
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFile.FileId)
                db.AddParameter("p_FILE_NAME", pUploadFile.FileName)
                db.AddParameter("p_FILE_TYPE", pUploadFile.FileType)
                db.AddParameter("p_REMARKS", pUploadFile.Remarks)
                db.AddParameter("p_CREATED_BY", pUploadFile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUploadFile.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUploadFile.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPDATE_UPLOAD_FILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUploadFile.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUploadFile"></param>
        ''' <returns>Return pUploadFile Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUploadFile As UploadFile) As UploadFile
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFile.FileId)
                db.AddParameter("p_FILE_NAME", pUploadFile.FileName)
                db.AddParameter("p_FILE_TYPE", pUploadFile.FileType)
                db.AddParameter("p_REMARKS", pUploadFile.Remarks)
                db.AddParameter("p_CREATED_BY", pUploadFile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUploadFile.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUploadFile.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPDATE_UPLOAD_FILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
            End Try
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUploadFile As UploadFile) As UploadFile
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PUploadFile.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_ID").ToString <> "" Then
                                PUploadFile.FileId = dbr("FILE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_NAME").ToString <> "" Then
                                PUploadFile.FileName = dbr("FILE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_TYPE").ToString <> "" Then
                                PUploadFile.FileType = dbr("FILE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PUploadFile.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PUploadFile.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PUploadFile.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
            End Try
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUploadFile As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UploadFile
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_ID").ToString <> "" Then
                                temp.FileId = dbr("FILE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_NAME").ToString <> "" Then
                                temp.FileName = dbr("FILE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_TYPE").ToString <> "" Then
                                temp.FileType = dbr("FILE_TYPE")
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
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function


        Public Shared Function GetTempMsgId(ByVal pUploadFile As UploadFile) As UploadFile
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_TEMP_MSG_ID", pUploadFile.TempMsgId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pUploadFile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_INSERT_SEQ_TEMP_MSG_ID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pUploadFile.TempMsgId = db.Parameters.Item("p_TEMP_MSG_ID").value
                End If
                If pUploadFile.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUploadFile.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnUploadFile(ByVal pUploadFile As UploadFile) As UploadFile
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("USP_SELECT_UPLOAD_FILE", "")
                pUploadFile = ReturnObjectValues(dbr, pUploadFile)
                dbr.Close()
            Catch ex As Exception
                pUploadFile.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUploadFile
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUploadFileList(ByVal pUploadFile As UploadFile) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUploadFile As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("USP_SELECT_UPLOAD_FILE", "' '")
                arrUploadFile = ReturnObjectValuesList(dbr, arrUploadFile)
                dbr.Close()
            Catch ex As Exception
                arrUploadFile = Nothing
            End Try
            db.CloseDB()
            Return arrUploadFile
        End Function
    End Class
End Namespace
