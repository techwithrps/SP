Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceType
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ServiceType 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strServiceTypeCode As String ' Define Private Variable ServiceTypeCode With DataType As String 
        Private strServiceTypeName As String ' Define Private Variable ServiceTypeName With DataType As String 
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
        ''' Get or Set the Value of ServiceTypeCode
        ''' </summary>
        ''' <value>strServiceTypeCode</value>
        ''' <returns> Return strServiceTypeCode</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeCode  </remarks>
        '''
        Public Property ServiceTypeCode() as String
            Get
                Return strServiceTypeCode
            End Get
            Set(ByVal value As String)
                strServiceTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ServiceTypeName
        ''' </summary>
        ''' <value>strServiceTypeName</value>
        ''' <returns> Return strServiceTypeName</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeName  </remarks>
        '''
        Public Property ServiceTypeName() as String
            Get
                Return strServiceTypeName
            End Get
            Set(ByVal value As String)
                strServiceTypeName = value
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
            strServiceTypeCode = ""
            strServiceTypeName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pServiceType"></param>
        ''' <returns>Return pServiceType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pServiceType As ServiceType) As ServiceType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceType.TerminalId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceType.ServiceTypeCode)
                db.AddParameter("p_SERVICE_TYPE_NAME", pServiceType.ServiceTypeName)
                db.AddParameter("p_CREATED_BY", pServiceType.CreatedBy)
                db.AddParameter("p_CREATED_ON", pServiceType.CreatedOn)
                db.AddParameter("p_ErrorMsg", pServiceType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pServiceType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceType"></param>
        ''' <returns>Return pServiceType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pServiceType As ServiceType) As ServiceType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceType.TerminalId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceType.ServiceTypeCode)
                db.AddParameter("p_SERVICE_TYPE_NAME", pServiceType.ServiceTypeName)
                db.AddParameter("p_CREATED_BY", pServiceType.CreatedBy)
                db.AddParameter("p_CREATED_ON", pServiceType.CreatedOn)
                db.AddParameter("p_ErrorMsg", pServiceType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pServiceType.ErrorMsg = ex.Message
            End Try
            Return pServiceType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pServiceType"></param>
        ''' <returns>Return pServiceType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pServiceType As ServiceType) As ServiceType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceType.TerminalId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceType.ServiceTypeCode)
                db.AddParameter("p_SERVICE_TYPE_NAME", pServiceType.ServiceTypeName)
                db.AddParameter("p_CREATED_BY", pServiceType.CreatedBy)
                db.AddParameter("p_CREATED_ON", pServiceType.CreatedOn)
                db.AddParameter("p_ErrorMsg", pServiceType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceType"></param>
        ''' <returns>Return pServiceType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pServiceType As ServiceType) As ServiceType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceType.TerminalId)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceType.ServiceTypeCode)
                db.AddParameter("p_SERVICE_TYPE_NAME", pServiceType.ServiceTypeName)
                db.AddParameter("p_CREATED_BY", pServiceType.CreatedBy)
                db.AddParameter("p_CREATED_ON", pServiceType.CreatedOn)
                db.AddParameter("p_ErrorMsg", pServiceType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pServiceType.ErrorMsg = ex.Message
                End Try
            Return pServiceType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pServiceType As ServiceType) As ServiceType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PServiceType.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                PServiceType.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_NAME").ToString <> "" Then
                                PServiceType.ServiceTypeName = dbr("SERVICE_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PServiceType.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PServiceType.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pServiceType.ErrorMsg = ex.Message
            End Try
            Return pServiceType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrServiceType As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ServiceType
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                temp.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_NAME").ToString <> "" Then
                                temp.ServiceTypeName = dbr("SERVICE_TYPE_NAME")
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
        ''' Preparing Return Object By ServiceTypeCode
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnServiceType(ByVal pServiceType As ServiceType) As ServiceType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_TYPE_BY_ID", pServiceType.TerminalId & ",'" & pServiceType.ServiceTypeCode & "'")
                pServiceType = ReturnObjectValues(dbr, pServiceType)
                dbr.Close()
            Catch ex As Exception
                pServiceType.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pServiceType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceTypeList (ByVal pServiceType As ServiceType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_TYPE_ALL", pServiceType.TerminalId)
                arrServiceType = ReturnObjectValuesList(dbr, arrServiceType)
                dbr.Close()
            Catch ex As Exception
                arrServiceType = Nothing
            End Try
            db.CloseDB()
            Return arrServiceType
        End Function
    End Class
End Namespace
