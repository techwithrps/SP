Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FinanceDetails
    ''' @author	: Amit K. Singh- 17/7/2012
    ''' </summary>    ''' <remarks> </remarks>
    '''
    Public Class FinanceDetails 
    
        Private lngKeyId As Long ' Define Private Variable KeyId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private lngInvoiceNo As Long ' Define Private Variable InvoiceNo With DataType As Long 
        Private lngReceiptNo As Long ' Define Private Variable ReceiptNo With DataType As Long 
        Private dblCrAmount As Double ' Define Private Variable CrAmount With DataType As Double 
        Private dblDrAmount As Double ' Define Private Variable DrAmount With DataType As Double
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strTrnType As String ' Define Private Variable TrnType With DataType As String 
        Private lngTrnValue As Long ' Define Private Variable TrnValue With DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String
        Private lngCompanyId As Long
        Private strFncType As String
                    
        ''' <summary>
        ''' Get or Set the Value of KeyId
        ''' </summary>
        ''' <value>lngKeyId</value>
        ''' <returns> Return lngKeyId</returns>
        ''' <remarks> Get or Set the Value of KeyId  </remarks>
        '''
        Public Property KeyId() as Long
            Get
                Return lngKeyId
            End Get
            Set(ByVal value As Long)
                lngKeyId = value
            End Set
        End Property

        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
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
        ''' Get or Set the Value of CustomerType
        ''' </summary>
        ''' <value>strCustomerType</value>
        ''' <returns> Return strCustomerType</returns>
        ''' <remarks> Get or Set the Value of CustomerType  </remarks>
        '''
        Public Property CustomerType() as String
            Get
                Return strCustomerType
            End Get
            Set(ByVal value As String)
                strCustomerType = value
            End Set
        End Property



        Public Property FNCType() As String
            Get
                Return strFncType
            End Get
            Set(ByVal value As String)
                strFncType = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of InvoiceNo
        ''' </summary>
        ''' <value>lngInvoiceNo</value>
        ''' <returns> Return lngInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceNo  </remarks>
        '''
        Public Property InvoiceNo() as Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReceiptNo
        ''' </summary>
        ''' <value>lngReceiptNo</value>
        ''' <returns> Return lngReceiptNo</returns>
        ''' <remarks> Get or Set the Value of ReceiptNo  </remarks>
        '''
        Public Property ReceiptNo() as Long
            Get
                Return lngReceiptNo
            End Get
            Set(ByVal value As Long)
                lngReceiptNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CrAmount
        ''' </summary>
        ''' <value>dblCrAmount</value>
        ''' <returns> Return dblCrAmount</returns>
        ''' <remarks> Get or Set the Value of CrAmount  </remarks>
        '''
        Public Property CrAmount() As Double
            Get
                Return dblCrAmount
            End Get
            Set(ByVal value As Double)
                dblCrAmount = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DrAmount
        ''' </summary>
        ''' <value>lngDrAmount</value>
        ''' <returns> Return dblDrAmount</returns>
        ''' <remarks> Get or Set the Value of DrAmount  </remarks>
        '''
        Public Property DrAmount() As Double
            Get
                Return dblDrAmount
            End Get
            Set(ByVal value As Double)
                dblDrAmount = value
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
        ''' Get or Set the Value of TrnType
        ''' </summary>
        ''' <value>strTrnType</value>
        ''' <returns> Return strTrnType</returns>
        ''' <remarks> Get or Set the Value of TrnType  </remarks>
        '''
        Public Property TrnType() as String
            Get
                Return strTrnType
            End Get
            Set(ByVal value As String)
                strTrnType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TrnValue
        ''' </summary>
        ''' <value>lngTrnValue</value>
        ''' <returns> Return lngTrnValue</returns>
        ''' <remarks> Get or Set the Value of TrnValue  </remarks>
        '''
        Public Property TrnValue() as Long
            Get
                Return lngTrnValue
            End Get
            Set(ByVal value As Long)
                lngTrnValue = value
            End Set
        End Property

                    
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
            lngKeyId = 0 
            lngCustomerId = 0 
            strCustomerType = ""
            lngInvoiceNo = 0 
            lngReceiptNo = 0 
            dblCrAmount = 0
            dblDrAmount = 0
            strRemarks = ""
            strCreatedOn = ""
            strTrnType = ""
            lngTrnValue = 0 
            lngTerminalId = 0
            lngCompanyId = 0
            strErrormsg = ""
            strFncType = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFinanceDetails"></param>
        ''' <returns>Return pFinanceDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FINANCE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFinanceDetails.KeyId  = db.Parameters.Item("p_KEY_ID").value
                
                If pFinanceDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFinanceDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFinanceDetails"></param>
        ''' <returns>Return pFinanceDetails Object</returns>
        ''' <remarks></remarks>
        '''
        
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FINANCE_DETAILS_AMOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFinanceDetails.KeyId = db.Parameters.Item("p_KEY_ID").value

            Catch ex As Exception
                pFinanceDetails.ErrorMsg = ex.Message
            End Try
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFinanceDetails"></param>
        ''' <returns>Return pFinanceDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FINANCE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFinanceDetails.KeyId = db.Parameters.Item("p_KEY_ID").value

                If pFinanceDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFinanceDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function
        Public Shared Function UpdateDrAmount(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FINANCE_DETAILS_DR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pFinanceDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFinanceDetails"></param>
        ''' <returns>Return pFinanceDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FINANCE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFinanceDetails.ErrorMsg = ex.Message
                End Try
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                PFinanceDetails.KeyId = dbr("KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PFinanceDetails.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                PFinanceDetails.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PFinanceDetails.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                PFinanceDetails.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                PFinanceDetails.CrAmount = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_AMOUNT").ToString <> "" Then
                                PFinanceDetails.DrAmount = dbr("DR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PFinanceDetails.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFinanceDetails.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRN_TYPE").ToString <> "" Then
                                PFinanceDetails.TrnType = dbr("TRN_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRN_VALUE").ToString <> "" Then
                                PFinanceDetails.TrnValue = dbr("TRN_VALUE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFinanceDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pFinanceDetails.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFinanceDetails.ErrorMsg = ex.Message
            End Try
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFinanceDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FinanceDetails
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                temp.KeyId = dbr("KEY_ID")
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
                            If dbr("INVOICE_NO").ToString <> "" Then
                                temp.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                temp.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                temp.CrAmount = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_AMOUNT").ToString <> "" Then
                                temp.DrAmount = dbr("DR_AMOUNT")
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
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRN_TYPE").ToString <> "" Then
                                temp.TrnType = dbr("TRN_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRN_VALUE").ToString <> "" Then
                                temp.TrnValue = dbr("TRN_VALUE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
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
        Public Shared Function ReturnFinanceDetails(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS", "' '")
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                pFinanceDetails.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By CustomerId, CustomerType,PaymentMode
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnInvoiceListByCustomer(ByVal pFinanceDetails As FinanceDetails, ByVal pPaymentMode As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFinanceDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_LIST_BY_CUSTOMER", pFinanceDetails.TerminalId & "," & pFinanceDetails.CustomerId & ",'" & pFinanceDetails.CustomerType & "','" & pPaymentMode & "'")
                arrFinanceDetails = ReturnObjectValuesList(dbr, arrFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                arrFinanceDetails = Nothing
            End Try
            db.CloseDB()
            Return arrFinanceDetails
        End Function
        Public Shared Function ReturnPreviousReceiptBalanceByCustomer(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RECEIPT_BALANCE_BY_CUSTOMER", pFinanceDetails.TerminalId & "," & pFinanceDetails.CustomerId & ",'" & pFinanceDetails.CustomerType & "'")
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnFinanceDetailsSumByInvoiceNo(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS_SUM_INVOICE", pFinanceDetails.TerminalId & "," & pFinanceDetails.InvoiceNo)
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFinanceDetailsList (ByVal pFinanceDetails As FinanceDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFinanceDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS", "' '")
                arrFinanceDetails = ReturnObjectValuesList(dbr, arrFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                arrFinanceDetails = Nothing
            End Try
            db.CloseDB()
            Return arrFinanceDetails
        End Function
        Public Shared Function ReturnToPayAmountByInvoiceNo(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TO_PAY_AMOUNT_BY_INVOICE", pFinanceDetails.TerminalId & "," & pFinanceDetails.InvoiceNo)
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception

            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function
        Public Shared Function ReturnFinanceDetailsByReceiptNo(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS_ALL_RECEIPT", pFinanceDetails.TerminalId & "," & pFinanceDetails.ReceiptNo)
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception

            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By ReceiptNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnFinanceDetailsListByReceiptNo(ByVal pFinanceDetails As FinanceDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFinanceDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS_ALL_RECEIPT", pFinanceDetails.TerminalId & "," & pFinanceDetails.ReceiptNo)
                arrFinanceDetails = ReturnObjectValuesList(dbr, arrFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                arrFinanceDetails = Nothing
            End Try
            db.CloseDB()
            Return arrFinanceDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By CustomerId, CustomerType,PaymentMode
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnInvoiceListByCustomerInvoice(ByVal pFinanceDetails As FinanceDetails, ByVal pPaymentMode As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFinanceDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_LIST_BY_CUSTOMER_INV", pFinanceDetails.TerminalId & "," & pFinanceDetails.CustomerId & ",'" & pFinanceDetails.CustomerType & "','" & pPaymentMode & "'," & pFinanceDetails.InvoiceNo)
                arrFinanceDetails = ReturnObjectValuesList(dbr, arrFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                arrFinanceDetails = Nothing
            End Try
            db.CloseDB()
            Return arrFinanceDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By CustomerId, CustomerType,PaymentMode
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnPurchaseInvoiceListByCustomerAndType(ByVal pFinanceDetails As FinanceDetails, ByVal pPaymentMode As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFinanceDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PURINV_LIST_BY_CUSTOMER", pFinanceDetails.TerminalId & "," & pFinanceDetails.CustomerId & ",'" & pFinanceDetails.CustomerType & "','" & pPaymentMode & "','" & pFinanceDetails.Remarks & "','" & pFinanceDetails.CreatedOn & "'")
                arrFinanceDetails = ReturnObjectValuesList(dbr, arrFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                arrFinanceDetails = Nothing
            End Try
            db.CloseDB()
            Return arrFinanceDetails
        End Function
        Public Shared Function ReturnPreviousIssueBalanceByCustomer(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ISSUE_BALANCE_BY_CUSTOMER", pFinanceDetails.TerminalId & "," & pFinanceDetails.CustomerId & ",'" & pFinanceDetails.CustomerType & "'")
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        Public Shared Function ReturnToPayAmountByPurchaseInvoiceNo(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TO_PAY_AMOUNT_BY_INVOICEP", pFinanceDetails.TerminalId & "," & pFinanceDetails.InvoiceNo)
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception

            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        Public Shared Function ReturnFinanceDetailsPurchaseSumByInvoiceNo(ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FINANCE_DETAILS_SUM_PCHINV", pFinanceDetails.TerminalId & "," & pFinanceDetails.InvoiceNo)
                pFinanceDetails = ReturnObjectValues(dbr, pFinanceDetails)
                dbr.Close()
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFinanceDetails
        End Function

        Public Shared Function PurchaseInsertTrn(ByVal db As DBConnect, ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_TYPE", pFinanceDetails.FNCType)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PURFNC_DETAILS_AMOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFinanceDetails.KeyId = db.Parameters.Item("p_KEY_ID").value

            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            Return pFinanceDetails
        End Function

        ''' <param name="db"></param>
        ''' <param name="pFinanceDetails"></param>
        ''' <returns>Return pFinanceDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function PurchaseUpdateTrn(ByVal db As DBConnect, ByVal pFinanceDetails As FinanceDetails) As FinanceDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_KEY_ID", pFinanceDetails.KeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_CUSTOMER_ID", pFinanceDetails.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pFinanceDetails.CustomerType)
                db.AddParameter("p_INVOICE_NO", pFinanceDetails.InvoiceNo)
                db.AddParameter("p_RECEIPT_NO", pFinanceDetails.ReceiptNo)
                db.AddParameter("p_CR_AMOUNT", pFinanceDetails.CrAmount)
                db.AddParameter("p_DR_AMOUNT", pFinanceDetails.DrAmount)
                db.AddParameter("p_REMARKS", pFinanceDetails.Remarks)
                db.AddParameter("p_CREATED_ON", pFinanceDetails.CreatedOn)
                db.AddParameter("p_TRN_TYPE", pFinanceDetails.TrnType)
                db.AddParameter("p_TRN_VALUE", pFinanceDetails.TrnValue)
                db.AddParameter("p_TERMINAL_ID", pFinanceDetails.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFinanceDetails.CompanyId)
                db.AddParameter("p_TYPE", pFinanceDetails.FNCType)
                db.AddParameter("p_ErrorMsg", pFinanceDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PURFNC_DETAILS_AMOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFinanceDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFinanceDetails.Errormsg = ex.Message
            End Try
            Return pFinanceDetails
        End Function


    End Class
End Namespace
