Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version     : Version 1.0.0.0
    ''' @Module/Class Name : ChangeRequest
    ''' @author      : Santosh Singh- 10/2/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ChangeRequest

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private dblTaskId As Double ' Define Private Variable TaskId With DataType As Long 
        Private lngMenuId As Long ' Define Private Variable MenuId With DataType As Long 
        Private strOpenDate As String ' Define Private Variable OpenDate With DataType As String 
        Private strCloseDate As String ' Define Private Variable CloseDate With DataType As String 
        Private strCloseRemark As String ' Define Private Variable Status With DataType As Long 
        Private strDescription As String ' Define Private Variable Description With DataType As String 
        Private strTaskHeader As String ' Define Private Variable Description With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strUpdatedBy As String ' Define Private Variable UpdatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable UpdatedOn With DataType As String 
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
        ''' Get or Set the Value of TaskId
        ''' </summary>
        ''' <value>lngTaskId</value>
        ''' <returns> Return lngTaskId</returns>
        ''' <remarks> Get or Set the Value of TaskId  </remarks>
        '''
        Public Property TaskId() As Double
            Get
                Return dblTaskId
            End Get
            Set(ByVal value As Double)
                dblTaskId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MenuId
        ''' </summary>
        ''' <value>lngMenuId</value>
        ''' <returns> Return lngMenuId</returns>
        ''' <remarks> Get or Set the Value of MenuId  </remarks>
        '''
        Public Property MenuId() As Long
            Get
                Return lngMenuId
            End Get
            Set(ByVal value As Long)
                lngMenuId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OpenDate
        ''' </summary>
        ''' <value>strOpenDate</value>
        ''' <returns> Return strOpenDate</returns>
        ''' <remarks> Get or Set the Value of OpenDate  </remarks>
        '''
        Public Property OpenDate() As String
            Get
                Return strOpenDate
            End Get
            Set(ByVal value As String)
                strOpenDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CloseDate
        ''' </summary>
        ''' <value>strCloseDate</value>
        ''' <returns> Return strCloseDate</returns>
        ''' <remarks> Get or Set the Value of CloseDate  </remarks>
        '''
        Public Property CloseDate() As String
            Get
                Return strCloseDate
            End Get
            Set(ByVal value As String)
                strCloseDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>lngStatus</value>
        ''' <returns> Return lngStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property CloseRemark() As String
            Get
                Return strCloseRemark
            End Get
            Set(ByVal value As String)
                strCloseRemark = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Description
        ''' </summary>
        ''' <value>strDescription</value>
        ''' <returns> Return strDescription</returns>
        ''' <remarks> Get or Set the Value of Description  </remarks>
        '''
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
            End Set
        End Property

        Public Property TaskHeader() As String
            Get
                Return strTaskHeader
            End Get
            Set(ByVal value As String)
                strTaskHeader = value
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
        ''' Get or Set the Value of UpdatedBy
        ''' </summary>
        ''' <value>strUpdatedBy</value>
        ''' <returns> Return strUpdatedBy</returns>
        ''' <remarks> Get or Set the Value of UpdatedBy  </remarks>
        '''
        Public Property UpdatedBy() As String
            Get
                Return strUpdatedBy
            End Get
            Set(ByVal value As String)
                strUpdatedBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UpdatedOn
        ''' </summary>
        ''' <value>strUpdatedOn</value>
        ''' <returns> Return strUpdatedOn</returns>
        ''' <remarks> Get or Set the Value of UpdatedOn  </remarks>
        '''
        Public Property UpdatedOn() As String
            Get
                Return strUpdatedOn
            End Get
            Set(ByVal value As String)
                strUpdatedOn = value
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
            dblTaskId = 0
            lngMenuId = 0
            strOpenDate = ""
            strCloseDate = ""
            strCloseRemark = ""
            strTaskHeader = ""
            strDescription = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pChangeRequest"></param>
        ''' <returns>Return pChangeRequest Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pChangeRequest.TerminalId)
                db.AddParameter("p_TASK_ID", pChangeRequest.TaskId, ParameterDirection.Output)
                db.AddParameter("p_MENU_ID", pChangeRequest.MenuId)
                db.AddParameter("p_OPEN_DATE", pChangeRequest.OpenDate, ParameterDirection.Output)
                db.AddParameter("p_CLOSE_DATE", pChangeRequest.CloseDate)
                db.AddParameter("p_CLOSE_REMARK", pChangeRequest.CloseRemark)
                db.AddParameter("p_DESCRIPTION", pChangeRequest.Description)
                db.AddParameter("p_TASK_HEADER", pChangeRequest.TaskHeader)
                db.AddParameter("p_CREATED_BY", pChangeRequest.CreatedBy)
                db.AddParameter("p_CREATED_ON", pChangeRequest.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pChangeRequest.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pChangeRequest.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pChangeRequest.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUERY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pChangeRequest.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pChangeRequest.TaskId = db.Parameters.Item("p_TASK_ID").value
                    pChangeRequest.OpenDate = db.Parameters.Item("p_OPEN_DATE").value
                End If
                If pChangeRequest.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pChangeRequest"></param>
        ''' <returns>Return pChangeRequest Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pChangeRequest.TerminalId)
                db.AddParameter("p_TASK_ID", pChangeRequest.TaskId, ParameterDirection.Output)
                db.AddParameter("p_MENU_ID", pChangeRequest.MenuId)
                db.AddParameter("p_OPEN_DATE", pChangeRequest.OpenDate, ParameterDirection.Output)
                db.AddParameter("p_CLOSE_DATE", pChangeRequest.CloseDate)
                db.AddParameter("p_CLOSE_REMARK", pChangeRequest.CloseRemark)
                db.AddParameter("p_DESCRIPTION", pChangeRequest.Description)
                db.AddParameter("p_TASK_HEADER", pChangeRequest.TaskHeader)
                db.AddParameter("p_CREATED_BY", pChangeRequest.CreatedBy)
                db.AddParameter("p_CREATED_ON", pChangeRequest.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pChangeRequest.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pChangeRequest.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pChangeRequest.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUERY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pChangeRequest.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pChangeRequest.TaskId = db.Parameters.Item("p_TASK_ID").value
                    pChangeRequest.OpenDate = db.Parameters.Item("p_OPEN_DATE").value
                End If

            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
            End Try
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pChangeRequest"></param>
        ''' <returns>Return pChangeRequest Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pChangeRequest.TerminalId)
                db.AddParameter("p_TASK_ID", pChangeRequest.TaskId)
                db.AddParameter("p_CLOSE_DATE", pChangeRequest.CloseDate)
                db.AddParameter("p_CLOSE_REMARK", pChangeRequest.CloseRemark)
                db.AddParameter("p_UPDATED_BY", pChangeRequest.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pChangeRequest.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pChangeRequest.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUERY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pChangeRequest.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pChangeRequest.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pChangeRequest"></param>
        ''' <returns>Return pChangeRequest Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pChangeRequest.TerminalId)
                db.AddParameter("p_TASK_ID", pChangeRequest.TaskId)
                db.AddParameter("p_CLOSE_DATE", pChangeRequest.CloseDate)
                db.AddParameter("p_CLOSE_REMARK", pChangeRequest.CloseRemark)
                db.AddParameter("p_UPDATED_BY", pChangeRequest.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pChangeRequest.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pChangeRequest.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUERY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pChangeRequest.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
            End Try
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pChangeRequest.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TASK_ID").ToString <> "" Then
                                pChangeRequest.TaskId = dbr("TASK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                pChangeRequest.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OPEN_DATE").ToString <> "" Then
                                pChangeRequest.OpenDate = dbr("OPEN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_DATE").ToString <> "" Then
                                pChangeRequest.CloseDate = dbr("CLOSE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_REMARK").ToString <> "" Then
                                pChangeRequest.CloseRemark = dbr("CLOSE_REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                pChangeRequest.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TASK_HEADER").ToString <> "" Then
                                pChangeRequest.TaskHeader = dbr("TASK_HEADER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pChangeRequest.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pChangeRequest.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                pChangeRequest.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                pChangeRequest.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
            End Try
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrChangeRequest As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ChangeRequest
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TASK_ID").ToString <> "" Then
                                temp.TaskId = dbr("TASK_ID")
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
                            If dbr("OPEN_DATE").ToString <> "" Then
                                temp.OpenDate = dbr("OPEN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_DATE").ToString <> "" Then
                                temp.CloseDate = dbr("CLOSE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_REMARK").ToString <> "" Then
                                temp.CloseRemark = dbr("CLOSE_REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                temp.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TASK_HEADER").ToString <> "" Then
                                temp.TaskHeader = dbr("TASK_HEADER")
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
                            If dbr("UPDATED_BY").ToString <> "" Then
                                temp.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                temp.UpdatedOn = dbr("UPDATED_ON")
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
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnChangeRequest(ByVal pChangeRequest As ChangeRequest) As ChangeRequest
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_QUERY_MASTER_BY_ID", pChangeRequest.TerminalId & "," & pChangeRequest.TaskId)
                pChangeRequest = ReturnObjectValues(dbr, pChangeRequest)
                dbr.Close()
            Catch ex As Exception
                pChangeRequest.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pChangeRequest
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnChangeRequestList(ByVal pChangeRequest As ChangeRequest) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrChangeRequest As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_QUERY_MASTER_BY_ALL", pChangeRequest.TerminalId)
                arrChangeRequest = ReturnObjectValuesList(dbr, arrChangeRequest)
                dbr.Close()
            Catch ex As Exception
                arrChangeRequest = Nothing
            End Try
            db.CloseDB()
            Return arrChangeRequest
        End Function
    End Class
End Namespace
