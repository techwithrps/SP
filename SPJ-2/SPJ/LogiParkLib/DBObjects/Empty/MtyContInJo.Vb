Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyContInJo
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MtyContInJo

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMtyContInJoId As Long ' Define Private Variable MtyContInJoId With DataType As Long 
        Private strMtyContInJoNo As String ' Define Private Variable MtyContInJoNo With DataType As String 
        Private strMtyContInJoDate As String ' Define Private Variable MtyContInJoDate With DataType As String 
        Private strMtyContInJoValidity As String ' Define Private Variable MtyContInJoValidity With DataType As String 
        Private lngTransporterId As Long ' Define Private Variable TransporterId With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private lngShipperId As Long ' Define Private Variable ShipperId With DataType As Long 
        Private lngAccountId As Long ' Define Private Variable AccountId With DataType As Long


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
        ''' Get or Set the Value of MtyContInJoId
        ''' </summary>
        ''' <value>lngMtyContInJoId</value>
        ''' <returns> Return lngMtyContInJoId</returns>
        ''' <remarks> Get or Set the Value of MtyContInJoId  </remarks>
        '''
        Public Property MtyContInJoId() As Long
            Get
                Return lngMtyContInJoId
            End Get
            Set(ByVal value As Long)
                lngMtyContInJoId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyContInJoNo
        ''' </summary>
        ''' <value>strMtyContInJoNo</value>
        ''' <returns> Return strMtyContInJoNo</returns>
        ''' <remarks> Get or Set the Value of MtyContInJoNo  </remarks>
        '''
        Public Property MtyContInJoNo() As String
            Get
                Return strMtyContInJoNo
            End Get
            Set(ByVal value As String)
                strMtyContInJoNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyContInJoDate
        ''' </summary>
        ''' <value>strMtyContInJoDate</value>
        ''' <returns> Return strMtyContInJoDate</returns>
        ''' <remarks> Get or Set the Value of MtyContInJoDate  </remarks>
        '''
        Public Property MtyContInJoDate() As String
            Get
                Return strMtyContInJoDate
            End Get
            Set(ByVal value As String)
                strMtyContInJoDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyContInJoValidity
        ''' </summary>
        ''' <value>strMtyContInJoValidity</value>
        ''' <returns> Return strMtyContInJoValidity</returns>
        ''' <remarks> Get or Set the Value of MtyContInJoValidity  </remarks>
        '''
        Public Property MtyContInJoValidity() As String
            Get
                Return strMtyContInJoValidity
            End Get
            Set(ByVal value As String)
                strMtyContInJoValidity = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TransporterId
        ''' </summary>
        ''' <value>lngTransporterId</value>
        ''' <returns> Return lngTransporterId</returns>
        ''' <remarks> Get or Set the Value of TransporterId  </remarks>
        '''
        Public Property TransporterId() As Long
            Get
                Return lngTransporterId
            End Get
            Set(ByVal value As Long)
                lngTransporterId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() As Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() As String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
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
        Public Property ShipperId() As Long
            Get
                Return lngShipperId
            End Get
            Set(ByVal value As Long)
                lngShipperId = value
            End Set
        End Property
        Public Property AccountId() As Long
            Get
                Return lngAccountId
            End Get
            Set(ByVal value As Long)
                lngAccountId = value
            End Set
        End Property




        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngMtyContInJoId = 0
            strMtyContInJoNo = ""
            strMtyContInJoDate = ""
            strMtyContInJoValidity = ""
            lngTransporterId = 0
            lngLineId = 0
            strRemarks = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
            lngShipperId = 0
            lngAccountId = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMtyContInJo"></param>
        ''' <returns>Return pMtyContInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJo.TerminalId)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJo.MtyContInJoId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_NO", pMtyContInJo.MtyContInJoNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_DATE", pMtyContInJo.MtyContInJoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_VALIDITY", pMtyContInJo.MtyContInJoValidity, ParameterDirection.Output)
                db.AddParameter("p_TRANSPORTER_ID", pMtyContInJo.TransporterId)
                db.AddParameter("p_LINE_ID", pMtyContInJo.LineId)
                db.AddParameter("p_REMARKS", pMtyContInJo.Remarks)
                db.AddParameter("p_CREATED_BY", pMtyContInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJo.CreatedOn)
                db.AddParameter("p_SHIPPER_ID", pMtyContInJo.ShipperId)
                db.AddParameter("p_ACCOUNT_ID", pMtyContInJo.AccountId)
                db.AddParameter("p_ErrorMsg", pMtyContInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONT_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContInJo.MtyContInJoId = db.Parameters.Item("p_MTY_CONT_IN_JO_ID").value.ToString
                pMtyContInJo.MtyContInJoNo = db.Parameters.Item("p_MTY_CONT_IN_JO_NO").value.ToString
                pMtyContInJo.MtyContInJoDate = db.Parameters.Item("p_MTY_CONT_IN_JO_DATE").value.ToString
                pMtyContInJo.MtyContInJoValidity = db.Parameters.Item("p_MTY_CONT_IN_JO_VALIDITY").value.ToString
                If pMtyContInJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContInJo"></param>
        ''' <returns>Return pMtyContInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJo.TerminalId)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJo.MtyContInJoId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_NO", pMtyContInJo.MtyContInJoNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_DATE", pMtyContInJo.MtyContInJoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_JO_VALIDITY", pMtyContInJo.MtyContInJoValidity, ParameterDirection.Output)
                db.AddParameter("p_TRANSPORTER_ID", pMtyContInJo.TransporterId)
                db.AddParameter("p_LINE_ID", pMtyContInJo.LineId)
                db.AddParameter("p_REMARKS", pMtyContInJo.Remarks)
                db.AddParameter("p_CREATED_BY", pMtyContInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJo.CreatedOn)
                db.AddParameter("p_SHIPPER_ID", pMtyContInJo.ShipperId)
                db.AddParameter("p_ACCOUNT_ID", pMtyContInJo.AccountId)
                db.AddParameter("p_ErrorMsg", pMtyContInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONT_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContInJo.MtyContInJoId = db.Parameters.Item("p_MTY_CONT_IN_JO_ID").value.ToString
                pMtyContInJo.MtyContInJoNo = db.Parameters.Item("p_MTY_CONT_IN_JO_NO").value.ToString
                pMtyContInJo.MtyContInJoDate = db.Parameters.Item("p_MTY_CONT_IN_JO_DATE").value.ToString
                pMtyContInJo.MtyContInJoValidity = db.Parameters.Item("p_MTY_CONT_IN_JO_VALIDITY").value.ToString

            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
            End Try
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMtyContInJo"></param>
        ''' <returns>Return pMtyContInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJo.TerminalId)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJo.MtyContInJoId)
                db.AddParameter("p_MTY_CONT_IN_JO_NO", pMtyContInJo.MtyContInJoNo)
                db.AddParameter("p_MTY_CONT_IN_JO_DATE", pMtyContInJo.MtyContInJoDate)
                db.AddParameter("p_MTY_CONT_IN_JO_VALIDITY", pMtyContInJo.MtyContInJoValidity)
                db.AddParameter("p_TRANSPORTER_ID", pMtyContInJo.TransporterId)
                db.AddParameter("p_LINE_ID", pMtyContInJo.LineId)
                db.AddParameter("p_REMARKS", pMtyContInJo.Remarks)
                db.AddParameter("p_CREATED_BY", pMtyContInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONT_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyContInJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContInJo"></param>
        ''' <returns>Return pMtyContInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJo.TerminalId)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJo.MtyContInJoId)
                db.AddParameter("p_MTY_CONT_IN_JO_NO", pMtyContInJo.MtyContInJoNo)
                db.AddParameter("p_MTY_CONT_IN_JO_DATE", pMtyContInJo.MtyContInJoDate)
                db.AddParameter("p_MTY_CONT_IN_JO_VALIDITY", pMtyContInJo.MtyContInJoValidity)
                db.AddParameter("p_TRANSPORTER_ID", pMtyContInJo.TransporterId)
                db.AddParameter("p_LINE_ID", pMtyContInJo.LineId)
                db.AddParameter("p_REMARKS", pMtyContInJo.Remarks)
                db.AddParameter("p_CREATED_BY", pMtyContInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pMtyContInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONT_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
            End Try
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pMtyContInJo.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_ID").ToString <> "" Then
                                pMtyContInJo.MtyContInJoId = dbr("MTY_CONT_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_NO").ToString <> "" Then
                                pMtyContInJo.MtyContInJoNo = dbr("MTY_CONT_IN_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_DATE").ToString <> "" Then
                                pMtyContInJo.MtyContInJoDate = dbr("MTY_CONT_IN_JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_VALIDITY").ToString <> "" Then
                                pMtyContInJo.MtyContInJoValidity = dbr("MTY_CONT_IN_JO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                pMtyContInJo.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pMtyContInJo.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pMtyContInJo.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pMtyContInJo.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pMtyContInJo.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SHIPPER_ID").ToString <> "" Then
                                pMtyContInJo.ShipperId = dbr("SHIPPER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_ID").ToString <> "" Then
                                pMtyContInJo.AccountId = dbr("ACCOUNT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try

                    End While
                End If
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
            End Try
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyContInJo As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MtyContInJo
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_ID").ToString <> "" Then
                                temp.MtyContInJoId = dbr("MTY_CONT_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_NO").ToString <> "" Then
                                temp.MtyContInJoNo = dbr("MTY_CONT_IN_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_DATE").ToString <> "" Then
                                temp.MtyContInJoDate = dbr("MTY_CONT_IN_JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_VALIDITY").ToString <> "" Then
                                temp.MtyContInJoValidity = dbr("MTY_CONT_IN_JO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                temp.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
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
                            If dbr("SHIPPER_ID").ToString <> "" Then
                                temp.ShipperId = dbr("SHIPPER_ID ")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_ID").ToString <> "" Then
                                temp.AccountId = dbr("ACCOUNT_ID ")
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
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyContInJo(ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_BY_ID", pMtyContInJo.TerminalId & "," & pMtyContInJo.MtyContInJoId)
                pMtyContInJo = ReturnObjectValues(dbr, pMtyContInJo)
                dbr.Close()
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContInJo
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContInJoList(ByVal pMtyContInJo As MtyContInJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContInJo As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_BY_ALL", pMtyContInJo.TerminalId)
                arrMtyContInJo = ReturnObjectValuesList(dbr, arrMtyContInJo)
                dbr.Close()
            Catch ex As Exception
                arrMtyContInJo = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContInJo
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContInJoListByJoNo(ByVal pMtyContInJo As MtyContInJo) As MtyContInJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_BY_JO_NO", pMtyContInJo.TerminalId & ",'" & pMtyContInJo.MtyContInJoNo & "'")
                pMtyContInJo = ReturnObjectValues(dbr, pMtyContInJo)
                dbr.Close()
            Catch ex As Exception
                pMtyContInJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContInJo
        End Function
    End Class
End Namespace
