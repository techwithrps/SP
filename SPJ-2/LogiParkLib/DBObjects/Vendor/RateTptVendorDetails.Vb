Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RatetptDetails Class
    ''' @author	: Amit K. Singh- 17/02/2012
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class RateTptVendorDetails

        Private lngRateTptRefId As Long ' Define Private Variable RateTptRefId DataType As Long 
        Private lngRateTptId As Long ' Define Private Variable RateTptId DataType As Long 
        Private strFromDate As String ' Define Private Variable FromDate DataType As String 
        Private strToDate As String ' Define Private Variable ToDate DataType As String 
        Private lngDocId As Long ' Define Private Variable DocId DataType As Long 
        Private lngTerminalId As Long ' Define Private Variable TerminalId DataType As Long 
        Private lngFromLocation As Long ' Define Private Variable FromLocation DataType As Long 
        Private lngToLocation As Long ' Define Private Variable ToLocation DataType As Long 
        Private dblDistance As Double ' Define Private Variable Distance DataType As Double
        Private strStuffDestuff As String ' Define Private Variable StuffDestuff DataType As String
        Private lngTrailorSize As Long ' Define Private Variable TrailorSize DataType As Long 
        Private lngContPerTrailor As Long ' Define Private Variable ContPerTrailor DataType As Long 
        Private strContSize As String ' Define Private Variable ContSize DataType As String 
        Private strContStatus As String ' Define Private Variable ContStatus DataType As String 
        Private strContType As String ' Define Private Variable ContType DataType As String 
        Private lngCommodityId As Long ' Define Private Variable CommodityId DataType As Long 
        Private strImoCode As String ' Define Private Variable ImoCode DataType As String 
        Private lngFromRange As Long ' Define Private Variable FromRange DataType As Long 
        Private lngToRange As Long ' Define Private Variable ToRange DataType As Long 
        Private dblRate As Double ' Define Private Variable Rate DataType As Double 
        Private strApprovalFlag As String ' Define Private Variable strApprovalFlag DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' RateTptRefId
        ''' </summary>
        ''' <value>lngRateTptRefId</value>
        ''' <returns> Return lngRateTptRefId</returns>
        ''' <remarks></remarks>
        Public Property RateTptRefId() As Long
            Get
                Return lngRateTptRefId
            End Get
            Set(ByVal value As Long)
                lngRateTptRefId = value
            End Set
        End Property


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
        ''' FromDate
        ''' </summary>
        ''' <value>strFromDate</value>
        ''' <returns> Return strFromDate</returns>
        ''' <remarks></remarks>
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal value As String)
                strFromDate = value
            End Set
        End Property

        ''' <summary>
        ''' ToDate
        ''' </summary>
        ''' <value>strToDate</value>
        ''' <returns> Return strToDate</returns>
        ''' <remarks></remarks>
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
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
        ''' FromLocation
        ''' </summary>
        ''' <value>lngFromLocation</value>
        ''' <returns> Return lngFromLocation</returns>
        ''' <remarks></remarks>
        Public Property FromLocation() As Long
            Get
                Return lngFromLocation
            End Get
            Set(ByVal value As Long)
                lngFromLocation = value
            End Set
        End Property

        ''' <summary>
        ''' ToLocation
        ''' </summary>
        ''' <value>lngToLocation</value>
        ''' <returns> Return lngToLocation</returns>
        ''' <remarks></remarks>
        Public Property ToLocation() As Long
            Get
                Return lngToLocation
            End Get
            Set(ByVal value As Long)
                lngToLocation = value
            End Set
        End Property

        ''' <summary>
        ''' Distance
        ''' </summary>
        ''' <value>dblDistance</value>
        ''' <returns> Return dblDistance</returns>
        ''' <remarks></remarks>
        Public Property Distance() As Double
            Get
                Return dblDistance
            End Get
            Set(ByVal value As Double)
                dblDistance = value
            End Set
        End Property


        ''' <summary>
        ''' StuffDestuff
        ''' </summary>
        ''' <value>strStuffDestuff</value>
        ''' <returns> Return strStuffDestuff</returns>
        ''' <remarks></remarks>
        Public Property StuffDestuff() As String
            Get
                Return strStuffDestuff
            End Get
            Set(ByVal value As String)
                strStuffDestuff = value
            End Set
        End Property


        ''' <summary>
        ''' TrailorSize
        ''' </summary>
        ''' <value>lngTrailorSize</value>
        ''' <returns> Return lngTrailorSize</returns>
        ''' <remarks></remarks>
        Public Property TrailorSize() As Long
            Get
                Return lngTrailorSize
            End Get
            Set(ByVal value As Long)
                lngTrailorSize = value
            End Set
        End Property

        ''' <summary>
        ''' ContPerTrailor
        ''' </summary>
        ''' <value>lngContPerTrailor</value>
        ''' <returns> Return lngContPerTrailor</returns>
        ''' <remarks></remarks>
        Public Property ContPerTrailor() As Long
            Get
                Return lngContPerTrailor
            End Get
            Set(ByVal value As Long)
                lngContPerTrailor = value
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
        ''' ContType
        ''' </summary>
        ''' <value>strContType</value>
        ''' <returns> Return strContType</returns>
        ''' <remarks></remarks>
        Public Property ContType() As String
            Get
                Return strContType
            End Get
            Set(ByVal value As String)
                strContType = value
            End Set
        End Property


        ''' <summary>
        ''' CommodityId
        ''' </summary>
        ''' <value>lngCommodityId</value>
        ''' <returns> Return lngCommodityId</returns>
        ''' <remarks></remarks>
        Public Property CommodityId() As Long
            Get
                Return lngCommodityId
            End Get
            Set(ByVal value As Long)
                lngCommodityId = value
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
        ''' <value>dblRate</value>
        ''' <returns> Return dblRate</returns>
        ''' <remarks></remarks>
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal value As Double)
                dblRate = value
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
            lngRateTptRefId = 0
            lngRateTptId = 0
            strFromDate = ""
            strToDate = ""
            lngDocId = 0
            lngTerminalId = 0
            lngFromLocation = 0
            lngToLocation = 0
            dblDistance = 0.0
            strStuffDestuff = ""
            lngTrailorSize = 0
            lngContPerTrailor = 0
            strContSize = ""
            strContStatus = ""
            strContType = ""
            lngCommodityId = 0
            strImoCode = ""
            lngFromRange = 0
            lngToRange = 0
            dblRate = 0.0
            strApprovalFlag = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRateTptVendorDetails"></param>
        ''' <returns>Return pRateTptVendorDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptVendorDetails.RateTptRefId, ParameterDirection.Output)
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendorDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptVendorDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptVendorDetails.ToDate)
                db.AddParameter("p_DOC_ID", pRateTptVendorDetails.DocId)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendorDetails.TerminalId)
                db.AddParameter("p_FROM_LOCATION", pRateTptVendorDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptVendorDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptVendorDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptVendorDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptVendorDetails.TrailorSize)
                db.AddParameter("p_CONT_PER_TRAILOR", pRateTptVendorDetails.ContPerTrailor)
                db.AddParameter("p_CONT_SIZE", pRateTptVendorDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptVendorDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptVendorDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptVendorDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptVendorDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptVendorDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptVendorDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptVendorDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pRateTptVendorDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pRateTptVendorDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_VENDOR_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendorDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptVendorDetails.RateTptRefId = db.Parameters.Item("p_RATE_TPT_REF_ID").value

                If pRateTptVendorDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptVendorDetails"></param>
        ''' <returns>Return pRateTptVendorDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Try
                'db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptVendorDetails.RateTptRefId, ParameterDirection.Output)
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendorDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptVendorDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptVendorDetails.ToDate)
                db.AddParameter("p_DOC_ID", pRateTptVendorDetails.DocId)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendorDetails.TerminalId)
                db.AddParameter("p_FROM_LOCATION", pRateTptVendorDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptVendorDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptVendorDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptVendorDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptVendorDetails.TrailorSize)
                db.AddParameter("p_CONT_PER_TRAILOR", pRateTptVendorDetails.ContPerTrailor)
                db.AddParameter("p_CONT_SIZE", pRateTptVendorDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptVendorDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptVendorDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptVendorDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptVendorDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptVendorDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptVendorDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptVendorDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pRateTptVendorDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pRateTptVendorDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_RATE_TPT_VENDOR_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendorDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRateTptVendorDetails.RateTptRefId = db.Parameters.Item("p_RATE_TPT_REF_ID").value

            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
            End Try
            Return pRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRateTptVendorDetails"></param>
        ''' <returns>Return pRateTptVendorDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptVendorDetails.RateTptRefId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendorDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptVendorDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptVendorDetails.ToDate)
                db.AddParameter("p_DOC_ID", pRateTptVendorDetails.DocId)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendorDetails.TerminalId)
                db.AddParameter("p_FROM_LOCATION", pRateTptVendorDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptVendorDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptVendorDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptVendorDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptVendorDetails.TrailorSize)
                db.AddParameter("p_CONT_PER_TRAILOR", pRateTptVendorDetails.ContPerTrailor)
                db.AddParameter("p_CONT_SIZE", pRateTptVendorDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptVendorDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptVendorDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptVendorDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptVendorDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptVendorDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptVendorDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptVendorDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pRateTptVendorDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pRateTptVendorDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_VENDOR_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendorDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRateTptVendorDetails.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRateTptVendorDetails"></param>
        ''' <returns>Return pRateTptVendorDetails Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Try
                db.ClearParameters()
                db.AddParameter("p_RATE_TPT_REF_ID", pRateTptVendorDetails.RateTptRefId)
                db.AddParameter("p_RATE_TPT_ID", pRateTptVendorDetails.RateTptId)
                db.AddParameter("p_FROM_DATE", pRateTptVendorDetails.FromDate)
                db.AddParameter("p_TO_DATE", pRateTptVendorDetails.ToDate)
                db.AddParameter("p_DOC_ID", pRateTptVendorDetails.DocId)
                db.AddParameter("p_TERMINAL_ID", pRateTptVendorDetails.TerminalId)
                db.AddParameter("p_FROM_LOCATION", pRateTptVendorDetails.FromLocation)
                db.AddParameter("p_TO_LOCATION", pRateTptVendorDetails.ToLocation)
                db.AddParameter("p_DISTANCE", pRateTptVendorDetails.Distance)
                db.AddParameter("p_STUFF_DESTUFF", pRateTptVendorDetails.StuffDestuff)
                db.AddParameter("p_TRAILOR_SIZE", pRateTptVendorDetails.TrailorSize)
                db.AddParameter("p_CONT_PER_TRAILOR", pRateTptVendorDetails.ContPerTrailor)
                db.AddParameter("p_CONT_SIZE", pRateTptVendorDetails.ContSize)
                db.AddParameter("p_CONT_STATUS", pRateTptVendorDetails.ContStatus)
                db.AddParameter("p_CONT_TYPE", pRateTptVendorDetails.ContType)
                db.AddParameter("p_COMMODITY_ID", pRateTptVendorDetails.CommodityId)
                db.AddParameter("p_IMO_CODE", pRateTptVendorDetails.ImoCode)
                db.AddParameter("p_FROM_RANGE", pRateTptVendorDetails.FromRange)
                db.AddParameter("p_TO_RANGE", pRateTptVendorDetails.ToRange)
                db.AddParameter("p_RATE", pRateTptVendorDetails.Rate)
                db.AddParameter("p_APPROVAL_FLAG", pRateTptVendorDetails.ApprovalFlag)
                db.AddParameter("p_ErrorMsg", pRateTptVendorDetails.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_RATE_TPT_VENDOR_DETAILS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRateTptVendorDetails.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
            End Try
            Return pRateTptVendorDetails
        End Function



        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("RATE_TPT_REF_ID").ToString <> "" Then
                            pRateTptVendorDetails.RateTptRefId = dbr("RATE_TPT_REF_ID")
                        End If
                        If dbr("RATE_TPT_ID").ToString <> "" Then
                            pRateTptVendorDetails.RateTptId = dbr("RATE_TPT_ID")
                        End If
                        If dbr("FROM_DATE").ToString <> "" Then
                            pRateTptVendorDetails.FromDate = dbr("FROM_DATE")
                        End If
                        If dbr("TO_DATE").ToString <> "" Then
                            pRateTptVendorDetails.ToDate = dbr("TO_DATE")
                        End If
                        If dbr("DOC_ID").ToString <> "" Then
                            pRateTptVendorDetails.DocId = dbr("DOC_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            pRateTptVendorDetails.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("FROM_LOCATION").ToString <> "" Then
                            pRateTptVendorDetails.FromLocation = dbr("FROM_LOCATION")
                        End If
                        If dbr("TO_LOCATION").ToString <> "" Then
                            pRateTptVendorDetails.ToLocation = dbr("TO_LOCATION")
                        End If
                        If dbr("DISTANCE").ToString <> "" Then
                            pRateTptVendorDetails.Distance = dbr("DISTANCE")
                        End If
                        If dbr("STUFF_DESTUFF").ToString <> "" Then
                            pRateTptVendorDetails.StuffDestuff = dbr("STUFF_DESTUFF")
                        End If
                        If dbr("TRAILOR_SIZE").ToString <> "" Then
                            pRateTptVendorDetails.TrailorSize = dbr("TRAILOR_SIZE")
                        End If
                        If dbr("CONT_REP_TRAILOR").ToString <> "" Then
                            pRateTptVendorDetails.ContPerTrailor = dbr("CONT_REP_TRAILOR")
                        End If
                        If dbr("CONT_SIZE").ToString <> "" Then
                            pRateTptVendorDetails.ContSize = dbr("CONT_SIZE")
                        End If
                        If dbr("CONT_STATUS").ToString <> "" Then
                            pRateTptVendorDetails.ContStatus = dbr("CONT_STATUS")
                        End If
                        If dbr("CONT_TYPE").ToString <> "" Then
                            pRateTptVendorDetails.ContType = dbr("CONT_TYPE")
                        End If
                        If dbr("COMMODITY_ID").ToString <> "" Then
                            pRateTptVendorDetails.CommodityId = dbr("COMMODITY_ID")
                        End If
                        If dbr("IMO_CODE").ToString <> "" Then
                            pRateTptVendorDetails.ImoCode = dbr("IMO_CODE")
                        End If
                        If dbr("FROM_RANGE").ToString <> "" Then
                            pRateTptVendorDetails.FromRange = dbr("FROM_RANGE")
                        End If
                        If dbr("TO_RANGE").ToString <> "" Then
                            pRateTptVendorDetails.ToRange = dbr("TO_RANGE")
                        End If
                        If dbr("RATE").ToString <> "" Then
                            pRateTptVendorDetails.Rate = dbr("RATE")
                        End If
                        If dbr("APPROVAL_FLAGE").ToString <> "" Then
                            pRateTptVendorDetails.ApprovalFlag = dbr("APPROVAL_FLAGE")
                        End If
                    End While
                End If
            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
            End Try
            Return pRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRateTptVendorDetails As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RateTptVendorDetails
                        If dbr("RATE_TPT_REF_ID").ToString <> "" Then
                            temp.RateTptRefId = dbr("RATE_TPT_REF_ID")
                        End If
                        If dbr("RATE_TPT_ID").ToString <> "" Then
                            temp.RateTptId = dbr("RATE_TPT_ID")
                        End If
                        If dbr("FROM_DATE").ToString <> "" Then
                            temp.FromDate = dbr("FROM_DATE")
                        End If
                        If dbr("TO_DATE").ToString <> "" Then
                            temp.ToDate = dbr("TO_DATE")
                        End If
                        If dbr("DOC_ID").ToString <> "" Then
                            temp.DocId = dbr("DOC_ID")
                        End If
                        If dbr("TERMINAL_ID").ToString <> "" Then
                            temp.TerminalId = dbr("TERMINAL_ID")
                        End If
                        If dbr("FROM_LOCATION").ToString <> "" Then
                            temp.FromLocation = dbr("FROM_LOCATION")
                        End If
                        If dbr("TO_LOCATION").ToString <> "" Then
                            temp.ToLocation = dbr("TO_LOCATION")
                        End If
                        If dbr("DISTANCE").ToString <> "" Then
                            temp.Distance = dbr("DISTANCE")
                        End If
                        If dbr("STUFF_DESTUFF").ToString <> "" Then
                            temp.StuffDestuff = dbr("STUFF_DESTUFF")
                        End If
                        If dbr("TRAILOR_SIZE").ToString <> "" Then
                            temp.TrailorSize = dbr("TRAILOR_SIZE")
                        End If
                        If dbr("CONT_REP_TRAILOR").ToString <> "" Then
                            temp.ContPerTrailor = dbr("CONT_REP_TRAILOR")
                        End If
                        If dbr("CONT_SIZE").ToString <> "" Then
                            temp.ContSize = dbr("CONT_SIZE")
                        End If
                        If dbr("CONT_STATUS").ToString <> "" Then
                            temp.ContStatus = dbr("CONT_STATUS")
                        End If
                        If dbr("CONT_TYPE").ToString <> "" Then
                            temp.ContType = dbr("CONT_TYPE")
                        End If
                        If dbr("COMMODITY_ID").ToString <> "" Then
                            temp.CommodityId = dbr("COMMODITY_ID")
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
                        If dbr("APPROVAL_FLAGE").ToString <> "" Then
                            temp.ApprovalFlag = dbr("APPROVAL_FLAGE")
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
        Public Shared Function ReturnRateTptVendorDetails(ByVal pRateTptVendorDetails As RateTptVendorDetails) As RateTptVendorDetails
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_DTLS_BY_ID", pRateTptVendorDetails.TerminalId & "," & pRateTptVendorDetails.RateTptId)
                pRateTptVendorDetails = ReturnObjectValues(dbr, pRateTptVendorDetails)
                dbr.Close()
            Catch ex As Exception
                pRateTptVendorDetails.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptVendorDetailsListByRateId(ByVal pRateTptVendorDetails As RateTptVendorDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptVendorDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_DTLS_BY_ID", pRateTptVendorDetails.TerminalId & "," & pRateTptVendorDetails.RateTptId)
                arrRateTptVendorDetails = ReturnObjectValuesList(dbr, arrRateTptVendorDetails)
                dbr.Close()
            Catch ex As Exception
                arrRateTptVendorDetails = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptVendorDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRateTptVendorDetailsList(ByVal pRateTptVendorDetails As RateTptVendorDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRateTptVendorDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_DTLS_LIST", pRateTptVendorDetails.TerminalId & "," & pRateTptVendorDetails.RateTptId)
                arrRateTptVendorDetails = ReturnObjectValuesList(dbr, arrRateTptVendorDetails)
                dbr.Close()
            Catch ex As Exception
                arrRateTptVendorDetails = Nothing
            End Try
            db.CloseDB()
            Return arrRateTptVendorDetails
        End Function
    End Class
End Namespace
