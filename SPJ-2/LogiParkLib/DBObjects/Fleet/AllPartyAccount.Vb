Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: AllPartyAccount
    ''' @author	: Amit K. Singh- 8/8/2017
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class AllPartyAccount

        Private lngTrackId As Long ' Define Private Variable TrackId With DataType As Long 
        Private lngTelexStatus As Long ' Define Private Variable TelexStatus With DataType As Long 
        Private lngBLStatusId As Long ' Define Private Variable BLStatusId With DataType As Long
        Private strShipperName As String ' Define Private Variable ShipperName With DataType As String 
        Private strConsingeeName As String ' Define Private Variable ConsingeeName With DataType As String 
        Private strNotifyParty As String ' Define Private Variable NotifyParty With DataType As String 
        Private strLot As String ' Define Private Variable Lot With DataType As String 
        Private strHealthCertificateNo As String ' Define Private Variable HealthCertificateNo With DataType As String 
        Private strHealthCertificateDate As String ' Define Private Variable HealthCertificateDate With DataType As String 
        Private strSelfExcise As String ' Define Private Variable SelfExcise With DataType As String 
        Private strPartyInvNo As String ' Define Private Variable PartyInvNo With DataType As String 
        Private strPartyInvDate As String ' Define Private Variable PartyInvDate With DataType As String 
        Private strSbNo As String ' Define Private Variable SbNo With DataType As String 
        Private strSbDate As String ' Define Private Variable SbDate With DataType As String 
        Private strCustomsHandoverDate As String ' Define Private Variable CustomsHandoverDate With DataType As String 
        Private strLineHandoverDate As String ' Define Private Variable LineHandoverDate With DataType As String 
        Private strSbReceived As String ' Define Private Variable SbReceived With DataType As String 
        Private lngCartons As Long ' Define Private Variable Cartons With DataType As Long 
        Private lngNetWt As Double ' Define Private Variable NetWt With DataType As Long 
        Private lngGrossWt As Double ' Define Private Variable GrossWt With DataType As Long 
        Private lngTareWt As Double ' Define Private Variable TareWt With DataType As Long 
        Private lngVgmWt As Double ' Define Private Variable VgmWt With DataType As Long 
        Private strVgmSubmitted As String ' Define Private Variable VgmSubmitted With DataType As String 
        Private strShipmentType As String ' Define Private Variable ShipmentType With DataType As String 
        Private lngFobValueInr As Long ' Define Private Variable FobValueInr With DataType As Long 
        Private lngExRate As Double ' Define Private Variable ExRate With DataType As Long 
        Private lngFobValueUsd As Long ' Define Private Variable FobValueUsd With DataType As Long 
        Private lngCnfUsd As Long ' Define Private Variable CnfUsd With DataType As Long 
        Private lngUnits As Long ' Define Private Variable Units With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strIcdGateOut As String ' Define Private Variable IcdGateOut With DataType As String 
        Private strIcdGateIn As String ' Define Private Variable IcdGateIn With DataType As String 
        Private strPort As String ' Define Private Variable Port With DataType As String 
        Private strCountry As String ' Define Private Variable Country With DataType As String 
        Private strRegion As String ' Define Private Variable Region With DataType As String 
        Private strLine As String ' Define Private Variable Line With DataType As String 
        Private strCha As String ' Define Private Variable Cha With DataType As String 
        Private strPdaAccount As String ' Define Private Variable PdaAccount With DataType As String 
        Private strBookingNo As String ' Define Private Variable BookingNo With DataType As String 
        Private strBookingDate As String ' Define Private Variable BookingNo With DataType As String 
        Private strBlNo As String ' Define Private Variable BlNo With DataType As String 
        Private strFollowUp As String ' Define Private Variable FollowUp With DataType As String 
        Private strBlRemarks As String ' Define Private Variable BlRemarks With DataType As String 
        Private strSob As String ' Define Private Variable Sob With DataType As String 
        Private strSailed As String ' Define Private Variable Sailed With DataType As String 
        Private strBlStatus As String ' Define Private Variable BlStatus With DataType As String 
        Private strLineInvoice As String ' Define Private Variable LineInvoice With DataType As String 
        Private strRequiredGst As String ' Define Private Variable RequiredGst With DataType As String 
        Private strSpecialComments As String ' Define Private Variable SpecialComments With DataType As String 
        Private strLinerInvNo As String ' Define Private Variable LinerInvNo With DataType As String 
        Private strLinerInvDate As String ' Define Private Variable LinerInvDate With DataType As String 
        Private strLinerDueDate As String ' Define Private Variable LinerDueDate With DataType As String 
        Private lngAgeing As Long ' Define Private Variable Ageing With DataType As Long 
        Private lngBaseFrtUsd As Long ' Define Private Variable BaseFrtUsd With DataType As Long 
        Private lngOtherChargesUsd As Long ' Define Private Variable OtherChargesUsd With DataType As Long 
        Private lngTotalFrtUsd As Long ' Define Private Variable TotalFrtUsd With DataType As Long 
        Private lngFrtExRate As Long ' Define Private Variable FrtExRate With DataType As Long 
        Private lngFrtGst As Long ' Define Private Variable FrtGst With DataType As Long 
        Private lngAmountInr As Long ' Define Private Variable AmountInr With DataType As Long 
        Private lngLineThc As Long ' Define Private Variable LineThc With DataType As Long 
        Private lngPortThc As Long ' Define Private Variable PortThc With DataType As Long 
        Private lngOriginThc As Long ' Define Private Variable OriginThc With DataType As Long 
        Private lngRailfreight As Long ' Define Private Variable Railfreight With DataType As Long 
        Private lngDocCharges As Long ' Define Private Variable DocCharges With DataType As Long 
        Private lngMiscCharges As Long ' Define Private Variable MiscCharges With DataType As Long 
        Private lngIgst As Long ' Define Private Variable Igst With DataType As Long 
        Private lngCgst As Long ' Define Private Variable Cgst With DataType As Long 
        Private lngSgst As Long ' Define Private Variable Sgst With DataType As Long 
        Private strLineChequeNo As String ' Define Private Variable LineChequeNo With DataType As String 
        Private strLineChequeDate As String ' Define Private Variable LineChequeDate With DataType As String 
        Private lngLineChequeAmount As Long ' Define Private Variable LineChequeAmount With DataType As Long 
        Private strPaymentRemarks As String ' Define Private Variable PaymentRemarks With DataType As String 
        Private strOblStatus As String ' Define Private Variable OblStatus With DataType As String 
        Private strOblIssueDate As String ' Define Private Variable OblIssueDate With DataType As String 
        Private strTrainNo As String ' Define Private Variable TrainNo With DataType As String 
        Private strTrainOutDate As String ' Define Private Variable TrainOutDate With DataType As String 
        Private strPortArrival As String ' Define Private Variable PortArrival With DataType As String 
        Private lngNoOfDays As Long ' Define Private Variable NoOfDays With DataType As Long 
        Private strOblIssueNo As String ' Define Private Variable OblIssueNo With DataType As String 
        Private strRequiredEtd As String ' Define Private Variable RequiredEtd With DataType As String 
        Private strRequiredVessel As String ' Define Private Variable RequiredVessel With DataType As String 
        Private strCurrentEtd As String ' Define Private Variable CurrentEtd With DataType As String 
        Private strCurrentVessel As String ' Define Private Variable CurrentVessel With DataType As String 
        Private strSailedSob As String ' Define Private Variable SailedSob With DataType As String 
        Private strCurrentEta As String ' Define Private Variable CurrentEta With DataType As String 
        Private lngTransitTime As Long ' Define Private Variable TransitTime With DataType As Long 
        Private lngShipmentStatus As Long ' Define Private Variable ShipmentStatus With DataType As Long 
        Private ingDetMethod As Long ' Define Private Variable DetMethod With DataType As Long 
        Private strSurrenderInvNo As String ' Define Private Variable SurrenderInvNo With DataType As String 
        Private lngSurrenderInvAmount As Long ' Define Private Variable SurrenderInvAmount With DataType As Long 
        Private strSurrenderInvPayment As String ' Define Private Variable SurrenderInvPayment With DataType As String 
        Private strSurrenderInvStatus As String ' Define Private Variable SurrenderInvStatus With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
        Private strJsbBilling As String ' Define Private Variable JsbBilling With DataType As String 
        Private strCFS As String ' Define Private Variable CFS With DataType As String 
        Private strPOL As String ' Define Private Variable POL With DataType As String 
        Private lngPOLId As Long ' Define Private Variable POLId With DataType As Long
        Private lngPODId As Long ' Define Private Variable lngPODId With DataType As Long
        Private lngCFSId As Long ' Define Private Variable CFSId With DataType As Long
        Private strFactoryLocation As String ' Define Private Variable FactoryLocation With DataType As String 
        Private strConsignmentType As String ' Define Private Variable ConsignmentType With DataType As String 
        Private strJobNo As String ' Define Private Variable ConsignmentType With DataType As String
        Private strJobDate As String ' Define Private Variable Job Date With DataType As String
        Private lngConsignmentTypeId As Long ' Define Private Variable ConsignmentTypeId With DataType As Long
        Private strPackageType As String ' Define Private Variable PackageType With DataType As String 
        Private lngPackageTypeId As Long ' Define Private Variable PackageTypeId  With DataType As Long
        Private strDischargeDate As String ' Define Private Variable strDischargeDate With DataType As String 
        Private strGateoutDate As String ' Define Private Variable strGateoutDate With DataType As String 
        Private strEmptyGateInDate As String ' Define Private Variable strEmptyGateinDate With DataType As String 
        Private strBLMethod As String ' Define Private Variable POL With DataType As String 
        Private lngBLMethodId As Long ' Define Private Variable POLId With DataType As Long
        Private strVoyage As String ' Define Private Variable POL With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngHoldRemarkId As Long
        Private strRefId As String ' Define Private Variable RefId With DataType As String 


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

        Public Property HoldRemarkId() As Long
            Get
                Return lngHoldRemarkId
            End Get
            Set(ByVal value As Long)
                lngHoldRemarkId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TelexStatus
        ''' </summary>
        ''' <value>lngTelexStatus</value>
        ''' <returns> Return lngTelexStatus</returns>
        ''' <remarks> Get or Set the Value of TelexStatus  </remarks>
        '''
        Public Property TelexStatus() As Long
            Get
                Return lngTelexStatus
            End Get
            Set(ByVal value As Long)
                lngTelexStatus = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CFSId
        ''' </summary>
        ''' <value>lngCFSId</value>
        ''' <returns> Return lngCFSId</returns>
        ''' <remarks> Get or Set the Value of CFSId  </remarks>
        '''
        Public Property CFSId() As Long
            Get
                Return lngCFSId
            End Get
            Set(ByVal value As Long)
                lngCFSId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BLStatusId
        ''' </summary>
        ''' <value>lngBLStatusId</value>
        ''' <returns> Return lngBLStatusId</returns>
        ''' <remarks> Get or Set the Value of BLStatusId  </remarks>
        '''
        Public Property BLStatusId() As Long
            Get
                Return lngBLStatusId
            End Get
            Set(ByVal value As Long)
                lngBLStatusId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of POLId
        ''' </summary>
        ''' <value>lngPOLId</value>
        ''' <returns> Return lngPOLId</returns>
        ''' <remarks> Get or Set the Value of POLId  </remarks>
        '''
        Public Property POLId() As Long
            Get
                Return lngPOLId
            End Get
            Set(ByVal value As Long)
                lngPOLId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of PODId
        ''' </summary>
        ''' <value>lngPODId</value>
        ''' <returns> Return lngPODId</returns>
        ''' <remarks> Get or Set the Value of PODId  </remarks>
        '''
        Public Property PODId() As Long
            Get
                Return lngPODId
            End Get
            Set(ByVal value As Long)
                lngPODId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TrackId
        ''' </summary>
        ''' <value>lngTrackId</value>
        ''' <returns> Return lngTrackId</returns>
        ''' <remarks> Get or Set the Value of TrackId  </remarks>
        '''
        Public Property TrackId() As Long
            Get
                Return lngTrackId
            End Get
            Set(ByVal value As Long)
                lngTrackId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of JsbBilling
        ''' </summary>
        ''' <value>strJsbBilling</value>
        ''' <returns> Return strJsbBilling</returns>
        ''' <remarks> Get or Set the Value of JsbBilling  </remarks>
        '''
        Public Property JsbBilling() As String
            Get
                Return strJsbBilling
            End Get
            Set(ByVal value As String)
                strJsbBilling = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryLocation
        ''' </summary>
        ''' <value>strFactoryLocation</value>
        ''' <returns> Return strFactoryLocation</returns>
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

        ''' <summary>
        ''' Get or Set the Value of JsbBilling
        ''' </summary>
        ''' <value>strJsbBilling</value>
        ''' <returns> Return strJsbBilling</returns>
        ''' <remarks> Get or Set the Value of JsbBilling  </remarks>
        '''
        Public Property CFS() As String
            Get
                Return strCFS
            End Get
            Set(ByVal value As String)
                strCFS = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ShipperName
        ''' </summary>
        ''' <value>strShipperName</value>
        ''' <returns> Return strShipperName</returns>
        ''' <remarks> Get or Set the Value of ShipperName  </remarks>
        '''
        Public Property ShipperName() As String
            Get
                Return strShipperName
            End Get
            Set(ByVal value As String)
                strShipperName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ConsingeeName
        ''' </summary>
        ''' <value>strConsingeeName</value>
        ''' <returns> Return strConsingeeName</returns>
        ''' <remarks> Get or Set the Value of ConsingeeName  </remarks>
        '''
        Public Property ConsingeeName() As String
            Get
                Return strConsingeeName
            End Get
            Set(ByVal value As String)
                strConsingeeName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NotifyParty
        ''' </summary>
        ''' <value>strNotifyParty</value>
        ''' <returns> Return strNotifyParty</returns>
        ''' <remarks> Get or Set the Value of NotifyParty  </remarks>
        '''
        Public Property NotifyParty() As String
            Get
                Return strNotifyParty
            End Get
            Set(ByVal value As String)
                strNotifyParty = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Lot
        ''' </summary>
        ''' <value>strLot</value>
        ''' <returns> Return strLot</returns>
        ''' <remarks> Get or Set the Value of Lot  </remarks>
        '''
        Public Property Lot() As String
            Get
                Return strLot
            End Get
            Set(ByVal value As String)
                strLot = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of HealthCertificateNo
        ''' </summary>
        ''' <value>strHealthCertificateNo</value>
        ''' <returns> Return strHealthCertificateNo</returns>
        ''' <remarks> Get or Set the Value of HealthCertificateNo  </remarks>
        '''
        Public Property HealthCertificateNo() As String
            Get
                Return strHealthCertificateNo
            End Get
            Set(ByVal value As String)
                strHealthCertificateNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of HealthCertificateDate
        ''' </summary>
        ''' <value>strHealthCertificateDate</value>
        ''' <returns> Return strHealthCertificateDate</returns>
        ''' <remarks> Get or Set the Value of HealthCertificateDate  </remarks>
        '''
        Public Property HealthCertificateDate() As String
            Get
                Return strHealthCertificateDate
            End Get
            Set(ByVal value As String)
                strHealthCertificateDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SelfExcise
        ''' </summary>
        ''' <value>strSelfExcise</value>
        ''' <returns> Return strSelfExcise</returns>
        ''' <remarks> Get or Set the Value of SelfExcise  </remarks>
        '''
        Public Property SelfExcise() As String
            Get
                Return strSelfExcise
            End Get
            Set(ByVal value As String)
                strSelfExcise = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PartyInvNo
        ''' </summary>
        ''' <value>strPartyInvNo</value>
        ''' <returns> Return strPartyInvNo</returns>
        ''' <remarks> Get or Set the Value of PartyInvNo  </remarks>
        '''
        Public Property PartyInvNo() As String
            Get
                Return strPartyInvNo
            End Get
            Set(ByVal value As String)
                strPartyInvNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PartyInvDate
        ''' </summary>
        ''' <value>strPartyInvDate</value>
        ''' <returns> Return strPartyInvDate</returns>
        ''' <remarks> Get or Set the Value of PartyInvDate  </remarks>
        '''
        Public Property PartyInvDate() As String
            Get
                Return strPartyInvDate
            End Get
            Set(ByVal value As String)
                strPartyInvDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SbNo
        ''' </summary>
        ''' <value>strSbNo</value>
        ''' <returns> Return strSbNo</returns>
        ''' <remarks> Get or Set the Value of SbNo  </remarks>
        '''
        Public Property SbNo() As String
            Get
                Return strSbNo
            End Get
            Set(ByVal value As String)
                strSbNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SbDate
        ''' </summary>
        ''' <value>strSbDate</value>
        ''' <returns> Return strSbDate</returns>
        ''' <remarks> Get or Set the Value of SbDate  </remarks>
        '''
        Public Property SbDate() As String
            Get
                Return strSbDate
            End Get
            Set(ByVal value As String)
                strSbDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomsHandoverDate
        ''' </summary>
        ''' <value>strCustomsHandoverDate</value>
        ''' <returns> Return strCustomsHandoverDate</returns>
        ''' <remarks> Get or Set the Value of CustomsHandoverDate  </remarks>
        '''
        Public Property CustomsHandoverDate() As String
            Get
                Return strCustomsHandoverDate
            End Get
            Set(ByVal value As String)
                strCustomsHandoverDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineHandoverDate
        ''' </summary>
        ''' <value>strLineHandoverDate</value>
        ''' <returns> Return strLineHandoverDate</returns>
        ''' <remarks> Get or Set the Value of LineHandoverDate  </remarks>
        '''
        Public Property LineHandoverDate() As String
            Get
                Return strLineHandoverDate
            End Get
            Set(ByVal value As String)
                strLineHandoverDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SbReceived
        ''' </summary>
        ''' <value>strSbReceived</value>
        ''' <returns> Return strSbReceived</returns>
        ''' <remarks> Get or Set the Value of SbReceived  </remarks>
        '''
        Public Property SbReceived() As String
            Get
                Return strSbReceived
            End Get
            Set(ByVal value As String)
                strSbReceived = value
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


        ''' <summary>
        ''' Get or Set the Value of NetWt
        ''' </summary>
        ''' <value>lngNetWt</value>
        ''' <returns> Return lngNetWt</returns>
        ''' <remarks> Get or Set the Value of NetWt  </remarks>
        '''
        Public Property NetWt() As Double
            Get
                Return lngNetWt
            End Get
            Set(ByVal value As Double)
                lngNetWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GrossWt
        ''' </summary>
        ''' <value>lngGrossWt</value>
        ''' <returns> Return lngGrossWt</returns>
        ''' <remarks> Get or Set the Value of GrossWt  </remarks>
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
        ''' Get or Set the Value of VgmWt
        ''' </summary>
        ''' <value>lngVgmWt</value>
        ''' <returns> Return lngVgmWt</returns>
        ''' <remarks> Get or Set the Value of VgmWt  </remarks>
        '''
        Public Property VgmWt() As Double
            Get
                Return lngVgmWt
            End Get
            Set(ByVal value As Double)
                lngVgmWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VgmSubmitted
        ''' </summary>
        ''' <value>strVgmSubmitted</value>
        ''' <returns> Return strVgmSubmitted</returns>
        ''' <remarks> Get or Set the Value of VgmSubmitted  </remarks>
        '''
        Public Property VgmSubmitted() As String
            Get
                Return strVgmSubmitted
            End Get
            Set(ByVal value As String)
                strVgmSubmitted = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ShipmentType
        ''' </summary>
        ''' <value>strShipmentType</value>
        ''' <returns> Return strShipmentType</returns>
        ''' <remarks> Get or Set the Value of ShipmentType  </remarks>
        '''
        Public Property ShipmentType() As String
            Get
                Return strShipmentType
            End Get
            Set(ByVal value As String)
                strShipmentType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FobValueInr
        ''' </summary>
        ''' <value>lngFobValueInr</value>
        ''' <returns> Return lngFobValueInr</returns>
        ''' <remarks> Get or Set the Value of FobValueInr  </remarks>
        '''
        Public Property FobValueInr() As Long
            Get
                Return lngFobValueInr
            End Get
            Set(ByVal value As Long)
                lngFobValueInr = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ExRate
        ''' </summary>
        ''' <value>lngExRate</value>
        ''' <returns> Return lngExRate</returns>
        ''' <remarks> Get or Set the Value of ExRate  </remarks>
        '''
        Public Property ExRate() As Double
            Get
                Return lngExRate
            End Get
            Set(ByVal value As Double)
                lngExRate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FobValueUsd
        ''' </summary>
        ''' <value>lngFobValueUsd</value>
        ''' <returns> Return lngFobValueUsd</returns>
        ''' <remarks> Get or Set the Value of FobValueUsd  </remarks>
        '''
        Public Property FobValueUsd() As Long
            Get
                Return lngFobValueUsd
            End Get
            Set(ByVal value As Long)
                lngFobValueUsd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CnfUsd
        ''' </summary>
        ''' <value>lngCnfUsd</value>
        ''' <returns> Return lngCnfUsd</returns>
        ''' <remarks> Get or Set the Value of CnfUsd  </remarks>
        '''
        Public Property CnfUsd() As Long
            Get
                Return lngCnfUsd
            End Get
            Set(ByVal value As Long)
                lngCnfUsd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Units
        ''' </summary>
        ''' <value>lngUnits</value>
        ''' <returns> Return lngUnits</returns>
        ''' <remarks> Get or Set the Value of Units  </remarks>
        '''
        Public Property Units() As Long
            Get
                Return lngUnits
            End Get
            Set(ByVal value As Long)
                lngUnits = value
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


        ''' <summary>
        ''' Get or Set the Value of IcdGateOut
        ''' </summary>
        ''' <value>strIcdGateOut</value>
        ''' <returns> Return strIcdGateOut</returns>
        ''' <remarks> Get or Set the Value of IcdGateOut  </remarks>
        '''
        Public Property IcdGateOut() As String
            Get
                Return strIcdGateOut
            End Get
            Set(ByVal value As String)
                strIcdGateOut = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of IcdGateIn
        ''' </summary>
        ''' <value>strIcdGateIn</value>
        ''' <returns> Return strIcdGateIn</returns>
        ''' <remarks> Get or Set the Value of IcdGateIn  </remarks>
        '''
        Public Property IcdGateIn() As String
            Get
                Return strIcdGateIn
            End Get
            Set(ByVal value As String)
                strIcdGateIn = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Port
        ''' </summary>
        ''' <value>strPort</value>
        ''' <returns> Return strPort</returns>
        ''' <remarks> Get or Set the Value of Port  </remarks>
        '''
        Public Property Port() As String
            Get
                Return strPort
            End Get
            Set(ByVal value As String)
                strPort = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Country
        ''' </summary>
        ''' <value>strCountry</value>
        ''' <returns> Return strCountry</returns>
        ''' <remarks> Get or Set the Value of Country  </remarks>
        '''
        Public Property Country() As String
            Get
                Return strCountry
            End Get
            Set(ByVal value As String)
                strCountry = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Region
        ''' </summary>
        ''' <value>strRegion</value>
        ''' <returns> Return strRegion</returns>
        ''' <remarks> Get or Set the Value of Region  </remarks>
        '''
        Public Property Region() As String
            Get
                Return strRegion
            End Get
            Set(ByVal value As String)
                strRegion = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Line
        ''' </summary>
        ''' <value>strLine</value>
        ''' <returns> Return strLine</returns>
        ''' <remarks> Get or Set the Value of Line  </remarks>
        '''
        Public Property Line() As String
            Get
                Return strLine
            End Get
            Set(ByVal value As String)
                strLine = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cha
        ''' </summary>
        ''' <value>strCha</value>
        ''' <returns> Return strCha</returns>
        ''' <remarks> Get or Set the Value of Cha  </remarks>
        '''
        Public Property Cha() As String
            Get
                Return strCha
            End Get
            Set(ByVal value As String)
                strCha = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PdaAccount
        ''' </summary>
        ''' <value>strPdaAccount</value>
        ''' <returns> Return strPdaAccount</returns>
        ''' <remarks> Get or Set the Value of PdaAccount  </remarks>
        '''
        Public Property PdaAccount() As String
            Get
                Return strPdaAccount
            End Get
            Set(ByVal value As String)
                strPdaAccount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BookingNo
        ''' </summary>
        ''' <value>strBookingNo</value>
        ''' <returns> Return strBookingNo</returns>
        ''' <remarks> Get or Set the Value of BookingNo  </remarks>
        '''
        Public Property BookingNo() As String
            Get
                Return strBookingNo
            End Get
            Set(ByVal value As String)
                strBookingNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BookingNo
        ''' </summary>
        ''' <value>strBookingNo</value>
        ''' <returns> Return strBookingNo</returns>
        ''' <remarks> Get or Set the Value of BookingNo  </remarks>
        '''
        Public Property BookingDate() As String
            Get
                Return strBookingDate
            End Get
            Set(ByVal value As String)
                strBookingDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BlNo
        ''' </summary>
        ''' <value>strBlNo</value>
        ''' <returns> Return strBlNo</returns>
        ''' <remarks> Get or Set the Value of BlNo  </remarks>
        '''
        Public Property BlNo() As String
            Get
                Return strBlNo
            End Get
            Set(ByVal value As String)
                strBlNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FollowUp
        ''' </summary>
        ''' <value>strFollowUp</value>
        ''' <returns> Return strFollowUp</returns>
        ''' <remarks> Get or Set the Value of FollowUp  </remarks>
        '''
        Public Property FollowUp() As String
            Get
                Return strFollowUp
            End Get
            Set(ByVal value As String)
                strFollowUp = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BlRemarks
        ''' </summary>
        ''' <value>strBlRemarks</value>
        ''' <returns> Return strBlRemarks</returns>
        ''' <remarks> Get or Set the Value of BlRemarks  </remarks>
        '''
        Public Property BlRemarks() As String
            Get
                Return strBlRemarks
            End Get
            Set(ByVal value As String)
                strBlRemarks = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Sob
        ''' </summary>
        ''' <value>strSob</value>
        ''' <returns> Return strSob</returns>
        ''' <remarks> Get or Set the Value of Sob  </remarks>
        '''
        Public Property Sob() As String
            Get
                Return strSob
            End Get
            Set(ByVal value As String)
                strSob = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Sailed
        ''' </summary>
        ''' <value>strSailed</value>
        ''' <returns> Return strSailed</returns>
        ''' <remarks> Get or Set the Value of Sailed  </remarks>
        '''
        Public Property Sailed() As String
            Get
                Return strSailed
            End Get
            Set(ByVal value As String)
                strSailed = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BlStatus
        ''' </summary>
        ''' <value>strBlStatus</value>
        ''' <returns> Return strBlStatus</returns>
        ''' <remarks> Get or Set the Value of BlStatus  </remarks>
        '''
        Public Property BlStatus() As String
            Get
                Return strBlStatus
            End Get
            Set(ByVal value As String)
                strBlStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineInvoice
        ''' </summary>
        ''' <value>strLineInvoice</value>
        ''' <returns> Return strLineInvoice</returns>
        ''' <remarks> Get or Set the Value of LineInvoice  </remarks>
        '''
        Public Property LineInvoice() As String
            Get
                Return strLineInvoice
            End Get
            Set(ByVal value As String)
                strLineInvoice = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RequiredGst
        ''' </summary>
        ''' <value>strRequiredGst</value>
        ''' <returns> Return strRequiredGst</returns>
        ''' <remarks> Get or Set the Value of RequiredGst  </remarks>
        '''
        Public Property RequiredGst() As String
            Get
                Return strRequiredGst
            End Get
            Set(ByVal value As String)
                strRequiredGst = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SpecialComments
        ''' </summary>
        ''' <value>strSpecialComments</value>
        ''' <returns> Return strSpecialComments</returns>
        ''' <remarks> Get or Set the Value of SpecialComments  </remarks>
        '''
        Public Property SpecialComments() As String
            Get
                Return strSpecialComments
            End Get
            Set(ByVal value As String)
                strSpecialComments = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LinerInvNo
        ''' </summary>
        ''' <value>strLinerInvNo</value>
        ''' <returns> Return strLinerInvNo</returns>
        ''' <remarks> Get or Set the Value of LinerInvNo  </remarks>
        '''
        Public Property LinerInvNo() As String
            Get
                Return strLinerInvNo
            End Get
            Set(ByVal value As String)
                strLinerInvNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LinerInvDate
        ''' </summary>
        ''' <value>strLinerInvDate</value>
        ''' <returns> Return strLinerInvDate</returns>
        ''' <remarks> Get or Set the Value of LinerInvDate  </remarks>
        '''
        Public Property LinerInvDate() As String
            Get
                Return strLinerInvDate
            End Get
            Set(ByVal value As String)
                strLinerInvDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LinerDueDate
        ''' </summary>
        ''' <value>strLinerDueDate</value>
        ''' <returns> Return strLinerDueDate</returns>
        ''' <remarks> Get or Set the Value of LinerDueDate  </remarks>
        '''
        Public Property LinerDueDate() As String
            Get
                Return strLinerDueDate
            End Get
            Set(ByVal value As String)
                strLinerDueDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Ageing
        ''' </summary>
        ''' <value>lngAgeing</value>
        ''' <returns> Return lngAgeing</returns>
        ''' <remarks> Get or Set the Value of Ageing  </remarks>
        '''
        Public Property Ageing() As Long
            Get
                Return lngAgeing
            End Get
            Set(ByVal value As Long)
                lngAgeing = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BaseFrtUsd
        ''' </summary>
        ''' <value>lngBaseFrtUsd</value>
        ''' <returns> Return lngBaseFrtUsd</returns>
        ''' <remarks> Get or Set the Value of BaseFrtUsd  </remarks>
        '''
        Public Property BaseFrtUsd() As Long
            Get
                Return lngBaseFrtUsd
            End Get
            Set(ByVal value As Long)
                lngBaseFrtUsd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OtherChargesUsd
        ''' </summary>
        ''' <value>lngOtherChargesUsd</value>
        ''' <returns> Return lngOtherChargesUsd</returns>
        ''' <remarks> Get or Set the Value of OtherChargesUsd  </remarks>
        '''
        Public Property OtherChargesUsd() As Long
            Get
                Return lngOtherChargesUsd
            End Get
            Set(ByVal value As Long)
                lngOtherChargesUsd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TotalFrtUsd
        ''' </summary>
        ''' <value>lngTotalFrtUsd</value>
        ''' <returns> Return lngTotalFrtUsd</returns>
        ''' <remarks> Get or Set the Value of TotalFrtUsd  </remarks>
        '''
        Public Property TotalFrtUsd() As Long
            Get
                Return lngTotalFrtUsd
            End Get
            Set(ByVal value As Long)
                lngTotalFrtUsd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FrtExRate
        ''' </summary>
        ''' <value>lngFrtExRate</value>
        ''' <returns> Return lngFrtExRate</returns>
        ''' <remarks> Get or Set the Value of FrtExRate  </remarks>
        '''
        Public Property FrtExRate() As Long
            Get
                Return lngFrtExRate
            End Get
            Set(ByVal value As Long)
                lngFrtExRate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of FrtGst
        ''' </summary>
        ''' <value>lngFrtGst</value>
        ''' <returns> Return lngFrtGst</returns>
        ''' <remarks> Get or Set the Value of FrtGst  </remarks>
        '''
        Public Property FrtGst() As Long
            Get
                Return lngFrtGst
            End Get
            Set(ByVal value As Long)
                lngFrtGst = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AmountInr
        ''' </summary>
        ''' <value>lngAmountInr</value>
        ''' <returns> Return lngAmountInr</returns>
        ''' <remarks> Get or Set the Value of AmountInr  </remarks>
        '''
        Public Property AmountInr() As Long
            Get
                Return lngAmountInr
            End Get
            Set(ByVal value As Long)
                lngAmountInr = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineThc
        ''' </summary>
        ''' <value>lngLineThc</value>
        ''' <returns> Return lngLineThc</returns>
        ''' <remarks> Get or Set the Value of LineThc  </remarks>
        '''
        Public Property LineThc() As Long
            Get
                Return lngLineThc
            End Get
            Set(ByVal value As Long)
                lngLineThc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PortThc
        ''' </summary>
        ''' <value>lngPortThc</value>
        ''' <returns> Return lngPortThc</returns>
        ''' <remarks> Get or Set the Value of PortThc  </remarks>
        '''
        Public Property PortThc() As Long
            Get
                Return lngPortThc
            End Get
            Set(ByVal value As Long)
                lngPortThc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OriginThc
        ''' </summary>
        ''' <value>lngOriginThc</value>
        ''' <returns> Return lngOriginThc</returns>
        ''' <remarks> Get or Set the Value of OriginThc  </remarks>
        '''
        Public Property OriginThc() As Long
            Get
                Return lngOriginThc
            End Get
            Set(ByVal value As Long)
                lngOriginThc = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Railfreight
        ''' </summary>
        ''' <value>lngRailfreight</value>
        ''' <returns> Return lngRailfreight</returns>
        ''' <remarks> Get or Set the Value of Railfreight  </remarks>
        '''
        Public Property Railfreight() As Long
            Get
                Return lngRailfreight
            End Get
            Set(ByVal value As Long)
                lngRailfreight = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DocCharges
        ''' </summary>
        ''' <value>lngDocCharges</value>
        ''' <returns> Return lngDocCharges</returns>
        ''' <remarks> Get or Set the Value of DocCharges  </remarks>
        '''
        Public Property DocCharges() As Long
            Get
                Return lngDocCharges
            End Get
            Set(ByVal value As Long)
                lngDocCharges = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MiscCharges
        ''' </summary>
        ''' <value>lngMiscCharges</value>
        ''' <returns> Return lngMiscCharges</returns>
        ''' <remarks> Get or Set the Value of MiscCharges  </remarks>
        '''
        Public Property MiscCharges() As Long
            Get
                Return lngMiscCharges
            End Get
            Set(ByVal value As Long)
                lngMiscCharges = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Igst
        ''' </summary>
        ''' <value>lngIgst</value>
        ''' <returns> Return lngIgst</returns>
        ''' <remarks> Get or Set the Value of Igst  </remarks>
        '''
        Public Property Igst() As Long
            Get
                Return lngIgst
            End Get
            Set(ByVal value As Long)
                lngIgst = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cgst
        ''' </summary>
        ''' <value>lngCgst</value>
        ''' <returns> Return lngCgst</returns>
        ''' <remarks> Get or Set the Value of Cgst  </remarks>
        '''
        Public Property Cgst() As Long
            Get
                Return lngCgst
            End Get
            Set(ByVal value As Long)
                lngCgst = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Sgst
        ''' </summary>
        ''' <value>lngSgst</value>
        ''' <returns> Return lngSgst</returns>
        ''' <remarks> Get or Set the Value of Sgst  </remarks>
        '''
        Public Property Sgst() As Long
            Get
                Return lngSgst
            End Get
            Set(ByVal value As Long)
                lngSgst = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineChequeNo
        ''' </summary>
        ''' <value>strLineChequeNo</value>
        ''' <returns> Return strLineChequeNo</returns>
        ''' <remarks> Get or Set the Value of LineChequeNo  </remarks>
        '''
        Public Property LineChequeNo() As String
            Get
                Return strLineChequeNo
            End Get
            Set(ByVal value As String)
                strLineChequeNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineChequeDate
        ''' </summary>
        ''' <value>strLineChequeDate</value>
        ''' <returns> Return strLineChequeDate</returns>
        ''' <remarks> Get or Set the Value of LineChequeDate  </remarks>
        '''
        Public Property LineChequeDate() As String
            Get
                Return strLineChequeDate
            End Get
            Set(ByVal value As String)
                strLineChequeDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineChequeAmount
        ''' </summary>
        ''' <value>lngLineChequeAmount</value>
        ''' <returns> Return lngLineChequeAmount</returns>
        ''' <remarks> Get or Set the Value of LineChequeAmount  </remarks>
        '''
        Public Property LineChequeAmount() As Long
            Get
                Return lngLineChequeAmount
            End Get
            Set(ByVal value As Long)
                lngLineChequeAmount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PaymentRemarks
        ''' </summary>
        ''' <value>strPaymentRemarks</value>
        ''' <returns> Return strPaymentRemarks</returns>
        ''' <remarks> Get or Set the Value of PaymentRemarks  </remarks>
        '''
        Public Property PaymentRemarks() As String
            Get
                Return strPaymentRemarks
            End Get
            Set(ByVal value As String)
                strPaymentRemarks = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OblStatus
        ''' </summary>
        ''' <value>strOblStatus</value>
        ''' <returns> Return strOblStatus</returns>
        ''' <remarks> Get or Set the Value of OblStatus  </remarks>
        '''
        Public Property OblStatus() As String
            Get
                Return strOblStatus
            End Get
            Set(ByVal value As String)
                strOblStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OblIssueDate
        ''' </summary>
        ''' <value>strOblIssueDate</value>
        ''' <returns> Return strOblIssueDate</returns>
        ''' <remarks> Get or Set the Value of OblIssueDate  </remarks>
        '''
        Public Property OblIssueDate() As String
            Get
                Return strOblIssueDate
            End Get
            Set(ByVal value As String)
                strOblIssueDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TrainNo
        ''' </summary>
        ''' <value>strTrainNo</value>
        ''' <returns> Return strTrainNo</returns>
        ''' <remarks> Get or Set the Value of TrainNo  </remarks>
        '''
        Public Property TrainNo() As String
            Get
                Return strTrainNo
            End Get
            Set(ByVal value As String)
                strTrainNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TrainOutDate
        ''' </summary>
        ''' <value>strTrainOutDate</value>
        ''' <returns> Return strTrainOutDate</returns>
        ''' <remarks> Get or Set the Value of TrainOutDate  </remarks>
        '''
        Public Property TrainOutDate() As String
            Get
                Return strTrainOutDate
            End Get
            Set(ByVal value As String)
                strTrainOutDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PortArrival
        ''' </summary>
        ''' <value>strPortArrival</value>
        ''' <returns> Return strPortArrival</returns>
        ''' <remarks> Get or Set the Value of PortArrival  </remarks>
        '''
        Public Property PortArrival() As String
            Get
                Return strPortArrival
            End Get
            Set(ByVal value As String)
                strPortArrival = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NoOfDays
        ''' </summary>
        ''' <value>lngNoOfDays</value>
        ''' <returns> Return lngNoOfDays</returns>
        ''' <remarks> Get or Set the Value of NoOfDays  </remarks>
        '''
        Public Property NoOfDays() As Long
            Get
                Return lngNoOfDays
            End Get
            Set(ByVal value As Long)
                lngNoOfDays = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OblIssueNo
        ''' </summary>
        ''' <value>strOblIssueNo</value>
        ''' <returns> Return strOblIssueNo</returns>
        ''' <remarks> Get or Set the Value of OblIssueNo  </remarks>
        '''
        Public Property OblIssueNo() As String
            Get
                Return strOblIssueNo
            End Get
            Set(ByVal value As String)
                strOblIssueNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RequiredEtd
        ''' </summary>
        ''' <value>strRequiredEtd</value>
        ''' <returns> Return strRequiredEtd</returns>
        ''' <remarks> Get or Set the Value of RequiredEtd  </remarks>
        '''
        Public Property RequiredEtd() As String
            Get
                Return strRequiredEtd
            End Get
            Set(ByVal value As String)
                strRequiredEtd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RequiredVessel
        ''' </summary>
        ''' <value>strRequiredVessel</value>
        ''' <returns> Return strRequiredVessel</returns>
        ''' <remarks> Get or Set the Value of RequiredVessel  </remarks>
        '''
        Public Property RequiredVessel() As String
            Get
                Return strRequiredVessel
            End Get
            Set(ByVal value As String)
                strRequiredVessel = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CurrentEtd
        ''' </summary>
        ''' <value>strCurrentEtd</value>
        ''' <returns> Return strCurrentEtd</returns>
        ''' <remarks> Get or Set the Value of CurrentEtd  </remarks>
        '''
        Public Property CurrentEtd() As String
            Get
                Return strCurrentEtd
            End Get
            Set(ByVal value As String)
                strCurrentEtd = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CurrentVessel
        ''' </summary>
        ''' <value>strCurrentVessel</value>
        ''' <returns> Return strCurrentVessel</returns>
        ''' <remarks> Get or Set the Value of CurrentVessel  </remarks>
        '''
        Public Property CurrentVessel() As String
            Get
                Return strCurrentVessel
            End Get
            Set(ByVal value As String)
                strCurrentVessel = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SailedSob
        ''' </summary>
        ''' <value>strSailedSob</value>
        ''' <returns> Return strSailedSob</returns>
        ''' <remarks> Get or Set the Value of SailedSob  </remarks>
        '''
        Public Property SailedSob() As String
            Get
                Return strSailedSob
            End Get
            Set(ByVal value As String)
                strSailedSob = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CurrentEta
        ''' </summary>
        ''' <value>strCurrentEta</value>
        ''' <returns> Return strCurrentEta</returns>
        ''' <remarks> Get or Set the Value of CurrentEta  </remarks>
        '''
        Public Property CurrentEta() As String
            Get
                Return strCurrentEta
            End Get
            Set(ByVal value As String)
                strCurrentEta = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TransitTime
        ''' </summary>
        ''' <value>lngTransitTime</value>
        ''' <returns> Return lngTransitTime</returns>
        ''' <remarks> Get or Set the Value of TransitTime  </remarks>
        '''
        Public Property TransitTime() As Long
            Get
                Return lngTransitTime
            End Get
            Set(ByVal value As Long)
                lngTransitTime = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ShipmentStatus
        ''' </summary>
        ''' <value>lngShipmentStatus</value>
        ''' <returns> Return lngShipmentStatus</returns>
        ''' <remarks> Get or Set the Value of ShipmentStatus  </remarks>
        '''
        Public Property ShipmentStatus() As Long
            Get
                Return lngShipmentStatus
            End Get
            Set(ByVal value As Long)
                lngShipmentStatus = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DetMethod
        ''' </summary>
        ''' <value>ingDetMethod</value>
        ''' <returns> Return lngShipmentStatus</returns>
        ''' <remarks> Get or Set the Value of DetMethod  </remarks>
        '''
        Public Property DetMethod() As Long
            Get
                Return ingDetMethod
            End Get
            Set(ByVal value As Long)
                ingDetMethod = value
            End Set
        End Property



        ''' <summary>
        ''' Get or Set the Value of SurrenderInvNo
        ''' </summary>
        ''' <value>strSurrenderInvNo</value>
        ''' <returns> Return strSurrenderInvNo</returns>
        ''' <remarks> Get or Set the Value of SurrenderInvNo  </remarks>
        '''
        Public Property SurrenderInvNo() As String
            Get
                Return strSurrenderInvNo
            End Get
            Set(ByVal value As String)
                strSurrenderInvNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SurrenderInvAmount
        ''' </summary>
        ''' <value>lngSurrenderInvAmount</value>
        ''' <returns> Return lngSurrenderInvAmount</returns>
        ''' <remarks> Get or Set the Value of SurrenderInvAmount  </remarks>
        '''
        Public Property SurrenderInvAmount() As Long
            Get
                Return lngSurrenderInvAmount
            End Get
            Set(ByVal value As Long)
                lngSurrenderInvAmount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SurrenderInvPayment
        ''' </summary>
        ''' <value>strSurrenderInvPayment</value>
        ''' <returns> Return strSurrenderInvPayment</returns>
        ''' <remarks> Get or Set the Value of SurrenderInvPayment  </remarks>
        '''
        Public Property SurrenderInvPayment() As String
            Get
                Return strSurrenderInvPayment
            End Get
            Set(ByVal value As String)
                strSurrenderInvPayment = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SurrenderInvStatus
        ''' </summary>
        ''' <value>strSurrenderInvStatus</value>
        ''' <returns> Return strSurrenderInvStatus</returns>
        ''' <remarks> Get or Set the Value of SurrenderInvStatus  </remarks>
        '''
        Public Property SurrenderInvStatus() As String
            Get
                Return strSurrenderInvStatus
            End Get
            Set(ByVal value As String)
                strSurrenderInvStatus = value
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
        ''' Get or Set the Value of POL
        ''' </summary>
        ''' <value>strPOL</value>
        ''' <returns> Return strPOL</returns>
        ''' <remarks> Get or Set the Value of POL  </remarks>
        '''
        Public Property POL() As String
            Get
                Return strPOL
            End Get
            Set(ByVal value As String)
                strPOL = value
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
        ''' Get or Set the Value of ConsignmentTypeId
        ''' </summary>
        ''' <value>ingConsignmentTypeId</value>
        ''' <returns> Return lngConsignmentTypeId</returns>
        ''' <remarks> Get or Set the Value of ConsignmentTypeId  </remarks>
        '''
        Public Property ConsignmentTypeId() As Long
            Get
                Return lngConsignmentTypeId
            End Get
            Set(ByVal value As Long)
                lngConsignmentTypeId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ConsignmentType
        ''' </summary>
        ''' <value>strConsignmentType</value>
        ''' <returns> Return strConsignmentType</returns>
        ''' <remarks> Get or Set the Value of ConsignmentType  </remarks>
        '''
        Public Property ConsignmentType() As String
            Get
                Return strConsignmentType
            End Get
            Set(ByVal value As String)
                strConsignmentType = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of JobNo
        ''' </summary>
        ''' <value>strJobNo</value>
        ''' <returns> Return strConsignmentType</returns>
        ''' <remarks> Get or Set the Value of JobNo  </remarks>
        '''
        Public Property JobNo() As String
            Get
                Return strJobNo
            End Get
            Set(ByVal value As String)
                strJobNo = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of JobDate
        ''' </summary>
        ''' <value>strJobDate</value>
        ''' <returns> Return JobDate</returns>
        ''' <remarks> Get or Set the Value of JobDate  </remarks>
        '''
        Public Property JobDate() As String
            Get
                Return strJobDate
            End Get
            Set(ByVal value As String)
                strJobDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of PackageType
        ''' </summary>
        ''' <value>strPackageType</value>
        ''' <returns> Return strPackageType</returns>
        ''' <remarks> Get or Set the Value of PackageType  </remarks>
        '''
        Public Property PackageType() As String
            Get
                Return strPackageType
            End Get
            Set(ByVal value As String)
                strPackageType = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of PackageTypeId
        ''' </summary>
        ''' <value>lngPackageTypeId</value>
        ''' <returns> Return lngPackageTypeId</returns>
        ''' <remarks> Get or Set the Value of PackageTypeId  </remarks>
        '''
        Public Property PackageTypeId() As Long
            Get
                Return lngPackageTypeId
            End Get
            Set(ByVal value As Long)
                lngPackageTypeId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of DischargeDate
        ''' </summary>
        ''' <value>strDischargeDate </value>
        ''' <returns> Return strDischargeDate </returns>
        ''' <remarks> Get or Set the Value of DischargeDate  </remarks>
        '''
        Public Property DischargeDate() As String
            Get
                Return strDischargeDate
            End Get
            Set(ByVal value As String)
                strDischargeDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of GateoutDate
        ''' </summary>
        ''' <value>strGateoutDate</value>
        ''' <returns> Return strGateoutDate</returns>
        ''' <remarks> Get or Set the Value of GateoutDate  </remarks>
        '''
        Public Property GateoutDate() As String
            Get
                Return strGateoutDate
            End Get
            Set(ByVal value As String)
                strGateoutDate = value
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
                Return strEmptyGateinDate
            End Get
            Set(ByVal value As String)
                strEmptyGateinDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of BLMethod
        ''' </summary>
        ''' <value>BLMethod</value>
        ''' <returns> Return BLMethod</returns>
        ''' <remarks> Get or Set the Value of BLMethod  </remarks>
        '''
        Public Property BLMethod() As String
            Get
                Return strBLMethod
            End Get
            Set(ByVal value As String)
                strBLMethod = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Voyage
        ''' </summary>
        ''' <value>Voyage</value>
        ''' <returns> Return Voyage</returns>
        ''' <remarks> Get or Set the Value of Voyage  </remarks>
        '''
        Public Property Voyage() As String
            Get
                Return strVoyage
            End Get
            Set(ByVal value As String)
                strVoyage = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of RefId
        ''' </summary>
        ''' <value>RefId</value>
        ''' <returns> Return RefId</returns>
        ''' <remarks> Get or Set the Value of RefId  </remarks>
        '''
        Public Property RefId() As String
            Get
                Return strRefId
            End Get
            Set(ByVal value As String)
                strRefId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of BLMethodId
        ''' </summary>
        ''' <value>lngBLMethodId</value>
        ''' <returns> Return lngBLMethodId</returns>
        ''' <remarks> Get or Set the Value of BLMethodId  </remarks>
        '''
        Public Property BLMethodId() As Long
            Get
                Return lngBLMethodId
            End Get
            Set(ByVal value As Long)
                lngBLMethodId = value
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
            lngTrackId = 0
            strShipperName = ""
            strConsingeeName = ""
            strNotifyParty = ""
            strLot = ""
            strHealthCertificateNo = ""
            strHealthCertificateDate = ""
            strSelfExcise = ""
            strPartyInvNo = ""
            strPartyInvDate = ""
            strSbNo = ""
            strSbDate = ""
            strCustomsHandoverDate = ""
            strLineHandoverDate = ""
            strSbReceived = ""
            lngCartons = 0
            lngNetWt = 0.0
            lngGrossWt = 0.0
            lngTareWt = 0.0
            lngVgmWt = 0.0
            strVgmSubmitted = ""
            strShipmentType = ""
            lngFobValueInr = 0
            lngExRate = 0.0
            lngFobValueUsd = 0
            lngCnfUsd = 0
            lngUnits = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            strIcdGateOut = ""
            strIcdGateIn = ""
            strPort = ""
            strCountry = ""
            strRegion = ""
            strLine = ""
            strCha = ""
            strPdaAccount = ""
            strBookingNo = ""
            strBookingDate = ""
            strBlNo = ""
            strFollowUp = ""
            strBlRemarks = ""
            strSob = ""
            strSailed = ""
            strBlStatus = ""
            strLineInvoice = ""
            strRequiredGst = ""
            strSpecialComments = ""
            strLinerInvNo = ""
            strLinerInvDate = ""
            strLinerDueDate = ""
            lngAgeing = 0
            lngBaseFrtUsd = 0
            lngOtherChargesUsd = 0
            lngTotalFrtUsd = 0
            lngFrtExRate = 0
            lngFrtGst = 0
            lngAmountInr = 0
            lngLineThc = 0
            lngPortThc = 0
            lngOriginThc = 0
            lngRailfreight = 0
            lngDocCharges = 0
            lngMiscCharges = 0
            lngIgst = 0
            lngCgst = 0
            lngSgst = 0
            strLineChequeNo = ""
            strLineChequeDate = ""
            lngLineChequeAmount = 0
            strPaymentRemarks = ""
            strOblStatus = ""
            strOblIssueDate = ""
            strTrainNo = ""
            strTrainOutDate = ""
            strPortArrival = ""
            lngNoOfDays = 0
            strOblIssueNo = ""
            strRequiredEtd = ""
            strRequiredVessel = ""
            strCurrentEtd = ""
            strCurrentVessel = ""
            strSailedSob = ""
            strCurrentEta = ""
            lngTransitTime = 0
            lngShipmentStatus = 0
            ingDetMethod = 0
            strSurrenderInvNo = ""
            lngSurrenderInvAmount = 0
            strSurrenderInvPayment = ""
            strSurrenderInvStatus = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngMtyContId = 0
            lngContJoId = 0
            strJsbBilling = ""
            strCFS = ""
            strErrormsg = ""
            strPOL = ""
            strFactoryLocation = ""
            lngBLStatusId = 0
            lngPOLId = 0
            lngPODId = 0
            lngCFSId = 0
            lngTelexStatus = 0
            strConsignmentType = ""
            strJobNo = ""
            strJobDate = ""
            lngConsignmentTypeId = 0
            strPackageType = ""
            lngPackageTypeId = 0
            lngHoldRemarkId = 0
            strDischargeDate = ""
            strGateoutDate = ""
            strEmptyGateInDate = ""
            ingDetMethod = 0
            strVoyage = ""
            strBLMethod = ""
            strRefId = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRACK_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_SHIPPER_NAME", pAllPartyAccount.ShipperName)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_NOTIFY_PARTY", pAllPartyAccount.NotifyParty)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SELF_EXCISE", pAllPartyAccount.SelfExcise)
                db.AddParameter("p_PARTY_INV_NO", pAllPartyAccount.PartyInvNo)
                db.AddParameter("p_PARTY_INV_DATE", pAllPartyAccount.PartyInvDate)
                db.AddParameter("p_SB_NO", pAllPartyAccount.SbNo)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_VGM_WT", pAllPartyAccount.VgmWt)
                db.AddParameter("p_VGM_SUBMITTED", pAllPartyAccount.VgmSubmitted)
                db.AddParameter("p_SHIPMENT_TYPE", pAllPartyAccount.ShipmentType)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONT_SIZE", pAllPartyAccount.ContSize)
                db.AddParameter("p_CONT_TYPE", pAllPartyAccount.ContType)
                db.AddParameter("p_ICD_GATE_OUT", pAllPartyAccount.IcdGateOut)
                db.AddParameter("p_ICD_GATE_IN", pAllPartyAccount.IcdGateIn)
                db.AddParameter("p_PORT", pAllPartyAccount.Port)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_BL_NO", pAllPartyAccount.BlNo)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter("p_BL_REMARKS", pAllPartyAccount.BlRemarks)
                db.AddParameter("p_SOB", pAllPartyAccount.Sob)
                db.AddParameter("p_SAILED", pAllPartyAccount.Sailed)
                db.AddParameter("p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_LINE_INVOICE", pAllPartyAccount.LineInvoice)
                db.AddParameter("p_REQUIRED_GST", pAllPartyAccount.RequiredGst)
                db.AddParameter("p_SPECIAL_COMMENTS", pAllPartyAccount.SpecialComments)
                db.AddParameter("p_LINER_INV_NO", pAllPartyAccount.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pAllPartyAccount.LinerInvDate)
                db.AddParameter("p_LINER_DUE_DATE", pAllPartyAccount.LinerDueDate)
                db.AddParameter("p_AGEING", pAllPartyAccount.Ageing)
                db.AddParameter("p_BASE_FRT_USD", pAllPartyAccount.BaseFrtUsd)
                db.AddParameter("p_OTHER_CHARGES_USD", pAllPartyAccount.OtherChargesUsd)
                db.AddParameter("p_TOTAL_FRT_USD", pAllPartyAccount.TotalFrtUsd)
                db.AddParameter("p_FRT_EX_RATE", pAllPartyAccount.FrtExRate)
                db.AddParameter("p_FRT_GST", pAllPartyAccount.FrtGst)
                db.AddParameter("p_AMOUNT_INR", pAllPartyAccount.AmountInr)
                db.AddParameter("p_LINE_THC", pAllPartyAccount.LineThc)
                db.AddParameter("p_PORT_THC", pAllPartyAccount.PortThc)
                db.AddParameter("p_ORIGIN_THC", pAllPartyAccount.OriginThc)
                db.AddParameter("p_RAILFREIGHT", pAllPartyAccount.Railfreight)
                db.AddParameter("p_DOC_CHARGES", pAllPartyAccount.DocCharges)
                db.AddParameter("p_MISC_CHARGES", pAllPartyAccount.MiscCharges)
                db.AddParameter("p_IGST", pAllPartyAccount.Igst)
                db.AddParameter("p_CGST", pAllPartyAccount.Cgst)
                db.AddParameter("p_SGST", pAllPartyAccount.Sgst)
                db.AddParameter("p_LINE_CHEQUE_NO", pAllPartyAccount.LineChequeNo)
                db.AddParameter("p_LINE_CHEQUE_DATE", pAllPartyAccount.LineChequeDate)
                db.AddParameter("p_LINE_CHEQUE_AMOUNT", pAllPartyAccount.LineChequeAmount)
                db.AddParameter("p_PAYMENT_REMARKS", pAllPartyAccount.PaymentRemarks)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_TRAIN_NO", pAllPartyAccount.TrainNo)
                db.AddParameter("p_TRAIN_OUT_DATE", pAllPartyAccount.TrainOutDate)
                db.AddParameter("p_PORT_ARRIVAL", pAllPartyAccount.PortArrival)
                db.AddParameter("p_NO_OF_DAYS", pAllPartyAccount.NoOfDays)
                db.AddParameter("p_OBL_ISSUE_NO", pAllPartyAccount.OblIssueNo)
                db.AddParameter("p_REQUIRED_ETD", pAllPartyAccount.RequiredEtd)
                db.AddParameter("p_REQUIRED_VESSEL", pAllPartyAccount.RequiredVessel)
                db.AddParameter("p_CURRENT_ETD", pAllPartyAccount.CurrentEtd)
                db.AddParameter("p_CURRENT_VESSEL", pAllPartyAccount.CurrentVessel)
                db.AddParameter("p_SAILED_SOB", pAllPartyAccount.SailedSob)
                db.AddParameter("p_CURRENT_ETA", pAllPartyAccount.CurrentEta)
                db.AddParameter("p_TRANSIT_TIME", pAllPartyAccount.TransitTime)
                db.AddParameter("p_DET_METHOD", pAllPartyAccount.DetMethod)
                db.AddParameter("p_SHIPMENT_STATUS", pAllPartyAccount.ShipmentStatus)
                db.AddParameter("DET_METHOD", pAllPartyAccount.DetMethod)
                db.AddParameter("p_SURRENDER_INV_NO", pAllPartyAccount.SurrenderInvNo)
                db.AddParameter("p_SURRENDER_INV_AMOUNT", pAllPartyAccount.SurrenderInvAmount)
                db.AddParameter("p_SURRENDER_INV_PAYMENT", pAllPartyAccount.SurrenderInvPayment)
                db.AddParameter("p_SURRENDER_INV_STATUS", pAllPartyAccount.SurrenderInvStatus)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pAllPartyAccount.MtyContId)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ALL_PARTY_ACCOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pAllPartyAccount.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Try
                db.ClearParameters()
                db.AddParameter("p_TRACK_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_SHIPPER_NAME", pAllPartyAccount.ShipperName)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_NOTIFY_PARTY", pAllPartyAccount.NotifyParty)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SELF_EXCISE", pAllPartyAccount.SelfExcise)
                db.AddParameter("p_PARTY_INV_NO", pAllPartyAccount.PartyInvNo)
                db.AddParameter("p_PARTY_INV_DATE", pAllPartyAccount.PartyInvDate)
                db.AddParameter("p_SB_NO", pAllPartyAccount.SbNo)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_VGM_WT", pAllPartyAccount.VgmWt)
                db.AddParameter("p_VGM_SUBMITTED", pAllPartyAccount.VgmSubmitted)
                db.AddParameter("p_SHIPMENT_TYPE", pAllPartyAccount.ShipmentType)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONT_SIZE", pAllPartyAccount.ContSize)
                db.AddParameter("p_CONT_TYPE", pAllPartyAccount.ContType)
                db.AddParameter("p_ICD_GATE_OUT", pAllPartyAccount.IcdGateOut)
                db.AddParameter("p_ICD_GATE_IN", pAllPartyAccount.IcdGateIn)
                db.AddParameter("p_PORT", pAllPartyAccount.Port)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_BL_NO", pAllPartyAccount.BlNo)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter("p_BL_REMARKS", pAllPartyAccount.BlRemarks)
                db.AddParameter("p_SOB", pAllPartyAccount.Sob)
                db.AddParameter("p_SAILED", pAllPartyAccount.Sailed)
                db.AddParameter("p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_LINE_INVOICE", pAllPartyAccount.LineInvoice)
                db.AddParameter("p_REQUIRED_GST", pAllPartyAccount.RequiredGst)
                db.AddParameter("p_SPECIAL_COMMENTS", pAllPartyAccount.SpecialComments)
                db.AddParameter("p_LINER_INV_NO", pAllPartyAccount.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pAllPartyAccount.LinerInvDate)
                db.AddParameter("p_LINER_DUE_DATE", pAllPartyAccount.LinerDueDate)
                db.AddParameter("p_AGEING", pAllPartyAccount.Ageing)
                db.AddParameter("p_BASE_FRT_USD", pAllPartyAccount.BaseFrtUsd)
                db.AddParameter("p_OTHER_CHARGES_USD", pAllPartyAccount.OtherChargesUsd)
                db.AddParameter("p_TOTAL_FRT_USD", pAllPartyAccount.TotalFrtUsd)
                db.AddParameter("p_FRT_EX_RATE", pAllPartyAccount.FrtExRate)
                db.AddParameter("p_FRT_GST", pAllPartyAccount.FrtGst)
                db.AddParameter("p_AMOUNT_INR", pAllPartyAccount.AmountInr)
                db.AddParameter("p_LINE_THC", pAllPartyAccount.LineThc)
                db.AddParameter("p_PORT_THC", pAllPartyAccount.PortThc)
                db.AddParameter("p_ORIGIN_THC", pAllPartyAccount.OriginThc)
                db.AddParameter("p_RAILFREIGHT", pAllPartyAccount.Railfreight)
                db.AddParameter("p_DOC_CHARGES", pAllPartyAccount.DocCharges)
                db.AddParameter("p_MISC_CHARGES", pAllPartyAccount.MiscCharges)
                db.AddParameter("p_IGST", pAllPartyAccount.Igst)
                db.AddParameter("p_CGST", pAllPartyAccount.Cgst)
                db.AddParameter("p_SGST", pAllPartyAccount.Sgst)
                db.AddParameter("p_LINE_CHEQUE_NO", pAllPartyAccount.LineChequeNo)
                db.AddParameter("p_LINE_CHEQUE_DATE", pAllPartyAccount.LineChequeDate)
                db.AddParameter("p_LINE_CHEQUE_AMOUNT", pAllPartyAccount.LineChequeAmount)
                db.AddParameter("p_PAYMENT_REMARKS", pAllPartyAccount.PaymentRemarks)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_TRAIN_NO", pAllPartyAccount.TrainNo)
                db.AddParameter("p_TRAIN_OUT_DATE", pAllPartyAccount.TrainOutDate)
                db.AddParameter("p_PORT_ARRIVAL", pAllPartyAccount.PortArrival)
                db.AddParameter("p_NO_OF_DAYS", pAllPartyAccount.NoOfDays)
                db.AddParameter("p_OBL_ISSUE_NO", pAllPartyAccount.OblIssueNo)
                db.AddParameter("p_REQUIRED_ETD", pAllPartyAccount.RequiredEtd)
                db.AddParameter("p_REQUIRED_VESSEL", pAllPartyAccount.RequiredVessel)
                db.AddParameter("p_CURRENT_ETD", pAllPartyAccount.CurrentEtd)
                db.AddParameter("p_CURRENT_VESSEL", pAllPartyAccount.CurrentVessel)
                db.AddParameter("p_SAILED_SOB", pAllPartyAccount.SailedSob)
                db.AddParameter("p_CURRENT_ETA", pAllPartyAccount.CurrentEta)
                db.AddParameter("p_TRANSIT_TIME", pAllPartyAccount.TransitTime)
                db.AddParameter("p_SHIPMENT_STATUS", pAllPartyAccount.ShipmentStatus)
                db.AddParameter("DET_METHOD", pAllPartyAccount.DetMethod)
                db.AddParameter("p_SURRENDER_INV_NO", pAllPartyAccount.SurrenderInvNo)
                db.AddParameter("p_SURRENDER_INV_AMOUNT", pAllPartyAccount.SurrenderInvAmount)
                db.AddParameter("p_SURRENDER_INV_PAYMENT", pAllPartyAccount.SurrenderInvPayment)
                db.AddParameter("p_SURRENDER_INV_STATUS", pAllPartyAccount.SurrenderInvStatus)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pAllPartyAccount.MtyContId)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ALL_PARTY_ACCOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pAllPartyAccount.ErrorMsg = ex.Message
            End Try
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRACK_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_SHIPPER_NAME", pAllPartyAccount.ShipperName)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_NOTIFY_PARTY", pAllPartyAccount.NotifyParty)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SELF_EXCISE", pAllPartyAccount.SelfExcise)
                db.AddParameter("p_PARTY_INV_NO", pAllPartyAccount.PartyInvNo)
                db.AddParameter("p_PARTY_INV_DATE", pAllPartyAccount.PartyInvDate)
                db.AddParameter("p_SB_NO", pAllPartyAccount.SbNo)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_VGM_WT", pAllPartyAccount.VgmWt)
                db.AddParameter("p_VGM_SUBMITTED", pAllPartyAccount.VgmSubmitted)
                db.AddParameter("p_SHIPMENT_TYPE", pAllPartyAccount.ShipmentType)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONT_SIZE", pAllPartyAccount.ContSize)
                db.AddParameter("p_CONT_TYPE", pAllPartyAccount.ContType)
                db.AddParameter("p_ICD_GATE_OUT", pAllPartyAccount.IcdGateOut)
                db.AddParameter("p_ICD_GATE_IN", pAllPartyAccount.IcdGateIn)
                db.AddParameter("p_PORT", pAllPartyAccount.Port)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_BL_NO", pAllPartyAccount.BlNo)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter("p_BL_REMARKS", pAllPartyAccount.BlRemarks)
                db.AddParameter("p_SOB", pAllPartyAccount.Sob)
                db.AddParameter("p_SAILED", pAllPartyAccount.Sailed)
                db.AddParameter("p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_LINE_INVOICE", pAllPartyAccount.LineInvoice)
                db.AddParameter("p_REQUIRED_GST", pAllPartyAccount.RequiredGst)
                db.AddParameter("p_SPECIAL_COMMENTS", pAllPartyAccount.SpecialComments)
                db.AddParameter("p_LINER_INV_NO", pAllPartyAccount.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pAllPartyAccount.LinerInvDate)
                db.AddParameter("p_LINER_DUE_DATE", pAllPartyAccount.LinerDueDate)
                db.AddParameter("p_AGEING", pAllPartyAccount.Ageing)
                db.AddParameter("p_BASE_FRT_USD", pAllPartyAccount.BaseFrtUsd)
                db.AddParameter("p_OTHER_CHARGES_USD", pAllPartyAccount.OtherChargesUsd)
                db.AddParameter("p_TOTAL_FRT_USD", pAllPartyAccount.TotalFrtUsd)
                db.AddParameter("p_FRT_EX_RATE", pAllPartyAccount.FrtExRate)
                db.AddParameter("p_FRT_GST", pAllPartyAccount.FrtGst)
                db.AddParameter("p_AMOUNT_INR", pAllPartyAccount.AmountInr)
                db.AddParameter("p_LINE_THC", pAllPartyAccount.LineThc)
                db.AddParameter("p_PORT_THC", pAllPartyAccount.PortThc)
                db.AddParameter("p_ORIGIN_THC", pAllPartyAccount.OriginThc)
                db.AddParameter("p_RAILFREIGHT", pAllPartyAccount.Railfreight)
                db.AddParameter("p_DOC_CHARGES", pAllPartyAccount.DocCharges)
                db.AddParameter("p_MISC_CHARGES", pAllPartyAccount.MiscCharges)
                db.AddParameter("p_IGST", pAllPartyAccount.Igst)
                db.AddParameter("p_CGST", pAllPartyAccount.Cgst)
                db.AddParameter("p_SGST", pAllPartyAccount.Sgst)
                db.AddParameter("p_LINE_CHEQUE_NO", pAllPartyAccount.LineChequeNo)
                db.AddParameter("p_LINE_CHEQUE_DATE", pAllPartyAccount.LineChequeDate)
                db.AddParameter("p_LINE_CHEQUE_AMOUNT", pAllPartyAccount.LineChequeAmount)
                db.AddParameter("p_PAYMENT_REMARKS", pAllPartyAccount.PaymentRemarks)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_TRAIN_NO", pAllPartyAccount.TrainNo)
                db.AddParameter("p_TRAIN_OUT_DATE", pAllPartyAccount.TrainOutDate)
                db.AddParameter("p_PORT_ARRIVAL", pAllPartyAccount.PortArrival)
                db.AddParameter("p_NO_OF_DAYS", pAllPartyAccount.NoOfDays)
                db.AddParameter("p_OBL_ISSUE_NO", pAllPartyAccount.OblIssueNo)
                db.AddParameter("p_REQUIRED_ETD", pAllPartyAccount.RequiredEtd)
                db.AddParameter("p_REQUIRED_VESSEL", pAllPartyAccount.RequiredVessel)
                db.AddParameter("p_CURRENT_ETD", pAllPartyAccount.CurrentEtd)
                db.AddParameter("p_CURRENT_VESSEL", pAllPartyAccount.CurrentVessel)
                db.AddParameter("p_SAILED_SOB", pAllPartyAccount.SailedSob)
                db.AddParameter("p_CURRENT_ETA", pAllPartyAccount.CurrentEta)
                db.AddParameter("p_TRANSIT_TIME", pAllPartyAccount.TransitTime)
                db.AddParameter("p_SHIPMENT_STATUS", pAllPartyAccount.ShipmentStatus)
                db.AddParameter("DET_METHOD", pAllPartyAccount.DetMethod)
                db.AddParameter("p_SURRENDER_INV_NO", pAllPartyAccount.SurrenderInvNo)
                db.AddParameter("p_SURRENDER_INV_AMOUNT", pAllPartyAccount.SurrenderInvAmount)
                db.AddParameter("p_SURRENDER_INV_PAYMENT", pAllPartyAccount.SurrenderInvPayment)
                db.AddParameter("p_SURRENDER_INV_STATUS", pAllPartyAccount.SurrenderInvStatus)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pAllPartyAccount.MtyContId)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pAllPartyAccount.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function




        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Try
                db.ClearParameters()
                db.AddParameter("p_TRACK_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_SHIPPER_NAME", pAllPartyAccount.ShipperName)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_NOTIFY_PARTY", pAllPartyAccount.NotifyParty)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SELF_EXCISE", pAllPartyAccount.SelfExcise)
                db.AddParameter("p_PARTY_INV_NO", pAllPartyAccount.PartyInvNo)
                db.AddParameter("p_PARTY_INV_DATE", pAllPartyAccount.PartyInvDate)
                db.AddParameter("p_SB_NO", pAllPartyAccount.SbNo)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_VGM_WT", pAllPartyAccount.VgmWt)
                db.AddParameter("p_VGM_SUBMITTED", pAllPartyAccount.VgmSubmitted)
                db.AddParameter("p_SHIPMENT_TYPE", pAllPartyAccount.ShipmentType)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONT_SIZE", pAllPartyAccount.ContSize)
                db.AddParameter("p_CONT_TYPE", pAllPartyAccount.ContType)
                db.AddParameter("p_ICD_GATE_OUT", pAllPartyAccount.IcdGateOut)
                db.AddParameter("p_ICD_GATE_IN", pAllPartyAccount.IcdGateIn)
                db.AddParameter("p_PORT", pAllPartyAccount.Port)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_BL_NO", pAllPartyAccount.BlNo)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter("p_BL_REMARKS", pAllPartyAccount.BlRemarks)
                db.AddParameter("p_SOB", pAllPartyAccount.Sob)
                db.AddParameter("p_SAILED", pAllPartyAccount.Sailed)
                db.AddParameter("p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_LINE_INVOICE", pAllPartyAccount.LineInvoice)
                db.AddParameter("p_REQUIRED_GST", pAllPartyAccount.RequiredGst)
                db.AddParameter("p_SPECIAL_COMMENTS", pAllPartyAccount.SpecialComments)
                db.AddParameter("p_LINER_INV_NO", pAllPartyAccount.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pAllPartyAccount.LinerInvDate)
                db.AddParameter("p_LINER_DUE_DATE", pAllPartyAccount.LinerDueDate)
                db.AddParameter("p_AGEING", pAllPartyAccount.Ageing)
                db.AddParameter("p_BASE_FRT_USD", pAllPartyAccount.BaseFrtUsd)
                db.AddParameter("p_OTHER_CHARGES_USD", pAllPartyAccount.OtherChargesUsd)
                db.AddParameter("p_TOTAL_FRT_USD", pAllPartyAccount.TotalFrtUsd)
                db.AddParameter("p_FRT_EX_RATE", pAllPartyAccount.FrtExRate)
                db.AddParameter("p_FRT_GST", pAllPartyAccount.FrtGst)
                db.AddParameter("p_AMOUNT_INR", pAllPartyAccount.AmountInr)
                db.AddParameter("p_LINE_THC", pAllPartyAccount.LineThc)
                db.AddParameter("p_PORT_THC", pAllPartyAccount.PortThc)
                db.AddParameter("p_ORIGIN_THC", pAllPartyAccount.OriginThc)
                db.AddParameter("p_RAILFREIGHT", pAllPartyAccount.Railfreight)
                db.AddParameter("p_DOC_CHARGES", pAllPartyAccount.DocCharges)
                db.AddParameter("p_MISC_CHARGES", pAllPartyAccount.MiscCharges)
                db.AddParameter("p_IGST", pAllPartyAccount.Igst)
                db.AddParameter("p_CGST", pAllPartyAccount.Cgst)
                db.AddParameter("p_SGST", pAllPartyAccount.Sgst)
                db.AddParameter("p_LINE_CHEQUE_NO", pAllPartyAccount.LineChequeNo)
                db.AddParameter("p_LINE_CHEQUE_DATE", pAllPartyAccount.LineChequeDate)
                db.AddParameter("p_LINE_CHEQUE_AMOUNT", pAllPartyAccount.LineChequeAmount)
                db.AddParameter("p_PAYMENT_REMARKS", pAllPartyAccount.PaymentRemarks)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_TRAIN_NO", pAllPartyAccount.TrainNo)
                db.AddParameter("p_TRAIN_OUT_DATE", pAllPartyAccount.TrainOutDate)
                db.AddParameter("p_PORT_ARRIVAL", pAllPartyAccount.PortArrival)
                db.AddParameter("p_NO_OF_DAYS", pAllPartyAccount.NoOfDays)
                db.AddParameter("p_OBL_ISSUE_NO", pAllPartyAccount.OblIssueNo)
                db.AddParameter("p_REQUIRED_ETD", pAllPartyAccount.RequiredEtd)
                db.AddParameter("p_REQUIRED_VESSEL", pAllPartyAccount.RequiredVessel)
                db.AddParameter("p_CURRENT_ETD", pAllPartyAccount.CurrentEtd)
                db.AddParameter("p_CURRENT_VESSEL", pAllPartyAccount.CurrentVessel)
                db.AddParameter("p_SAILED_SOB", pAllPartyAccount.SailedSob)
                db.AddParameter("p_CURRENT_ETA", pAllPartyAccount.CurrentEta)
                db.AddParameter("p_TRANSIT_TIME", pAllPartyAccount.TransitTime)
                db.AddParameter("p_SHIPMENT_STATUS", pAllPartyAccount.ShipmentStatus)
                db.AddParameter("DET_METHOD", pAllPartyAccount.DetMethod)
                db.AddParameter("p_SURRENDER_INV_NO", pAllPartyAccount.SurrenderInvNo)
                db.AddParameter("p_SURRENDER_INV_AMOUNT", pAllPartyAccount.SurrenderInvAmount)
                db.AddParameter("p_SURRENDER_INV_PAYMENT", pAllPartyAccount.SurrenderInvPayment)
                db.AddParameter("p_SURRENDER_INV_STATUS", pAllPartyAccount.SurrenderInvStatus)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_MTY_CONT_ID", pAllPartyAccount.MtyContId)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            Return pAllPartyAccount
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdatePart2(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT_PART2", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pAllPartyAccount.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdatePart2(ByVal db As DBConnect, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Try
                db.ClearParameters()
                db.AddParameter(" p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_CONSINGEE_NAME", pAllPartyAccount.ConsingeeName)
                db.AddParameter("p_LOT", pAllPartyAccount.Lot)
                db.AddParameter("p_HEALTH_CERTIFICATE_NO", pAllPartyAccount.HealthCertificateNo)
                db.AddParameter("p_HEALTH_CERTIFICATE_DATE", pAllPartyAccount.HealthCertificateDate)
                db.AddParameter("p_SB_DATE", pAllPartyAccount.SbDate)
                db.AddParameter("p_CUSTOMS_HANDOVER_DATE", pAllPartyAccount.CustomsHandoverDate)
                db.AddParameter("p_LINE_HANDOVER_DATE", pAllPartyAccount.LineHandoverDate)
                db.AddParameter("p_SB_RECEIVED", pAllPartyAccount.SbReceived)
                db.AddParameter("p_CARTONS", pAllPartyAccount.Cartons)
                db.AddParameter("p_NET_WT", pAllPartyAccount.NetWt)
                db.AddParameter("p_GROSS_WT", pAllPartyAccount.GrossWt)
                db.AddParameter("p_TARE_WT", pAllPartyAccount.TareWt)
                db.AddParameter("p_FOB_VALUE_INR", pAllPartyAccount.FobValueInr)
                db.AddParameter("p_EX_RATE", pAllPartyAccount.ExRate)
                db.AddParameter("p_FOB_VALUE_USD", pAllPartyAccount.FobValueUsd)
                db.AddParameter("p_CNF_USD", pAllPartyAccount.CnfUsd)
                db.AddParameter("p_UNITS", pAllPartyAccount.Units)
                db.AddParameter("p_COUNTRY", pAllPartyAccount.Country)
                db.AddParameter("p_REGION", pAllPartyAccount.Region)
                db.AddParameter("p_LINE", pAllPartyAccount.Line)
                db.AddParameter("p_CHA", pAllPartyAccount.Cha)
                db.AddParameter("p_PDA_ACCOUNT", pAllPartyAccount.PdaAccount)
                db.AddParameter("p_BOOKING_NO", pAllPartyAccount.BookingNo)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT_PART2", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            Return pAllPartyAccount
        End Function


        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                pAllPartyAccount.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRACK_ID").ToString <> "" Then
                                pAllPartyAccount.TrackId = dbr("TRACK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_NAME").ToString <> "" Then
                                pAllPartyAccount.ShipperName = dbr("SHIPPER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TELEX_STATUS").ToString <> "" Then
                                pAllPartyAccount.TelexStatus = dbr("TELEX_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_LOCATION").ToString <> "" Then
                                pAllPartyAccount.FactoryLocation = dbr("FACTORY_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSINGEE_NAME").ToString <> "" Then
                                pAllPartyAccount.ConsingeeName = dbr("CONSINGEE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NOTIFY_PARTY").ToString <> "" Then
                                pAllPartyAccount.NotifyParty = dbr("NOTIFY_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_STATUS_ID").ToString <> "" Then
                                pAllPartyAccount.BLStatusId = dbr("BL_STATUS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOT").ToString <> "" Then
                                pAllPartyAccount.Lot = dbr("LOT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HEALTH_CERTIFICATE_NO").ToString <> "" Then
                                pAllPartyAccount.HealthCertificateNo = dbr("HEALTH_CERTIFICATE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HEALTH_CERTIFICATE_DATE").ToString <> "" Then
                                pAllPartyAccount.HealthCertificateDate = dbr("HEALTH_CERTIFICATE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SELF_EXCISE").ToString <> "" Then
                                pAllPartyAccount.SelfExcise = dbr("SELF_EXCISE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARTY_INV_NO").ToString <> "" Then
                                pAllPartyAccount.PartyInvNo = dbr("PARTY_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARTY_INV_DATE").ToString <> "" Then
                                pAllPartyAccount.PartyInvDate = dbr("PARTY_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_NO").ToString <> "" Then
                                pAllPartyAccount.SbNo = dbr("SB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_DATE").ToString <> "" Then
                                pAllPartyAccount.SbDate = dbr("SB_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMS_HANDOVER_DATE").ToString <> "" Then
                                pAllPartyAccount.CustomsHandoverDate = dbr("CUSTOMS_HANDOVER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_HANDOVER_DATE").ToString <> "" Then
                                pAllPartyAccount.LineHandoverDate = dbr("LINE_HANDOVER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_RECEIVED").ToString <> "" Then
                                pAllPartyAccount.SbReceived = dbr("SB_RECEIVED")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARTONS").ToString <> "" Then
                                pAllPartyAccount.Cartons = dbr("CARTONS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NET_WT").ToString <> "" Then
                                pAllPartyAccount.NetWt = dbr("NET_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GROSS_WT").ToString <> "" Then
                                pAllPartyAccount.GrossWt = dbr("GROSS_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                pAllPartyAccount.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VGM_WT").ToString <> "" Then
                                pAllPartyAccount.VgmWt = dbr("VGM_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VGM_SUBMITTED").ToString <> "" Then
                                pAllPartyAccount.VgmSubmitted = dbr("VGM_SUBMITTED")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPMENT_TYPE").ToString <> "" Then
                                pAllPartyAccount.ShipmentType = dbr("SHIPMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOB_VALUE_INR").ToString <> "" Then
                                pAllPartyAccount.FobValueInr = dbr("FOB_VALUE_INR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pAllPartyAccount.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOB_VALUE_USD").ToString <> "" Then
                                pAllPartyAccount.FobValueUsd = dbr("FOB_VALUE_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CNF_USD").ToString <> "" Then
                                pAllPartyAccount.CnfUsd = dbr("CNF_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNITS").ToString <> "" Then
                                pAllPartyAccount.Units = dbr("UNITS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pAllPartyAccount.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pAllPartyAccount.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pAllPartyAccount.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_GATE_OUT").ToString <> "" Then
                                pAllPartyAccount.IcdGateOut = dbr("ICD_GATE_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_GATE_IN").ToString <> "" Then
                                pAllPartyAccount.IcdGateIn = dbr("ICD_GATE_IN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT").ToString <> "" Then
                                pAllPartyAccount.Port = dbr("PORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                pAllPartyAccount.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REGION").ToString <> "" Then
                                pAllPartyAccount.Region = dbr("REGION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE").ToString <> "" Then
                                pAllPartyAccount.Line = dbr("LINE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA").ToString <> "" Then
                                pAllPartyAccount.Cha = dbr("CHA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PDA_ACCOUNT").ToString <> "" Then
                                pAllPartyAccount.PdaAccount = dbr("PDA_ACCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                pAllPartyAccount.BookingNo = dbr("BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_DATE").ToString <> "" Then
                                pAllPartyAccount.BookingDate = dbr("BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                pAllPartyAccount.BlNo = dbr("BL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOLLOW_UP").ToString <> "" Then
                                pAllPartyAccount.FollowUp = dbr("FOLLOW_UP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_REMARKS").ToString <> "" Then
                                pAllPartyAccount.BlRemarks = dbr("BL_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SOB").ToString <> "" Then
                                pAllPartyAccount.Sob = dbr("SOB")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SAILED").ToString <> "" Then
                                pAllPartyAccount.Sailed = dbr("SAILED")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_STATUS").ToString <> "" Then
                                pAllPartyAccount.BlStatus = dbr("BL_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_INVOICE").ToString <> "" Then
                                pAllPartyAccount.LineInvoice = dbr("LINE_INVOICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_GST").ToString <> "" Then
                                pAllPartyAccount.RequiredGst = dbr("REQUIRED_GST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SPECIAL_COMMENTS").ToString <> "" Then
                                pAllPartyAccount.SpecialComments = dbr("SPECIAL_COMMENTS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                pAllPartyAccount.LinerInvNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                pAllPartyAccount.LinerInvDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_DUE_DATE").ToString <> "" Then
                                pAllPartyAccount.LinerDueDate = dbr("LINER_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGEING").ToString <> "" Then
                                pAllPartyAccount.Ageing = dbr("AGEING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_FRT_USD").ToString <> "" Then
                                pAllPartyAccount.BaseFrtUsd = dbr("BASE_FRT_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_CHARGES_USD").ToString <> "" Then
                                pAllPartyAccount.OtherChargesUsd = dbr("OTHER_CHARGES_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL_FRT_USD").ToString <> "" Then
                                pAllPartyAccount.TotalFrtUsd = dbr("TOTAL_FRT_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FRT_EX_RATE").ToString <> "" Then
                                pAllPartyAccount.FrtExRate = dbr("FRT_EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FRT_GST").ToString <> "" Then
                                pAllPartyAccount.FrtGst = dbr("FRT_GST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT_INR").ToString <> "" Then
                                pAllPartyAccount.AmountInr = dbr("AMOUNT_INR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_THC").ToString <> "" Then
                                pAllPartyAccount.LineThc = dbr("LINE_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_THC").ToString <> "" Then
                                pAllPartyAccount.PortThc = dbr("PORT_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ORIGIN_THC").ToString <> "" Then
                                pAllPartyAccount.OriginThc = dbr("ORIGIN_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RAILFREIGHT").ToString <> "" Then
                                pAllPartyAccount.Railfreight = dbr("RAILFREIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_CHARGES").ToString <> "" Then
                                pAllPartyAccount.DocCharges = dbr("DOC_CHARGES")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MISC_CHARGES").ToString <> "" Then
                                pAllPartyAccount.MiscCharges = dbr("MISC_CHARGES")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST").ToString <> "" Then
                                pAllPartyAccount.Igst = dbr("IGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST").ToString <> "" Then
                                pAllPartyAccount.Cgst = dbr("CGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST").ToString <> "" Then
                                pAllPartyAccount.Sgst = dbr("SGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_NO").ToString <> "" Then
                                pAllPartyAccount.LineChequeNo = dbr("LINE_CHEQUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_DATE").ToString <> "" Then
                                pAllPartyAccount.LineChequeDate = dbr("LINE_CHEQUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_AMOUNT").ToString <> "" Then
                                pAllPartyAccount.LineChequeAmount = dbr("LINE_CHEQUE_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_REMARKS").ToString <> "" Then
                                pAllPartyAccount.PaymentRemarks = dbr("PAYMENT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_STATUS").ToString <> "" Then
                                pAllPartyAccount.OblStatus = dbr("OBL_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_ISSUE_DATE").ToString <> "" Then
                                pAllPartyAccount.OblIssueDate = dbr("OBL_ISSUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_NO").ToString <> "" Then
                                pAllPartyAccount.TrainNo = dbr("TRAIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_OUT_DATE").ToString <> "" Then
                                pAllPartyAccount.TrainOutDate = dbr("TRAIN_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ARRIVAL").ToString <> "" Then
                                pAllPartyAccount.PortArrival = dbr("PORT_ARRIVAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_DAYS").ToString <> "" Then
                                pAllPartyAccount.NoOfDays = dbr("NO_OF_DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_ISSUE_NO").ToString <> "" Then
                                pAllPartyAccount.OblIssueNo = dbr("OBL_ISSUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_ETD").ToString <> "" Then
                                pAllPartyAccount.RequiredEtd = dbr("REQUIRED_ETD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_VESSEL").ToString <> "" Then
                                pAllPartyAccount.RequiredVessel = dbr("REQUIRED_VESSEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_ETD").ToString <> "" Then
                                pAllPartyAccount.CurrentEtd = dbr("CURRENT_ETD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_VESSEL").ToString <> "" Then
                                pAllPartyAccount.CurrentVessel = dbr("CURRENT_VESSEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SAILED_SOB").ToString <> "" Then
                                pAllPartyAccount.SailedSob = dbr("SAILED_SOB")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_ETA").ToString <> "" Then
                                pAllPartyAccount.CurrentEta = dbr("CURRENT_ETA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSIT_TIME").ToString <> "" Then
                                pAllPartyAccount.TransitTime = dbr("TRANSIT_TIME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPMENT_STATUS").ToString <> "" Then
                                pAllPartyAccount.ShipmentStatus = dbr("SHIPMENT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DET_METHOD").ToString <> "" Then
                                pAllPartyAccount.DetMethod = dbr("DET_METHOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_NO").ToString <> "" Then
                                pAllPartyAccount.SurrenderInvNo = dbr("SURRENDER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_AMOUNT").ToString <> "" Then
                                pAllPartyAccount.SurrenderInvAmount = dbr("SURRENDER_INV_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_PAYMENT").ToString <> "" Then
                                pAllPartyAccount.SurrenderInvPayment = dbr("SURRENDER_INV_PAYMENT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_STATUS").ToString <> "" Then
                                pAllPartyAccount.SurrenderInvStatus = dbr("SURRENDER_INV_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pAllPartyAccount.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pAllPartyAccount.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pAllPartyAccount.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CFS").ToString <> "" Then
                                pAllPartyAccount.CFS = dbr("CFS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JSB_BILLING").ToString <> "" Then
                                pAllPartyAccount.JsbBilling = dbr("JSB_BILLING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                pAllPartyAccount.POL = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL_ID").ToString <> "" Then
                                pAllPartyAccount.POLId = dbr("POL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_ID").ToString <> "" Then
                                pAllPartyAccount.PODId = dbr("POD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CFS_ID").ToString <> "" Then
                                pAllPartyAccount.CFSId = dbr("CFS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSIGNMENT_TYPE").ToString <> "" Then
                                pAllPartyAccount.ConsignmentType = dbr("CONSIGNMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_NO").ToString <> "" Then
                                pAllPartyAccount.JobNo = dbr("JOB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_DATE").ToString <> "" Then
                                pAllPartyAccount.JobDate = dbr("JOB_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSIGNMENT_TYPE_ID").ToString <> "" Then
                                pAllPartyAccount.ConsignmentTypeId = dbr("CONSIGNMENT_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REMARK_ID").ToString <> "" Then
                                pAllPartyAccount.HoldRemarkId = dbr("HOLD_REMARK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_TYPE").ToString <> "" Then
                                pAllPartyAccount.PackageType = dbr("PACKAGE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_TYPE_ID").ToString <> "" Then
                                pAllPartyAccount.PackageTypeId = dbr("PACKAGE_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCHARGE_DATE").ToString <> "" Then
                                pAllPartyAccount.DischargeDate = dbr("DISCHARGE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_OUT_DATE").ToString <> "" Then
                                pAllPartyAccount.GateoutDate = dbr("GATE_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_DATE").ToString <> "" Then
                                pAllPartyAccount.EmptyGateInDate = dbr("EMPTY_GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_METHOD").ToString <> "" Then
                                pAllPartyAccount.BLMethod = dbr("BL_METHOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_METHOD_ID").ToString <> "" Then
                                pAllPartyAccount.BLMethodId = dbr("BL_METHOD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VOYAGE").ToString <> "" Then
                                pAllPartyAccount.Voyage = dbr("VOYAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                pAllPartyAccount.RefId = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrAllPartyAccount As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New AllPartyAccount
                        Try
                            If dbr("BL_STATUS_ID").ToString <> "" Then
                                temp.BLStatusId = dbr("BL_STATUS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TELEX_STATUS").ToString <> "" Then
                                temp.TelexStatus = dbr("TELEX_STATUS")
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
                            If dbr("TRACK_ID").ToString <> "" Then
                                temp.TrackId = dbr("TRACK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_NAME").ToString <> "" Then
                                temp.ShipperName = dbr("SHIPPER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSINGEE_NAME").ToString <> "" Then
                                temp.ConsingeeName = dbr("CONSINGEE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NOTIFY_PARTY").ToString <> "" Then
                                temp.NotifyParty = dbr("NOTIFY_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOT").ToString <> "" Then
                                temp.Lot = dbr("LOT")
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
                            If dbr("HEALTH_CERTIFICATE_NO").ToString <> "" Then
                                temp.HealthCertificateNo = dbr("HEALTH_CERTIFICATE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HEALTH_CERTIFICATE_DATE").ToString <> "" Then
                                temp.HealthCertificateDate = dbr("HEALTH_CERTIFICATE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SELF_EXCISE").ToString <> "" Then
                                temp.SelfExcise = dbr("SELF_EXCISE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARTY_INV_NO").ToString <> "" Then
                                temp.PartyInvNo = dbr("PARTY_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARTY_INV_DATE").ToString <> "" Then
                                temp.PartyInvDate = dbr("PARTY_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_NO").ToString <> "" Then
                                temp.SbNo = dbr("SB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_DATE").ToString <> "" Then
                                temp.SbDate = dbr("SB_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMS_HANDOVER_DATE").ToString <> "" Then
                                temp.CustomsHandoverDate = dbr("CUSTOMS_HANDOVER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_HANDOVER_DATE").ToString <> "" Then
                                temp.LineHandoverDate = dbr("LINE_HANDOVER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_RECEIVED").ToString <> "" Then
                                temp.SbReceived = dbr("SB_RECEIVED")
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
                            If dbr("NET_WT").ToString <> "" Then
                                temp.NetWt = dbr("NET_WT")
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
                            If dbr("TARE_WT").ToString <> "" Then
                                temp.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VGM_WT").ToString <> "" Then
                                temp.VgmWt = dbr("VGM_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VGM_SUBMITTED").ToString <> "" Then
                                temp.VgmSubmitted = dbr("VGM_SUBMITTED")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPMENT_TYPE").ToString <> "" Then
                                temp.ShipmentType = dbr("SHIPMENT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOB_VALUE_INR").ToString <> "" Then
                                temp.FobValueInr = dbr("FOB_VALUE_INR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                temp.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOB_VALUE_USD").ToString <> "" Then
                                temp.FobValueUsd = dbr("FOB_VALUE_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CNF_USD").ToString <> "" Then
                                temp.CnfUsd = dbr("CNF_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNITS").ToString <> "" Then
                                temp.Units = dbr("UNITS")
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
                            If dbr("ICD_GATE_OUT").ToString <> "" Then
                                temp.IcdGateOut = dbr("ICD_GATE_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_GATE_IN").ToString <> "" Then
                                temp.IcdGateIn = dbr("ICD_GATE_IN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT").ToString <> "" Then
                                temp.Port = dbr("PORT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY").ToString <> "" Then
                                temp.Country = dbr("COUNTRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REGION").ToString <> "" Then
                                temp.Region = dbr("REGION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE").ToString <> "" Then
                                temp.Line = dbr("LINE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA").ToString <> "" Then
                                temp.Cha = dbr("CHA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PDA_ACCOUNT").ToString <> "" Then
                                temp.PdaAccount = dbr("PDA_ACCOUNT")
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
                            If dbr("BOOKING_DATE").ToString <> "" Then
                                temp.BookingDate = dbr("BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                temp.BlNo = dbr("BL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FOLLOW_UP").ToString <> "" Then
                                temp.FollowUp = dbr("FOLLOW_UP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_REMARKS").ToString <> "" Then
                                temp.BlRemarks = dbr("BL_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SOB").ToString <> "" Then
                                temp.Sob = dbr("SOB")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SAILED").ToString <> "" Then
                                temp.Sailed = dbr("SAILED")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_STATUS").ToString <> "" Then
                                temp.BlStatus = dbr("BL_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_INVOICE").ToString <> "" Then
                                temp.LineInvoice = dbr("LINE_INVOICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_GST").ToString <> "" Then
                                temp.RequiredGst = dbr("REQUIRED_GST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SPECIAL_COMMENTS").ToString <> "" Then
                                temp.SpecialComments = dbr("SPECIAL_COMMENTS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                temp.LinerInvNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                temp.LinerInvDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_DUE_DATE").ToString <> "" Then
                                temp.LinerDueDate = dbr("LINER_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AGEING").ToString <> "" Then
                                temp.Ageing = dbr("AGEING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_FRT_USD").ToString <> "" Then
                                temp.BaseFrtUsd = dbr("BASE_FRT_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER_CHARGES_USD").ToString <> "" Then
                                temp.OtherChargesUsd = dbr("OTHER_CHARGES_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL_FRT_USD").ToString <> "" Then
                                temp.TotalFrtUsd = dbr("TOTAL_FRT_USD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FRT_EX_RATE").ToString <> "" Then
                                temp.FrtExRate = dbr("FRT_EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FRT_GST").ToString <> "" Then
                                temp.FrtGst = dbr("FRT_GST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT_INR").ToString <> "" Then
                                temp.AmountInr = dbr("AMOUNT_INR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_THC").ToString <> "" Then
                                temp.LineThc = dbr("LINE_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_THC").ToString <> "" Then
                                temp.PortThc = dbr("PORT_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ORIGIN_THC").ToString <> "" Then
                                temp.OriginThc = dbr("ORIGIN_THC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RAILFREIGHT").ToString <> "" Then
                                temp.Railfreight = dbr("RAILFREIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_CHARGES").ToString <> "" Then
                                temp.DocCharges = dbr("DOC_CHARGES")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MISC_CHARGES").ToString <> "" Then
                                temp.MiscCharges = dbr("MISC_CHARGES")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST").ToString <> "" Then
                                temp.Igst = dbr("IGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST").ToString <> "" Then
                                temp.Cgst = dbr("CGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST").ToString <> "" Then
                                temp.Sgst = dbr("SGST")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_NO").ToString <> "" Then
                                temp.LineChequeNo = dbr("LINE_CHEQUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_DATE").ToString <> "" Then
                                temp.LineChequeDate = dbr("LINE_CHEQUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CHEQUE_AMOUNT").ToString <> "" Then
                                temp.LineChequeAmount = dbr("LINE_CHEQUE_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PAYMENT_REMARKS").ToString <> "" Then
                                temp.PaymentRemarks = dbr("PAYMENT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_STATUS").ToString <> "" Then
                                temp.OblStatus = dbr("OBL_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_ISSUE_DATE").ToString <> "" Then
                                temp.OblIssueDate = dbr("OBL_ISSUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_NO").ToString <> "" Then
                                temp.TrainNo = dbr("TRAIN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_OUT_DATE").ToString <> "" Then
                                temp.TrainOutDate = dbr("TRAIN_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ARRIVAL").ToString <> "" Then
                                temp.PortArrival = dbr("PORT_ARRIVAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_DAYS").ToString <> "" Then
                                temp.NoOfDays = dbr("NO_OF_DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OBL_ISSUE_NO").ToString <> "" Then
                                temp.OblIssueNo = dbr("OBL_ISSUE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_ETD").ToString <> "" Then
                                temp.RequiredEtd = dbr("REQUIRED_ETD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REQUIRED_VESSEL").ToString <> "" Then
                                temp.RequiredVessel = dbr("REQUIRED_VESSEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_ETD").ToString <> "" Then
                                temp.CurrentEtd = dbr("CURRENT_ETD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_VESSEL").ToString <> "" Then
                                temp.CurrentVessel = dbr("CURRENT_VESSEL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SAILED_SOB").ToString <> "" Then
                                temp.SailedSob = dbr("SAILED_SOB")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_ETA").ToString <> "" Then
                                temp.CurrentEta = dbr("CURRENT_ETA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSIT_TIME").ToString <> "" Then
                                temp.TransitTime = dbr("TRANSIT_TIME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPMENT_STATUS").ToString <> "" Then
                                temp.ShipmentStatus = dbr("SHIPMENT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DET_METHOD").ToString <> "" Then
                                temp.DetMethod = dbr("DET_METHOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_NO").ToString <> "" Then
                                temp.SurrenderInvNo = dbr("SURRENDER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_AMOUNT").ToString <> "" Then
                                temp.SurrenderInvAmount = dbr("SURRENDER_INV_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_PAYMENT").ToString <> "" Then
                                temp.SurrenderInvPayment = dbr("SURRENDER_INV_PAYMENT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SURRENDER_INV_STATUS").ToString <> "" Then
                                temp.SurrenderInvStatus = dbr("SURRENDER_INV_STATUS")
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
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CFS").ToString <> "" Then
                                temp.CFS = dbr("CFS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JSB_BILLING").ToString <> "" Then
                                temp.JsbBilling = dbr("JSB_BILLING")
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
                            If dbr("POL_ID").ToString <> "" Then
                                temp.POLId = dbr("POL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_ID").ToString <> "" Then
                                temp.PODId = dbr("POD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CFS_ID").ToString <> "" Then
                                temp.CFSId = dbr("CFS_ID")
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
                            If dbr("JOB_NO").ToString <> "" Then
                                temp.JobNo = dbr("JOB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOB_DATE").ToString <> "" Then
                                temp.JobDate = dbr("JOB_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONSIGNMENT_TYPE_ID").ToString <> "" Then
                                temp.ConsignmentTypeId = dbr("CONSIGNMENT_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("HOLD_REMARK_ID").ToString <> "" Then
                                temp.HoldRemarkId = dbr("HOLD_REMARK_ID")
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
                            If dbr("PACKAGE_TYPE_ID").ToString <> "" Then
                                temp.PackageTypeId = dbr("PACKAGE_TYPE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCHARGE_DATE").ToString <> "" Then
                                temp.DischargeDate = dbr("DISCHARGE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_OUT_DATE").ToString <> "" Then
                                temp.GateoutDate = dbr("GATE_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMPTY_GATE_IN_DATE").ToString <> "" Then
                                temp.EmptyGateInDate = dbr("EMPTY_GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_METHOD").ToString <> "" Then
                                temp.BLMethod = dbr("BL_METHOD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_METHOD_ID").ToString <> "" Then
                                temp.BLMethodId = dbr("BL_METHOD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VOYAGE").ToString <> "" Then
                                temp.Voyage = dbr("VOYAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                temp.RefId = dbr("REF_ID")
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
        Public Shared Function ReturnAllPartyAccount(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ACCOUNT", "' '")
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnAllPartyAccountList(ByVal pAllPartyAccount As AllPartyAccount) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrAllPartyAccount As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ACCOUNT_BY_ID", "' '")
                arrAllPartyAccount = ReturnObjectValuesList(dbr, arrAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                arrAllPartyAccount = Nothing
            End Try
            db.CloseDB()
            Return arrAllPartyAccount
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnAllPartyAccountSearchList(ByVal pAllPartyAccount As AllPartyAccount) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrAllPartyAccount As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ACCOUNT_SEARCH", "'" & pAllPartyAccount.CreatedBy & "','" & pAllPartyAccount.CreatedOn & "','" & pAllPartyAccount.BlNo & "','" & pAllPartyAccount.ShipperName & "','" & pAllPartyAccount.SelfExcise & "'")
                arrAllPartyAccount = ReturnObjectValuesList(dbr, arrAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                arrAllPartyAccount = Nothing
            End Try
            db.CloseDB()
            Return arrAllPartyAccount
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnAPA1(ByVal pAllPartyAccount As AllPartyAccount) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrAllPartyAccount As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_APA1", "'" & pAllPartyAccount.ContNo & "'")
                arrAllPartyAccount = ReturnObjectValuesList(dbr, arrAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                arrAllPartyAccount = Nothing
            End Try
            db.CloseDB()
            Return arrAllPartyAccount
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdatePart3(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_JSB_BILLING", pAllPartyAccount.JsbBilling)
                db.AddParameter("p_BL_NO ", pAllPartyAccount.BlNo)
                db.AddParameter(" p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter(" p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT_PART3", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pAllPartyAccount.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAllPartyAccount"></param>
        ''' <returns>Return pAllPartyAccount Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdatePart3Trn(ByVal db As DBConnect, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Try
                db.ClearParameters()
                db.AddParameter("p_CONT_NO", pAllPartyAccount.ContNo)
                db.AddParameter("p_JSB_BILLING", pAllPartyAccount.JsbBilling)
                db.AddParameter("p_BL_NO", pAllPartyAccount.BlNo)
                db.AddParameter("p_BL_STATUS", pAllPartyAccount.BlStatus)
                db.AddParameter("p_OBL_STATUS", pAllPartyAccount.OblStatus)
                db.AddParameter("p_FOLLOW_UP", pAllPartyAccount.FollowUp)
                db.AddParameter("p_OBL_ISSUE_DATE", pAllPartyAccount.OblIssueDate)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ALL_PARTY_ACCOUNT_PART3", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            Return pAllPartyAccount

        End Function

        '' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnAllPartyAccountPart2(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ID_PART", "'" & pAllPartyAccount.ContNo & "'")
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        '' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnAllPartyAccountByContJoId(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_BY_ID", pAllPartyAccount.ContJoId)
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function
        Public Shared Function ReturnAllPartyAccountPart3(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ID_CONT_ID", pAllPartyAccount.ContJoId)
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function
        Public Shared Function ReturnAPA2(ByVal pAllPartyAccount As AllPartyAccount) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrAllPartyAccount As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_APA1_BY_CONT_ID", "'" & pAllPartyAccount.MtyContId & "'")
                arrAllPartyAccount = ReturnObjectValuesList(dbr, arrAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                arrAllPartyAccount = Nothing
            End Try
            db.CloseDB()
            Return arrAllPartyAccount
        End Function
        Public Shared Function ReturnAllPartyAccountPartyHandover(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ALL_PARTY_ID_HANDOVER", pAllPartyAccount.ContJoId)
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function
        Public Shared Function ReturnAPA2data(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_APA1_BY_CONT_ID", "'" & pAllPartyAccount.MtyContId & "'")
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function
        Public Shared Function ReturnMtyContId(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_ID", "'" & pAllPartyAccount.MtyContId & "'")
                pAllPartyAccount = ReturnObjectValues(dbr, pAllPartyAccount)
                dbr.Close()
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

        Public Shared Function UploadAllPartyDocumentByFileId(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()

                db.AddParameter("p_FILE_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_ALL_PARTY_DOCUMNET", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString

                End If
                If pAllPartyAccount.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function
        Public Shared Function UploadVesselFileId(ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()

                db.AddParameter("p_FILE_ID", pAllPartyAccount.TrackId)
                db.AddParameter("p_CREATED_BY", pAllPartyAccount.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAllPartyAccount.CreatedOn)
                db.AddParameter("p_ErrorMsg", pAllPartyAccount.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_UPLOAD_VESSEL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAllPartyAccount.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString

                End If
                If pAllPartyAccount.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAllPartyAccount.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAllPartyAccount
        End Function

    End Class

End Namespace
