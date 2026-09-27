Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: UploadFile
    ''' @author	: Amit K. Singh- 14/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtUploadFile
        Inherits UploadFile

        Private arrUploadFileData As ArrayList

        Public Property UploadFileDataList() As ArrayList
            Get
                Return arrUploadFileData
            End Get
            Set(ByVal value As ArrayList)
                arrUploadFileData = value
            End Set
        End Property

        Sub New()

        End Sub

        Public Shared Function UploadFileDataIGM(ByVal pExtUploadFile As ExtUploadFile) As ExtUploadFile
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()

                ExtUploadFile.InsertTrn(db, pExtUploadFile)

                If pExtUploadFile.Errormsg = "" AndAlso pExtUploadFile.FileId > 0 Then
                    For Each ufd As UploadFileData In pExtUploadFile.UploadFileDataList
                        ufd.TerminalId = pExtUploadFile.TerminalId
                        ufd.FileId = pExtUploadFile.FileId

                        UploadFileData.InsertTrn(db, ufd)

                        If ufd.Errormsg <> "" Then
                            'Throw New Exception(ufd.Errormsg)
                        End If
                    Next
                Else
                    Throw New Exception(pExtUploadFile.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pExtUploadFile.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pExtUploadFile
        End Function

        'Public Shared Function TransferIGM(ByVal pExtUploadFile As ExtUploadFile, ByVal pIgmLineItems As IgmLineItems) As ExtUploadFile
        '    Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
        '    Try
        '        db.BeginTransaction()

        '        ExtUploadFile.IGMDataTransfer(db, pExtUploadFile)

        '        If pExtUploadFile.Errormsg = "" AndAlso pExtUploadFile.FileId > 0 Then
        '            IgmLineItems.InsertTrn(db, pIgmLineItems)
        '        Else
        '            Throw New Exception(pExtUploadFile.Errormsg)
        '        End If
        '        db.CommitTransaction()
        '    Catch ex As Exception
        '        pExtUploadFile.Errormsg = ex.Message
        '        Try
        '            db.RollbackTransaction()
        '        Catch ex1 As Exception

        '        End Try
        '        ' Rollback the transaction if any 
        '    End Try
        '    Return pExtUploadFile
        'End Function

        Friend Shared Function IGMDataTransfer(ByVal db As DBConnect, ByVal pUploadFile As ExtUploadFile) As ExtUploadFile
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pUploadFile.TerminalId)
                db.AddParameter("p_IGM_NO", pUploadFile.IGMNo)
                db.AddParameter("p_FILE_ID", pUploadFile.FileId)
                db.AddParameter("p_FILE_NAME", pUploadFile.FileName)
                db.AddParameter("p_FILE_TYPE", pUploadFile.FileType)
                db.AddParameter("p_REMARKS", pUploadFile.Remarks)
                db.AddParameter("p_CREATED_BY", pUploadFile.CreatedBy)
                db.AddParameter("p_CREATED_ON", pUploadFile.CreatedOn)
                db.AddParameter("p_ErrorMsg", pUploadFile.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPLOAD_PKG.SP_TRANSFER_IGM", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pUploadFile.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pUploadFile.Errormsg = ex.Message
            End Try
            Return pUploadFile
        End Function

    End Class
End Namespace
