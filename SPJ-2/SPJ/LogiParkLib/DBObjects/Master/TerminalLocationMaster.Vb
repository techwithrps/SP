Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TerminalLocationMaster
    ''' @author	: Santosh Singh- 21/1/2015
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TerminalLocationMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngLocationId As Long ' Define Private Variable LocationId With DataType As Long 
        Private strLocationName As String ' Define Private Variable LocationName With DataType As String 
        Private lngDistance As Long ' Define Private Variable Distance With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
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
        ''' Get or Set the Value of LocationId
        ''' </summary>
        ''' <value>lngLocationId</value>
        ''' <returns> Return lngLocationId</returns>
        ''' <remarks> Get or Set the Value of LocationId  </remarks>
        '''
        Public Property LocationId() as Long
            Get
                Return lngLocationId
            End Get
            Set(ByVal value As Long)
                lngLocationId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LocationName
        ''' </summary>
        ''' <value>strLocationName</value>
        ''' <returns> Return strLocationName</returns>
        ''' <remarks> Get or Set the Value of LocationName  </remarks>
        '''
        Public Property LocationName() as String
            Get
                Return strLocationName
            End Get
            Set(ByVal value As String)
                strLocationName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Distance
        ''' </summary>
        ''' <value>lngDistance</value>
        ''' <returns> Return lngDistance</returns>
        ''' <remarks> Get or Set the Value of Distance  </remarks>
        '''
        Public Property Distance() as Long
            Get
                Return lngDistance
            End Get
            Set(ByVal value As Long)
                lngDistance = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() as String
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
        Public Property CreatedOn() as String
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
            lngLocationId = 0 
            strLocationName = ""
            lngDistance = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalLocationMaster"></param>
        ''' <returns>Return pTerminalLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pTerminalLocationMaster.LocationId, ParameterDirection.Output)
                db.AddParameter("p_LOCATION_NAME", pTerminalLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pTerminalLocationMaster.Distance)
                db.AddParameter("p_CREATED_BY", pTerminalLocationMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalLocationMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTerminalLocationMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalLocationMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalLocationMaster.LocationId  = db.Parameters.Item("p_LOCATION_ID").value
                
                If pTerminalLocationMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalLocationMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalLocationMaster"></param>
        ''' <returns>Return pTerminalLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pTerminalLocationMaster.LocationId, ParameterDirection.Output)
                db.AddParameter("p_LOCATION_NAME", pTerminalLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pTerminalLocationMaster.Distance)
                db.AddParameter("p_CREATED_BY", pTerminalLocationMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalLocationMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTerminalLocationMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalLocationMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalLocationMaster.LocationId  = db.Parameters.Item("p_LOCATION_ID").value
                
            Catch ex As Exception
                pTerminalLocationMaster.ErrorMsg = ex.Message
            End Try
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalLocationMaster"></param>
        ''' <returns>Return pTerminalLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pTerminalLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pTerminalLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pTerminalLocationMaster.Distance)
                db.AddParameter("p_CREATED_BY", pTerminalLocationMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalLocationMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTerminalLocationMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalLocationMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalLocationMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalLocationMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalLocationMaster"></param>
        ''' <returns>Return pTerminalLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTerminalLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pTerminalLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pTerminalLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pTerminalLocationMaster.Distance)
                db.AddParameter("p_CREATED_BY", pTerminalLocationMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTerminalLocationMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTerminalLocationMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalLocationMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTerminalLocationMaster.ErrorMsg = ex.Message
                End Try
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTerminalLocationMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_ID").ToString <> "" Then
                                PTerminalLocationMaster.LocationId = dbr("LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_NAME").ToString <> "" Then
                                PTerminalLocationMaster.LocationName = dbr("LOCATION_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE").ToString <> "" Then
                                PTerminalLocationMaster.Distance = dbr("DISTANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTerminalLocationMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTerminalLocationMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTerminalLocationMaster.ErrorMsg = ex.Message
            End Try
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalLocationMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalLocationMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_ID").ToString <> "" Then
                                temp.LocationId = dbr("LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_NAME").ToString <> "" Then
                                temp.LocationName = dbr("LOCATION_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE").ToString <> "" Then
                                temp.Distance = dbr("DISTANCE")
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
        Public Shared Function ReturnTerminalLocationMaster(ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_LOCATION_MASTER", "' '")
                pTerminalLocationMaster = ReturnObjectValues(dbr, pTerminalLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pTerminalLocationMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalLocationMaster
        End Function
        Public Shared Function ReturnTerminalLocationByLocationId(ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_LOCATION_BY_ID", pTerminalLocationMaster.TerminalId & "," & pTerminalLocationMaster.LocationId)
                pTerminalLocationMaster = ReturnObjectValues(dbr, pTerminalLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pTerminalLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalLocationMaster
        End Function
        Public Shared Function ReturnTerminalLocationByName(ByVal pTerminalLocationMaster As TerminalLocationMaster) As TerminalLocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_LOCATION_BY_NAME", pTerminalLocationMaster.TerminalId & "," & "'" & pTerminalLocationMaster.LocationName & "'")
                pTerminalLocationMaster = ReturnObjectValues(dbr, pTerminalLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pTerminalLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalLocationMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTerminalLocationMasterList (ByVal pTerminalLocationMaster As TerminalLocationMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalLocationMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_LOCATION_MASTER", pTerminalLocationMaster.TerminalId)
                arrTerminalLocationMaster = ReturnObjectValuesList(dbr, arrTerminalLocationMaster)
                dbr.Close()
            Catch ex As Exception
                arrTerminalLocationMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalLocationMaster
        End Function

        Public Shared Function ReturnTerminalLocationMasterAll(ByVal pTerminalLocationMaster As TerminalLocationMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalLocationMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TERMINAL_LOCATION_ALL", "''")
                arrTerminalLocationMaster = ReturnObjectValuesList(dbr, arrTerminalLocationMaster)
                dbr.Close()
            Catch ex As Exception
                arrTerminalLocationMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalLocationMaster
        End Function
    End Class
End Namespace
