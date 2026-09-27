Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorContract
    ''' @author	: Amit K. Singh- 9/5/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
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
        Public Property TerminalId() as Long
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
        Public Property ContractId() as Long
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
        Public Property VendorTypeCode() as String
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
        Public Property VendorId() as Long
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
        Public Property ContractCode() as String
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
        Public Property EffectiveFrom() as String
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
        Public Property EffectiveTo() as String
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
        Public Property ApprovalFlage() as String
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
        Public Property Remarks() as String
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
        ''' <param name="pVendorContract"></param>
        ''' <returns>Return pVendorContract Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorContract As VendorContract) As VendorContract
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContract.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContract.ContractId, ParameterDirection.Output)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorContract.VendorTypeCode)
                db.AddParameter("p_VENDOR_ID", pVendorContract.VendorId)
                db.AddParameter("p_CONTRACT_CODE", pVendorContract.ContractCode)
                db.AddParameter("p_EFFECTIVE_FROM", pVendorContract.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pVendorContract.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pVendorContract.ApprovalFlage)
                db.AddParameter("p_REMARKS", pVendorContract.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorContract.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorContract.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorContract.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_CONTRACT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContract.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorContract.ContractId  = db.Parameters.Item("p_CONTRACT_ID").value
                
                If pVendorContract.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorContract.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContract"></param>
        ''' <returns>Return pVendorContract Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorContract As VendorContract) As VendorContract
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContract.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContract.ContractId, ParameterDirection.Output)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorContract.VendorTypeCode)
                db.AddParameter("p_VENDOR_ID", pVendorContract.VendorId)
                db.AddParameter("p_CONTRACT_CODE", pVendorContract.ContractCode)
                db.AddParameter("p_EFFECTIVE_FROM", pVendorContract.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pVendorContract.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pVendorContract.ApprovalFlage)
                db.AddParameter("p_REMARKS", pVendorContract.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorContract.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorContract.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorContract.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_CONTRACT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContract.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorContract.ContractId  = db.Parameters.Item("p_CONTRACT_ID").value
                
            Catch ex As Exception
                pVendorContract.ErrorMsg = ex.Message
            End Try
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorContract"></param>
        ''' <returns>Return pVendorContract Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorContract As VendorContract) As VendorContract
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContract.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContract.ContractId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorContract.VendorTypeCode)
                db.AddParameter("p_VENDOR_ID", pVendorContract.VendorId)
                db.AddParameter("p_CONTRACT_CODE", pVendorContract.ContractCode)
                db.AddParameter("p_EFFECTIVE_FROM", pVendorContract.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pVendorContract.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pVendorContract.ApprovalFlage)
                db.AddParameter("p_REMARKS", pVendorContract.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorContract.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorContract.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorContract.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContract.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorContract.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorContract.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContract"></param>
        ''' <returns>Return pVendorContract Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorContract As VendorContract) As VendorContract
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContract.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContract.ContractId)
                db.AddParameter("p_VENDOR_TYPE_CODE", pVendorContract.VendorTypeCode)
                db.AddParameter("p_VENDOR_ID", pVendorContract.VendorId)
                db.AddParameter("p_CONTRACT_CODE", pVendorContract.ContractCode)
                db.AddParameter("p_EFFECTIVE_FROM", pVendorContract.EffectiveFrom)
                db.AddParameter("p_EFFECTIVE_TO", pVendorContract.EffectiveTo)
                db.AddParameter("p_APPROVAL_FLAGE", pVendorContract.ApprovalFlage)
                db.AddParameter("p_REMARKS", pVendorContract.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorContract.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorContract.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorContract.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContract.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVendorContract.ErrorMsg = ex.Message
                End Try
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorContract As VendorContract) As VendorContract
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVendorContract.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTRACT_ID").ToString <> "" Then
                                PVendorContract.ContractId = dbr("CONTRACT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_CODE").ToString <> "" Then
                                PVendorContract.VendorTypeCode = dbr("VENDOR_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                PVendorContract.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTRACT_CODE").ToString <> "" Then
                                PVendorContract.ContractCode = dbr("CONTRACT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EFFECTIVE_FROM").ToString <> "" Then
                                PVendorContract.EffectiveFrom = dbr("EFFECTIVE_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EFFECTIVE_TO").ToString <> "" Then
                                PVendorContract.EffectiveTo = dbr("EFFECTIVE_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                PVendorContract.ApprovalFlage = dbr("APPROVAL_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PVendorContract.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PVendorContract.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PVendorContract.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVendorContract.ErrorMsg = ex.Message
            End Try
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorContract As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorContract
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTRACT_ID").ToString <> "" Then
                                temp.ContractId = dbr("CONTRACT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE_CODE").ToString <> "" Then
                                temp.VendorTypeCode = dbr("VENDOR_TYPE_CODE")
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
                            If dbr("CONTRACT_CODE").ToString <> "" Then
                                temp.ContractCode = dbr("CONTRACT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EFFECTIVE_FROM").ToString <> "" Then
                                temp.EffectiveFrom = dbr("EFFECTIVE_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EFFECTIVE_TO").ToString <> "" Then
                                temp.EffectiveTo = dbr("EFFECTIVE_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                temp.ApprovalFlage = dbr("APPROVAL_FLAGE")
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
        Public Shared Function ReturnVendorContract(ByVal pVendorContract As VendorContract) As VendorContract
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_BY_ID", pVendorContract.TerminalId & "," & pVendorContract.ContractId)
                pVendorContract = ReturnObjectValues(dbr, pVendorContract)
                dbr.Close()
            Catch ex As Exception
                pVendorContract.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorContract
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorContractList (ByVal pVendorContract As VendorContract) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorContract As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_BY_ALL", pVendorContract.TerminalId)
                arrVendorContract = ReturnObjectValuesList(dbr, arrVendorContract)
                dbr.Close()
            Catch ex As Exception
                arrVendorContract = Nothing
            End Try
            db.CloseDB()
            Return arrVendorContract
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContract"></param>
        ''' <returns>Return pVendorContract Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateApprovalTrn(ByVal db As DBConnect, ByVal pVendorContract As VendorContract) As VendorContract
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContract.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContract.ContractId)
                db.AddParameter("p_APPROVAL_FLAGE", pVendorContract.ApprovalFlage)
                db.AddParameter("p_REMARKS", pVendorContract.Remarks)
                db.AddParameter("p_ErrorMsg", pVendorContract.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT_APPROVAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContract.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pVendorContract.Errormsg = ex.Message
            End Try
            Return pVendorContract
        End Function
    End Class
End Namespace
