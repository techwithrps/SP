Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects

    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: WarehouseAllot
    ''' @author	: Amit K. Singh- 17/3/2012
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class WarehouseAllot
        Inherits WarehouseAllotCont

        Private lngTerminalId As Long ' Define Private Variable TerminalId With DataType As Long 
        Private lngWhAllotId As Long ' Define Private Variable WhAllotId With DataType As Long 
        Private lngGridId As Long ' Define Private Variable GridId With DataType As Long 
        Private lngLineItemId As Long ' Define Private Variable LineItemId With DataType As Long 
        Private strCreatedBy As String ' Define Private Variable CreatedBy With DataType As String 
        Private strCreatedOn As String ' Define Private Variable CreatedOn With DataType As String
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

        Dim arrWarehouseAllotCont As ArrayList
        Dim arrWarehouseAllot As ArrayList

        Public Property WarehouseAllotContList() As ArrayList
            Get
                Return arrWarehouseAllotCont
            End Get
            Set(ByVal value As ArrayList)
                arrWarehouseAllotCont = value
            End Set
        End Property



        Public Property WarehouseAllotList() As ArrayList
            Get
                Return arrWarehouseAllot
            End Get
            Set(ByVal value As ArrayList)
                arrWarehouseAllot = value
            End Set
        End Property

        ''' <summary>
        ''' Get or Set the Value of GridId
        ''' </summary>
        ''' <value>lngGridId</value>
        ''' <returns> Return lngGridId</returns>
        ''' <remarks> Get or Set the Value of GridId  </remarks>
        '''
        Public Property GridId() As Long
            Get
                Return lngGridId
            End Get
            Set(ByVal value As Long)
                lngGridId = value
            End Set
        End Property

        ''' <summary>
        ''' Preparing New as Default Constructor
        ''' </summary>
        ''' <remarks>   </remarks>
        '''
        Public Sub New()
            lngTerminalId = 0
            lngWhAllotId = 0
            lngGridId = 0
            lngLineItemId = 0
            strCreatedBy = ""
            strCreatedOn = ""
            strErrormsg = ""
        End Sub


        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pWarehouseAllot"></param>
        ''' <returns>Return pWarehouseAllot Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrnWarehouseAllot(ByVal db As DBConnect, ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllot.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllot.WhAllotId)
                db.AddParameter("p_GRID_ID", pWarehouseAllot.GridId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllot.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllot.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllot.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseAllot.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_ALLOT", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllot.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If

            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
            End Try
            Return pWarehouseAllot
        End Function

        Public Shared Function GetWhAllotId(ByVal db As DBConnect, ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Try
                db.ClearParameters()
                db.AddParameter("p_TERMINAL_ID", pWarehouseAllot.TerminalId)
                db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllot.WhAllotId, ParameterDirection.Output)
                db.AddParameter("p_GRID_ID", pWarehouseAllot.GridId)
                db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllot.LineItemId)
                db.AddParameter("p_CREATED_BY", pWarehouseAllot.CreatedBy)
                db.AddParameter("p_CREATED_ON", pWarehouseAllot.CreatedOn)
                db.AddParameter("p_ErrorMsg", pWarehouseAllot.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_WAREHOUSE_ALLOT_ID", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pWarehouseAllot.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                pWarehouseAllot.WhAllotId = db.Parameters.Item("p_WH_ALLOT_ID").value.ToString
            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
            End Try
            Return pWarehouseAllot
        End Function

        '''' <summary>
        '''' Update Member Function to Update the New Record
        '''' </summary>
        '''' <param name="pWarehouseAllot"></param>
        '''' <returns>Return pWarehouseAllot Object</returns>
        '''' <remarks></remarks>
        ' '''
        'Public Shared Function Update(ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
        '    Dim db As New DBConnect
        '    Try
        '        db.BeginTransaction()
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pWarehouseAllot.TerminalId)
        '        db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllot.WhAllotId)
        '        db.AddParameter("p_GRID_ID", pWarehouseAllot.GridId)
        '        db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllot.LineItemId)
        '        db.AddParameter("p_CREATED_BY", pWarehouseAllot.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pWarehouseAllot.CreatedOn)
        '        db.AddParameter("p_ErrorMsg", pWarehouseAllot.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_ALLOT", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pWarehouseAllot.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '        If pWarehouseAllot.Errormsg <> Nothing Then
        '            db.RollbackTransaction()
        '        Else
        '            db.CommitTransaction()
        '        End If
        '    Catch ex As Exception
        '        pWarehouseAllot.Errormsg = ex.Message
        '        db.RollbackTransaction()
        '    End Try
        '    db.CloseDB()
        '    Return pWarehouseAllot
        'End Function

        '''' <summary>
        '''' Update Member Function to Update the New Record
        '''' </summary>
        '''' <param name="db"></param>
        '''' <param name="pWarehouseAllot"></param>
        '''' <returns>Return pWarehouseAllot Object</returns>
        '''' <remarks></remarks>
        ' '''
        'Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
        '    Try
        '        db.ClearParameters()
        '        db.AddParameter("p_TERMINAL_ID", pWarehouseAllot.TerminalId)
        '        db.AddParameter("p_WH_ALLOT_ID", pWarehouseAllot.WhAllotId)
        '        db.AddParameter("p_GRID_ID", pWarehouseAllot.GridId)
        '        db.AddParameter("p_LINE_ITEM_ID", pWarehouseAllot.LineItemId)
        '        db.AddParameter("p_CREATED_BY", pWarehouseAllot.CreatedBy)
        '        db.AddParameter("p_CREATED_ON", pWarehouseAllot.CreatedOn)
        '        db.AddParameter("p_ErrorMsg", pWarehouseAllot.Errormsg, ParameterDirection.Output)
        '        db.ExecuteScalar("UPDATE_PKG.SP_WAREHOUSE_ALLOT", CommandType.StoredProcedure)
        '        If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
        '            pWarehouseAllot.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
        '        End If
        '    Catch ex As Exception
        '        pWarehouseAllot.Errormsg = ex.Message
        '    End Try
        '    Return pWarehouseAllot
        'End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Friend Overloads Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                pWarehouseAllot.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WH_ALLOT_ID").ToString <> "" Then
                                pWarehouseAllot.WhAllotId = dbr("WH_ALLOT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_ID").ToString <> "" Then
                                pWarehouseAllot.GridId = dbr("GRID_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                pWarehouseAllot.LineItemId = dbr("LINE_ITEM_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_BY").ToString <> "" Then
                                pWarehouseAllot.CreatedBy = dbr("CREATED_BY")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("CREATED_ON").ToString <> "" Then
                                pWarehouseAllot.CreatedOn = dbr("CREATED_ON")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                End If
            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
            End Try
            Return pWarehouseAllot
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Friend Overloads Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrWarehouseAllot As ArrayList) As ArrayList
            Dim arrList As New ArrayList
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New WarehouseAllot
                        Try
                            If dbr("TERMINAL_ID").ToString <> "" Then
                                temp.TerminalId = dbr("TERMINAL_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("WH_ALLOT_ID").ToString <> "" Then
                                temp.WhAllotId = dbr("WH_ALLOT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("GRID_ID").ToString <> "" Then
                                temp.GridId = dbr("GRID_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("LINE_ITEM_ID").ToString <> "" Then
                                temp.LineItemId = dbr("LINE_ITEM_ID")
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
        Public Shared Function ReturnWarehouseAllotByLineItemId(ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_ALLOT_BY_LINE_ITEM_ID", pWarehouseAllot.LineItemId)
                pWarehouseAllot = pWarehouseAllot.ReturnObjectValues(dbr, pWarehouseAllot)
                dbr.Close()
            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseAllot
        End Function

        ''' <summary>
        ''' Preparing Return Object 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnWarehouseAllotId(ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_ALLOT_ID", "' '")
                pWarehouseAllot = pWarehouseAllot.ReturnObjectValues(dbr, pWarehouseAllot)
                dbr.Close()
            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pWarehouseAllot
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList By TerminalId, WhAllotId or LineItemId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnWarehouseAllotList(ByVal pWarehouseAllot As WarehouseAllot) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrWarehouseAllot As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_WAREHOUSE_ALLOT_BY_ID", pWarehouseAllot.TerminalId & "," & pWarehouseAllot.WhAllotId & "," & pWarehouseAllot.LineItemId)
                arrWarehouseAllot = pWarehouseAllot.ReturnObjectValuesList(dbr, arrWarehouseAllot)
                dbr.Close()
            Catch ex As Exception
                arrWarehouseAllot = Nothing
            End Try
            db.CloseDB()
            Return arrWarehouseAllot
        End Function

        Public Shared Function InsertWhAllot(ByVal pWarehouseAllot As WarehouseAllot) As WarehouseAllot
            Dim db As New DBConnect 'object:db for database connectivity from class:DBAccess
            Try
                db.BeginTransaction()
                If pWarehouseAllot.WhAllotId <= 0 Then
                    WarehouseAllot.GetWhAllotId(db, pWarehouseAllot)
                End If

                If pWarehouseAllot.WhAllotId > 0 Then
                    If pWarehouseAllot.Errormsg = "" AndAlso pWarehouseAllot.WhAllotId > 0 Then
                        For Each ijd As WarehouseAllot In pWarehouseAllot.WarehouseAllotList
                            ijd.WhAllotId = pWarehouseAllot.WhAllotId
                            WarehouseAllot.InsertTrnWarehouseAllot(db, ijd)
                            If ijd.Errormsg <> "" Then
                                Throw New Exception(ijd.Errormsg)
                            End If
                        Next

                        If pWarehouseAllot.Errormsg = "" AndAlso pWarehouseAllot.WhAllotId > 0 Then
                            For Each ijd As WarehouseAllotCont In pWarehouseAllot.WarehouseAllotContList
                                ijd.WhAllotId = pWarehouseAllot.WhAllotId
                                WarehouseAllotCont.InsertTrn(db, ijd)
                                If ijd.Errormsg <> "" Then
                                    Throw New Exception(ijd.Errormsg)
                                End If
                            Next
                        End If
                    Else
                        Throw New Exception(pWarehouseAllot.Errormsg)
                    End If
                Else
                    Throw New Exception(pWarehouseAllot.Errormsg)
                End If
                db.CommitTransaction()
            Catch ex As Exception
                pWarehouseAllot.Errormsg = ex.Message
                Try
                    db.RollbackTransaction()
                Catch ex1 As Exception
                End Try
                ' Rollback the transaction if any 
            End Try
            Return pWarehouseAllot
        End Function
    End Class

End Namespace
