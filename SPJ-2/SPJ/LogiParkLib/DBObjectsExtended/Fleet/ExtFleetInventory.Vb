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
    Public Class ExtFleetInventory
        Inherits FleetInventory

        Private arrInventoryDtlsList As ArrayList

        Public Property InventoryDtlsList() As ArrayList
            Get
                Return arrInventoryDtlsList
            End Get
            Set(ByVal value As ArrayList)
                arrInventoryDtlsList = value
            End Set
        End Property

        Public Shared Function InsertUpdateFleetInventory(ByVal pExtFleetInventory As ExtFleetInventory) As ExtFleetInventory
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtFleetInventory.InventId > 0 Then
                    ExtFleetInventory.UpdateTrn(db, pExtFleetInventory)
                Else
                    ExtFleetInventory.InsertTrn(db, pExtFleetInventory)
                End If

                If pExtFleetInventory.Errormsg = "" AndAlso pExtFleetInventory.InventId > 0 Then
                    For Each pFID As FleetInventoryDtls In pExtFleetInventory.arrInventoryDtlsList
                        pFID.InventId = pExtFleetInventory.InventId
                        If pFID.InventDtls > 0 Then
                            FleetInventoryDtls.UpdateTrn(db, pFID)
                        Else
                            FleetInventoryDtls.InsertTrn(db, pFID)
                        End If
                        If pFID.Errormsg <> "" Then
                            Throw New Exception(pFID.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtFleetInventory.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtFleetInventory.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtFleetInventory
        End Function
    End Class
End Namespace
