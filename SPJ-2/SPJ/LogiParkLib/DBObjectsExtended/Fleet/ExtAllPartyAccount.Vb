Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ExportBooking
    ''' @author	: Amit K. Singh- 10/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtAllPartyAccount
        Inherits AllPartyAccount

        Private arrContDtlsList As ArrayList

        Public Property ContDtlsList() As ArrayList
            Get
                Return arrContDtlsList
            End Get
            Set(ByVal value As ArrayList)
                arrContDtlsList = value
            End Set
        End Property

        Public Shared Function InsertUpdateAllPartyAccount(ByVal pExtAllPartyAccount As ExtAllPartyAccount) As ExtAllPartyAccount
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                'If pExtAllPartyAccount.TrackId > 0 Then
                '    ExtAllPartyAccount.Update(pExtAllPartyAccount)
                'Else
                '    ExtAllPartyAccount.Insert(pExtAllPartyAccount)
                'End If

                If pExtAllPartyAccount.Errormsg = "" Then
                    ' AndAlso pExtAllPartyAccount.TrackId > 0 Then
                    For Each pAllPartyAccount As AllPartyAccount In pExtAllPartyAccount.arrContDtlsList
                        'pAllPartyAccount.TrackId = pExtFJO.ContJoId
                        If pAllPartyAccount.TrackId > 0 Then
                            AllPartyAccount.UpdateTrn(db, pAllPartyAccount)
                        Else
                            AllPartyAccount.InsertTrn(db, pAllPartyAccount)
                        End If
                        If pAllPartyAccount.Errormsg <> "" Then
                            Throw New Exception(pAllPartyAccount.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtAllPartyAccount.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtAllPartyAccount.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtAllPartyAccount
        End Function
    End Class
End Namespace
