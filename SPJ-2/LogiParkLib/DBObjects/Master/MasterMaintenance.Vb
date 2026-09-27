Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MasterMaintenance
    ''' @author	: Santosh Singh- 12/8/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MasterMaintenance

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngRefId As Long ' Define Private Variable RefId With DataType As Long 
        Private lngContId As Long ' Define Private Variable ContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private lngTareWt As Long ' Define Private Variable TareWt With DataType As Long 
        Private lngDamageStatus As Long ' Define Private Variable DamageStatus With DataType As Long 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private strServiceMode As String ' Define Private Variable DocType With DataType As String 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private strGateInDate As String ' Define Private Variable GateInDate With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String
        Private strNContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strNContType As String ' Define Private Variable ContSize With DataType As String 
        Private lngNTareWt As Long  ' Define Private Variable ContSize With DataType As String 
        Private lngNDamageStatus As Long  ' Define Private Variable ContSize With DataType As String 
        Private strNServiceMode As String ' Define Private Variable DocType With DataType As String 
        Private strRemarks As String ' Define Private Variable GateInDate With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


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
        ''' Get or Set the Value of RefId
        ''' </summary>
        ''' <value>lngRefId</value>
        ''' <returns> Return lngRefId</returns>
        ''' <remarks> Get or Set the Value of RefId  </remarks>
        '''
        Public Property RefId() As Long
            Get
                Return lngRefId
            End Get
            Set(ByVal value As Long)
                lngRefId = value
            End Set
        End Property


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
        ''' <value>lngTareWt</value>
        ''' <returns> Return lngTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property TareWt() As Long
            Get
                Return lngTareWt
            End Get
            Set(ByVal value As Long)
                lngTareWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DamageStatus
        ''' </summary>
        ''' <value>lngDamageStatus</value>
        ''' <returns> Return lngDamageStatus</returns>
        ''' <remarks> Get or Set the Value of DamageStatus  </remarks>
        '''
        Public Property DamageStatus() As Long
            Get
                Return lngDamageStatus
            End Get
            Set(ByVal value As Long)
                lngDamageStatus = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
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
        Public Property ServiceMode() As String
            Get
                Return strServiceMode
            End Get
            Set(ByVal value As String)
                strServiceMode = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property NServiceMode() As String
            Get
                Return strNServiceMode
            End Get
            Set(ByVal value As String)
                strNServiceMode = value
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
        ''' Get or Set the Value of ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks> Get or Set the Value of ContSize  </remarks>
        '''
        Public Property NContSize() As String
            Get
                Return strNContSize
            End Get
            Set(ByVal value As String)
                strNContSize = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property NContType() As String
            Get
                Return strNContType
            End Get
            Set(ByVal value As String)
                strNContType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TareWt
        ''' </summary>
        ''' <value>lngTareWt</value>
        ''' <returns> Return lngTareWt</returns>
        ''' <remarks> Get or Set the Value of TareWt  </remarks>
        '''
        Public Property NTareWt() As Long
            Get
                Return lngNTareWt
            End Get
            Set(ByVal value As Long)
                lngNTareWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DamageStatus
        ''' </summary>
        ''' <value>lngDamageStatus</value>
        ''' <returns> Return lngDamageStatus</returns>
        ''' <remarks> Get or Set the Value of DamageStatus  </remarks>
        '''
        Public Property NDamageStatus() As Long
            Get
                Return lngNDamageStatus
            End Get
            Set(ByVal value As Long)
                lngNDamageStatus = value
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
            lngRefId = 0
            lngContId = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            lngTareWt = 0
            lngDamageStatus = 0
            strDocType = ""
            lngLineId = 0
            strGateInDate = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strNContSize = ""
            strNContType = ""
            lngNTareWt = 0
            lngNDamageStatus = 0
            strRemarks = ""
            strServiceMode = ""
            strNServiceMode = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMasterMaintenance"></param>
        ''' <returns>Return pMasterMaintenance Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenance.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenance.RefId, ParameterDirection.Output)
                db.AddParameter("p_CONT_ID", pMasterMaintenance.ContId)
                db.AddParameter("p_CONT_NO", pMasterMaintenance.ContNo)
                db.AddParameter("p_CONT_SIZE", pMasterMaintenance.ContSize)
                db.AddParameter("p_CONT_TYPE", pMasterMaintenance.ContType)
                db.AddParameter("p_TARE_WT", pMasterMaintenance.TareWt)
                db.AddParameter("p_DAMAGE_STATUS", pMasterMaintenance.DamageStatus)
                db.AddParameter("p_DOC_TYPE", pMasterMaintenance.DocType)
                db.AddParameter("p_LINE_ID", pMasterMaintenance.LineId)
                db.AddParameter("p_GATE_IN_DATE", pMasterMaintenance.GateInDate)
                db.AddParameter("p_CREATED_BY", pMasterMaintenance.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMasterMaintenance.CreatedOn)
                db.AddParameter("p_NCONT_SIZE", pMasterMaintenance.NContSize)
                db.AddParameter("p_NCONT_TYPE", pMasterMaintenance.NContType)
                db.AddParameter("p_NTARE_WT", pMasterMaintenance.NTareWt)
                db.AddParameter("p_NDAMAGE_STATUS", pMasterMaintenance.NDamageStatus)
                db.AddParameter("p_REMARKS", pMasterMaintenance.Remarks)
                db.AddParameter("p_SERVICE_MODE", pMasterMaintenance.ServiceMode)
                db.AddParameter("p_NSERVICE_MODE", pMasterMaintenance.NServiceMode)
                db.AddParameter("p_ErrorMsg", pMasterMaintenance.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MASTER_MAINTENANCE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenance.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMasterMaintenance.RefId = db.Parameters.Item("p_REF_ID").value

                If pMasterMaintenance.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMasterMaintenance"></param>
        ''' <returns>Return pMasterMaintenance Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenance.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenance.RefId, ParameterDirection.Output)
                db.AddParameter("p_CONT_ID", pMasterMaintenance.ContId)
                db.AddParameter("p_CONT_NO", pMasterMaintenance.ContNo)
                db.AddParameter("p_CONT_SIZE", pMasterMaintenance.ContSize)
                db.AddParameter("p_CONT_TYPE", pMasterMaintenance.ContType)
                db.AddParameter("p_TARE_WT", pMasterMaintenance.TareWt)
                db.AddParameter("p_DAMAGE_STATUS", pMasterMaintenance.DamageStatus)
                db.AddParameter("p_DOC_TYPE", pMasterMaintenance.DocType)
                db.AddParameter("p_LINE_ID", pMasterMaintenance.LineId)
                db.AddParameter("p_GATE_IN_DATE", pMasterMaintenance.GateInDate)
                db.AddParameter("p_CREATED_BY", pMasterMaintenance.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMasterMaintenance.CreatedOn)
                db.AddParameter("p_SERVICE_MODE", pMasterMaintenance.ServiceMode)
                db.AddParameter("p_NSERVICE_MODE", pMasterMaintenance.NServiceMode)
                db.AddParameter("p_ErrorMsg", pMasterMaintenance.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MASTER_MAINTENANCE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenance.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMasterMaintenance.RefId = db.Parameters.Item("p_REF_ID").value

            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
            End Try
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMasterMaintenance"></param>
        ''' <returns>Return pMasterMaintenance Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenance.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenance.RefId)
                db.AddParameter("p_CONT_ID", pMasterMaintenance.ContId)
                db.AddParameter("p_CONT_NO", pMasterMaintenance.ContNo)
                db.AddParameter("p_CONT_SIZE", pMasterMaintenance.ContSize)
                db.AddParameter("p_CONT_TYPE", pMasterMaintenance.ContType)
                db.AddParameter("p_TARE_WT", pMasterMaintenance.TareWt)
                db.AddParameter("p_DAMAGE_STATUS", pMasterMaintenance.DamageStatus)
                db.AddParameter("p_DOC_TYPE", pMasterMaintenance.DocType)
                db.AddParameter("p_LINE_ID", pMasterMaintenance.LineId)
                db.AddParameter("p_GATE_IN_DATE", pMasterMaintenance.GateInDate)
                db.AddParameter("p_CREATED_BY", pMasterMaintenance.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMasterMaintenance.CreatedOn)
                db.AddParameter("p_ErrorMsg", pMasterMaintenance.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MASTER_MAINTENANCE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenance.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMasterMaintenance.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMasterMaintenance"></param>
        ''' <returns>Return pMasterMaintenance Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenance.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenance.RefId)
                db.AddParameter("p_CONT_ID", pMasterMaintenance.ContId)
                db.AddParameter("p_CONT_NO", pMasterMaintenance.ContNo)
                db.AddParameter("p_CONT_SIZE", pMasterMaintenance.ContSize)
                db.AddParameter("p_CONT_TYPE", pMasterMaintenance.ContType)
                db.AddParameter("p_TARE_WT", pMasterMaintenance.TareWt)
                db.AddParameter("p_DAMAGE_STATUS", pMasterMaintenance.DamageStatus)
                db.AddParameter("p_DOC_TYPE", pMasterMaintenance.DocType)
                db.AddParameter("p_LINE_ID", pMasterMaintenance.LineId)
                db.AddParameter("p_GATE_IN_DATE", pMasterMaintenance.GateInDate)
                db.AddParameter("p_CREATED_BY", pMasterMaintenance.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMasterMaintenance.CreatedOn)
                db.AddParameter("p_ErrorMsg", pMasterMaintenance.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MASTER_MAINTENANCE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenance.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
            End Try
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pMasterMaintenance.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                pMasterMaintenance.RefId = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                pMasterMaintenance.ContId = dbr("CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pMasterMaintenance.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                pMasterMaintenance.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pMasterMaintenance.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TARE_WT").ToString <> "" Then
                                pMasterMaintenance.TareWt = dbr("TARE_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_STATUS").ToString <> "" Then
                                pMasterMaintenance.DamageStatus = dbr("DAMAGE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                pMasterMaintenance.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pMasterMaintenance.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_IN_DATE").ToString <> "" Then
                                pMasterMaintenance.GateInDate = dbr("GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pMasterMaintenance.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pMasterMaintenance.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_MODE").ToString <> "" Then
                                pMasterMaintenance.ServiceMode = dbr("SERVICE_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NSERVICE_MODE").ToString <> "" Then
                                pMasterMaintenance.NServiceMode = dbr("NSERVICE_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
            End Try
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMasterMaintenance As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MasterMaintenance
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                temp.RefId = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
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
                            If dbr("DAMAGE_STATUS").ToString <> "" Then
                                temp.DamageStatus = dbr("DAMAGE_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
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
                            If dbr("GATE_IN_DATE").ToString <> "" Then
                                temp.GateInDate = dbr("GATE_IN_DATE")
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
                            If dbr("SERVICE_MODE").ToString <> "" Then
                                temp.ServiceMode = dbr("SERVICE_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NSERVICE_MODE").ToString <> "" Then
                                temp.NServiceMode = dbr("NSERVICE_MODE")
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
        Public Shared Function ReturnMasterMaintenance(ByVal pMasterMaintenance As MasterMaintenance) As MasterMaintenance
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MASTER_MAINTENANCE", "' '")
                pMasterMaintenance = ReturnObjectValues(dbr, pMasterMaintenance)
                dbr.Close()
            Catch ex As Exception
                pMasterMaintenance.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMasterMaintenance
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMasterMaintenanceList(ByVal pMasterMaintenance As MasterMaintenance) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMasterMaintenance As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MASTER_MAINTENANCE", "' '")
                arrMasterMaintenance = ReturnObjectValuesList(dbr, arrMasterMaintenance)
                dbr.Close()
            Catch ex As Exception
                arrMasterMaintenance = Nothing
            End Try
            db.CloseDB()
            Return arrMasterMaintenance
        End Function
    End Class
End Namespace
