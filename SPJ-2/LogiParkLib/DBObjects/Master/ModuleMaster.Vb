Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ModuleMaster
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ModuleMaster 
    
        Private lngModuleId As Long ' Define Private Variable ModuleId With DataType As Long 
        Private strModuleName As String ' Define Private Variable ModuleName With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of ModuleId
        ''' </summary>
        ''' <value>lngModuleId</value>
        ''' <returns> Return lngModuleId</returns>
        ''' <remarks> Get or Set the Value of ModuleId  </remarks>
        '''
        Public Property ModuleId() as Long
            Get
                Return lngModuleId
            End Get
            Set(ByVal value As Long)
                lngModuleId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ModuleName
        ''' </summary>
        ''' <value>strModuleName</value>
        ''' <returns> Return strModuleName</returns>
        ''' <remarks> Get or Set the Value of ModuleName  </remarks>
        '''
        Public Property ModuleName() as String
            Get
                Return strModuleName
            End Get
            Set(ByVal value As String)
                strModuleName = value
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
            lngModuleId = 0 
            strModuleName = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pModuleMaster"></param>
        ''' <returns>Return pModuleMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MODULE_ID", pModuleMaster.ModuleId)
                db.AddParameter("p_MODULE_NAME", pModuleMaster.ModuleName)
                db.AddParameter("p_ErrorMsg", pModuleMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MODULE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pModuleMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pModuleMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pModuleMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pModuleMaster"></param>
        ''' <returns>Return pModuleMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_MODULE_ID", pModuleMaster.ModuleId)
                db.AddParameter("p_MODULE_NAME", pModuleMaster.ModuleName)
                db.AddParameter("p_ErrorMsg", pModuleMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MODULE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pModuleMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pModuleMaster.ErrorMsg = ex.Message
            End Try
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pModuleMaster"></param>
        ''' <returns>Return pModuleMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MODULE_ID", pModuleMaster.ModuleId)
                db.AddParameter("p_MODULE_NAME", pModuleMaster.ModuleName)
                db.AddParameter("p_ErrorMsg", pModuleMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MODULE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pModuleMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pModuleMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pModuleMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pModuleMaster"></param>
        ''' <returns>Return pModuleMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_MODULE_ID", pModuleMaster.ModuleId)
                db.AddParameter("p_MODULE_NAME", pModuleMaster.ModuleName)
                db.AddParameter("p_ErrorMsg", pModuleMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MODULE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pModuleMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pModuleMaster.ErrorMsg = ex.Message
                End Try
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                PModuleMaster.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_NAME").ToString <> "" Then
                                PModuleMaster.ModuleName = dbr("MODULE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pModuleMaster.ErrorMsg = ex.Message
            End Try
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrModuleMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ModuleMaster
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                temp.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_NAME").ToString <> "" Then
                                temp.ModuleName = dbr("MODULE_NAME")
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
        ''' Preparing Return Object By ModuleId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnModuleMaster(ByVal pModuleMaster As ModuleMaster) As ModuleMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MODULE_MASTER_BY_ID", pModuleMaster.ModuleId)
                pModuleMaster = ReturnObjectValues(dbr, pModuleMaster)
                dbr.Close()
            Catch ex As Exception
                pModuleMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pModuleMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList All
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnModuleMasterList (ByVal pModuleMaster As ModuleMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrModuleMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MODULE_MASTER_ALL", "' '")
                arrModuleMaster = ReturnObjectValuesList(dbr, arrModuleMaster)
                dbr.Close()
            Catch ex As Exception
                arrModuleMaster = Nothing
            End Try
            db.CloseDB()
            Return arrModuleMaster
        End Function
    End Class
End Namespace
