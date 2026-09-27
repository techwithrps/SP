Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetContJoDtls
    ''' @author	: Amit K Singh- 20/12/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetContJoDtls

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngComapnyId As Long
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private lngWeight As Double ' Define Private Variable Gross Weight With DataType As Long 
        Private lngCargoWt As Double ' Define Private Variable Cargo Weight With DataType As Long 
        Private lngTareWt As Double ' Define Private Variable Tare Weight With DataType As Long 
        Private strTripType As String ' Define Private Variable TripType With DataType As String 
        Private strJoType As String ' Define Private Variable JoType With DataType As String 
        Private lngGrId As Long ' Define Private Variable GrId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngVehicleId As Long ' Define Private Variable GrId With DataType As Long 
        Private strSealNo As String ' Define Private Variable Errormsg With DataType As String 
        Private strAgentSeal As String
        Private strBENo As String
        Private strBookingNo As String
        Private strDOValidity As String
        Private lngLineId As Long
        Private strBEDate As String
        Private strRemarks As String
        Private strInvoiceFlagTPT As String
        Private strInvoiceFlagFRT As String
        Private strInvoiceFlagCLR As String
        Private strIcdOutDate As String
        Private strIcdInDate As String
        Private strFactoryInDate As String ' Define Private Variable FactoryIn With DataType As String 
        Private strFactoryOutDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strAllotMentDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strBufferDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strBufferOutDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strEmptyGateInDate As String ' Define Private Variable EmptyGateDate With DataType As String
        Private strVesselName As String ' Define Private Variable VesselName With DataType As String
        Private lngFpod As Long ' Define Private Variable POLId With DataType As Long
        Private lngPol As Long ' Define Private Variable lngPODId With DataType As Long
        Private strValidity As String ' Define Private Variable Validity With DataType As String
        Private strSicutDate As String ' Define Private Variable Validity With DataType As String 
        Private strPortCutOfdate As String ' Define Private Variable Validity With DataType As String 
        Private strETDDate As String ' Define Private Variable Validity With DataType As String 
        Private lngStuffingPOD As Long ' Define Private Variable POLId With DataType As Long
        Private lngStuffingPOL As Long ' Define Private Variable lngPODId With DataType As Long
        Private strUpdatedBy As String ' Define Private Variable UpdatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable UpdatedOn With DataType As String 

        ''Added by Amit K. Singh on 16/04/2026
        Private strIcdOutRemarks As String ' Define Private Variable IcdOutRemarks With DataType As String 
        Private strIcdOutBy As String ' Define Private Variable IcdOutBy With DataType As String 
        Private strIcdOutOn As String ' Define Private Variable IcdOutOn With DataType As String 
        Private strIcdInRemarks As String ' Define Private Variable IcdInRemarks With DataType As String 
        Private strIcdInBy As String ' Define Private Variable IcdInBy With DataType As String 
        Private strIcdInOn As String ' Define Private Variable IcdInOn With DataType As String 
        Private strFactoryInRemarks As String ' Define Private Variable FactoryInRemarks With DataType As String 
        Private strFactoryInBy As String ' Define Private Variable FactoryInBy With DataType As String 
        Private strFactoryInOn As String ' Define Private Variable FactoryInOn With DataType As String 
        Private strFactoryOutRemarks As String ' Define Private Variable FactoryOutRemarks With DataType As String 
        Private strFactoryOutBy As String ' Define Private Variable FactoryOutBy With DataType As String 
        Private strFactoryOutOn As String ' Define Private Variable FactoryOutOn With DataType As String 
        Private strBufferInRemarks As String ' Define Private Variable BufferInRemarks With DataType As String 
        Private strBufferInBy As String ' Define Private Variable BufferInBy With DataType As String 
        Private strBufferInOn As String ' Define Private Variable BufferInOn With DataType As String
        Private strBufferOutRemarks As String ' Define Private Variable BufferOutRemarks With DataType As String 
        Private strBufferOutBy As String ' Define Private Variable BufferOutBy With DataType As String 
        Private strBufferOutOn As String ' Define Private Variable BufferOutOn With DataType As String
        Private strEmptyGateInRemarks As String ' Define Private Variable EmptyGateInRemarks With DataType As String 
        Private strEmptyGateInBy As String ' Define Private Variable EmptyGateInBy With DataType As String 
        Private strEmptyGateInOn As String ' Define Private Variable EmptyGateInOn With DataType As String
        Private strVehicleGateOutDate As String

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
        Public Property CompanyId() As Long
            Get
                Return lngComapnyId
            End Get
            Set(ByVal value As Long)
                lngComapnyId = value
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
        ''' Get or Set the Value of ContJoId
        ''' </summary>
        ''' <value>lngContJoId</value>
        ''' <returns> Return lngContJoId</returns>
        ''' <remarks> Get or Set the Value of ContJoId  </remarks>
        '''
        Public Property ContJoId() As Long
            Get
                Return lngContJoId
            End Get
            Set(ByVal value As Long)
                lngContJoId = value
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
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
            End Set
        End Property
        Public Property BENo() As String
            Get
                Return strBENo
            End Get
            Set(ByVal value As String)
                strBENo = value
            End Set
        End Property
        Public Property BookingNo() As String
            Get
                Return strBookingNo
            End Get
            Set(ByVal value As String)
                strBookingNo = value
            End Set
        End Property
        Public Property AgentSeal() As String
            Get
                Return strAgentSeal
            End Get
            Set(ByVal value As String)
                strAgentSeal = value
            End Set
        End Property
        Public Property DOValidity() As String
            Get
                Return strDOValidity
            End Get
            Set(ByVal value As String)
                strDOValidity = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property SealNo() As String
            Get
                Return strSealNo
            End Get
            Set(ByVal value As String)
                strSealNo = value
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


        ''' <summary>
        ''' Get or Set the Value of Weight
        ''' </summary>
        ''' <value>lngWeight</value>
        ''' <returns> Return lngWeight</returns>
        ''' <remarks> Get or Set the Value of Weight  </remarks>
        '''
        Public Property Weight() As Double
            Get
                Return lngWeight
            End Get
            Set(ByVal value As Double)
                lngWeight = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CargoWt
        ''' </summary>
        ''' <value>lngCargoWt</value>
        ''' <returns> Return lngCargoWt</returns>
        ''' <remarks> Get or Set the Value of CargoWt  </remarks>
        '''
        Public Property CargoWt() As Double
            Get
                Return lngCargoWt
            End Get
            Set(ByVal value As Double)
                lngCargoWt = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TareWt
        ''' </summary>
        ''' <value>lngTareWt</value>
        ''' <returns> Return lngTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property TareWt() As Double
            Get
                Return lngTareWt
            End Get
            Set(ByVal value As Double)
                lngTareWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TripType
        ''' </summary>
        ''' <value>strTripType</value>
        ''' <returns> Return strTripType</returns>
        ''' <remarks> Get or Set the Value of TripType  </remarks>
        '''
        Public Property TripType() As String
            Get
                Return strTripType
            End Get
            Set(ByVal value As String)
                strTripType = value
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
        Public Property VehicleId() As Long
            Get
                Return lngVehicleId
            End Get
            Set(ByVal value As Long)
                lngVehicleId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrId
        ''' </summary>
        ''' <value>lngGrId</value>
        ''' <returns> Return lngGrId</returns>
        ''' <remarks> Get or Set the Value of GrId  </remarks>
        '''
        Public Property BEDate() As String
            Get
                Return strBEDate
            End Get
            Set(ByVal value As String)
                strBEDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of InvoiceFlagTPT
        ''' </summary>
        ''' <value>strInvoiceFlagTPT</value>
        ''' <returns> Return strInvoiceFlagTPT</returns>
        ''' <InvoiceFlagTPT> Get or Set the Value of InvoiceFlagTPT  </InvoiceFlagTPT>
        '''
        Public Property InvoiceFlagTPT() As String
            Get
                Return strInvoiceFlagTPT
            End Get
            Set(ByVal value As String)
                strInvoiceFlagTPT = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of InvoiceFlagFRT
        ''' </summary>
        ''' <value>strInvoiceFlagFRT</value>
        ''' <returns> Return strInvoiceFlagTPT</returns>
        ''' <InvoiceFlagFRT> Get or Set the Value of InvoiceFlagFRT  </InvoiceFlagFRT>
        '''
        Public Property InvoiceFlagFRT() As String
            Get
                Return strInvoiceFlagFRT
            End Get
            Set(ByVal value As String)
                strInvoiceFlagFRT = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of InvoiceFlagCLR
        ''' </summary>
        ''' <value>strInvoiceFlagCLR</value>
        ''' <returns> Return strInvoiceFlagCLR</returns>
        ''' <InvoiceFlagCLR> Get or Set the Value of InvoiceFlagCLR  </InvoiceFlagCLR>
        '''
        Public Property InvoiceFlagCLR() As String
            Get
                Return strInvoiceFlagCLR
            End Get
            Set(ByVal value As String)
                strInvoiceFlagCLR = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of IcdOutDate
        ''' </summary>
        ''' <value>strIcdInDate</value>
        ''' <returns> Return strInvoiceFlagCLR</returns>
        ''' <InvoiceFlagCLR> Get or Set the Value of strIcdOutDate  </InvoiceFlagCLR>
        '''
        Public Property IcdOutDate() As String
            Get
                Return strIcdOutDate
            End Get
            Set(ByVal value As String)
                strIcdOutDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of IcdInDate
        ''' </summary>
        ''' <value>strIcdInDate</value>
        ''' <returns> Return strIcdInDate</returns>
        ''' <InvoiceFlagCLR> Get or Set the Value of IcdInDate  </InvoiceFlagCLR>
        '''
        Public Property IcdInDate() As String
            Get
                Return strIcdInDate
            End Get
            Set(ByVal value As String)
                strIcdInDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of FactoryInDate
        ''' </summary>
        ''' <value>strFactoryIn</value>
        ''' <returns> Return strFactoryIn</returns>
        ''' <remarks> Get or Set the Value of FactoryInDate  </remarks>
        '''
        Public Property FactoryInDate() As String
            Get
                Return strFactoryInDate
            End Get
            Set(ByVal value As String)
                strFactoryInDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of FactoryOutDate
        ''' </summary>
        ''' <value>strFactoryOut</value>
        ''' <returns> Return strFactoryOutDate</returns>
        ''' <remarks> Get or Set the Value of FactoryOutDate  </remarks>
        '''
        Public Property FactoryOutDate() As String
            Get
                Return strFactoryOutDate
            End Get
            Set(ByVal value As String)
                strFactoryOutDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of IcdIn
        ''' </summary>
        ''' <value>strIcdIn</value>
        ''' <returns> Return strIcdIn</returns>
        ''' <remarks> Get or Set the Value of IcdIn  </remarks>
        '''
        Public Property AllotMentDate() As String
            Get
                Return strAllotMentDate
            End Get
            Set(ByVal value As String)
                strAllotMentDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of BufferOutDate
        ''' </summary>
        ''' <value>strBufferOutDate</value>
        ''' <returns> Return strIcdIn</returns>
        ''' <remarks> Get or Set the Value of IcdIn  </remarks>
        '''
        Public Property BufferOutDate() As String
            Get
                Return strBufferOutDate
            End Get
            Set(ByVal value As String)
                strBufferOutDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of EmptyGateInDate
        ''' </summary>
        ''' <value>strEmptyGateInDate</value>
        ''' <returns> Return strEmptyGateInDate</returns>
        ''' <remarks> Get or Set the Value of EmptyGateInDate  </remarks>
        '''
        Public Property EmptyGateInDate() As String
            Get
                Return strEmptyGateInDate
            End Get
            Set(ByVal value As String)
                strEmptyGateInDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdIn
        ''' </summary>
        ''' <value>strIcdIn</value>
        ''' <returns> Return strIcdIn</returns>
        ''' <remarks> Get or Set the Value of IcdIn  </remarks>
        '''
        Public Property BufferDate() As String
            Get
                Return strBufferDate
            End Get
            Set(ByVal value As String)
                strBufferDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Fpod
        ''' </summary>
        ''' <value>lngFpod</value>
        ''' <returns> Return lngFpod</returns>
        ''' <remarks> Get or Set the Value of Fpod  </remarks>
        '''
        Public Property Fpod() As Long
            Get
                Return lngFpod
            End Get
            Set(ByVal value As Long)
                lngFpod = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Pol
        ''' </summary>
        ''' <value>lngPol</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property Pol() As Long
            Get
                Return lngPol
            End Get
            Set(ByVal value As Long)
                lngPol = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of StuffingPOD
        ''' </summary>
        ''' <value>lngstuffingPOD</value>
        ''' <returns> Return lngstuffingPOD</returns>
        ''' <remarks> Get or Set the Value of Fpod  </remarks>
        '''
        Public Property StuffingPOD() As Long
            Get
                Return lngStuffingPOD
            End Get
            Set(ByVal value As Long)
                lngStuffingPOD = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of StuffingPOL
        ''' </summary>
        ''' <value>lngstuffingPOL</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property StuffingPOL() As Long
            Get
                Return lngStuffingPOL
            End Get
            Set(ByVal value As Long)
                lngStuffingPOL = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of VesselName
        ''' </summary>
        ''' <value>strVesselName</value>
        ''' <returns> Return strVesselName</returns>
        ''' <remarks> Get or Set the Value of VesselName  </remarks>
        '''
        Public Property VesselName() As String
            Get
                Return strVesselName
            End Get
            Set(ByVal value As String)
                strVesselName = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Validity
        ''' </summary>
        ''' <value>strValidity</value>
        ''' <returns> Return strValidity</returns>
        ''' <remarks> Get or Set the Value of Validity  </remarks>
        '''
        Public Property Validity() As String
            Get
                Return strValidity
            End Get
            Set(ByVal value As String)
                strValidity = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of SicutDate
        ''' </summary>
        ''' <value>strSicutDate</value>
        ''' <returns> Return strSicutDate</returns>
        ''' <remarks> Get or Set the Value of SicutDate  </remarks>
        '''
        Public Property SicutDate() As String
            Get
                Return strSicutDate
            End Get
            Set(ByVal value As String)
                strSicutDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of PortCutOfdate
        ''' </summary>
        ''' <value>strPortCutOfdate</value>
        ''' <returns> Return strPortCutOfdate</returns>
        ''' <remarks> Get or Set the Value of PortCutOfdate  </remarks>
        '''
        Public Property PortCutOfdate() As String
            Get
                Return strPortCutOfdate
            End Get
            Set(ByVal value As String)
                strPortCutOfdate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ETDDate
        ''' </summary>
        ''' <value>strETDDate</value>
        ''' <returns> Return strETDDate</returns>
        ''' <remarks> Get or Set the Value of ETDDate  </remarks>
        '''
        Public Property ETDDate() As String
            Get
                Return strETDDate
            End Get
            Set(ByVal value As String)
                strETDDate = value
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
        ''' Get or Set the Value of VehicleGateOutDate
        ''' </summary>
        ''' <value>strVehicleGateOutDate</value>
        ''' <returns> Return strVehicleGateOutDate</returns>
        ''' <remarks> Get or Set the Value of VehicleGateOutDate  </remarks>
        '''
        Public Property VehicleGateOutDate() As String
            Get
                Return strVehicleGateOutDate
            End Get
            Set(ByVal value As String)
                strVehicleGateOutDate = value
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
        ''' Get or Set the Value of IcdOutRemarks
        ''' </summary>
        ''' <value>strIcdOutRemarks</value>
        ''' <returns> Return strIcdOutRemarks</returns>
        ''' <remarks> Get or Set the Value of IcdOutRemarks  </remarks>
        '''
        Public Property IcdOutRemarks() As String
            Get
                Return strIcdOutRemarks
            End Get
            Set(ByVal value As String)
                strIcdOutRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdOutBy
        ''' </summary>
        ''' <value>strIcdOutBy</value>
        ''' <returns> Return strIcdOutBy</returns>
        ''' <remarks> Get or Set the Value of IcdOutBy  </remarks>
        '''
        Public Property IcdOutBy() As String
            Get
                Return strIcdOutBy
            End Get
            Set(ByVal value As String)
                strIcdOutBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdOutOn
        ''' </summary>
        ''' <value>strIcdOutOn</value>
        ''' <returns> Return strIcdOutOn</returns>
        ''' <remarks> Get or Set the Value of IcdOutOn  </remarks>
        '''
        Public Property IcdOutOn() As String
            Get
                Return strIcdOutOn
            End Get
            Set(ByVal value As String)
                strIcdOutOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdInRemarks
        ''' </summary>
        ''' <value>strIcdInRemarks</value>
        ''' <returns> Return strIcdInRemarks</returns>
        ''' <remarks> Get or Set the Value of IcdInRemarks  </remarks>
        '''
        Public Property IcdInRemarks() As String
            Get
                Return strIcdInRemarks
            End Get
            Set(ByVal value As String)
                strIcdInRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdInBy
        ''' </summary>
        ''' <value>strIcdInBy</value>
        ''' <returns> Return strIcdInBy</returns>
        ''' <remarks> Get or Set the Value of IcdInBy  </remarks>
        '''
        Public Property IcdInBy() As String
            Get
                Return strIcdInBy
            End Get
            Set(ByVal value As String)
                strIcdInBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdInOn
        ''' </summary>
        ''' <value>strIcdInOn</value>
        ''' <returns> Return strIcdInOn</returns>
        ''' <remarks> Get or Set the Value of IcdInOn  </remarks>
        '''
        Public Property IcdInOn() As String
            Get
                Return strIcdInOn
            End Get
            Set(ByVal value As String)
                strIcdInOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryInRemarks
        ''' </summary>
        ''' <value>strFactoryInRemarks</value>
        ''' <returns> Return strFactoryInRemarks</returns>
        ''' <remarks> Get or Set the Value of FactoryInRemarks  </remarks>
        '''
        Public Property FactoryInRemarks() As String
            Get
                Return strFactoryInRemarks
            End Get
            Set(ByVal value As String)
                strFactoryInRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryInBy
        ''' </summary>
        ''' <value>strFactoryInBy</value>
        ''' <returns> Return strFactoryInBy</returns>
        ''' <remarks> Get or Set the Value of FactoryInBy  </remarks>
        '''
        Public Property FactoryInBy() As String
            Get
                Return strFactoryInBy
            End Get
            Set(ByVal value As String)
                strFactoryInBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryInOn
        ''' </summary>
        ''' <value>strFactoryInOn</value>
        ''' <returns> Return strFactoryInOn</returns>
        ''' <remarks> Get or Set the Value of FactoryInOn  </remarks>
        '''
        Public Property FactoryInOn() As String
            Get
                Return strFactoryInOn
            End Get
            Set(ByVal value As String)
                strFactoryInOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryOutRemarks
        ''' </summary>
        ''' <value>strFactoryOutRemarks</value>
        ''' <returns> Return strFactoryOutRemarks</returns>
        ''' <remarks> Get or Set the Value of FactoryOutRemarks  </remarks>
        '''
        Public Property FactoryOutRemarks() As String
            Get
                Return strFactoryOutRemarks
            End Get
            Set(ByVal value As String)
                strFactoryOutRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryOutBy
        ''' </summary>
        ''' <value>strFactoryOutBy</value>
        ''' <returns> Return strFactoryOutBy</returns>
        ''' <remarks> Get or Set the Value of FactoryOutBy  </remarks>
        '''
        Public Property FactoryOutBy() As String
            Get
                Return strFactoryOutBy
            End Get
            Set(ByVal value As String)
                strFactoryOutBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryOutOn
        ''' </summary>
        ''' <value>strFactoryOutOn</value>
        ''' <returns> Return strFactoryOutOn</returns>
        ''' <remarks> Get or Set the Value of FactoryOutOn  </remarks>
        '''
        Public Property FactoryOutOn() As String
            Get
                Return strFactoryOutOn
            End Get
            Set(ByVal value As String)
                strFactoryOutOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferInRemarks
        ''' </summary>
        ''' <value>strBufferInRemarks</value>
        ''' <returns> Return strBufferInRemarks</returns>
        ''' <remarks> Get or Set the Value of BufferInRemarks  </remarks>
        '''
        Public Property BufferInRemarks() As String
            Get
                Return strBufferInRemarks
            End Get
            Set(ByVal value As String)
                strBufferInRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferInBy
        ''' </summary>
        ''' <value>strBufferInBy</value>
        ''' <returns> Return strBufferInBy</returns>
        ''' <remarks> Get or Set the Value of BufferInBy  </remarks>
        '''
        Public Property BufferInBy() As String
            Get
                Return strBufferInBy
            End Get
            Set(ByVal value As String)
                strBufferInBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferInOn
        ''' </summary>
        ''' <value>strBufferInOn</value>
        ''' <returns> Return strBufferInOn</returns>
        ''' <remarks> Get or Set the Value of BufferInOn  </remarks>
        '''
        Public Property BufferInOn() As String
            Get
                Return strBufferInOn
            End Get
            Set(ByVal value As String)
                strBufferInOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferOutRemarks
        ''' </summary>
        ''' <value>strBufferOutRemarks</value>
        ''' <returns> Return strBufferOutRemarks</returns>
        ''' <remarks> Get or Set the Value of BufferOutRemarks  </remarks>
        '''
        Public Property BufferOutRemarks() As String
            Get
                Return strBufferOutRemarks
            End Get
            Set(ByVal value As String)
                strBufferOutRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferOutBy
        ''' </summary>
        ''' <value>strBufferOutBy</value>
        ''' <returns> Return strBufferOutBy</returns>
        ''' <remarks> Get or Set the Value of BufferOutBy  </remarks>
        '''
        Public Property BufferOutBy() As String
            Get
                Return strBufferOutBy
            End Get
            Set(ByVal value As String)
                strBufferOutBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BufferOutOn
        ''' </summary>
        ''' <value>strBufferOutOn</value>
        ''' <returns> Return strBufferOutOn</returns>
        ''' <remarks> Get or Set the Value of BufferOutOn  </remarks>
        '''
        Public Property BufferOutOn() As String
            Get
                Return strBufferOutOn
            End Get
            Set(ByVal value As String)
                strBufferOutOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of EmptyGateInRemarks
        ''' </summary>
        ''' <value>strEmptyGateInRemarks</value>
        ''' <returns> Return strEmptyGateInRemarks</returns>
        ''' <remarks> Get or Set the Value of EmptyGateInRemarks  </remarks>
        '''
        Public Property EmptyGateInRemarks() As String
            Get
                Return strEmptyGateInRemarks
            End Get
            Set(ByVal value As String)
                strEmptyGateInRemarks = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of EmptyGateInBy
        ''' </summary>
        ''' <value>strEmptyGateInBy</value>
        ''' <returns> Return strEmptyGateInBy</returns>
        ''' <remarks> Get or Set the Value of EmptyGateInBy  </remarks>
        '''
        Public Property EmptyGateInBy() As String
            Get
                Return strEmptyGateInBy
            End Get
            Set(ByVal value As String)
                strEmptyGateInBy = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of EmptyGateInOn
        ''' </summary>
        ''' <value>strEmptyGateInOn</value>
        ''' <returns> Return strEmptyGateInOn</returns>
        ''' <remarks> Get or Set the Value of EmptyGateInOn  </remarks>
        '''
        Public Property EmptyGateInOn() As String
            Get
                Return strEmptyGateInOn
            End Get
            Set(ByVal value As String)
                strEmptyGateInOn = value
            End Set
        End Property



        Private arrItemDtlsList As New ArrayList

        Public Property ItemDtlsList() As ArrayList
            Get
                Return arrItemDtlsList
            End Get
            Set(ByVal value As ArrayList)
                arrItemDtlsList = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngComapnyId = 0
            lngMtyContId = 0
            lngContJoId = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            lngWeight = 0.0
            lngCargoWt = 0.0
            lngTareWt = 0.0
            strTripType = ""
            strJoType = ""
            lngGrId = 0
            lngVehicleId = 0
            strErrormsg = ""
            strSealNo = ""
            strAgentSeal = ""
            strBENo = ""
            strBookingNo = ""
            strDOValidity = ""
            lngLineId = 0
            strBEDate = ""
            strRemarks = ""
            strInvoiceFlagTPT = ""
            strInvoiceFlagFRT = ""
            strInvoiceFlagCLR = ""
            strIcdOutDate = ""
            strIcdInDate = ""
            strFactoryInDate = ""
            strFactoryOutDate = ""
            strAllotMentDate = ""
            strBufferDate = ""
            strBufferOutDate = ""
            strEmptyGateInDate = ""
            lngFpod = 0
            lngPol = 0
            lngStuffingPOD = 0
            lngStuffingPOL = 0
            strVesselName = ""
            strValidity = ""
            strSicutDate = ""
            strPortCutOfdate = ""
            strETDDate = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            strVehicleGateOutDate = ""
            strIcdOutRemarks = ""
            strIcdOutBy = ""
            strIcdOutOn = ""
            strIcdInRemarks = ""
            strIcdInBy = ""
            strIcdInOn = ""
            strFactoryInRemarks = ""
            strFactoryInBy = ""
            strFactoryInOn = ""
            strFactoryOutRemarks = ""
            strFactoryOutBy = ""
            strFactoryOutOn = ""
            strBufferInRemarks = ""
            strBufferInBy = ""
            strBufferInOn = ""
            strBufferOutRemarks = ""
            strBufferOutBy = ""
            strBufferOutOn = ""
            strEmptyGateInRemarks = ""
            strEmptyGateInBy = ""
            strEmptyGateInOn = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJoDtls.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_MTY_CONT_ID", pFleetContJoDtls.MtyContId, Global.System.Data.ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetContJoDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJoDtls.ContType)
                db.AddParameter("p_WEIGHT", pFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pFleetContJoDtls.TareWt)
                db.AddParameter("p_SEAL_NO", pFleetContJoDtls.SealNo)
                db.AddParameter("p_TRIP_TYPE", pFleetContJoDtls.TripType)
                db.AddParameter("p_JO_TYPE", pFleetContJoDtls.JoType)
                db.AddParameter("p_GR_ID", pFleetContJoDtls.GrId)
                db.AddParameter("p_BE_NO", pFleetContJoDtls.BENo)
                db.AddParameter("p_BOOKING_NO", pFleetContJoDtls.BookingNo)
                db.AddParameter("p_AGENT_SEAL", pFleetContJoDtls.AgentSeal)
                db.AddParameter("p_DO_VALIDITY", pFleetContJoDtls.DOValidity)
                db.AddParameter("p_LINE_ID", pFleetContJoDtls.LineId)
                db.AddParameter("p_BE_DATE", pFleetContJoDtls.BEDate)
                db.AddParameter("p_REMARKS", pFleetContJoDtls.Remarks)
                db.AddParameter("p_INVOICE_FLAG_TPT", pFleetContJoDtls.InvoiceFlagTPT)
                db.AddParameter("p_INVOICE_FLAG_FRT", pFleetContJoDtls.InvoiceFlagFRT)
                db.AddParameter("p_INVOICE_FLAG_CLR", pFleetContJoDtls.InvoiceFlagCLR)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_FPOD", pFleetContJoDtls.Fpod)
                db.AddParameter("p_POL", pFleetContJoDtls.Pol)
                db.AddParameter("p_VESSEL_NAME", pFleetContJoDtls.VesselName)
                db.AddParameter("p_VALIDITY", pFleetContJoDtls.Validity)
                db.AddParameter("p_SI_CUTOF_DATE", pFleetContJoDtls.SicutDate)
                db.AddParameter("p_PORT_CUTOF_DATE", pFleetContJoDtls.PortCutOfdate)
                db.AddParameter("p_ETD_DATE", pFleetContJoDtls.ETDDate)
                db.AddParameter("p_STUFFING_POD", pFleetContJoDtls.StuffingPOD)
                db.AddParameter("p_STUFFING_POL", pFleetContJoDtls.lngStuffingPOL)
                db.AddParameter("p_UPDATED_BY", pFleetContJoDtls.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pFleetContJoDtls.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pFleetContJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJoDtls.TerminalId)
                db.AddParameter("p_COMAPNY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_MTY_CONT_ID", pFleetContJoDtls.MtyContId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetContJoDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJoDtls.ContType)
                db.AddParameter("p_WEIGHT", pFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pFleetContJoDtls.TareWt)
                db.AddParameter("p_SEAL_NO", pFleetContJoDtls.SealNo)
                db.AddParameter("p_TRIP_TYPE", pFleetContJoDtls.TripType)
                db.AddParameter("p_JO_TYPE", pFleetContJoDtls.JoType)
                db.AddParameter("p_GR_ID", pFleetContJoDtls.GrId)
                db.AddParameter("p_BE_NO", pFleetContJoDtls.BENo)
                db.AddParameter("p_BOOKING_NO", pFleetContJoDtls.BookingNo)
                db.AddParameter("p_AGENT_SEAL", pFleetContJoDtls.AgentSeal)
                db.AddParameter("p_DO_VALIDITY", pFleetContJoDtls.DOValidity)
                db.AddParameter("p_LINE_ID", pFleetContJoDtls.LineId)
                db.AddParameter("p_BE_DATE", pFleetContJoDtls.BEDate)
                db.AddParameter("p_REMARKS", pFleetContJoDtls.Remarks)
                db.AddParameter("p_INVOICE_FLAG_TPT", pFleetContJoDtls.InvoiceFlagTPT)
                db.AddParameter("p_INVOICE_FLAG_FRT", pFleetContJoDtls.InvoiceFlagFRT)
                db.AddParameter("p_INVOICE_FLAG_CLR", pFleetContJoDtls.InvoiceFlagCLR)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_FPOD", pFleetContJoDtls.Fpod)
                db.AddParameter("p_POL", pFleetContJoDtls.Pol)
                db.AddParameter("p_VESSEL_NAME", pFleetContJoDtls.VesselName)
                db.AddParameter("p_VALIDITY", pFleetContJoDtls.Validity)
                db.AddParameter("p_SI_CUTOF_DATE", pFleetContJoDtls.SicutDate)
                db.AddParameter("p_PORT_CUTOF_DATE", pFleetContJoDtls.PortCutOfdate)
                db.AddParameter("p_ETD_DATE", pFleetContJoDtls.ETDDate)
                db.AddParameter("p_STUFFING_POD", pFleetContJoDtls.StuffingPOD)
                db.AddParameter("p_STUFFING_POL", pFleetContJoDtls.lngStuffingPOL)
                db.AddParameter("p_UPDATED_BY", pFleetContJoDtls.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pFleetContJoDtls.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetContJoDtls.MtyContId = db.Parameters.Item("p_MTY_CONT_ID").value
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetContJoDtls
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJoDtls.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_MTY_CONT_ID", pFleetContJoDtls.MtyContId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetContJoDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJoDtls.ContType)
                db.AddParameter("p_WEIGHT", pFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pFleetContJoDtls.TareWt)
                db.AddParameter("p_SEAL_NO", pFleetContJoDtls.SealNo)
                db.AddParameter("p_TRIP_TYPE", pFleetContJoDtls.TripType)
                db.AddParameter("p_JO_TYPE", pFleetContJoDtls.JoType)
                db.AddParameter("p_GR_ID", pFleetContJoDtls.GrId)
                db.AddParameter("p_BE_NO", pFleetContJoDtls.BENo)
                db.AddParameter("p_BOOKING_NO", pFleetContJoDtls.BookingNo)
                db.AddParameter("p_AGENT_SEAL", pFleetContJoDtls.AgentSeal)
                db.AddParameter("p_DO_VALIDITY", pFleetContJoDtls.DOValidity)
                db.AddParameter("p_LINE_ID", pFleetContJoDtls.LineId)
                db.AddParameter("p_BE_DATE", pFleetContJoDtls.BEDate)
                db.AddParameter("p_REMARKS", pFleetContJoDtls.Remarks)
                db.AddParameter("p_INVOICE_FLAG_TPT", pFleetContJoDtls.InvoiceFlagTPT)
                db.AddParameter("p_INVOICE_FLAG_FRT", pFleetContJoDtls.InvoiceFlagFRT)
                db.AddParameter("p_INVOICE_FLAG_CLR", pFleetContJoDtls.InvoiceFlagCLR)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_FPOD", pFleetContJoDtls.Fpod)
                db.AddParameter("p_POL", pFleetContJoDtls.Pol)
                db.AddParameter("p_VESSEL_NAME", pFleetContJoDtls.VesselName)
                db.AddParameter("p_VALIDITY", pFleetContJoDtls.Validity)
                db.AddParameter("p_SI_CUTOF_DATE", pFleetContJoDtls.SicutDate)
                db.AddParameter("p_PORT_CUTOF_DATE", pFleetContJoDtls.PortCutOfdate)
                db.AddParameter("p_ETD_DATE", pFleetContJoDtls.ETDDate)
                db.AddParameter("p_STUFFING_POD", pFleetContJoDtls.StuffingPOD)
                db.AddParameter("p_STUFFING_POL", pFleetContJoDtls.lngStuffingPOL)
                db.AddParameter("p_UPDATED_BY", pFleetContJoDtls.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pFleetContJoDtls.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetContJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJoDtls.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_MTY_CONT_ID", pFleetContJoDtls.MtyContId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_CONT_SIZE", pFleetContJoDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJoDtls.ContType)
                db.AddParameter("p_WEIGHT", pFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pFleetContJoDtls.TareWt)
                db.AddParameter("p_SEAL_NO", pFleetContJoDtls.SealNo)
                db.AddParameter("p_TRIP_TYPE", pFleetContJoDtls.TripType)
                db.AddParameter("p_JO_TYPE", pFleetContJoDtls.JoType)
                db.AddParameter("p_GR_ID", pFleetContJoDtls.GrId)
                db.AddParameter("p_BE_NO", pFleetContJoDtls.BENo)
                db.AddParameter("p_BOOKING_NO", pFleetContJoDtls.BookingNo)
                db.AddParameter("p_AGENT_SEAL", pFleetContJoDtls.AgentSeal)
                db.AddParameter("p_DO_VALIDITY", pFleetContJoDtls.DOValidity)
                db.AddParameter("p_LINE_ID", pFleetContJoDtls.LineId)
                db.AddParameter("p_BE_DATE", pFleetContJoDtls.BEDate)
                db.AddParameter("p_REMARKS", pFleetContJoDtls.Remarks)
                db.AddParameter("p_INVOICE_FLAG_TPT", pFleetContJoDtls.InvoiceFlagTPT)
                db.AddParameter("p_INVOICE_FLAG_FRT", pFleetContJoDtls.InvoiceFlagFRT)
                db.AddParameter("p_INVOICE_FLAG_CLR", pFleetContJoDtls.InvoiceFlagCLR)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_FPOD", pFleetContJoDtls.Fpod)
                db.AddParameter("p_POL", pFleetContJoDtls.Pol)
                db.AddParameter("p_VESSEL_NAME", pFleetContJoDtls.VesselName)
                db.AddParameter("p_VALIDITY", pFleetContJoDtls.Validity)
                db.AddParameter("p_SI_CUTOF_DATE", pFleetContJoDtls.SicutDate)
                db.AddParameter("p_PORT_CUTOF_DATE", pFleetContJoDtls.PortCutOfdate)
                db.AddParameter("p_ETD_DATE", pFleetContJoDtls.ETDDate)
                db.AddParameter("p_STUFFING_POD", pFleetContJoDtls.StuffingPOD)
                db.AddParameter("p_STUFFING_POL", pFleetContJoDtls.lngStuffingPOL)
                db.AddParameter("p_UPDATED_BY", pFleetContJoDtls.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pFleetContJoDtls.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateNew(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_BUFFER_DATE", pFleetContJoDtls.BufferDate)
                db.AddParameter("p_BUFFER_OUT_DATE", pFleetContJoDtls.BufferOutDate)
                db.AddParameter("p_EMPTY_GATE_IN_DATE", pFleetContJoDtls.EmptyGateInDate)
                db.AddParameter("p_FACTORY_IN_DATE", pFleetContJoDtls.FactoryInDate)
                db.AddParameter("p_FACTORY_OUT_DATE", pFleetContJoDtls.FactoryOutDate)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO_DTLS_NEW", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetContJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetContJoDtls"></param>
        ''' <returns>Return pFleetContJoDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrnNew(ByVal db As DBConnect, ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COMPANY_ID", pFleetContJoDtls.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJoDtls.ContJoId)
                db.AddParameter("p_MTY_CONT_ID", pFleetContJoDtls.MtyContId)
                db.AddParameter("p_CONT_NO", pFleetContJoDtls.ContNo)
                db.AddParameter("p_ICD_OUT_DATE", pFleetContJoDtls.IcdOutDate)
                db.AddParameter("p_ICD_IN_DATE", pFleetContJoDtls.IcdInDate)
                db.AddParameter("p_ALLOTMENT_DATE", pFleetContJoDtls.AllotMentDate)
                db.AddParameter("p_BUFFER_DATE", pFleetContJoDtls.BufferDate)
                db.AddParameter("p_BUFFER_OUT_DATE", pFleetContJoDtls.BufferOutDate)
                db.AddParameter("p_EMPTY_GATE_IN_DATE", pFleetContJoDtls.EmptyGateInDate)
                db.AddParameter("p_FACTORY_IN_DATE", pFleetContJoDtls.FactoryInDate)
                db.AddParameter("p_FACTORY_OUT_DATE", pFleetContJoDtls.FactoryOutDate)
                db.AddParameter("p_TRIP_TYPE", pFleetContJoDtls.TripType)
                db.AddParameter("p_VEHICLE_GATE_OUT_DATE", pFleetContJoDtls.VehicleGateOutDate)
                db.AddParameter("p_ICD_OUT_REMARKS", pFleetContJoDtls.IcdOutRemarks)
                db.AddParameter("p_ICD_OUT_BY", pFleetContJoDtls.IcdOutBy)
                db.AddParameter("p_ICD_IN_REMARKS", pFleetContJoDtls.IcdInRemarks)
                db.AddParameter("p_ICD_IN_BY", pFleetContJoDtls.IcdInBy)
                db.AddParameter("p_FACTORY_IN_REMARKS", pFleetContJoDtls.FactoryInRemarks)
                db.AddParameter("p_FACTORY_IN_BY", pFleetContJoDtls.FactoryInBy)
                db.AddParameter("p_FACTORY_OUT_REMARKS", pFleetContJoDtls.FactoryOutRemarks)
                db.AddParameter("p_FACTORY_OUT_BY", pFleetContJoDtls.FactoryOutBy)
                db.AddParameter("p_BUFFER_IN_REMARKS", pFleetContJoDtls.BufferInRemarks)
                db.AddParameter("p_BUFFER_IN_BY", pFleetContJoDtls.BufferInBy)
                db.AddParameter("p_BUFFER_OUT_REMARKS", pFleetContJoDtls.BufferOutRemarks)
                db.AddParameter("p_BUFFER_OUT_BY", pFleetContJoDtls.BufferOutBy)
                db.AddParameter("p_EMPTY_GATE_IN_REMARKS", pFleetContJoDtls.EmptyGateInRemarks)
                db.AddParameter("p_EMPTY_GATE_IN_BY", pFleetContJoDtls.EmptyGateInBy)
                db.AddParameter("p_ErrorMsg", pFleetContJoDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO_DTLS_NEW", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pFleetContJoDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pFleetContJoDtls.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pFleetContJoDtls.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pFleetContJoDtls.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                pFleetContJoDtls.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pFleetContJoDtls.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pFleetContJoDtls.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pFleetContJoDtls.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIGHT").ToString <> "" Then
                                pFleetContJoDtls.Weight = dbr("WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_WEIGHT").ToString <> "" Then
                                pFleetContJoDtls.CargoWt = dbr("CARGO_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WEIGHT").ToString <> "" Then
                                pFleetContJoDtls.TareWt = dbr("TARE_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEAL_NO").ToString <> "" Then
                                pFleetContJoDtls.SealNo = dbr("SEAL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRIP_TYPE").ToString <> "" Then
                                pFleetContJoDtls.TripType = dbr("TRIP_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                pFleetContJoDtls.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_ID").ToString <> "" Then
                                pFleetContJoDtls.GrId = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                pFleetContJoDtls.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BE_NO").ToString <> "" Then
                                pFleetContJoDtls.BENo = dbr("BE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                pFleetContJoDtls.BookingNo = dbr("BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGENT_SEAL").ToString <> "" Then
                                pFleetContJoDtls.AgentSeal = dbr("AGENT_SEAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALIDITY").ToString <> "" Then
                                pFleetContJoDtls.DOValidity = dbr("DO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pFleetContJoDtls.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BE_DATE").ToString <> "" Then
                                pFleetContJoDtls.BEDate = dbr("BE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_FLAG_TPT").ToString <> "" Then
                                pFleetContJoDtls.InvoiceFlagTPT = dbr("INVOICE_FLAG_TPT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_FLAG_FRT").ToString <> "" Then
                                pFleetContJoDtls.InvoiceFlagFRT = dbr("INVOICE_FLAG_FRT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_DATE").ToString <> "" Then
                                pFleetContJoDtls.IcdOutDate = dbr("ICD_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_DATE").ToString <> "" Then
                                pFleetContJoDtls.IcdInDate = dbr("ICD_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_DATE").ToString <> "" Then
                                pFleetContJoDtls.FactoryInDate = dbr("FACTORY_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_DATE").ToString <> "" Then
                                pFleetContJoDtls.FactoryOutDate = dbr("FACTORY_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOTMENT_DATE").ToString <> "" Then
                                pFleetContJoDtls.AllotMentDate = dbr("ALLOTMENT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_DATE").ToString <> "" Then
                                pFleetContJoDtls.BufferDate = dbr("BUFFER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_DATE").ToString <> "" Then
                                pFleetContJoDtls.BufferOutDate = dbr("BUFFER_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTYGATE_IN_DATE").ToString <> "" Then
                                pFleetContJoDtls.EmptyGateInDate = dbr("EMPTYGATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FPOD").ToString <> "" Then
                                pFleetContJoDtls.Fpod = dbr("FPOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                pFleetContJoDtls.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NAME").ToString <> "" Then
                                pFleetContJoDtls.VesselName = dbr("VESSEL_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY").ToString <> "" Then
                                pFleetContJoDtls.Validity = dbr("VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SI_CUTOF_DATE").ToString <> "" Then
                                pFleetContJoDtls.SicutDate = dbr("SI_CUTOF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_CUTOF_DATE").ToString <> "" Then
                                pFleetContJoDtls.PortCutOfdate = dbr("PORT_CUTOF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ETD_DATE").ToString <> "" Then
                                pFleetContJoDtls.ETDDate = dbr("ETD_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFFING_POD").ToString <> "" Then
                                pFleetContJoDtls.StuffingPOD = dbr("STUFFING_POD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFFING_POL").ToString <> "" Then
                                pFleetContJoDtls.StuffingPOL = dbr("STUFFING_POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                pFleetContJoDtls.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                pFleetContJoDtls.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_GATE_OUT_DATE").ToString <> "" Then
                                pFleetContJoDtls.VehicleGateOutDate = dbr("VEHICLE_GATE_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.IcdOutRemarks = dbr("ICD_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_BY").ToString <> "" Then
                                pFleetContJoDtls.IcdOutBy = dbr("ICD_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_ON").ToString <> "" Then
                                pFleetContJoDtls.IcdOutOn = dbr("ICD_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.IcdInRemarks = dbr("ICD_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_BY").ToString <> "" Then
                                pFleetContJoDtls.IcdInBy = dbr("ICD_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_ON").ToString <> "" Then
                                pFleetContJoDtls.IcdInOn = dbr("ICD_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.FactoryInRemarks = dbr("FACTORY_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_BY").ToString <> "" Then
                                pFleetContJoDtls.FactoryInBy = dbr("FACTORY_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_ON").ToString <> "" Then
                                pFleetContJoDtls.FactoryInOn = dbr("FACTORY_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.FactoryOutRemarks = dbr("FACTORY_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_BY").ToString <> "" Then
                                pFleetContJoDtls.FactoryOutBy = dbr("FACTORY_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_ON").ToString <> "" Then
                                pFleetContJoDtls.FactoryOutOn = dbr("FACTORY_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.BufferInRemarks = dbr("BUFFER_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_BY").ToString <> "" Then
                                pFleetContJoDtls.BufferInBy = dbr("BUFFER_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_ON").ToString <> "" Then
                                pFleetContJoDtls.BufferInOn = dbr("BUFFER_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.BufferOutRemarks = dbr("BUFFER_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_BY").ToString <> "" Then
                                pFleetContJoDtls.BufferOutBy = dbr("BUFFER_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_ON").ToString <> "" Then
                                pFleetContJoDtls.BufferOutOn = dbr("BUFFER_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_REMARKS").ToString <> "" Then
                                pFleetContJoDtls.EmptyGateInRemarks = dbr("EMPTY_GATE_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_BY").ToString <> "" Then
                                pFleetContJoDtls.EmptyGateInBy = dbr("EMPTY_GATE_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_ON").ToString <> "" Then
                                pFleetContJoDtls.EmptyGateInOn = dbr("EMPTY_GATE_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetContJoDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetContJoDtls
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
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                temp.ContJoId = dbr("CONT_JO_ID")
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
                            If dbr("WEIGHT").ToString <> "" Then
                                temp.Weight = dbr("WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_WEIGHT").ToString <> "" Then
                                temp.CargoWt = dbr("CARGO_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WEIGHT").ToString <> "" Then
                                temp.TareWt = dbr("TARE_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEAL_NO").ToString <> "" Then
                                temp.SealNo = dbr("SEAL_NO")
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
                            If dbr("JO_TYPE").ToString <> "" Then
                                temp.JoType = dbr("JO_TYPE")
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
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                temp.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BE_NO").ToString <> "" Then
                                temp.BENo = dbr("BE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                temp.BookingNo = dbr("BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGENT_SEAL").ToString <> "" Then
                                temp.AgentSeal = dbr("AGENT_SEAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALIDITY").ToString <> "" Then
                                temp.DOValidity = dbr("DO_VALIDITY")
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
                            If dbr("BE_DATE").ToString <> "" Then
                                temp.BEDate = dbr("BE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_FLAG_TPT").ToString <> "" Then
                                temp.InvoiceFlagTPT = dbr("INVOICE_FLAG_TPT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_FLAG_FRT").ToString <> "" Then
                                temp.InvoiceFlagFRT = dbr("INVOICE_FLAG_FRT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_FLAG_CLR").ToString <> "" Then
                                temp.InvoiceFlagCLR = dbr("INVOICE_FLAG_CLR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_DATE").ToString <> "" Then
                                temp.IcdOutDate = dbr("ICD_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_DATE").ToString <> "" Then
                                temp.IcdInDate = dbr("ICD_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_DATE").ToString <> "" Then
                                temp.FactoryInDate = dbr("FACTORY_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_DATE").ToString <> "" Then
                                temp.FactoryOutDate = dbr("FACTORY_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOTMENT_DATE").ToString <> "" Then
                                temp.AllotMentDate = dbr("ALLOTMENT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_DATE").ToString <> "" Then
                                temp.BufferDate = dbr("BUFFER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_DATE").ToString <> "" Then
                                temp.BufferOutDate = dbr("BUFFER_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTYGATE_IN_DATE").ToString <> "" Then
                                temp.EmptyGateInDate = dbr("EMPTYGATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FPOD").ToString <> "" Then
                                temp.Fpod = dbr("FPOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                temp.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NAME").ToString <> "" Then
                                temp.VesselName = dbr("VESSEL_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY").ToString <> "" Then
                                temp.Validity = dbr("VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SI_CUTOF_DATE").ToString <> "" Then
                                temp.SicutDate = dbr("SI_CUTOF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_CUTOF_DATE").ToString <> "" Then
                                temp.PortCutOfdate = dbr("PORT_CUTOF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ETD_DATE").ToString <> "" Then
                                temp.ETDDate = dbr("ETD_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFFING_POD").ToString <> "" Then
                                temp.StuffingPOD = dbr("STUFFING_POD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFFING_POL").ToString <> "" Then
                                temp.StuffingPOL = dbr("STUFFING_POL")
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
                        Try
                            If dbr("VEHICLE_GATE_OUT_DATE").ToString <> "" Then
                                temp.VehicleGateOutDate = dbr("VEHICLE_GATE_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_REMARKS").ToString <> "" Then
                                temp.IcdOutRemarks = dbr("ICD_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_BY").ToString <> "" Then
                                temp.IcdOutBy = dbr("ICD_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT_ON").ToString <> "" Then
                                temp.IcdOutOn = dbr("ICD_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_REMARKS").ToString <> "" Then
                                temp.IcdInRemarks = dbr("ICD_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_BY").ToString <> "" Then
                                temp.IcdInBy = dbr("ICD_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN_ON").ToString <> "" Then
                                temp.IcdInOn = dbr("ICD_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_REMARKS").ToString <> "" Then
                                temp.FactoryInRemarks = dbr("FACTORY_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_BY").ToString <> "" Then
                                temp.FactoryInBy = dbr("FACTORY_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN_ON").ToString <> "" Then
                                temp.FactoryInOn = dbr("FACTORY_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_REMARKS").ToString <> "" Then
                                temp.FactoryOutRemarks = dbr("FACTORY_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_BY").ToString <> "" Then
                                temp.FactoryOutBy = dbr("FACTORY_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT_ON").ToString <> "" Then
                                temp.FactoryOutOn = dbr("FACTORY_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_REMARKS").ToString <> "" Then
                                temp.BufferInRemarks = dbr("BUFFER_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_BY").ToString <> "" Then
                                temp.BufferInBy = dbr("BUFFER_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_IN_ON").ToString <> "" Then
                                temp.BufferInOn = dbr("BUFFER_IN_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_REMARKS").ToString <> "" Then
                                temp.BufferOutRemarks = dbr("BUFFER_OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_BY").ToString <> "" Then
                                temp.BufferOutBy = dbr("BUFFER_OUT_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_OUT_ON").ToString <> "" Then
                                temp.BufferOutOn = dbr("BUFFER_OUT_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_REMARKS").ToString <> "" Then
                                temp.EmptyGateInRemarks = dbr("EMPTY_GATE_IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_BY").ToString <> "" Then
                                temp.EmptyGateInBy = dbr("EMPTY_GATE_IN_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_ON").ToString <> "" Then
                                temp.EmptyGateInOn = dbr("EMPTY_GATE_IN_ON")
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

        Public Shared Function UpdateVehicleRunningPosition(ByVal pExtFJODtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                For Each pFID As FleetContJoDtls In pExtFJODtls.arrItemDtlsList
                    FleetContJoDtls.UpdateTrnNew(db, pFID)
                    If pFID.Errormsg <> "" Then
                        Throw New Exception(pFID.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pExtFJODtls.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtFJODtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoDtls(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_BY_ID", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.MtyContId & ",'" & pFleetContJoDtls.ContNo & "'")
                pFleetContJoDtls = ReturnObjectValues(dbr, pFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function
        Public Shared Function ReturnFleetContJoDtlslCont(ByVal pFleetContJoDtls As FleetContJoDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetContJoDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_BY_ID", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.MtyContId & ",'" & pFleetContJoDtls.ContNo & "'")
                arrFleetContJoDtls = ReturnObjectValuesList(dbr, arrFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetContJoDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetContJoDtls
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetContJoDtlsList(ByVal pFleetContJoDtls As FleetContJoDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetContJoDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.ContJoId)
                arrFleetContJoDtls = ReturnObjectValuesList(dbr, arrFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetContJoDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetContJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoDtlsContNo(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_BY_CONT", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.ContJoId)
                pFleetContJoDtls = ReturnObjectValues(dbr, pFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoDtlsvessel(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_VESSEL", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.ContJoId)
                pFleetContJoDtls = ReturnObjectValues(dbr, pFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoDtlsByGR(ByVal pFleetContJoDtls As FleetContJoDtls) As FleetContJoDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_GR", pFleetContJoDtls.TerminalId & "," & pFleetContJoDtls.GrId)
                pFleetContJoDtls = ReturnObjectValues(dbr, pFleetContJoDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetContJoDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJoDtls
        End Function
    End Class

End Namespace
