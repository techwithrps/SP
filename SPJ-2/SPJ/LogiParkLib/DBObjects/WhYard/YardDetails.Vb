Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: YardDetails
    ''' @author	: Amit K. Singh- 1/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class YardDetails 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngYardId As Long ' Define Private Variable YardId With DataType As Long 
        Private strYardCode As String ' Define Private Variable YardCode With DataType As String 
        Private lngBlockId As Long ' Define Private Variable BlockId With DataType As Long 
        Private strBlockRef As String ' Define Private Variable BlockRef With DataType As String 
        Private strLaneRef As String ' Define Private Variable LaneRef With DataType As String 
        Private strColumnRef As String ' Define Private Variable ColumnRef With DataType As String 
        Private lngStack As Long ' Define Private Variable Stack With DataType As Long 
        Private lngContId As Long ' Define Private Variable ContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strStatus As String ' Define Private Variable Status With DataType As String 
        Private strEqipPosition As String ' Define Private Variable EqipPosition With DataType As String 
        Private lngEquipmentId As Long    ' Define Private Variable EquipmentId With DataType As Long  
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
        ''' Get or Set the Value of BlockId
        ''' </summary>
        ''' <value>lngBlockId</value>
        ''' <returns> Return lngBlockId</returns>
        ''' <remarks> Get or Set the Value of BlockId  </remarks>
        '''
        Public Property BlockId() as Long
            Get
                Return lngBlockId
            End Get
            Set(ByVal value As Long)
                lngBlockId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BlockRef
        ''' </summary>
        ''' <value>strBlockRef</value>
        ''' <returns> Return strBlockRef</returns>
        ''' <remarks> Get or Set the Value of BlockRef  </remarks>
        '''
        Public Property BlockRef() as String
            Get
                Return strBlockRef
            End Get
            Set(ByVal value As String)
                strBlockRef = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LaneRef
        ''' </summary>
        ''' <value>strLaneRef</value>
        ''' <returns> Return strLaneRef</returns>
        ''' <remarks> Get or Set the Value of LaneRef  </remarks>
        '''
        Public Property LaneRef() as String
            Get
                Return strLaneRef
            End Get
            Set(ByVal value As String)
                strLaneRef = value
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
        ''' Get or Set the Value of Stack
        ''' </summary>
        ''' <value>lngStack</value>
        ''' <returns> Return lngStack</returns>
        ''' <remarks> Get or Set the Value of Stack  </remarks>
        '''
        Public Property Stack() as Long
            Get
                Return lngStack
            End Get
            Set(ByVal value As Long)
                lngStack = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContId
        ''' </summary>
        ''' <value>lngContId</value>
        ''' <returns> Return lngContId</returns>
        ''' <remarks> Get or Set the Value of ContId  </remarks>
        '''
        Public Property ContId() as Long
            Get
                Return lngContId
            End Get
            Set(ByVal value As Long)
                lngContId = value
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
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property Status() as String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property EqipPosition() As String
            Get
                Return strEqipPosition
            End Get
            Set(ByVal value As String)
                strEqipPosition = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of EquipmentId
        ''' </summary>
        ''' <value>lngEquipmentId</value>
        ''' <returns> Return lngEquipmentId</returns>
        ''' <remarks> Get or Set the Value of EquipmentId </remarks>
        '''
        Public Property EquipmentId() As Long
            Get
                Return lngEquipmentId
            End Get
            Set(ByVal value As Long)
                lngEquipmentId = value
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
            lngBlockId = 0 
            strBlockRef = ""
            strLaneRef = ""
            strColumnRef = ""
            lngStack = 0 
            lngContId = 0 
            strContNo = ""
            strStatus = ""
            strEqipPosition = ""
            lngEquipmentId = 0
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pYardDetails"></param>
        ''' <returns>Return pYardDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pYardDetails As YardDetails) As YardDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardDetails.TerminalId)
                db.AddParameter("p_YARD_ID", pYardDetails.YardId)
                db.AddParameter("p_YARD_CODE", pYardDetails.YardCode)
                db.AddParameter("p_BLOCK_ID", pYardDetails.BlockId, ParameterDirection.Output)
                db.AddParameter("p_BLOCK_REF", pYardDetails.BlockRef)
                db.AddParameter("p_LANE_REF", pYardDetails.LaneRef)
                db.AddParameter("p_COLUMN_REF", pYardDetails.ColumnRef)
                db.AddParameter("p_STACK", pYardDetails.Stack)
                db.AddParameter("p_CONT_ID", pYardDetails.ContId)
                db.AddParameter("p_CONT_NO", pYardDetails.ContNo)
                db.AddParameter("p_STATUS", pYardDetails.Status)
                db.AddParameter("p_EQIP_POSITION", pYardDetails.EqipPosition)
                db.AddParameter("p_EQUIPMENT_ID", pYardDetails.EquipmentId)
                db.AddParameter("p_ErrorMsg", pYardDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_YARD_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pYardDetails.BlockId  = db.Parameters.Item("p_BLOCK_ID").value
                
                If pYardDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pYardDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pYardDetails"></param>
        ''' <returns>Return pYardDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pYardDetails As YardDetails) As YardDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardDetails.TerminalId)
                db.AddParameter("p_YARD_ID", pYardDetails.YardId)
                db.AddParameter("p_YARD_CODE", pYardDetails.YardCode)
                db.AddParameter("p_BLOCK_ID", pYardDetails.BlockId, ParameterDirection.Output)
                db.AddParameter("p_BLOCK_REF", pYardDetails.BlockRef)
                db.AddParameter("p_LANE_REF", pYardDetails.LaneRef)
                db.AddParameter("p_COLUMN_REF", pYardDetails.ColumnRef)
                db.AddParameter("p_STACK", pYardDetails.Stack)
                db.AddParameter("p_CONT_ID", pYardDetails.ContId)
                db.AddParameter("p_CONT_NO", pYardDetails.ContNo)
                db.AddParameter("p_STATUS", pYardDetails.Status)
                db.AddParameter("p_EQIP_POSITION", pYardDetails.EqipPosition)
                'db.AddParameter("p_EQUIPMENT_ID", pYardDetails.EquipmentId)
                db.AddParameter("p_ErrorMsg", pYardDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_YARD_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pYardDetails.BlockId  = db.Parameters.Item("p_BLOCK_ID").value
                
            Catch ex As Exception
                pYardDetails.ErrorMsg = ex.Message
            End Try
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pYardDetails"></param>
        ''' <returns>Return pYardDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pYardDetails As YardDetails) As YardDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardDetails.TerminalId)
                db.AddParameter("p_YARD_ID", pYardDetails.YardId)
                db.AddParameter("p_YARD_CODE", pYardDetails.YardCode)
                db.AddParameter("p_BLOCK_ID", pYardDetails.BlockId)
                db.AddParameter("p_BLOCK_REF", pYardDetails.BlockRef)
                db.AddParameter("p_LANE_REF", pYardDetails.LaneRef)
                db.AddParameter("p_COLUMN_REF", pYardDetails.ColumnRef)
                db.AddParameter("p_STACK", pYardDetails.Stack)
                db.AddParameter("p_CONT_ID", pYardDetails.ContId)
                db.AddParameter("p_CONT_NO", pYardDetails.ContNo)
                db.AddParameter("p_STATUS", pYardDetails.Status)
                db.AddParameter("p_EQIP_POSITION", pYardDetails.EqipPosition)
                db.AddParameter("p_EQUIPMENT_ID", pYardDetails.EquipmentId)
                db.AddParameter("p_ErrorMsg", pYardDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_YARD_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pYardDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pYardDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pYardDetails"></param>
        ''' <returns>Return pYardDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pYardDetails As YardDetails) As YardDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pYardDetails.TerminalId)
                db.AddParameter("p_YARD_ID", pYardDetails.YardId)
                db.AddParameter("p_YARD_CODE", pYardDetails.YardCode)
                db.AddParameter("p_BLOCK_ID", pYardDetails.BlockId)
                db.AddParameter("p_BLOCK_REF", pYardDetails.BlockRef)
                db.AddParameter("p_LANE_REF", pYardDetails.LaneRef)
                db.AddParameter("p_COLUMN_REF", pYardDetails.ColumnRef)
                db.AddParameter("p_STACK", pYardDetails.Stack)
                db.AddParameter("p_CONT_ID", pYardDetails.ContId)
                db.AddParameter("p_CONT_NO", pYardDetails.ContNo)
                db.AddParameter("p_STATUS", pYardDetails.Status)
                db.AddParameter("p_EQIP_POSITION", pYardDetails.EqipPosition)
                db.AddParameter("p_EQUIPMENT_ID", pYardDetails.EquipmentId)
                db.AddParameter("p_ErrorMsg", pYardDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_YARD_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pYardDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pYardDetails.ErrorMsg = ex.Message
                End Try
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pYardDetails As YardDetails) As YardDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PYardDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_ID").ToString <> "" Then
                                PYardDetails.YardId = dbr("YARD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("YARD_CODE").ToString <> "" Then
                                PYardDetails.YardCode = dbr("YARD_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BLOCK_ID").ToString <> "" Then
                                PYardDetails.BlockId = dbr("BLOCK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BLOCK_REF").ToString <> "" Then
                                PYardDetails.BlockRef = dbr("BLOCK_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LANE_REF").ToString <> "" Then
                                PYardDetails.LaneRef = dbr("LANE_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COLUMN_REF").ToString <> "" Then
                                PYardDetails.ColumnRef = dbr("COLUMN_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STACK").ToString <> "" Then
                                PYardDetails.Stack = dbr("STACK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                PYardDetails.ContId = dbr("CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PYardDetails.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                PYardDetails.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQIP_POSITION").ToString <> "" Then
                                pYardDetails.EqipPosition = dbr("EQIP_POSITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                pYardDetails.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pYardDetails.ErrorMsg = ex.Message
            End Try
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrYardDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New YardDetails
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
                            If dbr("BLOCK_ID").ToString <> "" Then
                                temp.BlockId = dbr("BLOCK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BLOCK_REF").ToString <> "" Then
                                temp.BlockRef = dbr("BLOCK_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LANE_REF").ToString <> "" Then
                                temp.LaneRef = dbr("LANE_REF")
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
                            If dbr("STACK").ToString <> "" Then
                                temp.Stack = dbr("STACK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                temp.ContId = dbr("CONT_ID")
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
                            If dbr("STATUS").ToString <> "" Then
                                temp.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQIP_POSITION").ToString <> "" Then
                                temp.EqipPosition = dbr("EQIP_POSITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                temp.EquipmentId = dbr("EQUIPMENT_ID")
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
        ''' Preparing Return Object By TerminalId, YardId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnFreeBlock(ByVal pYardDetails As YardDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_FREE_BLOCK", pYardDetails.TerminalId & "," & pYardDetails.YardId & ", '" & pYardDetails.Status & "'")
                arrYardDetails = ReturnObjectValuesList(dbr, arrYardDetails)
                dbr.Close()
            Catch ex As Exception
                arrYardDetails = Nothing
            End Try
            db.CloseDB()
            Return arrYardDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, YardId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnYardDetails(ByVal pYardDetails As YardDetails) As YardDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_BY_ID_ALL", "' '")
                pYardDetails = ReturnObjectValues(dbr, pYardDetails)
                dbr.Close()
            Catch ex As Exception
                pYardDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object By TerminalId, BlockId, ContId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnYardDetailsByBlockId(ByVal pYardDetails As YardDetails) As YardDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_BY_BLOCK_ID", pYardDetails.TerminalId & "," & pYardDetails.BlockId & "," & pYardDetails.ContId)
                pYardDetails = ReturnObjectValues(dbr, pYardDetails)
                dbr.Close()
            Catch ex As Exception
                pYardDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pYardDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnYardDetailsByYardId(ByVal pYardDetails As YardDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_BY_ID_ALL", pYardDetails.TerminalId & "," & pYardDetails.YardId)
                arrYardDetails = ReturnObjectValuesList(dbr, arrYardDetails)
                dbr.Close()
            Catch ex As Exception
                arrYardDetails = Nothing
            End Try
            db.CloseDB()
            Return arrYardDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, YardId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnYardDetailsListByYardId(ByVal pYardDetails As YardDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_BY_ID_ALL", pYardDetails.TerminalId & "," & pYardDetails.YardId)
                arrYardDetails = ReturnObjectValuesList(dbr, arrYardDetails)
                dbr.Close()
            Catch ex As Exception
                arrYardDetails = Nothing
            End Try
            db.CloseDB()
            Return arrYardDetails
        End Function
    End Class
End Namespace
