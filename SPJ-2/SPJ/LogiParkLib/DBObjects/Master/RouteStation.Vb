Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: RouteStation
    ''' @author	: Santosh Singh- 16/5/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class RouteStation

        Private lngStationRefId As Long ' Define Private Variable StationRefId With DataType As Long 
        Private lngRouteId As Long ' Define Private Variable RouteId With DataType As Long 
        Private lngOrigin As Long ' Define Private Variable Origin With DataType As Long 
        Private lngDestination As Long ' Define Private Variable Destination With DataType As Long 
        Private strStationCode As String ' Define Private Variable StationCode With DataType As String 
        Private lngDistanceOrigin As Double  ' Define Private Variable DistanceOrigin With DataType As Long 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

        Dim arrRouteDetailsList As ArrayList

        Public Property RouteDetailsList() As ArrayList
            Get
                Return arrRouteDetailsList
            End Get
            Set(ByVal value As ArrayList)
                arrRouteDetailsList = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of StationRefId
        ''' </summary>
        ''' <value>lngStationRefId</value>
        ''' <returns> Return lngStationRefId</returns>
        ''' <remarks> Get or Set the Value of StationRefId  </remarks>
        '''
        Public Property StationRefId() As Long
            Get
                Return lngStationRefId
            End Get
            Set(ByVal value As Long)
                lngStationRefId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of RouteId
        ''' </summary>
        ''' <value>lngRouteId</value>
        ''' <returns> Return lngRouteId</returns>
        ''' <remarks> Get or Set the Value of RouteId  </remarks>
        '''
        Public Property RouteId() As Long
            Get
                Return lngRouteId
            End Get
            Set(ByVal value As Long)
                lngRouteId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Origin
        ''' </summary>
        ''' <value>lngOrigin</value>
        ''' <returns> Return lngOrigin</returns>
        ''' <remarks> Get or Set the Value of Origin  </remarks>
        '''
        Public Property Origin() As Long
            Get
                Return lngOrigin
            End Get
            Set(ByVal value As Long)
                lngOrigin = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Destination
        ''' </summary>
        ''' <value>lngDestination</value>
        ''' <returns> Return lngDestination</returns>
        ''' <remarks> Get or Set the Value of Destination  </remarks>
        '''
        Public Property Destination() As Long
            Get
                Return lngDestination
            End Get
            Set(ByVal value As Long)
                lngDestination = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of StationCode
        ''' </summary>
        ''' <value>strStationCode</value>
        ''' <returns> Return strStationCode</returns>
        ''' <remarks> Get or Set the Value of StationCode  </remarks>
        '''
        Public Property StationCode() As String
            Get
                Return strStationCode
            End Get
            Set(ByVal value As String)
                strStationCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DistanceOrigin
        ''' </summary>
        ''' <value>lngDistanceOrigin</value>
        ''' <returns> Return lngDistanceOrigin</returns>
        ''' <remarks> Get or Set the Value of DistanceOrigin  </remarks>
        '''
        Public Property DistanceOrigin() As Double
            Get
                Return lngDistanceOrigin
            End Get
            Set(ByVal value As Double)
                lngDistanceOrigin = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
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
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngStationRefId = 0
            lngRouteId = 0
            lngOrigin = 0
            lngDestination = 0
            strStationCode = ""
            lngDistanceOrigin = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRouteStation"></param>
        ''' <returns>Return pRouteStation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pRouteStation As RouteStation) As RouteStation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_STATION_REF_ID", pRouteStation.StationRefId, ParameterDirection.Output)
                db.AddParameter("p_ROUTE_ID", pRouteStation.RouteId)
                db.AddParameter("p_ORIGIN", pRouteStation.Origin)
                db.AddParameter("p_DESTINATION", pRouteStation.Destination)
                db.AddParameter("p_STATION_CODE", pRouteStation.StationCode)
                db.AddParameter("p_DISTANCE_ORIGIN", pRouteStation.DistanceOrigin)
                db.AddParameter("p_ErrorMsg", pRouteStation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_STATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteStation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteStation.StationRefId = db.Parameters.Item("p_STATION_REF_ID").value

                If pRouteStation.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteStation"></param>
        ''' <returns>Return pRouteStation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRouteStation As RouteStation) As RouteStation
            Try
                db.ClearParameters()
                db.AddParameter("p_STATION_REF_ID", pRouteStation.StationRefId, ParameterDirection.Output)
                db.AddParameter("p_ROUTE_ID", pRouteStation.RouteId)
                db.AddParameter("p_ORIGIN", pRouteStation.Origin)
                db.AddParameter("p_DESTINATION", pRouteStation.Destination)
                db.AddParameter("p_STATION_CODE", pRouteStation.StationCode)
                db.AddParameter("p_DISTANCE_ORIGIN", pRouteStation.DistanceOrigin)
                db.AddParameter("p_ErrorMsg", pRouteStation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_STATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteStation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteStation.StationRefId = db.Parameters.Item("p_STATION_REF_ID").value

            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
            End Try
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRouteStation"></param>
        ''' <returns>Return pRouteStation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pRouteStation As RouteStation) As RouteStation
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_STATION_REF_ID", pRouteStation.StationRefId)
                db.AddParameter("p_ROUTE_ID", pRouteStation.RouteId)
                db.AddParameter("p_ORIGIN", pRouteStation.Origin)
                db.AddParameter("p_DESTINATION", pRouteStation.Destination)
                db.AddParameter("p_STATION_CODE", pRouteStation.StationCode)
                db.AddParameter("p_DISTANCE_ORIGIN", pRouteStation.DistanceOrigin)
                db.AddParameter("p_ErrorMsg", pRouteStation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_STATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteStation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRouteStation.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteStation"></param>
        ''' <returns>Return pRouteStation Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRouteStation As RouteStation) As RouteStation
            Try
                db.ClearParameters()
                db.AddParameter("p_STATION_REF_ID", pRouteStation.StationRefId)
                db.AddParameter("p_ROUTE_ID", pRouteStation.RouteId)
                db.AddParameter("p_ORIGIN", pRouteStation.Origin)
                db.AddParameter("p_DESTINATION", pRouteStation.Destination)
                db.AddParameter("p_STATION_CODE", pRouteStation.StationCode)
                db.AddParameter("p_DISTANCE_ORIGIN", pRouteStation.DistanceOrigin)
                db.AddParameter("p_ErrorMsg", pRouteStation.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_STATION", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteStation.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
            End Try
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRouteStation As RouteStation) As RouteStation
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("STATION_REF_ID").ToString <> "" Then
                                pRouteStation.StationRefId = dbr("STATION_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROUTE_ID").ToString <> "" Then
                                pRouteStation.RouteId = dbr("ROUTE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ORIGIN").ToString <> "" Then
                                pRouteStation.Origin = dbr("ORIGIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESTINATION").ToString <> "" Then
                                pRouteStation.Destination = dbr("DESTINATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATION_CODE").ToString <> "" Then
                                pRouteStation.StationCode = dbr("STATION_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE_ORIGIN").ToString <> "" Then
                                pRouteStation.DistanceOrigin = dbr("DISTANCE_ORIGIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
            End Try
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRouteStation As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RouteStation
                        Try
                            If dbr("STATION_REF_ID").ToString <> "" Then
                                temp.StationRefId = dbr("STATION_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROUTE_ID").ToString <> "" Then
                                temp.RouteId = dbr("ROUTE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ORIGIN").ToString <> "" Then
                                temp.Origin = dbr("ORIGIN")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESTINATION").ToString <> "" Then
                                temp.Destination = dbr("DESTINATION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("STATION_CODE").ToString <> "" Then
                                temp.StationCode = dbr("STATION_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DISTANCE_ORIGIN").ToString <> "" Then
                                temp.DistanceOrigin = dbr("DISTANCE_ORIGIN")
                            End If
                        Catch ex1 As Exception
                        End Try
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
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnRouteStation(ByVal pRouteStation As RouteStation) As RouteStation
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_STATION_BY_ID", pRouteStation.RouteId)
                pRouteStation = ReturnObjectValues(dbr, pRouteStation)
                dbr.Close()
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRouteStation
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnRouteStationList(ByVal pRouteStation As RouteStation) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteStation As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_STATION_BY_ID", pRouteStation.RouteId)
                arrRouteStation = ReturnObjectValuesList(dbr, arrRouteStation)
                dbr.Close()
            Catch ex As Exception
                arrRouteStation = Nothing
            End Try
            db.CloseDB()
            Return arrRouteStation
        End Function
        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function InsertUpdateDetails(ByVal pRouteStation As RouteStation) As RouteStation
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each rs As RouteStation In pRouteStation.RouteDetailsList
                    If rs.StationRefId > 0 Then
                        RouteStation.UpdateTrn(db, rs)
                    Else
                        RouteStation.InsertTrn(db, rs)
                    End If

                    If rs.Errormsg <> "" Then
                        Throw New Exception(rs.Errormsg)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pRouteStation.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception

                End Try
                ' Rollback the transaction if any 
            End Try
            Return pRouteStation
        End Function

    End Class
End Namespace
