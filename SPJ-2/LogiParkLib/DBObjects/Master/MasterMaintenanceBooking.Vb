Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MasterMaintenanceBooking
    ''' @author	: Amit K. Singh- 13/11/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MasterMaintenanceBooking 
    
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngRefId As Long ' Define Private Variable RefId With DataType As Long 
        Private lngBookingId As Long ' Define Private Variable BookingId With DataType As Long 
        Private strBookingNo As String ' Define Private Variable BookingNo With DataType As String 
        Private lngLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngPol As Long ' Define Private Variable Pol With DataType As Long 
        Private strTptMode As String ' Define Private Variable TptMode With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngNLineId As Long ' Define Private Variable LineId With DataType As Long 
        Private lngNPol As Long ' Define Private Variable Pol With DataType As Long 
        Private strNTptMode As String ' Define Private Variable TptMode With DataType As String
        Private strRemarks As String ' Define Private Variable Remarks With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
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
        ''' Get or Set the Value of RefId
        ''' </summary>
        ''' <value>lngRefId</value>
        ''' <returns> Return lngRefId</returns>
        ''' <remarks> Get or Set the Value of RefId  </remarks>
        '''
        Public Property RefId() as Long
            Get
                Return lngRefId
            End Get
            Set(ByVal value As Long)
                lngRefId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BookingId
        ''' </summary>
        ''' <value>lngBookingId</value>
        ''' <returns> Return lngBookingId</returns>
        ''' <remarks> Get or Set the Value of BookingId  </remarks>
        '''
        Public Property BookingId() as Long
            Get
                Return lngBookingId
            End Get
            Set(ByVal value As Long)
                lngBookingId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BookingNo
        ''' </summary>
        ''' <value>strBookingNo</value>
        ''' <returns> Return strBookingNo</returns>
        ''' <remarks> Get or Set the Value of BookingNo  </remarks>
        '''
        Public Property BookingNo() as String
            Get
                Return strBookingNo
            End Get
            Set(ByVal value As String)
                strBookingNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property LineId() as Long
            Get
                Return lngLineId
            End Get
            Set(ByVal value As Long)
                lngLineId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property NLineId() As Long
            Get
                Return lngNLineId
            End Get
            Set(ByVal value As Long)
                lngNLineId = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of Pol
        ''' </summary>
        ''' <value>lngPol</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property Pol() as Long
            Get
                Return lngPol
            End Get
            Set(ByVal value As Long)
                lngPol = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Pol
        ''' </summary>
        ''' <value>lngPol</value>
        ''' <returns> Return lngPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property NPol() As Long
            Get
                Return lngNPol
            End Get
            Set(ByVal value As Long)
                lngNPol = value
            End Set
        End Property
                    
        ''' <summary>
        ''' Get or Set the Value of TptMode
        ''' </summary>
        ''' <value>strTptMode</value>
        ''' <returns> Return strTptMode</returns>
        ''' <remarks> Get or Set the Value of TptMode  </remarks>
        '''
        Public Property TptMode() as String
            Get
                Return strTptMode
            End Get
            Set(ByVal value As String)
                strTptMode = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TptMode
        ''' </summary>
        ''' <value>strTptMode</value>
        ''' <returns> Return strTptMode</returns>
        ''' <remarks> Get or Set the Value of TptMode  </remarks>
        '''
        Public Property NTptMode() As String
            Get
                Return strNTptMode
            End Get
            Set(ByVal value As String)
                strNTptMode = value
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
        ''' Get or Set the Value of Remarks
        ''' </summary>
        ''' <value>strRemarks</value>
        ''' <returns> Return strRemarks</returns>
        ''' <remarks> Get or Set the Value of Remarks  </remarks>
        '''
        Public Property Remarks() as String
            Get
                Return strRemarks
            End Get
            Set(ByVal value As String)
                strRemarks = value
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
            strCreatedBy = ""
            lngTerminalId = 0 
            lngRefId = 0 
            lngBookingId = 0 
            strBookingNo = ""
            lngLineId = 0 
            lngPol = 0 
            strTptMode = ""
            strCreatedOn = ""
            strRemarks = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMasterMaintenanceBooking"></param>
        ''' <returns>Return pMasterMaintenanceBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenanceBooking.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenanceBooking.RefId)
                db.AddParameter("p_BOOKING_ID", pMasterMaintenanceBooking.BookingId)
                db.AddParameter("p_BOOKING_NO", pMasterMaintenanceBooking.BookingNo)
                db.AddParameter("p_LINE_ID", pMasterMaintenanceBooking.LineId)
                db.AddParameter("p_POL", pMasterMaintenanceBooking.Pol)
                db.AddParameter("p_TPT_MODE", pMasterMaintenanceBooking.TptMode)
                db.AddParameter("p_NLINE_ID", pMasterMaintenanceBooking.NLineId)
                db.AddParameter("p_NPOL", pMasterMaintenanceBooking.NPol)
                db.AddParameter("p_NTPT_MODE", pMasterMaintenanceBooking.NTptMode)
                db.AddParameter("p_CREATED_BY", pMasterMaintenanceBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pMasterMaintenanceBooking.CreatedOn)
                db.AddParameter("p_REMARKS", pMasterMaintenanceBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pMasterMaintenanceBooking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MASTER_MAINTENANCE_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenanceBooking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pMasterMaintenanceBooking.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMasterMaintenanceBooking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMasterMaintenanceBooking"></param>
        ''' <returns>Return pMasterMaintenanceBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_CREATED_BY", pMasterMaintenanceBooking.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenanceBooking.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenanceBooking.RefId)
                db.AddParameter("p_BOOKING_ID", pMasterMaintenanceBooking.BookingId)
                db.AddParameter("p_BOOKING_NO", pMasterMaintenanceBooking.BookingNo)
                db.AddParameter("p_LINE_ID", pMasterMaintenanceBooking.LineId)
                db.AddParameter("p_POL", pMasterMaintenanceBooking.Pol)
                db.AddParameter("p_TPT_MODE", pMasterMaintenanceBooking.TptMode)
                db.AddParameter("p_CREATED_ON", pMasterMaintenanceBooking.CreatedOn)
                db.AddParameter("p_REMARKS", pMasterMaintenanceBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pMasterMaintenanceBooking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MASTER_MAINTENANCE_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenanceBooking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pMasterMaintenanceBooking.ErrorMsg = ex.Message
            End Try
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMasterMaintenanceBooking"></param>
        ''' <returns>Return pMasterMaintenanceBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_CREATED_BY", pMasterMaintenanceBooking.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenanceBooking.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenanceBooking.RefId)
                db.AddParameter("p_BOOKING_ID", pMasterMaintenanceBooking.BookingId)
                db.AddParameter("p_BOOKING_NO", pMasterMaintenanceBooking.BookingNo)
                db.AddParameter("p_LINE_ID", pMasterMaintenanceBooking.LineId)
                db.AddParameter("p_POL", pMasterMaintenanceBooking.Pol)
                db.AddParameter("p_TPT_MODE", pMasterMaintenanceBooking.TptMode)
                db.AddParameter("p_CREATED_ON", pMasterMaintenanceBooking.CreatedOn)
                db.AddParameter("p_REMARKS", pMasterMaintenanceBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pMasterMaintenanceBooking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MASTER_MAINTENANCE_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenanceBooking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMasterMaintenanceBooking.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMasterMaintenanceBooking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMasterMaintenanceBooking"></param>
        ''' <returns>Return pMasterMaintenanceBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_CREATED_BY", pMasterMaintenanceBooking.CreatedBy)
                db.AddParameter("p_TERMINAL_ID", pMasterMaintenanceBooking.TerminalId)
                db.AddParameter("p_REF_ID", pMasterMaintenanceBooking.RefId)
                db.AddParameter("p_BOOKING_ID", pMasterMaintenanceBooking.BookingId)
                db.AddParameter("p_BOOKING_NO", pMasterMaintenanceBooking.BookingNo)
                db.AddParameter("p_LINE_ID", pMasterMaintenanceBooking.LineId)
                db.AddParameter("p_POL", pMasterMaintenanceBooking.Pol)
                db.AddParameter("p_TPT_MODE", pMasterMaintenanceBooking.TptMode)
                db.AddParameter("p_CREATED_ON", pMasterMaintenanceBooking.CreatedOn)
                db.AddParameter("p_REMARKS", pMasterMaintenanceBooking.Remarks)
                db.AddParameter("p_ErrorMsg", pMasterMaintenanceBooking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MASTER_MAINTENANCE_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMasterMaintenanceBooking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMasterMaintenanceBooking.ErrorMsg = ex.Message
                End Try
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PMasterMaintenanceBooking.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PMasterMaintenanceBooking.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                PMasterMaintenanceBooking.RefId = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_ID").ToString <> "" Then
                                PMasterMaintenanceBooking.BookingId = dbr("BOOKING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BOOKING_NO").ToString <> "" Then
                                PMasterMaintenanceBooking.BookingNo = dbr("BOOKING_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                PMasterMaintenanceBooking.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                PMasterMaintenanceBooking.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TPT_MODE").ToString <> "" Then
                                PMasterMaintenanceBooking.TptMode = dbr("TPT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PMasterMaintenanceBooking.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                PMasterMaintenanceBooking.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMasterMaintenanceBooking.ErrorMsg = ex.Message
            End Try
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMasterMaintenanceBooking As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MasterMaintenanceBooking
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                temp.RefId = dbr("REF_ID")
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
                            If dbr("BOOKING_NO").ToString <> "" Then
                                temp.BookingNo = dbr("BOOKING_NO")
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
                            If dbr("POL").ToString <> "" Then
                                temp.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TPT_MODE").ToString <> "" Then
                                temp.TptMode = dbr("TPT_MODE")
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
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
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
        Public Shared Function ReturnMasterMaintenanceBooking(ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As MasterMaintenanceBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MASTER_MAINTENANCE_BOOKING", "' '")
                pMasterMaintenanceBooking = ReturnObjectValues(dbr, pMasterMaintenanceBooking)
                dbr.Close()
            Catch ex As Exception
                pMasterMaintenanceBooking.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMasterMaintenanceBooking
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMasterMaintenanceBookingList (ByVal pMasterMaintenanceBooking As MasterMaintenanceBooking) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMasterMaintenanceBooking As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MASTER_MAINTENANCE_BOOKING", "' '")
                arrMasterMaintenanceBooking = ReturnObjectValuesList(dbr, arrMasterMaintenanceBooking)
                dbr.Close()
            Catch ex As Exception
                arrMasterMaintenanceBooking = Nothing
            End Try
            db.CloseDB()
            Return arrMasterMaintenanceBooking
        End Function
    End Class
End Namespace
