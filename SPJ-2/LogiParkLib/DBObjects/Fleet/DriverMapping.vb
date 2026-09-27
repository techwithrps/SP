Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    Public Class DriverMapping
        Private lngAttachId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngDiverId As Long ' Define Private Variable EquipmentId With DataType As Long 
        Private strDriverName As String ' Define Private Variable TireNo With DataType As String 
        Private lngEquipmentId As Long ' Define Private Variable InstallationDate With DataType As String 
        Private strEquipmentNo As String ' Define Private Variable InstallLocation With DataType As String 
        ' Private strEquipmentType As String  ' Define Private Variable TerminalId With DataType As Long 
        Private strAttachBy As String ' Define Private Variable EquipmentId With DataType As Long 
        Private StrAttachDate As String ' Define Private Variable TireNo With DataType As String 
        Private StrDetachDate As String ' Define Private Variable InstallationDate With DataType As String 
        Private StrVehicleSize As String
        Private StrVehicleType As String
        Private strDetachBy As String ' 
        Private strRemark As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Dim arrlistDriverAttachDetach As ArrayList
        Public Property listDriverAttachDetach() As ArrayList
            Get
                Return arrlistDriverAttachDetach
            End Get
            Set(ByVal value As ArrayList)
                arrlistDriverAttachDetach = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property AttachId() As Long
            Get
                Return lngAttachId
            End Get
            Set(ByVal value As Long)
                lngAttachId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EquipmentId
        ''' </summary>
        ''' <value>lngEquipmentId</value>
        ''' <returns> Return lngEquipmentId</returns>
        ''' <remarks> Get or Set the Value of EquipmentId  </remarks>
        '''
        Public Property DriverId() As Long
            Get
                Return lngDiverId
            End Get
            Set(ByVal value As Long)
                lngDiverId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TireNo
        ''' </summary>
        ''' <value>strTireNo</value>
        ''' <returns> Return strTireNo</returns>
        ''' <remarks> Get or Set the Value of TireNo  </remarks>
        '''
        Public Property DriverName() As String
            Get
                Return strDriverName
            End Get
            Set(ByVal value As String)
                strDriverName = value
            End Set
        End Property

        Public Property VehicleType() As String
            Get
                Return StrVehicleType
            End Get
            Set(ByVal value As String)
                StrVehicleType = value
            End Set
        End Property

        Public Property VehicleSize() As String
            Get
                Return StrVehicleSize
            End Get
            Set(ByVal value As String)
                StrVehicleSize = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of InstallationDate
        ''' </summary>
        ''' <value>strInstallationDate</value>
        ''' <returns> Return strInstallationDate</returns>
        ''' <remarks> Get or Set the Value of InstallationDate  </remarks>
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
        ''' Get or Set the Value of InstallLocation
        ''' </summary>
        ''' <value>strInstallLocation</value>
        ''' <returns> Return strInstallLocation</returns>
        ''' <remarks> Get or Set the Value of InstallLocation  </remarks>
        '''
        Public Property EquipmentNo() As String
            Get
                Return strEquipmentNo
            End Get
            Set(ByVal value As String)
                strEquipmentNo = value
            End Set
        End Property

        Public Property AttachDate() As String
            Get
                Return StrAttachDate
            End Get
            Set(ByVal value As String)
                StrAttachDate = value
            End Set
        End Property
        Public Property AttachBy() As String
            Get
                Return strAttachBy
            End Get
            Set(ByVal value As String)
                strAttachBy = value
            End Set
        End Property
        Public Property DetachDate() As String
            Get
                Return StrDetachDate
            End Get
            Set(ByVal value As String)
                StrDetachDate = value
            End Set
        End Property
        Public Property DetachBy() As String
            Get
                Return strDetachBy
            End Get
            Set(ByVal value As String)
                strDetachBy = value
            End Set
        End Property
        Public Property DetachRemark() As String
            Get
                Return strRemark
            End Get
            Set(ByVal value As String)
                strRemark = value
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
            lngAttachId = 0
            lngDiverId = 0
            strDriverName = ""
            lngEquipmentId = 0
            strEquipmentNo = ""
            strAttachBy = ""
            StrAttachDate = ""
            strDetachBy = ""
            StrDetachDate = ""
            StrVehicleSize = ""
            StrVehicleType = ""
            strRemark = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pdDriverAttachDetach"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ATTACH_ID", pdDriverAttachDetach.AttachBy, ParameterDirection.Output)
                db.AddParameter("p_DRIVER_ID", pdDriverAttachDetach.DriverId)
                db.AddParameter("p_DRIVER_NAME", pdDriverAttachDetach.DriverName)
                db.AddParameter("p_EQUIPMENT_ID", pdDriverAttachDetach.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pdDriverAttachDetach.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE", pdDriverAttachDetach.VehicleType)
                'db.AddParameter("p_TIRE_POSITION", pdDriverAttachDetach.TirePosition)
                db.AddParameter("p_ATTACH_DATE", pdDriverAttachDetach.AttachDate)
                db.AddParameter("p_ATTACH_BY", pdDriverAttachDetach.AttachBy)
                ' db.AddParameter("p_EQUIPMENT_TYPE_CODE", pdDriverAttachDetach.EquipmentTypeCode)
                db.AddParameter("p_ErrorMsg", pdDriverAttachDetach.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TIRE_ATTACH_DETACH", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pdDriverAttachDetach.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pdDriverAttachDetach.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pdDriverAttachDetach
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pdDriverAttachDetach"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_ATTACH_ID", pdDriverAttachDetach.AttachId, ParameterDirection.Output)
                db.AddParameter("p_DRIVER_ID", pdDriverAttachDetach.DriverId)
                db.AddParameter("p_DRIVER_NAME", pdDriverAttachDetach.DriverName)
                db.AddParameter("p_EQUIPMENT_ID", pdDriverAttachDetach.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pdDriverAttachDetach.EquipmentNo)
                db.AddParameter("p_ATTACH_DATE", pdDriverAttachDetach.AttachDate)
                db.AddParameter("p_ATTACH_BY", pdDriverAttachDetach.AttachBy)
                db.AddParameter("p_VEHICLE_TYPE", pdDriverAttachDetach.VehicleType)
                ' db.AddParameter("p_VEHICLE_SIZE", pdDriverAttachDetach.VehicleSize)
                db.AddParameter("p_ErrorMsg", pdDriverAttachDetach.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DRIVER_ATTACH_DETACH", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pdDriverAttachDetach.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
            End Try
            Return pdDriverAttachDetach
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pdDriverAttachDetach"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ATTACH_ID", pdDriverAttachDetach.AttachId)
                db.AddParameter("p_DRIVER_ID", pdDriverAttachDetach.DriverId)
                db.AddParameter("p_DRIVER_NAME", pdDriverAttachDetach.DriverName)
                db.AddParameter("p_DETACH_DATE", pdDriverAttachDetach.DetachDate)
                db.AddParameter("p_DETACH_BY", pdDriverAttachDetach.DetachBy)
                db.AddParameter("p_DETACH_REMARK", pdDriverAttachDetach.DetachRemark)
                db.AddParameter("p_ErrorMsg", pdDriverAttachDetach.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TIRE_ATTACH_DETACH", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pdDriverAttachDetach.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pdDriverAttachDetach.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pdDriverAttachDetach
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pdDriverAttachDetach"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_ATTACH_ID", pdDriverAttachDetach.AttachId)
                db.AddParameter("p_DRIVER_ID", pdDriverAttachDetach.DriverId)
                db.AddParameter("p_DRIVER_NAME", pdDriverAttachDetach.DriverName)
                db.AddParameter("p_EQUIPMENT_NO", pdDriverAttachDetach.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_ID", pdDriverAttachDetach.EquipmentId)
                db.AddParameter("p_DETACH_DATE", pdDriverAttachDetach.DetachDate)
                db.AddParameter("p_DETACH_BY", pdDriverAttachDetach.DetachBy)
                '  db.AddParameter("p_BED_TYPE", pdDriverAttachDetach.BedType)
                'db.AddParameter("p_VEHICLE_SIZE", pdDriverAttachDetach.VehicleSize)
                db.AddParameter("p_DETACH_REMARK", pdDriverAttachDetach.DetachRemark)
                db.AddParameter("p_ErrorMsg", pdDriverAttachDetach.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DRIVER_DETACH", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pdDriverAttachDetach.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
            End Try
            Return pdDriverAttachDetach
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("ATTACHMENT_ID").ToString <> "" Then
                                pdDriverAttachDetach.AttachId = dbr("ATTACHMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                pdDriverAttachDetach.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_NAME").ToString <> "" Then
                                pdDriverAttachDetach.DriverName = dbr("DRIVER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                pdDriverAttachDetach.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_NO").ToString <> "" Then
                                pdDriverAttachDetach.EquipmentNo = dbr("EQUIPMENT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ATTACHMENT_DATE").ToString <> "" Then
                                pdDriverAttachDetach.AttachDate = dbr("ATTACHMENT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_REMARKS").ToString <> "" Then
                                pdDriverAttachDetach.DetachRemark = dbr("DETACH_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_DATE").ToString <> "" Then
                                pdDriverAttachDetach.DetachDate = dbr("DETACH_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ATTACH_BY").ToString <> "" Then
                                pdDriverAttachDetach.AttachBy = dbr("ATTACH_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_BY").ToString <> "" Then
                                pdDriverAttachDetach.DetachBy = dbr("DETACH_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_SIZE").ToString <> "" Then
                                pdDriverAttachDetach.VehicleSize = dbr("VEHICLE_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                pdDriverAttachDetach.VehicleType = dbr("VEHICLE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try

                    End While
                End If
            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
            End Try
            Return pdDriverAttachDetach
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrDriverAttachDetach As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New DriverMapping
                        Try
                            If dbr("ATTACHMENT_ID").ToString <> "" Then
                                temp.AttachId = dbr("ATTACHMENT_ID")
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
                            If dbr("DRIVER_NAME").ToString <> "" Then
                                temp.DriverName = dbr("DRIVER_NAME")
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
                            If dbr("ATTACHMENT_DATE").ToString <> "" Then
                                temp.AttachDate = dbr("ATTACHMENT_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_REMARKS").ToString <> "" Then
                                temp.DetachRemark = dbr("DETACH_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_DATE").ToString <> "" Then
                                temp.DetachDate = dbr("DETACH_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ATTACH_BY").ToString <> "" Then
                                temp.AttachBy = dbr("ATTACH_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DETACH_BY").ToString <> "" Then
                                temp.DetachBy = dbr("DETACH_BY")
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
                            If dbr("VEHICLE_TYPE").ToString <> "" Then
                                temp.VehicleType = dbr("VEHICLE_TYPE")
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
        Public Shared Function ReturnDriverAttachDetach(ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TIRE_ATTACH_DETACH", "' '")
                pdDriverAttachDetach = ReturnObjectValues(dbr, pdDriverAttachDetach)
                dbr.Close()
            Catch ex As Exception
                pdDriverAttachDetach.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pdDriverAttachDetach
        End Function
        Public Shared Function InsertDriverAttachDetachDetails(ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Dim db As New DBConnect

            Try
                db.BeginTransaction()

                For Each tgh As DriverMapping In pdDriverAttachDetach.listDriverAttachDetach
                    DriverMapping.InsertTrn(db, tgh)
                    If tgh.Errormsg <> "" Then
                        Throw New Exception(tgh.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                ' DriverAttachDetach.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
            End Try
            Return pdDriverAttachDetach
        End Function
        Public Shared Function UpdateDriverDetachDetails(ByVal pdDriverAttachDetach As DriverMapping) As DriverMapping
            Dim db As New DBConnect

            Try
                db.BeginTransaction()

                For Each tgh As DriverMapping In pdDriverAttachDetach.listDriverAttachDetach

                    DriverMapping.UpdateTrn(db, tgh)
                Next

                db.CommitTransaction()
            Catch ex As Exception
                ' pBedMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
            End Try
            Return pdDriverAttachDetach
        End Function
        Public Shared Function ReturnDriverMasterListForDriverAttachDetachDetach(ByVal pdDriverAttachDetach As DriverMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetDriverMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_DRIVER_MASTER_MAP", "' '")
                arrFleetDriverMaster = ReturnObjectValuesList(dbr, arrFleetDriverMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetDriverMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetDriverMaster
        End Function
        Public Shared Function ReturnDriverMasterListForDriverDetach(ByVal pdDriverAttachDetach As DriverMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetDriverMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_DRIVER_MASTER_DEATCH", "' '")
                arrFleetDriverMaster = ReturnObjectValuesList(dbr, arrFleetDriverMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetDriverMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetDriverMaster
        End Function

    End Class
End Namespace
