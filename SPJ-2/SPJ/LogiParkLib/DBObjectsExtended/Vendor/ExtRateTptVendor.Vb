Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RateTptVendor Class
    ''' @author	: Amit K. Singh- 17/02/2012
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class ExtRateTptVendor
        Inherits RateTptVendor
        Dim arrRateTptVendorDetails As ArrayList

        Public Property RateTptDetails() As ArrayList
            Get
                Return arrRateTptVendorDetails
            End Get
            Set(ByVal value As ArrayList)
                arrRateTptVendorDetails = value
            End Set
        End Property

        Public Shared Function ApproveTransaction(ByVal pExtRateTptVendor As ExtRateTptVendor) As ExtRateTptVendor
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each erd As ExtRateTptVendorDetails In pExtRateTptVendor.RateTptDetails
                    'erd.RateTptId = pExtRateTptVendor.RateTptId
                    'erd.ApprovalFlag = pExtRateTptVendor.ApprovalFlage
                    'If erd.RateTptRefId > 0 Then
                    '    ExtRateTptVendorDetails.ApprovalTrn(db, erd)
                    'End If
                    If erd.Errormsg <> "" Then
                        Throw New Exception(erd.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtRateTptVendor.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtRateTptVendor
        End Function

        Public Shared Function InsertUpdateTransaction(ByVal pExtRateTptVendor As ExtRateTptVendor) As ExtRateTptVendor
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtRateTptVendor.RateTptId > 0 Then
                    ExtRateTptVendor.UpdateTrn(db, pExtRateTptVendor)
                Else
                    ExtRateTptVendor.InsertTrn(db, pExtRateTptVendor)
                End If
                For Each tscd As RateTptVendorDetails In pExtRateTptVendor.RateTptDetails
                    tscd.RateTptId = pExtRateTptVendor.RateTptId
                    If tscd.RateTptRefId > 0 Then
                        ExtRateTptVendorDetails.UpdateTrn(db, tscd)
                    Else
                        ExtRateTptVendorDetails.InsertTrn(db, tscd)
                    End If
                    If tscd.Errormsg <> "" Then
                        Throw New Exception(tscd.Errormsg)
                    End If
                Next

                db.CommitTransaction()
            Catch ex As Exception
                pExtRateTptVendor.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtRateTptVendor
        End Function

        Public Shared Function ReturnRateTptVendorWithDetailsById(ByVal pExtRateTptVendor As ExtRateTptVendor) As ExtRateTptVendor
            ExtRateTptVendor.ReturnRateTptVendorById(pExtRateTptVendor)

            Dim pExtRateTptVendorDetails As New ExtRateTptVendorDetails
            pExtRateTptVendorDetails.RateTptId = pExtRateTptVendor.RateTptId
            pExtRateTptVendorDetails.TerminalId = pExtRateTptVendor.TerminalId

            pExtRateTptVendor.RateTptDetails = ExtRateTptVendorDetails.ReturnRateTptVendorDetailsListByRateId(pExtRateTptVendorDetails)

            Return pExtRateTptVendor
        End Function

        Public Shared Function ReturnRateTptVendorDetails(ByVal pExtRateTptVendor As ExtRateTptVendor) As ExtRateTptVendor
            ExtRateTptVendor.ReturnRateTptVendorById(pExtRateTptVendor)

            Dim pExtRateTptVendorDetails As New ExtRateTptVendorDetails
            pExtRateTptVendorDetails.RateTptId = pExtRateTptVendor.RateTptId
            pExtRateTptVendorDetails.TerminalId = pExtRateTptVendor.TerminalId
            pExtRateTptVendor.RateTptDetails = ExtRateTptVendorDetails.ReturnRateTptVendorDetailsList(pExtRateTptVendorDetails)

            Return pExtRateTptVendor
        End Function


        Public Shared Function UpdateRateMasterTransportationApproval(ByVal pRateTptVendor As ExtRateTptVendor) As ExtRateTptVendor
            Dim db As New DBConnect
            Try
                'db.BeginTransaction()
                'db.ClearParameters()
                'db.AddParameter("p_RATE_TPT_ID", pRateTptVendor.RateTptId)
                'db.AddParameter("p_RATE_CODE", pRateTptVendor.RateCode)
                'db.AddParameter("p_BILLING_CONDITION", pRateTptVendor.BillingCondition)
                'db.AddParameter("p_TERMINAL_ID", pRateTpt.TerminalId)
                'db.AddParameter("p_SERVICE_ID", pRateTpt.ServiceId)
                'db.AddParameter("p_CUSTOMER_TYPE", pRateTpt.CustomerType)
                'db.AddParameter("p_CUSTOMER_ID", pRateTpt.CustomerId)
                'db.AddParameter("P_EFFECTIVE_FROM", pRateTpt.EffectiveFrom)
                'db.AddParameter("p_EFFECTIVE_TO", pRateTpt.EffectiveTo)
                'db.AddParameter("p_APPROVAL_FLAGE", pRateTpt.ApprovalFlage)
                'db.AddParameter("p_CREATED_ON", pRateTpt.CreatedOn)
                'db.AddParameter("p_CREATED_BY", pRateTpt.CreatedBy)
                'db.AddParameter("p_ErrorMsg", pRateTpt.Errormsg, ParameterDirection.Output)
                'db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_APPROVAL", CommandType.StoredProcedure)
                'If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                '    pRateTpt.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                'End If
                'If pRateTpt.Errormsg <> Nothing Then
                '    db.RollbackTransaction()
                'Else
                '    db.CommitTransaction()
                'End If
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptVendor
        End Function
    End Class
End Namespace

