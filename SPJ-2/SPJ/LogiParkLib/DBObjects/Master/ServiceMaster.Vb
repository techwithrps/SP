Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceMaster
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ServiceMaster

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId With DataType As Long 
        Private strServiceCode As String ' Define Private Variable ServiceCode With DataType As String 
        Private strServiceName As String ' Define Private Variable ServiceName With DataType As String 
        Private strServiceTypeCode As String ' Define Private Variable ServiceTypeCode With DataType As String 
        Private lngTaxGroupId As Long ' Define Private Variable TaxGroupId With DataType As Long 
        Private strUnit As String ' Define Private Variable Unit With DataType As String 
        Private strMapCode As String ' Define Private Variable MapCode With DataType As String 
        Private lngTaxOnPercentage As Double ' Define Private Variable TaxOnPercentage With DataType As Long 
        Private lngUomId As Long ' Define Private Variable UomId With DataType As Long 
        Private dblExRate As Double ' Define Private Variable ExRate With DataType As Long 
        Private strCurrency As String ' Define Private Variable Currency With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strTallyInterStateServiceName As String ' Define Private Variable MapCode With DataType As String 
        Private strTallyLocalStateServiceName As String ' Define Private Variable MapCode With DataType As String 
        Private lngServiceGroupId As Long ' Define Private Variable TaxOnPercentage With DataType As Long 

        Private strTallyPurchaseInterStateServiceName As String ' Define Private Variable MapCode With DataType As String 
        Private strTallyPurchaseLocalStateServiceName As String ' Define Private Variable MapCode With DataType As String 
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

        Public Property ServiceGroupId() As Long
            Get
                Return lngServiceGroupId
            End Get
            Set(ByVal value As Long)
                lngServiceGroupId = value
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

        Public Property ExRate() As Double
            Get
                Return dblExRate
            End Get
            Set(ByVal value As Double)
                dblExRate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceCode
        ''' </summary>
        ''' <value>strServiceCode</value>
        ''' <returns> Return strServiceCode</returns>
        ''' <remarks> Get or Set the Value of ServiceCode  </remarks>
        '''
        Public Property ServiceCode() As String
            Get
                Return strServiceCode
            End Get
            Set(ByVal value As String)
                strServiceCode = value
            End Set
        End Property

        Public Property TallyInterStateServiceName() As String
            Get
                Return strTallyInterStateServiceName
            End Get
            Set(ByVal value As String)
                strTallyInterStateServiceName = value
            End Set
        End Property

        Public Property TallyLocalStateServiceName() As String
            Get
                Return strTallyLocalStateServiceName
            End Get
            Set(ByVal value As String)
                strTallyLocalStateServiceName = value
            End Set
        End Property


        Public Property TallyPurchaseInterStateServiceName() As String
            Get
                Return strTallyPurchaseInterStateServiceName
            End Get
            Set(ByVal value As String)
                strTallyPurchaseInterStateServiceName = value
            End Set
        End Property

        Public Property TallyPurchaseLocalStateServiceName() As String
            Get
                Return strTallyPurchaseLocalStateServiceName
            End Get
            Set(ByVal value As String)
                strTallyPurchaseLocalStateServiceName = value
            End Set
        End Property

        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal value As String)
                strCurrency = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceName
        ''' </summary>
        ''' <value>strServiceName</value>
        ''' <returns> Return strServiceName</returns>
        ''' <remarks> Get or Set the Value of ServiceName  </remarks>
        '''
        Public Property ServiceName() As String
            Get
                Return strServiceName
            End Get
            Set(ByVal value As String)
                strServiceName = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceTypeCode
        ''' </summary>
        ''' <value>strServiceTypeCode</value>
        ''' <returns> Return strServiceTypeCode</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeCode  </remarks>
        '''
        Public Property ServiceTypeCode() As String
            Get
                Return strServiceTypeCode
            End Get
            Set(ByVal value As String)
                strServiceTypeCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TaxGroupId
        ''' </summary>
        ''' <value>lngTaxGroupId</value>
        ''' <returns> Return lngTaxGroupId</returns>
        ''' <remarks> Get or Set the Value of TaxGroupId  </remarks>
        '''
        Public Property TaxGroupId() As Long
            Get
                Return lngTaxGroupId
            End Get
            Set(ByVal value As Long)
                lngTaxGroupId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Unit
        ''' </summary>
        ''' <value>strUnit</value>
        ''' <returns> Return strUnit</returns>
        ''' <remarks> Get or Set the Value of Unit  </remarks>
        '''
        Public Property Unit() As String
            Get
                Return strUnit
            End Get
            Set(ByVal value As String)
                strUnit = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of MapCode
        ''' </summary>
        ''' <value>strMapCode</value>
        ''' <returns> Return strMapCode</returns>
        ''' <remarks> Get or Set the Value of MapCode  </remarks>
        '''
        Public Property MapCode() As String
            Get
                Return strMapCode
            End Get
            Set(ByVal value As String)
                strMapCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TaxOnPercentage
        ''' </summary>
        ''' <value>lngTaxOnPercentage</value>
        ''' <returns> Return lngTaxOnPercentage</returns>
        ''' <remarks> Get or Set the Value of TaxOnPercentage  </remarks>
        '''
        Public Property TaxOnPercentage() As Double
            Get
                Return lngTaxOnPercentage
            End Get
            Set(ByVal value As Double)
                lngTaxOnPercentage = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of UomId
        ''' </summary>
        ''' <value>lngUomId</value>
        ''' <returns> Return lngUomId</returns>
        ''' <remarks> Get or Set the Value of UomId  </remarks>
        '''
        Public Property UomId() As Long
            Get
                Return lngUomId
            End Get
            Set(ByVal value As Long)
                lngUomId = value
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
            lngServiceId = 0
            strServiceCode = ""
            strServiceName = ""
            strServiceTypeCode = ""
            lngTaxGroupId = 0
            strUnit = ""
            strMapCode = ""
            lngTaxOnPercentage = 0
            lngUomId = 0
            dblExRate = 0.0
            strCurrency = ""
            strErrormsg = ""
            lngServiceGroupId = 0
            strTallyInterStateServiceName = ""
            strTallyLocalStateServiceName = ""
            strTallyPurchaseInterStateServiceName = ""
            strTallyPurchaseLocalStateServiceName = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pServiceMaster"></param>
        ''' <returns>Return pServiceMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMaster.TerminalId)
                db.AddParameter("p_SERVICE_ID", pServiceMaster.ServiceId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_CODE", pServiceMaster.ServiceCode)
                db.AddParameter("p_SERVICE_NAME", pServiceMaster.ServiceName)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceMaster.ServiceTypeCode)
                db.AddParameter("p_TAX_GROUP_ID", pServiceMaster.TaxGroupId)
                db.AddParameter("p_UNIT", pServiceMaster.Unit)
                db.AddParameter("p_MAP_CODE", pServiceMaster.MapCode)
                db.AddParameter("p_TAX_ON_PERCENTAGE", pServiceMaster.TaxOnPercentage)
                db.AddParameter("p_UOM_ID", pServiceMaster.UomId)
                db.AddParameter("p_EX_RATE", pServiceMaster.ExRate)
                db.AddParameter("p_CURRENCY", pServiceMaster.Currency)
                db.AddParameter("p_SERVICE_GROUP_ID", pServiceMaster.ServiceGroupId)
                db.AddParameter("p_TALLY_INTER_STATE_NAME", pServiceMaster.TallyInterStateServiceName)
                db.AddParameter("p_TALLY_LOCAL_STATE_NAME", pServiceMaster.TallyLocalStateServiceName)
                db.AddParameter("p_TALLY_PURCHASE_INTER_STATE_NAME", pServiceMaster.TallyPurchaseInterStateServiceName)
                db.AddParameter("p_TALLY__PURCHASE_LOCAL_STATE_NAME", pServiceMaster.TallyPurchaseLocalStateServiceName)
                db.AddParameter("p_ErrorMsg", pServiceMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pServiceMaster.ServiceId = db.Parameters.Item("p_SERVICE_ID").value

                If pServiceMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceMaster"></param>
        ''' <returns>Return pServiceMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMaster.TerminalId)
                db.AddParameter("p_SERVICE_ID", pServiceMaster.ServiceId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_CODE", pServiceMaster.ServiceCode)
                db.AddParameter("p_SERVICE_NAME", pServiceMaster.ServiceName)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceMaster.ServiceTypeCode)
                db.AddParameter("p_TAX_GROUP_ID", pServiceMaster.TaxGroupId)
                db.AddParameter("p_UNIT", pServiceMaster.Unit)
                db.AddParameter("p_MAP_CODE", pServiceMaster.MapCode)
                db.AddParameter("p_TAX_ON_PERCENTAGE", pServiceMaster.TaxOnPercentage)
                db.AddParameter("p_UOM_ID", pServiceMaster.UomId)
                db.AddParameter("p_ErrorMsg", pServiceMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pServiceMaster.ServiceId = db.Parameters.Item("p_SERVICE_ID").value

            Catch ex As Exception
                pServiceMaster.ErrorMsg = ex.Message
            End Try
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pServiceMaster"></param>
        ''' <returns>Return pServiceMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMaster.TerminalId)
                db.AddParameter("p_SERVICE_ID", pServiceMaster.ServiceId)
                db.AddParameter("p_SERVICE_CODE", pServiceMaster.ServiceCode)
                db.AddParameter("p_SERVICE_NAME", pServiceMaster.ServiceName)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceMaster.ServiceTypeCode)
                db.AddParameter("p_TAX_GROUP_ID", pServiceMaster.TaxGroupId)
                db.AddParameter("p_UNIT", pServiceMaster.Unit)
                db.AddParameter("p_MAP_CODE", pServiceMaster.MapCode)
                db.AddParameter("p_TAX_ON_PERCENTAGE", pServiceMaster.TaxOnPercentage)
                db.AddParameter("p_UOM_ID", pServiceMaster.UomId)
                db.AddParameter("p_EX_RATE", pServiceMaster.ExRate)
                db.AddParameter("p_CURRENCY", pServiceMaster.Currency)
                db.AddParameter("p_SERVICE_GROUP_ID", pServiceMaster.ServiceGroupId)
                db.AddParameter("p_TALLY_INTER_STATE_NAME", pServiceMaster.TallyInterStateServiceName)
                db.AddParameter("p_TALLY_LOCAL_STATE_NAME", pServiceMaster.TallyLocalStateServiceName)
                db.AddParameter("p_TALLY_PURCHASE_INTER_STATE_NAME", pServiceMaster.TallyPurchaseInterStateServiceName)
                db.AddParameter("p_TALLY__PURCHASE_LOCAL_STATE_NAME", pServiceMaster.TallyPurchaseLocalStateServiceName)
                db.AddParameter("p_ErrorMsg", pServiceMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceMaster.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pServiceMaster"></param>
        ''' <returns>Return pServiceMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pServiceMaster.TerminalId)
                db.AddParameter("p_SERVICE_ID", pServiceMaster.ServiceId)
                db.AddParameter("p_SERVICE_CODE", pServiceMaster.ServiceCode)
                db.AddParameter("p_SERVICE_NAME", pServiceMaster.ServiceName)
                db.AddParameter("p_SERVICE_TYPE_CODE", pServiceMaster.ServiceTypeCode)
                db.AddParameter("p_TAX_GROUP_ID", pServiceMaster.TaxGroupId)
                db.AddParameter("p_UNIT", pServiceMaster.Unit)
                db.AddParameter("p_MAP_CODE", pServiceMaster.MapCode)
                db.AddParameter("p_TAX_ON_PERCENTAGE", pServiceMaster.TaxOnPercentage)
                db.AddParameter("p_UOM_ID", pServiceMaster.UomId)
                db.AddParameter("p_EX_RATE", pServiceMaster.ExRate)
                db.AddParameter("p_CURRENCY", pServiceMaster.Currency)
                db.AddParameter("p_ErrorMsg", pServiceMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pServiceMaster.ErrorMsg = ex.Message
            End Try
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PServiceMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                PServiceMaster.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_CODE").ToString <> "" Then
                                PServiceMaster.ServiceCode = dbr("SERVICE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_NAME").ToString <> "" Then
                                PServiceMaster.ServiceName = dbr("SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                PServiceMaster.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                PServiceMaster.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNIT").ToString <> "" Then
                                PServiceMaster.Unit = dbr("UNIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                PServiceMaster.MapCode = dbr("MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_ON_PERCENTAGE").ToString <> "" Then
                                PServiceMaster.TaxOnPercentage = dbr("TAX_ON_PERCENTAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                PServiceMaster.UomId = dbr("UOM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pServiceMaster.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENCY").ToString <> "" Then
                                pServiceMaster.Currency = dbr("CURRENCY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("INTER_STATE_SERVICE_NAME").ToString <> "" Then
                                pServiceMaster.TallyInterStateServiceName = dbr("INTER_STATE_SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCAL_STATE_SERVICE_NAME").ToString <> "" Then
                                pServiceMaster.TallyLocalStateServiceName = dbr("LOCAL_STATE_SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_INTER_STATE_SERVICE").ToString <> "" Then
                                pServiceMaster.TallyPurchaseInterStateServiceName = dbr("PURCHASE_INTER_STATE_SERVICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_LOCAL_STATE_SERVICE").ToString <> "" Then
                                pServiceMaster.TallyPurchaseLocalStateServiceName = dbr("PURCHASE_LOCAL_STATE_SERVICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_GROUP_ID").ToString <> "" Then
                                pServiceMaster.ServiceGroupId = dbr("SERVICE_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pServiceMaster.ErrorMsg = ex.Message
            End Try
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrServiceMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New ServiceMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
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
                            If dbr("SERVICE_CODE").ToString <> "" Then
                                temp.ServiceCode = dbr("SERVICE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_NAME").ToString <> "" Then
                                temp.ServiceName = dbr("SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                temp.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                temp.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNIT").ToString <> "" Then
                                temp.Unit = dbr("UNIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                temp.MapCode = dbr("MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_ON_PERCENTAGE").ToString <> "" Then
                                temp.TaxOnPercentage = dbr("TAX_ON_PERCENTAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                temp.UomId = dbr("UOM_ID")
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
                        Try
                            If dbr("INTER_STATE_SERVICE_NAME").ToString <> "" Then
                                temp.TallyInterStateServiceName = dbr("INTER_STATE_SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LOCAL_STATE_SERVICE_NAME").ToString <> "" Then
                                temp.TallyLocalStateServiceName = dbr("LOCAL_STATE_SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_GROUP_ID").ToString <> "" Then
                                temp.ServiceGroupId = dbr("SERVICE_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_INTER_STATE_SERVICE").ToString <> "" Then
                                temp.TallyPurchaseInterStateServiceName = dbr("PURCHASE_INTER_STATE_SERVICE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_LOCAL_STATE_SERVICE").ToString <> "" Then
                                temp.TallyPurchaseLocalStateServiceName = dbr("PURCHASE_LOCAL_STATE_SERVICE")
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
        ''' Preparing Return Object By TerminalId, ServiceId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnServiceMasterByServiceId(ByVal pServiceMaster As ServiceMaster) As ServiceMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_BY_ID", pServiceMaster.TerminalId & "," & pServiceMaster.ServiceId)
                pServiceMaster = ReturnObjectValues(dbr, pServiceMaster)
                dbr.Close()
            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceMasterList(ByVal pServiceMaster As ServiceMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_ALL", pServiceMaster.TerminalId)
                arrServiceMaster = ReturnObjectValuesList(dbr, arrServiceMaster)
                dbr.Close()
            Catch ex As Exception
                arrServiceMaster = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceMasterListNew(ByVal pServiceMaster As ServiceMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_NEW", pServiceMaster.TerminalId)
                arrServiceMaster = ReturnObjectValuesList(dbr, arrServiceMaster)
                dbr.Close()
            Catch ex As Exception
                arrServiceMaster = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceMasterListSSR(ByVal pServiceMaster As ServiceMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_SSR", pServiceMaster.TerminalId)
                arrServiceMaster = ReturnObjectValuesList(dbr, arrServiceMaster)
                dbr.Close()
            Catch ex As Exception
                arrServiceMaster = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnServiceMasterListByType(ByVal pServiceMaster As ServiceMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_BY_TYPE", pServiceMaster.TerminalId & ",'" & pServiceMaster.ServiceTypeCode & "'")
                arrServiceMaster = ReturnObjectValuesList(dbr, arrServiceMaster)
                dbr.Close()
            Catch ex As Exception
                arrServiceMaster = Nothing
            End Try
            db.CloseDB()
            Return arrServiceMaster
        End Function
    End Class
End Namespace
