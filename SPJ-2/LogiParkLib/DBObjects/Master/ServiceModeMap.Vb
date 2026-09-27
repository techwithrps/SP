Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceModeMap
    ''' @author	: Amit K. Singh- 13/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ServiceModeMap 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngModeId As Long ' Define Private Variable ModeId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strServiceTypeCode As String ' Define Private Variable ServiceTypeCode With DataType As String 
        Private strServiceMode As String ' Define Private Variable ServiceMode With DataType As String 
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
        ''' Get or Set the Value of ModeId
        ''' </summary>
        ''' <value>lngModeId</value>
        ''' <returns> Return lngModeId</returns>
        ''' <remarks> Get or Set the Value of ModeId  </remarks>
        '''
        Public Property ModeId() as Long
            Get
                Return lngModeId
            End Get
            Set(ByVal value As Long)
                lngModeId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() as Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceTypeCode
        ''' </summary>
        ''' <value>strServiceTypeCode</value>
        ''' <returns> Return strServiceTypeCode</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeCode  </remarks>
        '''
        Public Property ServiceTypeCode() As String
            Get
                Return strServiceTypeCode
            End Get
            Set(ByVal value As String)
                strServiceTypeCode = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ServiceMode
        ''' </summary>
        ''' <value>strServiceMode</value>
        ''' <returns> Return strServiceMode</returns>
        ''' <remarks> Get or Set the Value of ServiceMode  </remarks>
        '''
        Public Property ServiceMode() As String
            Get
                Return strServiceMode
            End Get
            Set(ByVal value As String)
                strServiceMode = value
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
            lngModeId = 0 
            lngServiceId = 0
            strServiceTypeCode = ""
            strServiceMode = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pServiceModeMap"></param>
        ''' <returns>Return pServiceModeMap Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceModeMap.TerminalId)
                db.AddParameter("p_MODE_ID", pServiceModeMap.ModeId)
                db.AddParameter("p_SERVICE_ID", pServiceModeMap.ServiceId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceModeMap.strServiceTypeCode)
                db.AddParameter("p_SERVICE_MODE", pServiceModeMap.strServiceMode)
                db.AddParameter("p_ErrorMsg", pServiceModeMap.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MODE_MAP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceModeMap.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pServiceModeMap.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceModeMap.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceModeMap"></param>
        ''' <returns>Return pServiceModeMap Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceModeMap.TerminalId)
                db.AddParameter("p_MODE_ID", pServiceModeMap.ModeId)
                db.AddParameter("p_SERVICE_ID", pServiceModeMap.ServiceId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceModeMap.strServiceMode)
                db.AddParameter("p_SERVICE_MODE", pServiceModeMap.strServiceMode)
                db.AddParameter("p_ErrorMsg", pServiceModeMap.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MODE_MAP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceModeMap.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pServiceModeMap.ErrorMsg = ex.Message
            End Try
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pServiceModeMap"></param>
        ''' <returns>Return pServiceModeMap Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceModeMap.TerminalId)
                db.AddParameter("p_MODE_ID", pServiceModeMap.ModeId)
                db.AddParameter("p_SERVICE_ID", pServiceModeMap.ServiceId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceModeMap.strServiceTypeCode)
                db.AddParameter("p_SERVICE_MODE", pServiceModeMap.strServiceMode)
                db.AddParameter("p_ErrorMsg", pServiceModeMap.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MODE_MAP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceModeMap.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceModeMap.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceModeMap.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceModeMap"></param>
        ''' <returns>Return pServiceModeMap Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceModeMap.TerminalId)
                db.AddParameter("p_MODE_ID", pServiceModeMap.ModeId)
                db.AddParameter("p_SERVICE_ID", pServiceModeMap.ServiceId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceModeMap.strServiceTypeCode)
                db.AddParameter("p_SERVICE_MODE", pServiceModeMap.strServiceMode)
                db.AddParameter("p_ErrorMsg", pServiceModeMap.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MODE_MAP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceModeMap.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pServiceModeMap.Errormsg = ex.Message
            End Try
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PServiceModeMap.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_ID").ToString <> "" Then
                                PServiceModeMap.ModeId = dbr("MODE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PServiceModeMap.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                pServiceModeMap.strServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_MODE").ToString <> "" Then
                                pServiceModeMap.strServiceMode = dbr("SERVICE_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pServiceModeMap.ErrorMsg = ex.Message
            End Try
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrServiceModeMap As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ServiceModeMap
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_ID").ToString <> "" Then
                                temp.ModeId = dbr("MODE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                temp.strServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_MODE").ToString <> "" Then
                                temp.strServiceMode = dbr("SERVICE_MODE")
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
        Public Shared Function ReturnServiceModeMap(ByVal pServiceModeMap As ServiceModeMap) As ServiceModeMap
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_MAP_BY_ID", pServiceModeMap.TerminalId & "," & pServiceModeMap.ModeId & "," & pServiceModeMap.ServiceId)
                pServiceModeMap = ReturnObjectValues(dbr, pServiceModeMap)
                dbr.Close()
            Catch ex As Exception
                pServiceModeMap.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pServiceModeMap
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceModeMapList (ByVal pServiceModeMap As ServiceModeMap) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceModeMap As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MODE_MAP_ALL_BY_ID", pServiceModeMap.TerminalId & "," & pServiceModeMap.ModeId)
                arrServiceModeMap = ReturnObjectValuesList(dbr, arrServiceModeMap)
                dbr.Close()
            Catch ex As Exception
                arrServiceModeMap = Nothing
            End Try
            db.CloseDB()
            Return arrServiceModeMap
        End Function
    End Class
End Namespace
