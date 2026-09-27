Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TranshipmentJo
    ''' @author	: Santosh Singh- 26/8/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TranshipmentJo

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngJoId As Long ' Define Private Variable JoId With DataType As Long 
        Private strJoNo As String ' Define Private Variable JoNo With DataType As String 
        Private strJoDate As String ' Define Private Variable JoDate With DataType As String 
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private lngCargoWt As Long ' Define Private Variable CargoWt With DataType As Long 
        Private strGateInDate As String ' Define Private Variable GateInDate With DataType As String 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngBookingId As Long ' Define Private Variable BookingId With DataType As Long 
        Private lngAllotId As Long ' Define Private Variable AllotId With DataType As Long 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private lngNewContId As Long ' Define Private Variable NewContId With DataType As Long 
        Private strNewContNo As String ' Define Private Variable NewContNo With DataType As String 
        Private strNewContSize As String ' Define Private Variable NewContSize With DataType As String 
        Private strNewContType As String ' Define Private Variable NewContType With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Dim arrContTranshipmentlist As New ArrayList
        Public Property ContTranshipmentlist() As ArrayList
            Get
                Return arrContTranshipmentlist
            End Get
            Set(ByVal value As ArrayList)
                arrContTranshipmentlist = value
            End Set
        End Property

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
        ''' Get or Set the Value of JoId
        ''' </summary>
        ''' <value>lngJoId</value>
        ''' <returns> Return lngJoId</returns>
        ''' <remarks> Get or Set the Value of JoId  </remarks>
        '''
        Public Property JoId() As Long
            Get
                Return lngJoId
            End Get
            Set(ByVal value As Long)
                lngJoId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoNo
        ''' </summary>
        ''' <value>strJoNo</value>
        ''' <returns> Return strJoNo</returns>
        ''' <remarks> Get or Set the Value of JoNo  </remarks>
        '''
        Public Property JoNo() As String
            Get
                Return strJoNo
            End Get
            Set(ByVal value As String)
                strJoNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of JoDate
        ''' </summary>
        ''' <value>strJoDate</value>
        ''' <returns> Return strJoDate</returns>
        ''' <remarks> Get or Set the Value of JoDate  </remarks>
        '''
        Public Property JoDate() As String
            Get
                Return strJoDate
            End Get
            Set(ByVal value As String)
                strJoDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MtyContId
        ''' </summary>
        ''' <value>lngMtyContId</value>
        ''' <returns> Return lngMtyContId</returns>
        ''' <remarks> Get or Set the Value of MtyContId  </remarks>
        '''
        Public Property MtyContId() As Long
            Get
                Return lngMtyContId
            End Get
            Set(ByVal value As Long)
                lngMtyContId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property ContNo() As String
            Get
                Return strContNo
            End Get
            Set(ByVal value As String)
                strContNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks> Get or Set the Value of ContSize  </remarks>
        '''
        Public Property ContSize() As String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property ContType() As String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CargoWt
        ''' </summary>
        ''' <value>lngCargoWt</value>
        ''' <returns> Return lngCargoWt</returns>
        ''' <remarks> Get or Set the Value of CargoWt  </remarks>
        '''
        Public Property CargoWt() As Long
            Get
                Return lngCargoWt
            End Get
            Set(ByVal value As Long)
                lngCargoWt = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of GateInDate
        ''' </summary>
        ''' <value>strGateInDate</value>
        ''' <returns> Return strGateInDate</returns>
        ''' <remarks> Get or Set the Value of GateInDate  </remarks>
        '''
        Public Property GateInDate() As String
            Get
                Return strGateInDate
            End Get
            Set(ByVal value As String)
                strGateInDate = value
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
        ''' Get or Set the Value of BookingId
        ''' </summary>
        ''' <value>lngBookingId</value>
        ''' <returns> Return lngBookingId</returns>
        ''' <remarks> Get or Set the Value of BookingId  </remarks>
        '''
        Public Property BookingId() As Long
            Get
                Return lngBookingId
            End Get
            Set(ByVal value As Long)
                lngBookingId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of AllotId
        ''' </summary>
        ''' <value>lngAllotId</value>
        ''' <returns> Return lngAllotId</returns>
        ''' <remarks> Get or Set the Value of AllotId  </remarks>
        '''
        Public Property AllotId() As Long
            Get
                Return lngAllotId
            End Get
            Set(ByVal value As Long)
                lngAllotId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() As String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NewContId
        ''' </summary>
        ''' <value>lngNewContId</value>
        ''' <returns> Return lngNewContId</returns>
        ''' <remarks> Get or Set the Value of NewContId  </remarks>
        '''
        Public Property NewContId() As Long
            Get
                Return lngNewContId
            End Get
            Set(ByVal value As Long)
                lngNewContId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NewContNo
        ''' </summary>
        ''' <value>strNewContNo</value>
        ''' <returns> Return strNewContNo</returns>
        ''' <remarks> Get or Set the Value of NewContNo  </remarks>
        '''
        Public Property NewContNo() As String
            Get
                Return strNewContNo
            End Get
            Set(ByVal value As String)
                strNewContNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NewContSize
        ''' </summary>
        ''' <value>strNewContSize</value>
        ''' <returns> Return strNewContSize</returns>
        ''' <remarks> Get or Set the Value of NewContSize  </remarks>
        '''
        Public Property NewContSize() As String
            Get
                Return strNewContSize
            End Get
            Set(ByVal value As String)
                strNewContSize = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of NewContType
        ''' </summary>
        ''' <value>strNewContType</value>
        ''' <returns> Return strNewContType</returns>
        ''' <remarks> Get or Set the Value of NewContType  </remarks>
        '''
        Public Property NewContType() As String
            Get
                Return strNewContType
            End Get
            Set(ByVal value As String)
                strNewContType = value
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
            lngJoId = 0
            strJoNo = ""
            strJoDate = ""
            lngMtyContId = 0
            strContNo = ""
            strContSize = ""
            strContType = ""
            lngCargoWt = 0
            strGateInDate = ""
            lngLineId = 0
            lngBookingId = 0
            lngAllotId = 0
            strDocType = ""
            lngNewContId = 0
            strNewContNo = ""
            strNewContSize = ""
            strNewContType = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTranshipmentJo"></param>
        ''' <returns>Return pTranshipmentJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTranshipmentJo.TerminalId)
                db.AddParameter("p_JO_ID", pTranshipmentJo.JoId)
                db.AddParameter("p_JO_NO", pTranshipmentJo.JoNo)
                db.AddParameter("p_JO_DATE", pTranshipmentJo.JoDate)
                db.AddParameter("p_MTY_CONT_ID", pTranshipmentJo.MtyContId)
                db.AddParameter("p_CONT_NO", pTranshipmentJo.ContNo)
                db.AddParameter("p_CONT_SIZE", pTranshipmentJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pTranshipmentJo.ContType)
                db.AddParameter("p_CARGO_WT", pTranshipmentJo.CargoWt)
                db.AddParameter("p_GATE_IN_DATE", pTranshipmentJo.GateInDate)
                db.AddParameter("p_LINE_ID", pTranshipmentJo.LineId)
                db.AddParameter("p_BOOKING_ID", pTranshipmentJo.BookingId)
                db.AddParameter("p_ALLOT_ID", pTranshipmentJo.AllotId)
                db.AddParameter("p_DOC_TYPE", pTranshipmentJo.DocType)
                db.AddParameter("p_NEW_CONT_ID", pTranshipmentJo.NewContId)
                db.AddParameter("p_NEW_CONT_NO", pTranshipmentJo.NewContNo)
                db.AddParameter("p_NEW_CONT_SIZE", pTranshipmentJo.NewContSize)
                db.AddParameter("p_NEW_CONT_TYPE", pTranshipmentJo.NewContType)
                db.AddParameter("p_CREATED_BY", pTranshipmentJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTranshipmentJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTranshipmentJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TRANSHIPMENT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTranshipmentJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pTranshipmentJo.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTranshipmentJo.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTranshipmentJo"></param>
        ''' <returns>Return pTranshipmentJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTranshipmentJo.TerminalId)
                db.AddParameter("p_JO_ID", pTranshipmentJo.JoId)
                db.AddParameter("p_JO_NO", pTranshipmentJo.JoNo)
                db.AddParameter("p_JO_DATE", pTranshipmentJo.JoDate)
                db.AddParameter("p_MTY_CONT_ID", pTranshipmentJo.MtyContId)
                db.AddParameter("p_CONT_NO", pTranshipmentJo.ContNo)
                db.AddParameter("p_CONT_SIZE", pTranshipmentJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pTranshipmentJo.ContType)
                db.AddParameter("p_CARGO_WT", pTranshipmentJo.CargoWt)
                db.AddParameter("p_GATE_IN_DATE", pTranshipmentJo.GateInDate)
                db.AddParameter("p_LINE_ID", pTranshipmentJo.LineId)
                db.AddParameter("p_BOOKING_ID", pTranshipmentJo.BookingId)
                db.AddParameter("p_ALLOT_ID", pTranshipmentJo.AllotId)
                db.AddParameter("p_DOC_TYPE", pTranshipmentJo.DocType)
                db.AddParameter("p_NEW_CONT_ID", pTranshipmentJo.NewContId)
                db.AddParameter("p_NEW_CONT_NO", pTranshipmentJo.NewContNo)
                db.AddParameter("p_NEW_CONT_SIZE", pTranshipmentJo.NewContSize)
                db.AddParameter("p_NEW_CONT_TYPE", pTranshipmentJo.NewContType)
                db.AddParameter("p_CREATED_BY", pTranshipmentJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTranshipmentJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTranshipmentJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CONT_TRANSHIP_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTranshipmentJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pTranshipmentJo.ErrorMsg = ex.Message
            End Try
            Return pTranshipmentJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTranshipmentJo"></param>
        ''' <returns>Return pTranshipmentJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTranshipmentJo.TerminalId)
                db.AddParameter("p_JO_ID", pTranshipmentJo.JoId)
                db.AddParameter("p_JO_NO", pTranshipmentJo.JoNo)
                db.AddParameter("p_JO_DATE", pTranshipmentJo.JoDate)
                db.AddParameter("p_MTY_CONT_ID", pTranshipmentJo.MtyContId)
                db.AddParameter("p_CONT_NO", pTranshipmentJo.ContNo)
                db.AddParameter("p_CONT_SIZE", pTranshipmentJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pTranshipmentJo.ContType)
                db.AddParameter("p_CARGO_WT", pTranshipmentJo.CargoWt)
                db.AddParameter("p_GATE_IN_DATE", pTranshipmentJo.GateInDate)
                db.AddParameter("p_LINE_ID", pTranshipmentJo.LineId)
                db.AddParameter("p_BOOKING_ID", pTranshipmentJo.BookingId)
                db.AddParameter("p_ALLOT_ID", pTranshipmentJo.AllotId)
                db.AddParameter("p_DOC_TYPE", pTranshipmentJo.DocType)
                db.AddParameter("p_NEW_CONT_ID", pTranshipmentJo.NewContId)
                db.AddParameter("p_NEW_CONT_NO", pTranshipmentJo.NewContNo)
                db.AddParameter("p_NEW_CONT_SIZE", pTranshipmentJo.NewContSize)
                db.AddParameter("p_NEW_CONT_TYPE", pTranshipmentJo.NewContType)
                db.AddParameter("p_CREATED_BY", pTranshipmentJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTranshipmentJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTranshipmentJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CONT_TRANSHIP_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTranshipmentJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTranshipmentJo.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTranshipmentJo.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTranshipmentJo"></param>
        ''' <returns>Return pTranshipmentJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTranshipmentJo.TerminalId)
                db.AddParameter("p_JO_ID", pTranshipmentJo.JoId)
                db.AddParameter("p_JO_NO", pTranshipmentJo.JoNo)
                db.AddParameter("p_JO_DATE", pTranshipmentJo.JoDate)
                db.AddParameter("p_MTY_CONT_ID", pTranshipmentJo.MtyContId)
                db.AddParameter("p_CONT_NO", pTranshipmentJo.ContNo)
                db.AddParameter("p_CONT_SIZE", pTranshipmentJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pTranshipmentJo.ContType)
                db.AddParameter("p_CARGO_WT", pTranshipmentJo.CargoWt)
                db.AddParameter("p_GATE_IN_DATE", pTranshipmentJo.GateInDate)
                db.AddParameter("p_LINE_ID", pTranshipmentJo.LineId)
                db.AddParameter("p_BOOKING_ID", pTranshipmentJo.BookingId)
                db.AddParameter("p_ALLOT_ID", pTranshipmentJo.AllotId)
                db.AddParameter("p_DOC_TYPE", pTranshipmentJo.DocType)
                db.AddParameter("p_NEW_CONT_ID", pTranshipmentJo.NewContId)
                db.AddParameter("p_NEW_CONT_NO", pTranshipmentJo.NewContNo)
                db.AddParameter("p_NEW_CONT_SIZE", pTranshipmentJo.NewContSize)
                db.AddParameter("p_NEW_CONT_TYPE", pTranshipmentJo.NewContType)
                db.AddParameter("p_CREATED_BY", pTranshipmentJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTranshipmentJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTranshipmentJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TRANSHIPMENT_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTranshipmentJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTranshipmentJo.ErrorMsg = ex.Message
            End Try
            Return pTranshipmentJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTranshipmentJo.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                PTranshipmentJo.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                PTranshipmentJo.JoNo = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                PTranshipmentJo.JoDate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                PTranshipmentJo.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PTranshipmentJo.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PTranshipmentJo.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PTranshipmentJo.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_WT").ToString <> "" Then
                                PTranshipmentJo.CargoWt = dbr("CARGO_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_IN_DATE").ToString <> "" Then
                                PTranshipmentJo.GateInDate = dbr("GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PTranshipmentJo.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_ID").ToString <> "" Then
                                PTranshipmentJo.BookingId = dbr("BOOKING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOT_ID").ToString <> "" Then
                                PTranshipmentJo.AllotId = dbr("ALLOT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PTranshipmentJo.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_ID").ToString <> "" Then
                                PTranshipmentJo.NewContId = dbr("NEW_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_NO").ToString <> "" Then
                                PTranshipmentJo.NewContNo = dbr("NEW_CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_SIZE").ToString <> "" Then
                                PTranshipmentJo.NewContSize = dbr("NEW_CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_TYPE").ToString <> "" Then
                                PTranshipmentJo.NewContType = dbr("NEW_CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTranshipmentJo.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTranshipmentJo.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pTranshipmentJo.ErrorMsg = ex.Message
            End Try
            Return pTranshipmentJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTranshipmentJo As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TranshipmentJo
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_ID").ToString <> "" Then
                                temp.JoId = dbr("JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_NO").ToString <> "" Then
                                temp.JoNo = dbr("JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_DATE").ToString <> "" Then
                                temp.JoDate = dbr("JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                temp.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                temp.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                temp.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CARGO_WT").ToString <> "" Then
                                temp.CargoWt = dbr("CARGO_WT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GATE_IN_DATE").ToString <> "" Then
                                temp.GateInDate = dbr("GATE_IN_DATE")
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
                            If dbr("BOOKING_ID").ToString <> "" Then
                                temp.BookingId = dbr("BOOKING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOT_ID").ToString <> "" Then
                                temp.AllotId = dbr("ALLOT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_ID").ToString <> "" Then
                                temp.NewContId = dbr("NEW_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_NO").ToString <> "" Then
                                temp.NewContNo = dbr("NEW_CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_SIZE").ToString <> "" Then
                                temp.NewContSize = dbr("NEW_CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NEW_CONT_TYPE").ToString <> "" Then
                                temp.NewContType = dbr("NEW_CONT_TYPE")
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
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTranshipmentdtls(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONT_TRANSHI_JO", pTranshipmentJo.TerminalId & ",'" & pTranshipmentJo.ContNo & "'")
                pTranshipmentJo = ReturnObjectValues(dbr, pTranshipmentJo)
                dbr.Close()
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function
        Public Shared Function ReturnContdtls(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CONTAINER_TRANSHIPMENT", pTranshipmentJo.TerminalId & ",'" & pTranshipmentJo.ContNo & "'")
                pTranshipmentJo = ReturnObjectValues(dbr, pTranshipmentJo)
                dbr.Close()
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function
        Public Shared Function ReturnOldContdtls(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SEARCH_TRANSHIPMENT", pTranshipmentJo.TerminalId & ",'" & pTranshipmentJo.ContNo & "'")
                pTranshipmentJo = ReturnObjectValues(dbr, pTranshipmentJo)
                dbr.Close()
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function
        Public Shared Function ReturnOldContdtlsArr(ByVal pTranshipmentJo As TranshipmentJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrExpContAllotCancel As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SEARCH_TRANSHIPMENT", pTranshipmentJo.TerminalId & ",'" & pTranshipmentJo.ContNo & "'")
                arrExpContAllotCancel = ReturnObjectValuesList(dbr, arrExpContAllotCancel)
                dbr.Close()
            Catch ex As Exception
                arrExpContAllotCancel = Nothing
            End Try
            db.CloseDB()
            Return arrExpContAllotCancel
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTranshipmentJoList(ByVal pTranshipmentJo As TranshipmentJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTranshipmentJo As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TRANSHIPMENT_JO", "' '")
                arrTranshipmentJo = ReturnObjectValuesList(dbr, arrTranshipmentJo)
                dbr.Close()
            Catch ex As Exception
                arrTranshipmentJo = Nothing
            End Try
            db.CloseDB()
            Return arrTranshipmentJo
        End Function


        Public Shared Function ReturnMtycontdtls(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_TRANSHIPMENT", pTranshipmentJo.TerminalId & ", " & pTranshipmentJo.LineId & ",'" & pTranshipmentJo.ContNo & "'")
                pTranshipmentJo = ReturnObjectValues(dbr, pTranshipmentJo)
                dbr.Close()
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function
        Public Shared Function UpdateTranshipment(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTranshipmentJo.TerminalId)
                db.AddParameter("p_JO_ID", pTranshipmentJo.JoId, ParameterDirection.Output)
                db.AddParameter("p_JO_NO", pTranshipmentJo.JoNo, ParameterDirection.Output)
                db.AddParameter("p_JO_DATE", pTranshipmentJo.JoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_ID", pTranshipmentJo.MtyContId, )
                db.AddParameter("p_CONT_NO", pTranshipmentJo.ContNo)
                db.AddParameter("p_CONT_SIZE", pTranshipmentJo.ContSize)
                db.AddParameter("p_CONT_TYPE", pTranshipmentJo.ContType)
                db.AddParameter("p_CARGO_WT", pTranshipmentJo.CargoWt)
                db.AddParameter("p_GATE_IN_DATE", pTranshipmentJo.GateInDate)
                db.AddParameter("p_LINE_ID", pTranshipmentJo.LineId)
                db.AddParameter("p_BOOKING_ID", pTranshipmentJo.BookingId)
                db.AddParameter("p_ALLOT_ID", pTranshipmentJo.AllotId)
                db.AddParameter("p_DOC_TYPE", pTranshipmentJo.DocType)
                db.AddParameter("p_NEW_CONT_ID", pTranshipmentJo.NewContId)
                db.AddParameter("p_NEW_CONT_NO", pTranshipmentJo.NewContNo)
                db.AddParameter("p_NEW_CONT_SIZE", pTranshipmentJo.NewContSize)
                db.AddParameter("p_NEW_CONT_TYPE", pTranshipmentJo.NewContType)
                db.AddParameter("p_CREATED_BY", pTranshipmentJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTranshipmentJo.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTranshipmentJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CONT_TRANSHIP_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTranshipmentJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTranshipmentJo.JoNo = db.Parameters.Item("p_JO_NO").value.ToString
                pTranshipmentJo.JoDate = db.Parameters.Item("p_JO_DATE").value.ToString
                If pTranshipmentJo.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTranshipmentJo
        End Function
        Public Shared Function UpdateTransaction(ByVal pTranshipmentJo As TranshipmentJo) As TranshipmentJo
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                For Each det As TranshipmentJo In pTranshipmentJo.ContTranshipmentlist
                    TranshipmentJo.UpdateTranshipment(det)
                    If det.Errormsg <> "" Then
                        Throw New Exception(det.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pTranshipmentJo.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pTranshipmentJo
        End Function
    End Class
End Namespace
