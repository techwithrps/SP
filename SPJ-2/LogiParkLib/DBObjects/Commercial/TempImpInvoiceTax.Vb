Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TempImpInvoiceTax
    ''' @author	: Amit K. Singh- 1/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TempImpInvoiceTax 
    
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
        Private lngItemKeyId As Long ' Define Private Variable ItemKeyId With DataType As Double 
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
        Public Property ItemKeyId() As Long
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
        ''' <param name="pTempImpInvoiceTax"></param>
        ''' <returns>Return pTempImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pTempImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pTempImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pTempImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pTempImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pTempImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pTempImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pTempImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ErrorMsg", pTempImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pTempImpInvoiceTax.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoiceTax.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempImpInvoiceTax"></param>
        ''' <returns>Return pTempImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pTempImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pTempImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pTempImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pTempImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pTempImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pTempImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pTempImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ErrorMsg", pTempImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pTempImpInvoiceTax.ErrorMsg = ex.Message
            End Try
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTempImpInvoiceTax"></param>
        ''' <returns>Return pTempImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pTempImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pTempImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pTempImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pTempImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pTempImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pTempImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pTempImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ErrorMsg", pTempImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTempImpInvoiceTax.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempImpInvoiceTax.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempImpInvoiceTax"></param>
        ''' <returns>Return pTempImpInvoiceTax Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTempImpInvoiceTax.TerminalId)
                db.AddParameter("p_LINE_ITEM_ID", pTempImpInvoiceTax.LineItemId)
                db.AddParameter("p_LINE_ITEM", pTempImpInvoiceTax.LineItem)
                db.AddParameter("p_INVOICE_NO", pTempImpInvoiceTax.InvoiceNo)
                db.AddParameter("p_IMP_CONT_ID", pTempImpInvoiceTax.ImpContId)
                db.AddParameter("p_SERVICE_ID", pTempImpInvoiceTax.ServiceId)
                db.AddParameter("p_TAX_HEAD_ID", pTempImpInvoiceTax.TaxHeadId)
                db.AddParameter("p_TAX_PERC", pTempImpInvoiceTax.TaxPerc)
                db.AddParameter("p_TAX_ON_AMT", pTempImpInvoiceTax.TaxOnAmt)
                db.AddParameter("p_TAX_AMT", pTempImpInvoiceTax.TaxAmt)
                db.AddParameter("p_ErrorMsg", pTempImpInvoiceTax.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_IMP_INVOICE_TAX", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempImpInvoiceTax.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTempImpInvoiceTax.ErrorMsg = ex.Message
                End Try
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTempImpInvoiceTax.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                PTempImpInvoiceTax.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                PTempImpInvoiceTax.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INVOICE_NO").ToString <> "" Then
                                PTempImpInvoiceTax.InvoiceNo = dbr("INVOICE_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                PTempImpInvoiceTax.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PTempImpInvoiceTax.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                PTempImpInvoiceTax.TaxHeadId = dbr("TAX_HEAD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERC").ToString <> "" Then
                                PTempImpInvoiceTax.TaxPerc = dbr("TAX_PERC")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_ON_AMT").ToString <> "" Then
                                PTempImpInvoiceTax.TaxOnAmt = dbr("TAX_ON_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_AMT").ToString <> "" Then
                                PTempImpInvoiceTax.TaxAmt = dbr("TAX_AMT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_KEY_ID").ToString <> "" Then
                                pTempImpInvoiceTax.ItemKeyId = dbr("ITEM_KEY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTempImpInvoiceTax.ErrorMsg = ex.Message
            End Try
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTempImpInvoiceTax As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TempImpInvoiceTax
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
        Public Shared Function ReturnTempImpInvoiceTaxByInvoiceNo(ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As TempImpInvoiceTax
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_IMP_INVOICE_TAX_BY_NO", pTempImpInvoiceTax.TerminalId & "," & pTempImpInvoiceTax.InvoiceNo & "," & pTempImpInvoiceTax.ServiceId)
                pTempImpInvoiceTax = ReturnObjectValues(dbr, pTempImpInvoiceTax)
                dbr.Close()
            Catch ex As Exception
                pTempImpInvoiceTax.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTempImpInvoiceTax
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTempImpInvoiceTaxListByInvoiceNo(ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempImpInvoiceTax As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_IMP_INVOICE_TAX_BY_NO", pTempImpInvoiceTax.TerminalId & "," & pTempImpInvoiceTax.InvoiceNo & "," & pTempImpInvoiceTax.ServiceId & "," & pTempImpInvoiceTax.ImpContId & "," & pTempImpInvoiceTax.ItemKeyId)
                arrTempImpInvoiceTax = ReturnObjectValuesList(dbr, arrTempImpInvoiceTax)
                dbr.Close()
            Catch ex As Exception
                arrTempImpInvoiceTax = Nothing
            End Try
            db.CloseDB()
            Return arrTempImpInvoiceTax
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTempImpInvoiceTaxListByItemKeyId(ByVal pTempImpInvoiceTax As TempImpInvoiceTax) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempImpInvoiceTax As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_IMP_INVOICE_TAX_BY_ID", pTempImpInvoiceTax.TerminalId & "," & pTempImpInvoiceTax.ItemKeyId)
                arrTempImpInvoiceTax = ReturnObjectValuesList(dbr, arrTempImpInvoiceTax)
                dbr.Close()
            Catch ex As Exception
                arrTempImpInvoiceTax = Nothing
            End Try
            db.CloseDB()
            Return arrTempImpInvoiceTax
        End Function
    End Class
End Namespace
