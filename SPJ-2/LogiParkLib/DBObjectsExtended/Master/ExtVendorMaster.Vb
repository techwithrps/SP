Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: VendorMaster
    ''' @author	: Amit K. Singh- 19/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtVendorMaster
        Inherits VendorMaster

        Dim arrVendorTypeDetails As New ArrayList

        Public Property VendorTypeDetailsList() As ArrayList
            Get
                Return arrVendorTypeDetails
            End Get
            Set(ByVal value As ArrayList)
                arrVendorTypeDetails = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()

        End Sub

        Public Shared Function InsertUpdateTransaction(ByVal pVendorMaster As ExtVendorMaster) As ExtVendorMaster
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pVendorMaster.VendorId > 0 Then
                    ExtVendorMaster.UpdateTrn(db, pVendorMaster)
                Else
                    ExtVendorMaster.InsertTrn(db, pVendorMaster)
                End If

                If pVendorMaster.Errormsg = "" AndAlso pVendorMaster.VendorId > 0 Then
                    For Each det As VendorTypeDetails In pVendorMaster.VendorTypeDetailsList
                        det.VendorId = pVendorMaster.VendorId
                        If det.VendorKeyId > 0 Then
                            VendorTypeDetails.UpdateTrn(db, det)
                        Else
                            VendorTypeDetails.InsertTrn(db, det)
                        End If
                        If det.Errormsg <> "" Then
                            Throw New Exception(det.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pVendorMaster.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pVendorMaster.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAll(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_ALL", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllImportHandaling(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_IMP_HANDLING", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllImportTransporter(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_IMP_TPT", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllImportSurveyor(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_IMP_SVR", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllExportHandaling(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_EXP_HANDLING", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllExportTransporter(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_EXP_TPT", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllExportSurveyor(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_EXP_SVR", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterById(ByVal pVendorMaster As VendorMaster) As VendorMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_BY_ID", pVendorMaster.TerminalId & ",'" & pVendorMaster.VendorId & "'")
                pVendorMaster = ReturnObjectValues(dbr, pVendorMaster)
                dbr.Close()
            Catch ex As Exception
                pVendorMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListDomesticBroker(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_DOM_BROKER", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function
        Public Shared Function ReturnVendorMasterListDomesticBrokerDo(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_DOM_BROKER_DO", "")
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListTypeCode(ByVal pVendorMaster As ExtVendorMaster, ByVal pType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_TYPE_CODE", pVendorMaster.TerminalId & ",'" & pType & "'")
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllDomesticTransporter(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_DOM_TPT", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllDomesticSurveyor(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_DOM_SURV", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

        Public Shared Function ReturnVendorMasterListAllVendor(ByVal pVendorMaster As ExtVendorMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrVendorMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_MASTER_ALL_V", pVendorMaster.TerminalId)
                arrVendorMaster = ReturnObjectValuesList(dbr, arrVendorMaster)
                dbr.Close()
            Catch ex As Exception
                arrVendorMaster = Nothing
            End Try
            db.CloseDB()
            Return arrVendorMaster
        End Function

    End Class
End Namespace
