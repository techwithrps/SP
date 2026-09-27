Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: JobOrderType
    ''' @author	: Amit K. Singh- 27/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class JobOrderType 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strJoTypeCode As String ' Define Private Variable JoTypeCode With DataType As String 
        Private strJoTypeName As String ' Define Private Variable JoTypeName With DataType As String 
        Private strDocId As String ' Define Private Variable DocId With DataType As String 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private lngJoTypeId As Long ' Define Private Variable JoTypeId With DataType As Long 
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
        ''' Get or Set the Value of JoTypeCode
        ''' </summary>
        ''' <value>strJoTypeCode</value>
        ''' <returns> Return strJoTypeCode</returns>
        ''' <remarks> Get or Set the Value of JoTypeCode  </remarks>
        '''
        Public Property JoTypeCode() as String
            Get
                Return strJoTypeCode
            End Get
            Set(ByVal value As String)
                strJoTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoTypeName
        ''' </summary>
        ''' <value>strJoTypeName</value>
        ''' <returns> Return strJoTypeName</returns>
        ''' <remarks> Get or Set the Value of JoTypeName  </remarks>
        '''
        Public Property JoTypeName() as String
            Get
                Return strJoTypeName
            End Get
            Set(ByVal value As String)
                strJoTypeName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DocId
        ''' </summary>
        ''' <value>strDocId</value>
        ''' <returns> Return strDocId</returns>
        ''' <remarks> Get or Set the Value of DocId  </remarks>
        '''
        Public Property DocId() as String
            Get
                Return strDocId
            End Get
            Set(ByVal value As String)
                strDocId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() as Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoTypeId
        ''' </summary>
        ''' <value>lngJoTypeId</value>
        ''' <returns> Return lngJoTypeId</returns>
        ''' <remarks> Get or Set the Value of JoTypeId  </remarks>
        '''
        Public Property JoTypeId() as Long
            Get
                Return lngJoTypeId
            End Get
            Set(ByVal value As Long)
                lngJoTypeId = value
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
            strJoTypeCode = ""
            strJoTypeName = ""
            strDocId = ""
            lngServiceId = 0 
            lngJoTypeId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pJobOrderType"></param>
        ''' <returns>Return pJobOrderType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pJobOrderType As JobOrderType) As JobOrderType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJobOrderType.TerminalId)
                db.AddParameter("p_JO_TYPE_CODE", pJobOrderType.JoTypeCode)
                db.AddParameter("p_JO_TYPE_NAME", pJobOrderType.JoTypeName)
                db.AddParameter("p_DOC_ID", pJobOrderType.DocId)
                db.AddParameter("p_SERVICE_ID", pJobOrderType.ServiceId)
                db.AddParameter("p_JO_TYPE_ID", pJobOrderType.JoTypeId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pJobOrderType.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_ORDER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobOrderType.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJobOrderType.JoTypeId = db.Parameters.Item("p_JO_TYPE_ID").value
                If pJobOrderType.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobOrderType.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobOrderType"></param>
        ''' <returns>Return pJobOrderType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pJobOrderType As JobOrderType) As JobOrderType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJobOrderType.TerminalId)
                db.AddParameter("p_JO_TYPE_CODE", pJobOrderType.JoTypeCode)
                db.AddParameter("p_JO_TYPE_NAME", pJobOrderType.JoTypeName)
                db.AddParameter("p_DOC_ID", pJobOrderType.DocId)
                db.AddParameter("p_SERVICE_ID", pJobOrderType.ServiceId)
                db.AddParameter("p_JO_TYPE_ID", pJobOrderType.JoTypeId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pJobOrderType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_ORDER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobOrderType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pJobOrderType.JoTypeId = db.Parameters.Item("p_JO_TYPE_ID").value
            Catch ex As Exception
                pJobOrderType.ErrorMsg = ex.Message
            End Try
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pJobOrderType"></param>
        ''' <returns>Return pJobOrderType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pJobOrderType As JobOrderType) As JobOrderType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJobOrderType.TerminalId)
                db.AddParameter("p_JO_TYPE_CODE", pJobOrderType.JoTypeCode)
                db.AddParameter("p_JO_TYPE_NAME", pJobOrderType.JoTypeName)
                db.AddParameter("p_DOC_ID", pJobOrderType.DocId)
                db.AddParameter("p_SERVICE_ID", pJobOrderType.ServiceId)
                db.AddParameter("p_JO_TYPE_ID", pJobOrderType.JoTypeId)
                db.AddParameter("p_ErrorMsg", pJobOrderType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_ORDER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobOrderType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pJobOrderType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobOrderType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobOrderType"></param>
        ''' <returns>Return pJobOrderType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pJobOrderType As JobOrderType) As JobOrderType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pJobOrderType.TerminalId)
                db.AddParameter("p_JO_TYPE_CODE", pJobOrderType.JoTypeCode)
                db.AddParameter("p_JO_TYPE_NAME", pJobOrderType.JoTypeName)
                db.AddParameter("p_DOC_ID", pJobOrderType.DocId)
                db.AddParameter("p_SERVICE_ID", pJobOrderType.ServiceId)
                db.AddParameter("p_JO_TYPE_ID", pJobOrderType.JoTypeId)
                db.AddParameter("p_ErrorMsg", pJobOrderType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_ORDER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobOrderType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pJobOrderType.ErrorMsg = ex.Message
                End Try
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pJobOrderType As JobOrderType) As JobOrderType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PJobOrderType.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_CODE").ToString <> "" Then
                                PJobOrderType.JoTypeCode = dbr("JO_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_NAME").ToString <> "" Then
                                PJobOrderType.JoTypeName = dbr("JO_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_ID").ToString <> "" Then
                                PJobOrderType.DocId = dbr("DOC_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PJobOrderType.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_ID").ToString <> "" Then
                                PJobOrderType.JoTypeId = dbr("JO_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pJobOrderType.ErrorMsg = ex.Message
            End Try
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrJobOrderType As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New JobOrderType
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_CODE").ToString <> "" Then
                                temp.JoTypeCode = dbr("JO_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_NAME").ToString <> "" Then
                                temp.JoTypeName = dbr("JO_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_ID").ToString <> "" Then
                                temp.DocId = dbr("DOC_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE_ID").ToString <> "" Then
                                temp.JoTypeId = dbr("JO_TYPE_ID")
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
        Public Shared Function ReturnJobOrderType(ByVal pJobOrderType As JobOrderType) As JobOrderType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_ORDER_TYPE_BY_ID", pJobOrderType.TerminalId & "," & pJobOrderType.JoTypeId)
                pJobOrderType = ReturnObjectValues(dbr, pJobOrderType)
                dbr.Close()
            Catch ex As Exception
                pJobOrderType.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pJobOrderType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnJobOrderTypeList (ByVal pJobOrderType As JobOrderType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobOrderType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_ORDER_TYPE_ALL", pJobOrderType.TerminalId)
                arrJobOrderType = ReturnObjectValuesList(dbr, arrJobOrderType)
                dbr.Close()
            Catch ex As Exception
                arrJobOrderType = Nothing
            End Try
            db.CloseDB()
            Return arrJobOrderType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnJobOrderTypeListDomestic(ByVal pJobOrderType As JobOrderType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobOrderType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_ORDER_TYPE_DOM_ALL", pJobOrderType.TerminalId)
                arrJobOrderType = ReturnObjectValuesList(dbr, arrJobOrderType)
                dbr.Close()
            Catch ex As Exception
                arrJobOrderType = Nothing
            End Try
            db.CloseDB()
            Return arrJobOrderType
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnJobOrderTypeListDomesticDo(ByVal pJobOrderType As JobOrderType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobOrderType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_ORDER_TYPE_DOM_DO", " ")
                arrJobOrderType = ReturnObjectValuesList(dbr, arrJobOrderType)
                dbr.Close()
            Catch ex As Exception
                arrJobOrderType = Nothing
            End Try
            db.CloseDB()
            Return arrJobOrderType
        End Function

    End Class
End Namespace
