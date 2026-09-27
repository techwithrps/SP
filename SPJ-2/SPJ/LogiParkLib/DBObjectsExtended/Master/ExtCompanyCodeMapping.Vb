Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CompanyCodeMapping Class
    ''' @author	: Amit K. Singh- 27/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtCompanyCodeMapping
        Inherits CompanyCodeMapping

        Dim arrCompanyCodeMapping As ArrayList

        Public Property CompanyCodeMappingList() As ArrayList
            Get
                Return arrCompanyCodeMapping
            End Get
            Set(ByVal value As ArrayList)
                arrCompanyCodeMapping = value
            End Set
        End Property

        Public Shared Function InsertUpdateCompanyCodeMapping(ByVal pExtCompanyCodeMapping As ExtCompanyCodeMapping) As ExtCompanyCodeMapping
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each sb As ExtCompanyCodeMapping In pExtCompanyCodeMapping.CompanyCodeMappingList
                    ExtCompanyCodeMapping.InsertTrn(db, sb)
                    If sb.Errormsg <> "" Then
                        Throw New Exception(sb.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtCompanyCodeMapping.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtCompanyCodeMapping
        End Function
    End Class
End Namespace
