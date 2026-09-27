Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetVehicleStatus
    ''' @author	: Santosh Singh- 31/7/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetVehicleStatus 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngStatusId As Long ' Define Private Variable StatusId With DataType As Long 
        Private lngVehicleId As Long ' Define Private Variable VehicleId With DataType As Long 
        Private strVehicleNo As String ' Define Private Variable VehicleNo With DataType As String 
        Private lngVehicleSize As Long ' Define Private Variable VehicleSize With DataType As Long 
        Private lngGrNo As Long ' Define Private Variable GrNo With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strToViaJry As String ' Define Private Variable ToViaJry With DataType As String 
        Private strProgramDate As String
        Private strIcdOut As String ' Define Private Variable IcdOut With DataType As String 
        Private strFactoryIn As String ' Define Private Variable FactoryIn With DataType As String 
        Private strFactoryOut As String ' Define Private Variable FactoryOut With DataType As String 
        Private strAllotMentDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strBufferDate As String ' Define Private Variable FactoryOut With DataType As String 
        Private strIcdIn As String ' Define Private Variable IcdIn With DataType As String 
        Private strHrs0 As String ' Define Private Variable Hrs0 With DataType As String 
        Private strHrs4 As String ' Define Private Variable Hrs4 With DataType As String 
        Private strHrs8 As String ' Define Private Variable Hrs8 With DataType As String 
        Private strHrs12 As String ' Define Private Variable Hrs12 With DataType As String 
        Private strHrs16 As String ' Define Private Variable Hrs16 With DataType As String 
        Private strHrs20 As String ' Define Private Variable Hrs20 With DataType As String 
        Private strHrs24 As String ' Define Private Variable Hrs24 With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private dblDisIcd As Double ' Define Private Variable GrNo With DataType As Long 
        Private strPortOffLoad As String ' Define Private Variable IcdOut With DataType As String 

                    
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
        ''' Get or Set the Value of StatusId
        ''' </summary>
        ''' <value>lngStatusId</value>
        ''' <returns> Return lngStatusId</returns>
        ''' <remarks> Get or Set the Value of StatusId  </remarks>
        '''
        Public Property StatusId() as Long
            Get
                Return lngStatusId
            End Get
            Set(ByVal value As Long)
                lngStatusId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of StatusId
        ''' </summary>
        ''' <value>lngStatusId</value>
        ''' <returns> Return lngStatusId</returns>
        ''' <remarks> Get or Set the Value of StatusId  </remarks>
        '''
        Public Property DisIcd() As Double
            Get
                Return dblDisIcd

            End Get
            Set(ByVal value As Double)
                dblDisIcd = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VehicleId
        ''' </summary>
        ''' <value>lngVehicleId</value>
        ''' <returns> Return lngVehicleId</returns>
        ''' <remarks> Get or Set the Value of VehicleId  </remarks>
        '''
        Public Property VehicleId() as Long
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
        Public Property VehicleNo() as String
            Get
                Return strVehicleNo
            End Get
            Set(ByVal value As String)
                strVehicleNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VehicleSize
        ''' </summary>
        ''' <value>lngVehicleSize</value>
        ''' <returns> Return lngVehicleSize</returns>
        ''' <remarks> Get or Set the Value of VehicleSize  </remarks>
        '''
        Public Property VehicleSize() as Long
            Get
                Return lngVehicleSize
            End Get
            Set(ByVal value As Long)
                lngVehicleSize = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of VehicleSize
        ''' </summary>
        ''' <value>lngVehicleSize</value>
        ''' <returns> Return lngVehicleSize</returns>
        ''' <remarks> Get or Set the Value of VehicleSize  </remarks>
        '''
        Public Property PortOffLoad() As String
            Get
                Return strPortOffLoad
            End Get
            Set(ByVal value As String)
                strPortOffLoad = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of GrNo
        ''' </summary>
        ''' <value>lngGrNo</value>
        ''' <returns> Return lngGrNo</returns>
        ''' <remarks> Get or Set the Value of GrNo  </remarks>
        '''
        Public Property GrNo() as Long
            Get
                Return lngGrNo
            End Get
            Set(ByVal value As Long)
                lngGrNo = value
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
        ''' Get or Set the Value of ToViaJry
        ''' </summary>
        ''' <value>strToViaJry</value>
        ''' <returns> Return strToViaJry</returns>
        ''' <remarks> Get or Set the Value of ToViaJry  </remarks>
        '''
        Public Property ToViaJry() as String
            Get
                Return strToViaJry
            End Get
            Set(ByVal value As String)
                strToViaJry = value
            End Set
        End Property

        Public Property ProgramDate() As String
            Get
                Return strProgramDate
            End Get
            Set(ByVal value As String)
                strProgramDate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IcdOut
        ''' </summary>
        ''' <value>strIcdOut</value>
        ''' <returns> Return strIcdOut</returns>
        ''' <remarks> Get or Set the Value of IcdOut  </remarks>
        '''
        Public Property IcdOut() as String
            Get
                Return strIcdOut
            End Get
            Set(ByVal value As String)
                strIcdOut = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FactoryIn
        ''' </summary>
        ''' <value>strFactoryIn</value>
        ''' <returns> Return strFactoryIn</returns>
        ''' <remarks> Get or Set the Value of FactoryIn  </remarks>
        '''
        Public Property FactoryIn() as String
            Get
                Return strFactoryIn
            End Get
            Set(ByVal value As String)
                strFactoryIn = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FactoryOut
        ''' </summary>
        ''' <value>strFactoryOut</value>
        ''' <returns> Return strFactoryOut</returns>
        ''' <remarks> Get or Set the Value of FactoryOut  </remarks>
        '''
        Public Property FactoryOut() as String
            Get
                Return strFactoryOut
            End Get
            Set(ByVal value As String)
                strFactoryOut = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IcdIn
        ''' </summary>
        ''' <value>strIcdIn</value>
        ''' <returns> Return strIcdIn</returns>
        ''' <remarks> Get or Set the Value of IcdIn  </remarks>
        '''
        Public Property IcdIn() as String
            Get
                Return strIcdIn
            End Get
            Set(ByVal value As String)
                strIcdIn = value
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
        ''' Get or Set the Value of Hrs0
        ''' </summary>
        ''' <value>strHrs0</value>
        ''' <returns> Return strHrs0</returns>
        ''' <remarks> Get or Set the Value of Hrs0  </remarks>
        '''
        Public Property Hrs0() as String
            Get
                Return strHrs0
            End Get
            Set(ByVal value As String)
                strHrs0 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs4
        ''' </summary>
        ''' <value>strHrs4</value>
        ''' <returns> Return strHrs4</returns>
        ''' <remarks> Get or Set the Value of Hrs4  </remarks>
        '''
        Public Property Hrs4() as String
            Get
                Return strHrs4
            End Get
            Set(ByVal value As String)
                strHrs4 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs8
        ''' </summary>
        ''' <value>strHrs8</value>
        ''' <returns> Return strHrs8</returns>
        ''' <remarks> Get or Set the Value of Hrs8  </remarks>
        '''
        Public Property Hrs8() as String
            Get
                Return strHrs8
            End Get
            Set(ByVal value As String)
                strHrs8 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs12
        ''' </summary>
        ''' <value>strHrs12</value>
        ''' <returns> Return strHrs12</returns>
        ''' <remarks> Get or Set the Value of Hrs12  </remarks>
        '''
        Public Property Hrs12() as String
            Get
                Return strHrs12
            End Get
            Set(ByVal value As String)
                strHrs12 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs16
        ''' </summary>
        ''' <value>strHrs16</value>
        ''' <returns> Return strHrs16</returns>
        ''' <remarks> Get or Set the Value of Hrs16  </remarks>
        '''
        Public Property Hrs16() as String
            Get
                Return strHrs16
            End Get
            Set(ByVal value As String)
                strHrs16 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs20
        ''' </summary>
        ''' <value>strHrs20</value>
        ''' <returns> Return strHrs20</returns>
        ''' <remarks> Get or Set the Value of Hrs20  </remarks>
        '''
        Public Property Hrs20() as String
            Get
                Return strHrs20
            End Get
            Set(ByVal value As String)
                strHrs20 = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Hrs24
        ''' </summary>
        ''' <value>strHrs24</value>
        ''' <returns> Return strHrs24</returns>
        ''' <remarks> Get or Set the Value of Hrs24  </remarks>
        '''
        Public Property Hrs24() as String
            Get
                Return strHrs24
            End Get
            Set(ByVal value As String)
                strHrs24 = value
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
            lngStatusId = 0 
            lngVehicleId = 0
            DisIcd = 0
            strVehicleNo = ""
            lngVehicleSize = 0 
            lngGrNo = 0 
            strContNo = ""
            strToViaJry = ""
            strProgramDate = ""
            strIcdOut = ""
            strFactoryIn = ""
            strFactoryOut = ""
            strAllotMentDate = ""
            strBufferDate = ""
            strIcdIn = ""
            strHrs0 = ""
            strHrs4 = ""
            strHrs8 = ""
            strHrs12 = ""
            strHrs16 = ""
            strHrs20 = ""
            strHrs24 = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strPortOffLoad = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetVehicleStatus"></param>
        ''' <returns>Return pFleetVehicleStatus Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetVehicleStatus.TerminalId)
                db.AddParameter("p_STATUS_ID", pFleetVehicleStatus.StatusId)
                db.AddParameter("p_VEHICLE_ID", pFleetVehicleStatus.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetVehicleStatus.VehicleNo)
                db.AddParameter("p_VEHICLE_SIZE", pFleetVehicleStatus.VehicleSize)
                db.AddParameter("p_GR_NO", pFleetVehicleStatus.GrNo)
                db.AddParameter("p_CONT_NO", pFleetVehicleStatus.ContNo)
                db.AddParameter("p_TO_VIA_JRY", pFleetVehicleStatus.ToViaJry)
                db.AddParameter("p_ICD_OUT", pFleetVehicleStatus.IcdOut)
                db.AddParameter("p_FACTORY_IN", pFleetVehicleStatus.FactoryIn)
                db.AddParameter("p_FACTORY_OUT", pFleetVehicleStatus.FactoryOut)
                db.AddParameter("p_ICD_IN", pFleetVehicleStatus.IcdIn)
                db.AddParameter("p_HRS0", pFleetVehicleStatus.Hrs0)
                db.AddParameter("p_HRS4", pFleetVehicleStatus.Hrs4)
                db.AddParameter("p_HRS8", pFleetVehicleStatus.Hrs8)
                db.AddParameter("p_HRS12", pFleetVehicleStatus.Hrs12)
                db.AddParameter("p_HRS16", pFleetVehicleStatus.Hrs16)
                db.AddParameter("p_HRS20", pFleetVehicleStatus.Hrs20)
                db.AddParameter("p_HRS24", pFleetVehicleStatus.Hrs24)
                db.AddParameter("p_CREATED_BY", pFleetVehicleStatus.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetVehicleStatus.CreatedOn)
                db.AddParameter("p_PORT_OFFLOAD", pFleetVehicleStatus.PortOffLoad)
                db.AddParameter("p_ErrorMsg", pFleetVehicleStatus.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_VEHICLE_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetVehicleStatus.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pFleetVehicleStatus.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetVehicleStatus.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetVehicleStatus"></param>
        ''' <returns>Return pFleetVehicleStatus Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetVehicleStatus.TerminalId)
                db.AddParameter("p_STATUS_ID", pFleetVehicleStatus.StatusId)
                db.AddParameter("p_VEHICLE_ID", pFleetVehicleStatus.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetVehicleStatus.VehicleNo)
                db.AddParameter("p_VEHICLE_SIZE", pFleetVehicleStatus.VehicleSize)
                db.AddParameter("p_GR_NO", pFleetVehicleStatus.GrNo)
                db.AddParameter("p_CONT_NO", pFleetVehicleStatus.ContNo)
                db.AddParameter("p_TO_VIA_JRY", pFleetVehicleStatus.ToViaJry)
                db.AddParameter("p_ICD_OUT", pFleetVehicleStatus.IcdOut)
                db.AddParameter("p_FACTORY_IN", pFleetVehicleStatus.FactoryIn)
                db.AddParameter("p_FACTORY_OUT", pFleetVehicleStatus.FactoryOut)
                db.AddParameter("p_ICD_IN", pFleetVehicleStatus.IcdIn)
                db.AddParameter("p_HRS0", pFleetVehicleStatus.Hrs0)
                db.AddParameter("p_HRS4", pFleetVehicleStatus.Hrs4)
                db.AddParameter("p_HRS8", pFleetVehicleStatus.Hrs8)
                db.AddParameter("p_HRS12", pFleetVehicleStatus.Hrs12)
                db.AddParameter("p_HRS16", pFleetVehicleStatus.Hrs16)
                db.AddParameter("p_HRS20", pFleetVehicleStatus.Hrs20)
                db.AddParameter("p_HRS24", pFleetVehicleStatus.Hrs24)
                db.AddParameter("p_CREATED_BY", pFleetVehicleStatus.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetVehicleStatus.CreatedOn)
                db.AddParameter("p_PORT_OFFLOAD", pFleetVehicleStatus.PortOffLoad)
                db.AddParameter("p_ErrorMsg", pFleetVehicleStatus.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_VEHICLE_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetVehicleStatus.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pFleetVehicleStatus.ErrorMsg = ex.Message
            End Try
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetVehicleStatus"></param>
        ''' <returns>Return pFleetVehicleStatus Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetVehicleStatus.TerminalId)
                db.AddParameter("p_STATUS_ID", pFleetVehicleStatus.StatusId)
                db.AddParameter("p_VEHICLE_ID", pFleetVehicleStatus.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetVehicleStatus.VehicleNo)
                db.AddParameter("p_VEHICLE_SIZE", pFleetVehicleStatus.VehicleSize)
                db.AddParameter("p_GR_NO", pFleetVehicleStatus.GrNo)
                db.AddParameter("p_CONT_NO", pFleetVehicleStatus.ContNo)
                db.AddParameter("p_TO_VIA_JRY", pFleetVehicleStatus.ToViaJry)
                db.AddParameter("p_ICD_OUT", pFleetVehicleStatus.IcdOut)
                db.AddParameter("p_FACTORY_IN", pFleetVehicleStatus.FactoryIn)
                db.AddParameter("p_FACTORY_OUT", pFleetVehicleStatus.FactoryOut)
                db.AddParameter("p_ICD_IN", pFleetVehicleStatus.IcdIn)
                db.AddParameter("p_HRS0", pFleetVehicleStatus.Hrs0)
                db.AddParameter("p_HRS4", pFleetVehicleStatus.Hrs4)
                db.AddParameter("p_HRS8", pFleetVehicleStatus.Hrs8)
                db.AddParameter("p_HRS12", pFleetVehicleStatus.Hrs12)
                db.AddParameter("p_HRS16", pFleetVehicleStatus.Hrs16)
                db.AddParameter("p_HRS20", pFleetVehicleStatus.Hrs20)
                db.AddParameter("p_HRS24", pFleetVehicleStatus.Hrs24)
                db.AddParameter("p_CREATED_BY", pFleetVehicleStatus.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetVehicleStatus.CreatedOn)
                db.AddParameter("p_DIS_ICD", pFleetVehicleStatus.DisIcd)
                db.AddParameter("p_PORT_OFFLOAD", pFleetVehicleStatus.PortOffLoad)
                db.AddParameter("p_ErrorMsg", pFleetVehicleStatus.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_VEHICLE_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetVehicleStatus.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetVehicleStatus.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetVehicleStatus.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetVehicleStatus"></param>
        ''' <returns>Return pFleetVehicleStatus Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetVehicleStatus.TerminalId)
                db.AddParameter("p_STATUS_ID", pFleetVehicleStatus.StatusId)
                db.AddParameter("p_VEHICLE_ID", pFleetVehicleStatus.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetVehicleStatus.VehicleNo)
                db.AddParameter("p_VEHICLE_SIZE", pFleetVehicleStatus.VehicleSize)
                db.AddParameter("p_GR_NO", pFleetVehicleStatus.GrNo)
                db.AddParameter("p_CONT_NO", pFleetVehicleStatus.ContNo)
                db.AddParameter("p_TO_VIA_JRY", pFleetVehicleStatus.ToViaJry)
                db.AddParameter("p_ICD_OUT", pFleetVehicleStatus.IcdOut)
                db.AddParameter("p_FACTORY_IN", pFleetVehicleStatus.FactoryIn)
                db.AddParameter("p_FACTORY_OUT", pFleetVehicleStatus.FactoryOut)
                db.AddParameter("p_ICD_IN", pFleetVehicleStatus.IcdIn)
                db.AddParameter("p_HRS0", pFleetVehicleStatus.Hrs0)
                db.AddParameter("p_HRS4", pFleetVehicleStatus.Hrs4)
                db.AddParameter("p_HRS8", pFleetVehicleStatus.Hrs8)
                db.AddParameter("p_HRS12", pFleetVehicleStatus.Hrs12)
                db.AddParameter("p_HRS16", pFleetVehicleStatus.Hrs16)
                db.AddParameter("p_HRS20", pFleetVehicleStatus.Hrs20)
                db.AddParameter("p_HRS24", pFleetVehicleStatus.Hrs24)
                db.AddParameter("p_CREATED_BY", pFleetVehicleStatus.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetVehicleStatus.CreatedOn)
                db.AddParameter("p_DIS_ICD", pFleetVehicleStatus.DisIcd)

                db.AddParameter("p_PORT_OFFLOAD", pFleetVehicleStatus.PortOffLoad)
                db.AddParameter("p_ErrorMsg", pFleetVehicleStatus.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_VEHICLE_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetVehicleStatus.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetVehicleStatus.ErrorMsg = ex.Message
                End Try
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetVehicleStatus.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS_ID").ToString <> "" Then
                                PFleetVehicleStatus.StatusId = dbr("STATUS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                PFleetVehicleStatus.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                PFleetVehicleStatus.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_SIZE").ToString <> "" Then
                                PFleetVehicleStatus.VehicleSize = dbr("VEHICLE_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_NO").ToString <> "" Then
                                PFleetVehicleStatus.GrNo = dbr("GR_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PFleetVehicleStatus.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_VIA_JRY").ToString <> "" Then
                                PFleetVehicleStatus.ToViaJry = dbr("TO_VIA_JRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT").ToString <> "" Then
                                PFleetVehicleStatus.IcdOut = dbr("ICD_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN").ToString <> "" Then
                                PFleetVehicleStatus.FactoryIn = dbr("FACTORY_IN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT").ToString <> "" Then
                                PFleetVehicleStatus.FactoryOut = dbr("FACTORY_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN").ToString <> "" Then
                                pFleetVehicleStatus.IcdIn = dbr("ICD_IN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOTMENT_DATE").ToString <> "" Then
                                pFleetVehicleStatus.AllotMentDate = dbr("ALLOTMENT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BUFFER_DATE").ToString <> "" Then
                                pFleetVehicleStatus.BufferDate = dbr("BUFFER_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS0").ToString <> "" Then
                                PFleetVehicleStatus.Hrs0 = dbr("HRS0")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS4").ToString <> "" Then
                                PFleetVehicleStatus.Hrs4 = dbr("HRS4")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS8").ToString <> "" Then
                                PFleetVehicleStatus.Hrs8 = dbr("HRS8")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS12").ToString <> "" Then
                                PFleetVehicleStatus.Hrs12 = dbr("HRS12")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS16").ToString <> "" Then
                                PFleetVehicleStatus.Hrs16 = dbr("HRS16")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS20").ToString <> "" Then
                                PFleetVehicleStatus.Hrs20 = dbr("HRS20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS24").ToString <> "" Then
                                PFleetVehicleStatus.Hrs24 = dbr("HRS24")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetVehicleStatus.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetVehicleStatus.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIS_ICD").ToString <> "" Then
                                pFleetVehicleStatus.DisIcd = dbr("DIS_ICD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_OFFLOAD").ToString <> "" Then
                                pFleetVehicleStatus.PortOffLoad = dbr("PORT_OFFLOAD")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetVehicleStatus.ErrorMsg = ex.Message
            End Try
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetVehicleStatus As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetVehicleStatus
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS_ID").ToString <> "" Then
                                temp.StatusId = dbr("STATUS_ID")
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
                            If dbr("VEHICLE_SIZE").ToString <> "" Then
                                temp.VehicleSize = dbr("VEHICLE_SIZE")
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
                            If dbr("CONT_NO").ToString <> "" Then
                                temp.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_VIA_JRY").ToString <> "" Then
                                temp.ToViaJry = dbr("TO_VIA_JRY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_OUT").ToString <> "" Then
                                temp.IcdOut = dbr("ICD_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_IN").ToString <> "" Then
                                temp.FactoryIn = dbr("FACTORY_IN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FACTORY_OUT").ToString <> "" Then
                                temp.FactoryOut = dbr("FACTORY_OUT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ICD_IN").ToString <> "" Then
                                temp.IcdIn = dbr("ICD_IN")
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
                            If dbr("HRS0").ToString <> "" Then
                                temp.Hrs0 = dbr("HRS0")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS4").ToString <> "" Then
                                temp.Hrs4 = dbr("HRS4")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS8").ToString <> "" Then
                                temp.Hrs8 = dbr("HRS8")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS12").ToString <> "" Then
                                temp.Hrs12 = dbr("HRS12")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS16").ToString <> "" Then
                                temp.Hrs16 = dbr("HRS16")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS20").ToString <> "" Then
                                temp.Hrs20 = dbr("HRS20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HRS24").ToString <> "" Then
                                temp.Hrs24 = dbr("HRS24")
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
                            If dbr("DIS_ICD").ToString <> "" Then
                                temp.DisIcd = dbr("DIS_ICD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_OFFLOAD").ToString <> "" Then
                                temp.PortOffLoad = dbr("PORT_OFFLOAD")
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
        Public Shared Function ReturnFleetVehicleStatus(ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_VEHICLE_STATUS", pFleetVehicleStatus.TerminalId & "," & pFleetVehicleStatus.GrNo)
                pFleetVehicleStatus = ReturnObjectValues(dbr, pFleetVehicleStatus)
                dbr.Close()
            Catch ex As Exception
                pFleetVehicleStatus.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetVehicleStatus
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFleetVehicleGRId(ByVal pFleetVehicleStatus As FleetVehicleStatus) As FleetVehicleStatus
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_ID", pFleetVehicleStatus.TerminalId & "," & pFleetVehicleStatus.GrNo)
                pFleetVehicleStatus = ReturnObjectValues(dbr, pFleetVehicleStatus)
                dbr.Close()
            Catch ex As Exception
                pFleetVehicleStatus.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetVehicleStatus
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetVehicleStatusList (ByVal pFleetVehicleStatus As FleetVehicleStatus) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetVehicleStatus As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_VEHICLE_STATUS_BY_ID", pFleetVehicleStatus.TerminalId & "," & pFleetVehicleStatus.VehicleId & ",'" & pFleetVehicleStatus.VehicleNo & "','" & pFleetVehicleStatus.ToViaJry & "'," & pFleetVehicleStatus.StatusId)
                arrFleetVehicleStatus = ReturnObjectValuesList(dbr, arrFleetVehicleStatus)
                dbr.Close()
            Catch ex As Exception
                arrFleetVehicleStatus = Nothing
            End Try
            db.CloseDB()
            Return arrFleetVehicleStatus
        End Function
    End Class
End Namespace
