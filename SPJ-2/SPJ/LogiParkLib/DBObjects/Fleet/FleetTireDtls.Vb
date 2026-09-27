Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetTireDtls
    ''' @author	: Santosh Singh- 28/8/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetTireDtls 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngEquipmentId As Long ' Define Private Variable EquipmentId With DataType As Long 
        Private strTireNo As String ' Define Private Variable TireNo With DataType As String 
        Private strInstallationDate As String ' Define Private Variable InstallationDate With DataType As String 
        Private strInstallLocation As String ' Define Private Variable InstallLocation With DataType As String 
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
        ''' Get or Set the Value of TireNo
        ''' </summary>
        ''' <value>strTireNo</value>
        ''' <returns> Return strTireNo</returns>
        ''' <remarks> Get or Set the Value of TireNo  </remarks>
        '''
        Public Property TireNo() as String
            Get
                Return strTireNo
            End Get
            Set(ByVal value As String)
                strTireNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InstallationDate
        ''' </summary>
        ''' <value>strInstallationDate</value>
        ''' <returns> Return strInstallationDate</returns>
        ''' <remarks> Get or Set the Value of InstallationDate  </remarks>
        '''
        Public Property InstallationDate() as String
            Get
                Return strInstallationDate
            End Get
            Set(ByVal value As String)
                strInstallationDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InstallLocation
        ''' </summary>
        ''' <value>strInstallLocation</value>
        ''' <returns> Return strInstallLocation</returns>
        ''' <remarks> Get or Set the Value of InstallLocation  </remarks>
        '''
        Public Property InstallLocation() as String
            Get
                Return strInstallLocation
            End Get
            Set(ByVal value As String)
                strInstallLocation = value
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
            strTireNo = ""
            strInstallationDate = ""
            strInstallLocation = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetTireDtls"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetTireDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetTireDtls.EquipmentId)
                db.AddParameter("p_TIRE_NO", pFleetTireDtls.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetTireDtls.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetTireDtls.InstallLocation)
                db.AddParameter("p_ErrorMsg", pFleetTireDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_TIRE_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetTireDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pFleetTireDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetTireDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetTireDtls"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetTireDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetTireDtls.EquipmentId)
                db.AddParameter("p_TIRE_NO", pFleetTireDtls.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetTireDtls.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetTireDtls.InstallLocation)
                db.AddParameter("p_ErrorMsg", pFleetTireDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_TIRE_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetTireDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pFleetTireDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetTireDtls"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetTireDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetTireDtls.EquipmentId)
                db.AddParameter("p_TIRE_NO", pFleetTireDtls.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetTireDtls.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetTireDtls.InstallLocation)
                db.AddParameter("p_ErrorMsg", pFleetTireDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_TIRE_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetTireDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetTireDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetTireDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetTireDtls"></param>
        ''' <returns>Return pFleetTireDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetTireDtls.TerminalId)
                db.AddParameter("p_EQUIPMENT_ID", pFleetTireDtls.EquipmentId)
                db.AddParameter("p_TIRE_NO", pFleetTireDtls.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetTireDtls.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetTireDtls.InstallLocation)
                db.AddParameter("p_ErrorMsg", pFleetTireDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_TIRE_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetTireDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetTireDtls.ErrorMsg = ex.Message
                End Try
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetTireDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                PFleetTireDtls.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TIRE_NO").ToString <> "" Then
                                PFleetTireDtls.TireNo = dbr("TIRE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALLATION_DATE").ToString <> "" Then
                                PFleetTireDtls.InstallationDate = dbr("INSTALLATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALL_LOCATION").ToString <> "" Then
                                PFleetTireDtls.InstallLocation = dbr("INSTALL_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetTireDtls.ErrorMsg = ex.Message
            End Try
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetTireDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetTireDtls
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
                            If dbr("TIRE_NO").ToString <> "" Then
                                temp.TireNo = dbr("TIRE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALLATION_DATE").ToString <> "" Then
                                temp.InstallationDate = dbr("INSTALLATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALL_LOCATION").ToString <> "" Then
                                temp.InstallLocation = dbr("INSTALL_LOCATION")
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
        Public Shared Function ReturnFleetTireDtls(ByVal pFleetTireDtls As FleetTireDtls) As FleetTireDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_TIRE_DTLS", "' '")
                pFleetTireDtls = ReturnObjectValues(dbr, pFleetTireDtls)
                dbr.Close()
            Catch ex As Exception
                pFleetTireDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetTireDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetTireDtlsList (ByVal pFleetTireDtls As FleetTireDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetTireDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_TIRE_DTLS_BY_ID", pFleetTireDtls.TerminalId & "," & pFleetTireDtls.EquipmentId)
                arrFleetTireDtls = ReturnObjectValuesList(dbr, arrFleetTireDtls)
                dbr.Close()
            Catch ex As Exception
                arrFleetTireDtls = Nothing
            End Try
            db.CloseDB()
            Return arrFleetTireDtls
        End Function
    End Class
End Namespace
