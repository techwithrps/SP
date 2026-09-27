Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CancelImpInvoiceItems
    ''' @author	: Santosh Singh- 23/11/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CancelImpInvoiceItems 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngClInvoiceId As Long ' Define Private Variable ClInvoiceId With DataType As Long 
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
        Private strCargoType As String ' Define Private Variable CargoType With DataType As String 
        Private strFromDate As String ' Define Private Variable FromDate With DataType As String 
        Private strToDate As String ' Define Private Variable ToDate With DataType As String 
        Private lngItemKeyId As Long ' Define Private Variable ItemKeyId With DataType As Long 
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
        ''' Get or Set the Value of ClInvoiceId
        ''' </summary>
        ''' <value>lngClInvoiceId</value>
        ''' <returns> Return lngClInvoiceId</returns>
        ''' <remarks> Get or Set the Value of ClInvoiceId  </remarks>
        '''
        Public Property ClInvoiceId() as Long
            Get
                Return lngClInvoiceId
            End Get
            Set(ByVal value As Long)
                lngClInvoiceId = value
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
            lngClInvoiceId = 0 
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
            strCargoType = ""
            strFromDate = ""
            strToDate = ""
            lngItemKeyId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoiceItems"></param>
        ''' <returns>Return pCancelImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceItems.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoiceItems.ClInvoiceId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pCancelImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pCancelImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pCancelImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pCancelImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pCancelImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pCancelImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pCancelImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pCancelImpInvoiceItems.CommodityId)
                db.AddParameter("p_CARGO_TYPE", pCancelImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pCancelImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pCancelImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pCancelImpInvoiceItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoiceItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoiceItems"></param>
        ''' <returns>Return pCancelImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceItems.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoiceItems.ClInvoiceId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pCancelImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pCancelImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pCancelImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pCancelImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pCancelImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pCancelImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pCancelImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pCancelImpInvoiceItems.CommodityId)
                db.AddParameter("p_CARGO_TYPE", pCancelImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pCancelImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pCancelImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pCancelImpInvoiceItems.ErrorMsg = ex.Message
            End Try
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoiceItems"></param>
        ''' <returns>Return pCancelImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceItems.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoiceItems.ClInvoiceId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pCancelImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pCancelImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pCancelImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pCancelImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pCancelImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pCancelImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pCancelImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pCancelImpInvoiceItems.CommodityId)
                db.AddParameter("p_CARGO_TYPE", pCancelImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pCancelImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pCancelImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCancelImpInvoiceItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoiceItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoiceItems"></param>
        ''' <returns>Return pCancelImpInvoiceItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceItems.TerminalId)
                db.AddParameter("p_CL_INVOICE_ID", pCancelImpInvoiceItems.ClInvoiceId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceItems.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceItems.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceItems.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceItems.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceItems.ServiceId)
                db.AddParameter("p_BILL_QNTY", pCancelImpInvoiceItems.BillQnty)
                db.AddParameter("p_BILL_RATE", pCancelImpInvoiceItems.BillRate)
                db.AddParameter("p_BILL_AMOUNT", pCancelImpInvoiceItems.BillAmount)
                db.AddParameter("p_CONT_SIZE", pCancelImpInvoiceItems.ContSize)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceItems.TaxPerc)
                db.AddParameter("p_WEIVER_REQ_AMT", pCancelImpInvoiceItems.WeiverReqAmt)
                db.AddParameter("p_WEIVER_APR_AMT", pCancelImpInvoiceItems.WeiverAprAmt)
                db.AddParameter("p_CONT_NO", pCancelImpInvoiceItems.ContNo)
                db.AddParameter("p_COMMODITY_ID", pCancelImpInvoiceItems.CommodityId)
                db.AddParameter("p_CARGO_TYPE", pCancelImpInvoiceItems.CargoType)
                db.AddParameter("p_FROM_DATE", pCancelImpInvoiceItems.FromDate)
                db.AddParameter("p_TO_DATE", pCancelImpInvoiceItems.ToDate)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceItems.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCancelImpInvoiceItems.ErrorMsg = ex.Message
                End Try
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.ClInvoiceId = dbr("CL_INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                PCancelImpInvoiceItems.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PCancelImpInvoiceItems.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_QNTY").ToString <> "" Then
                                PCancelImpInvoiceItems.BillQnty = dbr("BILL_QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_RATE").ToString <> "" Then
                                PCancelImpInvoiceItems.BillRate = dbr("BILL_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                PCancelImpInvoiceItems.BillAmount = dbr("BILL_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PCancelImpInvoiceItems.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                PCancelImpInvoiceItems.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_REQ_AMT").ToString <> "" Then
                                PCancelImpInvoiceItems.WeiverReqAmt = dbr("WEIVER_REQ_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIVER_APR_AMT").ToString <> "" Then
                                PCancelImpInvoiceItems.WeiverAprAmt = dbr("WEIVER_APR_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PCancelImpInvoiceItems.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_TYPE").ToString <> "" Then
                                PCancelImpInvoiceItems.CargoType = dbr("CARGO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                PCancelImpInvoiceItems.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                PCancelImpInvoiceItems.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_KEY_ID").ToString <> "" Then
                                PCancelImpInvoiceItems.ItemKeyId = dbr("ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCancelImpInvoiceItems.ErrorMsg = ex.Message
            End Try
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCancelImpInvoiceItems As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CancelImpInvoiceItems
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CL_INVOICE_ID").ToString <> "" Then
                                temp.ClInvoiceId = dbr("CL_INVOICE_ID")
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
        Public Shared Function ReturnCancelImpInvoiceItems(ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As CancelImpInvoiceItems
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CANCEL_IMP_INVOICE_ITEMS", "' '")
                pCancelImpInvoiceItems = ReturnObjectValues(dbr, pCancelImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                pCancelImpInvoiceItems.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceItems
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCancelImpInvoiceItemsListByClInvoiceId(ByVal pCancelImpInvoiceItems As CancelImpInvoiceItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCancelImpInvoiceItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CL_INVOICE_ITEMS_ALL_BY_ID", pCancelImpInvoiceItems.TerminalId & "," & pCancelImpInvoiceItems.ClInvoiceId)
                arrCancelImpInvoiceItems = ReturnObjectValuesList(dbr, arrCancelImpInvoiceItems)
                dbr.Close()
            Catch ex As Exception
                arrCancelImpInvoiceItems = Nothing
            End Try
            db.CloseDB()
            Return arrCancelImpInvoiceItems
        End Function
    End Class
End Namespace
