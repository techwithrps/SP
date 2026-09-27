Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: Quatation
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtQuatation
        Inherits Quatation
        Dim arrQuatationDetails As New ArrayList
        Public Property QuatationDetailsList() As ArrayList
            Get
                Return arrQuatationDetails
            End Get
            Set(ByVal value As ArrayList)
                arrQuatationDetails = value
            End Set
        End Property


        Public Shared Function InsertUpdateQuatationWithDetailsTrn(ByVal pExtQuatation As ExtQuatation) As ExtQuatation
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtQuatation.RateId > 0 Then
                    ExtQuatation.UpdateTrn(db, pExtQuatation)
                Else
                    ExtQuatation.InsertTrn(db, pExtQuatation)
                End If
                If pExtQuatation.Errormsg = "" AndAlso pExtQuatation.RateId > 0 Then
                    For Each rd As QuatationDtls In pExtQuatation.QuatationDetailsList
                        rd.RateId = pExtQuatation.RateId
                        If rd.RateKeyId > 0 Then
                            QuatationDtls.UpdateTrn(db, rd)
                        Else
                            QuatationDtls.InsertTrn(db, rd)
                        End If
                        If rd.Errormsg <> "" Then
                            Throw New Exception(rd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtQuatation.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtQuatation.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtQuatation
        End Function

        Public Shared Function ReturnQuatationWithDetailsTrn(ByVal pExtQuatation As ExtQuatation) As ExtQuatation
            ExtQuatation.ReturnQUATATIONByRateId(pExtQuatation)

            Dim pReateDetails As New QuatationDtls
            pReateDetails.RateId = pExtQuatation.RateId
            pReateDetails.TerminalId = pExtQuatation.TerminalId

            pExtQuatation.QuatationDetailsList = QuatationDtls.ReturnQuatationDtlsListByRateId(pReateDetails)

            Return pExtQuatation
        End Function
    End Class
End Namespace
