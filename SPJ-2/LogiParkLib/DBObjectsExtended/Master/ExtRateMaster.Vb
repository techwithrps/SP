Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: RateMaster
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtRateMaster
        Inherits RateMaster
        Dim arrRateDetails As New ArrayList

        Public Property RateDetailsList() As ArrayList
            Get
                Return arrRateDetails
            End Get
            Set(ByVal value As ArrayList)
                arrRateDetails = value
            End Set
        End Property


        Public Shared Function InsertUpdateRateMasterWithDetailsTrn(ByVal pExtRateMaster As ExtRateMaster) As ExtRateMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtRateMaster.RateId > 0 Then
                    ExtRateMaster.UpdateTrn(db, pExtRateMaster)
                Else
                    ExtRateMaster.InsertTrn(db, pExtRateMaster)
                End If
                If pExtRateMaster.Errormsg = "" AndAlso pExtRateMaster.RateId > 0 Then
                    For Each rd As RateDetails In pExtRateMaster.RateDetailsList
                        rd.RateId = pExtRateMaster.RateId
                        If rd.RateKeyId > 0 Then
                            RateDetails.UpdateTrn(db, rd)
                        Else
                            RateDetails.InsertTrn(db, rd)
                        End If
                        If rd.Errormsg <> "" Then
                            Throw New Exception(rd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtRateMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtRateMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtRateMaster
        End Function

        Public Shared Function ReturnRateMasterWithDetailsTrn(ByVal pExtRateMaster As ExtRateMaster) As ExtRateMaster
            ExtRateMaster.ReturnRateMasterByRateId(pExtRateMaster)

            Dim pReateDetails As New RateDetails
            pReateDetails.RateId = pExtRateMaster.RateId
            pReateDetails.TerminalId = pExtRateMaster.TerminalId

            pExtRateMaster.RateDetailsList = RateDetails.ReturnRateDetailsListByRateId(pReateDetails)

            Return pExtRateMaster
        End Function
    End Class
End Namespace
