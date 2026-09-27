Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: Terminal Service Charges Class
    ''' @author	: Amit K. Singh- 17/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class ExtVendorContract
        Inherits VendorContract
        Dim arrVendorContractDetailsList As ArrayList

        Public Property VendorContractDetailsList() As ArrayList
            Get
                Return arrVendorContractDetailsList
            End Get
            Set(ByVal value As ArrayList)
                arrVendorContractDetailsList = value
            End Set
        End Property

        Public Shared Function InsertUpdateTransaction(ByVal pExtVendorContract As ExtVendorContract) As ExtVendorContract
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pExtVendorContract.ContractId > 0 Then
                    ExtVendorContract.UpdateTrn(db, pExtVendorContract)
                Else
                    ExtVendorContract.InsertTrn(db, pExtVendorContract)
                End If
                For Each tscd As VendorContractDetails In pExtVendorContract.VendorContractDetailsList
                    tscd.ContractId = pExtVendorContract.ContractId
                    If tscd.ContractRefId > 0 Then
                        VendorContractDetails.UpdateTrn(db, tscd)
                    Else
                        VendorContractDetails.InsertTrn(db, tscd)
                    End If
                    If tscd.Errormsg <> "" Then
                        Throw New Exception(tscd.Errormsg)
                    End If
                Next

                db.CommitTransaction()
            Catch ex As Exception
                pExtVendorContract.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtVendorContract
        End Function

        Public Shared Function ApproveUpdateTransaction(ByVal pExtVendorContract As ExtVendorContract) As ExtVendorContract
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                ExtVendorContract.UpdateApprovalTrn(db, pExtVendorContract)

                For Each pVendorContractDetails As VendorContractDetails In pExtVendorContract.VendorContractDetailsList
                    If pVendorContractDetails.ContractRefId > 0 Then
                        VendorContractDetails.UpdateApprovalTrn(db, pVendorContractDetails)
                    End If
                    If pVendorContractDetails.Errormsg <> "" Then
                        Throw New Exception(pVendorContractDetails.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtVendorContract.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtVendorContract
        End Function

        Public Shared Function ReturnVendorContractById(ByVal pExtVendorContract As ExtVendorContract) As ExtVendorContract
            ExtVendorContract.ReturnVendorContract(pExtVendorContract)

            Dim pExtVendorContractDetails As New VendorContractDetails
            pExtVendorContractDetails.ContractId = pExtVendorContract.ContractId
            pExtVendorContractDetails.TerminalId = pExtVendorContract.TerminalId
            pExtVendorContract.VendorContractDetailsList = VendorContractDetails.ReturnVendorContractDetailsListByContractRefId_ContractId(pExtVendorContractDetails)
            Return pExtVendorContract
        End Function
    End Class
End Namespace
