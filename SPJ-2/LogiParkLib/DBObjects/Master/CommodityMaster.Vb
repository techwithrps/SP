Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CommodityMaster
    ''' @author	: Amit K. Singh- 3/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CommodityMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngCommodityId As Long ' Define Private Variable CommodityId With DataType As Long 
        Private strCommodityCode As String ' Define Private Variable CommodityCode With DataType As String 
        Private strCommodityName As String ' Define Private Variable CommodityName With DataType As String 
        Private strCommodityType As String ' Define Private Variable CommodityType With DataType As String 
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
        ''' Get or Set the Value of CommodityCode
        ''' </summary>
        ''' <value>strCommodityCode</value>
        ''' <returns> Return strCommodityCode</returns>
        ''' <remarks> Get or Set the Value of CommodityCode  </remarks>
        '''
        Public Property CommodityCode() as String
            Get
                Return strCommodityCode
            End Get
            Set(ByVal value As String)
                strCommodityCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CommodityName
        ''' </summary>
        ''' <value>strCommodityName</value>
        ''' <returns> Return strCommodityName</returns>
        ''' <remarks> Get or Set the Value of CommodityName  </remarks>
        '''
        Public Property CommodityName() as String
            Get
                Return strCommodityName
            End Get
            Set(ByVal value As String)
                strCommodityName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CommodityType
        ''' </summary>
        ''' <value>strCommodityType</value>
        ''' <returns> Return strCommodityType</returns>
        ''' <remarks> Get or Set the Value of CommodityType  </remarks>
        '''
        Public Property CommodityType() As String
            Get
                Return strCommodityType
            End Get
            Set(ByVal value As String)
                strCommodityType = value
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
            lngCommodityId = 0 
            strCommodityCode = ""
            strCommodityName = ""
            strCommodityType = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCommodityMaster"></param>
        ''' <returns>Return pCommodityMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCommodityMaster.TerminalId)
                db.AddParameter("p_COMMODITY_ID", pCommodityMaster.CommodityId, ParameterDirection.Output)
                db.AddParameter("p_COMMODITY_CODE", pCommodityMaster.CommodityCode)
                db.AddParameter("p_COMMODITY_NAME", pCommodityMaster.CommodityName)
                db.AddParameter("p_COMMODITY_TYPE", pCommodityMaster.CommodityType)
                db.AddParameter("p_CREATED_BY", pCommodityMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCommodityMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCommodityMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMMODITY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCommodityMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCommodityMaster.CommodityId  = db.Parameters.Item("p_COMMODITY_ID").value
                
                If pCommodityMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCommodityMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCommodityMaster"></param>
        ''' <returns>Return pCommodityMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCommodityMaster.TerminalId)
                db.AddParameter("p_COMMODITY_ID", pCommodityMaster.CommodityId, ParameterDirection.Output)
                db.AddParameter("p_COMMODITY_CODE", pCommodityMaster.CommodityCode)
                db.AddParameter("p_COMMODITY_NAME", pCommodityMaster.CommodityName)
                db.AddParameter("p_COMMODITY_TYPE", pCommodityMaster.CommodityType)
                db.AddParameter("p_CREATED_BY", pCommodityMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCommodityMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCommodityMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMMODITY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCommodityMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCommodityMaster.CommodityId  = db.Parameters.Item("p_COMMODITY_ID").value
                
            Catch ex As Exception
                pCommodityMaster.ErrorMsg = ex.Message
            End Try
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCommodityMaster"></param>
        ''' <returns>Return pCommodityMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCommodityMaster.TerminalId)
                db.AddParameter("p_COMMODITY_ID", pCommodityMaster.CommodityId)
                db.AddParameter("p_COMMODITY_CODE", pCommodityMaster.CommodityCode)
                db.AddParameter("p_COMMODITY_NAME", pCommodityMaster.CommodityName)
                db.AddParameter("p_COMMODITY_TYPE", pCommodityMaster.CommodityType)
                db.AddParameter("p_CREATED_BY", pCommodityMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCommodityMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCommodityMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMMODITY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCommodityMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCommodityMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCommodityMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCommodityMaster"></param>
        ''' <returns>Return pCommodityMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCommodityMaster.TerminalId)
                db.AddParameter("p_COMMODITY_ID", pCommodityMaster.CommodityId)
                db.AddParameter("p_COMMODITY_CODE", pCommodityMaster.CommodityCode)
                db.AddParameter("p_COMMODITY_NAME", pCommodityMaster.CommodityName)
                db.AddParameter("p_COMMODITY_TYPE", pCommodityMaster.CommodityType)
                db.AddParameter("p_CREATED_BY", pCommodityMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pCommodityMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pCommodityMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMMODITY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCommodityMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCommodityMaster.ErrorMsg = ex.Message
                End Try
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCommodityMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_ID").ToString <> "" Then
                                PCommodityMaster.CommodityId = dbr("COMMODITY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_CODE").ToString <> "" Then
                                PCommodityMaster.CommodityCode = dbr("COMMODITY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_NAME").ToString <> "" Then
                                PCommodityMaster.CommodityName = dbr("COMMODITY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_TYPE").ToString <> "" Then
                                pCommodityMaster.CommodityType = dbr("COMMODITY_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PCommodityMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PCommodityMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCommodityMaster.ErrorMsg = ex.Message
            End Try
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCommodityMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CommodityMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("COMMODITY_CODE").ToString <> "" Then
                                temp.CommodityCode = dbr("COMMODITY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_NAME").ToString <> "" Then
                                temp.CommodityName = dbr("COMMODITY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMMODITY_NAME").ToString <> "" Then
                                temp.CommodityName = dbr("COMMODITY_NAME")
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
        Public Shared Function ReturnCommodityMaster(ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMMODITY_MASTER_BY_ID", pCommodityMaster.TerminalId & "," & pCommodityMaster.CommodityId)
                pCommodityMaster = ReturnObjectValues(dbr, pCommodityMaster)
                dbr.Close()
            Catch ex As Exception
                pCommodityMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCommodityMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCommodityMasterAll(ByVal pCommodityMaster As CommodityMaster) As CommodityMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMMODITY_MASTER_BY_ID_ALL", pCommodityMaster.CommodityId)
                pCommodityMaster = ReturnObjectValues(dbr, pCommodityMaster)
                dbr.Close()
            Catch ex As Exception
                pCommodityMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCommodityMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCommodityMasterList (ByVal pCommodityMaster As CommodityMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCommodityMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMMODITY_MASTER_ALL", pCommodityMaster.TerminalId)
                arrCommodityMaster = ReturnObjectValuesList(dbr, arrCommodityMaster)
                dbr.Close()
            Catch ex As Exception
                arrCommodityMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCommodityMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCommodityMasterListDo(ByVal pCommodityMaster As CommodityMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCommodityMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMMODITY_MASTER_ALL_DO", "")
                arrCommodityMaster = ReturnObjectValuesList(dbr, arrCommodityMaster)
                dbr.Close()
            Catch ex As Exception
                arrCommodityMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCommodityMaster
        End Function
    End Class
End Namespace
