Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyVehicleGateIn
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MtyVehicleGateIn
        Public Enum enmDocType As Long
            Import = 1
            Export = 2
            Empty = 3
        End Enum
        Public Enum enmVhStatus As Long
            Empty = 1
            ICD = 2
            Warehouse = 3
        End Enum
        Public Enum enmInMode As Long
            Cargo = 1
            Container = 2
            Empty = 3
        End Enum
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMtyVhGateInId As Long ' Define Private Variable MtyVhGateInId With DataType As Long 
        Private strMtyInPassNo As String ' Define Private Variable MtyInPassNo With DataType As String 
        Private strMtyInPassDate As String ' Define Private Variable MtyInPassDate With DataType As String 
        Private strMtyGateInDate As String ' Define Private Variable MtyGateInDate With DataType As String 
        Private lngMtyVhInJoId As Long ' Define Private Variable MtyVhInJoId With DataType As Long 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private lngTransporterId As Long ' Define Private Variable TransporterId With DataType As Long 
        Private lngChaId As Long ' Define Private Variable ChaId With DataType As Long 
        Private strVehicleType As String ' Define Private Variable VehicleType With DataType As String 
        Private strVehicleNo As String ' Define Private Variable VehicleNo With DataType As String 
        Private strDriverName As String ' Define Private Variable DriverName With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strGateOutDate As String ' Define Private Variable GateOutDate With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strVhStatus As String ' Define Private Variable VhStatus With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngImpVhGateOutJoId As Long ' Define Private Variable ImpVhGateOutJoId With DataType As Long 
        Private strOutPassNo As String ' Define Private Variable OutPassNo With DataType As String 
        Private strOutPassDate As String ' Define Private Variable OutPassDate With DataType As String 
        Private strOutRemarks As String ' Define Private Variable OutRemarks With DataType As String 
        Private strInMode As String ' Define Private Variable InMode With DataType As String 

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
        ''' Get or Set the Value of MtyVhGateInId
        ''' </summary>
        ''' <value>lngMtyVhGateInId</value>
        ''' <returns> Return lngMtyVhGateInId</returns>
        ''' <remarks> Get or Set the Value of MtyVhGateInId  </remarks>
        '''
        Public Property MtyVhGateInId() As Long
            Get
                Return lngMtyVhGateInId
            End Get
            Set(ByVal value As Long)
                lngMtyVhGateInId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyInPassNo
        ''' </summary>
        ''' <value>strMtyInPassNo</value>
        ''' <returns> Return strMtyInPassNo</returns>
        ''' <remarks> Get or Set the Value of MtyInPassNo  </remarks>
        '''
        Public Property MtyInPassNo() As String
            Get
                Return strMtyInPassNo
            End Get
            Set(ByVal value As String)
                strMtyInPassNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyInPassDate
        ''' </summary>
        ''' <value>strMtyInPassDate</value>
        ''' <returns> Return strMtyInPassDate</returns>
        ''' <remarks> Get or Set the Value of MtyInPassDate  </remarks>
        '''
        Public Property MtyInPassDate() As String
            Get
                Return strMtyInPassDate
            End Get
            Set(ByVal value As String)
                strMtyInPassDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyGateInDate
        ''' </summary>
        ''' <value>strMtyGateInDate</value>
        ''' <returns> Return strMtyGateInDate</returns>
        ''' <remarks> Get or Set the Value of MtyGateInDate  </remarks>
        '''
        Public Property MtyGateInDate() As String
            Get
                Return strMtyGateInDate
            End Get
            Set(ByVal value As String)
                strMtyGateInDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyVhInJoId
        ''' </summary>
        ''' <value>lngMtyVhInJoId</value>
        ''' <returns> Return lngMtyVhInJoId</returns>
        ''' <remarks> Get or Set the Value of MtyVhInJoId  </remarks>
        '''
        Public Property MtyVhInJoId() As Long
            Get
                Return lngMtyVhInJoId
            End Get
            Set(ByVal value As Long)
                lngMtyVhInJoId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
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
        ''' Get or Set the Value of ChaId
        ''' </summary>
        ''' <value>lngChaId</value>
        ''' <returns> Return lngChaId</returns>
        ''' <remarks> Get or Set the Value of ChaId  </remarks>
        '''
        Public Property ChaId() As Long
            Get
                Return lngChaId
            End Get
            Set(ByVal value As Long)
                lngChaId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VehicleType
        ''' </summary>
        ''' <value>strVehicleType</value>
        ''' <returns> Return strVehicleType</returns>
        ''' <remarks> Get or Set the Value of VehicleType  </remarks>
        '''
        Public Property VehicleType() As String
            Get
                Return strVehicleType
            End Get
            Set(ByVal value As String)
                strVehicleType = value
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
        ''' Get or Set the Value of DriverName
        ''' </summary>
        ''' <value>strDriverName</value>
        ''' <returns> Return strDriverName</returns>
        ''' <remarks> Get or Set the Value of DriverName  </remarks>
        '''
        Public Property DriverName() As String
            Get
                Return strDriverName
            End Get
            Set(ByVal value As String)
                strDriverName = value
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


        ''' <summary>
        ''' Get or Set the Value of GateOutDate
        ''' </summary>
        ''' <value>strGateOutDate</value>
        ''' <returns> Return strGateOutDate</returns>
        ''' <remarks> Get or Set the Value of GateOutDate  </remarks>
        '''
        Public Property GateOutDate() As String
            Get
                Return strGateOutDate
            End Get
            Set(ByVal value As String)
                strGateOutDate = value
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
        ''' Get or Set the Value of VhStatus
        ''' </summary>
        ''' <value>strVhStatus</value>
        ''' <returns> Return strVhStatus</returns>
        ''' <remarks> Get or Set the Value of VhStatus  </remarks>
        '''
        Public Property VhStatus() As String
            Get
                Return strVhStatus
            End Get
            Set(ByVal value As String)
                strVhStatus = value
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
        ''' Get or Set the Value of ImpVhGateOutJoId
        ''' </summary>
        ''' <value>lngImpVhGateOutJoId</value>
        ''' <returns> Return lngImpVhGateOutJoId</returns>
        ''' <remarks> Get or Set the Value of ImpVhGateOutJoId  </remarks>
        '''
        Public Property ImpVhGateOutJoId() As Long
            Get
                Return lngImpVhGateOutJoId
            End Get
            Set(ByVal value As Long)
                lngImpVhGateOutJoId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OutPassNo
        ''' </summary>
        ''' <value>strOutPassNo</value>
        ''' <returns> Return strOutPassNo</returns>
        ''' <remarks> Get or Set the Value of OutPassNo  </remarks>
        '''
        Public Property OutPassNo() As String
            Get
                Return strOutPassNo
            End Get
            Set(ByVal value As String)
                strOutPassNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OutPassDate
        ''' </summary>
        ''' <value>strOutPassDate</value>
        ''' <returns> Return strOutPassDate</returns>
        ''' <remarks> Get or Set the Value of OutPassDate  </remarks>
        '''
        Public Property OutPassDate() As String
            Get
                Return strOutPassDate
            End Get
            Set(ByVal value As String)
                strOutPassDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OutRemarks
        ''' </summary>
        ''' <value>strOutRemarks</value>
        ''' <returns> Return strOutRemarks</returns>
        ''' <remarks> Get or Set the Value of OutRemarks  </remarks>
        '''
        Public Property OutRemarks() As String
            Get
                Return strOutRemarks
            End Get
            Set(ByVal value As String)
                strOutRemarks = value
            End Set
        End Property

        Public Property InMode() As String
            Get
                Return strInMode
            End Get
            Set(ByVal value As String)
                strInMode = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngMtyVhGateInId = 0
            strMtyInPassNo = ""
            strMtyInPassDate = ""
            strMtyGateInDate = ""
            lngMtyVhInJoId = 0
            strDocType = ""
            lngTransporterId = 0
            lngChaId = 0
            strVehicleType = ""
            strVehicleNo = ""
            strDriverName = ""
            strRemarks = ""
            strGateOutDate = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            strVhStatus = ""
            lngImpVhGateOutJoId = 0
            strOutPassNo = ""
            strOutPassDate = ""
            strOutRemarks = ""
            strInMode = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId, ParameterDirection.Output)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_VEHICLE_GATE_IN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVehicleGateIn.MtyVhGateInId = db.Parameters.Item("p_MTY_VH_GATE_IN_ID").value
                pMtyVehicleGateIn.MtyInPassNo = db.Parameters.Item("p_MTY_IN_PASS_NO").value
                pMtyVehicleGateIn.MtyInPassDate = db.Parameters.Item("p_MTY_IN_PASS_DATE").value

                If pMtyVehicleGateIn.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId, ParameterDirection.Output)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_VEHICLE_GATE_IN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVehicleGateIn.MtyVhGateInId = db.Parameters.Item("p_MTY_VH_GATE_IN_ID").value
                pMtyVehicleGateIn.MtyInPassNo = db.Parameters.Item("p_MTY_IN_PASS_NO").value
                pMtyVehicleGateIn.MtyInPassDate = db.Parameters.Item("p_MTY_IN_PASS_DATE").value


            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VEHICLE_GATE_IN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyVehicleGateIn.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VEHICLE_GATE_IN", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrnOutJoId_OutPass(ByVal db As DBConnect, ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo, ParameterDirection.Output)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate, ParameterDirection.Output)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VEHICLE_GATE_JO_PASS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVehicleGateIn.OutPassNo = db.Parameters.Item("p_OUT_PASS_NO").value
                pMtyVehicleGateIn.OutPassDate = db.Parameters.Item("p_OUT_PASS_DATE").value

            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Update Member Function to Update the Gate_Out_Date,Out_Remarks
        ''' </summary>
        ''' <param name="pMtyVehicleGateIn"></param>
        ''' <returns>Return pMtyVehicleGateIn Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateGateOutDate(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVehicleGateIn.TerminalId)
                db.AddParameter("p_MTY_VH_GATE_IN_ID", pMtyVehicleGateIn.MtyVhGateInId)
                db.AddParameter("p_MTY_IN_PASS_NO", pMtyVehicleGateIn.MtyInPassNo)
                db.AddParameter("p_MTY_IN_PASS_DATE", pMtyVehicleGateIn.MtyInPassDate)
                db.AddParameter("p_MTY_GATE_IN_DATE", pMtyVehicleGateIn.MtyGateInDate)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.MtyVhInJoId)
                db.AddParameter("p_DOC_TYPE", pMtyVehicleGateIn.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVehicleGateIn.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVehicleGateIn.ChaId)
                db.AddParameter("p_VEHICLE_TYPE", pMtyVehicleGateIn.VehicleType)
                db.AddParameter("p_VEHICLE_NO", pMtyVehicleGateIn.VehicleNo)
                db.AddParameter("p_DRIVER_NAME", pMtyVehicleGateIn.DriverName)
                db.AddParameter("p_REMARKS", pMtyVehicleGateIn.Remarks)
                db.AddParameter("p_GATE_OUT_DATE", pMtyVehicleGateIn.GateOutDate)
                db.AddParameter("p_CREATED_BY", pMtyVehicleGateIn.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVehicleGateIn.CreatedOn)
                db.AddParameter("p_VH_STATUS", pMtyVehicleGateIn.VhStatus)
                db.AddParameter("p_IMP_VH_GATE_OUT_JO_ID", pMtyVehicleGateIn.ImpVhGateOutJoId)
                db.AddParameter("p_OUT_PASS_NO", pMtyVehicleGateIn.OutPassNo)
                db.AddParameter("p_OUT_PASS_DATE", pMtyVehicleGateIn.OutPassDate)
                db.AddParameter("p_OUT_REMARKS", pMtyVehicleGateIn.OutRemarks)
                db.AddParameter("p_IN_MODE", pMtyVehicleGateIn.InMode)
                db.AddParameter("p_ErrorMsg", pMtyVehicleGateIn.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VH_GATE_IN_GATE_OUT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVehicleGateIn.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyVehicleGateIn.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function



        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pMtyVehicleGateIn.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_GATE_IN_ID").ToString <> "" Then
                                pMtyVehicleGateIn.MtyVhGateInId = dbr("MTY_VH_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_IN_PASS_NO").ToString <> "" Then
                                pMtyVehicleGateIn.MtyInPassNo = dbr("MTY_IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_IN_PASS_DATE").ToString <> "" Then
                                pMtyVehicleGateIn.MtyInPassDate = dbr("MTY_IN_PASS_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_GATE_IN_DATE").ToString <> "" Then
                                pMtyVehicleGateIn.MtyGateInDate = dbr("MTY_GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_ID").ToString <> "" Then
                                pMtyVehicleGateIn.MtyVhInJoId = dbr("MTY_VH_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                pMtyVehicleGateIn.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                pMtyVehicleGateIn.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                pMtyVehicleGateIn.ChaId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                pMtyVehicleGateIn.VehicleType = dbr("VEHICLE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                pMtyVehicleGateIn.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_NAME").ToString <> "" Then
                                pMtyVehicleGateIn.DriverName = dbr("DRIVER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pMtyVehicleGateIn.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_OUT_DATE").ToString <> "" Then
                                pMtyVehicleGateIn.GateOutDate = dbr("GATE_OUT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pMtyVehicleGateIn.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pMtyVehicleGateIn.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VH_STATUS").ToString <> "" Then
                                pMtyVehicleGateIn.VhStatus = dbr("VH_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_VH_GATE_OUT_JO_ID").ToString <> "" Then
                                pMtyVehicleGateIn.ImpVhGateOutJoId = dbr("IMP_VH_GATE_OUT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PASS_NO").ToString <> "" Then
                                pMtyVehicleGateIn.OutPassNo = dbr("OUT_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_PASS_DATE").ToString <> "" Then
                                pMtyVehicleGateIn.OutPassDate = dbr("OUT_PASS_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OUT_REMARKS").ToString <> "" Then
                                pMtyVehicleGateIn.OutRemarks = dbr("OUT_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IN_MODE").ToString <> "" Then
                                pMtyVehicleGateIn.InMode = dbr("IN_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyVehicleGateIn As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MtyVehicleGateIn
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_GATE_IN_ID").ToString <> "" Then
                                temp.MtyVhGateInId = dbr("MTY_VH_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_IN_PASS_NO").ToString <> "" Then
                                temp.MtyInPassNo = dbr("MTY_IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_IN_PASS_DATE").ToString <> "" Then
                                temp.MtyInPassDate = dbr("MTY_IN_PASS_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_GATE_IN_DATE").ToString <> "" Then
                                temp.MtyGateInDate = dbr("MTY_GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_ID").ToString <> "" Then
                                temp.MtyVhInJoId = dbr("MTY_VH_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
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
                            If dbr("CHA_ID").ToString <> "" Then
                                temp.ChaId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                temp.VehicleType = dbr("VEHICLE_TYPE")
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
                            If dbr("DRIVER_NAME").ToString <> "" Then
                                temp.DriverName = dbr("DRIVER_NAME")
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
                            If dbr("GATE_OUT_DATE").ToString <> "" Then
                                temp.GateOutDate = dbr("GATE_OUT_DATE")
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
                            If dbr("VH_STATUS").ToString <> "" Then
                                temp.VhStatus = dbr("VH_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_VH_GATE_OUT_JO_ID").ToString <> "" Then
                                temp.ImpVhGateOutJoId = dbr("IMP_VH_GATE_OUT_JO_ID")
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
                            If dbr("OUT_PASS_DATE").ToString <> "" Then
                                temp.OutPassDate = dbr("OUT_PASS_DATE")
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
                            If dbr("IN_MODE").ToString <> "" Then
                                temp.InMode = dbr("IN_MODE")
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
        Public Shared Function ReturnMtyVehicleGateIn(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VEHICLE_GATE_IN", "' '")
                pMtyVehicleGateIn = ReturnObjectValues(dbr, pMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, MtyVhInJoId, MtyVhGateInID
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInList(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_GATE_IN_BY_JO_ID", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.MtyVhInJoId & "," & pMtyVehicleGateIn.MtyVhGateInId)
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, ImpMtyVhGateOutJoId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInListByOutJoId(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_GATE_IN_BY_OUT_JO_ID", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.ImpVhGateOutJoId & ",'" & pMtyVehicleGateIn.OutPassNo & "'")
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, ChaId, TransporterId, DocType, VhStatus
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInListAllByCha_Transporter_DocType_VhStatus(ByVal pMtyVehicleGateIn As MtyVehicleGateIn, ByVal pDocType As enmDocType, ByVal pVhStatus As enmVhStatus, ByVal pInMode As enmInMode) As ArrayList
            If enmDocType.Import = pDocType Then
                pMtyVehicleGateIn.DocType = "I"
            ElseIf enmDocType.Export = pDocType Then
                pMtyVehicleGateIn.DocType = "E"
            ElseIf enmDocType.Empty = pDocType Then
                pMtyVehicleGateIn.DocType = "M"
            End If

            If enmVhStatus.Empty = pVhStatus Then
                pMtyVehicleGateIn.VhStatus = "E"
            ElseIf enmVhStatus.ICD = pVhStatus Then
                pMtyVehicleGateIn.VhStatus = "I"
            ElseIf enmVhStatus.Warehouse = pVhStatus Then
                pMtyVehicleGateIn.VhStatus = "W"
            End If
            If enmInMode.Empty = pInMode Then
                pMtyVehicleGateIn.InMode = "M"
            ElseIf enmInMode.Cargo = pInMode Then
                pMtyVehicleGateIn.InMode = "G"
            ElseIf enmInMode.Container = pInMode Then
                pMtyVehicleGateIn.InMode = "R"
            End If

            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_BY_CHA_TPR_DOC_STS", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.ChaId & "," & pMtyVehicleGateIn.TransporterId & ",'" & pMtyVehicleGateIn.DocType & "','" & pMtyVehicleGateIn.VhStatus & "','" & pMtyVehicleGateIn.InMode & "'")
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function
        ''' <summary>
        ''' Preparing Return Object BY TerminalId, MtyInPassNo or OutPassNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInByGatePass(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VEHICLE_GATE_IN_BY_NO", pMtyVehicleGateIn.TerminalId & ",'" & pMtyVehicleGateIn.MtyInPassNo & "','" & pMtyVehicleGateIn.OutPassNo & "'")
                pMtyVehicleGateIn = ReturnObjectValues(dbr, pMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function
        ''' <summary>
        ''' Preparing Return Object BY TerminalId, Vehicle No
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInByVehicleNo(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As MtyVehicleGateIn
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VH_GATE_IN_VH_NO", pMtyVehicleGateIn.TerminalId & ",'" & pMtyVehicleGateIn.VehicleNo & "'")
                pMtyVehicleGateIn = ReturnObjectValues(dbr, pMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                pMtyVehicleGateIn.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyVehicleGateIn
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, ImpMtyVhGateOutJoId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInListByBookingId(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_IN_JO_ID", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.MtyVhInJoId & ",'" & pMtyVehicleGateIn.DocType & "'")
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, MtyVhInJoId, MtyVhGateInID
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVehicleGateInListDom(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_IN_OUT_JO", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.TransporterId & ",'" & pMtyVehicleGateIn.DocType & "'")
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function

        Public Shared Function ReturnMtyVehicleGateInListAllByTransporterId(ByVal pMtyVehicleGateIn As MtyVehicleGateIn) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVehicleGateIn As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_BY_TRANSPORTER_ID", pMtyVehicleGateIn.TerminalId & "," & pMtyVehicleGateIn.TransporterId)
                arrMtyVehicleGateIn = ReturnObjectValuesList(dbr, arrMtyVehicleGateIn)
                dbr.Close()
            Catch ex As Exception
                arrMtyVehicleGateIn = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVehicleGateIn
        End Function

    End Class

End Namespace
