Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VesselService
    ''' @author	: Amit K. Singh- 2/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VesselService 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strVcnNo As String ' Define Private Variable VcnNo With DataType As String 
        Private strVoyNo As String ' Define Private Variable VoyNo With DataType As String 
        Private strIgmNo As String ' Define Private Variable IgmNo With DataType As String 
        Private strIgmDate As String ' Define Private Variable IgmDate With DataType As String 
        Private strIgmReceivedDate As String ' Define Private Variable IgmReceivedDate With DataType As String 
        Private strVesselNo As String ' Define Private Variable VesselNo With DataType As String 
        Private lngVesselId As Long ' Define Private Variable VesselId With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private strArrivalDate As String ' Define Private Variable ArrivalDate With DataType As String 
        Private strGateOpenDate As String ' Define Private Variable GateOpenDate With DataType As String 
        Private strCutOfDate As String ' Define Private Variable CutOfDate With DataType As String 
        Private strBirthingDate As String ' Define Private Variable BirthingDate With DataType As String 
        Private strDepartureDate As String ' Define Private Variable DepartureDate With DataType As String 
        Private lngPortId As Long ' Define Private Variable PortId With DataType As Long 
        Private strService As String ' Define Private Variable Service With DataType As String 
        Private strRotationNo As String ' Define Private Variable RotationNo With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
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
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() as Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VcnNo
        ''' </summary>
        ''' <value>strVcnNo</value>
        ''' <returns> Return strVcnNo</returns>
        ''' <remarks> Get or Set the Value of VcnNo  </remarks>
        '''
        Public Property VcnNo() as String
            Get
                Return strVcnNo
            End Get
            Set(ByVal value As String)
                strVcnNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VoyNo
        ''' </summary>
        ''' <value>strVoyNo</value>
        ''' <returns> Return strVoyNo</returns>
        ''' <remarks> Get or Set the Value of VoyNo  </remarks>
        '''
        Public Property VoyNo() as String
            Get
                Return strVoyNo
            End Get
            Set(ByVal value As String)
                strVoyNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgmNo
        ''' </summary>
        ''' <value>strIgmNo</value>
        ''' <returns> Return strIgmNo</returns>
        ''' <remarks> Get or Set the Value of IgmNo  </remarks>
        '''
        Public Property IgmNo() as String
            Get
                Return strIgmNo
            End Get
            Set(ByVal value As String)
                strIgmNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgmDate
        ''' </summary>
        ''' <value>strIgmDate</value>
        ''' <returns> Return strIgmDate</returns>
        ''' <remarks> Get or Set the Value of IgmDate  </remarks>
        '''
        Public Property IgmDate() as String
            Get
                Return strIgmDate
            End Get
            Set(ByVal value As String)
                strIgmDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgmReceivedDate
        ''' </summary>
        ''' <value>strIgmReceivedDate</value>
        ''' <returns> Return strIgmReceivedDate</returns>
        ''' <remarks> Get or Set the Value of IgmReceivedDate  </remarks>
        '''
        Public Property IgmReceivedDate() as String
            Get
                Return strIgmReceivedDate
            End Get
            Set(ByVal value As String)
                strIgmReceivedDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VesselNo
        ''' </summary>
        ''' <value>strVesselNo</value>
        ''' <returns> Return strVesselNo</returns>
        ''' <remarks> Get or Set the Value of VesselNo  </remarks>
        '''
        Public Property VesselNo() as String
            Get
                Return strVesselNo
            End Get
            Set(ByVal value As String)
                strVesselNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VesselId
        ''' </summary>
        ''' <value>lngVesselId</value>
        ''' <returns> Return lngVesselId</returns>
        ''' <remarks> Get or Set the Value of VesselId  </remarks>
        '''
        Public Property VesselId() as Long
            Get
                Return lngVesselId
            End Get
            Set(ByVal value As Long)
                lngVesselId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() as Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ArrivalDate
        ''' </summary>
        ''' <value>strArrivalDate</value>
        ''' <returns> Return strArrivalDate</returns>
        ''' <remarks> Get or Set the Value of ArrivalDate  </remarks>
        '''
        Public Property ArrivalDate() as String
            Get
                Return strArrivalDate
            End Get
            Set(ByVal value As String)
                strArrivalDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of GateOpenDate
        ''' </summary>
        ''' <value>strGateOpenDate</value>
        ''' <returns> Return strGateOpenDate</returns>
        ''' <remarks> Get or Set the Value of GateOpenDate  </remarks>
        '''
        Public Property GateOpenDate() as String
            Get
                Return strGateOpenDate
            End Get
            Set(ByVal value As String)
                strGateOpenDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CutOfDate
        ''' </summary>
        ''' <value>strCutOfDate</value>
        ''' <returns> Return strCutOfDate</returns>
        ''' <remarks> Get or Set the Value of CutOfDate  </remarks>
        '''
        Public Property CutOfDate() as String
            Get
                Return strCutOfDate
            End Get
            Set(ByVal value As String)
                strCutOfDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BirthingDate
        ''' </summary>
        ''' <value>strBirthingDate</value>
        ''' <returns> Return strBirthingDate</returns>
        ''' <remarks> Get or Set the Value of BirthingDate  </remarks>
        '''
        Public Property BirthingDate() as String
            Get
                Return strBirthingDate
            End Get
            Set(ByVal value As String)
                strBirthingDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DepartureDate
        ''' </summary>
        ''' <value>strDepartureDate</value>
        ''' <returns> Return strDepartureDate</returns>
        ''' <remarks> Get or Set the Value of DepartureDate  </remarks>
        '''
        Public Property DepartureDate() as String
            Get
                Return strDepartureDate
            End Get
            Set(ByVal value As String)
                strDepartureDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PortId
        ''' </summary>
        ''' <value>lngPortId</value>
        ''' <returns> Return lngPortId</returns>
        ''' <remarks> Get or Set the Value of PortId  </remarks>
        '''
        Public Property PortId() as Long
            Get
                Return lngPortId
            End Get
            Set(ByVal value As Long)
                lngPortId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Service
        ''' </summary>
        ''' <value>strService</value>
        ''' <returns> Return strService</returns>
        ''' <remarks> Get or Set the Value of Service  </remarks>
        '''
        Public Property Service() as String
            Get
                Return strService
            End Get
            Set(ByVal value As String)
                strService = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RotationNo
        ''' </summary>
        ''' <value>strRotationNo</value>
        ''' <returns> Return strRotationNo</returns>
        ''' <remarks> Get or Set the Value of RotationNo  </remarks>
        '''
        Public Property RotationNo() as String
            Get
                Return strRotationNo
            End Get
            Set(ByVal value As String)
                strRotationNo = value
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
            lngServiceId = 0 
            strVcnNo = ""
            strVoyNo = ""
            strIgmNo = ""
            strIgmDate = ""
            strIgmReceivedDate = ""
            strVesselNo = ""
            lngVesselId = 0 
            lngLineId = 0 
            strArrivalDate = ""
            strGateOpenDate = ""
            strCutOfDate = ""
            strBirthingDate = ""
            strDepartureDate = ""
            lngPortId = 0 
            strService = ""
            strRotationNo = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVesselService"></param>
        ''' <returns>Return pVesselService Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVesselService As VesselService) As VesselService
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselService.TerminalId)
                db.AddParameter("p_SERVICE_ID", pVesselService.ServiceId, ParameterDirection.Output)
                db.AddParameter("p_VCN_NO", pVesselService.VcnNo)
                db.AddParameter("p_VOY_NO", pVesselService.VoyNo)
                db.AddParameter("p_IGM_NO", pVesselService.IgmNo)
                db.AddParameter("p_IGM_DATE", pVesselService.IgmDate)
                db.AddParameter("p_IGM_RECEIVED_DATE", pVesselService.IgmReceivedDate)
                db.AddParameter("p_VESSEL_NO", pVesselService.VesselNo)
                db.AddParameter("p_VESSEL_ID", pVesselService.VesselId)
                db.AddParameter("p_LINE_ID", pVesselService.LineId)
                db.AddParameter("p_ARRIVAL_DATE", pVesselService.ArrivalDate)
                db.AddParameter("p_GATE_OPEN_DATE", pVesselService.GateOpenDate)
                db.AddParameter("p_CUT_OF_DATE", pVesselService.CutOfDate)
                db.AddParameter("p_BIRTHING_DATE", pVesselService.BirthingDate)
                db.AddParameter("p_DEPARTURE_DATE", pVesselService.DepartureDate)
                db.AddParameter("p_PORT_ID", pVesselService.PortId)
                db.AddParameter("p_SERVICE", pVesselService.Service)
                db.AddParameter("p_ROTATION_NO", pVesselService.RotationNo)
                db.AddParameter("p_CREATED_BY", pVesselService.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVesselService.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVesselService.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VESSEL_SERVICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselService.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVesselService.ServiceId  = db.Parameters.Item("p_SERVICE_ID").value
                
                If pVesselService.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVesselService.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVesselService
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVesselService"></param>
        ''' <returns>Return pVesselService Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVesselService As VesselService) As VesselService
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselService.TerminalId)
                db.AddParameter("p_SERVICE_ID", pVesselService.ServiceId, ParameterDirection.Output)
                db.AddParameter("p_VCN_NO", pVesselService.VcnNo)
                db.AddParameter("p_VOY_NO", pVesselService.VoyNo)
                db.AddParameter("p_IGM_NO", pVesselService.IgmNo)
                db.AddParameter("p_IGM_DATE", pVesselService.IgmDate)
                db.AddParameter("p_IGM_RECEIVED_DATE", pVesselService.IgmReceivedDate)
                db.AddParameter("p_VESSEL_NO", pVesselService.VesselNo)
                db.AddParameter("p_VESSEL_ID", pVesselService.VesselId)
                db.AddParameter("p_LINE_ID", pVesselService.LineId)
                db.AddParameter("p_ARRIVAL_DATE", pVesselService.ArrivalDate)
                db.AddParameter("p_GATE_OPEN_DATE", pVesselService.GateOpenDate)
                db.AddParameter("p_CUT_OF_DATE", pVesselService.CutOfDate)
                db.AddParameter("p_BIRTHING_DATE", pVesselService.BirthingDate)
                db.AddParameter("p_DEPARTURE_DATE", pVesselService.DepartureDate)
                db.AddParameter("p_PORT_ID", pVesselService.PortId)
                db.AddParameter("p_SERVICE", pVesselService.Service)
                db.AddParameter("p_ROTATION_NO", pVesselService.RotationNo)
                db.AddParameter("p_CREATED_BY", pVesselService.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVesselService.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVesselService.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VESSEL_SERVICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselService.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVesselService.ServiceId  = db.Parameters.Item("p_SERVICE_ID").value
                
            Catch ex As Exception
                pVesselService.ErrorMsg = ex.Message
            End Try
            Return pVesselService
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVesselService"></param>
        ''' <returns>Return pVesselService Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVesselService As VesselService) As VesselService
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselService.TerminalId)
                db.AddParameter("p_SERVICE_ID", pVesselService.ServiceId)
                db.AddParameter("p_VCN_NO", pVesselService.VcnNo)
                db.AddParameter("p_VOY_NO", pVesselService.VoyNo)
                db.AddParameter("p_IGM_NO", pVesselService.IgmNo)
                db.AddParameter("p_IGM_DATE", pVesselService.IgmDate)
                db.AddParameter("p_IGM_RECEIVED_DATE", pVesselService.IgmReceivedDate)
                db.AddParameter("p_VESSEL_NO", pVesselService.VesselNo)
                db.AddParameter("p_VESSEL_ID", pVesselService.VesselId)
                db.AddParameter("p_LINE_ID", pVesselService.LineId)
                db.AddParameter("p_ARRIVAL_DATE", pVesselService.ArrivalDate)
                db.AddParameter("p_GATE_OPEN_DATE", pVesselService.GateOpenDate)
                db.AddParameter("p_CUT_OF_DATE", pVesselService.CutOfDate)
                db.AddParameter("p_BIRTHING_DATE", pVesselService.BirthingDate)
                db.AddParameter("p_DEPARTURE_DATE", pVesselService.DepartureDate)
                db.AddParameter("p_PORT_ID", pVesselService.PortId)
                db.AddParameter("p_SERVICE", pVesselService.Service)
                db.AddParameter("p_ROTATION_NO", pVesselService.RotationNo)
                db.AddParameter("p_CREATED_BY", pVesselService.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVesselService.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVesselService.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VESSEL_SERVICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselService.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVesselService.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVesselService.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVesselService
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVesselService"></param>
        ''' <returns>Return pVesselService Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVesselService As VesselService) As VesselService
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselService.TerminalId)
                db.AddParameter("p_SERVICE_ID", pVesselService.ServiceId)
                db.AddParameter("p_VCN_NO", pVesselService.VcnNo)
                db.AddParameter("p_VOY_NO", pVesselService.VoyNo)
                db.AddParameter("p_IGM_NO", pVesselService.IgmNo)
                db.AddParameter("p_IGM_DATE", pVesselService.IgmDate)
                db.AddParameter("p_IGM_RECEIVED_DATE", pVesselService.IgmReceivedDate)
                db.AddParameter("p_VESSEL_NO", pVesselService.VesselNo)
                db.AddParameter("p_VESSEL_ID", pVesselService.VesselId)
                db.AddParameter("p_LINE_ID", pVesselService.LineId)
                db.AddParameter("p_ARRIVAL_DATE", pVesselService.ArrivalDate)
                db.AddParameter("p_GATE_OPEN_DATE", pVesselService.GateOpenDate)
                db.AddParameter("p_CUT_OF_DATE", pVesselService.CutOfDate)
                db.AddParameter("p_BIRTHING_DATE", pVesselService.BirthingDate)
                db.AddParameter("p_DEPARTURE_DATE", pVesselService.DepartureDate)
                db.AddParameter("p_PORT_ID", pVesselService.PortId)
                db.AddParameter("p_SERVICE", pVesselService.Service)
                db.AddParameter("p_ROTATION_NO", pVesselService.RotationNo)
                db.AddParameter("p_CREATED_BY", pVesselService.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVesselService.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVesselService.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VESSEL_SERVICE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselService.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVesselService.ErrorMsg = ex.Message
                End Try
            Return pVesselService
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVesselService As VesselService) As VesselService
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVesselService.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PVesselService.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VCN_NO").ToString <> "" Then
                                PVesselService.VcnNo = dbr("VCN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VOY_NO").ToString <> "" Then
                                PVesselService.VoyNo = dbr("VOY_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_NO").ToString <> "" Then
                                PVesselService.IgmNo = dbr("IGM_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_DATE").ToString <> "" Then
                                PVesselService.IgmDate = dbr("IGM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_RECEIVED_DATE").ToString <> "" Then
                                PVesselService.IgmReceivedDate = dbr("IGM_RECEIVED_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NO").ToString <> "" Then
                                PVesselService.VesselNo = dbr("VESSEL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_ID").ToString <> "" Then
                                PVesselService.VesselId = dbr("VESSEL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PVesselService.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ARRIVAL_DATE").ToString <> "" Then
                                PVesselService.ArrivalDate = dbr("ARRIVAL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_OPEN_DATE").ToString <> "" Then
                                PVesselService.GateOpenDate = dbr("GATE_OPEN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUT_OF_DATE").ToString <> "" Then
                                PVesselService.CutOfDate = dbr("CUT_OF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BIRTHING_DATE").ToString <> "" Then
                                PVesselService.BirthingDate = dbr("BIRTHING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_DATE").ToString <> "" Then
                                PVesselService.DepartureDate = dbr("DEPARTURE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                PVesselService.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE").ToString <> "" Then
                                PVesselService.Service = dbr("SERVICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROTATION_NO").ToString <> "" Then
                                PVesselService.RotationNo = dbr("ROTATION_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PVesselService.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PVesselService.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVesselService.ErrorMsg = ex.Message
            End Try
            Return pVesselService
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVesselService As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VesselService
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VCN_NO").ToString <> "" Then
                                temp.VcnNo = dbr("VCN_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VOY_NO").ToString <> "" Then
                                temp.VoyNo = dbr("VOY_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_NO").ToString <> "" Then
                                temp.IgmNo = dbr("IGM_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_DATE").ToString <> "" Then
                                temp.IgmDate = dbr("IGM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_RECEIVED_DATE").ToString <> "" Then
                                temp.IgmReceivedDate = dbr("IGM_RECEIVED_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NO").ToString <> "" Then
                                temp.VesselNo = dbr("VESSEL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_ID").ToString <> "" Then
                                temp.VesselId = dbr("VESSEL_ID")
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
                            If dbr("ARRIVAL_DATE").ToString <> "" Then
                                temp.ArrivalDate = dbr("ARRIVAL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_OPEN_DATE").ToString <> "" Then
                                temp.GateOpenDate = dbr("GATE_OPEN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUT_OF_DATE").ToString <> "" Then
                                temp.CutOfDate = dbr("CUT_OF_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BIRTHING_DATE").ToString <> "" Then
                                temp.BirthingDate = dbr("BIRTHING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_DATE").ToString <> "" Then
                                temp.DepartureDate = dbr("DEPARTURE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                temp.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE").ToString <> "" Then
                                temp.Service = dbr("SERVICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROTATION_NO").ToString <> "" Then
                                temp.RotationNo = dbr("ROTATION_NO")
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
        Public Shared Function ReturnVesselService(ByVal pVesselService As VesselService) As VesselService
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VESSEL_SERVICE_BY_ID", pVesselService.TerminalId & "," & pVesselService.ServiceId)
                pVesselService = ReturnObjectValues(dbr, pVesselService)
                dbr.Close()
            Catch ex As Exception
                pVesselService.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVesselService
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVesselServiceList(ByVal pVesselService As VesselService) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVesselService As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VESSEL_SERVICE_BY_ALL", pVesselService.TerminalId)
                arrVesselService = ReturnObjectValuesList(dbr, arrVesselService)
                dbr.Close()
            Catch ex As Exception
                arrVesselService = Nothing
            End Try
            db.CloseDB()
            Return arrVesselService
        End Function
    End Class
End Namespace
