Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: EquipmentType
    ''' @author	: Amit K. Singh- 9/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class EquipmentType 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strEquipmentTypeCode As String ' Define Private Variable EquipmentTypeCode With DataType As String 
        Private strEquipmentTypeName As String ' Define Private Variable EquipmentTypeName With DataType As String 
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
        ''' Get or Set the Value of EquipmentTypeCode
        ''' </summary>
        ''' <value>strEquipmentTypeCode</value>
        ''' <returns> Return strEquipmentTypeCode</returns>
        ''' <remarks> Get or Set the Value of EquipmentTypeCode  </remarks>
        '''
        Public Property EquipmentTypeCode() as String
            Get
                Return strEquipmentTypeCode
            End Get
            Set(ByVal value As String)
                strEquipmentTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EquipmentTypeName
        ''' </summary>
        ''' <value>strEquipmentTypeName</value>
        ''' <returns> Return strEquipmentTypeName</returns>
        ''' <remarks> Get or Set the Value of EquipmentTypeName  </remarks>
        '''
        Public Property EquipmentTypeName() as String
            Get
                Return strEquipmentTypeName
            End Get
            Set(ByVal value As String)
                strEquipmentTypeName = value
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
            strEquipmentTypeCode = ""
            strEquipmentTypeName = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pEquipmentType"></param>
        ''' <returns>Return pEquipmentType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pEquipmentType As EquipmentType) As EquipmentType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentType.TerminalId)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentType.EquipmentTypeCode)
                db.AddParameter("p_EQUIPMENT_TYPE_NAME", pEquipmentType.EquipmentTypeName)
                db.AddParameter("p_ErrorMsg", pEquipmentType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pEquipmentType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentType"></param>
        ''' <returns>Return pEquipmentType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pEquipmentType As EquipmentType) As EquipmentType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentType.TerminalId)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentType.EquipmentTypeCode)
                db.AddParameter("p_EQUIPMENT_TYPE_NAME", pEquipmentType.EquipmentTypeName)
                db.AddParameter("p_ErrorMsg", pEquipmentType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pEquipmentType.ErrorMsg = ex.Message
            End Try
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pEquipmentType"></param>
        ''' <returns>Return pEquipmentType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pEquipmentType As EquipmentType) As EquipmentType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentType.TerminalId)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentType.EquipmentTypeCode)
                db.AddParameter("p_EQUIPMENT_TYPE_NAME", pEquipmentType.EquipmentTypeName)
                db.AddParameter("p_ErrorMsg", pEquipmentType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pEquipmentType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentType"></param>
        ''' <returns>Return pEquipmentType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pEquipmentType As EquipmentType) As EquipmentType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentType.TerminalId)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentType.EquipmentTypeCode)
                db.AddParameter("p_EQUIPMENT_TYPE_NAME", pEquipmentType.EquipmentTypeName)
                db.AddParameter("p_ErrorMsg", pEquipmentType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pEquipmentType.ErrorMsg = ex.Message
                End Try
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pEquipmentType As EquipmentType) As EquipmentType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PEquipmentType.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE_CODE").ToString <> "" Then
                                PEquipmentType.EquipmentTypeCode = dbr("EQUIPMENT_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE_NAME").ToString <> "" Then
                                PEquipmentType.EquipmentTypeName = dbr("EQUIPMENT_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pEquipmentType.ErrorMsg = ex.Message
            End Try
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrEquipmentType As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New EquipmentType
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE_CODE").ToString <> "" Then
                                temp.EquipmentTypeCode = dbr("EQUIPMENT_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE_NAME").ToString <> "" Then
                                temp.EquipmentTypeName = dbr("EQUIPMENT_TYPE_NAME")
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
        Public Shared Function ReturnEquipmentType(ByVal pEquipmentType As EquipmentType) As EquipmentType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_TYPE", "' '")
                pEquipmentType = ReturnObjectValues(dbr, pEquipmentType)
                dbr.Close()
            Catch ex As Exception
                pEquipmentType.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pEquipmentType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentTypeList(ByVal pEquipmentType As EquipmentType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrEquipmentType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_TYPE_BY_ALL", pEquipmentType.TerminalId)
                arrEquipmentType = ReturnObjectValuesList(dbr, arrEquipmentType)
                dbr.Close()
            Catch ex As Exception
                arrEquipmentType = Nothing
            End Try
            db.CloseDB()
            Return arrEquipmentType
        End Function
        Public Shared Function ReturnEquipmentTypeCode(ByVal pEquipmentType As EquipmentType) As EquipmentType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_TYPE_CODE", "'" & pEquipmentType.EquipmentTypeCode & "'")
                pEquipmentType = ReturnObjectValues(dbr, pEquipmentType)
                dbr.Close()
            Catch ex As Exception
                pEquipmentType.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pEquipmentType
        End Function

    End Class
End Namespace
