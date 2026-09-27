Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PortPendency
    ''' @author	: Santosh Singh- 15/11/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class PortPendency

        Dim arrPortDetailsList As New ArrayList

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngPendencyId As Long ' Define Private Variable PortId With DataType As Long 
        Private lngPortId As Long ' Define Private Variable PortId With DataType As Long 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngRailOperatorId As Long ' Define Private Variable RailOperatorId With DataType As Long 
        Private strPortCode As String ' Define Private Variable PortCode With DataType As String 
        Private strLineCode As String ' Define Private Variable LineCode With DataType As String 
        Private strRailOperator As String ' Define Private Variable RailOperator With DataType As String 
        Private strCont20 As String ' Define Private Variable Cont20 With DataType As String 
        Private strCont40 As String ' Define Private Variable Cont40 With DataType As String 
        Private strTotal As String ' Define Private Variable Total With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        Public Property PortDetailsList() As ArrayList
            Get
                Return arrPortDetailsList
            End Get
            Set(ByVal value As ArrayList)
                arrPortDetailsList = value
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
        ''' Get or Set the Value of PendencyId
        ''' </summary>
        ''' <value>lngPendencyId</value>
        ''' <returns> Return lngPendencyId</returns>
        ''' <remarks> Get or Set the Value of PendencyId  </remarks>
        '''
        Public Property PendencyId() As Long
            Get
                Return lngPendencyId
            End Get
            Set(ByVal value As Long)
                lngPendencyId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of PortId
        ''' </summary>
        ''' <value>lngPortId</value>
        ''' <returns> Return lngPortId</returns>
        ''' <remarks> Get or Set the Value of PortId  </remarks>
        '''
        Public Property PortId() As Long
            Get
                Return lngPortId
            End Get
            Set(ByVal value As Long)
                lngPortId = value
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
        ''' Get or Set the Value of RailOperatorId
        ''' </summary>
        ''' <value>lngRailOperatorId</value>
        ''' <returns> Return lngRailOperatorId</returns>
        ''' <remarks> Get or Set the Value of RailOperatorId  </remarks>
        '''
        Public Property RailOperatorId() As Long
            Get
                Return lngRailOperatorId
            End Get
            Set(ByVal value As Long)
                lngRailOperatorId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PortCode
        ''' </summary>
        ''' <value>strPortCode</value>
        ''' <returns> Return strPortCode</returns>
        ''' <remarks> Get or Set the Value of PortCode  </remarks>
        '''
        Public Property PortCode() As String
            Get
                Return strPortCode
            End Get
            Set(ByVal value As String)
                strPortCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineCode
        ''' </summary>
        ''' <value>strLineCode</value>
        ''' <returns> Return strLineCode</returns>
        ''' <remarks> Get or Set the Value of LineCode  </remarks>
        '''
        Public Property LineCode() As String
            Get
                Return strLineCode
            End Get
            Set(ByVal value As String)
                strLineCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RailOperator
        ''' </summary>
        ''' <value>strRailOperator</value>
        ''' <returns> Return strRailOperator</returns>
        ''' <remarks> Get or Set the Value of RailOperator  </remarks>
        '''
        Public Property RailOperator() As String
            Get
                Return strRailOperator
            End Get
            Set(ByVal value As String)
                strRailOperator = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cont20
        ''' </summary>
        ''' <value>strCont20</value>
        ''' <returns> Return strCont20</returns>
        ''' <remarks> Get or Set the Value of Cont20  </remarks>
        '''
        Public Property Cont20() As String
            Get
                Return strCont20
            End Get
            Set(ByVal value As String)
                strCont20 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Cont40
        ''' </summary>
        ''' <value>strCont40</value>
        ''' <returns> Return strCont40</returns>
        ''' <remarks> Get or Set the Value of Cont40  </remarks>
        '''
        Public Property Cont40() As String
            Get
                Return strCont40
            End Get
            Set(ByVal value As String)
                strCont40 = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Total
        ''' </summary>
        ''' <value>strTotal</value>
        ''' <returns> Return strTotal</returns>
        ''' <remarks> Get or Set the Value of Total  </remarks>
        '''
        Public Property Total() As String
            Get
                Return strTotal
            End Get
            Set(ByVal value As String)
                strTotal = value
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
            lngPendencyId = 0
            lngPortId = 0
            lngLineId = 0
            lngRailOperatorId = 0
            strPortCode = ""
            strLineCode = ""
            strRailOperator = ""
            strCont20 = ""
            strCont40 = ""
            strTotal = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pPortPendency"></param>
        ''' <returns>Return pPortPendency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pPortPendency As PortPendency) As PortPendency
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortPendency.TerminalId)
                db.AddParameter("p_PENDENCY_ID", pPortPendency.PendencyId, ParameterDirection.Output)
                db.AddParameter("p_PORT_ID", pPortPendency.PortId)
                db.AddParameter("p_LINE_ID", pPortPendency.LineId)
                db.AddParameter("p_RAIL_OPERATOR_ID", pPortPendency.RailOperatorId)
                db.AddParameter("p_PORT_CODE", pPortPendency.PortCode)
                db.AddParameter("p_LINE_CODE", pPortPendency.LineCode)
                db.AddParameter("p_RAIL_OPERATOR", pPortPendency.RailOperator)
                db.AddParameter("p_CONT_20", pPortPendency.Cont20)
                db.AddParameter("p_CONT_40", pPortPendency.Cont40)
                db.AddParameter("p_TOTAL", pPortPendency.Total)
                db.AddParameter("p_CREATED_BY", pPortPendency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortPendency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPortPendency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PORT_PENDENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortPendency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPortPendency.PendencyId = db.Parameters.Item("p_PENDENCY_ID").value
                If pPortPendency.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPortPendency"></param>
        ''' <returns>Return pPortPendency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pPortPendency As PortPendency) As PortPendency
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortPendency.TerminalId)
                db.AddParameter("p_PENDENCY_ID", pPortPendency.PendencyId, ParameterDirection.Output)
                db.AddParameter("p_PORT_ID", pPortPendency.PortId)
                db.AddParameter("p_LINE_ID", pPortPendency.LineId)
                db.AddParameter("p_RAIL_OPERATOR_ID", pPortPendency.RailOperatorId)
                db.AddParameter("p_PORT_CODE", pPortPendency.PortCode)
                db.AddParameter("p_LINE_CODE", pPortPendency.LineCode)
                db.AddParameter("p_RAIL_OPERATOR", pPortPendency.RailOperator)
                db.AddParameter("p_CONT_20", pPortPendency.Cont20)
                db.AddParameter("p_CONT_40", pPortPendency.Cont40)
                db.AddParameter("p_TOTAL", pPortPendency.Total)
                db.AddParameter("p_CREATED_BY", pPortPendency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortPendency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPortPendency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PORT_PENDENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortPendency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPortPendency.PendencyId = db.Parameters.Item("p_PENDENCY_ID").value
            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
            End Try
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pPortPendency"></param>
        ''' <returns>Return pPortPendency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pPortPendency As PortPendency) As PortPendency
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortPendency.TerminalId)
                db.AddParameter("p_PENDENCY_ID", pPortPendency.PendencyId)
                db.AddParameter("p_PORT_ID", pPortPendency.PortId)
                db.AddParameter("p_LINE_ID", pPortPendency.LineId)
                db.AddParameter("p_RAIL_OPERATOR_ID", pPortPendency.RailOperatorId)
                db.AddParameter("p_PORT_CODE", pPortPendency.PortCode)
                db.AddParameter("p_LINE_CODE", pPortPendency.LineCode)
                db.AddParameter("p_RAIL_OPERATOR", pPortPendency.RailOperator)
                db.AddParameter("p_CONT_20", pPortPendency.Cont20)
                db.AddParameter("p_CONT_40", pPortPendency.Cont40)
                db.AddParameter("p_TOTAL", pPortPendency.Total)
                db.AddParameter("p_CREATED_BY", pPortPendency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortPendency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPortPendency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PORT_PENDENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortPendency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pPortPendency.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPortPendency"></param>
        ''' <returns>Return pPortPendency Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pPortPendency As PortPendency) As PortPendency
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortPendency.TerminalId)
                db.AddParameter("p_PENDENCY_ID", pPortPendency.PendencyId)
                db.AddParameter("p_PORT_ID", pPortPendency.PortId)
                db.AddParameter("p_LINE_ID", pPortPendency.LineId)
                db.AddParameter("p_RAIL_OPERATOR_ID", pPortPendency.RailOperatorId)
                db.AddParameter("p_PORT_CODE", pPortPendency.PortCode)
                db.AddParameter("p_LINE_CODE", pPortPendency.LineCode)
                db.AddParameter("p_RAIL_OPERATOR", pPortPendency.RailOperator)
                db.AddParameter("p_CONT_20", pPortPendency.Cont20)
                db.AddParameter("p_CONT_40", pPortPendency.Cont40)
                db.AddParameter("p_TOTAL", pPortPendency.Total)
                db.AddParameter("p_CREATED_BY", pPortPendency.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortPendency.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPortPendency.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PORT_PENDENCY", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortPendency.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
            End Try
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pPortPendency As PortPendency) As PortPendency
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PPortPendency.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PENDENCY_ID").ToString <> "" Then
                                pPortPendency.PendencyId = dbr("PENDENCY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                PPortPendency.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PPortPendency.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RAIL_OPERATOR_ID").ToString <> "" Then
                                PPortPendency.RailOperatorId = dbr("RAIL_OPERATOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_CODE").ToString <> "" Then
                                PPortPendency.PortCode = dbr("PORT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CODE").ToString <> "" Then
                                PPortPendency.LineCode = dbr("LINE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RAIL_OPERATOR").ToString <> "" Then
                                PPortPendency.RailOperator = dbr("RAIL_OPERATOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_20").ToString <> "" Then
                                PPortPendency.Cont20 = dbr("CONT_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_40").ToString <> "" Then
                                PPortPendency.Cont40 = dbr("CONT_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                PPortPendency.Total = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PPortPendency.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PPortPendency.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
            End Try
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrPortPendency As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New PortPendency
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PENDENCY_ID").ToString <> "" Then
                                temp.PortId = dbr("PENDENCY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                temp.PortId = dbr("PORT_ID")
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
                            If dbr("RAIL_OPERATOR_ID").ToString <> "" Then
                                temp.RailOperatorId = dbr("RAIL_OPERATOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_CODE").ToString <> "" Then
                                temp.PortCode = dbr("PORT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_CODE").ToString <> "" Then
                                temp.LineCode = dbr("LINE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RAIL_OPERATOR").ToString <> "" Then
                                temp.RailOperator = dbr("RAIL_OPERATOR")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_20").ToString <> "" Then
                                temp.Cont20 = dbr("CONT_20")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_40").ToString <> "" Then
                                temp.Cont40 = dbr("CONT_40")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                temp.Total = dbr("TOTAL")
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
        Public Shared Function ReturnPortPendency(ByVal pPortPendency As PortPendency) As PortPendency
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_PENDENCY", "' '")
                pPortPendency = ReturnObjectValues(dbr, pPortPendency)
                dbr.Close()
            Catch ex As Exception
                pPortPendency.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pPortPendency
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortPendencyList(ByVal pPortPendency As PortPendency) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortPendency As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_PENDENCY", "' '")
                arrPortPendency = ReturnObjectValuesList(dbr, arrPortPendency)
                dbr.Close()
            Catch ex As Exception
                arrPortPendency = Nothing
            End Try
            db.CloseDB()
            Return arrPortPendency
        End Function
        Public Shared Function InsertUpdatePortPendency(ByVal pPortPendency As PortPendency) As PortPendency
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()


                For Each p As PortPendency In pPortPendency.PortDetailsList
                    If p.PortId > 0 Then
                        PortPendency.InsertTrn(db, p)
                    End If
                    If p.Errormsg <> "" Then
                        Throw New Exception(p.Errormsg)
                    End If
                Next

                db.CommitTransaction()
            Catch ex As Exception
                pPortPendency.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pPortPendency
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnPortPendencyListByOprterID(ByVal pPortPendency As PortPendency) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortPendecy As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_PENDENCY_BY_OPRATOR_ID", pPortPendency.RailOperatorId)
                arrPortPendecy = ReturnObjectValuesList(dbr, arrPortPendecy)
                dbr.Close()
            Catch ex As Exception
                arrPortPendecy = Nothing
            End Try
            db.CloseDB()
            Return arrPortPendecy
        End Function
    End Class
End Namespace
