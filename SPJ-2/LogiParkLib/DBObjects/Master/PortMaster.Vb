
Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PortMaster
    ''' @author	: Amit K. Singh- 2/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class PortMaster

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngPortId As Long ' Define Private Variable PortId With DataType As Long 
        Private lngPolId As Long ' Define Private Variable lngPolId With DataType As Long 
        Private strPortCode As String ' Define Private Variable PortCode With DataType As String 
        Private strPortName As String ' Define Private Variable PortName With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private strImpCustRef As String ' Define Private Variable ImpCustRef With DataType As String 
        Private strExpCustRef As String ' Define Private Variable ExpCustRef With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private lngCountryId As Long ' Define Private Variable CountryId With DataType As Long 
        Private StrEmailId As String ' Define Private Variable CountryId With DataType As Long 
        Private StrTelexMail As String ' Define Private Variable CountryId With DataType As Long 
        Private StrGatewayPort As String ' Define Private Variable CountryId With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


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
        ''' Get or Set the Value of PolId
        ''' </summary>
        ''' <value>lngPolId</value>
        ''' <returns> Return lngPolId</returns>
        ''' <remarks> Get or Set the Value of PolId  </remarks>
        '''
        Public Property PolId() As Long
            Get
                Return lngPolId
            End Get
            Set(ByVal value As Long)
                lngPolId = value
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
        ''' Get or Set the Value of PortName
        ''' </summary>
        ''' <value>strPortName</value>
        ''' <returns> Return strPortName</returns>
        ''' <remarks> Get or Set the Value of PortName  </remarks>
        '''
        Public Property PortName() As String
            Get
                Return strPortName
            End Get
            Set(ByVal value As String)
                strPortName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ImpCustRef
        ''' </summary>
        ''' <value>strImpCustRef</value>
        ''' <returns> Return strImpCustRef</returns>
        ''' <remarks> Get or Set the Value of ImpCustRef  </remarks>
        '''
        Public Property ImpCustRef() As String
            Get
                Return strImpCustRef
            End Get
            Set(ByVal value As String)
                strImpCustRef = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ExpCustRef
        ''' </summary>
        ''' <value>strExpCustRef</value>
        ''' <returns> Return strExpCustRef</returns>
        ''' <remarks> Get or Set the Value of ExpCustRef  </remarks>
        '''
        Public Property ExpCustRef() As String
            Get
                Return strExpCustRef
            End Get
            Set(ByVal value As String)
                strExpCustRef = value
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
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId</remarks>
        '''
        Public Property CountryId() As Long
            Get
                Return lngCountryId
            End Get
            Set(ByVal value As Long)
                lngCountryId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId</remarks>
        '''
        Public Property EmailId() As String
            Get
                Return StrEmailId
            End Get
            Set(ByVal value As String)
                StrEmailId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId</remarks>
        '''
        Public Property TelexMail() As String
            Get
                Return StrTelexMail
            End Get
            Set(ByVal value As String)
                StrTelexMail = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId</remarks>
        '''
        Public Property GatewayPort() As String
            Get
                Return StrGatewayPort
            End Get
            Set(ByVal value As String)
                StrGatewayPort = value
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
            lngPortId = 0
            lngPolId = 0
            strPortCode = ""
            strPortName = ""
            strAddress = ""
            strImpCustRef = ""
            strExpCustRef = ""
            strCreatedBy = ""
            strCreatedOn = ""
            lngCountryId = 0
            StrEmailId = ""
            StrTelexMail = ""
            StrGatewayPort = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pPortMaster"></param>
        ''' <returns>Return pPortMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pPortMaster As PortMaster) As PortMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortMaster.TerminalId)
                db.AddParameter("p_PORT_ID", pPortMaster.PortId, ParameterDirection.Output)
                db.AddParameter("p_PORT_CODE", pPortMaster.PortCode)
                db.AddParameter("p_PORT_NAME", pPortMaster.PortName)
                db.AddParameter("p_ADDRESS", pPortMaster.Address)
                db.AddParameter("p_IMP_CUST_REF", pPortMaster.ImpCustRef)
                db.AddParameter("p_EXP_CUST_REF", pPortMaster.ExpCustRef)
                db.AddParameter("p_CREATED_BY", pPortMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortMaster.CreatedOn)
                db.AddParameter("p_COUNTRY_ID", pPortMaster.CountryId)
                db.AddParameter("p_ErrorMsg", pPortMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PORT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPortMaster.PortId = db.Parameters.Item("p_PORT_ID").value

                If pPortMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPortMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPortMaster"></param>
        ''' <returns>Return pPortMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pPortMaster As PortMaster) As PortMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortMaster.TerminalId)
                db.AddParameter("p_PORT_ID", pPortMaster.PortId, ParameterDirection.Output)
                db.AddParameter("p_PORT_CODE", pPortMaster.PortCode)
                db.AddParameter("p_PORT_NAME", pPortMaster.PortName)
                db.AddParameter("p_ADDRESS", pPortMaster.Address)
                db.AddParameter("p_IMP_CUST_REF", pPortMaster.ImpCustRef)
                db.AddParameter("p_EXP_CUST_REF", pPortMaster.ExpCustRef)
                db.AddParameter("p_CREATED_BY", pPortMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortMaster.CreatedOn)
                db.AddParameter("p_COUNTRY_ID", pPortMaster.CountryId)
                db.AddParameter("p_ErrorMsg", pPortMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PORT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPortMaster.PortId = db.Parameters.Item("p_PORT_ID").value

            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
            End Try
            Return pPortMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pPortMaster"></param>
        ''' <returns>Return pPortMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pPortMaster As PortMaster) As PortMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortMaster.TerminalId)
                db.AddParameter("p_PORT_ID", pPortMaster.PortId)
                db.AddParameter("p_PORT_CODE", pPortMaster.PortCode)
                db.AddParameter("p_PORT_NAME", pPortMaster.PortName)
                db.AddParameter("p_ADDRESS", pPortMaster.Address)
                db.AddParameter("p_IMP_CUST_REF", pPortMaster.ImpCustRef)
                db.AddParameter("p_EXP_CUST_REF", pPortMaster.ExpCustRef)
                db.AddParameter("p_CREATED_BY", pPortMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortMaster.CreatedOn)
                db.AddParameter("p_COUNTRY_ID", pPortMaster.CountryId)
                db.AddParameter("p_ErrorMsg", pPortMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PORT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pPortMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPortMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPortMaster"></param>
        ''' <returns>Return pPortMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pPortMaster As PortMaster) As PortMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPortMaster.TerminalId)
                db.AddParameter("p_PORT_ID", pPortMaster.PortId)
                db.AddParameter("p_PORT_CODE", pPortMaster.PortCode)
                db.AddParameter("p_PORT_NAME", pPortMaster.PortName)
                db.AddParameter("p_ADDRESS", pPortMaster.Address)
                db.AddParameter("p_IMP_CUST_REF", pPortMaster.ImpCustRef)
                db.AddParameter("p_EXP_CUST_REF", pPortMaster.ExpCustRef)
                db.AddParameter("p_CREATED_BY", pPortMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPortMaster.CreatedOn)
                db.AddParameter("p_COUNTRY_ID", pPortMaster.CountryId)
                db.AddParameter("p_ErrorMsg", pPortMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PORT_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPortMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
            End Try
            Return pPortMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pPortMaster As PortMaster) As PortMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PPortMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ID").ToString <> "" Then
                                PPortMaster.PortId = dbr("PORT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL_ID").ToString <> "" Then
                                pPortMaster.PolId = dbr("POL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_CODE").ToString <> "" Then
                                PPortMaster.PortCode = dbr("PORT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_NAME").ToString <> "" Then
                                PPortMaster.PortName = dbr("PORT_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PPortMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CUST_REF").ToString <> "" Then
                                PPortMaster.ImpCustRef = dbr("IMP_CUST_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXP_CUST_REF").ToString <> "" Then
                                PPortMaster.ExpCustRef = dbr("EXP_CUST_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PPortMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PPortMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                pPortMaster.CountryId = dbr("COUNTRY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
            End Try
            Return pPortMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrPortMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New PortMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("POL_ID").ToString <> "" Then
                                temp.PolId = dbr("POL_ID")
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
                            If dbr("PORT_NAME").ToString <> "" Then
                                temp.PortName = dbr("PORT_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IMP_CUST_REF").ToString <> "" Then
                                temp.ImpCustRef = dbr("IMP_CUST_REF")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EXP_CUST_REF").ToString <> "" Then
                                temp.ExpCustRef = dbr("EXP_CUST_REF")
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
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                temp.CountryId = dbr("COUNTRY_ID")
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
        Public Shared Function ReturnPortMaster(ByVal pPortMaster As PortMaster) As PortMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_BY_ID", pPortMaster.TerminalId & ",'" & pPortMaster.PortId & "'")
                pPortMaster = ReturnObjectValues(dbr, pPortMaster)
                dbr.Close()
            Catch ex As Exception
                pPortMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pPortMaster
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterList(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_ALL", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterList1(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_ALL1", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterOther(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_OTHER", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterIndia(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_INDIA", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterIndiaGateway(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_INDIA_GATEWAY", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPortMasterCountry(ByVal pPortMaster As PortMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPortMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PORT_MASTER_COUNTRY", pPortMaster.TerminalId)
                arrPortMaster = ReturnObjectValuesList(dbr, arrPortMaster)
                dbr.Close()
            Catch ex As Exception
                arrPortMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPortMaster
        End Function
    End Class
End Namespace
