Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: JoReferences
    ''' @author	: Amit K. Singh- 27/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class JoReferences 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngJoId As Long ' Define Private Variable JoId With DataType As Long 
        Private strJoCode As String ' Define Private Variable JoCode With DataType As String 
        Private strJoDescription As String ' Define Private Variable JoDescription With DataType As String 
        Private strRefStart As String ' Define Private Variable RefStart With DataType As String 
        Private lngRefLength As Long ' Define Private Variable RefLength With DataType As Long 
        Private lngRefNo As Long ' Define Private Variable RefNo With DataType As Long 
        Private strRefEnd As String ' Define Private Variable RefEnd With DataType As String 
        Private lngModuleId As Long ' Define Private Variable ModuleId With DataType As Long 
        Private lngRefKeyId As Long ' Define Private Variable RefKeyId With DataType As Long 
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
        ''' Get or Set the Value of JoId
        ''' </summary>
        ''' <value>lngJoId</value>
        ''' <returns> Return lngJoId</returns>
        ''' <remarks> Get or Set the Value of JoId  </remarks>
        '''
        Public Property JoId() as Long
            Get
                Return lngJoId
            End Get
            Set(ByVal value As Long)
                lngJoId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoCode
        ''' </summary>
        ''' <value>strJoCode</value>
        ''' <returns> Return strJoCode</returns>
        ''' <remarks> Get or Set the Value of JoCode  </remarks>
        '''
        Public Property JoCode() as String
            Get
                Return strJoCode
            End Get
            Set(ByVal value As String)
                strJoCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoDescription
        ''' </summary>
        ''' <value>strJoDescription</value>
        ''' <returns> Return strJoDescription</returns>
        ''' <remarks> Get or Set the Value of JoDescription  </remarks>
        '''
        Public Property JoDescription() as String
            Get
                Return strJoDescription
            End Get
            Set(ByVal value As String)
                strJoDescription = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RefStart
        ''' </summary>
        ''' <value>strRefStart</value>
        ''' <returns> Return strRefStart</returns>
        ''' <remarks> Get or Set the Value of RefStart  </remarks>
        '''
        Public Property RefStart() as String
            Get
                Return strRefStart
            End Get
            Set(ByVal value As String)
                strRefStart = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RefLength
        ''' </summary>
        ''' <value>lngRefLength</value>
        ''' <returns> Return lngRefLength</returns>
        ''' <remarks> Get or Set the Value of RefLength  </remarks>
        '''
        Public Property RefLength() as Long
            Get
                Return lngRefLength
            End Get
            Set(ByVal value As Long)
                lngRefLength = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RefNo
        ''' </summary>
        ''' <value>lngRefNo</value>
        ''' <returns> Return lngRefNo</returns>
        ''' <remarks> Get or Set the Value of RefNo  </remarks>
        '''
        Public Property RefNo() as Long
            Get
                Return lngRefNo
            End Get
            Set(ByVal value As Long)
                lngRefNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RefEnd
        ''' </summary>
        ''' <value>strRefEnd</value>
        ''' <returns> Return strRefEnd</returns>
        ''' <remarks> Get or Set the Value of RefEnd  </remarks>
        '''
        Public Property RefEnd() as String
            Get
                Return strRefEnd
            End Get
            Set(ByVal value As String)
                strRefEnd = value
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
        ''' Get or Set the Value of RefKeyId
        ''' </summary>
        ''' <value>lngRefKeyId</value>
        ''' <returns> Return lngRefKeyId</returns>
        ''' <remarks> Get or Set the Value of RefKeyId  </remarks>
        '''
        Public Property RefKeyId() as Long
            Get
                Return lngRefKeyId
            End Get
            Set(ByVal value As Long)
                lngRefKeyId = value
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
            lngJoId = 0 
            strJoCode = ""
            strJoDescription = ""
            strRefStart = ""
            lngRefLength = 0 
            lngRefNo = 0 
            strRefEnd = ""
            lngModuleId = 0 
            lngRefKeyId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pJoReferences"></param>
        ''' <returns>Return pJoReferences Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pJoReferences As JoReferences) As JoReferences
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJoReferences.TerminalId)
                db.AddParameter("p_JO_ID", pJoReferences.JoId)
                db.AddParameter("p_JO_CODE", pJoReferences.JoCode)
                db.AddParameter("p_JO_DESCRIPTION", pJoReferences.JoDescription)
                db.AddParameter("p_REF_START", pJoReferences.RefStart)
                db.AddParameter("p_REF_LENGTH", pJoReferences.RefLength)
                db.AddParameter("p_REF_NO", pJoReferences.RefNo)
                db.AddParameter("p_REF_END", pJoReferences.RefEnd)
                db.AddParameter("p_MODULE_ID", pJoReferences.ModuleId)
                db.AddParameter("p_REF_KEY_ID", pJoReferences.RefKeyId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pJoReferences.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JO_REFERENCES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJoReferences.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJoReferences.RefKeyId = db.Parameters.Item("p_REF_KEY_ID").value
                If pJoReferences.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJoReferences.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJoReferences"></param>
        ''' <returns>Return pJoReferences Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pJoReferences As JoReferences) As JoReferences
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJoReferences.TerminalId)
                db.AddParameter("p_JO_ID", pJoReferences.JoId)
                db.AddParameter("p_JO_CODE", pJoReferences.JoCode)
                db.AddParameter("p_JO_DESCRIPTION", pJoReferences.JoDescription)
                db.AddParameter("p_REF_START", pJoReferences.RefStart)
                db.AddParameter("p_REF_LENGTH", pJoReferences.RefLength)
                db.AddParameter("p_REF_NO", pJoReferences.RefNo)
                db.AddParameter("p_REF_END", pJoReferences.RefEnd)
                db.AddParameter("p_MODULE_ID", pJoReferences.ModuleId)
                db.AddParameter("p_REF_KEY_ID", pJoReferences.RefKeyId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pJoReferences.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JO_REFERENCES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJoReferences.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJoReferences.RefKeyId = db.Parameters.Item("p_REF_KEY_ID").value
                
            Catch ex As Exception
                pJoReferences.ErrorMsg = ex.Message
            End Try
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pJoReferences"></param>
        ''' <returns>Return pJoReferences Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pJoReferences As JoReferences) As JoReferences
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJoReferences.TerminalId)
                db.AddParameter("p_JO_ID", pJoReferences.JoId)
                db.AddParameter("p_JO_CODE", pJoReferences.JoCode)
                db.AddParameter("p_JO_DESCRIPTION", pJoReferences.JoDescription)
                db.AddParameter("p_REF_START", pJoReferences.RefStart)
                db.AddParameter("p_REF_LENGTH", pJoReferences.RefLength)
                db.AddParameter("p_REF_NO", pJoReferences.RefNo)
                db.AddParameter("p_REF_END", pJoReferences.RefEnd)
                db.AddParameter("p_MODULE_ID", pJoReferences.ModuleId)
                db.AddParameter("p_REF_KEY_ID", pJoReferences.RefKeyId)
                db.AddParameter("p_ErrorMsg", pJoReferences.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JO_REFERENCES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJoReferences.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pJoReferences.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJoReferences.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJoReferences"></param>
        ''' <returns>Return pJoReferences Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pJoReferences As JoReferences) As JoReferences
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJoReferences.TerminalId)
                db.AddParameter("p_JO_ID", pJoReferences.JoId)
                db.AddParameter("p_JO_CODE", pJoReferences.JoCode)
                db.AddParameter("p_JO_DESCRIPTION", pJoReferences.JoDescription)
                db.AddParameter("p_REF_START", pJoReferences.RefStart)
                db.AddParameter("p_REF_LENGTH", pJoReferences.RefLength)
                db.AddParameter("p_REF_NO", pJoReferences.RefNo)
                db.AddParameter("p_REF_END", pJoReferences.RefEnd)
                db.AddParameter("p_MODULE_ID", pJoReferences.ModuleId)
                db.AddParameter("p_REF_KEY_ID", pJoReferences.RefKeyId)
                db.AddParameter("p_ErrorMsg", pJoReferences.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JO_REFERENCES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJoReferences.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pJoReferences.ErrorMsg = ex.Message
                End Try
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pJoReferences As JoReferences) As JoReferences
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PJoReferences.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                PJoReferences.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_CODE").ToString <> "" Then
                                PJoReferences.JoCode = dbr("JO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DESCRIPTION").ToString <> "" Then
                                PJoReferences.JoDescription = dbr("JO_DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_START").ToString <> "" Then
                                PJoReferences.RefStart = dbr("REF_START")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_LENGTH").ToString <> "" Then
                                PJoReferences.RefLength = dbr("REF_LENGTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_NO").ToString <> "" Then
                                PJoReferences.RefNo = dbr("REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_END").ToString <> "" Then
                                PJoReferences.RefEnd = dbr("REF_END")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                PJoReferences.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_KEY_ID").ToString <> "" Then
                                PJoReferences.RefKeyId = dbr("REF_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pJoReferences.ErrorMsg = ex.Message
            End Try
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrJoReferences As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New JoReferences
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                temp.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_CODE").ToString <> "" Then
                                temp.JoCode = dbr("JO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DESCRIPTION").ToString <> "" Then
                                temp.JoDescription = dbr("JO_DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_START").ToString <> "" Then
                                temp.RefStart = dbr("REF_START")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_LENGTH").ToString <> "" Then
                                temp.RefLength = dbr("REF_LENGTH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_NO").ToString <> "" Then
                                temp.RefNo = dbr("REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_END").ToString <> "" Then
                                temp.RefEnd = dbr("REF_END")
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
                            If dbr("REF_KEY_ID").ToString <> "" Then
                                temp.RefKeyId = dbr("REF_KEY_ID")
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
        Public Shared Function ReturnJoReferences(ByVal pJoReferences As JoReferences) As JoReferences
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JO_REFERENCES_BY_ID", pJoReferences.TerminalId & "," & pJoReferences.RefKeyId)
                pJoReferences = ReturnObjectValues(dbr, pJoReferences)
                dbr.Close()
            Catch ex As Exception
                pJoReferences.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pJoReferences
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnJoReferencesList (ByVal pJoReferences As JoReferences) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJoReferences As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JO_REFERENCES_ALL", pJoReferences.TerminalId)
                arrJoReferences = ReturnObjectValuesList(dbr, arrJoReferences)
                dbr.Close()
            Catch ex As Exception
                arrJoReferences = Nothing
            End Try
            db.CloseDB()
            Return arrJoReferences
        End Function
    End Class
End Namespace
