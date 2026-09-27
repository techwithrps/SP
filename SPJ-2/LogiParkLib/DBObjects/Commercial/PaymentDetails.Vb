Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PaymentDetails
    ''' @author	: Amit K. Singh- 18/7/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class PaymentDetails

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngReceiptNo As Long ' Define Private Variable ReceiptNo With DataType As Long 
        Private strReceiptMode As String ' Define Private Variable ReceiptMode With DataType As String 
        Private strChequeNo As String ' Define Private Variable ChequeNo With DataType As Long 
        Private strChequeDate As String ' Define Private Variable ChequeDate With DataType As String 
        Private lngBankId As Long ' Define Private Variable BankId With DataType As Long 
        Private dblAmount As Double ' Define Private Variable Amount With DataType As Double 
        Private strReconcilationDate As String ' Define Private Variable Errormsg With DataType As String 
        Private strBranch As String ' Define Private Variable Errormsg With DataType As String 
        Private lngReceiverBankId As Long ' Define Private Variable ReceiverBankId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strStateCode As String ' Define Private Variable StateCode With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strPDType As String
        Public Property PDType() As String
            Get
                Return strPDType
            End Get
            Set(ByVal value As String)
                strPDType = value
            End Set
        End Property
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
        ''' Get or Set the Value of ReceiptNo
        ''' </summary>
        ''' <value>lngReceiptNo</value>
        ''' <returns> Return lngReceiptNo</returns>
        ''' <remarks> Get or Set the Value of ReceiptNo  </remarks>
        '''
        Public Property ReceiptNo() As Long
            Get
                Return lngReceiptNo
            End Get
            Set(ByVal value As Long)
                lngReceiptNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ReceiptMode
        ''' </summary>
        ''' <value>strReceiptMode</value>
        ''' <returns> Return strReceiptMode</returns>
        ''' <remarks> Get or Set the Value of ReceiptMode  </remarks>
        '''
        Public Property ReceiptMode() As String
            Get
                Return strReceiptMode
            End Get
            Set(ByVal value As String)
                strReceiptMode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ChequeNo
        ''' </summary>
        ''' <value>lngChequeNo</value>
        ''' <returns> Return lngChequeNo</returns>
        ''' <remarks> Get or Set the Value of ChequeNo  </remarks>
        '''
        Public Property ChequeNo() As String
            Get
                Return strChequeNo
            End Get
            Set(ByVal value As String)
                strChequeNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ChequeDate
        ''' </summary>
        ''' <value>strChequeDate</value>
        ''' <returns> Return strChequeDate</returns>
        ''' <remarks> Get or Set the Value of ChequeDate  </remarks>
        '''
        Public Property ChequeDate() As String
            Get
                Return strChequeDate
            End Get
            Set(ByVal value As String)
                strChequeDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BankId
        ''' </summary>
        ''' <value>lngBankId</value>
        ''' <returns> Return lngBankId</returns>
        ''' <remarks> Get or Set the Value of BankId  </remarks>
        '''
        Public Property BankId() As Long
            Get
                Return lngBankId
            End Get
            Set(ByVal value As Long)
                lngBankId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Amount
        ''' </summary>
        ''' <value>dblAmount</value>
        ''' <returns> Return dblAmount</returns>
        ''' <remarks> Get or Set the Value of Amount  </remarks>
        '''
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal value As Double)
                dblAmount = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Branch
        ''' </summary>
        ''' <value>strBranch</value>
        ''' <returns> Return strBranch</returns>
        ''' <remarks> Get or Set the Value of Branch  </remarks>
        '''
        Public Property Branch() As String
            Get
                Return strBranch
            End Get
            Set(ByVal value As String)
                strBranch = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Branch
        ''' </summary>
        ''' <value>strBranch</value>
        ''' <returns> Return strBranch</returns>
        ''' <remarks> Get or Set the Value of Branch  </remarks>
        '''
        Public Property ReconcilationDate() As String
            Get
                Return strReconcilationDate
            End Get
            Set(ByVal value As String)
                strReconcilationDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ReceiverBankId
        ''' </summary>
        ''' <value>lngReceiverBankId</value>
        ''' <returns> Return lngReceiverBankId</returns>
        ''' <remarks> Get or Set the Value of ReceiverBankId  </remarks>
        '''
        Public Property ReceiverBankId() As Long
            Get
                Return lngReceiverBankId
            End Get
            Set(ByVal value As Long)
                lngReceiverBankId = value
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
        ''' Get or Set the Value of StateCode
        ''' </summary>
        ''' <value>strStateCode</value>
        ''' <returns> Return strStateCode</returns>
        ''' <remarks> Get or Set the Value of StateCode  </remarks>
        '''
        Public Property StateCode() As String
            Get
                Return strStateCode
            End Get
            Set(ByVal value As String)
                strStateCode = value
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
            lngReceiptNo = 0
            strReceiptMode = ""
            strChequeNo = ""
            strChequeDate = ""
            lngBankId = 0
            dblAmount = 0.0
            strBranch = ""
            strReconcilationDate = ""
            lngReceiverBankId = 0
            lngServiceId = 0
            strStateCode = ""
            strErrormsg = ""
            strPDType = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pPaymentDetails"></param>
        ''' <returns>Return pPaymentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPaymentDetails.TerminalId)
                db.AddParameter("p_RECEIPT_NO", pPaymentDetails.ReceiptNo)
                db.AddParameter("p_RECEIPT_MODE", pPaymentDetails.ReceiptMode)
                db.AddParameter("p_CHEQUE_NO", pPaymentDetails.ChequeNo)
                db.AddParameter("p_CHEQUE_DATE", pPaymentDetails.ChequeDate)
                db.AddParameter("p_BANK_ID", pPaymentDetails.BankId)
                db.AddParameter("p_AMOUNT", pPaymentDetails.Amount)
                db.AddParameter("p_RECONCILATION_DATE", pPaymentDetails.ReconcilationDate)
                db.AddParameter("p_BRANCH", pPaymentDetails.Branch)
                db.AddParameter("p_ErrorMsg", pPaymentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PAYMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPaymentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pPaymentDetails.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPaymentDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPaymentDetails"></param>
        ''' <returns>Return pPaymentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function PurchaseInsertTrn(ByVal db As DBConnect, ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPaymentDetails.TerminalId)
                db.AddParameter("p_RECEIPT_NO", pPaymentDetails.ReceiptNo)
                db.AddParameter("p_RECEIPT_MODE", pPaymentDetails.ReceiptMode)
                db.AddParameter("p_CHEQUE_NO", pPaymentDetails.ChequeNo)
                db.AddParameter("p_CHEQUE_DATE", pPaymentDetails.ChequeDate)
                db.AddParameter("p_BANK_ID", pPaymentDetails.BankId)
                db.AddParameter("p_AMOUNT", pPaymentDetails.Amount)
                db.AddParameter("p_RECONCILATION_DATE", pPaymentDetails.ReconcilationDate)
                db.AddParameter("p_BRANCH", pPaymentDetails.Branch)
                db.AddParameter("p_RECEIVER_BANK_ID", pPaymentDetails.ReceiverBankId)
                db.AddParameter("p_SERVICE_ID", pPaymentDetails.ServiceId)
                db.AddParameter("p_STATE_CODE", pPaymentDetails.StateCode)
                db.AddParameter("p_TYPE", pPaymentDetails.strPDType)
                db.AddParameter("p_ErrorMsg", pPaymentDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PURPAYMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPaymentDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pPaymentDetails.Errormsg = ex.Message
            End Try
            Return pPaymentDetails
        End Function



        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPaymentDetails"></param>
        ''' <returns>Return pPaymentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPaymentDetails.TerminalId)
                db.AddParameter("p_RECEIPT_NO", pPaymentDetails.ReceiptNo)
                db.AddParameter("p_RECEIPT_MODE", pPaymentDetails.ReceiptMode)
                db.AddParameter("p_CHEQUE_NO", pPaymentDetails.ChequeNo)
                db.AddParameter("p_CHEQUE_DATE", pPaymentDetails.ChequeDate)
                db.AddParameter("p_BANK_ID", pPaymentDetails.BankId)
                db.AddParameter("p_AMOUNT", pPaymentDetails.Amount)
                db.AddParameter("p_RECONCILATION_DATE", pPaymentDetails.ReconcilationDate)
                db.AddParameter("p_BRANCH", pPaymentDetails.Branch)
                db.AddParameter("p_RECEIVER_BANK_ID", pPaymentDetails.ReceiverBankId)
                db.AddParameter("p_SERVICE_ID", pPaymentDetails.ServiceId)
                db.AddParameter("p_STATE_CODE", pPaymentDetails.StateCode)
                db.AddParameter("p_ErrorMsg", pPaymentDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PAYMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPaymentDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pPaymentDetails.Errormsg = ex.Message
            End Try
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pPaymentDetails"></param>
        ''' <returns>Return pPaymentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPaymentDetails.TerminalId)
                db.AddParameter("p_RECEIPT_NO", pPaymentDetails.ReceiptNo)
                db.AddParameter("p_RECEIPT_MODE", pPaymentDetails.ReceiptMode)
                db.AddParameter("p_CHEQUE_NO", pPaymentDetails.ChequeNo)
                db.AddParameter("p_CHEQUE_DATE", pPaymentDetails.ChequeDate)
                db.AddParameter("p_BANK_ID", pPaymentDetails.BankId)
                db.AddParameter("p_AMOUNT", pPaymentDetails.Amount)
                db.AddParameter("p_RECONCILATION_DATE", pPaymentDetails.ReconcilationDate)
                db.AddParameter("p_BRANCH", pPaymentDetails.Branch)
                db.AddParameter("p_ErrorMsg", pPaymentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PAYMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPaymentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pPaymentDetails.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPaymentDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPaymentDetails"></param>
        ''' <returns>Return pPaymentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPaymentDetails.TerminalId)
                db.AddParameter("p_RECEIPT_NO", pPaymentDetails.ReceiptNo)
                db.AddParameter("p_RECEIPT_MODE", pPaymentDetails.ReceiptMode)
                db.AddParameter("p_CHEQUE_NO", pPaymentDetails.ChequeNo)
                db.AddParameter("p_CHEQUE_DATE", pPaymentDetails.ChequeDate)
                db.AddParameter("p_BANK_ID", pPaymentDetails.BankId)
                db.AddParameter("p_AMOUNT", pPaymentDetails.Amount)
                db.AddParameter("p_RECONCILATION_DATE", pPaymentDetails.ReconcilationDate)
                db.AddParameter("p_BRANCH", pPaymentDetails.Branch)
                db.AddParameter("p_ErrorMsg", pPaymentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PAYMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPaymentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pPaymentDetails.ErrorMsg = ex.Message
            End Try
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PPaymentDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                PPaymentDetails.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_MODE").ToString <> "" Then
                                PPaymentDetails.ReceiptMode = dbr("RECEIPT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHEQUE_NO").ToString <> "" Then
                                PPaymentDetails.ChequeNo = dbr("CHEQUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHEQUE_DATE").ToString <> "" Then
                                PPaymentDetails.ChequeDate = dbr("CHEQUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                PPaymentDetails.BankId = dbr("BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                PPaymentDetails.Amount = dbr("AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECONCILATION_DATE").ToString <> "" Then
                                pPaymentDetails.ReconcilationDate = dbr("RECONCILATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BRANCH").ToString <> "" Then
                                pPaymentDetails.Branch = dbr("BRANCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIVER_BANK_ID").ToString <> "" Then
                                pPaymentDetails.ReceiverBankId = dbr("RECEIVER_BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pPaymentDetails.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                pPaymentDetails.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pPaymentDetails.ErrorMsg = ex.Message
            End Try
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrPaymentDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New PaymentDetails
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("RECEIPT_MODE").ToString <> "" Then
                                temp.ReceiptMode = dbr("RECEIPT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHEQUE_NO").ToString <> "" Then
                                temp.ChequeNo = dbr("CHEQUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHEQUE_DATE").ToString <> "" Then
                                temp.ChequeDate = dbr("CHEQUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                temp.BankId = dbr("BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                temp.Amount = dbr("AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECONCILATION_DATE").ToString <> "" Then
                                temp.ReconcilationDate = dbr("RECONCILATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BRANCH").ToString <> "" Then
                                temp.Branch = dbr("BRANCH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIVER_BANK_ID").ToString <> "" Then
                                temp.ReceiverBankId = dbr("RECEIVER_BANK_ID")
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
                            If dbr("STATE_CODE").ToString <> "" Then
                                temp.StateCode = dbr("STATE_CODE")
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
        Public Shared Function ReturnPaymentDetails(ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PAYMENT_DETAILS", "' '")
                pPaymentDetails = ReturnObjectValues(dbr, pPaymentDetails)
                dbr.Close()
            Catch ex As Exception
                pPaymentDetails.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pPaymentDetails
        End Function

        Public Shared Function ReturnPaymentDetailsByReceiptNo(ByVal pPaymentDetails As PaymentDetails) As PaymentDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PAYMENT_DETAILS_BY_R_NO", pPaymentDetails.TerminalId & "," & pPaymentDetails.ReceiptNo)
                pPaymentDetails = ReturnObjectValues(dbr, pPaymentDetails)
                dbr.Close()
            Catch ex As Exception
                pPaymentDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pPaymentDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPaymentDetailsList(ByVal pPaymentDetails As PaymentDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPaymentDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PAYMENT_DETAILS", "' '")
                arrPaymentDetails = ReturnObjectValuesList(dbr, arrPaymentDetails)
                dbr.Close()
            Catch ex As Exception
                arrPaymentDetails = Nothing
            End Try
            db.CloseDB()
            Return arrPaymentDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By ReceiptNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnPaymentDetailsListByReceiptNo(ByVal pPaymentDetails As PaymentDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPaymentDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PAYMENT_DETAILS_ALL_BY_NO", pPaymentDetails.TerminalId & "," & pPaymentDetails.ReceiptNo)
                arrPaymentDetails = ReturnObjectValuesList(dbr, arrPaymentDetails)
                dbr.Close()
            Catch ex As Exception
                arrPaymentDetails = Nothing
            End Try
            db.CloseDB()
            Return arrPaymentDetails
        End Function
    End Class
End Namespace
