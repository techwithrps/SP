Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RateTpt Class
    ''' @author	: Amit K. Singh- 17/02/2012
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class RateTptVendor

        Private lngRateTptId As Long ' Define Private Variable RateTptId DataType As Long 
        Private strRateCode As String ' Define Private Variable RateCode DataType As String 
        Private lngBillingCondition As Long ' Define Private Variable BillingCondition DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId DataType As Long 
        Private lngVendorId As Long ' Define Private Variable VendorId DataType As Long  
        Private strCreatedBy As String ' Define Private Variable CreatedBy DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 

        ''' <summary>
        ''' RateTptId
        ''' </summary>
        ''' <value>lngRateTptId</value>
        ''' <returns> Return lngRateTptId</returns>
        ''' <remarks></remarks>
        Public Property RateTptId() As Long
            Get
                Return lngRateTptId
            End Get
            Set(ByVal value As Long)
                lngRateTptId = value
            End Set
        End Property


        ''' <summary>
        ''' RateCode
        ''' </summary>
        ''' <value>strRateCode</value>
        ''' <returns> Return strRateCode</returns>
        ''' <remarks></remarks>
        Public Property RateCode() As String
            Get
                Return strRateCode
            End Get
            Set(ByVal value As String)
                strRateCode = value
            End Set
        End Property


        ''' <summary>
        ''' BillingCondition
        ''' </summary>
        ''' <value>lngBillingCondition</value>
        ''' <returns> Return lngBillingCondition</returns>
        ''' <remarks></remarks>
        Public Property BillingCondition() As Long
            Get
                Return lngBillingCondition
            End Get
            Set(ByVal value As Long)
                lngBillingCondition = value
            End Set
        End Property


        ''' <summary>
        ''' TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks></remarks>
        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' ServiceId
        ''' </summary>
        ''' <value>lngServiceId</value>
        ''' <returns> Return lngServiceId</returns>
        ''' <remarks></remarks>
        Public Property ServiceId() As Long
            Get
                Return lngServiceId
            End Get
            Set(ByVal value As Long)
                lngServiceId = value
            End Set
        End Property


        ''' <summary>
        ''' VendorId
        ''' </summary>
        ''' <value>lngVendorId</value>
        ''' <returns> Return lngVendorId</returns>
        ''' <remarks></remarks>
        Public Property VendorId() As Long
            Get
                Return lngVendorId
            End Get
            Set(ByVal value As Long)
                lngVendorId = value
            End Set
        End Property


        ''' <summary>
        ''' CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks></remarks>
        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property


        ''' <summary>
        ''' CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks></remarks>
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property


        ''' <summary>
        ''' Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks></remarks>
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
        ''' <remarks></remarks>
        Public Sub New()
            lngRateTptId = 0
            strRateCode = ""
            lngBillingCondition = 0
            lngTerminalId = 0
            lngServiceId = 0
            lngVendorId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRateTptVendor"></param>
        ''' <returns>Return pRateTptVendor Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendor.RateTptId, ParameterDirection.Output)
                db.AddParameter("p_RATE_CODE", pRateTptVendor.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptVendor.BillingCondition)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendor.TerminalId)
                db.AddParameter("p_SERVICE_ID", pRateTptVendor.ServiceId)
                db.AddParameter("p_VENDOR_ID", pRateTptVendor.VendorId)
                db.AddParameter("p_CREATED_BY", pRateTptVendor.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptVendor.CreatedOn)
                db.AddParameter("p_ErrorMsg", pRateTptVendor.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_VENDOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendor.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptVendor.RateTptId = db.Parameters.Item("p_RATE_TPT_ID").value

                If pRateTptVendor.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptVendor"></param>
        ''' <returns>Return pRateTptVendor Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Try
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendor.RateTptId, ParameterDirection.Output)
                db.AddParameter("p_RATE_CODE", pRateTptVendor.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptVendor.BillingCondition)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendor.TerminalId)
                db.AddParameter("p_SERVICE_ID", pRateTptVendor.ServiceId)
                db.AddParameter("p_VENDOR_ID", pRateTptVendor.VendorId)
                db.AddParameter("p_CREATED_BY", pRateTptVendor.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptVendor.CreatedOn)
                db.AddParameter("p_ErrorMsg", pRateTptVendor.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_VENDOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendor.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptVendor.RateTptId = db.Parameters.Item("p_RATE_TPT_ID").value

            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
            End Try
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRateTptVendor"></param>
        ''' <returns>Return pRateTptVendor Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendor.RateTptId)
                db.AddParameter("p_RATE_CODE", pRateTptVendor.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptVendor.BillingCondition)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendor.TerminalId)
                db.AddParameter("p_SERVICE_ID", pRateTptVendor.ServiceId)
                db.AddParameter("p_VENDOR_ID", pRateTptVendor.VendorId)
                db.AddParameter("p_CREATED_BY", pRateTptVendor.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptVendor.CreatedOn)
                db.AddParameter("p_ErrorMsg", pRateTptVendor.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_VENDOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendor.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRateTptVendor.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptVendor"></param>
        ''' <returns>Return pRateTptVendor Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Try
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendor.RateTptId)
                db.AddParameter("p_RATE_CODE", pRateTptVendor.RateCode)
                db.AddParameter("p_BILLING_CONDITION", pRateTptVendor.BillingCondition)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendor.TerminalId)
                db.AddParameter("p_SERVICE_ID", pRateTptVendor.ServiceId)
                db.AddParameter("p_VENDOR_ID", pRateTptVendor.VendorId)
                db.AddParameter("p_CREATED_BY", pRateTptVendor.CreatedBy)
                db.AddParameter("p_CREATED_ON", pRateTptVendor.CreatedOn)
                db.AddParameter("p_ErrorMsg", pRateTptVendor.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_VENDOR", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendor.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
            End Try
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("RATE_TPT_ID").ToString <> "" Then
                            pRateTptVendor.RateTptId = dbr("RATE_TPT_ID")
                        End If
                        If dbr("RATE_CODE").ToString <> "" Then
                            pRateTptVendor.RateCode = dbr("RATE_CODE")
                        End If
                        If dbr("BILLING_CONDITION").ToString <> "" Then
                            pRateTptVendor.BillingCondition = dbr("BILLING_CONDITION")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pRateTptVendor.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("SERVICE_ID").ToString <> "" Then
                            pRateTptVendor.ServiceId = dbr("SERVICE_ID")
                        End If
                        If dbr("VENDOR_ID").ToString <> "" Then
                            pRateTptVendor.VendorId = dbr("VENDOR_ID")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            pRateTptVendor.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            pRateTptVendor.CreatedOn = dbr("CREATED_ON")
                        End If
                    End While
                End If
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
            End Try
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRateTptVendor As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RateTptVendor
                        If dbr("RATE_TPT_ID").ToString <> "" Then
                            temp.RateTptId = dbr("RATE_TPT_ID")
                        End If
                        If dbr("RATE_CODE").ToString <> "" Then
                            temp.RateCode = dbr("RATE_CODE")
                        End If
                        If dbr("BILLING_CONDITION").ToString <> "" Then
                            temp.BillingCondition = dbr("BILLING_CONDITION")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("SERVICE_ID").ToString <> "" Then
                            temp.ServiceId = dbr("SERVICE_ID")
                        End If
                        If dbr("VENDOR_ID").ToString <> "" Then
                            temp.VendorId = dbr("VENDOR_ID")
                        End If
                        If dbr("CREATED_BY").ToString <> "" Then
                            temp.CreatedBy = dbr("CREATED_BY")
                        End If
                        If dbr("CREATED_ON").ToString <> "" Then
                            temp.CreatedOn = dbr("CREATED_ON")
                        End If
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
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptVendorById(ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_BY_ID", pRateTptVendor.TerminalId & "," & pRateTptVendor.RateTptId)
                pRateTptVendor = ReturnObjectValues(dbr, pRateTptVendor)
                dbr.Close()
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptVendor
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptVendorList(ByVal pRateTptVendor As RateTptVendor) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptVendor As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_BY_ALL", pRateTptVendor.TerminalId)
                arrRateTptVendor = ReturnObjectValuesList(dbr, arrRateTptVendor)
                dbr.Close()
            Catch ex As Exception
                arrRateTptVendor = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptVendor
        End Function

        Public Shared Function ReturnRateTptVendorListSearch(ByVal pRateTptVendor As RateTptVendor) As ArrayList
            'Dim db As New DBConnect
            'Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptVendor As New ArrayList
            'Try
            '    db.ClearParameters()
            '    dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_MASTER_BY_ALL_SEARCH", "'" & pRateTptVendor.VendorId & "'," & _
            '                                   pRateTptVendor.RateCode & "'," & pRateTptVendor.BillingCondition)
            '    arrRateTptVendor = ReturnObjectValuesList(dbr, arrRateTptVendor)
            '    dbr.Close()
            'Catch ex As Exception
            '    arrRateTptVendor = Nothing
            'End Try
            'db.CloseDB()
            Return arrRateTptVendor
        End Function

        Public Shared Function ReturnRateTptByServiceIdWithCurrentDate(ByVal pRateTptVendor As RateTptVendor) As RateTptVendor
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_BY_DATE_ID", "'" & pRateTptVendor.BillingCondition & "," & pRateTptVendor.ServiceId & "," & pRateTptVendor.TerminalId & "'")
                pRateTptVendor = ReturnObjectValues(dbr, pRateTptVendor)
                dbr.Close()
            Catch ex As Exception
                pRateTptVendor.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptVendor
        End Function

    End Class
End Namespace
