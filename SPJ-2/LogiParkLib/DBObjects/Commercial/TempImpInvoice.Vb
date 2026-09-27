Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TempImpInvoice
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TempImpInvoice

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
        Private lngInvoiceNo As Long ' Define Private Variable InvoiceNo With DataType As Long 
        Private strInvoiceDate As String ' Define Private Variable InvoiceDate With DataType As String 
        Private strInvoiceRefNo As String ' Define Private Variable InvoiceRefNo With DataType As String 
        Private strServiceType As String ' Define Private Variable ServiceType With DataType As String 
        Private strCustomerType As String ' Define Private Variable CustomerType With DataType As String 
        Private lngBillTo As Long ' Define Private Variable BillTo With DataType As Long 
        Private strPaymentMode As String ' Define Private Variable PaymentMode With DataType As String 
        Private strGrTillDate As String ' Define Private Variable GrTillDate With DataType As String 
        Private strPrintStatus As String ' Define Private Variable PrintStatus With DataType As String 
        Private lngReceiptNo As Long ' Define Private Variable ReceiptNo With DataType As Long 
        Private strInvoiceNote As String ' Define Private Variable InvoiceNote With DataType As String 
        Private strCancleFlage As String ' Define Private Variable CancleFlage With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private strRateType As String ' Define Private Variable strrRateType With DataType As String
        Private lngImpContId As Long ' Define Private Variable ImpContId With DataType As Long 
        Private strServiceId As String ' Define Private Variable ServiceId With DataType As String
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
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>lngDocType</value>
        ''' <returns> Return lngDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>lngDocType</value>
        ''' <returns> Return strRateType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property RateType() As String
            Get
                Return strRateType
            End Get
            Set(ByVal value As String)
                strRateType = value
            End Set
        End Property



        ''' <summary>
        ''' Get or Set the Value of LineItemId
        ''' </summary>
        ''' <value>lngLineItemId</value>
        ''' <returns> Return lngLineItemId</returns>
        ''' <remarks> Get or Set the Value of LineItemId  </remarks>
        '''
        Public Property LineItemId() As Long
            Get
                Return lngLineItemId
            End Get
            Set(ByVal value As Long)
                lngLineItemId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InvoiceNo
        ''' </summary>
        ''' <value>lngInvoiceNo</value>
        ''' <returns> Return lngInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceNo  </remarks>
        '''
        Public Property InvoiceNo() As Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InvoiceDate
        ''' </summary>
        ''' <value>strInvoiceDate</value>
        ''' <returns> Return strInvoiceDate</returns>
        ''' <remarks> Get or Set the Value of InvoiceDate  </remarks>
        '''
        Public Property InvoiceDate() As String
            Get
                Return strInvoiceDate
            End Get
            Set(ByVal value As String)
                strInvoiceDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InvoiceRefNo
        ''' </summary>
        ''' <value>strInvoiceRefNo</value>
        ''' <returns> Return strInvoiceRefNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceRefNo  </remarks>
        '''
        Public Property InvoiceRefNo() As String
            Get
                Return strInvoiceRefNo
            End Get
            Set(ByVal value As String)
                strInvoiceRefNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceType
        ''' </summary>
        ''' <value>strServiceType</value>
        ''' <returns> Return strServiceType</returns>
        ''' <remarks> Get or Set the Value of ServiceType  </remarks>
        '''
        Public Property ServiceType() As String
            Get
                Return strServiceType
            End Get
            Set(ByVal value As String)
                strServiceType = value
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
        ''' Get or Set the Value of BillTo
        ''' </summary>
        ''' <value>lngBillTo</value>
        ''' <returns> Return lngBillTo</returns>
        ''' <remarks> Get or Set the Value of BillTo  </remarks>
        '''
        Public Property BillTo() As Long
            Get
                Return lngBillTo
            End Get
            Set(ByVal value As Long)
                lngBillTo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PaymentMode
        ''' </summary>
        ''' <value>strPaymentMode</value>
        ''' <returns> Return strPaymentMode</returns>
        ''' <remarks> Get or Set the Value of PaymentMode  </remarks>
        '''
        Public Property PaymentMode() As String
            Get
                Return strPaymentMode
            End Get
            Set(ByVal value As String)
                strPaymentMode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrTillDate
        ''' </summary>
        ''' <value>strGrTillDate</value>
        ''' <returns> Return strGrTillDate</returns>
        ''' <remarks> Get or Set the Value of GrTillDate  </remarks>
        '''
        Public Property GrTillDate() As String
            Get
                Return strGrTillDate
            End Get
            Set(ByVal value As String)
                strGrTillDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PrintStatus
        ''' </summary>
        ''' <value>strPrintStatus</value>
        ''' <returns> Return strPrintStatus</returns>
        ''' <remarks> Get or Set the Value of PrintStatus  </remarks>
        '''
        Public Property PrintStatus() As String
            Get
                Return strPrintStatus
            End Get
            Set(ByVal value As String)
                strPrintStatus = value
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
        ''' Get or Set the Value of InvoiceNote
        ''' </summary>
        ''' <value>strInvoiceNote</value>
        ''' <returns> Return strInvoiceNote</returns>
        ''' <remarks> Get or Set the Value of InvoiceNote  </remarks>
        '''
        Public Property InvoiceNote() As String
            Get
                Return strInvoiceNote
            End Get
            Set(ByVal value As String)
                strInvoiceNote = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CancleFlage
        ''' </summary>
        ''' <value>strCancleFlage</value>
        ''' <returns> Return strCancleFlage</returns>
        ''' <remarks> Get or Set the Value of CancleFlage  </remarks>
        '''
        Public Property CancleFlage() As String
            Get
                Return strCancleFlage
            End Get
            Set(ByVal value As String)
                strCancleFlage = value
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
        ''' Get or Set the Value of ImpContId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngImpContId</returns>
        ''' <remarks> Get or Set the Value of ImpContId  </remarks>
        '''
        Public Property ImpContId() As Long
            Get
                Return lngImpContId
            End Get
            Set(ByVal value As Long)
                lngImpContId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>strServiceId</value>
        ''' <returns> Return strServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() As String
            Get
                Return strServiceId
            End Get
            Set(ByVal value As String)
                strServiceId = value
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
            lngLineItemId = 0
            lngInvoiceNo = 0
            strInvoiceDate = ""
            strInvoiceRefNo = ""
            strServiceType = ""
            strCustomerType = ""
            lngBillTo = 0
            strPaymentMode = ""
            strGrTillDate = ""
            strPrintStatus = ""
            lngReceiptNo = 0
            strInvoiceNote = ""
            strCancleFlage = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strDocType = ""
            strRateType = ""
            ImpContId = 0
            strServiceId = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTempImpInvoice"></param>
        ''' <returns>Return pTempImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pTempImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTempImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value

                If pTempImpInvoice.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoice.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempImpInvoice"></param>
        ''' <returns>Return pTempImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pTempImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTempImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value

            Catch ex As Exception
                pTempImpInvoice.ErrorMsg = ex.Message
            End Try
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTempImpInvoice"></param>
        ''' <returns>Return pTempImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pTempImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTempImpInvoice.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoice.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempImpInvoice"></param>
        ''' <returns>Return pTempImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pTempImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTempImpInvoice.ErrorMsg = ex.Message
            End Try
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTempImpInvoice.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                PTempImpInvoice.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PTempImpInvoice.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_DATE").ToString <> "" Then
                                PTempImpInvoice.InvoiceDate = dbr("INVOICE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_REF_NO").ToString <> "" Then
                                PTempImpInvoice.InvoiceRefNo = dbr("INVOICE_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                PTempImpInvoice.ServiceType = dbr("SERVICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                PTempImpInvoice.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                PTempImpInvoice.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_MODE").ToString <> "" Then
                                PTempImpInvoice.PaymentMode = dbr("PAYMENT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_TILL_DATE").ToString <> "" Then
                                PTempImpInvoice.GrTillDate = dbr("GR_TILL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                PTempImpInvoice.PrintStatus = dbr("PRINT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                PTempImpInvoice.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NOTE").ToString <> "" Then
                                PTempImpInvoice.InvoiceNote = dbr("INVOICE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCLE_FLAGE").ToString <> "" Then
                                PTempImpInvoice.CancleFlage = dbr("CANCLE_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTempImpInvoice.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTempImpInvoice.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                pTempImpInvoice.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TYPE").ToString <> "" Then
                                pTempImpInvoice.RateType = dbr("RATE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pTempImpInvoice.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pTempImpInvoice.ErrorMsg = ex.Message
            End Try
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTempImpInvoice As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TempImpInvoice
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                temp.LineItemId = dbr("LINE_ITEM_ID")
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
                            If dbr("INVOICE_DATE").ToString <> "" Then
                                temp.InvoiceDate = dbr("INVOICE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_REF_NO").ToString <> "" Then
                                temp.InvoiceRefNo = dbr("INVOICE_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                temp.ServiceType = dbr("SERVICE_TYPE")
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
                            If dbr("BILL_TO").ToString <> "" Then
                                temp.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_MODE").ToString <> "" Then
                                temp.PaymentMode = dbr("PAYMENT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_TILL_DATE").ToString <> "" Then
                                temp.GrTillDate = dbr("GR_TILL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                temp.PrintStatus = dbr("PRINT_STATUS")
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
                            If dbr("INVOICE_NOTE").ToString <> "" Then
                                temp.InvoiceNote = dbr("INVOICE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCLE_FLAGE").ToString <> "" Then
                                temp.CancleFlage = dbr("CANCLE_FLAGE")
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
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                temp.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TYPE").ToString <> "" Then
                                temp.RateType = dbr("RATE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
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
        ''' Preparing Return Object TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTempImpInvoiceByInvoiceNo(ByVal pTempImpInvoice As TempImpInvoice) As TempImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_IMP_INVOICE_BY_ID", pTempImpInvoice.TerminalId & "," & pTempImpInvoice.InvoiceNo)
                pTempImpInvoice = ReturnObjectValues(dbr, pTempImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pTempImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTempImpInvoiceList(ByVal pTempImpInvoice As TempImpInvoice) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_IMP_INVOICE", "' '")
                arrTempImpInvoice = ReturnObjectValuesList(dbr, arrTempImpInvoice)
                dbr.Close()
            Catch ex As Exception
                arrTempImpInvoice = Nothing
            End Try
            db.CloseDB()
            Return arrTempImpInvoice
        End Function
    End Class
End Namespace
