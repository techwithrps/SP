Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MailConfig
    ''' @author	: Amit K. Singh- 5/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MailConfig 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strFromName As String ' Define Private Variable FromName With DataType As String 
        Private strFromId As String ' Define Private Variable FromId With DataType As String 
        Private strSmtpServer As String ' Define Private Variable SmtpServer With DataType As String 
        Private strPortNo As String ' Define Private Variable PortNo With DataType As String 
        Private strPassword As String ' Define Private Variable Password With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() as Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FromName
        ''' </summary>
        ''' <value>strFromName</value>
        ''' <returns> Return strFromName</returns>
        ''' <remarks> Get or Set the Value of FromName  </remarks>
        '''
        Public Property FromName() as String
            Get
                Return strFromName
            End Get
            Set(ByVal value As String)
                strFromName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FromId
        ''' </summary>
        ''' <value>strFromId</value>
        ''' <returns> Return strFromId</returns>
        ''' <remarks> Get or Set the Value of FromId  </remarks>
        '''
        Public Property FromId() as String
            Get
                Return strFromId
            End Get
            Set(ByVal value As String)
                strFromId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SmtpServer
        ''' </summary>
        ''' <value>strSmtpServer</value>
        ''' <returns> Return strSmtpServer</returns>
        ''' <remarks> Get or Set the Value of SmtpServer  </remarks>
        '''
        Public Property SmtpServer() as String
            Get
                Return strSmtpServer
            End Get
            Set(ByVal value As String)
                strSmtpServer = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PortNo
        ''' </summary>
        ''' <value>strPortNo</value>
        ''' <returns> Return strPortNo</returns>
        ''' <remarks> Get or Set the Value of PortNo  </remarks>
        '''
        Public Property PortNo() as String
            Get
                Return strPortNo
            End Get
            Set(ByVal value As String)
                strPortNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Password
        ''' </summary>
        ''' <value>strPassword</value>
        ''' <returns> Return strPassword</returns>
        ''' <remarks> Get or Set the Value of Password  </remarks>
        '''
        Public Property Password() as String
            Get
                Return strPassword
            End Get
            Set(ByVal value As String)
                strPassword = value
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
            lngTerminalId = 0 
            strFromName = ""
            strFromId = ""
            strSmtpServer = ""
            strPortNo = ""
            strPassword = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMailConfig"></param>
        ''' <returns>Return pMailConfig Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMailConfig As MailConfig) As MailConfig
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailConfig.TerminalId)
                db.AddParameter("p_FROM_NAME", pMailConfig.FromName)
                db.AddParameter("p_FROM_ID", pMailConfig.FromId)
                db.AddParameter("p_SMTP_SERVER", pMailConfig.SmtpServer)
                db.AddParameter("p_PORT_NO", pMailConfig.PortNo)
                db.AddParameter("p_PASSWORD", pMailConfig.Password)
                db.AddParameter("p_ErrorMsg", pMailConfig.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MAIL_CONFIG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailConfig.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pMailConfig.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMailConfig.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMailConfig"></param>
        ''' <returns>Return pMailConfig Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMailConfig As MailConfig) As MailConfig
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailConfig.TerminalId)
                db.AddParameter("p_FROM_NAME", pMailConfig.FromName)
                db.AddParameter("p_FROM_ID", pMailConfig.FromId)
                db.AddParameter("p_SMTP_SERVER", pMailConfig.SmtpServer)
                db.AddParameter("p_PORT_NO", pMailConfig.PortNo)
                db.AddParameter("p_PASSWORD", pMailConfig.Password)
                db.AddParameter("p_ErrorMsg", pMailConfig.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MAIL_CONFIG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailConfig.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pMailConfig.ErrorMsg = ex.Message
            End Try
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMailConfig"></param>
        ''' <returns>Return pMailConfig Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMailConfig As MailConfig) As MailConfig
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailConfig.TerminalId)
                db.AddParameter("p_FROM_NAME", pMailConfig.FromName)
                db.AddParameter("p_FROM_ID", pMailConfig.FromId)
                db.AddParameter("p_SMTP_SERVER", pMailConfig.SmtpServer)
                db.AddParameter("p_PORT_NO", pMailConfig.PortNo)
                db.AddParameter("p_PASSWORD", pMailConfig.Password)
                db.AddParameter("p_ErrorMsg", pMailConfig.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MAIL_CONFIG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailConfig.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMailConfig.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMailConfig.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMailConfig"></param>
        ''' <returns>Return pMailConfig Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMailConfig As MailConfig) As MailConfig
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailConfig.TerminalId)
                db.AddParameter("p_FROM_NAME", pMailConfig.FromName)
                db.AddParameter("p_FROM_ID", pMailConfig.FromId)
                db.AddParameter("p_SMTP_SERVER", pMailConfig.SmtpServer)
                db.AddParameter("p_PORT_NO", pMailConfig.PortNo)
                db.AddParameter("p_PASSWORD", pMailConfig.Password)
                db.AddParameter("p_ErrorMsg", pMailConfig.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MAIL_CONFIG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailConfig.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMailConfig.ErrorMsg = ex.Message
                End Try
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMailConfig As MailConfig) As MailConfig
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMailConfig.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_NAME").ToString <> "" Then
                                PMailConfig.FromName = dbr("FROM_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_ID").ToString <> "" Then
                                PMailConfig.FromId = dbr("FROM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SMTP_SERVER").ToString <> "" Then
                                PMailConfig.SmtpServer = dbr("SMTP_SERVER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_NO").ToString <> "" Then
                                PMailConfig.PortNo = dbr("PORT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD").ToString <> "" Then
                                PMailConfig.Password = dbr("PASSWORD")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMailConfig.ErrorMsg = ex.Message
            End Try
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMailConfig As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MailConfig
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_NAME").ToString <> "" Then
                                temp.FromName = dbr("FROM_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_ID").ToString <> "" Then
                                temp.FromId = dbr("FROM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SMTP_SERVER").ToString <> "" Then
                                temp.SmtpServer = dbr("SMTP_SERVER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_NO").ToString <> "" Then
                                temp.PortNo = dbr("PORT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PASSWORD").ToString <> "" Then
                                temp.Password = dbr("PASSWORD")
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
        Public Shared Function ReturnMailConfig(ByVal pMailConfig As MailConfig) As MailConfig
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_CONFIG_BY_ID", pMailConfig.TerminalId)
                pMailConfig = ReturnObjectValues(dbr, pMailConfig)
                dbr.Close()
            Catch ex As Exception
                pMailConfig.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMailConfig
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMailConfigList (ByVal pMailConfig As MailConfig) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMailConfig As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_CONFIG", "' '")
                arrMailConfig = ReturnObjectValuesList(dbr, arrMailConfig)
                dbr.Close()
            Catch ex As Exception
                arrMailConfig = Nothing
            End Try
            db.CloseDB()
            Return arrMailConfig
        End Function
    End Class
End Namespace
