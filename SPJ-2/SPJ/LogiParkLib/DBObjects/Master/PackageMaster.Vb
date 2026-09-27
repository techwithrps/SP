Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PackageMaster
    ''' @author	: Amit K. Singh- 3/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class PackageMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngPackageId As Long ' Define Private Variable PackageId With DataType As Long 
        Private strPackageCode As String ' Define Private Variable PackageCode With DataType As String 
        Private strPackageName As String ' Define Private Variable PackageName With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of TerminalId
        ''' </summary>
        ''' <value>lngTerminalId</value>
        ''' <returns> Return lngTerminalId</returns>
        ''' <remarks> Get or Set the Value of TerminalId  </remarks>
        '''
        Public Property TerminalId() as Long
            Get
                Return lngTerminalId
            End Get
            Set(ByVal value As Long)
                lngTerminalId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PackageId
        ''' </summary>
        ''' <value>lngPackageId</value>
        ''' <returns> Return lngPackageId</returns>
        ''' <remarks> Get or Set the Value of PackageId  </remarks>
        '''
        Public Property PackageId() as Long
            Get
                Return lngPackageId
            End Get
            Set(ByVal value As Long)
                lngPackageId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PackageCode
        ''' </summary>
        ''' <value>strPackageCode</value>
        ''' <returns> Return strPackageCode</returns>
        ''' <remarks> Get or Set the Value of PackageCode  </remarks>
        '''
        Public Property PackageCode() as String
            Get
                Return strPackageCode
            End Get
            Set(ByVal value As String)
                strPackageCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PackageName
        ''' </summary>
        ''' <value>strPackageName</value>
        ''' <returns> Return strPackageName</returns>
        ''' <remarks> Get or Set the Value of PackageName  </remarks>
        '''
        Public Property PackageName() as String
            Get
                Return strPackageName
            End Get
            Set(ByVal value As String)
                strPackageName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CreatedBy
        ''' </summary>
        ''' <value>strCreatedBy</value>
        ''' <returns> Return strCreatedBy</returns>
        ''' <remarks> Get or Set the Value of CreatedBy  </remarks>
        '''
        Public Property CreatedBy() as String
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
        Public Property CreatedOn() as String
            Get
                Return strCreatedOn
            End Get
            Set(ByVal value As String)
                strCreatedOn = value
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
            lngTerminalId = 0 
            lngPackageId = 0 
            strPackageCode = ""
            strPackageName = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pPackageMaster"></param>
        ''' <returns>Return pPackageMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pPackageMaster As PackageMaster) As PackageMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPackageMaster.TerminalId)
                db.AddParameter("p_PACKAGE_ID", pPackageMaster.PackageId, ParameterDirection.Output)
                db.AddParameter("p_PACKAGE_CODE", pPackageMaster.PackageCode)
                db.AddParameter("p_PACKAGE_NAME", pPackageMaster.PackageName)
                db.AddParameter("p_CREATED_BY", pPackageMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPackageMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPackageMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PACKAGE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPackageMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPackageMaster.PackageId  = db.Parameters.Item("p_PACKAGE_ID").value
                
                If pPackageMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPackageMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPackageMaster"></param>
        ''' <returns>Return pPackageMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pPackageMaster As PackageMaster) As PackageMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPackageMaster.TerminalId)
                db.AddParameter("p_PACKAGE_ID", pPackageMaster.PackageId, ParameterDirection.Output)
                db.AddParameter("p_PACKAGE_CODE", pPackageMaster.PackageCode)
                db.AddParameter("p_PACKAGE_NAME", pPackageMaster.PackageName)
                db.AddParameter("p_CREATED_BY", pPackageMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPackageMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPackageMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PACKAGE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPackageMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPackageMaster.PackageId  = db.Parameters.Item("p_PACKAGE_ID").value
                
            Catch ex As Exception
                pPackageMaster.ErrorMsg = ex.Message
            End Try
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pPackageMaster"></param>
        ''' <returns>Return pPackageMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pPackageMaster As PackageMaster) As PackageMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPackageMaster.TerminalId)
                db.AddParameter("p_PACKAGE_ID", pPackageMaster.PackageId)
                db.AddParameter("p_PACKAGE_CODE", pPackageMaster.PackageCode)
                db.AddParameter("p_PACKAGE_NAME", pPackageMaster.PackageName)
                db.AddParameter("p_CREATED_BY", pPackageMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPackageMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPackageMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PACKAGE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPackageMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pPackageMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPackageMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPackageMaster"></param>
        ''' <returns>Return pPackageMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pPackageMaster As PackageMaster) As PackageMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPackageMaster.TerminalId)
                db.AddParameter("p_PACKAGE_ID", pPackageMaster.PackageId)
                db.AddParameter("p_PACKAGE_CODE", pPackageMaster.PackageCode)
                db.AddParameter("p_PACKAGE_NAME", pPackageMaster.PackageName)
                db.AddParameter("p_CREATED_BY", pPackageMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPackageMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPackageMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PACKAGE_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPackageMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pPackageMaster.ErrorMsg = ex.Message
                End Try
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pPackageMaster As PackageMaster) As PackageMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PPackageMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_ID").ToString <> "" Then
                                PPackageMaster.PackageId = dbr("PACKAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_CODE").ToString <> "" Then
                                PPackageMaster.PackageCode = dbr("PACKAGE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_NAME").ToString <> "" Then
                                PPackageMaster.PackageName = dbr("PACKAGE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PPackageMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PPackageMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pPackageMaster.ErrorMsg = ex.Message
            End Try
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrPackageMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New PackageMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_ID").ToString <> "" Then
                                temp.PackageId = dbr("PACKAGE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_CODE").ToString <> "" Then
                                temp.PackageCode = dbr("PACKAGE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PACKAGE_NAME").ToString <> "" Then
                                temp.PackageName = dbr("PACKAGE_NAME")
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
        Public Shared Function ReturnPackageMaster(ByVal pPackageMaster As PackageMaster) As PackageMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PACKAGE_MASTER_BY_ID", pPackageMaster.TerminalId & "," & pPackageMaster.PackageId)
                pPackageMaster = ReturnObjectValues(dbr, pPackageMaster)
                dbr.Close()
            Catch ex As Exception
                pPackageMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pPackageMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPackageMasterList (ByVal pPackageMaster As PackageMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPackageMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PACKAGE_MASTER_ALL", pPackageMaster.TerminalId)
                arrPackageMaster = ReturnObjectValuesList(dbr, arrPackageMaster)
                dbr.Close()
            Catch ex As Exception
                arrPackageMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPackageMaster
        End Function
    End Class
End Namespace
