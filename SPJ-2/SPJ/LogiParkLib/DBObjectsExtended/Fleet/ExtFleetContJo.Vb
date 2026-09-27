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
    Public Class ExtFleetContJo
        Inherits FleetContJo

        Private arrContJoDtlsList As ArrayList

        Public Property ContJoDtlsList() As ArrayList
            Get
                Return arrContJoDtlsList
            End Get
            Set(ByVal value As ArrayList)
                arrContJoDtlsList = value
            End Set
        End Property

        Public Shared Function InsertUpdateFleetContJo(ByVal pExtFJO As ExtFleetContJo) As ExtFleetContJo
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtFJO.ContJoId > 0 Then
                    ExtFleetContJo.Update(pExtFJO)
                Else
                    ExtFleetContJo.Insert(pExtFJO)

                End If

                If pExtFJO.Errormsg = "" AndAlso pExtFJO.ContJoId > 0 Then
                    For Each pFID As FleetContJoDtls In pExtFJO.arrContJoDtlsList
                        pFID.ContJoId = pExtFJO.ContJoId
                        If pFID.MtyContId > 0 Then
                            FleetContJoDtls.UpdateTrn(db, pFID)
                        Else
                            FleetContJoDtls.InsertTrn(db, pFID)
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

        Public Shared Function InsertUpdateFleetContJoImp(ByVal pExtFJO As ExtFleetContJo) As ExtFleetContJo
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtFJO.ContJoId > 0 Then
                    ExtFleetContJo.UpdateImp(pExtFJO)
                Else
                    ExtFleetContJo.InsertImp(pExtFJO)

                End If

                If pExtFJO.Errormsg = "" AndAlso pExtFJO.ContJoId > 0 Then
                    For Each pFID As FleetContJoDtls In pExtFJO.arrContJoDtlsList
                        pFID.ContJoId = pExtFJO.ContJoId
                        If pFID.MtyContId > 0 Then
                            FleetContJoDtls.UpdateTrn(db, pFID)
                        Else
                            FleetContJoDtls.InsertTrn(db, pFID)
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
