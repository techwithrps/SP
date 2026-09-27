Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyContInJo
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtMtyContInJo
        Inherits MtyContInJo

        Dim arrMtyContInJoDetails As New ArrayList


        Public Property MtyContInJoDetailsList() As ArrayList
            Get
                Return arrMtyContInJoDetails
            End Get
            Set(ByVal value As ArrayList)
                arrMtyContInJoDetails = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()

        End Sub

        Public Shared Function InsertUpdateTransaction(ByVal pMtyContInJo As ExtMtyContInJo) As ExtMtyContInJo
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pMtyContInJo.MtyContInJoId > 0 Then
                    ExtMtyContInJo.UpdateTrn(db, pMtyContInJo)
                Else
                    ExtMtyContInJo.InsertTrn(db, pMtyContInJo)
                End If

                If pMtyContInJo.Errormsg = "" AndAlso pMtyContInJo.MtyContInJoId > 0 Then
                    For Each det As MtyContInJoDetail In pMtyContInJo.MtyContInJoDetailsList
                        det.MtyContInJoId = pMtyContInJo.MtyContInJoId
                        If det.MtyContGateInId > 0 Then
                            MtyContInJoDetail.UpdateTrn(db, det)
                        Else
                            MtyContInJoDetail.InsertTrn(db, det)
                        End If
                        If det.Errormsg <> "" Then
                            Throw New Exception(det.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pMtyContInJo.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pMtyContInJo
        End Function

        Public Shared Function ReturnExtMtyContInJoDetailsById(ByVal pExtMtyContInJo As ExtMtyContInJo) As ExtMtyContInJo
            ExtMtyContInJo.ReturnMtyContInJoListByJoNo(pExtMtyContInJo)

            Dim pMtyContInJoDetail As New MtyContInJoDetail
            pMtyContInJoDetail.MtyContInJoId = pExtMtyContInJo.MtyContInJoId
            pMtyContInJoDetail.TerminalId = pExtMtyContInJo.TerminalId

            pExtMtyContInJo.MtyContInJoDetailsList = MtyContInJoDetail.ReturnMtyContInJoDetailListByContJoId(pMtyContInJoDetail)

            Return pExtMtyContInJo
        End Function

    End Class
End Namespace
