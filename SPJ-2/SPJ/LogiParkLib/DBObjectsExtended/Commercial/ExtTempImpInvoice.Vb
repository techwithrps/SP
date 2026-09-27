Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ExtTempImpInvoice
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtTempImpInvoice
        Inherits TempImpInvoice

        Dim arrTempImpInvoiceItems As New ArrayList

        Public Property TempImpInvoiceItemsList() As ArrayList
            Get
                Return arrTempImpInvoiceItems
            End Get
            Set(ByVal value As ArrayList)
                arrTempImpInvoiceItems = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing Return Object TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTempImpInvoiceWithItemsDetails(ByVal pTempImpInvoice As ExtTempImpInvoice) As ExtTempImpInvoice
            ExtTempImpInvoice.ReturnTempImpInvoiceByInvoiceNo(pTempImpInvoice)

            Dim pTempImpInvoiceItems As New TempImpInvoiceItems
            pTempImpInvoiceItems.TerminalId = pTempImpInvoice.TerminalId
            pTempImpInvoiceItems.InvoiceNo = pTempImpInvoice.InvoiceNo
            pTempImpInvoice.TempImpInvoiceItemsList = TempImpInvoiceItems.ReturnTempImpInvoiceItemsListBuInvoiceNo(pTempImpInvoiceItems)

            Return pTempImpInvoice
        End Function

        Public Shared Function GenerateInvoice(ByVal pTempImpInvoice As ExtTempImpInvoice) As ExtTempImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pTempImpInvoice.ImpContId)
                db.AddParameter("p_RATE_TYPE", pTempImpInvoice.RateType)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("GENERATE_PKG.SP_INV_GENERATE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTempImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value

                If pTempImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function
        Public Shared Function GenerateInvoiceReExport(ByVal pTempImpInvoice As ExtTempImpInvoice) As ExtTempImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pTempImpInvoice.ImpContId)
                db.AddParameter("p_RATE_TYPE", pTempImpInvoice.RateType)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("GENERATE_PKG.SP_INV_GEN_REP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTempImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value

                If pTempImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function

        Public Shared Function GenerateInvoiceAdvance(ByVal pTempImpInvoice As ExtTempImpInvoice) As ExtTempImpInvoice
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoice.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoice.LineItemId)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoice.InvoiceNo, ParameterDirection.Output)
                db.AddParameter("p_INVOICE_DATE", pTempImpInvoice.InvoiceDate)
                db.AddParameter("p_INVOICE_REF_NO", pTempImpInvoice.InvoiceRefNo)
                db.AddParameter("p_SERVICE_TYPE", pTempImpInvoice.ServiceType)
                db.AddParameter("p_CUSTOMER_TYPE", pTempImpInvoice.CustomerType)
                db.AddParameter("p_BILL_TO", pTempImpInvoice.BillTo)
                db.AddParameter("p_PAYMENT_MODE", pTempImpInvoice.PaymentMode)
                db.AddParameter("p_PRINT_STATUS", pTempImpInvoice.PrintStatus)
                db.AddParameter("p_RECEIPT_NO", pTempImpInvoice.ReceiptNo)
                db.AddParameter("p_INVOICE_NOTE", pTempImpInvoice.InvoiceNote)
                db.AddParameter("p_CANCLE_FLAGE", pTempImpInvoice.CancleFlage)
                db.AddParameter("p_CREATED_BY", pTempImpInvoice.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempImpInvoice.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pTempImpInvoice.ImpContId)
                db.AddParameter("p_RATE_TYPE", pTempImpInvoice.RateType)
                db.AddParameter("p_ErrorMsg", pTempImpInvoice.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("GENERATE_PKG.SP_ADV_INV_GEN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTempImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value

                If pTempImpInvoice.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoice.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoice
        End Function



    End Class
End Namespace
