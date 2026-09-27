Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyVhInJo
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtMtyVhInJo
        Inherits MtyVhInJo
        Dim arrExtMtyVehicleGateIn As New ArrayList

        Public Property ExtMtyVehicleGateInList() As ArrayList
            Get
                Return arrExtMtyVehicleGateIn
            End Get
            Set(ByVal value As ArrayList)
                arrExtMtyVehicleGateIn = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing Return Object By TerminalId, MtyVhInJoNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyVhInJoWithVehicleGateInDetails(ByVal pExtMtyVhInJo As ExtMtyVhInJo) As ExtMtyVhInJo

            ExtMtyVhInJo.ReturnMtyVhInJo(pExtMtyVhInJo)

            Dim pExtMtyVehicleGateIn As New ExtMtyVehicleGateIn
            pExtMtyVehicleGateIn.TerminalId = pExtMtyVhInJo.TerminalId
            pExtMtyVehicleGateIn.MtyVhInJoId = pExtMtyVhInJo.MtyVhInJoId

            pExtMtyVhInJo.ExtMtyVehicleGateInList = ExtMtyVehicleGateIn.ReturnMtyVehicleGateInList(pExtMtyVehicleGateIn)

            Return pExtMtyVhInJo
        End Function

        Public Shared Function VegicleGateOutJo_OutPass(ByVal pExtMtyVhInJo As ExtMtyVhInJo) As ExtMtyVhInJo
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                ExtMtyVhInJo.InsertTrnOutJo(db, pExtMtyVhInJo)
                
                If pExtMtyVhInJo.Errormsg = "" AndAlso pExtMtyVhInJo.MtyVhInJoId > 0 Then
                    For Each mvi As MtyVehicleGateIn In pExtMtyVhInJo.ExtMtyVehicleGateInList
                        mvi.ImpVhGateOutJoId = pExtMtyVhInJo.MtyVhInJoId

                        MtyVehicleGateIn.UpdateTrnOutJoId_OutPass(db, mvi)

                    Next
                Else
                    Throw New Exception(pExtMtyVhInJo.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtMtyVhInJo.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtMtyVhInJo
        End Function

        Public Shared Function ReturnMtyVhInJo_WithVehicleGateOutJoDetails(ByVal pExtMtyVhInJo As ExtMtyVhInJo) As ExtMtyVhInJo

            ExtMtyVhInJo.ReturnMtyVhInJo(pExtMtyVhInJo)

            Dim pExtMtyVehicleGateIn As New ExtMtyVehicleGateIn
            pExtMtyVehicleGateIn.TerminalId = pExtMtyVhInJo.TerminalId
            pExtMtyVehicleGateIn.ImpVhGateOutJoId = pExtMtyVhInJo.MtyVhInJoId

            pExtMtyVhInJo.ExtMtyVehicleGateInList = ExtMtyVehicleGateIn.ReturnMtyVehicleGateInListByOutJoId(pExtMtyVehicleGateIn)

            Return pExtMtyVhInJo
        End Function
        Public Shared Function ReturnMtyVhInJo_WithVehicleGateOutJoDetailsId(ByVal pExtMtyVhInJo As ExtMtyVhInJo) As ExtMtyVhInJo

            ExtMtyVhInJo.ReturnMtyVhInJoById(pExtMtyVhInJo)

            Dim pExtMtyVehicleGateIn As New ExtMtyVehicleGateIn
            pExtMtyVehicleGateIn.TerminalId = pExtMtyVhInJo.TerminalId
            pExtMtyVehicleGateIn.ImpVhGateOutJoId = pExtMtyVhInJo.MtyVhInJoId

            pExtMtyVhInJo.ExtMtyVehicleGateInList = ExtMtyVehicleGateIn.ReturnMtyVehicleGateInListByOutJoId(pExtMtyVehicleGateIn)

            Return pExtMtyVhInJo
        End Function


    End Class
End Namespace
