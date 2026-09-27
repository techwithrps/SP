Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class CostBookingDtls
        Private lngCostId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCostDtlsId As Long
        Private lngServiceId As Long    ' Define Private Variable LineItemId With DataType As Long 
        Private lngQnty As Double  ' Define Private Variable InvoiceRefNo With DataType As String
        Private lngRate As Double
        Private lngExRate As Double   ' Define Private Variable ServiceType With DataType As String 
        Private lngTaxPerc As Double
        Private lngBaseRate As Double
        Private lngTaxAmt As Double
        Private lngTotal As Double
        Private lngCGSTRate As Double
        Private lngSGSTRate As Double
        Private lngIGSTRate As Double
        Private lngIGSTAmount As Double
        Private lngSGSTAmount As Double
		Private lngCGSTAmount As Double
        Private lngTDSAmount As Double
        Private LngMtyContId As Long
        Private strContNO As String
		Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strCreatedBy As String
        Private strCreatedOn As String
        Private lngKeyId As Long
        Dim arrCostBookingDtls As ArrayList
        Dim ArrCostBooking As New ArrayList
        Public Property ListCostBooking() As ArrayList
            Get
                Return ArrCostBooking
            End Get
            Set(ByVal value As ArrayList)
                ArrCostBooking = value
            End Set
        End Property

        Public Property CostBookingList() As ArrayList
            Get
                Return arrCostBookingDtls
            End Get
            Set(ByVal value As ArrayList)
                arrCostBookingDtls = value
            End Set
        End Property
        Public Property CostID() As Long
            Get
                Return lngCostId
            End Get
            Set(ByVal value As Long)
                lngCostId = value
            End Set
        End Property
        Public Property ContNO() As String
            Get
                Return strContNO
            End Get
            Set(ByVal value As String)
                strContNO = value
            End Set
        End Property
        Public Property CostDtlsID() As Long
            Get
                Return lngCostDtlsId
            End Get
            Set(ByVal value As Long)
                lngCostDtlsId = value
            End Set
        End Property
        Public Property KeyId() As Long
            Get
                Return lngKeyId
            End Get
            Set(ByVal value As Long)
                lngKeyId = value
            End Set
        End Property
        Public Property ServiceID() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property
		Public Property Total() As Double
			Get
				Return lngTotal
			End Get
			Set(ByVal value As Double)
				lngTotal = value
			End Set
		End Property

		Public Property TDSAmount() As Double
			Get
				Return lngTDSAmount
			End Get
			Set(ByVal value As Double)
				lngTDSAmount = value
			End Set
		End Property
		Public Property CGSTRate() As Double
            Get
                Return lngCGSTRate
            End Get
            Set(ByVal value As Double)
                lngCGSTRate = value
            End Set
        End Property

        Public Property SGSTRate() As Double
            Get
                Return lngSGSTRate
            End Get
            Set(ByVal value As Double)
                lngSGSTRate = value
            End Set
        End Property
        Public Property IGSTRate() As Double
            Get
                Return lngIGSTRate
            End Get
            Set(ByVal value As Double)
                lngIGSTRate = value
            End Set
        End Property

        Public Property IGSTAmount() As Double
            Get
                Return lngIGSTAmount
            End Get
            Set(ByVal value As Double)
                lngIGSTAmount = value
            End Set
        End Property

        Public Property CGSTAmount() As Double
            Get
                Return lngCGSTAmount
            End Get
            Set(ByVal value As Double)
                lngCGSTAmount = value
            End Set
        End Property

        Public Property SGSTAmount() As Double
            Get
                Return lngSGSTAmount
            End Get
            Set(ByVal value As Double)
                lngSGSTAmount = value
            End Set
        End Property

        Public Property TaxAmt() As Double
            Get
                Return lngTaxAmt
            End Get
            Set(ByVal value As Double)
                lngTaxAmt = value
            End Set
        End Property
        Public Property BaseRate() As Double
            Get
                Return lngBaseRate
            End Get
            Set(ByVal value As Double)
                lngBaseRate = value
            End Set
        End Property
        Public Property TaxPerc() As Double
            Get
                Return lngTaxPerc
            End Get
            Set(ByVal value As Double)
                lngTaxPerc = value
            End Set
        End Property
        Public Property ExRate() As Double
            Get
                Return lngExRate
            End Get
            Set(ByVal value As Double)
                lngExRate = value
            End Set
        End Property
        Public Property Rate() As Double
            Get
                Return lngRate
            End Get
            Set(ByVal value As Double)
                lngRate = value
            End Set
        End Property
        Public Property Qnty() As Double
            Get
                Return lngQnty
            End Get
            Set(ByVal value As Double)
                lngQnty = value
            End Set
        End Property
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property

        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property
        Public Property MtyContId() As Long
            Get
                Return LngMtyContId
            End Get
            Set(ByVal value As Long)
                LngMtyContId = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngCostId = 0
            lngCostDtlsId = 0
            lngServiceId = 0
            lngQnty = 0.0
            lngRate = 0.0
            lngExRate = 0.0
            lngTaxPerc = 0.0
            lngBaseRate = 0.0
            lngTaxAmt = 0.0
            lngTotal = 0.0
            strErrormsg = ""
            lngIGSTRate = 0
            lngCGSTRate = 0
            lngSGSTRate = 0
            lngCGSTAmount = 0
            lngSGSTAmount = 0
			lngIGSTAmount = 0
			lngTDSAmount = 0
			strCreatedBy = ""
            strCreatedOn = ""
            LngMtyContId = 0
            lngKeyId = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCostBookingDtls"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBookingDtls.CostID)
                db.AddParameter("p_COST_DTLS_ID", pCostBookingDtls.CostDtlsID, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pCostBookingDtls.ServiceID)
                db.AddParameter("p_QNTY", pCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pCostBookingDtls.Total)
                db.AddParameter("p_ErrorMsg", pCostBookingDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBookingDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostBookingDtls.CostDtlsID = db.Parameters.Item("p_COST_DTLS_ID").value
                If pCostBookingDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostBookingDtls
        End Function
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBookingDtls.CostID)
                db.AddParameter("p_COST_DTLS_ID", pCostBookingDtls.CostDtlsID, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pCostBookingDtls.ServiceID)
                db.AddParameter("p_QNTY", pCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pCostBookingDtls.Total)
                db.AddParameter("p_ErrorMsg", pCostBookingDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBookingDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostBookingDtls.CostDtlsID = db.Parameters.Item("p_COST_DTLS_ID").value
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
            End Try
            Return pCostBookingDtls
        End Function

        Public Shared Function InsertTrnNew(ByVal db As DBConnect, ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBookingDtls.CostID)
                db.AddParameter("p_COST_DTLS_ID", pCostBookingDtls.CostDtlsID, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pCostBookingDtls.ServiceID)
                db.AddParameter("p_QNTY", pCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pCostBookingDtls.CGSTRate)
                db.AddParameter("p_SGST_RATE", pCostBookingDtls.SGSTRate)
                db.AddParameter("p_IGST_RATE", pCostBookingDtls.IGSTRate)
                db.AddParameter("p_CGST_AMOUNT", pCostBookingDtls.CGSTAmount)
                db.AddParameter("p_SGST_AMOUNT", pCostBookingDtls.SGSTAmount)
				db.AddParameter("p_IGST_AMOUNT", pCostBookingDtls.IGSTAmount)
                db.AddParameter("p_TDS_AMOUNT", pCostBookingDtls.TDSAmount)
                db.AddParameter("p_MTY_CONT_ID", pCostBookingDtls.MtyContId)
				db.AddParameter("p_ErrorMsg", pCostBookingDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_NEWCOST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBookingDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostBookingDtls.CostDtlsID = db.Parameters.Item("p_COST_DTLS_ID").value
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
            End Try
            Return pCostBookingDtls
        End Function

        Public Shared Function InsertTrnNew1(ByVal db As DBConnect, ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBookingDtls.CostID)
                db.AddParameter("p_COST_DTLS_ID", pCostBookingDtls.CostDtlsID, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pCostBookingDtls.ServiceID)
                db.AddParameter("p_QNTY", pCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pCostBookingDtls.CGSTRate)
                db.AddParameter("p_SGST_RATE", pCostBookingDtls.SGSTRate)
                db.AddParameter("p_IGST_RATE", pCostBookingDtls.IGSTRate)
                db.AddParameter("p_CGST_AMOUNT", pCostBookingDtls.CGSTAmount)
                db.AddParameter("p_SGST_AMOUNT", pCostBookingDtls.SGSTAmount)
                db.AddParameter("p_IGST_AMOUNT", pCostBookingDtls.IGSTAmount)
                db.AddParameter("p_TDS_AMOUNT", pCostBookingDtls.TDSAmount)
                db.AddParameter("p_MTY_CONT_ID", pCostBookingDtls.MtyContId)
                db.AddParameter("p_ErrorMsg", pCostBookingDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_NEWCOST_BOOKING_DTLS1", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBookingDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostBookingDtls.CostDtlsID = db.Parameters.Item("p_COST_DTLS_ID").value
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
            End Try
            Return pCostBookingDtls
        End Function
        Public Shared Function UpdateTrnNew(ByVal db As DBConnect, ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBookingDtls.CostID)
                db.AddParameter("p_COST_DTLS_ID", pCostBookingDtls.CostDtlsID)
                db.AddParameter("p_SERVICE_ID", pCostBookingDtls.ServiceID)
                db.AddParameter("p_QNTY", pCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pCostBookingDtls.CGSTRate)
                db.AddParameter("p_SGST_RATE", pCostBookingDtls.SGSTRate)
                db.AddParameter("p_IGST_RATE", pCostBookingDtls.IGSTRate)
                db.AddParameter("p_CGST_AMOUNT", pCostBookingDtls.CGSTAmount)
                db.AddParameter("p_SGST_AMOUNT", pCostBookingDtls.SGSTAmount)
				db.AddParameter("p_IGST_AMOUNT", pCostBookingDtls.IGSTAmount)
                db.AddParameter("p_TDS_AMOUNT", pCostBookingDtls.TDSAmount)
                db.AddParameter("p_MTY_CONT_ID", pCostBookingDtls.MtyContId)
				db.AddParameter("p_ErrorMsg", pCostBookingDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_NEWCOST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBookingDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
            End Try
            Return pCostBookingDtls
        End Function


        ' ''' <summary>
        ' ''' Update Member Function to Update the Print Status of Invoice
        ' ''' </summary>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdatePrint(ByVal pCr As CreaditNote) As CreaditNote
        '    Dim db As New DBConnect
        '    Try
        '        db.BeginTransaction()
        '        db.ClearParameters()
        '        db.AddParameter("p_CR_ID", pCR.CrId, ParameterDirection.Output)
        '        db.AddParameter("p_CR_DATE", pCR.CrDate)
        '        db.AddParameter("p_CR_REF_NO", pCR.CrRefNo, ParameterDirection.Output)
        '        db.AddParameter("p_IVNOICE_ID", pCR.InvID)
        '        db.AddParameter("p_INVOICE_AMT", pCR.InvoiceAmt)
        '        db.AddParameter("p_CR_AMT", pCR.CrAmt)
        '        db.AddParameter("p_CR_TAX", pCR.CrTax)
        '        db.AddParameter("p_CR_BY", pCR.CrBy)
        '        db.AddParameter("p_CR_ON", pCR.CrOn)
        '        db.AddParameter("p_QNTY", pCR.Qnty)
        '        db.AddParameter("p_ErrorMsg", pCR.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_CR_NOTE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        If pCr.Errormsg <> Nothing Then
        '            db.RollbackTransaction()
        '        Else
        '            db.CommitTransaction()
        '        End If
        '    Catch ex As Exception
        '        pCr.Errormsg = ex.Message
        '        db.RollbackTransaction()
        '    End Try
        '    db.CloseDB()
        '    Return pCr
        'End Function

        ' ''' <summary>
        ' ''' Update Member Function to Cancel Invoice
        ' ''' </summary>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdateCancel(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Dim db As New DBConnect
        '    Try
        '        db.BeginTransaction()
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
        '        db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
        '        db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
        '        db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
        '        db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
        '        db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
        '        db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
        '        db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
        '        db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
        '        db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
        '        db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
        '        db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
        '        db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_IMP_INVOICE_CANCEL", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        If pImpInvoice.Errormsg <> Nothing Then
        '            db.RollbackTransaction()
        '        Else
        '            db.CommitTransaction()
        '        End If
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '        db.RollbackTransaction()
        '    End Try
        '    db.CloseDB()
        '    Return pImpInvoice
        'End Function


        ' ''' <summary>
        ' ''' Update Member Function to Update the New Record
        ' ''' </summary>
        ' ''' <param name="db"></param>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Try
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
        '        db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
        '        db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
        '        db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
        '        db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
        '        db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
        '        db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
        '        db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
        '        db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
        '        db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
        '        db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
        '        db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
        '        db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
        '        db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
        '        db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_IMP_INVOICE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    Return pImpInvoice
        'End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCostBookingDtls As CostBookingDtls) As CostBookingDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                pCostBookingDtls.CostID = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                pCostBookingDtls.CostDtlsID = dbr("COST_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pCostBookingDtls.ServiceID = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                pCostBookingDtls.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                pCostBookingDtls.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pCostBookingDtls.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                pCostBookingDtls.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                pCostBookingDtls.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                pCostBookingDtls.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                pCostBookingDtls.Total = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                pCostBookingDtls.CGSTRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                pCostBookingDtls.SGSTRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                pCostBookingDtls.IGSTRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                pCostBookingDtls.CGSTAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                pCostBookingDtls.SGSTAmount = dbr("SGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
						Try
							If dbr("IGST_AMOUNT").ToString <> "" Then
								pCostBookingDtls.IGSTAmount = dbr("IGST_AMOUNT")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("TDS_AMOUNT").ToString <> "" Then
								pCostBookingDtls.TDSAmount = dbr("TDS_AMOUNT")
							End If
						Catch ex1 As Exception
						End Try
						Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCostBookingDtls.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCostBookingDtls.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pCostBookingDtls.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                pCostBookingDtls.KeyId = dbr("KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCostBookingDtls.Errormsg = ex.Message
            End Try
            Return pCostBookingDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCR As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CostBookingDtls
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                temp.CostID = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                temp.CostDtlsID = dbr("COST_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceID = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                temp.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                temp.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                temp.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                temp.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                temp.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                temp.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                temp.Total = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                temp.CGSTRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                temp.SGSTRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                temp.IGSTRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                temp.CGSTAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                temp.SGSTAmount = dbr("SGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_AMOUNT").ToString <> "" Then
                                temp.IGSTAmount = dbr("IGST_AMOUNT")
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
							If dbr("TDS_AMOUNT").ToString <> "" Then
								temp.TDSAmount = dbr("TDS_AMOUNT")
							End If
						Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                temp.KeyId = dbr("KEY_ID")
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

        Public Shared Function ReturnPurchaseServiceListByCostId(ByVal pCr As CostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_ITEMS_TALLY", 1 & "," & pCr.CostID)
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function

        Public Shared Function ReturnPurchaseGSTNWiseDetailsForTally(ByVal pCr As CostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_SERVICE_TAX", pCr.CostID)
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function

        Public Shared Function ReturnCostBookingDtlsByCostId(ByVal pCr As CostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_DTLS_BY_ID", pCr.CostID)
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function
        
    End Class
End Namespace
