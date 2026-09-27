Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MailSetup
    ''' @author	: Amit K. Singh- 5/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MailSetup

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMenuId As Double ' Define Private Variable MenuId With DataType As Long 
        Private strFromMailId As String ' Define Private Variable FromMailId With DataType As String 
        Private strToMailIds As String ' Define Private Variable ToMailIds With DataType As String 
        Private strCcIds As String ' Define Private Variable CcIds With DataType As String 
        Private strBccIds As String ' Define Private Variable BccIds With DataType As String 
        Private strSubject As String ' Define Private Variable Subject With DataType As String 
        Private strMailBody As String ' Define Private Variable MailBody With DataType As String 
        Private strSignature As String ' Define Private Variable Signature With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


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
        ''' Get or Set the Value of MenuId
        ''' </summary>
        ''' <value>lngMenuId</value>
        ''' <returns> Return lngMenuId</returns>
        ''' <remarks> Get or Set the Value of MenuId  </remarks>
        '''
        Public Property MenuId() As Double
            Get
                Return lngMenuId
            End Get
            Set(ByVal value As Double)
                lngMenuId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FromMailId
        ''' </summary>
        ''' <value>strFromMailId</value>
        ''' <returns> Return strFromMailId</returns>
        ''' <remarks> Get or Set the Value of FromMailId  </remarks>
        '''
        Public Property FromMailId() As String
            Get
                Return strFromMailId
            End Get
            Set(ByVal value As String)
                strFromMailId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ToMailIds
        ''' </summary>
        ''' <value>strToMailIds</value>
        ''' <returns> Return strToMailIds</returns>
        ''' <remarks> Get or Set the Value of ToMailIds  </remarks>
        '''
        Public Property ToMailIds() As String
            Get
                Return strToMailIds
            End Get
            Set(ByVal value As String)
                strToMailIds = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CcIds
        ''' </summary>
        ''' <value>strCcIds</value>
        ''' <returns> Return strCcIds</returns>
        ''' <remarks> Get or Set the Value of CcIds  </remarks>
        '''
        Public Property CcIds() As String
            Get
                Return strCcIds
            End Get
            Set(ByVal value As String)
                strCcIds = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BccIds
        ''' </summary>
        ''' <value>strBccIds</value>
        ''' <returns> Return strBccIds</returns>
        ''' <remarks> Get or Set the Value of BccIds  </remarks>
        '''
        Public Property BccIds() As String
            Get
                Return strBccIds
            End Get
            Set(ByVal value As String)
                strBccIds = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Subject
        ''' </summary>
        ''' <value>strSubject</value>
        ''' <returns> Return strSubject</returns>
        ''' <remarks> Get or Set the Value of Subject  </remarks>
        '''
        Public Property Subject() As String
            Get
                Return strSubject
            End Get
            Set(ByVal value As String)
                strSubject = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MailBody
        ''' </summary>
        ''' <value>strMailBody</value>
        ''' <returns> Return strMailBody</returns>
        ''' <remarks> Get or Set the Value of MailBody  </remarks>
        '''
        Public Property MailBody() As String
            Get
                Return strMailBody
            End Get
            Set(ByVal value As String)
                strMailBody = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Signature
        ''' </summary>
        ''' <value>strSignature</value>
        ''' <returns> Return strSignature</returns>
        ''' <remarks> Get or Set the Value of Signature  </remarks>
        '''
        Public Property Signature() As String
            Get
                Return strSignature
            End Get
            Set(ByVal value As String)
                strSignature = value
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
            lngMenuId = 0.0
            strFromMailId = ""
            strToMailIds = ""
            strCcIds = ""
            strBccIds = ""
            strSubject = ""
            strMailBody = ""
            strSignature = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMailSetup"></param>
        ''' <returns>Return pMailSetup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMailSetup As MailSetup) As MailSetup
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailSetup.TerminalId)
                db.AddParameter("p_MENU_ID", pMailSetup.MenuId)
                db.AddParameter("p_FROM_MAIL_ID", pMailSetup.FromMailId)
                db.AddParameter("p_TO_MAIL_IDS", pMailSetup.ToMailIds)
                db.AddParameter("p_CC_IDS", pMailSetup.CcIds)
                db.AddParameter("p_BCC_IDS", pMailSetup.BccIds)
                db.AddParameter("p_SUBJECT", pMailSetup.Subject)
                db.AddParameter("p_MAIL_BODY", pMailSetup.MailBody)
                db.AddParameter("p_SIGNATURE", pMailSetup.Signature)
                db.AddParameter("p_ErrorMsg", pMailSetup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MAIL_SETUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailSetup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pMailSetup.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMailSetup"></param>
        ''' <returns>Return pMailSetup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMailSetup As MailSetup) As MailSetup
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailSetup.TerminalId)
                db.AddParameter("p_MENU_ID", pMailSetup.MenuId)
                db.AddParameter("p_FROM_MAIL_ID", pMailSetup.FromMailId)
                db.AddParameter("p_TO_MAIL_IDS", pMailSetup.ToMailIds)
                db.AddParameter("p_CC_IDS", pMailSetup.CcIds)
                db.AddParameter("p_BCC_IDS", pMailSetup.BccIds)
                db.AddParameter("p_SUBJECT", pMailSetup.Subject)
                db.AddParameter("p_MAIL_BODY", pMailSetup.MailBody)
                db.AddParameter("p_SIGNATURE", pMailSetup.Signature)
                db.AddParameter("p_ErrorMsg", pMailSetup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MAIL_SETUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailSetup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
            End Try
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMailSetup"></param>
        ''' <returns>Return pMailSetup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMailSetup As MailSetup) As MailSetup
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailSetup.TerminalId)
                db.AddParameter("p_MENU_ID", pMailSetup.MenuId)
                db.AddParameter("p_FROM_MAIL_ID", pMailSetup.FromMailId)
                db.AddParameter("p_TO_MAIL_IDS", pMailSetup.ToMailIds)
                db.AddParameter("p_CC_IDS", pMailSetup.CcIds)
                db.AddParameter("p_BCC_IDS", pMailSetup.BccIds)
                db.AddParameter("p_SUBJECT", pMailSetup.Subject)
                db.AddParameter("p_MAIL_BODY", pMailSetup.MailBody)
                db.AddParameter("p_SIGNATURE", pMailSetup.Signature)
                db.AddParameter("p_ErrorMsg", pMailSetup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MAIL_SETUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailSetup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMailSetup.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMailSetup"></param>
        ''' <returns>Return pMailSetup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMailSetup As MailSetup) As MailSetup
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMailSetup.TerminalId)
                db.AddParameter("p_MENU_ID", pMailSetup.MenuId)
                db.AddParameter("p_FROM_MAIL_ID", pMailSetup.FromMailId)
                db.AddParameter("p_TO_MAIL_IDS", pMailSetup.ToMailIds)
                db.AddParameter("p_CC_IDS", pMailSetup.CcIds)
                db.AddParameter("p_BCC_IDS", pMailSetup.BccIds)
                db.AddParameter("p_SUBJECT", pMailSetup.Subject)
                db.AddParameter("p_MAIL_BODY", pMailSetup.MailBody)
                db.AddParameter("p_SIGNATURE", pMailSetup.Signature)
                db.AddParameter("p_ErrorMsg", pMailSetup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MAIL_SETUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMailSetup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
            End Try
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMailSetup As MailSetup) As MailSetup
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMailSetup.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                PMailSetup.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_MAIL_ID").ToString <> "" Then
                                PMailSetup.FromMailId = dbr("FROM_MAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_MAIL_IDS").ToString <> "" Then
                                PMailSetup.ToMailIds = dbr("TO_MAIL_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CC_IDS").ToString <> "" Then
                                PMailSetup.CcIds = dbr("CC_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BCC_IDS").ToString <> "" Then
                                PMailSetup.BccIds = dbr("BCC_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SUBJECT").ToString <> "" Then
                                PMailSetup.Subject = dbr("SUBJECT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAIL_BODY").ToString <> "" Then
                                PMailSetup.MailBody = dbr("MAIL_BODY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SIGNATURE").ToString <> "" Then
                                PMailSetup.Signature = dbr("SIGNATURE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
            End Try
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMailSetup As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MailSetup
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("FROM_MAIL_ID").ToString <> "" Then
                                temp.FromMailId = dbr("FROM_MAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_MAIL_IDS").ToString <> "" Then
                                temp.ToMailIds = dbr("TO_MAIL_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CC_IDS").ToString <> "" Then
                                temp.CcIds = dbr("CC_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BCC_IDS").ToString <> "" Then
                                temp.BccIds = dbr("BCC_IDS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SUBJECT").ToString <> "" Then
                                temp.Subject = dbr("SUBJECT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAIL_BODY").ToString <> "" Then
                                temp.MailBody = dbr("MAIL_BODY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SIGNATURE").ToString <> "" Then
                                temp.Signature = dbr("SIGNATURE")
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
        ''' Preparing Return Object By TerminalId, MenuId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMailSetupByMenuId(ByVal pMailSetup As MailSetup) As MailSetup
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_SETUP_BY_ID", pMailSetup.MenuId & "," & pMailSetup.TerminalId)
                pMailSetup = ReturnObjectValues(dbr, pMailSetup)
                dbr.Close()
            Catch ex As Exception
                pMailSetup.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMailSetup
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMailSetupList(ByVal pMailSetup As MailSetup) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMailSetup As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_SETUP", "' '")
                arrMailSetup = ReturnObjectValuesList(dbr, arrMailSetup)
                dbr.Close()
            Catch ex As Exception
                arrMailSetup = Nothing
            End Try
            db.CloseDB()
            Return arrMailSetup
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnMailSetup(ByVal pMailSetup As MailSetup) As MailSetup
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_SETUP_BY_ID", pMailSetup.MenuId & "," & pMailSetup.TerminalId)
                pMailSetup = ReturnObjectValues(dbr, pMailSetup)
                dbr.Close()
            Catch ex As Exception
                pMailSetup.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMailSetup
        End Function
    End Class
End Namespace
