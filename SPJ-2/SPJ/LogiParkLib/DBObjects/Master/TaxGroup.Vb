Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TaxGroup
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TaxGroup 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngTaxGroupId As Long ' Define Private Variable TaxGroupId With DataType As Long 
        Private strTaxGroupCode As String ' Define Private Variable TaxGroupCode With DataType As String 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String 
        Private strFromDate As String
        Private strToDate As String
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
        ''' Get or Set the Value of TaxGroupId
        ''' </summary>
        ''' <value>lngTaxGroupId</value>
        ''' <returns> Return lngTaxGroupId</returns>
        ''' <remarks> Get or Set the Value of TaxGroupId  </remarks>
        '''
        Public Property TaxGroupId() as Long
            Get
                Return lngTaxGroupId
            End Get
            Set(ByVal value As Long)
                lngTaxGroupId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TaxGroupCode
        ''' </summary>
        ''' <value>strTaxGroupCode</value>
        ''' <returns> Return strTaxGroupCode</returns>
        ''' <remarks> Get or Set the Value of TaxGroupCode  </remarks>
        '''
        Public Property TaxGroupCode() as String
            Get
                Return strTaxGroupCode
            End Get
            Set(ByVal value As String)
                strTaxGroupCode = value
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
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal value As String)
                strFromDate = value
            End Set
        End Property
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal value As String)
                strToDate = value
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
            lngTaxGroupId = 0 
            strTaxGroupCode = ""
            strCreatedBy = ""
            strCreatedOn = ""
            strFromDate = ""
            strToDate = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTaxGroup"></param>
        ''' <returns>Return pTaxGroup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTaxGroup As TaxGroup) As TaxGroup
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroup.TerminalId)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroup.TaxGroupId, ParameterDirection.Output)
                db.AddParameter("p_TAX_GROUP_CODE", pTaxGroup.TaxGroupCode)
                db.AddParameter("p_FROM_DATE", pTaxGroup.FromDate)
                db.AddParameter("p_TO_DATE", pTaxGroup.ToDate)
                db.AddParameter("p_CREATED_BY", pTaxGroup.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxGroup.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxGroup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_GROUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxGroup.TaxGroupId  = db.Parameters.Item("p_TAX_GROUP_ID").value
                
                If pTaxGroup.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxGroup.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxGroup"></param>
        ''' <returns>Return pTaxGroup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTaxGroup As TaxGroup) As TaxGroup
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroup.TerminalId)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroup.TaxGroupId, ParameterDirection.Output)
                db.AddParameter("p_TAX_GROUP_CODE", pTaxGroup.TaxGroupCode)
                db.AddParameter("p_FROM_DATE", pTaxGroup.FromDate)
                db.AddParameter("p_TO_DATE", pTaxGroup.ToDate)
                db.AddParameter("p_CREATED_BY", pTaxGroup.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxGroup.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxGroup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_GROUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxGroup.TaxGroupId  = db.Parameters.Item("p_TAX_GROUP_ID").value
                
            Catch ex As Exception
                pTaxGroup.ErrorMsg = ex.Message
            End Try
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTaxGroup"></param>
        ''' <returns>Return pTaxGroup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTaxGroup As TaxGroup) As TaxGroup
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroup.TerminalId)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroup.TaxGroupId)
                db.AddParameter("p_TAX_GROUP_CODE", pTaxGroup.TaxGroupCode)
                db.AddParameter("p_FROM_DATE", pTaxGroup.FromDate)
                db.AddParameter("p_TO_DATE", pTaxGroup.ToDate)
                db.AddParameter("p_CREATED_BY", pTaxGroup.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxGroup.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxGroup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_GROUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTaxGroup.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxGroup.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxGroup"></param>
        ''' <returns>Return pTaxGroup Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTaxGroup As TaxGroup) As TaxGroup
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroup.TerminalId)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroup.TaxGroupId)
                db.AddParameter("p_TAX_GROUP_CODE", pTaxGroup.TaxGroupCode)
                db.AddParameter("p_FROM_DATE", pTaxGroup.FromDate)
                db.AddParameter("p_TO_DATE", pTaxGroup.ToDate)
                db.AddParameter("p_CREATED_BY", pTaxGroup.CreatedBy)
                db.AddParameter("p_CREATED_ON", pTaxGroup.CreatedOn)
                db.AddParameter("p_ErrorMsg", pTaxGroup.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_GROUP", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroup.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTaxGroup.ErrorMsg = ex.Message
                End Try
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTaxGroup As TaxGroup) As TaxGroup
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTaxGroup.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                PTaxGroup.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_CODE").ToString <> "" Then
                                PTaxGroup.TaxGroupCode = dbr("TAX_GROUP_CODE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                PTaxGroup.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                PTaxGroup.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("FROM_DATE").ToString <> "" Then
                                pTaxGroup.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                pTaxGroup.ToDate = dbr("TO_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTaxGroup.ErrorMsg = ex.Message
            End Try
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTaxGroup As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TaxGroup
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                temp.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_CODE").ToString <> "" Then
                                temp.TaxGroupCode = dbr("TAX_GROUP_CODE")
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
                            If dbr("FROM_DATE").ToString <> "" Then
                                temp.FromDate = dbr("FROM_DATE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TO_DATE").ToString <> "" Then
                                temp.ToDate = dbr("TO_DATE")
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
        ''' Preparing Return Object By TaxGroupId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnTaxGroupByTaxGroupId(ByVal pTaxGroup As TaxGroup) As TaxGroup
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_GROUP_BY_ID", pTaxGroup.TerminalId & "," & pTaxGroup.TaxGroupId)
                pTaxGroup = ReturnObjectValues(dbr, pTaxGroup)
                dbr.Close()
            Catch ex As Exception
                pTaxGroup.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pTaxGroup
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTaxGroupList(ByVal pTaxGroup As TaxGroup) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTaxGroup As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_GROUP_ALL", pTaxGroup.TerminalId)
                arrTaxGroup = ReturnObjectValuesList(dbr, arrTaxGroup)
                dbr.Close()
            Catch ex As Exception
                arrTaxGroup = Nothing
            End Try
            db.CloseDB()
            Return arrTaxGroup
        End Function
    End Class
End Namespace
