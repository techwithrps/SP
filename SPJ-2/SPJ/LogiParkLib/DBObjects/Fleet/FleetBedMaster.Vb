Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetBedMaster
    ''' @author	: Santosh Singh- 20/11/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class FleetBedMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngBedRefId As Long ' Define Private Variable BedRefId With DataType As Long 
        Private strBedNo As String ' Define Private Variable BedNo With DataType As String 
        Private strTireNo As String ' Define Private Variable TireNo With DataType As String 
        Private strInstallationDate As String ' Define Private Variable InstallationDate With DataType As String 
        Private strInstallLocation As String ' Define Private Variable InstallLocation With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Dim arrTireList As ArrayList

        Public Property TireList() As ArrayList
            Get
                Return arrTireList
            End Get
            Set(ByVal value As ArrayList)
                arrTireList = value
            End Set
        End Property
                    
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
        ''' Get or Set the Value of BedRefId
        ''' </summary>
        ''' <value>lngBedRefId</value>
        ''' <returns> Return lngBedRefId</returns>
        ''' <remarks> Get or Set the Value of BedRefId  </remarks>
        '''
        Public Property BedRefId() as Long
            Get
                Return lngBedRefId
            End Get
            Set(ByVal value As Long)
                lngBedRefId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BedNo
        ''' </summary>
        ''' <value>strBedNo</value>
        ''' <returns> Return strBedNo</returns>
        ''' <remarks> Get or Set the Value of BedNo  </remarks>
        '''
        Public Property BedNo() as String
            Get
                Return strBedNo
            End Get
            Set(ByVal value As String)
                strBedNo = value
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
            lngBedRefId = 0 
            strBedNo = ""
            strTireNo = ""
            strInstallationDate = ""
            strInstallLocation = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetBedMaster"></param>
        ''' <returns>Return pFleetBedMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetBedMaster.TerminalId)
                db.AddParameter("p_BED_REF_ID", pFleetBedMaster.BedRefId, ParameterDirection.Output)
                db.AddParameter("p_BED_NO", pFleetBedMaster.BedNo)
                db.AddParameter("p_TIRE_NO", pFleetBedMaster.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetBedMaster.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetBedMaster.InstallLocation)
                db.AddParameter("p_CREATED_BY", pFleetBedMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetBedMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetBedMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_BED_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetBedMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetBedMaster.BedRefId  = db.Parameters.Item("p_BED_REF_ID").value
                
                If pFleetBedMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetBedMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetBedMaster"></param>
        ''' <returns>Return pFleetBedMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetBedMaster.TerminalId)
                db.AddParameter("p_BED_REF_ID", pFleetBedMaster.BedRefId, ParameterDirection.Output)
                db.AddParameter("p_BED_NO", pFleetBedMaster.BedNo)
                db.AddParameter("p_TIRE_NO", pFleetBedMaster.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetBedMaster.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetBedMaster.InstallLocation)
                db.AddParameter("p_CREATED_BY", pFleetBedMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetBedMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetBedMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_FLEET_BED_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetBedMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pFleetBedMaster.BedRefId  = db.Parameters.Item("p_BED_REF_ID").value
                
            Catch ex As Exception
                pFleetBedMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pFleetBedMaster"></param>
        ''' <returns>Return pFleetBedMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetBedMaster.TerminalId)
                db.AddParameter("p_BED_REF_ID", pFleetBedMaster.BedRefId)
                db.AddParameter("p_BED_NO", pFleetBedMaster.BedNo)
                db.AddParameter("p_TIRE_NO", pFleetBedMaster.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetBedMaster.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetBedMaster.InstallLocation)
                db.AddParameter("p_CREATED_BY", pFleetBedMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetBedMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetBedMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_BED_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetBedMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pFleetBedMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pFleetBedMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pFleetBedMaster"></param>
        ''' <returns>Return pFleetBedMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pFleetBedMaster.TerminalId)
                db.AddParameter("p_BED_REF_ID", pFleetBedMaster.BedRefId)
                db.AddParameter("p_BED_NO", pFleetBedMaster.BedNo)
                db.AddParameter("p_TIRE_NO", pFleetBedMaster.TireNo)
                db.AddParameter("p_INSTALLATION_DATE", pFleetBedMaster.InstallationDate)
                db.AddParameter("p_INSTALL_LOCATION", pFleetBedMaster.InstallLocation)
                db.AddParameter("p_CREATED_BY", pFleetBedMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pFleetBedMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pFleetBedMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_FLEET_BED_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetBedMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pFleetBedMaster.ErrorMsg = ex.Message
                End Try
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PFleetBedMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_REF_ID").ToString <> "" Then
                                PFleetBedMaster.BedRefId = dbr("BED_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_NO").ToString <> "" Then
                                PFleetBedMaster.BedNo = dbr("BED_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TIRE_NO").ToString <> "" Then
                                PFleetBedMaster.TireNo = dbr("TIRE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALLATION_DATE").ToString <> "" Then
                                PFleetBedMaster.InstallationDate = dbr("INSTALLATION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INSTALL_LOCATION").ToString <> "" Then
                                PFleetBedMaster.InstallLocation = dbr("INSTALL_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PFleetBedMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PFleetBedMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pFleetBedMaster.ErrorMsg = ex.Message
            End Try
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetBedMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New FleetBedMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_REF_ID").ToString <> "" Then
                                temp.BedRefId = dbr("BED_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BED_NO").ToString <> "" Then
                                temp.BedNo = dbr("BED_NO")
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
        Public Shared Function ReturnFleetBedMaster(ByVal pFleetBedMaster As FleetBedMaster) As FleetBedMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_BED_MASTER", "' '")
                pFleetBedMaster = ReturnObjectValues(dbr, pFleetBedMaster)
                dbr.Close()
            Catch ex As Exception
                pFleetBedMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pFleetBedMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnFleetBedMasterList (ByVal pFleetBedMaster As FleetBedMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetBedMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_BED_MASTER", "' '")
                arrFleetBedMaster = ReturnObjectValuesList(dbr, arrFleetBedMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetBedMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetBedMaster
        End Function
        Public Shared Function ReturnFleetBedMasterListByBedNo(ByVal pFleetBedMaster As FleetBedMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetBedMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_BED_MASTER_BY_BED", "'" & pFleetBedMaster.BedNo & "'")
                arrFleetBedMaster = ReturnObjectValuesList(dbr, arrFleetBedMaster)
                dbr.Close()
            Catch ex As Exception
                arrFleetBedMaster = Nothing
            End Try
            db.CloseDB()
            Return arrFleetBedMaster
        End Function

        Public Shared Function InsertUpdateBedDetails(ByVal pBedMaster As FleetBedMaster) As FleetBedMaster
            Dim db As New DBConnect

            Try
                db.BeginTransaction()
                If pBedMaster.Errormsg = "" Then
                    For Each tgh As FleetBedMaster In pBedMaster.TireList
                        tgh.BedNo = pBedMaster.BedNo
                        If tgh.BedRefId > 0 Then
                            FleetBedMaster.UpdateTrn(db, tgh)
                        Else
                            FleetBedMaster.InsertTrn(db, tgh)
                        End If
                        If tgh.Errormsg <> Nothing Then
                            Throw New Exception(tgh.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pBedMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pBedMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
            End Try
            Return pBedMaster
        End Function
    End Class
End Namespace
