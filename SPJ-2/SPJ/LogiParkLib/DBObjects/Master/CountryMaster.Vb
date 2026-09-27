Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CountryMaster
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CountryMaster 
    
        Private lngCountryId As Long ' Define Private Variable CountryId With DataType As Long 
        Private strCountryCode As String ' Define Private Variable CountryCode With DataType As String 
        Private strCountryName As String ' Define Private Variable CountryName With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of CountryId
        ''' </summary>
        ''' <value>lngCountryId</value>
        ''' <returns> Return lngCountryId</returns>
        ''' <remarks> Get or Set the Value of CountryId  </remarks>
        '''
        Public Property CountryId() as Long
            Get
                Return lngCountryId
            End Get
            Set(ByVal value As Long)
                lngCountryId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CountryCode
        ''' </summary>
        ''' <value>strCountryCode</value>
        ''' <returns> Return strCountryCode</returns>
        ''' <remarks> Get or Set the Value of CountryCode  </remarks>
        '''
        Public Property CountryCode() as String
            Get
                Return strCountryCode
            End Get
            Set(ByVal value As String)
                strCountryCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CountryName
        ''' </summary>
        ''' <value>strCountryName</value>
        ''' <returns> Return strCountryName</returns>
        ''' <remarks> Get or Set the Value of CountryName  </remarks>
        '''
        Public Property CountryName() as String
            Get
                Return strCountryName
            End Get
            Set(ByVal value As String)
                strCountryName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Errormsg
        ''' </summary>
        ''' <value>strErrormsg</value>
        ''' <returns> Return strErrormsg</returns>
        ''' <remarks> Get or Set the Value of Errormsg  </remarks>
        '''
        Public Property Errormsg() as String
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
            lngCountryId = 0 
            strCountryCode = ""
            strCountryName = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCountryMaster"></param>
        ''' <returns>Return pCountryMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCountryMaster As CountryMaster) As CountryMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COUNTRY_ID", pCountryMaster.CountryId)
                db.AddParameter("p_COUNTRY_CODE", pCountryMaster.CountryCode)
                db.AddParameter("p_COUNTRY_NAME", pCountryMaster.CountryName)
                db.AddParameter("p_ErrorMsg", pCountryMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COUNTRY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCountryMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pCountryMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCountryMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCountryMaster"></param>
        ''' <returns>Return pCountryMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCountryMaster As CountryMaster) As CountryMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_COUNTRY_ID", pCountryMaster.CountryId)
                db.AddParameter("p_COUNTRY_CODE", pCountryMaster.CountryCode)
                db.AddParameter("p_COUNTRY_NAME", pCountryMaster.CountryName)
                db.AddParameter("p_ErrorMsg", pCountryMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_COUNTRY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCountryMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pCountryMaster.ErrorMsg = ex.Message
            End Try
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCountryMaster"></param>
        ''' <returns>Return pCountryMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCountryMaster As CountryMaster) As CountryMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_COUNTRY_ID", pCountryMaster.CountryId)
                db.AddParameter("p_COUNTRY_CODE", pCountryMaster.CountryCode)
                db.AddParameter("p_COUNTRY_NAME", pCountryMaster.CountryName)
                db.AddParameter("p_ErrorMsg", pCountryMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COUNTRY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCountryMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCountryMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCountryMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCountryMaster"></param>
        ''' <returns>Return pCountryMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCountryMaster As CountryMaster) As CountryMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_COUNTRY_ID", pCountryMaster.CountryId)
                db.AddParameter("p_COUNTRY_CODE", pCountryMaster.CountryCode)
                db.AddParameter("p_COUNTRY_NAME", pCountryMaster.CountryName)
                db.AddParameter("p_ErrorMsg", pCountryMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_COUNTRY_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCountryMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCountryMaster.ErrorMsg = ex.Message
                End Try
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCountryMaster As CountryMaster) As CountryMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                PCountryMaster.CountryId = dbr("COUNTRY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_CODE").ToString <> "" Then
                                PCountryMaster.CountryCode = dbr("COUNTRY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_NAME").ToString <> "" Then
                                PCountryMaster.CountryName = dbr("COUNTRY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCountryMaster.ErrorMsg = ex.Message
            End Try
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCountryMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CountryMaster
                        Try
                            If dbr("COUNTRY_ID").ToString <> "" Then
                                temp.CountryId = dbr("COUNTRY_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_CODE").ToString <> "" Then
                                temp.CountryCode = dbr("COUNTRY_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("COUNTRY_NAME").ToString <> "" Then
                                temp.CountryName = dbr("COUNTRY_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        arrList.Add(temp)
                    End While
                end If
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
        Public Shared Function ReturnCountryMaster(ByVal pCountryMaster As CountryMaster) As CountryMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COUNTRY_MASTER", "' '")
                pCountryMaster = ReturnObjectValues(dbr, pCountryMaster)
                dbr.Close()
            Catch ex As Exception
                pCountryMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCountryMasterById(ByVal pCountryMaster As CountryMaster) As CountryMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COUNTRY_MASTER_BY_ID", pCountryMaster.CountryId)
                pCountryMaster = ReturnObjectValues(dbr, pCountryMaster)
                dbr.Close()
            Catch ex As Exception
                pCountryMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pCountryMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCountryMasterList() As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCountryMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_COUNTRY_MASTER_ALL", " ")
                arrCountryMaster = ReturnObjectValuesList(dbr, arrCountryMaster)
                dbr.Close()
            Catch ex As Exception
                arrCountryMaster = Nothing
            End Try
            db.CloseDB()
            Return arrCountryMaster
        End Function
    End Class
End Namespace
