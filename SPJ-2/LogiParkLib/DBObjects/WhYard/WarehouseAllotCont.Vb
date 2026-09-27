Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: WarehouseAllotCont
    ''' @author	: Amit K. Singh- 17/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class WarehouseAllotCont 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngWhAllotId As Long ' Define Private Variable WhAllotId With DataType As Long 
        Private lngImpContId As Long ' Define Private Variable ImpContId With DataType As Long 
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String

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
        ''' Get or Set the Value of WhAllotId
        ''' </summary>
        ''' <value>lngWhAllotId</value>
        ''' <returns> Return lngWhAllotId</returns>
        ''' <remarks> Get or Set the Value of WhAllotId  </remarks>
        '''
        Public Property WhAllotId() as Long
            Get
                Return lngWhAllotId
            End Get
            Set(ByVal value As Long)
                lngWhAllotId = value
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
        ''' Get or Set the Value of LineItemId
        ''' </summary>
        ''' <value>lngLineItemId</value>
        ''' <returns> Return lngLineItemId</returns>
        ''' <remarks> Get or Set the Value of LineItemId  </remarks>
        '''
        Public Property LineItemId() As Long
            Get
                Return lngLineItemId
            End Get
            Set(ByVal value As Long)
                lngLineItemId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() As String
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
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0 
            lngWhAllotId = 0 
            lngImpContId = 0
            lngLineItemId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pWarehouseAllotCont"></param>
        ''' <returns>Return pWarehouseAllotCont Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllotCont.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllotCont.WhAllotId)
                db.AddParameter("p_IMP_CONT_ID", pWarehouseAllotCont.ImpContId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllotCont.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllotCont.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllotCont.CreatedOn)

                db.AddParameter("p_ErrorMsg", pWarehouseAllotCont.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_ALLOT_CONT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllotCont.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pWarehouseAllotCont.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseAllotCont.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseAllotCont"></param>
        ''' <returns>Return pWarehouseAllotCont Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllotCont.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllotCont.WhAllotId)
                db.AddParameter("p_IMP_CONT_ID", pWarehouseAllotCont.ImpContId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllotCont.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllotCont.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllotCont.CreatedOn)

                db.AddParameter("p_ErrorMsg", pWarehouseAllotCont.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_ALLOT_CONT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllotCont.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pWarehouseAllotCont.ErrorMsg = ex.Message
            End Try
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pWarehouseAllotCont"></param>
        ''' <returns>Return pWarehouseAllotCont Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllotCont.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllotCont.WhAllotId)
                db.AddParameter("p_IMP_CONT_ID", pWarehouseAllotCont.ImpContId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllotCont.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllotCont.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllotCont.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseAllotCont.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_ALLOT_CONT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllotCont.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pWarehouseAllotCont.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseAllotCont.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseAllotCont"></param>
        ''' <returns>Return pWarehouseAllotCont Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllotCont.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllotCont.WhAllotId)
                db.AddParameter("p_IMP_CONT_ID", pWarehouseAllotCont.ImpContId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllotCont.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllotCont.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllotCont.CreatedOn)

                db.AddParameter("p_ErrorMsg", pWarehouseAllotCont.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_ALLOT_CONT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllotCont.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pWarehouseAllotCont.ErrorMsg = ex.Message
                End Try
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PWarehouseAllotCont.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WH_ALLOT_ID").ToString <> "" Then
                                PWarehouseAllotCont.WhAllotId = dbr("WH_ALLOT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CONT_ID").ToString <> "" Then
                                PWarehouseAllotCont.ImpContId = dbr("IMP_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                pWarehouseAllotCont.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pWarehouseAllotCont.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pWarehouseAllotCont.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pWarehouseAllotCont.ErrorMsg = ex.Message
            End Try
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrWarehouseAllotCont As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New WarehouseAllotCont
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WH_ALLOT_ID").ToString <> "" Then
                                temp.WhAllotId = dbr("WH_ALLOT_ID")
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
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                temp.LineItemId = dbr("LINE_ITEM_ID")
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
                        arrList.Add(temp)
                    End While
                end If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, ImpContId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnWarehouseAllotContByImpContId(ByVal pWarehouseAllotCont As WarehouseAllotCont) As WarehouseAllotCont
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_ALLOT_CONT_BY_ID", pWarehouseAllotCont.TerminalId & "," & pWarehouseAllotCont.ImpContId)
                pWarehouseAllotCont = ReturnObjectValues(dbr, pWarehouseAllotCont)
                dbr.Close()
            Catch ex As Exception
                pWarehouseAllotCont.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseAllotCont
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, WhAllotId or LineItemId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnWarehouseAllotContListByWhAllotId_LineItemId(ByVal pWarehouseAllotCont As WarehouseAllotCont) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseAllotCont As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WH_ALLOT_CONT_LIST", pWarehouseAllotCont.TerminalId & "," & pWarehouseAllotCont.WhAllotId & "," & pWarehouseAllotCont.LineItemId)
                arrWarehouseAllotCont = ReturnObjectValuesList(dbr, arrWarehouseAllotCont)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseAllotCont = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseAllotCont
        End Function
    End Class
End Namespace
