Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    Public Class ExtRateTptCustomer
        Inherits RateTptCustomer
        Dim arrRateTptCustomerDetails As ArrayList

        Public Property RateTptDetails() As ArrayList
            Get
                Return arrRateTptCustomerDetails
            End Get
            Set(ByVal value As ArrayList)
                arrRateTptCustomerDetails = value
            End Set
        End Property
        Public Shared Function ApproveTransaction(ByVal pExtRateTptCustomer As ExtRateTptCustomer) As ExtRateTptCustomer
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each erd As ExtRateTptCustomerDetails In pExtRateTptCustomer.RateTptDetails
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
                pExtRateTptCustomer.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtRateTptCustomer
        End Function
        Public Shared Function ReturnRateTptCustomerDetails(ByVal pExtRateTptCustomer As ExtRateTptCustomer) As ExtRateTptCustomer
            ExtRateTptCustomer.ReturnRateTptCustomerById(pExtRateTptCustomer)

            Dim pExtRateTptCustomerDetails As New ExtRateTptCustomerDetails
            pExtRateTptCustomerDetails.RateTptId = pExtRateTptCustomer.RateTptId
            pExtRateTptCustomerDetails.TerminalId = pExtRateTptCustomer.TerminalId
            pExtRateTptCustomer.RateTptDetails = ExtRateTptCustomerDetails.ReturnRateTptCustomerDetailsList(pExtRateTptCustomerDetails)

            Return pExtRateTptCustomer
        End Function

        Public Shared Function InsertUpdateTransaction(ByVal pExtRateTptCustomer As ExtRateTptCustomer) As ExtRateTptCustomer
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtRateTptCustomer.RateTptId > 0 Then
                    ExtRateTptCustomer.UpdateTrn(db, pExtRateTptCustomer)
                Else
                    ExtRateTptCustomer.InsertTrn(db, pExtRateTptCustomer)
                End If
                For Each tscd As RateTptCustomerDetails In pExtRateTptCustomer.RateTptDetails
                    tscd.RateTptId = pExtRateTptCustomer.RateTptId
                    If tscd.RateTptRefId > 0 Then
                        RateTptCustomerDetails.UpdateTrn(db, tscd)
                    Else
                        RateTptCustomerDetails.InsertTrn(db, tscd)
                    End If
                    If tscd.Errormsg <> "" Then
                        Throw New Exception(tscd.Errormsg)
                    End If
                Next

                db.CommitTransaction()
            Catch ex As Exception
                pExtRateTptCustomer.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtRateTptCustomer
        End Function
        Public Shared Function ReturnRateTptCustomerWithDetailsById(ByVal pExtRateTptCustomer As ExtRateTptCustomer) As ExtRateTptCustomer
            ExtRateTptCustomer.ReturnRateTptCustomerById(pExtRateTptCustomer)

            Dim pExtRateTptCustomerDetails As New ExtRateTptCustomerDetails
            pExtRateTptCustomerDetails.RateTptId = pExtRateTptCustomer.RateTptId
            pExtRateTptCustomerDetails.TerminalId = pExtRateTptCustomer.TerminalId

            pExtRateTptCustomer.RateTptDetails = ExtRateTptCustomerDetails.ReturnRateTptVendorDetailsListByRateId(pExtRateTptCustomerDetails)

            Return pExtRateTptCustomer
        End Function
    End Class
End Namespace
