Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyContainers
    ''' @author	: Amit K. Singh- 14/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MtyContainers 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private lngMtyContGateInId As Long ' Define Private Variable MtyContGateInId With DataType As Long 
        Private lngDestuffImpContId As Long ' Define Private Variable DestuffImpContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strIsoCode As String ' Define Private Variable IsoCode With DataType As String 
        Private lngTareWt As Double ' Define Private Variable TareWt With DataType As Double
        Private lngYardId As Long ' Define Private Variable YardId With DataType As Long 
        Private lngInAgentId As Long ' Define Private Variable InAgentId With DataType As Long 
        Private lngInChaId As Long ' Define Private Variable InChaId With DataType As Long 
        Private lngInLineId As Long ' Define Private Variable InLineId With DataType As Long 
        Private lngInBillToId As Long ' Define Private Variable InBillToId With DataType As Long 
        Private strInDate As String ' Define Private Variable InDate With DataType As String 
        Private strInPassNo As String ' Define Private Variable InPassNo With DataType As String 
        Private strInMode As String ' Define Private Variable InMode With DataType As String 
        Private strInTruckNo As String ' Define Private Variable InTruckNo With DataType As String 
        Private strInDriverName As String ' Define Private Variable InDriverName With DataType As String 
        Private lngInDamageId As Long ' Define Private Variable InDamageId With DataType As Long 
        Private strInDamageDetails As String ' Define Private Variable InDamageDetails With DataType As String 
        Private lngInTransporterId As Long ' Define Private Variable InTransporterId With DataType As Long 
        Private strInTransMode As String ' Define Private Variable InTransMode With DataType As String 
        Private strInRemarks As String ' Define Private Variable InRemarks With DataType As String 
        Private strInBookingNo As String ' Define Private Variable InBookingNo With DataType As String 
        Private strInBookingDate As String ' Define Private Variable InBookingDate With DataType As String 
        Private strInCodeccoStatus As String ' Define Private Variable InCodeccoStatus With DataType As String 
        Private strInCodeccoDate As String ' Define Private Variable InCodeccoDate With DataType As String 
        Private strInDoNo As String ' Define Private Variable InDoNo With DataType As String 
        Private lngInTrainId As Long ' Define Private Variable InTrainId With DataType As Long 
        Private lngInPortId As Long ' Define Private Variable InPortId With DataType As Long 
        Private strInEirNo As String ' Define Private Variable InEirNo With DataType As String 
        Private lngInSurveyorId As Long ' Define Private Variable InSurveyorId With DataType As Long 
        Private strInCreatedBy As String ' Define Private Variable InCreatedBy With DataType As String 
        Private strInCreatedOn As String ' Define Private Variable InCreatedOn With DataType As String 
        Private lngOutChaId As Long ' Define Private Variable OutChaId With DataType As Long 
        Private lngOutAgentId As Long ' Define Private Variable OutAgentId With DataType As Long 
        Private lngOutLineId As Long ' Define Private Variable OutLineId With DataType As Long 
        Private lngOutConsigneeId As Long ' Define Private Variable OutConsigneeId With DataType As Long 
        Private lngOutBillToId As Long ' Define Private Variable OutBillToId With DataType As Long 
        Private strOutPassNo As String ' Define Private Variable OutPassNo With DataType As String 
        Private strOutDate As String ' Define Private Variable OutDate With DataType As String 
        Private strOutMode As String ' Define Private Variable OutMode With DataType As String 
        Private strOutTruckNo As String ' Define Private Variable OutTruckNo With DataType As String 
        Private lngOutTransporterId As Long ' Define Private Variable OutTransporterId With DataType As Long 
        Private strOutTransMode As String ' Define Private Variable OutTransMode With DataType As String 
        Private lngOutDamageId As Long ' Define Private Variable OutDamageId With DataType As Long 
        Private strOutDamageDetails As String ' Define Private Variable OutDamageDetails With DataType As String 
        Private strOutRemarks As String ' Define Private Variable OutRemarks With DataType As String 
        Private strOutBookingNo As String ' Define Private Variable OutBookingNo With DataType As String 
        Private strOutBookingDate As String ' Define Private Variable OutBookingDate With DataType As String 
        Private strOutCodeccoStatus As String ' Define Private Variable OutCodeccoStatus With DataType As String 
        Private strOutCoddeccoDate As String ' Define Private Variable OutCoddeccoDate With DataType As String 
        Private strOutDoNo As String ' Define Private Variable OutDoNo With DataType As String 
        Private lngOutTrainId As Long ' Define Private Variable OutTrainId With DataType As Long 
        Private lngOutPortId As Long ' Define Private Variable OutPortId With DataType As Long 
        Private lngOutEquipmentId As Long ' Define Private Variable OutEquipmentId With DataType As Long 
        Private strOutEirNo As String ' Define Private Variable OutEirNo With DataType As String 
        Private lngOutSurveyorId As Long ' Define Private Variable OutSurveyorId With DataType As Long 
        Private strOutCreatedBy As String ' Define Private Variable OutCreatedBy With DataType As String 
        Private strOutCreatedOn As String ' Define Private Variable OutCreatedOn With DataType As String 
        Private lngHoldId As Long ' Define Private Variable HoldId With DataType As  long 
        Private strFactoryOutDate As String ' Define Private Variable HoldId With DataType As  long 
        Private strFactoryInDate As String ' Define Private Variable HoldId With DataType As  long 
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
        ''' Get or Set the Value of MtyContId
        ''' </summary>
        ''' <value>lngMtyContId</value>
        ''' <returns> Return lngMtyContId</returns>
        ''' <remarks> Get or Set the Value of MtyContId  </remarks>
        '''
        Public Property MtyContId() as Long
            Get
                Return lngMtyContId
            End Get
            Set(ByVal value As Long)
                lngMtyContId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyContGateInId
        ''' </summary>
        ''' <value>lngMtyContGateInId</value>
        ''' <returns> Return lngMtyContGateInId</returns>
        ''' <remarks> Get or Set the Value of MtyContGateInId  </remarks>
        '''
        Public Property MtyContGateInId() as Long
            Get
                Return lngMtyContGateInId
            End Get
            Set(ByVal value As Long)
                lngMtyContGateInId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DestuffImpContId
        ''' </summary>
        ''' <value>lngDestuffImpContId</value>
        ''' <returns> Return lngDestuffImpContId</returns>
        ''' <remarks> Get or Set the Value of DestuffImpContId  </remarks>
        '''
        Public Property DestuffImpContId() as Long
            Get
                Return lngDestuffImpContId
            End Get
            Set(ByVal value As Long)
                lngDestuffImpContId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property ContNo() as String
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
        Public Property ContSize() as String
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
        Public Property ContType() as String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IsoCode
        ''' </summary>
        ''' <value>strIsoCode</value>
        ''' <returns> Return strIsoCode</returns>
        ''' <remarks> Get or Set the Value of IsoCode  </remarks>
        '''
        Public Property IsoCode() as String
            Get
                Return strIsoCode
            End Get
            Set(ByVal value As String)
                strIsoCode = value
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
        ''' Get or Set the Value of YardId
        ''' </summary>
        ''' <value>lngYardId</value>
        ''' <returns> Return lngYardId</returns>
        ''' <remarks> Get or Set the Value of YardId  </remarks>
        '''
        Public Property YardId() as Long
            Get
                Return lngYardId
            End Get
            Set(ByVal value As Long)
                lngYardId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InAgentId
        ''' </summary>
        ''' <value>lngInAgentId</value>
        ''' <returns> Return lngInAgentId</returns>
        ''' <remarks> Get or Set the Value of InAgentId  </remarks>
        '''
        Public Property InAgentId() as Long
            Get
                Return lngInAgentId
            End Get
            Set(ByVal value As Long)
                lngInAgentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InChaId
        ''' </summary>
        ''' <value>lngInChaId</value>
        ''' <returns> Return lngInChaId</returns>
        ''' <remarks> Get or Set the Value of InChaId  </remarks>
        '''
        Public Property InChaId() as Long
            Get
                Return lngInChaId
            End Get
            Set(ByVal value As Long)
                lngInChaId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InLineId
        ''' </summary>
        ''' <value>lngInLineId</value>
        ''' <returns> Return lngInLineId</returns>
        ''' <remarks> Get or Set the Value of InLineId  </remarks>
        '''
        Public Property InLineId() as Long
            Get
                Return lngInLineId
            End Get
            Set(ByVal value As Long)
                lngInLineId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InBillToId
        ''' </summary>
        ''' <value>lngInBillToId</value>
        ''' <returns> Return lngInBillToId</returns>
        ''' <remarks> Get or Set the Value of InBillToId  </remarks>
        '''
        Public Property InBillToId() as Long
            Get
                Return lngInBillToId
            End Get
            Set(ByVal value As Long)
                lngInBillToId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InDate
        ''' </summary>
        ''' <value>strInDate</value>
        ''' <returns> Return strInDate</returns>
        ''' <remarks> Get or Set the Value of InDate  </remarks>
        '''
        Public Property InDate() as String
            Get
                Return strInDate
            End Get
            Set(ByVal value As String)
                strInDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InPassNo
        ''' </summary>
        ''' <value>strInPassNo</value>
        ''' <returns> Return strInPassNo</returns>
        ''' <remarks> Get or Set the Value of InPassNo  </remarks>
        '''
        Public Property InPassNo() as String
            Get
                Return strInPassNo
            End Get
            Set(ByVal value As String)
                strInPassNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InMode
        ''' </summary>
        ''' <value>strInMode</value>
        ''' <returns> Return strInMode</returns>
        ''' <remarks> Get or Set the Value of InMode  </remarks>
        '''
        Public Property InMode() as String
            Get
                Return strInMode
            End Get
            Set(ByVal value As String)
                strInMode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InTruckNo
        ''' </summary>
        ''' <value>strInTruckNo</value>
        ''' <returns> Return strInTruckNo</returns>
        ''' <remarks> Get or Set the Value of InTruckNo  </remarks>
        '''
        Public Property InTruckNo() as String
            Get
                Return strInTruckNo
            End Get
            Set(ByVal value As String)
                strInTruckNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InDriverName
        ''' </summary>
        ''' <value>strInDriverName</value>
        ''' <returns> Return strInDriverName</returns>
        ''' <remarks> Get or Set the Value of InDriverName  </remarks>
        '''
        Public Property InDriverName() as String
            Get
                Return strInDriverName
            End Get
            Set(ByVal value As String)
                strInDriverName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InDamageId
        ''' </summary>
        ''' <value>lngInDamageId</value>
        ''' <returns> Return lngInDamageId</returns>
        ''' <remarks> Get or Set the Value of InDamageId  </remarks>
        '''
        Public Property InDamageId() as Long
            Get
                Return lngInDamageId
            End Get
            Set(ByVal value As Long)
                lngInDamageId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InDamageDetails
        ''' </summary>
        ''' <value>strInDamageDetails</value>
        ''' <returns> Return strInDamageDetails</returns>
        ''' <remarks> Get or Set the Value of InDamageDetails  </remarks>
        '''
        Public Property InDamageDetails() as String
            Get
                Return strInDamageDetails
            End Get
            Set(ByVal value As String)
                strInDamageDetails = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InTransporterId
        ''' </summary>
        ''' <value>lngInTransporterId</value>
        ''' <returns> Return lngInTransporterId</returns>
        ''' <remarks> Get or Set the Value of InTransporterId  </remarks>
        '''
        Public Property InTransporterId() as Long
            Get
                Return lngInTransporterId
            End Get
            Set(ByVal value As Long)
                lngInTransporterId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InTransMode
        ''' </summary>
        ''' <value>strInTransMode</value>
        ''' <returns> Return strInTransMode</returns>
        ''' <remarks> Get or Set the Value of InTransMode  </remarks>
        '''
        Public Property InTransMode() as String
            Get
                Return strInTransMode
            End Get
            Set(ByVal value As String)
                strInTransMode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InRemarks
        ''' </summary>
        ''' <value>strInRemarks</value>
        ''' <returns> Return strInRemarks</returns>
        ''' <remarks> Get or Set the Value of InRemarks  </remarks>
        '''
        Public Property InRemarks() as String
            Get
                Return strInRemarks
            End Get
            Set(ByVal value As String)
                strInRemarks = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InBookingNo
        ''' </summary>
        ''' <value>strInBookingNo</value>
        ''' <returns> Return strInBookingNo</returns>
        ''' <remarks> Get or Set the Value of InBookingNo  </remarks>
        '''
        Public Property InBookingNo() as String
            Get
                Return strInBookingNo
            End Get
            Set(ByVal value As String)
                strInBookingNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InBookingDate
        ''' </summary>
        ''' <value>strInBookingDate</value>
        ''' <returns> Return strInBookingDate</returns>
        ''' <remarks> Get or Set the Value of InBookingDate  </remarks>
        '''
        Public Property InBookingDate() as String
            Get
                Return strInBookingDate
            End Get
            Set(ByVal value As String)
                strInBookingDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InCodeccoStatus
        ''' </summary>
        ''' <value>strInCodeccoStatus</value>
        ''' <returns> Return strInCodeccoStatus</returns>
        ''' <remarks> Get or Set the Value of InCodeccoStatus  </remarks>
        '''
        Public Property InCodeccoStatus() as String
            Get
                Return strInCodeccoStatus
            End Get
            Set(ByVal value As String)
                strInCodeccoStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InCodeccoDate
        ''' </summary>
        ''' <value>strInCodeccoDate</value>
        ''' <returns> Return strInCodeccoDate</returns>
        ''' <remarks> Get or Set the Value of InCodeccoDate  </remarks>
        '''
        Public Property InCodeccoDate() as String
            Get
                Return strInCodeccoDate
            End Get
            Set(ByVal value As String)
                strInCodeccoDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InDoNo
        ''' </summary>
        ''' <value>strInDoNo</value>
        ''' <returns> Return strInDoNo</returns>
        ''' <remarks> Get or Set the Value of InDoNo  </remarks>
        '''
        Public Property InDoNo() as String
            Get
                Return strInDoNo
            End Get
            Set(ByVal value As String)
                strInDoNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InTrainId
        ''' </summary>
        ''' <value>lngInTrainId</value>
        ''' <returns> Return lngInTrainId</returns>
        ''' <remarks> Get or Set the Value of InTrainId  </remarks>
        '''
        Public Property InTrainId() as Long
            Get
                Return lngInTrainId
            End Get
            Set(ByVal value As Long)
                lngInTrainId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InPortId
        ''' </summary>
        ''' <value>lngInPortId</value>
        ''' <returns> Return lngInPortId</returns>
        ''' <remarks> Get or Set the Value of InPortId  </remarks>
        '''
        Public Property InPortId() as Long
            Get
                Return lngInPortId
            End Get
            Set(ByVal value As Long)
                lngInPortId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InEirNo
        ''' </summary>
        ''' <value>strInEirNo</value>
        ''' <returns> Return strInEirNo</returns>
        ''' <remarks> Get or Set the Value of InEirNo  </remarks>
        '''
        Public Property InEirNo() as String
            Get
                Return strInEirNo
            End Get
            Set(ByVal value As String)
                strInEirNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InSurveyorId
        ''' </summary>
        ''' <value>lngInSurveyorId</value>
        ''' <returns> Return lngInSurveyorId</returns>
        ''' <remarks> Get or Set the Value of InSurveyorId  </remarks>
        '''
        Public Property InSurveyorId() as Long
            Get
                Return lngInSurveyorId
            End Get
            Set(ByVal value As Long)
                lngInSurveyorId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InCreatedBy
        ''' </summary>
        ''' <value>strInCreatedBy</value>
        ''' <returns> Return strInCreatedBy</returns>
        ''' <remarks> Get or Set the Value of InCreatedBy  </remarks>
        '''
        Public Property InCreatedBy() as String
            Get
                Return strInCreatedBy
            End Get
            Set(ByVal value As String)
                strInCreatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InCreatedOn
        ''' </summary>
        ''' <value>strInCreatedOn</value>
        ''' <returns> Return strInCreatedOn</returns>
        ''' <remarks> Get or Set the Value of InCreatedOn  </remarks>
        '''
        Public Property InCreatedOn() as String
            Get
                Return strInCreatedOn
            End Get
            Set(ByVal value As String)
                strInCreatedOn = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutChaId
        ''' </summary>
        ''' <value>lngOutChaId</value>
        ''' <returns> Return lngOutChaId</returns>
        ''' <remarks> Get or Set the Value of OutChaId  </remarks>
        '''
        Public Property OutChaId() as Long
            Get
                Return lngOutChaId
            End Get
            Set(ByVal value As Long)
                lngOutChaId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutAgentId
        ''' </summary>
        ''' <value>lngOutAgentId</value>
        ''' <returns> Return lngOutAgentId</returns>
        ''' <remarks> Get or Set the Value of OutAgentId  </remarks>
        '''
        Public Property OutAgentId() as Long
            Get
                Return lngOutAgentId
            End Get
            Set(ByVal value As Long)
                lngOutAgentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutLineId
        ''' </summary>
        ''' <value>lngOutLineId</value>
        ''' <returns> Return lngOutLineId</returns>
        ''' <remarks> Get or Set the Value of OutLineId  </remarks>
        '''
        Public Property OutLineId() as Long
            Get
                Return lngOutLineId
            End Get
            Set(ByVal value As Long)
                lngOutLineId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutConsigneeId
        ''' </summary>
        ''' <value>lngOutConsigneeId</value>
        ''' <returns> Return lngOutConsigneeId</returns>
        ''' <remarks> Get or Set the Value of OutConsigneeId  </remarks>
        '''
        Public Property OutConsigneeId() as Long
            Get
                Return lngOutConsigneeId
            End Get
            Set(ByVal value As Long)
                lngOutConsigneeId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutBillToId
        ''' </summary>
        ''' <value>lngOutBillToId</value>
        ''' <returns> Return lngOutBillToId</returns>
        ''' <remarks> Get or Set the Value of OutBillToId  </remarks>
        '''
        Public Property OutBillToId() as Long
            Get
                Return lngOutBillToId
            End Get
            Set(ByVal value As Long)
                lngOutBillToId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutPassNo
        ''' </summary>
        ''' <value>strOutPassNo</value>
        ''' <returns> Return strOutPassNo</returns>
        ''' <remarks> Get or Set the Value of OutPassNo  </remarks>
        '''
        Public Property OutPassNo() as String
            Get
                Return strOutPassNo
            End Get
            Set(ByVal value As String)
                strOutPassNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutDate
        ''' </summary>
        ''' <value>strOutDate</value>
        ''' <returns> Return strOutDate</returns>
        ''' <remarks> Get or Set the Value of OutDate  </remarks>
        '''
        Public Property OutDate() as String
            Get
                Return strOutDate
            End Get
            Set(ByVal value As String)
                strOutDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutMode
        ''' </summary>
        ''' <value>strOutMode</value>
        ''' <returns> Return strOutMode</returns>
        ''' <remarks> Get or Set the Value of OutMode  </remarks>
        '''
        Public Property OutMode() as String
            Get
                Return strOutMode
            End Get
            Set(ByVal value As String)
                strOutMode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutTruckNo
        ''' </summary>
        ''' <value>strOutTruckNo</value>
        ''' <returns> Return strOutTruckNo</returns>
        ''' <remarks> Get or Set the Value of OutTruckNo  </remarks>
        '''
        Public Property OutTruckNo() as String
            Get
                Return strOutTruckNo
            End Get
            Set(ByVal value As String)
                strOutTruckNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutTransporterId
        ''' </summary>
        ''' <value>lngOutTransporterId</value>
        ''' <returns> Return lngOutTransporterId</returns>
        ''' <remarks> Get or Set the Value of OutTransporterId  </remarks>
        '''
        Public Property OutTransporterId() as Long
            Get
                Return lngOutTransporterId
            End Get
            Set(ByVal value As Long)
                lngOutTransporterId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutTransMode
        ''' </summary>
        ''' <value>strOutTransMode</value>
        ''' <returns> Return strOutTransMode</returns>
        ''' <remarks> Get or Set the Value of OutTransMode  </remarks>
        '''
        Public Property OutTransMode() as String
            Get
                Return strOutTransMode
            End Get
            Set(ByVal value As String)
                strOutTransMode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutDamageId
        ''' </summary>
        ''' <value>lngOutDamageId</value>
        ''' <returns> Return lngOutDamageId</returns>
        ''' <remarks> Get or Set the Value of OutDamageId  </remarks>
        '''
        Public Property OutDamageId() as Long
            Get
                Return lngOutDamageId
            End Get
            Set(ByVal value As Long)
                lngOutDamageId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutDamageDetails
        ''' </summary>
        ''' <value>strOutDamageDetails</value>
        ''' <returns> Return strOutDamageDetails</returns>
        ''' <remarks> Get or Set the Value of OutDamageDetails  </remarks>
        '''
        Public Property OutDamageDetails() as String
            Get
                Return strOutDamageDetails
            End Get
            Set(ByVal value As String)
                strOutDamageDetails = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutRemarks
        ''' </summary>
        ''' <value>strOutRemarks</value>
        ''' <returns> Return strOutRemarks</returns>
        ''' <remarks> Get or Set the Value of OutRemarks  </remarks>
        '''
        Public Property OutRemarks() as String
            Get
                Return strOutRemarks
            End Get
            Set(ByVal value As String)
                strOutRemarks = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutBookingNo
        ''' </summary>
        ''' <value>strOutBookingNo</value>
        ''' <returns> Return strOutBookingNo</returns>
        ''' <remarks> Get or Set the Value of OutBookingNo  </remarks>
        '''
        Public Property OutBookingNo() as String
            Get
                Return strOutBookingNo
            End Get
            Set(ByVal value As String)
                strOutBookingNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutBookingDate
        ''' </summary>
        ''' <value>strOutBookingDate</value>
        ''' <returns> Return strOutBookingDate</returns>
        ''' <remarks> Get or Set the Value of OutBookingDate  </remarks>
        '''
        Public Property OutBookingDate() as String
            Get
                Return strOutBookingDate
            End Get
            Set(ByVal value As String)
                strOutBookingDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutCodeccoStatus
        ''' </summary>
        ''' <value>strOutCodeccoStatus</value>
        ''' <returns> Return strOutCodeccoStatus</returns>
        ''' <remarks> Get or Set the Value of OutCodeccoStatus  </remarks>
        '''
        Public Property OutCodeccoStatus() as String
            Get
                Return strOutCodeccoStatus
            End Get
            Set(ByVal value As String)
                strOutCodeccoStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutCoddeccoDate
        ''' </summary>
        ''' <value>strOutCoddeccoDate</value>
        ''' <returns> Return strOutCoddeccoDate</returns>
        ''' <remarks> Get or Set the Value of OutCoddeccoDate  </remarks>
        '''
        Public Property OutCoddeccoDate() as String
            Get
                Return strOutCoddeccoDate
            End Get
            Set(ByVal value As String)
                strOutCoddeccoDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutDoNo
        ''' </summary>
        ''' <value>strOutDoNo</value>
        ''' <returns> Return strOutDoNo</returns>
        ''' <remarks> Get or Set the Value of OutDoNo  </remarks>
        '''
        Public Property OutDoNo() as String
            Get
                Return strOutDoNo
            End Get
            Set(ByVal value As String)
                strOutDoNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutTrainId
        ''' </summary>
        ''' <value>lngOutTrainId</value>
        ''' <returns> Return lngOutTrainId</returns>
        ''' <remarks> Get or Set the Value of OutTrainId  </remarks>
        '''
        Public Property OutTrainId() as Long
            Get
                Return lngOutTrainId
            End Get
            Set(ByVal value As Long)
                lngOutTrainId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutPortId
        ''' </summary>
        ''' <value>lngOutPortId</value>
        ''' <returns> Return lngOutPortId</returns>
        ''' <remarks> Get or Set the Value of OutPortId  </remarks>
        '''
        Public Property OutPortId() as Long
            Get
                Return lngOutPortId
            End Get
            Set(ByVal value As Long)
                lngOutPortId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutEquipmentId
        ''' </summary>
        ''' <value>lngOutEquipmentId</value>
        ''' <returns> Return lngOutEquipmentId</returns>
        ''' <remarks> Get or Set the Value of OutEquipmentId  </remarks>
        '''
        Public Property OutEquipmentId() as Long
            Get
                Return lngOutEquipmentId
            End Get
            Set(ByVal value As Long)
                lngOutEquipmentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutEirNo
        ''' </summary>
        ''' <value>strOutEirNo</value>
        ''' <returns> Return strOutEirNo</returns>
        ''' <remarks> Get or Set the Value of OutEirNo  </remarks>
        '''
        Public Property OutEirNo() as String
            Get
                Return strOutEirNo
            End Get
            Set(ByVal value As String)
                strOutEirNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutSurveyorId
        ''' </summary>
        ''' <value>lngOutSurveyorId</value>
        ''' <returns> Return lngOutSurveyorId</returns>
        ''' <remarks> Get or Set the Value of OutSurveyorId  </remarks>
        '''
        Public Property OutSurveyorId() as Long
            Get
                Return lngOutSurveyorId
            End Get
            Set(ByVal value As Long)
                lngOutSurveyorId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutCreatedBy
        ''' </summary>
        ''' <value>strOutCreatedBy</value>
        ''' <returns> Return strOutCreatedBy</returns>
        ''' <remarks> Get or Set the Value of OutCreatedBy  </remarks>
        '''
        Public Property OutCreatedBy() as String
            Get
                Return strOutCreatedBy
            End Get
            Set(ByVal value As String)
                strOutCreatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OutCreatedOn
        ''' </summary>
        ''' <value>strOutCreatedOn</value>
        ''' <returns> Return strOutCreatedOn</returns>
        ''' <remarks> Get or Set the Value of OutCreatedOn  </remarks>
        '''
        Public Property OutCreatedOn() as String
            Get
                Return strOutCreatedOn
            End Get
            Set(ByVal value As String)
                strOutCreatedOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of HoldId
        ''' </summary>
        ''' <value>lngHoldId</value>
        ''' <returns> Return lngHoldId</returns>
        ''' <remarks> Get or Set the Value of HoldId </remarks>
        '''
        Public Property HoldId() As Long
            Get
                Return lngHoldId
            End Get
            Set(ByVal value As Long)
                lngHoldId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FactoryOutDate
        ''' </summary>
        ''' <value>strFactoryOutDate</value>
        ''' <returns> Return strFactoryOutDate</returns>
        ''' <remarks> Get or Set the Value of FactoryOutDate </remarks>
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
        ''' Get or Set the Value of FactoryInDate
        ''' </summary>
        ''' <value>strFactoryInDate</value>
        ''' <returns> Return strFactoryOInDate</returns>
        ''' <remarks> Get or Set the Value of FactoryInDate </remarks>
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
            lngMtyContId = 0 
            lngMtyContGateInId = 0 
            lngDestuffImpContId = 0 
            strContNo = ""
            strContSize = ""
            strContType = ""
            strIsoCode = ""
            lngTareWt = 0 
            lngYardId = 0 
            lngInAgentId = 0 
            lngInChaId = 0 
            lngInLineId = 0 
            lngInBillToId = 0 
            strInDate = ""
            strInPassNo = ""
            strInMode = ""
            strInTruckNo = ""
            strInDriverName = ""
            lngInDamageId = 0 
            strInDamageDetails = ""
            lngInTransporterId = 0 
            strInTransMode = ""
            strInRemarks = ""
            strInBookingNo = ""
            strInBookingDate = ""
            strInCodeccoStatus = ""
            strInCodeccoDate = ""
            strInDoNo = ""
            lngInTrainId = 0 
            lngInPortId = 0 
            strInEirNo = ""
            lngInSurveyorId = 0 
            strInCreatedBy = ""
            strInCreatedOn = ""
            lngOutChaId = 0 
            lngOutAgentId = 0 
            lngOutLineId = 0 
            lngOutConsigneeId = 0 
            lngOutBillToId = 0 
            strOutPassNo = ""
            strOutDate = ""
            strOutMode = ""
            strOutTruckNo = ""
            lngOutTransporterId = 0 
            strOutTransMode = ""
            lngOutDamageId = 0 
            strOutDamageDetails = ""
            strOutRemarks = ""
            strOutBookingNo = ""
            strOutBookingDate = ""
            strOutCodeccoStatus = ""
            strOutCoddeccoDate = ""
            strOutDoNo = ""
            lngOutTrainId = 0 
            lngOutPortId = 0 
            lngOutEquipmentId = 0 
            strOutEirNo = ""
            lngOutSurveyorId = 0 
            strOutCreatedBy = ""
            strOutCreatedOn = ""
            lngHoldId = 0
            strFactoryOutDate = ""
            strFactoryInDate = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMtyContainers As MtyContainers) As MtyContainers
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContainers.MtyContGateInId)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_YARD_ID", pMtyContainers.YardId)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate, ParameterDirection.Output)
                db.AddParameter("p_IN_PASS_NO", pMtyContainers.InPassNo)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRUCK_NO", pMtyContainers.InTruckNo)
                db.AddParameter("p_IN_DRIVER_NAME", pMtyContainers.InDriverName)
                db.AddParameter("p_IN_DAMAGE_ID", pMtyContainers.InDamageId)
                db.AddParameter("p_IN_DAMAGE_DETAILS", pMtyContainers.InDamageDetails)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_BOOKING_NO", pMtyContainers.InBookingNo)
                db.AddParameter("p_IN_BOOKING_DATE", pMtyContainers.InBookingDate)
                db.AddParameter("p_IN_CODECCO_STATUS", pMtyContainers.InCodeccoStatus)
                db.AddParameter("p_IN_CODECCO_DATE", pMtyContainers.InCodeccoDate)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_TRAIN_ID", pMtyContainers.InTrainId)
                db.AddParameter("p_IN_PORT_ID", pMtyContainers.InPortId)
                db.AddParameter("p_IN_EIR_NO", pMtyContainers.InEirNo)
                db.AddParameter("p_IN_SURVEYOR_ID", pMtyContainers.InSurveyorId)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedOn)
                db.AddParameter("p_OUT_CHA_ID", pMtyContainers.OutChaId)
                db.AddParameter("p_OUT_AGENT_ID", pMtyContainers.OutAgentId)
                db.AddParameter("p_OUT_LINE_ID", pMtyContainers.OutLineId)
                db.AddParameter("p_OUT_CONSIGNEE_ID", pMtyContainers.OutConsigneeId)
                db.AddParameter("p_OUT_BILL_TO_ID", pMtyContainers.OutBillToId)
                db.AddParameter("p_OUT_PASS_NO", pMtyContainers.OutPassNo)
                db.AddParameter("p_OUT_DATE", pMtyContainers.OutDate)
                db.AddParameter("p_OUT_MODE", pMtyContainers.OutMode)
                db.AddParameter("p_OUT_TRUCK_NO", pMtyContainers.OutTruckNo)
                db.AddParameter("p_OUT_TRANSPORTER_ID", pMtyContainers.OutTransporterId)
                db.AddParameter("p_OUT_TRANS_MODE", pMtyContainers.OutTransMode)
                db.AddParameter("p_OUT_DAMAGE_ID", pMtyContainers.OutDamageId)
                db.AddParameter("p_OUT_DAMAGE_DETAILS", pMtyContainers.OutDamageDetails)
                db.AddParameter("p_OUT_REMARKS", pMtyContainers.OutRemarks)
                db.AddParameter("p_OUT_BOOKING_NO", pMtyContainers.OutBookingNo)
                db.AddParameter("p_OUT_BOOKING_DATE", pMtyContainers.OutBookingDate)
                db.AddParameter("p_OUT_CODECCO_STATUS", pMtyContainers.OutCodeccoStatus)
                db.AddParameter("p_OUT_CODDECCO_DATE", pMtyContainers.OutCoddeccoDate)
                db.AddParameter("p_OUT_DO_NO", pMtyContainers.OutDoNo)
                db.AddParameter("p_OUT_TRAIN_ID", pMtyContainers.OutTrainId)
                db.AddParameter("p_OUT_PORT_ID", pMtyContainers.OutPortId)
                db.AddParameter("p_OUT_EQUIPMENT_ID", pMtyContainers.OutEquipmentId)
                db.AddParameter("p_OUT_EIR_NO", pMtyContainers.OutEirNo)
                db.AddParameter("p_OUT_SURVEYOR_ID", pMtyContainers.OutSurveyorId)
                db.AddParameter("p_OUT_CREATED_BY", pMtyContainers.OutCreatedBy)
                db.AddParameter("p_OUT_CREATED_ON", pMtyContainers.OutCreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContainers.MtyContId  = db.Parameters.Item("p_MTY_CONT_ID").value
                
                If pMtyContainers.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContainers.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContainers.MtyContGateInId)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_YARD_ID", pMtyContainers.YardId)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate, ParameterDirection.Output)
                db.AddParameter("p_IN_PASS_NO", pMtyContainers.InPassNo)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRUCK_NO", pMtyContainers.InTruckNo)
                db.AddParameter("p_IN_DRIVER_NAME", pMtyContainers.InDriverName)
                db.AddParameter("p_IN_DAMAGE_ID", pMtyContainers.InDamageId)
                db.AddParameter("p_IN_DAMAGE_DETAILS", pMtyContainers.InDamageDetails)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_BOOKING_NO", pMtyContainers.InBookingNo)
                db.AddParameter("p_IN_BOOKING_DATE", pMtyContainers.InBookingDate)
                db.AddParameter("p_IN_CODECCO_STATUS", pMtyContainers.InCodeccoStatus)
                db.AddParameter("p_IN_CODECCO_DATE", pMtyContainers.InCodeccoDate)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_TRAIN_ID", pMtyContainers.InTrainId)
                db.AddParameter("p_IN_PORT_ID", pMtyContainers.InPortId)
                db.AddParameter("p_IN_EIR_NO", pMtyContainers.InEirNo)
                db.AddParameter("p_IN_SURVEYOR_ID", pMtyContainers.InSurveyorId)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedOn)
                db.AddParameter("p_OUT_CHA_ID", pMtyContainers.OutChaId)
                db.AddParameter("p_OUT_AGENT_ID", pMtyContainers.OutAgentId)
                db.AddParameter("p_OUT_LINE_ID", pMtyContainers.OutLineId)
                db.AddParameter("p_OUT_CONSIGNEE_ID", pMtyContainers.OutConsigneeId)
                db.AddParameter("p_OUT_BILL_TO_ID", pMtyContainers.OutBillToId)
                db.AddParameter("p_OUT_PASS_NO", pMtyContainers.OutPassNo)
                db.AddParameter("p_OUT_DATE", pMtyContainers.OutDate)
                db.AddParameter("p_OUT_MODE", pMtyContainers.OutMode)
                db.AddParameter("p_OUT_TRUCK_NO", pMtyContainers.OutTruckNo)
                db.AddParameter("p_OUT_TRANSPORTER_ID", pMtyContainers.OutTransporterId)
                db.AddParameter("p_OUT_TRANS_MODE", pMtyContainers.OutTransMode)
                db.AddParameter("p_OUT_DAMAGE_ID", pMtyContainers.OutDamageId)
                db.AddParameter("p_OUT_DAMAGE_DETAILS", pMtyContainers.OutDamageDetails)
                db.AddParameter("p_OUT_REMARKS", pMtyContainers.OutRemarks)
                db.AddParameter("p_OUT_BOOKING_NO", pMtyContainers.OutBookingNo)
                db.AddParameter("p_OUT_BOOKING_DATE", pMtyContainers.OutBookingDate)
                db.AddParameter("p_OUT_CODECCO_STATUS", pMtyContainers.OutCodeccoStatus)
                db.AddParameter("p_OUT_CODDECCO_DATE", pMtyContainers.OutCoddeccoDate)
                db.AddParameter("p_OUT_DO_NO", pMtyContainers.OutDoNo)
                db.AddParameter("p_OUT_TRAIN_ID", pMtyContainers.OutTrainId)
                db.AddParameter("p_OUT_PORT_ID", pMtyContainers.OutPortId)
                db.AddParameter("p_OUT_EQUIPMENT_ID", pMtyContainers.OutEquipmentId)
                db.AddParameter("p_OUT_EIR_NO", pMtyContainers.OutEirNo)
                db.AddParameter("p_OUT_SURVEYOR_ID", pMtyContainers.OutSurveyorId)
                db.AddParameter("p_OUT_CREATED_BY", pMtyContainers.OutCreatedBy)
                db.AddParameter("p_OUT_CREATED_ON", pMtyContainers.OutCreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContainers.MtyContId  = db.Parameters.Item("p_MTY_CONT_ID").value
                
            Catch ex As Exception
                pMtyContainers.ErrorMsg = ex.Message
            End Try
            Return pMtyContainers
        End Function
        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMtyContainers As MtyContainers) As MtyContainers
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContainers.MtyContGateInId)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_YARD_ID", pMtyContainers.YardId)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate)
                db.AddParameter("p_IN_PASS_NO", pMtyContainers.InPassNo)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRUCK_NO", pMtyContainers.InTruckNo)
                db.AddParameter("p_IN_DRIVER_NAME", pMtyContainers.InDriverName)
                db.AddParameter("p_IN_DAMAGE_ID", pMtyContainers.InDamageId)
                db.AddParameter("p_IN_DAMAGE_DETAILS", pMtyContainers.InDamageDetails)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_BOOKING_NO", pMtyContainers.InBookingNo)
                db.AddParameter("p_IN_BOOKING_DATE", pMtyContainers.InBookingDate)
                db.AddParameter("p_IN_CODECCO_STATUS", pMtyContainers.InCodeccoStatus)
                db.AddParameter("p_IN_CODECCO_DATE", pMtyContainers.InCodeccoDate)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_TRAIN_ID", pMtyContainers.InTrainId)
                db.AddParameter("p_IN_PORT_ID", pMtyContainers.InPortId)
                db.AddParameter("p_IN_EIR_NO", pMtyContainers.InEirNo)
                db.AddParameter("p_IN_SURVEYOR_ID", pMtyContainers.InSurveyorId)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedOn)
                db.AddParameter("p_OUT_CHA_ID", pMtyContainers.OutChaId)
                db.AddParameter("p_OUT_AGENT_ID", pMtyContainers.OutAgentId)
                db.AddParameter("p_OUT_LINE_ID", pMtyContainers.OutLineId)
                db.AddParameter("p_OUT_CONSIGNEE_ID", pMtyContainers.OutConsigneeId)
                db.AddParameter("p_OUT_BILL_TO_ID", pMtyContainers.OutBillToId)
                db.AddParameter("p_OUT_PASS_NO", pMtyContainers.OutPassNo)
                db.AddParameter("p_OUT_DATE", pMtyContainers.OutDate, ParameterDirection.Output)
                db.AddParameter("p_OUT_MODE", pMtyContainers.OutMode)
                db.AddParameter("p_OUT_TRUCK_NO", pMtyContainers.OutTruckNo)
                db.AddParameter("p_OUT_TRANSPORTER_ID", pMtyContainers.OutTransporterId)
                db.AddParameter("p_OUT_TRANS_MODE", pMtyContainers.OutTransMode)
                db.AddParameter("p_OUT_DAMAGE_ID", pMtyContainers.OutDamageId)
                db.AddParameter("p_OUT_DAMAGE_DETAILS", pMtyContainers.OutDamageDetails)
                db.AddParameter("p_OUT_REMARKS", pMtyContainers.OutRemarks)
                db.AddParameter("p_OUT_BOOKING_NO", pMtyContainers.OutBookingNo)
                db.AddParameter("p_OUT_BOOKING_DATE", pMtyContainers.OutBookingDate)
                db.AddParameter("p_OUT_CODECCO_STATUS", pMtyContainers.OutCodeccoStatus)
                db.AddParameter("p_OUT_CODDECCO_DATE", pMtyContainers.OutCoddeccoDate)
                db.AddParameter("p_OUT_DO_NO", pMtyContainers.OutDoNo)
                db.AddParameter("p_OUT_TRAIN_ID", pMtyContainers.OutTrainId)
                db.AddParameter("p_OUT_PORT_ID", pMtyContainers.OutPortId)
                db.AddParameter("p_OUT_EQUIPMENT_ID", pMtyContainers.OutEquipmentId)
                db.AddParameter("p_OUT_EIR_NO", pMtyContainers.OutEirNo)
                db.AddParameter("p_OUT_SURVEYOR_ID", pMtyContainers.OutSurveyorId)
                db.AddParameter("p_OUT_CREATED_BY", pMtyContainers.OutCreatedBy)
                db.AddParameter("p_OUT_CREATED_ON", pMtyContainers.OutCreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyContainers.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContainers.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContainers.MtyContGateInId)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_YARD_ID", pMtyContainers.YardId)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate)
                db.AddParameter("p_IN_PASS_NO", pMtyContainers.InPassNo)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRUCK_NO", pMtyContainers.InTruckNo)
                db.AddParameter("p_IN_DRIVER_NAME", pMtyContainers.InDriverName)
                db.AddParameter("p_IN_DAMAGE_ID", pMtyContainers.InDamageId)
                db.AddParameter("p_IN_DAMAGE_DETAILS", pMtyContainers.InDamageDetails)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_BOOKING_NO", pMtyContainers.InBookingNo)
                db.AddParameter("p_IN_BOOKING_DATE", pMtyContainers.InBookingDate)
                db.AddParameter("p_IN_CODECCO_STATUS", pMtyContainers.InCodeccoStatus)
                db.AddParameter("p_IN_CODECCO_DATE", pMtyContainers.InCodeccoDate)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_TRAIN_ID", pMtyContainers.InTrainId)
                db.AddParameter("p_IN_PORT_ID", pMtyContainers.InPortId)
                db.AddParameter("p_IN_EIR_NO", pMtyContainers.InEirNo)
                db.AddParameter("p_IN_SURVEYOR_ID", pMtyContainers.InSurveyorId)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedOn)
                db.AddParameter("p_OUT_CHA_ID", pMtyContainers.OutChaId)
                db.AddParameter("p_OUT_AGENT_ID", pMtyContainers.OutAgentId)
                db.AddParameter("p_OUT_LINE_ID", pMtyContainers.OutLineId)
                db.AddParameter("p_OUT_CONSIGNEE_ID", pMtyContainers.OutConsigneeId)
                db.AddParameter("p_OUT_BILL_TO_ID", pMtyContainers.OutBillToId)
                db.AddParameter("p_OUT_PASS_NO", pMtyContainers.OutPassNo)
                db.AddParameter("p_OUT_DATE", pMtyContainers.OutDate, ParameterDirection.Output)
                db.AddParameter("p_OUT_MODE", pMtyContainers.OutMode)
                db.AddParameter("p_OUT_TRUCK_NO", pMtyContainers.OutTruckNo)
                db.AddParameter("p_OUT_TRANSPORTER_ID", pMtyContainers.OutTransporterId)
                db.AddParameter("p_OUT_TRANS_MODE", pMtyContainers.OutTransMode)
                db.AddParameter("p_OUT_DAMAGE_ID", pMtyContainers.OutDamageId)
                db.AddParameter("p_OUT_DAMAGE_DETAILS", pMtyContainers.OutDamageDetails)
                db.AddParameter("p_OUT_REMARKS", pMtyContainers.OutRemarks)
                db.AddParameter("p_OUT_BOOKING_NO", pMtyContainers.OutBookingNo)
                db.AddParameter("p_OUT_BOOKING_DATE", pMtyContainers.OutBookingDate)
                db.AddParameter("p_OUT_CODECCO_STATUS", pMtyContainers.OutCodeccoStatus)
                db.AddParameter("p_OUT_CODDECCO_DATE", pMtyContainers.OutCoddeccoDate)
                db.AddParameter("p_OUT_DO_NO", pMtyContainers.OutDoNo)
                db.AddParameter("p_OUT_TRAIN_ID", pMtyContainers.OutTrainId)
                db.AddParameter("p_OUT_PORT_ID", pMtyContainers.OutPortId)
                db.AddParameter("p_OUT_EQUIPMENT_ID", pMtyContainers.OutEquipmentId)
                db.AddParameter("p_OUT_EIR_NO", pMtyContainers.OutEirNo)
                db.AddParameter("p_OUT_SURVEYOR_ID", pMtyContainers.OutSurveyorId)
                db.AddParameter("p_OUT_CREATED_BY", pMtyContainers.OutCreatedBy)
                db.AddParameter("p_OUT_CREATED_ON", pMtyContainers.OutCreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMtyContainers.ErrorMsg = ex.Message
                End Try
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrnImp(ByVal db As DBConnect, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_YARD_ID", pMtyContainers.YardId)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate, ParameterDirection.Output)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRUCK_NO", pMtyContainers.InTruckNo)
                db.AddParameter("p_IN_DRIVER_NAME", pMtyContainers.InDriverName)
                db.AddParameter("p_IN_DAMAGE_ID", pMtyContainers.InDamageId)
                db.AddParameter("p_IN_DAMAGE_DETAILS", pMtyContainers.InDamageDetails)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_EIR_NO", pMtyContainers.InEirNo)
                db.AddParameter("p_IN_SURVEYOR_ID", pMtyContainers.InSurveyorId)
                db.AddParameter("p_FACTORY_OUT_DATE", pMtyContainers.FactoryOutDate)
                db.AddParameter("p_FACTORY_IN_DATE", pMtyContainers.FactoryInDate)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_ErrorMsg", pMtyContainers.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONTAINERS_IMP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContainers.InDate = db.Parameters.Item("p_IN_DATE").value

            Catch ex As Exception
                pMtyContainers.Errormsg = ex.Message
            End Try
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMtyContainers.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                PMtyContainers.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_GATE_IN_ID").ToString <> "" Then
                                PMtyContainers.MtyContGateInId = dbr("MTY_CONT_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESTUFF_IMP_CONT_ID").ToString <> "" Then
                                PMtyContainers.DestuffImpContId = dbr("DESTUFF_IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PMtyContainers.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PMtyContainers.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PMtyContainers.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE").ToString <> "" Then
                                PMtyContainers.IsoCode = dbr("ISO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                PMtyContainers.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_ID").ToString <> "" Then
                                PMtyContainers.YardId = dbr("YARD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_AGENT_ID").ToString <> "" Then
                                PMtyContainers.InAgentId = dbr("IN_AGENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CHA_ID").ToString <> "" Then
                                PMtyContainers.InChaId = dbr("IN_CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_LINE_ID").ToString <> "" Then
                                PMtyContainers.InLineId = dbr("IN_LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BILL_TO_ID").ToString <> "" Then
                                PMtyContainers.InBillToId = dbr("IN_BILL_TO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DATE").ToString <> "" Then
                                PMtyContainers.InDate = dbr("IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_PASS_NO").ToString <> "" Then
                                PMtyContainers.InPassNo = dbr("IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_MODE").ToString <> "" Then
                                PMtyContainers.InMode = dbr("IN_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRUCK_NO").ToString <> "" Then
                                PMtyContainers.InTruckNo = dbr("IN_TRUCK_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DRIVER_NAME").ToString <> "" Then
                                PMtyContainers.InDriverName = dbr("IN_DRIVER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DAMAGE_ID").ToString <> "" Then
                                PMtyContainers.InDamageId = dbr("IN_DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DAMAGE_DETAILS").ToString <> "" Then
                                PMtyContainers.InDamageDetails = dbr("IN_DAMAGE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRANSPORTER_ID").ToString <> "" Then
                                PMtyContainers.InTransporterId = dbr("IN_TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRANS_MODE").ToString <> "" Then
                                PMtyContainers.InTransMode = dbr("IN_TRANS_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_REMARKS").ToString <> "" Then
                                PMtyContainers.InRemarks = dbr("IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BOOKING_NO").ToString <> "" Then
                                PMtyContainers.InBookingNo = dbr("IN_BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BOOKING_DATE").ToString <> "" Then
                                PMtyContainers.InBookingDate = dbr("IN_BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CODECCO_STATUS").ToString <> "" Then
                                PMtyContainers.InCodeccoStatus = dbr("IN_CODECCO_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CODECCO_DATE").ToString <> "" Then
                                PMtyContainers.InCodeccoDate = dbr("IN_CODECCO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DO_NO").ToString <> "" Then
                                PMtyContainers.InDoNo = dbr("IN_DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRAIN_ID").ToString <> "" Then
                                PMtyContainers.InTrainId = dbr("IN_TRAIN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_PORT_ID").ToString <> "" Then
                                PMtyContainers.InPortId = dbr("IN_PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_EIR_NO").ToString <> "" Then
                                PMtyContainers.InEirNo = dbr("IN_EIR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_SURVEYOR_ID").ToString <> "" Then
                                PMtyContainers.InSurveyorId = dbr("IN_SURVEYOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CREATED_BY").ToString <> "" Then
                                PMtyContainers.InCreatedBy = dbr("IN_CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CREATED_ON").ToString <> "" Then
                                PMtyContainers.InCreatedOn = dbr("IN_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CHA_ID").ToString <> "" Then
                                PMtyContainers.OutChaId = dbr("OUT_CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_AGENT_ID").ToString <> "" Then
                                PMtyContainers.OutAgentId = dbr("OUT_AGENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_LINE_ID").ToString <> "" Then
                                PMtyContainers.OutLineId = dbr("OUT_LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CONSIGNEE_ID").ToString <> "" Then
                                PMtyContainers.OutConsigneeId = dbr("OUT_CONSIGNEE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BILL_TO_ID").ToString <> "" Then
                                PMtyContainers.OutBillToId = dbr("OUT_BILL_TO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PASS_NO").ToString <> "" Then
                                PMtyContainers.OutPassNo = dbr("OUT_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DATE").ToString <> "" Then
                                PMtyContainers.OutDate = dbr("OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_MODE").ToString <> "" Then
                                PMtyContainers.OutMode = dbr("OUT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRUCK_NO").ToString <> "" Then
                                PMtyContainers.OutTruckNo = dbr("OUT_TRUCK_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRANSPORTER_ID").ToString <> "" Then
                                PMtyContainers.OutTransporterId = dbr("OUT_TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRANS_MODE").ToString <> "" Then
                                PMtyContainers.OutTransMode = dbr("OUT_TRANS_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DAMAGE_ID").ToString <> "" Then
                                PMtyContainers.OutDamageId = dbr("OUT_DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DAMAGE_DETAILS").ToString <> "" Then
                                PMtyContainers.OutDamageDetails = dbr("OUT_DAMAGE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_REMARKS").ToString <> "" Then
                                PMtyContainers.OutRemarks = dbr("OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BOOKING_NO").ToString <> "" Then
                                PMtyContainers.OutBookingNo = dbr("OUT_BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BOOKING_DATE").ToString <> "" Then
                                PMtyContainers.OutBookingDate = dbr("OUT_BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CODECCO_STATUS").ToString <> "" Then
                                PMtyContainers.OutCodeccoStatus = dbr("OUT_CODECCO_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CODDECCO_DATE").ToString <> "" Then
                                PMtyContainers.OutCoddeccoDate = dbr("OUT_CODDECCO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DO_NO").ToString <> "" Then
                                PMtyContainers.OutDoNo = dbr("OUT_DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRAIN_ID").ToString <> "" Then
                                PMtyContainers.OutTrainId = dbr("OUT_TRAIN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PORT_ID").ToString <> "" Then
                                PMtyContainers.OutPortId = dbr("OUT_PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_EQUIPMENT_ID").ToString <> "" Then
                                PMtyContainers.OutEquipmentId = dbr("OUT_EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_EIR_NO").ToString <> "" Then
                                PMtyContainers.OutEirNo = dbr("OUT_EIR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_SURVEYOR_ID").ToString <> "" Then
                                PMtyContainers.OutSurveyorId = dbr("OUT_SURVEYOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CREATED_BY").ToString <> "" Then
                                PMtyContainers.OutCreatedBy = dbr("OUT_CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CREATED_ON").ToString <> "" Then
                                PMtyContainers.OutCreatedOn = dbr("OUT_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                pMtyContainers.HoldId = dbr("HOLD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMtyContainers.ErrorMsg = ex.Message
            End Try
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyContainers As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MtyContainers
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("MTY_CONT_GATE_IN_ID").ToString <> "" Then
                                temp.MtyContGateInId = dbr("MTY_CONT_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESTUFF_IMP_CONT_ID").ToString <> "" Then
                                temp.DestuffImpContId = dbr("DESTUFF_IMP_CONT_ID")
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
                            If dbr("ISO_CODE").ToString <> "" Then
                                temp.IsoCode = dbr("ISO_CODE")
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
                            If dbr("YARD_ID").ToString <> "" Then
                                temp.YardId = dbr("YARD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_AGENT_ID").ToString <> "" Then
                                temp.InAgentId = dbr("IN_AGENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CHA_ID").ToString <> "" Then
                                temp.InChaId = dbr("IN_CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_LINE_ID").ToString <> "" Then
                                temp.InLineId = dbr("IN_LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BILL_TO_ID").ToString <> "" Then
                                temp.InBillToId = dbr("IN_BILL_TO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DATE").ToString <> "" Then
                                temp.InDate = dbr("IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_PASS_NO").ToString <> "" Then
                                temp.InPassNo = dbr("IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_MODE").ToString <> "" Then
                                temp.InMode = dbr("IN_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRUCK_NO").ToString <> "" Then
                                temp.InTruckNo = dbr("IN_TRUCK_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DRIVER_NAME").ToString <> "" Then
                                temp.InDriverName = dbr("IN_DRIVER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DAMAGE_ID").ToString <> "" Then
                                temp.InDamageId = dbr("IN_DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DAMAGE_DETAILS").ToString <> "" Then
                                temp.InDamageDetails = dbr("IN_DAMAGE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRANSPORTER_ID").ToString <> "" Then
                                temp.InTransporterId = dbr("IN_TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRANS_MODE").ToString <> "" Then
                                temp.InTransMode = dbr("IN_TRANS_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_REMARKS").ToString <> "" Then
                                temp.InRemarks = dbr("IN_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BOOKING_NO").ToString <> "" Then
                                temp.InBookingNo = dbr("IN_BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_BOOKING_DATE").ToString <> "" Then
                                temp.InBookingDate = dbr("IN_BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CODECCO_STATUS").ToString <> "" Then
                                temp.InCodeccoStatus = dbr("IN_CODECCO_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CODECCO_DATE").ToString <> "" Then
                                temp.InCodeccoDate = dbr("IN_CODECCO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_DO_NO").ToString <> "" Then
                                temp.InDoNo = dbr("IN_DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_TRAIN_ID").ToString <> "" Then
                                temp.InTrainId = dbr("IN_TRAIN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_PORT_ID").ToString <> "" Then
                                temp.InPortId = dbr("IN_PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_EIR_NO").ToString <> "" Then
                                temp.InEirNo = dbr("IN_EIR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_SURVEYOR_ID").ToString <> "" Then
                                temp.InSurveyorId = dbr("IN_SURVEYOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CREATED_BY").ToString <> "" Then
                                temp.InCreatedBy = dbr("IN_CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_CREATED_ON").ToString <> "" Then
                                temp.InCreatedOn = dbr("IN_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CHA_ID").ToString <> "" Then
                                temp.OutChaId = dbr("OUT_CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_AGENT_ID").ToString <> "" Then
                                temp.OutAgentId = dbr("OUT_AGENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_LINE_ID").ToString <> "" Then
                                temp.OutLineId = dbr("OUT_LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CONSIGNEE_ID").ToString <> "" Then
                                temp.OutConsigneeId = dbr("OUT_CONSIGNEE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BILL_TO_ID").ToString <> "" Then
                                temp.OutBillToId = dbr("OUT_BILL_TO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PASS_NO").ToString <> "" Then
                                temp.OutPassNo = dbr("OUT_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DATE").ToString <> "" Then
                                temp.OutDate = dbr("OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_MODE").ToString <> "" Then
                                temp.OutMode = dbr("OUT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRUCK_NO").ToString <> "" Then
                                temp.OutTruckNo = dbr("OUT_TRUCK_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRANSPORTER_ID").ToString <> "" Then
                                temp.OutTransporterId = dbr("OUT_TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRANS_MODE").ToString <> "" Then
                                temp.OutTransMode = dbr("OUT_TRANS_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DAMAGE_ID").ToString <> "" Then
                                temp.OutDamageId = dbr("OUT_DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DAMAGE_DETAILS").ToString <> "" Then
                                temp.OutDamageDetails = dbr("OUT_DAMAGE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_REMARKS").ToString <> "" Then
                                temp.OutRemarks = dbr("OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BOOKING_NO").ToString <> "" Then
                                temp.OutBookingNo = dbr("OUT_BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_BOOKING_DATE").ToString <> "" Then
                                temp.OutBookingDate = dbr("OUT_BOOKING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CODECCO_STATUS").ToString <> "" Then
                                temp.OutCodeccoStatus = dbr("OUT_CODECCO_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CODDECCO_DATE").ToString <> "" Then
                                temp.OutCoddeccoDate = dbr("OUT_CODDECCO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_DO_NO").ToString <> "" Then
                                temp.OutDoNo = dbr("OUT_DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_TRAIN_ID").ToString <> "" Then
                                temp.OutTrainId = dbr("OUT_TRAIN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PORT_ID").ToString <> "" Then
                                temp.OutPortId = dbr("OUT_PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_EQUIPMENT_ID").ToString <> "" Then
                                temp.OutEquipmentId = dbr("OUT_EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_EIR_NO").ToString <> "" Then
                                temp.OutEirNo = dbr("OUT_EIR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_SURVEYOR_ID").ToString <> "" Then
                                temp.OutSurveyorId = dbr("OUT_SURVEYOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CREATED_BY").ToString <> "" Then
                                temp.OutCreatedBy = dbr("OUT_CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_CREATED_ON").ToString <> "" Then
                                temp.OutCreatedOn = dbr("OUT_CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                temp.HoldId = dbr("HOLD_ID")
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
        ''' Preparing Return Object By TerminalId, MtyContId or MtyContGateInId or DestuffImpContId or ContNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyContainers(ByVal pMtyContainers As MtyContainers) As MtyContainers
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONTAINERS_BY_IDS", pMtyContainers.TerminalId & "," & pMtyContainers.MtyContId & "," & pMtyContainers.DestuffImpContId & "," & pMtyContainers.InLineId & ",'" & pMtyContainers.ContNo & "'")
                pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
                dbr.Close()
            Catch ex As Exception
                pMtyContainers.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContainersListAll(ByVal pMtyContainers As MtyContainers) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContainers As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONTAINERS_BY_IDS", pMtyContainers.TerminalId & "," & pMtyContainers.MtyContId & "," & pMtyContainers.MtyContGateInId & "," & pMtyContainers.DestuffImpContId & "," & pMtyContainers.InLineId & ",'" & pMtyContainers.ContNo & "'")
                arrMtyContainers = ReturnObjectValuesList(dbr, arrMtyContainers)
                dbr.Close()
            Catch ex As Exception
                arrMtyContainers = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContainers
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContainersListForAllot(ByVal pMtyContainers As MtyContainers) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContainers As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_LIST_ALLOT", pMtyContainers.TerminalId & "," & pMtyContainers.InLineId & "," & pMtyContainers.InTransporterId)
                arrMtyContainers = ReturnObjectValuesList(dbr, arrMtyContainers)
                dbr.Close()
            Catch ex As Exception
                arrMtyContainers = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContainers
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContainersList (ByVal pMtyContainers As MtyContainers) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContainers As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONTAINERS", "' '")
                arrMtyContainers = ReturnObjectValuesList(dbr, arrMtyContainers)
                dbr.Close()
            Catch ex As Exception
                arrMtyContainers = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContainers
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnStuffed(ByVal db As DBConnect, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContainers.MtyContGateInId)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContainers.DestuffImpContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_ISO_CODE", pMtyContainers.IsoCode)
                db.AddParameter("p_TARE_WT", pMtyContainers.TareWt)
                db.AddParameter("p_IN_CHA_ID", pMtyContainers.InChaId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_BILL_TO_ID", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate, ParameterDirection.Output)
                db.AddParameter("p_IN_PASS_NO", pMtyContainers.InPassNo, ParameterDirection.Output)
                db.AddParameter("p_IN_MODE", pMtyContainers.InMode)
                db.AddParameter("p_IN_TRANSPORTER_ID", pMtyContainers.InTransporterId)
                db.AddParameter("p_IN_TRANS_MODE", pMtyContainers.InTransMode)
                db.AddParameter("p_IN_REMARKS", pMtyContainers.InRemarks)
                db.AddParameter("p_IN_BOOKING_NO", pMtyContainers.InBookingNo)
                db.AddParameter("p_IN_BOOKING_DATE", pMtyContainers.InBookingDate)
                db.AddParameter("p_IN_PORT_ID", pMtyContainers.InPortId)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContainers.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONTAINERS_STUFFED", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContainers.MtyContId = db.Parameters.Item("p_MTY_CONT_ID").value
                pMtyContainers.InDate = db.Parameters.Item("p_IN_DATE").value.ToString
                pMtyContainers.InPassNo = db.Parameters.Item("p_IN_PASS_NO").value.ToString
            Catch ex As Exception
                pMtyContainers.Errormsg = ex.Message
            End Try
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, MtyContId or MtyContGateInId or DestuffImpContId or ContNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyContForYardLoc(ByVal pMtyContainers As MtyContainers) As MtyContainers
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_FOR_YARD_LOC", pMtyContainers.TerminalId & "," & pMtyContainers.MtyContId & ",'" & pMtyContainers.ContNo & "'")
                pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
                dbr.Close()
                If pMtyContainers.MtyContId = 0 Then
                    pMtyContainers.Errormsg = "Invalid Container Number."
                ElseIf pMtyContainers.InDate = Nothing Then
                    pMtyContainers.Errormsg = "Container not Gate In"
                ElseIf pMtyContainers.OutDate <> Nothing Then
                    pMtyContainers.Errormsg = "Container  Gated Out"
                End If
            Catch ex As Exception
                pMtyContainers.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContainers
        End Function
        Public Shared Function ReturnMtyContainersValidate(ByVal pMtyContainers As MtyContainers) As MtyContainers
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_ALLOT_EXP", pMtyContainers.TerminalId & "," & pMtyContainers.InLineId & "," & pMtyContainers.OutPortId & ",'" & pMtyContainers.ContNo & "'")
                pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
                dbr.Close()
            Catch ex As Exception
                pMtyContainers.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContainers
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContainers"></param>
        ''' <returns>Return pMtyContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrnLineConvesrion(ByVal db As DBConnect, ByVal pMtyContainers As MtyContainers) As MtyContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContainers.TerminalId)
                db.AddParameter("p_MTY_CONT_ID", pMtyContainers.MtyContId)
                db.AddParameter("p_CONT_NO", pMtyContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyContainers.ContType)
                db.AddParameter("p_IN_AGENT_ID", pMtyContainers.InAgentId)
                db.AddParameter("p_IN_DO_NO", pMtyContainers.InDoNo)
                db.AddParameter("p_IN_BILL_TO", pMtyContainers.InBillToId)
                db.AddParameter("p_IN_LINE_ID", pMtyContainers.InLineId)
                db.AddParameter("p_IN_CODECCO_DATE", pMtyContainers.InCodeccoDate)
                db.AddParameter("p_IN_DATE", pMtyContainers.InDate)
                db.AddParameter("p_IN_CREATED_BY", pMtyContainers.InCreatedBy)
                db.AddParameter("p_IN_CREATED_ON", pMtyContainers.InCreatedBy)
                db.AddParameter("p_ErrorMsg", pMtyContainers.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_SHIPPING_LINE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContainers.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContainers.InDate = db.Parameters.Item("p_IN_DATE").value

            Catch ex As Exception
                pMtyContainers.Errormsg = ex.Message
            End Try
            Return pMtyContainers
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContainersListForReworking(ByVal pMtyContainers As MtyContainers) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContainers As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_REWORKING_LIST", pMtyContainers.TerminalId & "," & pMtyContainers.InLineId & ",'" & pMtyContainers.ContSize & "','" & pMtyContainers.ContType & "','" & pMtyContainers.ContNo & "'")
                arrMtyContainers = ReturnObjectValuesList(dbr, arrMtyContainers)
                dbr.Close()
            Catch ex As Exception
                arrMtyContainers = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContainers
        End Function

       
    End Class
End Namespace
