Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  RFS :: RailFreight System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: Customer Mail Id Class
    ''' @Author	: Dhirendra K. Singh- 24/01/2012
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class CustomerMailId
        Private strEmailOperation As String
        Private lngVisitId As Long


        ''' <summary>
        ''' EmailOperation
        ''' </summary>
        ''' <value>strEmailOperation</value>
        ''' <returns> Return strEmailOperation</returns>
        ''' <remarks></remarks>
        Public Property EmailOperation() As String
            Get
                Return strEmailOperation
            End Get
            Set(ByVal value As String)
                strEmailOperation = value
            End Set
        End Property


        ''' <summary>
        ''' VisitId
        ''' </summary>
        ''' <value>lngVisitId</value>
        ''' <returns> Return lngVisitId</returns>
        ''' <remarks></remarks>
        Public Property VisitId() As Long
            Get
                Return lngVisitId
            End Get
            Set(ByVal value As Long)
                lngVisitId = value
            End Set
        End Property


        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            strEmailOperation = ""
            lngVisitId = 0
        End Sub

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRakeVisit As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerMailId
                        If dbr("EMAIL_OPERATIONAL").ToString <> "" Then
                            temp.EmailOperation = dbr("EMAIL_OPERATIONAL")
                        End If

                        arrList.Add(temp)
                    End While
                End If
            Catch ex As Exception
                arrList = Nothing
            End Try
            Return arrList
        End Function

        Public Shared Function ReturnCustomerMailId(ByVal pCustomerMailId As CustomerMailId) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerMailId As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MAIL_TO_BILLTO_PARTY", pCustomerMailId.lngVisitId)
                arrCustomerMailId = ReturnObjectValuesList(dbr, arrCustomerMailId)
                dbr.Close()
            Catch ex As Exception
                arrCustomerMailId = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerMailId
        End Function
    End Class
End Namespace