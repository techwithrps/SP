Imports LogiParkLib.DBConnection
     
Namespace LogiParkObjects
     
    ''' <summary>
    ''' @Project/Product Name:  LogiPark :: Logistic Park Management System 
    ''' @Version	: Version 1.0.0.0
    ''' @Module/Class Name	: MenuItemMaster
    ''' @author	: Amit K. Singh- 2/11/2011
    ''' </summary>
    ''' <remarks> </remarks>
    '''
    Public Class MenuItemMaster 
    
        Private dblMenuId As Double ' Define Private Variable MenuId With DataType As Double 
        Private dblParentId As Double ' Define Private Variable ParentId With DataType As Double 
        Private dblModuleId As Double ' Define Private Variable ModuleId With DataType As Double 
        Private strUrl As String ' Define Private Variable Url With DataType As String 
        Private strTitle As String ' Define Private Variable Title With DataType As String 
        Private strDescription As String ' Define Private Variable Description With DataType As String 
        Private strErrormsg As String ' Define Private Variable Errormsg With DataType As String 

                    
        ''' <summary>
        ''' Get or Set the Value of MenuId
        ''' </summary>
        ''' <value>dblMenuId</value>
        ''' <returns> Return dblMenuId</returns>
        ''' <remarks> Get or Set the Value of MenuId  </remarks>
        '''
        Public Property MenuId() as Double
            Get
                Return dblMenuId
            End Get
            Set(ByVal value As Double)
                dblMenuId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ParentId
        ''' </summary>
        ''' <value>dblParentId</value>
        ''' <returns> Return dblParentId</returns>
        ''' <remarks> Get or Set the Value of ParentId  </remarks>
        '''
        Public Property ParentId() as Double
            Get
                Return dblParentId
            End Get
            Set(ByVal value As Double)
                dblParentId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of ModuleId
        ''' </summary>
        ''' <value>dblModuleId</value>
        ''' <returns> Return dblModuleId</returns>
        ''' <remarks> Get or Set the Value of ModuleId  </remarks>
        '''
        Public Property ModuleId() as Double
            Get
                Return dblModuleId
            End Get
            Set(ByVal value As Double)
                dblModuleId = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Url
        ''' </summary>
        ''' <value>strUrl</value>
        ''' <returns> Return strUrl</returns>
        ''' <remarks> Get or Set the Value of Url  </remarks>
        '''
        Public Property Url() as String
            Get
                Return strUrl
            End Get
            Set(ByVal value As String)
                strUrl = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Title
        ''' </summary>
        ''' <value>strTitle</value>
        ''' <returns> Return strTitle</returns>
        ''' <remarks> Get or Set the Value of Title  </remarks>
        '''
        Public Property Title() as String
            Get
                Return strTitle
            End Get
            Set(ByVal value As String)
                strTitle = value
            End Set
        End Property

                    
        ''' <summary>
        ''' Get or Set the Value of Description
        ''' </summary>
        ''' <value>strDescription</value>
        ''' <returns> Return strDescription</returns>
        ''' <remarks> Get or Set the Value of Description  </remarks>
        '''
        Public Property Description() as String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
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
            dblMenuId = 0.0 
            dblParentId = 0.0 
            dblModuleId = 0.0 
            strUrl = ""
            strTitle = ""
            strDescription = ""
            strErrormsg = ""
        End Sub 

        ''' <summary>
        ''' Insert Member Function to Insert the New Record
        ''' </summary>
        ''' <param name="pMenuItemMaster"></param>
        ''' <returns>Return pMenuItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Insert(ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MENU_ID", pMenuItemMaster.MenuId)
                db.AddParameter("p_PARENT_ID", pMenuItemMaster.ParentId)
                db.AddParameter("p_MODULE_ID", pMenuItemMaster.ModuleId)
                db.AddParameter("p_URL", pMenuItemMaster.Url)
                db.AddParameter("p_TITLE", pMenuItemMaster.Title)
                db.AddParameter("p_DESCRIPTION", pMenuItemMaster.Description)
                db.AddParameter("p_ErrorMsg", pMenuItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MENU_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMenuItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
                If pMenuItemMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMenuItemMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Insert Member Function to Insert the New Record With Transaction
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMenuItemMaster"></param>
        ''' <returns>Return pMenuItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function InsertTrn(ByVal db As DBConnect, ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_MENU_ID", pMenuItemMaster.MenuId)
                db.AddParameter("p_PARENT_ID", pMenuItemMaster.ParentId)
                db.AddParameter("p_MODULE_ID", pMenuItemMaster.ModuleId)
                db.AddParameter("p_URL", pMenuItemMaster.Url)
                db.AddParameter("p_TITLE", pMenuItemMaster.Title)
                db.AddParameter("p_DESCRIPTION", pMenuItemMaster.Description)
                db.AddParameter("p_ErrorMsg", pMenuItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("INSERT_PKG.SP_MENU_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMenuItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                
            Catch ex As Exception
                pMenuItemMaster.ErrorMsg = ex.Message
            End Try
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="pMenuItemMaster"></param>
        ''' <returns>Return pMenuItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function Update(ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Dim db As New DBConnect
            Try
                db.BeginTransaction()
                db.ClearParameters()
                db.AddParameter("p_MENU_ID", pMenuItemMaster.MenuId)
                db.AddParameter("p_PARENT_ID", pMenuItemMaster.ParentId)
                db.AddParameter("p_MODULE_ID", pMenuItemMaster.ModuleId)
                db.AddParameter("p_URL", pMenuItemMaster.Url)
                db.AddParameter("p_TITLE", pMenuItemMaster.Title)
                db.AddParameter("p_DESCRIPTION", pMenuItemMaster.Description)
                db.AddParameter("p_ErrorMsg", pMenuItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MENU_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMenuItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                If pMenuItemMaster.ErrorMsg <> Nothing
                    db.RollbackTransaction()
                Else
                    db.CommitTransaction()
                End If
            Catch ex As Exception
                pMenuItemMaster.ErrorMsg = ex.Message
                db.RollbackTransaction()
            End Try
            db.CloseDB()
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Update Member Function to Update the New Record
        ''' </summary>
        ''' <param name="db"></param>
        ''' <param name="pMenuItemMaster"></param>
        ''' <returns>Return pMenuItemMaster Object</returns>
        ''' <remarks></remarks>
        '''
        Public Shared Function UpdateTrn(ByVal db As DBConnect, ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Try
                db.ClearParameters()
                db.AddParameter("p_MENU_ID", pMenuItemMaster.MenuId)
                db.AddParameter("p_PARENT_ID", pMenuItemMaster.ParentId)
                db.AddParameter("p_MODULE_ID", pMenuItemMaster.ModuleId)
                db.AddParameter("p_URL", pMenuItemMaster.Url)
                db.AddParameter("p_TITLE", pMenuItemMaster.Title)
                db.AddParameter("p_DESCRIPTION", pMenuItemMaster.Description)
                db.AddParameter("p_ErrorMsg", pMenuItemMaster.ErrorMsg, ParameterDirection.Output)
                db.ExecuteScalar("UPDATE_PKG.SP_MENU_ITEM_MASTER", CommandType.StoredProcedure)
                If db.Parameters.Item("p_ErrorMsg").value.ToString <> Nothing Then
                    pMenuItemMaster.ErrorMsg = db.Parameters.Item("p_ErrorMsg").value.ToString
                End If
                Catch ex As Exception
                    pMenuItemMaster.ErrorMsg = ex.Message
                End Try
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValues Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property</remarks>
        '''
        Private Shared Function ReturnObjectValues(ByVal dbr As OleDb.OleDbDataReader, ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                PMenuItemMaster.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARENT_ID").ToString <> "" Then
                                PMenuItemMaster.ParentId = dbr("PARENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                PMenuItemMaster.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("URL").ToString <> "" Then
                                PMenuItemMaster.Url = dbr("URL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TITLE").ToString <> "" Then
                                PMenuItemMaster.Title = dbr("TITLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                PMenuItemMaster.Description = dbr("DESCRIPTION")
                            End If
                        Catch ex1 As Exception
                        End Try
                    End While
                end If
            Catch ex As Exception
                pMenuItemMaster.ErrorMsg = ex.Message
            End Try
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Preparing ReturnObjectValuesList Member Function
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as List Of object</remarks>
        '''
        Private Shared Function ReturnObjectValuesList(ByVal dbr As OleDb.OleDbDataReader, ByVal arrMenuItemMaster As ArrayList) As ArrayList
            Dim arrList As New ArrayList 
            Try
                If dbr.HasRows Then
                    While dbr.Read
                        Dim temp As New MenuItemMaster
                        Try
                            If dbr("MENU_ID").ToString <> "" Then
                                temp.MenuId = dbr("MENU_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("PARENT_ID").ToString <> "" Then
                                temp.ParentId = dbr("PARENT_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("MODULE_ID").ToString <> "" Then
                                temp.ModuleId = dbr("MODULE_ID")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("URL").ToString <> "" Then
                                temp.Url = dbr("URL")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("TITLE").ToString <> "" Then
                                temp.Title = dbr("TITLE")
                            End If
                        Catch ex1 As Exception
                        End Try
                        Try
                            If dbr("DESCRIPTION").ToString <> "" Then
                                temp.Description = dbr("DESCRIPTION")
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
        ''' Preparing Return Object By MenuId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMenuItemMaster(ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_ITEM_MASTER_BY_ID", pMenuItemMaster.MenuId)
                pMenuItemMaster = ReturnObjectValues(dbr, pMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                pMenuItemMaster.ErrorMsg = ex.Message
            End Try
            db.CloseDB()
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object ArrayList By LoginUserId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMenuItemMasterListByLoginUserId(ByVal pLoginUserId As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMenuItemMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_ITEM_MASTER_BY_USER_ID", "'" & pLoginUserId & "'")
                arrMenuItemMaster = ReturnObjectValuesList(dbr, arrMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                arrMenuItemMaster = Nothing
            End Try
            db.CloseDB()
            Return arrMenuItemMaster
        End Function


        ''' <summary>
        ''' Preparing Return Object ArrayList By ModuleId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMenuItemMasterAllListEmailConfigList(ByVal pMenuItemMaster As MenuItemMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMenuItemMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_ITEM_MASTER_ALL_EMAIL", pMenuItemMaster.ModuleId)
                arrMenuItemMaster = ReturnObjectValuesList(dbr, arrMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                arrMenuItemMaster = Nothing
            End Try
            db.CloseDB()
            Return arrMenuItemMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object By URL
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMenuItemMasterByURL(ByVal pMenuItemMaster As MenuItemMaster) As MenuItemMaster
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_ITEM_MASTER_BY_URL", "'" & pMenuItemMaster.Url & "'")
                pMenuItemMaster = ReturnObjectValues(dbr, pMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                pMenuItemMaster.Errormsg = ex.Message
            End Try
            db.CloseDB()
            Return pMenuItemMaster
        End Function

        ''' <summary>
        ''' Preparing Return Object By URL
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as object</remarks>
        '''
        Public Shared Function ReturnMenuItemMasterAllListEmailConfig(ByVal pMenuItemMaster As MenuItemMaster) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMenuItemMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_ITEM_MASTER_ALL_EMAIL", "' ' ")
                arrMenuItemMaster = ReturnObjectValuesList(dbr, arrMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                arrMenuItemMaster = Nothing
            End Try
            db.CloseDB()
            Return arrMenuItemMaster

        End Function
        ''' <summary>
        ''' Preparing Return Object ArrayList By LoginUserId
        ''' </summary>
        ''' <remarks>Read The values of Column and Assign it to Property and Return as ArrayList of object</remarks>
        '''
        Public Shared Function ReturnMenuItemMasterListByLoginUserIdCR(ByVal pLoginUserId As String) As ArrayList
            Dim db As New DBConnect
            Dim dbr As OleDb.OleDbDataReader
            Dim arrMenuItemMaster As New ArrayList
            Try
                db.ClearParameters()
                dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_MENU_DETAILS_CR", "'" & pLoginUserId & "'")
                arrMenuItemMaster = ReturnObjectValuesList(dbr, arrMenuItemMaster)
                dbr.Close()
            Catch ex As Exception
                arrMenuItemMaster = Nothing
            End Try
            db.CloseDB()
            Return arrMenuItemMaster
        End Function

    End Class
End Namespace
