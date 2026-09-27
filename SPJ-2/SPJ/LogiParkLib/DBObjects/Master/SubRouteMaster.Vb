Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: SubRouteMaster Class
    ''' @author	: Amit K. Singh- 17/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class SubRouteMaster

        Private lngRouteId As Long ' Define Private Variable RouteId DataType As Long 
        Private lngSubRefId As Long ' Define Private Variable TerminalId DataType As Long 
        Private lngSubRouteId As Long ' Define Private Variable SubRouteId DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' RouteId
        ''' </summary>
        ''' <value>lngRouteId</value>
        ''' <returns> Return lngRouteId</returns>
        ''' <remarks></remarks>
        Public Property RouteId() As Long
            Get
                Return lngRouteId
            End Get
            Set(ByVal value As Long)
                lngRouteId = value
            End Set
        End Property


        ''' <summary>
        ''' TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks></remarks>
        Public Property SubRefId() As Long
            Get
                Return lngSubRefId
            End Get
            Set(ByVal value As Long)
                lngSubRefId = value
            End Set
        End Property



        ''' <summary>
        ''' SubRouteId
        ''' </summary>
        ''' <value>lngSubRouteId</value>
        ''' <returns> Return lngSubRouteId</returns>
        ''' <remarks></remarks>
        Public Property SubRouteId() As Long
            Get
                Return lngSubRouteId
            End Get
            Set(ByVal value As Long)
                lngSubRouteId = value
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
            lngRouteId = 0
            lngSubRefId = 0
            lngSubRouteId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pSubRouteMaster"></param>
        ''' <returns>Return pSubRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pSubRouteMaster.RouteId)
                db.AddParameter("p_SUB_REF_ID", pSubRouteMaster.SubRefId, ParameterDirection.Output)
                db.AddParameter("p_SUB_ROUTE_ID", pSubRouteMaster.SubRouteId)
                db.AddParameter("p_ErrorMsg", pSubRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SUB_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pSubRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pSubRouteMaster.SubRefId = db.Parameters.Item("p_SUB_REF_ID").value

                If pSubRouteMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pSubRouteMaster"></param>
        ''' <returns>Return pSubRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pSubRouteMaster.RouteId)
                db.AddParameter("p_SUB_REF_ID", pSubRouteMaster.SubRefId, ParameterDirection.Output)
                db.AddParameter("p_SUB_ROUTE_ID", pSubRouteMaster.SubRouteId)
                db.AddParameter("p_ErrorMsg", pSubRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_SUB_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pSubRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pSubRouteMaster.SubRefId = db.Parameters.Item("p_SUB_REF_ID").value

            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
            End Try
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pSubRouteMaster"></param>
        ''' <returns>Return pSubRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pSubRouteMaster.RouteId)
                db.AddParameter("p_SUB_REF_ID", pSubRouteMaster.SubRefId)
                db.AddParameter("p_SUB_ROUTE_ID", pSubRouteMaster.SubRouteId)
                db.AddParameter("p_ErrorMsg", pSubRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SUB_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pSubRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pSubRouteMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pSubRouteMaster"></param>
        ''' <returns>Return pSubRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pSubRouteMaster.RouteId)
                db.AddParameter("p_SUB_REF_ID", pSubRouteMaster.SubRefId)
                db.AddParameter("p_SUB_ROUTE_ID", pSubRouteMaster.SubRouteId)
                db.AddParameter("p_ErrorMsg", pSubRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_SUB_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pSubRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
            End Try
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("ROUTE_ID").ToString <> "" Then
                            pSubRouteMaster.RouteId = dbr("ROUTE_ID")
                        End If
                        If dbr("SUB_REF_ID").ToString <> "" Then
                            pSubRouteMaster.SubRefId = dbr("SUB_REF_ID")
                        End If
                        If dbr("SUB_ROUTE_ID").ToString <> "" Then
                            pSubRouteMaster.SubRouteId = dbr("SUB_ROUTE_ID")
                        End If
                    End While
                End If
            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
            End Try
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrSubRouteMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New SubRouteMaster
                        If dbr("ROUTE_ID").ToString <> "" Then
                            temp.RouteId = dbr("ROUTE_ID")
                        End If
                        If dbr("SUB_REF_ID").ToString <> "" Then
                            temp.SubRefId = dbr("SUB_REF_ID")
                        End If
                        If dbr("SUB_ROUTE_ID").ToString <> "" Then
                            temp.SubRouteId = dbr("SUB_ROUTE_ID")
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
        Public Shared Function ReturnSubRouteMaster(ByVal pSubRouteMaster As SubRouteMaster) As SubRouteMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SUB_ROUTE_MASTER_BY_ID", pSubRouteMaster.SubRouteId)
                pSubRouteMaster = ReturnObjectValues(dbr, pSubRouteMaster)
                dbr.Close()
            Catch ex As Exception
                pSubRouteMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pSubRouteMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnSubRouteMasterListByRouteId(ByVal pSubRouteMaster As SubRouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrSubRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SUB_ROUTE_BY_ROUTE_ID", pSubRouteMaster.RouteId)
                arrSubRouteMaster = ReturnObjectValuesList(dbr, arrSubRouteMaster)
                dbr.Close()
            Catch ex As Exception
                arrSubRouteMaster = Nothing
            End Try
            db.CloseDB()
            Return arrSubRouteMaster
        End Function
    End Class
End Namespace
