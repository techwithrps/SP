Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CompanyCodeMapping
    ''' @author	: Amit K. Singh- 27/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CompanyCodeMapping 
    
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strUpdatedBy As String ' Define Private Variable UpdatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable UpdatedOn With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMappingId As Long ' Define Private Variable MappingId With DataType As Long 
        Private strCompanyCode As String ' Define Private Variable CompanyCode With DataType As String 
        Private lngDivisionId As Long ' Define Private Variable DivisionId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable TerminalId With DataType As Long 

                    
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
        ''' Get or Set the Value of UpdatedBy
        ''' </summary>
        ''' <value>strUpdatedBy</value>
        ''' <returns> Return strUpdatedBy</returns>
        ''' <remarks> Get or Set the Value of UpdatedBy  </remarks>
        '''
        Public Property UpdatedBy() as String
            Get
                Return strUpdatedBy
            End Get
            Set(ByVal value As String)
                strUpdatedBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of UpdatedOn
        ''' </summary>
        ''' <value>strUpdatedOn</value>
        ''' <returns> Return strUpdatedOn</returns>
        ''' <remarks> Get or Set the Value of UpdatedOn  </remarks>
        '''
        Public Property UpdatedOn() as String
            Get
                Return strUpdatedOn
            End Get
            Set(ByVal value As String)
                strUpdatedOn = value
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
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of MappingId
        ''' </summary>
        ''' <value>lngMappingId</value>
        ''' <returns> Return lngMappingId</returns>
        ''' <remarks> Get or Set the Value of MappingId  </remarks>
        '''
        Public Property MappingId() as Long
            Get
                Return lngMappingId
            End Get
            Set(ByVal value As Long)
                lngMappingId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CompanyCode
        ''' </summary>
        ''' <value>strCompanyCode</value>
        ''' <returns> Return strCompanyCode</returns>
        ''' <remarks> Get or Set the Value of CompanyCode  </remarks>
        '''
        Public Property CompanyCode() as String
            Get
                Return strCompanyCode
            End Get
            Set(ByVal value As String)
                strCompanyCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DivisionId
        ''' </summary>
        ''' <value>lngDivisionId</value>
        ''' <returns> Return lngDivisionId</returns>
        ''' <remarks> Get or Set the Value of DivisionId  </remarks>
        '''
        Public Property DivisionId() as Long
            Get
                Return lngDivisionId
            End Get
            Set(ByVal value As Long)
                lngDivisionId = value
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
            strCreatedOn = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            lngTerminalId = 0 
            lngMappingId = 0 
            strCompanyCode = ""
            lngDivisionId = 0 
            strCreatedBy = ""
            strErrormsg = ""
            lngCompanyId = 0
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCompanyCodeMapping"></param>
        ''' <returns>Return pCompanyCodeMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CREATED_ON", pCompanyCodeMapping.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCompanyCodeMapping.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCompanyCodeMapping.UpdatedOn)
                db.AddParameter("p_TERMINAL_ID", pCompanyCodeMapping.TerminalId)
                db.AddParameter("p_MAPPING_ID", pCompanyCodeMapping.MappingId, ParameterDirection.Output)
                db.AddParameter("p_COMPANY_CODE", pCompanyCodeMapping.CompanyCode)
                db.AddParameter("p_DIVISION_ID", pCompanyCodeMapping.DivisionId)
                db.AddParameter("p_CREATED_BY", pCompanyCodeMapping.CreatedBy)
                db.AddParameter("p_COMPANY_ID", pCompanyCodeMapping.CompanyId)
                db.AddParameter("p_ErrorMsg", pCompanyCodeMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMPANY_CODE_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyCodeMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCompanyCodeMapping.MappingId = db.Parameters.Item("p_MAPPING_ID").value
                
                If pCompanyCodeMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCompanyCodeMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCompanyCodeMapping"></param>
        ''' <returns>Return pCompanyCodeMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_CREATED_ON", pCompanyCodeMapping.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCompanyCodeMapping.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCompanyCodeMapping.UpdatedOn)
                db.AddParameter("p_TERMINAL_ID", pCompanyCodeMapping.TerminalId)
                db.AddParameter("p_MAPPING_ID", pCompanyCodeMapping.MappingId, ParameterDirection.Output)
                db.AddParameter("p_COMPANY_CODE", pCompanyCodeMapping.CompanyCode)
                db.AddParameter("p_DIVISION_ID", pCompanyCodeMapping.DivisionId)
                db.AddParameter("p_CREATED_BY", pCompanyCodeMapping.CreatedBy)
                db.AddParameter("p_COMPANY_ID", pCompanyCodeMapping.CompanyId)
                db.AddParameter("p_ErrorMsg", pCompanyCodeMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COMPANY_CODE_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyCodeMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pCompanyCodeMapping.MappingId = db.Parameters.Item("p_MAPPING_ID").value

            Catch ex As Exception
                pCompanyCodeMapping.ErrorMsg = ex.Message
            End Try
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCompanyCodeMapping"></param>
        ''' <returns>Return pCompanyCodeMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CREATED_ON", pCompanyCodeMapping.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCompanyCodeMapping.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCompanyCodeMapping.UpdatedOn)
                db.AddParameter("p_TERMINAL_ID", pCompanyCodeMapping.TerminalId)
                db.AddParameter("p_MAPPING_ID", pCompanyCodeMapping.MappingId)
                db.AddParameter("p_COMPANY_CODE", pCompanyCodeMapping.CompanyCode)
                db.AddParameter("p_DIVISION_ID", pCompanyCodeMapping.DivisionId)
                db.AddParameter("p_CREATED_BY", pCompanyCodeMapping.CreatedBy)
                db.AddParameter("p_COMPANY_ID", pCompanyCodeMapping.CompanyId)
                db.AddParameter("p_ErrorMsg", pCompanyCodeMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMPANY_CODE_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyCodeMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCompanyCodeMapping.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCompanyCodeMapping.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCompanyCodeMapping"></param>
        ''' <returns>Return pCompanyCodeMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Try
                db.ClearParameters()
                db.AddParameter("p_CREATED_ON", pCompanyCodeMapping.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pCompanyCodeMapping.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pCompanyCodeMapping.UpdatedOn)
                db.AddParameter("p_TERMINAL_ID", pCompanyCodeMapping.TerminalId)
                db.AddParameter("p_MAPPING_ID", pCompanyCodeMapping.MappingId)
                db.AddParameter("p_COMPANY_CODE", pCompanyCodeMapping.CompanyCode)
                db.AddParameter("p_DIVISION_ID", pCompanyCodeMapping.DivisionId)
                db.AddParameter("p_CREATED_BY", pCompanyCodeMapping.CreatedBy)
                db.AddParameter("p_COMPANY_ID", pCompanyCodeMapping.CompanyId)
                db.AddParameter("p_ErrorMsg", pCompanyCodeMapping.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COMPANY_CODE_MAPPING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCompanyCodeMapping.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCompanyCodeMapping.ErrorMsg = ex.Message
                End Try
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PCompanyCodeMapping.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                PCompanyCodeMapping.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                PCompanyCodeMapping.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCompanyCodeMapping.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAPPING_ID").ToString <> "" Then
                                PCompanyCodeMapping.MappingId = dbr("MAPPING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CODE").ToString <> "" Then
                                PCompanyCodeMapping.CompanyCode = dbr("COMPANY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_ID").ToString <> "" Then
                                PCompanyCodeMapping.DivisionId = dbr("DIVISION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PCompanyCodeMapping.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pCompanyCodeMapping.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCompanyCodeMapping.ErrorMsg = ex.Message
            End Try
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCompanyCodeMapping As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CompanyCodeMapping
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                temp.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                temp.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAPPING_ID").ToString <> "" Then
                                temp.MappingId = dbr("MAPPING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_CODE").ToString <> "" Then
                                temp.CompanyCode = dbr("COMPANY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_ID").ToString <> "" Then
                                temp.DivisionId = dbr("DIVISION_ID")
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
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
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
        Public Shared Function ReturnCompanyCodeMapping(ByVal pCompanyCodeMapping As CompanyCodeMapping) As CompanyCodeMapping
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_CODE_MAPPING", "' '")
                pCompanyCodeMapping = ReturnObjectValues(dbr, pCompanyCodeMapping)
                dbr.Close()
            Catch ex As Exception
                pCompanyCodeMapping.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCompanyCodeMapping
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCompanyCodeMappingList (ByVal pCompanyCodeMapping As CompanyCodeMapping) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCompanyCodeMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COMPANY_CODE_MAPPING", "' '")
                arrCompanyCodeMapping = ReturnObjectValuesList(dbr, arrCompanyCodeMapping)
                dbr.Close()
            Catch ex As Exception
                arrCompanyCodeMapping = Nothing
            End Try
            db.CloseDB()
            Return arrCompanyCodeMapping
        End Function
    End Class
End Namespace
