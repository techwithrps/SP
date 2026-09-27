Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: YardDetails
    ''' @author	: Amit K. Singh- 1/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class ExtYardDetails
        Inherits YardDetails


        ''' <summary>
        ''' Preparing Return Object ArrayList of All Yards By TerminalId, YardId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnYardDetailsListByTerminalId(ByVal pYardDetails As ExtYardDetails) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DETAILS_ALL", pYardDetails.TerminalId)
                arrYardDetails = ReturnObjectValuesList(dbr, arrYardDetails)
                dbr.Close()
            Catch ex As Exception
                arrYardDetails = Nothing
            End Try
            db.CloseDB()
            Return arrYardDetails
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of Import All Yards By TerminalId, DocType, YardType
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnYardDetailsListByDockTypeYardType(ByVal pTerminalId As Long, ByVal pDocType As Long, ByVal pYardType As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrYardDetails As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_YARD_DET_BY_DOC_YARD_TYPE", pTerminalId & "," & pDocType & ",'" & pYardType & "'")
                arrYardDetails = ReturnObjectValuesList(dbr, arrYardDetails)
                dbr.Close()
            Catch ex As Exception
                arrYardDetails = Nothing
            End Try
            db.CloseDB()
            Return arrYardDetails
        End Function
    End Class
End Namespace
