
Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ImpInvoice
    ''' @author	: Amit K. Singh- 06/07/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ImpInvoice

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
        Private strUpdatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strPaymentstatus As String ' Define Private Variable PaymentStatus With DataType As String 
        Private strInvoiceType As String ' Define Private Variable InvoiceType With DataType As String 
        Private lngTaxExemptionPerc As Long ' Define Private Variable TaxExemptionPerc With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strDocType As String
        Private strPoNo As String
        Private strPoDate As String
        Private lngVisitId As Long
        Private lngExporterId As Long
        Private lngRefInvId As Long
        Private strCrDr As String
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long
        Private lngAdvanceAmount As Long
        Private strEinvoiceStatus As String ' Define Private Variable ServiceType With DataType As String 
        ''new
        Private strBookingNo As String ' Define Private Variable BookingNo With DataType As String 
        Private strBookingDate As String ' Define Private Variable BookingDate With DataType As String 
        ''new


        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        ''' <value>lngTaxExemptionPerc</value>
        ''' <returns> Return lngTaxExemptionPerc</returns>
        ''' <remarks> Get or Set the Value of TaxExemptionPerc</remarks>
        '''
        Public Property RefInvId() As Long
            Get
                Return lngRefInvId
            End Get
            Set(ByVal value As Long)
                lngRefInvId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property CrDr() As String
            Get
                Return strCrDr
            End Get
            Set(ByVal value As String)
                strCrDr = value
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
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngComapnyId</value>
        ''' <returns> Return lngComapnyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property

        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
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
        ''' Get or Set the Value of EinvoiceStatus
        ''' </summary>
        ''' <value>strEinvoiceStatus</value>
        ''' <returns> Return strEinvoiceStatus</returns>
        ''' <remarks> Get or Set the Value of EinvoiceStatus  </remarks>
        '''
        Public Property EinvoiceStatus() As String
            Get
                Return strEinvoiceStatus
            End Get
            Set(ByVal value As String)
                strEinvoiceStatus = value
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
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strUpdateBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property UpdatedBy() As String
            Get
                Return strUpdatedBy
            End Get
            Set(ByVal value As String)
                strUpdatedBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strUpdateOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property UpdatedOn() As String
            Get
                Return strUpdatedOn
            End Get
            Set(ByVal value As String)
                strUpdatedOn = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of PaymentStatus
        ''' </summary>
        ''' <value>strPaymentStatus</value>
        ''' <returns> Return strPaymentStatus</returns>
        ''' <remarks> Get or Set the Value of PaymentStatus </remarks>
        '''
        Public Property PaymentStatus() As String
            Get
                Return strPaymentstatus
            End Get
            Set(ByVal value As String)
                strPaymentstatus = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of InvoiceType
        ''' </summary>
        ''' <value>strInvoiceType</value>
        ''' <returns> Return strInvoiceType</returns>
        ''' <remarks> Get or Set the Value of InvoiceType </remarks>
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
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        ''' <value>lngTaxExemptionPerc</value>
        ''' <returns> Return lngTaxExemptionPerc</returns>
        ''' <remarks> Get or Set the Value of TaxExemptionPerc</remarks>
        '''
        Public Property TaxExemptionPerc() As Long
            Get
                Return lngTaxExemptionPerc
            End Get
            Set(ByVal value As Long)
                lngTaxExemptionPerc = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property PoNo() As String
            Get
                Return strPoNo
            End Get
            Set(ByVal value As String)
                strPoNo = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property PoDate() As String
            Get
                Return strPoDate
            End Get
            Set(ByVal value As String)
                strPoDate = value
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
        ''' Get or Set the Value of InvoiceNo
        ''' </summary>
        ''' <value>lngInvoiceNo</value>
        ''' <returns> Return lngInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceNo  </remarks>
        '''
        Public Property VisitId() As Long
            Get
                Return lngVisitId
            End Get
            Set(ByVal value As Long)
                lngVisitId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of InvoiceNo
        ''' </summary>
        ''' <value>lngInvoiceNo</value>
        ''' <returns> Return lngInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceNo  </remarks>
        '''
        Public Property ExporterId() As Long
            Get
                Return lngExporterId
            End Get
            Set(ByVal value As Long)
                lngExporterId = value
            End Set
        End Property


        Public Property AdvanceAmount() As Long
            Get
                Return lngAdvanceAmount
            End Get
            Set(ByVal value As Long)
                lngAdvanceAmount = value
            End Set
        End Property

        ''new
        Public Property BookingNo() As String
            Get
                Return strBookingNo
            End Get
            Set(ByVal value As String)
                strBookingNo = value
            End Set
        End Property

        Public Property BookingDate() As String
            Get
                Return strBookingDate
            End Get
            Set(ByVal value As String)
                strBookingDate = value
            End Set
        End Property
        ''new


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
            strEinvoiceStatus = ""
            lngBillTo = 0
            strPaymentMode = ""
            strGrTillDate = ""
            strPrintStatus = ""
            lngReceiptNo = 0
            strInvoiceNote = ""
            strCancleFlage = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            strErrormsg = ""
            strDocType = ""
            strPoNo = ""
            lngRefInvId = 0
            strCrDr = ""
            strPoDate = ""
            lngVisitId = 0
            lngExporterId = 0
            lngCompanyId = 0
            lngAdvanceAmount = 0
            strBookingNo = ""
            strBookingDate = ""

        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_VISIT_ID", pImpInvoice.VisitId)
                db.AddParameter("p_EXPORTER_ID", pImpInvoice.ExporterId)
                db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
                db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
                pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
                pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString

                If pImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.InputOutput)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.InputOutput)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_PO_NO", pImpInvoice.PoNo)
                db.AddParameter("p_PO_DATE", pImpInvoice.PoDate)
                db.AddParameter("p_VISIT_ID", pImpInvoice.VisitId)
                db.AddParameter("p_EXPORTER_ID", pImpInvoice.ExporterId)
                db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
                db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ADVANCE_AMOUNT", pImpInvoice.AdvanceAmount)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
                pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
                pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString

            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the Print Status of Invoice
        ''' </summary>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdatePrint(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE_PRINT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Cancel Invoice
        ''' </summary>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateCancel(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE_CANCEL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_PO_NO", pImpInvoice.PoNo)
                db.AddParameter("p_PO_DATE", pImpInvoice.PoDate)
                db.AddParameter("p_VISIT_ID", pImpInvoice.VisitId)
                db.AddParameter("p_EXPORTER_ID", pImpInvoice.ExporterId)
                db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
                db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pImpInvoice.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                pImpInvoice.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                pImpInvoice.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_DATE").ToString <> "" Then
                                pImpInvoice.InvoiceDate = dbr("INVOICE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_REF_NO").ToString <> "" Then
                                pImpInvoice.InvoiceRefNo = dbr("INVOICE_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                pImpInvoice.ServiceType = dbr("SERVICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE").ToString <> "" Then
                                pImpInvoice.CustomerType = dbr("CUSTOMER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                pImpInvoice.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_MODE").ToString <> "" Then
                                pImpInvoice.PaymentMode = dbr("PAYMENT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_TILL_DATE").ToString <> "" Then
                                pImpInvoice.GrTillDate = dbr("GR_TILL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                pImpInvoice.PrintStatus = dbr("PRINT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RECEIPT_NO").ToString <> "" Then
                                pImpInvoice.ReceiptNo = dbr("RECEIPT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NOTE").ToString <> "" Then
                                pImpInvoice.InvoiceNote = dbr("INVOICE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CANCLE_FLAGE").ToString <> "" Then
                                pImpInvoice.CancleFlage = dbr("CANCLE_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pImpInvoice.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pImpInvoice.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                pImpInvoice.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                pImpInvoice.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                pImpInvoice.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_STATUS").ToString <> "" Then
                                pImpInvoice.PaymentStatus = dbr("PAYMENT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_TYPE").ToString <> "" Then
                                pImpInvoice.InvoiceType = dbr("INVOICE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_EXEMPTION_PERC").ToString <> "" Then
                                pImpInvoice.TaxExemptionPerc = dbr("TAX_EXEMPTION_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PO_NO").ToString <> "" Then
                                pImpInvoice.PoNo = dbr("PO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PO_DATE").ToString <> "" Then
                                pImpInvoice.PoDate = dbr("PO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                pImpInvoice.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXPORTER_ID").ToString <> "" Then
                                pImpInvoice.ExporterId = dbr("EXPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_INV_ID").ToString <> "" Then
                                pImpInvoice.RefInvId = dbr("REF_INV_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DR").ToString <> "" Then
                                pImpInvoice.CrDr = dbr("CR_DR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pImpInvoice.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE_AMOUNT").ToString <> "" Then
                                pImpInvoice.AdvanceAmount = dbr("ADVANCE_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EINVOICE_STATUS").ToString <> "" Then
                                pImpInvoice.EinvoiceStatus = dbr("EINVOICE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                pImpInvoice.BookingNo = dbr("BOOKING_NO")

                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dbr("BOOKING_DATE").ToString <> "" Then
                                pImpInvoice.BookingDate = dbr("BOOKING_DATE")

                            End If
                        Catch ex As Exception

                        End Try
                    End While
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrImpInvoice As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ImpInvoice
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
                            If dbr("UPADTED_BY").ToString <> "" Then
                                temp.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                temp.UpdatedOn = dbr("UPDATED_ON")
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
                            If dbr("PAYMENT_STATUS").ToString <> "" Then
                                temp.PaymentStatus = dbr("PAYMENT_STATUS")
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
                            If dbr("TAX_EXEMPTION_PERC").ToString <> "" Then
                                temp.TaxExemptionPerc = dbr("TAX_EXEMPTION_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PO_NO").ToString <> "" Then
                                temp.PoNo = dbr("PO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PO_DATE").ToString <> "" Then
                                temp.PoDate = dbr("PO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                temp.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXPORTER_ID").ToString <> "" Then
                                temp.ExporterId = dbr("EXPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_INV_ID").ToString <> "" Then
                                temp.RefInvId = dbr("REF_INV_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DR").ToString <> "" Then
                                temp.CrDr = dbr("CR_DR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE_AMOUNT").ToString <> "" Then
                                temp.AdvanceAmount = dbr("ADVANCE_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EINVOICE_STATUS").ToString <> "" Then
                                temp.EinvoiceStatus = dbr("EINVOICE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                temp.BookingNo = dbr("BOOKING_NO")

                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dbr("BOOKING_DATE").ToString <> "" Then
                                temp.BookingDate = dbr("BOOKING_DATE")

                            End If
                        Catch ex As Exception

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
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceByInvoiceNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_BY_ID", pImpInvoice.TerminalId & "," & pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceRefNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceByInvoiceRefNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_BY_REF_NO", pImpInvoice.TerminalId & ",'" & pImpInvoice.InvoiceRefNo & "'")
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceRefNo, CompanyId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceByInvoiceRefNoComapny(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_BY_COMPANY", pImpInvoice.TerminalId & ",'" & pImpInvoice.InvoiceRefNo & "'")
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceRefNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceByInvoiceRefNoAndCompany(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INV_BY_REF_NOAC", pImpInvoice.TerminalId & ",'" & pImpInvoice.InvoiceRefNo & "'")
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function
        Public Shared Function ReturnImpInvoiceTallyNarationByInvoiceNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_NARATION_BY_INVOICE", pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function
        Public Shared Function ReturnImpInvoiceTallyNarationByFreightInvoiceNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_NARATION_BY_FRT", pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function
        Public Shared Function ReturnImpInvoiceTallyNarationByCR(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_NARATION_BY_CR", pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function
        Public Shared Function ReturnImpInvoiceTallySJNarationByInvoiceNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_SUPP_SJ_INVOICE", pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function
        Public Shared Function ReturnImpInvoiceTallySuppByInvoiceNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_SUPP_BY_INVOICE", pImpInvoice.InvoiceNo)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        Public Shared Function ReturnImpInvoiceContJoId(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_CONT_JO_ID", pImpInvoice.TerminalId & "," & pImpInvoice.LineItemId & "," & pImpInvoice.CompanyId)
                pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, LineItemId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceListByLineItemId(ByVal pImpInvoice As ImpInvoice) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ALL_LINEITEMID", pImpInvoice.TerminalId & "," & pImpInvoice.LineItemId & " ,'" & pImpInvoice.DocType & "'")
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoice = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function
        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnTemp(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_BOOKING_NO", pImpInvoice.BookingNo, ParameterDirection.Output)
                db.AddParameter("p_BOOKING_DATE", pImpInvoice.BookingDate, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
                pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
                pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString
                pImpInvoice.BookingNo = db.Parameters.Item("p_BOOKING_NO").value.ToString
                pImpInvoice.BookingDate = db.Parameters.Item("p_BOOKING_DATE").value



            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            Return pImpInvoice
        End Function
        ''
        ''new for booking no
        Public Shared Function InsertRebate(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.InputOutput)
                db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.InputOutput)
                db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
                db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
                db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
                db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
                db.AddParameter("p_PO_NO", pImpInvoice.PoNo)
                db.AddParameter("p_PO_DATE", pImpInvoice.PoDate)
                db.AddParameter("p_VISIT_ID", pImpInvoice.VisitId)
                db.AddParameter("p_EXPORTER_ID", pImpInvoice.ExporterId)
                db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
                db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
                db.AddParameter("p_COMPANY_ID", pImpInvoice.CompanyId)
                db.AddParameter("p_ADVANCE_AMOUNT", pImpInvoice.AdvanceAmount)
                db.AddParameter("p_BOOKING_NO", pImpInvoice.BookingNo, ParameterDirection.InputOutput)
                db.AddParameter("p_BOOKING_DATE", pImpInvoice.BookingDate)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_REBATE_IMP_INVOICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
                pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
                pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString
                pImpInvoice.BookingNo = db.Parameters.Item("p_BOOKING_NO").value.ToString
                pImpInvoice.BookingDate = db.Parameters.Item("p_BOOKING_DATE").value

            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
            End Try
            Return pImpInvoice
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''

        Public Shared Function UpdateInvoiceNote(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()

                db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
                db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
                db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
                db.AddParameter("p_UPDATED_BY", pImpInvoice.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pImpInvoice.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoice
        End Function


        Public Shared Function ReturnImpInvoiceNoListByLineItemId(ByVal pImpInvoice As ImpInvoice) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_NO_LINEITEMID", pImpInvoice.TerminalId & "," & pImpInvoice.LineItemId & " ,'" & pImpInvoice.DocType & "'")
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoice = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function
    End Class
End Namespace
