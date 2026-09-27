Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: BankMaster
    ''' @author	: Amit K. Singh- 2/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtCustomerProfile
        Inherits CustomerProfile

        Dim arrCustomerCallLog As New ArrayList

        Public Property CustomerCallLogList() As ArrayList
            Get
                Return arrCustomerCallLog
            End Get
            Set(ByVal value As ArrayList)
                arrCustomerCallLog = value
            End Set
        End Property

        Public Shared Function UpdateCallLogTrn(ByVal db As DBConnect, ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerProfile.TerminalId)
                db.AddParameter("p_PROFILE_ID", pCustomerProfile.ProfileId)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerProfile.CustomerName)
                db.AddParameter("p_COMPANY_TYPE", pCustomerProfile.CompanyType)
                db.AddParameter("p_BUSINESS", pCustomerProfile.Business)
                db.AddParameter("p_TURN_OVER", pCustomerProfile.TurnOver)
                db.AddParameter("p_COMPANY_AGE", pCustomerProfile.CompanyAge)
                db.AddParameter("p_TRANSPORT_MODE", pCustomerProfile.TransportMode)
                db.AddParameter("p_TRANSPORT_COST", pCustomerProfile.TransportCost)
                db.AddParameter("p_NET_WORTH", pCustomerProfile.NetWorth)
                db.AddParameter("p_EST_REVENUE", pCustomerProfile.EstRevenue)
                db.AddParameter("p_CONTACT_PERSON", pCustomerProfile.ContactPerson)
                db.AddParameter("p_CONTACT_NUMBER", pCustomerProfile.ContactNumber)
                db.AddParameter("p_EMAIL_ID", pCustomerProfile.EmailId)
                db.AddParameter("p_ADDRESS", pCustomerProfile.Address)
                db.AddParameter("p_REMARKS", pCustomerProfile.Remarks)
                db.AddParameter("p_CALL_STATUS", pCustomerProfile.CallStatus)
                db.AddParameter("p_ErrorMsg", pCustomerProfile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_PROFILE_CALL_LOG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerProfile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
            End Try
            Return pCustomerProfile
        End Function

        Public Shared Function InsertUpdateCustomerCallLog(ByVal pExtCustomerProfile As ExtCustomerProfile) As ExtCustomerProfile
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pExtCustomerProfile.CallStatus = "Y" Then
                    ExtCustomerProfile.UpdateCallLogTrn(db, pExtCustomerProfile)
                End If

                If pExtCustomerProfile.Errormsg = "" AndAlso pExtCustomerProfile.ProfileId > 0 Then
                    For Each ccl As CustomerCallLog In pExtCustomerProfile.CustomerCallLogList
                        ccl.CustomerId = pExtCustomerProfile.ProfileId
                        CustomerCallLog.InsertTrn(db, ccl)
                        If ccl.Errormsg <> "" Then
                            Throw New Exception(ccl.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtCustomerProfile.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtCustomerProfile.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtCustomerProfile
        End Function

        Public Shared Function RetrunCustomerProfileCallLogDeatilsByProfileId(ByVal pExtCustomerProfile As ExtCustomerProfile) As ExtCustomerProfile

            ExtCustomerProfile.ReturnCustomerProfile(pExtCustomerProfile)

            Dim P As New CustomerCallLog
            P.TerminalId = pExtCustomerProfile.TerminalId
            P.CustomerId = pExtCustomerProfile.ProfileId
            pExtCustomerProfile.CustomerCallLogList = CustomerCallLog.ReturnCustomerCallLogList(P)

            Return pExtCustomerProfile
        End Function
    End Class
End Namespace
