Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class QuatationDtls
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngValidityId As Long ' Define Private Variable ValidityId With DataType As Long 
        Private lngRateId As Long ' Define Private Variable RateId With DataType As Long 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strCargoType As String ' Define Private Variable CargoType With DataType As String 
        Private lngCommodityId As Long ' Define Private Variable CommodityId With DataType As Long 
        Private lngPol As Long ' Define Private Variable Pol With DataType As Long 
        Private lngFromRang As Long ' Define Private Variable FromRang With DataType As Long 
        Private lngToRang As Long ' Define Private Variable ToRang With DataType As Long 
        Private lngRate As Long ' Define Private Variable Rate With DataType As Long 
        Private lngRateKeyId As Long ' Define Private Variable RateKeyId With DataType As Long 
        Private strDiscountType As String
        Private dblDiscount As Long
        Private dblBaseRate As Long
        Private strHandlingMode As String
        Private strNowDate As String
        Private dblSurCharge As Double
        Private strContStatus As String
        Private strDocType As String
        Private lngLineId As Long
        Private lngPortId As Long
        Private strCurrency As String
        Private lngBrokerId As Long
        Private lngServiceId As Long
        Private strErrormsg As String
        Private strCreatedBy As String
        Private strCreatedOn As String
        ' Define Private Variable Errormsg With DataType As String 

        Public Property HandlingMode() As String
            Get
                Return strHandlingMode
            End Get
            Set(ByVal value As String)
                strHandlingMode = value
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
        ''' Get or Set the Value of PortId
        ''' </summary>
        ''' <value>lngPortId</value>
        ''' <returns> Return lngPortId</returns>
        ''' <remarks> Get or Set the Value of PortId  </remarks>
        '''
        Public Property PortId() As Long
            Get
                Return lngPortId
            End Get
            Set(ByVal value As Long)
                lngPortId = value
            End Set
        End Property

        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property

        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property

        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of BrokerId
        ''' </summary>
        ''' <value>lngBrokerId</value>
        ''' <returns> Return lngBrokerId</returns>
        ''' <remarks> Get or Set the Value of BrokerId  </remarks>
        '''
        Public Property BrokerId() As Long
            Get
                Return lngBrokerId
            End Get
            Set(ByVal value As Long)
                lngBrokerId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ValidityId
        ''' </summary>
        ''' <value>lngValidityId</value>
        ''' <returns> Return lngValidityId</returns>
        ''' <remarks> Get or Set the Value of ValidityId  </remarks>
        '''
        Public Property ValidityId() As Long
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
        Public Property RateId() As Long
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
        ''' Get or Set the Value of CargoType
        ''' </summary>
        ''' <value>strCargoType</value>
        ''' <returns> Return strCargoType</returns>
        ''' <remarks> Get or Set the Value of CargoType  </remarks>
        '''
        Public Property CargoType() As String
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
        Public Property CommodityId() As Long
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
        ''' <value>lngPol</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property Pol() As Long
            Get
                Return lngPol
            End Get
            Set(ByVal value As Long)
                lngPol = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of FromRang
        ''' </summary>
        ''' <value>lngFromRang</value>
        ''' <returns> Return lngFromRang</returns>
        ''' <remarks> Get or Set the Value of FromRang  </remarks>
        '''
        Public Property FromRang() As Long
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
        Public Property ToRang() As Long
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
        Public Property Rate() As Long
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
        Public Property RateKeyId() As Long
            Get
                Return lngRateKeyId
            End Get
            Set(ByVal value As Long)
                lngRateKeyId = value
            End Set
        End Property

        Public Property DiscountType() As String
            Get
                Return strDiscountType
            End Get
            Set(ByVal value As String)
                strDiscountType = value
            End Set
        End Property
        Public Property Discount() As Long
            Get
                Return dblDiscount
            End Get
            Set(ByVal value As Long)
                dblDiscount = value
            End Set
        End Property
        Public Property BaseRate() As Long
            Get
                Return dblBaseRate
            End Get
            Set(ByVal value As Long)
                dblBaseRate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property ContStatus() As String
            Get
                Return strContStatus
            End Get
            Set(ByVal value As String)
                strContStatus = value
            End Set
        End Property
        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
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


        Public Property NowDate() As String
            Get
                Return strNowDate
            End Get
            Set(ByVal value As String)
                strNowDate = value
            End Set
        End Property
        Public Property SurCharge() As Double
            Get
                Return dblSurCharge
            End Get
            Set(ByVal value As Double)
                dblSurCharge = value
            End Set
        End Property
        Public Property ServiceId() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
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
            lngPol = 0
            lngFromRang = 0
            lngToRang = 0
            lngRate = 0
            lngRateKeyId = 0
            strErrormsg = ""
            strDiscountType = ""
            dblDiscount = 0
            dblBaseRate = 0
            strHandlingMode = ""
            strContStatus = ""
            strDocType = ""
            dblSurCharge = 0
            lngLineId = 0
            lngPortId = 0
            strCurrency = ""
            lngBrokerId = 0
            lngServiceId = 0
            strCreatedBy = ""
            strCreatedOn = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pQuatationDtls"></param>
        ''' <returns>Return pQuatationDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatationDtls.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pQuatationDtls.ValidityId)
                db.AddParameter("p_RATE_ID", pQuatationDtls.RateId)
                db.AddParameter("p_CONT_SIZE", pQuatationDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pQuatationDtls.ContType)
                db.AddParameter("p_CARGO_TYPE", pQuatationDtls.CargoType)
                db.AddParameter("p_COMMODITY_ID", pQuatationDtls.CommodityId)
                db.AddParameter("p_POL", pQuatationDtls.Pol)
                db.AddParameter("p_FROM_RANG", pQuatationDtls.FromRang)
                db.AddParameter("p_TO_RANG", pQuatationDtls.ToRang)
                db.AddParameter("p_RATE", pQuatationDtls.Rate)
                db.AddParameter("p_RATE_KEY_ID", pQuatationDtls.RateKeyId, ParameterDirection.Output)
                db.AddParameter("p_DISCOUNT_TYPE", pQuatationDtls.DiscountType)
                db.AddParameter("p_DISCOUNT", pQuatationDtls.Discount)
                db.AddParameter("p_BASE_RATE", pQuatationDtls.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pQuatationDtls.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pQuatationDtls.SurCharge)
                db.AddParameter("p_CONT_STATUS", pQuatationDtls.ContStatus)
                db.AddParameter("p_DOC_TYPE", pQuatationDtls.DocType)
                db.AddParameter("p_LINE_ID", pQuatationDtls.LineId)
                db.AddParameter("p_PORT_ID", pQuatationDtls.PortId)
                db.AddParameter("p_CURRENCY", pQuatationDtls.Currency)
                db.AddParameter("p_SERVICE_ID", pQuatationDtls.ServiceId)
                db.AddParameter("p_ErrorMsg", pQuatationDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUATATION_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatationDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pQuatationDtls.RateKeyId = db.Parameters.Item("p_RATE_KEY_ID").value

                If pQuatationDtls.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pQuatationDtls"></param>
        ''' <returns>Return pQuatationDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatationDtls.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pQuatationDtls.ValidityId)
                db.AddParameter("p_RATE_ID", pQuatationDtls.RateId)
                db.AddParameter("p_CONT_SIZE", pQuatationDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pQuatationDtls.ContType)
                db.AddParameter("p_CARGO_TYPE", pQuatationDtls.CargoType)
                db.AddParameter("p_COMMODITY_ID", pQuatationDtls.CommodityId)
                db.AddParameter("p_POL", pQuatationDtls.Pol)
                db.AddParameter("p_FROM_RANG", pQuatationDtls.FromRang)
                db.AddParameter("p_TO_RANG", pQuatationDtls.ToRang)
                db.AddParameter("p_RATE", pQuatationDtls.Rate)
                db.AddParameter("p_RATE_KEY_ID", pQuatationDtls.RateKeyId, ParameterDirection.Output)
                db.AddParameter("p_DISCOUNT_TYPE", pQuatationDtls.DiscountType)
                db.AddParameter("p_DISCOUNT", pQuatationDtls.Discount)
                db.AddParameter("p_BASE_RATE", pQuatationDtls.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pQuatationDtls.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pQuatationDtls.SurCharge)
                db.AddParameter("p_CONT_STATUS", pQuatationDtls.ContStatus)
                db.AddParameter("p_DOC_TYPE", pQuatationDtls.DocType)
                db.AddParameter("p_LINE_ID", pQuatationDtls.LineId)
                db.AddParameter("p_PORT_ID", pQuatationDtls.PortId)
                db.AddParameter("p_CURRENCY", pQuatationDtls.Currency)
                db.AddParameter("p_SERVICE_ID", pQuatationDtls.ServiceId)
                db.AddParameter("p_ErrorMsg", pQuatationDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_QUATATION_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatationDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pQuatationDtls.RateKeyId = db.Parameters.Item("p_RATE_KEY_ID").value

            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
            End Try
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pQuatationDtls"></param>
        ''' <returns>Return pQuatationDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatationDtls.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pQuatationDtls.ValidityId)
                db.AddParameter("p_RATE_ID", pQuatationDtls.RateId)
                db.AddParameter("p_CONT_SIZE", pQuatationDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pQuatationDtls.ContType)
                db.AddParameter("p_CARGO_TYPE", pQuatationDtls.CargoType)
                db.AddParameter("p_COMMODITY_ID", pQuatationDtls.CommodityId)
                db.AddParameter("p_POL", pQuatationDtls.Pol)
                db.AddParameter("p_FROM_RANG", pQuatationDtls.FromRang)
                db.AddParameter("p_TO_RANG", pQuatationDtls.ToRang)
                db.AddParameter("p_RATE", pQuatationDtls.Rate)
                db.AddParameter("p_RATE_KEY_ID", pQuatationDtls.RateKeyId)
                db.AddParameter("p_DISCOUNT_TYPE", pQuatationDtls.DiscountType)
                db.AddParameter("p_DISCOUNT", pQuatationDtls.Discount)
                db.AddParameter("p_BASE_RATE", pQuatationDtls.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pQuatationDtls.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pQuatationDtls.SurCharge)
                db.AddParameter("p_CONT_STATUS", pQuatationDtls.ContStatus)
                db.AddParameter("p_DOC_TYPE", pQuatationDtls.DocType)
                db.AddParameter("p_LINE_ID", pQuatationDtls.LineId)
                db.AddParameter("p_PORT_ID", pQuatationDtls.PortId)
                db.AddParameter("p_CURRENCY", pQuatationDtls.Currency)
                db.AddParameter("p_SERVICE_ID", pQuatationDtls.ServiceId)
                db.AddParameter("p_ErrorMsg", pQuatationDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUATATION_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatationDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pQuatationDtls.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pQuatationDtls"></param>
        ''' <returns>Return pQuatationDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pQuatationDtls.TerminalId)
                db.AddParameter("p_VALIDITY_ID", pQuatationDtls.ValidityId)
                db.AddParameter("p_RATE_ID", pQuatationDtls.RateId)
                db.AddParameter("p_CONT_SIZE", pQuatationDtls.ContSize)
                db.AddParameter("p_CONT_TYPE", pQuatationDtls.ContType)
                db.AddParameter("p_CARGO_TYPE", pQuatationDtls.CargoType)
                db.AddParameter("p_COMMODITY_ID", pQuatationDtls.CommodityId)
                db.AddParameter("p_POL", pQuatationDtls.Pol)
                db.AddParameter("p_FROM_RANG", pQuatationDtls.FromRang)
                db.AddParameter("p_TO_RANG", pQuatationDtls.ToRang)
                db.AddParameter("p_RATE", pQuatationDtls.Rate)
                db.AddParameter("p_RATE_KEY_ID", pQuatationDtls.RateKeyId)
                db.AddParameter("p_DISCOUNT_TYPE", pQuatationDtls.DiscountType)
                db.AddParameter("p_DISCOUNT", pQuatationDtls.Discount)
                db.AddParameter("p_BASE_RATE", pQuatationDtls.BaseRate)
                db.AddParameter("p_HANDLING_MODE", pQuatationDtls.HandlingMode)
                db.AddParameter("p_SUR_CHARGE", pQuatationDtls.SurCharge)
                db.AddParameter("p_CONT_STATUS", pQuatationDtls.ContStatus)
                db.AddParameter("p_DOC_TYPE", pQuatationDtls.DocType)
                db.AddParameter("p_LINE_ID", pQuatationDtls.LineId)
                db.AddParameter("p_PORT_ID", pQuatationDtls.PortId)
                db.AddParameter("p_CURRENCY", pQuatationDtls.Currency)
                db.AddParameter("p_SERVICE_ID", pQuatationDtls.ServiceId)
                db.AddParameter("p_ErrorMsg", pQuatationDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_QUATATION_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatationDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
            End Try
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PQuatationDtls.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALIDITY_ID").ToString <> "" Then
                                PQuatationDtls.ValidityId = dbr("VALIDITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_ID").ToString <> "" Then
                                PQuatationDtls.RateId = dbr("RATE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PQuatationDtls.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PQuatationDtls.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_TYPE").ToString <> "" Then
                                PQuatationDtls.CargoType = dbr("CARGO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PQuatationDtls.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                pQuatationDtls.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_RANG").ToString <> "" Then
                                PQuatationDtls.FromRang = dbr("FROM_RANG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANG").ToString <> "" Then
                                PQuatationDtls.ToRang = dbr("TO_RANG")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PQuatationDtls.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE_KEY_ID").ToString <> "" Then
                                PQuatationDtls.RateKeyId = dbr("RATE_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT_TYPE").ToString <> "" Then
                                pQuatationDtls.DiscountType = dbr("DISCOUNT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISCOUNT").ToString <> "" Then
                                pQuatationDtls.Discount = dbr("DISCOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                pQuatationDtls.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HANDLING_MODE").ToString <> "" Then
                                pQuatationDtls.HandlingMode = dbr("HANDLING_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SUR_CHARGE").ToString <> "" Then
                                pQuatationDtls.SurCharge = dbr("SUR_CHARGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_STATUS").ToString <> "" Then
                                pQuatationDtls.ContStatus = dbr("CONT_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                pQuatationDtls.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pQuatationDtls.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                pQuatationDtls.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                pQuatationDtls.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BROKER_ID").ToString <> "" Then
                                pQuatationDtls.BrokerId = dbr("BROKER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pQuatationDtls.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
            End Try
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrQuatationDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New QuatationDtls
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
                            If dbr("POL").ToString <> "" Then
                                temp.Pol = dbr("POL")
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
                            If dbr("BROKER_ID").ToString <> "" Then
                                temp.BrokerId = dbr("BROKER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
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
        Public Shared Function ReturnQuatationDtls(ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_Q_DETAILS", "' '")
                pQuatationDtls = ReturnObjectValues(dbr, pQuatationDtls)
                dbr.Close()
            Catch ex As Exception
                pQuatationDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pQuatationDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, RateId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnQuatationDtlsListByRateId(ByVal pQuatationDtls As QuatationDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrQuatationDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_Q_DETAILS_ALL_BY_RATE_ID", pQuatationDtls.TerminalId & "," & pQuatationDtls.RateId)
                arrQuatationDtls = ReturnObjectValuesList(dbr, arrQuatationDtls)
                dbr.Close()
            Catch ex As Exception
                arrQuatationDtls = Nothing
            End Try
            db.CloseDB()
            Return arrQuatationDtls
        End Function

        Public Shared Function ReturnRateMasterByRateCheckListWithCurrentDate(ByVal pQuatationDtls As QuatationDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrQuatationDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_Q_MASTER_FOR_RATE_CHECK", pQuatationDtls.TerminalId & ",'" & pQuatationDtls.NowDate & "','" & pQuatationDtls.ContSize & "','" & pQuatationDtls.ContType & "','" & pQuatationDtls.CargoType & "'," & pQuatationDtls.CommodityId & ",'" & pQuatationDtls.HandlingMode & "'")
                arrQuatationDtls = ReturnObjectValuesList(dbr, arrQuatationDtls)
                dbr.Close()
            Catch ex As Exception
                arrQuatationDtls = Nothing
            End Try
            db.CloseDB()
            Return arrQuatationDtls
        End Function

        Public Shared Function UploadQuatationDtls(ByVal pQuatationDtls As QuatationDtls) As QuatationDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()

                db.AddParameter("p_FILE_ID", pQuatationDtls.TerminalId)
                db.AddParameter("p_CREATED_BY", pQuatationDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pQuatationDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pQuatationDtls.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_QUOTATION_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pQuatationDtls.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString

                End If
                If pQuatationDtls.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pQuatationDtls.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pQuatationDtls
        End Function
    End Class
  
End Namespace
