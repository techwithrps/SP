Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: DivisionMaster
    ''' @author	: Amit K. Singh- 27/4/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class DivisionMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngDivisionId As Long ' Define Private Variable DivisionId With DataType As Long 
        Private strDivisionCode As String ' Define Private Variable DivisionCode With DataType As String 
        Private strDivisionName As String ' Define Private Variable DivisionName With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strUpdatedBy As String ' Define Private Variable UpdatedBy With DataType As String 
        Private strUpdatedOn As String ' Define Private Variable UpdatedOn With DataType As String 
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
        ''' Get or Set the Value of DivisionCode
        ''' </summary>
        ''' <value>strDivisionCode</value>
        ''' <returns> Return strDivisionCode</returns>
        ''' <remarks> Get or Set the Value of DivisionCode  </remarks>
        '''
        Public Property DivisionCode() as String
            Get
                Return strDivisionCode
            End Get
            Set(ByVal value As String)
                strDivisionCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DivisionName
        ''' </summary>
        ''' <value>strDivisionName</value>
        ''' <returns> Return strDivisionName</returns>
        ''' <remarks> Get or Set the Value of DivisionName  </remarks>
        '''
        Public Property DivisionName() as String
            Get
                Return strDivisionName
            End Get
            Set(ByVal value As String)
                strDivisionName = value
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
            lngDivisionId = 0 
            strDivisionCode = ""
            strDivisionName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strUpdatedBy = ""
            strUpdatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pDivisionMaster"></param>
        ''' <returns>Return pDivisionMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDivisionMaster.TerminalId)
                db.AddParameter("p_DIVISION_ID", pDivisionMaster.DivisionId, ParameterDirection.Output)
                db.AddParameter("p_DIVISION_CODE", pDivisionMaster.DivisionCode)
                db.AddParameter("p_DIVISION_NAME", pDivisionMaster.DivisionName)
                db.AddParameter("p_CREATED_BY", pDivisionMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDivisionMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pDivisionMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pDivisionMaster.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pDivisionMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DIVISION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDivisionMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pDivisionMaster.DivisionId = db.Parameters.Item("p_DIVISION_ID").value

                If pDivisionMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDivisionMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDivisionMaster"></param>
        ''' <returns>Return pDivisionMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDivisionMaster.TerminalId)
                db.AddParameter("p_DIVISION_ID", pDivisionMaster.DivisionId, ParameterDirection.Output)
                db.AddParameter("p_DIVISION_CODE", pDivisionMaster.DivisionCode)
                db.AddParameter("p_DIVISION_NAME", pDivisionMaster.DivisionName)
                db.AddParameter("p_CREATED_BY", pDivisionMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDivisionMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pDivisionMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pDivisionMaster.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pDivisionMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_DIVISION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDivisionMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pDivisionMaster.DivisionId = db.Parameters.Item("p_DIVISION_ID").value

            Catch ex As Exception
                pDivisionMaster.ErrorMsg = ex.Message
            End Try
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pDivisionMaster"></param>
        ''' <returns>Return pDivisionMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDivisionMaster.TerminalId)
                db.AddParameter("p_DIVISION_ID", pDivisionMaster.DivisionId)
                db.AddParameter("p_DIVISION_CODE", pDivisionMaster.DivisionCode)
                db.AddParameter("p_DIVISION_NAME", pDivisionMaster.DivisionName)
                db.AddParameter("p_CREATED_BY", pDivisionMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDivisionMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pDivisionMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pDivisionMaster.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pDivisionMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DIVISION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDivisionMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pDivisionMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pDivisionMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pDivisionMaster"></param>
        ''' <returns>Return pDivisionMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pDivisionMaster.TerminalId)
                db.AddParameter("p_DIVISION_ID", pDivisionMaster.DivisionId)
                db.AddParameter("p_DIVISION_CODE", pDivisionMaster.DivisionCode)
                db.AddParameter("p_DIVISION_NAME", pDivisionMaster.DivisionName)
                db.AddParameter("p_CREATED_BY", pDivisionMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pDivisionMaster.CreatedOn)
                db.AddParameter("p_UPDATED_BY", pDivisionMaster.UpdatedBy)
                db.AddParameter("p_UPDATED_ON", pDivisionMaster.UpdatedOn)
                db.AddParameter("p_ErrorMsg", pDivisionMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_DIVISION_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pDivisionMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pDivisionMaster.ErrorMsg = ex.Message
                End Try
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PDivisionMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_ID").ToString <> "" Then
                                PDivisionMaster.DivisionId = dbr("DIVISION_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_CODE").ToString <> "" Then
                                PDivisionMaster.DivisionCode = dbr("DIVISION_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_NAME").ToString <> "" Then
                                PDivisionMaster.DivisionName = dbr("DIVISION_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PDivisionMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PDivisionMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_BY").ToString <> "" Then
                                PDivisionMaster.UpdatedBy = dbr("UPDATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UPDATED_ON").ToString <> "" Then
                                PDivisionMaster.UpdatedOn = dbr("UPDATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pDivisionMaster.ErrorMsg = ex.Message
            End Try
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrDivisionMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New DivisionMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("DIVISION_CODE").ToString <> "" Then
                                temp.DivisionCode = dbr("DIVISION_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION_NAME").ToString <> "" Then
                                temp.DivisionName = dbr("DIVISION_NAME")
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
        Public Shared Function ReturnDivisionMaster(ByVal pDivisionMaster As DivisionMaster) As DivisionMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DIVISION_MASTER_BY_ID", pDivisionMaster.TerminalId & "," & pDivisionMaster.DivisionId)
                pDivisionMaster = ReturnObjectValues(dbr, pDivisionMaster)
                dbr.Close()
            Catch ex As Exception
                pDivisionMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pDivisionMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnDivisionMasterList (ByVal pDivisionMaster As DivisionMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrDivisionMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DIVISION_MASTER_BY_ALL", pDivisionMaster.TerminalId)
                arrDivisionMaster = ReturnObjectValuesList(dbr, arrDivisionMaster)
                dbr.Close()
            Catch ex As Exception
                arrDivisionMaster = Nothing
            End Try
            db.CloseDB()
            Return arrDivisionMaster
        End Function
    End Class
End Namespace
