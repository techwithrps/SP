Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TaxHeadMaster
    ''' @author	: Amit K. Singh- 9/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TaxHeadMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngTaxHeadId As Long ' Define Private Variable TaxHeadId With DataType As Long 
        Private strTaxHeadName As String ' Define Private Variable TaxHeadName With DataType As String 
        Private strMapCode As String ' Define Private Variable MapCode With DataType As String 
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
        ''' Get or Set the Value of TaxHeadName
        ''' </summary>
        ''' <value>strTaxHeadName</value>
        ''' <returns> Return strTaxHeadName</returns>
        ''' <remarks> Get or Set the Value of TaxHeadName  </remarks>
        '''
        Public Property TaxHeadName() as String
            Get
                Return strTaxHeadName
            End Get
            Set(ByVal value As String)
                strTaxHeadName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MapCode
        ''' </summary>
        ''' <value>strMapCode</value>
        ''' <returns> Return strMapCode</returns>
        ''' <remarks> Get or Set the Value of MapCode  </remarks>
        '''
        Public Property MapCode() as String
            Get
                Return strMapCode
            End Get
            Set(ByVal value As String)
                strMapCode = value
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
            lngTaxHeadId = 0 
            strTaxHeadName = ""
            strMapCode = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTaxHeadMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxHeadMaster.TerminalId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxHeadMaster.TaxHeadId, ParameterDirection.Output)
                db.AddParameter("p_TAX_HEAD_NAME", pTaxHeadMaster.TaxHeadName)
                db.AddParameter("p_MAP_CODE", pTaxHeadMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pTaxHeadMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxHeadMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxHeadMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_HEAD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxHeadMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxHeadMaster.TaxHeadId  = db.Parameters.Item("p_TAX_HEAD_ID").value
                
                If pTaxHeadMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxHeadMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxHeadMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxHeadMaster.TerminalId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxHeadMaster.TaxHeadId, ParameterDirection.Output)
                db.AddParameter("p_TAX_HEAD_NAME", pTaxHeadMaster.TaxHeadName)
                db.AddParameter("p_MAP_CODE", pTaxHeadMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pTaxHeadMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxHeadMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxHeadMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_HEAD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxHeadMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxHeadMaster.TaxHeadId  = db.Parameters.Item("p_TAX_HEAD_ID").value
                
            Catch ex As Exception
                pTaxHeadMaster.ErrorMsg = ex.Message
            End Try
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTaxHeadMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxHeadMaster.TerminalId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxHeadMaster.TaxHeadId)
                db.AddParameter("p_TAX_HEAD_NAME", pTaxHeadMaster.TaxHeadName)
                db.AddParameter("p_MAP_CODE", pTaxHeadMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pTaxHeadMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxHeadMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxHeadMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_HEAD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxHeadMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTaxHeadMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxHeadMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxHeadMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxHeadMaster.TerminalId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxHeadMaster.TaxHeadId)
                db.AddParameter("p_TAX_HEAD_NAME", pTaxHeadMaster.TaxHeadName)
                db.AddParameter("p_MAP_CODE", pTaxHeadMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pTaxHeadMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxHeadMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxHeadMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_HEAD_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxHeadMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTaxHeadMaster.ErrorMsg = ex.Message
                End Try
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTaxHeadMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                PTaxHeadMaster.TaxHeadId = dbr("TAX_HEAD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_HEAD_NAME").ToString <> "" Then
                                PTaxHeadMaster.TaxHeadName = dbr("TAX_HEAD_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                PTaxHeadMaster.MapCode = dbr("MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTaxHeadMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTaxHeadMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTaxHeadMaster.ErrorMsg = ex.Message
            End Try
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTaxHeadMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TaxHeadMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("TAX_HEAD_NAME").ToString <> "" Then
                                temp.TaxHeadName = dbr("TAX_HEAD_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                temp.MapCode = dbr("MAP_CODE")
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
        ''' Preparing Return Object by TerminalId, TaxHeadId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTaxHeadMaster(ByVal pTaxHeadMaster As TaxHeadMaster) As TaxHeadMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_HEAD_MASTER_BY_ID", pTaxHeadMaster.TerminalId & "," & pTaxHeadMaster.TaxHeadId)
                pTaxHeadMaster = ReturnObjectValues(dbr, pTaxHeadMaster)
                dbr.Close()
            Catch ex As Exception
                pTaxHeadMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTaxHeadMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTaxHeadMasterList (ByVal pTaxHeadMaster As TaxHeadMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTaxHeadMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_HEAD_MASTER_ALL", pTaxHeadMaster.TerminalId)
                arrTaxHeadMaster = ReturnObjectValuesList(dbr, arrTaxHeadMaster)
                dbr.Close()
            Catch ex As Exception
                arrTaxHeadMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTaxHeadMaster
        End Function
    End Class
End Namespace
