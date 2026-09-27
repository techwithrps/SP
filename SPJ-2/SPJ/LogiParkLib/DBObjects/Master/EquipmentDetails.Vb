Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: EquipmentDetails
    ''' @author	: Santosh Singh- 14/6/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class EquipmentDetails 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngEquipRefId As Long ' Define Private Variable EquipRefId With DataType As Long 
        Private lngEquipmentId As Long ' Define Private Variable EquipmentId With DataType As Long 
        Private strEquipmentNo As String ' Define Private Variable EquipmentNo With DataType As String 
        Private strEquipmentTypeCode As String ' Define Private Variable EquipmentTypeCode With DataType As String 
        Private lngCapacity As Long ' Define Private Variable Capacity With DataType As Long 
        Private strValidFrom As String ' Define Private Variable ValidFrom With DataType As String 
        Private strValidTo As String ' Define Private Variable ValidTo With DataType As String 
        Private strStatus As String ' Define Private Variable Status With DataType As String 
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
        ''' Get or Set the Value of EquipmentId
        ''' </summary>
        ''' <value>lngEquipmentId</value>
        ''' <returns> Return lngEquipmentId</returns>
        ''' <remarks> Get or Set the Value of EquipmentId  </remarks>
        '''
        Public Property EquipmentId() as Long
            Get
                Return lngEquipmentId
            End Get
            Set(ByVal value As Long)
                lngEquipmentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EquipmentNo
        ''' </summary>
        ''' <value>strEquipmentNo</value>
        ''' <returns> Return strEquipmentNo</returns>
        ''' <remarks> Get or Set the Value of EquipmentNo  </remarks>
        '''
        Public Property EquipmentNo() as String
            Get
                Return strEquipmentNo
            End Get
            Set(ByVal value As String)
                strEquipmentNo = value
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
        ''' Get or Set the Value of Capacity
        ''' </summary>
        ''' <value>lngCapacity</value>
        ''' <returns> Return lngCapacity</returns>
        ''' <remarks> Get or Set the Value of Capacity  </remarks>
        '''
        Public Property Capacity() as Long
            Get
                Return lngCapacity
            End Get
            Set(ByVal value As Long)
                lngCapacity = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ValidFrom
        ''' </summary>
        ''' <value>strValidFrom</value>
        ''' <returns> Return strValidFrom</returns>
        ''' <remarks> Get or Set the Value of ValidFrom  </remarks>
        '''
        Public Property ValidFrom() as String
            Get
                Return strValidFrom
            End Get
            Set(ByVal value As String)
                strValidFrom = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ValidTo
        ''' </summary>
        ''' <value>strValidTo</value>
        ''' <returns> Return strValidTo</returns>
        ''' <remarks> Get or Set the Value of ValidTo  </remarks>
        '''
        Public Property ValidTo() as String
            Get
                Return strValidTo
            End Get
            Set(ByVal value As String)
                strValidTo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Status
        ''' </summary>
        ''' <value>strStatus</value>
        ''' <returns> Return strStatus</returns>
        ''' <remarks> Get or Set the Value of Status  </remarks>
        '''
        Public Property Status() as String
            Get
                Return strStatus
            End Get
            Set(ByVal value As String)
                strStatus = value
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
            lngEquipmentId = 0 
            strEquipmentNo = ""
            strEquipmentTypeCode = ""
            lngCapacity = 0 
            strValidFrom = ""
            strValidTo = ""
            strStatus = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pEquipmentDetails"></param>
        ''' <returns>Return pEquipmentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentDetails.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentDetails.EquipRefId)
                db.AddParameter("p_EQUIPMENT_ID", pEquipmentDetails.EquipmentId, ParameterDirection.Output)
                db.AddParameter("p_EQUIPMENT_NO", pEquipmentDetails.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentDetails.EquipmentTypeCode)
                db.AddParameter("p_CAPACITY", pEquipmentDetails.Capacity)
                db.AddParameter("p_VALID_FROM", pEquipmentDetails.ValidFrom)
                db.AddParameter("p_VALID_TO", pEquipmentDetails.ValidTo)
                db.AddParameter("p_STATUS", pEquipmentDetails.Status)
                db.AddParameter("p_CREATED_BY", pEquipmentDetails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentDetails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pEquipmentDetails.EquipmentId  = db.Parameters.Item("p_EQUIPMENT_ID").value
                
                If pEquipmentDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentDetails"></param>
        ''' <returns>Return pEquipmentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentDetails.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentDetails.EquipRefId)
                db.AddParameter("p_EQUIPMENT_ID", pEquipmentDetails.EquipmentId, ParameterDirection.Output)
                db.AddParameter("p_EQUIPMENT_NO", pEquipmentDetails.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentDetails.EquipmentTypeCode)
                db.AddParameter("p_CAPACITY", pEquipmentDetails.Capacity)
                db.AddParameter("p_VALID_FROM", pEquipmentDetails.ValidFrom)
                db.AddParameter("p_VALID_TO", pEquipmentDetails.ValidTo)
                db.AddParameter("p_STATUS", pEquipmentDetails.Status)
                db.AddParameter("p_CREATED_BY", pEquipmentDetails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentDetails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_EQUIPMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pEquipmentDetails.EquipmentId  = db.Parameters.Item("p_EQUIPMENT_ID").value
                
            Catch ex As Exception
                pEquipmentDetails.ErrorMsg = ex.Message
            End Try
            Return pEquipmentDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pEquipmentDetails"></param>
        ''' <returns>Return pEquipmentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentDetails.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentDetails.EquipRefId)
                db.AddParameter("p_EQUIPMENT_ID", pEquipmentDetails.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pEquipmentDetails.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentDetails.EquipmentTypeCode)
                db.AddParameter("p_CAPACITY", pEquipmentDetails.Capacity)
                db.AddParameter("p_VALID_FROM", pEquipmentDetails.ValidFrom)
                db.AddParameter("p_VALID_TO", pEquipmentDetails.ValidTo)
                db.AddParameter("p_STATUS", pEquipmentDetails.Status)
                db.AddParameter("p_CREATED_BY", pEquipmentDetails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentDetails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pEquipmentDetails.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pEquipmentDetails.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pEquipmentDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pEquipmentDetails"></param>
        ''' <returns>Return pEquipmentDetails Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pEquipmentDetails.TerminalId)
                db.AddParameter("p_EQUIP_REF_ID", pEquipmentDetails.EquipRefId)
                db.AddParameter("p_EQUIPMENT_ID", pEquipmentDetails.EquipmentId)
                db.AddParameter("p_EQUIPMENT_NO", pEquipmentDetails.EquipmentNo)
                db.AddParameter("p_EQUIPMENT_TYPE_CODE", pEquipmentDetails.EquipmentTypeCode)
                db.AddParameter("p_CAPACITY", pEquipmentDetails.Capacity)
                db.AddParameter("p_VALID_FROM", pEquipmentDetails.ValidFrom)
                db.AddParameter("p_VALID_TO", pEquipmentDetails.ValidTo)
                db.AddParameter("p_STATUS", pEquipmentDetails.Status)
                db.AddParameter("p_CREATED_BY", pEquipmentDetails.CreatedBy)
                db.AddParameter("p_CREATED_ON", pEquipmentDetails.CreatedOn)
                db.AddParameter("p_ErrorMsg", pEquipmentDetails.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_EQUIPMENT_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pEquipmentDetails.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pEquipmentDetails.ErrorMsg = ex.Message
                End Try
            Return pEquipmentDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PEquipmentDetails.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIP_REF_ID").ToString <> "" Then
                                PEquipmentDetails.EquipRefId = dbr("EQUIP_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                PEquipmentDetails.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_NO").ToString <> "" Then
                                PEquipmentDetails.EquipmentNo = dbr("EQUIPMENT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_TYPE_CODE").ToString <> "" Then
                                PEquipmentDetails.EquipmentTypeCode = dbr("EQUIPMENT_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CAPACITY").ToString <> "" Then
                                PEquipmentDetails.Capacity = dbr("CAPACITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALID_FROM").ToString <> "" Then
                                PEquipmentDetails.ValidFrom = dbr("VALID_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALID_TO").ToString <> "" Then
                                PEquipmentDetails.ValidTo = dbr("VALID_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                PEquipmentDetails.Status = dbr("STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pEquipmentDetails.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pEquipmentDetails.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pEquipmentDetails.ErrorMsg = ex.Message
            End Try
            Return pEquipmentDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrEquipmentDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New EquipmentDetails
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
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                temp.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_NO").ToString <> "" Then
                                temp.EquipmentNo = dbr("EQUIPMENT_NO")
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
                            If dbr("CAPACITY").ToString <> "" Then
                                temp.Capacity = dbr("CAPACITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALID_FROM").ToString <> "" Then
                                temp.ValidFrom = dbr("VALID_FROM")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VALID_TO").ToString <> "" Then
                                temp.ValidTo = dbr("VALID_TO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATUS").ToString <> "" Then
                                temp.Status = dbr("STATUS")
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
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentDetailsListByEquipRefId(ByVal pEquipmentDetails As EquipmentDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrEquipmentDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_DETAILS_BY_ID", pEquipmentDetails.TerminalId & "," & pEquipmentDetails.EquipRefId)
                arrEquipmentDetails = ReturnObjectValuesList(dbr, arrEquipmentDetails)
                dbr.Close()
            Catch ex As Exception
                arrEquipmentDetails = Nothing
            End Try
            db.CloseDB()
            Return arrEquipmentDetails
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentDetailsListByEquipRefIdTpt(ByVal pEquipmentDetails As EquipmentDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrEquipmentDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_DETAILS_BY_ID_TPT", pEquipmentDetails.TerminalId & "," & pEquipmentDetails.EquipRefId)
                arrEquipmentDetails = ReturnObjectValuesList(dbr, arrEquipmentDetails)
                dbr.Close()
            Catch ex As Exception
                arrEquipmentDetails = Nothing
            End Try
            db.CloseDB()
            Return arrEquipmentDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnEquipmentList(ByVal pEquipmentDetails As EquipmentDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrEquipmentDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_DETAILS_BY_ALL", pEquipmentDetails.TerminalId)
                arrEquipmentDetails = ReturnObjectValuesList(dbr, arrEquipmentDetails)
                dbr.Close()
            Catch ex As Exception
                arrEquipmentDetails = Nothing
            End Try
            db.CloseDB()
            Return arrEquipmentDetails
        End Function

        Public Shared Function ReturnEquipmentDetailsByEquipmentNo(ByVal pEquipmentDetails As EquipmentDetails) As EquipmentDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EQUIPMENT_DTLS_BY_EQUIP_NO", pEquipmentDetails.TerminalId & ",'" & pEquipmentDetails.EquipmentNo & "'")
                pEquipmentDetails = ReturnObjectValues(dbr, pEquipmentDetails)
                dbr.Close()
            Catch ex As Exception
                pEquipmentDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pEquipmentDetails
        End Function
    End Class
End Namespace
