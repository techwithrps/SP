Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: InvoiceReceipt Class
    ''' @author	: Amit K. Singh- 13/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class ExtInvoiceReceipt
        Inherits InvoiceReceipt

        Dim arrFinanceDetails As New ArrayList
        Dim arrPaymentDetails As New ArrayList

        Public Property FinanceDetailsList() As ArrayList
            Get
                Return arrFinanceDetails
            End Get
            Set(ByVal value As ArrayList)
                arrFinanceDetails = value
            End Set
        End Property

        Public Property PaymentDetailsList() As ArrayList
            Get
                Return arrPaymentDetails
            End Get
            Set(ByVal value As ArrayList)
                arrPaymentDetails = value
            End Set
        End Property


        Public Shared Function InsertTransaction(ByVal pExtInvoiceReceipt As ExtInvoiceReceipt) As ExtInvoiceReceipt
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()


                ExtInvoiceReceipt.InsertTrn(db, pExtInvoiceReceipt)


                If pExtInvoiceReceipt.Errormsg = "" AndAlso pExtInvoiceReceipt.ReceiptNo > 0 Then
                    For Each pd As PaymentDetails In pExtInvoiceReceipt.PaymentDetailsList
                        pd.ReceiptNo = pExtInvoiceReceipt.ReceiptNo

                        PaymentDetails.InsertTrn(db, pd)

                        If pd.Errormsg <> "" Then
                            Throw New Exception(pd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtInvoiceReceipt.Errormsg)
                End If

                If pExtInvoiceReceipt.Errormsg = "" AndAlso pExtInvoiceReceipt.ReceiptNo > 0 Then
                    For Each fd As FinanceDetails In pExtInvoiceReceipt.FinanceDetailsList
                        If fd.ReceiptNo <= 0 Then
                            fd.ReceiptNo = pExtInvoiceReceipt.ReceiptNo
                            FinanceDetails.InsertTrn(db, fd)
                        Else
                            FinanceDetails.UpdateTrn(db, fd)
                        End If


                        If fd.Errormsg <> "" Then
                            Throw New Exception(fd.Errormsg)
                        End If

                    Next
                Else
                    Throw New Exception(pExtInvoiceReceipt.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtInvoiceReceipt.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtInvoiceReceipt
        End Function





        Public Shared Function PurchasePaymentInsertTransaction(ByVal pExtInvoiceReceipt As ExtInvoiceReceipt) As ExtInvoiceReceipt
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtInvoiceReceipt.ReceiptNo <= 0 Then
                    ExtInvoiceReceipt.PurchaseInsertTrn(db, pExtInvoiceReceipt)
                End If

                If pExtInvoiceReceipt.Errormsg = "" AndAlso pExtInvoiceReceipt.ReceiptNo > 0 Then
                    For Each pd As PaymentDetails In pExtInvoiceReceipt.PaymentDetailsList
                        pd.ReceiptNo = pExtInvoiceReceipt.ReceiptNo

                        PaymentDetails.PurchaseInsertTrn(db, pd)

                        If pd.Errormsg <> "" Then
                            Throw New Exception(pd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtInvoiceReceipt.Errormsg)
                End If

                If pExtInvoiceReceipt.Errormsg = "" AndAlso pExtInvoiceReceipt.ReceiptNo > 0 Then
                    For Each fd As FinanceDetails In pExtInvoiceReceipt.FinanceDetailsList
                        If fd.ReceiptNo <= 0 Then
                            fd.ReceiptNo = pExtInvoiceReceipt.ReceiptNo
                            FinanceDetails.PurchaseInsertTrn(db, fd)
                        Else
                            FinanceDetails.PurchaseUpdateTrn(db, fd)
                        End If


                        If fd.Errormsg <> "" Then
                            Throw New Exception(fd.Errormsg)
                        End If

                    Next
                Else
                    Throw New Exception(pExtInvoiceReceipt.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtInvoiceReceipt.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtInvoiceReceipt
        End Function

        Public Shared Function ReturnPaymentDetailsByReceiptNo(ByVal pExtInvoiceReceipt As ExtInvoiceReceipt) As ExtInvoiceReceipt
            ExtInvoiceReceipt.ReturnInvoiceReceiptByNo(pExtInvoiceReceipt)

            Dim pFinance As New FinanceDetails
            pFinance.ReceiptNo = pExtInvoiceReceipt.ReceiptNo
            pFinance.TerminalId = pExtInvoiceReceipt.TerminalId
            pExtInvoiceReceipt.FinanceDetailsList = FinanceDetails.ReturnFinanceDetailsListByReceiptNo(pFinance)

            Dim pPayment As New PaymentDetails
            pPayment.ReceiptNo = pExtInvoiceReceipt.ReceiptNo
            pPayment.TerminalId = pExtInvoiceReceipt.TerminalId
            pExtInvoiceReceipt.PaymentDetailsList = PaymentDetails.ReturnPaymentDetailsListByReceiptNo(pPayment)

            Return pExtInvoiceReceipt
        End Function

        Public Shared Function ReturnPaymentDetailsByInvoiceNo(ByVal pExtInvoiceReceipt As ExtInvoiceReceipt, ByVal pPaymentMode As String) As ExtInvoiceReceipt
            ExtInvoiceReceipt.ReturnInvoiceReceiptByNo(pExtInvoiceReceipt)

            Dim pFinance As New FinanceDetails
            pFinance.TerminalId = pExtInvoiceReceipt.TerminalId
            pFinance.CustomerId = pExtInvoiceReceipt.CustomerId
            pFinance.CustomerType = pExtInvoiceReceipt.CustomerType

            pExtInvoiceReceipt.FinanceDetailsList = FinanceDetails.ReturnFinanceDetailsListByReceiptNo(pFinance)

            Dim pPayment As New PaymentDetails
            pPayment.TerminalId = pExtInvoiceReceipt.TerminalId
            pPayment.ReceiptNo = pExtInvoiceReceipt.ReceiptNo
            pExtInvoiceReceipt.PaymentDetailsList = PaymentDetails.ReturnPaymentDetailsListByReceiptNo(pPayment)

            Return pExtInvoiceReceipt
        End Function


    End Class
End Namespace
