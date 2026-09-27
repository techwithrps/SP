Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: InvoiceReceipt
    ''' @author	: Santosh Singh- 18/7/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class InvoiceReceipt 
    
        Private lngReceiptNo As Long ' Define Private Variable ReceiptNo With DataType As Long 
        Private strReceiptRefNo As String ' Define Private Variable ReceiptRefNo With DataType As String 
        Private strReceiptDate As String ' Define Private Variable ReceiptDate With DataType As String 
        Private strReceiptType As String ' Define Private Variable ReceiptType With DataType As String 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strIRType As String
        Private strRemarks As String
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property
        Public Property IRType() As String
            Get
                Return strIRType
            End Get
            Set(ByVal value As String)
                strIRType = value
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
        ''' Get or Set the Value of ReceiptRefNo
        ''' </summary>
        ''' <value>strReceiptRefNo</value>
        ''' <returns> Return strReceiptRefNo</returns>
        ''' <remarks> Get or Set the Value of ReceiptRefNo  </remarks>
        '''
        Public Property ReceiptRefNo() as String
            Get
                Return strReceiptRefNo
            End Get
            Set(ByVal value As String)
                strReceiptRefNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReceiptDate
        ''' </summary>
        ''' <value>strReceiptDate</value>
        ''' <returns> Return strReceiptDate</returns>
        ''' <remarks> Get or Set the Value of ReceiptDate  </remarks>
        '''
        Public Property ReceiptDate() as String
            Get
                Return strReceiptDate
            End Get
            Set(ByVal value As String)
                strReceiptDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReceiptType
        ''' </summary>
        ''' <value>strReceiptType</value>
        ''' <returns> Return strReceiptType</returns>
        ''' <remarks> Get or Set the Value of ReceiptType  </remarks>
        '''
        Public Property ReceiptType() as String
            Get
                Return strReceiptType
            End Get
            Set(ByVal value As String)
                strReceiptType = value
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
            lngReceiptNo = 0 
            strReceiptRefNo = ""
            strReceiptDate = ""
            strReceiptType = ""
            lngCustomerId = 0 
            strCustomerType = ""
            strCreatedOn = ""
            strCreatedBy = ""
            lngTerminalId = 0 
            strErrormsg = ""
            strIRType = ""
            strRemarks = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pInvoiceReceipt"></param>
        ''' <returns>Return pInvoiceReceipt Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RECEIPT_NO", pInvoiceReceipt.ReceiptNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_REF_NO", pInvoiceReceipt.ReceiptRefNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_DATE", pInvoiceReceipt.ReceiptDate, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_TYPE", pInvoiceReceipt.ReceiptType)
                db.AddParameter("p_CUSTOMER_ID", pInvoiceReceipt.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pInvoiceReceipt.CustomerType)
                db.AddParameter("p_CREATED_ON", pInvoiceReceipt.CreatedOn)
                db.AddParameter("p_CREATED_BY", pInvoiceReceipt.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pInvoiceReceipt.TerminalId)
                db.AddParameter("p_REMARKS", pInvoiceReceipt.Remarks)
                db.AddParameter("p_ErrorMsg", pInvoiceReceipt.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_INVOICE_RECEIPT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pInvoiceReceipt.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pInvoiceReceipt.ReceiptNo = db.Parameters.Item("p_RECEIPT_NO").value
                pInvoiceReceipt.ReceiptRefNo = db.Parameters.Item("p_RECEIPT_REF_NO").value.ToString
                pInvoiceReceipt.ReceiptDate = db.Parameters.Item("p_RECEIPT_DATE").value.ToString
                If pInvoiceReceipt.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pInvoiceReceipt.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pInvoiceReceipt"></param>
        ''' <returns>Return pInvoiceReceipt Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Try
                db.ClearParameters()
                db.AddParameter("p_RECEIPT_NO", pInvoiceReceipt.ReceiptNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_REF_NO", pInvoiceReceipt.ReceiptRefNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_DATE", pInvoiceReceipt.ReceiptDate, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_TYPE", pInvoiceReceipt.ReceiptType)
                db.AddParameter("p_CUSTOMER_ID", pInvoiceReceipt.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pInvoiceReceipt.CustomerType)
                db.AddParameter("p_CREATED_ON", pInvoiceReceipt.CreatedOn)
                db.AddParameter("p_CREATED_BY", pInvoiceReceipt.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pInvoiceReceipt.TerminalId)
                db.AddParameter("p_REMARKS", pInvoiceReceipt.Remarks)
                db.AddParameter("p_ErrorMsg", pInvoiceReceipt.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_INVOICE_RECEIPT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pInvoiceReceipt.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pInvoiceReceipt.ReceiptNo = db.Parameters.Item("p_RECEIPT_NO").value
                pInvoiceReceipt.ReceiptRefNo = db.Parameters.Item("p_RECEIPT_REF_NO").value.ToString
                pInvoiceReceipt.ReceiptDate = db.Parameters.Item("p_RECEIPT_DATE").value.ToString
            Catch ex As Exception
                pInvoiceReceipt.ErrorMsg = ex.Message
            End Try
            Return pInvoiceReceipt
        End Function


        '''
        Public Shared Function PurchaseInsertTrn(ByVal db As DBConnect, ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Try
                db.ClearParameters()
                db.AddParameter("p_RECEIPT_NO", pInvoiceReceipt.ReceiptNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_REF_NO", pInvoiceReceipt.ReceiptRefNo, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_DATE", pInvoiceReceipt.ReceiptDate, ParameterDirection.Output)
                db.AddParameter("p_RECEIPT_TYPE", pInvoiceReceipt.ReceiptType)
                db.AddParameter("p_CUSTOMER_ID", pInvoiceReceipt.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pInvoiceReceipt.CustomerType)
                db.AddParameter("p_CREATED_ON", pInvoiceReceipt.CreatedOn)
                db.AddParameter("p_CREATED_BY", pInvoiceReceipt.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pInvoiceReceipt.TerminalId)
                db.AddParameter("p_TYPE", pInvoiceReceipt.IRType)
                db.AddParameter("p_REMARKS", pInvoiceReceipt.Remarks)
                db.AddParameter("p_ErrorMsg", pInvoiceReceipt.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PURINVOICE_RECEIPT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pInvoiceReceipt.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pInvoiceReceipt.ReceiptNo = db.Parameters.Item("p_RECEIPT_NO").value
                pInvoiceReceipt.ReceiptRefNo = db.Parameters.Item("p_RECEIPT_REF_NO").value.ToString
                pInvoiceReceipt.ReceiptDate = db.Parameters.Item("p_RECEIPT_DATE").value.ToString
            Catch ex As Exception
                pInvoiceReceipt.Errormsg = ex.Message
            End Try
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pInvoiceReceipt"></param>
        ''' <returns>Return pInvoiceReceipt Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RECEIPT_NO", pInvoiceReceipt.ReceiptNo)
                db.AddParameter("p_RECEIPT_REF_NO", pInvoiceReceipt.ReceiptRefNo)
                db.AddParameter("p_RECEIPT_DATE", pInvoiceReceipt.ReceiptDate)
                db.AddParameter("p_RECEIPT_TYPE", pInvoiceReceipt.ReceiptType)
                db.AddParameter("p_CUSTOMER_ID", pInvoiceReceipt.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pInvoiceReceipt.CustomerType)
                db.AddParameter("p_CREATED_ON", pInvoiceReceipt.CreatedOn)
                db.AddParameter("p_CREATED_BY", pInvoiceReceipt.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pInvoiceReceipt.TerminalId)
                db.AddParameter("p_ErrorMsg", pInvoiceReceipt.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_INVOICE_RECEIPT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pInvoiceReceipt.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pInvoiceReceipt.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pInvoiceReceipt.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pInvoiceReceipt"></param>
        ''' <returns>Return pInvoiceReceipt Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Try
                db.ClearParameters()
                db.AddParameter("p_RECEIPT_NO", pInvoiceReceipt.ReceiptNo)
                db.AddParameter("p_RECEIPT_REF_NO", pInvoiceReceipt.ReceiptRefNo)
                db.AddParameter("p_RECEIPT_DATE", pInvoiceReceipt.ReceiptDate)
                db.AddParameter("p_RECEIPT_TYPE", pInvoiceReceipt.ReceiptType)
                db.AddParameter("p_CUSTOMER_ID", pInvoiceReceipt.CustomerId)
                db.AddParameter("p_CUSTOMER_TYPE", pInvoiceReceipt.CustomerType)
                db.AddParameter("p_CREATED_ON", pInvoiceReceipt.CreatedOn)
                db.AddParameter("p_CREATED_BY", pInvoiceReceipt.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pInvoiceReceipt.TerminalId)
                db.AddParameter("p_ErrorMsg", pInvoiceReceipt.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_INVOICE_RECEIPT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pInvoiceReceipt.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pInvoiceReceipt.ErrorMsg = ex.Message
                End Try
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                PInvoiceReceipt.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_REF_NO").ToString <> "" Then
                                PInvoiceReceipt.ReceiptRefNo = dbr("RECEIPT_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_DATE").ToString <> "" Then
                                PInvoiceReceipt.ReceiptDate = dbr("RECEIPT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_TYPE").ToString <> "" Then
                                PInvoiceReceipt.ReceiptType = dbr("RECEIPT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PInvoiceReceipt.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                PInvoiceReceipt.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PInvoiceReceipt.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PInvoiceReceipt.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PInvoiceReceipt.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IR_REMARKS").ToString <> "" Then
                                pInvoiceReceipt.Remarks = dbr("IR_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pInvoiceReceipt.ErrorMsg = ex.Message
            End Try
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrInvoiceReceipt As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New InvoiceReceipt
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                temp.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_REF_NO").ToString <> "" Then
                                temp.ReceiptRefNo = dbr("RECEIPT_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_DATE").ToString <> "" Then
                                temp.ReceiptDate = dbr("RECEIPT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_TYPE").ToString <> "" Then
                                temp.ReceiptType = dbr("RECEIPT_TYPE")
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
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
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
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IR_REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("IR_REMARKS")
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
        Public Shared Function ReturnInvoiceReceipt(ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_RECEIPT", "' '")
                pInvoiceReceipt = ReturnObjectValues(dbr, pInvoiceReceipt)
                dbr.Close()
            Catch ex As Exception
                pInvoiceReceipt.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pInvoiceReceipt
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnInvoiceReceiptList (ByVal pInvoiceReceipt As InvoiceReceipt) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrInvoiceReceipt As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_RECEIPT", "' '")
                arrInvoiceReceipt = ReturnObjectValuesList(dbr, arrInvoiceReceipt)
                dbr.Close()
            Catch ex As Exception
                arrInvoiceReceipt = Nothing
            End Try
            db.CloseDB()
            Return arrInvoiceReceipt
        End Function
        ''' <summary>
        ''' Preparing Return Object By ReceiptNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnInvoiceReceiptByNo(ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_RECEIPT_BY_NO", pInvoiceReceipt.TerminalId & "," & pInvoiceReceipt.ReceiptNo)
                pInvoiceReceipt = ReturnObjectValues(dbr, pInvoiceReceipt)
                dbr.Close()
            Catch ex As Exception
                pInvoiceReceipt.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pInvoiceReceipt
        End Function
        ''' <summary>
        ''' Preparing Return Object By ReceiptRefNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnInvoiceReceiptByRefNo(ByVal pInvoiceReceipt As InvoiceReceipt) As InvoiceReceipt
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_RECEIPT_BY_REF_NO", pInvoiceReceipt.TerminalId & ",'" & pInvoiceReceipt.ReceiptRefNo & "'")
                pInvoiceReceipt = ReturnObjectValues(dbr, pInvoiceReceipt)
                dbr.Close()
            Catch ex As Exception
                pInvoiceReceipt.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pInvoiceReceipt
        End Function
    End Class
End Namespace
