Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerMapping
    ''' @author	: Amit K. Singh- 12/6/2018
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CustomerMapping 
    
        Private lngMappingId As Long ' Define Private Variable MappingId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private lngBillingParty As Long ' Define Private Variable BillingParty With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngServiceGroupId As Long ' Define Private Variable ServiceGroupId With DataType As Long 
        Private strServiceTypeCode As String ' Define Private Variable ServiceTypeCode With DataType As String 
        Private lngTallyCustomerId As Long ' Define Private Variable TallyCustomerId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private arrTaxGroupHead As ArrayList

        Public Property CustomerMappingList() As ArrayList
            Get
                Return arrTaxGroupHead
            End Get
            Set(ByVal value As ArrayList)
                arrTaxGroupHead = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of MappingId
        ''' </summary>
        ''' <value>lngMappingId</value>
        ''' <returns> Return lngMappingId</returns>
        ''' <remarks> Get or Set the Value of MappingId  </remarks>
        '''
        Public Property MappingId() as Long
            Get
                Return lngMappingId
            End Get
            Set(ByVal value As Long)
                lngMappingId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() as Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BillingParty
        ''' </summary>
        ''' <value>lngBillingParty</value>
        ''' <returns> Return lngBillingParty</returns>
        ''' <remarks> Get or Set the Value of BillingParty  </remarks>
        '''
        Public Property BillingParty() as Long
            Get
                Return lngBillingParty
            End Get
            Set(ByVal value As Long)
                lngBillingParty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() as Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceGroupId
        ''' </summary>
        ''' <value>lngServiceGroupId</value>
        ''' <returns> Return lngServiceGroupId</returns>
        ''' <remarks> Get or Set the Value of ServiceGroupId  </remarks>
        '''
        Public Property ServiceGroupId() as Long
            Get
                Return lngServiceGroupId
            End Get
            Set(ByVal value As Long)
                lngServiceGroupId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceTypeCode
        ''' </summary>
        ''' <value>strServiceTypeCode</value>
        ''' <returns> Return strServiceTypeCode</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeCode  </remarks>
        '''
        Public Property ServiceTypeCode() as String
            Get
                Return strServiceTypeCode
            End Get
            Set(ByVal value As String)
                strServiceTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TallyCustomerId
        ''' </summary>
        ''' <value>lngTallyCustomerId</value>
        ''' <returns> Return lngTallyCustomerId</returns>
        ''' <remarks> Get or Set the Value of TallyCustomerId  </remarks>
        '''
        Public Property TallyCustomerId() as Long
            Get
                Return lngTallyCustomerId
            End Get
            Set(ByVal value As Long)
                lngTallyCustomerId = value
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
            lngMappingId = 0 
            lngCustomerId = 0 
            lngBillingParty = 0 
            lngLineId = 0 
            lngServiceGroupId = 0 
            strServiceTypeCode = ""
            lngTallyCustomerId = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerMapping"></param>
        ''' <returns>Return pCustomerMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MAPPING_ID", pCustomerMapping.MappingId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMapping.CustomerId)
                db.AddParameter("p_BILLING_PARTY", pCustomerMapping.BillingParty)
                db.AddParameter("p_LINE_ID", pCustomerMapping.LineId)
                db.AddParameter("p_SERVICE_GROUP_ID", pCustomerMapping.ServiceGroupId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pCustomerMapping.ServiceTypeCode)
                db.AddParameter("p_TALLY_CUSTOMER_ID", pCustomerMapping.TallyCustomerId)
                db.AddParameter("p_CREATED_BY", pCustomerMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMapping.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                ''pCustomerMapping.MappingId  = db.Parameters.Item("p_MAPPING_ID").value
                
                If pCustomerMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMapping"></param>
        ''' <returns>Return pCustomerMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_MAPPING_ID", pCustomerMapping.MappingId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMapping.CustomerId)
                db.AddParameter("p_BILLING_PARTY", pCustomerMapping.BillingParty)
                db.AddParameter("p_LINE_ID", pCustomerMapping.LineId)
                db.AddParameter("p_SERVICE_GROUP_ID", pCustomerMapping.ServiceGroupId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pCustomerMapping.ServiceTypeCode)
                db.AddParameter("p_TALLY_CUSTOMER_ID", pCustomerMapping.TallyCustomerId)
                db.AddParameter("p_CREATED_BY", pCustomerMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMapping.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                ''pCustomerMapping.MappingId  = db.Parameters.Item("p_MAPPING_ID").value
                
            Catch ex As Exception
                pCustomerMapping.ErrorMsg = ex.Message
            End Try
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerMapping"></param>
        ''' <returns>Return pCustomerMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MAPPING_ID", pCustomerMapping.MappingId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMapping.CustomerId)
                db.AddParameter("p_BILLING_PARTY", pCustomerMapping.BillingParty)
                db.AddParameter("p_LINE_ID", pCustomerMapping.LineId)
                db.AddParameter("p_SERVICE_GROUP_ID", pCustomerMapping.ServiceGroupId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pCustomerMapping.ServiceTypeCode)
                db.AddParameter("p_TALLY_CUSTOMER_ID", pCustomerMapping.TallyCustomerId)
                db.AddParameter("p_CREATED_BY", pCustomerMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMapping.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMapping"></param>
        ''' <returns>Return pCustomerMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_MAPPING_ID", pCustomerMapping.MappingId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMapping.CustomerId)
                db.AddParameter("p_BILLING_PARTY", pCustomerMapping.BillingParty)
                db.AddParameter("p_LINE_ID", pCustomerMapping.LineId)
                db.AddParameter("p_SERVICE_GROUP_ID", pCustomerMapping.ServiceGroupId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pCustomerMapping.ServiceTypeCode)
                db.AddParameter("p_TALLY_CUSTOMER_ID", pCustomerMapping.TallyCustomerId)
                db.AddParameter("p_CREATED_BY", pCustomerMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMapping.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCustomerMapping.ErrorMsg = ex.Message
                End Try
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("MAPPING_ID").ToString <> "" Then
                                PCustomerMapping.MappingId = dbr("MAPPING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PCustomerMapping.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_PARTY").ToString <> "" Then
                                PCustomerMapping.BillingParty = dbr("BILLING_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PCustomerMapping.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_GROUP_ID").ToString <> "" Then
                                PCustomerMapping.ServiceGroupId = dbr("SERVICE_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                PCustomerMapping.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_CUSTOMER_ID").ToString <> "" Then
                                PCustomerMapping.TallyCustomerId = dbr("TALLY_CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PCustomerMapping.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PCustomerMapping.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCustomerMapping.ErrorMsg = ex.Message
            End Try
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerMapping As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerMapping
                        Try
                            If dbr("MAPPING_ID").ToString <> "" Then
                                temp.MappingId = dbr("MAPPING_ID")
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
                            If dbr("BILLING_PARTY").ToString <> "" Then
                                temp.BillingParty = dbr("BILLING_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_GROUP_ID").ToString <> "" Then
                                temp.ServiceGroupId = dbr("SERVICE_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                temp.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_CUSTOMER_ID").ToString <> "" Then
                                temp.TallyCustomerId = dbr("TALLY_CUSTOMER_ID")
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
        Public Shared Function ReturnCustomerMapping(ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAPPING", "' '")
                pCustomerMapping = ReturnObjectValues(dbr, pCustomerMapping)
                dbr.Close()
            Catch ex As Exception
                pCustomerMapping.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMapping
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMappingList (ByVal pCustomerMapping As CustomerMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAPPING", "' '")
                arrCustomerMapping = ReturnObjectValuesList(dbr, arrCustomerMapping)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMapping = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMapping
        End Function
        Public Shared Function InsertUpdateTransaction(ByVal pCustomerMapping As CustomerMapping) As CustomerMapping
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each det As CustomerMapping In pCustomerMapping.CustomerMappingList
                    If pCustomerMapping.MappingId > 0 Then
                        CustomerMapping.UpdateTrn(db, det)
                    Else
                        CustomerMapping.InsertTrn(db, det)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pCustomerMapping.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCustomerMapping
        End Function
    End Class
End Namespace
