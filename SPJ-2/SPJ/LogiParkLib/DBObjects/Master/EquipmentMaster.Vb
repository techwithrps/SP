Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: EquipmentMaster
    ''' @author	: Santosh Singh- 14/6/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class EquipmentMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngEquipRefId As Long ' Define Private Variable EquipRefId With DataType As Long 
        Private strOwner As String ' Define Private Variable Owner With DataType As String 
        Private lngVendorId As Long ' Define Private Variable VendorId With DataType As Long 
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
        ''' Get or Set the Value of EquipRefId
        ''' </summary>
        ''' <value>lngEquipRefId</value>
        ''' <returns> Return lngEquipRefId</returns>
        ''' <remarks> Get or Set the Value of EquipRefId  </remarks>
        '''
        Public Property EquipRefId() as Long
            Get
                Return lngEquipRefId
            End Get
            Set(ByVal value As Long)
                lngEquipRefId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Owner
        ''' </summary>
        ''' <value>strOwner</value>
        ''' <returns> Return strOwner</returns>
        ''' <remarks> Get or Set the Value of Owner  </remarks>
        '''
        Public Property Owner() as String
            Get
                Return strOwner
            End Get
            Set(ByVal value As String)
                strOwner = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of VendorId
        ''' </summary>
        ''' <value>lngVendorId</value>
        ''' <returns> Return lngVendorId</returns>
        ''' <remarks> Get or Set the Value of VendorId  </remarks>
        '''
        Public Property VendorId() as Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
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
            lngEquipRefId = 0 
            strOwner = ""
            lngVendorId = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pEquipmentMaster"></param>
        ''' <returns>Return pEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentMaster.EquipRefId, ParameterDirection.Output)
                db.AddParameter("p_OWNER", pEquipmentMaster.Owner)
                db.AddParameter("p_VENDOR_ID", pEquipmentMaster.VendorId)
                db.AddParameter("p_CREATED_BY", pEquipmentMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pEquipmentMaster.EquipRefId  = db.Parameters.Item("p_EQUIP_REF_ID").value
                
                If pEquipmentMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentMaster"></param>
        ''' <returns>Return pEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentMaster.EquipRefId, ParameterDirection.Output)
                db.AddParameter("p_OWNER", pEquipmentMaster.Owner)
                db.AddParameter("p_VENDOR_ID", pEquipmentMaster.VendorId)
                db.AddParameter("p_CREATED_BY", pEquipmentMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pEquipmentMaster.EquipRefId  = db.Parameters.Item("p_EQUIP_REF_ID").value
                
            Catch ex As Exception
                pEquipmentMaster.ErrorMsg = ex.Message
            End Try
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pEquipmentMaster"></param>
        ''' <returns>Return pEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentMaster.EquipRefId)
                db.AddParameter("p_OWNER", pEquipmentMaster.Owner)
                db.AddParameter("p_VENDOR_ID", pEquipmentMaster.VendorId)
                db.AddParameter("p_CREATED_BY", pEquipmentMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pEquipmentMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentMaster"></param>
        ''' <returns>Return pEquipmentMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentMaster.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentMaster.EquipRefId)
                db.AddParameter("p_OWNER", pEquipmentMaster.Owner)
                db.AddParameter("p_VENDOR_ID", pEquipmentMaster.VendorId)
                db.AddParameter("p_CREATED_BY", pEquipmentMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pEquipmentMaster.ErrorMsg = ex.Message
                End Try
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PEquipmentMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIP_REF_ID").ToString <> "" Then
                                PEquipmentMaster.EquipRefId = dbr("EQUIP_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWNER").ToString <> "" Then
                                PEquipmentMaster.Owner = dbr("OWNER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                PEquipmentMaster.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PEquipmentMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PEquipmentMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pEquipmentMaster.ErrorMsg = ex.Message
            End Try
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrEquipmentMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New EquipmentMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIP_REF_ID").ToString <> "" Then
                                temp.EquipRefId = dbr("EQUIP_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OWNER").ToString <> "" Then
                                temp.Owner = dbr("OWNER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                temp.VendorId = dbr("VENDOR_ID")
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
        Public Shared Function ReturnEquipmentMasterByVendorId(ByVal pEquipmentMaster As EquipmentMaster) As EquipmentMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_MASTER_BY_V_ID", pEquipmentMaster.TerminalId & "," & pEquipmentMaster.VendorId)
                pEquipmentMaster = ReturnObjectValues(dbr, pEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                pEquipmentMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pEquipmentMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentMasterList(ByVal pEquipmentMaster As EquipmentMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrEquipmentMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_MASTER_BY_ALL", pEquipmentMaster.TerminalId)
                arrEquipmentMaster = ReturnObjectValuesList(dbr, arrEquipmentMaster)
                dbr.Close()
            Catch ex As Exception
                arrEquipmentMaster = Nothing
            End Try
            db.CloseDB()
            Return arrEquipmentMaster
        End Function
    End Class
End Namespace
