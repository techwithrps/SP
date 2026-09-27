Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CostRateMaster
    ''' @author	: Amit K. Singh- 3/9/2019
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CostRateMaster

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngRateId As Long ' Define Private Variable RateId With DataType As Long 
        Private strFromDate As String ' Define Private Variable FromDate With DataType As String 
        Private strToDate As String ' Define Private Variable ToDate With DataType As String 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private lngTaxGroupId As Long ' Define Private Variable TaxGroupId With DataType As Long 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strApprovalFlage As String ' Define Private Variable ApprovalFlage With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strAggrementDoc As String ' Define Private Variable AggrementDoc With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


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
                Return lngRateId
            End Get
            Set(ByVal value As Long)
                lngRateId = value
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
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TaxGroupId
        ''' </summary>
        ''' <value>lngTaxGroupId</value>
        ''' <returns> Return lngTaxGroupId</returns>
        ''' <remarks> Get or Set the Value of TaxGroupId  </remarks>
        '''
        Public Property TaxGroupId() As Long
            Get
                Return lngTaxGroupId
            End Get
            Set(ByVal value As Long)
                lngTaxGroupId = value
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
        ''' Get or Set the Value of AggrementDoc
        ''' </summary>
        ''' <value>strAggrementDoc</value>
        ''' <returns> Return strAggrementDoc</returns>
        ''' <remarks> Get or Set the Value of AggrementDoc  </remarks>
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
            lngRateId = 0
            strFromDate = ""
            strToDate = ""
            lngCustomerId = 0
            strCustomerType = ""
            lngServiceId = 0
            lngTaxGroupId = 0
            strRemarks = ""
            strApprovalFlage = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strAggrementDoc = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCostRateMaster"></param>
        ''' <returns>Return pCostRateMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateMaster.TerminalId)
                db.AddParameter("p_RATE_ID", pCostRateMaster.RateId, ParameterDirection.Output)
                db.AddParameter("p_FROM_DATE", pCostRateMaster.FromDate)
                db.AddParameter("p_TO_DATE", pCostRateMaster.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pCostRateMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pCostRateMaster.CustomerType)
                db.AddParameter("p_SERVICE_ID", pCostRateMaster.ServiceId)
                db.AddParameter("p_TAX_GROUP_ID", pCostRateMaster.TaxGroupId)
                db.AddParameter("p_REMARKS", pCostRateMaster.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pCostRateMaster.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pCostRateMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostRateMaster.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pCostRateMaster.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pCostRateMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_RATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostRateMaster.RateId = db.Parameters.Item("p_RATE_ID").value

                If pCostRateMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCostRateMaster"></param>
        ''' <returns>Return pCostRateMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateMaster.TerminalId)
                db.AddParameter("p_RATE_ID", pCostRateMaster.RateId, ParameterDirection.Output)
                db.AddParameter("p_FROM_DATE", pCostRateMaster.FromDate)
                db.AddParameter("p_TO_DATE", pCostRateMaster.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pCostRateMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pCostRateMaster.CustomerType)
                db.AddParameter("p_SERVICE_ID", pCostRateMaster.ServiceId)
                db.AddParameter("p_TAX_GROUP_ID", pCostRateMaster.TaxGroupId)
                db.AddParameter("p_REMARKS", pCostRateMaster.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pCostRateMaster.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pCostRateMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostRateMaster.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pCostRateMaster.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pCostRateMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_RATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostRateMaster.RateId = db.Parameters.Item("p_RATE_ID").value

            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCostRateMaster"></param>
        ''' <returns>Return pCostRateMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateMaster.TerminalId)
                db.AddParameter("p_RATE_ID", pCostRateMaster.RateId)
                db.AddParameter("p_FROM_DATE", pCostRateMaster.FromDate)
                db.AddParameter("p_TO_DATE", pCostRateMaster.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pCostRateMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pCostRateMaster.CustomerType)
                db.AddParameter("p_SERVICE_ID", pCostRateMaster.ServiceId)
                db.AddParameter("p_TAX_GROUP_ID", pCostRateMaster.TaxGroupId)
                db.AddParameter("p_REMARKS", pCostRateMaster.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pCostRateMaster.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pCostRateMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostRateMaster.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pCostRateMaster.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pCostRateMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COST_RATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostRateMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCostRateMaster"></param>
        ''' <returns>Return pCostRateMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateMaster.TerminalId)
                db.AddParameter("p_RATE_ID", pCostRateMaster.RateId)
                db.AddParameter("p_FROM_DATE", pCostRateMaster.FromDate)
                db.AddParameter("p_TO_DATE", pCostRateMaster.ToDate)
                db.AddParameter("p_CUSTOMER_ID", pCostRateMaster.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pCostRateMaster.CustomerType)
                db.AddParameter("p_SERVICE_ID", pCostRateMaster.ServiceId)
                db.AddParameter("p_TAX_GROUP_ID", pCostRateMaster.TaxGroupId)
                db.AddParameter("p_REMARKS", pCostRateMaster.Remarks)
                db.AddParameter("p_APPROVAL_FLAGE", pCostRateMaster.ApprovalFlage)
                db.AddParameter("p_CREATED_BY", pCostRateMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostRateMaster.CreatedOn)
                db.AddParameter("p_AGGREMENT_DOC", pCostRateMaster.AggrementDoc)
                db.AddParameter("p_ErrorMsg", pCostRateMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COST_RATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pCostRateMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                pCostRateMaster.RateId = dbr("RATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                pCostRateMaster.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                pCostRateMaster.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pCostRateMaster.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                pCostRateMaster.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pCostRateMaster.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                pCostRateMaster.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pCostRateMaster.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                pCostRateMaster.ApprovalFlage = dbr("APPROVAL_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCostRateMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCostRateMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGGREMENT_DOC").ToString <> "" Then
                                pCostRateMaster.AggrementDoc = dbr("AGGREMENT_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCostRateMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CostRateMaster
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
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                temp.TaxGroupId = dbr("TAX_GROUP_ID")
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
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCostRateMaster(ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_RATE_MASTER", "' '")
                pCostRateMaster = ReturnObjectValues(dbr, pCostRateMaster)
                dbr.Close()
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCostRateMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCostRateMasterList(ByVal pCostRateMaster As CostRateMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCostRateMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_RATE_MASTER", "' '")
                arrCostRateMaster = ReturnObjectValuesList(dbr, arrCostRateMaster)
                dbr.Close()
            Catch ex As Exception
                arrCostRateMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCostRateMaster
        End Function
        Public Shared Function ReturnRateMasterByRateId(ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_MASTER_BY_ID", pCostRateMaster.TerminalId & "," & pCostRateMaster.RateId)
                pCostRateMaster = ReturnObjectValues(dbr, pCostRateMaster)
                dbr.Close()
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCostRateMaster
        End Function
        Public Shared Function ReturnCostRateMasterListByCustomerId(ByVal pCostRateMaster As CostRateMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_DTLS_BY_CUSTOMER", pCostRateMaster.TerminalId & "," & pCostRateMaster.CustomerId)
                arrRateMaster = ReturnObjectValuesList(dbr, arrRateMaster)
                dbr.Close()
            Catch ex As Exception
                arrRateMaster = Nothing
            End Try
            db.CloseDB()
            Return arrRateMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCostRateMasterListByterminalId(ByVal pCostRateMaster As CostRateMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCostRateMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_MASTER_ALL_COST", pCostRateMaster.TerminalId)
                arrCostRateMaster = ReturnObjectValuesList(dbr, arrCostRateMaster)
                dbr.Close()
            Catch ex As Exception
                arrCostRateMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCostRateMaster
        End Function

        Public Shared Function ReturnCostMasterByServiceIdWithCurrentDate(ByVal pCostRateMaster As CostRateMaster) As CostRateMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST__MASTER_BY_DATE_ID", pCostRateMaster.TerminalId & ",'" & pCostRateMaster.FromDate & "','" & pCostRateMaster.ToDate & "'," & pCostRateMaster.ServiceId)
                pCostRateMaster = ReturnObjectValues(dbr, pCostRateMaster)
                dbr.Close()
            Catch ex As Exception
                pCostRateMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCostRateMaster
        End Function

    End Class
End Namespace
