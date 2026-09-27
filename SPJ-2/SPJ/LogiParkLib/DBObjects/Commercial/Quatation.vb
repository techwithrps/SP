Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class QUATATION
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngQUATATIONId As Long ' Define Private Variable RateId With DataType As Long 
        Private strFromDate As String ' Define Private Variable FromDate With DataType As String 
        Private strToDate As String ' Define Private Variable ToDate With DataType As String 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strApprovalFlage As String ' Define Private Variable ApprovalFlage With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strAggrementDoc As String ' Define Private Variable CreatedOn With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RateId
        ''' </summary>
        ''' <value>lngRateId</value>
        ''' <returns> Return lngRateId</returns>
        ''' <remarks> Get or Set the Value of RateId  </remarks>
        '''
        Public Property RateId() As Long
            Get
                Return lngQuatationId
            End Get
            Set(ByVal value As Long)
                lngQuatationId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FromDate
        ''' </summary>
        ''' <value>strFromDate</value>
        ''' <returns> Return strFromDate</returns>
        ''' <remarks> Get or Set the Value of FromDate  </remarks>
        '''
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal value As String)
                strFromDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ToDate
        ''' </summary>
        ''' <value>strToDate</value>
        ''' <returns> Return strToDate</returns>
        ''' <remarks> Get or Set the Value of ToDate  </remarks>
        '''
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ToDate
        ''' </summary>
        ''' <value>strToDate</value>
        ''' <returns> Return strToDate</returns>
        ''' <remarks> Get or Set the Value of ToDate  </remarks>
        '''
        Public Property AggrementDoc() As String
            Get
                Return strAggrementDoc
            End Get
            Set(ByVal value As String)
                strAggrementDoc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerType
        ''' </summary>
        ''' <value>strCustomerType</value>
        ''' <returns> Return strCustomerType</returns>
        ''' <remarks> Get or Set the Value of CustomerType  </remarks>
        '''
        Public Property CustomerType() As String
            Get
                Return strCustomerType
            End Get
            Set(ByVal value As String)
                strCustomerType = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ApprovalFlage
        ''' </summary>
        ''' <value>strApprovalFlage</value>
        ''' <returns> Return strApprovalFlage</returns>
        ''' <remarks> Get or Set the Value of ApprovalFlage  </remarks>
        '''
        Public Property ApprovalFlage() As String
            Get
                Return strApprovalFlage
            End Get
            Set(ByVal value As String)
                strApprovalFlage = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() As String
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
        Public Property CreatedOn() As String
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
        Public Property Errormsg() As String
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
            lngQuatationId = 0
            strFromDate = ""
            strToDate = ""
            lngCustomerId = 0
            strCustomerType = ""
            strRemarks = ""
            strApprovalFlage = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            strAggrementDoc = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pQUATATION"></param>
        ''' <returns>Return pQUATATION Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pQUATATION As Quatation) As Quatation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatation.TerminalId)
                db.AddParameter("p_RATE_ID", pQuatation.RateId, ParameterDirection.Output)
                db.AddParameter("p_FROM_DATE", pQuatation.FromDate)
                db.AddParameter("p_TO_DATE", pQuatation.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pQuatation.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pQuatation.CustomerType)
                db.AddParameter("p_REMARKS", pQuatation.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pQuatation.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pQuatation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pQuatation.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pQuatation.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pQuatation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUATATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pQuatation.RateId = db.Parameters.Item("p_RATE_ID").value

                If pQuatation.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pQuatation
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pQUATATION"></param>
        ''' <returns>Return pQUATATION Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pQUATATION As Quatation) As Quatation
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatation.TerminalId)
                db.AddParameter("p_RATE_ID", pQuatation.RateId, ParameterDirection.Output)
                db.AddParameter("p_FROM_DATE", pQuatation.FromDate)
                db.AddParameter("p_TO_DATE", pQuatation.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pQuatation.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pQuatation.CustomerType)
                db.AddParameter("p_REMARKS", pQuatation.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pQuatation.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pQuatation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pQuatation.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pQuatation.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pQuatation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUATATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pQuatation.RateId = db.Parameters.Item("p_RATE_ID").value

            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
            End Try
            Return pQuatation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pQUATATION"></param>
        ''' <returns>Return pQUATATION Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pQUATATION As Quatation) As Quatation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatation.TerminalId)
                db.AddParameter("p_RATE_ID", pQuatation.RateId)
                db.AddParameter("p_FROM_DATE", pQuatation.FromDate)
                db.AddParameter("p_TO_DATE", pQuatation.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pQuatation.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pQuatation.CustomerType)
                db.AddParameter("p_REMARKS", pQuatation.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pQuatation.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pQuatation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pQuatation.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pQuatation.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pQuatation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUATATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pQuatation.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pQuatation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pQUATATION"></param>
        ''' <returns>Return pQUATATION Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pQUATATION As Quatation) As Quatation
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatation.TerminalId)
                db.AddParameter("p_RATE_ID", pQuatation.RateId)
                db.AddParameter("p_FROM_DATE", pQuatation.FromDate)
                db.AddParameter("p_TO_DATE", pQuatation.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pQuatation.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pQuatation.CustomerType)
                db.AddParameter("p_REMARKS", pQuatation.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pQuatation.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pQuatation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pQuatation.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pQuatation.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pQuatation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUATATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
            End Try
            Return pQuatation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pQUATATION As Quatation) As Quatation
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pQuatation.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                pQuatation.RateId = dbr("RATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                pQuatation.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                pQuatation.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pQuatation.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                pQuatation.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pQuatation.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                pQuatation.ApprovalFlage = dbr("APPROVAL_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pQuatation.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pQuatation.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGGREMENT_DOC").ToString <> "" Then
                                pQuatation.AggrementDoc = dbr("AGGREMENT_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
            End Try
            Return pQuatation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrQUATATION As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New Quatation
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                temp.RateId = dbr("RATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                temp.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                temp.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                temp.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                temp.CustomerType = dbr("CUSTOMER_TYPE")
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
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                temp.ApprovalFlage = dbr("APPROVAL_FLAGE")
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
                            If dbr("AGGREMENT_DOC").ToString <> "" Then
                                temp.AggrementDoc = dbr("AGGREMENT_DOC")
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
        ''' Preparing Return Object By TerminalId, RateId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnQUATATIONByRateId(ByVal pQUATATION As Quatation) As Quatation
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_QUATATION_BY_ID", pQuatation.TerminalId & "," & pQuatation.RateId)
                pQuatation = ReturnObjectValues(dbr, pQuatation)
                dbr.Close()
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pQuatation
        End Function

        Public Shared Function ReturnQUATATIONByServiceIdWithCurrentDate(ByVal pQUATATION As Quatation) As Quatation
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_QUATATION_BY_DATE_ID", pQUATATION.TerminalId & ",'" & pQUATATION.FromDate & "','" & pQUATATION.ToDate & "'")
                pQuatation = ReturnObjectValues(dbr, pQuatation)
                dbr.Close()
            Catch ex As Exception
                pQuatation.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pQuatation
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnQUATATIONListByterminalId(ByVal pQUATATION As Quatation) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrQUATATION As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_QUATATION_ALL", pQuatation.TerminalId)
                arrQUATATION = ReturnObjectValuesList(dbr, arrQUATATION)
                dbr.Close()
            Catch ex As Exception
                arrQUATATION = Nothing
            End Try
            db.CloseDB()
            Return arrQUATATION
        End Function
        Public Shared Function ReturnQUATATIONListByCustomerId(ByVal pQUATATION As Quatation) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrQUATATION As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_DTLS_BY_CUSTOMER", pQuatation.TerminalId & "," & pQuatation.CustomerId)
                arrQUATATION = ReturnObjectValuesList(dbr, arrQUATATION)
                dbr.Close()
            Catch ex As Exception
                arrQUATATION = Nothing
            End Try
            db.CloseDB()
            Return arrQUATATION
        End Function
    End Class
End Namespace

