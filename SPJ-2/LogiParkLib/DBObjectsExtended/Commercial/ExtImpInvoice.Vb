Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ImpInvoice
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtImpInvoice
        Inherits ImpInvoice

        Dim arrImpInvoiceItems As ArrayList
        Dim arrImpInvoice As ArrayList

        Dim arrImpInvoiceTaxItems As ArrayList

        Public Property ImpInvoiceItemsList() As ArrayList
            Get
                Return arrImpInvoiceItems
            End Get
            Set(ByVal value As ArrayList)
                arrImpInvoiceItems = value
            End Set
        End Property
        Public Property ImpInvoiceList() As ArrayList
            Get
                Return arrImpInvoice
            End Get
            Set(ByVal value As ArrayList)
                arrImpInvoice = value
            End Set
        End Property
        Public Property ImpInvoiceTaxItemsList() As ArrayList
            Get
                Return arrImpInvoiceTaxItems
            End Get
            Set(ByVal value As ArrayList)
                arrImpInvoiceTaxItems = value
            End Set
        End Property

        Public Shared Function InsertInvoiceWithDetails(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each II As ImpInvoice In pExtImpInvoice.ImpInvoiceList
                    II.InvoiceNo = pExtImpInvoice.InvoiceNo
                    II.InvoiceDate = pExtImpInvoice.InvoiceDate
                    II.InvoiceRefNo = pExtImpInvoice.InvoiceRefNo
                    ExtImpInvoice.InsertTrn(db, II)
                    Dim pFinanceDetails As New FinanceDetails
                    If II.Errormsg = "" AndAlso II.InvoiceNo > 0 Then
                        For Each iii As ImpInvoiceItems In pExtImpInvoice.ImpInvoiceItemsList
                            If iii.LineItemId = II.LineItemId Then
                                iii.InvoiceNo = pExtImpInvoice.InvoiceNo
                                iii.VisitId = pExtImpInvoice.VisitId
                                ImpInvoiceItems.InsertTrn(db, iii)
                                pFinanceDetails.DrAmount += iii.BillAmount
                                If II.Errormsg <> "" Then
                                    Throw New Exception(II.Errormsg)
                                End If
                            End If

                        Next


                        pFinanceDetails.TerminalId = pExtImpInvoice.TerminalId
                        pFinanceDetails.CustomerId = pExtImpInvoice.BillTo
                        pFinanceDetails.Remarks = pExtImpInvoice.InvoiceRefNo
                        pFinanceDetails.TrnType = pExtImpInvoice.PaymentMode
                        pFinanceDetails.InvoiceNo = pExtImpInvoice.InvoiceNo
                        FinanceDetails.Insert(pFinanceDetails)
                        If pFinanceDetails.Errormsg <> "" Then
                            Throw New Exception(pFinanceDetails.Errormsg)
                        End If
                    Else
                        Throw New Exception(pExtImpInvoice.Errormsg)
                    End If
                    pExtImpInvoice.InvoiceNo = II.InvoiceNo
                    pExtImpInvoice.InvoiceDate = II.InvoiceDate
                    pExtImpInvoice.InvoiceRefNo = II.InvoiceRefNo

                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtImpInvoice.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try

            Return pExtImpInvoice
        End Function

        Public Shared Function ReturnInvoiceWithItemDetails(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            ExtImpInvoice.ReturnImpInvoiceByInvoiceNo(pExtImpInvoice)

            Dim pItem As New ImpInvoiceItems
            pItem.TerminalId = pExtImpInvoice.TerminalId
            pItem.InvoiceNo = pExtImpInvoice.InvoiceNo
            pExtImpInvoice.ImpInvoiceItemsList = ImpInvoiceItems.ReturnImpInvoiceItemsListByInvoiceNo(pItem)

            Return pExtImpInvoice
        End Function
        Public Shared Function InsertInvoiceWithDtlsTemp(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                ExtImpInvoice.InsertTrnTemp(db, pExtImpInvoice)
                Dim pFinanceDetails As New FinanceDetails
                If pExtImpInvoice.Errormsg = "" AndAlso pExtImpInvoice.InvoiceNo > 0 Then
                    For Each ii As ImpInvoiceItems In pExtImpInvoice.ImpInvoiceItemsList
                        ii.InvoiceNo = pExtImpInvoice.InvoiceNo
                        ImpInvoiceItems.InsertTrnTemp(db, ii)
                        pFinanceDetails.DrAmount += ii.BillAmount
                        If ii.Errormsg <> "" Then
                            Throw New Exception(ii.Errormsg)
                        End If
                    Next
                    For Each iit As ImpInvoiceTax In pExtImpInvoice.ImpInvoiceTaxItemsList
                        iit.InvoiceNo = pExtImpInvoice.InvoiceNo
                        ImpInvoiceTax.InsertTrnTemp(db, iit)
                        If iit.Errormsg <> "" Then
                            Throw New Exception(iit.Errormsg)
                        End If
                    Next

                    pFinanceDetails.TerminalId = pExtImpInvoice.TerminalId
                    pFinanceDetails.CustomerId = pExtImpInvoice.BillTo
                    pFinanceDetails.Remarks = pExtImpInvoice.InvoiceRefNo
                    pFinanceDetails.TrnType = pExtImpInvoice.PaymentMode
                    pFinanceDetails.InvoiceNo = pExtImpInvoice.InvoiceNo
                    FinanceDetails.Insert(pFinanceDetails)
                    If pFinanceDetails.Errormsg <> "" Then
                        Throw New Exception(pFinanceDetails.Errormsg)
                    End If
                Else
                    Throw New Exception(pExtImpInvoice.Errormsg)
                End If

                db.CommitTransaction()
            Catch ex As Exception
                pExtImpInvoice.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtImpInvoice
        End Function
        Public Shared Function InsertInvoiceWithDetailsWithRebate(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            Dim tr As New TransactionStatus
            tr.RunningStatus = 1
            TransactionStatus.Update(tr)
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                'Dim p As New ExtImpInvoice
                'ExtImpInvoice.ReturnSequenceMasterAsInvoiceId(p)
                'pExtImpInvoice.CostRequestId = p.SequenceId

                Dim hdninvno As Long = 0
                Dim strerrormsg As String = ""
                Dim strinvoicerefno As String = ""
                Dim strBookingNo As String = ""
                'Dim strBookingDate As String = ""

                For Each II As ImpInvoice In pExtImpInvoice.ImpInvoiceList
                    II.InvoiceNo = pExtImpInvoice.InvoiceNo
                    II.InvoiceRefNo = pExtImpInvoice.InvoiceRefNo
                    II.BookingNo = pExtImpInvoice.BookingNo
                    'II.BookingDate = pExtImpInvoice.BookingDate
                    ExtImpInvoice.InsertRebate(db, II)
                    hdninvno = II.InvoiceNo
                    strerrormsg = II.Errormsg
                    pExtImpInvoice.InvoiceNo = II.InvoiceNo
                    pExtImpInvoice.InvoiceRefNo = II.InvoiceRefNo
                    pExtImpInvoice.BookingNo = II.BookingNo
                    'pExtImpInvoice.BookingDate = II.BookingDate
                    strinvoicerefno = II.InvoiceRefNo
                    strBookingNo = II.BookingNo
                    'strBookingDate = II.BookingDate

                Next
                pExtImpInvoice.InvoiceNo = hdninvno
                pExtImpInvoice.InvoiceRefNo = strinvoicerefno
                pExtImpInvoice.BookingNo = strBookingNo
                Dim pFinanceDetails As New FinanceDetails
                If strerrormsg = "" AndAlso hdninvno > 0 Then
                    For Each iii As ImpInvoiceItems In pExtImpInvoice.ImpInvoiceItemsList
                        iii.InvoiceNo = hdninvno
                        iii.VisitId = pExtImpInvoice.VisitId
                        ImpInvoiceItems.InsertTrnRebate(db, iii)
                        pFinanceDetails.DrAmount += iii.BillAmount
                        If iii.Errormsg <> "" Then
                            Throw New Exception(iii.Errormsg)
                        End If
                    Next
                    'For Each iit As ImpInvoiceTax In pExtImpInvoice.ImpInvoiceTaxItemsList
                    '    If iit.LineItemId = II.LineItemId Then
                    '        iit.InvoiceNo = II.InvoiceNo
                    '        ImpInvoiceTax.InsertTrn(db, iit)
                    '        If iit.Errormsg <> "" Then
                    '            Throw New Exception(iit.Errormsg)
                    '        End If
                    '    End If

                    'Next

                    pFinanceDetails.TerminalId = pExtImpInvoice.TerminalId
                    pFinanceDetails.CustomerId = pExtImpInvoice.BillTo
                    pFinanceDetails.Remarks = strinvoicerefno
                    pFinanceDetails.TrnType = pExtImpInvoice.PaymentMode
                    pFinanceDetails.InvoiceNo = hdninvno
                    FinanceDetails.Insert(pFinanceDetails)
                    If pFinanceDetails.Errormsg <> "" Then
                        Throw New Exception(pFinanceDetails.Errormsg)
                    End If
                Else
                    Throw New Exception(pExtImpInvoice.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtImpInvoice.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try

            tr.RunningStatus = 0
            TransactionStatus.Update(tr)
            Return pExtImpInvoice
        End Function

        Public Shared Function InsertInvoiceWithDetailsTemp(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            Dim tr As New TransactionStatus
            tr.RunningStatus = 1
            TransactionStatus.Update(tr)
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                'Dim p As New ExtImpInvoice
                'ExtImpInvoice.ReturnSequenceMasterAsInvoiceId(p)
                'pExtImpInvoice.CostRequestId = p.SequenceId

                Dim hdninvno As Long = 0
                Dim strerrormsg As String = ""
                Dim strinvoicerefno As String = ""
                For Each II As ImpInvoice In pExtImpInvoice.ImpInvoiceList
                    II.InvoiceNo = pExtImpInvoice.InvoiceNo
                    II.InvoiceRefNo = pExtImpInvoice.InvoiceRefNo
                    ExtImpInvoice.InsertTrn(db, II)
                    hdninvno = II.InvoiceNo
                    strerrormsg = II.Errormsg
                    pExtImpInvoice.InvoiceNo = II.InvoiceNo
                    pExtImpInvoice.InvoiceRefNo = II.InvoiceRefNo
                    strinvoicerefno = II.InvoiceRefNo
                Next
                pExtImpInvoice.InvoiceNo = hdninvno
                pExtImpInvoice.InvoiceRefNo = strinvoicerefno
                Dim pFinanceDetails As New FinanceDetails
                If strerrormsg = "" AndAlso hdninvno > 0 Then
                    For Each iii As ImpInvoiceItems In pExtImpInvoice.ImpInvoiceItemsList
                        iii.InvoiceNo = hdninvno
                        iii.VisitId = pExtImpInvoice.VisitId
                        ImpInvoiceItems.InsertTrn(db, iii)
                        pFinanceDetails.DrAmount += iii.BillAmount
                        If iii.Errormsg <> "" Then
                            Throw New Exception(iii.Errormsg)
                        End If
                    Next
                    'For Each iit As ImpInvoiceTax In pExtImpInvoice.ImpInvoiceTaxItemsList
                    '    If iit.LineItemId = II.LineItemId Then
                    '        iit.InvoiceNo = II.InvoiceNo
                    '        ImpInvoiceTax.InsertTrn(db, iit)
                    '        If iit.Errormsg <> "" Then
                    '            Throw New Exception(iit.Errormsg)
                    '        End If
                    '    End If

                    'Next

                    pFinanceDetails.TerminalId = pExtImpInvoice.TerminalId
                    pFinanceDetails.CustomerId = pExtImpInvoice.BillTo
                    pFinanceDetails.Remarks = strinvoicerefno
                    pFinanceDetails.TrnType = pExtImpInvoice.PaymentMode
                    pFinanceDetails.InvoiceNo = hdninvno
                    FinanceDetails.Insert(pFinanceDetails)
                    If pFinanceDetails.Errormsg <> "" Then
                        Throw New Exception(pFinanceDetails.Errormsg)
                    End If
                Else
                    Throw New Exception(pExtImpInvoice.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtImpInvoice.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try

            tr.RunningStatus = 0
            TransactionStatus.Update(tr)
            Return pExtImpInvoice
        End Function

        Public Shared Function UpdateInvoiceWithDetails(ByVal pExtImpInvoice As ExtImpInvoice) As ExtImpInvoice
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()


                For Each II As ImpInvoice In pExtImpInvoice.ImpInvoiceList

                    ExtImpInvoice.UpdateTrn(db, II)
                    Dim pFinanceDetails As New FinanceDetails
                    If II.Errormsg = "" AndAlso II.InvoiceNo > 0 Then
                        For Each iii As ImpInvoiceItems In pExtImpInvoice.ImpInvoiceItemsList
                            ImpInvoiceItems.UpdateTrn(db, iii)
                            pFinanceDetails.DrAmount += iii.BillAmount
                            If II.Errormsg <> "" Then
                                Throw New Exception(II.Errormsg)
                            End If


                        Next
                        For Each iit As ImpInvoiceTax In pExtImpInvoice.ImpInvoiceTaxItemsList
                            ImpInvoiceTax.UpdateTrn(db, iit)
                            If iit.Errormsg <> "" Then
                                Throw New Exception(iit.Errormsg)
                            End If


                        Next

                        pFinanceDetails.CustomerId = II.BillTo
                        pFinanceDetails.InvoiceNo = II.InvoiceNo
                        FinanceDetails.UpdateDrAmount(pFinanceDetails)
                        If pFinanceDetails.Errormsg <> "" Then
                            Throw New Exception(pFinanceDetails.Errormsg)
                        End If
                    Else
                        Throw New Exception(pExtImpInvoice.Errormsg)
                    End If

                Next


                db.CommitTransaction()
            Catch ex As Exception
                pExtImpInvoice.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtImpInvoice
        End Function


    End Class
End Namespace
