Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: WarehouseMaster
    ''' @author	: Amit K. Singh- 8/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class WarehouseMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngWarehouseId As Long ' Define Private Variable WarehouseId With DataType As Long 
        Private strWarehouseCode As String ' Define Private Variable WarehouseCode With DataType As String 
        Private strWarehouseName As String ' Define Private Variable WarehouseName With DataType As String 
        Private lngNoOfRow As Long ' Define Private Variable NoOfRow With DataType As Long 
        Private lngNoOfColumn As Long ' Define Private Variable NoOfColumn With DataType As Long 
        Private strRowRefCode As String ' Define Private Variable RowRefCode With DataType As String 
        Private strColumnRefCode As String ' Define Private Variable ColumnRefCode With DataType As String 
        Private strWharehouseType As String ' Define Private Variable WharehouseType With DataType As String 
        Private strStorageType As String ' Define Private Variable StorageType With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private strActive As String ' Define Private Variable Active With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private arrGridDetails As ArrayList

        Public Enum enmDocType As Long
            I = 1
            E = 2
            D = 3
        End Enum
        Public Enum enmStorageType As Long
            A = 0
            G = 1
            H = 2
            R = 3
        End Enum
        Public Enum enmWharehouseType As Long
            O = 1
            S = 2
        End Enum

        Public Property GridDetailsList() As ArrayList
            Get
                Return arrGridDetails
            End Get
            Set(ByVal value As ArrayList)
                arrGridDetails = value
            End Set
        End Property
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
        ''' Get or Set the Value of WarehouseName
        ''' </summary>
        ''' <value>strWarehouseName</value>
        ''' <returns> Return strWarehouseName</returns>
        ''' <remarks> Get or Set the Value of WarehouseName  </remarks>
        '''
        Public Property WarehouseName() as String
            Get
                Return strWarehouseName
            End Get
            Set(ByVal value As String)
                strWarehouseName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfRow
        ''' </summary>
        ''' <value>lngNoOfRow</value>
        ''' <returns> Return lngNoOfRow</returns>
        ''' <remarks> Get or Set the Value of NoOfRow  </remarks>
        '''
        Public Property NoOfRow() as Long
            Get
                Return lngNoOfRow
            End Get
            Set(ByVal value As Long)
                lngNoOfRow = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfColumn
        ''' </summary>
        ''' <value>lngNoOfColumn</value>
        ''' <returns> Return lngNoOfColumn</returns>
        ''' <remarks> Get or Set the Value of NoOfColumn  </remarks>
        '''
        Public Property NoOfColumn() as Long
            Get
                Return lngNoOfColumn
            End Get
            Set(ByVal value As Long)
                lngNoOfColumn = value
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
        ''' Get or Set the Value of WharehouseType
        ''' </summary>
        ''' <value>strWharehouseType</value>
        ''' <returns> Return strWharehouseType</returns>
        ''' <remarks> Get or Set the Value of WharehouseType  </remarks>
        '''
        Public Property WharehouseType() as String
            Get
                Return strWharehouseType
            End Get
            Set(ByVal value As String)
                strWharehouseType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of StorageType
        ''' </summary>
        ''' <value>strStorageType</value>
        ''' <returns> Return strStorageType</returns>
        ''' <remarks> Get or Set the Value of StorageType  </remarks>
        '''
        Public Property StorageType() as String
            Get
                Return strStorageType
            End Get
            Set(ByVal value As String)
                strStorageType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() as String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
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
            lngTerminalId = 0 
            lngWarehouseId = 0 
            strWarehouseCode = ""
            strWarehouseName = ""
            lngNoOfRow = 0 
            lngNoOfColumn = 0 
            strRowRefCode = ""
            strColumnRefCode = ""
            strWharehouseType = ""
            strStorageType = ""
            strDocType = ""
            strActive = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pWarehouseMaster"></param>
        ''' <returns>Return pWarehouseMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseMaster.TerminalId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseMaster.WarehouseId, ParameterDirection.Output)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseMaster.WarehouseCode)
                db.AddParameter("p_WAREHOUSE_NAME", pWarehouseMaster.WarehouseName)
                db.AddParameter("p_NO_OF_ROW", pWarehouseMaster.NoOfRow)
                db.AddParameter("p_NO_OF_COLUMN", pWarehouseMaster.NoOfColumn)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseMaster.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseMaster.ColumnRefCode)
                db.AddParameter("p_WHAREHOUSE_TYPE", pWarehouseMaster.WharehouseType)
                db.AddParameter("p_STORAGE_TYPE", pWarehouseMaster.StorageType)
                db.AddParameter("p_DOC_TYPE", pWarehouseMaster.DocType)
                db.AddParameter("p_ACTIVE", pWarehouseMaster.Active)
                db.AddParameter("p_CREATED_BY", pWarehouseMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pWarehouseMaster.WarehouseId  = db.Parameters.Item("p_WAREHOUSE_ID").value
                
                If pWarehouseMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseMaster"></param>
        ''' <returns>Return pWarehouseMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_DOC_TYPE", pWarehouseMaster.DocType)
                db.AddParameter("p_ACTIVE", pWarehouseMaster.Active)
                db.AddParameter("p_CREATED_BY", pWarehouseMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseMaster.CreatedOn)
                db.AddParameter("p_TERMINAL_ID", pWarehouseMaster.TerminalId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseMaster.WarehouseId, ParameterDirection.Output)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseMaster.WarehouseCode)
                db.AddParameter("p_WAREHOUSE_NAME", pWarehouseMaster.WarehouseName)
                db.AddParameter("p_NO_OF_ROW", pWarehouseMaster.NoOfRow)
                db.AddParameter("p_NO_OF_COLUMN", pWarehouseMaster.NoOfColumn)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseMaster.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseMaster.ColumnRefCode)
                db.AddParameter("p_WHAREHOUSE_TYPE", pWarehouseMaster.WharehouseType)
                db.AddParameter("p_STORAGE_TYPE", pWarehouseMaster.StorageType)
                db.AddParameter("p_ErrorMsg", pWarehouseMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pWarehouseMaster.WarehouseId  = db.Parameters.Item("p_WAREHOUSE_ID").value
                
            Catch ex As Exception
                pWarehouseMaster.ErrorMsg = ex.Message
            End Try
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pWarehouseMaster"></param>
        ''' <returns>Return pWarehouseMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseMaster.TerminalId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseMaster.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseMaster.WarehouseCode)
                db.AddParameter("p_WAREHOUSE_NAME", pWarehouseMaster.WarehouseName)
                db.AddParameter("p_NO_OF_ROW", pWarehouseMaster.NoOfRow)
                db.AddParameter("p_NO_OF_COLUMN", pWarehouseMaster.NoOfColumn)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseMaster.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseMaster.ColumnRefCode)
                db.AddParameter("p_WHAREHOUSE_TYPE", pWarehouseMaster.WharehouseType)
                db.AddParameter("p_STORAGE_TYPE", pWarehouseMaster.StorageType)
                db.AddParameter("p_DOC_TYPE", pWarehouseMaster.DocType)
                db.AddParameter("p_ACTIVE", pWarehouseMaster.Active)
                db.AddParameter("p_CREATED_BY", pWarehouseMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pWarehouseMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pWarehouseMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseMaster"></param>
        ''' <returns>Return pWarehouseMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseMaster.TerminalId)
                db.AddParameter("p_WAREHOUSE_ID", pWarehouseMaster.WarehouseId)
                db.AddParameter("p_WAREHOUSE_CODE", pWarehouseMaster.WarehouseCode)
                db.AddParameter("p_WAREHOUSE_NAME", pWarehouseMaster.WarehouseName)
                db.AddParameter("p_NO_OF_ROW", pWarehouseMaster.NoOfRow)
                db.AddParameter("p_NO_OF_COLUMN", pWarehouseMaster.NoOfColumn)
                db.AddParameter("p_ROW_REF_CODE", pWarehouseMaster.RowRefCode)
                db.AddParameter("p_COLUMN_REF_CODE", pWarehouseMaster.ColumnRefCode)
                db.AddParameter("p_WHAREHOUSE_TYPE", pWarehouseMaster.WharehouseType)
                db.AddParameter("p_STORAGE_TYPE", pWarehouseMaster.StorageType)
                db.AddParameter("p_DOC_TYPE", pWarehouseMaster.DocType)
                db.AddParameter("p_ACTIVE", pWarehouseMaster.Active)
                db.AddParameter("p_CREATED_BY", pWarehouseMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pWarehouseMaster.ErrorMsg = ex.Message
                End Try
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PWarehouseMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_ID").ToString <> "" Then
                                PWarehouseMaster.WarehouseId = dbr("WAREHOUSE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_CODE").ToString <> "" Then
                                PWarehouseMaster.WarehouseCode = dbr("WAREHOUSE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WAREHOUSE_NAME").ToString <> "" Then
                                PWarehouseMaster.WarehouseName = dbr("WAREHOUSE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_ROW").ToString <> "" Then
                                PWarehouseMaster.NoOfRow = dbr("NO_OF_ROW")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_COLUMN").ToString <> "" Then
                                PWarehouseMaster.NoOfColumn = dbr("NO_OF_COLUMN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROW_REF_CODE").ToString <> "" Then
                                PWarehouseMaster.RowRefCode = dbr("ROW_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF_CODE").ToString <> "" Then
                                PWarehouseMaster.ColumnRefCode = dbr("COLUMN_REF_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WHAREHOUSE_TYPE").ToString <> "" Then
                                PWarehouseMaster.WharehouseType = dbr("WHAREHOUSE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STORAGE_TYPE").ToString <> "" Then
                                PWarehouseMaster.StorageType = dbr("STORAGE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PWarehouseMaster.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACTIVE").ToString <> "" Then
                                PWarehouseMaster.Active = dbr("ACTIVE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PWarehouseMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PWarehouseMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pWarehouseMaster.ErrorMsg = ex.Message
            End Try
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrWarehouseMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New WarehouseMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("WAREHOUSE_NAME").ToString <> "" Then
                                temp.WarehouseName = dbr("WAREHOUSE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_ROW").ToString <> "" Then
                                temp.NoOfRow = dbr("NO_OF_ROW")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_COLUMN").ToString <> "" Then
                                temp.NoOfColumn = dbr("NO_OF_COLUMN")
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
                            If dbr("WHAREHOUSE_TYPE").ToString <> "" Then
                                temp.WharehouseType = dbr("WHAREHOUSE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STORAGE_TYPE").ToString <> "" Then
                                temp.StorageType = dbr("STORAGE_TYPE")
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
                            If dbr("ACTIVE").ToString <> "" Then
                                temp.Active = dbr("ACTIVE")
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
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnWarehouseMasterById(ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_MASTER_BY_ID", pWarehouseMaster.TerminalId & "," & pWarehouseMaster.WarehouseId)
                pWarehouseMaster = ReturnObjectValues(dbr, pWarehouseMaster)
                dbr.Close()
            Catch ex As Exception
                pWarehouseMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnWarehouseMasterList (ByVal pWarehouseMaster As WarehouseMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_MASTER_BY_ALL", pWarehouseMaster.TerminalId)
                arrWarehouseMaster = ReturnObjectValuesList(dbr, arrWarehouseMaster)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseMaster = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseMaster
        End Function

        Public Shared Function InsertUpdateTransaction(ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pWarehouseMaster.WarehouseId > 0 Then
                    WarehouseMaster.UpdateTrn(db, pWarehouseMaster)
                Else
                    WarehouseMaster.InsertTrn(db, pWarehouseMaster)
                End If

                'If pWarehouseMaster.Errormsg = "" AndAlso pWarehouseMaster.WarehouseId > 0 Then
                If pWarehouseMaster.WarehouseId > 0 Then
                    For Each det As WarehouseGrid In pWarehouseMaster.GridDetailsList
                        det.WarehouseId = pWarehouseMaster.WarehouseId
                        If det.WarehouseId > 0 Then
                            WarehouseGrid.InsertTrn(db, det)
                        Else
                            WarehouseGrid.UpdateTrn(db, det)
                        End If
                        If det.Errormsg <> "" Then
                            Throw New Exception(det.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pWarehouseMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pWarehouseMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnWarehouseMasterDeatilsByGrid(ByVal pWarehouseMaster As WarehouseMaster) As WarehouseMaster
            WarehouseMaster.ReturnWarehouseMasterById(pWarehouseMaster)

            Dim pWarehouseGrid As New WarehouseGrid
            pWarehouseGrid.TerminalId = pWarehouseMaster.TerminalId
            pWarehouseGrid.WarehouseId = pWarehouseMaster.WarehouseId
            pWarehouseMaster.GridDetailsList = WarehouseGrid.ReturnWarehouseGridByWhId(pWarehouseGrid)

            Return pWarehouseMaster
        End Function

        ''' <summary>
        ''' Preparing Return ArrayList of WarehouseGrid By TerminalId, DocType, StorageType, WharehouseType
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnWarehouseFreeGridList(ByVal pWarehouseMaster As WarehouseMaster, ByVal pDocType As enmDocType, ByVal pStorageType As enmStorageType, ByVal pWharehouseType As enmWharehouseType) As ArrayList
            If enmDocType.I = pDocType Then
                pWarehouseMaster.DocType = "I"
            ElseIf enmDocType.E = pDocType Then
                pWarehouseMaster.DocType = "E"
            ElseIf enmDocType.D = pDocType Then
                pWarehouseMaster.DocType = "D"
            End If
            If enmStorageType.A = pStorageType Then
                pWarehouseMaster.StorageType = "A"
            ElseIf enmStorageType.G = pStorageType Then
                pWarehouseMaster.StorageType = "G"
            ElseIf enmStorageType.H = pStorageType Then
                pWarehouseMaster.StorageType = "H"
            ElseIf enmStorageType.R = pStorageType Then
                pWarehouseMaster.StorageType = "R"
            End If
            If enmWharehouseType.O = pWharehouseType Then
                pWarehouseMaster.WharehouseType = "O"
            ElseIf enmWharehouseType.S = pWharehouseType Then
                pWarehouseMaster.WharehouseType = "S"
            
            End If
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseGrid As New ArrayList
            Try
                db.ClearParameters()

                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_FREE_GRID", pWarehouseMaster.TerminalId & ",'" & pWarehouseMaster.DocType & "','" & pWarehouseMaster.StorageType & "','" & pWarehouseMaster.WharehouseType & "'")
                arrWarehouseGrid = WarehouseGrid.ReturnObjectValuesList(dbr, arrWarehouseGrid)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseGrid = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseGrid
        End Function
    End Class
End Namespace
