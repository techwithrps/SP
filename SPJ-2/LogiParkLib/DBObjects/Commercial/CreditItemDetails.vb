Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class CreditItemDetails
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCrRefId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCrId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngInvoiceNo As Long
        Private lngInvItemKeyId As Long ' Define Private Variable ItemKeyId With DataType As Long 
        Private lngServiceId As Long
        Private lngServiceAmt As Double
        Private lngCrAmt As Double
        Private lngCrTax As Double
        Private strCrOn As String
        Private lngIgst As Double
        Private lngIgstRate As Double
        Private lngSgst As Double
        Private lngSgstRate As Double
        Private lngCgst As Double
        Private lngCgstRate As Double
        Private lngBillQnty As Double
        Private DblExrate As Double
        Private strCurrency As String
        Private strInfo As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property
        Public Property CrRefId() As Long
            Get
                Return lngCrRefId
            End Get
            Set(ByVal value As Long)
                lngCrRefId = value
            End Set
        End Property
        Public Property ExRate() As Double
            Get
                Return DblExrate
            End Get
            Set(ByVal value As Double)
                DblExrate = value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property
        Public Property CrId() As Long
            Get
                Return lngCrId
            End Get
            Set(ByVal value As Long)
                lngCrId = value
            End Set
        End Property
        Public Property Invoiceno() As Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of InvItemKeyId
        ''' </summary>
        ''' <value>InvItemKeyId</value>
        ''' <returns> Return InvItemKeyId</returns>
        ''' <remarks> Get or Set the Value of InvItemKeyId  </remarks>
        '''
        Public Property InvItemKeyId() As Long
            Get
                Return lngInvItemKeyId
            End Get
            Set(ByVal value As Long)
                lngInvItemKeyId = value
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
        Public Property BillQnty() As Double
            Get
                Return lngBillQnty
            End Get
            Set(ByVal value As Double)
                lngBillQnty = value
            End Set
        End Property
        Public Property ServiceAmt() As Double
            Get
                Return lngServiceAmt
            End Get
            Set(ByVal value As Double)
                lngServiceAmt = value
            End Set
        End Property
        Public Property CrAmt() As Double
            Get
                Return lngCrAmt
            End Get
            Set(ByVal value As Double)
                lngCrAmt = value
            End Set
        End Property
        Public Property CrTax() As Double
            Get
                Return lngCrTax
            End Get
            Set(ByVal value As Double)
                lngCrTax = value
            End Set
        End Property
        Public Property CrOn() As String
            Get
                Return strCrOn
            End Get
            Set(ByVal value As String)
                strCrOn = value
            End Set
        End Property
        Public Property IGST() As Double
            Get
                Return lngIgst
            End Get
            Set(ByVal value As Double)
                lngIgst = value
            End Set
        End Property
        Public Property IGSTRate() As Double
            Get
                Return lngIgstRate
            End Get
            Set(ByVal value As Double)
                lngIgstRate = value
            End Set
        End Property
        Public Property CGST() As Double
            Get
                Return lngCgst
            End Get
            Set(ByVal value As Double)
                lngCgst = value
            End Set
        End Property
        Public Property CGSTRate() As Double
            Get
                Return lngCgstRate
            End Get
            Set(ByVal value As Double)
                lngCgstRate = value
            End Set
        End Property
        Public Property SGST() As Double
            Get
                Return lngSgst
            End Get
            Set(ByVal value As Double)
                lngSgst = value
            End Set
        End Property
        Public Property SGSTRate() As Double
            Get
                Return lngSgstRate
            End Get
            Set(ByVal value As Double)
                lngSgstRate = value
            End Set
        End Property
        '==added by arjun negi on 11/8/2025 for admin and 'avnish devrani' id can create any ammount creadit note
        Public Property Info() As String
            Get
                Return strInfo
            End Get
            Set(ByVal value As String)
                strInfo = value
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
        Public Sub New()
            lngTerminalId = 0
            lngCrRefId = 0
            lngCrId = 0
            lngInvoiceNo = 0
            lngInvItemKeyId = 0
            lngServiceId = 0
            lngServiceAmt = 0.0
            lngCrAmt = 0.0
            lngCrTax = 0.0
            strCrOn = ""
            lngIgst = 0.0
            lngIgstRate = 0
            lngSgst = 0.0
            lngSgstRate = 0
            lngCgst = 0.0
            lngCgstRate = 0
            lngBillQnty = 0.0
            strInfo = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCreditItemDetails"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCreditItemDetails As CreditItemDetails) As CreditItemDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCreditItemDetails.TerminalId)
                db.AddParameter("p_CR_REF_ID", pCreditItemDetails.CrRefId, ParameterDirection.Output)
                db.AddParameter("p_CR_ID", pCreditItemDetails.CrId)
                db.AddParameter("p_INVOICE_NO", pCreditItemDetails.Invoiceno)
                db.AddParameter("p_INV_ITEM_KEY_ID", pCreditItemDetails.InvItemKeyId)
                db.AddParameter("p_SERVICE_ID", pCreditItemDetails.ServiceID)
                db.AddParameter("p_SERVICE_AMT", pCreditItemDetails.ServiceAmt)
                db.AddParameter("p_CR_AMT", pCreditItemDetails.CrAmt)
                db.AddParameter("p_CR_TAX", pCreditItemDetails.CrTax)
                db.AddParameter("p_CR_ON", pCreditItemDetails.CrOn)
                db.AddParameter("p_IGST", pCreditItemDetails.IGST)
                db.AddParameter("p_IGST_RATE", pCreditItemDetails.IGSTRate)
                db.AddParameter("p_CGST", pCreditItemDetails.CGST)
                db.AddParameter("p_CGST_RATE", pCreditItemDetails.CGSTRate)
                db.AddParameter("p_SGST", pCreditItemDetails.SGST)
                db.AddParameter("p_SGST_RATE", pCreditItemDetails.SGSTRate)
                db.AddParameter("p_BILL_QNTY", pCreditItemDetails.BillQnty)
                db.AddParameter("p_EX_RATE", pCreditItemDetails.ExRate)
                db.AddParameter("p_CURRENCY", pCreditItemDetails.Currency)
                db.AddParameter("p_ErrorMsg", pCreditItemDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CREDIT_ITEM_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCreditItemDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCreditItemDetails.CrRefId = db.Parameters.Item("p_CR_REF_ID").value
                End If

                If pCreditItemDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCreditItemDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCreditItemDetails
        End Function
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCreditItemDetails As CreditItemDetails) As CreditItemDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCreditItemDetails.TerminalId)
                db.AddParameter("p_CR_REF_ID", pCreditItemDetails.CrRefId, ParameterDirection.Output)
                db.AddParameter("p_CR_ID", pCreditItemDetails.CrId)
                db.AddParameter("p_INVOICE_NO", pCreditItemDetails.Invoiceno)
                db.AddParameter("p_INV_ITEM_KEY_ID", pCreditItemDetails.InvItemKeyId)
                db.AddParameter("p_SERVICE_ID", pCreditItemDetails.ServiceID)
                db.AddParameter("p_SERVICE_AMT", pCreditItemDetails.ServiceAmt)
                db.AddParameter("p_CR_AMT", pCreditItemDetails.CrAmt)
                db.AddParameter("p_CR_TAX", pCreditItemDetails.CrTax)
                db.AddParameter("p_CR_ON", pCreditItemDetails.CrOn)
                db.AddParameter("p_IGST", pCreditItemDetails.IGST)
                db.AddParameter("p_IGST_RATE", pCreditItemDetails.IGSTRate)
                db.AddParameter("p_CGST", pCreditItemDetails.CGST)
                db.AddParameter("p_CGST_RATE", pCreditItemDetails.CGSTRate)
                db.AddParameter("p_SGST", pCreditItemDetails.SGST)
                db.AddParameter("p_SGST_RATE", pCreditItemDetails.SGSTRate)
                db.AddParameter("p_BILL_QNTY", pCreditItemDetails.BillQnty)
                db.AddParameter("p_EX_RATE", pCreditItemDetails.ExRate)
                db.AddParameter("p_CURRENCY", pCreditItemDetails.Currency)
                db.AddParameter("p_Info", pCreditItemDetails.Info, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pCreditItemDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CREDIT_ITEM_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCreditItemDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCreditItemDetails.CrRefId = db.Parameters.Item("p_CR_REF_ID").value
                End If

            Catch ex As Exception
                pCreditItemDetails.Errormsg = ex.Message
            End Try
            Return pCreditItemDetails
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
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCR As CreditItemDetails) As CreditItemDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pCR.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_REF_ID").ToString <> "" Then
                                pCR.CrRefId = dbr("CR_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ID").ToString <> "" Then
                                pCR.CrId = dbr("CR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pCR.ServiceID = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RF_AMOUNT").ToString <> "" Then
                                pCR.ServiceAmt = dbr("RF_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                pCR.Invoiceno = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INV_ITEM_KEY_ID").ToString <> "" Then
                                pCR.InvItemKeyId = dbr("INV_ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                pCR.CrAmt = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_TAX").ToString <> "" Then
                                pCR.CrTax = dbr("CR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_TAX").ToString <> "" Then
                                pCR.CrTax = dbr("CR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ON").ToString <> "" Then
                                pCR.CrOn = dbr("CR_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST").ToString <> "" Then
                                pCR.IGST = dbr("IGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                pCR.IGSTRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST").ToString <> "" Then
                                pCR.CGST = dbr("CGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                pCR.CGSTRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST").ToString <> "" Then
                                pCR.SGST = dbr("SGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                pCR.SGSTRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_QNTY").ToString <> "" Then
                                pCR.BillQnty = dbr("BILL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ON").ToString <> "" Then
                                pCR.CrOn = dbr("CR_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pCR.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                pCR.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try

                    End While
                End If
            Catch ex As Exception
                pCR.Errormsg = ex.Message
            End Try
            Return pCR
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
                        Dim temp As New CreditItemDetails
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_REF_ID").ToString <> "" Then
                                temp.CrRefId = dbr("CR_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ID").ToString <> "" Then
                                temp.CrId = dbr("CR_ID")
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
                            If dbr("RF_AMOUNT").ToString <> "" Then
                                temp.ServiceAmt = dbr("RF_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                temp.Invoiceno = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INV_ITEM_KEY_ID").ToString <> "" Then
                                temp.InvItemKeyId = dbr("INV_ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                temp.CrAmt = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_TAX").ToString <> "" Then
                                temp.CrTax = dbr("CR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                temp.CrAmt = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST").ToString <> "" Then
                                temp.IGST = dbr("IGST")
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
                            If dbr("CGST").ToString <> "" Then
                                temp.CGST = dbr("CGST")
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
                            If dbr("SGST").ToString <> "" Then
                                temp.SGST = dbr("SGST")
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
                            If dbr("BILL_QNTY").ToString <> "" Then
                                temp.BillQnty = dbr("BILL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ON").ToString <> "" Then
                                temp.CrOn = dbr("CR_ON")
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
                            If dbr("CURRENCY").ToString <> "" Then
                                temp.Currency = dbr("CURRENCY")
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

        ' ''' <summary>
        ' ''' Preparing Return Object By TerminalId, InvoiceNo
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        ' '''
        'Public Shared Function ReturnCreaditNotebyid(ByVal pCr As CreaditNote) As CreaditNote
        '    Dim db As New DBConnect
        '    Dim dbr As OleDb.OleDbDataReader
        '    Try
        '        db.ClearParameters()
        '        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.CrId)
        '        pCr = ReturnObjectValues(dbr, pCr)
        '        dbr.Close()
        '    Catch ex As Exception
        '        pCr.Errormsg = ex.Message
        '    End Try
        '    db.CloseDB()
        '    Return pCr
        'End Function
        Public Shared Function ReturnCreaditItemListbyid(ByVal pCr As CreditItemDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CR_ITEM_ID", pCr.CrId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function

        ' ''' <summary>
        ' ''' Preparing Return Object By TerminalId, InvoiceRefNo
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        ' '''
        'Public Shared Function ReturnImpInvoiceByInvoiceRefNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Dim db As New DBConnect
        '    Dim dbr As OleDb.OleDbDataReader
        '    Try
        '        db.ClearParameters()
        '        dbr = db.StoredProcedureReadDB("USP_SELECT_IMP_INVOICE_BY_REF_NO", pImpInvoice.TerminalId & ",'" & pImpInvoice.InvoiceRefNo & "'")
        '        pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
        '        dbr.Close()
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    db.CloseDB()
        '    Return pImpInvoice
        'End Function

        ' ''' <summary>
        ' ''' Preparing Return Object ArrayList By TerminalId, LineItemId
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        ' '''
        'Public Shared Function ReturnImpInvoiceListByLineItemId(ByVal pImpInvoice As ImpInvoice) As ArrayList
        '    Dim db As New DBConnect
        '    Dim dbr As OleDb.OleDbDataReader
        '    Dim arrImpInvoice As New ArrayList
        '    Try
        '        db.ClearParameters()
        '        dbr = db.StoredProcedureReadDB("USP_SELECT_IMP_INVOICE_ALL_LINEITEMID", pImpInvoice.TerminalId & "," & pImpInvoice.LineItemId)
        '        arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
        '        dbr.Close()
        '    Catch ex As Exception
        '        arrImpInvoice = Nothing
        '    End Try
        '    db.CloseDB()
        '    Return arrImpInvoice
        'End Function
        ' ''' <summary>
        ' ''' Insert Member Function to Insert the New Record With Transaction
        ' ''' </summary>
        ' ''' <param name="db"></param>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function InsertTrnTemp(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Try
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.Output)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate, ParameterDirection.Output)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.Output)
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
        '        db.ExecuteScalar("USP_INSERT_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
        '        pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
        '        pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString

        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    Return pImpInvoice
        'End Function
        'Public Shared Function InsertCRDetails(ByVal pCreditNote As CreaditNote) As CreaditNote
        '    Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
        '    Try
        '        db.BeginTransaction()
        '        For Each CR As CreaditNote In pCreditNote.CRNoteList
        '            CreaditNote.InsertTrn(db, CR)
        '            Dim pFinanceDetails As New FinanceDetails
        '        Next


        '        db.CommitTransaction()
        '    Catch ex As Exception
        '        pCreditNote.Errormsg = ex.Message
        '        Try
        '            db.RollbackTransaction()
        '        Catch ex1 As Exception

        '        End Try
        '        ' Rollback the transaction if any 
        '    End Try
        '    Return pCreditNote
        'End Function



        Public Shared Function ReturnCreditServiceTallyListByCRId(ByVal pCr As CreditItemDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CR_TALLY_SERVICE_DETAILS", pCr.CrId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function
    End Class

End Namespace
