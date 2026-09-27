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
    Public Class CustomerCallLog

        Private lngTerminalId As Long 'Define Private Variable TerminalId DataType As Long 
        Private lngCallLogId As Long ' Define Private Variable CallLogId DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId DataType As Long 
        Private strCallDate As String ' Define Private Variable CallDate DataType As String 
        Private strContactPerson As String ' Define Private Variable ContactPerson DataType As String 
        Private strApproachMethod As String ' Define Private Variable ApproachMethod DataType As String 
        Private strCallDetails As String ' Define Private Variable CallDetails DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn DataType As String 
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
        ''' CallLogId
        ''' </summary>
        ''' <value>lngCallLogId</value>
        ''' <returns> Return lngCallLogId</returns>
        ''' <remarks></remarks>
        Public Property CallLogId() As Long
            Get
                Return lngCallLogId
            End Get
            Set(ByVal value As Long)
                lngCallLogId = value
            End Set
        End Property


        ''' <summary>
        ''' CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks></remarks>
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property


        ''' <summary>
        ''' CallDate
        ''' </summary>
        ''' <value>strCallDate</value>
        ''' <returns> Return strCallDate</returns>
        ''' <remarks></remarks>
        Public Property CallDate() As String
            Get
                Return strCallDate
            End Get
            Set(ByVal value As String)
                strCallDate = value
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
        ''' ApproachMethod
        ''' </summary>
        ''' <value>strApproachMethod</value>
        ''' <returns> Return strApproachMethod</returns>
        ''' <remarks></remarks>
        Public Property ApproachMethod() As String
            Get
                Return strApproachMethod
            End Get
            Set(ByVal value As String)
                strApproachMethod = value
            End Set
        End Property


        ''' <summary>
        ''' CallDetails
        ''' </summary>
        ''' <value>strCallDetails</value>
        ''' <returns> Return strCallDetails</returns>
        ''' <remarks></remarks>
        Public Property CallDetails() As String
            Get
                Return strCallDetails
            End Get
            Set(ByVal value As String)
                strCallDetails = value
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
            lngTerminalId = 0
            lngCallLogId = 0
            lngCustomerId = 0
            strCallDate = ""
            strContactPerson = ""
            strApproachMethod = ""
            strCallDetails = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerCallLog"></param>
        ''' <returns>Return pCustomerCallLog Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerCallLog.lngTerminalId)
                db.AddParameter("p_CALL_LOG_ID", pCustomerCallLog.CallLogId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pCustomerCallLog.CustomerId)
                db.AddParameter("p_CALL_DATE", pCustomerCallLog.CallDate)
                db.AddParameter("p_CONTACT_PERSON", pCustomerCallLog.ContactPerson)
                db.AddParameter("p_APPROACH_METHOD", pCustomerCallLog.ApproachMethod)
                db.AddParameter("p_CALL_DETAILS", pCustomerCallLog.CallDetails)
                db.AddParameter("p_CREATED_BY", pCustomerCallLog.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerCallLog.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerCallLog.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_CALL_LOG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerCallLog.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerCallLog.CallLogId = db.Parameters.Item("p_CALL_LOG_ID").value

                If pCustomerCallLog.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerCallLog"></param>
        ''' <returns>Return pCustomerCallLog Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerCallLog.lngTerminalId)
                db.AddParameter("p_CALL_LOG_ID", pCustomerCallLog.CallLogId, ParameterDirection.Output)
                db.AddParameter("p_CUSTOMER_ID", pCustomerCallLog.CustomerId)
                db.AddParameter("p_CALL_DATE", pCustomerCallLog.CallDate)
                db.AddParameter("p_CONTACT_PERSON", pCustomerCallLog.ContactPerson)
                db.AddParameter("p_APPROACH_METHOD", pCustomerCallLog.ApproachMethod)
                db.AddParameter("p_CALL_DETAILS", pCustomerCallLog.CallDetails)
                db.AddParameter("p_CREATED_BY", pCustomerCallLog.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerCallLog.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerCallLog.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_CALL_LOG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerCallLog.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerCallLog.CallLogId = db.Parameters.Item("p_CALL_LOG_ID").value

            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
            End Try
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerCallLog"></param>
        ''' <returns>Return pCustomerCallLog Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerCallLog.lngTerminalId)
                db.AddParameter("p_CALL_LOG_ID", pCustomerCallLog.CallLogId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerCallLog.CustomerId)
                db.AddParameter("p_CALL_DATE", pCustomerCallLog.CallDate)
                db.AddParameter("p_CONTACT_PERSON", pCustomerCallLog.ContactPerson)
                db.AddParameter("p_APPROACH_METHOD", pCustomerCallLog.ApproachMethod)
                db.AddParameter("p_CALL_DETAILS", pCustomerCallLog.CallDetails)
                db.AddParameter("p_CREATED_BY", pCustomerCallLog.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerCallLog.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerCallLog.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_CALL_LOG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerCallLog.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerCallLog.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerCallLog"></param>
        ''' <returns>Return pCustomerCallLog Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerCallLog.lngTerminalId)
                db.AddParameter("p_CALL_LOG_ID", pCustomerCallLog.CallLogId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerCallLog.CustomerId)
                db.AddParameter("p_CALL_DATE", pCustomerCallLog.CallDate)
                db.AddParameter("p_CONTACT_PERSON", pCustomerCallLog.ContactPerson)
                db.AddParameter("p_APPROACH_METHOD", pCustomerCallLog.ApproachMethod)
                db.AddParameter("p_CALL_DETAILS", pCustomerCallLog.CallDetails)
                db.AddParameter("p_CREATED_BY", pCustomerCallLog.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerCallLog.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCustomerCallLog.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_CALL_LOG", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerCallLog.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
            End Try
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pCustomerCallLog.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("CALL_LOG_ID").ToString <> "" Then
                            pCustomerCallLog.CallLogId = dbr("CALL_LOG_ID")
                        End If
                        If dbr("CUSTOMER_ID").ToString <> "" Then
                            pCustomerCallLog.CustomerId = dbr("CUSTOMER_ID")
                        End If
                        If dbr("CALL_DATE").ToString <> "" Then
                            pCustomerCallLog.CallDate = dbr("CALL_DATE")
                        End If
                        If dbr("CONTACT_PERSON").ToString <> "" Then
                            pCustomerCallLog.ContactPerson = dbr("CONTACT_PERSON")
                        End If
                        If dbr("APPROACH_METHOD").ToString <> "" Then
                            pCustomerCallLog.ApproachMethod = dbr("APPROACH_METHOD")
                        End If
                        If dbr("CALL_DETAILS").ToString <> "" Then
                            pCustomerCallLog.CallDetails = dbr("CALL_DETAILS")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            pCustomerCallLog.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            pCustomerCallLog.CreatedOn = dbr("CREATED_ON")
                        End If
                    End While
                End If
            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
            End Try
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerCallLog As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerCallLog
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("CALL_LOG_ID").ToString <> "" Then
                            temp.CallLogId = dbr("CALL_LOG_ID")
                        End If
                        If dbr("CUSTOMER_ID").ToString <> "" Then
                            temp.CustomerId = dbr("CUSTOMER_ID")
                        End If
                        If dbr("CALL_DATE").ToString <> "" Then
                            temp.CallDate = dbr("CALL_DATE")
                        End If
                        If dbr("CONTACT_PERSON").ToString <> "" Then
                            temp.ContactPerson = dbr("CONTACT_PERSON")
                        End If
                        If dbr("APPROACH_METHOD").ToString <> "" Then
                            temp.ApproachMethod = dbr("APPROACH_METHOD")
                        End If
                        If dbr("CALL_DETAILS").ToString <> "" Then
                            temp.CallDetails = dbr("CALL_DETAILS")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            temp.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            temp.CreatedOn = dbr("CREATED_ON")
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
        Public Shared Function ReturnCustomerCallLog(ByVal pCustomerCallLog As CustomerCallLog) As CustomerCallLog
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_CALL_LOG", "' '")
                pCustomerCallLog = ReturnObjectValues(dbr, pCustomerCallLog)
                dbr.Close()
            Catch ex As Exception
                pCustomerCallLog.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerCallLog
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnCustomerCallLogList(ByVal pCustomerCallLog As CustomerCallLog) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerCallLog As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUST_CL_LOG_ALL_BY_CUST_ID", pCustomerCallLog.TerminalId & "," & pCustomerCallLog.CustomerId)
                arrCustomerCallLog = ReturnObjectValuesList(dbr, arrCustomerCallLog)
                dbr.Close()
            Catch ex As Exception
                arrCustomerCallLog = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerCallLog
        End Function
    End Class
End Namespace
