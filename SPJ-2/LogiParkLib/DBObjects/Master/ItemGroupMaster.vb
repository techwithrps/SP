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
    Public Class ItemGroupMaster
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngItemGroupId As Long ' Define Private Variable TaxHeadId With DataType As Long 
        Private strItemGrouName As String ' Define Private Variable TaxHeadName With DataType As String 
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
        Public Property TerminalId() As Long
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
        Public Property ItemGroupId() As Long
            Get
                Return lngItemGroupId
            End Get
            Set(ByVal value As Long)
                lngItemGroupId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TaxHeadName
        ''' </summary>
        ''' <value>strTaxHeadName</value>
        ''' <returns> Return strTaxHeadName</returns>
        ''' <remarks> Get or Set the Value of TaxHeadName  </remarks>
        '''
        Public Property ItemGroupName() As String
            Get
                Return strItemGrouName
            End Get
            Set(ByVal value As String)
                strItemGrouName = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of MapCode
        ''' </summary>
        ''' <value>strMapCode</value>
        ''' <returns> Return strMapCode</returns>
        ''' <remarks> Get or Set the Value of MapCode  </remarks>
        '''
        Public Property MapCode() As String
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
        Public Property CreatedBy() As String
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
        Public Property CreatedOn() As String
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
        Public Property Errormsg() As String
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
            lngItemGroupId = 0
            strItemGrouName = ""
            strMapCode = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub
        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pItemGroupMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemGroupMaster.TerminalId)
                db.AddParameter("p_ITEM_GROUP_ID", pItemGroupMaster.ItemGroupId, ParameterDirection.Output)
                db.AddParameter("p_ITEM_GROUP_NAME", pItemGroupMaster.ItemGroupName)
                db.AddParameter("p_MAP_CODE", pItemGroupMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pItemGroupMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemGroupMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pItemGroupMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ITEM_GROUP_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemGroupMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pItemGroupMaster.ItemGroupId = db.Parameters.Item("p_ITEM_GROUP_ID").value

                If pItemGroupMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pItemGroupMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemGroupMaster.TerminalId)
                db.AddParameter("p_ITEM_GROUP_ID", pItemGroupMaster.ItemGroupId, ParameterDirection.Output)
                db.AddParameter("p_ITEM_GROUP_NAME", pItemGroupMaster.ItemGroupName)
                db.AddParameter("p_MAP_CODE", pItemGroupMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pItemGroupMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemGroupMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pItemGroupMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ITEM_GROUP_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemGroupMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pItemGroupMaster.ItemGroupId = db.Parameters.Item("p_ITEM_GROUP_ID").value

            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
            End Try
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pItemGroupMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemGroupMaster.TerminalId)
                db.AddParameter("p_ITEM_GROUP_ID", pItemGroupMaster.ItemGroupId)
                db.AddParameter("p_ITEM_GROUP_NAME", pItemGroupMaster.ItemGroupName)
                db.AddParameter("p_MAP_CODE", pItemGroupMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pItemGroupMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemGroupMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pItemGroupMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ITEM_GROUP_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemGroupMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pItemGroupMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pItemGroupMaster"></param>
        ''' <returns>Return pTaxHeadMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pItemGroupMaster.TerminalId)
                db.AddParameter("p_ITEM_GROUP_ID", pItemGroupMaster.ItemGroupId)
                db.AddParameter("p_ITEM_GROUP_NAME", pItemGroupMaster.ItemGroupName)
                db.AddParameter("p_MAP_CODE", pItemGroupMaster.MapCode)
                db.AddParameter("p_CREATED_BY", pItemGroupMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pItemGroupMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pItemGroupMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ITEM_GROUP_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pItemGroupMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
            End Try
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pItemGroupMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP_ID").ToString <> "" Then
                                pItemGroupMaster.ItemGroupId = dbr("ITEM_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP_NAME").ToString <> "" Then
                                pItemGroupMaster.ItemGroupName = dbr("ITEM_GROUP_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                pItemGroupMaster.MapCode = dbr("MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pItemGroupMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pItemGroupMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
            End Try
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrItemGroupName As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ItemGroupMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP_ID").ToString <> "" Then
                                temp.ItemGroupId = dbr("ITEM_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ITEM_GROUP_NAME").ToString <> "" Then
                                temp.ItemGroupName = dbr("ITEM_GROUP_NAME")
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
                End If
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
        Public Shared Function ReturnItemMaster(ByVal pItemGroupMaster As ItemGroupMaster) As ItemGroupMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ITEM_GROUP_MASTER_BY_ID", pItemGroupMaster.TerminalId & "," & pItemGroupMaster.ItemGroupId)
                pItemGroupMaster = ReturnObjectValues(dbr, pItemGroupMaster)
                dbr.Close()
            Catch ex As Exception
                pItemGroupMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pItemGroupMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList by TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnItemGroupMasterList(ByVal pItemGroupMaster As ItemGroupMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrItemGroupName As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ITEM_GROUP_MASTER_ALL", pItemGroupMaster.TerminalId)
                arrItemGroupName = ReturnObjectValuesList(dbr, arrItemGroupName)
                dbr.Close()
            Catch ex As Exception
                arrItemGroupName = Nothing
            End Try
            db.CloseDB()
            Return arrItemGroupName
        End Function
    End Class
End Namespace


