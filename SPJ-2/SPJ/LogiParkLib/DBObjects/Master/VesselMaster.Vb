Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VesselMaster
    ''' @author	: Amit K. Singh- 1/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class VesselMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngVesselId As Long ' Define Private Variable VesselId With DataType As Long 
        Private strVesselCode As String ' Define Private Variable VesselCode With DataType As String 
        Private strVesselName As String ' Define Private Variable VesselName With DataType As String 
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
        ''' Get or Set the Value of VesselId
        ''' </summary>
        ''' <value>lngVesselId</value>
        ''' <returns> Return lngVesselId</returns>
        ''' <remarks> Get or Set the Value of VesselId  </remarks>
        '''
        Public Property VesselId() as Long
            Get
                Return lngVesselId
            End Get
            Set(ByVal value As Long)
                lngVesselId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VesselCode
        ''' </summary>
        ''' <value>strVesselCode</value>
        ''' <returns> Return strVesselCode</returns>
        ''' <remarks> Get or Set the Value of VesselCode  </remarks>
        '''
        Public Property VesselCode() as String
            Get
                Return strVesselCode
            End Get
            Set(ByVal value As String)
                strVesselCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VesselName
        ''' </summary>
        ''' <value>strVesselName</value>
        ''' <returns> Return strVesselName</returns>
        ''' <remarks> Get or Set the Value of VesselName  </remarks>
        '''
        Public Property VesselName() as String
            Get
                Return strVesselName
            End Get
            Set(ByVal value As String)
                strVesselName = value
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
            lngVesselId = 0 
            strVesselCode = ""
            strVesselName = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pVesselMaster"></param>
        ''' <returns>Return pVesselMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVesselMaster As VesselMaster) As VesselMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselMaster.TerminalId)
                db.AddParameter("p_VESSEL_ID", pVesselMaster.VesselId, ParameterDirection.Output)
                db.AddParameter("p_VESSEL_CODE", pVesselMaster.VesselCode)
                db.AddParameter("p_VESSEL_NAME", pVesselMaster.VesselName)
                db.AddParameter("p_ErrorMsg", pVesselMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VESSEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVesselMaster.VesselId  = db.Parameters.Item("p_VESSEL_ID").value
                
                If pVesselMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVesselMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVesselMaster"></param>
        ''' <returns>Return pVesselMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVesselMaster As VesselMaster) As VesselMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselMaster.TerminalId)
                db.AddParameter("p_VESSEL_ID", pVesselMaster.VesselId, ParameterDirection.Output)
                db.AddParameter("p_VESSEL_CODE", pVesselMaster.VesselCode)
                db.AddParameter("p_VESSEL_NAME", pVesselMaster.VesselName)
                db.AddParameter("p_ErrorMsg", pVesselMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VESSEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pVesselMaster.VesselId  = db.Parameters.Item("p_VESSEL_ID").value
                
            Catch ex As Exception
                pVesselMaster.ErrorMsg = ex.Message
            End Try
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVesselMaster"></param>
        ''' <returns>Return pVesselMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVesselMaster As VesselMaster) As VesselMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselMaster.TerminalId)
                db.AddParameter("p_VESSEL_ID", pVesselMaster.VesselId)
                db.AddParameter("p_VESSEL_CODE", pVesselMaster.VesselCode)
                db.AddParameter("p_VESSEL_NAME", pVesselMaster.VesselName)
                db.AddParameter("p_ErrorMsg", pVesselMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VESSEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVesselMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVesselMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVesselMaster"></param>
        ''' <returns>Return pVesselMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVesselMaster As VesselMaster) As VesselMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pVesselMaster.TerminalId)
                db.AddParameter("p_VESSEL_ID", pVesselMaster.VesselId)
                db.AddParameter("p_VESSEL_CODE", pVesselMaster.VesselCode)
                db.AddParameter("p_VESSEL_NAME", pVesselMaster.VesselName)
                db.AddParameter("p_ErrorMsg", pVesselMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VESSEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVesselMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pVesselMaster.ErrorMsg = ex.Message
                End Try
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVesselMaster As VesselMaster) As VesselMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PVesselMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_ID").ToString <> "" Then
                                PVesselMaster.VesselId = dbr("VESSEL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_CODE").ToString <> "" Then
                                PVesselMaster.VesselCode = dbr("VESSEL_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NAME").ToString <> "" Then
                                PVesselMaster.VesselName = dbr("VESSEL_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pVesselMaster.ErrorMsg = ex.Message
            End Try
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVesselMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VesselMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_ID").ToString <> "" Then
                                temp.VesselId = dbr("VESSEL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_CODE").ToString <> "" Then
                                temp.VesselCode = dbr("VESSEL_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VESSEL_NAME").ToString <> "" Then
                                temp.VesselName = dbr("VESSEL_NAME")
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
        Public Shared Function ReturnVesselMasterByID(ByVal pVesselMaster As VesselMaster) As VesselMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VESSEL_MASTER_BY_ID", pVesselMaster.TerminalId & "," & pVesselMaster.VesselId)
                pVesselMaster = ReturnObjectValues(dbr, pVesselMaster)
                dbr.Close()
            Catch ex As Exception
                pVesselMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pVesselMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVesselMasterList (ByVal pVesselMaster As VesselMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVesselMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VESSEL_MASTER_BY_ALL", pVesselMaster.TerminalId)
                arrVesselMaster = ReturnObjectValuesList(dbr, arrVesselMaster)
                dbr.Close()
            Catch ex As Exception
                arrVesselMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVesselMaster
        End Function
    End Class
End Namespace
