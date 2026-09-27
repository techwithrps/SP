Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RouteMaster Class
    ''' @author	: Amit K. Singh- 10/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class ExtRouteMaster
        Inherits RouteMaster

        Dim arrExtSubRoute As New ArrayList

        Public Property ExtSubRouteList() As ArrayList
            Get
                Return arrExtSubRoute
            End Get
            Set(ByVal value As ArrayList)
                arrExtSubRoute = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRouteMasterListByLoginTerminal(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MST_BY_FROM_TERMINAL", pRouteMaster.FromTerminalId)
                arrRouteMaster = ReturnObjectValuesList(dbr, arrRouteMaster)
                dbr.Close()
            Catch ex As Exception
                arrRouteMaster = Nothing
            End Try
            db.CloseDB()
            Return arrRouteMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRouteMasterListToLoginTerminal(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MST_BY_TO_TERMINAL", pRouteMaster.ToTerminalId)
                arrRouteMaster = ReturnObjectValuesList(dbr, arrRouteMaster)
                dbr.Close()
            Catch ex As Exception
                arrRouteMaster = Nothing
            End Try
            db.CloseDB()
            Return arrRouteMaster
        End Function


        Public Shared Function InsertDetails(ByVal pExtRouteMaster As ExtRouteMaster) As ExtRouteMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                If pExtRouteMaster.RouteId > 0 Then
                    ExtRouteMaster.UpdateTrn(db, pExtRouteMaster)
                Else
                    ExtRouteMaster.InsertTrn(db, pExtRouteMaster)
                End If
                If pExtRouteMaster.Errormsg = Nothing Then
                    For Each pExtSubRouteMaster As ExtSubRouteMaster In pExtRouteMaster.ExtSubRouteList
                        pExtSubRouteMaster.RouteId = pExtRouteMaster.RouteId
                        If pExtSubRouteMaster.SubRefId > 0 Then
                            ExtSubRouteMaster.UpdateTrn(db, pExtSubRouteMaster)
                        Else
                            ExtSubRouteMaster.InsertTrn(db, pExtSubRouteMaster)
                        End If
                        If pExtSubRouteMaster.Errormsg <> Nothing Then
                            Throw New Exception(pExtSubRouteMaster.Errormsg)
                        End If
                    Next
                End If
                If pExtRouteMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pExtRouteMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pExtRouteMaster
        End Function

        Public Shared Function ReturnRouteMasterWithSubRoutesById(ByVal pExtRouteMaster As ExtRouteMaster) As ExtRouteMaster
            pExtRouteMaster = ExtRouteMaster.ReturnRouteMaster(pExtRouteMaster)

            Dim pExtSubRouteMaster As New ExtSubRouteMaster
            pExtSubRouteMaster.RouteId = pExtRouteMaster.RouteId
            pExtRouteMaster.ExtSubRouteList = ExtSubRouteMaster.ReturnSubRouteMasterListByRouteId(pExtSubRouteMaster)

            Return pExtRouteMaster
        End Function

    End Class
End Namespace
