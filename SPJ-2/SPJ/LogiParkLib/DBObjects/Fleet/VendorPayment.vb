Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    Public Class VendorPayment
        Private lngPaymentId As Long ' Define Private Variable MappingId With DataType As Long 
        Private strVendorType As String
        Private lngVendorId As Long ' Define Private Variable CustomerId With DataType As Long 
        Private lngEquipmentId As Long ' Define Private Variable BillingParty With DataType As Long 
        Private lngDays As Long ' Define Private Variable LineId With DataType As Long 
        Private lngAmount As Long ' Define Private Variable ServiceGroupId With DataType As Long 
        Private strToDate As String ' Define Private Variable ServiceTypeCode With DataType As String 
        Private strRemark As String
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private arrVendorPayment As ArrayList

        Public Property VendorPaymentList() As ArrayList
            Get
                Return arrVendorPayment
            End Get
            Set(ByVal value As ArrayList)
                arrVendorPayment = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of MappingId
        ''' </summary>
        ''' <value>lngMappingId</value>
        ''' <returns> Return lngMappingId</returns>
        ''' <remarks> Get or Set the Value of MappingId  </remarks>
        '''
        Public Property PaymentID() As Long
            Get
                Return lngPaymentId
            End Get
            Set(ByVal value As Long)
                lngPaymentId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CustomerId
        ''' </summary>
        ''' <value>lngCustomerId</value>
        ''' <returns> Return lngCustomerId</returns>
        ''' <remarks> Get or Set the Value of CustomerId  </remarks>
        '''
        Public Property VendorType() As String
            Get
                Return strVendorType
            End Get
            Set(ByVal value As String)
                strVendorType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BillingParty
        ''' </summary>
        ''' <value>lngBillingParty</value>
        ''' <returns> Return lngBillingParty</returns>
        ''' <remarks> Get or Set the Value of BillingParty  </remarks>
        '''
        Public Property VendorId() As Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LineId
        ''' </summary>
        ''' <value>lngLineId</value>
        ''' <returns> Return lngLineId</returns>
        ''' <remarks> Get or Set the Value of LineId  </remarks>
        '''
        Public Property EquipmentId() As Long
            Get
                Return lngEquipmentId
            End Get
            Set(ByVal value As Long)
                lngEquipmentId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceGroupId
        ''' </summary>
        ''' <value>lngServiceGroupId</value>
        ''' <returns> Return lngServiceGroupId</returns>
        ''' <remarks> Get or Set the Value of ServiceGroupId  </remarks>
        '''
        Public Property Days() As Long
            Get
                Return lngDays
            End Get
            Set(ByVal value As Long)
                lngDays = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of ServiceTypeCode
        ''' </summary>
        ''' <value>strServiceTypeCode</value>
        ''' <returns> Return strServiceTypeCode</returns>
        ''' <remarks> Get or Set the Value of ServiceTypeCode  </remarks>
        '''
        Public Property Amount() As Long
            Get
                Return lngAmount
            End Get
            Set(ByVal value As Long)
                lngAmount = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TallyCustomerId
        ''' </summary>
        ''' <value>lngTallyCustomerId</value>
        ''' <returns> Return lngTallyCustomerId</returns>
        ''' <remarks> Get or Set the Value of TallyCustomerId  </remarks>
        '''
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Return strRemark
            End Get
            Set(ByVal value As String)
                strRemark = value
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
            lngPaymentId = 0
            strVendorType = ""
            lngVendorId = 0
            lngEquipmentId = 0
            lngDays = 0
            lngAmount = ""
            strToDate = ""
            strRemark = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="PVendorPayment"></param>
        ''' <returns>Return pVendorPayment Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pVendorPayment As VendorPayment) As VendorPayment
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_PAYMENT_ID", pVendorPayment.PaymentID)
                db.AddParameter("p_VENDOR_TYPE", pVendorPayment.VendorType)
                db.AddParameter("p_VENDOR_ID", pVendorPayment.VendorId)
                db.AddParameter("p_EQUIPMENT_ID", pVendorPayment.EquipmentId)
                db.AddParameter("p_DAYS", pVendorPayment.Days)
                db.AddParameter("p_AMOUNT", pVendorPayment.Amount)
                db.AddParameter("p_TO_DATE", pVendorPayment.ToDate)
                db.AddParameter("p_REMARKS", pVendorPayment.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorPayment.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorPayment.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorPayment.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_PAYMENT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorPayment.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                ''pVendorPayment.MappingId  = db.Parameters.Item("p_MAPPING_ID").value

                If pVendorPayment.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorPayment"></param>
        ''' <returns>Return pVendorPayment Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pVendorPayment As VendorPayment) As VendorPayment
            Try
                db.ClearParameters()
                db.AddParameter("p_PAYMENT_ID", pVendorPayment.PaymentID)
                db.AddParameter("p_VENDOR_TYPE", pVendorPayment.VendorType)
                db.AddParameter("p_VENDOR_ID", pVendorPayment.VendorId)
                db.AddParameter("p_EQUIPMENT_ID", pVendorPayment.EquipmentId)
                db.AddParameter("p_DAYS", pVendorPayment.Days)
                db.AddParameter("p_AMOUNT", pVendorPayment.Amount)
                db.AddParameter("p_TO_DATE", pVendorPayment.ToDate)
                db.AddParameter("p_REMARKS", pVendorPayment.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorPayment.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorPayment.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorPayment.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_VENDOR_PAYMENT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorPayment.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                ''pVendorPayment.MappingId  = db.Parameters.Item("p_MAPPING_ID").value

            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
            End Try
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pVendorPayment"></param>
        ''' <returns>Return pVendorPayment Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pVendorPayment As VendorPayment) As VendorPayment
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_PAYMENT_ID", pVendorPayment.PaymentID)
                db.AddParameter("p_VENDOR_TYPE", pVendorPayment.VendorType)
                db.AddParameter("p_VENDOR_ID", pVendorPayment.VendorId)
                db.AddParameter("p_EQUIPMENT_ID", pVendorPayment.EquipmentId)
                db.AddParameter("p_DAYS", pVendorPayment.Days)
                db.AddParameter("p_AMOUNT", pVendorPayment.Amount)
                db.AddParameter("p_TO_DATE", pVendorPayment.ToDate)
                db.AddParameter("p_REMARKS", pVendorPayment.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorPayment.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorPayment.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorPayment.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_PAYMENT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorPayment.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pVendorPayment.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pVendorPayment"></param>
        ''' <returns>Return pVendorPayment Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pVendorPayment As VendorPayment) As VendorPayment
            Try
                db.ClearParameters()
                db.AddParameter("p_PAYMENT_ID", pVendorPayment.PaymentID)
                db.AddParameter("p_VENDOR_TYPE", pVendorPayment.VendorType)
                db.AddParameter("p_VENDOR_ID", pVendorPayment.VendorId)
                db.AddParameter("p_EQUIPMENT_ID", pVendorPayment.EquipmentId)
                db.AddParameter("p_DAYS", pVendorPayment.Days)
                db.AddParameter("p_AMOUNT", pVendorPayment.Amount)
                db.AddParameter("p_TO_DATE", pVendorPayment.ToDate)
                db.AddParameter("p_REMARKS", pVendorPayment.Remarks)
                db.AddParameter("p_CREATED_BY", pVendorPayment.CreatedBy)
                db.AddParameter("p_CREATED_ON", pVendorPayment.CreatedOn)
                db.AddParameter("p_ErrorMsg", pVendorPayment.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_VENDOR_PAYMENT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pVendorPayment.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
            End Try
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pVendorPayment As VendorPayment) As VendorPayment
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("PAYMENT_ID").ToString <> "" Then
                                pVendorPayment.PaymentID = dbr("PAYMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE").ToString <> "" Then
                                pVendorPayment.VendorType = dbr("VENDOR_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                pVendorPayment.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                pVendorPayment.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAYS").ToString <> "" Then
                                pVendorPayment.Days = dbr("DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                pVendorPayment.Amount = dbr("AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANGE").ToString <> "" Then
                                pVendorPayment.ToDate = dbr("TO_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                pVendorPayment.Remarks = dbr("REMARKS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pVendorPayment.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pVendorPayment.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
            End Try
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrVendorPayment As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New VendorPayment
                        Try
                            If dbr("PAYMENT_ID").ToString <> "" Then
                                temp.PaymentID = dbr("PAYMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_TYPE").ToString <> "" Then
                                temp.VendorType = dbr("VENDOR_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VENDOR_ID").ToString <> "" Then
                                temp.VendorId = dbr("VENDOR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EQUIPMENT_ID").ToString <> "" Then
                                temp.EquipmentId = dbr("EQUIPMENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DAYS").ToString <> "" Then
                                temp.Days = dbr("DAYS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("AMOUNT").ToString <> "" Then
                                temp.Amount = dbr("AMOUNT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_RANGE").ToString <> "" Then
                                temp.ToDate = dbr("TO_RANGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("REMARKS").ToString <> "" Then
                                temp.Remarks = dbr("REMARKS")
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
        Public Shared Function ReturnVendorPayment(ByVal pVendorPayment As VendorPayment) As VendorPayment
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAPPING", "' '")
                pVendorPayment = ReturnObjectValues(dbr, pVendorPayment)
                dbr.Close()
            Catch ex As Exception
                pVendorPayment.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorPayment
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnVendorPaymentList(ByVal pVendorPayment As VendorPayment) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorPayment As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAPPING", "' '")
                arrVendorPayment = ReturnObjectValuesList(dbr, arrVendorPayment)
                dbr.Close()
            Catch ex As Exception
                arrVendorPayment = Nothing
            End Try
            db.CloseDB()
            Return arrVendorPayment
        End Function
        Public Shared Function InsertUpdateTransaction(ByVal pVendorPayment As VendorPayment) As VendorPayment
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each det As VendorPayment In pVendorPayment.VendorPaymentList
                    If pVendorPayment.PaymentID > 0 Then
                        VendorPayment.UpdateTrn(db, det)
                    Else
                        VendorPayment.InsertTrn(db, det)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pVendorPayment.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pVendorPayment
        End Function
    End Class
End Namespace
