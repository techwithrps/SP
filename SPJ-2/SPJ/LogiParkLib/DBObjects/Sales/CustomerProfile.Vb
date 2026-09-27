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
    Public Class CustomerProfile

        Private lngTerminalId As Long ' Define Private Variable TerminalId DataType As Long 
        Private lngProfileId As Long ' Define Private Variable ProfileId DataType As Long 
        Private strCustomerName As String ' Define Private Variable CustomerName DataType As String 
        Private strCompanyType As String ' Define Private Variable CompanyType DataType As String 
        Private strBusiness As String ' Define Private Variable Business DataType As String 
        Private lngTurnOver As Long ' Define Private Variable TurnOver DataType As Long 
        Private lngCompanyAge As Long ' Define Private Variable CompanyAge DataType As Long 
        Private strTransportMode As String ' Define Private Variable TransportMode DataType As String 
        Private lngTransportCost As Long ' Define Private Variable TransportCost DataType As Long 
        Private lngNetWorth As Long ' Define Private Variable NetWorth DataType As Long 
        Private lngEstRevenue As Long ' Define Private Variable EstRevenue DataType As Long 
        Private strContactPerson As String ' Define Private Variable ContactPerson DataType As String 
        Private strContactNumber As String ' Define Private Variable ContactNumber DataType As String 
        Private strEmailId As String ' Define Private Variable EmailId DataType As String 
        Private strAddress As String ' Define Private Variable Address DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks DataType As String 
        Private strCallStatus As String ' Define Private Variable CallStatus DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn DataType As String 
        Private lngCustomerId As Long
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks></remarks>
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' ProfileId
        ''' </summary>
        ''' <value>lngProfileId</value>
        ''' <returns> Return lngProfileId</returns>
        ''' <remarks></remarks>
        Public Property ProfileId() As Long
            Get
                Return lngProfileId
            End Get
            Set(ByVal value As Long)
                lngProfileId = value
            End Set
        End Property


        ''' <summary>
        ''' CustomerName
        ''' </summary>
        ''' <value>strCustomerName</value>
        ''' <returns> Return strCustomerName</returns>
        ''' <remarks></remarks>
        Public Property CustomerName() As String
            Get
                Return strCustomerName
            End Get
            Set(ByVal value As String)
                strCustomerName = value
            End Set
        End Property


        ''' <summary>
        ''' CompanyType
        ''' </summary>
        ''' <value>strCompanyType</value>
        ''' <returns> Return strCompanyType</returns>
        ''' <remarks></remarks>
        Public Property CompanyType() As String
            Get
                Return strCompanyType
            End Get
            Set(ByVal value As String)
                strCompanyType = value
            End Set
        End Property


        ''' <summary>
        ''' Business
        ''' </summary>
        ''' <value>strBusiness</value>
        ''' <returns> Return strBusiness</returns>
        ''' <remarks></remarks>
        Public Property Business() As String
            Get
                Return strBusiness
            End Get
            Set(ByVal value As String)
                strBusiness = value
            End Set
        End Property


        ''' <summary>
        ''' TurnOver
        ''' </summary>
        ''' <value>lngTurnOver</value>
        ''' <returns> Return lngTurnOver</returns>
        ''' <remarks></remarks>
        Public Property TurnOver() As Long
            Get
                Return lngTurnOver
            End Get
            Set(ByVal value As Long)
                lngTurnOver = value
            End Set
        End Property


        ''' <summary>
        ''' CompanyAge
        ''' </summary>
        ''' <value>lngCompanyAge</value>
        ''' <returns> Return lngCompanyAge</returns>
        ''' <remarks></remarks>
        Public Property CompanyAge() As Long
            Get
                Return lngCompanyAge
            End Get
            Set(ByVal value As Long)
                lngCompanyAge = value
            End Set
        End Property


        ''' <summary>
        ''' TransportMode
        ''' </summary>
        ''' <value>strTransportMode</value>
        ''' <returns> Return strTransportMode</returns>
        ''' <remarks></remarks>
        Public Property TransportMode() As String
            Get
                Return strTransportMode
            End Get
            Set(ByVal value As String)
                strTransportMode = value
            End Set
        End Property


        ''' <summary>
        ''' TransportCost
        ''' </summary>
        ''' <value>lngTransportCost</value>
        ''' <returns> Return lngTransportCost</returns>
        ''' <remarks></remarks>
        Public Property TransportCost() As Long
            Get
                Return lngTransportCost
            End Get
            Set(ByVal value As Long)
                lngTransportCost = value
            End Set
        End Property


        ''' <summary>
        ''' NetWorth
        ''' </summary>
        ''' <value>lngNetWorth</value>
        ''' <returns> Return lngNetWorth</returns>
        ''' <remarks></remarks>
        Public Property NetWorth() As Long
            Get
                Return lngNetWorth
            End Get
            Set(ByVal value As Long)
                lngNetWorth = value
            End Set
        End Property


        ''' <summary>
        ''' EstRevenue
        ''' </summary>
        ''' <value>lngEstRevenue</value>
        ''' <returns> Return lngEstRevenue</returns>
        ''' <remarks></remarks>
        Public Property EstRevenue() As Long
            Get
                Return lngEstRevenue
            End Get
            Set(ByVal value As Long)
                lngEstRevenue = value
            End Set
        End Property


        ''' <summary>
        ''' ContactPerson
        ''' </summary>
        ''' <value>strContactPerson</value>
        ''' <returns> Return strContactPerson</returns>
        ''' <remarks></remarks>
        Public Property ContactPerson() As String
            Get
                Return strContactPerson
            End Get
            Set(ByVal value As String)
                strContactPerson = value
            End Set
        End Property


        ''' <summary>
        ''' ContactNumber
        ''' </summary>
        ''' <value>strContactNumber</value>
        ''' <returns> Return strContactNumber</returns>
        ''' <remarks></remarks>
        Public Property ContactNumber() As String
            Get
                Return strContactNumber
            End Get
            Set(ByVal value As String)
                strContactNumber = value
            End Set
        End Property


        ''' <summary>
        ''' EmailId
        ''' </summary>
        ''' <value>strEmailId</value>
        ''' <returns> Return strEmailId</returns>
        ''' <remarks></remarks>
        Public Property EmailId() As String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
            End Set
        End Property


        ''' <summary>
        ''' Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks></remarks>
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property

        Public Property CallStatus() As String
            Get
                Return strCallStatus
            End Get
            Set(ByVal value As String)
                strCallStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks></remarks>
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks></remarks>
        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

        ''' <summary>
        ''' CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks></remarks>
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property

        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property
        ''' <summary>
        ''' Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks></remarks>
        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            TerminalId = 0
            lngProfileId = 0
            strCustomerName = ""
            strCompanyType = ""
            strBusiness = ""
            lngTurnOver = 0
            lngCompanyAge = 0
            strTransportMode = ""
            lngTransportCost = 0
            lngNetWorth = 0
            lngEstRevenue = 0
            strContactPerson = ""
            strContactNumber = ""
            strEmailId = ""
            strAddress = ""
            strRemarks = ""
            strCallStatus = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngCustomerId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerProfile"></param>
        ''' <returns>Return pCustomerProfile Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerProfile.TerminalId)
                db.AddParameter("p_PROFILE_ID", pCustomerProfile.ProfileId, ParameterDirection.Output)
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
                db.AddParameter("p_CREATED_BY", pCustomerProfile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerProfile.CreatedOn)
                db.AddParameter("p_CUSTOMER_ID", pCustomerProfile.CustomerId)
                db.AddParameter("p_ErrorMsg", pCustomerProfile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_PROFILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerProfile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerProfile.ProfileId = db.Parameters.Item("p_PROFILE_ID").value

                If pCustomerProfile.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerProfile"></param>
        ''' <returns>Return pCustomerProfile Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerProfile.TerminalId)
                db.AddParameter("p_PROFILE_ID", pCustomerProfile.ProfileId, ParameterDirection.Output)
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
                db.AddParameter("p_CREATED_BY", pCustomerProfile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerProfile.CreatedOn)
                db.AddParameter("p_CUSTOMER_ID", pCustomerProfile.CustomerId)
                db.AddParameter("p_ErrorMsg", pCustomerProfile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_PROFILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerProfile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerProfile.ProfileId = db.Parameters.Item("p_PROFILE_ID").value

            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
            End Try
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerProfile"></param>
        ''' <returns>Return pCustomerProfile Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
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
                db.AddParameter("p_CREATED_BY", pCustomerProfile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerProfile.CreatedOn)
                db.AddParameter("p_CUSTOMER_ID", pCustomerProfile.CustomerId)
                db.AddParameter("p_ErrorMsg", pCustomerProfile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_PROFILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerProfile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerProfile.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerProfile"></param>
        ''' <returns>Return pCustomerProfile Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
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
                db.AddParameter("p_CREATED_BY", pCustomerProfile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerProfile.CreatedOn)
                db.AddParameter("p_CUSTOMER_ID", pCustomerProfile.CustomerId)
                db.AddParameter("p_ErrorMsg", pCustomerProfile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_PROFILE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerProfile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
            End Try
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pCustomerProfile.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("PROFILE_ID").ToString <> "" Then
                            pCustomerProfile.ProfileId = dbr("PROFILE_ID")
                        End If
                        If dbr("CUSTOMER_NAME").ToString <> "" Then
                            pCustomerProfile.CustomerName = dbr("CUSTOMER_NAME")
                        End If
                        If dbr("COMPANY_TYPE").ToString <> "" Then
                            pCustomerProfile.CompanyType = dbr("COMPANY_TYPE")
                        End If
                        If dbr("BUSINESS").ToString <> "" Then
                            pCustomerProfile.Business = dbr("BUSINESS")
                        End If
                        If dbr("TURN_OVER").ToString <> "" Then
                            pCustomerProfile.TurnOver = dbr("TURN_OVER")
                        End If
                        If dbr("COMPANY_AGE").ToString <> "" Then
                            pCustomerProfile.CompanyAge = dbr("COMPANY_AGE")
                        End If
                        If dbr("TRANSPORT_MODE").ToString <> "" Then
                            pCustomerProfile.TransportMode = dbr("TRANSPORT_MODE")
                        End If
                        If dbr("TRANSPORT_COST").ToString <> "" Then
                            pCustomerProfile.TransportCost = dbr("TRANSPORT_COST")
                        End If
                        If dbr("NET_WORTH").ToString <> "" Then
                            pCustomerProfile.NetWorth = dbr("NET_WORTH")
                        End If
                        If dbr("EST_REVENUE").ToString <> "" Then
                            pCustomerProfile.EstRevenue = dbr("EST_REVENUE")
                        End If
                        If dbr("CONTACT_PERSON").ToString <> "" Then
                            pCustomerProfile.ContactPerson = dbr("CONTACT_PERSON")
                        End If
                        If dbr("CONTACT_NUMBER").ToString <> "" Then
                            pCustomerProfile.ContactNumber = dbr("CONTACT_NUMBER")
                        End If
                        If dbr("EMAIL_ID").ToString <> "" Then
                            pCustomerProfile.EmailId = dbr("EMAIL_ID")
                        End If
                        If dbr("ADDRESS").ToString <> "" Then
                            pCustomerProfile.Address = dbr("ADDRESS")
                        End If
                        If dbr("REMARKS").ToString <> "" Then
                            pCustomerProfile.Remarks = dbr("REMARKS")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            pCustomerProfile.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            pCustomerProfile.CreatedOn = dbr("CREATED_ON")
                        End If
                        If dbr("CALL_STATUS").ToString <> "" Then
                            pCustomerProfile.CallStatus = dbr("CALL_STATUS")
                        End If
                        If dbr("CUSTOMER_ID").ToString <> "" Then
                            pCustomerProfile.CustomerId = dbr("CUSTOMER_ID")
                        End If
                    End While
                End If
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
            End Try
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerProfile As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerProfile
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("PROFILE_ID").ToString <> "" Then
                            temp.ProfileId = dbr("PROFILE_ID")
                        End If
                        If dbr("CUSTOMER_NAME").ToString <> "" Then
                            temp.CustomerName = dbr("CUSTOMER_NAME")
                        End If
                        If dbr("COMPANY_TYPE").ToString <> "" Then
                            temp.CompanyType = dbr("COMPANY_TYPE")
                        End If
                        If dbr("BUSINESS").ToString <> "" Then
                            temp.Business = dbr("BUSINESS")
                        End If
                        If dbr("TURN_OVER").ToString <> "" Then
                            temp.TurnOver = dbr("TURN_OVER")
                        End If
                        If dbr("COMPANY_AGE").ToString <> "" Then
                            temp.CompanyAge = dbr("COMPANY_AGE")
                        End If
                        If dbr("TRANSPORT_MODE").ToString <> "" Then
                            temp.TransportMode = dbr("TRANSPORT_MODE")
                        End If
                        If dbr("TRANSPORT_COST").ToString <> "" Then
                            temp.TransportCost = dbr("TRANSPORT_COST")
                        End If
                        If dbr("NET_WORTH").ToString <> "" Then
                            temp.NetWorth = dbr("NET_WORTH")
                        End If
                        If dbr("EST_REVENUE").ToString <> "" Then
                            temp.EstRevenue = dbr("EST_REVENUE")
                        End If
                        If dbr("CONTACT_PERSON").ToString <> "" Then
                            temp.ContactPerson = dbr("CONTACT_PERSON")
                        End If
                        If dbr("CONTACT_NUMBER").ToString <> "" Then
                            temp.ContactNumber = dbr("CONTACT_NUMBER")
                        End If
                        If dbr("EMAIL_ID").ToString <> "" Then
                            temp.EmailId = dbr("EMAIL_ID")
                        End If
                        If dbr("ADDRESS").ToString <> "" Then
                            temp.Address = dbr("ADDRESS")
                        End If
                        If dbr("REMARKS").ToString <> "" Then
                            temp.Remarks = dbr("REMARKS")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            temp.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            temp.CreatedOn = dbr("CREATED_ON")
                        End If
                        If dbr("CALL_STATUS").ToString <> "" Then
                            temp.CallStatus = dbr("CALL_STATUS")
                        End If
                        If dbr("CUSTOMER_ID").ToString <> "" Then
                            temp.CustomerId = dbr("CUSTOMER_ID")
                        End If
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnCustomerProfile(ByVal pCustomerProfile As CustomerProfile) As CustomerProfile
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_PROFILE_BY_ID", pCustomerProfile.TerminalId & "," & pCustomerProfile.ProfileId)
                pCustomerProfile = ReturnObjectValues(dbr, pCustomerProfile)
                dbr.Close()
            Catch ex As Exception
                pCustomerProfile.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerProfile
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnCustomerProfileList(ByVal pCustomerProfile As CustomerProfile) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerProfile As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_PROFILE_BY_ALL", pCustomerProfile.TerminalId)
                arrCustomerProfile = ReturnObjectValuesList(dbr, arrCustomerProfile)
                dbr.Close()
            Catch ex As Exception
                arrCustomerProfile = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerProfile
        End Function
    End Class
End Namespace
