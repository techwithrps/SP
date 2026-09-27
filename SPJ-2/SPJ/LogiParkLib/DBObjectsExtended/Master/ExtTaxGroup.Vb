Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TaxGroup
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtTaxGroup
        Inherits TaxGroup

        Private arrTaxGroupHead As ArrayList

        Public Property TaxGroupHeadList() As ArrayList
            Get
                Return arrTaxGroupHead
            End Get
            Set(ByVal value As ArrayList)
                arrTaxGroupHead = value
            End Set
        End Property
        Public Shared Function InsertUpdateTransaction(ByVal pExtTaxGroup As ExtTaxGroup) As ExtTaxGroup
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtTaxGroup.TaxGroupId > 0 Then
                    ExtTaxGroup.UpdateTrn(db, pExtTaxGroup)
                Else
                    ExtTaxGroup.InsertTrn(db, pExtTaxGroup)
                End If

                If pExtTaxGroup.Errormsg = "" AndAlso pExtTaxGroup.TaxGroupId > 0 Then
                    For Each det As TaxGroupHeads In pExtTaxGroup.TaxGroupHeadList
                        det.TaxGroupId = pExtTaxGroup.TaxGroupId
                        If det.TaxRefId > 0 Then
                            TaxGroupHeads.UpdateTrn(db, det)
                        Else
                            TaxGroupHeads.InsertTrn(db, det)
                        End If
                        If det.Errormsg <> "" Then
                            Throw New Exception(det.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtTaxGroup.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtTaxGroup.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtTaxGroup
        End Function

        ''' <summary>
        ''' Preparing Return Object TaxGroup with TaxGroupHead Details By TaxGroupId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTaxGroupWithTaxGroupHeadDetailsByTaxGroupId(ByVal pTaxGroup As ExtTaxGroup) As ExtTaxGroup

            ExtTaxGroup.ReturnTaxGroupByTaxGroupId(pTaxGroup)

            Dim pTaxGroupHead As New TaxGroupHeads
            pTaxGroupHead.TerminalId = pTaxGroup.TerminalId
            pTaxGroupHead.TaxGroupId = pTaxGroup.TaxGroupId

            pTaxGroup.TaxGroupHeadList = TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroupHead)

            Return pTaxGroup
        End Function


    End Class
End Namespace
