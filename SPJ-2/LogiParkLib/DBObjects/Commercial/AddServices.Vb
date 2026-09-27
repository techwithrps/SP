Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: AddServices
    ''' @author	: Amit K. Singh- 25/1/2021
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class AddServices

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngContJoId As Long ' Define Private Variable ContJoId With DataType As Long 
        Private lngMtyContId As Long ' Define Private Variable MtyContId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private dblQnty As Double ' Define Private Variable Qnty With DataType As Double 
        Private dblRate As Double ' Define Private Variable Rate With DataType As Double 
        Private dblExRate As Double ' Define Private Variable ExRate With DataType As Double 
        Private strCurrency As String ' Define Private Variable Currency With DataType As String 
        Private strServiceType As String ' Define Private Variable ServiceType With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long
        Private lngSSRId As Long ' Define Private Variable InvoiceNo With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private arrAddService As ArrayList

        Public Property AddServiceList() As ArrayList
            Get
                Return arrAddService
            End Get
            Set(ByVal value As ArrayList)
                arrAddService = value
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
        ''' Get or Set the Value of ContJoId
        ''' </summary>
        ''' <value>lngContJoId</value>
        ''' <returns> Return lngContJoId</returns>
        ''' <remarks> Get or Set the Value of ContJoId  </remarks>
        '''
        Public Property ContJoId() As Long
            Get
                Return lngContJoId
            End Get
            Set(ByVal value As Long)
                lngContJoId = value
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
        ''' Get or Set the Value of ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks> Get or Set the Value of ServiceId  </remarks>
        '''
        Public Property ServiceId() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Qnty
        ''' </summary>
        ''' <value>dblQnty</value>
        ''' <returns> Return dblQnty</returns>
        ''' <remarks> Get or Set the Value of Qnty  </remarks>
        '''
        Public Property Qnty() As Double
            Get
                Return dblQnty
            End Get
            Set(ByVal value As Double)
                dblQnty = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Rate
        ''' </summary>
        ''' <value>dblRate</value>
        ''' <returns> Return dblRate</returns>
        ''' <remarks> Get or Set the Value of Rate  </remarks>
        '''
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal value As Double)
                dblRate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ExRate
        ''' </summary>
        ''' <value>dblExRate</value>
        ''' <returns> Return dblExRate</returns>
        ''' <remarks> Get or Set the Value of ExRate  </remarks>
        '''
        Public Property ExRate() As Double
            Get
                Return dblExRate
            End Get
            Set(ByVal value As Double)
                dblExRate = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Currency
        ''' </summary>
        ''' <value>strCurrency</value>
        ''' <returns> Return strCurrency</returns>
        ''' <remarks> Get or Set the Value of Currency  </remarks>
        '''
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of ServiceType
        ''' </summary>
        ''' <value>strServiceType</value>
        ''' <returns> Return strServiceType</returns>
        ''' <remarks> Get or Set the Value of ServiceType  </remarks>
        '''
        Public Property ServiceType() As String
            Get
                Return strServiceType
            End Get
            Set(ByVal value As String)
                strServiceType = value
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
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngComapnyId</value>
        ''' <returns> Return lngComapnyId</returns>
        ''' <remarks> Get or Set the Value of CompanyId  </remarks>
        '''
        Public Property CompanyId() As Long
            Get
                Return lngCompanyId
            End Get
            Set(ByVal value As Long)
                lngCompanyId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of SSRId
        ''' </summary>
        ''' <value>SSRId</value>
        ''' <returns> Return lngSSRId</returns>
        ''' <remarks> Get or Set the Value of SSRId  </remarks>
        '''
        Public Property SSRId() As Long
            Get
                Return lngSSRId
            End Get
            Set(ByVal value As Long)
                lngSSRId = value
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
            lngContJoId = 0
            lngMtyContId = 0
            lngServiceId = 0
            dblQnty = 0.0
            dblRate = 0.0
            dblExRate = 0.0
            strCurrency = ""
            strServiceType = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngCompanyId = 0
            lngSSRId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pAddServices"></param>
        ''' <returns>Return pAddServices Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pAddServices As AddServices) As AddServices
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pAddServices.TerminalId)
                db.AddParameter("p_SSR_ID", pAddServices.SSRId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_ID", pAddServices.ContJoId)
                db.AddParameter("p_MTY_CONT_ID", pAddServices.MtyContId)
                db.AddParameter("p_SERVICE_ID", pAddServices.ServiceId)
                db.AddParameter("p_QNTY", pAddServices.Qnty)
                db.AddParameter("p_RATE", pAddServices.Rate)
                db.AddParameter("p_EX_RATE", pAddServices.ExRate)
                db.AddParameter("p_CURRENCY", pAddServices.Currency)
                db.AddParameter("p_SERVICE_TYPE", pAddServices.ServiceType)
                db.AddParameter("p_CREATED_BY", pAddServices.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAddServices.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pAddServices.CompanyId)
                db.AddParameter("p_ErrorMsg", pAddServices.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ADD_SERVICES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAddServices.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pAddServices.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAddServices.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAddServices
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAddServices"></param>
        ''' <returns>Return pAddServices Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pAddServices As AddServices) As AddServices
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pAddServices.TerminalId)
                db.AddParameter("p_SSR_ID", pAddServices.SSRId, ParameterDirection.Output)
                db.AddParameter("p_CONT_JO_ID", pAddServices.ContJoId)
                db.AddParameter("p_MTY_CONT_ID", pAddServices.MtyContId)
                db.AddParameter("p_SERVICE_ID", pAddServices.ServiceId)
                db.AddParameter("p_QNTY", pAddServices.Qnty)
                db.AddParameter("p_RATE", pAddServices.Rate)
                db.AddParameter("p_EX_RATE", pAddServices.ExRate)
                db.AddParameter("p_CURRENCY", pAddServices.Currency)
                db.AddParameter("p_SERVICE_TYPE", pAddServices.ServiceType)
                db.AddParameter("p_CREATED_BY", pAddServices.CreatedBy)
                db.AddParameter("p_CREATED_ON", pAddServices.CreatedOn)
                db.AddParameter("p_COMPANY_ID", pAddServices.CompanyId)
                db.AddParameter("p_ErrorMsg", pAddServices.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ADD_SERVICES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAddServices.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pAddServices.ErrorMsg = ex.Message
            End Try
            Return pAddServices
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pAddServices"></param>
        ''' <returns>Return pAddServices Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pAddServices As AddServices) As AddServices
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pAddServices.TerminalId)
                db.AddParameter("p_CONT_JO_ID", pAddServices.ContJoId)
                db.AddParameter("p_MTY_CONT_ID", pAddServices.MtyContId)
                db.AddParameter("p_SERVICE_ID", pAddServices.ServiceId)
                db.AddParameter("p_QNTY", pAddServices.Qnty)
                db.AddParameter("p_RATE", pAddServices.Rate)
                db.AddParameter("p_EX_RATE", pAddServices.ExRate)
                db.AddParameter("p_CURRENCY", pAddServices.Currency)
                db.AddParameter("p_ErrorMsg", pAddServices.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ADD_SERVICES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAddServices.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pAddServices.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pAddServices.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pAddServices
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pAddServices"></param>
        ''' <returns>Return pAddServices Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pAddServices As AddServices) As AddServices
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pAddServices.TerminalId)
                db.AddParameter("p_CONT_JO_ID", pAddServices.ContJoId)
                db.AddParameter("p_MTY_CONT_ID", pAddServices.MtyContId)
                db.AddParameter("p_SERVICE_ID", pAddServices.ServiceId)
                db.AddParameter("p_QNTY", pAddServices.Qnty)
                db.AddParameter("p_RATE", pAddServices.Rate)
                db.AddParameter("p_EX_RATE", pAddServices.ExRate)
                db.AddParameter("p_CURRENCY", pAddServices.Currency)
                db.AddParameter("p_ErrorMsg", pAddServices.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ADD_SERVICES", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pAddServices.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pAddServices.ErrorMsg = ex.Message
            End Try
            Return pAddServices
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pAddServices As AddServices) As AddServices
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PAddServices.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                PAddServices.ContJoId = dbr("CONT_JO_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                PAddServices.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PAddServices.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                PAddServices.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                PAddServices.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                PAddServices.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                pAddServices.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pAddServices.ErrorMsg = ex.Message
            End Try
            Return pAddServices
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrAddServices As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New AddServices
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_JO_ID").ToString <> "" Then
                                temp.ContJoId = dbr("CONT_JO_ID")
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
                            If dbr("SERVICE_ID").ToString <> "" Then
                                temp.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("QNTY").ToString <> "" Then
                                temp.Qnty = dbr("QNTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                temp.Rate = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                temp.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                temp.Currency = dbr("CURRENCY")
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
        Public Shared Function ReturnAddServicesContJoId(ByVal pAddServices As AddServices) As AddServices
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ADD_SERVICES_ID", pAddServices.TerminalId & ",'" & pAddServices.ContJoId)
                pAddServices = ReturnObjectValues(dbr, pAddServices)
                dbr.Close()
            Catch ex As Exception
                pAddServices.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pAddServices
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnAddServicesList(ByVal pAddServices As AddServices) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrAddServices As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ADD_SERVICES", "' '")
                arrAddServices = ReturnObjectValuesList(dbr, arrAddServices)
                dbr.Close()
            Catch ex As Exception
                arrAddServices = Nothing
            End Try
            db.CloseDB()
            Return arrAddServices
        End Function
        Public Shared Function InsertAddServiceList(ByVal pAddServices As AddServices) As AddServices
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each ii As AddServices In pAddServices.AddServiceList
                    AddServices.InsertTrn(db, ii)
                    If ii.Errormsg <> "" Then
                        Throw New Exception(ii.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pAddServices.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pAddServices
        End Function
    End Class
End Namespace
