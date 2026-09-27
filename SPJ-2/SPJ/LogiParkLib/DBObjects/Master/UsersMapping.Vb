Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UsersMapping
    ''' @author	: Santosh Singh- 23/4/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UsersMapping 
    
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private strUserId As String ' Define Private Variable UserId With DataType As String 
        Private strMappedUser As String ' Define Private Variable MappedUser With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngCompanyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() as Long
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
        Public Property UserId() as String
            Get
                Return strUserId
            End Get
            Set(ByVal value As String)
                strUserId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MappedUser
        ''' </summary>
        ''' <value>strMappedUser</value>
        ''' <returns> Return strMappedUser</returns>
        ''' <remarks> Get or Set the Value of MappedUser  </remarks>
        '''
        Public Property MappedUser() as String
            Get
                Return strMappedUser
            End Get
            Set(ByVal value As String)
                strMappedUser = value
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
            lngCompanyId = 0 
            strUserId = ""
            strMappedUser = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUsersMapping"></param>
        ''' <returns>Return pUsersMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUsersMapping As UsersMapping) As UsersMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pUsersMapping.CompanyId)
                db.AddParameter("p_USER_ID", pUsersMapping.UserId)
                db.AddParameter("p_MAPPED_USER", pUsersMapping.MappedUser)
                db.AddParameter("p_ErrorMsg", pUsersMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USERS_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUsersMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pUsersMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUsersMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUsersMapping"></param>
        ''' <returns>Return pUsersMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUsersMapping As UsersMapping) As UsersMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pUsersMapping.CompanyId)
                db.AddParameter("p_USER_ID", pUsersMapping.UserId)
                db.AddParameter("p_MAPPED_USER", pUsersMapping.MappedUser)
                db.AddParameter("p_ErrorMsg", pUsersMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USERS_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUsersMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pUsersMapping.ErrorMsg = ex.Message
            End Try
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUsersMapping"></param>
        ''' <returns>Return pUsersMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUsersMapping As UsersMapping) As UsersMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pUsersMapping.CompanyId)
                db.AddParameter("p_USER_ID", pUsersMapping.UserId)
                db.AddParameter("p_MAPPED_USER", pUsersMapping.MappedUser)
                db.AddParameter("p_ErrorMsg", pUsersMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USERS_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUsersMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUsersMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUsersMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUsersMapping"></param>
        ''' <returns>Return pUsersMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUsersMapping As UsersMapping) As UsersMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pUsersMapping.CompanyId)
                db.AddParameter("p_USER_ID", pUsersMapping.UserId)
                db.AddParameter("p_MAPPED_USER", pUsersMapping.MappedUser)
                db.AddParameter("p_ErrorMsg", pUsersMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USERS_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUsersMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pUsersMapping.ErrorMsg = ex.Message
                End Try
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUsersMapping As UsersMapping) As UsersMapping
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                PUsersMapping.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                PUsersMapping.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAPPED_USER").ToString <> "" Then
                                PUsersMapping.MappedUser = dbr("MAPPED_USER")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pUsersMapping.ErrorMsg = ex.Message
            End Try
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUsersMapping As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UsersMapping
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
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
                            If dbr("MAPPED_USER").ToString <> "" Then
                                temp.MappedUser = dbr("MAPPED_USER")
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
        Public Shared Function ReturnUsersMapping(ByVal pUsersMapping As UsersMapping) As UsersMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_COMPANY_USER_ID", " '" & pUsersMapping.MappedUser & "'" & ",'" & pUsersMapping.UserId & "'")
                pUsersMapping = ReturnObjectValues(dbr, pUsersMapping)
                dbr.Close()
            Catch ex As Exception
                pUsersMapping.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUsersMapping
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUsersMappingList(ByVal pUsersMapping As UsersMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUsersMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_MAP_ALL_BY_USER_ID", "'" & pUsersMapping.UserId & "'" & ",'" & pUsersMapping.MappedUser & "'")
                arrUsersMapping = ReturnObjectValuesList(dbr, arrUsersMapping)
                dbr.Close()
            Catch ex As Exception
                arrUsersMapping = Nothing
            End Try
            db.CloseDB()
            Return arrUsersMapping
        End Function
        Public Shared Function ReturnUserUserListAssigned(ByVal pUsersMapping As UsersMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_COMP_ASSIGN_BY_USER_ID", "'" & pUsersMapping.UserId & "'")
                arrUserMapping = ReturnObjectValuesList(dbr, arrUserMapping)
                dbr.Close()
            Catch ex As Exception
                arrUserMapping = Nothing
            End Try
            db.CloseDB()
            Return arrUserMapping
        End Function
    End Class
End Namespace
