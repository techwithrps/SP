Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetContJo
    ''' @author	: Amit K. Singh- 31/05/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetContJo

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngComapnyId As Long
        Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
        Private strContJoNo As String ' Define Private Variable ContJoNo With DataType As String 
        Private lngConsigneeId As Long ' Define Private Variable ConsigneeId With DataType As Long 
        Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private lngTransporterId As Long ' Define Private Variable TransporterId With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngMtyPickup As Long ' Define Private Variable MtyPickup With DataType As Long 
        Private lngFromLocation As Long ' Define Private Variable FromLocation With DataType As Long 
        Private lngToLocationId As Long ' Define Private Variable ToLocationId With DataType As Long 
        Private lngHandLocation As Long ' Define Private Variable HandLocation With DataType As Long 
        Private lngGrId As Long ' Define Private Variable GrId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strTripType As String ' Define Private Variable ContJoNo With DataType As String 
        Private strModeType As String ' Define Private Variable strModeType With DataType As String 
        Private strJoType As String ' Define Private Variable ContJoNo With DataType As String 
        Private lngBillTo As Long ' Define Private Variable ContJoId With DataType As Long 
        Private lngOnAccount As Long ' Define Private Variable ContJoId With DataType As Long 
        Private lngNoOf20 As Long ' Define Private Variable ContJoId With DataType As Long 
        Private lngNoOf40 As Long ' Define Private Variable ContJoId With DataType As Long 
        Private strStuffdate As String ' Define Private Variable CreatedOn With DataType As String 
        Private strBookingNo As String ' Define Private Variable ContJoNo With DataType As String 
        Private lngCHA As Long
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String
        Private strBOENo As String ' Define Private Variable BOENo With DataType As String
        Private strBOEDate As String ' Define Private Variable BOEDate With DataType As String
        Private strShipperInvNo As String ' Define Private Variable ShipperInvNo With DataType As String
        Private strShipperInvDate As String ' Define Private Variable ShipperInvDate With DataType As String
        Private strMBLNo As String ' Define Private Variable MBLNo With DataType As String
        Private strMBLDate As String ' Define Private Variable MBLDate With DataType As String
        Private strHBLNo As String ' Define Private Variable HBLNo With DataType As String
        Private strHBLDate As String ' Define Private Variable HBLDate With DataType As String
        'Added 16/11/2022
        Private strHod As String ' Define Private Variable Hod With DataType As String 
        Private lngFpod As Long ' Define Private Variable Fpod With DataType As Long 
        Private lngClrBy As Long ' Define Private Variable ClrBy With DataType As Long 
        Private strCommodity As String ' Define Private Variable Hod With DataType As String 
        Private strConsignee As String ' Define Private Variable Consignee With DataType As String
        Private strPackageType As String ' Define Private Variable PackageType With DataType As Long 
        Private lngCartons As Long ' Define Private Variable Cartons With DataType As Long
        Private strJONo As String ' Define Private Variable JONo With DataType As String 
        Private strJoDate As String ' Define Private Variable JoDate With DataType As String 
        Private lngEmptyLocationId As Long ' Define Private Variable EmptyLocation With DataType As Long
        Private strEmptyDate As String ' Define Private Variable EmptyDate With DataType As String 
        Private lngGrossWt As Double ' Define Private Variable Gross Weight With DataType As Long 
        'Added 16/02/2024
        Private lngCbm As Long ' Define Private Variable Cbm With DataType As Long 
        Private lngExtn1 As Long ' Define Private Variable Extn1 With DataType As Long 
        Private lngExtn2 As Long ' Define Private Variable Extn2 With DataType As Long 
        Private strExtv1 As String ' Define Private Variable Extv1 With DataType As String 
        Private strExtv2 As String ' Define Private Variable Extv2 With DataType As String 

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
        Public Property CHA() As Long
            Get
                Return lngCHA
            End Get
            Set(ByVal value As Long)
                lngCHA = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ContJoId
        ''' </summary>
        ''' <value>lngContJoId</value>
        ''' <returns> Return lngContJoId</returns>
        ''' <remarks> Get or Set the Value of ContJoId  </remarks>
        '''
        Public Property NoOf20() As Long
            Get
                Return lngNoOf20
            End Get
            Set(ByVal value As Long)
                lngNoOf20 = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ContJoId
        ''' </summary>
        ''' <value>lngContJoId</value>
        ''' <returns> Return lngContJoId</returns>
        ''' <remarks> Get or Set the Value of ContJoId  </remarks>
        '''
        Public Property NoOf40() As Long
            Get
                Return lngNoOf40
            End Get
            Set(ByVal value As Long)
                lngNoOf40 = value
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
        ''' Get or Set the Value of ContJoNo
        ''' </summary>
        ''' <value>strContJoNo</value>
        ''' <returns> Return strContJoNo</returns>
        ''' <remarks> Get or Set the Value of ContJoNo  </remarks>
        '''
        Public Property ContJoNo() As String
            Get
                Return strContJoNo
            End Get
            Set(ByVal value As String)
                strContJoNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ContJoNo
        ''' </summary>
        ''' <value>strContJoNo</value>
        ''' <returns> Return strContJoNo</returns>
        ''' <remarks> Get or Set the Value of ContJoNo  </remarks>
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
        ''' Get or Set the Value of ContJoNo
        ''' </summary>
        ''' <value>strContJoNo</value>
        ''' <returns> Return strModeType</returns>
        ''' <remarks> Get or Set the Value of ContJoNo  </remarks>
        '''
        Public Property ModeType() As String
            Get
                Return strModeType
            End Get
            Set(ByVal value As String)
                strModeType = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ContJoNo
        ''' </summary>
        ''' <value>strContJoNo</value>
        ''' <returns> Return strContJoNo</returns>
        ''' <remarks> Get or Set the Value of ContJoNo  </remarks>
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
        ''' Get or Set the Value of ConsigneeId
        ''' </summary>
        ''' <value>lngConsigneeId</value>
        ''' <returns> Return lngConsigneeId</returns>
        ''' <remarks> Get or Set the Value of ConsigneeId  </remarks>
        '''
        Public Property ConsigneeId() As Long
            Get
                Return lngConsigneeId
            End Get
            Set(ByVal value As Long)
                lngConsigneeId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property CustomerId() As Long
            Get
                Return lngCustomerId
            End Get
            Set(ByVal value As Long)
                lngCustomerId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TransporterId
        ''' </summary>
        ''' <value>lngTransporterId</value>
        ''' <returns> Return lngTransporterId</returns>
        ''' <remarks> Get or Set the Value of TransporterId  </remarks>
        '''
        Public Property TransporterId() As Long
            Get
                Return lngTransporterId
            End Get
            Set(ByVal value As Long)
                lngTransporterId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TransporterId
        ''' </summary>
        ''' <value>lngTransporterId</value>
        ''' <returns> Return lngTransporterId</returns>
        ''' <remarks> Get or Set the Value of TransporterId  </remarks>
        '''
        Public Property BillTo() As Long
            Get
                Return lngBillTo
            End Get
            Set(ByVal value As Long)
                lngBillTo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TransporterId
        ''' </summary>
        ''' <value>lngTransporterId</value>
        ''' <returns> Return lngTransporterId</returns>
        ''' <remarks> Get or Set the Value of TransporterId  </remarks>
        '''
        Public Property OnAccount() As Long
            Get
                Return lngOnAccount
            End Get
            Set(ByVal value As Long)
                lngOnAccount = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() As Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyPickup
        ''' </summary>
        ''' <value>lngMtyPickup</value>
        ''' <returns> Return lngMtyPickup</returns>
        ''' <remarks> Get or Set the Value of MtyPickup  </remarks>
        '''
        Public Property MtyPickup() As Long
            Get
                Return lngMtyPickup
            End Get
            Set(ByVal value As Long)
                lngMtyPickup = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FromLocation
        ''' </summary>
        ''' <value>lngFromLocation</value>
        ''' <returns> Return lngFromLocation</returns>
        ''' <remarks> Get or Set the Value of FromLocation  </remarks>
        '''
        Public Property FromLocation() As Long
            Get
                Return lngFromLocation
            End Get
            Set(ByVal value As Long)
                lngFromLocation = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ToLocationId
        ''' </summary>
        ''' <value>lngToLocationId</value>
        ''' <returns> Return lngToLocationId</returns>
        ''' <remarks> Get or Set the Value of ToLocationId  </remarks>
        '''
        Public Property ToLocationId() As Long
            Get
                Return lngToLocationId
            End Get
            Set(ByVal value As Long)
                lngToLocationId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of HandLocation
        ''' </summary>
        ''' <value>lngHandLocation</value>
        ''' <returns> Return lngHandLocation</returns>
        ''' <remarks> Get or Set the Value of HandLocation  </remarks>
        '''
        Public Property HandLocation() As Long
            Get
                Return lngHandLocation
            End Get
            Set(ByVal value As Long)
                lngHandLocation = value
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
        Public Property StuffDate() As String
            Get
                Return strStuffdate
            End Get
            Set(ByVal value As String)
                strStuffdate = value
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
        ''' Get or Set the Value of BOENo
        ''' </summary>
        ''' <value>strBOENo</value>
        ''' <returns> Return strBOENo</returns>
        ''' <remarks> Get or Set the Value of BOENo  </remarks>
        '''
        Public Property BOENo() As String
            Get
                Return strBOENo
            End Get
            Set(ByVal value As String)
                strBOENo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BOEDate
        ''' </summary>
        ''' <value>strBOEDate</value>
        ''' <returns> Return strBOEDate</returns>
        ''' <remarks> Get or Set the Value of BOEDate  </remarks>
        '''
        Public Property BOEDate() As String
            Get
                Return strBOEDate
            End Get
            Set(ByVal value As String)
                strBOEDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ShipperInvNo
        ''' </summary>
        ''' <value>strShipperInvNo</value>
        ''' <returns> Return strShipperInvNo</returns>
        ''' <remarks> Get or Set the Value of ShipperInvNo  </remarks>
        '''
        Public Property ShipperInvNo() As String
            Get
                Return strShipperInvNo
            End Get
            Set(ByVal value As String)
                strShipperInvNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ShipperInvDate
        ''' </summary>
        ''' <value>strShipperInvDate</value>
        ''' <returns> Return strShipperInvDate</returns>
        ''' <remarks> Get or Set the Value of ShipperInvDate  </remarks>
        '''
        Public Property ShipperInvDate() As String
            Get
                Return strShipperInvDate
            End Get
            Set(ByVal value As String)
                strShipperInvDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of MBLNo
        ''' </summary>
        ''' <value>strMBLNo</value>
        ''' <returns> Return strMBLNo</returns>
        ''' <remarks> Get or Set the Value of MBLNo  </remarks>
        '''
        Public Property MBLNo() As String
            Get
                Return strMBLNo
            End Get
            Set(ByVal value As String)
                strMBLNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of MBLDate
        ''' </summary>
        ''' <value>strMBLDate</value>
        ''' <returns> Return strMMBLDate</returns>
        ''' <remarks> Get or Set the Value of MBLDate  </remarks>
        '''
        Public Property MBLDate() As String
            Get
                Return strMBLDate
            End Get
            Set(ByVal value As String)
                strMBLDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of HBLNo
        ''' </summary>
        ''' <value>strHBLNo</value>
        ''' <returns> Return strHBLNo</returns>
        ''' <remarks> Get or Set the Value of HBLNo  </remarks>
        '''
        Public Property HBLNo() As String
            Get
                Return strHBLNo
            End Get
            Set(ByVal value As String)
                strHBLNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of HBLDate
        ''' </summary>
        ''' <value>strHBLDate</value>
        ''' <returns> Return strHBLDate</returns>
        ''' <remarks> Get or Set the Value of HBLDate  </remarks>
        '''
        Public Property HBLDate() As String
            Get
                Return strHBLDate
            End Get
            Set(ByVal value As String)
                strHBLDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Hod
        ''' </summary>
        ''' <value>strHod</value>
        ''' <returns> Return strHod</returns>
        ''' <remarks> Get or Set the Value of Hod  </remarks>
        '''
        Public Property Hod() As String
            Get
                Return strHod
            End Get
            Set(ByVal value As String)
                strHod = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Fpod
        ''' </summary>
        ''' <value>strFpod</value>
        ''' <returns> Return strFpod</returns>
        ''' <remarks> Get or Set the Value of Fpod  </remarks>
        '''
        Public Property Fpod() As String
            Get
                Return lngFpod
            End Get
            Set(ByVal value As String)
                lngFpod = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ClrBy
        ''' </summary>
        ''' <value>lngClrBy</value>
        ''' <returns> Return lngClrBy</returns>
        ''' <remarks> Get or Set the Value of ClrBy  </remarks>
        '''
        Public Property ClrBy() As Long
            Get
                Return lngClrBy
            End Get
            Set(ByVal value As Long)
                lngClrBy = value
            End Set
        End Property
        Public Property Commodity() As String
            Get
                Return strCommodity
            End Get
            Set(ByVal value As String)
                strCommodity = value
            End Set
        End Property
        Public Property Consignee() As String
            Get
                Return strConsignee
            End Get
            Set(ByVal value As String)
                strConsignee = value
            End Set
        End Property
        Public Property PackageType() As String
            Get
                Return strPackageType
            End Get
            Set(ByVal value As String)
                strPackageType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cartons
        ''' </summary>
        ''' <value>lngCartons</value>
        ''' <returns> Return lngCartons</returns>
        ''' <remarks> Get or Set the Value of Cartons  </remarks>
        '''
        Public Property Cartons() As Long
            Get
                Return lngCartons
            End Get
            Set(ByVal value As Long)
                lngCartons = value
            End Set
        End Property
        Public Property JONO() As String
            Get
                Return strJONo
            End Get
            Set(ByVal value As String)
                strJONo = value
            End Set
        End Property
        Public Property JODate() As String
            Get
                Return strJoDate
            End Get
            Set(ByVal value As String)
                strJoDate = value
            End Set
        End Property
        Public Property EmptyLocationId() As Long
            Get
                Return lngEmptyLocationId
            End Get
            Set(ByVal value As Long)
                lngEmptyLocationId = value
            End Set
        End Property
        Public Property EmptyDate() As String
            Get
                Return strEmptyDate
            End Get
            Set(ByVal value As String)
                strEmptyDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Weight
        ''' </summary>
        ''' <value>lngWeight</value>
        ''' <returns> Return lngWeight</returns>
        ''' <remarks> Get or Set the Value of Weight  </remarks>
        '''
        Public Property GrossWt() As Double
            Get
                Return lngGrossWt
            End Get
            Set(ByVal value As Double)
                lngGrossWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cbm
        ''' </summary>
        ''' <value>lngCbm</value>
        ''' <returns> Return lngCbm</returns>
        ''' <remarks> Get or Set the Value of Cbm  </remarks>
        '''
        Public Property Cbm() As Long
            Get
                Return lngCbm
            End Get
            Set(ByVal value As Long)
                lngCbm = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Extn1
        ''' </summary>
        ''' <value>lngExtn1</value>
        ''' <returns> Return lngExtn1</returns>
        ''' <remarks> Get or Set the Value of Extn1  </remarks>
        '''
        Public Property Extn1() As Long
            Get
                Return lngExtn1
            End Get
            Set(ByVal value As Long)
                lngExtn1 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Extn2
        ''' </summary>
        ''' <value>lngExtn2</value>
        ''' <returns> Return lngExtn2</returns>
        ''' <remarks> Get or Set the Value of Extn2  </remarks>
        '''
        Public Property Extn2() As Long
            Get
                Return lngExtn2
            End Get
            Set(ByVal value As Long)
                lngExtn2 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Extv1
        ''' </summary>
        ''' <value>strExtv1</value>
        ''' <returns> Return strExtv1</returns>
        ''' <remarks> Get or Set the Value of Extv1  </remarks>
        '''
        Public Property Extv1() As String
            Get
                Return strExtv1
            End Get
            Set(ByVal value As String)
                strExtv1 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Extv2
        ''' </summary>
        ''' <value>strExtv2</value>
        ''' <returns> Return strExtv2</returns>
        ''' <remarks> Get or Set the Value of Extv2  </remarks>
        '''
        Public Property Extv2() As String
            Get
                Return strExtv2
            End Get
            Set(ByVal value As String)
                strExtv2 = value
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
            lngContJoId = 0
            strContJoNo = ""
            lngComapnyId = 0
            lngConsigneeId = 0
            lngCustomerId = 0
            lngTransporterId = 0
            lngLineId = 0
            lngMtyPickup = 0
            lngFromLocation = 0
            lngToLocationId = 0
            lngHandLocation = 0
            lngGrId = 0
            strTripType = ""
            strModeType = ""
            strCreatedBy = ""
            strJoType = ""
            lngNoOf20 = 0
            lngNoOf40 = 0
            strCreatedOn = ""
            strErrormsg = ""
            lngBillTo = 0
            lngOnAccount = 0
            strStuffdate = ""
            strBookingNo = ""
            lngCHA = 0
            strContSize = ""
            strContType = ""
            strBOENo = ""
            strBOEDate = ""
            strShipperInvNo = ""
            strShipperInvDate = ""
            strMBLNo = ""
            strMBLDate = ""
            strHBLNo = ""
            strHBLDate = ""
            'Added
            strHod = ""
            lngFpod = 0
            lngClrBy = 0
            strCommodity = ""
            strConsignee = ""
            strPackageType = ""
            strJONo = ""
            strJoDate = ""
            lngCartons = 0
            lngEmptyLocationId = 0
            strEmptyDate = ""
            lngGrossWt = 0.0
            lngCbm = 0
            lngExtn1 = 0
            lngExtn2 = 0
            strExtv1 = ""
            strExtv2 = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetContJo"></param>
        ''' <returns>Return pFleetContJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo, ParameterDirection.Output)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_TRIP_TYPE", pFleetContJo.TripType)
                db.AddParameter("p_MODE_TYPE", pFleetContJo.ModeType)
                db.AddParameter("p_JO_TYPE", pFleetContJo.JoType)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn, ParameterDirection.Output)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_CONT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetContJo.ContJoId = db.Parameters.Item("p_CONT_JO_ID").value
                pFleetContJo.ContJoNo = db.Parameters.Item("p_CONT_JO_NO").value
                pFleetContJo.CreatedOn = db.Parameters.Item("p_CREATED_ON").value

                If pFleetContJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function


        Public Shared Function InsertImp(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo, ParameterDirection.Output)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_TRIP_TYPE", pFleetContJo.TripType)
                db.AddParameter("p_MODE_TYPE", pFleetContJo.ModeType)
                db.AddParameter("p_JO_TYPE", pFleetContJo.JoType)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn, ParameterDirection.Output)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_BOE_NO", pFleetContJo.BOENo)
                db.AddParameter("p_BOE_DATE", pFleetContJo.BOEDate)
                db.AddParameter("p_SHIPPER_INV_NO", pFleetContJo.ShipperInvNo)
                db.AddParameter("p_SHIPPER_INV_DATE", pFleetContJo.ShipperInvDate)
                db.AddParameter("p_MBL_NO", pFleetContJo.MBLNo)
                db.AddParameter("p_MBL_DATE", pFleetContJo.MBLDate)
                db.AddParameter("p_HBL_NO", pFleetContJo.HBLNo)
                db.AddParameter("p_HBL_DATE", pFleetContJo.HBLDate)
                db.AddParameter("p_HOD", pFleetContJo.Hod)          'Added 16/11/2022
                db.AddParameter("p_FPOD", pFleetContJo.Fpod)        'Added 16/11/2022
                db.AddParameter("p_CLR_BY", pFleetContJo.ClrBy)     'Added 16/11/2022
                db.AddParameter("p_COMMODITY", pFleetContJo.Commodity)
                db.AddParameter("p_CONSIGNEE", pFleetContJo.Consignee)
                db.AddParameter("p_PACKAGE_TYPE", pFleetContJo.PackageType)
                db.AddParameter("p_CARTONS", pFleetContJo.Cartons)
                db.AddParameter("p_EMPTY_LOCATION_ID", pFleetContJo.EmptyLocationId)
                db.AddParameter("p_EMPTY_DATE", pFleetContJo.EmptyDate)
                db.AddParameter("p_GROSS_WT", pFleetContJo.GrossWt)
                db.AddParameter("p_JO_NO", pFleetContJo.JONO, ParameterDirection.Output)
                db.AddParameter("p_JO_DATE", pFleetContJo.JODate, ParameterDirection.Output)
                db.AddParameter("p_CBM", pFleetContJo.Cbm)          'Added 16/02/2024
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_CONT_JO_IMP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetContJo.ContJoId = db.Parameters.Item("p_CONT_JO_ID").value
                pFleetContJo.ContJoNo = db.Parameters.Item("p_CONT_JO_NO").value
                pFleetContJo.CreatedOn = db.Parameters.Item("p_CREATED_ON").value
                pFleetContJo.JONO = db.Parameters.Item("p_JO_NO").value
                pFleetContJo.JODate = db.Parameters.Item("p_JO_DATE").value

                If pFleetContJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetContJo"></param>
        ''' <returns>Return pFleetContJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetContJo As FleetContJo) As FleetContJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo, ParameterDirection.Output)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_TRIP_TYPE", pFleetContJo.TripType)
                db.AddParameter("p_MODE_TYPE", pFleetContJo.ModeType)
                db.AddParameter("p_JO_TYPE", pFleetContJo.JoType)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn, ParameterDirection.Output)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_CONT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetContJo.ContJoId = db.Parameters.Item("p_CONT_JO_ID").value
                pFleetContJo.ContJoNo = db.Parameters.Item("p_CONT_JO_NO").value
                pFleetContJo.CreatedOn = db.Parameters.Item("p_CREATED_ON").value

            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            Return pFleetContJo
        End Function




        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetContJo"></param>
        ''' <returns>Return pFleetContJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetContJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        Public Shared Function UpdateImp(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_BOE_NO", pFleetContJo.BOENo)
                db.AddParameter("p_BOE_DATE", pFleetContJo.BOEDate)
                db.AddParameter("p_SHIPPER_INV_NO", pFleetContJo.ShipperInvNo)
                db.AddParameter("p_SHIPPER_INV_DATE", pFleetContJo.ShipperInvDate)
                db.AddParameter("p_MBL_NO", pFleetContJo.MBLNo)
                db.AddParameter("p_MBL_DATE", pFleetContJo.MBLDate)
                db.AddParameter("p_HBL_NO", pFleetContJo.HBLNo)
                db.AddParameter("p_HBL_DATE", pFleetContJo.HBLDate)
                db.AddParameter("p_HOD", pFleetContJo.Hod)          'Added 16/11/2022
                db.AddParameter("p_FPOD", pFleetContJo.Fpod)        'Added 16/11/2022
                db.AddParameter("p_CLR_BY", pFleetContJo.ClrBy)     'Added 16/11/2022
                db.AddParameter("p_COMMODITY", pFleetContJo.Commodity)
                db.AddParameter("p_CONSIGNEE", pFleetContJo.Consignee)
                db.AddParameter("p_PACKAGE_TYPE", pFleetContJo.PackageType)
                db.AddParameter("p_CARTONS", pFleetContJo.Cartons)
                db.AddParameter("p_JO_NO", pFleetContJo.JONO)
                db.AddParameter("p_JO_DATE", pFleetContJo.JODate)
                db.AddParameter("p_TRIP_TYPE", pFleetContJo.TripType)
                db.AddParameter("p_MODE_TYPE", pFleetContJo.ModeType)
                db.AddParameter("p_EMPTY_LOCATION_ID", pFleetContJo.EmptyLocationId)
                db.AddParameter("p_EMPTY_DATE", pFleetContJo.EmptyDate)
                db.AddParameter("p_GROSS_WT", pFleetContJo.GrossWt)
                db.AddParameter("p_CBM", pFleetContJo.Cbm)          'Added 16/02/2024
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO_IMP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetContJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetContJo"></param>
        ''' <returns>Return pFleetContJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetContJo As FleetContJo) As FleetContJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetContJo.TerminalId)
                db.AddParameter("p_COMPANY_ID", pFleetContJo.CompanyId)
                db.AddParameter("p_CONT_JO_ID", pFleetContJo.ContJoId)
                db.AddParameter("p_CONT_JO_NO", pFleetContJo.ContJoNo)
                db.AddParameter("p_CONSIGNEE_ID", pFleetContJo.ConsigneeId)
                db.AddParameter("p_CUSTOMER_ID", pFleetContJo.CustomerId)
                db.AddParameter("p_BILL_TO", pFleetContJo.BillTo)
                db.AddParameter("p_ON_ACCOUNT", pFleetContJo.OnAccount)
                db.AddParameter("p_TRANSPORTER_ID", pFleetContJo.TransporterId)
                db.AddParameter("p_LINE_ID", pFleetContJo.LineId)
                db.AddParameter("p_MTY_PICKUP", pFleetContJo.MtyPickup)
                db.AddParameter("p_FROM_LOCATION", pFleetContJo.FromLocation)
                db.AddParameter("p_TO_LOCATION_ID", pFleetContJo.ToLocationId)
                db.AddParameter("p_HAND_LOCATION", pFleetContJo.HandLocation)
                db.AddParameter("p_GR_ID", pFleetContJo.GrId)
                db.AddParameter("p_CREATED_BY", pFleetContJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetContJo.CreatedOn)
                db.AddParameter("p_NO_OF_40", pFleetContJo.NoOf40)
                db.AddParameter("p_NO_OF_20", pFleetContJo.NoOf20)
                db.AddParameter("p_STUFF_DATE", pFleetContJo.StuffDate)
                db.AddParameter("p_BOOKING_NO", pFleetContJo.BookingNo)
                db.AddParameter("p_CHA_ID", pFleetContJo.CHA)
                db.AddParameter("p_CONT_SIZE", pFleetContJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pFleetContJo.ContType)
                db.AddParameter("p_ErrorMsg", pFleetContJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_CONT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            Return pFleetContJo
        End Function



        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetContJo As FleetContJo) As FleetContJo
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pFleetContJo.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pFleetContJo.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                pFleetContJo.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_NO").ToString <> "" Then
                                pFleetContJo.ContJoNo = dbr("CONT_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONSIGNEE_ID").ToString <> "" Then
                                pFleetContJo.ConsigneeId = dbr("CONSIGNEE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_ID").ToString <> "" Then
                                pFleetContJo.CustomerId = dbr("CUSTOMER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                pFleetContJo.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pFleetContJo.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                pFleetContJo.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_PICKUP").ToString <> "" Then
                                pFleetContJo.MtyPickup = dbr("MTY_PICKUP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                pFleetContJo.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_LOCATION_ID").ToString <> "" Then
                                pFleetContJo.ToLocationId = dbr("TO_LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAND_LOCATION").ToString <> "" Then
                                pFleetContJo.HandLocation = dbr("HAND_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_ID").ToString <> "" Then
                                pFleetContJo.GrId = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetContJo.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetContJo.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRIP_TYPE").ToString <> "" Then
                                pFleetContJo.TripType = dbr("TRIP_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODE_TYPE").ToString <> "" Then
                                pFleetContJo.ModeType = dbr("MODE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                pFleetContJo.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                pFleetContJo.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ON_ACCOUNT").ToString <> "" Then
                                pFleetContJo.OnAccount = dbr("ON_ACCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_20").ToString <> "" Then
                                pFleetContJo.NoOf20 = dbr("NO_OF_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_40").ToString <> "" Then
                                pFleetContJo.NoOf40 = dbr("NO_OF_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFF_DATE").ToString <> "" Then
                                pFleetContJo.StuffDate = dbr("STUFF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                pFleetContJo.BookingNo = dbr("BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                pFleetContJo.CHA = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pFleetContJo.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pFleetContJo.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOE_NO").ToString <> "" Then
                                pFleetContJo.BOENo = dbr("BOE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOE_DATE").ToString <> "" Then
                                pFleetContJo.BOEDate = dbr("BOE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_INV_NO").ToString <> "" Then
                                pFleetContJo.ShipperInvNo = dbr("SHIPPER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_INV_DATE").ToString <> "" Then
                                pFleetContJo.ShipperInvDate = dbr("SHIPPER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MBL_NO").ToString <> "" Then
                                pFleetContJo.MBLNo = dbr("MBL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MBL_DATE").ToString <> "" Then
                                pFleetContJo.MBLDate = dbr("MBL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HBL_NO").ToString <> "" Then
                                pFleetContJo.HBLNo = dbr("HBL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HBL_DATE").ToString <> "" Then
                                pFleetContJo.HBLDate = dbr("HBL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        'Added 16/11/2022
                        Try
                            If dbr("HOD").ToString <> "" Then
                                pFleetContJo.Hod = dbr("HOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FPOD").ToString <> "" Then
                                pFleetContJo.Fpod = dbr("FPOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLR_BY").ToString <> "" Then
                                pFleetContJo.ClrBy = dbr("CLR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOD").ToString <> "" Then
                                pFleetContJo.Hod = dbr("HOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSIGNEE").ToString <> "" Then
                                pFleetContJo.Consignee = dbr("CONSIGNEE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY").ToString <> "" Then
                                pFleetContJo.Commodity = dbr("COMMODITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_TYPE").ToString <> "" Then
                                pFleetContJo.PackageType = dbr("PACKAGE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARTONS").ToString <> "" Then
                                pFleetContJo.Cartons = dbr("CARTONS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                pFleetContJo.JONO = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                pFleetContJo.JODate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_LOCATION_ID").ToString <> "" Then
                                pFleetContJo.EmptyLocationId = dbr("EMPTY_LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_DATE").ToString <> "" Then
                                pFleetContJo.EmptyDate = dbr("EMPTY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROSS_WT").ToString <> "" Then
                                pFleetContJo.GrossWt = dbr("GROSS_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CBM").ToString <> "" Then
                                pFleetContJo.Cbm = dbr("CBM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTN1").ToString <> "" Then
                                pFleetContJo.Extn1 = dbr("EXTN1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTN2").ToString <> "" Then
                                pFleetContJo.Extn2 = dbr("EXTN2")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTV1").ToString <> "" Then
                                pFleetContJo.Extv1 = dbr("EXTV1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTV2").ToString <> "" Then
                                pFleetContJo.Extv2 = dbr("EXTV2")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetContJo As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetContJo
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
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                temp.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_NO").ToString <> "" Then
                                temp.ContJoNo = dbr("CONT_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("CONSIGNEE_ID").ToString <> "" Then
                                temp.ConsigneeId = dbr("CONSIGNEE_ID")
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
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_TO").ToString <> "" Then
                                temp.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_PICKUP").ToString <> "" Then
                                temp.MtyPickup = dbr("MTY_PICKUP")
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
                            If dbr("TO_LOCATION_ID").ToString <> "" Then
                                temp.ToLocationId = dbr("TO_LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HAND_LOCATION").ToString <> "" Then
                                temp.HandLocation = dbr("HAND_LOCATION")
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
                            If dbr("MODE_TYPE").ToString <> "" Then
                                temp.ModeType = dbr("MODE_TYPE")
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
                            If dbr("BILL_TO").ToString <> "" Then
                                temp.BillTo = dbr("BILL_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ON_ACCOUNT").ToString <> "" Then
                                temp.OnAccount = dbr("ON_ACCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_20").ToString <> "" Then
                                temp.NoOf20 = dbr("NO_OF_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_40").ToString <> "" Then
                                temp.NoOf40 = dbr("NO_OF_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFF_DATE").ToString <> "" Then
                                temp.StuffDate = dbr("STUFF_DATE")
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
                            If dbr("CHA_ID").ToString <> "" Then
                                temp.CHA = dbr("CHA_ID")
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
                            If dbr("BOE_NO").ToString <> "" Then
                                temp.BOENo = dbr("BOE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOE_DATE").ToString <> "" Then
                                temp.BOEDate = dbr("BOE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_INV_NO").ToString <> "" Then
                                temp.ShipperInvNo = dbr("SHIPPER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_INV_DATE").ToString <> "" Then
                                temp.ShipperInvDate = dbr("SHIPPER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MBL_NO").ToString <> "" Then
                                temp.MBLNo = dbr("MBL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MBL_DATE").ToString <> "" Then
                                temp.MBLDate = dbr("MBL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HBL_NO").ToString <> "" Then
                                temp.HBLNo = dbr("HBL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HBL_DATE").ToString <> "" Then
                                temp.HBLDate = dbr("HBL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        'Added 16/11/2022
                        Try
                            If dbr("HOD").ToString <> "" Then
                                temp.Hod = dbr("HOD")
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
                            If dbr("CLR_BY").ToString <> "" Then
                                temp.ClrBy = dbr("CLR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY").ToString <> "" Then
                                temp.Commodity = dbr("COMMODITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSIGNEE").ToString <> "" Then
                                temp.Consignee = dbr("CONSIGNEE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_TYPE").ToString <> "" Then
                                temp.PackageType = dbr("PACKAGE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARTONS").ToString <> "" Then
                                temp.Cartons = dbr("CARTONS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                temp.JONO = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                temp.JODate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_LOCATION_ID").ToString <> "" Then
                                temp.EmptyLocationId = dbr("EMPTY_LOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_DATE").ToString <> "" Then
                                temp.EmptyDate = dbr("EMPTY_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROSS_WT").ToString <> "" Then
                                temp.GrossWt = dbr("GROSS_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        'Added 16/02/2024
                        Try
                            If dbr("CBM").ToString <> "" Then
                                temp.Cbm = dbr("CBM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTN1").ToString <> "" Then
                                temp.Extn1 = dbr("EXTN1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTN2").ToString <> "" Then
                                temp.Extn2 = dbr("EXTN2")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTV1").ToString <> "" Then
                                temp.Extv1 = dbr("EXTV1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTV2").ToString <> "" Then
                                temp.Extv2 = dbr("EXTV2")
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
        Public Shared Function ReturnFleetContJo(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO", pFleetContJo.TerminalId & "," & pFleetContJo.ContJoId & ",'" & pFleetContJo.ContJoNo & "'")
                pFleetContJo = ReturnObjectValues(dbr, pFleetContJo)
                dbr.Close()
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoRebate(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_RBT", pFleetContJo.TerminalId & "," & pFleetContJo.ContJoId & ",'" & pFleetContJo.ContJoNo & "'")
                pFleetContJo = ReturnObjectValues(dbr, pFleetContJo)
                dbr.Close()
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoTerminalWise(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_TERMINAL", pFleetContJo.TerminalId & "," & pFleetContJo.ContJoId & ",'" & pFleetContJo.ContJoNo & "'")
                pFleetContJo = ReturnObjectValues(dbr, pFleetContJo)
                dbr.Close()
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetContJoMode(ByVal pFleetContJo As FleetContJo) As FleetContJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_MODE", pFleetContJo.TerminalId & "," & pFleetContJo.ContJoId & ",'" & pFleetContJo.ContJoNo & "'")
                pFleetContJo = ReturnObjectValues(dbr, pFleetContJo)
                dbr.Close()
            Catch ex As Exception
                pFleetContJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetContJo
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetContJoPendingList(ByVal pFleetContJo As FleetContJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetContJo As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_PEN", pFleetContJo.TerminalId)
                arrFleetContJo = ReturnObjectValuesList(dbr, arrFleetContJo)
                dbr.Close()
            Catch ex As Exception
                arrFleetContJo = Nothing
            End Try
            db.CloseDB()
            Return arrFleetContJo
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetContJoImpPendingList(ByVal pFleetContJo As FleetContJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetContJo As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_IMP", pFleetContJo.TerminalId)
                arrFleetContJo = ReturnObjectValuesList(dbr, arrFleetContJo)
                dbr.Close()
            Catch ex As Exception
                arrFleetContJo = Nothing
            End Try
            db.CloseDB()
            Return arrFleetContJo
        End Function
    End Class

End Namespace
