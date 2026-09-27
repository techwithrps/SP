Imports LogiParkLib.DBConnection

Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version    : Version 1.0.0.0
    ''' @Module/Class Name          : Tracking
    ''' @author      : Amit K. Singh- 27/11/2013
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class Tracking

        Private lngTrackingId As Long ' Define Private Variable TrackingId With DataType As Long 
        Private lngVisitId As Long ' Define Private Variable CreatedBy With DataType As Long
        Private strTrainTruck As String ' Define Private Variable TrainTruck With DataType As String 
        Private strZone As String ' Define Private Variable Zone With DataType As String 
        Private strDivision As String ' Define Private Variable Division With DataType As String 
        Private strCode As String ' Define Private Variable Division With DataType As String
        Private strPositionDate As String ' Define Private Variable PositionDate With DataType As String 
        Private strCurrentPosition As String ' Define Private Variable CurrentPosition With DataType As String 
        Private strDepartureTerminal As String ' Define Private Variable DepartureTerminal With DataType As String 
        Private strDepartureDate As String ' Define Private Variable DepartureDate With DataType As String 
        Private strRoute As String ' Define Private Variable Route With DataType As String 
        Private lngPolId As Long ' Define Private Variable PolId With DataType As Long 
        Private strPol As String ' Define Private Variable Pol With DataType As String 
        Private lngPodId As Long ' Define Private Variable PodId With DataType As Long 
        Private strPod As String ' Define Private Variable Pod With DataType As String 
        Private strPortArrivalDate As String ' Define Private Variable PortArrivalDate With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strTptMode As String ' Define Private Variable CreatedBy With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 
        Private strContNo As String
        Private strLineId As String
        Private lngMtyContId As Long

        Dim arrTrackingList As ArrayList

        Public Property TrackingDetailsList() As ArrayList
            Get
                Return arrTrackingList
            End Get
            Set(ByVal value As ArrayList)
                arrTrackingList = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of TrackingId
        ''' </summary>
        ''' <value>lngTrackingId</value>
        ''' <returns> Return lngTrackingId</returns>
        ''' <remarks> Get or Set the Value of TrackingId  </remarks>
        '''
        Public Property TrackingId() As Long
            Get
                Return lngTrackingId
            End Get
            Set(ByVal value As Long)
                lngTrackingId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of VisitId
        ''' </summary>
        ''' <value>lngTrackingId</value>
        ''' <returns> Return lngTrackingId</returns>
        ''' <remarks> Get or Set the Value of TrackingId  </remarks>
        '''
        Public Property VisitId() As Long
            Get
                Return lngVisitId
            End Get
            Set(ByVal value As Long)
                lngVisitId = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TrainTruck
        ''' </summary>
        ''' <value>strTrainTruck</value>
        ''' <returns> Return strTrainTruck</returns>
        ''' <remarks> Get or Set the Value of TrainTruck  </remarks>
        '''
        Public Property TrainTruck() As String
            Get
                Return strTrainTruck
            End Get
            Set(ByVal value As String)
                strTrainTruck = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Zone
        ''' </summary>
        ''' <value>strZone</value>
        ''' <returns> Return strZone</returns>
        ''' <remarks> Get or Set the Value of Zone  </remarks>
        '''
        Public Property Zone() As String
            Get
                Return strZone
            End Get
            Set(ByVal value As String)
                strZone = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Division
        ''' </summary>
        ''' <value>strDivision</value>
        ''' <returns> Return strDivision</returns>
        ''' <remarks> Get or Set the Value of Division  </remarks>
        '''
        Public Property Division() As String
            Get
                Return strDivision
            End Get
            Set(ByVal value As String)
                strDivision = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of Division
        ''' </summary>
        ''' <value>strDivision</value>
        ''' <returns> Return strCode</returns>
        ''' <remarks> Get or Set the Value of Division  </remarks>
        '''
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal value As String)
                strCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PositionDate
        ''' </summary>
        ''' <value>strPositionDate</value>
        ''' <returns> Return strPositionDate</returns>
        ''' <remarks> Get or Set the Value of PositionDate  </remarks>
        '''
        Public Property PositionDate() As String
            Get
                Return strPositionDate
            End Get
            Set(ByVal value As String)
                strPositionDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CurrentPosition
        ''' </summary>
        ''' <value>strCurrentPosition</value>
        ''' <returns> Return strCurrentPosition</returns>
        ''' <remarks> Get or Set the Value of CurrentPosition  </remarks>
        '''
        Public Property CurrentPosition() As String
            Get
                Return strCurrentPosition
            End Get
            Set(ByVal value As String)
                strCurrentPosition = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of DepartureTerminal
        ''' </summary>
        ''' <value>strDepartureTerminal</value>
        ''' <returns> Return strDepartureTerminal</returns>
        ''' <remarks> Get or Set the Value of DepartureTerminal  </remarks>
        '''
        Public Property DepartureTerminal() As String
            Get
                Return strDepartureTerminal
            End Get
            Set(ByVal value As String)
                strDepartureTerminal = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of DepartureDate
        ''' </summary>
        ''' <value>strDepartureDate</value>
        ''' <returns> Return strDepartureDate</returns>
        ''' <remarks> Get or Set the Value of DepartureDate  </remarks>
        '''
        Public Property DepartureDate() As String
            Get
                Return strDepartureDate
            End Get
            Set(ByVal value As String)
                strDepartureDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Route
        ''' </summary>
        ''' <value>strRoute</value>
        ''' <returns> Return strRoute</returns>
        ''' <remarks> Get or Set the Value of Route  </remarks>
        '''
        Public Property Route() As String
            Get
                Return strRoute
            End Get
            Set(ByVal value As String)
                strRoute = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PolId
        ''' </summary>
        ''' <value>lngPolId</value>
        ''' <returns> Return lngPolId</returns>
        ''' <remarks> Get or Set the Value of PolId  </remarks>
        '''
        Public Property PolId() As Long
            Get
                Return lngPolId
            End Get
            Set(ByVal value As Long)
                lngPolId = value
            End Set
        End Property
        Public Property MtyContId() As Long
            Get
                Return lngMtyContId
            End Get
            Set(ByVal value As Long)
                lngMtyContId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Pol
        ''' </summary>
        ''' <value>strPol</value>
        ''' <returns> Return strPol</returns>
        ''' <remarks> Get or Set the Value of Pol  </remarks>
        '''
        Public Property Pol() As String
            Get
                Return strPol
            End Get
            Set(ByVal value As String)
                strPol = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of PodId
        ''' </summary>
        ''' <value>lngPodId</value>
        ''' <returns> Return lngPodId</returns>
        ''' <remarks> Get or Set the Value of PodId  </remarks>
        '''
        Public Property PodId() As Long
            Get
                Return lngPodId
            End Get
            Set(ByVal value As Long)
                lngPodId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of Pod
        ''' </summary>
        ''' <value>strPod</value>
        ''' <returns> Return strPod</returns>
        ''' <remarks> Get or Set the Value of Pod  </remarks>
        '''
        Public Property Pod() As String
            Get
                Return strPod
            End Get
            Set(ByVal value As String)
                strPod = value
            End Set
        End Property
        Public Property ContNo() As String
            Get
                Return strContNo
            End Get
            Set(ByVal value As String)
                strContNo = value
            End Set
        End Property
        Public Property LineId() As String
            Get
                Return strLineId
            End Get
            Set(ByVal value As String)
                strLineId = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of PortArrivalDate
        ''' </summary>
        ''' <value>strPortArrivalDate</value>
        ''' <returns> Return strPortArrivalDate</returns>
        ''' <remarks> Get or Set the Value of PortArrivalDate  </remarks>
        '''
        Public Property PortArrivalDate() As String
            Get
                Return strPortArrivalDate
            End Get
            Set(ByVal value As String)
                strPortArrivalDate = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedOn
        ''' </summary>
        ''' <value>strCreatedOn</value>
        ''' <returns> Return strCreatedOn</returns>
        ''' <remarks> Get or Set the Value of CreatedOn  </remarks>
        '''
        Public Property CreatedOn() As String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() As String
            Get
                Return strCreatedBy
            End Get
            Set(ByVal value As String)
                strCreatedBy = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of TptMode
        ''' </summary>
        ''' <value>strTptMode</value>
        ''' <returns> Return strTptMode</returns>
        ''' <remarks> Get or Set the Value of TptMode  </remarks>
        '''
        Public Property TptMode() As String
            Get
                Return strTptMode
            End Get
            Set(ByVal value As String)
                strTptMode = value
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
            lngTrackingId = 0
            lngVisitId = 0
            strTrainTruck = ""
            strZone = ""
            strDivision = ""
            strCode = ""
            strPositionDate = ""
            strCurrentPosition = ""
            strDepartureTerminal = ""
            strDepartureDate = ""
            strRoute = ""
            lngPolId = 0
            strPol = ""
            lngPodId = 0
            strPod = ""
            strPortArrivalDate = ""
            strCreatedOn = ""
            strCreatedBy = ""
            strTptMode = ""
            strContNo = ""
            strLineId = ""
            lngMtyContId = 0
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTracking"></param>
        ''' <returns>Return pTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTracking As Tracking) As Tracking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRACKING_ID", pTracking.TrackingId)
                db.AddParameter("p_VISIT_ID", pTracking.VisitId)
                db.AddParameter("p_TRAIN_TRUCK", pTracking.TrainTruck)
                db.AddParameter("p_ZONE", pTracking.Zone)
                db.AddParameter("p_DIVISION", pTracking.Division)
                db.AddParameter("p_CODE", pTracking.Code)
                db.AddParameter("p_POSITION_DATE", pTracking.PositionDate)
                db.AddParameter("p_CURRENT_POSITION", pTracking.CurrentPosition)
                db.AddParameter("p_DEPARTURE_TERMINAL", pTracking.DepartureTerminal)
                db.AddParameter("p_DEPARTURE_DATE", pTracking.DepartureDate)
                db.AddParameter("p_ROUTE", pTracking.Route)
                db.AddParameter("p_POL_ID", pTracking.PolId)
                db.AddParameter("p_POL", pTracking.Pol)
                db.AddParameter("p_POD_ID", pTracking.PodId)
                db.AddParameter("p_POD", pTracking.Pod)
                db.AddParameter("p_PORT_ARRIVAL_DATE", pTracking.PortArrivalDate)
                db.AddParameter("p_CREATED_ON", pTracking.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTracking.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTracking.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

                If pTracking.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTracking
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTracking"></param>
        ''' <returns>Return pTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTracking As Tracking) As Tracking
            Try
                db.ClearParameters()
                db.AddParameter("p_TRACKING_ID", pTracking.TrackingId)
                db.AddParameter("p_VISIT_ID", pTracking.VisitId)
                db.AddParameter("p_TRAIN_TRUCK", pTracking.TrainTruck)
                db.AddParameter("p_ZONE", pTracking.Zone)
                db.AddParameter("p_DIVISION", pTracking.Division)
                db.AddParameter("p_CODE", pTracking.Code)
                db.AddParameter("p_POSITION_DATE", pTracking.PositionDate)
                db.AddParameter("p_CURRENT_POSITION", pTracking.CurrentPosition)
                db.AddParameter("p_DEPARTURE_TERMINAL", pTracking.DepartureTerminal)
                db.AddParameter("p_DEPARTURE_DATE", pTracking.DepartureDate)
                db.AddParameter("p_ROUTE", pTracking.Route)
                db.AddParameter("p_POL_ID", pTracking.PolId)
                db.AddParameter("p_POL", pTracking.Pol)
                db.AddParameter("p_POD_ID", pTracking.PodId)
                db.AddParameter("p_POD", pTracking.Pod)
                db.AddParameter("p_PORT_ARRIVAL_DATE", pTracking.PortArrivalDate)
                db.AddParameter("p_CREATED_ON", pTracking.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTracking.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTracking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
            End Try
            Return pTracking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTracking"></param>
        ''' <returns>Return pTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTracking As Tracking) As Tracking
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TRACKING_ID", pTracking.TrackingId)
                db.AddParameter("p_VISIT_ID", pTracking.VisitId)
                db.AddParameter("p_TRAIN_TRUCK", pTracking.TrainTruck)
                db.AddParameter("p_ZONE", pTracking.Zone)
                db.AddParameter("p_DIVISION", pTracking.Division)
                db.AddParameter("p_CODE", pTracking.Code)
                db.AddParameter("p_POSITION_DATE", pTracking.PositionDate)
                db.AddParameter("p_CURRENT_POSITION", pTracking.CurrentPosition)
                db.AddParameter("p_DEPARTURE_TERMINAL", pTracking.DepartureTerminal)
                db.AddParameter("p_DEPARTURE_DATE", pTracking.DepartureDate)
                db.AddParameter("p_ROUTE", pTracking.Route)
                db.AddParameter("p_POL_ID", pTracking.PolId)
                db.AddParameter("p_POL", pTracking.Pol)
                db.AddParameter("p_POD_ID", pTracking.PodId)
                db.AddParameter("p_POD", pTracking.Pod)
                db.AddParameter("p_PORT_ARRIVAL_DATE", pTracking.PortArrivalDate)
                db.AddParameter("p_CREATED_ON", pTracking.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTracking.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTracking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTracking.ErrorMsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTracking
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTracking"></param>
        ''' <returns>Return pTracking Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTracking As Tracking) As Tracking
            Try
                db.ClearParameters()
                db.AddParameter("p_TRACKING_ID", pTracking.TrackingId)
                db.AddParameter("p_VISIT_ID", pTracking.VisitId)
                db.AddParameter("p_TRAIN_TRUCK", pTracking.TrainTruck)
                db.AddParameter("p_ZONE", pTracking.Zone)
                db.AddParameter("p_DIVISION", pTracking.Division)
                db.AddParameter("p_CODE", pTracking.Code)
                db.AddParameter("p_POSITION_DATE", pTracking.PositionDate)
                db.AddParameter("p_CURRENT_POSITION", pTracking.CurrentPosition)
                db.AddParameter("p_DEPARTURE_TERMINAL", pTracking.DepartureTerminal)
                db.AddParameter("p_DEPARTURE_DATE", pTracking.DepartureDate)
                db.AddParameter("p_ROUTE", pTracking.Route)
                db.AddParameter("p_POL_ID", pTracking.PolId)
                db.AddParameter("p_POL", pTracking.Pol)
                db.AddParameter("p_POD_ID", pTracking.PodId)
                db.AddParameter("p_POD", pTracking.Pod)
                db.AddParameter("p_PORT_ARRIVAL_DATE", pTracking.PortArrivalDate)
                db.AddParameter("p_CREATED_ON", pTracking.CreatedOn)
                db.AddParameter("p_CREATED_BY", pTracking.CreatedBy)
                db.AddParameter("p_ErrorMsg", pTracking.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TRACKING", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTracking.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
            End Try
            Return pTracking
        End Function

        Public Shared Function InsertUpdateTracking(ByVal pTracking As Tracking) As Tracking
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                For Each pTracki As Tracking In pTracking.TrackingDetailsList
                    If pTracki.TrainTruck <> Nothing Then
                        Tracking.UpdateTrn(db, pTracki)
                    End If
                Next
                db.CommitTransaction()
            Catch ex As Exception
                pTracking.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pTracking
        End Function
        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTracking As Tracking) As Tracking
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TRACKING_ID").ToString <> "" Then
                                pTracking.TrackingId = dbr("TRACKING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                pTracking.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_TRUCK").ToString <> "" Then
                                pTracking.TrainTruck = dbr("TRAIN_TRUCK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ZONE").ToString <> "" Then
                                pTracking.Zone = dbr("ZONE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION").ToString <> "" Then
                                pTracking.Division = dbr("DIVISION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CODE").ToString <> "" Then
                                pTracking.Code = dbr("CODE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("POSITION_DATE").ToString <> "" Then
                                pTracking.PositionDate = dbr("POSITION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_POSITION").ToString <> "" Then
                                pTracking.CurrentPosition = dbr("CURRENT_POSITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_TERMINAL").ToString <> "" Then
                                pTracking.DepartureTerminal = dbr("DEPARTURE_TERMINAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_DATE").ToString <> "" Then
                                pTracking.DepartureDate = dbr("DEPARTURE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROUTE").ToString <> "" Then
                                pTracking.Route = dbr("ROUTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL_ID").ToString <> "" Then
                                pTracking.PolId = dbr("POL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                pTracking.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_ID").ToString <> "" Then
                                pTracking.PodId = dbr("POD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD").ToString <> "" Then
                                pTracking.Pod = dbr("POD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ARRIVAL_DATE").ToString <> "" Then
                                pTracking.PortArrivalDate = dbr("PORT_ARRIVAL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pTracking.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pTracking.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TPT_MODE").ToString <> "" Then
                                pTracking.TptMode = dbr("TPT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                pTracking.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                pTracking.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                pTracking.MtyContId = dbr("MTY_CONT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
            End Try
            Return pTracking
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTracking As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New Tracking
                        Try
                            If dbr("TRACKING_ID").ToString <> "" Then
                                temp.TrackingId = dbr("TRACKING_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("VISIT_ID").ToString <> "" Then
                                temp.VisitId = dbr("VISIT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TRAIN_TRUCK").ToString <> "" Then
                                temp.TrainTruck = dbr("TRAIN_TRUCK")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ZONE").ToString <> "" Then
                                temp.Zone = dbr("ZONE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DIVISION").ToString <> "" Then
                                temp.Division = dbr("DIVISION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CODE").ToString <> "" Then
                                temp.Code = dbr("CODE")
                            End If
                        Catch ex1 As Exception
                        End Try

                        Try
                            If dbr("POSITION_DATE").ToString <> "" Then
                                temp.PositionDate = dbr("POSITION_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CURRENT_POSITION").ToString <> "" Then
                                temp.CurrentPosition = dbr("CURRENT_POSITION")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_TERMINAL").ToString <> "" Then
                                temp.DepartureTerminal = dbr("DEPARTURE_TERMINAL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DEPARTURE_DATE").ToString <> "" Then
                                temp.DepartureDate = dbr("DEPARTURE_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ROUTE").ToString <> "" Then
                                temp.Route = dbr("ROUTE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL_ID").ToString <> "" Then
                                temp.PolId = dbr("POL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POL").ToString <> "" Then
                                temp.Pol = dbr("POL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD_ID").ToString <> "" Then
                                temp.PodId = dbr("POD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("POD").ToString <> "" Then
                                temp.Pod = dbr("POD")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PORT_ARRIVAL_DATE").ToString <> "" Then
                                temp.PortArrivalDate = dbr("PORT_ARRIVAL_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                temp.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TPT_MODE").ToString <> "" Then
                                temp.TptMode = dbr("TPT_MODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONT_NO").ToString <> "" Then
                                temp.ContNo = dbr("CONT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ID").ToString <> "" Then
                                temp.LineId = dbr("LINE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MTY_CONT_ID").ToString <> "" Then
                                temp.MtyContId = dbr("MTY_CONT_ID")
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
        Public Shared Function ReturnTracking(ByVal pTracking As Tracking) As Tracking
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TRACKING", "' '")
                pTracking = ReturnObjectValues(dbr, pTracking)
                dbr.Close()
            Catch ex As Exception
                pTracking.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTracking
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTrackingList(ByVal pTracking As Tracking) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTracking As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TRACKING", pTracking.VisitId & ",'" & pTracking.TptMode & "'")
                arrTracking = ReturnObjectValuesList(dbr, arrTracking)
                dbr.Close()
            Catch ex As Exception
                arrTracking = Nothing
            End Try
            db.CloseDB()
            Return arrTracking
        End Function
    End Class
End Namespace
