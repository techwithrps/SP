Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: RouteMaster Class
    ''' @author	: Amit K. Singh- 10/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class RouteMaster

        Private lngRouteId As Long ' Define Private Variable RouteId DataType As Long 
        Private lngFromTerminalId As Long ' Define Private Variable FromTerminalId DataType As Long 
        Private lngToTerminalId As Long ' Define Private Variable ToTerminalId DataType As Long 
        Private lngRouteTypeId As Long ' Define Private Variable RouteTypeId DataType As Long 
        Private lngBillableDistance As Long ' Define Private Variable BillableDistance DataType As Long 
        Private lngActualDistance As Long ' Define Private Variable ActualDistance DataType As Long 
        Private strRouteName As String ' Define Private Variable RouteName DataType As String 
        Private strTrainNoPrefx As String ' Define Private Variable TrainNoPrefx DataType As String 
        Private lngBeginNo As Long ' Define Private Variable BeginNo DataType As Long 
        Private lngAverageTime As Long ' Define Private Variable AverageTime DataType As Long 
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
        ''' FromTerminalId
        ''' </summary>
        ''' <value>lngFromTerminalId</value>
        ''' <returns> Return lngFromTerminalId</returns>
        ''' <remarks></remarks>
        Public Property FromTerminalId() As Long
            Get
                Return lngFromTerminalId
            End Get
            Set(ByVal value As Long)
                lngFromTerminalId = value
            End Set
        End Property


        ''' <summary>
        ''' ToTerminalId
        ''' </summary>
        ''' <value>lngToTerminalId</value>
        ''' <returns> Return lngToTerminalId</returns>
        ''' <remarks></remarks>
        Public Property ToTerminalId() As Long
            Get
                Return lngToTerminalId
            End Get
            Set(ByVal value As Long)
                lngToTerminalId = value
            End Set
        End Property


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
        ''' BillableDistance
        ''' </summary>
        ''' <value>lngBillableDistance</value>
        ''' <returns> Return lngBillableDistance</returns>
        ''' <remarks></remarks>
        Public Property BillableDistance() As Long
            Get
                Return lngBillableDistance
            End Get
            Set(ByVal value As Long)
                lngBillableDistance = value
            End Set
        End Property


        ''' <summary>
        ''' ActualDistance
        ''' </summary>
        ''' <value>lngActualDistance</value>
        ''' <returns> Return lngActualDistance</returns>
        ''' <remarks></remarks>
        Public Property ActualDistance() As Long
            Get
                Return lngActualDistance
            End Get
            Set(ByVal value As Long)
                lngActualDistance = value
            End Set
        End Property


        ''' <summary>
        ''' RouteName
        ''' </summary>
        ''' <value>strRouteName</value>
        ''' <returns> Return strRouteName</returns>
        ''' <remarks></remarks>
        Public Property RouteName() As String
            Get
                Return strRouteName
            End Get
            Set(ByVal value As String)
                strRouteName = value
            End Set
        End Property


        ''' <summary>
        ''' TrainNoPrefx
        ''' </summary>
        ''' <value>strTrainNoPrefx</value>
        ''' <returns> Return strTrainNoPrefx</returns>
        ''' <remarks></remarks>
        Public Property TrainNoPrefx() As String
            Get
                Return strTrainNoPrefx
            End Get
            Set(ByVal value As String)
                strTrainNoPrefx = value
            End Set
        End Property


        ''' <summary>
        ''' BeginNo
        ''' </summary>
        ''' <value>lngBeginNo</value>
        ''' <returns> Return lngBeginNo</returns>
        ''' <remarks></remarks>
        Public Property BeginNo() As Long
            Get
                Return lngBeginNo
            End Get
            Set(ByVal value As Long)
                lngBeginNo = value
            End Set
        End Property


        ''' <summary>
        ''' AverageTime
        ''' </summary>
        ''' <value>lngAverageTime</value>
        ''' <returns> Return lngAverageTime</returns>
        ''' <remarks></remarks>
        Public Property AverageTime() As Long
            Get
                Return lngAverageTime
            End Get
            Set(ByVal value As Long)
                lngAverageTime = value
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
            lngFromTerminalId = 0
            lngToTerminalId = 0
            lngRouteTypeId = 0
            lngBillableDistance = 0
            lngActualDistance = 0
            strRouteName = ""
            strTrainNoPrefx = ""
            lngBeginNo = 0
            lngAverageTime = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pRouteMaster"></param>
        ''' <returns>Return pRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pRouteMaster As RouteMaster) As RouteMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pRouteMaster.RouteId, ParameterDirection.Output)
                db.AddParameter("p_FROM_TERMINAL_ID", pRouteMaster.FromTerminalId)
                db.AddParameter("p_TO_TERMINAL_ID", pRouteMaster.ToTerminalId)
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteMaster.RouteTypeId)
                db.AddParameter("p_BILLABLE_DISTANCE", pRouteMaster.BillableDistance)
                db.AddParameter("p_ACTUAL_DISTANCE", pRouteMaster.ActualDistance)
                db.AddParameter("p_ROUTE_NAME", pRouteMaster.RouteName)
                db.AddParameter("p_TRAIN_NO_PREFX", pRouteMaster.TrainNoPrefx)
                db.AddParameter("p_BEGIN_NO", pRouteMaster.BeginNo)
                db.AddParameter("p_AVERAGE_TIME", pRouteMaster.AverageTime)
                db.AddParameter("p_ErrorMsg", pRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteMaster.RouteId = db.Parameters.Item("p_ROUTE_ID").value

                If pRouteMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteMaster"></param>
        ''' <returns>Return pRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pRouteMaster As RouteMaster) As RouteMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pRouteMaster.RouteId, ParameterDirection.Output)
                db.AddParameter("p_FROM_TERMINAL_ID", pRouteMaster.FromTerminalId)
                db.AddParameter("p_TO_TERMINAL_ID", pRouteMaster.ToTerminalId)
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteMaster.RouteTypeId)
                db.AddParameter("p_BILLABLE_DISTANCE", pRouteMaster.BillableDistance)
                db.AddParameter("p_ACTUAL_DISTANCE", pRouteMaster.ActualDistance)
                db.AddParameter("p_ROUTE_NAME", pRouteMaster.RouteName)
                db.AddParameter("p_TRAIN_NO_PREFX", pRouteMaster.TrainNoPrefx)
                db.AddParameter("p_BEGIN_NO", pRouteMaster.BeginNo)
                db.AddParameter("p_AVERAGE_TIME", pRouteMaster.AverageTime)
                db.AddParameter("p_ErrorMsg", pRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pRouteMaster.RouteId = db.Parameters.Item("p_ROUTE_ID").value

            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
            End Try
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pRouteMaster"></param>
        ''' <returns>Return pRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pRouteMaster As RouteMaster) As RouteMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pRouteMaster.RouteId)
                db.AddParameter("p_FROM_TERMINAL_ID", pRouteMaster.FromTerminalId)
                db.AddParameter("p_TO_TERMINAL_ID", pRouteMaster.ToTerminalId)
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteMaster.RouteTypeId)
                db.AddParameter("p_BILLABLE_DISTANCE", pRouteMaster.BillableDistance)
                db.AddParameter("p_ACTUAL_DISTANCE", pRouteMaster.ActualDistance)
                db.AddParameter("p_ROUTE_NAME", pRouteMaster.RouteName)
                db.AddParameter("p_TRAIN_NO_PREFX", pRouteMaster.TrainNoPrefx)
                db.AddParameter("p_BEGIN_NO", pRouteMaster.BeginNo)
                db.AddParameter("p_AVERAGE_TIME", pRouteMaster.AverageTime)
                db.AddParameter("p_ErrorMsg", pRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pRouteMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pRouteMaster"></param>
        ''' <returns>Return pRouteMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pRouteMaster As RouteMaster) As RouteMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_ROUTE_ID", pRouteMaster.RouteId)
                db.AddParameter("p_FROM_TERMINAL_ID", pRouteMaster.FromTerminalId)
                db.AddParameter("p_TO_TERMINAL_ID", pRouteMaster.ToTerminalId)
                db.AddParameter("p_ROUTE_TYPE_ID", pRouteMaster.RouteTypeId)
                db.AddParameter("p_BILLABLE_DISTANCE", pRouteMaster.BillableDistance)
                db.AddParameter("p_ACTUAL_DISTANCE", pRouteMaster.ActualDistance)
                db.AddParameter("p_ROUTE_NAME", pRouteMaster.RouteName)
                db.AddParameter("p_TRAIN_NO_PREFX", pRouteMaster.TrainNoPrefx)
                db.AddParameter("p_BEGIN_NO", pRouteMaster.BeginNo)
                db.AddParameter("p_AVERAGE_TIME", pRouteMaster.AverageTime)
                db.AddParameter("p_ErrorMsg", pRouteMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_ROUTE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pRouteMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
            End Try
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pRouteMaster As RouteMaster) As RouteMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("ROUTE_ID").ToString <> "" Then
                            pRouteMaster.RouteId = dbr("ROUTE_ID")
                        End If
                        If dbr("FROM_TERMINAL_ID").ToString <> "" Then
                            pRouteMaster.FromTerminalId = dbr("FROM_TERMINAL_ID")
                        End If
                        If dbr("TO_TERMINAL_ID").ToString <> "" Then
                            pRouteMaster.ToTerminalId = dbr("TO_TERMINAL_ID")
                        End If
                        If dbr("ROUTE_TYPE_ID").ToString <> "" Then
                            pRouteMaster.RouteTypeId = dbr("ROUTE_TYPE_ID")
                        End If
                        If dbr("BILLABLE_DISTANCE").ToString <> "" Then
                            pRouteMaster.BillableDistance = dbr("BILLABLE_DISTANCE")
                        End If
                        If dbr("ACTUAL_DISTANCE").ToString <> "" Then
                            pRouteMaster.ActualDistance = dbr("ACTUAL_DISTANCE")
                        End If
                        If dbr("ROUTE_NAME").ToString <> "" Then
                            pRouteMaster.RouteName = dbr("ROUTE_NAME")
                        End If
                        If dbr("TRAIN_NO_PREFX").ToString <> "" Then
                            pRouteMaster.TrainNoPrefx = dbr("TRAIN_NO_PREFX")
                        End If
                        If dbr("MAIN_BEGIN_NO").ToString <> "" Then
                            pRouteMaster.BeginNo = dbr("MAIN_BEGIN_NO")
                        End If
                        If dbr("AVERAGE_TIME").ToString <> "" Then
                            pRouteMaster.AverageTime = dbr("AVERAGE_TIME")
                        End If
                    End While
                End If
            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
            End Try
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrRouteMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New RouteMaster
                        If dbr("ROUTE_ID").ToString <> "" Then
                            temp.RouteId = dbr("ROUTE_ID")
                        End If
                        If dbr("FROM_TERMINAL_ID").ToString <> "" Then
                            temp.FromTerminalId = dbr("FROM_TERMINAL_ID")
                        End If
                        If dbr("TO_TERMINAL_ID").ToString <> "" Then
                            temp.ToTerminalId = dbr("TO_TERMINAL_ID")
                        End If
                        If dbr("ROUTE_TYPE_ID").ToString <> "" Then
                            temp.RouteTypeId = dbr("ROUTE_TYPE_ID")
                        End If
                        If dbr("BILLABLE_DISTANCE").ToString <> "" Then
                            temp.BillableDistance = dbr("BILLABLE_DISTANCE")
                        End If
                        If dbr("ACTUAL_DISTANCE").ToString <> "" Then
                            temp.ActualDistance = dbr("ACTUAL_DISTANCE")
                        End If
                        If dbr("ROUTE_NAME").ToString <> "" Then
                            temp.RouteName = dbr("ROUTE_NAME")
                        End If
                        If dbr("TRAIN_NO_PREFX").ToString <> "" Then
                            temp.TrainNoPrefx = dbr("TRAIN_NO_PREFX")
                        End If
                        If dbr("MAIN_BEGIN_NO").ToString <> "" Then
                            temp.BeginNo = dbr("MAIN_BEGIN_NO")
                        End If
                        If dbr("AVERAGE_TIME").ToString <> "" Then
                            temp.AverageTime = dbr("AVERAGE_TIME")
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
        Public Shared Function ReturnRouteMaster(ByVal pRouteMaster As RouteMaster) As RouteMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MASTER_BY_ID", pRouteMaster.RouteId)
                pRouteMaster = ReturnObjectValues(dbr, pRouteMaster)
                dbr.Close()
            Catch ex As Exception
                pRouteMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pRouteMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnRouteMasterListIn(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MASTER_BY_IN", pRouteMaster.ToTerminalId)
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
        Public Shared Function ReturnRouteMasterList(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MASTER_BY_ALL", "' '")
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
        Public Shared Function ReturnRouteMasterListOut(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_MASTER_BY_OUT", pRouteMaster.FromTerminalId)
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
        Public Shared Function ReturnRouteMasterListRouteName(ByVal pRouteMaster As RouteMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrRouteMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_ROUTE_STATION", " ")
                arrRouteMaster = ReturnObjectValuesList(dbr, arrRouteMaster)
                dbr.Close()
            Catch ex As Exception
                arrRouteMaster = Nothing
            End Try
            db.CloseDB()
            Return arrRouteMaster
        End Function
    End Class
End Namespace
