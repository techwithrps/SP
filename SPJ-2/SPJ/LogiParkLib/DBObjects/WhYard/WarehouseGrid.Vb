Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: WarehouseGrid
    ''' @author	: Amit K. Singh- 14/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class WarehouseGrid 
    
        Private lngGridId As Long ' Define Private Variable GridId With DataType As Long 
        Private lngWarehouseId As Long ' Define Private Variable WarehouseId With DataType As Long 
        Private strWarehouseCode As String ' Define Private Variable WarehouseCode With DataType As String 
        Private strRowRefCode As String ' Define Private Variable RowRefCode With DataType As String 
        Private strColumnRefCode As String ' Define Private Variable ColumnRefCode With DataType As String 
        Private strGridCode As String ' Define Private Variable GridCode With DataType As String 
        Private lngGridSize As Long ' Define Private Variable GridSize With DataType As Long 
        Private lngGridCapacity As Long ' Define Private Variable GridCapacity With DataType As Long 
        Private strActive As String ' Define Private Variable Active With DataType As String 
        Private lngCargoRefId As Long ' Define Private Variable CargoRefId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngTerminalId As Long

        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of GridId
        ''' </summary>
        ''' <value>lngGridId</value>
        ''' <returns> Return lngGridId</returns>
        ''' <remarks> Get or Set the Value of GridId  </remarks>
        '''
        Public Property GridId() as Long
            Get
                Return lngGridId
            End Get
            Set(ByVal value As Long)
                lngGridId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of WarehouseId
        ''' </summary>
        ''' <value>lngWarehouseId</value>
        ''' <returns> Return lngWarehouseId</returns>
        ''' <remarks> Get or Set the Value of WarehouseId  </remarks>
        '''
        Public Property WarehouseId() as Long
            Get
                Return lngWarehouseId
            End Get
            Set(ByVal value As Long)
                lngWarehouseId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of WarehouseCode
        ''' </summary>
        ''' <value>strWarehouseCode</value>
        ''' <returns> Return strWarehouseCode</returns>
        ''' <remarks> Get or Set the Value of WarehouseCode  </remarks>
        '''
        Public Property WarehouseCode() as String
            Get
                Return strWarehouseCode
            End Get
            Set(ByVal value As String)
                strWarehouseCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RowRefCode
        ''' </summary>
        ''' <value>strRowRefCode</value>
        ''' <returns> Return strRowRefCode</returns>
        ''' <remarks> Get or Set the Value of RowRefCode  </remarks>
        '''
        Public Property RowRefCode() as String
            Get
                Return strRowRefCode
            End Get
            Set(ByVal value As String)
                strRowRefCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ColumnRefCode
        ''' </summary>
        ''' <value>strColumnRefCode</value>
        ''' <returns> Return strColumnRefCode</returns>
        ''' <remarks> Get or Set the Value of ColumnRefCode  </remarks>
        '''
        Public Property ColumnRefCode() as String
            Get
                Return strColumnRefCode
            End Get
            Set(ByVal value As String)
                strColumnRefCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of GridCode
        ''' </summary>
        ''' <value>strGridCode</value>
        ''' <returns> Return strGridCode</returns>
        ''' <remarks> Get or Set the Value of GridCode  </remarks>
        '''
        Public Property GridCode() as String
            Get
                Return strGridCode
            End Get
            Set(ByVal value As String)
                strGridCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of GridSize
        ''' </summary>
        ''' <value>lngGridSize</value>
        ''' <returns> Return lngGridSize</returns>
        ''' <remarks> Get or Set the Value of GridSize  </remarks>
        '''
        Public Property GridSize() as Long
            Get
                Return lngGridSize
            End Get
            Set(ByVal value As Long)
                lngGridSize = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of GridCapacity
        ''' </summary>
        ''' <value>lngGridCapacity</value>
        ''' <returns> Return lngGridCapacity</returns>
        ''' <remarks> Get or Set the Value of GridCapacity  </remarks>
        '''
        Public Property GridCapacity() as Long
            Get
                Return lngGridCapacity
            End Get
            Set(ByVal value As Long)
                lngGridCapacity = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Active
        ''' </summary>
        ''' <value>strActive</value>
        ''' <returns> Return strActive</returns>
        ''' <remarks> Get or Set the Value of Active  </remarks>
        '''
        Public Property Active() as String
            Get
                Return strActive
            End Get
            Set(ByVal value As String)
                strActive = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CargoRefId
        ''' </summary>
        ''' <value>lngCargoRefId</value>
        ''' <returns> Return lngCargoRefId</returns>
        ''' <remarks> Get or Set the Value of CargoRefId  </remarks>
        '''
        Public Property CargoRefId() As Long
            Get
                Return lngCargoRefId
            End Get
            Set(ByVal value As Long)
                lngCargoRefId = value
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
            lngGridId = 0 
            lngWarehouseId = 0 
            strWarehouseCode = ""
            strRowRefCode = ""
            strColumnRefCode = ""
            strGridCode = ""
            lngGridSize = 0 
            lngGridCapacity = 0 
            strActive = ""
            CargoRefId = 0
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pWarehouseGrid"></param>
        ''' <returns>Return pWarehouseGrid Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_GRID_ID", pWarehouseGrid.GridId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseGrid.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseGrid.WarehouseCode)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseGrid.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseGrid.ColumnRefCode)
                db.AddParameter("p_GRID_CODE", pWarehouseGrid.GridCode)
                db.AddParameter("p_GRID_SIZE", pWarehouseGrid.GridSize)
                db.AddParameter("p_GRID_CAPACITY", pWarehouseGrid.GridCapacity)
                db.AddParameter("p_ACTIVE", pWarehouseGrid.Active)
                db.AddParameter("p_TERMINAL_ID", pWarehouseGrid.TerminalId)
                db.AddParameter("p_ErrorMsg", pWarehouseGrid.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_GRID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseGrid.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pWarehouseGrid.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseGrid.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseGrid"></param>
        ''' <returns>Return pWarehouseGrid Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Try
                db.ClearParameters()
                db.AddParameter("p_GRID_ID", pWarehouseGrid.GridId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseGrid.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseGrid.WarehouseCode)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseGrid.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseGrid.ColumnRefCode)
                db.AddParameter("p_GRID_CODE", pWarehouseGrid.GridCode)
                db.AddParameter("p_GRID_SIZE", pWarehouseGrid.GridSize)
                db.AddParameter("p_GRID_CAPACITY", pWarehouseGrid.GridCapacity)
                db.AddParameter("p_ACTIVE", pWarehouseGrid.Active)
                db.AddParameter("p_TERMINAL_ID", pWarehouseGrid.TerminalId)
                db.AddParameter("p_ErrorMsg", pWarehouseGrid.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_GRID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseGrid.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pWarehouseGrid.ErrorMsg = ex.Message
            End Try
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pWarehouseGrid"></param>
        ''' <returns>Return pWarehouseGrid Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_GRID_ID", pWarehouseGrid.GridId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseGrid.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseGrid.WarehouseCode)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseGrid.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseGrid.ColumnRefCode)
                db.AddParameter("p_GRID_CODE", pWarehouseGrid.GridCode)
                db.AddParameter("p_GRID_SIZE", pWarehouseGrid.GridSize)
                db.AddParameter("p_GRID_CAPACITY", pWarehouseGrid.GridCapacity)
                db.AddParameter("p_ACTIVE", pWarehouseGrid.Active)
                db.AddParameter("p_TERMINAL_ID", pWarehouseGrid.TerminalId)
                db.AddParameter("p_ErrorMsg", pWarehouseGrid.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_GRID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseGrid.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pWarehouseGrid.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseGrid.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseGrid"></param>
        ''' <returns>Return pWarehouseGrid Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Try
                db.ClearParameters()
                db.AddParameter("p_GRID_ID", pWarehouseGrid.GridId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseGrid.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseGrid.WarehouseCode)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseGrid.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseGrid.ColumnRefCode)
                db.AddParameter("p_GRID_CODE", pWarehouseGrid.GridCode)
                db.AddParameter("p_GRID_SIZE", pWarehouseGrid.GridSize)
                db.AddParameter("p_GRID_CAPACITY", pWarehouseGrid.GridCapacity)
                db.AddParameter("p_ACTIVE", pWarehouseGrid.Active)
                db.AddParameter("p_TERMINAL_ID", pWarehouseGrid.TerminalId)
                db.AddParameter("p_ErrorMsg", pWarehouseGrid.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_GRID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseGrid.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pWarehouseGrid.ErrorMsg = ex.Message
                End Try
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pWarehouseGrid.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_ID").ToString <> "" Then
                                pWarehouseGrid.GridId = dbr("GRID_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_ID").ToString <> "" Then
                                pWarehouseGrid.WarehouseId = dbr("WAREHOUSE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_CODE").ToString <> "" Then
                                pWarehouseGrid.WarehouseCode = dbr("WAREHOUSE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROW_REF_CODE").ToString <> "" Then
                                pWarehouseGrid.RowRefCode = dbr("ROW_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF_CODE").ToString <> "" Then
                                pWarehouseGrid.ColumnRefCode = dbr("COLUMN_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_CODE").ToString <> "" Then
                                pWarehouseGrid.GridCode = dbr("GRID_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_SIZE").ToString <> "" Then
                                pWarehouseGrid.GridSize = dbr("GRID_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_CAPACITY").ToString <> "" Then
                                pWarehouseGrid.GridCapacity = dbr("GRID_CAPACITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE").ToString <> "" Then
                                pWarehouseGrid.Active = dbr("ACTIVE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_REF_ID").ToString <> "" Then
                                pWarehouseGrid.CargoRefId = dbr("CARGO_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pWarehouseGrid.ErrorMsg = ex.Message
            End Try
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrWarehouseGrid As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New WarehouseGrid
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_ID").ToString <> "" Then
                                temp.GridId = dbr("GRID_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_ID").ToString <> "" Then
                                temp.WarehouseId = dbr("WAREHOUSE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_CODE").ToString <> "" Then
                                temp.WarehouseCode = dbr("WAREHOUSE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROW_REF_CODE").ToString <> "" Then
                                temp.RowRefCode = dbr("ROW_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF_CODE").ToString <> "" Then
                                temp.ColumnRefCode = dbr("COLUMN_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_CODE").ToString <> "" Then
                                temp.GridCode = dbr("GRID_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_SIZE").ToString <> "" Then
                                temp.GridSize = dbr("GRID_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_CAPACITY").ToString <> "" Then
                                temp.GridCapacity = dbr("GRID_CAPACITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE").ToString <> "" Then
                                temp.Active = dbr("ACTIVE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_REF_ID").ToString <> "" Then
                                temp.CargoRefId = dbr("CARGO_REF_ID")
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
        ''' Preparing Return Object By TerminalId, GridId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnWarehouseGridByGridId(ByVal pWarehouseGrid As WarehouseGrid) As WarehouseGrid
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_GRID_BY_GRID_ID", pWarehouseGrid.TerminalId & "," & pWarehouseGrid.GridId)
                pWarehouseGrid = ReturnObjectValues(dbr, pWarehouseGrid)
                dbr.Close()
            Catch ex As Exception
                pWarehouseGrid.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseGrid
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnWarehouseGridList (ByVal pWarehouseGrid As WarehouseGrid) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseGrid As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_GRID", "' '")
                arrWarehouseGrid = ReturnObjectValuesList(dbr, arrWarehouseGrid)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseGrid = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseGrid
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnWarehouseGridByWhId(ByVal pWarehouseGrid As WarehouseGrid) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseGrid As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_GRID_BY_WH_ID", pWarehouseGrid.TerminalId & "," & pWarehouseGrid.WarehouseId)
                arrWarehouseGrid = ReturnObjectValuesList(dbr, arrWarehouseGrid)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseGrid = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseGrid
        End Function
    End Class
End Namespace
