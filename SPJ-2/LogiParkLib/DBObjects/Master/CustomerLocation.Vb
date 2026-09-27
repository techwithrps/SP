Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerLocation
    ''' @author	: Santosh Singh- 21/4/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CustomerLocation 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private lngLocationId As Long ' Define Private Variable LocationId With DataType As Long 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngLocationKeyId As Long ' Define Private Variable LocationKeyId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private dblLongitude As Double
        Private dblLatitude As Double
                    
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
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() as Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
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
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() as String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
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
        ''' Get or Set the Value of LocationKeyId
        ''' </summary>
        ''' <value>lngLocationKeyId</value>
        ''' <returns> Return lngLocationKeyId</returns>
        ''' <remarks> Get or Set the Value of LocationKeyId  </remarks>
        '''
        Public Property LocationKeyId() as Long
            Get
                Return lngLocationKeyId
            End Get
            Set(ByVal value As Long)
                lngLocationKeyId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of LocationKeyId
        ''' </summary>
        ''' <value>lngLocationKeyId</value>
        ''' <returns> Return lngLocationKeyId</returns>
        ''' <remarks> Get or Set the Value of LocationKeyId  </remarks>
        '''
        Public Property Longitude() As Double
            Get
                Return dblLongitude
            End Get
            Set(ByVal value As Double)
                dblLongitude = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of LocationKeyId
        ''' </summary>
        ''' <value>lngLocationKeyId</value>
        ''' <returns> Return lngLocationKeyId</returns>
        ''' <remarks> Get or Set the Value of LocationKeyId  </remarks>
        '''
        Public Property Latitude() As Double
            Get
                Return dblLatitude
            End Get
            Set(ByVal value As Double)
                dblLatitude = value
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
            lngCustomerId = 0 
            lngLocationId = 0 
            strAddress = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngLocationKeyId = 0
            dblLongitude = 0.0
            dblLatitude = 0.0
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerLocation"></param>
        ''' <returns>Return pCustomerLocation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerLocation.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerLocation.CustomerId)
                db.AddParameter("p_LOCATION_ID", pCustomerLocation.LocationId)
                db.AddParameter("p_ADDRESS", pCustomerLocation.Address)
                db.AddParameter("p_CREATED_BY", pCustomerLocation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerLocation.CreatedOn)
                db.AddParameter("p_LOCATION_KEY_ID", pCustomerLocation.LocationKeyId, ParameterDirection.Output)
                db.AddParameter("P_LONGITUDE", pCustomerLocation.Longitude)
                db.AddParameter("P_LATITUDE", pCustomerLocation.Latitude)
                db.AddParameter("p_ErrorMsg", pCustomerLocation.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_LOCATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerLocation.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerLocation.LocationKeyId  = db.Parameters.Item("p_LOCATION_KEY_ID").value
                
                If pCustomerLocation.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerLocation.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerLocation"></param>
        ''' <returns>Return pCustomerLocation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerLocation.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerLocation.CustomerId)
                db.AddParameter("p_LOCATION_ID", pCustomerLocation.LocationId)
                db.AddParameter("p_ADDRESS", pCustomerLocation.Address)
                db.AddParameter("p_CREATED_BY", pCustomerLocation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerLocation.CreatedOn)
                db.AddParameter("p_LOCATION_KEY_ID", pCustomerLocation.LocationKeyId, ParameterDirection.Output)
                db.AddParameter("P_LONGITUDE", pCustomerLocation.Longitude)
                db.AddParameter("P_LATITUDE", pCustomerLocation.Latitude)
                db.AddParameter("p_ErrorMsg", pCustomerLocation.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_LOCATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerLocation.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCustomerLocation.LocationKeyId  = db.Parameters.Item("p_LOCATION_KEY_ID").value
                
            Catch ex As Exception
                pCustomerLocation.ErrorMsg = ex.Message
            End Try
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerLocation"></param>
        ''' <returns>Return pCustomerLocation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerLocation.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerLocation.CustomerId)
                db.AddParameter("p_LOCATION_ID", pCustomerLocation.LocationId)
                db.AddParameter("p_ADDRESS", pCustomerLocation.Address)
                db.AddParameter("p_CREATED_BY", pCustomerLocation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerLocation.CreatedOn)
                db.AddParameter("p_LOCATION_KEY_ID", pCustomerLocation.LocationKeyId)
                db.AddParameter("P_LONGITUDE", pCustomerLocation.Longitude)
                db.AddParameter("P_LATITUDE", pCustomerLocation.Latitude)
                db.AddParameter("p_ErrorMsg", pCustomerLocation.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_LOCATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerLocation.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerLocation.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerLocation.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerLocation"></param>
        ''' <returns>Return pCustomerLocation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerLocation.TerminalId)
                db.AddParameter("p_CUSTOMER_ID", pCustomerLocation.CustomerId)
                db.AddParameter("p_LOCATION_ID", pCustomerLocation.LocationId)
                db.AddParameter("p_ADDRESS", pCustomerLocation.Address)
                db.AddParameter("p_CREATED_BY", pCustomerLocation.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCustomerLocation.CreatedOn)
                db.AddParameter("p_LOCATION_KEY_ID", pCustomerLocation.LocationKeyId)
                db.AddParameter("p_ErrorMsg", pCustomerLocation.Errormsg, ParameterDirection.Output)
                db.AddParameter("P_LONGITUDE", pCustomerLocation.Longitude)
                db.AddParameter("P_LATITUDE", pCustomerLocation.Latitude)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_LOCATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerLocation.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCustomerLocation.ErrorMsg = ex.Message
                End Try
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCustomerLocation.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                PCustomerLocation.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_ID").ToString <> "" Then
                                PCustomerLocation.LocationId = dbr("LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PCustomerLocation.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PCustomerLocation.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PCustomerLocation.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_KEY_ID").ToString <> "" Then
                                PCustomerLocation.LocationKeyId = dbr("LOCATION_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LONGITUDE").ToString <> "" Then
                                pCustomerLocation.Longitude = dbr("LONGITUDE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LATITUDE").ToString <> "" Then
                                pCustomerLocation.Latitude = dbr("LATITUDE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCustomerLocation.ErrorMsg = ex.Message
            End Try
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerLocation As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerLocation
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("LOCATION_ID").ToString <> "" Then
                                temp.LocationId = dbr("LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
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
                            If dbr("LOCATION_KEY_ID").ToString <> "" Then
                                temp.LocationKeyId = dbr("LOCATION_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LONGITUDE").ToString <> "" Then
                                temp.Longitude = dbr("LONGITUDE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LATITUDE").ToString <> "" Then
                                temp.Latitude = dbr("LATITUDE")
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
        Public Shared Function ReturnCustomerLocation(ByVal pCustomerLocation As CustomerLocation) As CustomerLocation
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_LOCATION_BY_ID", pCustomerLocation.TerminalId & "," & pCustomerLocation.LocationKeyId)
                pCustomerLocation = ReturnObjectValues(dbr, pCustomerLocation)
                dbr.Close()
            Catch ex As Exception
                pCustomerLocation.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerLocation
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerLocationList (ByVal pCustomerLocation As CustomerLocation) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerLocation As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_LOCATION_BY_ALL", pCustomerLocation.TerminalId & "," & pCustomerLocation.CustomerId)
                arrCustomerLocation = ReturnObjectValuesList(dbr, arrCustomerLocation)
                dbr.Close()
            Catch ex As Exception
                arrCustomerLocation = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerLocation
        End Function
    End Class
End Namespace
