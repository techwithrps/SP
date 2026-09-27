Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TaxHeadMaster
    ''' @author	: Amit K. Singh- 9/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CustomerMails
        Private lngCustomerMailId As Long ' Define Private Variable TaxHeadId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable TaxHeadName With DataType As String 
        Private lngMenuid As Long ' Define Private Variable MapCode With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strCustomerName As String
        Private strEmailId As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property

        Public Property CustomerMailId() As Long
            Get
                Return lngCustomerMailId
            End Get
            Set(ByVal value As Long)
                lngCustomerMailId = value
            End Set
        End Property
        Public Property MenuId() As Long
            Get
                Return lngMenuid
            End Get
            Set(ByVal value As Long)
                lngMenuid = value
            End Set
        End Property
        Public Property EmailId() As String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
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
        Public Property CustoMername() As String
            Get
                Return strCustomerName
            End Get
            Set(ByVal value As String)
                strCustomerName = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngCustomerId = 0
            lngCustomerMailId = 0
            lngMenuid = 0
            strEmailId = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strCustomerName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerMails"></param>
        ''' <returns>Return pCustomerMails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCustomerMails As CustomerMails) As CustomerMails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CUSTOMER_MAIL_ID", pCustomerMails.CustomerMailId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMails.CustomerId)
                db.AddParameter("p_MENU_ID", pCustomerMails.MenuId)
                db.AddParameter("p_EMAIL_ID", pCustomerMails.EmailId)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMails.CustoMername)
                db.AddParameter("p_CREATED_BY", pCustomerMails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerMails.CustomerMailId = db.Parameters.Item("p_CUSTOMER_MAIL_ID").value

                If pCustomerMails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMails"></param>
        ''' <returns>Return pCustomerMails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerMails As CustomerMails) As CustomerMails
            Try
                db.ClearParameters()
                db.AddParameter("p_CUSTOMER_MAIL_ID", pCustomerMails.CustomerMailId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMails.CustomerId)
                db.AddParameter("p_MENU_ID", pCustomerMails.MenuId)
                db.AddParameter("p_EMAIL_ID", pCustomerMails.EmailId)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMails.CustoMername)
                db.AddParameter("p_CREATED_BY", pCustomerMails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_MAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pCustomerMails.CustomerMailId = db.Parameters.Item("p_CUSTOMER_MAIL_ID").value
                End If


            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
            End Try
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerMails"></param>
        ''' <returns>Return pCustomerMails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCustomerMails As CustomerMails) As CustomerMails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CUSTOMER_MAIL_ID", pCustomerMails.CustomerMailId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMails.CustomerId)
                db.AddParameter("p_MENU_ID", pCustomerMails.MenuId)
                db.AddParameter("p_EMAIL_ID", pCustomerMails.EmailId)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMails.CustoMername)
                db.AddParameter("p_CREATED_BY", pCustomerMails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerMails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerMails"></param>
        ''' <returns>Return pCustomerMails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerMails As CustomerMails) As CustomerMails
            Try
                db.ClearParameters()
                db.AddParameter("p_CUSTOMER_MAIL_ID", pCustomerMails.CustomerMailId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerMails.CustomerId)
                db.AddParameter("p_MENU_ID", pCustomerMails.MenuId)
                db.AddParameter("p_EMAIL_ID", pCustomerMails.EmailId)
                db.AddParameter("p_CUSTOMER_NAME", pCustomerMails.CustoMername)
                db.AddParameter("p_CREATED_BY", pCustomerMails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerMails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerMails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_MAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerMails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
            End Try
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerMails As CustomerMails) As CustomerMails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CUSTOMER_MAIL_ID").ToString <> "" Then
                                pCustomerMails.CustomerMailId = dbr("CUSTOMER_MAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pCustomerMails.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                pCustomerMails.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                pCustomerMails.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pCustomerMails.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pCustomerMails.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_NAME").ToString <> "" Then
                                pCustomerMails.CustoMername = dbr("CUSTOMER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
            End Try
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerMails As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerMails
                        Try
                            If dbr("CUSTOMER_MAIL_ID").ToString <> "" Then
                                temp.CustomerMailId = dbr("CUSTOMER_MAIL_ID")
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
                            If dbr("MENU_ID").ToString <> "" Then
                                temp.MenuId = dbr("MENU_ID")
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
                            If dbr("CUSTOMER_NAME").ToString <> "" Then
                                temp.CustoMername = dbr("CUSTOMER_NAME")
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
        ''' Preparing Return Object by TerminalId, TaxHeadId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomersmails(ByVal pCustomerMails As CustomerMails) As CustomerMails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTMOR_MAILS", pCustomerMails.CustomerMailId)
                pCustomerMails = ReturnObjectValues(dbr, pCustomerMails)
                dbr.Close()
            Catch ex As Exception
                pCustomerMails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerMails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerMailsList(ByVal pCustomerMails As CustomerMails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTaxHeadMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAIL_ALL", "")
                arrTaxHeadMaster = ReturnObjectValuesList(dbr, arrTaxHeadMaster)
                dbr.Close()
            Catch ex As Exception
                arrTaxHeadMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTaxHeadMaster
        End Function
    End Class
End Namespace
