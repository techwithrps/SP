Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CancelImpInvoiceTax
    ''' @author	: Santosh Singh- 23/11/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CancelImpInvoiceTax 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
        Private strLineItem As String ' Define Private Variable LineItem With DataType As String 
        Private lngInvoiceNo As Long ' Define Private Variable InvoiceNo With DataType As Long 
        Private lngImpContId As Long ' Define Private Variable ImpContId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private lngTaxHeadId As Long ' Define Private Variable TaxHeadId With DataType As Long 
        Private dblTaxPerc As Double ' Define Private Variable TaxPerc With DataType As Double 
        Private dblTaxOnAmt As Double ' Define Private Variable TaxOnAmt With DataType As Double 
        Private dblTaxAmt As Double ' Define Private Variable TaxAmt With DataType As Double 
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
        ''' Get or Set the Value of TaxHeadId
        ''' </summary>
        ''' <value>lngTaxHeadId</value>
        ''' <returns> Return lngTaxHeadId</returns>
        ''' <remarks> Get or Set the Value of TaxHeadId  </remarks>
        '''
        Public Property TaxHeadId() as Long
            Get
                Return lngTaxHeadId
            End Get
            Set(ByVal value As Long)
                lngTaxHeadId = value
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
        ''' Get or Set the Value of TaxOnAmt
        ''' </summary>
        ''' <value>dblTaxOnAmt</value>
        ''' <returns> Return dblTaxOnAmt</returns>
        ''' <remarks> Get or Set the Value of TaxOnAmt  </remarks>
        '''
        Public Property TaxOnAmt() as Double
            Get
                Return dblTaxOnAmt
            End Get
            Set(ByVal value As Double)
                dblTaxOnAmt = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TaxAmt
        ''' </summary>
        ''' <value>dblTaxAmt</value>
        ''' <returns> Return dblTaxAmt</returns>
        ''' <remarks> Get or Set the Value of TaxAmt  </remarks>
        '''
        Public Property TaxAmt() as Double
            Get
                Return dblTaxAmt
            End Get
            Set(ByVal value As Double)
                dblTaxAmt = value
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
            lngLineItemId = 0 
            strLineItem = ""
            lngInvoiceNo = 0 
            lngImpContId = 0 
            lngServiceId = 0 
            lngTaxHeadId = 0 
            dblTaxPerc = 0.0 
            dblTaxOnAmt = 0.0 
            dblTaxAmt = 0.0 
            lngItemKeyId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoiceTax"></param>
        ''' <returns>Return pCancelImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pCancelImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pCancelImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pCancelImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceTax.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pCancelImpInvoiceTax.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoiceTax.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoiceTax"></param>
        ''' <returns>Return pCancelImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pCancelImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pCancelImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pCancelImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceTax.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CANCEL_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pCancelImpInvoiceTax.ErrorMsg = ex.Message
            End Try
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCancelImpInvoiceTax"></param>
        ''' <returns>Return pCancelImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pCancelImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pCancelImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pCancelImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceTax.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCancelImpInvoiceTax.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCancelImpInvoiceTax.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCancelImpInvoiceTax"></param>
        ''' <returns>Return pCancelImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCancelImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pCancelImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pCancelImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pCancelImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pCancelImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pCancelImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pCancelImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pCancelImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pCancelImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pCancelImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ITEM_KEY_ID", pCancelImpInvoiceTax.ItemKeyId)
                db.AddParameter("p_ErrorMsg", pCancelImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CANCEL_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCancelImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCancelImpInvoiceTax.ErrorMsg = ex.Message
                End Try
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                PCancelImpInvoiceTax.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PCancelImpInvoiceTax.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.TaxHeadId = dbr("TAX_HEAD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                PCancelImpInvoiceTax.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_ON_AMT").ToString <> "" Then
                                PCancelImpInvoiceTax.TaxOnAmt = dbr("TAX_ON_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                PCancelImpInvoiceTax.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_KEY_ID").ToString <> "" Then
                                PCancelImpInvoiceTax.ItemKeyId = dbr("ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCancelImpInvoiceTax.ErrorMsg = ex.Message
            End Try
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCancelImpInvoiceTax As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CancelImpInvoiceTax
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
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                temp.TaxHeadId = dbr("TAX_HEAD_ID")
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
                            If dbr("TAX_ON_AMT").ToString <> "" Then
                                temp.TaxOnAmt = dbr("TAX_ON_AMT")
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
        Public Shared Function ReturnCancelImpInvoiceTax(ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As CancelImpInvoiceTax
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CANCEL_IMP_INVOICE_TAX", "' '")
                pCancelImpInvoiceTax = ReturnObjectValues(dbr, pCancelImpInvoiceTax)
                dbr.Close()
            Catch ex As Exception
                pCancelImpInvoiceTax.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCancelImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCancelImpInvoiceTaxListByItemKeyId(ByVal pCancelImpInvoiceTax As CancelImpInvoiceTax) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCancelImpInvoiceTax As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CL_IMP_INVOICE_TAX_BY_ID", pCancelImpInvoiceTax.TerminalId & "," & pCancelImpInvoiceTax.ItemKeyId)
                arrCancelImpInvoiceTax = ReturnObjectValuesList(dbr, arrCancelImpInvoiceTax)
                dbr.Close()
            Catch ex As Exception
                arrCancelImpInvoiceTax = Nothing
            End Try
            db.CloseDB()
            Return arrCancelImpInvoiceTax
        End Function
    End Class
End Namespace
