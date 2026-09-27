Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetCostDtls
    ''' @author	: Santosh Singh- 18/3/2016
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetCostDtls

        Private lngCostDtlsId As Long ' Define Private Variable CostDtlsId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private lngTripId As Long ' Define Private Variable TripId With DataType As Long 
        Private lngAmount As Long ' Define Private Variable Amount With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strJoType As String ' Define Private Variable Remarks With DataType As String
        Private lngDriverid As Long
        Private lngVehicleNo As Long
        Private lngVendorId As Long
        Private strBillNo As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of CostDtlsId
        ''' </summary>
        ''' <value>lngCostDtlsId</value>
        ''' <returns> Return lngCostDtlsId</returns>
        ''' <remarks> Get or Set the Value of CostDtlsId  </remarks>
        '''
        Public Property CostDtlsId() As Long
            Get
                Return lngCostDtlsId
            End Get
            Set(ByVal value As Long)
                lngCostDtlsId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of VehicleNo
        ''' </summary>
        ''' <value>lngVehicleNo</value>
        ''' <returns> Return lngVehicleNo</returns>
        ''' <remarks> Get or Set the Value of VehicleNo  </remarks>
        '''
        Public Property VehicleNo() As Long
            Get
                Return lngVehicleNo
            End Get
            Set(ByVal value As Long)
                lngVehicleNo = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of VendorId
        ''' </summary>
        ''' <value>lngVendorId</value>
        ''' <returns> Return lngVendorId</returns>
        ''' <remarks> Get or Set the Value of VendorId  </remarks>
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
        ''' Get or Set the Value of BillNo
        ''' </summary>
        ''' <value>strBillNo</value>
        ''' <returns> Return strBillNo</returns>
        ''' <remarks> Get or Set the Value of BillNo  </remarks>
        '''
        Public Property BillNo() As String
            Get
                Return strBillNo
            End Get
            Set(ByVal value As String)
                strBillNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property

        Public Property DriverId() As Long
            Get
                Return lngDriverid
            End Get
            Set(ByVal value As Long)
                lngDriverid = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TripId
        ''' </summary>
        ''' <value>lngTripId</value>
        ''' <returns> Return lngTripId</returns>
        ''' <remarks> Get or Set the Value of TripId  </remarks>
        '''
        Public Property TripId() As Long
            Get
                Return lngTripId
            End Get
            Set(ByVal value As Long)
                lngTripId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Amount
        ''' </summary>
        ''' <value>lngAmount</value>
        ''' <returns> Return lngAmount</returns>
        ''' <remarks> Get or Set the Value of Amount  </remarks>
        '''
        Public Property Amount() As Long
            Get
                Return lngAmount
            End Get
            Set(ByVal value As Long)
                lngAmount = value
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
        Public Property JoType() As String
            Get
                Return strJoType
            End Get
            Set(ByVal value As String)
                strJoType = value
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
            lngCostDtlsId = 0
            lngServiceId = 0
            lngTripId = 0
            lngAmount = 0
            lngDriverid = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strRemarks = ""
            lngTerminalId = 0
            strErrormsg = ""
            strJoType = ""
            lngVehicleNo = 0
            lngVendorId = 0
            strBillNo = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetCostDtls"></param>
        ''' <returns>Return pFleetCostDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_DTLS_ID", pFleetCostDtls.CostDtlsId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pFleetCostDtls.ServiceId)
                db.AddParameter("p_TRIP_ID", pFleetCostDtls.TripId)
                db.AddParameter("p_AMOUNT", pFleetCostDtls.Amount)
                db.AddParameter("p_CREATED_BY", pFleetCostDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetCostDtls.CreatedOn)
                db.AddParameter("p_REMARKS", pFleetCostDtls.Remarks)
                db.AddParameter("p_TERMINAL_ID", pFleetCostDtls.TerminalId)
                db.AddParameter("p_TJO_TYPE", pFleetCostDtls.JoType)
                db.AddParameter("P_DRIVER_ID", pFleetCostDtls.DriverId)
                db.AddParameter("p_ErrorMsg", pFleetCostDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_COST_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetCostDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetCostDtls.CostDtlsId = db.Parameters.Item("p_COST_DTLS_ID").value

                If pFleetCostDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetCostDtls"></param>
        ''' <returns>Return pFleetCostDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_DTLS_ID", pFleetCostDtls.CostDtlsId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_ID", pFleetCostDtls.ServiceId)
                db.AddParameter("p_TRIP_ID", pFleetCostDtls.TripId)
                db.AddParameter("p_AMOUNT", pFleetCostDtls.Amount)
                db.AddParameter("p_CREATED_BY", pFleetCostDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetCostDtls.CreatedOn)
                db.AddParameter("p_REMARKS", pFleetCostDtls.Remarks)
                db.AddParameter("p_TERMINAL_ID", pFleetCostDtls.TerminalId)
                db.AddParameter("p_TJO_TYPE", pFleetCostDtls.JoType)
                db.AddParameter("P_DRIVER_ID", pFleetCostDtls.DriverId)
                db.AddParameter("P_EQUIPMENT_ID", pFleetCostDtls.VehicleNo)
                db.AddParameter("P_VENDOR_ID", pFleetCostDtls.VendorId)
                db.AddParameter("P_BILL_NO", pFleetCostDtls.BillNo)
                db.AddParameter("p_ErrorMsg", pFleetCostDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_COST_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetCostDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetCostDtls.CostDtlsId = db.Parameters.Item("p_COST_DTLS_ID").value

            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
            End Try
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetCostDtls"></param>
        ''' <returns>Return pFleetCostDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_DTLS_ID", pFleetCostDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pFleetCostDtls.ServiceId)
                db.AddParameter("p_TRIP_ID", pFleetCostDtls.TripId)
                db.AddParameter("p_AMOUNT", pFleetCostDtls.Amount)
                db.AddParameter("p_CREATED_BY", pFleetCostDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetCostDtls.CreatedOn)
                db.AddParameter("p_REMARKS", pFleetCostDtls.Remarks)
                db.AddParameter("p_TERMINAL_ID", pFleetCostDtls.TerminalId)
                db.AddParameter("p_TJO_TYPE", pFleetCostDtls.JoType)
                db.AddParameter("p_ErrorMsg", pFleetCostDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_COST_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetCostDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetCostDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetCostDtls"></param>
        ''' <returns>Return pFleetCostDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_DTLS_ID", pFleetCostDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pFleetCostDtls.ServiceId)
                db.AddParameter("p_TRIP_ID", pFleetCostDtls.TripId)
                db.AddParameter("p_AMOUNT", pFleetCostDtls.Amount)
                db.AddParameter("p_CREATED_BY", pFleetCostDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetCostDtls.CreatedOn)
                db.AddParameter("p_REMARKS", pFleetCostDtls.Remarks)
                db.AddParameter("p_TERMINAL_ID", pFleetCostDtls.TerminalId)
                db.AddParameter("p_TJO_TYPE", pFleetCostDtls.JoType)
                db.AddParameter("p_ErrorMsg", pFleetCostDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_COST_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetCostDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
            End Try
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                pFleetCostDtls.CostDtlsId = dbr("COST_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pFleetCostDtls.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRIP_ID").ToString <> "" Then
                                pFleetCostDtls.TripId = dbr("TRIP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                pFleetCostDtls.Amount = dbr("AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetCostDtls.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetCostDtls.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pFleetCostDtls.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pFleetCostDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                pFleetCostDtls.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                pFleetCostDtls.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                pFleetCostDtls.VehicleNo = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pFleetCostDtls.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_NO").ToString <> "" Then
                                pFleetCostDtls.BillNo = dbr("BILL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
            End Try
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetCostDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetCostDtls
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                temp.CostDtlsId = dbr("COST_DTLS_ID")
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
                            If dbr("TRIP_ID").ToString <> "" Then
                                temp.TripId = dbr("TRIP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                temp.Amount = dbr("AMOUNT")
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
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
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
                            If dbr("JO_TYPE").ToString <> "" Then
                                temp.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                temp.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                temp.VehicleNo = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                temp.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_NO").ToString <> "" Then
                                temp.BillNo = dbr("BILL_NO")
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
        Public Shared Function ReturnFleetCostDtls(ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_COST_DTLS", "' '")
                pFleetCostDtls = ReturnObjectValues(dbr, pFleetCostDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetCostDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetCostDtlsList(ByVal pFleetCostDtls As FleetCostDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetCostDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_COST_DTLS", "' '")
                arrFleetCostDtls = ReturnObjectValuesList(dbr, arrFleetCostDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetCostDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetCostDtls
        End Function
        Private arrFleetCostDtls As ArrayList
        Public Property FleetCostDtlsList() As ArrayList
            Get
                Return arrFleetCostDtls
            End Get
            Set(ByVal value As ArrayList)
                arrFleetCostDtls = value
            End Set
        End Property

        Public Shared Function InsertTransaction(ByVal pFleetCostDtls As FleetCostDtls) As FleetCostDtls
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()


                For Each det As FleetCostDtls In pFleetCostDtls.FleetCostDtlsList

                    FleetCostDtls.InsertTrn(db, det)
                    If det.Errormsg <> "" Then
                        Throw New Exception(det.Errormsg)
                    End If
                Next

                db.CommitTransaction()
            Catch ex As Exception
                pFleetCostDtls.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pFleetCostDtls
        End Function
    End Class
End Namespace
