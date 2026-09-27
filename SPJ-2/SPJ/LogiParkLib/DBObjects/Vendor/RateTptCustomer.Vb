Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: RateTptCustomer
    ''' @author	: Santosh Singh- 25/1/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class RateTptCustomer

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngRateTptId As Long ' Define Private Variable RateTptId With DataType As Long 
        Private strRateCode As String ' Define Private Variable RateCode With DataType As String 
        Private lngBillingCondition As Long ' Define Private Variable BillingCondition With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngTaxGroupId As Long ' Define Private Variable TaxGroupId With DataType As Long
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
        ''' Get or Set the Value of RateTptId
        ''' </summary>
        ''' <value>lngRateTptId</value>
        ''' <returns> Return lngRateTptId</returns>
        ''' <remarks> Get or Set the Value of RateTptId  </remarks>
        '''
        Public Property RateTptId() As Long
            Get
                Return lngRateTptId
            End Get
            Set(ByVal value As Long)
                lngRateTptId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RateCode
        ''' </summary>
        ''' <value>strRateCode</value>
        ''' <returns> Return strRateCode</returns>
        ''' <remarks> Get or Set the Value of RateCode  </remarks>
        '''
        Public Property RateCode() As String
            Get
                Return strRateCode
            End Get
            Set(ByVal value As String)
                strRateCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BillingCondition
        ''' </summary>
        ''' <value>lngBillingCondition</value>
        ''' <returns> Return lngBillingCondition</returns>
        ''' <remarks> Get or Set the Value of BillingCondition  </remarks>
        '''
        Public Property BillingCondition() As Long
            Get
                Return lngBillingCondition
            End Get
            Set(ByVal value As Long)
                lngBillingCondition = value
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
            lngRateTptId = 0
            strRateCode = ""
            lngBillingCondition = 0
            lngServiceId = 0
            lngCustomerId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            lngTaxGroupId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRateTptCustomer"></param>
        ''' <returns>Return pRateTptCustomer Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomer.TerminalId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomer.RateTptId, ParameterDirection.Output)
                db.AddParameter("p_RATE_CODE", pRateTptCustomer.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptCustomer.BillingCondition)
                db.AddParameter("p_SERVICE_ID", pRateTptCustomer.ServiceId)
                db.AddParameter("p_CUSTOMER_ID", pRateTptCustomer.CustomerId)
                db.AddParameter("p_CREATED_BY", pRateTptCustomer.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptCustomer.CreatedOn)
                db.AddParameter("p_TAX_GROUP_ID", pRateTptCustomer.TaxGroupId)
                db.AddParameter("p_ErrorMsg", pRateTptCustomer.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_CUSTOMER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomer.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptCustomer.RateTptId = db.Parameters.Item("p_RATE_TPT_ID").value

                If pRateTptCustomer.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptCustomer.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptCustomer
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptCustomer"></param>
        ''' <returns>Return pRateTptCustomer Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomer.TerminalId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomer.RateTptId, ParameterDirection.Output)
                db.AddParameter("p_RATE_CODE", pRateTptCustomer.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptCustomer.BillingCondition)
                db.AddParameter("p_SERVICE_ID", pRateTptCustomer.ServiceId)
                db.AddParameter("p_CUSTOMER_ID", pRateTptCustomer.CustomerId)
                db.AddParameter("p_CREATED_BY", pRateTptCustomer.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptCustomer.CreatedOn)
                db.AddParameter("p_TAX_GROUP_ID", pRateTptCustomer.TaxGroupId)
                db.AddParameter("p_ErrorMsg", pRateTptCustomer.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_CUSTOMER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomer.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptCustomer.RateTptId = db.Parameters.Item("p_RATE_TPT_ID").value

            Catch ex As Exception
                pRateTptCustomer.ErrorMsg = ex.Message
            End Try
            Return pRateTptCustomer
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRateTptCustomer"></param>
        ''' <returns>Return pRateTptCustomer Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomer.TerminalId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomer.RateTptId)
                db.AddParameter("p_RATE_CODE", pRateTptCustomer.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptCustomer.BillingCondition)
                db.AddParameter("p_SERVICE_ID", pRateTptCustomer.ServiceId)
                db.AddParameter("p_CUSTOMER_ID", pRateTptCustomer.CustomerId)
                db.AddParameter("p_CREATED_BY", pRateTptCustomer.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptCustomer.CreatedOn)
                db.AddParameter("p_TAX_GROUP_ID", pRateTptCustomer.TaxGroupId)
                db.AddParameter("p_ErrorMsg", pRateTptCustomer.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_CUSTOMER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomer.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRateTptCustomer.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptCustomer.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptCustomer
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptCustomer"></param>
        ''' <returns>Return pRateTptCustomer Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomer.TerminalId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomer.RateTptId)
                db.AddParameter("p_RATE_CODE", pRateTptCustomer.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptCustomer.BillingCondition)
                db.AddParameter("p_SERVICE_ID", pRateTptCustomer.ServiceId)
                db.AddParameter("p_CUSTOMER_ID", pRateTptCustomer.CustomerId)
                db.AddParameter("p_CREATED_BY", pRateTptCustomer.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptCustomer.CreatedOn)
                db.AddParameter("p_TAX_GROUP_ID", pRateTptCustomer.TaxGroupId)
                db.AddParameter("p_ErrorMsg", pRateTptCustomer.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_CUSTOMER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomer.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRateTptCustomer.ErrorMsg = ex.Message
            End Try
            Return pRateTptCustomer
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PRateTptCustomer.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TPT_ID").ToString <> "" Then
                                PRateTptCustomer.RateTptId = dbr("RATE_TPT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_CODE").ToString <> "" Then
                                PRateTptCustomer.RateCode = dbr("RATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_CONDITION").ToString <> "" Then
                                PRateTptCustomer.BillingCondition = dbr("BILLING_CONDITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PRateTptCustomer.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PRateTptCustomer.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PRateTptCustomer.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PRateTptCustomer.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                pRateTptCustomer.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pRateTptCustomer.ErrorMsg = ex.Message
            End Try
            Return pRateTptCustomer
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRateTptCustomer As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RateTptCustomer
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TPT_ID").ToString <> "" Then
                                temp.RateTptId = dbr("RATE_TPT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_CODE").ToString <> "" Then
                                temp.RateCode = dbr("RATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_CONDITION").ToString <> "" Then
                                temp.BillingCondition = dbr("BILLING_CONDITION")
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
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                temp.CustomerId = dbr("CUSTOMER_ID")
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
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                temp.TaxGroupId = dbr("TAX_GROUP_ID")
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
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptCustomerById(ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_BY_ID", pRateTptCustomer.TerminalId & "," & pRateTptCustomer.RateTptId)
                pRateTptCustomer = ReturnObjectValues(dbr, pRateTptCustomer)
                dbr.Close()
            Catch ex As Exception
                pRateTptCustomer.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptCustomer
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnRateTptCustomerList(ByVal pRateTptCustomer As RateTptCustomer) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptCustomer As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_BY_ALL", pRateTptCustomer.TerminalId)
                arrRateTptCustomer = ReturnObjectValuesList(dbr, arrRateTptCustomer)
                dbr.Close()
            Catch ex As Exception
                arrRateTptCustomer = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptCustomer
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnRateTptByServiceIdWithCurrentDate(ByVal pRateTptCustomer As RateTptCustomer) As RateTptCustomer
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_BY_DATE_ID", "'" & pRateTptCustomer.BillingCondition & "," & pRateTptCustomer.ServiceId & "," & pRateTptCustomer.TerminalId & "'")
                pRateTptCustomer = ReturnObjectValues(dbr, pRateTptCustomer)
                dbr.Close()
            Catch ex As Exception
                pRateTptCustomer.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptCustomer
        End Function
    End Class
End Namespace
