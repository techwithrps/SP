Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic-Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UserMaster
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtUserMaster
        Inherits UserMaster
        Dim arrUser As New ArrayList
        Dim arrCompany As New ArrayList
        Dim arrTerminal As New ArrayList
        Dim arrRole As New ArrayList

        Public Property UserList() As ArrayList
            Get
                Return arrUser
            End Get
            Set(ByVal value As ArrayList)
                arrUser = value
            End Set
        End Property
        Public Property CompanyList() As ArrayList
            Get
                Return arrCompany
            End Get
            Set(ByVal value As ArrayList)
                arrCompany = value
            End Set
        End Property
        Public Property TerminalList() As ArrayList
            Get
                Return arrTerminal
            End Get
            Set(ByVal value As ArrayList)
                arrTerminal = value
            End Set
        End Property

        Public Property RoleList() As ArrayList
            Get
                Return arrRole
            End Get
            Set(ByVal value As ArrayList)
                arrRole = value
            End Set
        End Property

        Public Shared Function InsertUpdateUserMaster(ByVal pExtUserMaster As ExtUserMaster) As ExtUserMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                Dim strUserId As String = ""
                Dim temp As New ExtUserMaster
                temp.UserId = pExtUserMaster.UserId.Trim.ToString
                ExtUserMaster.ReturnUserMaster(temp)

                db.BeginTransaction()

                If temp.UserName.Trim <> Nothing Then
                    ExtUserMaster.UpdateTrn(db, pExtUserMaster)
                Else
                    ExtUserMaster.InsertTrn(db, pExtUserMaster)
                End If
                Dim pUJ As New UserJobs
                pUJ.UserId = pExtUserMaster.UserId
                UserJobs.DeleteTrnByUserId(db, pUJ)
                If pExtUserMaster.Errormsg = "" Then
                    For Each ut As UserTerminal In pExtUserMaster.TerminalList
                        ut.UserId = pExtUserMaster.UserId
                        UserTerminal.InsertTrn(db, ut)
                        If ut.Errormsg <> "" Then
                            Throw New Exception(ut.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtUserMaster.Errormsg)
                End If
                If pExtUserMaster.Errormsg = "" Then
                    For Each ut As UserCompany In pExtUserMaster.CompanyList
                        ut.UserId = pExtUserMaster.UserId
                        UserCompany.InsertTrn(db, ut)
                        If ut.Errormsg <> "" Then
                            Throw New Exception(ut.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtUserMaster.Errormsg)
                End If
                If pExtUserMaster.Errormsg = "" Then
                    For Each PMapping As UsersMapping In pExtUserMaster.UserList
                        PMapping.UserId = pExtUserMaster.UserId
                        UsersMapping.InsertTrn(db, PMapping)
                        If PMapping.Errormsg <> "" Then
                            Throw New Exception(PMapping.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtUserMaster.Errormsg)
                End If
                If pExtUserMaster.Errormsg = "" Then
                    For Each uj As UserJobs In pExtUserMaster.RoleList
                        uj.UserId = pExtUserMaster.UserId
                        UserJobs.InsertTrn(db, uj)
                        If uj.Errormsg <> "" Then
                            Throw New Exception(uj.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtUserMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtUserMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtUserMaster
        End Function

        Public Shared Function ReturnUserMasterRolAndTerminalListByUserId(ByVal pExtUserMaster As ExtUserMaster) As ExtUserMaster

            ExtUserMaster.ReturnUserMaster(pExtUserMaster)
            Dim uMapp As New UsersMapping
            uMapp.UserId = pExtUserMaster.UserId
            uMapp.MappedUser = pExtUserMaster.UserName
            pExtUserMaster.UserList = UsersMapping.ReturnUsersMappingList(uMapp)

            Dim uc As New UserCompany
            uc.UserId = pExtUserMaster.UserId
            pExtUserMaster.CompanyList = UserCompany.ReturnUserCompanyList(uc)

            Dim ut As New UserTerminal
            ut.UserId = pExtUserMaster.UserId
            pExtUserMaster.TerminalList = UserTerminal.ReturnUserTerminalList(ut)

            Dim uj As New UserJobs
            uj.UserId = pExtUserMaster.UserId
            pExtUserMaster.RoleList = UserJobs.ReturnUserJobsListByUserId(uj)

            Return pExtUserMaster
        End Function

        Public Shared Function ReturnUserMasterRolAndTerminalListByUserIAssign(ByVal pExtUserMaster As ExtUserMaster) As ExtUserMaster

            ExtUserMaster.ReturnUserMaster(pExtUserMaster)
            Dim uMapp As New UsersMapping
            uMapp.UserId = pExtUserMaster.UserId
            pExtUserMaster.UserList = UsersMapping.ReturnUserUserListAssigned(uMapp)

            Dim uc As New UserCompany
            uc.UserId = pExtUserMaster.UserId
            pExtUserMaster.CompanyList = UserCompany.ReturnUserCompanyListAssigned(uc)

            Dim ut As New UserTerminal
            ut.UserId = pExtUserMaster.UserId
            pExtUserMaster.TerminalList = UserTerminal.ReturnUserTerminalListAssigned(ut)

            Dim uj As New UserJobs
            uj.UserId = pExtUserMaster.UserId
            pExtUserMaster.RoleList = UserJobs.ReturnUserJobsListByUserId(uj)

            Return pExtUserMaster
        End Function
    End Class
End Namespace
