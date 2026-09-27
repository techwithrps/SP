Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class ExtCostBooking
        Inherits TempCostBooking
        Dim arrTempImpInvoiceItems As New ArrayList
        Dim ArrCostBooking As New ArrayList
        Dim ArrCostBookingDtls As New ArrayList
        Public Property ListCostBooking() As ArrayList
            Get
                Return ArrCostBooking
            End Get
            Set(ByVal value As ArrayList)
                ArrCostBooking = value
            End Set
        End Property
        Public Property ListCostBookingDtls() As ArrayList
            Get
                Return ArrCostBookingDtls
            End Get
            Set(ByVal value As ArrayList)
                ArrCostBookingDtls = value
            End Set
        End Property
        Public Property TempImpInvoiceItemsList() As ArrayList
            Get
                Return arrTempImpInvoiceItems
            End Get
            Set(ByVal value As ArrayList)
                arrTempImpInvoiceItems = value
            End Set
        End Property
        Public Shared Function ReturnTempCostBookingWithItemsDetails(ByVal pExtCostBooking As ExtCostBooking) As ExtCostBooking
            ExtCostBooking.ReturnTempImpInvoiceByInvoiceNo(pExtCostBooking)
            Dim pTempImpInvoiceItems As New TempCostBookingDtls
            pTempImpInvoiceItems.CostId = pExtCostBooking.CostId
            pExtCostBooking.TempImpInvoiceItemsList = TempCostBookingDtls.ReturnTempcostDtlsListBuInvoiceNo(pTempImpInvoiceItems)

            Return pExtCostBooking
        End Function

        Public Shared Function GenerateCostInvoice(ByVal pExtCostBooking As ExtCostBooking) As ExtCostBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pExtCostBooking.CostId, ParameterDirection.Output)
                db.AddParameter("p_BILL_TO", pExtCostBooking.BillingParty)
                db.AddParameter("p_CONT_NO", pExtCostBooking.BlNo)
                db.AddParameter("p_CREATED_BY", pExtCostBooking.CreatedBy)
                db.AddParameter("p_COMPANY_ID", pExtCostBooking.CompanyId)
                db.AddParameter("p_EX_RATE", pExtCostBooking.ExRate)
                db.AddParameter("p_TDS_PER", pExtCostBooking.TdsPer)
                db.AddParameter("p_ErrorMsg", pExtCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("GENERATE_PKG.SP_COST_GENERATE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pExtCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pExtCostBooking.CostId = db.Parameters.Item("p_COST_ID").value
                End If
                If pExtCostBooking.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pExtCostBooking.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pExtCostBooking
        End Function
        
    End Class
End Namespace

