Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: RateTptCustomerDetails
    ''' @author	: Santosh Singh- 25/1/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class RateTptCustomerDetails 
    
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContStatus As String ' Define Private Variable ContStatus With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private lngCommodityId As Long ' Define Private Variable CommodityId With DataType As Long 
        Private strImoCode As String ' Define Private Variable ImoCode With DataType As String 
        Private lngFromRange As Long ' Define Private Variable FromRange With DataType As Long 
        Private lngToRange As Long ' Define Private Variable ToRange With DataType As Long 
        Private dblRate As Double ' Define Private Variable Rate With DataType As Double 
        Private strApprovalFlage As String ' Define Private Variable ApprovalFlage With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngRateTptRefId As Long ' Define Private Variable RateTptRefId With DataType As Long 
        Private lngRateTptId As Long ' Define Private Variable RateTptId With DataType As Long 
        Private strFromDate As String ' Define Private Variable FromDate With DataType As String 
        Private strToDate As String ' Define Private Variable ToDate With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private lngFromLocation As Long ' Define Private Variable FromLocation With DataType As Long 
        Private lngToLocation As Long ' Define Private Variable ToLocation With DataType As Long 
        Private lngDistance As Long ' Define Private Variable Distance With DataType As Long 
        Private strStuffDestuff As String ' Define Private Variable StuffDestuff With DataType As String 
        Private lngTrailorSize As Long ' Define Private Variable TrailorSize With DataType As Long 
        Private lngContRepTrailor As Long ' Define Private Variable ContRepTrailor With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
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
        ''' Get or Set the Value of CommodityId
        ''' </summary>
        ''' <value>lngCommodityId</value>
        ''' <returns> Return lngCommodityId</returns>
        ''' <remarks> Get or Set the Value of CommodityId  </remarks>
        '''
        Public Property CommodityId() as Long
            Get
                Return lngCommodityId
            End Get
            Set(ByVal value As Long)
                lngCommodityId = value
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
        ''' <value>dblRate</value>
        ''' <returns> Return dblRate</returns>
        ''' <remarks> Get or Set the Value of Rate  </remarks>
        '''
        Public Property Rate() as Double
            Get
                Return dblRate
            End Get
            Set(ByVal value As Double)
                dblRate = value
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
        ''' Get or Set the Value of RateTptRefId
        ''' </summary>
        ''' <value>lngRateTptRefId</value>
        ''' <returns> Return lngRateTptRefId</returns>
        ''' <remarks> Get or Set the Value of RateTptRefId  </remarks>
        '''
        Public Property RateTptRefId() as Long
            Get
                Return lngRateTptRefId
            End Get
            Set(ByVal value As Long)
                lngRateTptRefId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RateTptId
        ''' </summary>
        ''' <value>lngRateTptId</value>
        ''' <returns> Return lngRateTptId</returns>
        ''' <remarks> Get or Set the Value of RateTptId  </remarks>
        '''
        Public Property RateTptId() as Long
            Get
                Return lngRateTptId
            End Get
            Set(ByVal value As Long)
                lngRateTptId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FromDate
        ''' </summary>
        ''' <value>strFromDate</value>
        ''' <returns> Return strFromDate</returns>
        ''' <remarks> Get or Set the Value of FromDate  </remarks>
        '''
        Public Property FromDate() as String
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
        ''' <remarks> Get or Set the Value of ToDate  </remarks>
        '''
        Public Property ToDate() as String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
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
        ''' Get or Set the Value of FromLocation
        ''' </summary>
        ''' <value>lngFromLocation</value>
        ''' <returns> Return lngFromLocation</returns>
        ''' <remarks> Get or Set the Value of FromLocation  </remarks>
        '''
        Public Property FromLocation() as Long
            Get
                Return lngFromLocation
            End Get
            Set(ByVal value As Long)
                lngFromLocation = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ToLocation
        ''' </summary>
        ''' <value>lngToLocation</value>
        ''' <returns> Return lngToLocation</returns>
        ''' <remarks> Get or Set the Value of ToLocation  </remarks>
        '''
        Public Property ToLocation() as Long
            Get
                Return lngToLocation
            End Get
            Set(ByVal value As Long)
                lngToLocation = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Distance
        ''' </summary>
        ''' <value>lngDistance</value>
        ''' <returns> Return lngDistance</returns>
        ''' <remarks> Get or Set the Value of Distance  </remarks>
        '''
        Public Property Distance() as Long
            Get
                Return lngDistance
            End Get
            Set(ByVal value As Long)
                lngDistance = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of StuffDestuff
        ''' </summary>
        ''' <value>strStuffDestuff</value>
        ''' <returns> Return strStuffDestuff</returns>
        ''' <remarks> Get or Set the Value of StuffDestuff  </remarks>
        '''
        Public Property StuffDestuff() as String
            Get
                Return strStuffDestuff
            End Get
            Set(ByVal value As String)
                strStuffDestuff = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TrailorSize
        ''' </summary>
        ''' <value>lngTrailorSize</value>
        ''' <returns> Return lngTrailorSize</returns>
        ''' <remarks> Get or Set the Value of TrailorSize  </remarks>
        '''
        Public Property TrailorSize() as Long
            Get
                Return lngTrailorSize
            End Get
            Set(ByVal value As Long)
                lngTrailorSize = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContRepTrailor
        ''' </summary>
        ''' <value>lngContRepTrailor</value>
        ''' <returns> Return lngContRepTrailor</returns>
        ''' <remarks> Get or Set the Value of ContRepTrailor  </remarks>
        '''
        Public Property ContRepTrailor() as Long
            Get
                Return lngContRepTrailor
            End Get
            Set(ByVal value As Long)
                lngContRepTrailor = value
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
            strContSize = ""
            strContStatus = ""
            strContType = ""
            lngCommodityId = 0 
            strImoCode = ""
            lngFromRange = 0 
            lngToRange = 0 
            dblRate = 0.0 
            strApprovalFlage = ""
            lngTerminalId = 0 
            lngRateTptRefId = 0 
            lngRateTptId = 0 
            strFromDate = ""
            strToDate = ""
            strDocType = ""
            lngFromLocation = 0 
            lngToLocation = 0 
            lngDistance = 0 
            strStuffDestuff = ""
            lngTrailorSize = 0 
            lngContRepTrailor = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRateTptCustomerDetails"></param>
        ''' <returns>Return pRateTptCustomerDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_SIZE", pRateTptCustomerDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptCustomerDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptCustomerDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptCustomerDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptCustomerDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptCustomerDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptCustomerDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptCustomerDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAGE", pRateTptCustomerDetails.ApprovalFlage)
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomerDetails.TerminalId)
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptCustomerDetails.RateTptRefId, ParameterDirection.Output)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomerDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptCustomerDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptCustomerDetails.ToDate)
                db.AddParameter("p_DOC_TYPE", pRateTptCustomerDetails.DocType)
                db.AddParameter("p_FROM_LOCATION", pRateTptCustomerDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptCustomerDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptCustomerDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptCustomerDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptCustomerDetails.TrailorSize)
                db.AddParameter("p_CONT_REP_TRAILOR", pRateTptCustomerDetails.ContRepTrailor)
                db.AddParameter("p_ErrorMsg", pRateTptCustomerDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_CUSTOMER_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomerDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptCustomerDetails.RateTptRefId  = db.Parameters.Item("p_RATE_TPT_REF_ID").value
                
                If pRateTptCustomerDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptCustomerDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptCustomerDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptCustomerDetails"></param>
        ''' <returns>Return pRateTptCustomerDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_CONT_SIZE", pRateTptCustomerDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptCustomerDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptCustomerDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptCustomerDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptCustomerDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptCustomerDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptCustomerDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptCustomerDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAGE", pRateTptCustomerDetails.ApprovalFlage)
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomerDetails.TerminalId)
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptCustomerDetails.RateTptRefId, ParameterDirection.Output)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomerDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptCustomerDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptCustomerDetails.ToDate)
                db.AddParameter("p_DOC_TYPE", pRateTptCustomerDetails.DocType)
                db.AddParameter("p_FROM_LOCATION", pRateTptCustomerDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptCustomerDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptCustomerDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptCustomerDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptCustomerDetails.TrailorSize)
                db.AddParameter("p_CONT_REP_TRAILOR", pRateTptCustomerDetails.ContRepTrailor)
                db.AddParameter("p_ErrorMsg", pRateTptCustomerDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_CUSTOMER_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomerDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptCustomerDetails.RateTptRefId  = db.Parameters.Item("p_RATE_TPT_REF_ID").value
                
            Catch ex As Exception
                pRateTptCustomerDetails.ErrorMsg = ex.Message
            End Try
            Return pRateTptCustomerDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRateTptCustomerDetails"></param>
        ''' <returns>Return pRateTptCustomerDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CONT_SIZE", pRateTptCustomerDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptCustomerDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptCustomerDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptCustomerDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptCustomerDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptCustomerDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptCustomerDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptCustomerDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAGE", pRateTptCustomerDetails.ApprovalFlage)
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomerDetails.TerminalId)
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptCustomerDetails.RateTptRefId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomerDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptCustomerDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptCustomerDetails.ToDate)
                db.AddParameter("p_DOC_TYPE", pRateTptCustomerDetails.DocType)
                db.AddParameter("p_FROM_LOCATION", pRateTptCustomerDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptCustomerDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptCustomerDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptCustomerDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptCustomerDetails.TrailorSize)
                db.AddParameter("p_CONT_REP_TRAILOR", pRateTptCustomerDetails.ContRepTrailor)
                db.AddParameter("p_ErrorMsg", pRateTptCustomerDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_CUSTOMER_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomerDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRateTptCustomerDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptCustomerDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptCustomerDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptCustomerDetails"></param>
        ''' <returns>Return pRateTptCustomerDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_CONT_SIZE", pRateTptCustomerDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptCustomerDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptCustomerDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptCustomerDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptCustomerDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptCustomerDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptCustomerDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptCustomerDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAGE", pRateTptCustomerDetails.ApprovalFlage)
                db.AddParameter("p_TERMINAL_ID", pRateTptCustomerDetails.TerminalId)
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptCustomerDetails.RateTptRefId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptCustomerDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptCustomerDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptCustomerDetails.ToDate)
                db.AddParameter("p_DOC_TYPE", pRateTptCustomerDetails.DocType)
                db.AddParameter("p_FROM_LOCATION", pRateTptCustomerDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptCustomerDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptCustomerDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptCustomerDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptCustomerDetails.TrailorSize)
                db.AddParameter("p_CONT_REP_TRAILOR", pRateTptCustomerDetails.ContRepTrailor)
                db.AddParameter("p_ErrorMsg", pRateTptCustomerDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_CUSTOMER_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptCustomerDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pRateTptCustomerDetails.ErrorMsg = ex.Message
                End Try
            Return pRateTptCustomerDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PRateTptCustomerDetails.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                PRateTptCustomerDetails.ContStatus = dbr("CONT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PRateTptCustomerDetails.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PRateTptCustomerDetails.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMO_CODE").ToString <> "" Then
                                PRateTptCustomerDetails.ImoCode = dbr("IMO_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_RANGE").ToString <> "" Then
                                PRateTptCustomerDetails.FromRange = dbr("FROM_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANGE").ToString <> "" Then
                                PRateTptCustomerDetails.ToRange = dbr("TO_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PRateTptCustomerDetails.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                PRateTptCustomerDetails.ApprovalFlage = dbr("APPROVAL_FLAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PRateTptCustomerDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TPT_REF_ID").ToString <> "" Then
                                PRateTptCustomerDetails.RateTptRefId = dbr("RATE_TPT_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TPT_ID").ToString <> "" Then
                                PRateTptCustomerDetails.RateTptId = dbr("RATE_TPT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                PRateTptCustomerDetails.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                PRateTptCustomerDetails.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PRateTptCustomerDetails.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                PRateTptCustomerDetails.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_LOCATION").ToString <> "" Then
                                PRateTptCustomerDetails.ToLocation = dbr("TO_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE").ToString <> "" Then
                                PRateTptCustomerDetails.Distance = dbr("DISTANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFF_DESTUFF").ToString <> "" Then
                                PRateTptCustomerDetails.StuffDestuff = dbr("STUFF_DESTUFF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAILOR_SIZE").ToString <> "" Then
                                PRateTptCustomerDetails.TrailorSize = dbr("TRAILOR_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_REP_TRAILOR").ToString <> "" Then
                                PRateTptCustomerDetails.ContRepTrailor = dbr("CONT_REP_TRAILOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pRateTptCustomerDetails.ErrorMsg = ex.Message
            End Try
            Return pRateTptCustomerDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRateTptCustomerDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RateTptCustomerDetails
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
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                temp.CommodityId = dbr("COMMODITY_ID")
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
                            If dbr("APPROVAL_FLAGE").ToString <> "" Then
                                temp.ApprovalFlage = dbr("APPROVAL_FLAGE")
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
                            If dbr("RATE_TPT_REF_ID").ToString <> "" Then
                                temp.RateTptRefId = dbr("RATE_TPT_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_TPT_ID").ToString <> "" Then
                                temp.RateTptId = dbr("RATE_TPT_ID")
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
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                temp.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_LOCATION").ToString <> "" Then
                                temp.ToLocation = dbr("TO_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE").ToString <> "" Then
                                temp.Distance = dbr("DISTANCE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STUFF_DESTUFF").ToString <> "" Then
                                temp.StuffDestuff = dbr("STUFF_DESTUFF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAILOR_SIZE").ToString <> "" Then
                                temp.TrailorSize = dbr("TRAILOR_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_REP_TRAILOR").ToString <> "" Then
                                temp.ContRepTrailor = dbr("CONT_REP_TRAILOR")
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
        Public Shared Function ReturnRateTptCustomerDetails(ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As RateTptCustomerDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_DTLS_BYID", pRateTptCustomerDetails.TerminalId & "," & pRateTptCustomerDetails.RateTptId)
                pRateTptCustomerDetails = ReturnObjectValues(dbr, pRateTptCustomerDetails)
                dbr.Close()
            Catch ex As Exception
                pRateTptCustomerDetails.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptCustomerDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptVendorDetailsListByRateId(ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptCustomerDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_DTLS_BYID", pRateTptCustomerDetails.TerminalId & "," & pRateTptCustomerDetails.RateTptId)
                arrRateTptCustomerDetails = ReturnObjectValuesList(dbr, arrRateTptCustomerDetails)
                dbr.Close()
            Catch ex As Exception
                arrRateTptCustomerDetails = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptCustomerDetails
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnRateTptCustomerDetailsList (ByVal pRateTptCustomerDetails As RateTptCustomerDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptCustomerDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_DTLS_LIST", pRateTptCustomerDetails.TerminalId & "," & pRateTptCustomerDetails.RateTptId)
                arrRateTptCustomerDetails = ReturnObjectValuesList(dbr, arrRateTptCustomerDetails)
                dbr.Close()
            Catch ex As Exception
                arrRateTptCustomerDetails = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptCustomerDetails
        End Function
    End Class
End Namespace
