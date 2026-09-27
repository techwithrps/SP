Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ContainerMaster
    ''' @author	: Amit K. Singh- 3/5/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ContainerMaster

        Private lngContId As Long ' Define Private Variable ContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As string
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private dblTareWt As Double ' Define Private Variable TareWt With DataType As Double 
        Private strIsoCode As String ' Define Private Variable IsoCode With DataType As String 
        Private dblPermissibleWt As Double ' Define Private Variable PermissibleWt With DataType As Double 
        Private strOwnLease As String ' Define Private Variable OwnLease With DataType As String 
        Private strPurchaseDate As String ' Define Private Variable PurchaseDate With DataType As String 
        Private lngLeaseId As Long ' Define Private Variable LeaseId With DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strLandedOn As String ' Define Private Variable LandedOn With DataType As String 
        Private strContStatus As String ' Define Private Variable ContStatus With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strLeaseFromDate As String ' Define Private Variable LeaseFromDate With DataType As String 
        Private strLeaseToDate As String ' Define Private Variable LeaseToDate With DataType As String 
        Private lngContAgeing As Long ' Define Private Variable ContAgeing With DataType As Long 
        Private lngHoldId As Long ' Define Private Variable HoldId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of ContId
        ''' </summary>
        ''' <value>lngContId</value>
        ''' <returns> Return lngContId</returns>
        ''' <remarks> Get or Set the Value of ContId  </remarks>
        '''
        Public Property ContId() As Long
            Get
                Return lngContId
            End Get
            Set(ByVal value As Long)
                lngContId = value
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
        ''' Get or Set the Value of TareWt
        ''' </summary>
        ''' <value>dblTareWt</value>
        ''' <returns> Return dblTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property TareWt() As Double
            Get
                Return dblTareWt
            End Get
            Set(ByVal value As Double)
                dblTareWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of IsoCode
        ''' </summary>
        ''' <value>strIsoCode</value>
        ''' <returns> Return strIsoCode</returns>
        ''' <remarks> Get or Set the Value of IsoCode  </remarks>
        '''
        Public Property IsoCode() As String
            Get
                Return strIsoCode
            End Get
            Set(ByVal value As String)
                strIsoCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PermissibleWt
        ''' </summary>
        ''' <value>dblPermissibleWt</value>
        ''' <returns> Return dblPermissibleWt</returns>
        ''' <remarks> Get or Set the Value of PermissibleWt  </remarks>
        '''
        Public Property PermissibleWt() As Double
            Get
                Return dblPermissibleWt
            End Get
            Set(ByVal value As Double)
                dblPermissibleWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of OwnLease
        ''' </summary>
        ''' <value>strOwnLease</value>
        ''' <returns> Return strOwnLease</returns>
        ''' <remarks> Get or Set the Value of OwnLease  </remarks>
        '''
        Public Property OwnLease() As String
            Get
                Return strOwnLease
            End Get
            Set(ByVal value As String)
                strOwnLease = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PurchaseDate
        ''' </summary>
        ''' <value>strPurchaseDate</value>
        ''' <returns> Return strPurchaseDate</returns>
        ''' <remarks> Get or Set the Value of PurchaseDate  </remarks>
        '''
        Public Property PurchaseDate() As String
            Get
                Return strPurchaseDate
            End Get
            Set(ByVal value As String)
                strPurchaseDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LeaseId
        ''' </summary>
        ''' <value>lngLeaseId</value>
        ''' <returns> Return lngLeaseId</returns>
        ''' <remarks> Get or Set the Value of LeaseId  </remarks>
        '''
        Public Property LeaseId() As Long
            Get
                Return lngLeaseId
            End Get
            Set(ByVal value As Long)
                lngLeaseId = value
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
        ''' Get or Set the Value of LandedOn
        ''' </summary>
        ''' <value>strLandedOn</value>
        ''' <returns> Return strLandedOn</returns>
        ''' <remarks> Get or Set the Value of LandedOn  </remarks>
        '''
        Public Property LandedOn() As String
            Get
                Return strLandedOn
            End Get
            Set(ByVal value As String)
                strLandedOn = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContStatus
        ''' </summary>
        ''' <value>strContStatus</value>
        ''' <returns> Return strContStatus</returns>
        ''' <remarks> Get or Set the Value of ContStatus  </remarks>
        '''
        Public Property ContStatus() As String
            Get
                Return strContStatus
            End Get
            Set(ByVal value As String)
                strContStatus = value
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
        ''' Get or Set the Value of LeaseFromDate
        ''' </summary>
        ''' <value>strLeaseFromDate</value>
        ''' <returns> Return strLeaseFromDate</returns>
        ''' <remarks> Get or Set the Value of LeaseFromDate  </remarks>
        '''
        Public Property LeaseFromDate() As String
            Get
                Return strLeaseFromDate
            End Get
            Set(ByVal value As String)
                strLeaseFromDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LeaseToDate
        ''' </summary>
        ''' <value>strLeaseToDate</value>
        ''' <returns> Return strLeaseToDate</returns>
        ''' <remarks> Get or Set the Value of LeaseToDate  </remarks>
        '''
        Public Property LeaseToDate() As String
            Get
                Return strLeaseToDate
            End Get
            Set(ByVal value As String)
                strLeaseToDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContAgeing
        ''' </summary>
        ''' <value>lngContAgeing</value>
        ''' <returns> Return lngContAgeing</returns>
        ''' <remarks> Get or Set the Value of ContAgeing  </remarks>
        '''
        Public Property ContAgeing() As Long
            Get
                Return lngContAgeing
            End Get
            Set(ByVal value As Long)
                lngContAgeing = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of HoldId
        ''' </summary>
        ''' <value>lngHoldId</value>
        ''' <returns> Return lngHoldId</returns>
        ''' <remarks> Get or Set the Value of HoldId </remarks>
        '''
        Public Property HoldId() As Long
            Get
                Return lngHoldId
            End Get
            Set(ByVal value As Long)
                lngHoldId = value
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
            lngContId = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            dblTareWt = 0.0
            strIsoCode = ""
            dblPermissibleWt = 0.0
            strOwnLease = ""
            strPurchaseDate = ""
            lngLeaseId = 0
            lngTerminalId = 0
            strLandedOn = ""
            strContStatus = ""
            strRemarks = ""
            strLeaseFromDate = ""
            strLeaseToDate = ""
            lngContAgeing = 0
            lngHoldId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pContainerMaster"></param>
        ''' <returns>Return pContainerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_ID", pContainerMaster.ContId, ParameterDirection.Output)
                db.AddParameter("p_CONT_NO", pContainerMaster.ContNo, ParameterDirection.Output)
                db.AddParameter("p_CONT_SIZE", pContainerMaster.ContSize)
                db.AddParameter("p_CONT_TYPE", pContainerMaster.ContType)
                db.AddParameter("p_TARE_WT", pContainerMaster.TareWt)
                db.AddParameter("p_ISO_CODE", pContainerMaster.IsoCode)
                db.AddParameter("p_PERMISSIBLE_WT", pContainerMaster.PermissibleWt)
                db.AddParameter("p_OWN_LEASE", pContainerMaster.OwnLease)
                db.AddParameter("p_PURCHASE_DATE", pContainerMaster.PurchaseDate)
                db.AddParameter("p_LEASE_ID", pContainerMaster.LeaseId)
                db.AddParameter("p_TERMINAL_ID", pContainerMaster.TerminalId)
                db.AddParameter("p_LANDED_ON", pContainerMaster.LandedOn)
                db.AddParameter("p_CONT_STATUS", pContainerMaster.ContStatus)
                db.AddParameter("p_REMARKS", pContainerMaster.Remarks)
                db.AddParameter("p_LEASE_FROM_DATE", pContainerMaster.LeaseFromDate)
                db.AddParameter("p_LEASE_TO_DATE", pContainerMaster.LeaseToDate)
                db.AddParameter("p_CONT_AGEING", pContainerMaster.ContAgeing)
                db.AddParameter("p_ErrorMsg", pContainerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CONTAINER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pContainerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pContainerMaster.ContId = db.Parameters.Item("p_CONT_ID").value
                pContainerMaster.ContNo = db.Parameters.Item("p_CONT_NO").value

                If pContainerMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pContainerMaster"></param>
        ''' <returns>Return pContainerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_CONT_ID", pContainerMaster.ContId, ParameterDirection.Output)
                db.AddParameter("p_CONT_NO", pContainerMaster.ContNo, ParameterDirection.Output)
                db.AddParameter("p_CONT_SIZE", pContainerMaster.ContSize)
                db.AddParameter("p_CONT_TYPE", pContainerMaster.ContType)
                db.AddParameter("p_TARE_WT", pContainerMaster.TareWt)
                db.AddParameter("p_ISO_CODE", pContainerMaster.IsoCode)
                db.AddParameter("p_PERMISSIBLE_WT", pContainerMaster.PermissibleWt)
                db.AddParameter("p_OWN_LEASE", pContainerMaster.OwnLease)
                db.AddParameter("p_PURCHASE_DATE", pContainerMaster.PurchaseDate)
                db.AddParameter("p_LEASE_ID", pContainerMaster.LeaseId)
                db.AddParameter("p_TERMINAL_ID", pContainerMaster.TerminalId)
                db.AddParameter("p_LANDED_ON", pContainerMaster.LandedOn)
                db.AddParameter("p_CONT_STATUS", pContainerMaster.ContStatus)
                db.AddParameter("p_REMARKS", pContainerMaster.Remarks)
                db.AddParameter("p_LEASE_FROM_DATE", pContainerMaster.LeaseFromDate)
                db.AddParameter("p_LEASE_TO_DATE", pContainerMaster.LeaseToDate)
                db.AddParameter("p_CONT_AGEING", pContainerMaster.ContAgeing)
                db.AddParameter("p_ErrorMsg", pContainerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CONTAINER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pContainerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pContainerMaster.ContId = db.Parameters.Item("p_CONT_ID").value
                pContainerMaster.ContNo = db.Parameters.Item("p_CONT_NO").value

            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
            End Try
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pContainerMaster"></param>
        ''' <returns>Return pContainerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_ID", pContainerMaster.ContId)
                db.AddParameter("p_CONT_NO", pContainerMaster.ContNo)
                db.AddParameter("p_CONT_SIZE", pContainerMaster.ContSize)
                db.AddParameter("p_CONT_TYPE", pContainerMaster.ContType)
                db.AddParameter("p_TARE_WT", pContainerMaster.TareWt)
                db.AddParameter("p_ISO_CODE", pContainerMaster.IsoCode)
                db.AddParameter("p_PERMISSIBLE_WT", pContainerMaster.PermissibleWt)
                db.AddParameter("p_OWN_LEASE", pContainerMaster.OwnLease)
                db.AddParameter("p_PURCHASE_DATE", pContainerMaster.PurchaseDate)
                db.AddParameter("p_LEASE_ID", pContainerMaster.LeaseId)
                db.AddParameter("p_TERMINAL_ID", pContainerMaster.TerminalId)
                db.AddParameter("p_LANDED_ON", pContainerMaster.LandedOn)
                db.AddParameter("p_CONT_STATUS", pContainerMaster.ContStatus)
                db.AddParameter("p_REMARKS", pContainerMaster.Remarks)
                db.AddParameter("p_LEASE_FROM_DATE", pContainerMaster.LeaseFromDate)
                db.AddParameter("p_LEASE_TO_DATE", pContainerMaster.LeaseToDate)
                db.AddParameter("p_CONT_AGEING", pContainerMaster.ContAgeing)
                db.AddParameter("p_ErrorMsg", pContainerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CONTAINER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pContainerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pContainerMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pContainerMaster"></param>
        ''' <returns>Return pContainerMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_CONT_ID", pContainerMaster.ContId)
                db.AddParameter("p_CONT_NO", pContainerMaster.ContNo)
                db.AddParameter("p_CONT_SIZE", pContainerMaster.ContSize)
                db.AddParameter("p_CONT_TYPE", pContainerMaster.ContType)
                db.AddParameter("p_TARE_WT", pContainerMaster.TareWt)
                db.AddParameter("p_ISO_CODE", pContainerMaster.IsoCode)
                db.AddParameter("p_PERMISSIBLE_WT", pContainerMaster.PermissibleWt)
                db.AddParameter("p_OWN_LEASE", pContainerMaster.OwnLease)
                db.AddParameter("p_PURCHASE_DATE", pContainerMaster.PurchaseDate)
                db.AddParameter("p_LEASE_ID", pContainerMaster.LeaseId)
                db.AddParameter("p_TERMINAL_ID", pContainerMaster.TerminalId)
                db.AddParameter("p_LANDED_ON", pContainerMaster.LandedOn)
                db.AddParameter("p_CONT_STATUS", pContainerMaster.ContStatus)
                db.AddParameter("p_REMARKS", pContainerMaster.Remarks)
                db.AddParameter("p_LEASE_FROM_DATE", pContainerMaster.LeaseFromDate)
                db.AddParameter("p_LEASE_TO_DATE", pContainerMaster.LeaseToDate)
                db.AddParameter("p_CONT_AGEING", pContainerMaster.ContAgeing)
                db.AddParameter("p_ErrorMsg", pContainerMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CONTAINER_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pContainerMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
            End Try
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                pContainerMaster.ContId = dbr("CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pContainerMaster.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pContainerMaster.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pContainerMaster.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                pContainerMaster.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE").ToString <> "" Then
                                pContainerMaster.IsoCode = dbr("ISO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMISSIBLE_WT").ToString <> "" Then
                                pContainerMaster.PermissibleWt = dbr("PERMISSIBLE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWN_LEASE").ToString <> "" Then
                                pContainerMaster.OwnLease = dbr("OWN_LEASE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_DATE").ToString <> "" Then
                                pContainerMaster.PurchaseDate = dbr("PURCHASE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LEASE_ID").ToString <> "" Then
                                pContainerMaster.LeaseId = dbr("LEASE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pContainerMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LANDED_ON").ToString <> "" Then
                                pContainerMaster.LandedOn = dbr("LANDED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                pContainerMaster.ContStatus = dbr("CONT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pContainerMaster.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LEASE_FROM_DATE").ToString <> "" Then
                                pContainerMaster.LeaseFromDate = dbr("LEASE_FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LEASE_TO_DATE").ToString <> "" Then
                                pContainerMaster.LeaseToDate = dbr("LEASE_TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_AGEING").ToString <> "" Then
                                pContainerMaster.ContAgeing = dbr("CONT_AGEING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                pContainerMaster.HoldId = dbr("HOLD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
            End Try
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrContainerMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ContainerMaster
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                temp.ContId = dbr("CONT_ID")
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
                            If dbr("TARE_WT").ToString <> "" Then
                                temp.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ISO_CODE").ToString <> "" Then
                                temp.IsoCode = dbr("ISO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PERMISSIBLE_WT").ToString <> "" Then
                                temp.PermissibleWt = dbr("PERMISSIBLE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWN_LEASE").ToString <> "" Then
                                temp.OwnLease = dbr("OWN_LEASE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_DATE").ToString <> "" Then
                                temp.PurchaseDate = dbr("PURCHASE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LEASE_ID").ToString <> "" Then
                                temp.LeaseId = dbr("LEASE_ID")
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
                            If dbr("LANDED_ON").ToString <> "" Then
                                temp.LandedOn = dbr("LANDED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                temp.ContStatus = dbr("CONT_STATUS")
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
                            If dbr("LEASE_FROM_DATE").ToString <> "" Then
                                temp.LeaseFromDate = dbr("LEASE_FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LEASE_TO_DATE").ToString <> "" Then
                                temp.LeaseToDate = dbr("LEASE_TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_AGEING").ToString <> "" Then
                                temp.ContAgeing = dbr("CONT_AGEING")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                temp.HoldId = dbr("HOLD_ID")
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
        Public Shared Function ReturnContainerMaster(ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONTAINER_MASTER_BY_CONT_NO", pContainerMaster.TerminalId & "," & pContainerMaster.ContId & ",'" & pContainerMaster.ContNo & "'")
                pContainerMaster = ReturnObjectValues(dbr, pContainerMaster)
                dbr.Close()
            Catch ex As Exception
                pContainerMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pContainerMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList ContId For Booking_ID
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnContainerMasterList(ByVal pContainerMaster As ContainerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrContainerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONTAINER_MASTER", pContainerMaster.TerminalId & "," & pContainerMaster.ContId)
                arrContainerMaster = ReturnObjectValuesList(dbr, arrContainerMaster)
                dbr.Close()
            Catch ex As Exception
                arrContainerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrContainerMaster
        End Function

        Dim arrContMasterList As ArrayList

        Public Property ContMasterList() As ArrayList
            Get
                Return arrContMasterList
            End Get
            Set(ByVal value As ArrayList)
                arrContMasterList = value
            End Set
        End Property

        Public Shared Function ReturnContainerMasterById(ByVal pContainerMaster As ContainerMaster) As ContainerMaster
            ContainerMaster.ReturnContainerMaster(pContainerMaster)

            'Dim pDomBookingContDtls As New ContainerMaster
            pContainerMaster.TerminalId = pContainerMaster.TerminalId
            'pContainerMaster.BookingNo = pExtDomesticBooking.BookingId
            pContainerMaster.ContMasterList = ContainerMaster.ReturnContainerMasterList(pContainerMaster)
            Return pContainerMaster
        End Function

    End Class
End Namespace
