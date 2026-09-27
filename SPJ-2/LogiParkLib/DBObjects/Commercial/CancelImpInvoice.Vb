Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CancelImpInvoice
    ''' @author	: Amit K Singh- 23/04/2018
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CancelImpInvoice

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngClInvoiceId As Long ' Define Private Variable ClInvoiceId With DataType As Long 
        Private strClInvoiceNo As String ' Define Private Variable ClInvoiceNo With DataType As String 
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
        Private strCancelNote As String ' Define Private Variable CancelNote With DataType As String
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private strInvoiceType As String ' Define Private Variable InvoiceType With DataType As String 
        Private strCancelBy As String ' Define Private Variable CancelBy With DataType As String 
        Private strCancelOn As String ' Define Private Variable CancelOn With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
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
        ''' Get or Set the Value of ClInvoiceId
        ''' </summary>
        ''' <value>lngClInvoiceId</value>
        ''' <returns> Return lngClInvoiceId</returns>
        ''' <remarks> Get or Set the Value of ClInvoiceId  </remarks>
        '''
        Public Property ClInvoiceId() As Long
            Get
                Return lngClInvoiceId
            End Get
            Set(ByVal value As Long)
                lngClInvoiceId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ClInvoiceNo
        ''' </summary>
        ''' <value>strClInvoiceNo</value>
        ''' <returns> Return strClInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of ClInvoiceNo  </remarks>
        '''
        Public Property ClInvoiceNo() As String
            Get
                Return strClInvoiceNo
            End Get
            Set(ByVal value As String)
                strClInvoiceNo = value
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
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
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
        ''' Get or Set the Value of InvoiceType
        ''' </summary>
        ''' <value>strInvoiceType</value>
        ''' <returns> Return strInvoiceType</returns>
        ''' <remarks> Get or Set the Value of InvoiceType  </remarks>
        '''
        Public Property InvoiceType() As String
            Get
                Return strInvoiceType
            End Get
            Set(ByVal value As String)
                strInvoiceType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CancelNote
        ''' </summary>
        ''' <value>strCancelNote</value>
        ''' <returns> Return strCancelNote</returns>
        ''' <remarks> Get or Set the Value of CancelNote  </remarks>
        '''
        Public Property CancelNote() As String
            Get
                Return strCancelNote
            End Get
            Set(ByVal value As String)
                strCancelNote = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CancelBy
        ''' </summary>
        ''' <value>strCancelBy</value>
        ''' <returns> Return strCancelBy</returns>
        ''' <remarks> Get or Set the Value of CancelBy  </remarks>
        '''
        Public Property CancelBy() As String
            Get
                Return strCancelBy
            End Get
            Set(ByVal value As String)
                strCancelBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CancelOn
        ''' </summary>
        ''' <value>strCancelOn</value>
        ''' <returns> Return strCancelOn</returns>
        ''' <remarks> Get or Set the Value of CancelOn  </remarks>
        '''
        Public Property CancelOn() As String
            Get
                Return strCancelOn
            End Get
            Set(ByVal value As String)
                strCancelOn = value
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
            lngClInvoiceId = 0
            strClInvoiceNo = ""
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
            strDocType = ""
            strInvoiceType = ""
            strCancelNote = ""
            strCancelBy = ""
            strCancelOn = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoice"></param>
        ''' <returns>Return pCancelImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoice.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoice.ClInvoiceId, ParameterDirection.Output)
                db.AddParameter("p_CL_INVOICE_NO", pCancelImpInvoice.ClInvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pCancelImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pCancelImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pCancelImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pCancelImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pCancelImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pCancelImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pCancelImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pCancelImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pCancelImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pCancelImpInvoice.InvoiceNote)
                db.AddParameter("p_DOC_TYPE", pCancelImpInvoice.DocType)
                db.AddParameter("p_INVOICE_TYPE", pCancelImpInvoice.InvoiceType)
                db.AddParameter("p_CANCEL_NOTE", pCancelImpInvoice.CancelNote)
                db.AddParameter("p_CANCEL_BY", pCancelImpInvoice.CancelBy)
                db.AddParameter("p_CANCEL_ON", pCancelImpInvoice.CancelOn, ParameterDirection.Output)
                db.AddParameter("p_CREATED_BY", pCancelImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCancelImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCancelImpInvoice.ClInvoiceId = db.Parameters.Item("p_CL_INVOICE_ID").value
                    pCancelImpInvoice.ClInvoiceNo = db.Parameters.Item("p_CL_INVOICE_NO").value.ToString
                    pCancelImpInvoice.CancelOn = db.Parameters.Item("p_CANCEL_ON").value.ToString
                End If

                If pCancelImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoice"></param>
        ''' <returns>Return pCancelImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoice.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoice.ClInvoiceId, ParameterDirection.Output)
                db.AddParameter("p_CL_INVOICE_NO", pCancelImpInvoice.ClInvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pCancelImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pCancelImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pCancelImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pCancelImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pCancelImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pCancelImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pCancelImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pCancelImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pCancelImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pCancelImpInvoice.InvoiceNote)
                db.AddParameter("p_DOC_TYPE", pCancelImpInvoice.DocType)
                db.AddParameter("p_INVOICE_TYPE", pCancelImpInvoice.InvoiceType)
                db.AddParameter("p_CANCEL_NOTE", pCancelImpInvoice.CancelNote)
                db.AddParameter("p_CANCEL_BY", pCancelImpInvoice.CancelBy)
                db.AddParameter("p_CANCEL_ON", pCancelImpInvoice.CancelOn, ParameterDirection.Output)
                db.AddParameter("p_CREATED_BY", pCancelImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCancelImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCancelImpInvoice.ClInvoiceId = db.Parameters.Item("p_CL_INVOICE_ID").value
                pCancelImpInvoice.ClInvoiceNo = db.Parameters.Item("p_CL_INVOICE_NO").value.ToString
                pCancelImpInvoice.CancelOn = db.Parameters.Item("p_CANCEL_ON").value.ToString

            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
            End Try
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoice"></param>
        ''' <returns>Return pCancelImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoice.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoice.ClInvoiceId)
                db.AddParameter("p_CL_INVOICE_NO", pCancelImpInvoice.ClInvoiceNo)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pCancelImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pCancelImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pCancelImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pCancelImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pCancelImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pCancelImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pCancelImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pCancelImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pCancelImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pCancelImpInvoice.InvoiceNote)
                db.AddParameter("p_DOC_TYPE", pCancelImpInvoice.DocType)
                db.AddParameter("p_INVOICE_TYPE", pCancelImpInvoice.InvoiceType)
                db.AddParameter("p_CANCEL_NOTE", pCancelImpInvoice.CancelNote)
                db.AddParameter("p_CANCEL_BY", pCancelImpInvoice.CancelBy)
                db.AddParameter("p_CANCEL_ON", pCancelImpInvoice.CancelOn)
                db.AddParameter("p_CREATED_BY", pCancelImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCancelImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCancelImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoice"></param>
        ''' <returns>Return pCancelImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoice.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoice.ClInvoiceId)
                db.AddParameter("p_CL_INVOICE_NO", pCancelImpInvoice.ClInvoiceNo)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pCancelImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pCancelImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pCancelImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pCancelImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pCancelImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pCancelImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pCancelImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pCancelImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pCancelImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pCancelImpInvoice.InvoiceNote)
                db.AddParameter("p_DOC_TYPE", pCancelImpInvoice.DocType)
                db.AddParameter("p_INVOICE_TYPE", pCancelImpInvoice.InvoiceType)
                db.AddParameter("p_CANCEL_NOTE", pCancelImpInvoice.CancelNote)
                db.AddParameter("p_CANCEL_BY", pCancelImpInvoice.CancelBy)
                db.AddParameter("p_CANCEL_ON", pCancelImpInvoice.CancelOn)
                db.AddParameter("p_CREATED_BY", pCancelImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCancelImpInvoice.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
            End Try
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pCancelImpInvoice.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_ID").ToString <> "" Then
                                pCancelImpInvoice.ClInvoiceId = dbr("CL_INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_NO").ToString <> "" Then
                                pCancelImpInvoice.ClInvoiceNo = dbr("CL_INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                pCancelImpInvoice.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                pCancelImpInvoice.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_DATE").ToString <> "" Then
                                pCancelImpInvoice.InvoiceDate = dbr("INVOICE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_REF_NO").ToString <> "" Then
                                pCancelImpInvoice.InvoiceRefNo = dbr("INVOICE_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                pCancelImpInvoice.ServiceType = dbr("SERVICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                pCancelImpInvoice.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                pCancelImpInvoice.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_MODE").ToString <> "" Then
                                pCancelImpInvoice.PaymentMode = dbr("PAYMENT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_TILL_DATE").ToString <> "" Then
                                pCancelImpInvoice.GrTillDate = dbr("GR_TILL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                pCancelImpInvoice.PrintStatus = dbr("PRINT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                pCancelImpInvoice.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NOTE").ToString <> "" Then
                                pCancelImpInvoice.InvoiceNote = dbr("INVOICE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                pCancelImpInvoice.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_TYPE").ToString <> "" Then
                                pCancelImpInvoice.InvoiceType = dbr("INVOICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_NOTE").ToString <> "" Then
                                pCancelImpInvoice.CancelNote = dbr("CANCEL_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_BY").ToString <> "" Then
                                pCancelImpInvoice.CancelBy = dbr("CANCEL_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_ON").ToString <> "" Then
                                pCancelImpInvoice.CancelOn = dbr("CANCEL_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCancelImpInvoice.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCancelImpInvoice.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
            End Try
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCancelImpInvoice As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CancelImpInvoice
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_ID").ToString <> "" Then
                                temp.ClInvoiceId = dbr("CL_INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_NO").ToString <> "" Then
                                temp.ClInvoiceNo = dbr("CL_INVOICE_NO")
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
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_TYPE").ToString <> "" Then
                                temp.InvoiceType = dbr("INVOICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_NOTE").ToString <> "" Then
                                temp.CancelNote = dbr("CANCEL_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_BY").ToString <> "" Then
                                temp.CancelBy = dbr("CANCEL_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCEL_ON").ToString <> "" Then
                                temp.CancelOn = dbr("CANCEL_ON")
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
        Public Shared Function ReturnCancelImpInvoiceByInvoiceRefNo(ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CL_IMP_INVOICE_BY_REF_NO", pCancelImpInvoice.TerminalId & ",'" & pCancelImpInvoice.InvoiceRefNo & "'")
                pCancelImpInvoice = ReturnObjectValues(dbr, pCancelImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCancelImpInvoiceByClInvoiceId(ByVal pCancelImpInvoice As CancelImpInvoice) As CancelImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CL_IMP_INVOICE_BY_CI_ID", pCancelImpInvoice.TerminalId & "," & pCancelImpInvoice.ClInvoiceId)
                pCancelImpInvoice = ReturnObjectValues(dbr, pCancelImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCancelImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCancelImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCancelImpInvoiceListByLineItemId(ByVal pCancelImpInvoice As CancelImpInvoice) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCancelImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CL_IMP_INVOICE_BY_LITEM_ID", pCancelImpInvoice.TerminalId & "," & pCancelImpInvoice.LineItemId)
                arrCancelImpInvoice = ReturnObjectValuesList(dbr, arrCancelImpInvoice)
                dbr.Close()
            Catch ex As Exception
                arrCancelImpInvoice = Nothing
            End Try
            db.CloseDB()
            Return arrCancelImpInvoice
        End Function


        Public Shared Function ReturnCancelInvoice(ByVal pCancelImpInvoice As CancelImpInvoice) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCancelImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CANCEL_INVOICE_LIST", pCancelImpInvoice.TerminalId)
                arrCancelImpInvoice = ReturnObjectValuesList(dbr, arrCancelImpInvoice)
                dbr.Close()
            Catch ex As Exception
                arrCancelImpInvoice = Nothing
            End Try
            db.CloseDB()
            Return arrCancelImpInvoice
        End Function

    End Class
End Namespace
