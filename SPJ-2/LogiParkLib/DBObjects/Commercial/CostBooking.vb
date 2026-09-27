Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class CostBooking

        Private lngCostId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strLinerInvoiceNo As String  ' Define Private Variable LineItemId With DataType As Long 
        Private strLinerInvoiceDate As String ' Define Private Variable InvoiceRefNo With DataType As String
        Private StrDueDate As String
        Private strBLNo As String  ' Define Private Variable ServiceType With DataType As String 
        Private lngBillingParty As Long
        Private lngCompanyId As Long
        Private StrCreatedBy As String
        Private StrPurchaseType As String
        Private StrCreatedOn As String
        Private StrRemarks As String
        Private lngKeyId As Long
        Dim arrCostBookingDtls As ArrayList
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Dim ArrCostBooking As New ArrayList
        Public Property ListCostBooking() As ArrayList
            Get
                Return ArrCostBooking
            End Get
            Set(ByVal value As ArrayList)
                ArrCostBooking = value
            End Set
        End Property
        Public Property CostBookingDtlsList() As ArrayList
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
        Public Property KeyId() As Long
            Get
                Return lngKeyId
            End Get
            Set(ByVal value As Long)
                lngKeyId = value
            End Set
        End Property
        Public Property LinerInvoiceNo() As String
            Get
                Return strLinerInvoiceNo
            End Get
            Set(ByVal value As String)
                strLinerInvoiceNo = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Return StrRemarks
            End Get
            Set(ByVal value As String)
                StrRemarks = value
            End Set
        End Property

        Public Property PurchaseType() As String
            Get
                Return StrPurchaseType
            End Get
            Set(ByVal value As String)
                StrPurchaseType = value
            End Set
        End Property
        Public Property LinerInvoiceDate() As String
            Get
                Return strLinerInvoiceDate
            End Get
            Set(ByVal value As String)
                strLinerInvoiceDate = value
            End Set
        End Property
        Public Property DueDate() As String
            Get
                Return StrDueDate
            End Get
            Set(ByVal value As String)
                StrDueDate = value
            End Set
        End Property
        Public Property BLNO() As String
            Get
                Return strBLNo
            End Get
            Set(ByVal value As String)
                strBLNo = value
            End Set
        End Property
        Public Property BillingParty() As Long
            Get
                Return lngBillingParty
            End Get
            Set(ByVal value As Long)
                lngBillingParty = value
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

        Public Property CreatedBy() As String
            Get
                Return StrCreatedBy
            End Get
            Set(ByVal value As String)
                StrCreatedBy = value
            End Set
        End Property
        Public Property CreatedOn() As String
            Get
                Return StrCreatedOn
            End Get
            Set(ByVal value As String)
                StrCreatedOn = value
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
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngCostId = 0
            strLinerInvoiceNo = ""
            strLinerInvoiceDate = ""
            StrDueDate = ""
            strBLNo = ""
            lngBillingParty = 0
            lngCompanyId = 0
            StrCreatedBy = ""
            StrCreatedOn = ""
            strErrormsg = ""
            StrPurchaseType = ""
            lngKeyId = 0
            StrRemarks = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCostBooking"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCostBooking As CostBooking) As CostBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID, ParameterDirection.Output)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostBooking.CostID = db.Parameters.Item("p_COST_ID").value
                If pCostBooking.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostBooking
        End Function
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID, ParameterDirection.Output)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostBooking.Errormsg = "" Then
                    pCostBooking.CostID = db.Parameters.Item("p_COST_ID").value
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
        End Function

        Public Shared Function InsertTrnNew(ByVal db As DBConnect, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID, ParameterDirection.Output)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pCostBooking.PurchaseType)
                db.AddParameter("p_REMARK", pCostBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING_NEW", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostBooking.Errormsg = "" Then
                    pCostBooking.CostID = db.Parameters.Item("p_COST_ID").value
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
        End Function
        Public Shared Function InsertTrnNew1(ByVal db As DBConnect, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID, ParameterDirection.Output)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pCostBooking.PurchaseType)
                db.AddParameter("p_REMARK", pCostBooking.Remarks)
                db.AddParameter("p_KEY_ID", pCostBooking.KeyId, CommandType.StoredProcedure)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING_NEW1", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostBooking.Errormsg = "" Then
                    pCostBooking.CostID = db.Parameters.Item("p_COST_ID").value
                    pCostBooking.KeyId = db.Parameters.Item("p_KEY_ID").value
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
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

        Public Shared Function UpdateTrnNew(ByVal db As DBConnect, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pCostBooking.PurchaseType)
                db.AddParameter("p_REMARK", pCostBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COST_BOOKING_NEW", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
        End Function
        Public Shared Function InsertGenTrn(ByVal db As DBConnect, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pCostBooking.CostID, ParameterDirection.Output)
                db.AddParameter("p_LINER_INVOICE_NO", pCostBooking.LinerInvoiceNo)
                db.AddParameter("p_LINER_INVOICE_DATE", pCostBooking.LinerInvoiceDate)
                db.AddParameter("p_DUE_dATE", pCostBooking.DueDate)
                db.AddParameter("p_BL_NO", pCostBooking.BLNO)
                db.AddParameter("p_BILLING_PARTY", pCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pCostBooking.PurchaseType)
                db.AddParameter("p_REMARK", pCostBooking.Remarks)
                db.AddParameter("p_KEY_ID", pCostBooking.KeyId)
                db.AddParameter("p_ErrorMsg", pCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_BOOKING_GEN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostBooking.Errormsg = "" Then
                    pCostBooking.CostID = db.Parameters.Item("p_COST_ID").value
                End If
                'pCostBooking.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
        End Function


        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCostBooking As CostBooking) As CostBooking
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                pCostBooking.CostID = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                pCostBooking.LinerInvoiceNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                pCostBooking.LinerInvoiceDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DUE_DATE").ToString <> "" Then
                                pCostBooking.DueDate = dbr("LINER_INV_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                pCostBooking.BLNO = dbr("BL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_PARTY").ToString <> "" Then
                                pCostBooking.BillingParty = dbr("BILLING_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pCostBooking.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCostBooking.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCostBooking.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_TYPE").ToString <> "" Then
                                pCostBooking.PurchaseType = dbr("PURCHASE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                pCostBooking.KeyId = dbr("KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
            End Try
            Return pCostBooking
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
                        Dim temp As New CostBooking
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                temp.CostID = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                temp.LinerInvoiceNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                temp.LinerInvoiceDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DUE_DATE").ToString <> "" Then
                                temp.DueDate = dbr("LINER_INV_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                temp.BLNO = dbr("BL_NO")
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
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
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
                            If dbr("PURCHASE_TYPE").ToString <> "" Then
                                temp.PurchaseType = dbr("PURCHASE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK").ToString <> "" Then
                                temp.Remarks = dbr("REMARK")
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
        Public Shared Function InsertCostBookingDtls(ByVal pCostBooking As CostBooking) As CostBooking
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                CostBooking.InsertTrn(db, pCostBooking)
                If pCostBooking.Errormsg = "" AndAlso pCostBooking.CostID > 0 Then
                    For Each CBD As CostBookingDtls In pCostBooking.CostBookingDtlsList
                        CBD.CostID = pCostBooking.CostID
                        CostBookingDtls.InsertTrn(db, CBD)

                        If CBD.Errormsg <> "" Then
                            Throw New Exception(CBD.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pCostBooking.Errormsg)
                End If

                db.CommitTransaction()
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCostBooking
        End Function

        Public Shared Function InsertNewCostBookingDtls(ByVal pCostBooking As CostBooking) As CostBooking
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                CostBooking.InsertTrnNew(db, pCostBooking)
                If pCostBooking.Errormsg = "" AndAlso pCostBooking.CostID > 0 Then
                    For Each CBD As CostBookingDtls In pCostBooking.CostBookingDtlsList
                        CBD.CostID = pCostBooking.CostID
                        CostBookingDtls.InsertTrnNew(db, CBD)

                        If CBD.Errormsg <> "" Then
                            Throw New Exception(CBD.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pCostBooking.Errormsg)
                End If

                db.CommitTransaction()
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCostBooking
        End Function




        Public Shared Function UpdateCostBookingDtls(ByVal pCostBooking As CostBooking) As CostBooking
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                CostBooking.UpdateTrnNew(db, pCostBooking)
                If pCostBooking.Errormsg = "" AndAlso pCostBooking.CostID > 0 Then
                    For Each CBD As CostBookingDtls In pCostBooking.CostBookingDtlsList
                        CBD.CostID = pCostBooking.CostID
                        If CBD.CostDtlsID > 0 Then
                            CostBookingDtls.UpdateTrnNew(db, CBD)
                        Else
                            CostBookingDtls.InsertTrnNew(db, CBD)
                        End If


                        If CBD.Errormsg <> "" Then
                            Throw New Exception(CBD.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pCostBooking.Errormsg)
                End If

                db.CommitTransaction()
            Catch ex As Exception
                pCostBooking.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCostBooking
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnPurchaseNaration(ByVal pCr As CostBooking) As CostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PUR_NARRATION_BL", pCr.CostID & " ,'" & pCr.BLNO & "'")
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnPurchaseByInvoice(ByVal pCr As CostBooking) As CostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PURCHASE_INVOICE", pCr.CompanyId & " ,'" & pCr.LinerInvoiceNo & "'")
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function DeletePurchaseEntryByCostId(ByVal pCr As CostBooking) As CostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_DELETE_BY_ID", pCr.CostID)
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        ''' <summary>
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnPurchaseDetailsByCostId(ByVal pCr As CostBooking) As CostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PURCHASE_BY_COSTID", pCr.CostID)
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function InsertCostWithDetailsTemp(ByVal pExtCostBooking As CostBooking) As CostBooking
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                Dim hdninvno As Long = 0
                Dim strerrormsg As String = ""
                Dim strinvoicerefno As String = ""
                For Each II As CostBooking In pExtCostBooking.ListCostBooking
                    'If II.KeyId > 0 Then
                    If pExtCostBooking.Errormsg = Nothing Then
                        CostBooking.InsertGenTrn(db, II)
                        If II.Errormsg <> Nothing Then
                            pExtCostBooking.Errormsg = II.Errormsg
                        End If
                    End If
                
                    ' Else
                    'CostBooking.InsertTrnNew1(db, pExtCostBooking)
                    'If pExtCostBooking.Errormsg = "" AndAlso pExtCostBooking.CostID > 0 Then
                    '    For Each CBD As CostBookingDtls In pExtCostBooking.CostBookingDtlsList
                    '        CBD.CostID = pExtCostBooking.CostID
                    '        CBD.MtyContId = pExtCostBooking.KeyId
                    '        CostBookingDtls.InsertTrnNew1(db, CBD)
                    '        If CBD.Errormsg <> "" Then
                    '            Throw New Exception(CBD.Errormsg)
                    '        End If
                    '    Next
                    'Else
                    'Throw New Exception(pExtCostBooking.Errormsg)
                    'End If
                    'End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtCostBooking.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtCostBooking
        End Function
    End Class
End Namespace

