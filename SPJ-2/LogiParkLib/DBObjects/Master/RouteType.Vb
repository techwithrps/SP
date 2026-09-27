Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  RFS :: Rail Freight System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RouteType Class
    ''' @author	: Amit K. Singh- 10/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class RouteType

        Private lngRouteTypeId As Long ' Define Private Variable RouteTypeId DataType As Long 
        Private strRouteTypeName As String ' Define Private Variable RouteTypeName DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' RouteTypeId
        ''' </summary>
        ''' <value>lngRouteTypeId</value>
        ''' <returns> Return lngRouteTypeId</returns>
        ''' <remarks></remarks>
        Public Property RouteTypeId() As Long
            Get
                Return lngRouteTypeId
            End Get
            Set(ByVal value As Long)
                lngRouteTypeId = value
            End Set
        End Property


        ''' <summary>
        ''' RouteTypeName
        ''' </summary>
        ''' <value>strRouteTypeName</value>
        ''' <returns> Return strRouteTypeName</returns>
        ''' <remarks></remarks>
        Public Property RouteTypeName() As String
            Get
                Return strRouteTypeName
            End Get
            Set(ByVal value As String)
                strRouteTypeName = value
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
            lngRouteTypeId = 0
            strRouteTypeName = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRouteType"></param>
        ''' <returns>Return pRouteType Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pRouteType As RouteType) As RouteType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteType.RouteTypeId, ParameterDirection.Output)
                db.AddParameter("p_ROUTE_TYPE_NAME", pRouteType.RouteTypeName)
                db.AddParameter("p_ErrorMsg", pRouteType.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteType.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteType.RouteTypeId = db.Parameters.Item("p_ROUTE_TYPE_ID").value

                If pRouteType.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteType"></param>
        ''' <returns>Return pRouteType Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRouteType As RouteType) As RouteType
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteType.RouteTypeId, ParameterDirection.Output)
                db.AddParameter("p_ROUTE_TYPE_NAME", pRouteType.RouteTypeName)
                db.AddParameter("p_ErrorMsg", pRouteType.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteType.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteType.RouteTypeId = db.Parameters.Item("p_ROUTE_TYPE_ID").value

            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
            End Try
            Return pRouteType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRouteType"></param>
        ''' <returns>Return pRouteType Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pRouteType As RouteType) As RouteType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteType.RouteTypeId)
                db.AddParameter("p_ROUTE_TYPE_NAME", pRouteType.RouteTypeName)
                db.AddParameter("p_ErrorMsg", pRouteType.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteType.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRouteType.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteType"></param>
        ''' <returns>Return pRouteType Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRouteType As RouteType) As RouteType
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteType.RouteTypeId)
                db.AddParameter("p_ROUTE_TYPE_NAME", pRouteType.RouteTypeName)
                db.AddParameter("p_ErrorMsg", pRouteType.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteType.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
            End Try
            Return pRouteType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRouteType As RouteType) As RouteType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("ROUTE_TYPE_ID").ToString <> "" Then
                            pRouteType.RouteTypeId = dbr("ROUTE_TYPE_ID")
                        End If
                        If dbr("ROUTE_TYPE_NAME").ToString <> "" Then
                            pRouteType.RouteTypeName = dbr("ROUTE_TYPE_NAME")
                        End If
                    End While
                End If
            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
            End Try
            Return pRouteType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRouteType As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RouteType
                        If dbr("ROUTE_TYPE_ID").ToString <> "" Then
                            temp.RouteTypeId = dbr("ROUTE_TYPE_ID")
                        End If
                        If dbr("ROUTE_TYPE_NAME").ToString <> "" Then
                            temp.RouteTypeName = dbr("ROUTE_TYPE_NAME")
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
        Public Shared Function ReturnRouteType(ByVal pRouteType As RouteType) As RouteType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_TYPE_BY_ID", pRouteType.RouteTypeId)
                pRouteType = ReturnObjectValues(dbr, pRouteType)
                dbr.Close()
            Catch ex As Exception
                pRouteType.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRouteType
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRouteTypeList(ByVal pRouteType As RouteType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_TYPE_BY_ALL", " ")
                arrRouteType = ReturnObjectValuesList(dbr, arrRouteType)
                dbr.Close()
            Catch ex As Exception
                arrRouteType = Nothing
            End Try
            db.CloseDB()
            Return arrRouteType
        End Function
    End Class
End Namespace
