Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DamageCode
    ''' @author	: Amit K. Singh- 8/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class DamageCode 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngDamageId As Long ' Define Private Variable DamageId With DataType As Long 
        Private strDamageCode As String ' Define Private Variable DamageCode With DataType As String 
        Private strDamageDetails As String ' Define Private Variable DamageDetails With DataType As String 
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
        ''' Get or Set the Value of DamageId
        ''' </summary>
        ''' <value>lngDamageId</value>
        ''' <returns> Return lngDamageId</returns>
        ''' <remarks> Get or Set the Value of DamageId  </remarks>
        '''
        Public Property DamageId() as Long
            Get
                Return lngDamageId
            End Get
            Set(ByVal value As Long)
                lngDamageId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DamageCode
        ''' </summary>
        ''' <value>strDamageCode</value>
        ''' <returns> Return strDamageCode</returns>
        ''' <remarks> Get or Set the Value of DamageCode  </remarks>
        '''
        Public Property DamageCode() as String
            Get
                Return strDamageCode
            End Get
            Set(ByVal value As String)
                strDamageCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DamageDetails
        ''' </summary>
        ''' <value>strDamageDetails</value>
        ''' <returns> Return strDamageDetails</returns>
        ''' <remarks> Get or Set the Value of DamageDetails  </remarks>
        '''
        Public Property DamageDetails() as String
            Get
                Return strDamageDetails
            End Get
            Set(ByVal value As String)
                strDamageDetails = value
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
            lngDamageId = 0 
            strDamageCode = ""
            strDamageDetails = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pDamageCode"></param>
        ''' <returns>Return pDamageCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pDamageCode As DamageCode) As DamageCode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDamageCode.TerminalId)
                db.AddParameter("p_DAMAGE_ID", pDamageCode.DamageId, ParameterDirection.Output)
                db.AddParameter("p_DAMAGE_CODE", pDamageCode.DamageCode)
                db.AddParameter("p_DAMAGE_DETAILS", pDamageCode.DamageDetails)
                db.AddParameter("p_CREATED_BY", pDamageCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDamageCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pDamageCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DAMAGE_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDamageCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pDamageCode.DamageId  = db.Parameters.Item("p_DAMAGE_ID").value
                
                If pDamageCode.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDamageCode.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDamageCode"></param>
        ''' <returns>Return pDamageCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pDamageCode As DamageCode) As DamageCode
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDamageCode.TerminalId)
                db.AddParameter("p_DAMAGE_ID", pDamageCode.DamageId, ParameterDirection.Output)
                db.AddParameter("p_DAMAGE_CODE", pDamageCode.DamageCode)
                db.AddParameter("p_DAMAGE_DETAILS", pDamageCode.DamageDetails)
                db.AddParameter("p_CREATED_BY", pDamageCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDamageCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pDamageCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DAMAGE_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDamageCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pDamageCode.DamageId  = db.Parameters.Item("p_DAMAGE_ID").value
                
            Catch ex As Exception
                pDamageCode.ErrorMsg = ex.Message
            End Try
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pDamageCode"></param>
        ''' <returns>Return pDamageCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pDamageCode As DamageCode) As DamageCode
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDamageCode.TerminalId)
                db.AddParameter("p_DAMAGE_ID", pDamageCode.DamageId)
                db.AddParameter("p_DAMAGE_CODE", pDamageCode.DamageCode)
                db.AddParameter("p_DAMAGE_DETAILS", pDamageCode.DamageDetails)
                db.AddParameter("p_CREATED_BY", pDamageCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDamageCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pDamageCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DAMAGE_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDamageCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pDamageCode.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDamageCode.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDamageCode"></param>
        ''' <returns>Return pDamageCode Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pDamageCode As DamageCode) As DamageCode
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDamageCode.TerminalId)
                db.AddParameter("p_DAMAGE_ID", pDamageCode.DamageId)
                db.AddParameter("p_DAMAGE_CODE", pDamageCode.DamageCode)
                db.AddParameter("p_DAMAGE_DETAILS", pDamageCode.DamageDetails)
                db.AddParameter("p_CREATED_BY", pDamageCode.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDamageCode.CreatedOn)
                db.AddParameter("p_ErrorMsg", pDamageCode.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DAMAGE_CODE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDamageCode.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pDamageCode.ErrorMsg = ex.Message
                End Try
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pDamageCode As DamageCode) As DamageCode
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PDamageCode.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_ID").ToString <> "" Then
                                PDamageCode.DamageId = dbr("DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_CODE").ToString <> "" Then
                                PDamageCode.DamageCode = dbr("DAMAGE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_DETAILS").ToString <> "" Then
                                PDamageCode.DamageDetails = dbr("DAMAGE_DETAILS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PDamageCode.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PDamageCode.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pDamageCode.ErrorMsg = ex.Message
            End Try
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrDamageCode As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New DamageCode
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_ID").ToString <> "" Then
                                temp.DamageId = dbr("DAMAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_CODE").ToString <> "" Then
                                temp.DamageCode = dbr("DAMAGE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAMAGE_DETAILS").ToString <> "" Then
                                temp.DamageDetails = dbr("DAMAGE_DETAILS")
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
        ''' Preparing Return Object By TerminalId, DamageId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnDamageCode(ByVal pDamageCode As DamageCode) As DamageCode
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DAMAGE_CODE_BY_ID", pDamageCode.TerminalId & "," & pDamageCode.DamageId)
                pDamageCode = ReturnObjectValues(dbr, pDamageCode)
                dbr.Close()
            Catch ex As Exception
                pDamageCode.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pDamageCode
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnDamageCodeList (ByVal pDamageCode As DamageCode) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrDamageCode As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DAMAGE_CODE_ALL", pDamageCode.TerminalId)
                arrDamageCode = ReturnObjectValuesList(dbr, arrDamageCode)
                dbr.Close()
            Catch ex As Exception
                arrDamageCode = Nothing
            End Try
            db.CloseDB()
            Return arrDamageCode
        End Function
    End Class
End Namespace
