Imports LogiParkLib.DBConnection

Namespace LogiParkObjects
    ''' <summary>
    ''' @Project/Product Name:  RFS :: Rail Freight System 
    ''' @Version	: Version 1.0
    ''' @Module/Class Name	: TdsMaster Class
    ''' @author	: Amit K. Singh- 24/8/2011
    ''' </summary>
    ''' <remarks> </remarks>
    Public Class TdsMaster

        Private strTdsCode As String ' Define Private Variable TdsCode DataType As String 
        Private strTdsDescription As String ' Define Private Variable TdsDescription DataType As String 
        Private lngTdsPercentage As Long ' Define Private Variable TdsPercentage DataType As Long 
        Private strExemptCode As String ' Define Private Variable ExemptCode DataType As String 
        Private lngExemptPercentage As Long ' Define Private Variable ExemptPercentage DataType As Long 
        Private strExemptResion As String ' Define Private Variable ExemptResion DataType As String 
        Private strExemptFrom As String ' Define Private Variable ExemptFrom DataType As String 
        Private strExemptTo As String ' Define Private Variable ExemptTo DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg DataType As String 


        ''' <summary>
        ''' TdsCode
        ''' </summary>
        ''' <value>strTdsCode</value>
        ''' <returns> Return strTdsCode</returns>
        ''' <remarks></remarks>
        Public Property TdsCode() As String
            Get
                Return strTdsCode
            End Get
            Set(ByVal value As String)
                strTdsCode = value
            End Set
        End Property


        ''' <summary>
        ''' TdsDescription
        ''' </summary>
        ''' <value>strTdsDescription</value>
        ''' <returns> Return strTdsDescription</returns>
        ''' <remarks></remarks>
        Public Property TdsDescription() As String
            Get
                Return strTdsDescription
            End Get
            Set(ByVal value As String)
                strTdsDescription = value
            End Set
        End Property


        ''' <summary>
        ''' TdsPercentage
        ''' </summary>
        ''' <value>lngTdsPercentage</value>
        ''' <returns> Return lngTdsPercentage</returns>
        ''' <remarks></remarks>
        Public Property TdsPercentage() As Long
            Get
                Return lngTdsPercentage
            End Get
            Set(ByVal value As Long)
                lngTdsPercentage = value
            End Set
        End Property


        ''' <summary>
        ''' ExemptCode
        ''' </summary>
        ''' <value>strExemptCode</value>
        ''' <returns> Return strExemptCode</returns>
        ''' <remarks></remarks>
        Public Property ExemptCode() As String
            Get
                Return strExemptCode
            End Get
            Set(ByVal value As String)
                strExemptCode = value
            End Set
        End Property


        ''' <summary>
        ''' ExemptPercentage
        ''' </summary>
        ''' <value>lngExemptPercentage</value>
        ''' <returns> Return lngExemptPercentage</returns>
        ''' <remarks></remarks>
        Public Property ExemptPercentage() As Long
            Get
                Return lngExemptPercentage
            End Get
            Set(ByVal value As Long)
                lngExemptPercentage = value
            End Set
        End Property


        ''' <summary>
        ''' ExemptResion
        ''' </summary>
        ''' <value>strExemptResion</value>
        ''' <returns> Return strExemptResion</returns>
        ''' <remarks></remarks>
        Public Property ExemptResion() As String
            Get
                Return strExemptResion
            End Get
            Set(ByVal value As String)
                strExemptResion = value
            End Set
        End Property


        ''' <summary>
        ''' ExemptFrom
        ''' </summary>
        ''' <value>strExemptFrom</value>
        ''' <returns> Return strExemptFrom</returns>
        ''' <remarks></remarks>
        Public Property ExemptFrom() As String
            Get
                Return strExemptFrom
            End Get
            Set(ByVal value As String)
                strExemptFrom = value
            End Set
        End Property


        ''' <summary>
        ''' ExemptTo
        ''' </summary>
        ''' <value>strExemptTo</value>
        ''' <returns> Return strExemptTo</returns>
        ''' <remarks></remarks>
        Public Property ExemptTo() As String
            Get
                Return strExemptTo
            End Get
            Set(ByVal value As String)
                strExemptTo = value
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
            strTdsCode = ""
            strTdsDescription = ""
            lngTdsPercentage = 0
            strExemptCode = ""
            lngExemptPercentage = 0
            strExemptResion = ""
            strExemptFrom = ""
            strExemptTo = ""
            strErrormsg = ""
        End Sub

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTdsMaster"></param>
        ''' <returns>Return pTdsMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Insert(ByVal pTdsMaster As TdsMaster) As TdsMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TDS_CODE", pTdsMaster.TdsCode, ParameterDirection.Output)
                db.AddParameter("p_TDS_DESCRIPTION", pTdsMaster.TdsDescription)
                db.AddParameter("p_TDS_PERCENTAGE", pTdsMaster.TdsPercentage)
                db.AddParameter("p_EXEMPT_CODE", pTdsMaster.ExemptCode)
                db.AddParameter("p_EXEMPT_PERCENTAGE", pTdsMaster.ExemptPercentage)
                db.AddParameter("p_EXEMPT_RESION", pTdsMaster.ExemptResion)
                db.AddParameter("p_EXEMPT_FROM", pTdsMaster.ExemptFrom)
                db.AddParameter("p_EXEMPT_TO", pTdsMaster.ExemptTo)
                db.AddParameter("p_ErrorMsg", pTdsMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TDS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTdsMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTdsMaster.TdsCode = db.Parameters.Item("p_TDS_CODE").value

                If pTdsMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTdsMaster"></param>
        ''' <returns>Return pTdsMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTdsMaster As TdsMaster) As TdsMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TDS_CODE", pTdsMaster.TdsCode, ParameterDirection.Output)
                db.AddParameter("p_TDS_DESCRIPTION", pTdsMaster.TdsDescription)
                db.AddParameter("p_TDS_PERCENTAGE", pTdsMaster.TdsPercentage)
                db.AddParameter("p_EXEMPT_CODE", pTdsMaster.ExemptCode)
                db.AddParameter("p_EXEMPT_PERCENTAGE", pTdsMaster.ExemptPercentage)
                db.AddParameter("p_EXEMPT_RESION", pTdsMaster.ExemptResion)
                db.AddParameter("p_EXEMPT_FROM", pTdsMaster.ExemptFrom)
                db.AddParameter("p_EXEMPT_TO", pTdsMaster.ExemptTo)
                db.AddParameter("p_ErrorMsg", pTdsMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TDS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTdsMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTdsMaster.TdsCode = db.Parameters.Item("p_TDS_CODE").value

            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
            End Try
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTdsMaster"></param>
        ''' <returns>Return pTdsMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function Update(ByVal pTdsMaster As TdsMaster) As TdsMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TDS_CODE", pTdsMaster.TdsCode)
                db.AddParameter("p_TDS_DESCRIPTION", pTdsMaster.TdsDescription)
                db.AddParameter("p_TDS_PERCENTAGE", pTdsMaster.TdsPercentage)
                db.AddParameter("p_EXEMPT_CODE", pTdsMaster.ExemptCode)
                db.AddParameter("p_EXEMPT_PERCENTAGE", pTdsMaster.ExemptPercentage)
                db.AddParameter("p_EXEMPT_RESION", pTdsMaster.ExemptResion)
                db.AddParameter("p_EXEMPT_FROM", pTdsMaster.ExemptFrom)
                db.AddParameter("p_EXEMPT_TO", pTdsMaster.ExemptTo)
                db.AddParameter("p_ErrorMsg", pTdsMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TDS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTdsMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTdsMaster.Errormsg <> Nothing Then
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTdsMaster"></param>
        ''' <returns>Return pTdsMaster Object</returns>
        ''' <remarks></remarks>
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTdsMaster As TdsMaster) As TdsMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TDS_CODE", pTdsMaster.TdsCode)
                db.AddParameter("p_TDS_DESCRIPTION", pTdsMaster.TdsDescription)
                db.AddParameter("p_TDS_PERCENTAGE", pTdsMaster.TdsPercentage)
                db.AddParameter("p_EXEMPT_CODE", pTdsMaster.ExemptCode)
                db.AddParameter("p_EXEMPT_PERCENTAGE", pTdsMaster.ExemptPercentage)
                db.AddParameter("p_EXEMPT_RESION", pTdsMaster.ExemptResion)
                db.AddParameter("p_EXEMPT_FROM", pTdsMaster.ExemptFrom)
                db.AddParameter("p_EXEMPT_TO", pTdsMaster.ExemptTo)
                db.AddParameter("p_ErrorMsg", pTdsMaster.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TDS_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTdsMaster.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
            End Try
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        Public Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTdsMaster As TdsMaster) As TdsMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        If dbr("TDS_CODE").ToString <> "" Then
                            pTdsMaster.TdsCode = dbr("TDS_CODE")
                        End If
                        If dbr("TDS_DESCRIPTION").ToString <> "" Then
                            pTdsMaster.TdsDescription = dbr("TDS_DESCRIPTION")
                        End If
                        If dbr("TDS_PERCENTAGE").ToString <> "" Then
                            pTdsMaster.TdsPercentage = dbr("TDS_PERCENTAGE")
                        End If
                        If dbr("EXEMPT_CODE").ToString <> "" Then
                            pTdsMaster.ExemptCode = dbr("EXEMPT_CODE")
                        End If
                        If dbr("EXEMPT_PERCENTAGE").ToString <> "" Then
                            pTdsMaster.ExemptPercentage = dbr("EXEMPT_PERCENTAGE")
                        End If
                        If dbr("EXEMPT_RESION").ToString <> "" Then
                            pTdsMaster.ExemptResion = dbr("EXEMPT_RESION")
                        End If
                        If dbr("EXEMPT_FROM").ToString <> "" Then
                            pTdsMaster.ExemptFrom = dbr("EXEMPT_FROM")
                        End If
                        If dbr("EXEMPT_TO").ToString <> "" Then
                            pTdsMaster.ExemptTo = dbr("EXEMPT_TO")
                        End If
                    End While
                End If
            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
            End Try
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTdsMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TdsMaster
                        If dbr("TDS_CODE").ToString <> "" Then
                            temp.TdsCode = dbr("TDS_CODE")
                        End If
                        If dbr("TDS_DESCRIPTION").ToString <> "" Then
                            temp.TdsDescription = dbr("TDS_DESCRIPTION")
                        End If
                        If dbr("TDS_PERCENTAGE").ToString <> "" Then
                            temp.TdsPercentage = dbr("TDS_PERCENTAGE")
                        End If
                        If dbr("EXEMPT_CODE").ToString <> "" Then
                            temp.ExemptCode = dbr("EXEMPT_CODE")
                        End If
                        If dbr("EXEMPT_PERCENTAGE").ToString <> "" Then
                            temp.ExemptPercentage = dbr("EXEMPT_PERCENTAGE")
                        End If
                        If dbr("EXEMPT_RESION").ToString <> "" Then
                            temp.ExemptResion = dbr("EXEMPT_RESION")
                        End If
                        If dbr("EXEMPT_FROM").ToString <> "" Then
                            temp.ExemptFrom = dbr("EXEMPT_FROM")
                        End If
                        If dbr("EXEMPT_TO").ToString <> "" Then
                            temp.ExemptTo = dbr("EXEMPT_TO")
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
        Public Shared Function ReturnTdsMaster(ByVal pTdsMaster As TdsMaster) As TdsMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TDS_MASTER_BY_ID", "'" & pTdsMaster.TdsCode & "'")
                pTdsMaster = ReturnObjectValues(dbr, pTdsMaster)
                dbr.Close()
            Catch ex As Exception
                pTdsMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTdsMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnTdsMasterList(ByVal pTdsMaster As TdsMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTdsMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TDS_MASTER_BY_ALL", " ")
                arrTdsMaster = ReturnObjectValuesList(dbr, arrTdsMaster)
                dbr.Close()
            Catch ex As Exception
                arrTdsMaster = Nothing
            End Try
            db.CloseDB()
            Return arrTdsMaster
        End Function
    End Class
End Namespace
