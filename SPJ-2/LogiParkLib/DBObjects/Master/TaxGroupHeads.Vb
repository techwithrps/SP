Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: TaxGroupHeads
    ''' @author	: Amit K. Singh- 28/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class TaxGroupHeads 
    
        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngTaxPercentage As Double ' Define Private Variable TaxPercentage With DataType As Long 
        Private lngTaxGroupId As Long ' Define Private Variable TaxGroupId With DataType As Long 
        Private lngTaxHeadId As Long ' Define Private Variable TaxHeadId With DataType As Long 
        Private lngTaxRefId As Long ' Define Private Variable TaxRefId With DataType As Long 
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
        ''' Get or Set the Value of TaxPercentage
        ''' </summary>
        ''' <value>lngTaxPercentage</value>
        ''' <returns> Return lngTaxPercentage</returns>
        ''' <remarks> Get or Set the Value of TaxPercentage  </remarks>
        '''
        Public Property TaxPercentage() As Double
            Get
                Return lngTaxPercentage
            End Get
            Set(ByVal value As Double)
                lngTaxPercentage = value
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
        ''' Get or Set the Value of TaxHeadId
        ''' </summary>
        ''' <value>lngTaxHeadId</value>
        ''' <returns> Return lngTaxHeadId</returns>
        ''' <remarks> Get or Set the Value of TaxHeadId  </remarks>
        '''
        Public Property TaxHeadId() as Long
            Get
                Return lngTaxHeadId
            End Get
            Set(ByVal value As Long)
                lngTaxHeadId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of TaxRefId
        ''' </summary>
        ''' <value>lngTaxRefId</value>
        ''' <returns> Return lngTaxRefId</returns>
        ''' <remarks> Get or Set the Value of TaxRefId  </remarks>
        '''
        Public Property TaxRefId() as Long
            Get
                Return lngTaxRefId
            End Get
            Set(ByVal value As Long)
                lngTaxRefId = value
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
            lngTaxPercentage = 0 
            lngTaxGroupId = 0 
            lngTaxHeadId = 0 
            lngTaxRefId = 0 
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pTaxGroupHeads"></param>
        ''' <returns>Return pTaxGroupHeads Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroupHeads.TerminalId)
                db.AddParameter("p_TAX_PERCENTAGE", pTaxGroupHeads.TaxPercentage)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroupHeads.TaxGroupId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxGroupHeads.TaxHeadId)
                db.AddParameter("p_TAX_REF_ID", pTaxGroupHeads.TaxRefId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pTaxGroupHeads.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_GROUP_HEADS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroupHeads.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxGroupHeads.TaxRefId  = db.Parameters.Item("p_TAX_REF_ID").value
                
                If pTaxGroupHeads.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxGroupHeads.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxGroupHeads"></param>
        ''' <returns>Return pTaxGroupHeads Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroupHeads.TerminalId)
                db.AddParameter("p_TAX_PERCENTAGE", pTaxGroupHeads.TaxPercentage)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroupHeads.TaxGroupId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxGroupHeads.TaxHeadId)
                db.AddParameter("p_TAX_REF_ID", pTaxGroupHeads.TaxRefId, ParameterDirection.Output)
                db.AddParameter("p_ErrorMsg", pTaxGroupHeads.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_TAX_GROUP_HEADS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroupHeads.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pTaxGroupHeads.TaxRefId  = db.Parameters.Item("p_TAX_REF_ID").value
                
            Catch ex As Exception
                pTaxGroupHeads.ErrorMsg = ex.Message
            End Try
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pTaxGroupHeads"></param>
        ''' <returns>Return pTaxGroupHeads Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroupHeads.TerminalId)
                db.AddParameter("p_TAX_PERCENTAGE", pTaxGroupHeads.TaxPercentage)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroupHeads.TaxGroupId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxGroupHeads.TaxHeadId)
                db.AddParameter("p_TAX_REF_ID", pTaxGroupHeads.TaxRefId)
                db.AddParameter("p_ErrorMsg", pTaxGroupHeads.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_GROUP_HEADS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroupHeads.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pTaxGroupHeads.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pTaxGroupHeads.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pTaxGroupHeads"></param>
        ''' <returns>Return pTaxGroupHeads Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pTaxGroupHeads.TerminalId)
                db.AddParameter("p_TAX_PERCENTAGE", pTaxGroupHeads.TaxPercentage)
                db.AddParameter("p_TAX_GROUP_ID", pTaxGroupHeads.TaxGroupId)
                db.AddParameter("p_TAX_HEAD_ID", pTaxGroupHeads.TaxHeadId)
                db.AddParameter("p_TAX_REF_ID", pTaxGroupHeads.TaxRefId)
                db.AddParameter("p_ErrorMsg", pTaxGroupHeads.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_TAX_GROUP_HEADS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pTaxGroupHeads.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pTaxGroupHeads.ErrorMsg = ex.Message
                End Try
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                PTaxGroupHeads.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERCENTAGE").ToString <> "" Then
                                PTaxGroupHeads.TaxPercentage = dbr("TAX_PERCENTAGE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_GROUP_ID").ToString <> "" Then
                                PTaxGroupHeads.TaxGroupId = dbr("TAX_GROUP_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                PTaxGroupHeads.TaxHeadId = dbr("TAX_HEAD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_REF_ID").ToString <> "" Then
                                PTaxGroupHeads.TaxRefId = dbr("TAX_REF_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pTaxGroupHeads.ErrorMsg = ex.Message
            End Try
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrTaxGroupHeads As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New TaxGroupHeads
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_PERCENTAGE").ToString <> "" Then
                                temp.TaxPercentage = dbr("TAX_PERCENTAGE")
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
                            If dbr("TAX_HEAD_ID").ToString <> "" Then
                                temp.TaxHeadId = dbr("TAX_HEAD_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TAX_REF_ID").ToString <> "" Then
                                temp.TaxRefId = dbr("TAX_REF_ID")
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
        Public Shared Function ReturnTaxGroupHeads(ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_GROUP_HEADS", "' '")
                pTaxGroupHeads = ReturnObjectValues(dbr, pTaxGroupHeads)
                dbr.Close()
            Catch ex As Exception
                pTaxGroupHeads.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pTaxGroupHeads
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By TaxGroupId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnTaxGroupHeadsListByTaxGroupId(ByVal pTaxGroupHeads As TaxGroupHeads) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTaxGroupHeads As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_GROUP_HEADS_ALL_BY_ID", pTaxGroupHeads.TerminalId & "," & pTaxGroupHeads.TaxGroupId)
                arrTaxGroupHeads = ReturnObjectValuesList(dbr, arrTaxGroupHeads)
                dbr.Close()
            Catch ex As Exception
                arrTaxGroupHeads = Nothing
            End Try
            db.CloseDB()
            Return arrTaxGroupHeads
        End Function


        Public Shared Function ReturnTaxGroupHeadsListByTaxGroupIdAndIGST(ByVal pTaxGroupHeads As TaxGroupHeads) As TaxGroupHeads
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrTaxGroupHeads As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TAX_GROUP_HEADS_IGST_BY_ID", pTaxGroupHeads.TerminalId & "," & pTaxGroupHeads.TaxGroupId)
                pTaxGroupHeads = ReturnObjectValues(dbr, pTaxGroupHeads)
                dbr.Close()
            Catch ex As Exception
                arrTaxGroupHeads = Nothing
            End Try
            db.CloseDB()
            Return pTaxGroupHeads
        End Function
    End Class
End Namespace
