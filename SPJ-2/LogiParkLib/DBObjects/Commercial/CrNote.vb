Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class CrNote
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCrId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngInvoiceNo As Long
        Private lngCompanyId As Long
        Private StrCrDate As String
        Private StrCrRefNO As String
        Private lngInvoiceAmt As Double
        Private lngCrAmt As Double
        Private lngCrTax As Double
        Private strCrBy As String
        Private strCrOn As String
        Private strCrNotes As String
        Private arrCRNote As ArrayList
        Private strServiceType As String ' Define Private Variable ServiceType With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        ''' 
        Public Property CRNoteList() As ArrayList
            Get
                Return arrCRNote
            End Get
            Set(ByVal value As ArrayList)
                arrCRNote = value
            End Set
        End Property
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
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
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property
        Public Property InvoiceID() As Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
            End Set
        End Property
        Public Property CrDate() As String
            Get
                Return StrCrDate
            End Get
            Set(ByVal value As String)
                StrCrDate = value
            End Set
        End Property
        Public Property CrRefNo() As String
            Get
                Return StrCrRefNO
            End Get
            Set(ByVal value As String)
                StrCrRefNO = value
            End Set
        End Property
        Public Property InvoiceAmt() As Double
            Get
                Return lngInvoiceAmt
            End Get
            Set(ByVal value As Double)
                lngInvoiceAmt = value
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
        Public Property CrBy() As String
            Get
                Return strCrBy
            End Get
            Set(ByVal value As String)
                strCrBy = value
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
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property

        Public Property CrNotes() As String
            Get
                Return strCrNotes
            End Get
            Set(ByVal value As String)
                strCrNotes = value
            End Set
        End Property
        Public Sub New()
            lngTerminalId = 0
            lngCrId = 0
            lngInvoiceNo = 0
            StrCrRefNO = ""
            StrCrDate = ""
            strCrBy = ""
            strCrOn = ""
            lngCrAmt = 0.0
            lngCrTax = 0.0
            strCrOn = ""
            lngInvoiceAmt = 0
            lngCompanyId = 0
            strServiceType = ""
            strErrormsg = ""
            strCrNotes = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCr"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCr As CrNote) As CrNote
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCr.TerminalId)
                db.AddParameter("p_CR_ID", pCr.CrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.CrDate)
                db.AddParameter("p_CR_REF_NO", pCr.CrRefNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_ID", pCr.InvoiceID)
                db.AddParameter("p_INVOICE_AMT", pCr.lngInvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.CrAmt)
                db.AddParameter("p_CR_TAX", pCr.CrTax)
                db.AddParameter("p_CR_BY", pCr.CrBy)
                db.AddParameter("p_CR_ON", pCr.CrOn)
                db.AddParameter("p_COMPANY_ID", pCr.CompanyId)
                db.AddParameter("p_CR_NOTE", pCr.CrNotes)
                db.AddParameter("p_SERVICE_TYPE", pCr.ServiceType)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCr.CrId = db.Parameters.Item("p_CR_ID").value
                    pCr.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
                End If

                If pCr.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCr.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCr As CrNote) As CrNote
            Try
                'db.ClearParameters()
                'db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCr.TerminalId)
                db.AddParameter("p_CR_ID", pCr.CrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.CrDate)
                db.AddParameter("p_CR_REF_NO", pCr.CrRefNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_ID", pCr.InvoiceID)
                db.AddParameter("p_INVOICE_AMT", pCr.InvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.CrAmt)
                db.AddParameter("p_CR_TAX", pCr.CrTax)
                db.AddParameter("p_CR_BY", pCr.CrBy)
                db.AddParameter("p_CR_ON", pCr.CrOn)
                db.AddParameter("p_COMPANY_ID", pCr.CompanyId)
                db.AddParameter("p_CR_NOTE", pCr.CrNotes)
                db.AddParameter("p_SERVICE_TYPE", pCr.ServiceType)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCr.CrId = db.Parameters.Item("p_CR_ID").value
                    pCr.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
                End If

            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            Return pCr
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
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCR As CrNote) As CrNote
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
                            If dbr("CR_ID").ToString <> "" Then
                                pCR.CrId = dbr("CR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_REF_NO").ToString <> "" Then
                                pCR.CrRefNo = dbr("CR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DATE").ToString <> "" Then
                                pCR.CrDate = dbr("CR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                pCR.InvoiceID = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RF_AMOUNT").ToString <> "" Then
                                pCR.lngInvoiceAmt = dbr("RF_AMOUNT")
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
                            If dbr("CR_BY").ToString <> "" Then
                                pCR.CrBy = dbr("CR_BY")
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
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pCR.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_NOTE").ToString <> "" Then
                                pCR.CrNotes = dbr("CR_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                pCR.ServiceType = dbr("SERVICE_TYPE")
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
                        Dim temp As New CrNote
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("CR_REF_NO").ToString <> "" Then
                                temp.CrRefNo = dbr("CR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DATE").ToString <> "" Then
                                temp.CrDate = dbr("CR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                temp.InvoiceID = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RF_AMOUNT").ToString <> "" Then
                                temp.InvoiceAmt = dbr("RF_AMOUNT")
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
                            If dbr("CR_BY").ToString <> "" Then
                                temp.CrBy = dbr("CR_BY")
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
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_NOTE").ToString <> "" Then
                                temp.CrNotes = dbr("CR_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE").ToString <> "" Then
                                temp.ServiceType = dbr("SERVICE_TYPE")
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
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCreaditNotebyid(ByVal pCr As CrNote) As CrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.CrId)
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function

        Public Shared Function ReturnCreaditNotebyInvoiceId(ByVal pCr As CrNote) As CrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CREDIT_NOTE_INVOICE_ID", pCr.InvoiceID)
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
        Public Shared Function ReturnCreaditNotebyCrRefNo(ByVal pCr As CrNote) As CrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CR_BY_REF_NO", "'" & pCr.CrRefNo & "'")
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function ReturnCreaditNoteListbyid(ByVal pCr As CrNote) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.CrId)
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
        Public Shared Function InsertCRDetails(ByVal pCreditNote As CrNote) As CrNote
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                CrNote.InsertTrn(db, pCreditNote)
                Dim pFinanceDetails As New FinanceDetails
                If pCreditNote.Errormsg = "" AndAlso pCreditNote.CrId > 0 Then
                    For Each CR As CreditItemDetails In pCreditNote.CRNoteList

                        CR.CrId = pCreditNote.CrId
                        CreditItemDetails.InsertTrn(db, CR)
                        If Not String.IsNullOrEmpty(CR.Errormsg) Then
                            db.RollbackTransaction()
                            pCreditNote.Errormsg = CR.Errormsg
                            Return pCreditNote
                        End If
                    Next
                    Dim pImpInvoice As New ImpInvoice
                    pImpInvoice.TerminalId = 1
                    pImpInvoice.InvoiceNo = pCreditNote.InvoiceID
                    ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
                    pFinanceDetails.TerminalId = 4
                    pFinanceDetails.CustomerId = pImpInvoice.BillTo
                    pFinanceDetails.Remarks = pCreditNote.CrRefNo
                    pFinanceDetails.TrnType = "R"
                    pFinanceDetails.CrAmount = pCreditNote.InvoiceAmt
                    pFinanceDetails.InvoiceNo = pCreditNote.InvoiceID
                    FinanceDetails.Insert(pFinanceDetails)
                    If pFinanceDetails.Errormsg <> "" Then
                        Throw New Exception(pFinanceDetails.Errormsg)
                    End If
                Else
                    Throw New Exception(pCreditNote.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pCreditNote.Errormsg = ex.Message

                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCreditNote
        End Function
    End Class
End Namespace

