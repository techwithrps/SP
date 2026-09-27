Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: YardMaster
    ''' @author	: Amit K. Singh- 1/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class YardMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngYardId As Long ' Define Private Variable YardId With DataType As Long 
        Private strYardCode As String ' Define Private Variable YardCode With DataType As String 
        Private strYardName As String ' DefineF Private Variable YardName With DataType As String 
        Private lngNoOfRows As Long ' Define Private Variable NoOfRows With DataType As Long 
        Private lngNoOfColumns As Long ' Define Private Variable NoOfColumns With DataType As Long 
        Private strRowRef As String ' Define Private Variable RowRef With DataType As String 
        Private strColumnRef As String ' Define Private Variable ColumnRef With DataType As String 
        Private lngStacks As Long ' Define Private Variable Stacks With DataType As Long 
        Private lngPowerPlugs As Long ' Define Private Variable PowerPlugs With DataType As Long 
        Private strYardType As String ' Define Private Variable YardType With DataType As String 
        Private lngDockType As Long ' Define Private Variable DockType With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private arrYardDetails As ArrayList

        Public Property GridDetailsList() As ArrayList
            Get
                Return arrYardDetails
            End Get
            Set(ByVal value As ArrayList)
                arrYardDetails = value
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
        ''' Get or Set the Value of YardId
        ''' </summary>
        ''' <value>lngYardId</value>
        ''' <returns> Return lngYardId</returns>
        ''' <remarks> Get or Set the Value of YardId  </remarks>
        '''
        Public Property YardId() as Long
            Get
                Return lngYardId
            End Get
            Set(ByVal value As Long)
                lngYardId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of YardCode
        ''' </summary>
        ''' <value>strYardCode</value>
        ''' <returns> Return strYardCode</returns>
        ''' <remarks> Get or Set the Value of YardCode  </remarks>
        '''
        Public Property YardCode() as String
            Get
                Return strYardCode
            End Get
            Set(ByVal value As String)
                strYardCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of YardName
        ''' </summary>
        ''' <value>strYardName</value>
        ''' <returns> Return strYardName</returns>
        ''' <remarks> Get or Set the Value of YardName  </remarks>
        '''
        Public Property YardName() as String
            Get
                Return strYardName
            End Get
            Set(ByVal value As String)
                strYardName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfRows
        ''' </summary>
        ''' <value>lngNoOfRows</value>
        ''' <returns> Return lngNoOfRows</returns>
        ''' <remarks> Get or Set the Value of NoOfRows  </remarks>
        '''
        Public Property NoOfRows() as Long
            Get
                Return lngNoOfRows
            End Get
            Set(ByVal value As Long)
                lngNoOfRows = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfColumns
        ''' </summary>
        ''' <value>lngNoOfColumns</value>
        ''' <returns> Return lngNoOfColumns</returns>
        ''' <remarks> Get or Set the Value of NoOfColumns  </remarks>
        '''
        Public Property NoOfColumns() as Long
            Get
                Return lngNoOfColumns
            End Get
            Set(ByVal value As Long)
                lngNoOfColumns = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of RowRef
        ''' </summary>
        ''' <value>strRowRef</value>
        ''' <returns> Return strRowRef</returns>
        ''' <remarks> Get or Set the Value of RowRef  </remarks>
        '''
        Public Property RowRef() as String
            Get
                Return strRowRef
            End Get
            Set(ByVal value As String)
                strRowRef = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ColumnRef
        ''' </summary>
        ''' <value>strColumnRef</value>
        ''' <returns> Return strColumnRef</returns>
        ''' <remarks> Get or Set the Value of ColumnRef  </remarks>
        '''
        Public Property ColumnRef() as String
            Get
                Return strColumnRef
            End Get
            Set(ByVal value As String)
                strColumnRef = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Stacks
        ''' </summary>
        ''' <value>lngStacks</value>
        ''' <returns> Return lngStacks</returns>
        ''' <remarks> Get or Set the Value of Stacks  </remarks>
        '''
        Public Property Stacks() as Long
            Get
                Return lngStacks
            End Get
            Set(ByVal value As Long)
                lngStacks = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PowerPlugs
        ''' </summary>
        ''' <value>lngPowerPlugs</value>
        ''' <returns> Return lngPowerPlugs</returns>
        ''' <remarks> Get or Set the Value of PowerPlugs  </remarks>
        '''
        Public Property PowerPlugs() as Long
            Get
                Return lngPowerPlugs
            End Get
            Set(ByVal value As Long)
                lngPowerPlugs = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of YardType
        ''' </summary>
        ''' <value>strYardType</value>
        ''' <returns> Return strYardType</returns>
        ''' <remarks> Get or Set the Value of YardType  </remarks>
        '''
        Public Property YardType() as String
            Get
                Return strYardType
            End Get
            Set(ByVal value As String)
                strYardType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DockType
        ''' </summary>
        ''' <value>lngDockType</value>
        ''' <returns> Return lngDockType</returns>
        ''' <remarks> Get or Set the Value of DockType  </remarks>
        '''
        Public Property DockType() as Long
            Get
                Return lngDockType
            End Get
            Set(ByVal value As Long)
                lngDockType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() as Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
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
            lngYardId = 0 
            strYardCode = ""
            strYardName = ""
            lngNoOfRows = 0 
            lngNoOfColumns = 0 
            strRowRef = ""
            strColumnRef = ""
            lngStacks = 0 
            lngPowerPlugs = 0 
            strYardType = ""
            lngDockType = 0 
            lngLineId = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pYardMaster"></param>
        ''' <returns>Return pYardMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pYardMaster As YardMaster) As YardMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardMaster.TerminalId)
                db.AddParameter("p_YARD_ID", pYardMaster.YardId, ParameterDirection.Output)
                db.AddParameter("p_YARD_CODE", pYardMaster.YardCode)
                db.AddParameter("p_YARD_NAME", pYardMaster.YardName)
                db.AddParameter("p_NO_OF_ROWS", pYardMaster.NoOfRows)
                db.AddParameter("p_NO_OF_COLUMNS", pYardMaster.NoOfColumns)
                db.AddParameter("p_ROW_REF", pYardMaster.RowRef)
                db.AddParameter("p_COLUMN_REF", pYardMaster.ColumnRef)
                db.AddParameter("p_STACKS", pYardMaster.Stacks)
                db.AddParameter("p_POWER_PLUGS", pYardMaster.PowerPlugs)
                db.AddParameter("p_YARD_TYPE", pYardMaster.YardType)
                db.AddParameter("p_DOCK_TYPE", pYardMaster.DockType)
                db.AddParameter("p_LINE_ID", pYardMaster.LineId)
                db.AddParameter("p_CREATED_BY", pYardMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pYardMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pYardMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_YARD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pYardMaster.YardId  = db.Parameters.Item("p_YARD_ID").value
                
                If pYardMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pYardMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pYardMaster"></param>
        ''' <returns>Return pYardMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pYardMaster As YardMaster) As YardMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardMaster.TerminalId)
                db.AddParameter("p_YARD_ID", pYardMaster.YardId, ParameterDirection.Output)
                db.AddParameter("p_YARD_CODE", pYardMaster.YardCode)
                db.AddParameter("p_YARD_NAME", pYardMaster.YardName)
                db.AddParameter("p_NO_OF_ROWS", pYardMaster.NoOfRows)
                db.AddParameter("p_NO_OF_COLUMNS", pYardMaster.NoOfColumns)
                db.AddParameter("p_ROW_REF", pYardMaster.RowRef)
                db.AddParameter("p_COLUMN_REF", pYardMaster.ColumnRef)
                db.AddParameter("p_STACKS", pYardMaster.Stacks)
                db.AddParameter("p_POWER_PLUGS", pYardMaster.PowerPlugs)
                db.AddParameter("p_YARD_TYPE", pYardMaster.YardType)
                db.AddParameter("p_DOCK_TYPE", pYardMaster.DockType)
                db.AddParameter("p_LINE_ID", pYardMaster.LineId)
                db.AddParameter("p_CREATED_BY", pYardMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pYardMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pYardMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_YARD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pYardMaster.YardId  = db.Parameters.Item("p_YARD_ID").value
                
            Catch ex As Exception
                pYardMaster.ErrorMsg = ex.Message
            End Try
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pYardMaster"></param>
        ''' <returns>Return pYardMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pYardMaster As YardMaster) As YardMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardMaster.TerminalId)
                db.AddParameter("p_YARD_ID", pYardMaster.YardId)
                db.AddParameter("p_YARD_CODE", pYardMaster.YardCode)
                db.AddParameter("p_YARD_NAME", pYardMaster.YardName)
                db.AddParameter("p_NO_OF_ROWS", pYardMaster.NoOfRows)
                db.AddParameter("p_NO_OF_COLUMNS", pYardMaster.NoOfColumns)
                db.AddParameter("p_ROW_REF", pYardMaster.RowRef)
                db.AddParameter("p_COLUMN_REF", pYardMaster.ColumnRef)
                db.AddParameter("p_STACKS", pYardMaster.Stacks)
                db.AddParameter("p_POWER_PLUGS", pYardMaster.PowerPlugs)
                db.AddParameter("p_YARD_TYPE", pYardMaster.YardType)
                db.AddParameter("p_DOCK_TYPE", pYardMaster.DockType)
                db.AddParameter("p_LINE_ID", pYardMaster.LineId)
                db.AddParameter("p_CREATED_BY", pYardMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pYardMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pYardMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_YARD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pYardMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pYardMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pYardMaster"></param>
        ''' <returns>Return pYardMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pYardMaster As YardMaster) As YardMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardMaster.TerminalId)
                db.AddParameter("p_YARD_ID", pYardMaster.YardId)
                db.AddParameter("p_YARD_CODE", pYardMaster.YardCode)
                db.AddParameter("p_YARD_NAME", pYardMaster.YardName)
                db.AddParameter("p_NO_OF_ROWS", pYardMaster.NoOfRows)
                db.AddParameter("p_NO_OF_COLUMNS", pYardMaster.NoOfColumns)
                db.AddParameter("p_ROW_REF", pYardMaster.RowRef)
                db.AddParameter("p_COLUMN_REF", pYardMaster.ColumnRef)
                db.AddParameter("p_STACKS", pYardMaster.Stacks)
                db.AddParameter("p_POWER_PLUGS", pYardMaster.PowerPlugs)
                db.AddParameter("p_YARD_TYPE", pYardMaster.YardType)
                db.AddParameter("p_DOCK_TYPE", pYardMaster.DockType)
                db.AddParameter("p_LINE_ID", pYardMaster.LineId)
                db.AddParameter("p_CREATED_BY", pYardMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pYardMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pYardMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_YARD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pYardMaster.ErrorMsg = ex.Message
                End Try
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pYardMaster As YardMaster) As YardMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PYardMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_ID").ToString <> "" Then
                                PYardMaster.YardId = dbr("YARD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_CODE").ToString <> "" Then
                                PYardMaster.YardCode = dbr("YARD_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_NAME").ToString <> "" Then
                                PYardMaster.YardName = dbr("YARD_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_ROWS").ToString <> "" Then
                                PYardMaster.NoOfRows = dbr("NO_OF_ROWS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_COLUMNS").ToString <> "" Then
                                PYardMaster.NoOfColumns = dbr("NO_OF_COLUMNS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROW_REF").ToString <> "" Then
                                PYardMaster.RowRef = dbr("ROW_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF").ToString <> "" Then
                                PYardMaster.ColumnRef = dbr("COLUMN_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STACKS").ToString <> "" Then
                                PYardMaster.Stacks = dbr("STACKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POWER_PLUGS").ToString <> "" Then
                                PYardMaster.PowerPlugs = dbr("POWER_PLUGS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_TYPE").ToString <> "" Then
                                PYardMaster.YardType = dbr("YARD_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOCK_TYPE").ToString <> "" Then
                                PYardMaster.DockType = dbr("DOCK_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PYardMaster.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PYardMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PYardMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pYardMaster.ErrorMsg = ex.Message
            End Try
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrYardMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New YardMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_ID").ToString <> "" Then
                                temp.YardId = dbr("YARD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_CODE").ToString <> "" Then
                                temp.YardCode = dbr("YARD_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_NAME").ToString <> "" Then
                                temp.YardName = dbr("YARD_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_ROWS").ToString <> "" Then
                                temp.NoOfRows = dbr("NO_OF_ROWS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_COLUMNS").ToString <> "" Then
                                temp.NoOfColumns = dbr("NO_OF_COLUMNS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROW_REF").ToString <> "" Then
                                temp.RowRef = dbr("ROW_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF").ToString <> "" Then
                                temp.ColumnRef = dbr("COLUMN_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STACKS").ToString <> "" Then
                                temp.Stacks = dbr("STACKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POWER_PLUGS").ToString <> "" Then
                                temp.PowerPlugs = dbr("POWER_PLUGS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_TYPE").ToString <> "" Then
                                temp.YardType = dbr("YARD_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOCK_TYPE").ToString <> "" Then
                                temp.DockType = dbr("DOCK_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
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
        ''' Preparing Return Object By Terminal_id, YardId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnYardMasterByYardId(ByVal pYardMaster As YardMaster) As YardMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_MASTER_BY_YARD_ID", pYardMaster.TerminalId & "," & pYardMaster.YardId)
                pYardMaster = ReturnObjectValues(dbr, pYardMaster)
                dbr.Close()
            Catch ex As Exception
                pYardMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnYardMasterList (ByVal pYardMaster As YardMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_MASTER_ALL", pYardMaster.TerminalId)
                arrYardMaster = ReturnObjectValuesList(dbr, arrYardMaster)
                dbr.Close()
            Catch ex As Exception
                arrYardMaster = Nothing
            End Try
            db.CloseDB()
            Return arrYardMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnYardMasterById(ByVal pYardMaster As YardMaster) As YardMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_MASTER_BY_YARD_ID", pYardMaster.TerminalId & "," & pYardMaster.YardId)
                pYardMaster = ReturnObjectValues(dbr, pYardMaster)
                dbr.Close()
            Catch ex As Exception
                pYardMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pYardMaster
        End Function

        Public Shared Function InsertUpdateTransaction(ByVal pYardMaster As YardMaster) As YardMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                If pYardMaster.YardId > 0 Then
                    YardMaster.UpdateTrn(db, pYardMaster)
                Else
                    YardMaster.InsertTrn(db, pYardMaster)
                End If

                'If pWarehouseMaster.Errormsg = "" AndAlso pWarehouseMaster.WarehouseId > 0 Then
                If pYardMaster.YardId > 0 Then
                    For Each det As YardDetails In pYardMaster.GridDetailsList
                        det.YardId = pYardMaster.YardId
                        If det.YardId > 0 Then
                            YardDetails.InsertTrn(db, det)
                        Else
                            YardDetails.UpdateTrn(db, det)
                        End If
                        If det.Errormsg <> "" Then
                            Throw New Exception(det.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pYardMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pYardMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pYardMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnYardMasterDeatilsByGrid(ByVal pYardMaster As YardMaster) As YardMaster
            YardMaster.ReturnYardMasterById(pYardMaster)

            Dim pYardDetails As New YardDetails
            pYardDetails.YardId = pYardMaster.YardId
            pYardMaster.GridDetailsList = YardDetails.ReturnYardDetailsByYardId(pYardDetails)

            Return pYardMaster
        End Function

    End Class
End Namespace
