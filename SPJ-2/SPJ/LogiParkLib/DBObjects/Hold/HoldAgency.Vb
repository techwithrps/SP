Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: HoldAgency
    ''' @author	: Santosh Singh- 9/7/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class HoldAgency 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngHoldAgencyId As Long ' Define Private Variable HoldAgencyId With DataType As Long 
        Private strHoldAgencyName As String ' Define Private Variable HoldAgencyName With DataType As String 
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
        ''' Get or Set the Value of HoldAgencyId
        ''' </summary>
        ''' <value>lngHoldAgencyId</value>
        ''' <returns> Return lngHoldAgencyId</returns>
        ''' <remarks> Get or Set the Value of HoldAgencyId  </remarks>
        '''
        Public Property HoldAgencyId() as Long
            Get
                Return lngHoldAgencyId
            End Get
            Set(ByVal value As Long)
                lngHoldAgencyId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldAgencyName
        ''' </summary>
        ''' <value>strHoldAgencyName</value>
        ''' <returns> Return strHoldAgencyName</returns>
        ''' <remarks> Get or Set the Value of HoldAgencyName  </remarks>
        '''
        Public Property HoldAgencyName() as String
            Get
                Return strHoldAgencyName
            End Get
            Set(ByVal value As String)
                strHoldAgencyName = value
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
            lngHoldAgencyId = 0 
            strHoldAgencyName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pHoldAgency"></param>
        ''' <returns>Return pHoldAgency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pHoldAgency As HoldAgency) As HoldAgency
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldAgency.TerminalId)
                db.AddParameter("p_HOLD_AGENCY_ID", pHoldAgency.HoldAgencyId, ParameterDirection.Output)
                db.AddParameter("p_HOLD_AGENCY_NAME", pHoldAgency.HoldAgencyName)
                db.AddParameter("p_CREATED_BY", pHoldAgency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldAgency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldAgency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_AGENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldAgency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldAgency.HoldAgencyId  = db.Parameters.Item("p_HOLD_AGENCY_ID").value
                
                If pHoldAgency.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldAgency.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldAgency"></param>
        ''' <returns>Return pHoldAgency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pHoldAgency As HoldAgency) As HoldAgency
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldAgency.TerminalId)
                db.AddParameter("p_HOLD_AGENCY_ID", pHoldAgency.HoldAgencyId, ParameterDirection.Output)
                db.AddParameter("p_HOLD_AGENCY_NAME", pHoldAgency.HoldAgencyName)
                db.AddParameter("p_CREATED_BY", pHoldAgency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldAgency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldAgency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_AGENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldAgency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldAgency.HoldAgencyId  = db.Parameters.Item("p_HOLD_AGENCY_ID").value
                
            Catch ex As Exception
                pHoldAgency.ErrorMsg = ex.Message
            End Try
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pHoldAgency"></param>
        ''' <returns>Return pHoldAgency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pHoldAgency As HoldAgency) As HoldAgency
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldAgency.TerminalId)
                db.AddParameter("p_HOLD_AGENCY_ID", pHoldAgency.HoldAgencyId)
                db.AddParameter("p_HOLD_AGENCY_NAME", pHoldAgency.HoldAgencyName)
                db.AddParameter("p_CREATED_BY", pHoldAgency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldAgency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldAgency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_AGENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldAgency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pHoldAgency.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldAgency.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldAgency"></param>
        ''' <returns>Return pHoldAgency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pHoldAgency As HoldAgency) As HoldAgency
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldAgency.TerminalId)
                db.AddParameter("p_HOLD_AGENCY_ID", pHoldAgency.HoldAgencyId)
                db.AddParameter("p_HOLD_AGENCY_NAME", pHoldAgency.HoldAgencyName)
                db.AddParameter("p_CREATED_BY", pHoldAgency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pHoldAgency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pHoldAgency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_AGENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldAgency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pHoldAgency.ErrorMsg = ex.Message
                End Try
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pHoldAgency As HoldAgency) As HoldAgency
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PHoldAgency.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY_ID").ToString <> "" Then
                                PHoldAgency.HoldAgencyId = dbr("HOLD_AGENCY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY_NAME").ToString <> "" Then
                                PHoldAgency.HoldAgencyName = dbr("HOLD_AGENCY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PHoldAgency.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PHoldAgency.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pHoldAgency.ErrorMsg = ex.Message
            End Try
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrHoldAgency As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New HoldAgency
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY_ID").ToString <> "" Then
                                temp.HoldAgencyId = dbr("HOLD_AGENCY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY_NAME").ToString <> "" Then
                                temp.HoldAgencyName = dbr("HOLD_AGENCY_NAME")
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
        Public Shared Function ReturnHoldAgency(ByVal pHoldAgency As HoldAgency) As HoldAgency
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_AGENCY", "' '")
                pHoldAgency = ReturnObjectValues(dbr, pHoldAgency)
                dbr.Close()
            Catch ex As Exception
                pHoldAgency.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pHoldAgency
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnHoldAgencyList (ByVal pHoldAgency As HoldAgency) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrHoldAgency As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_AGENCY_ALL", pHoldAgency.TerminalId)
                arrHoldAgency = ReturnObjectValuesList(dbr, arrHoldAgency)
                dbr.Close()
            Catch ex As Exception
                arrHoldAgency = Nothing
            End Try
            db.CloseDB()
            Return arrHoldAgency
        End Function
    End Class
End Namespace
