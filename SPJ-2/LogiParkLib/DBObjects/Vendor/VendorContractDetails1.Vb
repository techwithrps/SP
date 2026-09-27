Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RateDetails Class
    ''' @author	: Amit K. Singh- 17/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class VendorContractDetails

        Private lngServiceChargeRefId As Long ' Define Private Variable RateRefId DataType As Long 
        Private lngServiceChargeId As Long ' Define Private Variable RateId DataType As Long 
        Private lngUomId As Long ' Define Private Variable UomId DataType As Long 
        Private lngServiceId As Long ' Define Private Variable ServiceId DataType As Long 
        Private lngDocId As Long ' Define Private Variable DocId DataType As Long  
        Private strContSize As String ' Define Private Variable ContSize DataType As String 
        Private strContStatus As String ' Define Private Variable ContStatus DataType As String 
        Private strCargoType As String ' Define Private Variable CargoType DataType As String 
        Private strImoCode As String ' Define Private Variable ImoCode DataType As String 
        Private lngFromRange As Long ' Define Private Variable FromRange DataType As Long 
        Private lngToRange As Long ' Define Private Variable ToRange DataType As Long 
        Private lngRate As Decimal ' Define Private Variable Rate DataType As Long 
        Private lngVendorId As Long ' Define Private Variable VendorId DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId DataType As Long 
        Private strApprovalFlag As String ' Define Private Variable ApprovalFlag DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' ServiceChargeRefId
        ''' </summary>
        ''' <value>lngServiceChargeRefId</value>
        ''' <returns> Return lngServiceChargeRefId</returns>
        ''' <remarks></remarks>
        Public Property ServiceChargeRefId() As Long
            Get
                Return lngServiceChargeRefId
            End Get
            Set(ByVal value As Long)
                lngServiceChargeRefId = value
            End Set
        End Property


        ''' <summary>
        ''' ServiceChargeId
        ''' </summary>
        ''' <value>lngServiceChargeId</value>
        ''' <returns> Return lngServiceChargeId</returns>
        ''' <remarks></remarks>
        Public Property ServiceChargeId() As Long
            Get
                Return lngServiceChargeId
            End Get
            Set(ByVal value As Long)
                lngServiceChargeId = value
            End Set
        End Property


        ''' <summary>
        ''' UomId
        ''' </summary>
        ''' <value>lngUomId</value>
        ''' <returns> Return lngUomId</returns>
        ''' <remarks></remarks>
        Public Property UomId() As Long
            Get
                Return lngUomId
            End Get
            Set(ByVal value As Long)
                lngUomId = value
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
        ''' DocId
        ''' </summary>
        ''' <value>lngDocId</value>
        ''' <returns> Return lngDocId</returns>
        ''' <remarks></remarks>
        Public Property DocId() As Long
            Get
                Return lngDocId
            End Get
            Set(ByVal value As Long)
                lngDocId = value
            End Set
        End Property


        ''' <summary>
        ''' ContSize
        ''' </summary>
        ''' <value>strContSize</value>
        ''' <returns> Return strContSize</returns>
        ''' <remarks></remarks>
        Public Property ContSize() As String
            Get
                Return strContSize
            End Get
            Set(ByVal value As String)
                strContSize = value
            End Set
        End Property


        ''' <summary>
        ''' ContStatus
        ''' </summary>
        ''' <value>strContStatus</value>
        ''' <returns> Return strContStatus</returns>
        ''' <remarks></remarks>
        Public Property ContStatus() As String
            Get
                Return strContStatus
            End Get
            Set(ByVal value As String)
                strContStatus = value
            End Set
        End Property


        ''' <summary>
        ''' CargoType
        ''' </summary>
        ''' <value>strCargoType</value>
        ''' <returns> Return strCargoType</returns>
        ''' <remarks></remarks>
        Public Property CargoType() As String
            Get
                Return strCargoType
            End Get
            Set(ByVal value As String)
                strCargoType = value
            End Set
        End Property


        ''' <summary>
        ''' ImoCode
        ''' </summary>
        ''' <value>strImoCode</value>
        ''' <returns> Return strImoCode</returns>
        ''' <remarks></remarks>
        Public Property ImoCode() As String
            Get
                Return strImoCode
            End Get
            Set(ByVal value As String)
                strImoCode = value
            End Set
        End Property


        ''' <summary>
        ''' FromRange
        ''' </summary>
        ''' <value>lngFromRange</value>
        ''' <returns> Return lngFromRange</returns>
        ''' <remarks></remarks>
        Public Property FromRange() As Long
            Get
                Return lngFromRange
            End Get
            Set(ByVal value As Long)
                lngFromRange = value
            End Set
        End Property


        ''' <summary>
        ''' ToRange
        ''' </summary>
        ''' <value>lngToRange</value>
        ''' <returns> Return lngToRange</returns>
        ''' <remarks></remarks>
        Public Property ToRange() As Long
            Get
                Return lngToRange
            End Get
            Set(ByVal value As Long)
                lngToRange = value
            End Set
        End Property


        ''' <summary>
        ''' Rate
        ''' </summary>
        ''' <value>lngRate</value>
        ''' <returns> Return lngRate</returns>
        ''' <remarks></remarks>
        Public Property Rate() As Decimal
            Get
                Return lngRate
            End Get
            Set(ByVal value As Decimal)
                lngRate = value
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

        Public Property TerminalId() As Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' ApprovalFlag
        ''' </summary>
        ''' <value>strApprovalFlag</value>
        ''' <returns> Return strApprovalFlag</returns>
        ''' <remarks></remarks>
        Public Property ApprovalFlag() As String
            Get
                Return strApprovalFlag
            End Get
            Set(ByVal value As String)
                strApprovalFlag = value
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
            lngServiceChargeRefId = 0
            lngServiceChargeId = 0
            lngUomId = 0
            lngServiceId = 0
            lngDocId = 0
            strContSize = ""
            strContStatus = ""
            strCargoType = ""
            strImoCode = ""
            lngFromRange = 0
            lngToRange = 0
            lngRate = 0
            lngVendorId = 0
            strApprovalFlag = ""
            strErrormsg = ""
            lngTerminalId = 0
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTerminalServiceChargeDetails"></param>
        ''' <returns>Return pTerminalServiceChargeDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_REF_ID", pTerminalServiceChargeDetails.ServiceChargeRefId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                db.AddParameter("p_UOM_ID", pTerminalServiceChargeDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pTerminalServiceChargeDetails.ServiceId)
                db.AddParameter("p_DOC_ID", pTerminalServiceChargeDetails.DocId)
                db.AddParameter("p_CONT_SIZE", pTerminalServiceChargeDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pTerminalServiceChargeDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pTerminalServiceChargeDetails.CargoType)
                db.AddParameter("p_IMO_CODE", pTerminalServiceChargeDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pTerminalServiceChargeDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pTerminalServiceChargeDetails.ToRange)
                db.AddParameter("p_RATE", pTerminalServiceChargeDetails.Rate)
                db.AddParameter("p_VENDOR_ID", pTerminalServiceChargeDetails.lngVendorId)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceChargeDetails.lngTerminalId)
                db.AddParameter("p_APPROVAL_FLAG", pTerminalServiceChargeDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pTerminalServiceChargeDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_CHARGE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceChargeDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalServiceChargeDetails.lngServiceChargeRefId = db.Parameters.Item("p_SERVICE_CHARGE_REF_ID").value

                If pTerminalServiceChargeDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalServiceChargeDetails"></param>
        ''' <returns>Return pTerminalServiceChargeDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_REF_ID", pTerminalServiceChargeDetails.ServiceChargeRefId, ParameterDirection.Output)
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                db.AddParameter("p_UOM_ID", pTerminalServiceChargeDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pTerminalServiceChargeDetails.ServiceId)
                db.AddParameter("p_DOC_ID", pTerminalServiceChargeDetails.DocId)
                db.AddParameter("p_CONT_SIZE", pTerminalServiceChargeDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pTerminalServiceChargeDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pTerminalServiceChargeDetails.CargoType)
                db.AddParameter("p_IMO_CODE", pTerminalServiceChargeDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pTerminalServiceChargeDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pTerminalServiceChargeDetails.ToRange)
                db.AddParameter("p_RATE", pTerminalServiceChargeDetails.Rate)
                db.AddParameter("p_VENDOR_ID", pTerminalServiceChargeDetails.lngVendorId)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceChargeDetails.lngTerminalId)
                db.AddParameter("p_APPROVAL_FLAG", pTerminalServiceChargeDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pTerminalServiceChargeDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SERVICE_CHARGE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceChargeDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTerminalServiceChargeDetails.ServiceChargeRefId = db.Parameters.Item("p_SERVICE_CHARGE_REF_ID").value

            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
            End Try
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTerminalServiceChargeDetails"></param>
        ''' <returns>Return pTerminalServiceChargeDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_REF_ID", pTerminalServiceChargeDetails.ServiceChargeRefId)
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                db.AddParameter("p_UOM_ID", pTerminalServiceChargeDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pTerminalServiceChargeDetails.ServiceId)
                db.AddParameter("p_DOC_ID", pTerminalServiceChargeDetails.DocId)
                db.AddParameter("p_CONT_SIZE", pTerminalServiceChargeDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pTerminalServiceChargeDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pTerminalServiceChargeDetails.CargoType)
                db.AddParameter("p_IMO_CODE", pTerminalServiceChargeDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pTerminalServiceChargeDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pTerminalServiceChargeDetails.ToRange)
                db.AddParameter("p_RATE", pTerminalServiceChargeDetails.Rate)
                db.AddParameter("p_VENDOR_ID", pTerminalServiceChargeDetails.lngVendorId)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceChargeDetails.lngTerminalId)
                db.AddParameter("p_APPROVAL_FLAG", pTerminalServiceChargeDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pTerminalServiceChargeDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_CHARGE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceChargeDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTerminalServiceChargeDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalServiceChargeDetails"></param>
        ''' <returns>Return pTerminalServiceChargeDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_REF_ID", pTerminalServiceChargeDetails.ServiceChargeRefId)
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                db.AddParameter("p_UOM_ID", pTerminalServiceChargeDetails.UomId)
                db.AddParameter("p_SERVICE_ID", pTerminalServiceChargeDetails.ServiceId)
                db.AddParameter("p_DOC_ID", pTerminalServiceChargeDetails.DocId)
                db.AddParameter("p_CONT_SIZE", pTerminalServiceChargeDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pTerminalServiceChargeDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pTerminalServiceChargeDetails.CargoType)
                db.AddParameter("p_IMO_CODE", pTerminalServiceChargeDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pTerminalServiceChargeDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pTerminalServiceChargeDetails.ToRange)
                db.AddParameter("p_RATE", pTerminalServiceChargeDetails.Rate)
                db.AddParameter("p_VENDOR_ID", pTerminalServiceChargeDetails.lngVendorId)
                db.AddParameter("p_TERMINAL_ID", pTerminalServiceChargeDetails.lngTerminalId)
                db.AddParameter("p_APPROVAL_FLAG", pTerminalServiceChargeDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pTerminalServiceChargeDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_CHARGE_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceChargeDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
            End Try
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("SERVICE_CHARGE_REF_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.ServiceChargeRefId = dbr("SERVICE_CHARGE_REF_ID")
                        End If
                        If dbr("SERVICE_CHARGE_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.ServiceChargeId = dbr("SERVICE_CHARGE_ID")
                        End If
                        If dbr("UOM_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.UomId = dbr("UOM_ID")
                        End If
                        If dbr("SERVICE_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.ServiceId = dbr("SERVICE_ID")
                        End If
                        If dbr("DOC_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.DocId = dbr("DOC_ID")
                        End If
                        If dbr("CONT_SIZE").ToString <> "" Then
                            pTerminalServiceChargeDetails.ContSize = dbr("CONT_SIZE")
                        End If
                        If dbr("CONT_STATUS").ToString <> "" Then
                            pTerminalServiceChargeDetails.ContStatus = dbr("CONT_STATUS")
                        End If
                        If dbr("CONT_TYPE").ToString <> "" Then
                            pTerminalServiceChargeDetails.CargoType = dbr("CONT_TYPE")
                        End If
                        If dbr("IMO_CODE").ToString <> "" Then
                            pTerminalServiceChargeDetails.ImoCode = dbr("IMO_CODE")
                        End If
                        If dbr("FROM_RANGE").ToString <> "" Then
                            pTerminalServiceChargeDetails.FromRange = dbr("FROM_RANGE")
                        End If
                        If dbr("TO_RANGE").ToString <> "" Then
                            pTerminalServiceChargeDetails.ToRange = dbr("TO_RANGE")
                        End If
                        If dbr("RATE").ToString <> "" Then
                            pTerminalServiceChargeDetails.Rate = dbr("RATE")
                        End If
                        If dbr("VENDOR_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.VendorId = dbr("VENDOR_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pTerminalServiceChargeDetails.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("APPROVAL_FLAG").ToString <> "" Then
                            pTerminalServiceChargeDetails.ApprovalFlag = dbr("APPROVAL_FLAG")
                        End If
                    End While
                End If
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
            End Try
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTerminalServiceChargeDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TerminalServiceChargeDetails
                        If dbr("SERVICE_CHARGE_REF_ID").ToString <> "" Then
                            temp.ServiceChargeRefId = dbr("SERVICE_CHARGE_REF_ID")
                        End If
                        If dbr("SERVICE_CHARGE_ID").ToString <> "" Then
                            temp.ServiceChargeId = dbr("SERVICE_CHARGE_ID")
                        End If
                        If dbr("UOM_ID").ToString <> "" Then
                            temp.UomId = dbr("UOM_ID")
                        End If
                        If dbr("SERVICE_ID").ToString <> "" Then
                            temp.ServiceId = dbr("SERVICE_ID")
                        End If
                        If dbr("DOC_ID").ToString <> "" Then
                            temp.DocId = dbr("DOC_ID")
                        End If
                        If dbr("CONT_SIZE").ToString <> "" Then
                            temp.ContSize = dbr("CONT_SIZE")
                        End If
                        If dbr("CONT_STATUS").ToString <> "" Then
                            temp.ContStatus = dbr("CONT_STATUS")
                        End If
                        If dbr("CONT_TYPE").ToString <> "" Then
                            temp.CargoType = dbr("CONT_TYPE")
                        End If
                        If dbr("IMO_CODE").ToString <> "" Then
                            temp.ImoCode = dbr("IMO_CODE")
                        End If
                        If dbr("FROM_RANGE").ToString <> "" Then
                            temp.FromRange = dbr("FROM_RANGE")
                        End If
                        If dbr("TO_RANGE").ToString <> "" Then
                            temp.ToRange = dbr("TO_RANGE")
                        End If
                        If dbr("RATE").ToString <> "" Then
                            temp.Rate = dbr("RATE")
                        End If
                        If dbr("VENDOR_ID").ToString <> "" Then
                            temp.VendorId = dbr("VENDOR_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("APPROVAL_FLAG").ToString <> "" Then
                            temp.ApprovalFlag = dbr("APPROVAL_FLAG")
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
        Public Shared Function ReturnTerminalServiceChargeDetails(ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGE_D_BY_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                pTerminalServiceChargeDetails = ReturnObjectValues(dbr, pTerminalServiceChargeDetails)
                dbr.Close()
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalServiceChargeDetailsListByRateId(ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalServiceChargeDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGE_D_BY_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                arrTerminalServiceChargeDetails = ReturnObjectValuesList(dbr, arrTerminalServiceChargeDetails)
                dbr.Close()
            Catch ex As Exception
                arrTerminalServiceChargeDetails = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTerminalServiceChargeDetailsList(ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTerminalServiceChargeDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SERVICE_CHARGE_D_LIST", pTerminalServiceChargeDetails.ServiceChargeId)
                arrTerminalServiceChargeDetails = ReturnObjectValuesList(dbr, arrTerminalServiceChargeDetails)
                dbr.Close()
            Catch ex As Exception
                arrTerminalServiceChargeDetails = Nothing
            End Try
            db.CloseDB()
            Return arrTerminalServiceChargeDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTerminalServiceChargeDetails"></param>
        ''' <returns>Return pTerminalServiceChargeDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function ApprovalTrn(ByVal db As DBConnect, ByVal pTerminalServiceChargeDetails As TerminalServiceChargeDetails) As TerminalServiceChargeDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_SERVICE_CHARGE_ID", pTerminalServiceChargeDetails.ServiceChargeId)
                db.AddParameter("p_SERVICE_CHARGE_REF_ID", pTerminalServiceChargeDetails.ServiceChargeRefId)
                db.AddParameter("p_APPROVAL_FLAG", pTerminalServiceChargeDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pTerminalServiceChargeDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SERVICE_CHARGES_APPROVAL", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTerminalServiceChargeDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTerminalServiceChargeDetails.Errormsg = ex.Message
            End Try
            Return pTerminalServiceChargeDetails
        End Function

    End Class
End Namespace
