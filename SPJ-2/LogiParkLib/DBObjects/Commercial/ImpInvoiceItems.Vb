Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ImpInvoiceItems
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ImpInvoiceItems 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
        Private strLineItem As String ' Define Private Variable LineItem With DataType As String 
        Private lngInvoiceNo As Long ' Define Private Variable InvoiceNo With DataType As Long 
        Private lngImpContId As Long ' Define Private Variable ImpContId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private dblBillQnty As Double ' Define Private Variable BillQnty With DataType As Double 
        Private dblBillRate As Double ' Define Private Variable BillRate With DataType As Double 
        Private dblBillAmount As Double ' Define Private Variable BillAmount With DataType As Double 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private dblTaxPerc As Double ' Define Private Variable TaxPerc With DataType As Double 
        Private dblWeiverReqAmt As Double ' Define Private Variable WeiverReqAmt With DataType As Double 
        Private dblWeiverAprAmt As Double ' Define Private Variable WeiverAprAmt With DataType As Double 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private lngCommodityId As Long ' Define Private Variable CommodityId With DataType As Long 
        Private strCurrency As String ' Define Private Variable Currency With DataType As String 
        Private dblExRate As Double ' Define Private Variable ExRate With DataType As Double 
        Private strCargoType As String ' Define Private Variable CargoType With DataType As String 
        Private strFromDate As String ' Define Private Variable FromDate With DataType As String 
        Private strToDate As String ' Define Private Variable ToDate With DataType As String 
        Private lngItemKeyId As Long ' Define Private Variable ItemKeyId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngVisitId As Long
        Private dblIGSTRate As Double ' Define Private Variable IGSTRate With DataType As Double 
        Private dblIGSTAmount As Double ' Define Private Variable IGSTAmount With DataType As Double 
        Private dblCGSTRate As Double ' Define Private Variable CGSTRate With DataType As Double 
        Private dblCGSTAmount As Double ' Define Private Variable CGSTAmount With DataType As Double 
        Private dblSGSTRate As Double ' Define Private Variable SGSTRate With DataType As Double 
        Private dblSGSTAmount As Double ' Define Private Variable SGSTAmount With DataType As Double 


                    
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
        ''' Get or Set the Value of LineItemId
        ''' </summary>
        ''' <value>lngLineItemId</value>
        ''' <returns> Return lngLineItemId</returns>
        ''' <remarks> Get or Set the Value of LineItemId  </remarks>
        '''
        Public Property LineItemId() as Long
            Get
                Return lngLineItemId
            End Get
            Set(ByVal value As Long)
                lngLineItemId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LineItem
        ''' </summary>
        ''' <value>strLineItem</value>
        ''' <returns> Return strLineItem</returns>
        ''' <remarks> Get or Set the Value of LineItem  </remarks>
        '''
        Public Property LineItem() as String
            Get
                Return strLineItem
            End Get
            Set(ByVal value As String)
                strLineItem = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of InvoiceNo
        ''' </summary>
        ''' <value>lngInvoiceNo</value>
        ''' <returns> Return lngInvoiceNo</returns>
        ''' <remarks> Get or Set the Value of InvoiceNo  </remarks>
        '''
        Public Property InvoiceNo() as Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ImpContId
        ''' </summary>
        ''' <value>lngImpContId</value>
        ''' <returns> Return lngImpContId</returns>
        ''' <remarks> Get or Set the Value of ImpContId  </remarks>
        '''
        Public Property ImpContId() as Long
            Get
                Return lngImpContId
            End Get
            Set(ByVal value As Long)
                lngImpContId = value
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
        ''' Get or Set the Value of BillQnty
        ''' </summary>
        ''' <value>dblBillQnty</value>
        ''' <returns> Return dblBillQnty</returns>
        ''' <remarks> Get or Set the Value of BillQnty  </remarks>
        '''
        Public Property BillQnty() as Double
            Get
                Return dblBillQnty
            End Get
            Set(ByVal value As Double)
                dblBillQnty = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BillRate
        ''' </summary>
        ''' <value>dblBillRate</value>
        ''' <returns> Return dblBillRate</returns>
        ''' <remarks> Get or Set the Value of BillRate  </remarks>
        '''
        Public Property BillRate() as Double
            Get
                Return dblBillRate
            End Get
            Set(ByVal value As Double)
                dblBillRate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BillAmount
        ''' </summary>
        ''' <value>dblBillAmount</value>
        ''' <returns> Return dblBillAmount</returns>
        ''' <remarks> Get or Set the Value of BillAmount  </remarks>
        '''
        Public Property BillAmount() as Double
            Get
                Return dblBillAmount
            End Get
            Set(ByVal value As Double)
                dblBillAmount = value
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
        ''' Get or Set the Value of TaxPerc
        ''' </summary>
        ''' <value>dblTaxPerc</value>
        ''' <returns> Return dblTaxPerc</returns>
        ''' <remarks> Get or Set the Value of TaxPerc  </remarks>
        '''
        Public Property TaxPerc() as Double
            Get
                Return dblTaxPerc
            End Get
            Set(ByVal value As Double)
                dblTaxPerc = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of WeiverReqAmt
        ''' </summary>
        ''' <value>dblWeiverReqAmt</value>
        ''' <returns> Return dblWeiverReqAmt</returns>
        ''' <remarks> Get or Set the Value of WeiverReqAmt  </remarks>
        '''
        Public Property WeiverReqAmt() as Double
            Get
                Return dblWeiverReqAmt
            End Get
            Set(ByVal value As Double)
                dblWeiverReqAmt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of WeiverAprAmt
        ''' </summary>
        ''' <value>dblWeiverAprAmt</value>
        ''' <returns> Return dblWeiverAprAmt</returns>
        ''' <remarks> Get or Set the Value of WeiverAprAmt  </remarks>
        '''
        Public Property WeiverAprAmt() as Double
            Get
                Return dblWeiverAprAmt
            End Get
            Set(ByVal value As Double)
                dblWeiverAprAmt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property ContNo() as String
            Get
                Return strContNo
            End Get
            Set(ByVal value As String)
                strContNo = value
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
        ''' Get or Set the Value of Currency
        ''' </summary>
        ''' <value>strCurrency</value>
        ''' <returns> Return strCurrency</returns>
        ''' <remarks> Get or Set the Value of Currency  </remarks>
        '''
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ExRate
        ''' </summary>
        ''' <value>dblExRate</value>
        ''' <returns> Return dblExRate</returns>
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
        ''' Get or Set the Value of ItemKeyId
        ''' </summary>
        ''' <value>lngItemKeyId</value>
        ''' <returns> Return lngItemKeyId</returns>
        ''' <remarks> Get or Set the Value of ItemKeyId  </remarks>
        '''
        Public Property ItemKeyId() as Long
            Get
                Return lngItemKeyId
            End Get
            Set(ByVal value As Long)
                lngItemKeyId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ItemKeyId
        ''' </summary>
        ''' <value>lngItemKeyId</value>
        ''' <returns> Return lngItemKeyId</returns>
        ''' <remarks> Get or Set the Value of ItemKeyId  </remarks>
        '''
        Public Property VisitId() As Long
            Get
                Return lngVisitId
            End Get
            Set(ByVal value As Long)
                lngVisitId = value
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
        ''' Get or Set the Value of IGSTRate
        ''' </summary>
        ''' <value>dblIGSTRate</value>
        ''' <returns> Return dblIGSTRate</returns>
        ''' <remarks> Get or Set the Value of IGSTRate  </remarks>
        '''
        Public Property IGSTRate() As Double
            Get
                Return dblIGSTRate
            End Get
            Set(ByVal value As Double)
                dblIGSTRate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of IGSTAmount
        ''' </summary>
        ''' <value>dblIGSTAmount</value>
        ''' <returns> Return dblIGSTAmount</returns>
        ''' <remarks> Get or Set the Value of IGSTAmount  </remarks>
        '''
        Public Property IGSTAmount() As Double
            Get
                Return dblIGSTAmount
            End Get
            Set(ByVal value As Double)
                dblIGSTAmount = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CGSTRate
        ''' </summary>
        ''' <value>dblCGSTRate</value>
        ''' <returns> Return dblCGSTRate</returns>
        ''' <remarks> Get or Set the Value of CGSTRate  </remarks>
        '''
        Public Property CGSTRate() As Double
            Get
                Return dblCGSTRate
            End Get
            Set(ByVal value As Double)
                dblCGSTRate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CGSTAmount
        ''' </summary>
        ''' <value>dblCGSTAmount</value>
        ''' <returns> Return dblCGSTAmount</returns>
        ''' <remarks> Get or Set the Value of CGSTAmount  </remarks>
        '''
        Public Property CGSTAmount() As Double
            Get
                Return dblCGSTAmount
            End Get
            Set(ByVal value As Double)
                dblCGSTAmount = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of SGSTRate
        ''' </summary>
        ''' <value>dblSGSTRate</value>
        ''' <returns> Return dblSGSTRate</returns>
        ''' <remarks> Get or Set the Value of SGSTRate  </remarks>
        '''
        Public Property SGSTRate() As Double
            Get
                Return dblSGSTRate
            End Get
            Set(ByVal value As Double)
                dblSGSTRate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of SGSTAmount
        ''' </summary>
        ''' <value>dblSGSTAmount</value>
        ''' <returns> Return dblSGSTAmount</returns>
        ''' <remarks> Get or Set the Value of SGSTAmount  </remarks>
        '''
        Public Property SGSTAmount() As Double
            Get
                Return dblSGSTAmount
            End Get
            Set(ByVal value As Double)
                dblSGSTAmount = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0 
            lngLineItemId = 0 
            strLineItem = ""
            lngInvoiceNo = 0 
            lngImpContId = 0 
            lngServiceId = 0 
            dblBillQnty = 0.0 
            dblBillRate = 0.0 
            dblBillAmount = 0.0 
            strContSize = ""
            dblTaxPerc = 0.0 
            dblWeiverReqAmt = 0.0 
            dblWeiverAprAmt = 0.0 
            strContNo = ""
            lngCommodityId = 0
            strCurrency = ""
            dblExRate = 0.0
            strCargoType = ""
            strFromDate = ""
            strToDate = ""
            lngItemKeyId = 0
            lngVisitId = 0
            strErrormsg = ""
            dblIGSTRate = 0.0
            dblIGSTAmount = 0.0
            dblCGSTRate = 0.0
            dblCGSTAmount = 0.0
            dblSGSTRate = 0.0
            dblSGSTAmount = 0.0
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_VISIT_ID", pImpInvoiceItems.VisitId)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoiceItems.ItemKeyId  = db.Parameters.Item("p_ITEM_KEY_ID").value
                
                If pImpInvoiceItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoiceItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_VISIT_ID", pImpInvoiceItems.VisitId)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoiceItems.ItemKeyId = db.Parameters.Item("p_ITEM_KEY_ID").value

            Catch ex As Exception
                pImpInvoiceItems.ErrorMsg = ex.Message
            End Try
            Return pImpInvoiceItems
        End Function
        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnRebate(ByVal db As DBConnect, ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_VISIT_ID", pImpInvoiceItems.VisitId)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_REBATE_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoiceItems.ItemKeyId = db.Parameters.Item("p_ITEM_KEY_ID").value

            Catch ex As Exception
                pImpInvoiceItems.Errormsg = ex.Message
            End Try
            Return pImpInvoiceItems
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE_ITEMS_WEAVER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pImpInvoiceItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpInvoiceItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_INVOICE_ITEMS_WEAVER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pImpInvoiceItems.Errormsg = ex.Message
            End Try
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PImpInvoiceItems.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                PImpInvoiceItems.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                PImpInvoiceItems.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PImpInvoiceItems.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                PImpInvoiceItems.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PImpInvoiceItems.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_QNTY").ToString <> "" Then
                                PImpInvoiceItems.BillQnty = dbr("BILL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_RATE").ToString <> "" Then
                                PImpInvoiceItems.BillRate = dbr("BILL_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                PImpInvoiceItems.BillAmount = dbr("BILL_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PImpInvoiceItems.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                PImpInvoiceItems.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_REQ_AMT").ToString <> "" Then
                                PImpInvoiceItems.WeiverReqAmt = dbr("WEIVER_REQ_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_APR_AMT").ToString <> "" Then
                                PImpInvoiceItems.WeiverAprAmt = dbr("WEIVER_APR_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PImpInvoiceItems.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PImpInvoiceItems.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                pImpInvoiceItems.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pImpInvoiceItems.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_TYPE").ToString <> "" Then
                                PImpInvoiceItems.CargoType = dbr("CARGO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                PImpInvoiceItems.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                PImpInvoiceItems.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_KEY_ID").ToString <> "" Then
                                PImpInvoiceItems.ItemKeyId = dbr("ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                pImpInvoiceItems.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                pImpInvoiceItems.IGSTRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_AMOUNT").ToString <> "" Then
                                pImpInvoiceItems.IGSTAmount = dbr("IGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                pImpInvoiceItems.CGSTRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                pImpInvoiceItems.CGSTAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                pImpInvoiceItems.SGSTRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                pImpInvoiceItems.SGSTAmount = dbr("SGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pImpInvoiceItems.ErrorMsg = ex.Message
            End Try
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrImpInvoiceItems As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ImpInvoiceItems
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                temp.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                temp.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                temp.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                temp.ImpContId = dbr("IMP_CONT_ID")
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
                            If dbr("BILL_QNTY").ToString <> "" Then
                                temp.BillQnty = dbr("BILL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_RATE").ToString <> "" Then
                                temp.BillRate = dbr("BILL_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                temp.BillAmount = dbr("BILL_AMOUNT")
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
                            If dbr("TAX_PERC").ToString <> "" Then
                                temp.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_REQ_AMT").ToString <> "" Then
                                temp.WeiverReqAmt = dbr("WEIVER_REQ_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_APR_AMT").ToString <> "" Then
                                temp.WeiverAprAmt = dbr("WEIVER_APR_AMT")
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
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                temp.CommodityId = dbr("COMMODITY_ID")
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
                            If dbr("EX_RATE").ToString <> "" Then
                                temp.ExRate = dbr("EX_RATE")
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
                            If dbr("ITEM_KEY_ID").ToString <> "" Then
                                temp.ItemKeyId = dbr("ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                temp.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_RATE").ToString <> "" Then
                                temp.IGSTRate = dbr("IGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_AMOUNT").ToString <> "" Then
                                temp.IGSTAmount = dbr("IGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_RATE").ToString <> "" Then
                                temp.CGSTRate = dbr("CGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_AMOUNT").ToString <> "" Then
                                temp.CGSTAmount = dbr("CGST_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_RATE").ToString <> "" Then
                                temp.SGSTRate = dbr("SGST_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_AMOUNT").ToString <> "" Then
                                temp.SGSTAmount = dbr("SGST_AMOUNT")
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
        Public Shared Function ReturnImpInvoiceItemsWaiver(ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ITEMS_WAIVER", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.InvoiceNo)
                pImpInvoiceItems = ReturnObjectValues(dbr, pImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                pImpInvoiceItems.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList TerminalId , InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceItemsListByInvoiceNo(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ITEMS_ALL_BY_NO", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.InvoiceNo)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function

        Public Shared Function ReturnImpInvoiceCheckDetails(ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_CHECK_DTLS", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.LineItemId & ",'" & pImpInvoiceItems.LineItem & "'," & pImpInvoiceItems.ImpContId & ",'" & pImpInvoiceItems.CargoType & "'")
                pImpInvoiceItems = ReturnObjectValues(dbr, pImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                pImpInvoiceItems.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList TerminalId , InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceItemsListByInvoiceNoPrint(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ITEMS_ALL_PRINT", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.InvoiceNo)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList TerminalId , InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceItemsListByInvoiceNoPrintnew(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ITEMS_PRINT", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.InvoiceNo)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList TerminalId , InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpInvoiceItemsListCreditItemKeyId(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_ITEMS_CREDIT", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.ItemKeyId & "," & pImpInvoiceItems.InvoiceNo)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function
        Public Shared Function ReturnImpInvoiceItemsListByTally(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_INVOICE_ITEMS_TALLY", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.InvoiceNo)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function
        Public Shared Function ReturnExpContainersListMiscInv(ByVal pImpInvoiceItems As ImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EXP_CONT_DTLS_MISC_INV", pImpInvoiceItems.TerminalId & "," & pImpInvoiceItems.LineItemId)
                arrImpInvoiceItems = ReturnObjectValuesList(dbr, arrImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrImpInvoiceItems
        End Function
        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpInvoiceItems"></param>
        ''' <returns>Return pImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnTemp(ByVal db As DBConnect, ByVal pImpInvoiceItems As ImpInvoiceItems) As ImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpInvoiceItems.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pImpInvoiceItems.ContNo)
                db.AddParameter("p_CURRENCY", pImpInvoiceItems.Currency)
                db.AddParameter("p_EX_RATE", pImpInvoiceItems.ExRate)
                db.AddParameter("p_COMMODITY_ID", pImpInvoiceItems.CommodityId)
                db.AddParameter("p_CARGO_TYPE", pImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pImpInvoiceItems.ItemKeyId, ParameterDirection.InputOutput)
                db.AddParameter("p_ErrorMsg", pImpInvoiceItems.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpInvoiceItems.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pImpInvoiceItems.ItemKeyId = db.Parameters.Item("p_ITEM_KEY_ID").value

            Catch ex As Exception
                pImpInvoiceItems.Errormsg = ex.Message
            End Try
            Return pImpInvoiceItems
        End Function

    End Class
End Namespace
