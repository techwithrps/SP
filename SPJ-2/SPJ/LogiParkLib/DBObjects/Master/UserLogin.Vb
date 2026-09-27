Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UserLogin
    ''' @author	: Amit K. Singh- 16/8/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UserLogin 
    
        Private lngTrnId As Long ' Define Private Variable TrnId With DataType As Long 
        Private strUserId As String ' Define Private Variable UserId With DataType As String 
        Private strUserName As String ' Define Private Variable UserName With DataType As String 
        Private strUserType As String ' Define Private Variable UserType With DataType As String 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private strLoginDate As String ' Define Private Variable LoginDate With DataType As String 
        Private strLogoutDate As String ' Define Private Variable LogoutDate With DataType As String 
        Private strIpAddress As String ' Define Private Variable IpAddress With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

        ''' <summary>
        ''' Get or Set the Value of TrnId
        ''' </summary>
        ''' <value>lngTrnId</value>
        ''' <returns> Return lngTrnId</returns>
        ''' <remarks> Get or Set the Value of TrnId  </remarks>
        '''
        Public Property TrnId() As Long
            Get
                Return lngTrnId
            End Get
            Set(ByVal value As Long)
                lngTrnId = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of UserId
        ''' </summary>
        ''' <value>strUserId</value>
        ''' <returns> Return strUserId</returns>
        ''' <remarks> Get or Set the Value of UserId  </remarks>
        '''
        Public Property UserId() as String
            Get
                Return strUserId
            End Get
            Set(ByVal value As String)
                strUserId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of UserName
        ''' </summary>
        ''' <value>strUserName</value>
        ''' <returns> Return strUserName</returns>
        ''' <remarks> Get or Set the Value of UserName  </remarks>
        '''
        Public Property UserName() as String
            Get
                Return strUserName
            End Get
            Set(ByVal value As String)
                strUserName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of UserType
        ''' </summary>
        ''' <value>strUserType</value>
        ''' <returns> Return strUserType</returns>
        ''' <remarks> Get or Set the Value of UserType  </remarks>
        '''
        Public Property UserType() as String
            Get
                Return strUserType
            End Get
            Set(ByVal value As String)
                strUserType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() as Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LoginDate
        ''' </summary>
        ''' <value>strLoginDate</value>
        ''' <returns> Return strLoginDate</returns>
        ''' <remarks> Get or Set the Value of LoginDate  </remarks>
        '''
        Public Property LoginDate() as String
            Get
                Return strLoginDate
            End Get
            Set(ByVal value As String)
                strLoginDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LogoutDate
        ''' </summary>
        ''' <value>strLogoutDate</value>
        ''' <returns> Return strLogoutDate</returns>
        ''' <remarks> Get or Set the Value of LogoutDate  </remarks>
        '''
        Public Property LogoutDate() as String
            Get
                Return strLogoutDate
            End Get
            Set(ByVal value As String)
                strLogoutDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IpAddress
        ''' </summary>
        ''' <value>strIpAddress</value>
        ''' <returns> Return strIpAddress</returns>
        ''' <remarks> Get or Set the Value of IpAddress  </remarks>
        '''
        Public Property IpAddress() as String
            Get
                Return strIpAddress
            End Get
            Set(ByVal value As String)
                strIpAddress = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() as String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() as String
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
            lngTrnId = 0
            strUserId = ""
            strUserName = ""
            strUserType = ""
            lngCustomerId = 0
            strLoginDate = ""
            strLogoutDate = ""
            strIpAddress = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUserLogin"></param>
        ''' <returns>Return pUserLogin Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUserLogin As UserLogin) As UserLogin
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRN_ID", pUserLogin.TrnId, ParameterDirection.Output)
                db.AddParameter("p_USER_ID", pUserLogin.UserId)
                db.AddParameter("p_USER_NAME", pUserLogin.UserName)
                db.AddParameter("p_USER_TYPE", pUserLogin.UserType)
                db.AddParameter("p_CUSTOMER_ID", pUserLogin.CustomerId)
                db.AddParameter("p_LOGIN_DATE", pUserLogin.LoginDate)
                db.AddParameter("p_LOGOUT_DATE", pUserLogin.LogoutDate)
                db.AddParameter("p_IP_ADDRESS", pUserLogin.IpAddress)
                db.AddParameter("p_CREATED_ON", pUserLogin.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUserLogin.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_LOGIN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserLogin.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUserLogin.TrnId = db.Parameters.Item("p_TRN_ID").value
                If pUserLogin.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserLogin.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserLogin"></param>
        ''' <returns>Return pUserLogin Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUserLogin As UserLogin) As UserLogin
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserLogin.UserId)
                db.AddParameter("p_USER_NAME", pUserLogin.UserName)
                db.AddParameter("p_USER_TYPE", pUserLogin.UserType)
                db.AddParameter("p_CUSTOMER_ID", pUserLogin.CustomerId)
                db.AddParameter("p_LOGIN_DATE", pUserLogin.LoginDate)
                db.AddParameter("p_LOGOUT_DATE", pUserLogin.LogoutDate)
                db.AddParameter("p_IP_ADDRESS", pUserLogin.IpAddress)
                db.AddParameter("p_CREATED_ON", pUserLogin.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUserLogin.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_LOGIN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserLogin.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pUserLogin.ErrorMsg = ex.Message
            End Try
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserLogin"></param>
        ''' <returns>Return pUserLogin Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUserLogin As UserLogin) As UserLogin
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRN_ID", pUserLogin.TrnId)
                db.AddParameter("p_USER_ID", pUserLogin.UserId)
                db.AddParameter("p_USER_NAME", pUserLogin.UserName)
                db.AddParameter("p_USER_TYPE", pUserLogin.UserType)
                db.AddParameter("p_CUSTOMER_ID", pUserLogin.CustomerId)
                db.AddParameter("p_LOGIN_DATE", pUserLogin.LoginDate)
                db.AddParameter("p_LOGOUT_DATE", pUserLogin.LogoutDate)
                db.AddParameter("p_IP_ADDRESS", pUserLogin.IpAddress)
                db.AddParameter("p_CREATED_ON", pUserLogin.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUserLogin.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_LOGIN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserLogin.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserLogin.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserLogin.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserLogin"></param>
        ''' <returns>Return pUserLogin Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUserLogin As UserLogin) As UserLogin
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserLogin.UserId)
                db.AddParameter("p_USER_NAME", pUserLogin.UserName)
                db.AddParameter("p_USER_TYPE", pUserLogin.UserType)
                db.AddParameter("p_CUSTOMER_ID", pUserLogin.CustomerId)
                db.AddParameter("p_LOGIN_DATE", pUserLogin.LoginDate)
                db.AddParameter("p_LOGOUT_DATE", pUserLogin.LogoutDate)
                db.AddParameter("p_IP_ADDRESS", pUserLogin.IpAddress)
                db.AddParameter("p_CREATED_ON", pUserLogin.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUserLogin.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_LOGIN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserLogin.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pUserLogin.ErrorMsg = ex.Message
                End Try
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUserLogin As UserLogin) As UserLogin
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                PUserLogin.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_NAME").ToString <> "" Then
                                PUserLogin.UserName = dbr("USER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_TYPE").ToString <> "" Then
                                PUserLogin.UserType = dbr("USER_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PUserLogin.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOGIN_DATE").ToString <> "" Then
                                PUserLogin.LoginDate = dbr("LOGIN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOGOUT_DATE").ToString <> "" Then
                                PUserLogin.LogoutDate = dbr("LOGOUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IP_ADDRESS").ToString <> "" Then
                                PUserLogin.IpAddress = dbr("IP_ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PUserLogin.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pUserLogin.ErrorMsg = ex.Message
            End Try
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUserLogin As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UserLogin
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                temp.UserId = dbr("USER_ID")
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
                            If dbr("USER_TYPE").ToString <> "" Then
                                temp.UserType = dbr("USER_TYPE")
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
                            If dbr("LOGIN_DATE").ToString <> "" Then
                                temp.LoginDate = dbr("LOGIN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOGOUT_DATE").ToString <> "" Then
                                temp.LogoutDate = dbr("LOGOUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IP_ADDRESS").ToString <> "" Then
                                temp.IpAddress = dbr("IP_ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                end If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnUserLogin(ByVal pUserLogin As UserLogin) As UserLogin
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_LOGIN", "' '")
                pUserLogin = ReturnObjectValues(dbr, pUserLogin)
                dbr.Close()
            Catch ex As Exception
                pUserLogin.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUserLogin
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUserLoginList (ByVal pUserLogin As UserLogin) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserLogin As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_LOGIN", "' '")
                arrUserLogin = ReturnObjectValuesList(dbr, arrUserLogin)
                dbr.Close()
            Catch ex As Exception
                arrUserLogin = Nothing
            End Try
            db.CloseDB()
            Return arrUserLogin
        End Function
    End Class
End Namespace
