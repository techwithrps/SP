Imports LogiParkLib.DBConnection
Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  SAS :: Terminal Management System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: BreakVanMaster Class
    ''' @author	: Amit K. Singh- 9/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class BreakVanMaster

        Private lngBVId As Long ' Define Private Variable BVId With DataType As Long 
        Private strBVNo As String ' Define Private Variable BVNo With DataType As String 
        Private lngBVOwner As Long ' Define Private Variable BVOwner With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strAllotedStatus As String ' Define Private Variable AlllotedStatus With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 


        ''' <summary>
        ''' Get or Set the Value of BVId
        ''' </summary>
        ''' <value>lngBVId</value>
        ''' <returns> Return lngBVId</returns>
        ''' <remarks> Get or Set the Value of BVId  </remarks>
        '''
        Public Property BVId() As Long
            Get
                Return lngBVId
            End Get
            Set(ByVal value As Long)
                lngBVId = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BVNo
        ''' </summary>
        ''' <value>lngBVNo</value>
        ''' <returns> Return lngBVNo</returns>
        ''' <remarks> Get or Set the Value of BVNo  </remarks>
        '''
        Public Property BVNo() As String
            Get
                Return strBVNo
            End Get
            Set(ByVal value As String)
                strBVNo = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of BVOwner
        ''' </summary>
        ''' <value>lngBVOwner</value>
        ''' <returns> Return lngBVOwner</returns>
        ''' <remarks> Get or Set the Value of BVOwner  </remarks>
        '''
        Public Property BVOwner() As Long
            Get
                Return lngBVOwner
            End Get
            Set(ByVal value As Long)
                lngBVOwner = value
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
        ''' Get or Set the Value of AllotedStatus
        ''' </summary>
        ''' <value>strAllotedStatus</value>
        ''' <returns> Return strAllotedStatus</returns>
        ''' <remarks> Get or Set the Value of  Status</remarks>
        '''
        Public Property AllotedStatus() As String
            Get
                Return strAllotedStatus
            End Get
            Set(ByVal value As String)
                strAllotedStatus = value
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
            lngBVId = 0
            strBVNo = ""
            lngBVOwner = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strAllotedStatus = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pBreakVanMaster"></param>
        ''' <returns>Return pBreakVanMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_B_V_ID", pBreakVanMaster.BVId, ParameterDirection.Output)
                db.AddParameter("p_B_V_NO", pBreakVanMaster.BVNo)
                db.AddParameter("p_B_V_OWNER", pBreakVanMaster.BVOwner)
                db.AddParameter("p_CREATED_BY", pBreakVanMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBreakVanMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBreakVanMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_BREAK_VAN_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBreakVanMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pBreakVanMaster.BVId = db.Parameters.Item("p_B_V_ID").value

                If pBreakVanMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pBreakVanMaster"></param>
        ''' <returns>Return pBreakVanMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_B_V_ID", pBreakVanMaster.BVId, ParameterDirection.Output)
                db.AddParameter("p_B_V_NO", pBreakVanMaster.BVNo)
                db.AddParameter("p_B_V_OWNER", pBreakVanMaster.BVOwner)
                db.AddParameter("p_CREATED_BY", pBreakVanMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBreakVanMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBreakVanMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_BREAK_VAN_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBreakVanMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pBreakVanMaster.BVId = db.Parameters.Item("p_B_V_ID").value

            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
            End Try
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pBreakVanMaster"></param>
        ''' <returns>Return pBreakVanMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_B_V_ID", pBreakVanMaster.BVId)
                db.AddParameter("p_B_V_NO", pBreakVanMaster.BVNo)
                db.AddParameter("p_B_V_OWNER", pBreakVanMaster.BVOwner)
                db.AddParameter("p_CREATED_BY", pBreakVanMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBreakVanMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBreakVanMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_BREAK_VAN_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBreakVanMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pBreakVanMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pBreakVanMaster"></param>
        ''' <returns>Return pBreakVanMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_B_V_ID", pBreakVanMaster.BVId)
                db.AddParameter("p_B_V_NO", pBreakVanMaster.BVNo)
                db.AddParameter("p_B_V_OWNER", pBreakVanMaster.BVOwner)
                db.AddParameter("p_CREATED_BY", pBreakVanMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBreakVanMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBreakVanMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_BREAK_VAN_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBreakVanMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
            End Try
            Return pBreakVanMaster
        End Function
        ''' <summary>
        ''' Update Member Function to Update the Record Alloted_Status
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pBreakVanMaster"></param>
        ''' <returns>Return pBreakVanMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrnStatus(ByVal db As DBConnect, ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_B_V_ID", pBreakVanMaster.BVId)
                db.AddParameter("p_B_V_NO", pBreakVanMaster.BVNo)
                db.AddParameter("p_B_V_OWNER", pBreakVanMaster.BVOwner)
                db.AddParameter("p_CREATED_BY", pBreakVanMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBreakVanMaster.CreatedOn)
                db.AddParameter("p_ALLOTED_STATUS", pBreakVanMaster.AllotedStatus)
                db.AddParameter("p_ErrorMsg", pBreakVanMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_BREAK_VAN_MASTER_STATUS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBreakVanMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
            End Try
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("B_V_ID").ToString <> "" Then
                                pBreakVanMaster.BVId = dbr("B_V_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("B_V_NO").ToString <> "" Then
                                pBreakVanMaster.BVNo = dbr("B_V_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("B_V_OWNER").ToString <> "" Then
                                pBreakVanMaster.BVOwner = dbr("B_V_OWNER")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pBreakVanMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pBreakVanMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOTED_STATUS").ToString <> "" Then
                                pBreakVanMaster.AllotedStatus = dbr("ALLOTED_STATUS")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
            End Try
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrBreakVanMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New BreakVanMaster
                        Try
                            If dbr("B_V_ID").ToString <> "" Then
                                temp.BVId = dbr("B_V_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("B_V_NO").ToString <> "" Then
                                temp.BVNo = dbr("B_V_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("B_V_OWNER").ToString <> "" Then
                                temp.BVOwner = dbr("B_V_OWNER")
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
                            If dbr("CREATED_ON").ToString <> "" Then
                                temp.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ALLOTED_STATUS").ToString <> "" Then
                                temp.AllotedStatus = dbr("ALLOTED_STATUS")
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
        Public Shared Function ReturnBreakVanMaster(ByVal pBreakVanMaster As BreakVanMaster) As BreakVanMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_BREAK_VAN_MASTER_BY_ID", pBreakVanMaster.BVId)
                pBreakVanMaster = ReturnObjectValues(dbr, pBreakVanMaster)
                dbr.Close()
            Catch ex As Exception
                pBreakVanMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pBreakVanMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnBreakVanMasterList(ByVal pBreakVanMaster As BreakVanMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrBreakVanMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_BREAK_VAN_MASTER_ALL", "' '")
                arrBreakVanMaster = ReturnObjectValuesList(dbr, arrBreakVanMaster)
                dbr.Close()
            Catch ex As Exception
                arrBreakVanMaster = Nothing
            End Try
            db.CloseDB()
            Return arrBreakVanMaster
        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnBreakVanMasterListAlloted(ByVal pBreakVanMaster As BreakVanMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrBreakVanMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_BREAK_VAN_MASTER_ALLOTED", "' '")
                arrBreakVanMaster = ReturnObjectValuesList(dbr, arrBreakVanMaster)
                dbr.Close()
            Catch ex As Exception
                arrBreakVanMaster = Nothing
            End Try
            db.CloseDB()
            Return arrBreakVanMaster
        End Function
    End Class
End Namespace
