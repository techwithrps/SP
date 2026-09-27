Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MtyVhInJo
    ''' @author	: Amit K. Singh- 12/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MtyVhInJo 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngMtyVhInJoId As Long ' Define Private Variable MtyVhInJoId With DataType As Long 
        Private strMtyVhInJoNo As String ' Define Private Variable MtyVhInJoNo With DataType As String 
        Private strMtyVhInJoDate As String ' Define Private Variable MtyVhInJoDate With DataType As String 
        Private strMtyVhInJoValidity As String ' Define Private Variable MtyVhInJoValidity With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
        Private lngTransporterId As Long ' Define Private Variable TransporterId With DataType As Long 
        Private lngChaId As Long ' Define Private Variable ChaId With DataType As Long 
        Private lngNoOfVehicle As Long ' Define Private Variable NoOfVehicle With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strJoType As String
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
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
        ''' Get or Set the Value of MtyVhInJoId
        ''' </summary>
        ''' <value>lngMtyVhInJoId</value>
        ''' <returns> Return lngMtyVhInJoId</returns>
        ''' <remarks> Get or Set the Value of MtyVhInJoId  </remarks>
        '''
        Public Property MtyVhInJoId() as Long
            Get
                Return lngMtyVhInJoId
            End Get
            Set(ByVal value As Long)
                lngMtyVhInJoId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyVhInJoNo
        ''' </summary>
        ''' <value>strMtyVhInJoNo</value>
        ''' <returns> Return strMtyVhInJoNo</returns>
        ''' <remarks> Get or Set the Value of MtyVhInJoNo  </remarks>
        '''
        Public Property MtyVhInJoNo() as String
            Get
                Return strMtyVhInJoNo
            End Get
            Set(ByVal value As String)
                strMtyVhInJoNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyVhInJoDate
        ''' </summary>
        ''' <value>strMtyVhInJoDate</value>
        ''' <returns> Return strMtyVhInJoDate</returns>
        ''' <remarks> Get or Set the Value of MtyVhInJoDate  </remarks>
        '''
        Public Property MtyVhInJoDate() as String
            Get
                Return strMtyVhInJoDate
            End Get
            Set(ByVal value As String)
                strMtyVhInJoDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MtyVhInJoValidity
        ''' </summary>
        ''' <value>strMtyVhInJoValidity</value>
        ''' <returns> Return strMtyVhInJoValidity</returns>
        ''' <remarks> Get or Set the Value of MtyVhInJoValidity  </remarks>
        '''
        Public Property MtyVhInJoValidity() as String
            Get
                Return strMtyVhInJoValidity
            End Get
            Set(ByVal value As String)
                strMtyVhInJoValidity = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DocType
        ''' </summary>
        ''' <value>strDocType</value>
        ''' <returns> Return strDocType</returns>
        ''' <remarks> Get or Set the Value of DocType  </remarks>
        '''
        Public Property DocType() as String
            Get
                Return strDocType
            End Get
            Set(ByVal value As String)
                strDocType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TransporterId
        ''' </summary>
        ''' <value>lngTransporterId</value>
        ''' <returns> Return lngTransporterId</returns>
        ''' <remarks> Get or Set the Value of TransporterId  </remarks>
        '''
        Public Property TransporterId() as Long
            Get
                Return lngTransporterId
            End Get
            Set(ByVal value As Long)
                lngTransporterId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ChaId
        ''' </summary>
        ''' <value>lngChaId</value>
        ''' <returns> Return lngChaId</returns>
        ''' <remarks> Get or Set the Value of ChaId  </remarks>
        '''
        Public Property ChaId() as Long
            Get
                Return lngChaId
            End Get
            Set(ByVal value As Long)
                lngChaId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfVehicle
        ''' </summary>
        ''' <value>lngNoOfVehicle</value>
        ''' <returns> Return lngNoOfVehicle</returns>
        ''' <remarks> Get or Set the Value of NoOfVehicle  </remarks>
        '''
        Public Property NoOfVehicle() as Long
            Get
                Return lngNoOfVehicle
            End Get
            Set(ByVal value As Long)
                lngNoOfVehicle = value
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
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Property JoType() As String
            Get
                Return strJoType
            End Get
            Set(ByVal value As String)
                strJoType = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of LineItemId
        ''' </summary>
        ''' <value>lngLineItemId</value>
        ''' <returns> Return lngLineItemId</returns>
        ''' <remarks> Get or Set the Value of LineItemId  </remarks>
        '''
        Public Property LineItemId() As String
            Get
                Return lngLineItemId
            End Get
            Set(ByVal value As String)
                lngLineItemId = value
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
        

        
        Public Sub New()
            lngTerminalId = 0 
            lngMtyVhInJoId = 0 
            strMtyVhInJoNo = ""
            strMtyVhInJoDate = ""
            strMtyVhInJoValidity = ""
            strDocType = ""
            lngTransporterId = 0 
            lngChaId = 0 
            lngNoOfVehicle = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strJoType = ""
            lngLineItemId = 0
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMtyVhInJo"></param>
        ''' <returns>Return pMtyVhInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVhInJo.TerminalId)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVhInJo.MtyVhInJoId, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_NO", pMtyVhInJo.MtyVhInJoNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_DATE", pMtyVhInJo.MtyVhInJoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_VALIDITY", pMtyVhInJo.MtyVhInJoValidity)
                db.AddParameter("p_DOC_TYPE", pMtyVhInJo.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVhInJo.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVhInJo.ChaId)
                db.AddParameter("p_NO_OF_VEHICLE", pMtyVhInJo.NoOfVehicle)
                db.AddParameter("p_CREATED_BY", pMtyVhInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVhInJo.CreatedOn)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.JoType)
                db.AddParameter("p_LINE_ITEM_ID", pMtyVhInJo.LineItemId)
                db.AddParameter("p_ErrorMsg", pMtyVhInJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_VH_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVhInJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVhInJo.MtyVhInJoId = db.Parameters.Item("p_MTY_VH_IN_JO_ID").value
                pMtyVhInJo.MtyVhInJoNo = db.Parameters.Item("p_MTY_VH_IN_JO_NO").value
                pMtyVhInJo.MtyVhInJoDate = db.Parameters.Item("p_MTY_VH_IN_JO_DATE").value
                
                If pMtyVhInJo.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyVhInJo.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyVhInJo
        End Function



        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVhInJo"></param>
        ''' <returns>Return pMtyVhInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVhInJo.TerminalId)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVhInJo.MtyVhInJoId, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_NO", pMtyVhInJo.MtyVhInJoNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_DATE", pMtyVhInJo.MtyVhInJoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_VALIDITY", pMtyVhInJo.MtyVhInJoValidity)
                db.AddParameter("p_DOC_TYPE", pMtyVhInJo.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVhInJo.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVhInJo.ChaId)
                db.AddParameter("p_NO_OF_VEHICLE", pMtyVhInJo.NoOfVehicle)
                db.AddParameter("p_CREATED_BY", pMtyVhInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVhInJo.CreatedOn)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.JoType)
                db.AddParameter("p_LINE_ITEM_ID", pMtyVhInJo.LineItemId)
                db.AddParameter("p_ErrorMsg", pMtyVhInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_VH_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVhInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVhInJo.MtyVhInJoId = db.Parameters.Item("p_MTY_VH_IN_JO_ID").value
                pMtyVhInJo.MtyVhInJoNo = db.Parameters.Item("p_MTY_VH_IN_JO_NO").value
                pMtyVhInJo.MtyVhInJoDate = db.Parameters.Item("p_MTY_VH_IN_JO_DATE").value

                
            Catch ex As Exception
                pMtyVhInJo.ErrorMsg = ex.Message
            End Try
            Return pMtyVhInJo
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVhInJo"></param>
        ''' <returns>Return pMtyVhInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnOutJo(ByVal db As DBConnect, ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVhInJo.TerminalId)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVhInJo.MtyVhInJoId, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_NO", pMtyVhInJo.MtyVhInJoNo, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_DATE", pMtyVhInJo.MtyVhInJoDate, ParameterDirection.Output)
                db.AddParameter("p_MTY_VH_IN_JO_VALIDITY", pMtyVhInJo.MtyVhInJoValidity)
                db.AddParameter("p_DOC_TYPE", pMtyVhInJo.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVhInJo.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVhInJo.ChaId)
                db.AddParameter("p_NO_OF_VEHICLE", pMtyVhInJo.NoOfVehicle)
                db.AddParameter("p_CREATED_BY", pMtyVhInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVhInJo.CreatedOn)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.JoType)
                db.AddParameter("p_LINE_ITEM_ID", pMtyVhInJo.LineItemId)
                db.AddParameter("p_ErrorMsg", pMtyVhInJo.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MTY_VH_OUT_JO_IMP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVhInJo.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pMtyVhInJo.MtyVhInJoId = db.Parameters.Item("p_MTY_VH_IN_JO_ID").value
                pMtyVhInJo.MtyVhInJoNo = db.Parameters.Item("p_MTY_VH_IN_JO_NO").value
                pMtyVhInJo.MtyVhInJoDate = db.Parameters.Item("p_MTY_VH_IN_JO_DATE").value


            Catch ex As Exception
                pMtyVhInJo.Errormsg = ex.Message
            End Try
            Return pMtyVhInJo
        End Function


        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMtyVhInJo"></param>
        ''' <returns>Return pMtyVhInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVhInJo.TerminalId)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVhInJo.MtyVhInJoId)
                db.AddParameter("p_MTY_VH_IN_JO_NO", pMtyVhInJo.MtyVhInJoNo)
                db.AddParameter("p_MTY_VH_IN_JO_DATE", pMtyVhInJo.MtyVhInJoDate)
                db.AddParameter("p_MTY_VH_IN_JO_VALIDITY", pMtyVhInJo.MtyVhInJoValidity)
                db.AddParameter("p_DOC_TYPE", pMtyVhInJo.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVhInJo.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVhInJo.ChaId)
                db.AddParameter("p_NO_OF_VEHICLE", pMtyVhInJo.NoOfVehicle)
                db.AddParameter("p_CREATED_BY", pMtyVhInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVhInJo.CreatedOn)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.JoType)
                db.AddParameter("p_LINE_ITEM_ID", pMtyVhInJo.LineItemId)
                db.AddParameter("p_ErrorMsg", pMtyVhInJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VH_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVhInJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMtyVhInJo.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMtyVhInJo.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMtyVhInJo
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMtyVhInJo"></param>
        ''' <returns>Return pMtyVhInJo Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMtyVhInJo.TerminalId)
                db.AddParameter("p_MTY_VH_IN_JO_ID", pMtyVhInJo.MtyVhInJoId)
                db.AddParameter("p_MTY_VH_IN_JO_NO", pMtyVhInJo.MtyVhInJoNo)
                db.AddParameter("p_MTY_VH_IN_JO_DATE", pMtyVhInJo.MtyVhInJoDate)
                db.AddParameter("p_MTY_VH_IN_JO_VALIDITY", pMtyVhInJo.MtyVhInJoValidity)
                db.AddParameter("p_DOC_TYPE", pMtyVhInJo.DocType)
                db.AddParameter("p_TRANSPORTER_ID", pMtyVhInJo.TransporterId)
                db.AddParameter("p_CHA_ID", pMtyVhInJo.ChaId)
                db.AddParameter("p_NO_OF_VEHICLE", pMtyVhInJo.NoOfVehicle)
                db.AddParameter("p_CREATED_BY", pMtyVhInJo.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMtyVhInJo.CreatedOn)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.JoType)
                db.AddParameter("p_JO_TYPE", pMtyVhInJo.LineItemId)
                db.AddParameter("p_ErrorMsg", pMtyVhInJo.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MTY_VH_IN_JO", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMtyVhInJo.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMtyVhInJo.ErrorMsg = ex.Message
                End Try
            Return pMtyVhInJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMtyVhInJo.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_ID").ToString <> "" Then
                                PMtyVhInJo.MtyVhInJoId = dbr("MTY_VH_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_NO").ToString <> "" Then
                                PMtyVhInJo.MtyVhInJoNo = dbr("MTY_VH_IN_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_DATE").ToString <> "" Then
                                PMtyVhInJo.MtyVhInJoDate = dbr("MTY_VH_IN_JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_VALIDITY").ToString <> "" Then
                                PMtyVhInJo.MtyVhInJoValidity = dbr("MTY_VH_IN_JO_VALIDITY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PMtyVhInJo.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                PMtyVhInJo.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                PMtyVhInJo.ChaId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_VEHICLE").ToString <> "" Then
                                PMtyVhInJo.NoOfVehicle = dbr("NO_OF_VEHICLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PMtyVhInJo.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PMtyVhInJo.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("JO_TYPE").ToString <> "" Then
                                pMtyVhInJo.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                pMtyVhInJo.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMtyVhInJo.ErrorMsg = ex.Message
            End Try
            Return pMtyVhInJo
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMtyVhInJo As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MtyVhInJo
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_ID").ToString <> "" Then
                                temp.MtyVhInJoId = dbr("MTY_VH_IN_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_NO").ToString <> "" Then
                                temp.MtyVhInJoNo = dbr("MTY_VH_IN_JO_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_DATE").ToString <> "" Then
                                temp.MtyVhInJoDate = dbr("MTY_VH_IN_JO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_VH_IN_JO_VALIDITY").ToString <> "" Then
                                temp.MtyVhInJoValidity = dbr("MTY_VH_IN_JO_VALIDITY")
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
                            If dbr("TRANSPORTER_ID").ToString <> "" Then
                                temp.TransporterId = dbr("TRANSPORTER_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHA_ID").ToString <> "" Then
                                temp.ChaId = dbr("CHA_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_VEHICLE").ToString <> "" Then
                                temp.NoOfVehicle = dbr("NO_OF_VEHICLE")
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
                            If dbr("JO_TYPE").ToString <> "" Then
                                temp.JoType = dbr("JO_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                temp.LineItemId = dbr("LINE_ITEM_ID")
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
        ''' Preparing Return Object By TerminalId, MtyVhInJoNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyVhInJo(ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_IN_JO_BY_NO", pMtyVhInJo.TerminalId & ",'" & pMtyVhInJo.MtyVhInJoNo & "'")
                pMtyVhInJo = ReturnObjectValues(dbr, pMtyVhInJo)
                dbr.Close()
            Catch ex As Exception
                pMtyVhInJo.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyVhInJo
        End Function
        ''' <summary>
        ''' Preparing Return Object By TerminalId, MtyVhInJoNo
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMtyVhInJoById(ByVal pMtyVhInJo As MtyVhInJo) As MtyVhInJo
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_IN_JO_BY_ID", pMtyVhInJo.TerminalId & ",'" & pMtyVhInJo.MtyVhInJoId & "'")
                pMtyVhInJo = ReturnObjectValues(dbr, pMtyVhInJo)
                dbr.Close()
            Catch ex As Exception
                pMtyVhInJo.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMtyVhInJo
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMtyVhInJoList (ByVal pMtyVhInJo As MtyVhInJo) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMtyVhInJo As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MTY_VH_IN_JO", "' '")
                arrMtyVhInJo = ReturnObjectValuesList(dbr, arrMtyVhInJo)
                dbr.Close()
            Catch ex As Exception
                arrMtyVhInJo = Nothing
            End Try
            db.CloseDB()
            Return arrMtyVhInJo
        End Function
    End Class
End Namespace
