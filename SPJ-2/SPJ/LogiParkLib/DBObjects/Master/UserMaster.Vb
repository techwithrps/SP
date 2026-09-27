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
    Public Class UserMaster

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strUserId As String ' Define Private Variable UserId With DataType As String 
        Private strPassword As String ' Define Private Variable Password With DataType As String 
        Private strValidityDate As String ' Define Private Variable ValidityDate With DataType As String 
        Private strUserName As String ' Define Private Variable UserName With DataType As String 
        Private lngDesignationId As String ' Define Private Variable DesignationId With DataType As Long 
        Private lngDepartmentId As String ' Define Private Variable DepartmentId With DataType As Long 
        Private strEmailId As String ' Define Private Variable EmailId With DataType As String 
        Private strUserType As String ' Define Private Variable UserType With DataType As String 
        Private strUserStatus As String ' Define Private Variable UserStatus With DataType As String 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strRestrictedIp As String ' Define Private Variable RestrictedIp With DataType As String 
        Private lngPasswordExpiry As Long ' Define Private Variable PasswordExpiry With DataType As Long 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strMAC As String ' Define Private Variable strMAC With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngCompanyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UserId
        ''' </summary>
        ''' <value>strUserId</value>
        ''' <returns> Return strUserId</returns>
        ''' <remarks> Get or Set the Value of UserId  </remarks>
        '''
        Public Property UserId() As String
            Get
                Return strUserId
            End Get
            Set(ByVal value As String)
                strUserId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Password
        ''' </summary>
        ''' <value>strPassword</value>
        ''' <returns> Return strPassword</returns>
        ''' <remarks> Get or Set the Value of Password  </remarks>
        '''
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal value As String)
                strPassword = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ValidityDate
        ''' </summary>
        ''' <value>strValidityDate</value>
        ''' <returns> Return strValidityDate</returns>
        ''' <remarks> Get or Set the Value of ValidityDate  </remarks>
        '''
        Public Property ValidityDate() As String
            Get
                Return strValidityDate
            End Get
            Set(ByVal value As String)
                strValidityDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UserName
        ''' </summary>
        ''' <value>strUserName</value>
        ''' <returns> Return strUserName</returns>
        ''' <remarks> Get or Set the Value of UserName  </remarks>
        '''
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal value As String)
                strUserName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DesignationId
        ''' </summary>
        ''' <value>lngDesignationId</value>
        ''' <returns> Return lngDesignationId</returns>
        ''' <remarks> Get or Set the Value of DesignationId  </remarks>
        '''
        Public Property DesignationId() As String
            Get
                Return lngDesignationId
            End Get
            Set(ByVal value As String)
                lngDesignationId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DepartmentId
        ''' </summary>
        ''' <value>lngDepartmentId</value>
        ''' <returns> Return lngDepartmentId</returns>
        ''' <remarks> Get or Set the Value of DepartmentId  </remarks>
        '''
        Public Property DepartmentId() As String
            Get
                Return lngDepartmentId
            End Get
            Set(ByVal value As String)
                lngDepartmentId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EmailId
        ''' </summary>
        ''' <value>strEmailId</value>
        ''' <returns> Return strEmailId</returns>
        ''' <remarks> Get or Set the Value of EmailId  </remarks>
        '''
        Public Property EmailId() As String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UserType
        ''' </summary>
        ''' <value>strUserType</value>
        ''' <returns> Return strUserType</returns>
        ''' <remarks> Get or Set the Value of UserType  </remarks>
        '''
        Public Property UserType() As String
            Get
                Return strUserType
            End Get
            Set(ByVal value As String)
                strUserType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UserStatus
        ''' </summary>
        ''' <value>strUserStatus</value>
        ''' <returns> Return strUserStatus</returns>
        ''' <remarks> Get or Set the Value of UserStatus  </remarks>
        '''
        Public Property UserStatus() As String
            Get
                Return strUserStatus
            End Get
            Set(ByVal value As String)
                strUserStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of RestrictedIp
        ''' </summary>
        ''' <value>strRestrictedIp</value>
        ''' <returns> Return strRestrictedIp</returns>
        ''' <remarks> Get or Set the Value of RestrictedIp  </remarks>
        '''
        Public Property RestrictedIp() As String
            Get
                Return strRestrictedIp
            End Get
            Set(ByVal value As String)
                strRestrictedIp = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of PasswordExpiry
        ''' </summary>
        ''' <value>lngPasswordExpiry</value>
        ''' <returns> Return lngPasswordExpiry</returns>
        ''' <remarks> Get or Set the Value of PasswordExpiry  </remarks>
        '''
        Public Property PasswordExpiry() As Long
            Get
                Return lngPasswordExpiry
            End Get
            Set(ByVal value As Long)
                lngPasswordExpiry = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of MACAddress
        ''' </summary>
        ''' <value>strMAC</value>
        ''' <returns> Return strMAC</returns>
        ''' <remarks> Get or Set the Value of MACAddress  </remarks>
        '''
        Public Property MACAddress() As String
            Get
                Return strMAC
            End Get
            Set(ByVal value As String)
                strMAC = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
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
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            strUserId = ""
            strPassword = ""
            strValidityDate = ""
            strUserName = ""
            lngDesignationId = 0
            lngDepartmentId = 0
            strEmailId = ""
            strUserType = ""
            strUserStatus = ""
            lngCustomerId = 0
            strRestrictedIp = ""
            lngPasswordExpiry = 0
            strRemarks = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            lngCompanyId = 0
            strMAC = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUserMaster"></param>
        ''' <returns>Return pUserMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUserMaster As UserMaster) As UserMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUserMaster.TerminalId)
                db.AddParameter("p_USER_ID", pUserMaster.UserId)
                db.AddParameter("p_PASSWORD", pUserMaster.Password)
                db.AddParameter("p_VALIDITY_DATE", pUserMaster.ValidityDate)
                db.AddParameter("p_USER_NAME", pUserMaster.UserName)
                db.AddParameter("p_DESIGNATION_ID", pUserMaster.DesignationId)
                db.AddParameter("p_DEPARTMENT_ID", pUserMaster.DepartmentId)
                db.AddParameter("p_EMAIL_ID", pUserMaster.EmailId)
                db.AddParameter("p_USER_TYPE", pUserMaster.UserType)
                db.AddParameter("p_USER_STATUS", pUserMaster.UserStatus)
                db.AddParameter("p_CUSTOMER_ID", pUserMaster.CustomerId)
                db.AddParameter("p_RESTRICTED_IP", pUserMaster.RestrictedIp)
                db.AddParameter("p_PASSWORD_EXPIRY", pUserMaster.PasswordExpiry)
                db.AddParameter("p_REMARKS", pUserMaster.Remarks)
                db.AddParameter("p_CREATED_BY", pUserMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUserMaster.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pUserMaster.CompanyId)
                db.AddParameter("p_MAC_ADDRESSES", pUserMaster.MACAddress)
                db.AddParameter("p_ErrorMsg", pUserMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pUserMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserMaster"></param>
        ''' <returns>Return pUserMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUserMaster As UserMaster) As UserMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUserMaster.TerminalId)
                db.AddParameter("p_USER_ID", pUserMaster.UserId)
                db.AddParameter("p_PASSWORD", pUserMaster.Password)
                db.AddParameter("p_VALIDITY_DATE", pUserMaster.ValidityDate)
                db.AddParameter("p_USER_NAME", pUserMaster.UserName)
                db.AddParameter("p_DESIGNATION_ID", pUserMaster.DesignationId)
                db.AddParameter("p_DEPARTMENT_ID", pUserMaster.DepartmentId)
                db.AddParameter("p_EMAIL_ID", pUserMaster.EmailId)
                db.AddParameter("p_USER_TYPE", pUserMaster.UserType)
                db.AddParameter("p_USER_STATUS", pUserMaster.UserStatus)
                db.AddParameter("p_CUSTOMER_ID", pUserMaster.CustomerId)
                db.AddParameter("p_RESTRICTED_IP", pUserMaster.RestrictedIp)
                db.AddParameter("p_PASSWORD_EXPIRY", pUserMaster.PasswordExpiry)
                db.AddParameter("p_REMARKS", pUserMaster.Remarks)
                db.AddParameter("p_CREATED_BY", pUserMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUserMaster.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pUserMaster.CompanyId)
                db.AddParameter("p_MAC_ADDRESSES", pUserMaster.MACAddress)
                db.AddParameter("p_ErrorMsg", pUserMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pUserMaster.ErrorMsg = ex.Message
            End Try
            Return pUserMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserMaster"></param>
        ''' <returns>Return pUserMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUserMaster As UserMaster) As UserMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUserMaster.TerminalId)
                db.AddParameter("p_USER_ID", pUserMaster.UserId)
                db.AddParameter("p_PASSWORD", pUserMaster.Password)
                db.AddParameter("p_VALIDITY_DATE", pUserMaster.ValidityDate)
                db.AddParameter("p_USER_NAME", pUserMaster.UserName)
                db.AddParameter("p_DESIGNATION_ID", pUserMaster.DesignationId)
                db.AddParameter("p_DEPARTMENT_ID", pUserMaster.DepartmentId)
                db.AddParameter("p_EMAIL_ID", pUserMaster.EmailId)
                db.AddParameter("p_USER_TYPE", pUserMaster.UserType)
                db.AddParameter("p_USER_STATUS", pUserMaster.UserStatus)
                db.AddParameter("p_CUSTOMER_ID", pUserMaster.CustomerId)
                db.AddParameter("p_RESTRICTED_IP", pUserMaster.RestrictedIp)
                db.AddParameter("p_PASSWORD_EXPIRY", pUserMaster.PasswordExpiry)
                db.AddParameter("p_REMARKS", pUserMaster.Remarks)
                db.AddParameter("p_CREATED_BY", pUserMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUserMaster.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pUserMaster.CompanyId)
                db.AddParameter("p_MAC_ADDRESSES", pUserMaster.MACAddress)
                db.AddParameter("p_ErrorMsg", pUserMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserMaster
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserMaster"></param>
        ''' <returns>Return pUserMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUserMaster As UserMaster) As UserMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUserMaster.TerminalId)
                db.AddParameter("p_USER_ID", pUserMaster.UserId)
                db.AddParameter("p_PASSWORD", pUserMaster.Password)
                db.AddParameter("p_VALIDITY_DATE", pUserMaster.ValidityDate)
                db.AddParameter("p_USER_NAME", pUserMaster.UserName)
                db.AddParameter("p_DESIGNATION_ID", pUserMaster.DesignationId)
                db.AddParameter("p_DEPARTMENT_ID", pUserMaster.DepartmentId)
                db.AddParameter("p_EMAIL_ID", pUserMaster.EmailId)
                db.AddParameter("p_USER_TYPE", pUserMaster.UserType)
                db.AddParameter("p_USER_STATUS", pUserMaster.UserStatus)
                db.AddParameter("p_CUSTOMER_ID", pUserMaster.CustomerId)
                db.AddParameter("p_RESTRICTED_IP", pUserMaster.RestrictedIp)
                db.AddParameter("p_PASSWORD_EXPIRY", pUserMaster.PasswordExpiry)
                db.AddParameter("p_REMARKS", pUserMaster.Remarks)
                db.AddParameter("p_CREATED_BY", pUserMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUserMaster.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pUserMaster.CompanyId)
                db.AddParameter("p_MAC_ADDRESSES", pUserMaster.MACAddress)
                db.AddParameter("p_ErrorMsg", pUserMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUserMaster.Errormsg = ex.Message
            End Try
            Return pUserMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserMaster"></param>
        ''' <returns>Return pUserMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function ChangePassword(ByVal pUserMaster As UserMaster) As UserMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUserMaster.TerminalId)
                db.AddParameter("p_USER_ID", pUserMaster.UserId)
                db.AddParameter("p_PASSWORD", pUserMaster.Password)
                db.AddParameter("p_VALIDITY_DATE", pUserMaster.ValidityDate)
                db.AddParameter("p_USER_NAME", pUserMaster.UserName)
                db.AddParameter("p_DESIGNATION_ID", pUserMaster.DesignationId)
                db.AddParameter("p_DEPARTMENT_ID", pUserMaster.DepartmentId)
                db.AddParameter("p_EMAIL_ID", pUserMaster.EmailId)
                db.AddParameter("p_USER_TYPE", pUserMaster.UserType)
                db.AddParameter("p_USER_STATUS", pUserMaster.UserStatus)
                db.AddParameter("p_CUSTOMER_ID", pUserMaster.CustomerId)
                db.AddParameter("p_RESTRICTED_IP", pUserMaster.RestrictedIp)
                db.AddParameter("p_PASSWORD_EXPIRY", pUserMaster.PasswordExpiry)
                db.AddParameter("p_REMARKS", pUserMaster.Remarks)
                db.AddParameter("p_CREATED_BY", pUserMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUserMaster.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pUserMaster.CompanyId)
                db.AddParameter("p_ErrorMsg", pUserMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CHANGE_PASSWORD", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserMaster
        End Function
        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUserMaster As UserMaster) As UserMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PUserMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                PUserMaster.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD").ToString <> "" Then
                                PUserMaster.Password = dbr("PASSWORD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY_DATE").ToString <> "" Then
                                PUserMaster.ValidityDate = dbr("VALIDITY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_NAME").ToString <> "" Then
                                PUserMaster.UserName = dbr("USER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESIGNATION_ID").ToString <> "" Then
                                PUserMaster.DesignationId = dbr("DESIGNATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTMENT_ID").ToString <> "" Then
                                PUserMaster.DepartmentId = dbr("DEPARTMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                PUserMaster.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_TYPE").ToString <> "" Then
                                PUserMaster.UserType = dbr("USER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_STATUS").ToString <> "" Then
                                PUserMaster.UserStatus = dbr("USER_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pUserMaster.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RESTRICTED_IP").ToString <> "" Then
                                pUserMaster.RestrictedIp = dbr("RESTRICTED_IP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD_EXPIRY").ToString <> "" Then
                                pUserMaster.PasswordExpiry = dbr("PASSWORD_EXPIRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pUserMaster.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PUserMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PUserMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pUserMaster.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAC_ADDRESSES").ToString <> "" Then
                                pUserMaster.MACAddress = dbr("MAC_ADDRESSES")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pUserMaster.ErrorMsg = ex.Message
            End Try
            Return pUserMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUserMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UserMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                temp.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD").ToString <> "" Then
                                temp.Password = dbr("PASSWORD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY_DATE").ToString <> "" Then
                                temp.ValidityDate = dbr("VALIDITY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_NAME").ToString <> "" Then
                                temp.UserName = dbr("USER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESIGNATION_ID").ToString <> "" Then
                                temp.DesignationId = dbr("DESIGNATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTMENT_ID").ToString <> "" Then
                                temp.DepartmentId = dbr("DEPARTMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                temp.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_TYPE").ToString <> "" Then
                                temp.UserType = dbr("USER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_STATUS").ToString <> "" Then
                                temp.UserStatus = dbr("USER_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                temp.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RESTRICTED_IP").ToString <> "" Then
                                temp.RestrictedIp = dbr("RESTRICTED_IP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD_EXPIRY").ToString <> "" Then
                                temp.PasswordExpiry = dbr("PASSWORD_EXPIRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAC_ADDRESSES").ToString <> "" Then
                                temp.MACAddress = dbr("MAC_ADDRESSES")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Returns the UserMaster by UserId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnUserMaster(ByVal pUserMaster As UserMaster) As UserMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_MASTER_BY_ID", "'" & pUserMaster.UserId & "'," & pUserMaster.CompanyId)
                pUserMaster = ReturnObjectValues(dbr, pUserMaster)
                dbr.Close()
            Catch ex As Exception
                pUserMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUserMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUserMasterList(ByVal pUserMaster As UserMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_MASTER", "' '")
                arrUserMaster = ReturnObjectValuesList(dbr, arrUserMaster)
                dbr.Close()
            Catch ex As Exception
                arrUserMaster = Nothing
            End Try
            db.CloseDB()
            Return arrUserMaster
        End Function
    End Class
End Namespace
