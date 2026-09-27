Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorContractDetails
    ''' @author	: Amit K. Singh- 9/5/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VendorContractDetails 
    
        Private lngContractRefId As Long ' Define Private Variable ContractRefId With DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngContractId As Long ' Define Private Variable ContractId With DataType As Long 
        Private lngUomId As Long ' Define Private Variable UomId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContStatus As String ' Define Private Variable ContStatus With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strImoCode As String ' Define Private Variable ImoCode With DataType As String 
        Private lngFromRange As Long ' Define Private Variable FromRange With DataType As Long 
        Private lngToRange As Long ' Define Private Variable ToRange With DataType As Long 
        Private lngRate As Long ' Define Private Variable Rate With DataType As Long 
        Private strApprovalFlag As String ' Define Private Variable ApprovalFlag With DataType As String 
        Private strFromDate As String  ' Define Private Variable FromDate With DataType As String
        Private strToDate As String ' Define Private Variable ToDate With DataType As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of ContractRefId
        ''' </summary>
        ''' <value>lngContractRefId</value>
        ''' <returns> Return lngContractRefId</returns>
        ''' <remarks> Get or Set the Value of ContractRefId  </remarks>
        '''
        Public Property ContractRefId() as Long
            Get
                Return lngContractRefId
            End Get
            Set(ByVal value As Long)
                lngContractRefId = value
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
        ''' Get or Set the Value of UomId
        ''' </summary>
        ''' <value>lngUomId</value>
        ''' <returns> Return lngUomId</returns>
        ''' <remarks> Get or Set the Value of UomId  </remarks>
        '''
        Public Property UomId() as Long
            Get
                Return lngUomId
            End Get
            Set(ByVal value As Long)
                lngUomId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() as Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() as String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks> Get or Set the Value of ContSize  </remarks>
        '''
        Public Property ContSize() as String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContStatus
        ''' </summary>
        ''' <value>strContStatus</value>
        ''' <returns> Return strContStatus</returns>
        ''' <remarks> Get or Set the Value of ContStatus  </remarks>
        '''
        Public Property ContStatus() as String
            Get
                Return strContStatus
            End Get
            Set(ByVal value As String)
                strContStatus = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property ContType() as String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ImoCode
        ''' </summary>
        ''' <value>strImoCode</value>
        ''' <returns> Return strImoCode</returns>
        ''' <remarks> Get or Set the Value of ImoCode  </remarks>
        '''
        Public Property ImoCode() as String
            Get
                Return strImoCode
            End Get
            Set(ByVal value As String)
                strImoCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FromRange
        ''' </summary>
        ''' <value>lngFromRange</value>
        ''' <returns> Return lngFromRange</returns>
        ''' <remarks> Get or Set the Value of FromRange  </remarks>
        '''
        Public Property FromRange() as Long
            Get
                Return lngFromRange
            End Get
            Set(ByVal value As Long)
                lngFromRange = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ToRange
        ''' </summary>
        ''' <value>lngToRange</value>
        ''' <returns> Return lngToRange</returns>
        ''' <remarks> Get or Set the Value of ToRange  </remarks>
        '''
        Public Property ToRange() as Long
            Get
                Return lngToRange
            End Get
            Set(ByVal value As Long)
                lngToRange = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Rate
        ''' </summary>
        ''' <value>lngRate</value>
        ''' <returns> Return lngRate</returns>
        ''' <remarks> Get or Set the Value of Rate  </remarks>
        '''
        Public Property Rate() as Long
            Get
                Return lngRate
            End Get
            Set(ByVal value As Long)
                lngRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ApprovalFlag
        ''' </summary>
        ''' <value>strApprovalFlag</value>
        ''' <returns> Return strApprovalFlag</returns>
        ''' <remarks> Get or Set the Value of ApprovalFlag  </remarks>
        '''
        Public Property ApprovalFlag() as String
            Get
                Return strApprovalFlag
            End Get
            Set(ByVal value As String)
                strApprovalFlag = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of FromDate
        ''' </summary>
        ''' <value>strFromDate</value>
        ''' <returns> Return strFromDate</returns>
        ''' <remarks> Get or Set the Value of FromDate </remarks>
        '''
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal value As String)
                strFromDate = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of ToDate
        ''' </summary>
        ''' <value>strToDate</value>
        ''' <returns> Return strToDate</returns>
        ''' <remarks> Get or Set the Value of ToDate </remarks>
        '''
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
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
            lngContractRefId = 0 
            lngTerminalId = 0 
            lngContractId = 0 
            lngUomId = 0 
            lngServiceId = 0 
            strDocType = ""
            strContSize = ""
            strContStatus = ""
            strContType = ""
            strImoCode = ""
            lngFromRange = 0 
            lngToRange = 0 
            lngRate = 0 
            strApprovalFlag = ""
            strFromDate = ""
            strToDate = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVendorContractDetails"></param>
        ''' <returns>Return pVendorContractDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONTRACT_REF_ID", pVendorContractDetails.ContractRefId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pVendorContractDetails.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContractDetails.ContractId)
                db.AddParameter("p_UOM_ID", pVendorContractDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pVendorContractDetails.ServiceId)
                db.AddParameter("p_DOC_TYPE", pVendorContractDetails.DocType)
                db.AddParameter("p_CONT_SIZE", pVendorContractDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pVendorContractDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pVendorContractDetails.ContType)
                db.AddParameter("p_IMO_CODE", pVendorContractDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pVendorContractDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pVendorContractDetails.ToRange)
                db.AddParameter("p_RATE", pVendorContractDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pVendorContractDetails.ApprovalFlag)
                db.AddParameter("p_FROM_DATE", pVendorContractDetails.FromDate)
                db.AddParameter("p_TO_DATE", pVendorContractDetails.ToDate)
                db.AddParameter("p_ErrorMsg", pVendorContractDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_CONTRACT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContractDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorContractDetails.ContractRefId  = db.Parameters.Item("p_CONTRACT_REF_ID").value
                
                If pVendorContractDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorContractDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContractDetails"></param>
        ''' <returns>Return pVendorContractDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_CONTRACT_REF_ID", pVendorContractDetails.ContractRefId, ParameterDirection.Output)
                db.AddParameter("p_TERMINAL_ID", pVendorContractDetails.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContractDetails.ContractId)
                db.AddParameter("p_UOM_ID", pVendorContractDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pVendorContractDetails.ServiceId)
                db.AddParameter("p_DOC_TYPE", pVendorContractDetails.DocType)
                db.AddParameter("p_CONT_SIZE", pVendorContractDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pVendorContractDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pVendorContractDetails.ContType)
                db.AddParameter("p_IMO_CODE", pVendorContractDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pVendorContractDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pVendorContractDetails.ToRange)
                db.AddParameter("p_RATE", pVendorContractDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pVendorContractDetails.ApprovalFlag)
                db.AddParameter("p_FROM_DATE", pVendorContractDetails.FromDate)
                db.AddParameter("p_TO_DATE", pVendorContractDetails.ToDate)
                db.AddParameter("p_ErrorMsg", pVendorContractDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_CONTRACT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContractDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVendorContractDetails.ContractRefId  = db.Parameters.Item("p_CONTRACT_REF_ID").value
                
            Catch ex As Exception
                pVendorContractDetails.ErrorMsg = ex.Message
            End Try
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorContractDetails"></param>
        ''' <returns>Return pVendorContractDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONTRACT_REF_ID", pVendorContractDetails.ContractRefId)
                db.AddParameter("p_TERMINAL_ID", pVendorContractDetails.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContractDetails.ContractId)
                db.AddParameter("p_UOM_ID", pVendorContractDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pVendorContractDetails.ServiceId)
                db.AddParameter("p_DOC_TYPE", pVendorContractDetails.DocType)
                db.AddParameter("p_CONT_SIZE", pVendorContractDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pVendorContractDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pVendorContractDetails.ContType)
                db.AddParameter("p_IMO_CODE", pVendorContractDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pVendorContractDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pVendorContractDetails.ToRange)
                db.AddParameter("p_RATE", pVendorContractDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pVendorContractDetails.ApprovalFlag)
                db.AddParameter("p_FROM_DATE", pVendorContractDetails.FromDate)
                db.AddParameter("p_TO_DATE", pVendorContractDetails.ToDate)
                db.AddParameter("p_ErrorMsg", pVendorContractDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContractDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorContractDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorContractDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContractDetails"></param>
        ''' <returns>Return pVendorContractDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_CONTRACT_REF_ID", pVendorContractDetails.ContractRefId)
                db.AddParameter("p_TERMINAL_ID", pVendorContractDetails.TerminalId)
                db.AddParameter("p_CONTRACT_ID", pVendorContractDetails.ContractId)
                db.AddParameter("p_UOM_ID", pVendorContractDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pVendorContractDetails.ServiceId)
                db.AddParameter("p_DOC_TYPE", pVendorContractDetails.DocType)
                db.AddParameter("p_CONT_SIZE", pVendorContractDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pVendorContractDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pVendorContractDetails.ContType)
                db.AddParameter("p_IMO_CODE", pVendorContractDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pVendorContractDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pVendorContractDetails.ToRange)
                db.AddParameter("p_RATE", pVendorContractDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pVendorContractDetails.ApprovalFlag)
                db.AddParameter("p_FROM_DATE", pVendorContractDetails.FromDate)
                db.AddParameter("p_TO_DATE", pVendorContractDetails.ToDate)
                db.AddParameter("p_ErrorMsg", pVendorContractDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContractDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVendorContractDetails.ErrorMsg = ex.Message
                End Try
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CONTRACT_REF_ID").ToString <> "" Then
                                PVendorContractDetails.ContractRefId = dbr("CONTRACT_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVendorContractDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTRACT_ID").ToString <> "" Then
                                PVendorContractDetails.ContractId = dbr("CONTRACT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                PVendorContractDetails.UomId = dbr("UOM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PVendorContractDetails.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PVendorContractDetails.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PVendorContractDetails.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                PVendorContractDetails.ContStatus = dbr("CONT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PVendorContractDetails.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMO_CODE").ToString <> "" Then
                                PVendorContractDetails.ImoCode = dbr("IMO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_RANGE").ToString <> "" Then
                                PVendorContractDetails.FromRange = dbr("FROM_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANGE").ToString <> "" Then
                                PVendorContractDetails.ToRange = dbr("TO_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PVendorContractDetails.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAG").ToString <> "" Then
                                PVendorContractDetails.ApprovalFlag = dbr("APPROVAL_FLAG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                pVendorContractDetails.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                pVendorContractDetails.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVendorContractDetails.ErrorMsg = ex.Message
            End Try
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorContractDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorContractDetails
                        Try
                            If dbr("CONTRACT_REF_ID").ToString <> "" Then
                                temp.ContractRefId = dbr("CONTRACT_REF_ID")
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
                            If dbr("CONTRACT_ID").ToString <> "" Then
                                temp.ContractId = dbr("CONTRACT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                temp.UomId = dbr("UOM_ID")
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
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
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
                            If dbr("CONT_STATUS").ToString <> "" Then
                                temp.ContStatus = dbr("CONT_STATUS")
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
                            If dbr("IMO_CODE").ToString <> "" Then
                                temp.ImoCode = dbr("IMO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_RANGE").ToString <> "" Then
                                temp.FromRange = dbr("FROM_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANGE").ToString <> "" Then
                                temp.ToRange = dbr("TO_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                temp.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAG").ToString <> "" Then
                                temp.ApprovalFlag = dbr("APPROVAL_FLAG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                temp.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                temp.ToDate = dbr("TO_DATE")
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
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnVendorContractDetailsListByContractRefId_ContractId(ByVal pVendorContractDetails As VendorContractDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorContractDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_DTLS_BY_ID", pVendorContractDetails.TerminalId & "," & pVendorContractDetails.ContractId & "," & pVendorContractDetails.ContractRefId)
                arrVendorContractDetails = ReturnObjectValuesList(dbr, arrVendorContractDetails)
                dbr.Close()
            Catch ex As Exception
                arrVendorContractDetails = Nothing
            End Try
            db.CloseDB()
            Return arrVendorContractDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnVendorContractDetailsByContractRefId_ContractId(ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_DTLS_BY_ID", pVendorContractDetails.TerminalId & "," & pVendorContractDetails.ContractId & "," & pVendorContractDetails.ContractRefId)
                pVendorContractDetails = ReturnObjectValues(dbr, pVendorContractDetails)
                dbr.Close()
            Catch ex As Exception
                pVendorContractDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorContractDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorContractDetails"></param>
        ''' <returns>Return pVendorContractDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateApprovalTrn(ByVal db As DBConnect, ByVal pVendorContractDetails As VendorContractDetails) As VendorContractDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVendorContractDetails.TerminalId)
                db.AddParameter("p_CONTRACT_REF_ID", pVendorContractDetails.ContractRefId)
                db.AddParameter("p_APPROVAL_FLAG", pVendorContractDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pVendorContractDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_CONTRACT_DTLS_APPROV", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorContractDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pVendorContractDetails.Errormsg = ex.Message
            End Try
            Return pVendorContractDetails
        End Function
    End Class
End Namespace
