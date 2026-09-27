Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyVehicleGateIn
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtMtyVehicleGateIn
        Inherits MtyVehicleGateIn

        Dim arrMtyVehicleGateIn As New ArrayList

        Public Property MtyVehicleGateInList() As ArrayList
            Get
                Return arrMtyVehicleGateIn
            End Get
            Set(ByVal value As ArrayList)
                arrMtyVehicleGateIn = value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Shared Function InsertUpdateTransaction(ByVal pExtMtyVehicleGateIn As ExtMtyVehicleGateIn) As ExtMtyVehicleGateIn
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                For Each mvgi As ExtMtyVehicleGateIn In pExtMtyVehicleGateIn.MtyVehicleGateInList
                    If mvgi.MtyVhGateInId > 0 Then
                        ExtMtyVehicleGateIn.UpdateTrn(db, mvgi)
                    Else
                        ExtMtyVehicleGateIn.InsertTrn(db, mvgi)
                    End If
                    If mvgi.Errormsg <> "" Then
                        Throw New Exception(mvgi.Errormsg)
                    End If
                Next

                db.CommitTransaction()

            Catch ex As Exception
                pExtMtyVehicleGateIn.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtMtyVehicleGateIn
        End Function
     
    End Class
End Namespace
