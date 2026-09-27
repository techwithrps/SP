Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DamageCode
    ''' @author	: Amit K. Singh- 8/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class LocationMaster

        Private lngLocationRefId As Long ' Define Private Variable LocationRefId With DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngLocationId As Long ' Define Private Variable LocationId With DataType As Long 
        Private strLocationName As String ' Define Private Variable LOcationName With DataType As String 
        Private lngDistance As Long ' Define Private Variable Distance With DataType As Long
        Private dblToll As Double ' Define Private Variable Toll With DataType As Double  
        Private lngAdvanceRs As Long ' Define Private Variable LocationId With DataType As Long 
        Private lngOilAdvance As Long ' Define Private Variable LOcationName With DataType As String 
        Private lngALAdvance As Long ' Define Private Variable LOcationName With DataType As String 
        Private lngDoubleTwenty As Long ' Define Private Variable LOcationName With DataType As String 
        Private lngHandoverLocation As Long
        Private lngCustomerId As Long
        Private lng20oil As Long
        Private lng40oil As Long
        Private lngdouble20oil As Long
        Private StrVehicleType As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Dim arrLocation As ArrayList

        Public Property LocationList() As ArrayList
            Get
                Return arrLocation
            End Get
            Set(ByVal value As ArrayList)
                arrLocation = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of LocationRefId
        ''' </summary>
        ''' <value>lngLocationRefId</value>
        ''' <returns> Return lngLocationRefId</returns>
        ''' <remarks> Get or Set the Value of LocationRefId  </remarks>
        '''
        Public Property LocationRefId() As Long
            Get
                Return lngLocationRefId
            End Get
            Set(ByVal value As Long)
                lngLocationRefId = value
            End Set
        End Property
        Public Property VehicleType() As String
            Get
                Return StrVehicleType
            End Get
            Set(ByVal value As String)
                StrVehicleType = value
            End Set
        End Property
        Public Property HandoverLocation() As Long
            Get
                Return lngHandoverLocation
            End Get
            Set(ByVal value As Long)
                lngHandoverLocation = value
            End Set
        End Property
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
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
        ''' Get or Set the Value of LocationId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngLocationId</returns>
        ''' <remarks> Get or Set the Value of LocationId  </remarks>
        '''
        Public Property LocationId() As Long
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
        ''' <remarks> Get or Set the Value of LocationName </remarks>
        '''
        Public Property LocationName() As String
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
        ''' <remarks> Get or Set the Value of Distance </remarks>
        '''
        Public Property AdvanceRs() As Long
            Get
                Return lngAdvanceRs
            End Get
            Set(ByVal value As Long)
                lngAdvanceRs = value
            End Set
        End Property
        Public Property DoubleTwenty() As Long
            Get
                Return lngDoubleTwenty
            End Get
            Set(ByVal value As Long)
                lngDoubleTwenty = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Distance
        ''' </summary>
        ''' <value>lngDistance</value>
        ''' <returns> Return lngDistance</returns>
        ''' <remarks> Get or Set the Value of Distance </remarks>
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
        ''' Get or Set the Value of Distance
        ''' </summary>
        ''' <value>lngDistance</value>
        ''' <returns> Return lngDistance</returns>
        ''' <remarks> Get or Set the Value of Distance </remarks>
        '''
        Public Property ALAdvance() As Long
            Get
                Return lngALAdvance
            End Get
            Set(ByVal value As Long)
                lngALAdvance = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Distance
        ''' </summary>
        ''' <value>lngDistance</value>
        ''' <returns> Return lngDistance</returns>
        ''' <remarks> Get or Set the Value of Distance </remarks>
        '''
        Public Property Distance() As Long
            Get
                Return lngDistance
            End Get
            Set(ByVal value As Long)
                lngDistance = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Toll
        ''' </summary>
        ''' <value>dblToll</value>
        ''' <returns> Return dblToll</returns>
        ''' <remarks> Get or Set the Value of Toll </remarks>
        '''
        Public Property Toll() As Double
            Get
                Return dblToll
            End Get
            Set(ByVal value As Double)
                dblToll = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Toll
        ''' </summary>
        ''' <value>dblToll</value>
        ''' <returns> Return dblToll</returns>
        ''' <remarks> Get or Set the Value of Toll </remarks>
        '''
        Public Property Oil20() As Long
            Get
                Return lng20oil
            End Get
            Set(ByVal value As Long)
                lng20oil = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Toll
        ''' </summary>
        ''' <value>dblToll</value>
        ''' <returns> Return dblToll</returns>
        ''' <remarks> Get or Set the Value of Toll </remarks>
        '''
        Public Property Oil40() As Long
            Get
                Return lng40oil
            End Get
            Set(ByVal value As Long)
                lng40oil = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Toll
        ''' </summary>
        ''' <value>dblToll</value>
        ''' <returns> Return dblToll</returns>
        ''' <remarks> Get or Set the Value of Toll </remarks>
        '''
        Public Property Double20Oil() As Long
            Get
                Return lngdouble20oil
            End Get
            Set(ByVal value As Long)
                lngdouble20oil = value
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
            lngLocationRefId = 0
            lngTerminalId = 0
            lngLocationId = 0
            strLocationName = ""
            lngDistance = 0
            lngOilAdvance = 0
            lngALAdvance = 0
            lngAdvanceRs = 0
            lngDoubleTwenty = 0
            lngHandoverLocation = 0
            lngCustomerId = 0
            lng20oil = 0
            lng40oil = 0
            lngdouble20oil = 0
            dblToll = 0.0
            StrVehicleType = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pLocationMaster"></param>
        ''' <returns>Return pLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_REF_ID", pLocationMaster.LocationRefId, ParameterDirection.Output)
                db.AddParameter("p_LOCATION_ID", pLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pLocationMaster.Distance)
                db.AddParameter("p_TOLL", pLocationMaster.Toll)
                db.AddParameter("p_ADVANCE_RS", pLocationMaster.AdvanceRs)
                db.AddParameter("p_OIL_ADVANCE", pLocationMaster.OilAdvance)
                db.AddParameter("p_AL_ADVANCE", pLocationMaster.ALAdvance)
                db.AddParameter("p_DOUBLE_TWENTY", pLocationMaster.DoubleTwenty)
                db.AddParameter("p_HANDOVER_LOCATION", pLocationMaster.HandoverLocation)
                db.AddParameter("p_CUSTOMER_ID", pLocationMaster.CustomerId)
                db.AddParameter("p_OIL_20", pLocationMaster.Oil20)
                db.AddParameter("p_OIL_40", pLocationMaster.Oil40)
                db.AddParameter("p_DOUBLE_20_OIL", pLocationMaster.Double20Oil)
                db.AddParameter("p_VEHICLE_TYPE", pLocationMaster.VehicleType)
                db.AddParameter("p_ErrorMsg", pLocationMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pLocationMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pLocationMaster.LocationRefId = db.Parameters.Item("p_LOCATION_REF_ID").value

                If pLocationMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pLocationMaster"></param>
        ''' <returns>Return pLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pLocationMaster As LocationMaster) As LocationMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_LOCATION_REF_ID", pLocationMaster.LocationRefId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pLocationMaster.Distance)
                db.AddParameter("p_TOLL", pLocationMaster.Toll)
                db.AddParameter("p_ADVANCE_RS", pLocationMaster.AdvanceRs)
                db.AddParameter("p_OIL_ADVANCE", pLocationMaster.OilAdvance)
                db.AddParameter("p_AL_ADVANCE", pLocationMaster.ALAdvance)
                db.AddParameter("p_DOUBLE_TWENTY", pLocationMaster.DoubleTwenty)
                db.AddParameter("p_HANDOVER_LOCATION", pLocationMaster.HandoverLocation)
                db.AddParameter("p_CUSTOMER_ID", pLocationMaster.CustomerId)
                db.AddParameter("p_OIL_20", pLocationMaster.Oil20)
                db.AddParameter("p_OIL_40", pLocationMaster.Oil40)
                db.AddParameter("p_DOUBLE_20_OIL", pLocationMaster.Double20Oil)
                db.AddParameter("p_VEHICLE_TYPE", pLocationMaster.VehicleType)
                db.AddParameter("p_ErrorMsg", pLocationMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pLocationMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pLocationMaster.LocationRefId = db.Parameters.Item("p_LOCATION_REF_ID").value


            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pLocationMaster"></param>
        ''' <returns>Return pLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_LOCATION_REF_ID", pLocationMaster.LocationRefId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pLocationMaster.Distance)
                db.AddParameter("p_TOLL", pLocationMaster.Toll)
                db.AddParameter("p_ADVANCE_RS", pLocationMaster.AdvanceRs)
                db.AddParameter("p_OIL_ADVANCE", pLocationMaster.OilAdvance)
                db.AddParameter("p_AL_ADVANCE", pLocationMaster.ALAdvance)
                db.AddParameter("p_DOUBLE_TWENTY", pLocationMaster.DoubleTwenty)
                db.AddParameter("p_HANDOVER_LOCATION", pLocationMaster.HandoverLocation)
                db.AddParameter("p_CUSTOMER_ID", pLocationMaster.CustomerId)
                db.AddParameter("p_OIL_20", pLocationMaster.Oil20)
                db.AddParameter("p_OIL_40", pLocationMaster.Oil40)
                db.AddParameter("p_DOUBLE_20_OIL", pLocationMaster.Double20Oil)
                db.AddParameter("p_VEHICLE_TYPE", pLocationMaster.VehicleType)
                db.AddParameter("p_ErrorMsg", pLocationMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pLocationMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pLocationMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pLocationMaster"></param>
        ''' <returns>Return pLocationMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pLocationMaster As LocationMaster) As LocationMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_LOCATION_REF_ID", pLocationMaster.LocationRefId)
                db.AddParameter("p_TERMINAL_ID", pLocationMaster.TerminalId)
                db.AddParameter("p_LOCATION_ID", pLocationMaster.LocationId)
                db.AddParameter("p_LOCATION_NAME", pLocationMaster.LocationName)
                db.AddParameter("p_DISTANCE", pLocationMaster.Distance)
                db.AddParameter("p_TOLL", pLocationMaster.Toll)
                db.AddParameter("p_ADVANCE_RS", pLocationMaster.AdvanceRs)
                db.AddParameter("p_OIL_ADVANCE", pLocationMaster.OilAdvance)
                db.AddParameter("p_AL_ADVANCE", pLocationMaster.ALAdvance)
                db.AddParameter("p_DOUBLE_TWENTY", pLocationMaster.DoubleTwenty)
                db.AddParameter("p_HANDOVER_LOCATION", pLocationMaster.HandoverLocation)
                db.AddParameter("p_CUSTOMER_ID", pLocationMaster.CustomerId)
                db.AddParameter("p_OIL_20", pLocationMaster.Oil20)
                db.AddParameter("p_OIL_40", pLocationMaster.Oil40)
                db.AddParameter("p_DOUBLE_20_OIL", pLocationMaster.Double20Oil)
                db.AddParameter("p_VEHICLE_TYPE", pLocationMaster.VehicleType)
                db.AddParameter("p_ErrorMsg", pLocationMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_LOCATION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pLocationMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pLocationMaster As LocationMaster) As LocationMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("LOCATION_REF_ID").ToString <> "" Then
                                pLocationMaster.LocationRefId = dbr("LOCATION_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pLocationMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_ID").ToString <> "" Then
                                pLocationMaster.LocationId = dbr("LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCATION_NAME").ToString <> "" Then
                                pLocationMaster.LocationName = dbr("LOCATION_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE").ToString <> "" Then
                                pLocationMaster.Distance = dbr("DISTANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOLL").ToString <> "" Then
                                pLocationMaster.Toll = dbr("TOLL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE_RS").ToString <> "" Then
                                pLocationMaster.AdvanceRs = dbr("ADVANCE_RS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_ADVANCE").ToString <> "" Then
                                pLocationMaster.OilAdvance = dbr("OIL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AL_ADVANCE").ToString <> "" Then
                                pLocationMaster.ALAdvance = dbr("AL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOUBLE_TWENTY").ToString <> "" Then
                                pLocationMaster.DoubleTwenty = dbr("DOUBLE_TWENTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_LOCATION").ToString <> "" Then
                                pLocationMaster.HandoverLocation = dbr("HANDOVER_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pLocationMaster.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_20").ToString <> "" Then
                                pLocationMaster.Oil20 = dbr("OIL_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_40").ToString <> "" Then
                                pLocationMaster.Oil40 = dbr("OIL_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOUBLE_20_OIL").ToString <> "" Then
                                pLocationMaster.Double20Oil = dbr("DOUBLE_20_OIL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                pLocationMaster.VehicleType = dbr("VEHICLE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrLocationMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New LocationMaster
                        Try
                            If dbr("LOCATION_REF_ID").ToString <> "" Then
                                temp.LocationRefId = dbr("LOCATION_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
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
                            If dbr("TOLL").ToString <> "" Then
                                temp.Toll = dbr("TOLL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE_RS").ToString <> "" Then
                                temp.AdvanceRs = dbr("ADVANCE_RS")
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
                            If dbr("AL_ADVANCE").ToString <> "" Then
                                temp.ALAdvance = dbr("AL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOUBLE_TWENTY").ToString <> "" Then
                                temp.DoubleTwenty = dbr("DOUBLE_TWENTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDOVER_LOCATION").ToString <> "" Then
                                temp.HandoverLocation = dbr("HANDOVER_LOCATION")
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
                            If dbr("OIL_20").ToString <> "" Then
                                temp.Oil20 = dbr("OIL_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_40").ToString <> "" Then
                                temp.Oil40 = dbr("OIL_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOUBLE_20_OIL").ToString <> "" Then
                                temp.Double20Oil = dbr("DOUBLE_20_OIL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                temp.VehicleType = dbr("VEHICLE_TYPE")
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

        Public Shared Function InsertUpdateLocationDetails(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect

            Try
                db.BeginTransaction()
                If pLocationMaster.Errormsg = "" Then
                    For Each tgh As LocationMaster In pLocationMaster.LocationList
                        tgh.TerminalId = pLocationMaster.TerminalId
                        If tgh.LocationRefId > 0 Then
                            LocationMaster.UpdateTrn(db, tgh)
                        Else
                            LocationMaster.InsertTrn(db, tgh)
                        End If
                        If tgh.Errormsg <> Nothing Then
                            Throw New Exception(tgh.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pLocationMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
            End Try
            Return pLocationMaster
        End Function
        Public Shared Function ReturnLocationMaster(ByVal pLocationMaster As LocationMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrLocationMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_ALL", "")
                arrLocationMaster = ReturnObjectValuesList(dbr, arrLocationMaster)
                dbr.Close()
            Catch ex As Exception
                arrLocationMaster = Nothing
            End Try
            db.CloseDB()
            Return arrLocationMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnLocationMasterByTerminalId(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_ID", pLocationMaster.TerminalId)
                pLocationMaster = ReturnObjectValues(dbr, pLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnLocationMasterList(ByVal pLocationMaster As LocationMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrLocationMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_ID", pLocationMaster.TerminalId)
                arrLocationMaster = ReturnObjectValuesList(dbr, arrLocationMaster)
                dbr.Close()
            Catch ex As Exception
                arrLocationMaster = Nothing
            End Try
            db.CloseDB()
            Return arrLocationMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnLocationMasterByTerminalIdlocation(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_ID1", pLocationMaster.TerminalId)
                pLocationMaster = ReturnObjectValues(dbr, pLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnLocationMasterListlocation(ByVal pLocationMaster As LocationMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrLocationMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_ID1", pLocationMaster.TerminalId)
                arrLocationMaster = ReturnObjectValuesList(dbr, arrLocationMaster)
                dbr.Close()
            Catch ex As Exception
                arrLocationMaster = Nothing
            End Try
            db.CloseDB()
            Return arrLocationMaster
        End Function
        Public Shared Function ReturnLocationId(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_ID_BY_NAME", pLocationMaster.TerminalId & ",'" & pLocationMaster.LocationName & "'")

                pLocationMaster = ReturnObjectValues(dbr, pLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function

        Public Shared Function ReturnLocationDetailsByTerminalId(ByVal pLocationMaster As LocationMaster) As LocationMaster
            LocationMaster.ReturnLocationDetailsByTerminalId(pLocationMaster)

            Dim tgh As New LocationMaster
            tgh.LocationRefId = pLocationMaster.LocationRefId
            pLocationMaster.LocationList = LocationMaster.ReturnLocationMasterList(tgh)

            Return pLocationMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnLocationMasterByLocationId(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_LOC_ID", pLocationMaster.TerminalId & "," & pLocationMaster.LocationId)
                pLocationMaster = ReturnObjectValues(dbr, pLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function
        Public Shared Function ReturnLocationMasterByHandover(ByVal pLocationMaster As LocationMaster) As LocationMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LOCATION_MASTER_BY_HANDOVER", pLocationMaster.TerminalId & "," & pLocationMaster.LocationId & "," & pLocationMaster.HandoverLocation & "," & pLocationMaster.CustomerId & ",'" & pLocationMaster.VehicleType & "'")
                pLocationMaster = ReturnObjectValues(dbr, pLocationMaster)
                dbr.Close()
            Catch ex As Exception
                pLocationMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pLocationMaster
        End Function
    End Class
End Namespace
