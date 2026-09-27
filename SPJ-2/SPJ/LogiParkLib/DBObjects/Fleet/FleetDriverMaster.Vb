Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  eLOGiFleet :: Fleet Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetDriverMaster
    ''' @author	: Amit K. Singh- 5/8/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetDriverMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngDriverId As Long ' Define Private Variable DriverId With DataType As Long 
        Private strDriverName As String ' Define Private Variable DriverName With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private lngVehicleId As Long ' Define Private Variable VehicleId With DataType As Long 
        Private strVehicleNo As String ' Define Private Variable VehicleNo With DataType As Long 
        Private strContactNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strMobileNo As String ' Define Private Variable MobileNo With DataType As String 
        Private strEmailId As String ' Define Private Variable EmailId With DataType As String 
        Private strBloodGroup As String ' Define Private Variable BloodGroup With DataType As String 
        Private strJoiningDate As String ' Define Private Variable JoiningDate With DataType As String 
        Private strDlNo As String ' Define Private Variable DlNo With DataType As String 
        Private strDlRenewableDate As String ' Define Private Variable DlRenewableDate With DataType As String 
        Private lngSalary As Long ' Define Private Variable Salary With DataType As Long 
        Private strActiveFlage As String ' Define Private Variable ActiveFlage With DataType As String 

        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strImage As String
        Private strGaurantor As String

        Private strJoCloseStatus As String ' Define Private Variable TerminalId With DataType As Long 
        Private lngCloseStatus As Long ' Define Private Variable DriverId With DataType As Long 
        Private strPhoneNo As String ' Define Private Variable ContactNo With DataType As String 
        Private strEmergPhone As String ' Define Private Variable MobileNo With DataType As String 
        Private strAddressDoc As String ' Define Private Variable ContactNo With DataType As String 
        Private strDlDoc As String ' Define Private Variable MobileNo With DataType As String 

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
        ''' Get or Set the Value of DriverId
        ''' </summary>
        ''' <value>lngDriverId</value>
        ''' <returns> Return lngDriverId</returns>
        ''' <remarks> Get or Set the Value of DriverId  </remarks>
        '''
        Public Property DriverId() as Long
            Get
                Return lngDriverId
            End Get
            Set(ByVal value As Long)
                lngDriverId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property CloseStatus() As Long
            Get
                Return lngCloseStatus
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DriverId
        ''' </summary>
        ''' <value>lngDriverId</value>
        ''' <returns> Return lngDriverId</returns>
        ''' <remarks> Get or Set the Value of DriverId  </remarks>
        '''
        Public Property JoCloseStatus() As String
            Get
                Return strJoCloseStatus
            End Get
            Set(ByVal value As String)
                strJoCloseStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DriverName
        ''' </summary>
        ''' <value>strDriverName</value>
        ''' <returns> Return strDriverName</returns>
        ''' <remarks> Get or Set the Value of DriverName  </remarks>
        '''
        Public Property DriverName() as String
            Get
                Return strDriverName
            End Get
            Set(ByVal value As String)
                strDriverName = value
            End Set
        End Property
        Public Property Gaurantor() As String
            Get
                Return strGaurantor
            End Get
            Set(ByVal value As String)
                strGaurantor = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DriverName
        ''' </summary>
        ''' <value>strDriverName</value>
        ''' <returns> Return strDriverName</returns>
        ''' <remarks> Get or Set the Value of DriverName  </remarks>
        '''
        Public Property PhoneNo() As String
            Get
                Return strPhoneNo
            End Get
            Set(ByVal value As String)
                strPhoneNo = value
            End Set
        End Property
        Public Property EmergPhone() As String
            Get
                Return strEmergPhone
            End Get
            Set(ByVal value As String)
                strEmergPhone = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DriverName
        ''' </summary>
        ''' <value>strDriverName</value>
        ''' <returns> Return strDriverName</returns>
        ''' <remarks> Get or Set the Value of DriverName  </remarks>
        '''
        Public Property AddressDoc() As String
            Get
                Return strAddressDoc
            End Get
            Set(ByVal value As String)
                strAddressDoc = value
            End Set
        End Property
        Public Property DlDoc() As String
            Get
                Return strDlDoc
            End Get
            Set(ByVal value As String)
                strDlDoc = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() as String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
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
        ''' <value>lngVehicleNo</value>
        ''' <returns> Return lngVehicleNo</returns>
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
        ''' Get or Set the Value of ContactNo
        ''' </summary>
        ''' <value>strContactNo</value>
        ''' <returns> Return strContactNo</returns>
        ''' <remarks> Get or Set the Value of ContactNo  </remarks>
        '''
        Public Property ContactNo() as String
            Get
                Return strContactNo
            End Get
            Set(ByVal value As String)
                strContactNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MobileNo
        ''' </summary>
        ''' <value>strMobileNo</value>
        ''' <returns> Return strMobileNo</returns>
        ''' <remarks> Get or Set the Value of MobileNo  </remarks>
        '''
        Public Property MobileNo() as String
            Get
                Return strMobileNo
            End Get
            Set(ByVal value As String)
                strMobileNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EmailId
        ''' </summary>
        ''' <value>strEmailId</value>
        ''' <returns> Return strEmailId</returns>
        ''' <remarks> Get or Set the Value of EmailId  </remarks>
        '''
        Public Property EmailId() as String
            Get
                Return strEmailId
            End Get
            Set(ByVal value As String)
                strEmailId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BloodGroup
        ''' </summary>
        ''' <value>strBloodGroup</value>
        ''' <returns> Return strBloodGroup</returns>
        ''' <remarks> Get or Set the Value of BloodGroup  </remarks>
        '''
        Public Property BloodGroup() as String
            Get
                Return strBloodGroup
            End Get
            Set(ByVal value As String)
                strBloodGroup = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of JoiningDate
        ''' </summary>
        ''' <value>strJoiningDate</value>
        ''' <returns> Return strJoiningDate</returns>
        ''' <remarks> Get or Set the Value of JoiningDate  </remarks>
        '''
        Public Property JoiningDate() as String
            Get
                Return strJoiningDate
            End Get
            Set(ByVal value As String)
                strJoiningDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DlNo
        ''' </summary>
        ''' <value>strDlNo</value>
        ''' <returns> Return strDlNo</returns>
        ''' <remarks> Get or Set the Value of DlNo  </remarks>
        '''
        Public Property DlNo() as String
            Get
                Return strDlNo
            End Get
            Set(ByVal value As String)
                strDlNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DlRenewableDate
        ''' </summary>
        ''' <value>strDlRenewableDate</value>
        ''' <returns> Return strDlRenewableDate</returns>
        ''' <remarks> Get or Set the Value of DlRenewableDate  </remarks>
        '''
        Public Property DlRenewableDate() as String
            Get
                Return strDlRenewableDate
            End Get
            Set(ByVal value As String)
                strDlRenewableDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Salary
        ''' </summary>
        ''' <value>lngSalary</value>
        ''' <returns> Return lngSalary</returns>
        ''' <remarks> Get or Set the Value of Salary  </remarks>
        '''
        Public Property Salary() as Long
            Get
                Return lngSalary
            End Get
            Set(ByVal value As Long)
                lngSalary = value
            End Set
        End Property

        
        ''' <summary>
        ''' Get or Set the Value of ActiveFlage
        ''' </summary>
        ''' <value>strActiveFlage</value>
        ''' <returns> Return strActiveFlage</returns>
        ''' <remarks> Get or Set the Value of ActiveFlage  </remarks>
        '''
        Public Property ActiveFlage() as String
            Get
                Return strActiveFlage
            End Get
            Set(ByVal value As String)
                strActiveFlage = value
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

        Public Property Image() As String
            Get
                Return strImage
            End Get
            Set(ByVal value As String)
                strImage = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0 
            lngDriverId = 0 
            strDriverName = ""
            strAddress = ""
            lngVehicleId = 0 
            strVehicleNo = ""
            strContactNo = ""
            strMobileNo = ""
            strEmailId = ""
            strBloodGroup = ""
            strJoiningDate = ""
            strDlNo = ""
            strDlRenewableDate = ""
            lngSalary = 0 
            strActiveFlage = ""

            lngCloseStatus = 0
            strJoCloseStatus = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            strImage = ""
            strPhoneNo = ""
            strEmergPhone = ""
            strAddressDoc = ""
            strDlDoc = ""
            strGaurantor = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetDriverMaster"></param>
        ''' <returns>Return pFleetDriverMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetDriverMaster.TerminalId)
                db.AddParameter("p_DRIVER_ID", pFleetDriverMaster.DriverId, ParameterDirection.Output)
                db.AddParameter("p_DRIVER_NAME", pFleetDriverMaster.DriverName)
                db.AddParameter("p_ADDRESS", pFleetDriverMaster.Address)
                db.AddParameter("p_VEHICLE_ID", pFleetDriverMaster.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetDriverMaster.VehicleNo)
                db.AddParameter("p_CONTACT_NO", pFleetDriverMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pFleetDriverMaster.MobileNo)
                db.AddParameter("p_PHONE_NO", pFleetDriverMaster.PhoneNo)
                db.AddParameter("p_EMERG_PHONE", pFleetDriverMaster.EmergPhone)
                db.AddParameter("p_EMAIL_ID", pFleetDriverMaster.EmailId)
                db.AddParameter("p_BLOOD_GROUP", pFleetDriverMaster.BloodGroup)
                db.AddParameter("p_JOINING_DATE", pFleetDriverMaster.JoiningDate)
                db.AddParameter("p_DL_NO", pFleetDriverMaster.DlNo)
                db.AddParameter("p_DL_RENEWABLE_DATE", pFleetDriverMaster.DlRenewableDate)
                db.AddParameter("p_SALARY", pFleetDriverMaster.Salary)
                db.AddParameter("p_ACTIVE_FLAGE", pFleetDriverMaster.ActiveFlage)
                db.AddParameter("p_CREATED_BY", pFleetDriverMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetDriverMaster.CreatedOn)
                db.AddParameter("p_IMAGE", pFleetDriverMaster.Image)
                db.AddParameter("p_GAURANTOR", pFleetDriverMaster.Gaurantor)
                db.AddParameter("p_ADDRESS_DOC", pFleetDriverMaster.AddressDoc)
                db.AddParameter("p_DL_DOC", pFleetDriverMaster.DlDoc)
                db.AddParameter("p_ErrorMsg", pFleetDriverMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_DRIVER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetDriverMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pFleetDriverMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetDriverMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetDriverMaster"></param>
        ''' <returns>Return pFleetDriverMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetDriverMaster.TerminalId)
                db.AddParameter("p_DRIVER_ID", pFleetDriverMaster.DriverId, ParameterDirection.Output)
                db.AddParameter("p_DRIVER_NAME", pFleetDriverMaster.DriverName)
                db.AddParameter("p_ADDRESS", pFleetDriverMaster.Address)
                db.AddParameter("p_VEHICLE_ID", pFleetDriverMaster.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetDriverMaster.VehicleNo)
                db.AddParameter("p_CONTACT_NO", pFleetDriverMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pFleetDriverMaster.MobileNo)
                db.AddParameter("p_PHONE_NO", pFleetDriverMaster.PhoneNo)
                db.AddParameter("p_EMERG_PHONE", pFleetDriverMaster.EmergPhone)
                db.AddParameter("p_EMAIL_ID", pFleetDriverMaster.EmailId)
                db.AddParameter("p_BLOOD_GROUP", pFleetDriverMaster.BloodGroup)
                db.AddParameter("p_JOINING_DATE", pFleetDriverMaster.JoiningDate)
                db.AddParameter("p_DL_NO", pFleetDriverMaster.DlNo)
                db.AddParameter("p_DL_RENEWABLE_DATE", pFleetDriverMaster.DlRenewableDate)
                db.AddParameter("p_SALARY", pFleetDriverMaster.Salary)
                db.AddParameter("p_ACTIVE_FLAGE", pFleetDriverMaster.ActiveFlage)
                db.AddParameter("p_CREATED_BY", pFleetDriverMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetDriverMaster.CreatedOn)
                db.AddParameter("p_IMAGE", pFleetDriverMaster.Image)
                db.AddParameter("p_GAURANTOR", pFleetDriverMaster.Gaurantor)
                db.AddParameter("p_ADDRESS_DOC", pFleetDriverMaster.AddressDoc)
                db.AddParameter("p_DL_DOC", pFleetDriverMaster.DlDoc)
                db.AddParameter("p_ErrorMsg", pFleetDriverMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_DRIVER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetDriverMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pFleetDriverMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetDriverMaster"></param>
        ''' <returns>Return pFleetDriverMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetDriverMaster.TerminalId)
                db.AddParameter("p_DRIVER_ID", pFleetDriverMaster.DriverId, Global.System.Data.ParameterDirection.InputOutput)
                db.AddParameter("p_DRIVER_NAME", pFleetDriverMaster.DriverName)
                db.AddParameter("p_ADDRESS", pFleetDriverMaster.Address)
                db.AddParameter("p_VEHICLE_ID", pFleetDriverMaster.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetDriverMaster.VehicleNo)
                db.AddParameter("p_CONTACT_NO", pFleetDriverMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pFleetDriverMaster.MobileNo)
                db.AddParameter("p_PHONE_NO", pFleetDriverMaster.PhoneNo)
                db.AddParameter("p_EMERG_PHONE", pFleetDriverMaster.EmergPhone)
                db.AddParameter("p_EMAIL_ID", pFleetDriverMaster.EmailId)
                db.AddParameter("p_BLOOD_GROUP", pFleetDriverMaster.BloodGroup)
                db.AddParameter("p_JOINING_DATE", pFleetDriverMaster.JoiningDate)
                db.AddParameter("p_DL_NO", pFleetDriverMaster.DlNo)
                db.AddParameter("p_DL_RENEWABLE_DATE", pFleetDriverMaster.DlRenewableDate)
                db.AddParameter("p_SALARY", pFleetDriverMaster.Salary)
                db.AddParameter("p_ACTIVE_FLAGE", pFleetDriverMaster.ActiveFlage)
                db.AddParameter("p_CREATED_BY", pFleetDriverMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetDriverMaster.CreatedOn)
                db.AddParameter("p_IMAGE", pFleetDriverMaster.Image)
                db.AddParameter("p_GAURANTOR", pFleetDriverMaster.Gaurantor)
                db.AddParameter("p_ADDRESS_DOC", pFleetDriverMaster.AddressDoc)
                db.AddParameter("p_DL_DOC", pFleetDriverMaster.DlDoc)
                db.AddParameter("p_ErrorMsg", pFleetDriverMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_DRIVER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetDriverMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetDriverMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetDriverMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetDriverMaster"></param>
        ''' <returns>Return pFleetDriverMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetDriverMaster.TerminalId)
                db.AddParameter("p_DRIVER_ID", pFleetDriverMaster.DriverId, ParameterDirection.Output)
                db.AddParameter("p_DRIVER_NAME", pFleetDriverMaster.DriverName)
                db.AddParameter("p_ADDRESS", pFleetDriverMaster.Address)
                db.AddParameter("p_VEHICLE_ID", pFleetDriverMaster.VehicleId)
                db.AddParameter("p_VEHICLE_NO", pFleetDriverMaster.VehicleNo)
                db.AddParameter("p_CONTACT_NO", pFleetDriverMaster.ContactNo)
                db.AddParameter("p_MOBILE_NO", pFleetDriverMaster.MobileNo)
                db.AddParameter("p_PHONE_NO", pFleetDriverMaster.PhoneNo)
                db.AddParameter("p_EMERG_PHONE", pFleetDriverMaster.EmergPhone)
                db.AddParameter("p_EMAIL_ID", pFleetDriverMaster.EmailId)
                db.AddParameter("p_BLOOD_GROUP", pFleetDriverMaster.BloodGroup)
                db.AddParameter("p_JOINING_DATE", pFleetDriverMaster.JoiningDate)
                db.AddParameter("p_DL_NO", pFleetDriverMaster.DlNo)
                db.AddParameter("p_DL_RENEWABLE_DATE", pFleetDriverMaster.DlRenewableDate)
                db.AddParameter("p_SALARY", pFleetDriverMaster.Salary)
                db.AddParameter("p_ACTIVE_FLAGE", pFleetDriverMaster.ActiveFlage)
                db.AddParameter("p_CREATED_BY", pFleetDriverMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetDriverMaster.CreatedOn)
                db.AddParameter("p_IMAGE", pFleetDriverMaster.Image)
                db.AddParameter("p_GAURANTOR", pFleetDriverMaster.Gaurantor)
                db.AddParameter("p_ADDRESS_DOC", pFleetDriverMaster.AddressDoc)
                db.AddParameter("p_DL_DOC", pFleetDriverMaster.DlDoc)
                db.AddParameter("p_ErrorMsg", pFleetDriverMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_DRIVER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetDriverMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetDriverMaster.ErrorMsg = ex.Message
                End Try
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetDriverMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_ID").ToString <> "" Then
                                PFleetDriverMaster.DriverId = dbr("DRIVER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DRIVER_NAME").ToString <> "" Then
                                PFleetDriverMaster.DriverName = dbr("DRIVER_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PFleetDriverMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_ID").ToString <> "" Then
                                PFleetDriverMaster.VehicleId = dbr("VEHICLE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VEHICLE_NO").ToString <> "" Then
                                PFleetDriverMaster.VehicleNo = dbr("VEHICLE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                PFleetDriverMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MOBILE_NO").ToString <> "" Then
                                PFleetDriverMaster.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                PFleetDriverMaster.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BLOOD_GROUP").ToString <> "" Then
                                PFleetDriverMaster.BloodGroup = dbr("BLOOD_GROUP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOINING_DATE").ToString <> "" Then
                                PFleetDriverMaster.JoiningDate = dbr("JOINING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_NO").ToString <> "" Then
                                PFleetDriverMaster.DlNo = dbr("DL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_RENEWABLE_DATE").ToString <> "" Then
                                PFleetDriverMaster.DlRenewableDate = dbr("DL_RENEWABLE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SALARY").ToString <> "" Then
                                PFleetDriverMaster.Salary = dbr("SALARY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE_FLAGE").ToString <> "" Then
                                PFleetDriverMaster.ActiveFlage = dbr("ACTIVE_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                       
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetDriverMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetDriverMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMAGE").ToString <> "" Then
                                pFleetDriverMaster.Image = dbr("IMAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_STATUS").ToString <> "" Then
                                pFleetDriverMaster.CloseStatus = dbr("CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_CLOSE_STATUS").ToString <> "" Then
                                pFleetDriverMaster.JoCloseStatus = dbr("JO_CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GAURANTOR").ToString <> "" Then
                                pFleetDriverMaster.Gaurantor = dbr("GAURANTOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PHONE_NO").ToString <> "" Then
                                pFleetDriverMaster.PhoneNo = dbr("PHONE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMERG_PHONE").ToString <> "" Then
                                pFleetDriverMaster.EmergPhone = dbr("EMERG_PHONE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("ADDRESS_DOC").ToString <> "" Then
                                pFleetDriverMaster.AddressDoc = dbr("ADDRESS_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_DOC").ToString <> "" Then
                                pFleetDriverMaster.DlDoc = dbr("DL_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try

                    End While
                end If
            Catch ex As Exception
                pFleetDriverMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetDriverMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetDriverMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
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
                            If dbr("CONTACT_NO").ToString <> "" Then
                                temp.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MOBILE_NO").ToString <> "" Then
                                temp.MobileNo = dbr("MOBILE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMAIL_ID").ToString <> "" Then
                                temp.EmailId = dbr("EMAIL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BLOOD_GROUP").ToString <> "" Then
                                temp.BloodGroup = dbr("BLOOD_GROUP")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JOINING_DATE").ToString <> "" Then
                                temp.JoiningDate = dbr("JOINING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_NO").ToString <> "" Then
                                temp.DlNo = dbr("DL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_RENEWABLE_DATE").ToString <> "" Then
                                temp.DlRenewableDate = dbr("DL_RENEWABLE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SALARY").ToString <> "" Then
                                temp.Salary = dbr("SALARY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE_FLAGE").ToString <> "" Then
                                temp.ActiveFlage = dbr("ACTIVE_FLAGE")
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
                            If dbr("IMAGE").ToString <> "" Then
                                temp.Image = dbr("IMAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CLOSE_STATUS").ToString <> "" Then
                                temp.CloseStatus = dbr("CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_CLOSE_STATUS").ToString <> "" Then
                                temp.JoCloseStatus = dbr("JO_CLOSE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GAURANTOR").ToString <> "" Then
                                temp.Gaurantor = dbr("GAURANTOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PHONE_NO").ToString <> "" Then
                                temp.PhoneNo = dbr("PHONE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EMERG_PHONE").ToString <> "" Then
                                temp.EmergPhone = dbr("EMERG_PHONE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("ADDRESS_DOC").ToString <> "" Then
                                temp.AddressDoc = dbr("ADDRESS_DOC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DL_DOC").ToString <> "" Then
                                temp.DlDoc = dbr("DL_DOC")
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
        Public Shared Function ReturnFleetDriverMaster(ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_DRIVER_MASTER_BY_ID", pFleetDriverMaster.TerminalId & "," & pFleetDriverMaster.DriverId)
                pFleetDriverMaster = ReturnObjectValues(dbr, pFleetDriverMaster)
                dbr.Close()
            Catch ex As Exception
                pFleetDriverMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetDriverMaster
        End Function

        Public Shared Function ReturnFleetDriverMasterByVehicle(ByVal pFleetDriverMaster As FleetDriverMaster) As FleetDriverMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_DRIVER_MASTER_VEHICLE", pFleetDriverMaster.TerminalId & "," & pFleetDriverMaster.VehicleId & ",'" & pFleetDriverMaster.VehicleNo & "'")
                pFleetDriverMaster = ReturnObjectValues(dbr, pFleetDriverMaster)
                dbr.Close()
            Catch ex As Exception
                pFleetDriverMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetDriverMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetDriverMasterList (ByVal pFleetDriverMaster As FleetDriverMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetDriverMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_DRIVER_MASTER_ALL", pFleetDriverMaster.TerminalId)
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
