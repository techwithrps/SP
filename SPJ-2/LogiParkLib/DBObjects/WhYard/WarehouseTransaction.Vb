Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: WarehouseTransaction
    ''' @author	: Amit K. Singh- 8/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class WarehouseTransaction 
    
        Private lngTransactionId As Long ' Define Private Variable TransactionId With DataType As Long 
        Private lngAllocationId As Long ' Define Private Variable AllocationId With DataType As Long 
        Private strIgmNo As String ' Define Private Variable IgmNo With DataType As String 
        Private strLineItem As String ' Define Private Variable LineItem With DataType As String 
        Private strSbNo As String ' Define Private Variable SbNo With DataType As String 
        Private lngCha As Long ' Define Private Variable Cha With DataType As Long 
        Private lngLine As Long ' Define Private Variable Line With DataType As Long 
        Private dblPkgs As Double ' Define Private Variable Pkgs With DataType As Double 
        Private dblWeight As Double ' Define Private Variable Weight With DataType As Double 
        Private strTransactionDate As String ' Define Private Variable TransactionDate With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of TransactionId
        ''' </summary>
        ''' <value>lngTransactionId</value>
        ''' <returns> Return lngTransactionId</returns>
        ''' <remarks> Get or Set the Value of TransactionId  </remarks>
        '''
        Public Property TransactionId() as Long
            Get
                Return lngTransactionId
            End Get
            Set(ByVal value As Long)
                lngTransactionId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of AllocationId
        ''' </summary>
        ''' <value>lngAllocationId</value>
        ''' <returns> Return lngAllocationId</returns>
        ''' <remarks> Get or Set the Value of AllocationId  </remarks>
        '''
        Public Property AllocationId() as Long
            Get
                Return lngAllocationId
            End Get
            Set(ByVal value As Long)
                lngAllocationId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IgmNo
        ''' </summary>
        ''' <value>strIgmNo</value>
        ''' <returns> Return strIgmNo</returns>
        ''' <remarks> Get or Set the Value of IgmNo  </remarks>
        '''
        Public Property IgmNo() as String
            Get
                Return strIgmNo
            End Get
            Set(ByVal value As String)
                strIgmNo = value
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
        ''' Get or Set the Value of SbNo
        ''' </summary>
        ''' <value>strSbNo</value>
        ''' <returns> Return strSbNo</returns>
        ''' <remarks> Get or Set the Value of SbNo  </remarks>
        '''
        Public Property SbNo() as String
            Get
                Return strSbNo
            End Get
            Set(ByVal value As String)
                strSbNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Cha
        ''' </summary>
        ''' <value>lngCha</value>
        ''' <returns> Return lngCha</returns>
        ''' <remarks> Get or Set the Value of Cha  </remarks>
        '''
        Public Property Cha() as Long
            Get
                Return lngCha
            End Get
            Set(ByVal value As Long)
                lngCha = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Line
        ''' </summary>
        ''' <value>lngLine</value>
        ''' <returns> Return lngLine</returns>
        ''' <remarks> Get or Set the Value of Line  </remarks>
        '''
        Public Property Line() as Long
            Get
                Return lngLine
            End Get
            Set(ByVal value As Long)
                lngLine = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Pkgs
        ''' </summary>
        ''' <value>dblPkgs</value>
        ''' <returns> Return dblPkgs</returns>
        ''' <remarks> Get or Set the Value of Pkgs  </remarks>
        '''
        Public Property Pkgs() as Double
            Get
                Return dblPkgs
            End Get
            Set(ByVal value As Double)
                dblPkgs = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Weight
        ''' </summary>
        ''' <value>dblWeight</value>
        ''' <returns> Return dblWeight</returns>
        ''' <remarks> Get or Set the Value of Weight  </remarks>
        '''
        Public Property Weight() as Double
            Get
                Return dblWeight
            End Get
            Set(ByVal value As Double)
                dblWeight = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TransactionDate
        ''' </summary>
        ''' <value>strTransactionDate</value>
        ''' <returns> Return strTransactionDate</returns>
        ''' <remarks> Get or Set the Value of TransactionDate  </remarks>
        '''
        Public Property TransactionDate() as String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal value As String)
                strTransactionDate = value
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
            lngTransactionId = 0 
            lngAllocationId = 0 
            strIgmNo = ""
            strLineItem = ""
            strSbNo = ""
            lngCha = 0 
            lngLine = 0 
            dblPkgs = 0.0 
            dblWeight = 0.0 
            strTransactionDate = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pWarehouseTransaction"></param>
        ''' <returns>Return pWarehouseTransaction Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRANSACTION_ID", pWarehouseTransaction.TransactionId)
                db.AddParameter("p_ALLOCATION_ID", pWarehouseTransaction.AllocationId)
                db.AddParameter("p_IGM_NO", pWarehouseTransaction.IgmNo)
                db.AddParameter("p_LINE_ITEM", pWarehouseTransaction.LineItem)
                db.AddParameter("p_SB_NO", pWarehouseTransaction.SbNo)
                db.AddParameter("p_CHA", pWarehouseTransaction.Cha)
                db.AddParameter("p_LINE", pWarehouseTransaction.Line)
                db.AddParameter("p_PKGS", pWarehouseTransaction.Pkgs)
                db.AddParameter("p_WEIGHT", pWarehouseTransaction.Weight)
                db.AddParameter("p_TRANSACTION_DATE", pWarehouseTransaction.TransactionDate)
                db.AddParameter("p_ErrorMsg", pWarehouseTransaction.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_TRANSACTION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseTransaction.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pWarehouseTransaction.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseTransaction.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseTransaction"></param>
        ''' <returns>Return pWarehouseTransaction Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Try
                db.ClearParameters()
                db.AddParameter("p_TRANSACTION_ID", pWarehouseTransaction.TransactionId)
                db.AddParameter("p_ALLOCATION_ID", pWarehouseTransaction.AllocationId)
                db.AddParameter("p_IGM_NO", pWarehouseTransaction.IgmNo)
                db.AddParameter("p_LINE_ITEM", pWarehouseTransaction.LineItem)
                db.AddParameter("p_SB_NO", pWarehouseTransaction.SbNo)
                db.AddParameter("p_CHA", pWarehouseTransaction.Cha)
                db.AddParameter("p_LINE", pWarehouseTransaction.Line)
                db.AddParameter("p_PKGS", pWarehouseTransaction.Pkgs)
                db.AddParameter("p_WEIGHT", pWarehouseTransaction.Weight)
                db.AddParameter("p_TRANSACTION_DATE", pWarehouseTransaction.TransactionDate)
                db.AddParameter("p_ErrorMsg", pWarehouseTransaction.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_TRANSACTION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseTransaction.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pWarehouseTransaction.ErrorMsg = ex.Message
            End Try
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pWarehouseTransaction"></param>
        ''' <returns>Return pWarehouseTransaction Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRANSACTION_ID", pWarehouseTransaction.TransactionId)
                db.AddParameter("p_ALLOCATION_ID", pWarehouseTransaction.AllocationId)
                db.AddParameter("p_IGM_NO", pWarehouseTransaction.IgmNo)
                db.AddParameter("p_LINE_ITEM", pWarehouseTransaction.LineItem)
                db.AddParameter("p_SB_NO", pWarehouseTransaction.SbNo)
                db.AddParameter("p_CHA", pWarehouseTransaction.Cha)
                db.AddParameter("p_LINE", pWarehouseTransaction.Line)
                db.AddParameter("p_PKGS", pWarehouseTransaction.Pkgs)
                db.AddParameter("p_WEIGHT", pWarehouseTransaction.Weight)
                db.AddParameter("p_TRANSACTION_DATE", pWarehouseTransaction.TransactionDate)
                db.AddParameter("p_ErrorMsg", pWarehouseTransaction.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_TRANSACTION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseTransaction.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pWarehouseTransaction.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseTransaction.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseTransaction"></param>
        ''' <returns>Return pWarehouseTransaction Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Try
                db.ClearParameters()
                db.AddParameter("p_TRANSACTION_ID", pWarehouseTransaction.TransactionId)
                db.AddParameter("p_ALLOCATION_ID", pWarehouseTransaction.AllocationId)
                db.AddParameter("p_IGM_NO", pWarehouseTransaction.IgmNo)
                db.AddParameter("p_LINE_ITEM", pWarehouseTransaction.LineItem)
                db.AddParameter("p_SB_NO", pWarehouseTransaction.SbNo)
                db.AddParameter("p_CHA", pWarehouseTransaction.Cha)
                db.AddParameter("p_LINE", pWarehouseTransaction.Line)
                db.AddParameter("p_PKGS", pWarehouseTransaction.Pkgs)
                db.AddParameter("p_WEIGHT", pWarehouseTransaction.Weight)
                db.AddParameter("p_TRANSACTION_DATE", pWarehouseTransaction.TransactionDate)
                db.AddParameter("p_ErrorMsg", pWarehouseTransaction.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_TRANSACTION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseTransaction.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pWarehouseTransaction.ErrorMsg = ex.Message
                End Try
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TRANSACTION_ID").ToString <> "" Then
                                PWarehouseTransaction.TransactionId = dbr("TRANSACTION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOCATION_ID").ToString <> "" Then
                                PWarehouseTransaction.AllocationId = dbr("ALLOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_NO").ToString <> "" Then
                                PWarehouseTransaction.IgmNo = dbr("IGM_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM").ToString <> "" Then
                                PWarehouseTransaction.LineItem = dbr("LINE_ITEM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SB_NO").ToString <> "" Then
                                PWarehouseTransaction.SbNo = dbr("SB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA").ToString <> "" Then
                                PWarehouseTransaction.Cha = dbr("CHA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE").ToString <> "" Then
                                PWarehouseTransaction.Line = dbr("LINE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PKGS").ToString <> "" Then
                                PWarehouseTransaction.Pkgs = dbr("PKGS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIGHT").ToString <> "" Then
                                PWarehouseTransaction.Weight = dbr("WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSACTION_DATE").ToString <> "" Then
                                PWarehouseTransaction.TransactionDate = dbr("TRANSACTION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pWarehouseTransaction.ErrorMsg = ex.Message
            End Try
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrWarehouseTransaction As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New WarehouseTransaction
                        Try
                            If dbr("TRANSACTION_ID").ToString <> "" Then
                                temp.TransactionId = dbr("TRANSACTION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOCATION_ID").ToString <> "" Then
                                temp.AllocationId = dbr("ALLOCATION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IGM_NO").ToString <> "" Then
                                temp.IgmNo = dbr("IGM_NO")
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
                            If dbr("SB_NO").ToString <> "" Then
                                temp.SbNo = dbr("SB_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA").ToString <> "" Then
                                temp.Cha = dbr("CHA")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE").ToString <> "" Then
                                temp.Line = dbr("LINE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PKGS").ToString <> "" Then
                                temp.Pkgs = dbr("PKGS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WEIGHT").ToString <> "" Then
                                temp.Weight = dbr("WEIGHT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSACTION_DATE").ToString <> "" Then
                                temp.TransactionDate = dbr("TRANSACTION_DATE")
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
        Public Shared Function ReturnWarehouseTransaction(ByVal pWarehouseTransaction As WarehouseTransaction) As WarehouseTransaction
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_TRANSACTION", "' '")
                pWarehouseTransaction = ReturnObjectValues(dbr, pWarehouseTransaction)
                dbr.Close()
            Catch ex As Exception
                pWarehouseTransaction.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseTransaction
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnWarehouseTransactionList (ByVal pWarehouseTransaction As WarehouseTransaction) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseTransaction As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_TRANSACTION", "' '")
                arrWarehouseTransaction = ReturnObjectValuesList(dbr, arrWarehouseTransaction)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseTransaction = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseTransaction
        End Function
    End Class
End Namespace
