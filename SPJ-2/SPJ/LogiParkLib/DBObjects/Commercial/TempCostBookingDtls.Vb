Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TempCostBookingDtls
    ''' @author	: Amit K. Singh- 17/9/2019
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TempCostBookingDtls 
    
        Private lngCostId As Long ' Define Private Variable CostId With DataType As Long 
        Private lngCostDtlsId As Long ' Define Private Variable CostDtlsId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private dblQnty As Double ' Define Private Variable Qnty With DataType As Long 
        Private dblRate As Double ' Define Private Variable Rate With DataType As Long 
        Private dblExRate As Double ' Define Private Variable ExRate With DataType As Long 
        Private dblBaseRate As Double ' Define Private Variable BaseRate With DataType As Long 
        Private lngTaxPerc As Long ' Define Private Variable TaxPerc With DataType As Long 
        Private dblTaxAmt As Double ' Define Private Variable TaxAmt With DataType As Long 
        Private dblTotal As Double ' Define Private Variable Total With DataType As Long 
        Private lngCgstRate As Long ' Define Private Variable CgstRate With DataType As Long 
        Private lngSgstRate As Long ' Define Private Variable SgstRate With DataType As Long 
        Private lngIgstRate As Long ' Define Private Variable IgstRate With DataType As Long 
        Private dblCgstAmount As Double ' Define Private Variable CgstAmount With DataType As Long 
        Private dblSgstAmount As Double ' Define Private Variable SgstAmount With DataType As Long 
        Private dblIgstAmount As Double ' Define Private Variable IgstAmount With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private LngMtyContId As Double
        Private dblTDSAmount As Double
        Private strContNO As String
        Private lngKeyId As Long
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of CostId
        ''' </summary>
        ''' <value>lngCostId</value>
        ''' <returns> Return lngCostId</returns>
        ''' <remarks> Get or Set the Value of CostId  </remarks>
        '''
        Public Property CostId() as Long
            Get
                Return lngCostId
            End Get
            Set(ByVal value As Long)
                lngCostId = value
            End Set
        End Property
        Public Property KeyId() As Long
            Get
                Return lngKeyId
            End Get
            Set(ByVal value As Long)
                lngKeyId = value
            End Set
        End Property
        Public Property ContNO() As String
            Get
                Return strContNO
            End Get
            Set(ByVal value As String)
                strContNO = value
            End Set
        End Property
        Public Property MtyContId() As Long
            Get
                Return LngMtyContId
            End Get
            Set(ByVal value As Long)
                LngMtyContId = value
            End Set
        End Property
        Public Property TDSAmount() As Double
            Get
                Return dblTDSAmount
            End Get
            Set(ByVal value As Double)
                dblTDSAmount = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of CostDtlsId
        ''' </summary>
        ''' <value>lngCostDtlsId</value>
        ''' <returns> Return lngCostDtlsId</returns>
        ''' <remarks> Get or Set the Value of CostDtlsId  </remarks>
        '''
        Public Property CostDtlsId() as Long
            Get
                Return lngCostDtlsId
            End Get
            Set(ByVal value As Long)
                lngCostDtlsId = value
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
        ''' Get or Set the Value of Qnty
        ''' </summary>
        ''' <value>lngQnty</value>
        ''' <returns> Return lngQnty</returns>
        ''' <remarks> Get or Set the Value of Qnty  </remarks>
        '''
        Public Property Qnty() As Double
            Get
                Return dblQnty
            End Get
            Set(ByVal value As Double)
                dblQnty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Rate
        ''' </summary>
        ''' <value>lngRate</value>
        ''' <returns> Return lngRate</returns>
        ''' <remarks> Get or Set the Value of Rate  </remarks>
        '''
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal value As Double)
                dblRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ExRate
        ''' </summary>
        ''' <value>lngExRate</value>
        ''' <returns> Return lngExRate</returns>
        ''' <remarks> Get or Set the Value of ExRate  </remarks>
        '''
        Public Property ExRate() As Double
            Get
                Return dblExRate
            End Get
            Set(ByVal value As Double)
                dblExRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BaseRate
        ''' </summary>
        ''' <value>lngBaseRate</value>
        ''' <returns> Return lngBaseRate</returns>
        ''' <remarks> Get or Set the Value of BaseRate  </remarks>
        '''
        Public Property BaseRate() As Double
            Get
                Return dblBaseRate
            End Get
            Set(ByVal value As Double)
                dblBaseRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TaxPerc
        ''' </summary>
        ''' <value>lngTaxPerc</value>
        ''' <returns> Return lngTaxPerc</returns>
        ''' <remarks> Get or Set the Value of TaxPerc  </remarks>
        '''
        Public Property TaxPerc() as Long
            Get
                Return lngTaxPerc
            End Get
            Set(ByVal value As Long)
                lngTaxPerc = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TaxAmt
        ''' </summary>
        ''' <value>lngTaxAmt</value>
        ''' <returns> Return lngTaxAmt</returns>
        ''' <remarks> Get or Set the Value of TaxAmt  </remarks>
        '''
        Public Property TaxAmt() As Double
            Get
                Return dblTaxAmt
            End Get
            Set(ByVal value As Double)
                dblTaxAmt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Total
        ''' </summary>
        ''' <value>lngTotal</value>
        ''' <returns> Return lngTotal</returns>
        ''' <remarks> Get or Set the Value of Total  </remarks>
        '''
        Public Property Total() As Double
            Get
                Return dblTotal
            End Get
            Set(ByVal value As Double)
                dblTotal = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CgstRate
        ''' </summary>
        ''' <value>lngCgstRate</value>
        ''' <returns> Return lngCgstRate</returns>
        ''' <remarks> Get or Set the Value of CgstRate  </remarks>
        '''
        Public Property CgstRate() as Long
            Get
                Return lngCgstRate
            End Get
            Set(ByVal value As Long)
                lngCgstRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SgstRate
        ''' </summary>
        ''' <value>lngSgstRate</value>
        ''' <returns> Return lngSgstRate</returns>
        ''' <remarks> Get or Set the Value of SgstRate  </remarks>
        '''
        Public Property SgstRate() as Long
            Get
                Return lngSgstRate
            End Get
            Set(ByVal value As Long)
                lngSgstRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgstRate
        ''' </summary>
        ''' <value>lngIgstRate</value>
        ''' <returns> Return lngIgstRate</returns>
        ''' <remarks> Get or Set the Value of IgstRate  </remarks>
        '''
        Public Property IgstRate() as Long
            Get
                Return lngIgstRate
            End Get
            Set(ByVal value As Long)
                lngIgstRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CgstAmount
        ''' </summary>
        ''' <value>lngCgstAmount</value>
        ''' <returns> Return lngCgstAmount</returns>
        ''' <remarks> Get or Set the Value of CgstAmount  </remarks>
        '''
        Public Property CgstAmount() As Double
            Get
                Return dblCgstAmount
            End Get
            Set(ByVal value As Double)
                dblCgstAmount = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SgstAmount
        ''' </summary>
        ''' <value>lngSgstAmount</value>
        ''' <returns> Return lngSgstAmount</returns>
        ''' <remarks> Get or Set the Value of SgstAmount  </remarks>
        '''
        Public Property SgstAmount() As Double
            Get
                Return dblSgstAmount
            End Get
            Set(ByVal value As Double)
                dblSgstAmount = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgstAmount
        ''' </summary>
        ''' <value>lngIgstAmount</value>
        ''' <returns> Return lngIgstAmount</returns>
        ''' <remarks> Get or Set the Value of IgstAmount  </remarks>
        '''
        Public Property IgstAmount() As Double
            Get
                Return dblIgstAmount
            End Get
            Set(ByVal value As Double)
                dblIgstAmount = value
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
            lngCostId = 0 
            lngCostDtlsId = 0 
            lngServiceId = 0 
            dblQnty = 0
            dblRate = 0
            dblExRate = 0
            dblBaseRate = 0
            lngTaxPerc = 0 
            dblTaxAmt = 0
            dblTotal = 0
            lngCgstRate = 0 
            lngSgstRate = 0 
            lngIgstRate = 0 
            dblCgstAmount = 0
            dblSgstAmount = 0
            dblIgstAmount = 0
            strCreatedBy = ""
            strCreatedOn = ""
            LngMtyContId = 0
            dblTDSAmount = 0
            strContNO = ""
            strErrormsg = ""
            lngKeyId = 0
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTempCostBookingDtls"></param>
        ''' <returns>Return pTempCostBookingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBookingDtls.CostId)
                db.AddParameter("p_COST_DTLS_ID", pTempCostBookingDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pTempCostBookingDtls.ServiceId)
                db.AddParameter("p_QNTY", pTempCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pTempCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pTempCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pTempCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pTempCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pTempCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pTempCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pTempCostBookingDtls.CgstRate)
                db.AddParameter("p_SGST_RATE", pTempCostBookingDtls.SgstRate)
                db.AddParameter("p_IGST_RATE", pTempCostBookingDtls.IgstRate)
                db.AddParameter("p_CGST_AMOUNT", pTempCostBookingDtls.CgstAmount)
                db.AddParameter("p_SGST_AMOUNT", pTempCostBookingDtls.SgstAmount)
                db.AddParameter("p_IGST_AMOUNT", pTempCostBookingDtls.IgstAmount)
                db.AddParameter("p_CREATED_BY", pTempCostBookingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBookingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempCostBookingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBookingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pTempCostBookingDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempCostBookingDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempCostBookingDtls"></param>
        ''' <returns>Return pTempCostBookingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBookingDtls.CostId)
                db.AddParameter("p_COST_DTLS_ID", pTempCostBookingDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pTempCostBookingDtls.ServiceId)
                db.AddParameter("p_QNTY", pTempCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pTempCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pTempCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pTempCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pTempCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pTempCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pTempCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pTempCostBookingDtls.CgstRate)
                db.AddParameter("p_SGST_RATE", pTempCostBookingDtls.SgstRate)
                db.AddParameter("p_IGST_RATE", pTempCostBookingDtls.IgstRate)
                db.AddParameter("p_CGST_AMOUNT", pTempCostBookingDtls.CgstAmount)
                db.AddParameter("p_SGST_AMOUNT", pTempCostBookingDtls.SgstAmount)
                db.AddParameter("p_IGST_AMOUNT", pTempCostBookingDtls.IgstAmount)
                db.AddParameter("p_CREATED_BY", pTempCostBookingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBookingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempCostBookingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBookingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pTempCostBookingDtls.ErrorMsg = ex.Message
            End Try
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTempCostBookingDtls"></param>
        ''' <returns>Return pTempCostBookingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBookingDtls.CostId)
                db.AddParameter("p_COST_DTLS_ID", pTempCostBookingDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pTempCostBookingDtls.ServiceId)
                db.AddParameter("p_QNTY", pTempCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pTempCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pTempCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pTempCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pTempCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pTempCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pTempCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pTempCostBookingDtls.CgstRate)
                db.AddParameter("p_SGST_RATE", pTempCostBookingDtls.SgstRate)
                db.AddParameter("p_IGST_RATE", pTempCostBookingDtls.IgstRate)
                db.AddParameter("p_CGST_AMOUNT", pTempCostBookingDtls.CgstAmount)
                db.AddParameter("p_SGST_AMOUNT", pTempCostBookingDtls.SgstAmount)
                db.AddParameter("p_IGST_AMOUNT", pTempCostBookingDtls.IgstAmount)
                db.AddParameter("p_CREATED_BY", pTempCostBookingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBookingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempCostBookingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBookingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTempCostBookingDtls.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempCostBookingDtls.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempCostBookingDtls"></param>
        ''' <returns>Return pTempCostBookingDtls Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBookingDtls.CostId)
                db.AddParameter("p_COST_DTLS_ID", pTempCostBookingDtls.CostDtlsId)
                db.AddParameter("p_SERVICE_ID", pTempCostBookingDtls.ServiceId)
                db.AddParameter("p_QNTY", pTempCostBookingDtls.Qnty)
                db.AddParameter("p_RATE", pTempCostBookingDtls.Rate)
                db.AddParameter("p_EX_RATE", pTempCostBookingDtls.ExRate)
                db.AddParameter("p_BASE_RATE", pTempCostBookingDtls.BaseRate)
                db.AddParameter("p_TAX_PERC", pTempCostBookingDtls.TaxPerc)
                db.AddParameter("p_TAX_AMT", pTempCostBookingDtls.TaxAmt)
                db.AddParameter("p_TOTAL", pTempCostBookingDtls.Total)
                db.AddParameter("p_CGST_RATE", pTempCostBookingDtls.CgstRate)
                db.AddParameter("p_SGST_RATE", pTempCostBookingDtls.SgstRate)
                db.AddParameter("p_IGST_RATE", pTempCostBookingDtls.IgstRate)
                db.AddParameter("p_CGST_AMOUNT", pTempCostBookingDtls.CgstAmount)
                db.AddParameter("p_SGST_AMOUNT", pTempCostBookingDtls.SgstAmount)
                db.AddParameter("p_IGST_AMOUNT", pTempCostBookingDtls.IgstAmount)
                db.AddParameter("p_CREATED_BY", pTempCostBookingDtls.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBookingDtls.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTempCostBookingDtls.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_COST_BOOKING_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBookingDtls.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTempCostBookingDtls.ErrorMsg = ex.Message
                End Try
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                PTempCostBookingDtls.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                PTempCostBookingDtls.CostDtlsId = dbr("COST_DTLS_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PTempCostBookingDtls.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                PTempCostBookingDtls.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PTempCostBookingDtls.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                PTempCostBookingDtls.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BASE_RATE").ToString <> "" Then
                                PTempCostBookingDtls.BaseRate = dbr("BASE_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                PTempCostBookingDtls.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                PTempCostBookingDtls.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                PTempCostBookingDtls.Total = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                PTempCostBookingDtls.CgstRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                PTempCostBookingDtls.SgstRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                PTempCostBookingDtls.IgstRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                PTempCostBookingDtls.CgstAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                PTempCostBookingDtls.SgstAmount = dbr("SGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_AMOUNT").ToString <> "" Then
                                PTempCostBookingDtls.IgstAmount = dbr("IGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTempCostBookingDtls.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTempCostBookingDtls.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pTempCostBookingDtls.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_AMOUNT").ToString <> "" Then
                                pTempCostBookingDtls.TDSAmount = dbr("TDS_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pTempCostBookingDtls.ContNO = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                pTempCostBookingDtls.KeyId = dbr("KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTempCostBookingDtls.ErrorMsg = ex.Message
            End Try
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTempCostBookingDtls As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TempCostBookingDtls
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                temp.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COST_DTLS_ID").ToString <> "" Then
                                temp.CostDtlsId = dbr("COST_DTLS_ID")
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
                            If dbr("QNTY").ToString <> "" Then
                                temp.Qnty = dbr("QNTY")
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
                            If dbr("EX_RATE").ToString <> "" Then
                                temp.ExRate = dbr("EX_RATE")
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
                            If dbr("TAX_PERC").ToString <> "" Then
                                temp.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                temp.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                temp.Total = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                temp.CgstRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                temp.SgstRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                temp.IgstRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                temp.CgstAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                temp.SgstAmount = dbr("SGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_AMOUNT").ToString <> "" Then
                                temp.IgstAmount = dbr("IGST_AMOUNT")
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
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_AMOUNT").ToString <> "" Then
                                temp.TDSAmount = dbr("TDS_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                temp.ContNO = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KEY_ID").ToString <> "" Then
                                temp.KeyId = dbr("KEY_ID")
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
        Public Shared Function ReturnTempCostBookingDtls(ByVal pTempCostBookingDtls As TempCostBookingDtls) As TempCostBookingDtls
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_COST_BOOKING_DTLS", "' '")
                pTempCostBookingDtls = ReturnObjectValues(dbr, pTempCostBookingDtls)
                dbr.Close()
            Catch ex As Exception
                pTempCostBookingDtls.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTempCostBookingDtls
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTempCostBookingDtlsList (ByVal pTempCostBookingDtls As TempCostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempCostBookingDtls As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_COST_BOOKING_DTLS", "' '")
                arrTempCostBookingDtls = ReturnObjectValuesList(dbr, arrTempCostBookingDtls)
                dbr.Close()
            Catch ex As Exception
                arrTempCostBookingDtls = Nothing
            End Try
            db.CloseDB()
            Return arrTempCostBookingDtls
        End Function
        Public Shared Function ReturnTempcostDtlsListBuInvoiceNo(ByVal pTempCostBookingDtls As TempCostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TMP_COST_DTLS_ALL_BY_ID", pTempCostBookingDtls.CostId)
                arrTempImpInvoiceItems = ReturnObjectValuesList(dbr, arrTempImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrTempImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrTempImpInvoiceItems
        End Function

        Public Shared Function ReturnMaincostDtlsListByInvoiceNo(ByVal pTempCostBookingDtls As TempCostBookingDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIN_COST_DTLS_ALL_BY_INV", pTempCostBookingDtls.CostId & ",'" & pTempCostBookingDtls.CreatedBy & "'")
                arrTempImpInvoiceItems = ReturnObjectValuesList(dbr, arrTempImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrTempImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrTempImpInvoiceItems
        End Function
    End Class
End Namespace
