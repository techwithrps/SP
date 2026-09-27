Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CostRateDetails
    ''' @author	: Amit K. Singh- 3/9/2019
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CostRateDetails 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngValidityId As Long ' Define Private Variable ValidityId With DataType As Long 
        Private lngRateId As Long ' Define Private Variable RateId With DataType As Long 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strCargoType As String ' Define Private Variable CargoType With DataType As String 
        Private lngCommodityId As Long ' Define Private Variable CommodityId With DataType As Long 
        Private lngFromRang As Long ' Define Private Variable FromRang With DataType As Long 
        Private lngToRang As Long ' Define Private Variable ToRang With DataType As Long 
        Private lngRate As Long ' Define Private Variable Rate With DataType As Long 
        Private lngRateKeyId As Long ' Define Private Variable RateKeyId With DataType As Long 
        Private strDiscountType As String ' Define Private Variable DiscountType With DataType As String 
        Private dblDiscount As Double ' Define Private Variable Discount With DataType As Double 
        Private dblBaseRate As Double ' Define Private Variable BaseRate With DataType As Double 
        Private strHandlingMode As String ' Define Private Variable HandlingMode With DataType As String 
        Private lngSurCharge As Long ' Define Private Variable SurCharge With DataType As Long 
        Private lngPol As Long ' Define Private Variable Pol With DataType As Long 
        Private strContStatus As String ' Define Private Variable ContStatus With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngPortId As Long ' Define Private Variable PortId With DataType As Long 
        Private strCurrency As String ' Define Private Variable Currency With DataType As String 
        Private strTransitTime As String ' Define Private Variable Currency With DataType As String 
        Private strPodFreeDays As String ' Define Private Variable Currency With DataType As String 
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
        ''' Get or Set the Value of ValidityId
        ''' </summary>
        ''' <value>lngValidityId</value>
        ''' <returns> Return lngValidityId</returns>
        ''' <remarks> Get or Set the Value of ValidityId  </remarks>
        '''
        Public Property ValidityId() as Long
            Get
                Return lngValidityId
            End Get
            Set(ByVal value As Long)
                lngValidityId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RateId
        ''' </summary>
        ''' <value>lngRateId</value>
        ''' <returns> Return lngRateId</returns>
        ''' <remarks> Get or Set the Value of RateId  </remarks>
        '''
        Public Property RateId() as Long
            Get
                Return lngRateId
            End Get
            Set(ByVal value As Long)
                lngRateId = value
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
        ''' Get or Set the Value of CargoType
        ''' </summary>
        ''' <value>strCargoType</value>
        ''' <returns> Return strCargoType</returns>
        ''' <remarks> Get or Set the Value of CargoType  </remarks>
        '''
        Public Property CargoType() as String
            Get
                Return strCargoType
            End Get
            Set(ByVal value As String)
                strCargoType = value
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
        ''' Get or Set the Value of FromRang
        ''' </summary>
        ''' <value>lngFromRang</value>
        ''' <returns> Return lngFromRang</returns>
        ''' <remarks> Get or Set the Value of FromRang  </remarks>
        '''
        Public Property FromRang() as Long
            Get
                Return lngFromRang
            End Get
            Set(ByVal value As Long)
                lngFromRang = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ToRang
        ''' </summary>
        ''' <value>lngToRang</value>
        ''' <returns> Return lngToRang</returns>
        ''' <remarks> Get or Set the Value of ToRang  </remarks>
        '''
        Public Property ToRang() as Long
            Get
                Return lngToRang
            End Get
            Set(ByVal value As Long)
                lngToRang = value
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
        ''' Get or Set the Value of RateKeyId
        ''' </summary>
        ''' <value>lngRateKeyId</value>
        ''' <returns> Return lngRateKeyId</returns>
        ''' <remarks> Get or Set the Value of RateKeyId  </remarks>
        '''
        Public Property RateKeyId() as Long
            Get
                Return lngRateKeyId
            End Get
            Set(ByVal value As Long)
                lngRateKeyId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DiscountType
        ''' </summary>
        ''' <value>strDiscountType</value>
        ''' <returns> Return strDiscountType</returns>
        ''' <remarks> Get or Set the Value of DiscountType  </remarks>
        '''
        Public Property DiscountType() as String
            Get
                Return strDiscountType
            End Get
            Set(ByVal value As String)
                strDiscountType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Discount
        ''' </summary>
        ''' <value>dblDiscount</value>
        ''' <returns> Return dblDiscount</returns>
        ''' <remarks> Get or Set the Value of Discount  </remarks>
        '''
        Public Property Discount() as Double
            Get
                Return dblDiscount
            End Get
            Set(ByVal value As Double)
                dblDiscount = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BaseRate
        ''' </summary>
        ''' <value>dblBaseRate</value>
        ''' <returns> Return dblBaseRate</returns>
        ''' <remarks> Get or Set the Value of BaseRate  </remarks>
        '''
        Public Property BaseRate() as Double
            Get
                Return dblBaseRate
            End Get
            Set(ByVal value As Double)
                dblBaseRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HandlingMode
        ''' </summary>
        ''' <value>strHandlingMode</value>
        ''' <returns> Return strHandlingMode</returns>
        ''' <remarks> Get or Set the Value of HandlingMode  </remarks>
        '''
        Public Property HandlingMode() as String
            Get
                Return strHandlingMode
            End Get
            Set(ByVal value As String)
                strHandlingMode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SurCharge
        ''' </summary>
        ''' <value>lngSurCharge</value>
        ''' <returns> Return lngSurCharge</returns>
        ''' <remarks> Get or Set the Value of SurCharge  </remarks>
        '''
        Public Property SurCharge() as Long
            Get
                Return lngSurCharge
            End Get
            Set(ByVal value As Long)
                lngSurCharge = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Pol
        ''' </summary>
        ''' <value>lngPol</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property Pol() as Long
            Get
                Return lngPol
            End Get
            Set(ByVal value As Long)
                lngPol = value
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
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() as Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PortId
        ''' </summary>
        ''' <value>lngPortId</value>
        ''' <returns> Return lngPortId</returns>
        ''' <remarks> Get or Set the Value of PortId  </remarks>
        '''
        Public Property PortId() as Long
            Get
                Return lngPortId
            End Get
            Set(ByVal value As Long)
                lngPortId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Currency
        ''' </summary>
        ''' <value>strCurrency</value>
        ''' <returns> Return strCurrency</returns>
        ''' <remarks> Get or Set the Value of Currency  </remarks>
        '''
        Public Property Currency() as String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TransitTime
        ''' </summary>
        ''' <value>strCurrency</value>
        ''' <returns> Return strTransitTime</returns>
        ''' <remarks> Get or Set the Value of strTransitTime  </remarks>
        '''
        Public Property TransitTime() as String
            Get
                Return strTransitTime
            End Get
            Set(ByVal value As String)
                strTransitTime = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TransitTime
        ''' </summary>
        ''' <value>strCurrency</value>
        ''' <returns> Return strTransitTime</returns>
        ''' <remarks> Get or Set the Value of strTransitTime  </remarks>
        '''
        Public Property PodFreeDays() as String
            Get
                Return strPodFreeDays
            End Get
            Set(ByVal value As String)
                strPodFreeDays = value
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
            lngValidityId = 0 
            lngRateId = 0 
            strContSize = ""
            strContType = ""
            strCargoType = ""
            lngCommodityId = 0 
            lngFromRang = 0 
            lngToRang = 0 
            lngRate = 0 
            lngRateKeyId = 0 
            strDiscountType = ""
            dblDiscount = 0.0 
            dblBaseRate = 0.0 
            strHandlingMode = ""
            lngSurCharge = 0 
            lngPol = 0 
            strContStatus = ""
            strDocType = ""
            lngLineId = 0 
            lngPortId = 0 
            strCurrency = ""
            strTransitTime=""
            strPodFreeDays=""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCostRateDetails"></param>
        ''' <returns>Return pCostRateDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateDetails.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pCostRateDetails.ValidityId)
                db.AddParameter("p_RATE_ID", pCostRateDetails.RateId)
                db.AddParameter("p_CONT_SIZE", pCostRateDetails.ContSize)
                db.AddParameter("p_CONT_TYPE", pCostRateDetails.ContType)
                db.AddParameter("p_CARGO_TYPE", pCostRateDetails.CargoType)
                db.AddParameter("p_COMMODITY_ID", pCostRateDetails.CommodityId)
                db.AddParameter("p_FROM_RANG", pCostRateDetails.FromRang)
                db.AddParameter("p_TO_RANG", pCostRateDetails.ToRang)
                db.AddParameter("p_RATE", pCostRateDetails.Rate)
                db.AddParameter("p_RATE_KEY_ID", pCostRateDetails.RateKeyId, ParameterDirection.Output)
                db.AddParameter("p_DISCOUNT_TYPE", pCostRateDetails.DiscountType)
                db.AddParameter("p_DISCOUNT", pCostRateDetails.Discount)
                db.AddParameter("p_BASE_RATE", pCostRateDetails.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pCostRateDetails.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pCostRateDetails.SurCharge)
                db.AddParameter("p_POL", pCostRateDetails.Pol)
                db.AddParameter("p_CONT_STATUS", pCostRateDetails.ContStatus)
                db.AddParameter("p_DOC_TYPE", pCostRateDetails.DocType)
                db.AddParameter("p_LINE_ID", pCostRateDetails.LineId)
                db.AddParameter("p_PORT_ID", pCostRateDetails.PortId)
                db.AddParameter("p_CURRENCY", pCostRateDetails.Currency)
                db.AddParameter("p_TRANSIT_TIME", pCostRateDetails.TransitTime)
                db.AddParameter("p_POD_FREE_DAYS", pCostRateDetails.PodFreeDays)
                db.AddParameter("p_ErrorMsg", pCostRateDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_RATE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostRateDetails.RateKeyId  = db.Parameters.Item("p_RATE_KEY_ID").value
                
                If pCostRateDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostRateDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCostRateDetails"></param>
        ''' <returns>Return pCostRateDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateDetails.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pCostRateDetails.ValidityId)
                db.AddParameter("p_RATE_ID", pCostRateDetails.RateId)
                db.AddParameter("p_CONT_SIZE", pCostRateDetails.ContSize)
                db.AddParameter("p_CONT_TYPE", pCostRateDetails.ContType)
                db.AddParameter("p_CARGO_TYPE", pCostRateDetails.CargoType)
                db.AddParameter("p_COMMODITY_ID", pCostRateDetails.CommodityId)
                db.AddParameter("p_FROM_RANG", pCostRateDetails.FromRang)
                db.AddParameter("p_TO_RANG", pCostRateDetails.ToRang)
                db.AddParameter("p_RATE", pCostRateDetails.Rate)
                db.AddParameter("p_RATE_KEY_ID", pCostRateDetails.RateKeyId, ParameterDirection.Output)
                db.AddParameter("p_DISCOUNT_TYPE", pCostRateDetails.DiscountType)
                db.AddParameter("p_DISCOUNT", pCostRateDetails.Discount)
                db.AddParameter("p_BASE_RATE", pCostRateDetails.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pCostRateDetails.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pCostRateDetails.SurCharge)
                db.AddParameter("p_POL", pCostRateDetails.Pol)
                db.AddParameter("p_CONT_STATUS", pCostRateDetails.ContStatus)
                db.AddParameter("p_DOC_TYPE", pCostRateDetails.DocType)
                db.AddParameter("p_LINE_ID", pCostRateDetails.LineId)
                db.AddParameter("p_PORT_ID", pCostRateDetails.PortId)
                db.AddParameter("p_CURRENCY", pCostRateDetails.Currency)
                db.AddParameter("p_TRANSIT_TIME", pCostRateDetails.TransitTime)
                db.AddParameter("p_POD_FREE_DAYS", pCostRateDetails.PodFreeDays)
                db.AddParameter("p_ErrorMsg", pCostRateDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COST_RATE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCostRateDetails.RateKeyId  = db.Parameters.Item("p_RATE_KEY_ID").value
                
            Catch ex As Exception
                pCostRateDetails.ErrorMsg = ex.Message
            End Try
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCostRateDetails"></param>
        ''' <returns>Return pCostRateDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateDetails.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pCostRateDetails.ValidityId)
                db.AddParameter("p_RATE_ID", pCostRateDetails.RateId)
                db.AddParameter("p_CONT_SIZE", pCostRateDetails.ContSize)
                db.AddParameter("p_CONT_TYPE", pCostRateDetails.ContType)
                db.AddParameter("p_CARGO_TYPE", pCostRateDetails.CargoType)
                db.AddParameter("p_COMMODITY_ID", pCostRateDetails.CommodityId)
                db.AddParameter("p_FROM_RANG", pCostRateDetails.FromRang)
                db.AddParameter("p_TO_RANG", pCostRateDetails.ToRang)
                db.AddParameter("p_RATE", pCostRateDetails.Rate)
                db.AddParameter("p_RATE_KEY_ID", pCostRateDetails.RateKeyId)
                db.AddParameter("p_DISCOUNT_TYPE", pCostRateDetails.DiscountType)
                db.AddParameter("p_DISCOUNT", pCostRateDetails.Discount)
                db.AddParameter("p_BASE_RATE", pCostRateDetails.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pCostRateDetails.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pCostRateDetails.SurCharge)
                db.AddParameter("p_POL", pCostRateDetails.Pol)
                db.AddParameter("p_CONT_STATUS", pCostRateDetails.ContStatus)
                db.AddParameter("p_DOC_TYPE", pCostRateDetails.DocType)
                db.AddParameter("p_LINE_ID", pCostRateDetails.LineId)
                db.AddParameter("p_PORT_ID", pCostRateDetails.PortId)
                db.AddParameter("p_CURRENCY", pCostRateDetails.Currency)
                db.AddParameter("p_TRANSIT_TIME", pCostRateDetails.TransitTime)
                db.AddParameter("p_POD_FREE_DAYS", pCostRateDetails.PodFreeDays)
                db.AddParameter("p_ErrorMsg", pCostRateDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COST_RATE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCostRateDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCostRateDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCostRateDetails"></param>
        ''' <returns>Return pCostRateDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCostRateDetails.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pCostRateDetails.ValidityId)
                db.AddParameter("p_RATE_ID", pCostRateDetails.RateId)
                db.AddParameter("p_CONT_SIZE", pCostRateDetails.ContSize)
                db.AddParameter("p_CONT_TYPE", pCostRateDetails.ContType)
                db.AddParameter("p_CARGO_TYPE", pCostRateDetails.CargoType)
                db.AddParameter("p_COMMODITY_ID", pCostRateDetails.CommodityId)
                db.AddParameter("p_FROM_RANG", pCostRateDetails.FromRang)
                db.AddParameter("p_TO_RANG", pCostRateDetails.ToRang)
                db.AddParameter("p_RATE", pCostRateDetails.Rate)
                db.AddParameter("p_RATE_KEY_ID", pCostRateDetails.RateKeyId)
                db.AddParameter("p_DISCOUNT_TYPE", pCostRateDetails.DiscountType)
                db.AddParameter("p_DISCOUNT", pCostRateDetails.Discount)
                db.AddParameter("p_BASE_RATE", pCostRateDetails.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pCostRateDetails.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pCostRateDetails.SurCharge)
                db.AddParameter("p_POL", pCostRateDetails.Pol)
                db.AddParameter("p_CONT_STATUS", pCostRateDetails.ContStatus)
                db.AddParameter("p_DOC_TYPE", pCostRateDetails.DocType)
                db.AddParameter("p_LINE_ID", pCostRateDetails.LineId)
                db.AddParameter("p_PORT_ID", pCostRateDetails.PortId)
                db.AddParameter("p_CURRENCY", pCostRateDetails.Currency)
                db.AddParameter("p_TRANSIT_TIME", pCostRateDetails.TransitTime)
                db.AddParameter("p_POD_FREE_DAYS", pCostRateDetails.PodFreeDays)
                db.AddParameter("p_ErrorMsg", pCostRateDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COST_RATE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCostRateDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCostRateDetails.ErrorMsg = ex.Message
                End Try
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCostRateDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY_ID").ToString <> "" Then
                                PCostRateDetails.ValidityId = dbr("VALIDITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                PCostRateDetails.RateId = dbr("RATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PCostRateDetails.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PCostRateDetails.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_TYPE").ToString <> "" Then
                                PCostRateDetails.CargoType = dbr("CARGO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PCostRateDetails.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_RANG").ToString <> "" Then
                                PCostRateDetails.FromRang = dbr("FROM_RANG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANG").ToString <> "" Then
                                PCostRateDetails.ToRang = dbr("TO_RANG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PCostRateDetails.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_KEY_ID").ToString <> "" Then
                                PCostRateDetails.RateKeyId = dbr("RATE_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT_TYPE").ToString <> "" Then
                                PCostRateDetails.DiscountType = dbr("DISCOUNT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT").ToString <> "" Then
                                PCostRateDetails.Discount = dbr("DISCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                PCostRateDetails.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDLING_MODE").ToString <> "" Then
                                PCostRateDetails.HandlingMode = dbr("HANDLING_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SUR_CHARGE").ToString <> "" Then
                                PCostRateDetails.SurCharge = dbr("SUR_CHARGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                PCostRateDetails.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                PCostRateDetails.ContStatus = dbr("CONT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PCostRateDetails.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PCostRateDetails.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                PCostRateDetails.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                PCostRateDetails.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSIT_TIME").ToString <> "" Then
                                PCostRateDetails.TransitTime = dbr("TRANSIT_TIME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_FREE_DAYS").ToString <> "" Then
                                PCostRateDetails.PodFreeDays = dbr("POD_FREE_DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCostRateDetails.ErrorMsg = ex.Message
            End Try
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCostRateDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CostRateDetails
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY_ID").ToString <> "" Then
                                temp.ValidityId = dbr("VALIDITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                temp.RateId = dbr("RATE_ID")
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
                            If dbr("CARGO_TYPE").ToString <> "" Then
                                temp.CargoType = dbr("CARGO_TYPE")
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
                            If dbr("FROM_RANG").ToString <> "" Then
                                temp.FromRang = dbr("FROM_RANG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANG").ToString <> "" Then
                                temp.ToRang = dbr("TO_RANG")
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
                            If dbr("RATE_KEY_ID").ToString <> "" Then
                                temp.RateKeyId = dbr("RATE_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT_TYPE").ToString <> "" Then
                                temp.DiscountType = dbr("DISCOUNT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT").ToString <> "" Then
                                temp.Discount = dbr("DISCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                temp.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDLING_MODE").ToString <> "" Then
                                temp.HandlingMode = dbr("HANDLING_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SUR_CHARGE").ToString <> "" Then
                                temp.SurCharge = dbr("SUR_CHARGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                temp.Pol = dbr("POL")
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
                            If dbr("PORT_ID").ToString <> "" Then
                                temp.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                temp.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSIT_TIME").ToString <> "" Then
                                temp.TransitTime = dbr("TRANSIT_TIME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_FREE_DAYS").ToString <> "" Then
                                temp.PodFreeDays = dbr("POD_FREE_DAYS")
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
        Public Shared Function ReturnCostRateDetails(ByVal pCostRateDetails As CostRateDetails) As CostRateDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_RATE_DETAILS", "' '")
                pCostRateDetails = ReturnObjectValues(dbr, pCostRateDetails)
                dbr.Close()
            Catch ex As Exception
                pCostRateDetails.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCostRateDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCostRateDetailsList (ByVal pCostRateDetails As CostRateDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCostRateDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_RATE_DETAILS", "' '")
                arrCostRateDetails = ReturnObjectValuesList(dbr, arrCostRateDetails)
                dbr.Close()
            Catch ex As Exception
                arrCostRateDetails = Nothing
            End Try
            db.CloseDB()
            Return arrCostRateDetails
        End Function
        Public Shared Function ReturnCostRateDetailsListByRateId(ByVal pCostRateDetails As CostRateDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COST_DETAILS_ALL_BY_RATE_ID", pCostRateDetails.TerminalId & "," & pCostRateDetails.RateId)
                arrRateDetails = ReturnObjectValuesList(dbr, arrRateDetails)
                dbr.Close()
            Catch ex As Exception
                arrRateDetails = Nothing
            End Try
            db.CloseDB()
            Return arrRateDetails
        End Function
    End Class
End Namespace
