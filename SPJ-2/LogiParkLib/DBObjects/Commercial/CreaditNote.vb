Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ImpInvoice
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CreaditNote

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCrId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strCrDate As String  ' Define Private Variable LineItemId With DataType As Long 
        Private strCrRefNo As String ' Define Private Variable InvoiceRefNo With DataType As String
        Private lngInvoiceNo As Long
        Private lngInvoiceAmt As Long ' Define Private Variable ServiceType With DataType As String 
        Private lngCrAmt As Long
        Private lngCrTax As Long
        Private lngSer As Double
        Private lngKKC As Double
        Private lngsbc As Double
        Private strCrBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCrOn As String
        Private lngBillQnty As Long
        Private lngServiceId As Long
        Private strRemark As String
        Private lngCommodityId As Long
        Private lngIgstPer As Double
        Private lngCgstPer As Double
        Private lngsgstper As Double
        Private lngImpContId As Long
        Private lngBillRate As Double
        Private dblWeiverAprAmt As Double ' Define Private Variable WeiverAprAmt With DataType As Double 
        Private lngBillAmount As Double
        Private lngTaxPerc As Long
        Private arrCRNote As ArrayList
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        ''' <summary>
        ''' Get or Set the Value of TaxExemptionPerc
        ''' </summary>
        ''' <value>lngTaxExemptionPerc</value>
        ''' <returns> Return lngTaxExemptionPerc</returns>
        ''' <remarks> Get or Set the Value of TaxExemptionPerc</remarks>
        '''
        Public Property CRNoteList() As ArrayList
            Get
                Return arrCRNote
            End Get
            Set(ByVal value As ArrayList)
                arrCRNote = value
            End Set
        End Property
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

        Public Property CrId() As Long
            Get
                Return lngCrId
            End Get
            Set(ByVal value As Long)
                lngCrId = value
            End Set
        End Property
        Public Property CommodityId() As Long
            Get
                Return lngCommodityId
            End Get
            Set(ByVal value As Long)
                lngCommodityId = value
            End Set
        End Property
        Public Property CrDate() As String
            Get
                Return strCrDate
            End Get
            Set(ByVal value As String)
                strCrDate = value
            End Set
        End Property
        Public Property CrRefNo() As String
            Get
                Return strCrRefNo
            End Get
            Set(ByVal value As String)
                strCrRefNo = value
            End Set
        End Property
        Public Property InvoiceNo() As Long
            Get
                Return lngInvoiceNo
            End Get
            Set(ByVal value As Long)
                lngInvoiceNo = value
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
        Public Property InvoiceAmt() As Long
            Get
                Return lngInvoiceAmt
            End Get
            Set(ByVal value As Long)
                lngInvoiceAmt = value
            End Set
        End Property
        Public Property CrAmt() As Long
            Get
                Return lngCrAmt
            End Get
            Set(ByVal value As Long)
                lngCrAmt = value
            End Set
        End Property

        Public Property CrTax() As Long
            Get
                Return lngCrTax
            End Get
            Set(ByVal value As Long)
                lngCrTax = value
            End Set
        End Property
        Public Property CrBy() As String
            Get
                Return strCrBy
            End Get
            Set(ByVal value As String)
                strCrBy = value
            End Set
        End Property
        Public Property CrOn() As String
            Get
                Return strCrOn
            End Get
            Set(ByVal value As String)
                strCrOn = value
            End Set
        End Property
        Public Property BillQnty() As Long
            Get
                Return lngBillQnty
            End Get
            Set(ByVal value As Long)
                lngBillQnty = value
            End Set
        End Property
        Public Property ServiceTax() As Double
            Get
                Return lngSer
            End Get
            Set(ByVal value As Double)
                lngSer = value
            End Set
        End Property
        Public Property KKC() As Double
            Get
                Return lngKKC
            End Get
            Set(ByVal value As Double)
                lngKKC = value
            End Set
        End Property
        Public Property sbc() As Double
            Get
                Return lngsbc
            End Get
            Set(ByVal value As Double)
                lngsbc = value
            End Set
        End Property
        Public Property IgstPer() As Double
            Get
                Return lngIgstPer
            End Get
            Set(ByVal value As Double)
                lngIgstPer = value
            End Set
        End Property
        Public Property SgstPer() As Double
            Get
                Return lngsgstper
            End Get
            Set(ByVal value As Double)
                lngsgstper = value
            End Set
        End Property
        Public Property CgstPer() As Double
            Get
                Return lngCgstPer
            End Get
            Set(ByVal value As Double)
                lngCgstPer = value
            End Set
        End Property
        Public Property Remark() As String
            Get
                Return strRemark
            End Get
            Set(ByVal value As String)
                strRemark = value
            End Set
        End Property
        Public Property ImpContId() As Long
            Get
                Return lngImpContId
            End Get
            Set(ByVal value As Long)
                lngImpContId = value
            End Set
        End Property
        Public Property BillRate() As Long
            Get
                Return lngBillRate
            End Get
            Set(ByVal value As Long)
                lngBillRate = value
            End Set
        End Property
        Public Property TaxPerc() As Long
            Get
                Return lngTaxPerc
            End Get
            Set(ByVal value As Long)
                lngTaxPerc = value
            End Set
        End Property

        Public Property Errormsg() As String
            Get
                Return strErrormsg
            End Get
            Set(ByVal value As String)
                strErrormsg = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of WeiverAprAmt
        ''' </summary>
        ''' <value>dblWeiverAprAmt</value>
        ''' <returns> Return dblWeiverAprAmt</returns>
        ''' <remarks> Get or Set the Value of WeiverAprAmt  </remarks>
        '''
        Public Property WeiverAprAmt() As Double
            Get
                Return dblWeiverAprAmt
            End Get
            Set(ByVal value As Double)
                dblWeiverAprAmt = value
            End Set
        End Property
        Public Property BillAmount() As Double
            Get
                Return lngBillAmount
            End Get
            Set(ByVal value As Double)
                lngBillAmount = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngCrId = 0
            strCrDate = ""
            strCrRefNo = ""
            lngInvoiceNo = 0
            lngInvoiceAmt = 0
            lngCrAmt = 0
            lngCrTax = 0
            strCrBy = ""
            strCrOn = ""
            lngBillQnty = 0
            lngServiceId = 0
            lngSer = 0.0
            lngsbc = 0.0
            lngKKC = 0.0
            strRemark = ""
            lngCommodityId = 0
            lngCgstPer = 0.0
            lngIgstPer = 0.0
            lngsgstper = 0.0
            lngImpContId = 0
            lngBillRate = 0
            dblWeiverAprAmt = 0.0
            lngBillAmount = 0.0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pImpInvoice"></param>
        ''' <returns>Return pImpInvoice Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCr As CreaditNote) As CreaditNote
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCr.TerminalId)
                db.AddParameter("p_CR_ID", pCr.CrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.CrDate)
                db.AddParameter("p_CR_REF_NO", pCr.CrRefNo, ParameterDirection.Output)
                db.AddParameter("p_IVNOICE_ID", pCr.InvoiceNo)
                db.AddParameter("p_INVOICE_AMT", pCr.InvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.CrAmt)
                db.AddParameter("p_CR_TAX", pCr.CrTax)
                db.AddParameter("p_CR_BY", pCr.CrBy)
                db.AddParameter("p_CR_ON", pCr.CrOn)
                db.AddParameter("p_QNTY", pCr.BillQnty)
                db.AddParameter("p_SERVICE_ID", pCr.ServiceId)
                db.AddParameter("p_SERVICE_TAX", pCr.ServiceTax)
                db.AddParameter("p_KKC", pCr.KKC)
                db.AddParameter("p_SBC", pCr.sbc)
                db.AddParameter("p_REMARK", pCr.Remark)
                db.AddParameter("p_COMMODITY_ID", pCr.CommodityId)
                db.AddParameter("p_IGST_PER", pCr.IgstPer)
                db.AddParameter("p_SGST_PER", pCr.SgstPer)
                db.AddParameter("p_CGST_PER", pCr.CgstPer)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("Generate_Pkg.SP_GENERATE_CR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCr.CrId = db.Parameters.Item("p_CR_ID").value
                pCr.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
                If pCr.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCr.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCr As CreaditNote) As CreaditNote
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCr.TerminalId)
                db.AddParameter("p_CR_ID", pCr.CrId, ParameterDirection.Output)
                db.AddParameter("p_CR_DATE", pCr.CrDate)
                db.AddParameter("p_CR_REF_NO", pCr.CrRefNo, ParameterDirection.Output)
                db.AddParameter("p_IVNOICE_ID", pCr.InvoiceNo)
                db.AddParameter("p_INVOICE_AMT", pCr.InvoiceAmt)
                db.AddParameter("p_CR_AMT", pCr.CrAmt)
                db.AddParameter("p_CR_TAX", pCr.CrTax)
                db.AddParameter("p_CR_BY", pCr.CrBy)
                db.AddParameter("p_CR_ON", pCr.CrOn)
                db.AddParameter("p_QNTY", pCr.BillQnty)
                db.AddParameter("p_SERVICE_ID", pCr.ServiceId)
                db.AddParameter("p_SERVICE_TAX", pCr.ServiceTax)
                db.AddParameter("p_KKC", pCr.KKC)
                db.AddParameter("p_SBC", pCr.sbc)
                db.AddParameter("p_REMARK", pCr.Remark)
                db.AddParameter("p_COMMODITY_ID", pCr.CommodityId)
                db.AddParameter("p_IGST_PER", pCr.IgstPer)
                db.AddParameter("p_SGST_PER", pCr.SgstPer)
                db.AddParameter("p_CGST_PER", pCr.CgstPer)
                db.AddParameter("p_ErrorMsg", pCr.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("Generate_Pkg.SP_GENERATE_CR_NOTE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCr.CrId = db.Parameters.Item("p_CR_ID").value
                pCr.CrRefNo = db.Parameters.Item("p_CR_REF_NO").value
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            Return pCr
        End Function

        ' ''' <summary>
        ' ''' Update Member Function to Update the Print Status of Invoice
        ' ''' </summary>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdatePrint(ByVal pCr As CreaditNote) As CreaditNote
        '    Dim db As New DBConnect
        '    Try
        '        db.BeginTransaction()
        '        db.ClearParameters()
        '        db.AddParameter("p_CR_ID", pCR.CrId, ParameterDirection.Output)
        '        db.AddParameter("p_CR_DATE", pCR.CrDate)
        '        db.AddParameter("p_CR_REF_NO", pCR.CrRefNo, ParameterDirection.Output)
        '        db.AddParameter("p_IVNOICE_ID", pCR.InvID)
        '        db.AddParameter("p_INVOICE_AMT", pCR.InvoiceAmt)
        '        db.AddParameter("p_CR_AMT", pCR.CrAmt)
        '        db.AddParameter("p_CR_TAX", pCR.CrTax)
        '        db.AddParameter("p_CR_BY", pCR.CrBy)
        '        db.AddParameter("p_CR_ON", pCR.CrOn)
        '        db.AddParameter("p_QNTY", pCR.Qnty)
        '        db.AddParameter("p_ErrorMsg", pCR.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_CR_NOTE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pCr.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        If pCr.Errormsg <> Nothing Then
        '            db.RollbackTransaction()
        '        Else
        '            db.CommitTransaction()
        '        End If
        '    Catch ex As Exception
        '        pCr.Errormsg = ex.Message
        '        db.RollbackTransaction()
        '    End Try
        '    db.CloseDB()
        '    Return pCr
        'End Function

        ' ''' <summary>
        ' ''' Update Member Function to Cancel Invoice
        ' ''' </summary>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdateCancel(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Dim db As New DBConnect
        '    Try
        '        db.BeginTransaction()
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
        '        db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
        '        db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
        '        db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
        '        db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
        '        db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
        '        db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
        '        db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
        '        db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
        '        db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
        '        db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
        '        db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
        '        db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_IMP_INVOICE_CANCEL", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        If pImpInvoice.Errormsg <> Nothing Then
        '            db.RollbackTransaction()
        '        Else
        '            db.CommitTransaction()
        '        End If
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '        db.RollbackTransaction()
        '    End Try
        '    db.CloseDB()
        '    Return pImpInvoice
        'End Function


        ' ''' <summary>
        ' ''' Update Member Function to Update the New Record
        ' ''' </summary>
        ' ''' <param name="db"></param>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Try
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo)
        '        db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
        '        db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
        '        db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
        '        db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
        '        db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
        '        db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
        '        db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
        '        db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
        '        db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
        '        db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
        '        db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
        '        db.AddParameter("p_REF_INV_ID", pImpInvoice.RefInvId)
        '        db.AddParameter("p_CR_DR", pImpInvoice.CrDr)
        '        db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_UPDATE_IMP_INVOICE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    Return pImpInvoice
        'End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCR As CreaditNote) As CreaditNote
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pCR.CrId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ID").ToString <> "" Then
                                pCR.CrId = dbr("CR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DATE").ToString <> "" Then
                                pCR.CrDate = dbr("CR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_REF_NO").ToString <> "" Then
                                pCR.CrRefNo = dbr("CR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                pCR.InvoiceNo = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_AMOUNT").ToString <> "" Then
                                pCR.InvoiceAmt = dbr("INVOICE_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                pCR.BillRate = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                pCR.CrAmt = dbr("CR_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILL_AMOUNT").ToString <> "" Then
                                pCR.BillAmount = dbr("BILL_AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_TAX").ToString <> "" Then
                                pCR.CrTax = dbr("CR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_BY").ToString <> "" Then
                                pCR.CrBy = dbr("CR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ON").ToString <> "" Then
                                pCR.CrOn = dbr("CR_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                pCR.BillQnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pCR.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TAX").ToString <> "" Then
                                pCR.ServiceTax = dbr("SERVICE_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KKC").ToString <> "" Then
                                pCR.KKC = dbr("KKC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SBC").ToString <> "" Then
                                pCR.sbc = dbr("SBC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK").ToString <> "" Then
                                pCR.Remark = dbr("REMARK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                pCR.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGST_PER").ToString <> "" Then
                                pCR.IgstPer = dbr("IGST_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_PER").ToString <> "" Then
                                pCR.SgstPer = dbr("SGST_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_PER").ToString <> "" Then
                                pCR.CgstPer = dbr("CGST_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pCR.Errormsg = ex.Message
            End Try
            Return pCR
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCR As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CreaditNote
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.CrId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ID").ToString <> "" Then
                                temp.CrId = dbr("CR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_DATE").ToString <> "" Then
                                temp.CrDate = dbr("CR_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_REF_NO").ToString <> "" Then
                                temp.CrRefNo = dbr("CR_REF_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_ID").ToString <> "" Then
                                temp.InvoiceNo = dbr("INVOICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_AMT").ToString <> "" Then
                                temp.InvoiceAmt = dbr("INVOICE_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_AMOUNT").ToString <> "" Then
                                temp.BillRate = dbr("CR_AMOUNT")
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
                            If dbr("CR_AMT").ToString <> "" Then
                                temp.CrAmt = dbr("CR_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_TAX").ToString <> "" Then
                                temp.CrTax = dbr("CR_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_BY").ToString <> "" Then
                                temp.CrBy = dbr("CR_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CR_ON").ToString <> "" Then
                                temp.CrOn = dbr("CR_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                temp.BillQnty = dbr("QNTY")
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
                            If dbr("SERVICE_TAX").ToString <> "" Then
                                temp.ServiceTax = dbr("SERVICE_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("KKC").ToString <> "" Then
                                temp.KKC = dbr("KKC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SBC").ToString <> "" Then
                                temp.sbc = dbr("SBC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARK").ToString <> "" Then
                                temp.Remark = dbr("REMARK")
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
                            If dbr("IGST_PER").ToString <> "" Then
                                temp.IgstPer = dbr("IGST_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SGST_PER").ToString <> "" Then
                                temp.SgstPer = dbr("SGST_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CGST_PER").ToString <> "" Then
                                temp.CgstPer = dbr("CGST_PER")
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
        ''' Preparing Return Object By TerminalId, InvoiceNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCreaditNotebyid(ByVal pCr As CreaditNote) As CreaditNote
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.CrId)
                pCr = ReturnObjectValues(dbr, pCr)
                dbr.Close()
            Catch ex As Exception
                pCr.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCr
        End Function
        Public Shared Function ReturnCreaditNoteListbyid(ByVal pCr As CreaditNote) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCreditNoteItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SELECT_CREDIT_NOTE_ID", pCr.CrId)
                arrCreditNoteItems = ReturnObjectValuesList(dbr, arrCreditNoteItems)
                dbr.Close()
            Catch ex As Exception
                arrCreditNoteItems = Nothing
            End Try
            db.CloseDB()
            Return arrCreditNoteItems
        End Function

        ' ''' <summary>
        ' ''' Preparing Return Object By TerminalId, InvoiceRefNo
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        ' '''
        'Public Shared Function ReturnImpInvoiceByInvoiceRefNo(ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Dim db As New DBConnect
        '    Dim dbr As OleDb.OleDbDataReader
        '    Try
        '        db.ClearParameters()
        '        dbr = db.StoredProcedureReadDB("USP_SELECT_IMP_INVOICE_BY_REF_NO", pImpInvoice.TerminalId & ",'" & pImpInvoice.InvoiceRefNo & "'")
        '        pImpInvoice = ReturnObjectValues(dbr, pImpInvoice)
        '        dbr.Close()
        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    db.CloseDB()
        '    Return pImpInvoice
        'End Function

        ' ''' <summary>
        ' ''' Preparing Return Object ArrayList By TerminalId, LineItemId
        ' ''' </summary>
        ' ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        ' '''
        'Public Shared Function ReturnImpInvoiceListByLineItemId(ByVal pImpInvoice As ImpInvoice) As ArrayList
        '    Dim db As New DBConnect
        '    Dim dbr As OleDb.OleDbDataReader
        '    Dim arrImpInvoice As New ArrayList
        '    Try
        '        db.ClearParameters()
        '        dbr = db.StoredProcedureReadDB("USP_SELECT_IMP_INVOICE_ALL_LINEITEMID", pImpInvoice.TerminalId & "," & pImpInvoice.LineItemId)
        '        arrImpInvoice = ReturnObjectValuesList(dbr, arrImpInvoice)
        '        dbr.Close()
        '    Catch ex As Exception
        '        arrImpInvoice = Nothing
        '    End Try
        '    db.CloseDB()
        '    Return arrImpInvoice
        'End Function
        ' ''' <summary>
        ' ''' Insert Member Function to Insert the New Record With Transaction
        ' ''' </summary>
        ' ''' <param name="db"></param>
        ' ''' <param name="pImpInvoice"></param>
        ' ''' <returns>Return pImpInvoice Object</returns>
        ' ''' <remarks></remarks>
        ' '''
        'Public Shared Function InsertTrnTemp(ByVal db As DBConnect, ByVal pImpInvoice As ImpInvoice) As ImpInvoice
        '    Try
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pImpInvoice.TerminalId)
        '        db.AddParameter("p_LINE_ITEM_ID", pImpInvoice.LineItemId)
        '        db.AddParameter("p_INVOICE_NO", pImpInvoice.InvoiceNo, ParameterDirection.Output)
        '        db.AddParameter("p_INVOICE_DATE", pImpInvoice.InvoiceDate, ParameterDirection.Output)
        '        db.AddParameter("p_INVOICE_REF_NO", pImpInvoice.InvoiceRefNo, ParameterDirection.Output)
        '        db.AddParameter("p_SERVICE_TYPE", pImpInvoice.ServiceType)
        '        db.AddParameter("p_CUSTOMER_TYPE", pImpInvoice.CustomerType)
        '        db.AddParameter("p_BILL_TO", pImpInvoice.BillTo)
        '        db.AddParameter("p_PAYMENT_MODE", pImpInvoice.PaymentMode)
        '        db.AddParameter("p_GR_TILL_DATE", pImpInvoice.GrTillDate)
        '        db.AddParameter("p_PRINT_STATUS", pImpInvoice.PrintStatus)
        '        db.AddParameter("p_RECEIPT_NO", pImpInvoice.ReceiptNo)
        '        db.AddParameter("p_INVOICE_NOTE", pImpInvoice.InvoiceNote)
        '        db.AddParameter("p_CANCLE_FLAGE", pImpInvoice.CancleFlage)
        '        db.AddParameter("p_CREATED_BY", pImpInvoice.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pImpInvoice.CreatedOn)
        '        db.AddParameter("p_DOC_TYPE", pImpInvoice.DocType)
        '        db.AddParameter("p_ErrorMsg", pImpInvoice.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("USP_INSERT_TEMP_IMP_INVOICE", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pImpInvoice.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        pImpInvoice.InvoiceNo = db.Parameters.Item("p_INVOICE_NO").value
        '        pImpInvoice.InvoiceDate = db.Parameters.Item("p_INVOICE_DATE").value
        '        pImpInvoice.InvoiceRefNo = db.Parameters.Item("p_INVOICE_REF_NO").value.ToString

        '    Catch ex As Exception
        '        pImpInvoice.Errormsg = ex.Message
        '    End Try
        '    Return pImpInvoice
        'End Function
        Public Shared Function InsertCRDetails(ByVal pCreditNote As CreaditNote) As CreaditNote
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each CR As CreaditNote In pCreditNote.CRNoteList
                    CreaditNote.InsertTrn(db, CR)
                    Dim pFinanceDetails As New FinanceDetails
                Next


                db.CommitTransaction()
            Catch ex As Exception
                pCreditNote.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pCreditNote
        End Function
    End Class

End Namespace
