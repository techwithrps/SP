Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: YardMaster
    ''' @author	: Amit K. Singh- 1/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtYardMaster
        Inherits YardMaster

        Private arrExtYardDetailsList As ArrayList

        Public Property ExtYardDetailsList() As ArrayList
            Get
                Return arrExtYardDetailsList
            End Get
            Set(ByVal value As ArrayList)
                arrExtYardDetailsList = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()

        End Sub

        Public Shared Function InsertUpdateTransaction2(ByVal pExtYardMaster As ExtYardMaster) As ExtYardMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Dim temp As Boolean = False
            Try
                db.BeginTransaction()

                If pExtYardMaster.YardId > 0 Then
                    ExtYardMaster.UpdateTrn(db, pExtYardMaster)
                Else
                    temp = True
                    ExtYardMaster.InsertTrn(db, pExtYardMaster)
                End If

                If pExtYardMaster.Errormsg = "" AndAlso pExtYardMaster.YardId > 0 Then
                    If temp = True Then
                        For Each yd As ExtYardDetails In pExtYardMaster.ExtYardDetailsList
                            yd.YardId = pExtYardMaster.YardId
                            yd.YardCode = pExtYardMaster.YardCode
                            ExtYardDetails.InsertTrn(db, yd)
                            If yd.Errormsg <> "" Then
                                Throw New Exception(yd.Errormsg)
                            End If
                        Next
                    End If
                Else
                    Throw New Exception(pExtYardMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtYardMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtYardMaster
        End Function

        Public Shared Function ReturnYardMasterDetailsByYardId(ByVal pExtYardMaster As ExtYardMaster) As ExtYardMaster
            ExtYardMaster.ReturnYardMasterByYardId(pExtYardMaster)

            Dim pExtYardDetails As New ExtYardDetails
            pExtYardDetails.TerminalId = pExtYardMaster.TerminalId
            pExtYardDetails.YardId = pExtYardMaster.YardId

            pExtYardMaster.ExtYardDetailsList = ExtYardDetails.ReturnYardDetailsListByYardId(pExtYardDetails)

            Return pExtYardMaster
        End Function

        ''' <summary>
        ''' ''' Preparing Return ArrayList of YardDetails By TerminalId, DocType, YardType
        ''' </summary>
        ''' <param name="pExtYardMaster">TerminalId,DocType,YardType </param>
        ''' <returns>ArrayList</returns>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnYardDetailsByTerminalIdDocTypeYardType(ByVal pExtYardMaster As ExtYardMaster) As ArrayList
            pExtYardMaster.ExtYardDetailsList = ExtYardDetails.ReturnYardDetailsListByDockTypeYardType(pExtYardMaster.TerminalId, pExtYardMaster.DockType, pExtYardMaster.YardType)
            Return pExtYardMaster.ExtYardDetailsList
        End Function
    End Class
End Namespace
