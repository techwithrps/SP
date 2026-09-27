Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetServicingDtls
    ''' @author	: Santosh Singh- 28/8/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetServicingDtls 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngEquipmentId As Long ' Define Private Variable EquipmentId With DataType As Long 
        Private lngOdometerReading As Long ' Define Private Variable OdometerReading With DataType As Long 
        Private strServicingDate As String ' Define Private Variable ServicingDate With DataType As String 
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
        ''' Get or Set the Value of EquipmentId
        ''' </summary>
        ''' <value>lngEquipmentId</value>
        ''' <returns> Return lngEquipmentId</returns>
        ''' <remarks> Get or Set the Value of EquipmentId  </remarks>
        '''
        Public Property EquipmentId() as Long
            Get
                Return lngEquipmentId
            End Get
            Set(ByVal value As Long)
                lngEquipmentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of OdometerReading
        ''' </summary>
        ''' <value>lngOdometerReading</value>
        ''' <returns> Return lngOdometerReading</returns>
        ''' <remarks> Get or Set the Value of OdometerReading  </remarks>
        '''
        Public Property OdometerReading() as Long
            Get
                Return lngOdometerReading
            End Get
            Set(ByVal value As Long)
                lngOdometerReading = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServicingDate
        ''' </summary>
        ''' <value>strServicingDate</value>
        ''' <returns> Return strServicingDate</returns>
        ''' <remarks> Get or Set the Value of ServicingDate  </remarks>
        '''
        Public Property ServicingDate() as String
            Get
                Return strServicingDate
            End Get
            Set(ByVal value As String)
                strServicingDate = value
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
            lngEquipmentId = 0 
            lngOdometerReading = 0 
            strServicingDate = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetServicingDtls"></param>
        ''' <returns>Return pFleetServicingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetServicingDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetServicingDtls.EquipmentId)
                db.AddParameter("p_ODOMETER_READING", pFleetServicingDtls.OdometerReading)
                db.AddParameter("p_SERVICING_DATE", pFleetServicingDtls.ServicingDate)
                db.AddParameter("p_CREATED_BY", pFleetServicingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetServicingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetServicingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_SERVICING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetServicingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pFleetServicingDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetServicingDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetServicingDtls"></param>
        ''' <returns>Return pFleetServicingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetServicingDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetServicingDtls.EquipmentId)
                db.AddParameter("p_ODOMETER_READING", pFleetServicingDtls.OdometerReading)
                db.AddParameter("p_SERVICING_DATE", pFleetServicingDtls.ServicingDate)
                db.AddParameter("p_CREATED_BY", pFleetServicingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetServicingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetServicingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_SERVICING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetServicingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pFleetServicingDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetServicingDtls"></param>
        ''' <returns>Return pFleetServicingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetServicingDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetServicingDtls.EquipmentId)
                db.AddParameter("p_ODOMETER_READING", pFleetServicingDtls.OdometerReading)
                db.AddParameter("p_SERVICING_DATE", pFleetServicingDtls.ServicingDate)
                db.AddParameter("p_CREATED_BY", pFleetServicingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetServicingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetServicingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_SERVICING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetServicingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetServicingDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetServicingDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetServicingDtls"></param>
        ''' <returns>Return pFleetServicingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetServicingDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetServicingDtls.EquipmentId)
                db.AddParameter("p_ODOMETER_READING", pFleetServicingDtls.OdometerReading)
                db.AddParameter("p_SERVICING_DATE", pFleetServicingDtls.ServicingDate)
                db.AddParameter("p_CREATED_BY", pFleetServicingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetServicingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetServicingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_SERVICING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetServicingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetServicingDtls.ErrorMsg = ex.Message
                End Try
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetServicingDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                PFleetServicingDtls.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ODOMETER_READING").ToString <> "" Then
                                PFleetServicingDtls.OdometerReading = dbr("ODOMETER_READING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICING_DATE").ToString <> "" Then
                                PFleetServicingDtls.ServicingDate = dbr("SERVICING_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetServicingDtls.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetServicingDtls.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetServicingDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetServicingDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetServicingDtls
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("ODOMETER_READING").ToString <> "" Then
                                temp.OdometerReading = dbr("ODOMETER_READING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICING_DATE").ToString <> "" Then
                                temp.ServicingDate = dbr("SERVICING_DATE")
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
        Public Shared Function ReturnFleetServicingDtls(ByVal pFleetServicingDtls As FleetServicingDtls) As FleetServicingDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_SERVICING_DTLS", "' '")
                pFleetServicingDtls = ReturnObjectValues(dbr, pFleetServicingDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetServicingDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetServicingDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetServicingDtlsList (ByVal pFleetServicingDtls As FleetServicingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetServicingDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_SERVICING_DTLS_BY_ID", pFleetServicingDtls.TerminalId & "," & pFleetServicingDtls.EquipmentId)
                arrFleetServicingDtls = ReturnObjectValuesList(dbr, arrFleetServicingDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetServicingDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetServicingDtls
        End Function
    End Class
End Namespace
