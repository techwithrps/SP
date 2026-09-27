Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: PersonnelMaster
    ''' @author	: Santosh Singh- 30/9/2014
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class PersonnelMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngPrId As Long ' Define Private Variable PrId With DataType As Long 
        Private strPrCode As String ' Define Private Variable PrCode With DataType As String 
        Private strPrName As String ' Define Private Variable PrName With DataType As String 
        Private strAddress As String ' Define Private Variable Address With DataType As String 
        Private lngContactNo As Long ' Define Private Variable ContactNo With DataType As Long 
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
        ''' Get or Set the Value of PrId
        ''' </summary>
        ''' <value>lngPrId</value>
        ''' <returns> Return lngPrId</returns>
        ''' <remarks> Get or Set the Value of PrId  </remarks>
        '''
        Public Property PrId() as Long
            Get
                Return lngPrId
            End Get
            Set(ByVal value As Long)
                lngPrId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PrCode
        ''' </summary>
        ''' <value>strPrCode</value>
        ''' <returns> Return strPrCode</returns>
        ''' <remarks> Get or Set the Value of PrCode  </remarks>
        '''
        Public Property PrCode() as String
            Get
                Return strPrCode
            End Get
            Set(ByVal value As String)
                strPrCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of PrName
        ''' </summary>
        ''' <value>strPrName</value>
        ''' <returns> Return strPrName</returns>
        ''' <remarks> Get or Set the Value of PrName  </remarks>
        '''
        Public Property PrName() as String
            Get
                Return strPrName
            End Get
            Set(ByVal value As String)
                strPrName = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Address
        ''' </summary>
        ''' <value>strAddress</value>
        ''' <returns> Return strAddress</returns>
        ''' <remarks> Get or Set the Value of Address  </remarks>
        '''
        Public Property Address() as String
            Get
                Return strAddress
            End Get
            Set(ByVal value As String)
                strAddress = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ContactNo
        ''' </summary>
        ''' <value>lngContactNo</value>
        ''' <returns> Return lngContactNo</returns>
        ''' <remarks> Get or Set the Value of ContactNo  </remarks>
        '''
        Public Property ContactNo() as Long
            Get
                Return lngContactNo
            End Get
            Set(ByVal value As Long)
                lngContactNo = value
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
            lngPrId = 0 
            strPrCode = ""
            strPrName = ""
            strAddress = ""
            lngContactNo = 0 
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pPersonnelMaster"></param>
        ''' <returns>Return pPersonnelMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPersonnelMaster.TerminalId)
                db.AddParameter("p_PR_ID", pPersonnelMaster.PrId, ParameterDirection.Output)
                db.AddParameter("p_PR_CODE", pPersonnelMaster.PrCode)
                db.AddParameter("p_PR_NAME", pPersonnelMaster.PrName)
                db.AddParameter("p_ADDRESS", pPersonnelMaster.Address)
                db.AddParameter("p_CONTACT_NO", pPersonnelMaster.ContactNo)
                db.AddParameter("p_CREATED_BY", pPersonnelMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPersonnelMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPersonnelMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PERSONNEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPersonnelMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPersonnelMaster.PrId  = db.Parameters.Item("p_PR_ID").value
                
                If pPersonnelMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPersonnelMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPersonnelMaster"></param>
        ''' <returns>Return pPersonnelMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPersonnelMaster.TerminalId)
                db.AddParameter("p_PR_ID", pPersonnelMaster.PrId, ParameterDirection.Output)
                db.AddParameter("p_PR_CODE", pPersonnelMaster.PrCode)
                db.AddParameter("p_PR_NAME", pPersonnelMaster.PrName)
                db.AddParameter("p_ADDRESS", pPersonnelMaster.Address)
                db.AddParameter("p_CONTACT_NO", pPersonnelMaster.ContactNo)
                db.AddParameter("p_CREATED_BY", pPersonnelMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPersonnelMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPersonnelMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_PERSONNEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPersonnelMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pPersonnelMaster.PrId  = db.Parameters.Item("p_PR_ID").value
                
            Catch ex As Exception
                pPersonnelMaster.ErrorMsg = ex.Message
            End Try
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pPersonnelMaster"></param>
        ''' <returns>Return pPersonnelMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPersonnelMaster.TerminalId)
                db.AddParameter("p_PR_ID", pPersonnelMaster.PrId)
                db.AddParameter("p_PR_CODE", pPersonnelMaster.PrCode)
                db.AddParameter("p_PR_NAME", pPersonnelMaster.PrName)
                db.AddParameter("p_ADDRESS", pPersonnelMaster.Address)
                db.AddParameter("p_CONTACT_NO", pPersonnelMaster.ContactNo)
                db.AddParameter("p_CREATED_BY", pPersonnelMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPersonnelMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPersonnelMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PERSONNEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPersonnelMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pPersonnelMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pPersonnelMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pPersonnelMaster"></param>
        ''' <returns>Return pPersonnelMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pPersonnelMaster.TerminalId)
                db.AddParameter("p_PR_ID", pPersonnelMaster.PrId)
                db.AddParameter("p_PR_CODE", pPersonnelMaster.PrCode)
                db.AddParameter("p_PR_NAME", pPersonnelMaster.PrName)
                db.AddParameter("p_ADDRESS", pPersonnelMaster.Address)
                db.AddParameter("p_CONTACT_NO", pPersonnelMaster.ContactNo)
                db.AddParameter("p_CREATED_BY", pPersonnelMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pPersonnelMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pPersonnelMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_PERSONNEL_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pPersonnelMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pPersonnelMaster.ErrorMsg = ex.Message
                End Try
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PPersonnelMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_ID").ToString <> "" Then
                                PPersonnelMaster.PrId = dbr("PR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_CODE").ToString <> "" Then
                                PPersonnelMaster.PrCode = dbr("PR_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_NAME").ToString <> "" Then
                                PPersonnelMaster.PrName = dbr("PR_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                PPersonnelMaster.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                PPersonnelMaster.ContactNo = dbr("CONTACT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PPersonnelMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PPersonnelMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pPersonnelMaster.ErrorMsg = ex.Message
            End Try
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrPersonnelMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New PersonnelMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_ID").ToString <> "" Then
                                temp.PrId = dbr("PR_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_CODE").ToString <> "" Then
                                temp.PrCode = dbr("PR_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PR_NAME").ToString <> "" Then
                                temp.PrName = dbr("PR_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADDRESS").ToString <> "" Then
                                temp.Address = dbr("ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CONTACT_NO").ToString <> "" Then
                                temp.ContactNo = dbr("CONTACT_NO")
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
        Public Shared Function ReturnPersonnelMaster(ByVal pPersonnelMaster As PersonnelMaster) As PersonnelMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PERSONNEL_MASTER_BY_ID", pPersonnelMaster.TerminalId & "," & pPersonnelMaster.PrId)
                pPersonnelMaster = ReturnObjectValues(dbr, pPersonnelMaster)
                dbr.Close()
            Catch ex As Exception
                pPersonnelMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pPersonnelMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnPersonnelMasterList (ByVal pPersonnelMaster As PersonnelMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrPersonnelMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PERSONNEL_MASTER", pPersonnelMaster.TerminalId)
                arrPersonnelMaster = ReturnObjectValuesList(dbr, arrPersonnelMaster)
                dbr.Close()
            Catch ex As Exception
                arrPersonnelMaster = Nothing
            End Try
            db.CloseDB()
            Return arrPersonnelMaster
        End Function
    End Class
End Namespace
