Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class DrItemDetails
        Private lngDrRefId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngDrId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCost As Long
        Private lngServiceId As Long
        Private dblBillQnty As Double
        Private dblExRate As Double
        Private dblBillRate As Double
        Private dblBillAmt As Double
        Private dblDrAmt As Double
        Private dblDrTax As Double
        Private strDrOn As String
        Private dblIgst As Double
        Private dblIgstRate As Double
        Private dblSgst As Double
        Private dblSgstRate As Double
        Private dblCgst As Double
        Private dblCgstRate As Double
        Private arrDRNoteDetails As ArrayList
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        Public Property DRNoteDetailsList() As ArrayList
            Get
                Return arrDRNoteDetails
            End Get
            Set(ByVal value As ArrayList)
                arrDRNoteDetails = value
            End Set
        End Property
        Public Property DrRefId() As Long
            Get
                Return lngDrRefId
            End Get
            Set(ByVal value As Long)
                lngDrRefId = value
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
        Public Property CostId() As Long
            Get
                Return lngCost
            End Get
            Set(ByVal value As Long)
                lngCost = value
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
                Return dblBillQnty
            End Get
            Set(ByVal value As Double)
                dblBillQnty = value
            End Set
        End Property
        Public Property ExRate() As Double
            Get
                Return dblExRate
            End Get
            Set(ByVal value As Double)
                dblExRate = value
            End Set
        End Property
        Public Property BillRate() As Double
            Get
                Return dblBillRate
            End Get
            Set(ByVal value As Double)
                dblBillRate = value
            End Set
        End Property
        Public Property BillAmt() As Double
            Get
                Return dblBillAmt
            End Get
            Set(ByVal value As Double)
                dblBillAmt = value
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
        Public Property DrTax() As Double
            Get
                Return dblDrTax
            End Get
            Set(ByVal value As Double)
                dblDrTax = value
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
        Public Property IGST() As Double
            Get
                Return dblIgst
            End Get
            Set(ByVal value As Double)
                dblIgst = value
            End Set
        End Property
        Public Property IGSTRate() As Double
            Get
                Return dblIgstRate
            End Get
            Set(ByVal value As Double)
                dblIgstRate = value
            End Set
        End Property
        Public Property CGST() As Double
            Get
                Return dblCgst
            End Get
            Set(ByVal value As Double)
                dblCgst = value
            End Set
        End Property
        Public Property CGSTRate() As Double
            Get
                Return dblCgstRate
            End Get
            Set(ByVal value As Double)
                dblCgstRate = value
            End Set
        End Property
        Public Property SGST() As Double
            Get
                Return dblSgst
            End Get
            Set(ByVal value As Double)
                dblSgst = value
            End Set
        End Property
        Public Property SGSTRate() As Double
            Get
                Return dblSgstRate
            End Get
            Set(ByVal value As Double)
                dblSgstRate = value
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
            lngDrRefId = 0
            lngDrId = 0
            lngCost = 0
            lngServiceId = 0
            dblBillQnty = 0
            dblBillRate = 0
            dblExRate = 0
            dblBillAmt = 0
            dblDrAmt = 0.0
            dblDrTax = 0.0
            strDrOn = ""
            dblIgst = 0.0
            dblIgstRate = 0
            dblSgst = 0.0
            dblSgstRate = 0
            dblCgst = 0.0
            dblCgstRate = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCreditItemDetails"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCreditItemDetails As DrItemDetails) As DrItemDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CR_REF_ID", pCreditItemDetails.DrRefId, ParameterDirection.Output)
                db.AddParameter("p_CR_ID", pCreditItemDetails.DrId)
                db.AddParameter("p_INVOICE_NO", pCreditItemDetails.CostId)
                db.AddParameter("p_SERVICE_ID", pCreditItemDetails.ServiceID)
                db.AddParameter("p_BILL_QNTY", pCreditItemDetails.BillQnty)
                db.AddParameter("p_BILL_RATE", pCreditItemDetails.BillRate)
                db.AddParameter("p_EX_RATE", pCreditItemDetails.ExRate)
                db.AddParameter("p_BILL_AMT", pCreditItemDetails.BillAmt)
                db.AddParameter("p_DR_AMT", pCreditItemDetails.DrAmt)
                db.AddParameter("p_DR_TAX", pCreditItemDetails.DrTax)
                db.AddParameter("p_DR_ON", pCreditItemDetails.DrOn)
                db.AddParameter("p_IGST", pCreditItemDetails.IGST)
                db.AddParameter("p_IGST_RATE", pCreditItemDetails.IGSTRate)
                db.AddParameter("p_CGST", pCreditItemDetails.CGST)
                db.AddParameter("p_CGST_RATE", pCreditItemDetails.CGSTRate)
                db.AddParameter("p_SGST", pCreditItemDetails.SGST)
                db.AddParameter("p_SGST_RATE", pCreditItemDetails.SGSTRate)
                db.AddParameter("p_ErrorMsg", pCreditItemDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DR_ITEM_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCreditItemDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCreditItemDetails.DrRefId = db.Parameters.Item("p_CR_REF_ID").value
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
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCreditItemDetails As DrItemDetails) As DrItemDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_CR_REF_ID", pCreditItemDetails.DrRefId, ParameterDirection.Output)
                db.AddParameter("p_CR_ID", pCreditItemDetails.DrId)
                db.AddParameter("p_INVOICE_NO", pCreditItemDetails.CostId)
                db.AddParameter("p_SERVICE_ID", pCreditItemDetails.ServiceID)
                db.AddParameter("p_BILL_QNTY", pCreditItemDetails.BillQnty)
                db.AddParameter("p_BILL_RATE", pCreditItemDetails.BillRate)
                db.AddParameter("p_EX_RATE", pCreditItemDetails.ExRate)
                db.AddParameter("p_BILL_AMT", pCreditItemDetails.BillAmt)
                db.AddParameter("p_DR_AMT", pCreditItemDetails.DrAmt)
                db.AddParameter("p_DR_TAX", pCreditItemDetails.DrTax)
                db.AddParameter("p_DR_ON", pCreditItemDetails.DrOn)
                db.AddParameter("p_IGST", pCreditItemDetails.IGST)
                db.AddParameter("p_IGST_RATE", pCreditItemDetails.IGSTRate)
                db.AddParameter("p_CGST", pCreditItemDetails.CGST)
                db.AddParameter("p_CGST_RATE", pCreditItemDetails.CGSTRate)
                db.AddParameter("p_SGST", pCreditItemDetails.SGST)
                db.AddParameter("p_SGST_RATE", pCreditItemDetails.SGSTRate)
                db.AddParameter("p_ErrorMsg", pCreditItemDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DR_ITEM_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCreditItemDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCreditItemDetails.DrRefId = db.Parameters.Item("p_CR_REF_ID").value
                End If

            Catch ex As Exception
                pCreditItemDetails.Errormsg = ex.Message
            End Try
            Return pCreditItemDetails
        End Function

        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCR As DrItemDetails) As DrItemDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("DR_REF_ID").ToString <> "" Then
                                pCR.DrRefId = dbr("DR_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_ID").ToString <> "" Then
                                pCR.DrId = dbr("DR_ID")
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
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pCR.ServiceID = dbr("SERVICE_ID")
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
                            If dbr("BILL_RATE").ToString <> "" Then
                                pCR.BillRate = dbr("BILL_RATE")
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
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                pCR.BillAmt = dbr("BILL_AMOUNT")
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
                            If dbr("DR_ON").ToString <> "" Then
                                pCR.DrOn = dbr("DR_ON")
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
                        Dim temp As New DrItemDetails
                        Try
                            If dbr("DR_REF_ID").ToString <> "" Then
                                temp.DrRefId = dbr("DR_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DR_ID").ToString <> "" Then
                                temp.DrId = dbr("DR_ID")
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
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceID = dbr("SERVICE_ID")
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
                            If dbr("BILL_RATE").ToString <> "" Then
                                temp.BillRate = dbr("BILL_RATE")
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
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                temp.BillAmt = dbr("BILL_AMOUNT")
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
                            If dbr("DR_ON").ToString <> "" Then
                                temp.DrOn = dbr("DR_ON")
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
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        Public Shared Function ReturnCreaditItemListbyid(ByVal pCr As DrItemDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_DR_ITEM_ID", pCr.DrId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function
        Public Shared Function ReturnCostBookingDtlsByCostId(ByVal pCr As DrItemDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoice As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_DTLS_BY_IDD", pCr.CostID)
                arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return arrImpInvoice
        End Function



        Public Shared Function ReturnDebitServiceTallyListByDRId(ByVal pCr As DrItemDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DR_TALLY_SERVICE_DETAILS", pCr.DrId)
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
