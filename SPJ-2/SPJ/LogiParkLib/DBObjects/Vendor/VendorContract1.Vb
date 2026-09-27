Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: Terminal Service Charges Class
    ''' @author	: Amit K. Singh- 17/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class VendorContract

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngContractId As Long ' Define Private Variable ContractId With DataType As Long 
        Private strVendorTypeCode As String ' Define Private Variable VendorTypeCode With DataType As String 
        Private lngVendorId As Long ' Define Private Variable VendorId With DataType As Long 
        Private strContractCode As String ' Define Private Variable ContractCode With DataType As String 
        Private strEffectiveFrom As String ' Define Private Variable EffectiveFrom With DataType As String 
        Private strEffectiveTo As String ' Define Private Variable EffectiveTo With DataType As String 
        Private strApprovalFlage As String ' Define Private Variable ApprovalFlage With DataType As String 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
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
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContractId
        ''' </summary>
        ''' <value>lngContractId</value>
        ''' <returns> Return lngContractId</returns>
        ''' <remarks> Get or Set the Value of ContractId  </remarks>
        '''
        Public Property ContractId() As Long
            Get
                Return lngContractId
            End Get
            Set(ByVal value As Long)
                lngContractId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VendorTypeCode
        ''' </summary>
        ''' <value>strVendorTypeCode</value>
        ''' <returns> Return strVendorTypeCode</returns>
        ''' <remarks> Get or Set the Value of VendorTypeCode  </remarks>
        '''
        Public Property VendorTypeCode() As String
            Get
                Return strVendorTypeCode
            End Get
            Set(ByVal value As String)
                strVendorTypeCode = value
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
        ''' Get or Set the Value of ContractCode
        ''' </summary>
        ''' <value>strContractCode</value>
        ''' <returns> Return strContractCode</returns>
        ''' <remarks> Get or Set the Value of ContractCode  </remarks>
        '''
        Public Property ContractCode() As String
            Get
                Return strContractCode
            End Get
            Set(ByVal value As String)
                strContractCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EffectiveFrom
        ''' </summary>
        ''' <value>strEffectiveFrom</value>
        ''' <returns> Return strEffectiveFrom</returns>
        ''' <remarks> Get or Set the Value of EffectiveFrom  </remarks>
        '''
        Public Property EffectiveFrom() As String
            Get
                Return strEffectiveFrom
            End Get
            Set(ByVal value As String)
                strEffectiveFrom = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of EffectiveTo
        ''' </summary>
        ''' <value>strEffectiveTo</value>
        ''' <returns> Return strEffectiveTo</returns>
        ''' <remarks> Get or Set the Value of EffectiveTo  </remarks>
        '''
        Public Property EffectiveTo() As String
            Get
                Return strEffectiveTo
            End Get
            Set(ByVal value As String)
                strEffectiveTo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ApprovalFlage
        ''' </summary>
        ''' <value>strApprovalFlage</value>
        ''' <returns> Return strApprovalFlage</returns>
        ''' <remarks> Get or Set the Value of ApprovalFlage  </remarks>
        '''
        Public Property ApprovalFlage() As String
            Get
                Return strApprovalFlage
            End Get
            Set(ByVal value As String)
                strApprovalFlage = value
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
            lngContractId = 0
            strVendorTypeCode = ""
            lngVendorId = 0
            strContractCode = ""
            strEffectiveFrom = ""
            strEffectiveTo = ""
            strApprovalFlage = ""
            strRemarks = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub


        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalServiceCharge"></param>
        ''' <returns>Return pTerminalServiceCharge Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceCharge.ServiceChargeId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceCharge.TerminalId)
                db.AddParameter("p_RATE_CODE", pTerminalServiceCharge.RateCode)
                db.AddParameter("p_EFFECTIVE_FROM", pTerminalServiceCharge.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pTerminalServiceCharge.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pTerminalServiceCharge.ApprovalFlage)
                db.AddParameter("p_REMARKS", pTerminalServiceCharge.Remarks)
                db.AddParameter("p_CREATED_ON", pTerminalServiceCharge.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTerminalServiceCharge.CreatedBy)
                db.AddParameter("p_ERRORMSG", pTerminalServiceCharge.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_SERVICE_CHARGES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceCharge.Errormsg = db.Parameters.Item("p_ERRORMSG").value.ToString
                End If
                pTerminalServiceCharge.ServiceChargeId = db.Parameters.Item("p_SERVICE_CHARGE_ID").value

                If pTerminalServiceCharge.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalServiceCharge"></param>
        ''' <returns>Return pTerminalServiceCharge Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Try
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceCharge.ServiceChargeId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceCharge.TerminalId)
                db.AddParameter("p_RATE_CODE", pTerminalServiceCharge.RateCode)
                db.AddParameter("P_EFFECTIVE_FROM", pTerminalServiceCharge.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pTerminalServiceCharge.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pTerminalServiceCharge.ApprovalFlage)
                db.AddParameter("p_REMARKS", pTerminalServiceCharge.Remarks)
                db.AddParameter("p_CREATED_ON", pTerminalServiceCharge.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTerminalServiceCharge.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTerminalServiceCharge.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TERMINAL_SERVICE_CHARGES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceCharge.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalServiceCharge.ServiceChargeId = db.Parameters.Item("p_SERVICE_CHARGE_ID").value

            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
            End Try
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalServiceCharge"></param>
        ''' <returns>Return pTerminalServiceCharge Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceCharge.ServiceChargeId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceCharge.TerminalId)
                db.AddParameter("p_RATE_CODE", pTerminalServiceCharge.RateCode)
                db.AddParameter("P_EFFECTIVE_FROM", pTerminalServiceCharge.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pTerminalServiceCharge.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pTerminalServiceCharge.ApprovalFlage)
                db.AddParameter("p_REMARKS", pTerminalServiceCharge.Remarks)
                db.AddParameter("p_CREATED_ON", pTerminalServiceCharge.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTerminalServiceCharge.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTerminalServiceCharge.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_SERVICE_CHARGES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceCharge.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalServiceCharge.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalServiceCharge"></param>
        ''' <returns>Return pTerminalServiceCharge Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Try
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceCharge.ServiceChargeId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceCharge.TerminalId)
                db.AddParameter("p_RATE_CODE", pTerminalServiceCharge.RateCode)
                db.AddParameter("P_EFFECTIVE_FROM", pTerminalServiceCharge.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pTerminalServiceCharge.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pTerminalServiceCharge.ApprovalFlage)
                db.AddParameter("p_REMARKS", pTerminalServiceCharge.Remarks)
                db.AddParameter("p_CREATED_ON", pTerminalServiceCharge.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTerminalServiceCharge.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTerminalServiceCharge.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TERMINAL_SERVICE_CHARGES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceCharge.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
            End Try
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("SERVICE_CHARGE_ID").ToString <> "" Then
                            pTerminalServiceCharge.ServiceChargeId = dbr("SERVICE_CHARGE_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pTerminalServiceCharge.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("RATE_CODE").ToString <> "" Then
                            pTerminalServiceCharge.RateCode = dbr("RATE_CODE")
                        End If
                        If dbr("EFFECTIVE_FROM").ToString <> "" Then
                            pTerminalServiceCharge.EffectiveFrom = dbr("EFFECTIVE_FROM")
                        End If
                        If dbr("EFFECTIVE_TO").ToString <> "" Then
                            pTerminalServiceCharge.EffectiveTo = dbr("EFFECTIVE_TO")
                        End If
                        If dbr("APPROVAL_FLAGE").ToString <> "" Then
                            pTerminalServiceCharge.ApprovalFlage = dbr("APPROVAL_FLAGE")
                        End If
                        If dbr("REMARKS").ToString <> "" Then
                            pTerminalServiceCharge.Remarks = dbr("REMARKS")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            pTerminalServiceCharge.CreatedOn = dbr("CREATED_ON")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            pTerminalServiceCharge.CreatedBy = dbr("CREATED_BY")
                        End If
                    End While
                End If
            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
            End Try
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalServiceCharge As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalServiceCharge
                        If dbr("SERVICE_CHARGE_ID").ToString <> "" Then
                            temp.ServiceChargeId = dbr("SERVICE_CHARGE_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("RATE_CODE").ToString <> "" Then
                            temp.RateCode = dbr("RATE_CODE")
                        End If
                        If dbr("EFFECTIVE_FROM").ToString <> "" Then
                            temp.EffectiveFrom = dbr("EFFECTIVE_FROM")
                        End If
                        If dbr("EFFECTIVE_TO").ToString <> "" Then
                            temp.EffectiveTo = dbr("EFFECTIVE_TO")
                        End If
                        If dbr("APPROVAL_FLAGE").ToString <> "" Then
                            temp.ApprovalFlage = dbr("APPROVAL_FLAGE")
                        End If
                        If dbr("REMARKS").ToString <> "" Then
                            temp.Remarks = dbr("REMARKS")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            temp.CreatedOn = dbr("CREATED_ON")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            temp.CreatedBy = dbr("CREATED_BY")
                        End If
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
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalServiceCharge(ByVal pTerminalServiceCharge As TerminalServiceCharge) As TerminalServiceCharge
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGES_BY_ID", pTerminalServiceCharge.ServiceChargeId)
                pTerminalServiceCharge = ReturnObjectValues(dbr, pTerminalServiceCharge)
                dbr.Close()
            Catch ex As Exception
                pTerminalServiceCharge.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalServiceCharge
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalServiceChargeList(ByVal pTerminalServiceCharge As TerminalServiceCharge) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalServiceCharge As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGES_BY_ALL", " ")
                arrTerminalServiceCharge = ReturnObjectValuesList(dbr, arrTerminalServiceCharge)
                dbr.Close()
            Catch ex As Exception
                arrTerminalServiceCharge = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalServiceCharge
        End Function



        Public Shared Function ReturnTerminalServiceChargeListSearch(ByVal pTerminalServiceCharge As TerminalServiceCharge) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalServiceCharge As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGES_SEARCH", "'" & pTerminalServiceCharge.RateCode & "'," & _
                                               pTerminalServiceCharge.TerminalId & ",'" & pTerminalServiceCharge.ApprovalFlage & "','" & _
                                               pTerminalServiceCharge.EffectiveFrom & "'," & pTerminalServiceCharge.EffectiveTo)
                arrTerminalServiceCharge = ReturnObjectValuesList(dbr, arrTerminalServiceCharge)
                dbr.Close()
            Catch ex As Exception
                arrTerminalServiceCharge = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalServiceCharge
        End Function
    End Class
End Namespace
