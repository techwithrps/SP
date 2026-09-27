Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    Public Class DrNote
        Private lngDrId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCostId As Long
        Private lngCompanyId As Long
        Private StrDrDate As String
        Private StrDrRefNO As String
        Private dblInvoiceAmt As Double
        Private dblDrAmt As Double
        Private dblDrTax As Double
        Private strDrBy As String
        Private strDrOn As String
        Private strDrNotes As String
        Private strTallyStatus As String
        Private strTallyCreatedOn As String
        Private dblBalAmt As Double
        Private strBalUpBy As String
        Private strBalUpDate As String
        Private arrDRNote As ArrayList
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        ''' 
        Public Property DRNoteList() As ArrayList
            Get
                Return arrDRNote
            End Get
            Set(ByVal value As ArrayList)
                arrDRNote = value
            End Set
        End Property
        Public Property DrId() As Long
            Get
                Return lngDrId
            End Get
            Set(ByVal value As Long)
                lngDrId = value
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
        Public Property CostId() As Long
            Get
                Return lngCostId
            End Get
            Set(ByVal value As Long)
                lngCostId = value
            End Set
        End Property
        Public Property DrDate() As String
            Get
                Return StrDrDate
            End Get
            Set(ByVal value As String)
                StrDrDate = value
            End Set
        End Property
        Public Property DrRefNo() As String
            Get
                Return StrDrRefNO
            End Get
            Set(ByVal value As String)
                StrDrRefNO = value
            End Set
        End Property
        Public Property InvoiceAmt() As Double
            Get
                Return dblInvoiceAmt
            End Get
            Set(ByVal value As Double)
                dblInvoiceAmt = value
            End Set
        End Property
        Public Property DrAmt() As Double
            Get
                Return dblDrAmt
            End Get
            Set(ByVal value As Double)
                dblDrAmt = value
            End Set
        End Property

        Public Property BalAmt() As Double
            Get
                Return dblBalAmt
            End Get
            Set(ByVal value As Double)
                dblBalAmt = value
            End Set
        End Property

        Public Property DrTax() As Double
            Get
                Return dblDrTax
            End Get
            Set(ByVal value As Double)
                dblDrTax = value
            End Set
        End Property
        Public Property DrBy() As String
            Get
                Return strDrBy
            End Get
            Set(ByVal value As String)
                strDrBy = value
            End Set
        End Property

        Public Property BalUpBy() As String
            Get
                Return strBalUpBy
            End Get
            Set(ByVal value As String)
                strBalUpBy = value
            End Set
        End Property

        Public Property BalUpDate() As String
            Get
                Return strBalUpDate
            End Get
            Set(ByVal value As String)
                strBalUpDate = value
            End Set
        End Property

        Public Property TallyStatus() As String
            Get
                Return strTallyStatus
            End Get
            Set(ByVal value As String)
                strTallyStatus = value
            End Set
        End Property

        Public Property TallyCreatedOn() As String
            Get
                Return strTallyCreatedOn
            End Get
            Set(ByVal value As String)
                strTallyCreatedOn = value
            End Set
        End Property
        Public Property DrOn() As String
            Get
                Return strDrOn
            End Get
            Set(ByVal value As String)
                strDrOn = value
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

        Public Property DrNotes() As String
            Get
                Return strDrNotes
            End Get
            Set(ByVal value As String)
                strDrNotes = value
            End Set
        End Property
        Public Sub New()
            lngDrId = 0
            lngCostId = 0
            StrDrRefNO = ""
            StrDrDate = ""
            strDrBy = ""
            strDrOn = ""
            dblDrAmt = 0.0
            dblDrTax = 0.0
            strDrOn = ""
            dblInvoiceAmt = 0
            lngCompanyId = 0
            strErrormsg = ""
            strDrNotes = ""
            strTallyStatus = ""
            strTallyCreatedOn = ""
            BalAmt = 0
            BalUpBy = ""
            BalUpDate = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCr"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCr As DrNote) As DrNote
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CR_ID", pCr.DrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.DrDate)
                db.AddParameter("p_CR_REF_NO", pCr.DrRefNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_ID", pCr.CostId)
                db.AddParameter("p_INVOICE_AMT", pCr.InvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.DrAmt)
                db.AddParameter("p_CR_TAX", pCr.DrTax)
                db.AddParameter("p_CR_BY", pCr.DrBy)
                db.AddParameter("p_CR_ON", pCr.DrOn)
                db.AddParameter("p_COMPANY_ID", pCr.CompanyId)
                db.AddParameter("p_CR_NOTE", pCr.DrNotes)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCr.DrId = db.Parameters.Item("p_CR_ID").value
                    pCr.DrRefNo = db.Parameters.Item("p_CR_REF_NO").value
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
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCr As DrNote) As DrNote
            Try
                'db.ClearParameters()
                'db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CR_ID", pCr.DrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.DrDate)
                db.AddParameter("p_CR_REF_NO", pCr.DrRefNo)
                db.AddParameter("p_INVOICE_ID", pCr.CostId)
                db.AddParameter("p_INVOICE_AMT", pCr.InvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.DrAmt)
                db.AddParameter("p_CR_TAX", pCr.DrTax)
                db.AddParameter("p_CR_BY", pCr.DrBy)
                db.AddParameter("p_CR_ON", pCr.DrOn)
                db.AddParameter("p_COMPANY_ID", pCr.CompanyId)
                db.AddParameter("p_CR_NOTE", pCr.DrNotes)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCr.DrId = db.Parameters.Item("p_CR_ID").value
                    ' pCr.DrRefNo = db.Parameters.Item("p_CR_REF_NO").value
                End If

            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            Return pCr
        End Function


        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCR As DrNote) As DrNote
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("DR_ID").ToString <> "" Then
                                pCR.DrId = dbr("DR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_REF_NO").ToString <> "" Then
                                pCR.DrRefNo = dbr("DR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_DATE").ToString <> "" Then
                                pCR.DrDate = dbr("DR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                pCR.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                pCR.InvoiceAmt = dbr("BILL_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_AMOUNT").ToString <> "" Then
                                pCR.DrAmt = dbr("DR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_TAX").ToString <> "" Then
                                pCR.DrTax = dbr("DR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_BY").ToString <> "" Then
                                pCR.DrBy = dbr("DR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_ON").ToString <> "" Then
                                pCR.DrOn = dbr("DR_ON")
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
                            If dbr("DR_NOTE").ToString <> "" Then
                                pCR.DrNotes = dbr("DR_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_STATUS").ToString <> "" Then
                                pCR.TallyStatus = dbr("TALLY_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_CREATED_ON").ToString <> "" Then
                                pCR.TallyCreatedOn = dbr("TALLY_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_AMT").ToString <> "" Then
                                pCR.BalAmt = dbr("BAL_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_UP_BY").ToString <> "" Then
                                pCR.BalUpBy = dbr("BAL_UP_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_UP_DATE").ToString <> "" Then
                                pCR.BalUpDate = dbr("BAL_UP_DATE")
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
                        Dim temp As DrNote
                        Try
                            If dbr("DR_ID").ToString <> "" Then
                                temp.DrId = dbr("DR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_REF_NO").ToString <> "" Then
                                temp.DrRefNo = dbr("DR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_DATE").ToString <> "" Then
                                temp.DrDate = dbr("DR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                temp.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                temp.InvoiceAmt = dbr("BILL_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_AMOUNT").ToString <> "" Then
                                temp.DrAmt = dbr("DR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_TAX").ToString <> "" Then
                                temp.DrTax = dbr("DR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_BY").ToString <> "" Then
                                temp.DrBy = dbr("DR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_ON").ToString <> "" Then
                                temp.DrOn = dbr("DR_ON")
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
                            If dbr("DR_NOTE").ToString <> "" Then
                                temp.DrNotes = dbr("DR_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("TALLY_STATUS").ToString <> "" Then
                                temp.TallyStatus = dbr("TALLY_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_CREATED_ON").ToString <> "" Then
                                temp.TallyCreatedOn = dbr("TALLY_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_AMT").ToString <> "" Then
                                temp.BalAmt = dbr("BAL_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_UP_BY").ToString <> "" Then
                                temp.BalUpBy = dbr("BAL_UP_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BAL_UP_DATE").ToString <> "" Then
                                temp.BalUpDate = dbr("BAL_UP_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
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
        Public Shared Function ReturnCreaditNotebyid(ByVal pCr As DrNote) As DrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_DR_NOTE_ID", pCr.DrId)
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
        Public Shared Function ReturnCreaditNotebyCrRefNo(ByVal pCr As DrNote) As DrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DR_BY_REF_NO", "'" & pCr.DrRefNo & "'")
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function ReturnCreaditNoteListbyid(ByVal pCr As DrNote) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.DrId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function
        Public Shared Function ReturnCreaditNoteListbyCostid(ByVal pCr As DrNote) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_CID", pCr.CostId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function
        Public Shared Function InsertDRDetails(ByVal pCreditNote As DrNote) As DrNote
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                DrNote.InsertTrn(db, pCreditNote)
                If pCreditNote.Errormsg = "" AndAlso pCreditNote.DrId > 0 Then
                    For Each CR As DrItemDetails In pCreditNote.DRNoteList
                        CR.DrId = pCreditNote.DrId
                        DrItemDetails.InsertTrn(db, CR)
                    Next

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

        Public Shared Function ReturnCreaditNotebyCostid(ByVal pCr As DrNote) As DrNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            '  Dim arrCreditNoteItems As New ArrayList

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_CID", pCr.CostId)
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
           
        End Function
    End Class
End Namespace

