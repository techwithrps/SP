Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ImpHolydayMaster
    ''' @author	: Amit K. Singh- 24/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ImpHolydayMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngHolydayId As Long ' Define Private Variable HolydayId With DataType As Long 
        Private strHolidayName As String ' Define Private Variable HolidayName With DataType As String 
        Private strChargable As String ' Define Private Variable Chargable With DataType As String 
        Private strHolydayFromDate As String ' Define Private Variable HolydayFromDate With DataType As String 
        Private strHolydayToDate As String ' Define Private Variable HolydayToDate With DataType As String 
        Private lngNoOfDays As Long ' Define Private Variable NoOfDays With DataType As Long 
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
        ''' Get or Set the Value of HolydayId
        ''' </summary>
        ''' <value>lngHolydayId</value>
        ''' <returns> Return lngHolydayId</returns>
        ''' <remarks> Get or Set the Value of HolydayId  </remarks>
        '''
        Public Property HolydayId() as Long
            Get
                Return lngHolydayId
            End Get
            Set(ByVal value As Long)
                lngHolydayId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HolidayName
        ''' </summary>
        ''' <value>strHolidayName</value>
        ''' <returns> Return strHolidayName</returns>
        ''' <remarks> Get or Set the Value of HolidayName  </remarks>
        '''
        Public Property HolidayName() as String
            Get
                Return strHolidayName
            End Get
            Set(ByVal value As String)
                strHolidayName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Chargable
        ''' </summary>
        ''' <value>strChargable</value>
        ''' <returns> Return strChargable</returns>
        ''' <remarks> Get or Set the Value of Chargable  </remarks>
        '''
        Public Property Chargable() as String
            Get
                Return strChargable
            End Get
            Set(ByVal value As String)
                strChargable = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HolydayFromDate
        ''' </summary>
        ''' <value>strHolydayFromDate</value>
        ''' <returns> Return strHolydayFromDate</returns>
        ''' <remarks> Get or Set the Value of HolydayFromDate  </remarks>
        '''
        Public Property HolydayFromDate() as String
            Get
                Return strHolydayFromDate
            End Get
            Set(ByVal value As String)
                strHolydayFromDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of HolydayToDate
        ''' </summary>
        ''' <value>strHolydayToDate</value>
        ''' <returns> Return strHolydayToDate</returns>
        ''' <remarks> Get or Set the Value of HolydayToDate  </remarks>
        '''
        Public Property HolydayToDate() as String
            Get
                Return strHolydayToDate
            End Get
            Set(ByVal value As String)
                strHolydayToDate = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of NoOfDays
        ''' </summary>
        ''' <value>lngNoOfDays</value>
        ''' <returns> Return lngNoOfDays</returns>
        ''' <remarks> Get or Set the Value of NoOfDays  </remarks>
        '''
        Public Property NoOfDays() as Long
            Get
                Return lngNoOfDays
            End Get
            Set(ByVal value As Long)
                lngNoOfDays = value
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
            lngHolydayId = 0 
            strHolidayName = ""
            strChargable = ""
            strHolydayFromDate = ""
            strHolydayToDate = ""
            lngNoOfDays = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pImpHolydayMaster"></param>
        ''' <returns>Return pImpHolydayMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpHolydayMaster.TerminalId)
                db.AddParameter("p_HOLYDAY_ID", pImpHolydayMaster.HolydayId)
                db.AddParameter("p_HOLIDAY_NAME", pImpHolydayMaster.HolidayName)
                db.AddParameter("p_CHARGABLE", pImpHolydayMaster.Chargable)
                db.AddParameter("p_HOLYDAY_FROM_DATE", pImpHolydayMaster.HolydayFromDate)
                db.AddParameter("p_HOLYDAY_TO_DATE", pImpHolydayMaster.HolydayToDate)
                db.AddParameter("p_NO_OF_DAYS", pImpHolydayMaster.NoOfDays)
                db.AddParameter("p_CREATED_BY", pImpHolydayMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpHolydayMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pImpHolydayMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_HOLYDAY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpHolydayMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pImpHolydayMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpHolydayMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpHolydayMaster"></param>
        ''' <returns>Return pImpHolydayMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpHolydayMaster.TerminalId)
                db.AddParameter("p_HOLYDAY_ID", pImpHolydayMaster.HolydayId)
                db.AddParameter("p_HOLIDAY_NAME", pImpHolydayMaster.HolidayName)
                db.AddParameter("p_CHARGABLE", pImpHolydayMaster.Chargable)
                db.AddParameter("p_HOLYDAY_FROM_DATE", pImpHolydayMaster.HolydayFromDate)
                db.AddParameter("p_HOLYDAY_TO_DATE", pImpHolydayMaster.HolydayToDate)
                db.AddParameter("p_NO_OF_DAYS", pImpHolydayMaster.NoOfDays)
                db.AddParameter("p_CREATED_BY", pImpHolydayMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpHolydayMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pImpHolydayMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_IMP_HOLYDAY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpHolydayMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pImpHolydayMaster.ErrorMsg = ex.Message
            End Try
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pImpHolydayMaster"></param>
        ''' <returns>Return pImpHolydayMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpHolydayMaster.TerminalId)
                db.AddParameter("p_HOLYDAY_ID", pImpHolydayMaster.HolydayId)
                db.AddParameter("p_HOLIDAY_NAME", pImpHolydayMaster.HolidayName)
                db.AddParameter("p_CHARGABLE", pImpHolydayMaster.Chargable)
                db.AddParameter("p_HOLYDAY_FROM_DATE", pImpHolydayMaster.HolydayFromDate)
                db.AddParameter("p_HOLYDAY_TO_DATE", pImpHolydayMaster.HolydayToDate)
                db.AddParameter("p_NO_OF_DAYS", pImpHolydayMaster.NoOfDays)
                db.AddParameter("p_CREATED_BY", pImpHolydayMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpHolydayMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pImpHolydayMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_HOLYDAY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpHolydayMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pImpHolydayMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pImpHolydayMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pImpHolydayMaster"></param>
        ''' <returns>Return pImpHolydayMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pImpHolydayMaster.TerminalId)
                db.AddParameter("p_HOLYDAY_ID", pImpHolydayMaster.HolydayId)
                db.AddParameter("p_HOLIDAY_NAME", pImpHolydayMaster.HolidayName)
                db.AddParameter("p_CHARGABLE", pImpHolydayMaster.Chargable)
                db.AddParameter("p_HOLYDAY_FROM_DATE", pImpHolydayMaster.HolydayFromDate)
                db.AddParameter("p_HOLYDAY_TO_DATE", pImpHolydayMaster.HolydayToDate)
                db.AddParameter("p_NO_OF_DAYS", pImpHolydayMaster.NoOfDays)
                db.AddParameter("p_CREATED_BY", pImpHolydayMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pImpHolydayMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pImpHolydayMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_IMP_HOLYDAY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pImpHolydayMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pImpHolydayMaster.ErrorMsg = ex.Message
                End Try
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PImpHolydayMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_ID").ToString <> "" Then
                                PImpHolydayMaster.HolydayId = dbr("HOLYDAY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLIDAY_NAME").ToString <> "" Then
                                PImpHolydayMaster.HolidayName = dbr("HOLIDAY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHARGABLE").ToString <> "" Then
                                PImpHolydayMaster.Chargable = dbr("CHARGABLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_FROM_DATE").ToString <> "" Then
                                PImpHolydayMaster.HolydayFromDate = dbr("HOLYDAY_FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_TO_DATE").ToString <> "" Then
                                PImpHolydayMaster.HolydayToDate = dbr("HOLYDAY_TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_DAYS").ToString <> "" Then
                                PImpHolydayMaster.NoOfDays = dbr("NO_OF_DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PImpHolydayMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PImpHolydayMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pImpHolydayMaster.ErrorMsg = ex.Message
            End Try
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrImpHolydayMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ImpHolydayMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_ID").ToString <> "" Then
                                temp.HolydayId = dbr("HOLYDAY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLIDAY_NAME").ToString <> "" Then
                                temp.HolidayName = dbr("HOLIDAY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CHARGABLE").ToString <> "" Then
                                temp.Chargable = dbr("CHARGABLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_FROM_DATE").ToString <> "" Then
                                temp.HolydayFromDate = dbr("HOLYDAY_FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("HOLYDAY_TO_DATE").ToString <> "" Then
                                temp.HolydayToDate = dbr("HOLYDAY_TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("NO_OF_DAYS").ToString <> "" Then
                                temp.NoOfDays = dbr("NO_OF_DAYS")
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
        Public Shared Function ReturnImpHolydayMaster(ByVal pImpHolydayMaster As ImpHolydayMaster) As ImpHolydayMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_HOLYDAY_MASTER_BY_ID", pImpHolydayMaster.TerminalId & "," & pImpHolydayMaster.HolydayId)
                pImpHolydayMaster = ReturnObjectValues(dbr, pImpHolydayMaster)
                dbr.Close()
            Catch ex As Exception
                pImpHolydayMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pImpHolydayMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnImpHolydayMasterList (ByVal pImpHolydayMaster As ImpHolydayMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrImpHolydayMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_IMP_HOLYDAY_MASTER_ALL", pImpHolydayMaster.TerminalId)
                arrImpHolydayMaster = ReturnObjectValuesList(dbr, arrImpHolydayMaster)
                dbr.Close()
            Catch ex As Exception
                arrImpHolydayMaster = Nothing
            End Try
            db.CloseDB()
            Return arrImpHolydayMaster
        End Function
    End Class
End Namespace
