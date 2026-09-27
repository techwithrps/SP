Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DamageCode
    ''' @author	: Amit K. Singh- 05/07/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class StateCodeMaster

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngStateId As Long ' Define Private Variable StateId With DataType As Long 
        Private strStateCode As String ' Define Private Variable StateCode With DataType As String 
        Private strStateName As String ' Define Private Variable StateName With DataType As String 
        Private strStateCapital As String ' Define Private Variable StateCapital With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strGSTN As String ' Define Private Variable GSTN With DataType As String 
        Private strStateAddress As String ' Define Private Variable StateAddress With DataType As String 
        Private strActiveStatus As String ' Define Private Variable ActiveStatus With DataType As String  
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
        ''' Get or Set the Value of StateId
        ''' </summary>
        ''' <value>lngStateId</value>
        ''' <returns> Return lngStateId</returns>
        ''' <remarks> Get or Set the Value of StateId  </remarks>
        '''
        Public Property StateId() As Long
            Get
                Return lngStateId
            End Get
            Set(ByVal value As Long)
                lngStateId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of StateCode
        ''' </summary>
        ''' <value>strStateCode</value>
        ''' <returns> Return strStateCode</returns>
        ''' <remarks> Get or Set the Value of StateCode  </remarks>
        '''
        Public Property StateCode() As String
            Get
                Return strStateCode
            End Get
            Set(ByVal value As String)
                strStateCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of StateName
        ''' </summary>
        ''' <value>strStateName</value>
        ''' <returns> Return strStateName</returns>
        ''' <remarks> Get or Set the Value of StateName  </remarks>
        '''
        Public Property StateName() As String
            Get
                Return strStateName
            End Get
            Set(ByVal value As String)
                strStateName = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of StateCapital
        ''' </summary>
        ''' <value>strStateCapital</value>
        ''' <returns> Return strStateCapital</returns>
        ''' <remarks> Get or Set the Value of StateCapital  </remarks>
        '''
        Public Property StateCapital() As String
            Get
                Return strStateCapital
            End Get
            Set(ByVal value As String)
                strStateCapital = value
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
        ''' Get or Set the Value of GSTN
        ''' </summary>
        ''' <value>strGSTN</value>
        ''' <returns> Return strGSTN</returns>
        ''' <remarks> Get or Set the Value of GSTN  </remarks>
        '''
        Public Property GSTN() As String
            Get
                Return strGSTN
            End Get
            Set(ByVal value As String)
                strGSTN = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of StateAddress
        ''' </summary>
        ''' <value>strStateAddress</value>
        ''' <returns> Return strStateAddress</returns>
        ''' <remarks> Get or Set the Value of StateAddress  </remarks>
        '''
        Public Property StateAddress() As String
            Get
                Return strStateAddress
            End Get
            Set(ByVal value As String)
                strStateAddress = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ActiveStatus
        ''' </summary>
        ''' <value>strActiveStatus</value>
        ''' <returns> Return strActiveStatus</returns>
        ''' <remarks> Get or Set the Value of ActiveStatus  </remarks>
        '''
        Public Property ActiveStatus() As String
            Get
                Return strActiveStatus
            End Get
            Set(ByVal value As String)
                strActiveStatus = value
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
            lngStateId = 0
            strStateCode = ""
            strStateName = ""
            strStateCapital = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            strGSTN = ""
            strStateAddress = ""
            strActiveStatus = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="PStateCodeMaster"></param>
        ''' <returns>Return pStateCodeMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                'db.AddParameter("p_TERMINAL_ID", pStateCodeMaster.TerminalId)
                db.AddParameter("p_STATE_ID", pStateCodeMaster.StateId)
                db.AddParameter("p_STATE_CODE", pStateCodeMaster.StateCode)
                db.AddParameter("p_STATE_NAME", pStateCodeMaster.StateName)
                db.AddParameter("p_STATE_CAPITAL", pStateCodeMaster.StateCapital)
                db.AddParameter("p_CREATED_BY", pStateCodeMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pStateCodeMaster.CreatedOn)
                db.AddParameter("p_GSTN", pStateCodeMaster.GSTN)
                db.AddParameter("p_STATE_ADDRESS", pStateCodeMaster.StateAddress)
                db.AddParameter("p_ACTIVE_STATUS", pStateCodeMaster.ActiveStatus)
                db.AddParameter("p_ErrorMsg", pStateCodeMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_STATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pStateCodeMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pStateCodeMaster.StateId = db.Parameters.Item("p_STATE_ID").value

                If pStateCodeMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pStateCodeMaster"></param>
        ''' <returns>Return pStateCodeMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Try
                db.ClearParameters()
                ' db.AddParameter("p_TERMINAL_ID", pStateCodeMaster.TerminalId)
                db.AddParameter("p_STATE_ID", pStateCodeMaster.StateId)
                db.AddParameter("p_STATE_CODE", pStateCodeMaster.StateCode)
                db.AddParameter("p_STATE_NAME", pStateCodeMaster.StateName)
                db.AddParameter("p_STATE_CAPITAL", pStateCodeMaster.StateCapital)
                db.AddParameter("p_CREATED_BY", pStateCodeMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pStateCodeMaster.CreatedOn)
                db.AddParameter("p_GSTN", pStateCodeMaster.GSTN)
                db.AddParameter("p_STATE_ADDRESS", pStateCodeMaster.StateAddress)
                db.AddParameter("p_ACTIVE_STATUS", pStateCodeMaster.ActiveStatus)
                db.AddParameter("p_ErrorMsg", pStateCodeMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_STATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pStateCodeMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pStateCodeMaster.StateId = db.Parameters.Item("p_STATE_ID").value

            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
            End Try
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pStateCodeMaster"></param>
        ''' <returns>Return pStateCodeMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_STATE_ID", pStateCodeMaster.StateId)
                db.AddParameter("p_STATE_CODE", pStateCodeMaster.StateCode)
                db.AddParameter("p_STATE_NAME", pStateCodeMaster.StateName)
                db.AddParameter("p_STATE_CAPITAL", pStateCodeMaster.StateCapital)
                db.AddParameter("p_CREATED_BY", pStateCodeMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pStateCodeMaster.CreatedOn)
                db.AddParameter("p_GSTN", pStateCodeMaster.GSTN)
                db.AddParameter("p_STATE_ADDRESS", pStateCodeMaster.StateAddress)
                db.AddParameter("p_ACTIVE_STATUS", pStateCodeMaster.ActiveStatus)
                db.AddParameter("p_ErrorMsg", pStateCodeMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_STATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pStateCodeMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pStateCodeMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pStateCodeMaster"></param>
        ''' <returns>Return pStateCodeMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Try
                db.AddParameter("p_STATE_ID", pStateCodeMaster.StateId)
                db.AddParameter("p_STATE_CODE", pStateCodeMaster.StateCode)
                db.AddParameter("p_STATE_NAME", pStateCodeMaster.StateName)
                db.AddParameter("p_STATE_CAPITAL", pStateCodeMaster.StateCapital)
                db.AddParameter("p_CREATED_BY", pStateCodeMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pStateCodeMaster.CreatedOn)
                db.AddParameter("p_GSTN", pStateCodeMaster.GSTN)
                db.AddParameter("p_STATE_ADDRESS", pStateCodeMaster.StateAddress)
                db.AddParameter("p_ACTIVE_STATUS", pStateCodeMaster.ActiveStatus)
                db.AddParameter("p_ErrorMsg", pStateCodeMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_STATE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pStateCodeMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pStateCodeMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pStateCodeMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_ID").ToString <> "" Then
                                pStateCodeMaster.StateId = dbr("STATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                pStateCodeMaster.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_NAME").ToString <> "" Then
                                pStateCodeMaster.StateName = dbr("STATE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CAPITAL").ToString <> "" Then
                                pStateCodeMaster.StateCapital = dbr("STATE_CAPITAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pStateCodeMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pStateCodeMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GSTN").ToString <> "" Then
                                pStateCodeMaster.GSTN = dbr("GSTN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_ADDRESS").ToString <> "" Then
                                pStateCodeMaster.StateAddress = dbr("STATE_ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE_STATUS").ToString <> "" Then
                                pStateCodeMaster.ActiveStatus = dbr("ACTIVE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
            End Try
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrStateMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New StateCodeMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_ID").ToString <> "" Then
                                temp.StateId = dbr("STATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CODE").ToString <> "" Then
                                temp.StateCode = dbr("STATE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_NAME").ToString <> "" Then
                                temp.StateName = dbr("STATE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_CAPITAL").ToString <> "" Then
                                temp.StateCapital = dbr("STATE_CAPITAL")
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
                            If dbr("GSTN").ToString <> "" Then
                                temp.GSTN = dbr("GSTN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_ADDRESS").ToString <> "" Then
                                temp.StateAddress = dbr("STATE_ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE_STATUS").ToString <> "" Then
                                temp.ActiveStatus = dbr("ACTIVE_STATUS")
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
        ''' Preparing Return Object By TerminalId, StateId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnStateById(ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_STATE_MASTER_BY_ID", pStateCodeMaster.StateId)
                pStateCodeMaster = ReturnObjectValues(dbr, pStateCodeMaster)
                dbr.Close()
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, StateId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnStateByCode(ByVal pStateCodeMaster As StateCodeMaster) As StateCodeMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_STATE_MASTER_BY_CODE", "'" & pStateCodeMaster.StateCode & "'")
                pStateCodeMaster = ReturnObjectValues(dbr, pStateCodeMaster)
                dbr.Close()
            Catch ex As Exception
                pStateCodeMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pStateCodeMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnStateList(ByVal pStateCodeMaster As StateCodeMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrStateMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_STATE_MASTER_ALL", "")
                arrStateMaster = ReturnObjectValuesList(dbr, arrStateMaster)
                dbr.Close()
            Catch ex As Exception
                arrStateMaster = Nothing
            End Try
            db.CloseDB()
            Return arrStateMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnStateListForInvoice(ByVal pStateCodeMaster As StateCodeMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrStateMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_STATE_MASTER_FOR_INVOICE", "")
                arrStateMaster = ReturnObjectValuesList(dbr, arrStateMaster)
                dbr.Close()
            Catch ex As Exception
                arrStateMaster = Nothing
            End Try
            db.CloseDB()
            Return arrStateMaster
        End Function
    End Class
End Namespace
