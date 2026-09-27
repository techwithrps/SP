Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: HoldContainers
    ''' @author	: Santosh Singh- 7/7/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class HoldContainers 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngHoldId As Long ' Define Private Variable HoldId With DataType As Long 
        Private lngContId As Long ' Define Private Variable ContId With DataType As Long 
        Private strContNo As String ' Define Private Variable ContNo With DataType As String 
        Private strContSize As String ' Define Private Variable ContSize With DataType As String 
        Private strContType As String ' Define Private Variable ContType With DataType As String 
        Private lngContOwner As Long ' Define Private Variable ContOwner With DataType As Long 
        Private lngHoldAgency As Long ' Define Private Variable HoldAgency With DataType As Long 
        Private lngHoldReasonId As Long ' Define Private Variable HoldReasonId With DataType As Long 
        Private strHoldRemarks As String ' Define Private Variable HoldRemarks With DataType As String 
        Private strHoldDate As String ' Define Private Variable HoldDate With DataType As String 
        Private strHoldBy As String ' Define Private Variable HoldBy With DataType As String 
        Private strReleaseDate As String ' Define Private Variable ReleaseDate With DataType As String 
        Private strReleaseBy As String ' Define Private Variable ReleaseBy With DataType As String 
        Private strReleaseRemarks As String ' Define Private Variable ReleaseRemarks With DataType As String 
        Private strDocType As String ' Define Private Variable DocType With DataType As String 
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
        ''' Get or Set the Value of HoldId
        ''' </summary>
        ''' <value>lngHoldId</value>
        ''' <returns> Return lngHoldId</returns>
        ''' <remarks> Get or Set the Value of HoldId  </remarks>
        '''
        Public Property HoldId() as Long
            Get
                Return lngHoldId
            End Get
            Set(ByVal value As Long)
                lngHoldId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContId
        ''' </summary>
        ''' <value>lngContId</value>
        ''' <returns> Return lngContId</returns>
        ''' <remarks> Get or Set the Value of ContId  </remarks>
        '''
        Public Property ContId() as Long
            Get
                Return lngContId
            End Get
            Set(ByVal value As Long)
                lngContId = value
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
        ''' Get or Set the Value of ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks> Get or Set the Value of ContType  </remarks>
        '''
        Public Property ContType() as String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContOwner
        ''' </summary>
        ''' <value>lngContOwner</value>
        ''' <returns> Return lngContOwner</returns>
        ''' <remarks> Get or Set the Value of ContOwner  </remarks>
        '''
        Public Property ContOwner() as Long
            Get
                Return lngContOwner
            End Get
            Set(ByVal value As Long)
                lngContOwner = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldAgency
        ''' </summary>
        ''' <value>strHoldAgency</value>
        ''' <returns> Return lngHoldAgency</returns>
        ''' <remarks> Get or Set the Value of HoldAgency  </remarks>
        '''
        Public Property HoldAgency() As Long
            Get
                Return lngHoldAgency
            End Get
            Set(ByVal value As Long)
                lngHoldAgency = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldReasonId
        ''' </summary>
        ''' <value>lngHoldReasonId</value>
        ''' <returns> Return lngHoldReasonId</returns>
        ''' <remarks> Get or Set the Value of HoldReasonId  </remarks>
        '''
        Public Property HoldReasonId() as Long
            Get
                Return lngHoldReasonId
            End Get
            Set(ByVal value As Long)
                lngHoldReasonId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldRemarks
        ''' </summary>
        ''' <value>strHoldRemarks</value>
        ''' <returns> Return strHoldRemarks</returns>
        ''' <remarks> Get or Set the Value of HoldRemarks  </remarks>
        '''
        Public Property HoldRemarks() as String
            Get
                Return strHoldRemarks
            End Get
            Set(ByVal value As String)
                strHoldRemarks = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldDate
        ''' </summary>
        ''' <value>strHoldDate</value>
        ''' <returns> Return strHoldDate</returns>
        ''' <remarks> Get or Set the Value of HoldDate  </remarks>
        '''
        Public Property HoldDate() as String
            Get
                Return strHoldDate
            End Get
            Set(ByVal value As String)
                strHoldDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HoldBy
        ''' </summary>
        ''' <value>strHoldBy</value>
        ''' <returns> Return strHoldBy</returns>
        ''' <remarks> Get or Set the Value of HoldBy  </remarks>
        '''
        Public Property HoldBy() as String
            Get
                Return strHoldBy
            End Get
            Set(ByVal value As String)
                strHoldBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReleaseDate
        ''' </summary>
        ''' <value>strReleaseDate</value>
        ''' <returns> Return strReleaseDate</returns>
        ''' <remarks> Get or Set the Value of ReleaseDate  </remarks>
        '''
        Public Property ReleaseDate() as String
            Get
                Return strReleaseDate
            End Get
            Set(ByVal value As String)
                strReleaseDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReleaseBy
        ''' </summary>
        ''' <value>strReleaseBy</value>
        ''' <returns> Return strReleaseBy</returns>
        ''' <remarks> Get or Set the Value of ReleaseBy  </remarks>
        '''
        Public Property ReleaseBy() as String
            Get
                Return strReleaseBy
            End Get
            Set(ByVal value As String)
                strReleaseBy = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ReleaseRemarks
        ''' </summary>
        ''' <value>strReleaseRemarks</value>
        ''' <returns> Return strReleaseRemarks</returns>
        ''' <remarks> Get or Set the Value of ReleaseRemarks  </remarks>
        '''
        Public Property ReleaseRemarks() as String
            Get
                Return strReleaseRemarks
            End Get
            Set(ByVal value As String)
                strReleaseRemarks = value
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
            lngHoldId = 0 
            lngContId = 0 
            strContNo = ""
            strContSize = ""
            strContType = ""
            lngContOwner = 0 
            lngHoldAgency = 0
            lngHoldReasonId = 0 
            strHoldRemarks = ""
            strHoldDate = ""
            strHoldBy = ""
            strReleaseDate = ""
            strReleaseBy = ""
            strReleaseRemarks = ""
            strDocType = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pHoldContainers"></param>
        ''' <returns>Return pHoldContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pHoldContainers As HoldContainers) As HoldContainers
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldContainers.TerminalId)
                db.AddParameter("p_HOLD_ID", pHoldContainers.HoldId, ParameterDirection.Output)
                db.AddParameter("p_CONT_ID", pHoldContainers.ContId)
                db.AddParameter("p_CONT_NO", pHoldContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pHoldContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pHoldContainers.ContType)
                db.AddParameter("p_CONT_OWNER", pHoldContainers.ContOwner)
                db.AddParameter("p_HOLD_AGENCY", pHoldContainers.HoldAgency)
                db.AddParameter("p_HOLD_REASON_ID", pHoldContainers.HoldReasonId)
                db.AddParameter("p_HOLD_REMARKS", pHoldContainers.HoldRemarks)
                db.AddParameter("p_HOLD_DATE", pHoldContainers.HoldDate, ParameterDirection.Output)
                db.AddParameter("p_HOLD_BY", pHoldContainers.HoldBy)
                db.AddParameter("p_RELEASE_DATE", pHoldContainers.ReleaseDate)
                db.AddParameter("p_RELEASE_BY", pHoldContainers.ReleaseBy)
                db.AddParameter("p_RELEASE_REMARKS", pHoldContainers.ReleaseRemarks)
                db.AddParameter("p_DOC_TYPE", pHoldContainers.DocType)
                db.AddParameter("p_ErrorMsg", pHoldContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldContainers.HoldId  = db.Parameters.Item("p_HOLD_ID").value
                pHoldContainers.HoldDate = db.Parameters.Item("p_HOLD_DATE").value.ToString
                If pHoldContainers.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldContainers.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldContainers"></param>
        ''' <returns>Return pHoldContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pHoldContainers As HoldContainers) As HoldContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldContainers.TerminalId)
                db.AddParameter("p_HOLD_ID", pHoldContainers.HoldId, ParameterDirection.Output)
                db.AddParameter("p_CONT_ID", pHoldContainers.ContId)
                db.AddParameter("p_CONT_NO", pHoldContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pHoldContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pHoldContainers.ContType)
                db.AddParameter("p_CONT_OWNER", pHoldContainers.ContOwner)
                db.AddParameter("p_HOLD_AGENCY", pHoldContainers.HoldAgency)
                db.AddParameter("p_HOLD_REASON_ID", pHoldContainers.HoldReasonId)
                db.AddParameter("p_HOLD_REMARKS", pHoldContainers.HoldRemarks)
                db.AddParameter("p_HOLD_DATE", pHoldContainers.HoldDate, ParameterDirection.Output)
                db.AddParameter("p_HOLD_BY", pHoldContainers.HoldBy)
                db.AddParameter("p_RELEASE_DATE", pHoldContainers.ReleaseDate)
                db.AddParameter("p_RELEASE_BY", pHoldContainers.ReleaseBy)
                db.AddParameter("p_RELEASE_REMARKS", pHoldContainers.ReleaseRemarks)
                db.AddParameter("p_DOC_TYPE", pHoldContainers.DocType)
                db.AddParameter("p_ErrorMsg", pHoldContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_HOLD_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pHoldContainers.HoldId  = db.Parameters.Item("p_HOLD_ID").value
                pHoldContainers.HoldDate = db.Parameters.Item("p_HOLD_DATE").value.ToString
            Catch ex As Exception
                pHoldContainers.ErrorMsg = ex.Message
            End Try
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pHoldContainers"></param>
        ''' <returns>Return pHoldContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pHoldContainers As HoldContainers) As HoldContainers
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldContainers.TerminalId)
                db.AddParameter("p_HOLD_ID", pHoldContainers.HoldId)
                db.AddParameter("p_CONT_ID", pHoldContainers.ContId)
                db.AddParameter("p_CONT_NO", pHoldContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pHoldContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pHoldContainers.ContType)
                db.AddParameter("p_CONT_OWNER", pHoldContainers.ContOwner)
                db.AddParameter("p_HOLD_AGENCY", pHoldContainers.HoldAgency)
                db.AddParameter("p_HOLD_REASON_ID", pHoldContainers.HoldReasonId)
                db.AddParameter("p_HOLD_REMARKS", pHoldContainers.HoldRemarks)
                db.AddParameter("p_HOLD_DATE", pHoldContainers.HoldDate)
                db.AddParameter("p_HOLD_BY", pHoldContainers.HoldBy)
                db.AddParameter("p_RELEASE_DATE", pHoldContainers.ReleaseDate)
                db.AddParameter("p_RELEASE_BY", pHoldContainers.ReleaseBy)
                db.AddParameter("p_RELEASE_REMARKS", pHoldContainers.ReleaseRemarks)
                db.AddParameter("p_DOC_TYPE", pHoldContainers.DocType)
                db.AddParameter("p_ErrorMsg", pHoldContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pHoldContainers.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pHoldContainers.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pHoldContainers"></param>
        ''' <returns>Return pHoldContainers Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pHoldContainers As HoldContainers) As HoldContainers
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pHoldContainers.TerminalId)
                db.AddParameter("p_HOLD_ID", pHoldContainers.HoldId)
                db.AddParameter("p_CONT_ID", pHoldContainers.ContId)
                db.AddParameter("p_CONT_NO", pHoldContainers.ContNo)
                db.AddParameter("p_CONT_SIZE", pHoldContainers.ContSize)
                db.AddParameter("p_CONT_TYPE", pHoldContainers.ContType)
                db.AddParameter("p_CONT_OWNER", pHoldContainers.ContOwner)
                db.AddParameter("p_HOLD_AGENCY", pHoldContainers.HoldAgency)
                db.AddParameter("p_HOLD_REASON_ID", pHoldContainers.HoldReasonId)
                db.AddParameter("p_HOLD_REMARKS", pHoldContainers.HoldRemarks)
                db.AddParameter("p_HOLD_DATE", pHoldContainers.HoldDate)
                db.AddParameter("p_HOLD_BY", pHoldContainers.HoldBy)
                db.AddParameter("p_RELEASE_DATE", pHoldContainers.ReleaseDate)
                db.AddParameter("p_RELEASE_BY", pHoldContainers.ReleaseBy)
                db.AddParameter("p_RELEASE_REMARKS", pHoldContainers.ReleaseRemarks)
                db.AddParameter("p_DOC_TYPE", pHoldContainers.DocType)
                db.AddParameter("p_ErrorMsg", pHoldContainers.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_HOLD_CONTAINERS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pHoldContainers.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pHoldContainers.ErrorMsg = ex.Message
                End Try
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pHoldContainers As HoldContainers) As HoldContainers
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PHoldContainers.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                PHoldContainers.HoldId = dbr("HOLD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                PHoldContainers.ContId = dbr("CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                PHoldContainers.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_SIZE").ToString <> "" Then
                                PHoldContainers.ContSize = dbr("CONT_SIZE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_TYPE").ToString <> "" Then
                                PHoldContainers.ContType = dbr("CONT_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_OWNER").ToString <> "" Then
                                PHoldContainers.ContOwner = dbr("CONT_OWNER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY").ToString <> "" Then
                                PHoldContainers.HoldAgency = dbr("HOLD_AGENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REASON_ID").ToString <> "" Then
                                PHoldContainers.HoldReasonId = dbr("HOLD_REASON_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REMARKS").ToString <> "" Then
                                PHoldContainers.HoldRemarks = dbr("HOLD_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_DATE").ToString <> "" Then
                                PHoldContainers.HoldDate = dbr("HOLD_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_BY").ToString <> "" Then
                                PHoldContainers.HoldBy = dbr("HOLD_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_DATE").ToString <> "" Then
                                PHoldContainers.ReleaseDate = dbr("RELEASE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_BY").ToString <> "" Then
                                PHoldContainers.ReleaseBy = dbr("RELEASE_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_REMARKS").ToString <> "" Then
                                PHoldContainers.ReleaseRemarks = dbr("RELEASE_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                PHoldContainers.DocType = dbr("DOC_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pHoldContainers.ErrorMsg = ex.Message
            End Try
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrHoldContainers As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New HoldContainers
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_ID").ToString <> "" Then
                                temp.HoldId = dbr("HOLD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_ID").ToString <> "" Then
                                temp.ContId = dbr("CONT_ID")
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
                            If dbr("CONT_OWNER").ToString <> "" Then
                                temp.ContOwner = dbr("CONT_OWNER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_AGENCY").ToString <> "" Then
                                temp.HoldAgency = dbr("HOLD_AGENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REASON_ID").ToString <> "" Then
                                temp.HoldReasonId = dbr("HOLD_REASON_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_REMARKS").ToString <> "" Then
                                temp.HoldRemarks = dbr("HOLD_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_DATE").ToString <> "" Then
                                temp.HoldDate = dbr("HOLD_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLD_BY").ToString <> "" Then
                                temp.HoldBy = dbr("HOLD_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_DATE").ToString <> "" Then
                                temp.ReleaseDate = dbr("RELEASE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_BY").ToString <> "" Then
                                temp.ReleaseBy = dbr("RELEASE_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RELEASE_REMARKS").ToString <> "" Then
                                temp.ReleaseRemarks = dbr("RELEASE_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DOC_TYPE").ToString <> "" Then
                                temp.DocType = dbr("DOC_TYPE")
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
        Public Shared Function ReturnHoldContainers(ByVal pHoldContainers As HoldContainers) As HoldContainers
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_CONTAINERS_BY_CONT_NO", pHoldContainers.TerminalId & ",'" & pHoldContainers.ContNo & "'")
                pHoldContainers = ReturnObjectValues(dbr, pHoldContainers)
                dbr.Close()
            Catch ex As Exception
                pHoldContainers.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pHoldContainers
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnHoldContainersList (ByVal pHoldContainers As HoldContainers) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrHoldContainers As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_HOLD_CONTAINERS", "' '")
                arrHoldContainers = ReturnObjectValuesList(dbr, arrHoldContainers)
                dbr.Close()
            Catch ex As Exception
                arrHoldContainers = Nothing
            End Try
            db.CloseDB()
            Return arrHoldContainers
        End Function
    End Class
End Namespace
