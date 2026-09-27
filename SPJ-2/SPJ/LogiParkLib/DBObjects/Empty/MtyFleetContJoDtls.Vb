Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects

	''' <summary>
	''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
	''' @Version	: Version 1.0.0.0
	''' @Module/Class Name	: MtyFleetContJoDtls
	''' @author	: Amit K Singh- 20/12/2017
	''' </summary>
	''' <remarks> </remarks>
	'''
	Public Class MtyFleetContJoDtls

		Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
		Private lngComapnyId As Long
		Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
		Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
		Private lngLineId As Long
		Private strContNo As String ' Define Private Variable ContNo With DataType As String 
		Private strContSize As String ' Define Private Variable ContSize With DataType As String 
		Private strContType As String ' Define Private Variable ContType With DataType As String
		Private strSealNo As String ' Define Private Variable Errormsg With DataType As String 
		Private strVehicleNo As String ' Define Private Variable VehicleNo With DataType As String
		Private strGRNo As String ' Define Private Variable GRNo With DataType As String
		Private strPickupDate As String ' Define Private Variable PickupDate With DataType As String
		Private strGateInDate As String ' Define Private Variable GateInDate With DataType As String
		Private strBookingNo As String ' Define Private Variable BookingNo With DataType As String
		Private strBookingDate As String ' Define Private Variable BookingDate With DataType As String
		Private strJoType As String ' Define Private Variable JoType With DataType As String 
		Private strCancelStatus As String ' Define Private Variable CancelStatus With DataType As Long 
        Private strRemarks As String
        Private strDoNo As String ' Define Private Variable DoNo With DataType As String 
        Private strDoDate As String ' Define Private Variable DoDate With DataType As String 
        Private strDoValidDate As String ' Define Private Variable DoValidDate With DataType As String 
        Private lngWeight As Double ' Define Private Variable Gross Weight With DataType As Long 
        Private lngCargoWt As Double ' Define Private Variable Cargo Weight With DataType As Long 
        Private lngTareWt As Double ' Define Private Variable Tare Weight With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strExtra As String ' Define Private Variable strExtra With DataType As String
        Private lngExtra1 As Long ' Define Private Variable strExtra With DataType As String
        Private strExtr2 As String ' Define Private Variable strExtra With DataType As String
		Private strExtr3 As String ' Define Private Variable strExtra With DataType As String


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
		Public Property BookingDate() As String
			Get
				Return strBookingDate
			End Get
			Set(ByVal value As String)
				strBookingDate = value
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
		Public Property CancelStatus() As String
			Get
				Return strCancelStatus
			End Get
			Set(ByVal value As String)
				strCancelStatus = value
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
		Public Property GRNo() As String
			Get
				Return strGRNo
			End Get
			Set(ByVal value As String)
				strGRNo = value
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
		''' Get or Set the Value of TripType
		''' </summary>
		''' <value>strPickupDate</value>
		''' <returns> Return strPickupDate</returns>
		''' <remarks> Get or Set the Value of PickUpDate  </remarks>
		'''
		Public Property PickUpDate() As String
			Get
				Return strPickupDate
			End Get
			Set(ByVal value As String)
				strPickupDate = value
			End Set
		End Property

		''' <summary>
		''' Get or Set the Value of GateInDate
		''' </summary>
		''' <value>strGateInDate</value>
		''' <returns> Return strGateInDate</returns>
		''' <remarks> Get or Set the Value of GateInDate  </remarks>
		'''
		Public Property GateInDate() As String
			Get
				Return strGateInDate
			End Get
			Set(ByVal value As String)
				strGateInDate = value
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
        ''' Get or Set the Value of DoNo
        ''' </summary>
        ''' <value>strDoNo</value>
        ''' <returns> Return strDoNo</returns>
        ''' <remarks> Get or Set the Value of DoNo  </remarks>
        '''
        Public Property DoNo() As String
            Get
                Return strDoNo
            End Get
            Set(ByVal value As String)
                strDoNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DoDate
        ''' </summary>
        ''' <value>strDoDate</value>
        ''' <returns> Return strDoDate</returns>
        ''' <remarks> Get or Set the Value of DoDate  </remarks>
        '''
        Public Property DoDate() As String
            Get
                Return strDoDate
            End Get
            Set(ByVal value As String)
                strDoDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DoValidDate
        ''' </summary>
        ''' <value>strDoValidDate</value>
        ''' <returns> Return strDoValidDate</returns>
        ''' <remarks> Get or Set the Value of DoValidDate  </remarks>
        '''
        Public Property DoValidDate() As String
            Get
                Return strDoValidDate
            End Get
            Set(ByVal value As String)
                strDoValidDate = value
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

        Public Property Extra() As String
            Get
                Return strExtra
            End Get
            Set(ByVal value As String)
                strExtra = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Extra1
        ''' </summary>
        ''' <value>lngExtra1</value>
        ''' <returns> Return lngExtra1</returns>
        ''' <remarks> Get or Set the Value of Extra1  </remarks>
        '''
        Public Property Extra1() As Double
            Get
                Return lngExtra1
            End Get
            Set(ByVal value As Double)
                lngExtra1 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of strExtr2
        ''' </summary>
        ''' <value>strExtr2</value>
        ''' <returns> Return strExtr2</returns>
        ''' <remarks> Get or Set the Value of strExtr2  </remarks>
        '''
        Public Property Extra2() As String
            Get
                Return strExtr2
            End Get
            Set(ByVal value As String)
                strExtr2 = value
            End Set
        End Property


		''' <summary>
		''' Get or Set the Value of strExtr3
		''' </summary>
		''' <value>strExtr2</value>
		''' <returns> Return strExtr2</returns>
		''' <remarks> Get or Set the Value of strExtr3  </remarks>
		'''
		Public Property Extra3() As String
			Get
				Return strExtr3
			End Get
			Set(ByVal value As String)
				strExtr3 = value
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
			lngComapnyId = 0
			lngMtyContId = 0
			lngContJoId = 0
			strContNo = ""
			strContSize = ""
			strContType = ""
			strJoType = ""
			strVehicleNo = ""
			strGRNo = ""
            strSealNo = ""
			strBookingNo = ""
			strBookingDate = ""
			lngLineId = 0
            strRemarks = ""
            strDoNo = ""
            strDoDate = ""
            strDoValidDate = ""
            lngWeight = 0.0
            lngCargoWt = 0.0
            lngTareWt = 0.0
            strExtra = ""
            lngExtra1 = 0.0
            strExtr2 = ""
			strExtr3 = ""

			strErrormsg = ""
		End Sub

		''' <summary>
		''' Insert Member Function to Insert the New Record
		''' </summary>
		''' <param name="pMtyFleetContJoDtls"></param>
		''' <returns>Return pMtyFleetContJoDtls Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function Insert(ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Try
				db.BeginTransaction()
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJoDtls.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJoDtls.CompanyId)
				db.AddParameter("p_MTY_CONT_ID", pMtyFleetContJoDtls.MtyContId, Global.System.Data.ParameterDirection.Output)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJoDtls.ContJoId)
				db.AddParameter("p_CONT_NO", pMtyFleetContJoDtls.ContNo)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJoDtls.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJoDtls.ContType)
				db.AddParameter("p_VEHICLE_NO", pMtyFleetContJoDtls.VehicleNo)
				db.AddParameter("p_GR_NO", pMtyFleetContJoDtls.GRNo)
				db.AddParameter("p_PICKUP_DATE", pMtyFleetContJoDtls.PickUpDate)
				db.AddParameter("p_GATE_IN_DATE", pMtyFleetContJoDtls.GateInDate)
				db.AddParameter("p_SEAL_NO", pMtyFleetContJoDtls.SealNo)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJoDtls.JoType)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJoDtls.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJoDtls.BookingDate)
				db.AddParameter("p_LINE_ID", pMtyFleetContJoDtls.LineId)
                db.AddParameter("p_REMARKS", pMtyFleetContJoDtls.Remarks)
                db.AddParameter("p_DO_NO", pMtyFleetContJoDtls.DoNo)
                db.AddParameter("p_DO_DATE", pMtyFleetContJoDtls.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyFleetContJoDtls.DoValidDate)
                db.AddParameter("p_WEIGHT", pMtyFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pMtyFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pMtyFleetContJoDtls.TareWt)
                db.AddParameter("p_EXTRA", pMtyFleetContJoDtls.Extra)
                db.AddParameter("p_EXTRA1", pMtyFleetContJoDtls.Extra1)
                db.AddParameter("p_EXTRA2", pMtyFleetContJoDtls.Extra2)
				db.AddParameter("p_EXTRA3", pMtyFleetContJoDtls.Extra3)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJoDtls.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("INSERT_PKG.SP_MTY_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyFleetContJoDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
			Catch ex As Exception
				pMtyFleetContJoDtls.Errormsg = ex.Message
				db.RollbackTransaction()
			End Try
			db.CloseDB()
			Return pMtyFleetContJoDtls
		End Function

		''' <summary>
		''' Insert Member Function to Insert the New Record With Transaction
		''' </summary>
		''' <param name="db"></param>
		''' <param name="pMtyFleetContJoDtls"></param>
		''' <returns>Return pFleetContJoDtls Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyFleetContJoDtls.TerminalId)
                db.AddParameter("p_COMPANY_ID", pMtyFleetContJoDtls.CompanyId)
                db.AddParameter("p_MTY_CONT_ID", pMtyFleetContJoDtls.MtyContId, Global.System.Data.ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_ID", pMtyFleetContJoDtls.ContJoId)
                db.AddParameter("p_CONT_NO", pMtyFleetContJoDtls.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyFleetContJoDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pMtyFleetContJoDtls.ContType)
                db.AddParameter("p_VEHICLE_NO", pMtyFleetContJoDtls.VehicleNo)
                db.AddParameter("p_GR_NO", pMtyFleetContJoDtls.GRNo)
                db.AddParameter("p_PICKUP_DATE", pMtyFleetContJoDtls.PickUpDate)
                db.AddParameter("p_GATE_IN_DATE", pMtyFleetContJoDtls.GateInDate)
                db.AddParameter("p_SEAL_NO", pMtyFleetContJoDtls.SealNo)
                db.AddParameter("p_JO_TYPE", pMtyFleetContJoDtls.JoType)
                db.AddParameter("p_BOOKING_NO", pMtyFleetContJoDtls.BookingNo)
                db.AddParameter("p_BOOKING_DATE", pMtyFleetContJoDtls.BookingDate)
                db.AddParameter("p_LINE_ID", pMtyFleetContJoDtls.LineId)
                db.AddParameter("p_REMARKS", pMtyFleetContJoDtls.Remarks)
                db.AddParameter("p_DO_NO", pMtyFleetContJoDtls.DoNo)
                db.AddParameter("p_DO_DATE", pMtyFleetContJoDtls.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyFleetContJoDtls.DoValidDate)
                db.AddParameter("p_WEIGHT", pMtyFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pMtyFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pMtyFleetContJoDtls.TareWt)
                db.AddParameter("p_EXTRA", pMtyFleetContJoDtls.Extra)
                db.AddParameter("p_EXTRA1", pMtyFleetContJoDtls.Extra1)
                db.AddParameter("p_EXTRA2", pMtyFleetContJoDtls.Extra2)
				db.AddParameter("p_EXTRA3", pMtyFleetContJoDtls.Extra3)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJoDtls.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("INSERT_PKG.SP_MTY_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else

                    pMtyFleetContJoDtls.MtyContId = db.Parameters.Item("p_MTY_CONT_ID").value
                End If

            Catch ex As Exception
                pMtyFleetContJoDtls.Errormsg = ex.Message
            End Try
			Return pMtyFleetContJoDtls
		End Function

		''' <summary>
		''' Update Member Function to Update the New Record
		''' </summary>
		''' <param name="pMtyFleetContJoDtls"></param>
		''' <returns>Return pMtyFleetContJoDtls Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function Update(ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Try
				db.BeginTransaction()
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJoDtls.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJoDtls.CompanyId)
				db.AddParameter("p_MTY_CONT_ID", pMtyFleetContJoDtls.MtyContId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJoDtls.ContJoId)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJoDtls.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJoDtls.BookingDate)
				db.AddParameter("p_LINE_ID", pMtyFleetContJoDtls.LineId)
				db.AddParameter("p_CONT_NO", pMtyFleetContJoDtls.ContNo)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJoDtls.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJoDtls.ContType)
				db.AddParameter("p_SEAL_NO", pMtyFleetContJoDtls.SealNo)
				db.AddParameter("p_VEHICLE_NO", pMtyFleetContJoDtls.VehicleNo)
				db.AddParameter("p_GR_NO", pMtyFleetContJoDtls.GRNo)
				db.AddParameter("p_PICKUP_DATE", pMtyFleetContJoDtls.PickUpDate)
				db.AddParameter("p_GATE_IN_DATE", pMtyFleetContJoDtls.GateInDate)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJoDtls.JoType)
                db.AddParameter("p_REMARKS", pMtyFleetContJoDtls.Remarks)
                db.AddParameter("p_DO_NO", pMtyFleetContJoDtls.DoNo)
                db.AddParameter("p_DO_DATE", pMtyFleetContJoDtls.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyFleetContJoDtls.DoValidDate)
                db.AddParameter("p_WEIGHT", pMtyFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pMtyFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pMtyFleetContJoDtls.TareWt)
                db.AddParameter("p_EXTRA", pMtyFleetContJoDtls.Extra)
                db.AddParameter("p_EXTRA1", pMtyFleetContJoDtls.Extra1)
                db.AddParameter("p_EXTRA2", pMtyFleetContJoDtls.Extra2)
				db.AddParameter("p_EXTRA3", pMtyFleetContJoDtls.Extra3)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJoDtls.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("UPDATE_PKG.SP_MTY_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
				If pMtyFleetContJoDtls.Errormsg <> Nothing Then
					db.RollbackTransaction()
				Else
					db.CommitTransaction()
				End If
			Catch ex As Exception
				pMtyFleetContJoDtls.Errormsg = ex.Message
				db.RollbackTransaction()
			End Try
			db.CloseDB()
			Return pMtyFleetContJoDtls
		End Function

		''' <summary>
		''' Update Member Function to Update the New Record
		''' </summary>
		''' <param name="db"></param>
		''' <param name="pMtyFleetContJoDtls"></param>
		''' <returns>Return pMtyFleetContJoDtls Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Try
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJoDtls.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJoDtls.CompanyId)
				db.AddParameter("p_MTY_CONT_ID", pMtyFleetContJoDtls.MtyContId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJoDtls.ContJoId)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJoDtls.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJoDtls.BookingDate)
				db.AddParameter("p_LINE_ID", pMtyFleetContJoDtls.LineId)
				db.AddParameter("p_CONT_NO", pMtyFleetContJoDtls.ContNo)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJoDtls.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJoDtls.ContType)
				db.AddParameter("p_SEAL_NO", pMtyFleetContJoDtls.SealNo)
				db.AddParameter("p_VEHICLE_NO", pMtyFleetContJoDtls.VehicleNo)
				db.AddParameter("p_GR_NO", pMtyFleetContJoDtls.GRNo)
				db.AddParameter("p_PICKUP_DATE", pMtyFleetContJoDtls.PickUpDate)
				db.AddParameter("p_GATE_IN_DATE", pMtyFleetContJoDtls.GateInDate)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJoDtls.JoType)
                db.AddParameter("p_REMARKS", pMtyFleetContJoDtls.Remarks)
                db.AddParameter("p_DO_NO", pMtyFleetContJoDtls.DoNo)
                db.AddParameter("p_DO_DATE", pMtyFleetContJoDtls.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyFleetContJoDtls.DoValidDate)
                db.AddParameter("p_WEIGHT", pMtyFleetContJoDtls.Weight)
                db.AddParameter("p_CARGO_WEIGHT", pMtyFleetContJoDtls.CargoWt)
                db.AddParameter("p_TARE_WEIGHT", pMtyFleetContJoDtls.TareWt)
                db.AddParameter("p_EXTRA", pMtyFleetContJoDtls.Extra)
                db.AddParameter("p_EXTRA1", pMtyFleetContJoDtls.Extra1)
                db.AddParameter("p_EXTRA2", pMtyFleetContJoDtls.Extra2)
				db.AddParameter("p_EXTRA3", pMtyFleetContJoDtls.Extra3)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJoDtls.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("UPDATE_PKG.SP_MTY_FLEET_CONT_JO_DTLS", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJoDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
			Catch ex As Exception
				pMtyFleetContJoDtls.Errormsg = ex.Message
			End Try
			Return pMtyFleetContJoDtls
		End Function

		''' <summary>
		''' Preparing ReturnObjectValues Member Function
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property</remarks>
		'''
		Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Try
				If dbr.HasRows Then
					While dbr.Read
						Try
							If dbr("TERMINAL_ID").ToString <> "" Then
								pMtyFleetContJoDtls.TerminalId = dbr("TERMINAL_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("COMPANY_ID").ToString <> "" Then
								pMtyFleetContJoDtls.CompanyId = dbr("COMPANY_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("MTY_CONT_ID").ToString <> "" Then
								pMtyFleetContJoDtls.MtyContId = dbr("MTY_CONT_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("REMARKS").ToString <> "" Then
								pMtyFleetContJoDtls.Remarks = dbr("REMARKS")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_JO_ID").ToString <> "" Then
								pMtyFleetContJoDtls.ContJoId = dbr("CONT_JO_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_NO").ToString <> "" Then
								pMtyFleetContJoDtls.ContNo = dbr("CONT_NO")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_SIZE").ToString <> "" Then
								pMtyFleetContJoDtls.ContSize = dbr("CONT_SIZE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_TYPE").ToString <> "" Then
								pMtyFleetContJoDtls.ContType = dbr("CONT_TYPE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("VEHICLE_NO").ToString <> "" Then
								pMtyFleetContJoDtls.VehicleNo = dbr("VEHICLE_NO")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("GR_NO").ToString <> "" Then
								pMtyFleetContJoDtls.GRNo = dbr("GR_NO")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("SEAL_NO").ToString <> "" Then
								pMtyFleetContJoDtls.SealNo = dbr("SEAL_NO")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("JO_TYPE").ToString <> "" Then
								pMtyFleetContJoDtls.JoType = dbr("JO_TYPE")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("BOOKING_NO").ToString <> "" Then
								pMtyFleetContJoDtls.BookingNo = dbr("BOOKING_NO")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("BOOKING_DATE").ToString <> "" Then
								pMtyFleetContJoDtls.BookingDate = dbr("BOOKING_DATE")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("PICKUP_DATE").ToString <> "" Then
								pMtyFleetContJoDtls.PickUpDate = dbr("PICKUP_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("GATE_IN_DATE").ToString <> "" Then
								pMtyFleetContJoDtls.GateInDate = dbr("GATE_IN_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("LINE_ID").ToString <> "" Then
								pMtyFleetContJoDtls.LineId = dbr("LINE_ID")
							End If
						Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_NO").ToString <> "" Then
                                pMtyFleetContJoDtls.DoNo = dbr("DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_DATE").ToString <> "" Then
                                pMtyFleetContJoDtls.DoDate = dbr("DO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALID_DATE").ToString <> "" Then
                                pMtyFleetContJoDtls.DoValidDate = dbr("DO_VALID_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIGHT").ToString <> "" Then
                                pMtyFleetContJoDtls.Weight = dbr("WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_WEIGHT").ToString <> "" Then
                                pMtyFleetContJoDtls.CargoWt = dbr("CARGO_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WEIGHT").ToString <> "" Then
                                pMtyFleetContJoDtls.TareWt = dbr("TARE_WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTRA").ToString <> "" Then
                                pMtyFleetContJoDtls.Extra = dbr("EXTRA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTRA1").ToString <> "" Then
                                pMtyFleetContJoDtls.Extra1 = dbr("EXTRA1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTRA2").ToString <> "" Then
                                pMtyFleetContJoDtls.Extra2 = dbr("EXTRA2")
                            End If
                        Catch ex1 As Exception
                        End Try
						Try
							If dbr("EXTRA3").ToString <> "" Then
								pMtyFleetContJoDtls.Extra3 = dbr("EXTRA3")
							End If
						Catch ex1 As Exception
						End Try




					End While
				End If
			Catch ex As Exception
				pMtyFleetContJoDtls.Errormsg = ex.Message
			End Try
			Return pMtyFleetContJoDtls
		End Function

		''' <summary>
		''' Preparing ReturnObjectValuesList Member Function
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
		'''
		Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyFleetContJoDtls As ArrayList) As ArrayList
			Dim arrList As New ArrayList
			Try
				If dbr.HasRows Then
					While dbr.Read
						Dim temp As New MtyFleetContJoDtls
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
							If dbr("VEHICLE_NO").ToString <> "" Then
								temp.VehicleNo = dbr("VEHICLE_NO")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("GR_NO").ToString <> "" Then
								temp.GRNo = dbr("GR_NO")
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
							If dbr("JO_TYPE").ToString <> "" Then
								temp.JoType = dbr("JO_TYPE")
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
							If dbr("LINE_ID").ToString <> "" Then
								temp.LineId = dbr("LINE_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("PICKUP_DATE").ToString <> "" Then
								temp.PickUpDate = dbr("PICKUP_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("GATE_IN_DATE").ToString <> "" Then
								temp.GateInDate = dbr("GATE_IN_DATE")
							End If
						Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_NO").ToString <> "" Then
                                temp.DoNo = dbr("DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_DATE").ToString <> "" Then
                                temp.DoDate = dbr("DO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALID_DATE").ToString <> "" Then
                                temp.DoValidDate = dbr("DO_VALID_DATE")
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
                            If dbr("EXTRA").ToString <> "" Then
                                temp.Extra = dbr("EXTRA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTRA1").ToString <> "" Then
                                temp.Extra1 = dbr("EXTRA1")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXTRA2").ToString <> "" Then
                                temp.Extra2 = dbr("EXTRA2")
                            End If
                        Catch ex1 As Exception
                        End Try
						Try
							If dbr("EXTRA3").ToString <> "" Then
								temp.Extra3 = dbr("EXTRA3")
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
		Public Shared Function ReturnMtyFleetContJoDtls(ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_BY_ID", pMtyFleetContJoDtls.TerminalId & "," & pMtyFleetContJoDtls.MtyContId & ",'" & pMtyFleetContJoDtls.ContNo & "'")
				pMtyFleetContJoDtls = ReturnObjectValues(dbr, pMtyFleetContJoDtls)
				dbr.Close()
			Catch ex As Exception
				pMtyFleetContJoDtls.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyFleetContJoDtls
		End Function

		Public Shared Function ReturnMtyFleetContJoDtlslCont(ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As ArrayList
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Dim arrMtyFleetContJoDtls As New ArrayList
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO_DTLS_BY_ID", pMtyFleetContJoDtls.TerminalId & "," & pMtyFleetContJoDtls.MtyContId & ",'" & pMtyFleetContJoDtls.ContNo & "'")
				arrMtyFleetContJoDtls = ReturnObjectValuesList(dbr, arrMtyFleetContJoDtls)
				dbr.Close()
			Catch ex As Exception
				arrMtyFleetContJoDtls = Nothing
			End Try
			db.CloseDB()
			Return arrMtyFleetContJoDtls
        End Function
		Public Shared Function ReturnMtyContainersValidate(ByVal pMtyContainers As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_ALLOT_EXP", pMtyContainers.TerminalId & "," & pMtyContainers.LineId & ",'" & pMtyContainers.ContNo & "'")
				pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
				dbr.Close()
			Catch ex As Exception
				pMtyContainers.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyContainers
		End Function
		Public Shared Function ReturnMtyContainersValidateNew(ByVal pMtyContainers As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_ALLOT_EXP_NEW", pMtyContainers.TerminalId & "," & pMtyContainers.LineId & ",'" & pMtyContainers.ContNo & "'")
				pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
				dbr.Close()
			Catch ex As Exception
				pMtyContainers.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyContainers
		End Function
		Public Shared Function ReturnMtyContainersValidateWithSize(ByVal pMtyContainers As MtyFleetContJoDtls) As MtyFleetContJoDtls
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_ALLOT_EXP_SIZE", pMtyContainers.TerminalId & "," & pMtyContainers.LineId & ",'" & pMtyContainers.ContNo & "'" & pMtyContainers.ContSize & "'" & pMtyContainers.ContType & "'")
				pMtyContainers = ReturnObjectValues(dbr, pMtyContainers)
				dbr.Close()
			Catch ex As Exception
				pMtyContainers.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyContainers
		End Function
		''' <summary>
		''' Preparing Return Object ArrayList 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
		'''
		Public Shared Function ReturnFleetContJoDtlsList(ByVal pMtyFleetContJoDtls As MtyFleetContJoDtls) As ArrayList
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Dim arrMtyFleetContJoDtls As New ArrayList
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_FLEET_CONT_JO_DTLS", pMtyFleetContJoDtls.TerminalId & "," & pMtyFleetContJoDtls.ContJoId)
				arrMtyFleetContJoDtls = ReturnObjectValuesList(dbr, arrMtyFleetContJoDtls)
				dbr.Close()
			Catch ex As Exception
				arrMtyFleetContJoDtls = Nothing
			End Try
			db.CloseDB()
			Return arrMtyFleetContJoDtls
		End Function

	End Class

End Namespace
