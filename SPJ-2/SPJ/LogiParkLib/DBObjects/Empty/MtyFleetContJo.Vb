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
	Public Class MtyFleetContJo

		Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
		Private lngComapnyId As Long
		Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
		Private strContJoNo As String ' Define Private Variable ContJoNo With DataType As String 
		Private lngConsigneeId As Long ' Define Private Variable ConsigneeId With DataType As Long 
		Private lngCustomerId As Long ' Define Private Variable CustomerId With DataType As Long 
		Private lngTransporterId As Long ' Define Private Variable TransporterId With DataType As Long 
		Private lngSurveyorId As Long ' Define Private Variable TransporterId With DataType As Long
		Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
		Private lngFromLocationId As Long ' Define Private Variable MtyPickup With DataType As Long 
		Private lngToLocationId As Long ' Define Private Variable ToLocationId With DataType As Long 
		Private strBookingNo As String ' Define Private Variable BookingNo With DataType As String 
		Private strBookingDate As String ' Define Private Variable BookingDate With DataType As String
		Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
		Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
		Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
		Private strJoType As String ' Define Private Variable ContJoNo With DataType As String 
		Private lngNoOf20 As Long ' Define Private Variable ContJoId With DataType As Long 
		Private lngNoOf40 As Long ' Define Private Variable ContJoId With DataType As Long 
		Private strContSize As String ' Define Private Variable ContSize With DataType As String 
		Private strContType As String ' Define Private Variable ContType With DataType As String
		Private lngEmptyPodId As Long ' Define Private Variable LineId With DataType As Long 
		Private lngEmptyPolId As Long ' Define Private Variable LineId With DataType As Long 
		Private strVesselName As String ' Define Private Variable VesselName With DataType As String 
		Private strValidity As String ' Define Private Variable Validity With DataType As String 
		Private strSicutDate As String ' Define Private Variable Validity With DataType As String 
		Private strPortCutOfdate As String ' Define Private Variable Validity With DataType As String 
		Private strETDDate As String ' Define Private Variable Validity With DataType As String 

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
		''' Get or Set the Value of SurveyorId
		''' </summary>
		''' <value>lngSurveyorId</value>
		''' <returns> Return lngSurveyorId</returns>
		''' <remarks> Get or Set the Value of SurveyorId  </remarks>
		'''
		Public Property SurveyorId() As Long
			Get
				Return lngSurveyorId
			End Get
			Set(ByVal value As Long)
				lngSurveyorId = value
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
		''' Get or Set the Value of FromLocationId
		''' </summary>
		''' <value>lngFromLocationId</value>
		''' <returns> Return lngFromLocationId</returns>
		''' <remarks> Get or Set the Value of FromLocationId  </remarks>
		'''
		Public Property FromLocationId() As Long
			Get
				Return lngFromLocationId
			End Get
			Set(ByVal value As Long)
				lngFromLocationId = value
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
		''' Get or Set the Value of BookingDate
		''' </summary>
		''' <value>strBookingDate</value>
		''' <returns> Return strBookingDate</returns>
		''' <remarks> Get or Set the Value of BookingDate  </remarks>
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
		''' Get or Set the Value of EmptyPodId
		''' </summary>
		''' <value>lngEmptyPodId</value>
		''' <returns> Return lngEmptyPodId</returns>
		''' <remarks> Get or Set the Value of EmptyPodId  </remarks>
		'''
		Public Property EmptyPodId() As Long
			Get
				Return lngEmptyPodId
			End Get
			Set(ByVal value As Long)
				lngEmptyPodId = value
			End Set
		End Property

		''' <summary>
		''' Get or Set the Value of EmptyPolId
		''' </summary>
		''' <value>lngEmptyPolId</value>
		''' <returns> Return lngEmptyPolId</returns>
		''' <remarks> Get or Set the Value of EmptyPolId  </remarks>
		'''
		Public Property EmptyPolId() As Long
			Get
				Return lngEmptyPolId
			End Get
			Set(ByVal value As Long)
				lngEmptyPolId = value
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
			lngFromLocationId = 0
			lngToLocationId = 0
			strBookingNo = ""
			strBookingDate = ""
			strCreatedBy = ""
			strCreatedOn = ""
			strJoType = ""
			lngNoOf20 = 0
			lngNoOf40 = 0
			strContSize = ""
			strContType = ""
			lngEmptyPodId = 0
			lngEmptyPolId = 0
			strVesselName = ""
			strValidity = ""
			strSicutDate = ""
			strPortCutOfdate = ""
			strETDDate = ""
			strErrormsg = ""
		End Sub

		''' <summary>
		''' Insert Member Function to Insert the New Record
		''' </summary>
		''' <param name="pMtyFleetContJo"></param>
		''' <returns>Return pMtyFleetContJo Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function Insert(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Try
				db.BeginTransaction()
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJo.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJo.CompanyId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJo.ContJoId, ParameterDirection.Output)
				db.AddParameter("p_CONT_JO_NO", pMtyFleetContJo.ContJoNo, ParameterDirection.Output)
				db.AddParameter("p_CONSIGNEE_ID", pMtyFleetContJo.ConsigneeId)
				db.AddParameter("p_CUSTOMER_ID", pMtyFleetContJo.CustomerId)
				db.AddParameter("p_TRANSPORTER_ID", pMtyFleetContJo.TransporterId)
				db.AddParameter("p_SURVEYOR_ID", pMtyFleetContJo.SurveyorId)
				db.AddParameter("p_LINE_ID", pMtyFleetContJo.LineId)
				db.AddParameter("p_FROM_LOCATION_ID", pMtyFleetContJo.FromLocationId)
				db.AddParameter("p_TO_LOCATION_ID", pMtyFleetContJo.ToLocationId)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJo.JoType)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJo.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJo.BookingDate)
				db.AddParameter("p_NO_OF_20", pMtyFleetContJo.NoOf20)
				db.AddParameter("p_NO_OF_40", pMtyFleetContJo.NoOf40)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJo.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJo.ContType)
				db.AddParameter("p_CREATED_BY", pMtyFleetContJo.CreatedBy)
				db.AddParameter("p_CREATED_ON", pMtyFleetContJo.CreatedOn, ParameterDirection.Output)
				db.AddParameter("p_EMPTY_POD_ID", pMtyFleetContJo.EmptyPodId)
				db.AddParameter("p_EMPTY_POL_ID", pMtyFleetContJo.EmptyPolId)
				db.AddParameter("p_VESSEL_NAME", pMtyFleetContJo.VesselName)
				db.AddParameter("p_VALIDITY", pMtyFleetContJo.Validity)
				db.AddParameter("p_EMPTY_SI_CUTOF_DATE", pMtyFleetContJo.SicutDate)
				db.AddParameter("p_EMPTY_CUTOF_DATE", pMtyFleetContJo.PortCutOfdate)
				db.AddParameter("p_ETD_DATE", pMtyFleetContJo.ETDDate)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJo.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("INSERT_PKG.SP_MTY_FLEET_CONT_JO", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
				pMtyFleetContJo.ContJoId = db.Parameters.Item("p_CONT_JO_ID").value
				pMtyFleetContJo.ContJoNo = db.Parameters.Item("p_CONT_JO_NO").value
				pMtyFleetContJo.CreatedOn = db.Parameters.Item("p_CREATED_ON").value

				If pMtyFleetContJo.Errormsg <> Nothing Then
					db.RollbackTransaction()
				Else
					db.CommitTransaction()
				End If
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
				db.RollbackTransaction()
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Insert Member Function to Insert the New Record With Transaction
		''' </summary>
		''' <param name="db"></param>
		''' <param name="pMtyFleetContJo"></param>
		''' <returns>Return pMtyFleetContJo Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Try
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJo.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJo.CompanyId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJo.ContJoId, ParameterDirection.Output)
				db.AddParameter("p_CONT_JO_NO", pMtyFleetContJo.ContJoNo, ParameterDirection.Output)
				db.AddParameter("p_CONSIGNEE_ID", pMtyFleetContJo.ConsigneeId)
				db.AddParameter("p_CUSTOMER_ID", pMtyFleetContJo.CustomerId)
				db.AddParameter("p_TRANSPORTER_ID", pMtyFleetContJo.TransporterId)
				db.AddParameter("p_SURVEYOR_ID", pMtyFleetContJo.SurveyorId)
				db.AddParameter("p_LINE_ID", pMtyFleetContJo.LineId)
				db.AddParameter("p_FROM_LOCATION_ID", pMtyFleetContJo.FromLocationId)
				db.AddParameter("p_TO_LOCATION_ID", pMtyFleetContJo.ToLocationId)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJo.JoType)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJo.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJo.BookingDate)
				db.AddParameter("p_NO_OF_20", pMtyFleetContJo.NoOf20)
				db.AddParameter("p_NO_OF_40", pMtyFleetContJo.NoOf40)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJo.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJo.ContType)
				db.AddParameter("p_CREATED_BY", pMtyFleetContJo.CreatedBy)
				db.AddParameter("p_EMPTY_POD_ID", pMtyFleetContJo.EmptyPodId)
				db.AddParameter("p_EMPTY_POL_ID", pMtyFleetContJo.EmptyPolId)
				db.AddParameter("p_VESSEL_NAME", pMtyFleetContJo.VesselName)
				db.AddParameter("p_VALIDITY", pMtyFleetContJo.Validity)
				db.AddParameter("p_EMPTY_SI_CUTOF_DATE", pMtyFleetContJo.SicutDate)
				db.AddParameter("p_EMPTY_CUTOF_DATE", pMtyFleetContJo.PortCutOfdate)
				db.AddParameter("p_ETD_DATE", pMtyFleetContJo.ETDDate)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJo.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("INSERT_PKG.SP_MTY_FLEET_CONT_JO", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
				pMtyFleetContJo.ContJoId = db.Parameters.Item("p_CONT_JO_ID").value
				pMtyFleetContJo.ContJoNo = db.Parameters.Item("p_CONT_JO_NO").value
				pMtyFleetContJo.CreatedOn = db.Parameters.Item("p_CREATED_ON").value

			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Update Member Function to Update the New Record
		''' </summary>
		''' <param name="pMtyFleetContJo"></param>
		''' <returns>Return pMtyFleetContJo Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function Update(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Try
				db.BeginTransaction()
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJo.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJo.CompanyId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJo.ContJoId)
				db.AddParameter("p_CONT_JO_NO", pMtyFleetContJo.ContJoNo)
				db.AddParameter("p_CONSIGNEE_ID", pMtyFleetContJo.ConsigneeId)
				db.AddParameter("p_CUSTOMER_ID", pMtyFleetContJo.CustomerId)
				db.AddParameter("p_TRANSPORTER_ID", pMtyFleetContJo.TransporterId)
				db.AddParameter("p_SURVEYOR_ID", pMtyFleetContJo.SurveyorId)
				db.AddParameter("p_LINE_ID", pMtyFleetContJo.LineId)
				db.AddParameter("p_FROM_LOCATION_ID", pMtyFleetContJo.FromLocationId)
				db.AddParameter("p_TO_LOCATION_ID", pMtyFleetContJo.ToLocationId)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJo.JoType)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJo.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJo.BookingDate)
				db.AddParameter("p_NO_OF_20", pMtyFleetContJo.NoOf20)
				db.AddParameter("p_NO_OF_40", pMtyFleetContJo.NoOf40)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJo.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJo.ContType)
				db.AddParameter("p_CREATED_BY", pMtyFleetContJo.CreatedBy)
				db.AddParameter("p_EMPTY_POD_ID", pMtyFleetContJo.EmptyPodId)
				db.AddParameter("p_EMPTY_POL_ID", pMtyFleetContJo.EmptyPolId)
				db.AddParameter("p_VESSEL_NAME", pMtyFleetContJo.VesselName)
				db.AddParameter("p_VALIDITY", pMtyFleetContJo.Validity)
				db.AddParameter("p_EMPTY_SI_CUTOF_DATE", pMtyFleetContJo.SicutDate)
				db.AddParameter("p_EMPTY_CUTOF_DATE", pMtyFleetContJo.PortCutOfdate)
				db.AddParameter("p_ETD_DATE", pMtyFleetContJo.ETDDate)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJo.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("UPDATE_PKG.SP_MTY_FLEET_CONT_JO", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
				If pMtyFleetContJo.Errormsg <> Nothing Then
					db.RollbackTransaction()
				Else
					db.CommitTransaction()
				End If
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
				db.RollbackTransaction()
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Update Member Function to Update the New Record
		''' </summary>
		''' <param name="db"></param>
		''' <param name="pMtyFleetContJo"></param>
		''' <returns>Return pMtyFleetContJo Object</returns>
		''' <remarks></remarks>
		'''
		Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Try
				db.ClearParameters()
				db.AddParameter("p_TERMINAL_ID", pMtyFleetContJo.TerminalId)
				db.AddParameter("p_COMPANY_ID", pMtyFleetContJo.CompanyId)
				db.AddParameter("p_CONT_JO_ID", pMtyFleetContJo.ContJoId)
				db.AddParameter("p_CONT_JO_NO", pMtyFleetContJo.ContJoNo)
				db.AddParameter("p_CONSIGNEE_ID", pMtyFleetContJo.ConsigneeId)
				db.AddParameter("p_CUSTOMER_ID", pMtyFleetContJo.CustomerId)
				db.AddParameter("p_TRANSPORTER_ID", pMtyFleetContJo.TransporterId)
				db.AddParameter("p_SURVEYOR_ID", pMtyFleetContJo.SurveyorId)
				db.AddParameter("p_LINE_ID", pMtyFleetContJo.LineId)
				db.AddParameter("p_FROM_LOCATION_ID", pMtyFleetContJo.FromLocationId)
				db.AddParameter("p_TO_LOCATION_ID", pMtyFleetContJo.ToLocationId)
				db.AddParameter("p_JO_TYPE", pMtyFleetContJo.JoType)
				db.AddParameter("p_BOOKING_NO", pMtyFleetContJo.BookingNo)
				db.AddParameter("p_BOOKING_DATE", pMtyFleetContJo.BookingDate)
				db.AddParameter("p_NO_OF_20", pMtyFleetContJo.NoOf20)
				db.AddParameter("p_NO_OF_40", pMtyFleetContJo.NoOf40)
				db.AddParameter("p_CONT_SIZE", pMtyFleetContJo.ContSize)
				db.AddParameter("p_CONT_TYPE", pMtyFleetContJo.ContType)
				db.AddParameter("p_CREATED_BY", pMtyFleetContJo.CreatedBy)
				db.AddParameter("p_EMPTY_POD_ID", pMtyFleetContJo.EmptyPodId)
				db.AddParameter("p_EMPTY_POL_ID", pMtyFleetContJo.EmptyPolId)
				db.AddParameter("p_VESSEL_NAME", pMtyFleetContJo.VesselName)
				db.AddParameter("p_VALIDITY", pMtyFleetContJo.Validity)
				db.AddParameter("p_EMPTY_SI_CUTOF_DATE", pMtyFleetContJo.SicutDate)
				db.AddParameter("p_EMPTY_CUTOF_DATE", pMtyFleetContJo.PortCutOfdate)
				db.AddParameter("p_ETD_DATE", pMtyFleetContJo.ETDDate)
				db.AddParameter("p_ErrorMsg", pMtyFleetContJo.Errormsg, ParameterDirection.Output)
				db.ExecuteScalar("UPDATE_PKG.SP_MTY_FLEET_CONT_JO", CommandType.StoredProcedure)
				If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
					pMtyFleetContJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
				End If
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing ReturnObjectValues Member Function
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property</remarks>
		'''
		Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Try
				If dbr.HasRows Then
					While dbr.Read
						Try
							If dbr("TERMINAL_ID").ToString <> "" Then
								pMtyFleetContJo.TerminalId = dbr("TERMINAL_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("COMPANY_ID").ToString <> "" Then
								pMtyFleetContJo.CompanyId = dbr("COMPANY_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_JO_ID").ToString <> "" Then
								pMtyFleetContJo.ContJoId = dbr("CONT_JO_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_JO_NO").ToString <> "" Then
								pMtyFleetContJo.ContJoNo = dbr("CONT_JO_NO")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("CONSIGNEE_ID").ToString <> "" Then
								pMtyFleetContJo.ConsigneeId = dbr("CONSIGNEE_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CUSTOMER_ID").ToString <> "" Then
								pMtyFleetContJo.CustomerId = dbr("CUSTOMER_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("TRANSPORTER_ID").ToString <> "" Then
								pMtyFleetContJo.TransporterId = dbr("TRANSPORTER_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("SURVEYOR_ID").ToString <> "" Then
								pMtyFleetContJo.SurveyorId = dbr("SURVEYOR_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("LINE_ID").ToString <> "" Then
								pMtyFleetContJo.LineId = dbr("LINE_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("BOOKING_NO").ToString <> "" Then
								pMtyFleetContJo.BookingNo = dbr("BOOKING_NO")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("BOOKING_DATE").ToString <> "" Then
								pMtyFleetContJo.BookingDate = dbr("BOOKING_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("FROM_LOCATION_ID").ToString <> "" Then
								pMtyFleetContJo.FromLocationId = dbr("FROM_LOCATION_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("TO_LOCATION_ID").ToString <> "" Then
								pMtyFleetContJo.ToLocationId = dbr("TO_LOCATION_ID")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("CREATED_BY").ToString <> "" Then
								pMtyFleetContJo.CreatedBy = dbr("CREATED_BY")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CREATED_ON").ToString <> "" Then
								pMtyFleetContJo.CreatedOn = dbr("CREATED_ON")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("JO_TYPE").ToString <> "" Then
								pMtyFleetContJo.JoType = dbr("JO_TYPE")
							End If
						Catch ex1 As Exception
						End Try

						Try
							If dbr("NO_OF_20").ToString <> "" Then
								pMtyFleetContJo.NoOf20 = dbr("NO_OF_20")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("NO_OF_40").ToString <> "" Then
								pMtyFleetContJo.NoOf40 = dbr("NO_OF_40")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_SIZE").ToString <> "" Then
								pMtyFleetContJo.ContSize = dbr("CONT_SIZE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("CONT_TYPE").ToString <> "" Then
								pMtyFleetContJo.ContType = dbr("CONT_TYPE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_POD_ID").ToString <> "" Then
								pMtyFleetContJo.EmptyPodId = dbr("EMPTY_POD_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_POL_ID").ToString <> "" Then
								pMtyFleetContJo.EmptyPolId = dbr("EMPTY_POL_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("VESSEL_NAME").ToString <> "" Then
								pMtyFleetContJo.VesselName = dbr("VESSEL_NAME")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("VALIDITY").ToString <> "" Then
								pMtyFleetContJo.Validity = dbr("VALIDITY")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_SI_CUTOF_DATE").ToString <> "" Then
								pMtyFleetContJo.SicutDate = dbr("EMPTY_SI_CUTOF_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_CUTOF_DATE").ToString <> "" Then
								pMtyFleetContJo.PortCutOfdate = dbr("EMPTY_CUTOF_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ETD_DATE").ToString <> "" Then
								pMtyFleetContJo.ETDDate = dbr("ETD_DATE")
							End If
						Catch ex1 As Exception
						End Try
					End While
				End If
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing ReturnObjectValuesList Member Function
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
		'''
		Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyFleetContJo As ArrayList) As ArrayList
			Dim arrList As New ArrayList
			Try
				If dbr.HasRows Then
					While dbr.Read
						Dim temp As New MtyFleetContJo
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
							If dbr("SURVEYOR_ID").ToString <> "" Then
								temp.SurveyorId = dbr("SURVEYOR_ID")
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
							If dbr("FROM_LOCATION_ID").ToString <> "" Then
								temp.FromLocationId = dbr("FROM_LOCATION_ID")
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
							If dbr("JO_TYPE").ToString <> "" Then
								temp.JoType = dbr("JO_TYPE")
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
							If dbr("EMPTY_POD_ID").ToString <> "" Then
								temp.EmptyPodId = dbr("EMPTY_POD_ID")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_POL_ID").ToString <> "" Then
								temp.EmptyPolId = dbr("EMPTY_POL_ID")
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
							If dbr("EMPTY_SI_CUTOF_DATE").ToString <> "" Then
								temp.SicutDate = dbr("EMPTY_SI_CUTOF_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("EMPTY_CUTOF_DATE").ToString <> "" Then
								temp.PortCutOfdate = dbr("EMPTY_CUTOF_DATE")
							End If
						Catch ex1 As Exception
						End Try
						Try
							If dbr("ETD_DATE").ToString <> "" Then
								temp.ETDDate = dbr("ETD_DATE")
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
		Public Shared Function ReturnMtyFleetContJo(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_JO", pMtyFleetContJo.TerminalId & "," & pMtyFleetContJo.ContJoId & ",'" & pMtyFleetContJo.ContJoNo & "'")
				pMtyFleetContJo = ReturnObjectValues(dbr, pMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing Return Object 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
		'''
		Public Shared Function ReturnMtyFleetContJoHandover(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_JO_HANDOVER", pMtyFleetContJo.FromLocationId & ",'" & pMtyFleetContJo.ContJoNo & "'")
				pMtyFleetContJo = ReturnObjectValues(dbr, pMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing Return Object 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
		'''
		Public Shared Function ReturnMtyFleetContJoVessel(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_JO_VESSL", pMtyFleetContJo.TerminalId & "," & pMtyFleetContJo.ContJoId)
				pMtyFleetContJo = ReturnObjectValues(dbr, pMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing Return Object ArrayList 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
		'''
		Public Shared Function ReturnMtyFleetContJoList(ByVal pMtyFleetContJo As MtyFleetContJo) As ArrayList
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Dim arrMtyFleetContJo As New ArrayList
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO", "' '")
				arrMtyFleetContJo = ReturnObjectValuesList(dbr, arrMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				arrMtyFleetContJo = Nothing
			End Try
			db.CloseDB()
			Return arrMtyFleetContJo
		End Function

		''' <summary>
		''' Preparing Return Object ArrayList 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
		'''
		Public Shared Function ReturnMtyFleetContJoPendingList(ByVal pMtyFleetContJo As MtyFleetContJo) As ArrayList
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Dim arrMtyFleetContJo As New ArrayList
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_CONT_JO", pMtyFleetContJo.TerminalId)
				arrMtyFleetContJo = ReturnObjectValuesList(dbr, arrMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				arrMtyFleetContJo = Nothing
			End Try
			db.CloseDB()
			Return arrMtyFleetContJo
		End Function


		''' <summary>
		''' Preparing Return Object 
		''' </summary>
		''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
		'''
		Public Shared Function ReturnMtyFleetContJoPendingBooking(ByVal pMtyFleetContJo As MtyFleetContJo) As MtyFleetContJo
			Dim db As New DBConnect
			Dim dbr As OleDb.OleDbDataReader
			Try
				db.ClearParameters()
				dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PENDING_BOOKING", ",'" & pMtyFleetContJo.BookingNo & "'")
				pMtyFleetContJo = ReturnObjectValues(dbr, pMtyFleetContJo)
				dbr.Close()
			Catch ex As Exception
				pMtyFleetContJo.Errormsg = ex.Message
			End Try
			db.CloseDB()
			Return pMtyFleetContJo
		End Function
	End Class
End Namespace
