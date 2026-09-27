Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: EquipmentMaster
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtEquipmentMaster
        Inherits EquipmentMaster

        Dim arrEquipmentTypeDetails As New ArrayList

        Public Property EquipmentTypeDetailsList() As ArrayList
            Get
                Return arrEquipmentTypeDetails
            End Get
            Set(ByVal value As ArrayList)
                arrEquipmentTypeDetails = value
            End Set
        End Property

        Public Shared Function InsertUpdateTransaction(ByVal pExtEquipmentMaster As ExtEquipmentMaster) As ExtEquipmentMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtEquipmentMaster.EquipRefId > 0 Then
                    ExtEquipmentMaster.UpdateTrn(db, pExtEquipmentMaster)
                Else
                    ExtEquipmentMaster.InsertTrn(db, pExtEquipmentMaster)
                End If
                If pExtEquipmentMaster.Errormsg = "" AndAlso pExtEquipmentMaster.EquipRefId > 0 Then
                    For Each pEquipmentDetails As EquipmentDetails In pExtEquipmentMaster.EquipmentTypeDetailsList
                        pEquipmentDetails.EquipRefId = pExtEquipmentMaster.EquipRefId
                        If pEquipmentDetails.EquipmentId > 0 Then
                            EquipmentDetails.UpdateTrn(db, pEquipmentDetails)
                        Else
                            EquipmentDetails.InsertTrn(db, pEquipmentDetails)
                        End If
                        If pEquipmentDetails.Errormsg <> "" Then
                            Throw New Exception(pEquipmentDetails.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtEquipmentMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtEquipmentMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtEquipmentMaster
        End Function

        Public Shared Function InsertUpdateTransactionEquipmentDetails(ByVal pExtEquipmentMaster As ExtEquipmentMaster) As ExtEquipmentMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtEquipmentMaster.Errormsg = "" AndAlso pExtEquipmentMaster.EquipRefId > 0 Then
                    For Each pEquipmentDetails As EquipmentDetails In pExtEquipmentMaster.EquipmentTypeDetailsList
                        pEquipmentDetails.EquipRefId = pExtEquipmentMaster.EquipRefId
                        EquipmentDetails.InsertTrn(db, pEquipmentDetails)
                        If pEquipmentDetails.Errormsg <> "" Then
                            Throw New Exception(pEquipmentDetails.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtEquipmentMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtEquipmentMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtEquipmentMaster
        End Function

        Public Shared Function ReturnEquipmentMasterDetailsById(ByVal pExtEquipmentMaster As ExtEquipmentMaster) As ExtEquipmentMaster
            ExtEquipmentMaster.ReturnEquipmentMasterByVendorId(pExtEquipmentMaster)
            Dim pEquipmentDetails As New EquipmentDetails
            pEquipmentDetails.TerminalId = pExtEquipmentMaster.TerminalId
            pEquipmentDetails.EquipRefId = pExtEquipmentMaster.EquipRefId
            pExtEquipmentMaster.EquipmentTypeDetailsList = EquipmentDetails.ReturnEquipmentDetailsListByEquipRefId(pEquipmentDetails)
            Return pExtEquipmentMaster
        End Function
    End Class
End Namespace
