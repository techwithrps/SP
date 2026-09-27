Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: ServiceMasterCost
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ServiceMasterCost

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
        Private strCurrency As Long ' Define Private Variable Currency With DataType As Long 
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
            strCurrency = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pServiceMaster"></param>
        ''' <returns>Return pServiceMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
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
                db.AddParameter("p_ErrorMsg", pServiceMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MASTER_COST", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pServiceMaster.ServiceId = db.Parameters.Item("p_SERVICE_ID").value

                If pServiceMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
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
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
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
                db.AddParameter("p_ErrorMsg", pServiceMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_MASTER_COST", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pServiceMaster.ServiceId = db.Parameters.Item("p_SERVICE_ID").value

            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
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
        Public Shared Function Update(ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
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
                db.AddParameter("p_ErrorMsg", pServiceMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MASTER_COST", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pServiceMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
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
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
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
                db.AddParameter("p_ErrorMsg", pServiceMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_MASTER_COST", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pServiceMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
            End Try
            Return pServiceMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pServiceMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_ID").ToString <> "" Then
                                pServiceMaster.ServiceId = dbr("SERVICE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_CODE").ToString <> "" Then
                                pServiceMaster.ServiceCode = dbr("SERVICE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_NAME").ToString <> "" Then
                                pServiceMaster.ServiceName = dbr("SERVICE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SERVICE_TYPE_CODE").ToString <> "" Then
                                pServiceMaster.ServiceTypeCode = dbr("SERVICE_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                pServiceMaster.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UNIT").ToString <> "" Then
                                pServiceMaster.Unit = dbr("UNIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MAP_CODE").ToString <> "" Then
                                pServiceMaster.MapCode = dbr("MAP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_ON_PERCENTAGE").ToString <> "" Then
                                pServiceMaster.TaxOnPercentage = dbr("TAX_ON_PERCENTAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("UOM_ID").ToString <> "" Then
                                pServiceMaster.UomId = dbr("UOM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pServiceMaster.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pServiceMaster.Errormsg = ex.Message
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
                        Dim temp As New ServiceMasterCost
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
        Public Shared Function ReturnServiceMasterByServiceId(ByVal pServiceMaster As ServiceMasterCost) As ServiceMasterCost
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_COST_BY_ID", pServiceMaster.TerminalId & "," & pServiceMaster.ServiceId)
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
        Public Shared Function ReturnServiceMasterList(ByVal pServiceMaster As ServiceMasterCost) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrServiceMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_MASTER_COST_ALL", pServiceMaster.TerminalId)
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
        Public Shared Function ReturnServiceMasterListByType(ByVal pServiceMaster As ServiceMasterCost) As ArrayList
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
