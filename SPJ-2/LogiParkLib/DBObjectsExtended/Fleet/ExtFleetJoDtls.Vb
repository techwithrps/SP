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
    Public Class ExtFleetJoDtls
        Inherits FleetJoDtls

        Private arrItemDtlsList As ArrayList

        Public Property ItemDtlsList() As ArrayList
            Get
                Return arrItemDtlsList
            End Get
            Set(ByVal value As ArrayList)
                arrItemDtlsList = value
            End Set
        End Property

        Public Shared Function InsertUpdateFleetJoDtls(ByVal pExtFJO As ExtFleetJoDtls) As ExtFleetJoDtls
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtFJO.JoId > 0 Then
                    ExtFleetJoDtls.UpdateTrn(db, pExtFJO)
                Else
                    ExtFleetJoDtls.InsertTrn(db, pExtFJO)
                End If

                If pExtFJO.Errormsg = "" AndAlso pExtFJO.JoId > 0 Then
                    For Each pFID As FleetJoItemDtls In pExtFJO.arrItemDtlsList
                        pFID.JoId = pExtFJO.JoId
                        If pFID.JoDtlsId > 0 Then
                            FleetJoItemDtls.UpdateTrn(db, pFID)
                        Else
                            FleetJoItemDtls.InsertTrn(db, pFID)
                        End If
                        If pFID.Errormsg <> "" Then
                            Throw New Exception(pFID.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtFJO.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtFJO.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtFJO
        End Function
    End Class
End Namespace
