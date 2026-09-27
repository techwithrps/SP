Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetEquipmentMaster
    ''' @author	: Amit K. Singh- 13/9/2020
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetEquipmentMaster

        Private strStatePermitFrom As String ' Define Private Variable StatePermitFrom With DataType As String 
        Private strStatePermitTo As String ' Define Private Variable StatePermitTo With DataType As String 
        Private strRemarkNote As String ' Define Private Variable RemarkNote With DataType As String 
        Private strRoadTaxValidity As String ' Define Private Variable RoadTaxValidity With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngEquipmentId As Long ' Define Private Variable EquipmentId With DataType As Long 
        Private strEquipmentNo As String ' Define Private Variable EquipmentNo With DataType As String 
        Private strEquipmentType As String ' Define Private Variable EquipmentType With DataType As String 
        Private strPurchageDate As String ' Define Private Variable PurchageDate With DataType As String 
        Private strInsuranceNo As String ' Define Private Variable InsuranceNo With DataType As String 
        Private strEngNo As String ' Define Private Variable EngNo With DataType As String 
        Private strEngType As String ' Define Private Variable EngType With DataType As String 
        Private strVinNo As String ' Define Private Variable VinNo With DataType As String 
        Private lngManufacturingYear As Long ' Define Private Variable ManufacturingYear With DataType As Long 
        Private strModel As String ' Define Private Variable Model With DataType As String 
        Private strCondition As String ' Define Private Variable Condition With DataType As String 
        Private lngTareWt As Long ' Define Private Variable TareWt With DataType As Long 
        Private lngGrossWt As Long ' Define Private Variable GrossWt With DataType As Long 
        Private strStatus As String ' Define Private Variable Status With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strBedChangeable As String ' Define Private Variable BedChangeable With DataType As String 
        Private strImage As String ' Define Private Variable Image With DataType As String 
        Private strRegistrationDate As String ' Define Private Variable RegistrationDate With DataType As String 
        Private lngManufacturer As Long ' Define Private Variable Manufacturer With DataType As Long 
        Private strBedNo As String ' Define Private Variable BedNo With DataType As String 
        Private lngInsVendor As Long ' Define Private Variable InsVendor With DataType As Long 
        Private strInsValidity As String ' Define Private Variable InsValidity With DataType As String 
        Private strPermitFrom As String ' Define Private Variable PermitFrom With DataType As String 
        Private strPermitTo As String ' Define Private Variable PermitTo With DataType As String 
        Private strPollutionValidity As String ' Define Private Variable PollutionValidity With DataType As String 
        Private strRto As String ' Define Private Variable Rto With DataType As String 
        Private strFitnessDoc As String ' Define Private Variable FitnessDoc With DataType As String 
        Private strValidity As String ' Define Private Variable Validity With DataType As String 
        Private strRcDoc As String ' Define Private Variable RcDoc With DataType As String 
        Private strInsuranceDoc As String ' Define Private Variable InsuranceDoc With DataType As String 
        Private strPermitA As String ' Define Private Variable PermitA With DataType As String 
        Private strPermitB As String ' Define Private Variable PermitB With DataType As String 
        Private lngHpBy As Long ' Define Private Variable HpBy With DataType As Long 
        Private strXlType As String ' Define Private Variable XlType With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private lngDriverAttachId As Long ' Define Private Variable DriverAttachId With DataType As Long 
        Private strDriverAttcahStatus As String ' Define Private Variable DriverAttcahStatus With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngVendorId As Long

        ''' <summary>
        ''' Get or Set the Value of StatePermitFrom
        ''' </summary>
        ''' <value>strStatePermitFrom</value>
        ''' <returns> Return strStatePermitFrom</returns>
        ''' <remarks> Get or Set the Value of StatePermitFrom  </remarks>
        '''
        Public Property StatePermitFrom() As String
            Get
                Return strStatePermitFrom
            End Get
            Set(ByVal value As String)
                strStatePermitFrom = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of StatePermitTo
        ''' </summary>
        ''' <value>strStatePermitTo</value>
        ''' <returns> Return strStatePermitTo</returns>
        ''' <remarks> Get or Set the Value of StatePermitTo  </remarks>
        '''
        Public Property StatePermitTo() As String
            Get
                Return strStatePermitTo
            End Get
            Set(ByVal value As String)
                strStatePermitTo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RemarkNote
        ''' </summary>
        ''' <value>strRemarkNote</value>
        ''' <returns> Return strRemarkNote</returns>
        ''' <remarks> Get or Set the Value of RemarkNote  </remarks>
        '''
        Public Property RemarkNote() As String
            Get
                Return strRemarkNote
            End Get
            Set(ByVal value As String)
                strRemarkNote = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RoadTaxValidity
        ''' </summary>
        ''' <value>strRoadTaxValidity</value>
        ''' <returns> Return strRoadTaxValidity</returns>
        ''' <remarks> Get or Set the Value of RoadTaxValidity  </remarks>
        '''
        Public Property RoadTaxValidity() As String
            Get
                Return strRoadTaxValidity
            End Get
            Set(ByVal value As String)
                strRoadTaxValidity = value
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
        ''' Get or Set the Value of EquipmentId
        ''' </summary>
        ''' <value>lngEquipmentId</value>
        ''' <returns> Return lngEquipmentId</returns>
        ''' <remarks> Get or Set the Value of EquipmentId  </remarks>
        '''
        Public Property EquipmentId() As Long
            Get
                Return lngEquipmentId
            End Get
            Set(ByVal value As Long)
                lngEquipmentId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EquipmentNo
        ''' </summary>
        ''' <value>strEquipmentNo</value>
        ''' <returns> Return strEquipmentNo</returns>
        ''' <remarks> Get or Set the Value of EquipmentNo  </remarks>
        '''
        Public Property EquipmentNo() As String
            Get
                Return strEquipmentNo
            End Get
            Set(ByVal value As String)
                strEquipmentNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EquipmentType
        ''' </summary>
        ''' <value>strEquipmentType</value>
        ''' <returns> Return strEquipmentType</returns>
        ''' <remarks> Get or Set the Value of EquipmentType  </remarks>
        '''
        Public Property EquipmentType() As String
            Get
                Return strEquipmentType
            End Get
            Set(ByVal value As String)
                strEquipmentType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PurchageDate
        ''' </summary>
        ''' <value>strPurchageDate</value>
        ''' <returns> Return strPurchageDate</returns>
        ''' <remarks> Get or Set the Value of PurchageDate  </remarks>
        '''
        Public Property PurchageDate() As String
            Get
                Return strPurchageDate
            End Get
            Set(ByVal value As String)
                strPurchageDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InsuranceNo
        ''' </summary>
        ''' <value>strInsuranceNo</value>
        ''' <returns> Return strInsuranceNo</returns>
        ''' <remarks> Get or Set the Value of InsuranceNo  </remarks>
        '''
        Public Property InsuranceNo() As String
            Get
                Return strInsuranceNo
            End Get
            Set(ByVal value As String)
                strInsuranceNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EngNo
        ''' </summary>
        ''' <value>strEngNo</value>
        ''' <returns> Return strEngNo</returns>
        ''' <remarks> Get or Set the Value of EngNo  </remarks>
        '''
        Public Property EngNo() As String
            Get
                Return strEngNo
            End Get
            Set(ByVal value As String)
                strEngNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EngType
        ''' </summary>
        ''' <value>strEngType</value>
        ''' <returns> Return strEngType</returns>
        ''' <remarks> Get or Set the Value of EngType  </remarks>
        '''
        Public Property EngType() As String
            Get
                Return strEngType
            End Get
            Set(ByVal value As String)
                strEngType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VinNo
        ''' </summary>
        ''' <value>strVinNo</value>
        ''' <returns> Return strVinNo</returns>
        ''' <remarks> Get or Set the Value of VinNo  </remarks>
        '''
        Public Property VinNo() As String
            Get
                Return strVinNo
            End Get
            Set(ByVal value As String)
                strVinNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ManufacturingYear
        ''' </summary>
        ''' <value>lngManufacturingYear</value>
        ''' <returns> Return lngManufacturingYear</returns>
        ''' <remarks> Get or Set the Value of ManufacturingYear  </remarks>
        '''
        Public Property ManufacturingYear() As Long
            Get
                Return lngManufacturingYear
            End Get
            Set(ByVal value As Long)
                lngManufacturingYear = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Model
        ''' </summary>
        ''' <value>strModel</value>
        ''' <returns> Return strModel</returns>
        ''' <remarks> Get or Set the Value of Model  </remarks>
        '''
        Public Property Model() As String
            Get
                Return strModel
            End Get
            Set(ByVal value As String)
                strModel = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Condition
        ''' </summary>
        ''' <value>strCondition</value>
        ''' <returns> Return strCondition</returns>
        ''' <remarks> Get or Set the Value of Condition  </remarks>
        '''
        Public Property Condition() As String
            Get
                Return strCondition
            End Get
            Set(ByVal value As String)
                strCondition = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TareWt
        ''' </summary>
        ''' <value>lngTareWt</value>
        ''' <returns> Return lngTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property TareWt() As Long
            Get
                Return lngTareWt
            End Get
            Set(ByVal value As Long)
                lngTareWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrossWt
        ''' </summary>
        ''' <value>lngGrossWt</value>
        ''' <returns> Return lngGrossWt</returns>
        ''' <remarks> Get or Set the Value of GrossWt  </remarks>
        '''
        Public Property GrossWt() As Long
            Get
                Return lngGrossWt
            End Get
            Set(ByVal value As Long)
                lngGrossWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property Status() As String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
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
        ''' Get or Set the Value of BedChangeable
        ''' </summary>
        ''' <value>strBedChangeable</value>
        ''' <returns> Return strBedChangeable</returns>
        ''' <remarks> Get or Set the Value of BedChangeable  </remarks>
        '''
        Public Property BedChangeable() As String
            Get
                Return strBedChangeable
            End Get
            Set(ByVal value As String)
                strBedChangeable = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Image
        ''' </summary>
        ''' <value>strImage</value>
        ''' <returns> Return strImage</returns>
        ''' <remarks> Get or Set the Value of Image  </remarks>
        '''
        Public Property Image() As String
            Get
                Return strImage
            End Get
            Set(ByVal value As String)
                strImage = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RegistrationDate
        ''' </summary>
        ''' <value>strRegistrationDate</value>
        ''' <returns> Return strRegistrationDate</returns>
        ''' <remarks> Get or Set the Value of RegistrationDate  </remarks>
        '''
        Public Property RegistrationDate() As String
            Get
                Return strRegistrationDate
            End Get
            Set(ByVal value As String)
                strRegistrationDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Manufacturer
        ''' </summary>
        ''' <value>lngManufacturer</value>
        ''' <returns> Return lngManufacturer</returns>
        ''' <remarks> Get or Set the Value of Manufacturer  </remarks>
        '''
        Public Property Manufacturer() As Long
            Get
                Return lngManufacturer
            End Get
            Set(ByVal value As Long)
                lngManufacturer = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BedNo
        ''' </summary>
        ''' <value>strBedNo</value>
        ''' <returns> Return strBedNo</returns>
        ''' <remarks> Get or Set the Value of BedNo  </remarks>
        '''
        Public Property BedNo() As String
            Get
                Return strBedNo
            End Get
            Set(ByVal value As String)
                strBedNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InsVendor
        ''' </summary>
        ''' <value>lngInsVendor</value>
        ''' <returns> Return lngInsVendor</returns>
        ''' <remarks> Get or Set the Value of InsVendor  </remarks>
        '''
        Public Property InsVendor() As Long
            Get
                Return lngInsVendor
            End Get
            Set(ByVal value As Long)
                lngInsVendor = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InsValidity
        ''' </summary>
        ''' <value>strInsValidity</value>
        ''' <returns> Return strInsValidity</returns>
        ''' <remarks> Get or Set the Value of InsValidity  </remarks>
        '''
        Public Property InsValidity() As String
            Get
                Return strInsValidity
            End Get
            Set(ByVal value As String)
                strInsValidity = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PermitFrom
        ''' </summary>
        ''' <value>strPermitFrom</value>
        ''' <returns> Return strPermitFrom</returns>
        ''' <remarks> Get or Set the Value of PermitFrom  </remarks>
        '''
        Public Property PermitFrom() As String
            Get
                Return strPermitFrom
            End Get
            Set(ByVal value As String)
                strPermitFrom = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PermitTo
        ''' </summary>
        ''' <value>strPermitTo</value>
        ''' <returns> Return strPermitTo</returns>
        ''' <remarks> Get or Set the Value of PermitTo  </remarks>
        '''
        Public Property PermitTo() As String
            Get
                Return strPermitTo
            End Get
            Set(ByVal value As String)
                strPermitTo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PollutionValidity
        ''' </summary>
        ''' <value>strPollutionValidity</value>
        ''' <returns> Return strPollutionValidity</returns>
        ''' <remarks> Get or Set the Value of PollutionValidity  </remarks>
        '''
        Public Property PollutionValidity() As String
            Get
                Return strPollutionValidity
            End Get
            Set(ByVal value As String)
                strPollutionValidity = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Rto
        ''' </summary>
        ''' <value>strRto</value>
        ''' <returns> Return strRto</returns>
        ''' <remarks> Get or Set the Value of Rto  </remarks>
        '''
        Public Property Rto() As String
            Get
                Return strRto
            End Get
            Set(ByVal value As String)
                strRto = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FitnessDoc
        ''' </summary>
        ''' <value>strFitnessDoc</value>
        ''' <returns> Return strFitnessDoc</returns>
        ''' <remarks> Get or Set the Value of FitnessDoc  </remarks>
        '''
        Public Property FitnessDoc() As String
            Get
                Return strFitnessDoc
            End Get
            Set(ByVal value As String)
                strFitnessDoc = value
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
        ''' Get or Set the Value of RcDoc
        ''' </summary>
        ''' <value>strRcDoc</value>
        ''' <returns> Return strRcDoc</returns>
        ''' <remarks> Get or Set the Value of RcDoc  </remarks>
        '''
        Public Property RcDoc() As String
            Get
                Return strRcDoc
            End Get
            Set(ByVal value As String)
                strRcDoc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of InsuranceDoc
        ''' </summary>
        ''' <value>strInsuranceDoc</value>
        ''' <returns> Return strInsuranceDoc</returns>
        ''' <remarks> Get or Set the Value of InsuranceDoc  </remarks>
        '''
        Public Property InsuranceDoc() As String
            Get
                Return strInsuranceDoc
            End Get
            Set(ByVal value As String)
                strInsuranceDoc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PermitA
        ''' </summary>
        ''' <value>strPermitA</value>
        ''' <returns> Return strPermitA</returns>
        ''' <remarks> Get or Set the Value of PermitA  </remarks>
        '''
        Public Property PermitA() As String
            Get
                Return strPermitA
            End Get
            Set(ByVal value As String)
                strPermitA = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PermitB
        ''' </summary>
        ''' <value>strPermitB</value>
        ''' <returns> Return strPermitB</returns>
        ''' <remarks> Get or Set the Value of PermitB  </remarks>
        '''
        Public Property PermitB() As String
            Get
                Return strPermitB
            End Get
            Set(ByVal value As String)
                strPermitB = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of HpBy
        ''' </summary>
        ''' <value>lngHpBy</value>
        ''' <returns> Return lngHpBy</returns>
        ''' <remarks> Get or Set the Value of HpBy  </remarks>
        '''
        Public Property HpBy() As Long
            Get
                Return lngHpBy
            End Get
            Set(ByVal value As Long)
                lngHpBy = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of XlType
        ''' </summary>
        ''' <value>strXlType</value>
        ''' <returns> Return strXlType</returns>
        ''' <remarks> Get or Set the Value of XlType  </remarks>
        '''
        Public Property XlType() As String
            Get
                Return strXlType
            End Get
            Set(ByVal value As String)
                strXlType = value
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
        ''' Get or Set the Value of DriverAttachId
        ''' </summary>
        ''' <value>lngDriverAttachId</value>
        ''' <returns> Return lngDriverAttachId</returns>
        ''' <remarks> Get or Set the Value of DriverAttachId  </remarks>
        '''
        Public Property DriverAttachId() As Long
            Get
                Return lngDriverAttachId
            End Get
            Set(ByVal value As Long)
                lngDriverAttachId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DriverAttcahStatus
        ''' </summary>
        ''' <value>strDriverAttcahStatus</value>
        ''' <returns> Return strDriverAttcahStatus</returns>
        ''' <remarks> Get or Set the Value of DriverAttcahStatus  </remarks>
        '''
        Public Property DriverAttcahStatus() As String
            Get
                Return strDriverAttcahStatus
            End Get
            Set(ByVal value As String)
                strDriverAttcahStatus = value
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
            strStatePermitFrom = ""
            strStatePermitTo = ""
            strRemarkNote = ""
            strRoadTaxValidity = ""
            lngTerminalId = 0
            lngEquipmentId = 0
            strEquipmentNo = ""
            strEquipmentType = ""
            strPurchageDate = ""
            strInsuranceNo = ""
            strEngNo = ""
            strEngType = ""
            strVinNo = ""
            lngManufacturingYear = 0
            strModel = ""
            strCondition = ""
            lngTareWt = 0
            lngGrossWt = 0
            strStatus = ""
            strCreatedOn = ""
            strCreatedBy = ""
            strBedChangeable = ""
            strImage = ""
            strRegistrationDate = ""
            lngManufacturer = 0
            strBedNo = ""
            lngInsVendor = 0
            lngVendorId = 0
            strInsValidity = ""
            strPermitFrom = ""
            strPermitTo = ""
            strPollutionValidity = ""
            strRto = ""
            strFitnessDoc = ""
            strValidity = ""
            strRcDoc = ""
            strInsuranceDoc = ""
            strPermitA = ""
            strPermitB = ""
            lngHpBy = 0
            strXlType = ""
            lngCompanyId = 0
            lngDriverAttachId = 0
            strDriverAttcahStatus = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetEquipmentMaster"></param>
        ''' <returns>Return pFleetEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_STATE_PERMIT_FROM", pFleetEquipmentMaster.StatePermitFrom)
                db.AddParameter("p_STATE_PERMIT_TO", pFleetEquipmentMaster.StatePermitTo)
                db.AddParameter("p_REMARK_NOTE", pFleetEquipmentMaster.RemarkNote)
                db.AddParameter("p_ROAD_TAX_VALIDITY", pFleetEquipmentMaster.RoadTaxValidity)
                db.AddParameter("p_TERMINAL_ID", pFleetEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetEquipmentMaster.EquipmentId, ParameterDirection.Output)
                db.AddParameter("p_EQUIPMENT_NO", pFleetEquipmentMaster.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE", pFleetEquipmentMaster.EquipmentType)
                db.AddParameter("p_PURCHAGE_DATE", pFleetEquipmentMaster.PurchageDate)
                db.AddParameter("p_INSURANCE_NO", pFleetEquipmentMaster.InsuranceNo)
                db.AddParameter("p_ENG_NO", pFleetEquipmentMaster.EngNo)
                db.AddParameter("p_ENG_TYPE", pFleetEquipmentMaster.EngType)
                db.AddParameter("p_VIN_NO", pFleetEquipmentMaster.VinNo)
                db.AddParameter("p_MANUFACTURING_YEAR", pFleetEquipmentMaster.ManufacturingYear)
                db.AddParameter("p_MODEL", pFleetEquipmentMaster.Model)
                db.AddParameter("p_CONDITION", pFleetEquipmentMaster.Condition)
                db.AddParameter("p_TARE_WT", pFleetEquipmentMaster.TareWt)
                db.AddParameter("p_GROSS_WT", pFleetEquipmentMaster.GrossWt)
                db.AddParameter("p_STATUS", pFleetEquipmentMaster.Status)
                db.AddParameter("p_CREATED_ON", pFleetEquipmentMaster.CreatedOn)
                db.AddParameter("p_CREATED_BY", pFleetEquipmentMaster.CreatedBy)
                db.AddParameter("p_BED_CHANGEABLE", pFleetEquipmentMaster.BedChangeable)
                db.AddParameter("p_IMAGE", pFleetEquipmentMaster.Image)
                db.AddParameter("p_REGISTRATION_DATE", pFleetEquipmentMaster.RegistrationDate)
                db.AddParameter("p_MANUFACTURER", pFleetEquipmentMaster.Manufacturer)
                db.AddParameter("p_BED_NO", pFleetEquipmentMaster.BedNo)
                db.AddParameter("p_INS_VENDOR", pFleetEquipmentMaster.InsVendor)
                db.AddParameter("p_INS_VALIDITY", pFleetEquipmentMaster.InsValidity)
                db.AddParameter("p_PERMIT_FROM", pFleetEquipmentMaster.PermitFrom)
                db.AddParameter("p_PERMIT_TO", pFleetEquipmentMaster.PermitTo)
                db.AddParameter("p_POLLUTION_VALIDITY", pFleetEquipmentMaster.PollutionValidity)
                db.AddParameter("p_RTO", pFleetEquipmentMaster.Rto)
                db.AddParameter("p_FITNESS_DOC", pFleetEquipmentMaster.FitnessDoc)
                db.AddParameter("p_VALIDITY", pFleetEquipmentMaster.Validity)
                db.AddParameter("p_RC_DOC", pFleetEquipmentMaster.RcDoc)
                db.AddParameter("p_INSURANCE_DOC", pFleetEquipmentMaster.InsuranceDoc)
                db.AddParameter("p_PERMIT_A", pFleetEquipmentMaster.PermitA)
                db.AddParameter("p_PERMIT_B", pFleetEquipmentMaster.PermitB)
                db.AddParameter("p_HP_BY", pFleetEquipmentMaster.HpBy)
                db.AddParameter("p_XL_TYPE", pFleetEquipmentMaster.XlType)
                db.AddParameter("p_COMPANY_ID", pFleetEquipmentMaster.CompanyId)
                db.AddParameter("p_DRIVER_ATTACH_ID", pFleetEquipmentMaster.DriverAttachId)
                db.AddParameter("p_DRIVER_ATTCAH_STATUS", pFleetEquipmentMaster.DriverAttcahStatus)
                db.AddParameter("p_VENDOR_ID", pFleetEquipmentMaster.VendorId)
                db.AddParameter("p_ErrorMsg", pFleetEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetEquipmentMaster.EquipmentId = db.Parameters.Item("p_EQUIPMENT_ID").value
            
                If pFleetEquipmentMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetEquipmentMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetEquipmentMaster"></param>
        ''' <returns>Return pFleetEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_STATE_PERMIT_FROM", pFleetEquipmentMaster.StatePermitFrom)
                db.AddParameter("p_STATE_PERMIT_TO", pFleetEquipmentMaster.StatePermitTo)
                db.AddParameter("p_REMARK_NOTE", pFleetEquipmentMaster.RemarkNote)
                db.AddParameter("p_ROAD_TAX_VALIDITY", pFleetEquipmentMaster.RoadTaxValidity)
                db.AddParameter("p_TERMINAL_ID", pFleetEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetEquipmentMaster.EquipmentId, ParameterDirection.Output)
                db.AddParameter("p_EQUIPMENT_NO", pFleetEquipmentMaster.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE", pFleetEquipmentMaster.EquipmentType)
                db.AddParameter("p_PURCHAGE_DATE", pFleetEquipmentMaster.PurchageDate)
                db.AddParameter("p_INSURANCE_NO", pFleetEquipmentMaster.InsuranceNo)
                db.AddParameter("p_ENG_NO", pFleetEquipmentMaster.EngNo)
                db.AddParameter("p_ENG_TYPE", pFleetEquipmentMaster.EngType)
                db.AddParameter("p_VIN_NO", pFleetEquipmentMaster.VinNo)
                db.AddParameter("p_MANUFACTURING_YEAR", pFleetEquipmentMaster.ManufacturingYear)
                db.AddParameter("p_MODEL", pFleetEquipmentMaster.Model)
                db.AddParameter("p_CONDITION", pFleetEquipmentMaster.Condition)
                db.AddParameter("p_TARE_WT", pFleetEquipmentMaster.TareWt)
                db.AddParameter("p_GROSS_WT", pFleetEquipmentMaster.GrossWt)
                db.AddParameter("p_STATUS", pFleetEquipmentMaster.Status)
                db.AddParameter("p_CREATED_ON", pFleetEquipmentMaster.CreatedOn)
                db.AddParameter("p_CREATED_BY", pFleetEquipmentMaster.CreatedBy)
                db.AddParameter("p_BED_CHANGEABLE", pFleetEquipmentMaster.BedChangeable)
                db.AddParameter("p_IMAGE", pFleetEquipmentMaster.Image)
                db.AddParameter("p_REGISTRATION_DATE", pFleetEquipmentMaster.RegistrationDate)
                db.AddParameter("p_MANUFACTURER", pFleetEquipmentMaster.Manufacturer)
                db.AddParameter("p_BED_NO", pFleetEquipmentMaster.BedNo)
                db.AddParameter("p_INS_VENDOR", pFleetEquipmentMaster.InsVendor)
                db.AddParameter("p_INS_VALIDITY", pFleetEquipmentMaster.InsValidity)
                db.AddParameter("p_PERMIT_FROM", pFleetEquipmentMaster.PermitFrom)
                db.AddParameter("p_PERMIT_TO", pFleetEquipmentMaster.PermitTo)
                db.AddParameter("p_POLLUTION_VALIDITY", pFleetEquipmentMaster.PollutionValidity)
                db.AddParameter("p_RTO", pFleetEquipmentMaster.Rto)
                db.AddParameter("p_FITNESS_DOC", pFleetEquipmentMaster.FitnessDoc)
                db.AddParameter("p_VALIDITY", pFleetEquipmentMaster.Validity)
                db.AddParameter("p_RC_DOC", pFleetEquipmentMaster.RcDoc)
                db.AddParameter("p_INSURANCE_DOC", pFleetEquipmentMaster.InsuranceDoc)
                db.AddParameter("p_PERMIT_A", pFleetEquipmentMaster.PermitA)
                db.AddParameter("p_PERMIT_B", pFleetEquipmentMaster.PermitB)
                db.AddParameter("p_HP_BY", pFleetEquipmentMaster.HpBy)
                db.AddParameter("p_XL_TYPE", pFleetEquipmentMaster.XlType)
                db.AddParameter("p_COMPANY_ID", pFleetEquipmentMaster.CompanyId)
                db.AddParameter("p_DRIVER_ATTACH_ID", pFleetEquipmentMaster.DriverAttachId)
                db.AddParameter("p_DRIVER_ATTCAH_STATUS", pFleetEquipmentMaster.DriverAttcahStatus)
                db.AddParameter("p_VENDOR_ID", pFleetEquipmentMaster.VendorId)
                db.AddParameter("p_ErrorMsg", pFleetEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetEquipmentMaster.EquipmentId = db.Parameters.Item("p_EQUIPMENT_ID").value
            Catch ex As Exception
                pFleetEquipmentMaster.Errormsg = ex.Message
            End Try
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetEquipmentMaster"></param>
        ''' <returns>Return pFleetEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_STATE_PERMIT_FROM", pFleetEquipmentMaster.StatePermitFrom)
                db.AddParameter("p_STATE_PERMIT_TO", pFleetEquipmentMaster.StatePermitTo)
                db.AddParameter("p_REMARK_NOTE", pFleetEquipmentMaster.RemarkNote)
                db.AddParameter("p_ROAD_TAX_VALIDITY", pFleetEquipmentMaster.RoadTaxValidity)
                db.AddParameter("p_TERMINAL_ID", pFleetEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetEquipmentMaster.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pFleetEquipmentMaster.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE", pFleetEquipmentMaster.EquipmentType)
                db.AddParameter("p_PURCHAGE_DATE", pFleetEquipmentMaster.PurchageDate)
                db.AddParameter("p_INSURANCE_NO", pFleetEquipmentMaster.InsuranceNo)
                db.AddParameter("p_ENG_NO", pFleetEquipmentMaster.EngNo)
                db.AddParameter("p_ENG_TYPE", pFleetEquipmentMaster.EngType)
                db.AddParameter("p_VIN_NO", pFleetEquipmentMaster.VinNo)
                db.AddParameter("p_MANUFACTURING_YEAR", pFleetEquipmentMaster.ManufacturingYear)
                db.AddParameter("p_MODEL", pFleetEquipmentMaster.Model)
                db.AddParameter("p_CONDITION", pFleetEquipmentMaster.Condition)
                db.AddParameter("p_TARE_WT", pFleetEquipmentMaster.TareWt)
                db.AddParameter("p_GROSS_WT", pFleetEquipmentMaster.GrossWt)
                db.AddParameter("p_STATUS", pFleetEquipmentMaster.Status)
                db.AddParameter("p_CREATED_ON", pFleetEquipmentMaster.CreatedOn)
                db.AddParameter("p_CREATED_BY", pFleetEquipmentMaster.CreatedBy)
                db.AddParameter("p_BED_CHANGEABLE", pFleetEquipmentMaster.BedChangeable)
                db.AddParameter("p_IMAGE", pFleetEquipmentMaster.Image)
                db.AddParameter("p_REGISTRATION_DATE", pFleetEquipmentMaster.RegistrationDate)
                db.AddParameter("p_MANUFACTURER", pFleetEquipmentMaster.Manufacturer)
                db.AddParameter("p_BED_NO", pFleetEquipmentMaster.BedNo)
                db.AddParameter("p_INS_VENDOR", pFleetEquipmentMaster.InsVendor)
                db.AddParameter("p_INS_VALIDITY", pFleetEquipmentMaster.InsValidity)
                db.AddParameter("p_PERMIT_FROM", pFleetEquipmentMaster.PermitFrom)
                db.AddParameter("p_PERMIT_TO", pFleetEquipmentMaster.PermitTo)
                db.AddParameter("p_POLLUTION_VALIDITY", pFleetEquipmentMaster.PollutionValidity)
                db.AddParameter("p_RTO", pFleetEquipmentMaster.Rto)
                db.AddParameter("p_FITNESS_DOC", pFleetEquipmentMaster.FitnessDoc)
                db.AddParameter("p_VALIDITY", pFleetEquipmentMaster.Validity)
                db.AddParameter("p_RC_DOC", pFleetEquipmentMaster.RcDoc)
                db.AddParameter("p_INSURANCE_DOC", pFleetEquipmentMaster.InsuranceDoc)
                db.AddParameter("p_PERMIT_A", pFleetEquipmentMaster.PermitA)
                db.AddParameter("p_PERMIT_B", pFleetEquipmentMaster.PermitB)
                db.AddParameter("p_HP_BY", pFleetEquipmentMaster.HpBy)
                db.AddParameter("p_XL_TYPE", pFleetEquipmentMaster.XlType)
                db.AddParameter("p_COMPANY_ID", pFleetEquipmentMaster.CompanyId)
                db.AddParameter("p_DRIVER_ATTACH_ID", pFleetEquipmentMaster.DriverAttachId)
                db.AddParameter("p_DRIVER_ATTCAH_STATUS", pFleetEquipmentMaster.DriverAttcahStatus)
                db.AddParameter("p_VENDOR_ID", pFleetEquipmentMaster.VendorId)
                db.AddParameter("p_ErrorMsg", pFleetEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetEquipmentMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetEquipmentMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetEquipmentMaster"></param>
        ''' <returns>Return pFleetEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_STATE_PERMIT_FROM", pFleetEquipmentMaster.StatePermitFrom)
                db.AddParameter("p_STATE_PERMIT_TO", pFleetEquipmentMaster.StatePermitTo)
                db.AddParameter("p_REMARK_NOTE", pFleetEquipmentMaster.RemarkNote)
                db.AddParameter("p_ROAD_TAX_VALIDITY", pFleetEquipmentMaster.RoadTaxValidity)
                db.AddParameter("p_TERMINAL_ID", pFleetEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetEquipmentMaster.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pFleetEquipmentMaster.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE", pFleetEquipmentMaster.EquipmentType)
                db.AddParameter("p_PURCHAGE_DATE", pFleetEquipmentMaster.PurchageDate)
                db.AddParameter("p_INSURANCE_NO", pFleetEquipmentMaster.InsuranceNo)
                db.AddParameter("p_ENG_NO", pFleetEquipmentMaster.EngNo)
                db.AddParameter("p_ENG_TYPE", pFleetEquipmentMaster.EngType)
                db.AddParameter("p_VIN_NO", pFleetEquipmentMaster.VinNo)
                db.AddParameter("p_MANUFACTURING_YEAR", pFleetEquipmentMaster.ManufacturingYear)
                db.AddParameter("p_MODEL", pFleetEquipmentMaster.Model)
                db.AddParameter("p_CONDITION", pFleetEquipmentMaster.Condition)
                db.AddParameter("p_TARE_WT", pFleetEquipmentMaster.TareWt)
                db.AddParameter("p_GROSS_WT", pFleetEquipmentMaster.GrossWt)
                db.AddParameter("p_STATUS", pFleetEquipmentMaster.Status)
                db.AddParameter("p_CREATED_ON", pFleetEquipmentMaster.CreatedOn)
                db.AddParameter("p_CREATED_BY", pFleetEquipmentMaster.CreatedBy)
                db.AddParameter("p_BED_CHANGEABLE", pFleetEquipmentMaster.BedChangeable)
                db.AddParameter("p_IMAGE", pFleetEquipmentMaster.Image)
                db.AddParameter("p_REGISTRATION_DATE", pFleetEquipmentMaster.RegistrationDate)
                db.AddParameter("p_MANUFACTURER", pFleetEquipmentMaster.Manufacturer)
                db.AddParameter("p_BED_NO", pFleetEquipmentMaster.BedNo)
                db.AddParameter("p_INS_VENDOR", pFleetEquipmentMaster.InsVendor)
                db.AddParameter("p_INS_VALIDITY", pFleetEquipmentMaster.InsValidity)
                db.AddParameter("p_PERMIT_FROM", pFleetEquipmentMaster.PermitFrom)
                db.AddParameter("p_PERMIT_TO", pFleetEquipmentMaster.PermitTo)
                db.AddParameter("p_POLLUTION_VALIDITY", pFleetEquipmentMaster.PollutionValidity)
                db.AddParameter("p_RTO", pFleetEquipmentMaster.Rto)
                db.AddParameter("p_FITNESS_DOC", pFleetEquipmentMaster.FitnessDoc)
                db.AddParameter("p_VALIDITY", pFleetEquipmentMaster.Validity)
                db.AddParameter("p_RC_DOC", pFleetEquipmentMaster.RcDoc)
                db.AddParameter("p_INSURANCE_DOC", pFleetEquipmentMaster.InsuranceDoc)
                db.AddParameter("p_PERMIT_A", pFleetEquipmentMaster.PermitA)
                db.AddParameter("p_PERMIT_B", pFleetEquipmentMaster.PermitB)
                db.AddParameter("p_HP_BY", pFleetEquipmentMaster.HpBy)
                db.AddParameter("p_XL_TYPE", pFleetEquipmentMaster.XlType)
                db.AddParameter("p_COMPANY_ID", pFleetEquipmentMaster.CompanyId)
                db.AddParameter("p_DRIVER_ATTACH_ID", pFleetEquipmentMaster.DriverAttachId)
                db.AddParameter("p_DRIVER_ATTCAH_STATUS", pFleetEquipmentMaster.DriverAttcahStatus)
                db.AddParameter("p_VENDOR_ID", pFleetEquipmentMaster.VendorId)
                db.AddParameter("p_ErrorMsg", pFleetEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetEquipmentMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("STATE_PERMIT_FROM").ToString <> "" Then
                                PFleetEquipmentMaster.StatePermitFrom = dbr("STATE_PERMIT_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_PERMIT_TO").ToString <> "" Then
                                PFleetEquipmentMaster.StatePermitTo = dbr("STATE_PERMIT_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK_NOTE").ToString <> "" Then
                                PFleetEquipmentMaster.RemarkNote = dbr("REMARK_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROAD_TAX_VALIDITY").ToString <> "" Then
                                PFleetEquipmentMaster.RoadTaxValidity = dbr("ROAD_TAX_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetEquipmentMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                PFleetEquipmentMaster.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_NO").ToString <> "" Then
                                PFleetEquipmentMaster.EquipmentNo = dbr("EQUIPMENT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE").ToString <> "" Then
                                PFleetEquipmentMaster.EquipmentType = dbr("EQUIPMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHAGE_DATE").ToString <> "" Then
                                PFleetEquipmentMaster.PurchageDate = dbr("PURCHAGE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSURANCE_NO").ToString <> "" Then
                                PFleetEquipmentMaster.InsuranceNo = dbr("INSURANCE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ENG_NO").ToString <> "" Then
                                PFleetEquipmentMaster.EngNo = dbr("ENG_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ENG_TYPE").ToString <> "" Then
                                PFleetEquipmentMaster.EngType = dbr("ENG_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VIN_NO").ToString <> "" Then
                                PFleetEquipmentMaster.VinNo = dbr("VIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURING_YEAR").ToString <> "" Then
                                PFleetEquipmentMaster.ManufacturingYear = dbr("MANUFACTURING_YEAR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODEL").ToString <> "" Then
                                PFleetEquipmentMaster.Model = dbr("MODEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONDITION").ToString <> "" Then
                                PFleetEquipmentMaster.Condition = dbr("CONDITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                PFleetEquipmentMaster.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROSS_WT").ToString <> "" Then
                                PFleetEquipmentMaster.GrossWt = dbr("GROSS_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                PFleetEquipmentMaster.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetEquipmentMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetEquipmentMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_CHANGEABLE").ToString <> "" Then
                                PFleetEquipmentMaster.BedChangeable = dbr("BED_CHANGEABLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMAGE").ToString <> "" Then
                                PFleetEquipmentMaster.Image = dbr("IMAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REGISTRATION_DATE").ToString <> "" Then
                                PFleetEquipmentMaster.RegistrationDate = dbr("REGISTRATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURER").ToString <> "" Then
                                PFleetEquipmentMaster.Manufacturer = dbr("MANUFACTURER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_NO").ToString <> "" Then
                                PFleetEquipmentMaster.BedNo = dbr("BED_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INS_VENDOR").ToString <> "" Then
                                PFleetEquipmentMaster.InsVendor = dbr("INS_VENDOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INS_VALIDITY").ToString <> "" Then
                                PFleetEquipmentMaster.InsValidity = dbr("INS_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_FROM").ToString <> "" Then
                                PFleetEquipmentMaster.PermitFrom = dbr("PERMIT_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_TO").ToString <> "" Then
                                PFleetEquipmentMaster.PermitTo = dbr("PERMIT_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POLLUTION_VALIDITY").ToString <> "" Then
                                PFleetEquipmentMaster.PollutionValidity = dbr("POLLUTION_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RTO").ToString <> "" Then
                                PFleetEquipmentMaster.Rto = dbr("RTO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FITNESS_DOC").ToString <> "" Then
                                PFleetEquipmentMaster.FitnessDoc = dbr("FITNESS_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY").ToString <> "" Then
                                PFleetEquipmentMaster.Validity = dbr("VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RC_DOC").ToString <> "" Then
                                PFleetEquipmentMaster.RcDoc = dbr("RC_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSURANCE_DOC").ToString <> "" Then
                                PFleetEquipmentMaster.InsuranceDoc = dbr("INSURANCE_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_A").ToString <> "" Then
                                PFleetEquipmentMaster.PermitA = dbr("PERMIT_A")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_B").ToString <> "" Then
                                PFleetEquipmentMaster.PermitB = dbr("PERMIT_B")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HP_BY").ToString <> "" Then
                                PFleetEquipmentMaster.HpBy = dbr("HP_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("XL_TYPE").ToString <> "" Then
                                PFleetEquipmentMaster.XlType = dbr("XL_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                PFleetEquipmentMaster.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ATTACH_ID").ToString <> "" Then
                                PFleetEquipmentMaster.DriverAttachId = dbr("DRIVER_ATTACH_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ATTCAH_STATUS").ToString <> "" Then
                                PFleetEquipmentMaster.DriverAttcahStatus = dbr("DRIVER_ATTCAH_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pFleetEquipmentMaster.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetEquipmentMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetEquipmentMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetEquipmentMaster
                        Try
                            If dbr("STATE_PERMIT_FROM").ToString <> "" Then
                                temp.StatePermitFrom = dbr("STATE_PERMIT_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATE_PERMIT_TO").ToString <> "" Then
                                temp.StatePermitTo = dbr("STATE_PERMIT_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK_NOTE").ToString <> "" Then
                                temp.RemarkNote = dbr("REMARK_NOTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROAD_TAX_VALIDITY").ToString <> "" Then
                                temp.RoadTaxValidity = dbr("ROAD_TAX_VALIDITY")
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
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                temp.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_NO").ToString <> "" Then
                                temp.EquipmentNo = dbr("EQUIPMENT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE").ToString <> "" Then
                                temp.EquipmentType = dbr("EQUIPMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHAGE_DATE").ToString <> "" Then
                                temp.PurchageDate = dbr("PURCHAGE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSURANCE_NO").ToString <> "" Then
                                temp.InsuranceNo = dbr("INSURANCE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ENG_NO").ToString <> "" Then
                                temp.EngNo = dbr("ENG_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ENG_TYPE").ToString <> "" Then
                                temp.EngType = dbr("ENG_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VIN_NO").ToString <> "" Then
                                temp.VinNo = dbr("VIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURING_YEAR").ToString <> "" Then
                                temp.ManufacturingYear = dbr("MANUFACTURING_YEAR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODEL").ToString <> "" Then
                                temp.Model = dbr("MODEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONDITION").ToString <> "" Then
                                temp.Condition = dbr("CONDITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                temp.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROSS_WT").ToString <> "" Then
                                temp.GrossWt = dbr("GROSS_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                temp.Status = dbr("STATUS")
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
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_CHANGEABLE").ToString <> "" Then
                                temp.BedChangeable = dbr("BED_CHANGEABLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMAGE").ToString <> "" Then
                                temp.Image = dbr("IMAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REGISTRATION_DATE").ToString <> "" Then
                                temp.RegistrationDate = dbr("REGISTRATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MANUFACTURER").ToString <> "" Then
                                temp.Manufacturer = dbr("MANUFACTURER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_NO").ToString <> "" Then
                                temp.BedNo = dbr("BED_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INS_VENDOR").ToString <> "" Then
                                temp.InsVendor = dbr("INS_VENDOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INS_VALIDITY").ToString <> "" Then
                                temp.InsValidity = dbr("INS_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_FROM").ToString <> "" Then
                                temp.PermitFrom = dbr("PERMIT_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_TO").ToString <> "" Then
                                temp.PermitTo = dbr("PERMIT_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POLLUTION_VALIDITY").ToString <> "" Then
                                temp.PollutionValidity = dbr("POLLUTION_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RTO").ToString <> "" Then
                                temp.Rto = dbr("RTO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FITNESS_DOC").ToString <> "" Then
                                temp.FitnessDoc = dbr("FITNESS_DOC")
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
                            If dbr("RC_DOC").ToString <> "" Then
                                temp.RcDoc = dbr("RC_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSURANCE_DOC").ToString <> "" Then
                                temp.InsuranceDoc = dbr("INSURANCE_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_A").ToString <> "" Then
                                temp.PermitA = dbr("PERMIT_A")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMIT_B").ToString <> "" Then
                                temp.PermitB = dbr("PERMIT_B")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HP_BY").ToString <> "" Then
                                temp.HpBy = dbr("HP_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("XL_TYPE").ToString <> "" Then
                                temp.XlType = dbr("XL_TYPE")
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
                            If dbr("DRIVER_ATTACH_ID").ToString <> "" Then
                                temp.DriverAttachId = dbr("DRIVER_ATTACH_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ATTCAH_STATUS").ToString <> "" Then
                                temp.DriverAttcahStatus = dbr("DRIVER_ATTCAH_STATUS")
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
        Public Shared Function ReturnFleetEquipmentMaster(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_EQUIPMENT_BY_ID", pFleetEquipmentMaster.TerminalId & "," & pFleetEquipmentMaster.EquipmentId & ",'" & pFleetEquipmentMaster.EquipmentNo & "'")
                pFleetEquipmentMaster = ReturnObjectValues(dbr, pFleetEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                pFleetEquipmentMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetEquipmentMasterList(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetEquipmentMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_EQUIPMENT_MASTER_ALL", pFleetEquipmentMaster.TerminalId & "," & pFleetEquipmentMaster.CompanyId)
                arrFleetEquipmentMaster = ReturnObjectValuesList(dbr, arrFleetEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetEquipmentMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetEquipmentMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetEquipmentMasterListPending(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetEquipmentMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_MASTER_PENDING", pFleetEquipmentMaster.TerminalId)
                arrFleetEquipmentMaster = ReturnObjectValuesList(dbr, arrFleetEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetEquipmentMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetEquipmentMaster
        End Function
        Public Shared Function ReturnFleetEquipmentMasterListByDriverId(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetEquipmentMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_MASTER_DRIVER", pFleetEquipmentMaster.TerminalId)
                arrFleetEquipmentMaster = ReturnObjectValuesList(dbr, arrFleetEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetEquipmentMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetEquipmentMaster
        End Function
        Public Shared Function InsertUpdate(ByVal pFleetEquipmentMaster As FleetEquipmentMaster) As FleetEquipmentMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pFleetEquipmentMaster.EquipmentId > 0 Then
                    FleetEquipmentMaster.UpdateTrn(db, pFleetEquipmentMaster)
                    If pFleetEquipmentMaster.Errormsg <> "" Then
                        Throw New Exception(pFleetEquipmentMaster.Errormsg)
                    End If
                Else
                    FleetEquipmentMaster.InsertTrn(db, pFleetEquipmentMaster)
                    If pFleetEquipmentMaster.Errormsg <> "" Then
                        Throw New Exception(pFleetEquipmentMaster.Errormsg)
                    End If
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pFleetEquipmentMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pFleetEquipmentMaster
        End Function
    End Class
End Namespace
