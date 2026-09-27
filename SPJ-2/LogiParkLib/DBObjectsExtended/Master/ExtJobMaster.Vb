Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: JobMaster Class
    ''' @author	: Amit K. Singh- 28/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class ExtJobMaster
        Inherits JobMaster

        Dim arrJobMenuItems As ArrayList

        Public Property JobMenuItemsList() As ArrayList
            Get
                Return arrJobMenuItems
            End Get
            Set(ByVal value As ArrayList)
                arrJobMenuItems = value
            End Set
        End Property

        Public Shared Function InsertUpdateJobMenuItems(ByVal pExtJobMaster As ExtJobMaster) As ExtJobMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtJobMaster.JobId > 0 Then
                    ExtJobMaster.UpdateTrn(db, pExtJobMaster)
                Else
                    ExtJobMaster.InsertTrn(db, pExtJobMaster)
                End If

                Dim pJMIs As New JobMenuItems
                pJMIs.JobId = pExtJobMaster.JobId
                JobMenuItems.DeleteTrnByJobCode(db, pJMIs)

                If pExtJobMaster.Errormsg = "" AndAlso pExtJobMaster.JobId > 0 Then
                    For Each jmi As JobMenuItems In pExtJobMaster.JobMenuItemsList
                        jmi.JobId = pExtJobMaster.JobId
                        JobMenuItems.InsertTrn(db, jmi)
                        If jmi.Errormsg <> "" Then
                            Throw New Exception(jmi.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtJobMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtJobMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtJobMaster
        End Function

        Public Shared Function ReturnJobMenuDetailsByJobId(ByVal pExtJobMaster As ExtJobMaster) As ExtJobMaster
            ExtJobMaster.ReturnJobMaster(pExtJobMaster)

            Dim pJobMenuItem As New JobMenuItems
            pJobMenuItem.JobId = pExtJobMaster.JobId
            pExtJobMaster.JobMenuItemsList = JobMenuItems.ReturnJobMenuItemsByIdWithAllMenu(pJobMenuItem)


            Return pExtJobMaster
        End Function
    End Class
End Namespace
