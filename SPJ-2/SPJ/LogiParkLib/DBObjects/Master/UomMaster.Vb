Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UomMaster
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class UomMaster 

        Private lngTerminalId As Long
        Private lngUomId As Long ' Define Private Variable UomId With DataType As Long 
        Private strUomName As String ' Define Private Variable UomName With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of UomId
        ''' </summary>
        ''' <value>lngUomId</value>
        ''' <returns> Return lngUomId</returns>
        ''' <remarks> Get or Set the Value of UomId  </remarks>
        '''
        Public Property UomId() as Long
            Get
                Return lngUomId
            End Get
            Set(ByVal value As Long)
                lngUomId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of UomName
        ''' </summary>
        ''' <value>strUomName</value>
        ''' <returns> Return strUomName</returns>
        ''' <remarks> Get or Set the Value of UomName  </remarks>
        '''
        Public Property UomName() as String
            Get
                Return strUomName
            End Get
            Set(ByVal value As String)
                strUomName = value
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
            lngUomId = 0
            strUomName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pUomMaster"></param>
        ''' <returns>Return pUomMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pUomMaster As UomMaster) As UomMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUomMaster.TerminalId)
                db.AddParameter("p_UOM_ID", pUomMaster.UomId, ParameterDirection.Output)
                db.AddParameter("p_UOM_NAME", pUomMaster.UomName)
                db.AddParameter("p_ErrorMsg", pUomMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_UOM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUomMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUomMaster.UomId  = db.Parameters.Item("p_UOM_ID").value
                
                If pUomMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUomMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUomMaster"></param>
        ''' <returns>Return pUomMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pUomMaster As UomMaster) As UomMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUomMaster.TerminalId)
                db.AddParameter("p_UOM_ID", pUomMaster.UomId, ParameterDirection.Output)
                db.AddParameter("p_UOM_NAME", pUomMaster.UomName)
                db.AddParameter("p_ErrorMsg", pUomMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_UOM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUomMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pUomMaster.UomId  = db.Parameters.Item("p_UOM_ID").value
                
            Catch ex As Exception
                pUomMaster.ErrorMsg = ex.Message
            End Try
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pUomMaster"></param>
        ''' <returns>Return pUomMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pUomMaster As UomMaster) As UomMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUomMaster.TerminalId)
                db.AddParameter("p_UOM_ID", pUomMaster.UomId)
                db.AddParameter("p_UOM_NAME", pUomMaster.UomName)
                db.AddParameter("p_ErrorMsg", pUomMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_UOM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUomMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pUomMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pUomMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pUomMaster"></param>
        ''' <returns>Return pUomMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pUomMaster As UomMaster) As UomMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUomMaster.TerminalId)
                db.AddParameter("p_UOM_ID", pUomMaster.UomId)
                db.AddParameter("p_UOM_NAME", pUomMaster.UomName)
                db.AddParameter("p_ErrorMsg", pUomMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_UOM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUomMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pUomMaster.ErrorMsg = ex.Message
                End Try
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pUomMaster As UomMaster) As UomMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pUomMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                pUomMaster.UomId = dbr("UOM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_NAME").ToString <> "" Then
                                pUomMaster.UomName = dbr("UOM_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pUomMaster.ErrorMsg = ex.Message
            End Try
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrUomMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New UomMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                temp.UomId = dbr("UOM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_NAME").ToString <> "" Then
                                temp.UomName = dbr("UOM_NAME")
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
        ''' Preparing Return Object By UomId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnUomMaster(ByVal pUomMaster As UomMaster) As UomMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_UOM_MASTER_BY_ID", pUomMaster.TerminalId & "," & pUomMaster.UomId)
                pUomMaster = ReturnObjectValues(dbr, pUomMaster)
                dbr.Close()
            Catch ex As Exception
                pUomMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pUomMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnUomMasterList(ByVal pUomMaster As UomMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrUomMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_UOM_MASTER_ALL", pUomMaster.TerminalId)
                arrUomMaster = ReturnObjectValuesList(dbr, arrUomMaster)
                dbr.Close()
            Catch ex As Exception
                arrUomMaster = Nothing
            End Try
            db.CloseDB()
            Return arrUomMaster
        End Function
    End Class
End Namespace
