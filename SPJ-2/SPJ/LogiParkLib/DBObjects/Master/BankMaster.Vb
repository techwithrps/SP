Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: BankMaster
    ''' @author	: Amit K. Singh- 2/12/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class BankMaster 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngBankId As Long ' Define Private Variable BankId With DataType As Long 
        Private strBankCode As String ' Define Private Variable BankCode With DataType As String 
        Private strBankName As String ' Define Private Variable BankName With DataType As String 
        Private strAccountNo As String ' Define Private Variable AccountNo With DataType As String 
        Private strIfscCode As String ' Define Private Variable IfscCode With DataType As String 
        Private strSwiftCode As String ' Define Private Variable strSwiftCode With DataType As String 
        Private strBankAddress As String ' Define Private Variable BankAddress With DataType As String 
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
        ''' Get or Set the Value of BankId
        ''' </summary>
        ''' <value>lngBankId</value>
        ''' <returns> Return lngBankId</returns>
        ''' <remarks> Get or Set the Value of BankId  </remarks>
        '''
        Public Property BankId() as Long
            Get
                Return lngBankId
            End Get
            Set(ByVal value As Long)
                lngBankId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BankCode
        ''' </summary>
        ''' <value>strBankCode</value>
        ''' <returns> Return strBankCode</returns>
        ''' <remarks> Get or Set the Value of BankCode  </remarks>
        '''
        Public Property BankCode() as String
            Get
                Return strBankCode
            End Get
            Set(ByVal value As String)
                strBankCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BankName
        ''' </summary>
        ''' <value>strBankName</value>
        ''' <returns> Return strBankName</returns>
        ''' <remarks> Get or Set the Value of BankName  </remarks>
        '''
        Public Property BankName() as String
            Get
                Return strBankName
            End Get
            Set(ByVal value As String)
                strBankName = value
            End Set
        End Property
        ''' <summary>
        ''' Get or Set the Value of AccountNo
        ''' </summary>
        ''' <value>strAccountNo</value>
        ''' <returns> Return strAccountNo</returns>
        ''' <remarks> Get or Set the Value of AccountNo  </remarks>
        '''
        Public Property AccountNo() As String
            Get
                Return strAccountNo
            End Get
            Set(ByVal value As String)
                strAccountNo = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of IfscCode
        ''' </summary>
        ''' <value>strIfscCode</value>
        ''' <returns> Return strIfscCode</returns>
        ''' <remarks> Get or Set the Value of IfscCode  </remarks>
        '''
        Public Property IfscCode() as String
            Get
                Return strIfscCode
            End Get
            Set(ByVal value As String)
                strIfscCode = value
            End Set
        End Property


        ''' <summary>
        ''' Get or Set the Value of SwiftCode
        ''' </summary>
        ''' <value>strSwiftCode</value>
        ''' <returns> Return strIfscCode</returns>
        ''' <remarks> Get or Set the Value of SwiftCode  </remarks>
        '''
        Public Property SwiftCode() As String
            Get
                Return strSwiftCode
            End Get
            Set(ByVal value As String)
                strSwiftCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of BankAddress
        ''' </summary>
        ''' <value>strBankAddress</value>
        ''' <returns> Return strBankAddress</returns>
        ''' <remarks> Get or Set the Value of BankAddress  </remarks>
        '''
        Public Property BankAddress() as String
            Get
                Return strBankAddress
            End Get
            Set(ByVal value As String)
                strBankAddress = value
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
            lngBankId = 0 
            strBankCode = ""
            strBankName = ""
            strAccountNo = ""
            strIfscCode = ""
            strSwiftCode = ""
            strBankAddress = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pBankMaster"></param>
        ''' <returns>Return pBankMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pBankMaster As BankMaster) As BankMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pBankMaster.TerminalId)
                db.AddParameter("p_BANK_ID", pBankMaster.BankId, ParameterDirection.Output)
                db.AddParameter("p_BANK_CODE", pBankMaster.BankCode)
                db.AddParameter("p_BANK_NAME", pBankMaster.BankName)
                db.AddParameter("p_ACCOUNT_NO", pBankMaster.AccountNo)
                db.AddParameter("p_IFSC_CODE", pBankMaster.IfscCode)
                db.AddParameter("p_SWIFT_CODE", pBankMaster.SwiftCode)
                db.AddParameter("p_BANK_ADDRESS", pBankMaster.BankAddress)
                db.AddParameter("p_CREATED_BY", pBankMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBankMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBankMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_BANK_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBankMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pBankMaster.BankId  = db.Parameters.Item("p_BANK_ID").value
                
                If pBankMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pBankMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pBankMaster"></param>
        ''' <returns>Return pBankMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pBankMaster As BankMaster) As BankMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pBankMaster.TerminalId)
                db.AddParameter("p_BANK_ID", pBankMaster.BankId, ParameterDirection.Output)
                db.AddParameter("p_BANK_CODE", pBankMaster.BankCode)
                db.AddParameter("p_BANK_NAME", pBankMaster.BankName)
                db.AddParameter("p_ACCOUNT_NO", pBankMaster.AccountNo)
                db.AddParameter("p_IFSC_CODE", pBankMaster.IfscCode)
                db.AddParameter("p_SWIFT_CODE", pBankMaster.SwiftCode)
                db.AddParameter("p_BANK_ADDRESS", pBankMaster.BankAddress)
                db.AddParameter("p_CREATED_BY", pBankMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBankMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBankMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_BANK_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBankMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pBankMaster.BankId  = db.Parameters.Item("p_BANK_ID").value
                
            Catch ex As Exception
                pBankMaster.ErrorMsg = ex.Message
            End Try
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pBankMaster"></param>
        ''' <returns>Return pBankMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pBankMaster As BankMaster) As BankMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pBankMaster.TerminalId)
                db.AddParameter("p_BANK_ID", pBankMaster.BankId)
                db.AddParameter("p_BANK_CODE", pBankMaster.BankCode)
                db.AddParameter("p_BANK_NAME", pBankMaster.BankName)
                db.AddParameter("p_ACCOUNT_NO", pBankMaster.AccountNo)
                db.AddParameter("p_IFSC_CODE", pBankMaster.IfscCode)
                db.AddParameter("p_SWIFT_CODE", pBankMaster.SwiftCode)
                db.AddParameter("p_BANK_ADDRESS", pBankMaster.BankAddress)
                db.AddParameter("p_CREATED_BY", pBankMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBankMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBankMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_BANK_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBankMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pBankMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pBankMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pBankMaster"></param>
        ''' <returns>Return pBankMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pBankMaster As BankMaster) As BankMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pBankMaster.TerminalId)
                db.AddParameter("p_BANK_ID", pBankMaster.BankId)
                db.AddParameter("p_BANK_CODE", pBankMaster.BankCode)
                db.AddParameter("p_BANK_NAME", pBankMaster.BankName)
                db.AddParameter("p_ACCOUNT_NO", pBankMaster.AccountNo)
                db.AddParameter("p_IFSC_CODE", pBankMaster.IfscCode)
                db.AddParameter("p_SWIFT_CODE", pBankMaster.SwiftCode)
                db.AddParameter("p_BANK_ADDRESS", pBankMaster.BankAddress)
                db.AddParameter("p_CREATED_BY", pBankMaster.CreatedBy)
                db.AddParameter("p_CREATED_ON", pBankMaster.CreatedOn)
                db.AddParameter("p_ErrorMsg", pBankMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_BANK_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pBankMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pBankMaster.ErrorMsg = ex.Message
                End Try
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pBankMaster As BankMaster) As BankMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PBankMaster.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                PBankMaster.BankId = dbr("BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_CODE").ToString <> "" Then
                                PBankMaster.BankCode = dbr("BANK_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_NAME").ToString <> "" Then
                                PBankMaster.BankName = dbr("BANK_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_NO").ToString <> "" Then
                                pBankMaster.AccountNo = dbr("ACCOUNT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IFSC_CODE").ToString <> "" Then
                                PBankMaster.IfscCode = dbr("IFSC_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SWIFT_CODE").ToString <> "" Then
                                pBankMaster.SwiftCode = dbr("SWIFT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ADDRESS").ToString <> "" Then
                                PBankMaster.BankAddress = dbr("BANK_ADDRESS")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PBankMaster.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PBankMaster.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pBankMaster.ErrorMsg = ex.Message
            End Try
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrBankMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New BankMaster
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ID").ToString <> "" Then
                                temp.BankId = dbr("BANK_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_CODE").ToString <> "" Then
                                temp.BankCode = dbr("BANK_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_NAME").ToString <> "" Then
                                temp.BankName = dbr("BANK_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ACCOUNT_NO").ToString <> "" Then
                                temp.AccountNo = dbr("ACCOUNT_NO")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("IFSC_CODE").ToString <> "" Then
                                temp.IfscCode = dbr("IFSC_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SWIFT_CODE").ToString <> "" Then
                                temp.SwiftCode = dbr("SWIFT_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("BANK_ADDRESS").ToString <> "" Then
                                temp.BankAddress = dbr("BANK_ADDRESS")
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
        Public Shared Function ReturnBankMaster(ByVal pBankMaster As BankMaster) As BankMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_BANK_MASTER_BY_ID", pBankMaster.TerminalId & "," & pBankMaster.BankId)
                pBankMaster = ReturnObjectValues(dbr, pBankMaster)
                dbr.Close()
            Catch ex As Exception
                pBankMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pBankMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnBankMasterList(ByVal pBankMaster As BankMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrBankMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_BANK_MASTER_ALL", pBankMaster.TerminalId)
                arrBankMaster = ReturnObjectValuesList(dbr, arrBankMaster)
                dbr.Close()
            Catch ex As Exception
                arrBankMaster = Nothing
            End Try
            db.CloseDB()
            Return arrBankMaster
        End Function


    End Class
End Namespace
