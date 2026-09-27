Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerMaster
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtCustomerMaster
        Inherits CustomerMaster

        Dim arrCustomerTypeDetails As New ArrayList

        Public Property CustomerTypeDetailsList() As ArrayList
            Get
                Return arrCustomerTypeDetails
            End Get
            Set(ByVal value As ArrayList)
                arrCustomerTypeDetails = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()

        End Sub

        Public Shared Function ReturnCustomerMasterDetailsById(ByVal pCustomerMaster As ExtCustomerMaster) As ExtCustomerMaster
            ExtCustomerMaster.ReturnCustomerMaster(pCustomerMaster)

            'Dim pCustomerTypeDetails As New CustomerTypeDetails
            'pCustomerTypeDetails.CustomerId = pCustomerMaster.CustomerId
            'pCustomerTypeDetails.TerminalId = pCustomerMaster.TerminalId

            'pCustomerMaster.CustomerTypeDetailsList = CustomerTypeDetails.ReturnCustomerTypeDetailsList(pCustomerTypeDetails)

            Return pCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListImportCha(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_IMP_CHA", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListExportCha(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_EXP_CHA", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListImportLine(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_IMP_LINE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListExportLine(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_EXP_LINE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnImporterList(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_IMPORTER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListImportAgent(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_IMP_AGENT", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListExportAgent(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_EXP_AGENT", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListAgent(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_AGENT", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListCha(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_CHA", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListLine(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_LINE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListConsignee(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_CONSIGNEE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListConsigner(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_CONSIGNER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListShipper(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_SHIPPER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListForwarder(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_FORWARDER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListAll(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_ALL", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListAllByCustomertypeCode(ByVal pCustomerMaster As ExtCustomerMaster, ByVal pType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_TYPECODE", pCustomerMaster.TerminalId & ",'" & pType & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListAllByCustomerrForwerder(ByVal pCustomerMaster As ExtCustomerMaster, ByVal pType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_FOR", pCustomerMaster.TerminalId & ",'" & pType & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListAllByCustomerrAgent(ByVal pCustomerMaster As ExtCustomerMaster, ByVal pType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_AGENT", pCustomerMaster.TerminalId & ",'" & pType & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListAllByCustomerrCha(ByVal pCustomerMaster As ExtCustomerMaster, ByVal pType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_BY_CHA", pCustomerMaster.TerminalId & ",'" & pType & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListByPendingInvoice(ByVal pCustomerMaster As CustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_PENDING_INVOICE", "' '")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListAllBy_CustomerTypeCode_DocType_Status(ByVal pCustomerMaster As ExtCustomerMaster, ByVal pType As CustomerMaster.enumCustomerTypeCode, ByVal pDocType As CustomerMaster.enumDocType, ByVal pStatus As CustomerMaster.enumStatus) As ArrayList
            Dim strType As String = Nothing
            Dim strDoc As String = Nothing
            Dim strStatus As String = Nothing

            If enumCustomerTypeCode.Agent = pType Then
                strType = "A"
            ElseIf enumCustomerTypeCode.Line = pType Then
                strType = "L"
            ElseIf enumCustomerTypeCode.Cha = pType Then
                strType = "C"
            ElseIf enumCustomerTypeCode.Consignee = pType Then
                strType = "E"
            ElseIf enumCustomerTypeCode.Consignor = pType Then
                strType = "R"
            ElseIf enumCustomerTypeCode.Forwarder = pType Then
                strType = "F"
            ElseIf enumCustomerTypeCode.Shipper = pType Then
                strType = "S"
            End If
            If enumDocType.All = pDocType Then
                strDoc = "ALL"
            ElseIf enumDocType.Domestic = pDocType Then
                strDoc = "D"
            ElseIf enumDocType.Export = pDocType Then
                strDoc = "E"
            ElseIf enumDocType.Import = pDocType Then
                strDoc = "I"
            End If
            If enumStatus.All = pStatus Then
                strStatus = "ALL"
            ElseIf enumStatus.Yes = pStatus Then
                strStatus = "YES"
            End If
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MAST_COD_DOC_STS", pCustomerMaster.TerminalId & ",'" & strType & "','" & strDoc & "','" & strStatus & "'")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnDomesticForwarderListAll(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_FORWARDER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnDomesticForwarderListAllDo(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_FORWARDER_DO", " ")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnDomesticConsignorListAll(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_CONSIGNOR", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnDomesticConsignorListAllDo(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_CONSIGNOR_DO", " ")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnDomesticConsigneeListAll(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_CONSIGNEE", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnDomesticConsigneeListAllDo(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DOM_CONSIGNEE_DO", " ")
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

        Public Shared Function ReturnCustomerMasterListRailOperator(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_RAIL_OPER", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function


        Public Shared Function ReturnLineListMgtRpt(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_LINELISTMGTRPT", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function
        Public Shared Function ReturnCustomerMasterListAgen(ByVal pCustomerMaster As ExtCustomerMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_MASTER_AGEN", pCustomerMaster.TerminalId)
                arrCustomerMaster = ReturnObjectValuesList(dbr, arrCustomerMaster)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMaster
        End Function

    End Class
End Namespace

