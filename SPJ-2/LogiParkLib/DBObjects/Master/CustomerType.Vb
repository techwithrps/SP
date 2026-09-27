Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: CustomerType
    ''' @author	: Amit K. Singh- 8/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class CustomerType 
        

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private strCustomerTypeCode As String ' Define Private Variable CustomerTypeCode With DataType As String 
        Private strCustomerTypeName As String ' Define Private Variable CustomerTypeName With DataType As String 
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
        ''' Get or Set the Value of CustomerTypeCode
        ''' </summary>
        ''' <value>strCustomerTypeCode</value>
        ''' <returns> Return strCustomerTypeCode</returns>
        ''' <remarks> Get or Set the Value of CustomerTypeCode  </remarks>
        '''
        Public Property CustomerTypeCode() as String
            Get
                Return strCustomerTypeCode
            End Get
            Set(ByVal value As String)
                strCustomerTypeCode = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of CustomerTypeName
        ''' </summary>
        ''' <value>strCustomerTypeName</value>
        ''' <returns> Return strCustomerTypeName</returns>
        ''' <remarks> Get or Set the Value of CustomerTypeName  </remarks>
        '''
        Public Property CustomerTypeName() as String
            Get
                Return strCustomerTypeName
            End Get
            Set(ByVal value As String)
                strCustomerTypeName = value
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
            strCustomerTypeCode = ""
            strCustomerTypeName = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pCustomerType"></param>
        ''' <returns>Return pCustomerType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pCustomerType As CustomerType) As CustomerType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerType.TerminalId)
                db.AddParameter("p_CUSTOMER_TYPE_CODE", pCustomerType.CustomerTypeCode)
                db.AddParameter("p_CUSTOMER_TYPE_NAME", pCustomerType.CustomerTypeName)
                db.AddParameter("p_ErrorMsg", pCustomerType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pCustomerType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerType
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerType"></param>
        ''' <returns>Return pCustomerType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pCustomerType As CustomerType) As CustomerType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerType.TerminalId)
                db.AddParameter("p_CUSTOMER_TYPE_CODE", pCustomerType.CustomerTypeCode)
                db.AddParameter("p_CUSTOMER_TYPE_NAME", pCustomerType.CustomerTypeName)
                db.AddParameter("p_ErrorMsg", pCustomerType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_CUSTOMER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pCustomerType.ErrorMsg = ex.Message
            End Try
            Return pCustomerType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pCustomerType"></param>
        ''' <returns>Return pCustomerType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pCustomerType As CustomerType) As CustomerType
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerType.TerminalId)
                db.AddParameter("p_CUSTOMER_TYPE_CODE", pCustomerType.CustomerTypeCode)
                db.AddParameter("p_CUSTOMER_TYPE_NAME", pCustomerType.CustomerTypeName)
                db.AddParameter("p_ErrorMsg", pCustomerType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pCustomerType.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pCustomerType.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pCustomerType
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pCustomerType"></param>
        ''' <returns>Return pCustomerType Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pCustomerType As CustomerType) As CustomerType
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pCustomerType.TerminalId)
                db.AddParameter("p_CUSTOMER_TYPE_CODE", pCustomerType.CustomerTypeCode)
                db.AddParameter("p_CUSTOMER_TYPE_NAME", pCustomerType.CustomerTypeName)
                db.AddParameter("p_ErrorMsg", pCustomerType.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_CUSTOMER_TYPE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pCustomerType.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pCustomerType.ErrorMsg = ex.Message
                End Try
            Return pCustomerType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pCustomerType As CustomerType) As CustomerType
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PCustomerType.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE_CODE").ToString <> "" Then
                                PCustomerType.CustomerTypeCode = dbr("CUSTOMER_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE_NAME").ToString <> "" Then
                                PCustomerType.CustomerTypeName = dbr("CUSTOMER_TYPE_NAME")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pCustomerType.ErrorMsg = ex.Message
            End Try
            Return pCustomerType
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrCustomerType As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New CustomerType
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE_CODE").ToString <> "" Then
                                temp.CustomerTypeCode = dbr("CUSTOMER_TYPE_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CUSTOMER_TYPE_NAME").ToString <> "" Then
                                temp.CustomerTypeName = dbr("CUSTOMER_TYPE_NAME")
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
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnCustomerTypeList (ByVal pCustomerType As CustomerType) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrCustomerType As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_TYPE_ALL", pCustomerType.TerminalId)
                arrCustomerType = ReturnObjectValuesList(dbr, arrCustomerType)
                dbr.Close()
            Catch ex As Exception
                arrCustomerType = Nothing
            End Try
            db.CloseDB()
            Return arrCustomerType
        End Function


        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnCustomerType(ByVal pCustomerType As CustomerType) As CustomerType
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CUSTOMER_TYPE_BY_CODE", pCustomerType.TerminalId & ",'" & pCustomerType.CustomerTypeCode & "'")
                pCustomerType = ReturnObjectValues(dbr, pCustomerType)
                dbr.Close()
            Catch ex As Exception
                pCustomerType.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pCustomerType
        End Function

    End Class
End Namespace
