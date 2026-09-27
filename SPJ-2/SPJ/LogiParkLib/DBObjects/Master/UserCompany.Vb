Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UserCompany
    ''' @author	: Santosh Singh- 21/4/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UserCompany 
    
        Private strUserId As String ' Define Private Variable UserId With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strCompanyName As String ' Define Private Variable UserId With DataType As String 

                    
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
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property CompanyName() As String
            Get
                Return strCompanyName
            End Get
            Set(ByVal value As String)
                strCompanyName = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            strUserId = ""
            lngCompanyId = 0 
            strErrormsg = ""
            strCompanyName = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUserCompany"></param>
        ''' <returns>Return pUserCompany Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUserCompany As UserCompany) As UserCompany
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserCompany.UserId)
                db.AddParameter("p_COMPANY_ID", pUserCompany.CompanyId)
                db.AddParameter("p_ErrorMsg", pUserCompany.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_COMPANY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserCompany.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pUserCompany.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserCompany.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserCompany"></param>
        ''' <returns>Return pUserCompany Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUserCompany As UserCompany) As UserCompany
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserCompany.UserId)
                db.AddParameter("p_COMPANY_ID", pUserCompany.CompanyId)
                db.AddParameter("p_ErrorMsg", pUserCompany.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_USER_COMPANY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserCompany.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pUserCompany.ErrorMsg = ex.Message
            End Try
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUserCompany"></param>
        ''' <returns>Return pUserCompany Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUserCompany As UserCompany) As UserCompany
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserCompany.UserId)
                db.AddParameter("p_COMPANY_ID", pUserCompany.CompanyId)
                db.AddParameter("p_ErrorMsg", pUserCompany.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_COMPANY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserCompany.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUserCompany.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUserCompany.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUserCompany"></param>
        ''' <returns>Return pUserCompany Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUserCompany As UserCompany) As UserCompany
            Try
                db.ClearParameters()
                db.AddParameter("p_USER_ID", pUserCompany.UserId)
                db.AddParameter("p_COMPANY_ID", pUserCompany.CompanyId)
                db.AddParameter("p_ErrorMsg", pUserCompany.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_USER_COMPANY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUserCompany.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pUserCompany.ErrorMsg = ex.Message
                End Try
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUserCompany As UserCompany) As UserCompany
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                PUserCompany.UserId = dbr("USER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                PUserCompany.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_NAME").ToString <> "" Then
                                pUserCompany.CompanyName = dbr("COMPANY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pUserCompany.ErrorMsg = ex.Message
            End Try
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUserCompany As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UserCompany
                        Try
                            If dbr("USER_ID").ToString <> "" Then
                                temp.UserId = dbr("USER_ID")
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
                            If dbr("COMPANY_NAME").ToString <> "" Then
                                temp.CompanyName = dbr("COMPANY_NAME")
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
        Public Shared Function ReturnUserCompany(ByVal pUserCompany As UserCompany) As UserCompany
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_COMPANY_USER_ID", pUserCompany.CompanyId & ",'" & pUserCompany.UserId & "'")
                pUserCompany = ReturnObjectValues(dbr, pUserCompany)
                dbr.Close()
            Catch ex As Exception
                pUserCompany.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUserCompany
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUserCompanyList(ByVal pUserCompany As UserCompany) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserCompany As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_COMP_ALL_BY_USER_ID", "'" & pUserCompany.UserId & "'")
                arrUserCompany = ReturnObjectValuesList(dbr, arrUserCompany)
                dbr.Close()
            Catch ex As Exception
                arrUserCompany = Nothing
            End Try
            db.CloseDB()
            Return arrUserCompany
        End Function
        Public Shared Function ReturnUserCompanyListAssigned(ByVal pUserComapny As UserCompany) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUserCompany As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_USER_COMP_ASSIGN_BY_USER_ID", "'" & pUserComapny.UserId & "'")
                arrUserCompany = ReturnObjectValuesList(dbr, arrUserCompany)
                dbr.Close()
            Catch ex As Exception
                arrUserCompany = Nothing
            End Try
            db.CloseDB()
            Return arrUserCompany
        End Function
    End Class
End Namespace
