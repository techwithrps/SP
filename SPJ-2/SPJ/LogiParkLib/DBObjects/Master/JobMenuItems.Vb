Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: JobMenuItems
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class JobMenuItems 
    
        Private lngJobId As Long ' Define Private Variable JobId With DataType As Long 
        Private lngMenuId As Double ' Define Private Variable MenuId With DataType As Long 
        Private strAddPermit As String ' Define Private Variable AddPermit With DataType As String 
        Private strEditPermit As String ' Define Private Variable EditPermit With DataType As String 
        Private strDeletePermit As String ' Define Private Variable DeletePermit With DataType As String 
        Private strSearchPermit As String ' Define Private Variable SearchPermit With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of JobId
        ''' </summary>
        ''' <value>lngJobId</value>
        ''' <returns> Return lngJobId</returns>
        ''' <remarks> Get or Set the Value of JobId  </remarks>
        '''
        Public Property JobId() as Long
            Get
                Return lngJobId
            End Get
            Set(ByVal value As Long)
                lngJobId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of MenuId
        ''' </summary>
        ''' <value>lngMenuId</value>
        ''' <returns> Return lngMenuId</returns>
        ''' <remarks> Get or Set the Value of MenuId  </remarks>
        '''
        Public Property MenuId() As Double
            Get
                Return lngMenuId
            End Get
            Set(ByVal value As Double)
                lngMenuId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of AddPermit
        ''' </summary>
        ''' <value>strAddPermit</value>
        ''' <returns> Return strAddPermit</returns>
        ''' <remarks> Get or Set the Value of AddPermit  </remarks>
        '''
        Public Property AddPermit() as String
            Get
                Return strAddPermit
            End Get
            Set(ByVal value As String)
                strAddPermit = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of EditPermit
        ''' </summary>
        ''' <value>strEditPermit</value>
        ''' <returns> Return strEditPermit</returns>
        ''' <remarks> Get or Set the Value of EditPermit  </remarks>
        '''
        Public Property EditPermit() as String
            Get
                Return strEditPermit
            End Get
            Set(ByVal value As String)
                strEditPermit = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of DeletePermit
        ''' </summary>
        ''' <value>strDeletePermit</value>
        ''' <returns> Return strDeletePermit</returns>
        ''' <remarks> Get or Set the Value of DeletePermit  </remarks>
        '''
        Public Property DeletePermit() as String
            Get
                Return strDeletePermit
            End Get
            Set(ByVal value As String)
                strDeletePermit = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of SearchPermit
        ''' </summary>
        ''' <value>strSearchPermit</value>
        ''' <returns> Return strSearchPermit</returns>
        ''' <remarks> Get or Set the Value of SearchPermit  </remarks>
        '''
        Public Property SearchPermit() as String
            Get
                Return strSearchPermit
            End Get
            Set(ByVal value As String)
                strSearchPermit = value
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
            lngJobId = 0 
            lngMenuId = 0 
            strAddPermit = ""
            strEditPermit = ""
            strDeletePermit = ""
            strSearchPermit = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pJobMenuItems"></param>
        ''' <returns>Return pJobMenuItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMenuItems.JobId)
                db.AddParameter("p_MENU_ID", pJobMenuItems.MenuId)
                db.AddParameter("p_ADD_PERMIT", pJobMenuItems.AddPermit)
                db.AddParameter("p_EDIT_PERMIT", pJobMenuItems.EditPermit)
                db.AddParameter("p_DELETE_PERMIT", pJobMenuItems.DeletePermit)
                db.AddParameter("p_SEARCH_PERMIT", pJobMenuItems.SearchPermit)
                db.AddParameter("p_ErrorMsg", pJobMenuItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_MENU_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMenuItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pJobMenuItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobMenuItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobMenuItems"></param>
        ''' <returns>Return pJobMenuItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMenuItems.JobId)
                db.AddParameter("p_MENU_ID", pJobMenuItems.MenuId)
                db.AddParameter("p_ADD_PERMIT", pJobMenuItems.AddPermit)
                db.AddParameter("p_EDIT_PERMIT", pJobMenuItems.EditPermit)
                db.AddParameter("p_DELETE_PERMIT", pJobMenuItems.DeletePermit)
                db.AddParameter("p_SEARCH_PERMIT", pJobMenuItems.SearchPermit)
                db.AddParameter("p_ErrorMsg", pJobMenuItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_JOB_MENU_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMenuItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pJobMenuItems.ErrorMsg = ex.Message
            End Try
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pJobMenuItems"></param>
        ''' <returns>Return pJobMenuItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMenuItems.JobId)
                db.AddParameter("p_MENU_ID", pJobMenuItems.MenuId)
                db.AddParameter("p_ADD_PERMIT", pJobMenuItems.AddPermit)
                db.AddParameter("p_EDIT_PERMIT", pJobMenuItems.EditPermit)
                db.AddParameter("p_DELETE_PERMIT", pJobMenuItems.DeletePermit)
                db.AddParameter("p_SEARCH_PERMIT", pJobMenuItems.SearchPermit)
                db.AddParameter("p_ErrorMsg", pJobMenuItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_MENU_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMenuItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pJobMenuItems.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pJobMenuItems.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pJobMenuItems"></param>
        ''' <returns>Return pJobMenuItems Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMenuItems.JobId)
                db.AddParameter("p_MENU_ID", pJobMenuItems.MenuId)
                db.AddParameter("p_ADD_PERMIT", pJobMenuItems.AddPermit)
                db.AddParameter("p_EDIT_PERMIT", pJobMenuItems.EditPermit)
                db.AddParameter("p_DELETE_PERMIT", pJobMenuItems.DeletePermit)
                db.AddParameter("p_SEARCH_PERMIT", pJobMenuItems.SearchPermit)
                db.AddParameter("p_ErrorMsg", pJobMenuItems.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_MENU_ITEMS", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMenuItems.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pJobMenuItems.ErrorMsg = ex.Message
                End Try
            Return pJobMenuItems
        End Function

        Public Shared Function DeleteTrnByJobCode(ByVal db As DBConnect, ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Try
                db.ClearParameters()
                db.AddParameter("p_JOB_ID", pJobMenuItems.JobId)
                db.AddParameter("p_MENU_ID", pJobMenuItems.MenuId)
                db.AddParameter("p_ADD_PERMIT", pJobMenuItems.AddPermit)
                db.AddParameter("p_EDIT_PERMIT", pJobMenuItems.EditPermit)
                db.AddParameter("p_DELETE_PERMIT", pJobMenuItems.DeletePermit)
                db.AddParameter("p_SEARCH_PERMIT", pJobMenuItems.SearchPermit)
                db.AddParameter("p_ErrorMsg", pJobMenuItems.Errormsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_JOB_MENU_ITEMS_DELETE", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pJobMenuItems.Errormsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
            Catch ex As Exception
                pJobMenuItems.Errormsg = ex.Message
            End Try
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                PJobMenuItems.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                PJobMenuItems.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADD_PERMIT").ToString <> "" Then
                                PJobMenuItems.AddPermit = dbr("ADD_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EDIT_PERMIT").ToString <> "" Then
                                PJobMenuItems.EditPermit = dbr("EDIT_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DELETE_PERMIT").ToString <> "" Then
                                PJobMenuItems.DeletePermit = dbr("DELETE_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEARCH_PERMIT").ToString <> "" Then
                                PJobMenuItems.SearchPermit = dbr("SEARCH_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pJobMenuItems.ErrorMsg = ex.Message
            End Try
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrJobMenuItems As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New JobMenuItems
                        Try
                            If dbr("JOB_ID").ToString <> "" Then
                                temp.JobId = dbr("JOB_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                temp.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("ADD_PERMIT").ToString <> "" Then
                                temp.AddPermit = dbr("ADD_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("EDIT_PERMIT").ToString <> "" Then
                                temp.EditPermit = dbr("EDIT_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DELETE_PERMIT").ToString <> "" Then
                                temp.DeletePermit = dbr("DELETE_PERMIT")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("SEARCH_PERMIT").ToString <> "" Then
                                temp.SearchPermit = dbr("SEARCH_PERMIT")
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
        ''' Preparing Return Object ArrayList By JobId and MenuId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnJobMenuItems(ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader

            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MENU_ITEMS_BY_ID", pJobMenuItems.JobId & "," & pJobMenuItems.MenuId)
                pJobMenuItems = ReturnObjectValues(dbr, pJobMenuItems)
                dbr.Close()
            Catch ex As Exception
                pJobMenuItems.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList of JobId and All MenuId By JobId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnJobMenuItemsByIdWithAllMenu(ByVal pJobMenuItems As JobMenuItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobMenuItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MENU_ITEMS_ALL_JOB_ID", pJobMenuItems.JobId)
                arrJobMenuItems = ReturnObjectValuesList(dbr, arrJobMenuItems)
                dbr.Close()
            Catch ex As Exception
                arrJobMenuItems = Nothing
            End Try
            db.CloseDB()
            Return arrJobMenuItems
        End Function

        Public Shared Function ReturnJobMenuItemsJobIdMenuCode(ByVal pJobMenuItems As JobMenuItems) As JobMenuItems
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MENU_ITEMS_BY_ID_CODE", pJobMenuItems.JobId & "," & pJobMenuItems.MenuId)
                pJobMenuItems = ReturnObjectValues(dbr, pJobMenuItems)
                dbr.Close()
            Catch ex As Exception
                pJobMenuItems.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pJobMenuItems
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList 
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        Public Shared Function ReturnJobMenuItemsList(ByVal pJobMenuItems As JobMenuItems) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrJobMenuItems As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_JOB_MENU_ITEMS_BY_ALL", " ")
                arrJobMenuItems = ReturnObjectValuesList(dbr, arrJobMenuItems)
                dbr.Close()
            Catch ex As Exception
                arrJobMenuItems = Nothing
            End Try
            db.CloseDB()
            Return arrJobMenuItems
        End Function

    End Class
End Namespace
