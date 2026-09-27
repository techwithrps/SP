
Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class ExtCostRatemaster
        Inherits CostRateMaster
        Dim arrCostRateDetails As New ArrayList
        Public Property CostRateDetailsList() As ArrayList
            Get
                Return arrCostRateDetails
            End Get
            Set(ByVal value As ArrayList)
                arrCostRateDetails = value
            End Set
        End Property
        Public Shared Function InsertUpdateCostRateMasterWithDetailsTrn(ByVal pExtCostRatemaster As ExtCostRatemaster) As ExtCostRatemaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtCostRatemaster.RateId > 0 Then
                    ExtCostRatemaster.UpdateTrn(db, pExtCostRatemaster)
                Else
                    ExtCostRatemaster.InsertTrn(db, pExtCostRatemaster)
                End If
                If pExtCostRatemaster.Errormsg = "" AndAlso pExtCostRatemaster.RateId > 0 Then
                    For Each rd As CostRateDetails In pExtCostRatemaster.CostRateDetailsList
                        rd.RateId = pExtCostRatemaster.RateId
                        If rd.RateKeyId > 0 Then
                            CostRateDetails.UpdateTrn(db, rd)
                        Else
                            CostRateDetails.InsertTrn(db, rd)
                        End If
                        If rd.Errormsg <> "" Then
                            Throw New Exception(rd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtCostRatemaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtCostRatemaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtCostRatemaster
        End Function

        Public Shared Function ReturnCostRateMasterWithDetailsTrn(ByVal pExtCostRatemaster As ExtCostRatemaster) As ExtCostRatemaster
            ExtCostRatemaster.ReturnRateMasterByRateId(pExtCostRatemaster)
            Dim pCostRateDetails As New CostRateDetails
            pCostRateDetails.RateId = pExtCostRatemaster.RateId
            pCostRateDetails.TerminalId = pExtCostRatemaster.TerminalId

            pExtCostRatemaster.CostRateDetailsList = CostRateDetails.ReturnCostRateDetailsListByRateId(pCostRateDetails)

            Return pExtCostRatemaster
        End Function
    End Class
End Namespace

