Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceMode
    ''' @author	: Amit K. Singh- 13/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ServiceMode 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strModeCode As String ' Define Private Variable ModeCode With DataType As String 
        Private strModeName As String ' Define Private Variable ModeName With DataType As String 
        Private lngModeId As Long
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

        Private arrServiceModeMap As ArrayList

        Public Property ServiceModeMapList() As ArrayList
            Get
                Return arrServiceModeMap
            End Get
            Set(ByVal value As ArrayList)
                arrServiceModeMap = value
            End Set
        End Property

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
        ''' Get or Set the Value of ModeCode
        ''' </summary>
        ''' <value>strModeCode</value>
        ''' <returns> Return strModeCode</returns>
        ''' <remarks> Get or Set the Value of ModeCode  </remarks>
        '''
        Public Property ModeCode() As String
            Get
                Return strModeCode
            End Get
            Set(ByVal value As String)
                strModeCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ModeName
        ''' </summary>
        ''' <value>strModeName</value>
        ''' <returns> Return strModeName</returns>
        ''' <remarks> Get or Set the Value of ModeName  </remarks>
        '''
        Public Property ModeName() As String
            Get
                Return strModeName
            End Get
            Set(ByVal value As String)
                strModeName = value
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

        Public Property ModeId() As Long
            Get
                Return lngModeId
            End Get
            Set(ByVal value As Long)
                lngModeId = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            strModeCode = ""
            strModeName = ""
            strErrormsg = ""
            lngModeId = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pServiceMode"></param>
        ''' <returns>Return pServiceMode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMode.TerminalId)
                db.AddParameter("p_MODE_CODE", pServiceMode.ModeCode)
                db.AddParameter("p_MODE_NAME", pServiceMode.ModeName)
                db.AddParameter("p_MODE_ID", pServiceMode.ModeId)
                db.AddParameter("p_ErrorMsg", pServiceMode.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMode.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pServiceMode.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceMode
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceMode"></param>
        ''' <returns>Return pServiceMode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pServiceMode As ServiceMode) As ServiceMode
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMode.TerminalId)
                db.AddParameter("p_MODE_CODE", pServiceMode.ModeCode)
                db.AddParameter("p_MODE_NAME", pServiceMode.ModeName)
                db.AddParameter("p_MODE_ID", pServiceMode.ModeId)
                db.AddParameter("p_ErrorMsg", pServiceMode.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMode.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
            End Try
            Return pServiceMode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pServiceMode"></param>
        ''' <returns>Return pServiceMode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMode.TerminalId)
                db.AddParameter("p_MODE_CODE", pServiceMode.ModeCode)
                db.AddParameter("p_MODE_NAME", pServiceMode.ModeName)
                db.AddParameter("p_MODE_ID", pServiceMode.ModeId)
                db.AddParameter("p_ErrorMsg", pServiceMode.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMode.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceMode.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceMode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceMode"></param>
        ''' <returns>Return pServiceMode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pServiceMode As ServiceMode) As ServiceMode
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMode.TerminalId)
                db.AddParameter("p_MODE_CODE", pServiceMode.ModeCode)
                db.AddParameter("p_MODE_NAME", pServiceMode.ModeName)
                db.AddParameter("p_MODE_ID", pServiceMode.ModeId)
                db.AddParameter("p_ErrorMsg", pServiceMode.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMode.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
            End Try
            Return pServiceMode
        End Function
        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pServiceMode"></param>
        ''' <returns>Return pServiceMode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateServicModeMap(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMode.TerminalId)
                db.AddParameter("p_MODE_ID", pServiceMode.ModeId)
                db.AddParameter("p_MODE_CODE", pServiceMode.ModeCode)
                db.AddParameter("p_ErrorMsg", pServiceMode.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MODE_MAP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMode.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceMode.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceMode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pServiceMode As ServiceMode) As ServiceMode
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pServiceMode.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_CODE").ToString <> "" Then
                                pServiceMode.ModeCode = dbr("MODE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_NAME").ToString <> "" Then
                                pServiceMode.ModeName = dbr("MODE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_ID").ToString <> "" Then
                                pServiceMode.ModeId = dbr("MODE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
            End Try
            Return pServiceMode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrServiceMode As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ServiceMode
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_CODE").ToString <> "" Then
                                temp.ModeCode = dbr("MODE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_NAME").ToString <> "" Then
                                temp.ModeName = dbr("MODE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_ID").ToString <> "" Then
                                temp.ModeId = dbr("MODE_ID")
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
        Public Shared Function ReturnServiceModeByModeCode(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_BY_MODE_CODE", pServiceMode.TerminalId & ",'" & pServiceMode.ModeCode & "'")
                pServiceMode = ReturnObjectValues(dbr, pServiceMode)
                dbr.Close()
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pServiceMode
        End Function
        Public Shared Function ReturnServiceModeByModeId(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_BY_MODE_ID", pServiceMode.TerminalId & "," & pServiceMode.ModeId)
                pServiceMode = ReturnObjectValues(dbr, pServiceMode)
                dbr.Close()
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pServiceMode
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceModeList(ByVal pServiceMode As ServiceMode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_ALL", pServiceMode.TerminalId)
                arrServiceMode = ReturnObjectValuesList(dbr, arrServiceMode)
                dbr.Close()
            Catch ex As Exception
                arrServiceMode = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMode
        End Function
        ''*******************************Change By : Dhirendra Kumar singh on date : 30/04/2012 ***********************************

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceModeListDomestic(ByVal pServiceMode As ServiceMode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_DOM", pServiceMode.TerminalId)
                arrServiceMode = ReturnObjectValuesList(dbr, arrServiceMode)
                dbr.Close()
            Catch ex As Exception
                arrServiceMode = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMode
        End Function

        Public Shared Function InsertUpdateDetails(ByVal pServiceMode As ServiceMode) As ServiceMode
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                ServiceMode.UpdateServicModeMap(pServiceMode)
                For Each det As ServiceModeMap In pServiceMode.ServiceModeMapList
                    ServiceModeMap.InsertTrn(db, det)
                    If det.Errormsg <> "" Then
                        Throw New Exception(det.Errormsg)
                    End If
                Next
                
                db.CommitTransaction()
            Catch ex As Exception
                pServiceMode.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pServiceMode
        End Function

    End Class
End Namespace
