Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyContInJoDetail
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MtyContInJoDetail 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMtyContGateInId As Long ' Define Private Variable MtyContGateInId With DataType As Long 
        Private strMtyContInPassNo As String ' Define Private Variable MtyContInPassNo With DataType As String 
        Private strMtyContInPassDate As String ' Define Private Variable MtyContInPassDate With DataType As String 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private strMtyContGateInDate As String ' Define Private Variable MtyContGateInDate With DataType As String 
        Private lngMtyContInJoId As Long ' Define Private Variable MtyContInJoId With DataType As Long 
        Private lngFromLocation As Long ' Define Private Variable FromLocation With DataType As Long 
        Private strDoNo As String ' Define Private Variable DoNo With DataType As String 
        Private strDoDate As String ' Define Private Variable DoDate With DataType As String 
        Private strDoValidDate As String ' Define Private Variable DoValidDate With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private lngDestuffImpContId As Long ' Define Private Variable DestuffImpId With DataType As Long
        Private lngLineId As Long ' Define Private Variable DestuffImpId With DataType As Long
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
        ''' Get or Set the Value of MtyContGateInId
        ''' </summary>
        ''' <value>lngMtyContGateInId</value>
        ''' <returns> Return lngMtyContGateInId</returns>
        ''' <remarks> Get or Set the Value of MtyContGateInId  </remarks>
        '''
        Public Property MtyContGateInId() as Long
            Get
                Return lngMtyContGateInId
            End Get
            Set(ByVal value As Long)
                lngMtyContGateInId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyContInPassNo
        ''' </summary>
        ''' <value>strMtyContInPassNo</value>
        ''' <returns> Return strMtyContInPassNo</returns>
        ''' <remarks> Get or Set the Value of MtyContInPassNo  </remarks>
        '''
        Public Property MtyContInPassNo() as String
            Get
                Return strMtyContInPassNo
            End Get
            Set(ByVal value As String)
                strMtyContInPassNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyContInPassDate
        ''' </summary>
        ''' <value>strMtyContInPassDate</value>
        ''' <returns> Return strMtyContInPassDate</returns>
        ''' <remarks> Get or Set the Value of MtyContInPassDate  </remarks>
        '''
        Public Property MtyContInPassDate() as String
            Get
                Return strMtyContInPassDate
            End Get
            Set(ByVal value As String)
                strMtyContInPassDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContNo
        ''' </summary>
        ''' <value>strContNo</value>
        ''' <returns> Return strContNo</returns>
        ''' <remarks> Get or Set the Value of ContNo  </remarks>
        '''
        Public Property ContNo() as String
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
        Public Property ContSize() as String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property
        

                    
        ''' <summary>
        ''' Get or Set the Value of MtyContGateInDate
        ''' </summary>
        ''' <value>strMtyContGateInDate</value>
        ''' <returns> Return strMtyContGateInDate</returns>
        ''' <remarks> Get or Set the Value of MtyContGateInDate  </remarks>
        '''
        Public Property MtyContGateInDate() as String
            Get
                Return strMtyContGateInDate
            End Get
            Set(ByVal value As String)
                strMtyContGateInDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyContInJoId
        ''' </summary>
        ''' <value>lngMtyContInJoId</value>
        ''' <returns> Return lngMtyContInJoId</returns>
        ''' <remarks> Get or Set the Value of MtyContInJoId  </remarks>
        '''
        Public Property MtyContInJoId() as Long
            Get
                Return lngMtyContInJoId
            End Get
            Set(ByVal value As Long)
                lngMtyContInJoId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of FromLocation
        ''' </summary>
        ''' <value>lngFromLocation</value>
        ''' <returns> Return lngFromLocation</returns>
        ''' <remarks> Get or Set the Value of FromLocation  </remarks>
        '''
        Public Property FromLocation() As Long
            Get
                Return lngFromLocation
            End Get
            Set(ByVal value As Long)
                lngFromLocation = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DoNo
        ''' </summary>
        ''' <value>strDoNo</value>
        ''' <returns> Return strDoNo</returns>
        ''' <remarks> Get or Set the Value of DoNo  </remarks>
        '''
        Public Property DoNo() as String
            Get
                Return strDoNo
            End Get
            Set(ByVal value As String)
                strDoNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DoDate
        ''' </summary>
        ''' <value>strDoDate</value>
        ''' <returns> Return strDoDate</returns>
        ''' <remarks> Get or Set the Value of DoDate  </remarks>
        '''
        Public Property DoDate() as String
            Get
                Return strDoDate
            End Get
            Set(ByVal value As String)
                strDoDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DoValidDate
        ''' </summary>
        ''' <value>strDoValidDate</value>
        ''' <returns> Return strDoValidDate</returns>
        ''' <remarks> Get or Set the Value of DoValidDate  </remarks>
        '''
        Public Property DoValidDate() as String
            Get
                Return strDoValidDate
            End Get
            Set(ByVal value As String)
                strDoValidDate = value
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
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType </remarks>
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
        ''' Get or Set the Value of DestuffImpContId
        ''' </summary>
        ''' <value>lngDestuffImpContId</value>
        ''' <returns> Return lngDestuffImpContId</returns>
        ''' <remarks> Get or Set the Value of DestuffImpContId </remarks>
        '''
        Public Property DestuffImpContId() As Long
            Get
                Return lngDestuffImpContId
            End Get
            Set(ByVal value As Long)
                lngDestuffImpContId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId </remarks>
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
            lngMtyContGateInId = 0 
            strMtyContInPassNo = ""
            strMtyContInPassDate = ""
            strContNo = ""
            strContSize = ""
            strContType = ""
            strMtyContGateInDate = ""
            lngMtyContInJoId = 0 
            lngFromLocation = 0
            strDoNo = ""
            strDoDate = ""
            strDoValidDate = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngDestuffImpContId = 0
            lngLineId = 0
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMtyContInJoDetail"></param>
        ''' <returns>Return pMtyContInJoDetail Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJoDetail.TerminalId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContInJoDetail.MtyContGateInId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_PASS_NO", pMtyContInJoDetail.MtyContInPassNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_PASS_DATE", pMtyContInJoDetail.MtyContInPassDate, ParameterDirection.Output)
                db.AddParameter("p_CONT_NO", pMtyContInJoDetail.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContInJoDetail.ContSize)
                db.AddParameter("p_MTY_CONT_GATE_IN_DATE", pMtyContInJoDetail.MtyContGateInDate)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJoDetail.MtyContInJoId)
                db.AddParameter("p_FROM_LOCATION", pMtyContInJoDetail.FromLocation)
                db.AddParameter("p_DO_NO", pMtyContInJoDetail.DoNo)
                db.AddParameter("p_DO_DATE", pMtyContInJoDetail.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyContInJoDetail.DoValidDate)
                db.AddParameter("p_CREATED_BY", pMtyContInJoDetail.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJoDetail.CreatedOn)
                db.AddParameter("p_CONT_TYPE", pMtyContInJoDetail.ContType)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContInJoDetail.DestuffImpContId)
                db.AddParameter("p_LINE_ID", pMtyContInJoDetail.LineId)
                db.AddParameter("p_ErrorMsg", pMtyContInJoDetail.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONT_IN_JO_DETAIL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJoDetail.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContInJoDetail.MtyContGateInId = db.Parameters.Item("p_MTY_CONT_GATE_IN_ID").value.ToString
                pMtyContInJoDetail.MtyContInPassNo = db.Parameters.Item("p_MTY_CONT_IN_PASS_NO").value.ToString
                pMtyContInJoDetail.MtyContGateInDate = db.Parameters.Item("p_MTY_CONT_IN_PASS_DATE").value.ToString
                
                If pMtyContInJoDetail.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContInJoDetail.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContInJoDetail"></param>
        ''' <returns>Return pMtyContInJoDetail Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJoDetail.TerminalId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContInJoDetail.MtyContGateInId, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_PASS_NO", pMtyContInJoDetail.MtyContInPassNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_CONT_IN_PASS_DATE", pMtyContInJoDetail.MtyContInPassDate, ParameterDirection.Output)
                db.AddParameter("p_CONT_NO", pMtyContInJoDetail.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContInJoDetail.ContSize)
                db.AddParameter("p_MTY_CONT_GATE_IN_DATE", pMtyContInJoDetail.MtyContGateInDate)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJoDetail.MtyContInJoId)
                db.AddParameter("p_FROM_LOCATION", pMtyContInJoDetail.FromLocation)
                db.AddParameter("p_DO_NO", pMtyContInJoDetail.DoNo)
                db.AddParameter("p_DO_DATE", pMtyContInJoDetail.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyContInJoDetail.DoValidDate)
                db.AddParameter("p_CREATED_BY", pMtyContInJoDetail.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJoDetail.CreatedOn)
                db.AddParameter("p_CONT_TYPE", pMtyContInJoDetail.ContType)
                db.AddParameter("p_DESTUFF_IMP_CONT_ID", pMtyContInJoDetail.DestuffImpContId)
                db.AddParameter("p_LINE_ID", pMtyContInJoDetail.LineId)
                db.AddParameter("p_ErrorMsg", pMtyContInJoDetail.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_CONT_IN_JO_DETAIL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJoDetail.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyContInJoDetail.MtyContGateInId = db.Parameters.Item("p_MTY_CONT_GATE_IN_ID").value.ToString
                pMtyContInJoDetail.MtyContInPassNo = db.Parameters.Item("p_MTY_CONT_IN_PASS_NO").value.ToString
                pMtyContInJoDetail.MtyContGateInDate = db.Parameters.Item("p_MTY_CONT_IN_PASS_DATE").value.ToString
                
            Catch ex As Exception
                pMtyContInJoDetail.ErrorMsg = ex.Message
            End Try
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMtyContInJoDetail"></param>
        ''' <returns>Return pMtyContInJoDetail Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJoDetail.TerminalId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContInJoDetail.MtyContGateInId)
                db.AddParameter("p_MTY_CONT_IN_PASS_NO", pMtyContInJoDetail.MtyContInPassNo)
                db.AddParameter("p_MTY_CONT_IN_PASS_DATE", pMtyContInJoDetail.MtyContInPassDate)
                db.AddParameter("p_CONT_NO", pMtyContInJoDetail.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContInJoDetail.ContSize)
                db.AddParameter("p_MTY_CONT_GATE_IN_DATE", pMtyContInJoDetail.MtyContGateInDate)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJoDetail.MtyContInJoId)
                db.AddParameter("p_FROM_LOCATION", pMtyContInJoDetail.FromLocation)
                db.AddParameter("p_DO_NO", pMtyContInJoDetail.DoNo)
                db.AddParameter("p_DO_DATE", pMtyContInJoDetail.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyContInJoDetail.DoValidDate)
                db.AddParameter("p_CREATED_BY", pMtyContInJoDetail.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJoDetail.CreatedOn)
                db.AddParameter("p_CONT_TYPE", pMtyContInJoDetail.ContType)
                db.AddParameter("p_ErrorMsg", pMtyContInJoDetail.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONT_IN_JO_DETAIL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJoDetail.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyContInJoDetail.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyContInJoDetail.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyContInJoDetail"></param>
        ''' <returns>Return pMtyContInJoDetail Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyContInJoDetail.TerminalId)
                db.AddParameter("p_MTY_CONT_GATE_IN_ID", pMtyContInJoDetail.MtyContGateInId)
                db.AddParameter("p_MTY_CONT_IN_PASS_NO", pMtyContInJoDetail.MtyContInPassNo)
                db.AddParameter("p_MTY_CONT_IN_PASS_DATE", pMtyContInJoDetail.MtyContInPassDate)
                db.AddParameter("p_CONT_NO", pMtyContInJoDetail.ContNo)
                db.AddParameter("p_CONT_SIZE", pMtyContInJoDetail.ContSize)
                db.AddParameter("p_MTY_CONT_GATE_IN_DATE", pMtyContInJoDetail.MtyContGateInDate)
                db.AddParameter("p_MTY_CONT_IN_JO_ID", pMtyContInJoDetail.MtyContInJoId)
                db.AddParameter("p_FROM_LOCATION", pMtyContInJoDetail.FromLocation)
                db.AddParameter("p_DO_NO", pMtyContInJoDetail.DoNo)
                db.AddParameter("p_DO_DATE", pMtyContInJoDetail.DoDate)
                db.AddParameter("p_DO_VALID_DATE", pMtyContInJoDetail.DoValidDate)
                db.AddParameter("p_CREATED_BY", pMtyContInJoDetail.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyContInJoDetail.CreatedOn)
                db.AddParameter("p_CONT_TYPE", pMtyContInJoDetail.ContType)
                db.AddParameter("p_ErrorMsg", pMtyContInJoDetail.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_CONT_IN_JO_DETAIL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyContInJoDetail.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMtyContInJoDetail.ErrorMsg = ex.Message
                End Try
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMtyContInJoDetail.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_GATE_IN_ID").ToString <> "" Then
                                PMtyContInJoDetail.MtyContGateInId = dbr("MTY_CONT_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_PASS_NO").ToString <> "" Then
                                PMtyContInJoDetail.MtyContInPassNo = dbr("MTY_CONT_IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_PASS_DATE").ToString <> "" Then
                                PMtyContInJoDetail.MtyContInPassDate = dbr("MTY_CONT_IN_PASS_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PMtyContInJoDetail.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PMtyContInJoDetail.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_GATE_IN_DATE").ToString <> "" Then
                                PMtyContInJoDetail.MtyContGateInDate = dbr("MTY_CONT_GATE_IN_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_JO_ID").ToString <> "" Then
                                PMtyContInJoDetail.MtyContInJoId = dbr("MTY_CONT_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                PMtyContInJoDetail.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_NO").ToString <> "" Then
                                PMtyContInJoDetail.DoNo = dbr("DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_DATE").ToString <> "" Then
                                PMtyContInJoDetail.DoDate = dbr("DO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALID_DATE").ToString <> "" Then
                                PMtyContInJoDetail.DoValidDate = dbr("DO_VALID_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PMtyContInJoDetail.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PMtyContInJoDetail.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                pMtyContInJoDetail.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMtyContInJoDetail.ErrorMsg = ex.Message
            End Try
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyContInJoDetail As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MtyContInJoDetail
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_GATE_IN_ID").ToString <> "" Then
                                temp.MtyContGateInId = dbr("MTY_CONT_GATE_IN_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_PASS_NO").ToString <> "" Then
                                temp.MtyContInPassNo = dbr("MTY_CONT_IN_PASS_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_IN_PASS_DATE").ToString <> "" Then
                                temp.MtyContInPassDate = dbr("MTY_CONT_IN_PASS_DATE")
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
                            If dbr("MTY_CONT_GATE_IN_DATE").ToString <> "" Then
                                temp.MtyContGateInDate = dbr("MTY_CONT_GATE_IN_DATE")
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
                            If dbr("FROM_LOCATION").ToString <> "" Then
                                temp.FromLocation = dbr("FROM_LOCATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_NO").ToString <> "" Then
                                temp.DoNo = dbr("DO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_DATE").ToString <> "" Then
                                temp.DoDate = dbr("DO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DO_VALID_DATE").ToString <> "" Then
                                temp.DoValidDate = dbr("DO_VALID_DATE")
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
                            If dbr("CONT_TYPE").ToString <> "" Then
                                temp.ContType = dbr("CONT_TYPE")
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
        Public Shared Function ReturnMtyContInJoDetail(ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_DETAIL_BY_ID", pMtyContInJoDetail.TerminalId & "," & pMtyContInJoDetail.MtyContGateInId)
                pMtyContInJoDetail = ReturnObjectValues(dbr, pMtyContInJoDetail)
                dbr.Close()
            Catch ex As Exception
                pMtyContInJoDetail.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContInJoDetailList (ByVal pMtyContInJoDetail As MtyContInJoDetail) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContInJoDetail As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_DETAIL_ALL", pMtyContInJoDetail.TerminalId)
                arrMtyContInJoDetail = ReturnObjectValuesList(dbr, arrMtyContInJoDetail)
                dbr.Close()
            Catch ex As Exception
                arrMtyContInJoDetail = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContInJoDetail
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyContInJoDetailListByContJoId(ByVal pMtyContInJoDetail As MtyContInJoDetail) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyContInJoDetail As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_DETAIL_BY_ID", pMtyContInJoDetail.TerminalId & "," & pMtyContInJoDetail.MtyContInJoId)
                arrMtyContInJoDetail = ReturnObjectValuesList(dbr, arrMtyContInJoDetail)
                dbr.Close()
            Catch ex As Exception
                arrMtyContInJoDetail = Nothing
            End Try
            db.CloseDB()
            Return arrMtyContInJoDetail
        End Function
        ''' <summary>
        ''' Preparing Return Object By TerminalId,MtyContGateInId or ContNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyContInJoDetailByMtyContGateInId_ContNo(ByVal pMtyContInJoDetail As MtyContInJoDetail) As MtyContInJoDetail
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_CONT_IN_JO_DET_ID_CONT", pMtyContInJoDetail.TerminalId & "," & pMtyContInJoDetail.MtyContGateInId & "," & pMtyContInJoDetail.MtyContInJoId & ",'" & pMtyContInJoDetail.ContNo & "'")
                pMtyContInJoDetail = ReturnObjectValues(dbr, pMtyContInJoDetail)
                dbr.Close()
            Catch ex As Exception
                pMtyContInJoDetail.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyContInJoDetail
        End Function

    End Class
End Namespace
