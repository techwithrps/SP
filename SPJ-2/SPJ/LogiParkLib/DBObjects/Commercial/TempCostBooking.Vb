Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TempCostBooking
    ''' @author	: Amit K. Singh- 17/9/2019
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TempCostBooking

        Private lngCostId As Long ' Define Private Variable CostId With DataType As Long 
        Private strLinerInvNo As String ' Define Private Variable LinerInvNo With DataType As String 
        Private strLinerInvDate As String ' Define Private Variable LinerInvDate With DataType As String 
        Private strLinerInvDueDate As String ' Define Private Variable LinerInvDueDate With DataType As String 
        Private strBlNo As String ' Define Private Variable BlNo With DataType As String 
        Private lngBillingParty As Long ' Define Private Variable BillingParty With DataType As Long 
        Private lngCompanyId As Long ' Define Private Variable CompanyId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strPurchaseType As String ' Define Private Variable PurchaseType With DataType As String 
        Private strTallyStatus As String ' Define Private Variable TallyStatus With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private DblExRate As Double
        Private DblTdsPer As Double


        ''' <summary>
        ''' Get or Set the Value of CostId
        ''' </summary>
        ''' <value>lngCostId</value>
        ''' <returns> Return lngCostId</returns>
        ''' <remarks> Get or Set the Value of CostId  </remarks>
        '''
        Public Property CostId() As Long
            Get
                Return lngCostId
            End Get
            Set(ByVal value As Long)
                lngCostId = value
            End Set
        End Property
        Public Property ExRate() As Double
            Get
                Return DblExRate
            End Get
            Set(ByVal value As Double)
                DblExRate = value
            End Set
        End Property
        Public Property TdsPer() As Double
            Get
                Return DblTdsPer
            End Get
            Set(ByVal value As Double)
                DblTdsPer = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of LinerInvNo
        ''' </summary>
        ''' <value>strLinerInvNo</value>
        ''' <returns> Return strLinerInvNo</returns>
        ''' <remarks> Get or Set the Value of LinerInvNo  </remarks>
        '''
        Public Property LinerInvNo() As String
            Get
                Return strLinerInvNo
            End Get
            Set(ByVal value As String)
                strLinerInvNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LinerInvDate
        ''' </summary>
        ''' <value>strLinerInvDate</value>
        ''' <returns> Return strLinerInvDate</returns>
        ''' <remarks> Get or Set the Value of LinerInvDate  </remarks>
        '''
        Public Property LinerInvDate() As String
            Get
                Return strLinerInvDate
            End Get
            Set(ByVal value As String)
                strLinerInvDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of LinerInvDueDate
        ''' </summary>
        ''' <value>strLinerInvDueDate</value>
        ''' <returns> Return strLinerInvDueDate</returns>
        ''' <remarks> Get or Set the Value of LinerInvDueDate  </remarks>
        '''
        Public Property LinerInvDueDate() As String
            Get
                Return strLinerInvDueDate
            End Get
            Set(ByVal value As String)
                strLinerInvDueDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BlNo
        ''' </summary>
        ''' <value>strBlNo</value>
        ''' <returns> Return strBlNo</returns>
        ''' <remarks> Get or Set the Value of BlNo  </remarks>
        '''
        Public Property BlNo() As String
            Get
                Return strBlNo
            End Get
            Set(ByVal value As String)
                strBlNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BillingParty
        ''' </summary>
        ''' <value>lngBillingParty</value>
        ''' <returns> Return lngBillingParty</returns>
        ''' <remarks> Get or Set the Value of BillingParty  </remarks>
        '''
        Public Property BillingParty() As Long
            Get
                Return lngBillingParty
            End Get
            Set(ByVal value As Long)
                lngBillingParty = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CompanyId
        ''' </summary>
        ''' <value>lngCompanyId</value>
        ''' <returns> Return lngCompanyId</returns>
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
        ''' Get or Set the Value of PurchaseType
        ''' </summary>
        ''' <value>strPurchaseType</value>
        ''' <returns> Return strPurchaseType</returns>
        ''' <remarks> Get or Set the Value of PurchaseType  </remarks>
        '''
        Public Property PurchaseType() As String
            Get
                Return strPurchaseType
            End Get
            Set(ByVal value As String)
                strPurchaseType = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of TallyStatus
        ''' </summary>
        ''' <value>strTallyStatus</value>
        ''' <returns> Return strTallyStatus</returns>
        ''' <remarks> Get or Set the Value of TallyStatus  </remarks>
        '''
        Public Property TallyStatus() As String
            Get
                Return strTallyStatus
            End Get
            Set(ByVal value As String)
                strTallyStatus = value
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
            lngCostId = 0
            strLinerInvNo = ""
            strLinerInvDate = ""
            strLinerInvDueDate = ""
            strBlNo = ""
            lngBillingParty = 0
            lngCompanyId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strPurchaseType = ""
            strTallyStatus = ""
            DblExRate = 0.0
            DblTdsPer = 0.0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTempCostBooking"></param>
        ''' <returns>Return pTempCostBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBooking.CostId)
                db.AddParameter("p_LINER_INV_NO", pTempCostBooking.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pTempCostBooking.LinerInvDate)
                db.AddParameter("p_LINER_INV_DUE_DATE", pTempCostBooking.LinerInvDueDate)
                db.AddParameter("p_BL_NO", pTempCostBooking.BlNo)
                db.AddParameter("p_BILLING_PARTY", pTempCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pTempCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pTempCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pTempCostBooking.PurchaseType)
                db.AddParameter("p_TALLY_STATUS", pTempCostBooking.TallyStatus)
                db.AddParameter("p_ErrorMsg", pTempCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pTempCostBooking.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempCostBooking"></param>
        ''' <returns>Return pTempCostBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBooking.CostId)
                db.AddParameter("p_LINER_INV_NO", pTempCostBooking.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pTempCostBooking.LinerInvDate)
                db.AddParameter("p_LINER_INV_DUE_DATE", pTempCostBooking.LinerInvDueDate)
                db.AddParameter("p_BL_NO", pTempCostBooking.BlNo)
                db.AddParameter("p_BILLING_PARTY", pTempCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pTempCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pTempCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pTempCostBooking.PurchaseType)
                db.AddParameter("p_TALLY_STATUS", pTempCostBooking.TallyStatus)
                db.AddParameter("p_ErrorMsg", pTempCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TEMP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
            End Try
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTempCostBooking"></param>
        ''' <returns>Return pTempCostBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBooking.CostId)
                db.AddParameter("p_LINER_INV_NO", pTempCostBooking.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pTempCostBooking.LinerInvDate)
                db.AddParameter("p_LINER_INV_DUE_DATE", pTempCostBooking.LinerInvDueDate)
                db.AddParameter("p_BL_NO", pTempCostBooking.BlNo)
                db.AddParameter("p_BILLING_PARTY", pTempCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pTempCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pTempCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pTempCostBooking.PurchaseType)
                db.AddParameter("p_TALLY_STATUS", pTempCostBooking.TallyStatus)
                db.AddParameter("p_ErrorMsg", pTempCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTempCostBooking.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTempCostBooking"></param>
        ''' <returns>Return pTempCostBooking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Try
                db.ClearParameters()
                db.AddParameter("p_COST_ID", pTempCostBooking.CostId)
                db.AddParameter("p_LINER_INV_NO", pTempCostBooking.LinerInvNo)
                db.AddParameter("p_LINER_INV_DATE", pTempCostBooking.LinerInvDate)
                db.AddParameter("p_LINER_INV_DUE_DATE", pTempCostBooking.LinerInvDueDate)
                db.AddParameter("p_BL_NO", pTempCostBooking.BlNo)
                db.AddParameter("p_BILLING_PARTY", pTempCostBooking.BillingParty)
                db.AddParameter("p_COMPANY_ID", pTempCostBooking.CompanyId)
                db.AddParameter("p_CREATED_BY", pTempCostBooking.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTempCostBooking.CreatedOn)
                db.AddParameter("p_PURCHASE_TYPE", pTempCostBooking.PurchaseType)
                db.AddParameter("p_TALLY_STATUS", pTempCostBooking.TallyStatus)
                db.AddParameter("p_ErrorMsg", pTempCostBooking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TEMP_COST_BOOKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTempCostBooking.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
            End Try
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                pTempCostBooking.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                pTempCostBooking.LinerInvNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                pTempCostBooking.LinerInvDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DUE_DATE").ToString <> "" Then
                                pTempCostBooking.LinerInvDueDate = dbr("LINER_INV_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                pTempCostBooking.BlNo = dbr("BL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_PARTY").ToString <> "" Then
                                pTempCostBooking.BillingParty = dbr("BILLING_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                pTempCostBooking.CompanyId = dbr("COMPANY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pTempCostBooking.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pTempCostBooking.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PURCHASE_TYPE").ToString <> "" Then
                                pTempCostBooking.PurchaseType = dbr("PURCHASE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_STATUS").ToString <> "" Then
                                pTempCostBooking.TallyStatus = dbr("TALLY_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EX_RATE").ToString <> "" Then
                                pTempCostBooking.ExRate = dbr("EX_RATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TDS_PER").ToString <> "" Then
                                pTempCostBooking.TdsPer = dbr("TDS_PER")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
            End Try
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTempCostBooking As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TempCostBooking
                        Try
                            If dbr("COST_ID").ToString <> "" Then
                                temp.CostId = dbr("COST_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_NO").ToString <> "" Then
                                temp.LinerInvNo = dbr("LINER_INV_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DATE").ToString <> "" Then
                                temp.LinerInvDate = dbr("LINER_INV_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINER_INV_DUE_DATE").ToString <> "" Then
                                temp.LinerInvDueDate = dbr("LINER_INV_DUE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BL_NO").ToString <> "" Then
                                temp.BlNo = dbr("BL_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BILLING_PARTY").ToString <> "" Then
                                temp.BillingParty = dbr("BILLING_PARTY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COMPANY_ID").ToString <> "" Then
                                temp.CompanyId = dbr("COMPANY_ID")
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
                            If dbr("PURCHASE_TYPE").ToString <> "" Then
                                temp.PurchaseType = dbr("PURCHASE_TYPE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TALLY_STATUS").ToString <> "" Then
                                temp.TallyStatus = dbr("TALLY_STATUS")
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
                            If dbr("TDS_PER").ToString <> "" Then
                                temp.TdsPer = dbr("TDS_PER")
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
        Public Shared Function ReturnTempCostBooking(ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_COST_BOOKING", "' '")
                pTempCostBooking = ReturnObjectValues(dbr, pTempCostBooking)
                dbr.Close()
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTempCostBooking
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTempCostBookingList(ByVal pTempCostBooking As TempCostBooking) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTempCostBooking As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_COST_BOOKING", "' '")
                arrTempCostBooking = ReturnObjectValuesList(dbr, arrTempCostBooking)
                dbr.Close()
            Catch ex As Exception
                arrTempCostBooking = Nothing
            End Try
            db.CloseDB()
            Return arrTempCostBooking
        End Function
        Public Shared Function ReturnTempImpInvoiceByInvoiceNo(ByVal pTempCostBooking As TempCostBooking) As TempCostBooking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TEMP_COST_INVOICE_BY_ID", pTempCostBooking.CostId)
                pTempCostBooking = ReturnObjectValues(dbr, pTempCostBooking)
                dbr.Close()
            Catch ex As Exception
                pTempCostBooking.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTempCostBooking
        End Function
        
    End Class
End Namespace
