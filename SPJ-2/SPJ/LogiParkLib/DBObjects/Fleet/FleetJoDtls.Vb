Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetJoDtls
    ''' @author	: Santosh Singh- 30/8/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetJoDtls

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngJoId As Long ' Define Private Variable JoId With DataType As Long 
        Private strJoDate As String ' Define Private Variable JoDate With DataType As String 
        Private strJoValidity As String ' Define Private Variable JoDate With DataType As String 
        Private strJoNo As String ' Define Private Variable JoNo With DataType As String 
        Private strJoFor As String ' Define Private Variable JoDate With DataType As String 
        Private strJoType As String ' Define Private Variable JoType With DataType As String 
        Private strLocation As String ' Define Private Variable Location With DataType As String 
        Private lngVehicleId As Long ' Define Private Variable VehicleId With DataType As Long 
        Private strVehicleNo As String ' Define Private Variable VehicleNo With DataType As String 
        Private strServeyBy As String ' Define Private Variable ServeyBy With DataType As String 
        Private lngDriverId As Long ' Define Private Variable DriverId With DataType As Long 
        Private strCloseDate As String ' Define Private Variable CloseDate With DataType As String 
        Private strNote As String ' Define Private Variable Note With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngWorkshopId As Long ' Define Private Variable Advance With DataType As Long 
        Private lngAdvance As Long ' Define Private Variable Advance With DataType As Long 
        Private lngOilAdvance As Long ' Define Private Variable OilAdvance With DataType As Long 
        Private lngCloseAdvance As Long ' Define Private Variable Advance With DataType As Long 
        Private lngVendorId As Long
        Private dblAvgRate As Double

        Private strCloseNote As String ' Define Private Variable Note With DataType As String 
        Private strCloseBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCloseStatus As String ' Define Private Variable CreatedOn With DataType As String 


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

        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property VendorId() As Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoId
        ''' </summary>
        ''' <value>lngJoId</value>
        ''' <returns> Return lngJoId</returns>
        ''' <remarks> Get or Set the Value of JoId  </remarks>
        '''
        Public Property JoId() As Long
            Get
                Return lngJoId
            End Get
            Set(ByVal value As Long)
                lngJoId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoId
        ''' </summary>
        ''' <value>lngJoId</value>
        ''' <returns> Return lngJoId</returns>
        ''' <remarks> Get or Set the Value of JoId  </remarks>
        '''
        Public Property AvgRate() As Double
            Get
                Return dblAvgRate
            End Get
            Set(ByVal value As Double)
                dblAvgRate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Advance
        ''' </summary>
        ''' <value>lngAdvance</value>
        ''' <returns> Return lngAdvance</returns>
        ''' <remarks> Get or Set the Value of Advance  </remarks>
        '''
        Public Property WorkshopId() As Long
            Get
                Return lngWorkshopId
            End Get
            Set(ByVal value As Long)
                lngWorkshopId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Advance
        ''' </summary>
        ''' <value>lngAdvance</value>
        ''' <returns> Return lngAdvance</returns>
        ''' <remarks> Get or Set the Value of Advance  </remarks>
        '''
        Public Property Advance() As Long
            Get
                Return lngAdvance
            End Get
            Set(ByVal value As Long)
                lngAdvance = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Advance
        ''' </summary>
        ''' <value>lngAdvance</value>
        ''' <returns> Return lngAdvance</returns>
        ''' <remarks> Get or Set the Value of Advance  </remarks>
        '''
        Public Property CloseAdvance() As Long
            Get
                Return lngCloseAdvance
            End Get
            Set(ByVal value As Long)
                lngCloseAdvance = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OilAdvance
        ''' </summary>
        ''' <value>lngOilAdvance</value>
        ''' <returns> Return lngOilAdvance</returns>
        ''' <remarks> Get or Set the Value of OilAdvance  </remarks>
        '''
        Public Property OilAdvance() As Long
            Get
                Return lngOilAdvance
            End Get
            Set(ByVal value As Long)
                lngOilAdvance = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of JoDate
        ''' </summary>
        ''' <value>strJoDate</value>
        ''' <returns> Return strJoDate</returns>
        ''' <remarks> Get or Set the Value of JoDate  </remarks>
        '''
        Public Property JoDate() As String
            Get
                Return strJoDate
            End Get
            Set(ByVal value As String)
                strJoDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of JoDate
        ''' </summary>
        ''' <value>strJoDate</value>
        ''' <returns> Return strJoDate</returns>
        ''' <remarks> Get or Set the Value of JoDate  </remarks>
        '''
        Public Property JoValidity() As String
            Get
                Return strJoValidity
            End Get
            Set(ByVal value As String)
                strJoValidity = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of JoDate
        ''' </summary>
        ''' <value>strJoDate</value>
        ''' <returns> Return strJoDate</returns>
        ''' <remarks> Get or Set the Value of JoDate  </remarks>
        '''
        Public Property JoFor() As String
            Get
                Return strJoFor
            End Get
            Set(ByVal value As String)
                strJoFor = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoNo
        ''' </summary>
        ''' <value>strJoNo</value>
        ''' <returns> Return strJoNo</returns>
        ''' <remarks> Get or Set the Value of JoNo  </remarks>
        '''
        Public Property JoNo() As String
            Get
                Return strJoNo
            End Get
            Set(ByVal value As String)
                strJoNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoType
        ''' </summary>
        ''' <value>strJoType</value>
        ''' <returns> Return strJoType</returns>
        ''' <remarks> Get or Set the Value of JoType  </remarks>
        '''
        Public Property JoType() As String
            Get
                Return strJoType
            End Get
            Set(ByVal value As String)
                strJoType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Location
        ''' </summary>
        ''' <value>strLocation</value>
        ''' <returns> Return strLocation</returns>
        ''' <remarks> Get or Set the Value of Location  </remarks>
        '''
        Public Property Location() As String
            Get
                Return strLocation
            End Get
            Set(ByVal value As String)
                strLocation = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Location
        ''' </summary>
        ''' <value>strLocation</value>
        ''' <returns> Return strLocation</returns>
        ''' <remarks> Get or Set the Value of Location  </remarks>
        '''
        Public Property CloseBy() As String
            Get
                Return strCloseBy
            End Get
            Set(ByVal value As String)
                strCloseBy = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Location
        ''' </summary>
        ''' <value>strLocation</value>
        ''' <returns> Return strLocation</returns>
        ''' <remarks> Get or Set the Value of Location  </remarks>
        '''
        Public Property CloseStatus() As String
            Get
                Return strCloseStatus
            End Get
            Set(ByVal value As String)
                strCloseStatus = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Location
        ''' </summary>
        ''' <value>strLocation</value>
        ''' <returns> Return strLocation</returns>
        ''' <remarks> Get or Set the Value of Location  </remarks>
        '''
        Public Property CloseNote() As String
            Get
                Return strCloseNote
            End Get
            Set(ByVal value As String)
                strCloseNote = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VehicleId
        ''' </summary>
        ''' <value>lngVehicleId</value>
        ''' <returns> Return lngVehicleId</returns>
        ''' <remarks> Get or Set the Value of VehicleId  </remarks>
        '''
        Public Property VehicleId() As Long
            Get
                Return lngVehicleId
            End Get
            Set(ByVal value As Long)
                lngVehicleId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VehicleNo
        ''' </summary>
        ''' <value>strVehicleNo</value>
        ''' <returns> Return strVehicleNo</returns>
        ''' <remarks> Get or Set the Value of VehicleNo  </remarks>
        '''
        Public Property VehicleNo() As String
            Get
                Return strVehicleNo
            End Get
            Set(ByVal value As String)
                strVehicleNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServeyBy
        ''' </summary>
        ''' <value>strServeyBy</value>
        ''' <returns> Return strServeyBy</returns>
        ''' <remarks> Get or Set the Value of ServeyBy  </remarks>
        '''
        Public Property ServeyBy() As String
            Get
                Return strServeyBy
            End Get
            Set(ByVal value As String)
                strServeyBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DriverId
        ''' </summary>
        ''' <value>lngDriverId</value>
        ''' <returns> Return lngDriverId</returns>
        ''' <remarks> Get or Set the Value of DriverId  </remarks>
        '''
        Public Property DriverId() As Long
            Get
                Return lngDriverId
            End Get
            Set(ByVal value As Long)
                lngDriverId = value
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
        ''' Get or Set the Value of Note
        ''' </summary>
        ''' <value>strNote</value>
        ''' <returns> Return strNote</returns>
        ''' <remarks> Get or Set the Value of Note  </remarks>
        '''
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal value As String)
                strNote = value
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
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngCompanyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
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
            lngJoId = 0
            strJoDate = ""
            strJoNo = ""
            strJoValidity = ""
            strJoFor = ""
            strJoType = ""
            strLocation = ""
            lngVehicleId = 0
            strVehicleNo = ""
            strServeyBy = ""
            lngDriverId = 0
            strCloseDate = ""
            strNote = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngCompanyId = 0
            strErrormsg = ""
            lngAdvance = 0
            lngWorkshopId = 0
            lngOilAdvance = 0
            lngCloseAdvance = 0
            lngVendorId = 0
            dblAvgRate = 0
            strCloseBy = ""
            strCloseNote = ""
            strCloseStatus = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetJoDtls"></param>
        ''' <returns>Return pFleetJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoDtls.TerminalId)
                db.AddParameter("p_JO_ID", pFleetJoDtls.JoId, ParameterDirection.Output)
                db.AddParameter("p_JO_DATE", pFleetJoDtls.JoDate, ParameterDirection.Output)
                db.AddParameter("p_JO_NO", pFleetJoDtls.JoNo, ParameterDirection.Output)
                db.AddParameter("p_JO_VALIDITY", pFleetJoDtls.JoValidity, ParameterDirection.Output)
                db.AddParameter("p_JO_TYPE", pFleetJoDtls.JoType)
                db.AddParameter("p_JO_FOR", pFleetJoDtls.JoFor)
                db.AddParameter("p_LOCATION", pFleetJoDtls.Location)
                db.AddParameter("p_VEHICLE_ID", pFleetJoDtls.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetJoDtls.VehicleNo)
                db.AddParameter("p_SERVEY_BY", pFleetJoDtls.ServeyBy)
                db.AddParameter("p_DRIVER_ID", pFleetJoDtls.DriverId)
                db.AddParameter("p_CLOSE_DATE", pFleetJoDtls.CloseDate)
                db.AddParameter("p_NOTE", pFleetJoDtls.Note)
                db.AddParameter("p_CREATED_BY", pFleetJoDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetJoDtls.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pFleetJoDtls.CompanyId)
                db.AddParameter("p_WORKSHOP_ID", pFleetJoDtls.WorkshopId)

                db.AddParameter("p_ADVANCE", pFleetJoDtls.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetJoDtls.OilAdvance)
                db.AddParameter("p_ErrorMsg", pFleetJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetJoDtls.JoId = db.Parameters.Item("p_JO_ID").value
                    pFleetJoDtls.JoDate = db.Parameters.Item("p_JO_DATE").value.ToString
                    pFleetJoDtls.JoNo = db.Parameters.Item("p_JO_NO").value.ToString
                End If

                If pFleetJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetJoDtls"></param>
        ''' <returns>Return pFleetJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoDtls.TerminalId)
                db.AddParameter("p_JO_ID", pFleetJoDtls.JoId, ParameterDirection.Output)
                db.AddParameter("p_JO_DATE", pFleetJoDtls.JoDate, ParameterDirection.InputOutput)
                db.AddParameter("p_JO_NO", pFleetJoDtls.JoNo, ParameterDirection.Output)
                db.AddParameter("p_JO_VALIDITY", pFleetJoDtls.JoValidity, ParameterDirection.InputOutput)
                db.AddParameter("p_JO_TYPE", pFleetJoDtls.JoType)
                db.AddParameter("p_JO_FOR", pFleetJoDtls.JoFor)
                db.AddParameter("p_LOCATION", pFleetJoDtls.Location)
                db.AddParameter("p_VEHICLE_ID", pFleetJoDtls.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetJoDtls.VehicleNo)
                db.AddParameter("p_SERVEY_BY", pFleetJoDtls.ServeyBy)
                db.AddParameter("p_DRIVER_ID", pFleetJoDtls.DriverId)
                db.AddParameter("p_CLOSE_DATE", pFleetJoDtls.CloseDate)
                db.AddParameter("p_NOTE", pFleetJoDtls.Note)
                db.AddParameter("p_CREATED_BY", pFleetJoDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetJoDtls.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pFleetJoDtls.CompanyId)
                db.AddParameter("p_WORKSHOP_ID", pFleetJoDtls.WorkshopId)
                db.AddParameter("p_ADVANCE", pFleetJoDtls.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetJoDtls.OilAdvance)
                db.AddParameter("p_VENDOR_ID", pFleetJoDtls.VendorId)
                db.AddParameter("p_ErrorMsg", pFleetJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetJoDtls.JoId = db.Parameters.Item("p_JO_ID").value
                    pFleetJoDtls.JoDate = db.Parameters.Item("p_JO_DATE").value.ToString
                    pFleetJoDtls.JoNo = db.Parameters.Item("p_JO_NO").value.ToString
                    pFleetJoDtls.JoValidity = db.Parameters.Item("p_JO_VALIDITY").value.ToString
                End If
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetJoDtls"></param>
        ''' <returns>Return pFleetJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoDtls.TerminalId)
                db.AddParameter("p_JO_ID", pFleetJoDtls.JoId, ParameterDirection.Output)
                db.AddParameter("p_JO_DATE", pFleetJoDtls.JoDate)
                db.AddParameter("p_JO_NO", pFleetJoDtls.JoNo, ParameterDirection.Output)
                db.AddParameter("p_JO_TYPE", pFleetJoDtls.JoType)
                db.AddParameter("p_LOCATION", pFleetJoDtls.Location)
                db.AddParameter("p_VEHICLE_ID", pFleetJoDtls.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetJoDtls.VehicleNo)
                db.AddParameter("p_SERVEY_BY", pFleetJoDtls.ServeyBy)
                db.AddParameter("p_DRIVER_ID", pFleetJoDtls.DriverId)
                db.AddParameter("p_CLOSE_DATE", pFleetJoDtls.CloseDate)
                db.AddParameter("p_NOTE", pFleetJoDtls.Note)
                db.AddParameter("p_CREATED_BY", pFleetJoDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetJoDtls.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pFleetJoDtls.CompanyId)
                db.AddParameter("p_ErrorMsg", pFleetJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetJoDtls"></param>
        ''' <returns>Return pFleetJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetJoDtls.TerminalId)
                db.AddParameter("p_JO_ID", pFleetJoDtls.JoId)
                db.AddParameter("p_DRIVER_ID", pFleetJoDtls.DriverId)
                db.AddParameter("p_ADVANCE", pFleetJoDtls.Advance)
                db.AddParameter("p_NOTE", pFleetJoDtls.Note)
                db.AddParameter("p_CLOSE_ADVANCE", pFleetJoDtls.CloseAdvance)
                db.AddParameter("p_CLOSE_DATE", pFleetJoDtls.CloseDate)
                db.AddParameter("p_CLOSE_NOTE", pFleetJoDtls.CloseNote)
                db.AddParameter("p_CLOSE_STATUS", pFleetJoDtls.CloseStatus)
                db.AddParameter("p_CLOSE_BY", pFleetJoDtls.CloseBy)
                db.AddParameter("p_ErrorMsg", pFleetJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pFleetJoDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                pFleetJoDtls.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                pFleetJoDtls.JoDate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                pFleetJoDtls.JoNo = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_VALIDITY").ToString <> "" Then
                                pFleetJoDtls.JoValidity = dbr("JO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_FOR").ToString <> "" Then
                                pFleetJoDtls.JoFor = dbr("JO_FOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                pFleetJoDtls.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION").ToString <> "" Then
                                pFleetJoDtls.Location = dbr("LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                pFleetJoDtls.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                pFleetJoDtls.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVEY_BY").ToString <> "" Then
                                pFleetJoDtls.ServeyBy = dbr("SERVEY_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                pFleetJoDtls.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_DATE").ToString <> "" Then
                                pFleetJoDtls.CloseDate = dbr("CLOSE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NOTE").ToString <> "" Then
                                pFleetJoDtls.Note = dbr("NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetJoDtls.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetJoDtls.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pFleetJoDtls.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WORKSHOP_ID").ToString <> "" Then
                                pFleetJoDtls.WorkshopId = dbr("WORKSHOP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE").ToString <> "" Then
                                pFleetJoDtls.Advance = dbr("ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_ADVANCE").ToString <> "" Then
                                pFleetJoDtls.OilAdvance = dbr("OIL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_ADVANCE").ToString <> "" Then
                                pFleetJoDtls.CloseAdvance = dbr("CLOSE_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_BY").ToString <> "" Then
                                pFleetJoDtls.CloseBy = dbr("CLOSE_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_NOTE").ToString <> "" Then
                                pFleetJoDtls.CloseNote = dbr("CLOSE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_STATUS").ToString <> "" Then
                                pFleetJoDtls.CloseStatus = dbr("CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pFleetJoDtls.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetJoDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetJoDtls
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                temp.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                temp.JoDate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                temp.JoNo = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                temp.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_VALIDITY").ToString <> "" Then
                                temp.JoValidity = dbr("JO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_FOR").ToString <> "" Then
                                temp.JoFor = dbr("JO_FOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION").ToString <> "" Then
                                temp.Location = dbr("LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                temp.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                temp.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVEY_BY").ToString <> "" Then
                                temp.ServeyBy = dbr("SERVEY_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                temp.DriverId = dbr("DRIVER_ID")
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
                            If dbr("NOTE").ToString <> "" Then
                                temp.Note = dbr("NOTE")
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
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE").ToString <> "" Then
                                temp.Advance = dbr("ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_ADVANCE").ToString <> "" Then
                                temp.OilAdvance = dbr("OIL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WORKSHOP_ID").ToString <> "" Then
                                temp.WorkshopId = dbr("WORKSHOP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_ADVANCE").ToString <> "" Then
                                temp.CloseAdvance = dbr("CLOSE_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_BY").ToString <> "" Then
                                temp.CloseBy = dbr("CLOSE_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_NOTE").ToString <> "" Then
                                temp.CloseNote = dbr("CLOSE_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_STATUS").ToString <> "" Then
                                temp.CloseStatus = dbr("CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                temp.VendorId = dbr("VENDOR_ID")
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
        Public Shared Function ReturnFleetJoDtls(ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_DTLS", pFleetJoDtls.VehicleId & ",'" & pFleetJoDtls.VehicleNo & "'")
                pFleetJoDtls = ReturnObjectValues(dbr, pFleetJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetJoDtlsByJoNo(ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_DTLS_BY_NO", pFleetJoDtls.TerminalId & "," & pFleetJoDtls.JoId & "")
                pFleetJoDtls = ReturnObjectValues(dbr, pFleetJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetJoDtlsList(ByVal pFleetJoDtls As FleetJoDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetJoDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_DTLS", "' '")
                arrFleetJoDtls = ReturnObjectValuesList(dbr, arrFleetJoDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetJoDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetJoVehicleNo(ByVal pFleetJoDtls As FleetJoDtls) As FleetJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_JO_DTLS_VEHICLE", pFleetJoDtls.TerminalId & ",'" & pFleetJoDtls.VehicleNo & "'")
                pFleetJoDtls = ReturnObjectValues(dbr, pFleetJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetJoDtls
        End Function
    End Class
End Namespace
