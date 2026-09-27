Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  eLOGiFleet :: Fleet Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetGrMapping
    ''' @author	: Amit K. Singh- 10/11/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetGrMapping

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCompanyID As Long
        Private lngGrId As Long ' Define Private Variable GrId With DataType As Long 
        Private lngGrNo As Long ' Define Private Variable GrNo With DataType As Long 
        Private strGrDate As String ' Define Private Variable GrDate With DataType As String 
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strVehicleNo As String
        Private lngCustomerId As Long  ' Define Private Variable CustomerId With DataType As Long 
        Private lngTransporterId As Long
        Private lngAdvance As Long ' Define Private Variable Advance With DataType As Long 
        Private lngOilAdvance As Long ' Define Private Variable OilAdvance With DataType As Long 
        Private strFactoryLocation As String ' Define Private Variable FactoryLocation With DataType As String
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strTripType As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngDriverId As Long
        Private lngClosingAmt As Long
        Private strCloseStatus As String
        Private strCloseDate As String
        Private strRemark As String
        Private lngLineId As Long
        Private lngCHAId As Long
        Private lngPetrolVendor As Long
        Private strSlipNo As String
        Private lngOtherAmt As Long
        Private strOtherReason As String
        Private strPrintStatus As String
        Private strGRRemark As String
        Private strFromLocation As String
        Private strToLocation As String
        Private lngCGR As Long
        Private lngFPOD As Long
        Private lngPOL As Long
        Private lngContJoId As Long
        Private lngConsignmentType As Long

        Private arrFleetGRList As ArrayList
        Public Property FleetGRList() As ArrayList
            Get
                Return arrFleetGRList
            End Get
            Set(ByVal value As ArrayList)
                arrFleetGRList = value
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

        Public Property ContJoId() As Long
            Get
                Return lngContJoId
            End Get
            Set(ByVal value As Long)
                lngContJoId = value
            End Set
        End Property

        Public Property CompanyId() As Long
            Get
                Return lngCompanyID
            End Get
            Set(ByVal value As Long)
                lngCompanyID = value
            End Set
        End Property

        Public Property FPOD() As Long
            Get
                Return lngFPOD
            End Get
            Set(ByVal value As Long)
                lngFPOD = value
            End Set
        End Property

        Public Property POL() As Long
            Get
                Return lngPOL
            End Get
            Set(ByVal value As Long)
                lngPOL = value
            End Set
        End Property

        Public Property ConsignmentType() As Long
            Get
                Return lngConsignmentType
            End Get
            Set(ByVal value As Long)
                lngConsignmentType = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of GrId
        ''' </summary>
        ''' <value>lngGrId</value>
        ''' <returns> Return lngGrId</returns>
        ''' <remarks> Get or Set the Value of GrId  </remarks>
        '''
        Public Property GrId() As Long
            Get
                Return lngGrId
            End Get
            Set(ByVal value As Long)
                lngGrId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of GrId
        ''' </summary>
        ''' <value>lngGrId</value>
        ''' <returns> Return lngGrId</returns>
        ''' <remarks> Get or Set the Value of GrId  </remarks>
        '''
        Public Property PetrolVendor() As Long
            Get
                Return lngPetrolVendor
            End Get
            Set(ByVal value As Long)
                lngPetrolVendor = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrNo
        ''' </summary>
        ''' <value>lngGrNo</value>
        ''' <returns> Return lngGrNo</returns>
        ''' <remarks> Get or Set the Value of GrNo  </remarks>
        '''
        Public Property GrNo() As Long
            Get
                Return lngGrNo
            End Get
            Set(ByVal value As Long)
                lngGrNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrDate
        ''' </summary>
        ''' <value>strGrDate</value>
        ''' <returns> Return strGrDate</returns>
        ''' <remarks> Get or Set the Value of GrDate  </remarks>
        '''
        Public Property GrDate() As String
            Get
                Return strGrDate
            End Get
            Set(ByVal value As String)
                strGrDate = value
            End Set
        End Property
        Public Property GrRemark() As String
            Get
                Return strGRRemark
            End Get
            Set(ByVal value As String)
                strGRRemark = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of GrDate
        ''' </summary>
        ''' <value>strGrDate</value>
        ''' <returns> Return strGrDate</returns>
        ''' <remarks> Get or Set the Value of GrDate  </remarks>
        '''
        Public Property SlipNo() As String
            Get
                Return strSlipNo
            End Get
            Set(ByVal value As String)
                strSlipNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyContId
        ''' </summary>
        ''' <value>lngMtyContId</value>
        ''' <returns> Return lngMtyContId</returns>
        ''' <remarks> Get or Set the Value of MtyContId  </remarks>
        '''
        Public Property MtyContId() As Long
            Get
                Return lngMtyContId
            End Get
            Set(ByVal value As Long)
                lngMtyContId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property ContNo() As String
            Get
                Return strContNo
            End Get
            Set(ByVal value As String)
                strContNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks> Get or Set the Value of ContSize  </remarks>
        '''
        Public Property ContSize() As String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property ContType() As String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property

        Public Property VehicleNo() As String
            Get
                Return strVehicleNo
            End Get
            Set(ByVal value As String)
                strVehicleNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CommodityType
        ''' </summary>
        ''' <value>strCommodityType</value>
        ''' <returns> Return strCommodityType</returns>
        ''' <remarks> Get or Set the Value of CommodityType  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property

        Public Property TransporterId() As String
            Get
                Return lngTransporterId
            End Get
            Set(ByVal value As String)
                lngTransporterId = value
            End Set
        End Property

        Public Property LineId() As Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property
        Public Property CHAId() As Long
            Get
                Return lngCHAId
            End Get
            Set(ByVal value As Long)
                lngCHAId = value
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
        ''' Get or Set the Value of FactoryLocation
        ''' </summary>
        ''' <value>lngFactoryLocation</value>
        ''' <returns> Return lngFactoryLocation</returns>
        ''' <remarks> Get or Set the Value of FactoryLocation  </remarks>
        '''
        Public Property FactoryLocation() As String
            Get
                Return strFactoryLocation
            End Get
            Set(ByVal value As String)
                strFactoryLocation = value
            End Set
        End Property
        Public Property FromLocation() As String
            Get
                Return strFromLocation
            End Get
            Set(ByVal value As String)
                strFromLocation = value
            End Set
        End Property
        Public Property ToLocation() As String
            Get
                Return strToLocation
            End Get
            Set(ByVal value As String)
                strToLocation = value
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
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property PrintStatus() As String
            Get
                Return strPrintStatus
            End Get
            Set(ByVal value As String)
                strPrintStatus = value
            End Set
        End Property

        Public Property TripType() As String
            Get
                Return strTripType
            End Get
            Set(ByVal value As String)
                strTripType = value
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

        Public Property DriverId() As Long
            Get
                Return lngDriverId
            End Get
            Set(ByVal value As Long)
                lngDriverId = value
            End Set
        End Property

        Public Property ClosingAmt() As Long
            Get
                Return lngClosingAmt
            End Get
            Set(ByVal value As Long)
                lngClosingAmt = value
            End Set
        End Property

        Public Property CloseDate() As String
            Get
                Return strCloseDate
            End Get
            Set(ByVal value As String)
                strCloseDate = value
            End Set
        End Property

        Public Property OtherAmt() As Long
            Get
                Return lngOtherAmt
            End Get
            Set(ByVal value As Long)
                lngOtherAmt = value
            End Set
        End Property

        Public Property OtherReason() As String
            Get
                Return strOtherReason
            End Get
            Set(ByVal value As String)
                strOtherReason = value
            End Set
        End Property

        Public Property Remark() As String
            Get
                Return strRemark
            End Get
            Set(ByVal value As String)
                strRemark = value
            End Set
        End Property

        Public Property CloseStatus() As String
            Get
                Return strCloseStatus
            End Get
            Set(ByVal value As String)
                strCloseStatus = value
            End Set
        End Property
        Public Property CGR() As Long
            Get
                Return lngCGR
            End Get
            Set(ByVal value As Long)
                lngCGR = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngCompanyID = 0
            lngGrId = 0
            lngGrNo = 0
            strGrDate = ""
            lngMtyContId = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            strVehicleNo = ""
            lngCustomerId = 0
            lngTransporterId = 0
            lngAdvance = 0
            lngOilAdvance = 0
            strFactoryLocation = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strTripType = ""
            strErrormsg = ""
            lngDriverId = 0
            lngClosingAmt = 0
            strCloseDate = ""
            lngOtherAmt = 0
            strOtherReason = ""
            strRemark = ""
            strCloseStatus = ""
            lngLineId = 0
            strSlipNo = ""
            lngCHAId = 0
            lngPetrolVendor = 0
            strPrintStatus = ""
            strGRRemark = ""
            strFromLocation = ""
            strToLocation = ""
            lngCGR = 0
            lngFPOD = 0
            lngPOL = 0
            lngContJoId = 0
            lngConsignmentType = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetGrMapping.TerminalId)
                db.AddParameter("p_COMAPNY_ID", pFleetGrMapping.CompanyId)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GrId, ParameterDirection.Output)
                db.AddParameter("p_GR_NO", pFleetGrMapping.GrNo, ParameterDirection.InputOutput)
                db.AddParameter("p_GR_DATE", pFleetGrMapping.GrDate)
                db.AddParameter("p_MTY_CONT_ID", pFleetGrMapping.MtyContId)
                db.AddParameter("p_CONT_NO", pFleetGrMapping.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetGrMapping.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetGrMapping.ContType)
                db.AddParameter("p_VEHICLE_NO", pFleetGrMapping.VehicleNo)
                db.AddParameter("p_CUSTOMER_ID", pFleetGrMapping.CustomerId)
                db.AddParameter("p_TRANSPORTER_ID", pFleetGrMapping.TransporterId)
                db.AddParameter("p_ADVANCE", pFleetGrMapping.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetGrMapping.OilAdvance)
                db.AddParameter("p_FACTORY_LOCATION", pFleetGrMapping.FactoryLocation)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CreatedOn, ParameterDirection.Output)
                db.AddParameter("p_TRIP_TYPE", pFleetGrMapping.TripType)
                db.AddParameter("p_DRIVER_ID", pFleetGrMapping.DriverId)
                db.AddParameter("p_OTHER_AMT", pFleetGrMapping.OtherAmt)
                db.AddParameter("p_OTHER_REASON", pFleetGrMapping.OtherReason)
                db.AddParameter("p_LINE_ID", pFleetGrMapping.LineId)
                db.AddParameter("p_CHA_ID", pFleetGrMapping.CHAId)
                db.AddParameter("p_PETROL_VENDOR", pFleetGrMapping.PetrolVendor)
                db.AddParameter("p_SLIP_NO", pFleetGrMapping.SlipNo)
                db.AddParameter("p_GR_REMARK", pFleetGrMapping.GrRemark)
                db.AddParameter("p_FROM_LOCATION", pFleetGrMapping.FromLocation)
                db.AddParameter("p_TO_LOCATION", pFleetGrMapping.ToLocation)
                db.AddParameter("p_C_GR", pFleetGrMapping.CGR)
                db.AddParameter("p_FPOD", pFleetGrMapping.FPOD)
                db.AddParameter("p_POL", pFleetGrMapping.POL)
                db.AddParameter("p_CONSIGNMENT_TYPE", pFleetGrMapping.ConsignmentType)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_GR_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetGrMapping.GrId = db.Parameters.Item("p_GR_ID").value
                    pFleetGrMapping.GrNo = db.Parameters.Item("p_GR_NO").value
                    pFleetGrMapping.CreatedOn = db.Parameters.Item("p_CREATED_ON").value

                End If

                If pFleetGrMapping.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetGrMapping.TerminalId)
                db.AddParameter("p_COMAPNY_ID", pFleetGrMapping.CompanyId)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GrId, ParameterDirection.Output)
                db.AddParameter("p_GR_NO", pFleetGrMapping.GrNo, ParameterDirection.InputOutput)
                db.AddParameter("p_GR_DATE", pFleetGrMapping.GrDate)
                db.AddParameter("p_MTY_CONT_ID", pFleetGrMapping.MtyContId)
                db.AddParameter("p_CONT_NO", pFleetGrMapping.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetGrMapping.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetGrMapping.ContType)
                db.AddParameter("p_VEHICLE_NO", pFleetGrMapping.VehicleNo)
                db.AddParameter("p_CUSTOMER_ID", pFleetGrMapping.CustomerId)
                db.AddParameter("p_TRANSPORTER_ID", pFleetGrMapping.TransporterId)
                db.AddParameter("p_ADVANCE", pFleetGrMapping.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetGrMapping.OilAdvance)
                db.AddParameter("p_FACTORY_LOCATION", pFleetGrMapping.FactoryLocation)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CreatedOn, Global.System.Data.ParameterDirection.Output)
                db.AddParameter("p_TRIP_TYPE", pFleetGrMapping.TripType)
                db.AddParameter("p_DRIVER_ID", pFleetGrMapping.DriverId)
                db.AddParameter("p_OTHER_AMT", pFleetGrMapping.OtherAmt)
                db.AddParameter("p_OTHER_REASON", pFleetGrMapping.OtherReason)
                db.AddParameter("p_LINE_ID", pFleetGrMapping.LineId)
                db.AddParameter("p_CHA_ID", pFleetGrMapping.CHAId)
                db.AddParameter("p_PETROL_VENDOR", pFleetGrMapping.PetrolVendor)
                db.AddParameter("p_SLIP_NO", pFleetGrMapping.SlipNo)
                db.AddParameter("p_GR_REMARK", pFleetGrMapping.GrRemark)
                db.AddParameter("p_FROM_LOCATION", pFleetGrMapping.FromLocation)
                db.AddParameter("p_TO_LOCATION", pFleetGrMapping.ToLocation)
                db.AddParameter("p_C_GR", pFleetGrMapping.CGR)
                db.AddParameter("p_FPOD", pFleetGrMapping.FPOD)
                db.AddParameter("p_POL", pFleetGrMapping.POL)
                db.AddParameter("p_CONSIGNMENT_TYPE", pFleetGrMapping.ConsignmentType)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_GR_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetGrMapping.GrId = db.Parameters.Item("p_GR_ID").value
                    pFleetGrMapping.GrNo = db.Parameters.Item("p_GR_NO").value
                    pFleetGrMapping.CreatedOn = db.Parameters.Item("p_CREATED_ON").value
                End If

            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetGrMapping.TerminalId)
                'db.AddParameter("p_COMAPNY_ID", pFleetGrMapping.CompanyId)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GrId)
                db.AddParameter("p_GR_NO", pFleetGrMapping.GrNo)
                db.AddParameter("p_GR_DATE", pFleetGrMapping.GrDate)
                db.AddParameter("p_MTY_CONT_ID", pFleetGrMapping.MtyContId)
                db.AddParameter("p_CONT_NO", pFleetGrMapping.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetGrMapping.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetGrMapping.ContType)
                db.AddParameter("p_VEHICLE_NO", pFleetGrMapping.VehicleNo)
                db.AddParameter("p_CUSTOMER_ID", pFleetGrMapping.CustomerId)
                db.AddParameter("p_TRANSPORTER_ID", pFleetGrMapping.TransporterId)
                db.AddParameter("p_ADVANCE", pFleetGrMapping.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetGrMapping.OilAdvance)
                db.AddParameter("p_FACTORY_LOCATION", pFleetGrMapping.FactoryLocation)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CreatedOn)
                db.AddParameter("p_TRIP_TYPE", pFleetGrMapping.TripType)
                db.AddParameter("p_DRIVER_ID", pFleetGrMapping.DriverId)
                db.AddParameter("p_CLOSING_AMT", pFleetGrMapping.ClosingAmt)
                db.AddParameter("p_CLOSE_DATE", pFleetGrMapping.CloseDate)
                db.AddParameter("p_REMARK", pFleetGrMapping.Remark)
                db.AddParameter("p_LINE_ID", pFleetGrMapping.LineId)
                db.AddParameter("p_CHA_ID", pFleetGrMapping.CHAId)
                db.AddParameter("p_PETROL_VENDOR", pFleetGrMapping.PetrolVendor)
                db.AddParameter("p_SLIP_NO", pFleetGrMapping.SlipNo)
                db.AddParameter("p_GR_REMARK", pFleetGrMapping.GrRemark)
                db.AddParameter("p_FROM_LOCATION", pFleetGrMapping.FromLocation)
                db.AddParameter("p_TO_LOCATION", pFleetGrMapping.ToLocation)
                db.AddParameter("p_C_GR", pFleetGrMapping.CGR)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_GR_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetGrMapping.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateVehicle(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetGrMapping.TerminalId)
                ' db.AddParameter("p_COMAPNY_ID", pFleetGrMapping.CompanyId)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GrId)
                db.AddParameter("p_CONT_NO", pFleetGrMapping.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetGrMapping.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetGrMapping.ContType)
                db.AddParameter("p_VEHICLE_NO", pFleetGrMapping.VehicleNo)
                db.AddParameter("p_CUSTOMER_ID", pFleetGrMapping.CustomerId)
                db.AddParameter("p_TRANSPORTER_ID", pFleetGrMapping.TransporterId)
                db.AddParameter("p_ADVANCE", pFleetGrMapping.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetGrMapping.OilAdvance)
                db.AddParameter("p_FACTORY_LOCATION", pFleetGrMapping.FactoryLocation)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CreatedOn)
                db.AddParameter("p_TRIP_TYPE", pFleetGrMapping.TripType)
                db.AddParameter("p_DRIVER_ID", pFleetGrMapping.DriverId)
                db.AddParameter("p_OTHER_AMT", pFleetGrMapping.OtherAmt)
                db.AddParameter("p_OTHER_REASON", pFleetGrMapping.OtherReason)
                db.AddParameter("p_PETROL_VENDOR", pFleetGrMapping.PetrolVendor)
                db.AddParameter("p_SLIP_NO", pFleetGrMapping.SlipNo)
                db.AddParameter("p_GR_REMARK", pFleetGrMapping.GrRemark)
                db.AddParameter("p_FROM_LOCATION", pFleetGrMapping.FromLocation)
                db.AddParameter("p_TO_LOCATION", pFleetGrMapping.ToLocation)
                db.AddParameter("p_C_GR", pFleetGrMapping.CGR)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_GR_MAPPING_VEHICLE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetGrMapping.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function
        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetGrMapping.TerminalId)
                'db.AddParameter("p_COMAPNY_ID", pFleetGrMapping.CompanyId)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GrId)
                db.AddParameter("p_GR_NO", pFleetGrMapping.GrNo)
                db.AddParameter("p_GR_DATE", pFleetGrMapping.GrDate)
                db.AddParameter("p_MTY_CONT_ID", pFleetGrMapping.MtyContId)
                db.AddParameter("p_CONT_NO", pFleetGrMapping.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetGrMapping.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetGrMapping.ContType)
                db.AddParameter("p_VEHICLE_NO", pFleetGrMapping.VehicleNo)
                db.AddParameter("p_CUSTOMER_ID", pFleetGrMapping.CustomerId)
                db.AddParameter("p_TRANSPORTER_ID", pFleetGrMapping.TransporterId)
                db.AddParameter("p_ADVANCE", pFleetGrMapping.Advance)
                db.AddParameter("p_OIL_ADVANCE", pFleetGrMapping.OilAdvance)
                db.AddParameter("p_FACTORY_LOCATION", pFleetGrMapping.FactoryLocation)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CreatedOn)
                db.AddParameter("p_TRIP_TYPE", pFleetGrMapping.TripType)
                db.AddParameter("p_LINE_ID", pFleetGrMapping.LineId)
                db.AddParameter("p_CHA_ID", pFleetGrMapping.CHAId)
                db.AddParameter("p_PETROL_VENDOR", pFleetGrMapping.PetrolVendor)
                db.AddParameter("p_SLIP_NO", pFleetGrMapping.SlipNo)
                db.AddParameter("p_GR_REMARK", pFleetGrMapping.GrRemark)
                db.AddParameter("p_FROM_LOCATION", pFleetGrMapping.FromLocation)
                db.AddParameter("p_TO_LOCATION", pFleetGrMapping.ToLocation)
                db.AddParameter("p_C_GR", pFleetGrMapping.CGR)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_GR_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pFleetGrMapping.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pFleetGrMapping.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_ID").ToString <> "" Then
                                pFleetGrMapping.GrId = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_NO").ToString <> "" Then
                                pFleetGrMapping.GrNo = dbr("GR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_DATE").ToString <> "" Then
                                pFleetGrMapping.GrDate = dbr("GR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pFleetGrMapping.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pFleetGrMapping.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pFleetGrMapping.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pFleetGrMapping.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                pFleetGrMapping.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pFleetGrMapping.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                pFleetGrMapping.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADVANCE").ToString <> "" Then
                                pFleetGrMapping.Advance = dbr("ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_ADVANCE").ToString <> "" Then
                                pFleetGrMapping.OilAdvance = dbr("OIL_ADVANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_LOCATION").ToString <> "" Then
                                pFleetGrMapping.FactoryLocation = dbr("FACTORY_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetGrMapping.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetGrMapping.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRIP_TYPE").ToString <> "" Then
                                pFleetGrMapping.TripType = dbr("TRIP_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                pFleetGrMapping.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSING_AMT").ToString <> "" Then
                                pFleetGrMapping.ClosingAmt = dbr("CLOSING_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_DATE").ToString <> "" Then
                                pFleetGrMapping.CloseDate = dbr("CLOSE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK").ToString <> "" Then
                                pFleetGrMapping.Remark = dbr("REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_AMT").ToString <> "" Then
                                pFleetGrMapping.OtherAmt = dbr("OTHER_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_REASON").ToString <> "" Then
                                pFleetGrMapping.OtherReason = dbr("OTHER_REASON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_STATUS").ToString <> "" Then
                                pFleetGrMapping.CloseStatus = dbr("CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pFleetGrMapping.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                pFleetGrMapping.CHAId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PETROL_VENDOR").ToString <> "" Then
                                pFleetGrMapping.PetrolVendor = dbr("PETROL_VENDOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SLIP_NO").ToString <> "" Then
                                pFleetGrMapping.SlipNo = dbr("SLIP_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                pFleetGrMapping.PrintStatus = dbr("PRINT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_REMARK").ToString <> "" Then
                                pFleetGrMapping.GrRemark = dbr("GR_REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                pFleetGrMapping.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_LOCATION").ToString <> "" Then
                                pFleetGrMapping.ToLocation = dbr("TO_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("C_GR").ToString <> "" Then
                                pFleetGrMapping.CGR = dbr("C_GR")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("FPOD").ToString <> "" Then
                                pFleetGrMapping.FPOD = dbr("FPOD")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("POL").ToString <> "" Then
                                pFleetGrMapping.POL = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONSIGNMENT_TYPE").ToString <> "" Then
                                pFleetGrMapping.ConsignmentType = dbr("CONSIGNMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                pFleetGrMapping.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetGrMapping As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetGrMapping
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("GR_ID").ToString <> "" Then
                                temp.GrId = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_NO").ToString <> "" Then
                                temp.GrNo = dbr("GR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_DATE").ToString <> "" Then
                                temp.GrDate = dbr("GR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                temp.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                temp.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                temp.ContType = dbr("CONT_TYPE")
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
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                temp.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                temp.TransporterId = dbr("TRANSPORTER_ID")
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
                            If dbr("FACTORY_LOCATION").ToString <> "" Then
                                temp.FactoryLocation = dbr("FACTORY_LOCATION")
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
                            If dbr("TRIP_TYPE").ToString <> "" Then
                                temp.TripType = dbr("TRIP_TYPE")
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
                            If dbr("CLOSING_AMT").ToString <> "" Then
                                temp.ClosingAmt = dbr("CLOSING_AMT")
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
                            If dbr("REMARK").ToString <> "" Then
                                temp.Remark = dbr("REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_AMT").ToString <> "" Then
                                temp.OtherAmt = dbr("OTHER_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_REASON").ToString <> "" Then
                                temp.OtherReason = dbr("OTHER_REASON")
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
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                temp.CHAId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PETROL_VENDOR").ToString <> "" Then
                                temp.PetrolVendor = dbr("PETROL_VENDOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SLIP_NO").ToString <> "" Then
                                temp.SlipNo = dbr("SLIP_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PRINT_STATUS").ToString <> "" Then
                                temp.PrintStatus = dbr("PRINT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_REMARK").ToString <> "" Then
                                temp.GrRemark = dbr("GR_REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                temp.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_LOCATION").ToString <> "" Then
                                temp.ToLocation = dbr("TO_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("C_GR").ToString <> "" Then
                                temp.CGR = dbr("C_GR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FPOD").ToString <> "" Then
                                temp.FPOD = dbr("FPOD")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("POL").ToString <> "" Then
                                temp.POL = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONSIGNMENT_TYPE").ToString <> "" Then
                                temp.ConsignmentType = dbr("CONSIGNMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                temp.ContJoId = dbr("CONT_JO_ID")
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
        Public Shared Function ReturnFleetGrMapping(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_MAPPING", pFleetGrMapping.TerminalId & "," & pFleetGrMapping.GrId)
                pFleetGrMapping = ReturnObjectValues(dbr, pFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetGrMappingVehicle(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_MAPPING_VEHICLE", pFleetGrMapping.TerminalId & "," & pFleetGrMapping.ContJoId)
                pFleetGrMapping = ReturnObjectValues(dbr, pFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function

        Public Shared Function ReturnFleetGrMappingPrint(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_PRINT", pFleetGrMapping.TerminalId & "," & pFleetGrMapping.GrNo)
                pFleetGrMapping = ReturnObjectValues(dbr, pFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function
        Public Shared Function ReturnFleetGrMappingByGrNo(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_MAPPING_BY_GR_NO", pFleetGrMapping.TerminalId & "," & pFleetGrMapping.GrNo)
                pFleetGrMapping = ReturnObjectValues(dbr, pFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                pFleetGrMapping.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetGrMappingListByContNo(ByVal pFleetGrMapping As FleetGrMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetGrMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_GR_MAPPING_BY_CONT_NO", "'" & pFleetGrMapping.ContNo & "'")
                arrFleetGrMapping = ReturnObjectValuesList(dbr, arrFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                arrFleetGrMapping = Nothing
            End Try
            db.CloseDB()
            Return arrFleetGrMapping
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetGrMappingList(ByVal pFleetGrMapping As FleetGrMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetGrMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_GR_MAPPING", "' '")
                arrFleetGrMapping = ReturnObjectValuesList(dbr, arrFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                arrFleetGrMapping = Nothing
            End Try
            db.CloseDB()
            Return arrFleetGrMapping
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList TerminalId , InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetGrPrint(ByVal pFleetGrMapping As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_GR_SERACH", pFleetGrMapping.TerminalId & ",'" & pFleetGrMapping.ContNo & "'")
                pFleetGrMapping = ReturnObjectValues(dbr, pFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                pFleetGrMapping.Errormsg = Nothing
            End Try
            db.CloseDB()
            Return pFleetGrMapping
        End Function

        Public Shared Function InsertUpdateFleetGrMapping(ByVal pExtFleetGR As FleetGrMapping) As FleetGrMapping
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each pFID As FleetGrMapping In pExtFleetGR.arrFleetGRList
                    FleetGrMapping.InsertTrn(db, pFID)
                    pExtFleetGR.GrNo = pFID.GrNo
                    pExtFleetGR.GrId = pFID.GrId
                    pExtFleetGR.GrDate = pFID.GrDate
                    If pFID.Errormsg <> "" Then
                        Throw New Exception(pFID.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtFleetGR.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtFleetGR
        End Function
    End Class
End Namespace
