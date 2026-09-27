Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  eLOGiFleet :: Fleet Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: FleetGrMapping
    ''' @author	: Amit K. Singh- 10/11/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class GrOilDtls

        Private lngRefId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngGRId As Long
        Private lngRate As Double ' Define Private Variable GrId With DataType As Long 
        Private IngCash As Double ' Define Private Variable GrId With DataType As Long 
        Private IngToll As Double ' Define Private Variable GrId With DataType As Long 
        Private ingOther As Double ' Define Private Variable GrId With DataType As Long 
        Private strOilRemarks As String ' Define Private Variable GrId With DataType As Long 
        Private lngOil As Double ' Define Private Variable GrNo With DataType As Long 
        Private lngTotal As Double
        Private lngVendorId As Long
        Private strCreatedBy As String ' Define Private Variable GrDate With DataType As String 
        Private strCreatedOn As String ' Define Private Variable ContNo With DataType As String 
        Private strErrorMsg As String
        Private arrFleetGRList As ArrayList
        Public Property GrOilDtlsList() As ArrayList
            Get
                Return arrFleetGRList
            End Get
            Set(ByVal value As ArrayList)
                arrFleetGRList = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property REF_ID() As Long
            Get
                Return lngRefId
            End Get
            Set(ByVal value As Long)
                lngRefId = value
            End Set
        End Property

        Public Property GR_ID() As Long
            Get
                Return lngGRId
            End Get
            Set(ByVal value As Long)
                lngGRId = value
            End Set
        End Property

        Public Property RATE() As Double
            Get
                Return lngRate
            End Get
            Set(ByVal value As Double)
                lngRate = value
            End Set
        End Property

        Public Property CASH() As Double
            Get
                Return IngCash
            End Get
            Set(ByVal value As Double)
                IngCash = value
            End Set
        End Property
        Public Property TOLL() As Double
            Get
                Return IngToll
            End Get
            Set(ByVal value As Double)
                IngToll = value
            End Set
        End Property
        Public Property OTHER() As Double
            Get
                Return ingOther
            End Get
            Set(ByVal value As Double)
                ingOther = value
            End Set
        End Property
        Public Property OilRemarks() As String
            Get
                Return strOilRemarks
            End Get
            Set(ByVal value As String)
                strOilRemarks = value
            End Set
        End Property

        Public Property OIL() As Double
            Get
                Return lngOil
            End Get
            Set(ByVal value As Double)
                lngOil = value
            End Set
        End Property

        Public Property TOTAL() As Double
            Get
                Return lngTotal
            End Get
            Set(ByVal value As Double)
                lngTotal = value
            End Set
        End Property

        Public Property VENDOR_ID() As Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
            End Set
        End Property

        Public Property CREATED_BY() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property
        Public Property CREATED_ON() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property
        Public Property ERROR_MSG() As String
            Get
                Return strErrorMsg
            End Get
            Set(ByVal value As String)
                strErrorMsg = value
            End Set
        End Property
        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngRefId = 0
            lngGRId = 0
            lngRate = 0.0
            lngOil = 0.0
            lngTotal = 0.0
            IngCash = 0.0
            IngToll = 0.0
            ingOther = 0.0
            strOilRemarks = ""
            lngVendorId = 0
            strCreatedBy = ""
            strCreatedOn = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pFleetGrMapping"></param>
        ''' <returns>Return pFleetGrMapping Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pFleetGrMapping As GrOilDtls) As GrOilDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_REF_ID", pFleetGrMapping.REF_ID, ParameterDirection.Output)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GR_ID)
                db.AddParameter("p_RATE", pFleetGrMapping.RATE)
                db.AddParameter("p_CASH", pFleetGrMapping.CASH)
                db.AddParameter("p_TOLL_TAX", pFleetGrMapping.TOLL)
                db.AddParameter("p_OTHER", pFleetGrMapping.OTHER)
                db.AddParameter("p_OIL_REMARKS", pFleetGrMapping.OilRemarks)
                db.AddParameter("p_OIL", pFleetGrMapping.OIL)
                db.AddParameter("p_TOTAL", pFleetGrMapping.TOTAL)
                db.AddParameter("p_VENDOR_ID", pFleetGrMapping.VENDOR_ID)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CREATED_BY)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CREATED_ON)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.ERROR_MSG, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_GR_OIL_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.ERROR_MSG = db.Parameters.Item("p_ErrorMsg").value.ToString
                Else
                    pFleetGrMapping.REF_ID = db.Parameters.Item("p_REF_ID").value
                End If

            Catch ex As Exception
                pFleetGrMapping.ERROR_MSG = ex.Message
            End Try
            Return pFleetGrMapping
        End Function

        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pFleetGrMapping As GrOilDtls) As GrOilDtls
            Try
                db.ClearParameters()
                db.AddParameter("p_REF_ID", pFleetGrMapping.REF_ID)
                db.AddParameter("p_GR_ID", pFleetGrMapping.GR_ID)
                db.AddParameter("p_RATE", pFleetGrMapping.RATE)
                db.AddParameter("p_CASH", pFleetGrMapping.CASH)
                db.AddParameter("p_TOLL_TAX", pFleetGrMapping.TOLL)
                db.AddParameter("p_OTHER", pFleetGrMapping.OTHER)
                db.AddParameter("p_OIL_REMARKS", pFleetGrMapping.OilRemarks)
                db.AddParameter("p_OIL", pFleetGrMapping.OIL)
                db.AddParameter("p_TOTAL", pFleetGrMapping.TOTAL)
                db.AddParameter("p_VENDOR_ID", pFleetGrMapping.VENDOR_ID)
                db.AddParameter("p_CREATED_BY", pFleetGrMapping.CREATED_BY)
                db.AddParameter("p_CREATED_ON", pFleetGrMapping.CREATED_ON)
                db.AddParameter("p_ErrorMsg", pFleetGrMapping.ERROR_MSG, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.GR_OIL_DTLS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pFleetGrMapping.ERROR_MSG = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pFleetGrMapping.ERROR_MSG = ex.Message
            End Try
            Return pFleetGrMapping
        End Function

        Public Shared Function InsertUpdateGrOilDtls(ByVal pGrOilDtls As GrOilDtls) As GrOilDtls
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each pFID As GrOilDtls In pGrOilDtls.GrOilDtlsList
                    If pFID.REF_ID = 0 Then
                        GrOilDtls.InsertTrn(db, pFID)
                    Else
                        GrOilDtls.UpdateTrn(db, pFID)
                    End If
                    If pFID.ERROR_MSG <> "" Then
                        Throw New Exception(pFID.ERROR_MSG)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pGrOilDtls.ERROR_MSG = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pGrOilDtls
        End Function

        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pFleetGrMapping As GrOilDtls) As GrOilDtls
            Try
                If dbr.HasRows Then

                    While dbr.Read
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                pFleetGrMapping.REF_ID = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_ID").ToString <> "" Then
                                pFleetGrMapping.GR_ID = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                pFleetGrMapping.RATE = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CASH").ToString <> "" Then
                                pFleetGrMapping.CASH = dbr("CASH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOLL_TAX").ToString <> "" Then
                                pFleetGrMapping.TOLL = dbr("TOLL_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER").ToString <> "" Then
                                pFleetGrMapping.OTHER = dbr("OTHER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_REMARKS").ToString <> "" Then
                                pFleetGrMapping.OilRemarks = dbr("OIL_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL").ToString <> "" Then
                                pFleetGrMapping.OIL = dbr("OIL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                pFleetGrMapping.TOTAL = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pFleetGrMapping.VENDOR_ID = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetGrMapping.CREATED_BY = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetGrMapping.CREATED_ON = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pFleetGrMapping.ERROR_MSG = ex.Message
            End Try
            Return pFleetGrMapping
        End Function
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrFleetGrMapping As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim pFleetGrMapping As New GrOilDtls
                        Try
                            If dbr("REF_ID").ToString <> "" Then
                                pFleetGrMapping.REF_ID = dbr("REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GR_ID").ToString <> "" Then
                                pFleetGrMapping.GR_ID = dbr("GR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("RATE").ToString <> "" Then
                                pFleetGrMapping.RATE = dbr("RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CASH").ToString <> "" Then
                                pFleetGrMapping.CASH = dbr("CASH")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOLL_TAX").ToString <> "" Then
                                pFleetGrMapping.TOLL = dbr("TOLL_TAX")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OTHER").ToString <> "" Then
                                pFleetGrMapping.OTHER = dbr("OTHER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL_REMARKS").ToString <> "" Then
                                pFleetGrMapping.OilRemarks = dbr("OIL_REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("OIL").ToString <> "" Then
                                pFleetGrMapping.OIL = dbr("OIL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TOTAL").ToString <> "" Then
                                pFleetGrMapping.TOTAL = dbr("TOTAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pFleetGrMapping.VENDOR_ID = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pFleetGrMapping.CREATED_BY = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pFleetGrMapping.CREATED_ON = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(pFleetGrMapping)
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
        Public Shared Function ReturnGrOilDtlsByGrId(ByVal pGrOilDtls As GrOilDtls) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrFleetGrMapping As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_OIL_DTLS_BY_GR_ID", pGrOilDtls.GR_ID)
                arrFleetGrMapping = ReturnObjectValuesList(dbr, arrFleetGrMapping)
                dbr.Close()
            Catch ex As Exception
                arrFleetGrMapping = Nothing
            End Try
            db.CloseDB()
            Return arrFleetGrMapping
        End Function
    End Class
End Namespace
