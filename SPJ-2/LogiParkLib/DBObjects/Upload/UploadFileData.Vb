Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UploadFileData
    ''' @author	: Amit K. Singh- 14/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UploadFileData 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngFileId As Long ' Define Private Variable FileId With DataType As Long 
        Private lngRecordId As Long ' Define Private Variable RecordId With DataType As Long 
        Private strFileData As String ' Define Private Variable FileData With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
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
        ''' Get or Set the Value of RecordId
        ''' </summary>
        ''' <value>lngRecordId</value>
        ''' <returns> Return lngRecordId</returns>
        ''' <remarks> Get or Set the Value of RecordId  </remarks>
        '''
        Public Property RecordId() as Long
            Get
                Return lngRecordId
            End Get
            Set(ByVal value As Long)
                lngRecordId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FileData
        ''' </summary>
        ''' <value>strFileData</value>
        ''' <returns> Return strFileData</returns>
        ''' <remarks> Get or Set the Value of FileData  </remarks>
        '''
        Public Property FileData() as String
            Get
                Return strFileData
            End Get
            Set(ByVal value As String)
                strFileData = value
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
            lngTerminalId = 0 
            lngFileId = 0 
            lngRecordId = 0 
            strFileData = ""
            strRemarks = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUploadFileData"></param>
        ''' <returns>Return pUploadFileData Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUploadFileData As UploadFileData) As UploadFileData
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFileData.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFileData.FileId, ParameterDirection.Output)
                db.AddParameter("p_RECORD_ID", pUploadFileData.RecordId)
                db.AddParameter("p_FILE_DATA", pUploadFileData.FileData)
                db.AddParameter("p_REMARKS", pUploadFileData.Remarks)
                db.AddParameter("p_ErrorMsg", pUploadFileData.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPLOAD_FILE_DATA", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFileData.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUploadFileData.TerminalId  = db.Parameters.Item("p_TERMINAL_ID").value
                pUploadFileData.FileId  = db.Parameters.Item("p_FILE_ID").value
                
                If pUploadFileData.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUploadFileData"></param>
        ''' <returns>Return pUploadFileData Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUploadFileData As UploadFileData) As UploadFileData
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFileData.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFileData.FileId)
                db.AddParameter("p_RECORD_ID", pUploadFileData.RecordId, ParameterDirection.Output)
                db.AddParameter("p_FILE_DATA", pUploadFileData.FileData)
                db.AddParameter("p_REMARKS", pUploadFileData.Remarks)
                db.AddParameter("p_ErrorMsg", pUploadFileData.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_UPLOAD_FILE_DATA", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFileData.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                pUploadFileData.RecordId = db.Parameters.Item("p_RECORD_ID").value
                
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
            End Try
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUploadFileData"></param>
        ''' <returns>Return pUploadFileData Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUploadFileData As UploadFileData) As UploadFileData
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFileData.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFileData.FileId)
                db.AddParameter("p_RECORD_ID", pUploadFileData.RecordId)
                db.AddParameter("p_FILE_DATA", pUploadFileData.FileData)
                db.AddParameter("p_REMARKS", pUploadFileData.Remarks)
                db.AddParameter("p_ErrorMsg", pUploadFileData.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPDATE_UPLOAD_FILE_DATA", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFileData.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUploadFileData.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUploadFileData"></param>
        ''' <returns>Return pUploadFileData Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUploadFileData As UploadFileData) As UploadFileData
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFileData.TerminalId)
                db.AddParameter("p_FILE_ID", pUploadFileData.FileId)
                db.AddParameter("p_RECORD_ID", pUploadFileData.RecordId)
                db.AddParameter("p_FILE_DATA", pUploadFileData.FileData)
                db.AddParameter("p_REMARKS", pUploadFileData.Remarks)
                db.AddParameter("p_ErrorMsg", pUploadFileData.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("USP_UPDATE_UPLOAD_FILE_DATA", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFileData.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
            End Try
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUploadFileData As UploadFileData) As UploadFileData
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PUploadFileData.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_ID").ToString <> "" Then
                                PUploadFileData.FileId = dbr("FILE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECORD_ID").ToString <> "" Then
                                PUploadFileData.RecordId = dbr("RECORD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_DATA").ToString <> "" Then
                                PUploadFileData.FileData = dbr("FILE_DATA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PUploadFileData.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
            End Try
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUploadFileData As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UploadFileData
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
                            If dbr("RECORD_ID").ToString <> "" Then
                                temp.RecordId = dbr("RECORD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FILE_DATA").ToString <> "" Then
                                temp.FileData = dbr("FILE_DATA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
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

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnUploadFileData(ByVal pUploadFileData As UploadFileData) As UploadFileData
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("USP_SELECT_UPLOAD_FILE_DATA", "' '")
                pUploadFileData = ReturnObjectValues(dbr, pUploadFileData)
                dbr.Close()
            Catch ex As Exception
                pUploadFileData.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUploadFileData
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUploadFileDataList(ByVal pUploadFileData As UploadFileData) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUploadFileData As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("USP_SELECT_UPLOAD_FILE_DATA", "' '")
                arrUploadFileData = ReturnObjectValuesList(dbr, arrUploadFileData)
                dbr.Close()
            Catch ex As Exception
                arrUploadFileData = Nothing
            End Try
            db.CloseDB()
            Return arrUploadFileData
        End Function
    End Class
End Namespace
